using System;

/*
 * Copyright 2006-2018 Prowide
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace com.prowidesoftware.swift.io.parser
{



	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;
	using Document = org.w3c.dom.Document;
	using Node = org.w3c.dom.Node;
	using NodeList = org.w3c.dom.NodeList;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;
	using SwiftBlock1 = com.prowidesoftware.swift.model.SwiftBlock1;
	using SwiftBlock2 = com.prowidesoftware.swift.model.SwiftBlock2;
	using SwiftBlock2Input = com.prowidesoftware.swift.model.SwiftBlock2Input;
	using SwiftBlock2Output = com.prowidesoftware.swift.model.SwiftBlock2Output;
	using SwiftBlock3 = com.prowidesoftware.swift.model.SwiftBlock3;
	using SwiftBlock4 = com.prowidesoftware.swift.model.SwiftBlock4;
	using SwiftBlock5 = com.prowidesoftware.swift.model.SwiftBlock5;
	using SwiftBlockUser = com.prowidesoftware.swift.model.SwiftBlockUser;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using SwiftTagListBlock = com.prowidesoftware.swift.model.SwiftTagListBlock;
	using Tag = com.prowidesoftware.swift.model.Tag;
	using UnparsedTextList = com.prowidesoftware.swift.model.UnparsedTextList;
	using Field = com.prowidesoftware.swift.model.field.Field;

	/// <summary>
	/// This is the main parser for WIFE's XML internal representation.<br>
	/// The supported XML format is consider <i>internal</i> because it is an ad-hoc
	/// defined XML structure for Swift messages, so it's not the SWIFT XML
	/// Standard for FIN Messages.<br>
	/// <br>
	/// 
	/// This implementation should be used by calling some of the the conversion
	/// services.
	/// </summary>
	/// <seealso cref= com.prowidesoftware.swift.io.IConversionService
	/// @since 5.0
	/// @author www.prowidesoftware.com </seealso>
	public class XMLParser
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(XMLParser).FullName);

		private const string UNPARSEDTEXTS = "unparsedtexts";

		/// <summary>
		/// Given a String containing a message in its WIFE internal XML
		/// representation, returns a SwiftMessage object.
		/// If there is any error during conversion this method returns null </summary>
		/// <param name="xml"> the string containing the XML to parse </param>
		/// <returns> the XML parsed into a SwiftMessage object
		/// </returns>
		/// <seealso cref= com.prowidesoftware.swift.io.IConversionService#getMessageFromXML(java.lang.String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.SwiftMessage parse(final String xml)
		public virtual SwiftMessage parse(string xml)
		{
			Validate.notNull(xml);
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.parsers.DocumentBuilder db = javax.xml.parsers.DocumentBuilderFactory.newInstance().newDocumentBuilder();
				DocumentBuilder db = DocumentBuilderFactory.newInstance().newDocumentBuilder();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Document doc = db.parse(new java.io.ByteArrayInputStream(xml.getBytes()));
				Document doc = db.parse(new ByteArrayInputStream(xml.GetBytes()));
				return createMessage(doc);
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
			catch (Exception e)
			{
				log.log(Level.WARNING, "Error parsing XML", e);
				return null;
			}
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// </summary>
		/// <param name="doc">
		///            Document object containing a message in XML format </param>
		/// <returns> SwiftMessage object populated with the given XML message data </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.SwiftMessage createMessage(final org.w3c.dom.Document doc)
		private SwiftMessage createMessage(Document doc)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.NodeList messageNL = doc.getElementsByTagName("message");
			NodeList messageNL = doc.getElementsByTagName("message");

			if (messageNL.Length == 1)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node message = messageNL.item(0);
				Node message = messageNL.item(0);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftMessage m = new com.prowidesoftware.swift.model.SwiftMessage(false);
				SwiftMessage m = new SwiftMessage(false);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.NodeList blocksNL = message.getChildNodes();
				NodeList blocksNL = message.ChildNodes;
				if (log.isLoggable(Level.FINE))
				{
					log.fine("blocks in message: " + blocksNL.Length);
				}

				for (int i = 0; i < blocksNL.Length; i++)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node blockNode = blocksNL.item(i);
					Node blockNode = blocksNL.item(i);
					if (log.isLoggable(Level.FINE))
					{
						log.fine("evaluating node " + blockNode.NodeName);
					}
					if (blockNode.NodeType == Node.ELEMENT_NODE)
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String blockName = blockNode.getNodeName();
						string blockName = blockNode.NodeName;

						if ("block1".Equals(blockName, StringComparison.CurrentCultureIgnoreCase))
						{
							m.Block1 = getBlock1FromNode(blockNode);
						}
						else if ("block2".Equals(blockName, StringComparison.CurrentCultureIgnoreCase))
						{
							m.Block2 = getBlock2FromNode(blockNode);
						}
						else if (UNPARSEDTEXTS.Equals(blockName, StringComparison.CurrentCultureIgnoreCase))
						{
							// unparsed texts at <message> level
							m.UnparsedTexts = getUnparsedTextsFromNode(blockNode);
						}
						else
						{
							// blocks 3, 4, 5 or user blocks
							m.addBlock(getTagListBlockFromNode(blockNode));
						}
					}
				} // end block list iteration
				return m;
			}
			else
			{
				throw new System.ArgumentException("<message> tag not found");
			}
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// Given the &lt;block1&gt; node in the XML tree, returns the SwiftBlock1 object.
		/// </summary>
		/// <param name="blockNode"> Node object of the &lt;block1&gt; tag in the XML message </param>
		/// <returns> SwiftBlock1 object populated with the given portion of the XML message </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.SwiftBlock1 getBlock1FromNode(final org.w3c.dom.Node blockNode)
		private SwiftBlock1 getBlock1FromNode(Node blockNode)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.NodeList fields = blockNode.getChildNodes();
			NodeList fields = blockNode.ChildNodes;
			if (log.isLoggable(Level.FINE))
			{
				log.fine(fields.Length + " children in <block1>");
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftBlock1 b1 = new com.prowidesoftware.swift.model.SwiftBlock1();
			SwiftBlock1 b1 = new SwiftBlock1();

			for (int i = 0; i < fields.Length; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node n = fields.item(i);
				Node n = fields.item(i);
				if ("APPLICATIONID".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b1.ApplicationId = getText(n);
				}
				else if ("SERVICEID".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b1.ServiceId = getText(n);
				}
				else if ("LOGICALTERMINAL".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b1.LogicalTerminal = getText(n);
				}
				else if ("SESSIONNUMBER".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b1.SessionNumber = getText(n);
				}
				else if ("SEQUENCENUMBER".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b1.SequenceNumber = getText(n);
				}
				else if (UNPARSEDTEXTS.Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b1.UnparsedTexts = getUnparsedTextsFromNode(n);
				}
			}

			return b1;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String getText(final org.w3c.dom.Node n)
		private string getText(Node n)
		{
			string text = null;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node c = n.getFirstChild();
			Node c = n.FirstChild;
			if (c != null)
			{
				if (c.NodeType == Node.TEXT_NODE)
				{
					text = c.NodeValue.Trim();
				}
				else
				{
					log.warning("Node is not TEXT_NODE: " + c);
				}
			}
			return text;
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// Given the &lt;block2&gt; node in the XML tree, returns the SwiftBlock1 object.
		/// The method checks for the "type" attribute in the &lt;block2&gt; tag and
		/// returns a SwiftBlock2Input or SwiftBlock2Output.
		/// </summary>
		/// <param name="blockNode"> Node object of the &lt;block2&gt; tag in the XML message </param>
		/// <returns> SwiftBlock2 object populated with the given portion of the XML message </returns>
		/// <seealso cref= #getBlock2InputFromNode(Node) </seealso>
		/// <seealso cref= #getBlock2OutputFromNode(Node) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.SwiftBlock2 getBlock2FromNode(final org.w3c.dom.Node blockNode)
		private SwiftBlock2 getBlock2FromNode(Node blockNode)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String type = getNodeAttribute(blockNode, "type");
			string type = getNodeAttribute(blockNode, "type");

			if (type == null)
			{
				log.severe("atrribute 'type' was expected but not found at <block2> xml tag");
				return null;
			}
			else if ("input".Equals(type))
			{
				return getBlock2InputFromNode(blockNode);
			}
			else if ("output".Equals(type))
			{
				return getBlock2OutputFromNode(blockNode);
			}
			else
			{
				log.severe("expected 'input' or 'output' value for 'type' atribute at <block2> xml tag, and found: " + type);
				return null;
			}
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// Given the &lt;block2 type="input"&gt; node in the XML tree, returns the
		/// SwiftBlock2Input object.
		/// </summary>
		/// <param name="blockNode"> Node object of the &lt;block2&gt; tag in the XML message </param>
		/// <returns> SwiftBlock2Input object populated with the given portion of the XML message </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.SwiftBlock2Input getBlock2InputFromNode(final org.w3c.dom.Node blockNode)
		private SwiftBlock2Input getBlock2InputFromNode(Node blockNode)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.NodeList fields = blockNode.getChildNodes();
			NodeList fields = blockNode.ChildNodes;
			if (log.isLoggable(Level.FINE))
			{
				log.fine(fields.Length + " childrens in <block2 type=\"input\">");
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftBlock2Input b2 = new com.prowidesoftware.swift.model.SwiftBlock2Input();
			SwiftBlock2Input b2 = new SwiftBlock2Input();

			for (int i = 0; i < fields.Length; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node n = fields.item(i);
				Node n = fields.item(i);
				if ("MESSAGETYPE".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.MessageType = getText(n);
				}
				else if ("RECEIVERADDRESS".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.ReceiverAddress = getText(n);
				}
				else if ("MESSAGEPRIORITY".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.MessagePriority = getText(n);
				}
				else if ("DELIVERYMONITORING".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.DeliveryMonitoring = getText(n);
				}
				else if ("OBSOLESCENCEPERIOD".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.ObsolescencePeriod = getText(n);
				}
				else if (UNPARSEDTEXTS.Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.UnparsedTexts = getUnparsedTextsFromNode(n);
				}
			}

			return b2;
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// Given the &lt;block2 type="output" node in the XML tree, returns the
		/// SwiftBlock2Output object.
		/// </summary>
		/// <param name="blockNode"> Node object of the &lt;block2&gt; tag in the XML message </param>
		/// <returns> SwiftBlock2Output object populated with the given portion of the XML message </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.SwiftBlock2Output getBlock2OutputFromNode(final org.w3c.dom.Node blockNode)
		private SwiftBlock2Output getBlock2OutputFromNode(Node blockNode)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.NodeList fields = blockNode.getChildNodes();
			NodeList fields = blockNode.ChildNodes;
			if (log.isLoggable(Level.FINE))
			{
				log.fine(fields.Length + " childrens in <block2 type=\"output\">");
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftBlock2Output b2 = new com.prowidesoftware.swift.model.SwiftBlock2Output();
			SwiftBlock2Output b2 = new SwiftBlock2Output();

			for (int i = 0; i < fields.Length; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node n = fields.item(i);
				Node n = fields.item(i);
				if ("MESSAGETYPE".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.MessageType = getText(n);
				}
				else if ("SENDERINPUTTIME".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.SenderInputTime = getText(n);
				}
				else if ("MIRDATE".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.MIRDate = getText(n);
				}
				else if ("MIRLOGICALTERMINAL".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.MIRLogicalTerminal = getText(n);
				}
				else if ("MIRSESSIONNUMBER".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.MIRSessionNumber = getText(n);
				}
				else if ("MIRSEQUENCENUMBER".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.MIRSequenceNumber = getText(n);
				}
				else if ("RECEIVEROUTPUTDATE".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.ReceiverOutputDate = getText(n);
				}
				else if ("RECEIVEROUTPUTTIME".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.ReceiverOutputTime = getText(n);
				}
				else if ("MESSAGEPRIORITY".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.MessagePriority = getText(n);
				}
				else if (UNPARSEDTEXTS.Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b2.UnparsedTexts = getUnparsedTextsFromNode(n);
				}
			}

			return b2;
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// Given the &lt;block3&gt;, &lt;block4&gt;, &lt;block5&gt; or &lt;block&gt; (user block) node in
		/// the XML tree, returns the corresponding SwiftTagListBlock object
		/// populated with the given portion of the XML message.
		/// </summary>
		/// <param name="blockNode"> Node object of the &lt;block3&gt;, &lt;block4&gt;, &lt;block5&gt; or &lt;block&gt; tag in the XML message </param>
		/// <returns> SwiftTagListBlock object populated with the given portion of the XML message </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.SwiftTagListBlock getTagListBlockFromNode(final org.w3c.dom.Node blockNode)
		private SwiftTagListBlock getTagListBlockFromNode(Node blockNode)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String blockName = blockNode.getNodeName();
			string blockName = blockNode.NodeName;
			SwiftTagListBlock b;
			if ("block3".Equals(blockName, StringComparison.CurrentCultureIgnoreCase))
			{
				b = new SwiftBlock3();
			}
			else if ("block4".Equals(blockName, StringComparison.CurrentCultureIgnoreCase))
			{
				b = new SwiftBlock4();
			}
			else if ("block5".Equals(blockName, StringComparison.CurrentCultureIgnoreCase))
			{
				b = new SwiftBlock5();
			}
			else if ("block".Equals(blockName, StringComparison.CurrentCultureIgnoreCase))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String name = getNodeAttribute(blockNode, "name");
				string name = getNodeAttribute(blockNode, "name");
				if (name != null)
				{
					b = new SwiftBlockUser(name);
				}
				else
				{
					b = new SwiftBlockUser();
				}
			}
			else
			{
				return null;
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.NodeList fields = blockNode.getChildNodes();
			NodeList fields = blockNode.ChildNodes;
			if (log.isLoggable(Level.FINE))
			{
				log.fine(fields.Length + " children in tag list " + blockName);
			}

			for (int j = 0; j < fields.Length; j++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node t = fields.item(j);
				Node t = fields.item(j);
				if ("tag".Equals(t.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.Tag tag = getTag(t);
					Tag tag = getTag(t);
					b.append(tag);
				}
				else if ("field".Equals(t.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field field = getField(t);
						Field field = getField(t);
						b.append(field);
				}
				else if (UNPARSEDTEXTS.Equals(t.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					b.UnparsedTexts = getUnparsedTextsFromNode(t);
				}
			}

			return b;
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// Parses the given &lt;tag&gt; Node and returns a Tag object containing data from
		/// the expected &lt;name&gt; and &lt;value&gt; tags. If name or value are not found as
		/// children of the given node, the Tag object is returned with empty values.
		/// </summary>
		/// <param name="t"> the XML node to parse for name-value pair </param>
		/// <returns> a Tag object containing the name and value of the given XML node. </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.Tag getTag(final org.w3c.dom.Node t)
		private Tag getTag(Node t)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.Tag tag = new com.prowidesoftware.swift.model.Tag();
			Tag tag = new Tag();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.NodeList children = t.getChildNodes();
			NodeList children = t.ChildNodes;
			for (int i = 0; i < children.Length; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node n = children.item(i);
				Node n = children.item(i);

				/*
				 * soportar ambas versiones de xml automagicamente
				 */

				if ("name".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					tag.Name = getText(n);
				}
				if ("value".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					string text = getText(n);
					//normalize line feeds (DOM parser removes carriage return characters from original XML file)
					text = StringUtils.replace(text, "\n", FINWriterVisitor.SWIFT_EOL);
					tag.Value = text;
				}
				else if (UNPARSEDTEXTS.Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					tag.UnparsedTexts = getUnparsedTextsFromNode(n);
				}
			}
			return tag;
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// Parses the given &gt;field&lt; Node and returns a Field object containing data from
		/// the expected &lt;name&gt; and &lt;component&gt; inner elements. 
		/// If &lt;name&gt; element is not set it will return null. Otherwise it will return a Field
		/// instance filled with content from &lt;component&gt; elements.
		/// </summary>
		/// <param name="t"> the XML node to parse for name-value pair </param>
		/// <returns> a Field object or null if "name" element is not present </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.field.Field getField(final org.w3c.dom.Node t)
		private Field getField(Node t)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.NodeList children = t.getChildNodes();
			NodeList children = t.ChildNodes;
			string name = null;
			for (int i = 0; i < children.Length; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node n = children.item(i);
				Node n = children.item(i);
				if ("name".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					name = getText(n);
					break;
				}
			}
			if (name != null)
			{
				Field field = Field.getField(name, null);
				for (int i = 0; i < children.Length; i++)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node n = children.item(i);
					Node n = children.item(i);
					if ("component".Equals(n.NodeName, StringComparison.CurrentCultureIgnoreCase))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String number = getNodeAttribute(n, "number");
						string number = getNodeAttribute(n, "number");
						if (StringUtils.isNumeric(number))
						{
							string text = getText(n);
							//normalize line feeds (DOM parser removes carriage return characters from original XML file)
							text = StringUtils.replace(text, "\n", FINWriterVisitor.SWIFT_EOL);
							field.setComponent(Convert.ToInt32(number), text);
						}
					}
				}
				return field;
			}
			return null;
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// Given the &lt;unparsedtexts&gt; node in the XML tree, returns an
		/// UnparsedTextList object populated with the contents of the <text> child
		/// tags of &lt;unparsedtexts&gt;.
		/// </summary>
		/// <param name="blockNode"> Node object of the &lt;unparsedtexts&gt; tag in the XML message </param>
		/// <returns> UnparsedTextList object populated with the given &lt;text&gt; tags content of the &lt;unparsedtexts&gt; </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.UnparsedTextList getUnparsedTextsFromNode(final org.w3c.dom.Node blockNode)
		private UnparsedTextList getUnparsedTextsFromNode(Node blockNode)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.UnparsedTextList unparsedTexts = new com.prowidesoftware.swift.model.UnparsedTextList();
			UnparsedTextList unparsedTexts = new UnparsedTextList();

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.NodeList texts = blockNode.getChildNodes();
			NodeList texts = blockNode.ChildNodes;
			if (log.isLoggable(Level.FINE))
			{
				log.fine(texts.Length + " children in <unparsedtexts>");
			}
			for (int j = 0; j < texts.Length; j++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node t = texts.item(j);
				Node t = texts.item(j);
				if ("text".Equals(t.NodeName, StringComparison.CurrentCultureIgnoreCase))
				{
					unparsedTexts.addText(getText(t));
				}
			}
			return unparsedTexts;
		}

		/// <summary>
		/// Helper method for XML representation parsing.<br>
		/// Gets the value of an expected attribute in a Node.
		/// </summary>
		/// <param name="n"> Node to analyze to find the attribute </param>
		/// <param name="attributeName"> the attribute name expected in the analyzed Node n </param>
		/// <returns> the value of the attribute expected, or null if the attribute was not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String getNodeAttribute(final org.w3c.dom.Node n, final String attributeName)
		private string getNodeAttribute(Node n, string attributeName)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Node attr = n.getAttributes().getNamedItem(attributeName);
			Node attr = n.Attributes.getNamedItem(attributeName);
			if ((attr == null) || !attr.NodeName.Equals(attributeName))
			{
				return null;
			}
			else
			{
				return attr.NodeValue;
			}
		}
	}

}