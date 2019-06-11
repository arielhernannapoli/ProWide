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

	using MxNode = com.prowidesoftware.swift.model.MxNode;

	/// <summary>
	/// Non-public content handler used by <seealso cref="MxParser"/> to parse MX message into <seealso cref="MxNode"/> tree
	/// <br >
	/// Non Namespace Aware. 
	/// The namespace uri, if present, is stored as attribute named "xmlns" in the root node.
	/// </summary>
	/*
	 * TODO sebastian oct 2015
	 * Esto debiera soportar namespaces, ahroa se lo guarda como attr porque se usa para detectar tipo de header.
	 */
	internal sealed class MxNodeContentHandler : org.xml.sax.ContentHandler
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly Logger log = Logger.getLogger(typeof(MxNodeContentHandler).FullName);

		private MxNode currentNode;
		private MxNode rootNode;

		internal MxNode RootNode
		{
			get
			{
				return this.rootNode;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setDocumentLocator(final org.xml.sax.Locator locator)
		public org.xml.sax.Locator DocumentLocator
		{
			set
			{
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void startDocument() throws org.xml.sax.SAXException
		public void startDocument()
		{
			this.currentNode = null;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void endDocument() throws org.xml.sax.SAXException
		public void endDocument()
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void startPrefixMapping(final String prefix, final String uri) throws org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public void startPrefixMapping(string prefix, string uri)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void endPrefixMapping(final String prefix) throws org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public void endPrefixMapping(string prefix)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void startElement(final String uri, final String localName, final String qName, final org.xml.sax.Attributes atts) throws org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public void startElement(string uri, string localName, string qName, org.xml.sax.Attributes atts)
		{
			if (log.isLoggable(Level.FINEST))
			{
				log.finest("uri: " + uri + "\nlocalName: " + localName + "\nqName: " + qName + (atts == null ? "" : "\natts(" + atts.Length + "): ..."));
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode node = new com.prowidesoftware.swift.model.MxNode(currentNode, localName);
			MxNode node = new MxNode(currentNode, localName);
			if (atts != null)
			{
				for (int i = 0; i < atts.Length; i++)
				{
					node.addAttribute(atts.getLocalName(i), atts.getValue(i));
				}
			}
			/*
			 * set uri as xmlns attribute for the first node in namespace
			 */
			if (uri != null && (node.Parent == null || !StringUtils.Equals(node.Parent.getAttribute("xmlns"), uri)))
			{
				node.addAttribute("xmlns", uri);
			}
			currentNode = node;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void endElement(final String uri, final String localName, final String qName) throws org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public void endElement(string uri, string localName, string qName)
		{
			log.finest("end: " + localName);
			if (currentNode.Parent == null)
			{
				rootNode = currentNode;
			}
			// shouln't overlap
			// TODO merge review
			currentNode = currentNode.Parent;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void characters(final char[] ch, final int start, final int length) throws org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public void characters(char[] ch, int start, int length)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String v = new String(ch, start, length);
			string v = new string(ch, start, length);
			log.finest("characters: " + v);
			// TODO this may need buffering and be pushed in end element, check with big data and impl specs
			currentNode.Value = v;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void ignorableWhitespace(final char[] ch, final int start, final int length) throws org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public void ignorableWhitespace(char[] ch, int start, int length)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void processingInstruction(final String target, final String data) throws org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public void processingInstruction(string target, string data)
		{
			/*
			 *  2015.03 miguel
			 *  seria muy intersante soportar custom processing instructions aca
			 */
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void skippedEntity(final String name) throws org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public void skippedEntity(string name)
		{
			log.finer("skippedEntity: " + name);
		}
	}

}