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

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using MxId = com.prowidesoftware.swift.model.MxId;
	using MxNode = com.prowidesoftware.swift.model.MxNode;
	using AbstractMX = com.prowidesoftware.swift.model.mx.AbstractMX;
	using BusinessHeader = com.prowidesoftware.swift.model.mx.BusinessHeader;
	using MxPayload = com.prowidesoftware.swift.model.mx.MxPayload;
	using MxSimpleDocument = com.prowidesoftware.swift.model.mx.MxSimpleDocument;
	using ApplicationHeader = com.prowidesoftware.swift.model.mx.dic.ApplicationHeader;
	using BusinessApplicationHeaderV01 = com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01;
	using Lib = com.prowidesoftware.swift.utils.Lib;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Basic parser for MX messages.
	/// <para>IMPORTANT: An MX message is conformed by a set of optional headers 
	/// and a message payload or document with the actual specific MX message. 
	/// The name of the envelope element that binds a Header to the message 
	/// to which it applies is <b>implementation/network specific</b> and not
	/// part of the scope of the parser.
	/// <br>
	/// This parser has three main utilities;
	/// <ol>
	/// <li>The first one to <em>convert the message into an MxNode tree</em>. 
	/// This is a generic structured representation of the
	/// complete content that can be used to get specific items by xpath. It parses
	/// the complete tree including both payload and overhead information
	/// (wrappers, if any, application header and body content).</li>
	/// <li>The second utility is to <em>parse the application header</em> extract of the
	/// XML into a model object. Notice the application header is mainly used to identify 
	/// the specific message, and two versions are supported; the legacy SWIFT 
	/// <seealso cref="ApplicationHeader"/> and the ISO <seealso cref="BusinessApplicationHeaderV01"/>.</li>
	/// <li>The third one is to provide convenient API to detect the specific Mx message
	/// type, to analyze the payload structure and to strip the document or header portions
	/// from the XML in a lightweight and efficient way.</li>
	/// </ol>
	/// <br>
	/// Notice that support for MX in Prowide Core is limited. Complete model and parser 
	/// implementation for each MX message type is implemented into subclasses of 
	/// <seealso cref="AbstractMX"/> by <a href="http://www.prowidesoftware.com/products/integrator">Prowide Integrator</a>.
	/// 
	/// @since 7.6
	/// </para>
	/// </summary>
	public class MxParser
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MxParser).FullName);
		/// <summary>
		/// @since 7.8.4
		/// </summary>
		public const string HEADER_LOCALNAME = "AppHdr";
		/// <summary>
		/// @since 7.8.4
		/// </summary>
		public const string DOCUMENT_LOCALNAME = "Document";

		private string buffer = null;
		private MxStructureInfo info = null;

		/// <summary>
		/// Construct a parser for a file containing a single MX message </summary>
		/// <param name="file"> the file containing a single unit of a message
		/// @since 7.7 </param>
		/// <exception cref="IOException"> if an error occurs during the read of the file </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MxParser(final File file) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MxParser(File file)
		{
			Validate.notNull(file);
			this.buffer = Lib.readFile(file);
		}

		/// <summary>
		/// Construct a parser for a stream containing a single MX message </summary>
		/// <param name="stream"> non null stream containing a single unit of message </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MxParser(final InputStream stream) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MxParser(InputStream stream)
		{
			this.buffer = Lib.readStream(stream);
		}

		/// <summary>
		/// Creates the parser initializing its content source from the given string.
		/// @since 7.7
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxParser(final String message)
		public MxParser(string message) : base()
		{
			buffer = message;
		}

		/// <summary>
		/// Initializes the parser with the given stream, and returns its parsed
		/// content.
		/// </summary>
		/// @deprecated initialize the parser with the stream instead an call the generic <seealso cref="#parse()"/> method
		/// @since 7.6 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("initialize the parser with the stream instead an call the generic <seealso cref="#parse()"/> method") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public com.prowidesoftware.swift.model.MxNode parse(final InputStream stream)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("initialize the parser with the stream instead an call the generic <seealso cref="#parse()"/> method")]
		public virtual MxNode parse(InputStream stream)
		{
			DeprecationUtils.phase3(this.GetType(), "parse(stream)", "Initialize the parser with the stream instead an call the generic parse() method.");
			try
			{
				this.buffer = Lib.readStream(stream);
				return parse();
			}
			catch (UnsupportedEncodingException e)
			{
				log.log(Level.SEVERE, "error reading stream", e);
			}
			catch (IOException e)
			{
				log.log(Level.SEVERE, "error reading stream", e);
			}
			return null;
		}

		/// <summary>
		/// Non-namespace aware parse.<br>
		/// Parses the complete message content into an <seealso cref="MxNode"/> tree structure.
		/// The parser should be initialized with a valid source.
		/// 
		/// @since 7.7
		/// </summary>
		public virtual MxNode parse()
		{
			Validate.notNull(buffer, "the source must be initialized");
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.parsers.SAXParserFactory spf = javax.xml.parsers.SAXParserFactory.newInstance();
				javax.xml.parsers.SAXParserFactory spf = javax.xml.parsers.SAXParserFactory.newInstance();
				spf.NamespaceAware = true;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.parsers.SAXParser saxParser = spf.newSAXParser();
				javax.xml.parsers.SAXParser saxParser = spf.newSAXParser();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MxNodeContentHandler contentHandler = new MxNodeContentHandler();
				MxNodeContentHandler contentHandler = new MxNodeContentHandler();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.xml.sax.XMLReader xmlReader = saxParser.getXMLReader();
				org.xml.sax.XMLReader xmlReader = saxParser.XMLReader;
				xmlReader.ContentHandler = contentHandler;
				xmlReader.parse(new org.xml.sax.InputSource(new StringReader(this.buffer)));
				return contentHandler.RootNode;
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
			catch (Exception e)
			{
				log.log(Level.SEVERE, "Error parsing: ", e);
			}
			return null;
		}

		/// @deprecated use <seealso cref="#stripDocument()"/> and <seealso cref="#stripHeader()"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#stripDocument()"/> and <seealso cref="#stripHeader()"/> instead") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public com.prowidesoftware.swift.model.mx.MxPayload payload()
		[Obsolete("use <seealso cref="#stripDocument()"/> and <seealso cref="#stripHeader()"/> instead")]
		public virtual MxPayload payload()
		{
			DeprecationUtils.phase3(this.GetType(), "payload()", "In order to get the payload of a wrapped MX, use stripDocument() and stripHeader() instead.");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxId id = detectMessage();
			MxId id = detectMessage();
			log.fine("Detected message {}" + id);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mx.MxPayload result = new com.prowidesoftware.swift.model.mx.MxPayload();
			MxPayload result = new MxPayload();

			result.Header = parseBusinessHeader();
			result.Document = new MxSimpleDocument();
			return result;
		}

		/// <summary>
		/// Detects the type of header and parses it as a legacy SWIFT Application Header or ISO Business Application Header.
		/// Uses the namespace (if present) or an heuristic based on tags names.
		/// <br>
		/// By default ISO Business Application Header is expected and assumed for the AppHdr tag.
		/// </summary>
		/// <returns> parsed header or null if the content cannot be parsed or the header is not present in the XML </returns>
		public virtual BusinessHeader parseBusinessHeader()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mx.BusinessHeader bh = new com.prowidesoftware.swift.model.mx.BusinessHeader();
			BusinessHeader bh = new BusinessHeader();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode tree = parse();
			MxNode tree = parse();
			if (tree != null)
			{
				MxNode appHdr = tree.findFirstByName(HEADER_LOCALNAME);
				if (appHdr != null)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String ns = appHdr.getAttribute("xmlns");
					string ns = appHdr.getAttribute("xmlns");
					if ((ns != null && ns.Equals(BusinessHeader.NAMESPACE_AH)) || (appHdr.findFirstByName("From") != null))
					{
						bh.ApplicationHeader = parseApplicationHeader(tree);
					}
					else
					{
						bh.BusinessApplicationHeader = parseBusinessApplicationHeaderV01(tree);
					}
					return bh;
				}
			}
			return null;
		}

		/// <summary>
		/// Parse the business header from an XML Element node </summary>
		/// <seealso cref= #parseBusinessHeader()
		/// @since 7.8 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.mx.BusinessHeader parseBusinessHeader(final org.w3c.dom.Element e)
		public static BusinessHeader parseBusinessHeader(org.w3c.dom.Element e)
		{
			org.w3c.dom.ls.DOMImplementationLS lsImpl = (org.w3c.dom.ls.DOMImplementationLS) e.OwnerDocument.Implementation.getFeature("LS", "3.0");
			org.w3c.dom.ls.LSSerializer serializer = lsImpl.createLSSerializer();
			serializer.DomConfig.setParameter("xml-declaration", false);
			string xml = serializer.writeToString(e);
			MxParser parser = new MxParser(xml);
			return parser.parseBusinessHeader();
		}

		/// <summary>
		/// Parses the application header (SWIFT legacy) from the internal message source.
		/// <br> </summary>
		/// <seealso cref= #parseBusinessHeader() </seealso>
		/// <returns> parsed header or null if the content cannot be parsed or the header is not present in the XML </returns>
		public virtual ApplicationHeader parseApplicationHeader()
		{
			return parseApplicationHeader(parse());
		}

		/// <summary>
		/// Parses the application header (SWIFT legacy) from the parameter node.
		/// <br> </summary>
		/// <seealso cref= #parseBusinessHeader() </seealso>
		/// <returns> parsed header or null if the content cannot be parsed or the header is not present in the XML </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.mx.dic.ApplicationHeader parseApplicationHeader(final com.prowidesoftware.swift.model.MxNode tree)
		public static ApplicationHeader parseApplicationHeader(MxNode tree)
		{
			return MxBusinessHeaderParser.parseApplicationHeader(tree);
		}

		/// <summary>
		/// Parses the application header (ISO) from the internal message source.
		/// <br> </summary>
		/// <seealso cref= #parseBusinessHeader() </seealso>
		/// <returns> parsed header or null if the content cannot be parsed or the header is not present in the XML </returns>
		public virtual BusinessApplicationHeaderV01 parseBusinessApplicationHeaderV01()
		{
			return parseBusinessApplicationHeaderV01(parse());
		}

		/// <summary>
		/// Parses the application header (ISO) from the parameter node.
		/// <br> </summary>
		/// <seealso cref= #parseBusinessHeader() </seealso>
		/// <returns> parsed header or null if the content cannot be parsed or the header is not present in the XML </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01 parseBusinessApplicationHeaderV01(final com.prowidesoftware.swift.model.MxNode tree)
		public static BusinessApplicationHeaderV01 parseBusinessApplicationHeaderV01(MxNode tree)
		{
			return MxBusinessHeaderParser.parseBusinessApplicationHeaderV01(tree);
		}

		/// <summary>
		/// Takes an xml with an MX message and detects the specific message type
		/// parsing just the namespace from the Document element. If the Document
		/// element is not present, or without the namespace or if the namespace url
		/// contains invalid content it will return null.
		/// 
		/// <para>
		/// Example of a recognizable Document element:<br>
		/// &lt;Doc:Document xmlns:Doc="urn:swift:xsd:camt.003.001.04" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"&gt;
		/// 
		/// </para>
		/// <para>
		/// The implementation is intended to be lightweight and efficient, based on <seealso cref="javax.xml.stream.XMLStreamReader"/> 
		/// 
		/// </para>
		/// </summary>
		/// <returns> id with the detected MX message type or null if it cannot be determined.
		/// @since 7.7 </returns>
		public virtual MxId detectMessage()
		{
			if (StringUtils.isBlank(this.buffer))
			{
				log.log(Level.SEVERE, "cannot detect message from null or empty content");
				return null;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.stream.XMLInputFactory xif = javax.xml.stream.XMLInputFactory.newInstance();
			javax.xml.stream.XMLInputFactory xif = javax.xml.stream.XMLInputFactory.newInstance();
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.stream.XMLStreamReader reader = xif.createXMLStreamReader(new StringReader(this.buffer));
				javax.xml.stream.XMLStreamReader reader = xif.createXMLStreamReader(new StringReader(this.buffer));
				while (reader.hasNext())
				{
					int @event = reader.next();
					if (javax.xml.stream.XMLStreamConstants.START_ELEMENT == @event && reader.LocalName.Equals(DOCUMENT_LOCALNAME))
					{
						if (reader.NamespaceCount > 0)
						{
							//log.finest("ELEMENT START: " + reader.getLocalName() + " , namespace count is: " + reader.getNamespaceCount());
							for (int nsIndex = 0; nsIndex < reader.NamespaceCount; nsIndex++)
							{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String nsPrefix = org.apache.commons.lang3.StringUtils.trimToNull(reader.getNamespacePrefix(nsIndex));
								string nsPrefix = StringUtils.trimToNull(reader.getNamespacePrefix(nsIndex));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String elementPrefix = org.apache.commons.lang3.StringUtils.trimToNull(reader.getPrefix());
								string elementPrefix = StringUtils.trimToNull(reader.Prefix);
								if (StringUtils.Equals(nsPrefix, elementPrefix))
								{
									string nsId = reader.getNamespaceURI(nsIndex);
									//log.finest("\tNamepsace prefix: " + nsPrefix + " associated with URI " + nsId);
									return new MxId(nsId);
								}
							}
						}
					}
				}
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
			catch (Exception e)
			{
				log.log(Level.SEVERE, "error while detecting message", e);
			}
			return null;
		}

		/// @deprecated use <seealso cref="#analyzeMessage()"/> instead
		/// @since 7.8.4 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#analyzeMessage()"/> instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public MxStructureInfo analizeMessage()
		[Obsolete("use <seealso cref="#analyzeMessage()"/> instead")]
		public virtual MxStructureInfo analizeMessage()
		{
			return analyzeMessage();
		}

		/// <summary>
		/// Convenient API to get structure information from an MX message.
		/// <para>This can be helpful when the actual content of an XML is unknown and 
		/// some preprocessing of the XML must be done in order to parse or
		/// validate its content properly.
		/// </para>
		/// <para>The implementation is intended to be lightweight and efficient, based on <seealso cref="javax.xml.stream.XMLStreamReader"/>
		/// </para>
		/// <para>If the message contains more than one Document element, the first one will be picked. The same applies for
		/// the header, only the first AppHdr will be picked
		/// 
		/// @since 7.10.3
		/// </para>
		/// </summary>
		public virtual MxStructureInfo analyzeMessage()
		{
			if (this.info != null)
			{
				return this.info;
			}
			this.info = new MxStructureInfo(this);
			if (StringUtils.isBlank(this.buffer))
			{
				log.log(Level.WARNING, "cannot analyze message from null or empty content");
				return this.info;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.stream.XMLInputFactory xif = javax.xml.stream.XMLInputFactory.newInstance();
			javax.xml.stream.XMLInputFactory xif = javax.xml.stream.XMLInputFactory.newInstance();
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.stream.XMLStreamReader reader = xif.createXMLStreamReader(new StringReader(this.buffer));
				javax.xml.stream.XMLStreamReader reader = xif.createXMLStreamReader(new StringReader(this.buffer));
				bool first = true;
				while (reader.hasNext())
				{
					int @event = reader.next();
					if (javax.xml.stream.XMLStreamConstants.START_ELEMENT == @event)
					{
						if (!this.info.containsDocument_Renamed && reader.LocalName.Equals(DOCUMENT_LOCALNAME))
						{
							this.info.containsDocument_Renamed = true;
							this.info.documentNamespace = readNamespace(reader);
							this.info.documentPrefix = StringUtils.trimToNull(reader.Prefix);
						}
						else if (!this.info.containsHeader_Renamed && reader.LocalName.Equals(HEADER_LOCALNAME))
						{
							this.info.containsHeader_Renamed = true;
							this.info.headerNamespace = readNamespace(reader);
							this.info.headerPrefix = StringUtils.trimToNull(reader.Prefix);
						}
						else if (first)
						{
							this.info.containsWrapper_Renamed = true;
						}
						first = false;
					}
				}
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
			catch (Exception e)
			{
				log.log(Level.SEVERE, "error while analizing message: " + e.Message);
				info.exception = e;
			}
			return this.info;
		}

		/// <summary>
		/// Gets the namespace, if any, from current position in the parameter reader
		/// @since 7.8.4
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String readNamespace(final javax.xml.stream.XMLStreamReader reader)
		private string readNamespace(javax.xml.stream.XMLStreamReader reader)
		{
			if (reader.NamespaceCount > 0)
			{
				//log.finest("ELEMENT START: " + reader.getLocalName() + " , namespace count is: " + reader.getNamespaceCount());
				for (int nsIndex = 0; nsIndex < reader.NamespaceCount; nsIndex++)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String nsPrefix = org.apache.commons.lang3.StringUtils.trimToNull(reader.getNamespacePrefix(nsIndex));
					string nsPrefix = StringUtils.trimToNull(reader.getNamespacePrefix(nsIndex));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String elementPrefix = org.apache.commons.lang3.StringUtils.trimToNull(reader.getPrefix());
					string elementPrefix = StringUtils.trimToNull(reader.Prefix);
					if (StringUtils.Equals(nsPrefix, elementPrefix))
					{
						//log.finest("\tNamepsace prefix: " + nsPrefix + " associated with URI " + nsId);
						return reader.getNamespaceURI(nsIndex);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Helper bean used by <seealso cref="MxParser#analyzeMessage()"/> to return 
		/// structure information from an MX message
		/// 
		/// @since 7.8.4
		/// </summary>
		public class MxStructureInfo
		{
			private readonly MxParser outerInstance;

			public MxStructureInfo(MxParser outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			internal bool containsWrapper_Renamed = false;
			internal bool containsHeader_Renamed = false;
			internal bool containsDocument_Renamed = false;
			internal string documentNamespace = null;
			internal string documentPrefix = null;
			internal string headerNamespace = null;
			internal string headerPrefix = null;
			internal Exception exception = null;

			public virtual bool containsWrapper()
			{
				return containsWrapper_Renamed;
			}
			public virtual bool containsHeader()
			{
				return containsHeader_Renamed;
			}
			public virtual bool containsDocument()
			{
				return containsDocument_Renamed;
			}
			public virtual string DocumentNamespace
			{
				get
				{
					return documentNamespace;
				}
			}
			public virtual string DocumentPrefix
			{
				get
				{
					return documentPrefix;
				}
			}
			public virtual string HeaderNamespace
			{
				get
				{
					return headerNamespace;
				}
			}
			public virtual string HeaderPrefix
			{
				get
				{
					return headerPrefix;
				}
			}
			public virtual Exception Exception
			{
				get
				{
					return exception;
				}
			}
			public override string ToString()
			{
				return "MxStructureInfo [containsWrapper=" + containsWrapper_Renamed + ", containsHeader=" + containsHeader_Renamed + ", containsDocument=" + containsDocument_Renamed + ", documentNamespace=" + documentNamespace + ", documentPrefix=" + documentPrefix + ", headerNamespace=" + headerNamespace + ", headerPrefix=" + headerPrefix + "]";
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public com.prowidesoftware.swift.model.mx.MxPayload mx()
		[Obsolete]
		public virtual MxPayload mx()
		{
			DeprecationUtils.phase3(this.GetType(), "mx()", "In order to get the payload of a wrapped MX, use stripDocument() and stripHeader() instead.");
			return null;
		}

		/// <summary>
		/// Distinguished Name structure: cn=name,ou=payment,o=bank,o=swift
		/// <br>
		/// Example: o=spxainjj,o=swift
		/// </summary>
		/// <param name="dn"> the DN element content </param>
		/// <returns> returns capitalized "bank", in the example SPXAINJJ </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getBICFromDN(final String dn)
		public static string getBICFromDN(string dn)
		{
			foreach (string s in StringUtils.Split(dn, ","))
			{
				if (StringUtils.StartsWith(s, "o=") && !StringUtils.Equals(s, "o=swift"))
				{
					return StringUtils.upperCase(StringUtils.substringAfter(s, "o="));
				}
				/*
				else if (StringUtils.startsWith(s, "ou=") && !StringUtils.equals(s, "ou=swift")) {
					return StringUtils.upperCase(StringUtils.substringAfter(s, "ou="));
				}
				*/
			}
			return null;
		}

		/// <summary>
		/// Helper API to strip Document portion of message XML.
		/// 
		/// <para>This API is convenient when only the Document element of an MX message
		/// is needed and the wrapper/payload structure is unknown.
		/// 
		/// </para>
		/// <para>This implementation is intended to be lightweight and efficient so it actually
		/// does a simple substring operation on the XML using information provided
		/// by the result of <seealso cref="#analyzeMessage()"/>. The XML is not converted into DOM.
		/// <br >
		/// If the message contains more than one Document element the expected result is as follows:
		/// <ul>
		/// <li>If the documents are nested (this can happen for example when an additional MX message
		/// is provided within a supplementary data element within the main MX) then the outermost Document
		/// will be returned.</li>
		/// <li>If the documents are not-nested (weird situation) the result might be not well-formed</li>
		/// </ul>
		///  
		/// @since 7.8.4
		/// </para>
		/// </summary>
		/// <returns> XML with Document element of the Mx message or null if message is blank or invalid </returns>
		public virtual string stripDocument()
		{
			analyzeMessage();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String tag = this.info.getDocumentPrefix() != null? this.info.getDocumentPrefix() + ":" + MxParser.DOCUMENT_LOCALNAME : MxParser.DOCUMENT_LOCALNAME;
			string tag = this.info.DocumentPrefix != null? this.info.DocumentPrefix + ":" + MxParser.DOCUMENT_LOCALNAME : MxParser.DOCUMENT_LOCALNAME;
			int beginIndex = this.buffer.IndexOf("<" + tag, StringComparison.Ordinal);
			int endIndex = this.buffer.LastIndexOf("</" + tag, StringComparison.Ordinal);
			if (beginIndex >= 0 && endIndex >= 0)
			{
				return this.buffer.Substring(beginIndex, endIndex - beginIndex) + "</" + tag + ">";
			}
			else
			{
				return null;
			}
		}

		/* alternative future implementation using DOM instead of MxNode
		public String stripDocument1() {
			try {
			    javax.xml.parsers.DocumentBuilderFactory dbf = javax.xml.parsers.DocumentBuilderFactory.newInstance();
			    org.w3c.dom.Document doc = dbf.newDocumentBuilder().parse(new org.xml.sax.InputSource(new StringReader(this.buffer)));
			    javax.xml.xpath.XPath xPath = javax.xml.xpath.XPathFactory.newInstance().newXPath();
			    org.w3c.dom.Node result = (org.w3c.dom.Node)xPath.evaluate("Document", doc, javax.xml.xpath.XPathConstants.NODE);
			    return nodeToString(result);
			} catch (Exception e) {
				e.printStackTrace();
				return null;
			}
		}
		private static String nodeToString(org.w3c.dom.Node node) throws javax.xml.transform.TransformerException {
		    StringWriter buf = new StringWriter();
		    javax.xml.transform.Transformer xform = javax.xml.transform.TransformerFactory.newInstance().newTransformer();
		    xform.setOutputProperty(javax.xml.transform.OutputKeys.OMIT_XML_DECLARATION, "yes");
		    xform.transform(new javax.xml.transform.dom.DOMSource(node), new javax.xml.transform.stream.StreamResult(buf));
		    return(buf.toString());
		}
		*/

		/// <summary>
		/// Helper API to strip AppHdr portion of message XML.
		/// 
		/// <para>This API is convenient when only the header element of an MX message
		/// is needed and the wrapper/payload structure is unknown.
		/// 
		/// </para>
		/// <para>To gather the header already parsed into objects see <seealso cref="#parseBusinessHeader()"/>
		/// 
		/// </para>
		/// <para>This implementation is intended to be lightweight and efficient so it actually
		/// does a simple substring operation on the XML using information provided
		/// by the result of <seealso cref="#analyzeMessage()"/>. The XML is not converted into DOM.
		/// <br >
		/// If the message contains more than one AppHdr element the expected result is as follows:
		/// <ul>
		/// <li>If the headers are not nested, the first one will be returned.</li>
		/// <li>If the headers are nested (weird situation) the result might be not well-formed</li>
		/// </ul>
		/// 
		/// @since 7.8.4
		/// </para>
		/// </summary>
		/// <returns> XML with AppHdr element of the Mx message or null if not found </returns>
		public virtual string stripHeader()
		{
			analyzeMessage();
			if (this.info.containsHeader())
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String tag = this.info.getHeaderPrefix() != null? this.info.getHeaderPrefix() + ":" + MxParser.HEADER_LOCALNAME : MxParser.HEADER_LOCALNAME;
				string tag = this.info.HeaderPrefix != null? this.info.HeaderPrefix + ":" + MxParser.HEADER_LOCALNAME : MxParser.HEADER_LOCALNAME;
				int beginIndex = this.buffer.IndexOf("<" + tag, StringComparison.Ordinal);
				int endIndex = this.buffer.IndexOf("</" + tag, StringComparison.Ordinal);
				if (beginIndex >= 0 && endIndex >= 0)
				{
					return this.buffer.Substring(beginIndex, endIndex - beginIndex) + "</" + tag + ">";
				}
				else
				{
					return null;
				}
			}
			return null;
		}
	}

}