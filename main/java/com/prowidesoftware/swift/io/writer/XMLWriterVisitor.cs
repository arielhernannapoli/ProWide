using System;
using System.Collections.Generic;
using System.Text;

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
namespace com.prowidesoftware.swift.io.writer
{

	using com.prowidesoftware.swift.model;
	using Field = com.prowidesoftware.swift.model.field.Field;
	using IMessageVisitor = com.prowidesoftware.swift.utils.IMessageVisitor;
	using StringUtils = org.apache.commons.lang3.StringUtils;


	/// <summary>
	/// Main class for XML generation, that is called from <seealso cref="SwiftMessage#visit(IMessageVisitor)"/>.
	/// Presence of blocks is checked by the calling class so the methods below asume that blocks are not null.
	/// 
	/// @author www.prowidesoftware.com
	/// </summary>
	public class XMLWriterVisitor : IMessageVisitor
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(XMLWriterVisitor).FullName);

		private static readonly string EOL = System.Properties.getProperty("line.separator", "\n");

		private Writer writer;

		private bool useField;

		/// <summary>
		/// Constructor for XMLWriteVisitor from a Writer object
		/// Same as <code>XMLWriterVisitor(writer, false)</code> </summary>
		/// <param name="writer"> </param>
		public XMLWriterVisitor(Writer writer)
		{
			this.writer = writer;
		}

		/// 
		/// <param name="writer"> </param>
		/// <param name="useField"> use <seealso cref="Field"/> for serialization, instead of Tag </param>
		public XMLWriterVisitor(Writer writer, bool useField)
		{
			this.writer = writer;
			this.useField = useField;
		}

		////////////////////////////////////////////////////////////
		//
		// MESSAGE HANDLING
		//
		////////////////////////////////////////////////////////////
		public virtual void startMessage(SwiftMessage m)
		{
			write("<message>");
		}

		public virtual void endMessage(SwiftMessage m)
		{

			// if message has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)m.UnparsedTextsSize > 0)
			{
				write(m.UnparsedTexts, 0);
			}

			write(EOL + "</message>");
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 1
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock1(SwiftBlock1 b)
		{
			write(EOL + "<block1>");
		}

		public virtual void value(SwiftBlock1 b, string v)
		{
			// generate the attributes for this block
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			if (!b.Empty)
			{
				appendElement(sb, "applicationId", b.ApplicationId);
				appendElement(sb, "serviceId", b.ServiceId);
				appendElement(sb, "logicalTerminal", b.LogicalTerminal);
				if (b.SessionNumber != null)
				{
					// optional for service messages
					appendElement(sb, "sessionNumber", b.SessionNumber);
				}
				if (b.SequenceNumber != null)
				{
					// optional for service messages
					appendElement(sb, "sequenceNumber", b.SequenceNumber);
				}
				write(sb.ToString());
			}
		}

		public virtual void endBlock1(SwiftBlock1 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts, 1);
			}

			// write block termination
			write(EOL + "</block1>");
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 2
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock2(SwiftBlock2 b)
		{
			// decide on the tag to use
			string xmlTag = "<block2>";
			if (!b.Empty)
			{
				if (b is SwiftBlock2Input)
				{
					xmlTag = "<block2 type=\"input\">";
				}
				if (b is SwiftBlock2Output)
				{
					xmlTag = "<block2 type=\"output\">";
				}
			}
			write(EOL + xmlTag);
		}

		public virtual void value(SwiftBlock2 b, string v)
		{

			// if there is no value (null or empty) => add no nodes
			if (StringUtils.isEmpty(v))
			{
				return;
			}

			// generate the attributes for this block
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			if (b is SwiftBlock2Input)
			{
				SwiftBlock2Input b2 = (SwiftBlock2Input) b;
				appendElement(sb, "messageType", b2.MessageType);
				appendElement(sb, "receiverAddress", b2.ReceiverAddress);
				if (b2.MessagePriority != null)
				{
					// optional for service messages
					appendElement(sb, "messagePriority", b2.MessagePriority);
				}
				if (b2.DeliveryMonitoring != null)
				{
					// optional for service messages
					appendElement(sb, "deliveryMonitoring", b2.DeliveryMonitoring);
				}
				if (b2.ObsolescencePeriod != null)
				{
					// optional for service messages
					appendElement(sb, "obsolescencePeriod", b2.ObsolescencePeriod);
				}
			}
			if (b is SwiftBlock2Output)
			{
				SwiftBlock2Output b2 = (SwiftBlock2Output) b;
				appendElement(sb, "messageType", b2.MessageType);
				appendElement(sb, "senderInputTime", b2.SenderInputTime);
				appendElement(sb, "MIRDate", b2.MIRDate);
				appendElement(sb, "MIRLogicalTerminal", b2.MIRLogicalTerminal);
				appendElement(sb, "MIRSessionNumber", b2.MIRSessionNumber);
				appendElement(sb, "MIRSequenceNumber", b2.MIRSequenceNumber);
				appendElement(sb, "receiverOutputDate", b2.ReceiverOutputDate);
				appendElement(sb, "receiverOutputTime", b2.ReceiverOutputTime);
				if (b2.MessagePriority != null) // optional for service messages
				{
				appendElement(sb, "messagePriority", b2.MessagePriority);
				}
			}

			write(sb.ToString());
		}

		public virtual void endBlock2(SwiftBlock2 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts, 1);
			}

			// write block termination
			write(EOL + "</block2>");
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 3
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock3(SwiftBlock3 b)
		{
			write(EOL + "<block3>");
		}

		public virtual void tag(SwiftBlock3 b, Tag t)
		{
			appendTag(t);
		}

		public virtual void endBlock3(SwiftBlock3 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts, 1);
			}

			// write block termination
			write(EOL + "</block3>");
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 4
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock4(SwiftBlock4 b)
		{
			write(EOL + "<block4>");
		}

		public virtual void tag(SwiftBlock4 b, Tag t)
		{
			if (useField)
			{
				appendField(t);
			}
			else
			{
				appendTag(t);
			}
		}

		public virtual void endBlock4(SwiftBlock4 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts, 1);
			}

			// write block termination
			write(EOL + "</block4>");
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 5
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock5(SwiftBlock5 b)
		{
			write(EOL + "<block5>");
		}

		public virtual void tag(SwiftBlock5 b, Tag t)
		{
			appendTag(t);
		}

		public virtual void endBlock5(SwiftBlock5 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts, 1);
			}

			// write block termination
			write(EOL + "</block5>");
		}

		////////////////////////////////////////////////////////////
		//
		// USER DEFINED BLOCK
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlockUser(SwiftBlockUser b)
		{
			write(EOL + "<block name=\"" + b.Name + "\">");
		}

		public virtual void tag(SwiftBlockUser b, Tag t)
		{
			appendTag(t);
		}

		public virtual void endBlockUser(SwiftBlockUser b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts, 1);
			}

			// write block termination
			write(EOL + "</block>");
		}

		////////////////////////////////////////////////////////////
		//
		// DEPRECATED
		//
		////////////////////////////////////////////////////////////
		public virtual void tag(SwiftBlock b, Tag t)
		{
			if (b == null)
			{
				return;
			}
			if (b is SwiftBlock3)
			{
				tag((SwiftBlock3) b, t);
			}
			if (b is SwiftBlock4)
			{
				tag((SwiftBlock4) b, t);
			}
			if (b is SwiftBlock5)
			{
				tag((SwiftBlock5) b, t);
			}
			if (b is SwiftBlockUser)
			{
				tag((SwiftBlockUser) b, t);
			}
		}

		////////////////////////////////////////////////////////////
		//
		// INTERNAL METHODS
		//
		////////////////////////////////////////////////////////////
		private void appendTag(Tag t)
		{
			// generate the xml tag
			write(EOL + "\t<tag>");
			write(EOL + "\t\t<name>");
			if (t.Name != null) // otherwise, null name writes name "null"
			{
				write(t.Name);
			}
			write("</name>");
			write(EOL + "\t\t<value>");
			if (t.Value != null) // otherwise, null value writes value "null"
			{
				write(t.Value);
			}
			write("</value>");

			// if tag has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)t.UnparsedTextsSize > 0)
			{
				write(t.UnparsedTexts, 2);
			}

			// write tag termination
			write(EOL + "\t</tag>");
		}

		private void appendField(Tag tag)
		{
			if (tag == null)
			{
				return;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field f = tag.asField();
			Field f = tag.asField();
			if (f == null)
			{
				// Something went wrong
			}
			else
			{
				// generate the xml tag
				write(EOL + "\t<field>");
				write(EOL + "\t\t<name>");
				if (f.Name != null) // otherwise, null name writes name "null"
				{
					write(f.Name);
				}
				write("</name>");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<String> components = f.getComponents();
				IList<string> components = f.Components;
				for (int i = 0;i < components.Count;i++)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int id = i+1;
					int id = i + 1;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String component = components.get(i);
					string component = components[i];
					if (component != null)
					{
						write(EOL + "\t\t<component number=\"" + id + "\">");
						write(component);
						write("</component>");
					}
				}

				// write tag termination
				write(EOL + "\t</field>");
			}
		}

		private void appendElement(StringBuilder sb, string element, string value)
		{
			sb.Append(EOL + "\t<").Append(element).Append('>').Append(value).Append("</").Append(element).Append('>');
		}

		private void write(UnparsedTextList texts, int level)
		{
			// write prefix
			string prefix;
			switch (level)
			{
				case 0:
					prefix = "";
					break;
				case 2:
					prefix = "\t\t";
					break;
				default: //level 1 is catched here
					prefix = "\t";
					break;
			}

			// write the unparsed texts (if any)
			if ((int)texts.size() > 0)
			{
				write(EOL + prefix + "<unparsedTexts>");
				for (int i = 0; i < (int)texts.size(); i++)
				{
					write(EOL + prefix + "\t<text>");
					write(texts.getText(Convert.ToInt32(i)));
					write("</text>");
				}
				write(EOL + prefix + "</unparsedTexts>");
			}
		}

		private void write(string s)
		{
			try
			{
				writer.write(s);
			}
			catch (IOException e)
			{
				log.log(Level.SEVERE, "Caught exception in XMLWriterVisitor, method write", e);
				throw new ProwideException(e);
			}
		}
	}

}