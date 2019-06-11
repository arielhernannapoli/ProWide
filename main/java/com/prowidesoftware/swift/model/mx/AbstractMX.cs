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
namespace com.prowidesoftware.swift.model.mx
{

	using Gson = com.google.gson.Gson;
	using GsonBuilder = com.google.gson.GsonBuilder;
	using MxParser = com.prowidesoftware.swift.io.parser.MxParser;
	using AbstractMT = com.prowidesoftware.swift.model.mt.AbstractMT;
	using Lib = com.prowidesoftware.swift.utils.Lib;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;
	using Document = org.w3c.dom.Document;
	using Element = org.w3c.dom.Element;



	/// <summary>
	/// Base class for specific MX messages.<br>
	/// 
	/// IMPORTANT: An MX message is conformed by a set of optional headers 
	/// and a message payload or document with the actual specific MX message. 
	/// The name of the envelope element that binds a Header to the message 
	/// to which it applies is <b>implementation/network specific</b> and not
	/// part of the scope of this model. 
	/// 
	/// <para>This class provides the base container model for MX messages including
	/// an attribute for the header. Further it supports both versions for the
	/// header; the SWIFT Application Header (legacy) and the ISO Business
	/// Application Header.
	/// 
	/// </para>
	/// <para>Subclasses in Prowide Integrator SDK implement the Document portion
	/// of each specific MX message type.
	/// 
	/// </para>
	/// <para>Serialization of this model into XML text can be done for the with or without
	/// the header portion. When the header is set and included into the serialization, 
	/// the container root element must be provided.
	/// 
	/// @since 7.6
	/// </para>
	/// </summary>
	/// <seealso cref= AbstractMT </seealso>
	public abstract class AbstractMX : AbstractMessage, IDocument, JsonSerializable
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly Logger log = Logger.getLogger(typeof(AbstractMX).FullName);

		protected internal AbstractMX() : base(MessageStandardType.MX)
		{
			// prevent construction
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected AbstractMX(final BusinessHeader businessHeader)
		protected internal AbstractMX(BusinessHeader businessHeader) : base(MessageStandardType.MX)
		{
			this.businessHeader = businessHeader;
		}

		/// <summary>
		/// Header portion of the message payload, common to all specific MX subclasses.
		/// This information is required before opening the actual message to process the content properly.
		/// @since 7.7
		/// </summary>
		private BusinessHeader businessHeader;

		// TODO message is MT parse
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected static String message(final String namespace, final AbstractMX obj, @SuppressWarnings("rawtypes") final Class[] classes, final String prefix, boolean includeXMLDeclaration)
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
		protected internal static string message(string @namespace, AbstractMX obj, Type[] classes, string prefix, bool includeXMLDeclaration)
		{
			return Resolver.mxWrite().message(@namespace, obj, classes, prefix, includeXMLDeclaration);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings({ "rawtypes", "unchecked" }) protected static AbstractMX read(final Class targetClass, final String xml, final Class[] classes)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		protected internal static AbstractMX read(Type targetClass, string xml, Type[] classes)
		{
			return Resolver.mxRead().read(targetClass, xml, classes);
		}

		/// <summary>
		/// Get the classes associated with this message
		/// @since 7.7
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public abstract Class[] getClasses();
		public abstract Type[] Classes {get;}

		/// <summary>
		/// Get the XML namespace of the message
		/// @since 7.7
		/// </summary>
		public abstract string Namespace {get;}

		/// <summary>
		/// get the Alphabetic code in four positions (fixed length) identifying the Business Process </summary>
		/// <returns> the business process of the implementing class
		/// @since 7.7 </returns>
		public abstract string BusinessProcess {get;}

		/// <summary>
		/// Get the code identifying the Message Functionality </summary>
		/// <returns> the set functionality or null if not set
		/// @since 7.7 </returns>
		public abstract int Functionality {get;}

		/// <summary>
		/// Get the Message variant </summary>
		/// <returns> the set variant or null if not set
		/// @since 7.7 </returns>
		public abstract int Variant {get;}

		/// <summary>
		/// Get the message version </summary>
		/// <returns> the set vesion or null if not set
		/// @since 7.7 </returns>
		public abstract int Version {get;}

		/// <summary>
		/// Get this message document as an XML string (headers not included).
		/// The XML will include the XML declaration, the corresponding
		/// namespace and a "Doc" prefix for the namespace.
		/// </summary>
		/// <seealso cref= #message(String, boolean)
		/// @since 7.7 </seealso>
		public virtual string message()
		{
			return message(Namespace, this, Classes, "Doc", true);
		}

		/// <summary>
		/// Get this message as an XML string.
		/// <br> 
		/// If the business header is set, the created XML will include
		/// both the header and the document elements, under a default 
		/// root element.
		/// <br>
		/// If the header is not present, the created XMl will only include
		/// the document.
		/// <br>
		/// Both header and document are generated with namespace declaration
		/// and default prefixes.
		/// <br>
		/// IMPORTANT: The name of the envelope element that binds a Header to 
		/// the message to which it applies is implementation/network specific. 
		/// The header root element ‘AppHdr’ and the ISO 20022 MessageDefinition 
		/// root element ‘Document’ must always be sibling elements in any XML 
		/// document, with the AppHdr element preceding the Document element.
		/// <br>
		/// </summary>
		/// <param name="rootElement"> optional specification of the root element </param>
		/// <returns> created XML
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String message(final String rootElement, boolean includeXMLDeclaration)
		public virtual string message(string rootElement, bool includeXMLDeclaration)
		{
			StringBuilder xml = new StringBuilder();
			if (includeXMLDeclaration)
			{
				xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n");
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String header = header("h", false);
			string header = header("h", false);
			if (header != null)
			{
				xml.Append("<" + rootElement + ">\n");
				xml.Append(header + "\n");
			}
			xml.Append(document("Doc", false) + "\n");
			if (header != null)
			{
				xml.Append("</" + rootElement + ">");
			}
			return xml.ToString();
		}

		/// <summary>
		/// Same as <seealso cref="#message(String)"/> with includeXMLDeclaration set to true
		/// @since 7.8
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String message(final String rootElement)
		public virtual string message(string rootElement)
		{
			return message(rootElement, true);
		}

		/// <summary>
		/// Get this message business header as an XML string.
		/// <br>
		/// The XML will not include the XML declaration, and will
		/// include de namespace as default (without prefix).
		/// </summary>
		/// <returns> the serialized header or null if header is not set
		/// @since 7.8 </returns>
		/// <seealso cref= #header(String, boolean) </seealso>
		public virtual string header()
		{
			return header(null, false);
		}

		/// <summary>
		/// Get this message business header as an XML string.
		/// <br> </summary>
		/// <param name="prefix"> optional prefix for namespace (empty by default) </param>
		/// <param name="includeXMLDeclaration"> true to include the XML declaration (false by default) </param>
		/// <returns> header serialized into XML string or null if neither header version is present
		/// @since 7.8 </returns>
		/// <seealso cref= BusinessHeader#xml(String, boolean) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String header(final String prefix, boolean includeXMLDeclaration)
		public virtual string header(string prefix, bool includeXMLDeclaration)
		{
			if (this.businessHeader != null)
			{
				return this.businessHeader.xml(prefix, includeXMLDeclaration);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Get this message document as an XML string.
		/// Same as <seealso cref="#message()"/>
		/// @since 7.8
		/// </summary>
		public virtual string document()
		{
			return message();
		}

		/// <summary>
		/// Get this message document as an XML string.
		/// <br> </summary>
		/// <param name="prefix"> optional prefix for namespace (empty by default) </param>
		/// <param name="includeXMLDeclaration"> true to include the XML declaration (false by default) </param>
		/// <returns> document serialized into XML string or null if errors occur during serialization
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String document(final String prefix, boolean includeXMLDeclaration)
		public virtual string document(string prefix, bool includeXMLDeclaration)
		{
			return message(Namespace, this, Classes, prefix, includeXMLDeclaration);
		}

		/// <summary>
		/// Convenience method to get this message XML as javax.xml.transform.Source.
		/// Notice this method will return only the document element of the message (headers not included).
		/// </summary>
		/// <returns> null if message() returns null or StreamSource in other case
		/// @since 7.7 </returns>
		/// <seealso cref= #message() </seealso>
		public virtual Source xmlSource()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = message();
			string xml = message();
			log.fine("XML: " + xml);
			if (xml != null)
			{
				return new StreamSource(new StringReader(xml));
			}
			return null;
		}


		/// <summary>
		/// Writes the message document content into a file in XML format (headers not included).
		/// </summary>
		/// <param name="file"> a not null file to write, if it does not exists, it will be created
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void write(final File file) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual void write(File file)
		{
			Validate.notNull(file, "the file to write cannot be null");
			bool created = file.createNewFile();
			if (created)
			{
				log.fine("new file created: " + file.AbsolutePath);
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final FileOutputStream stream = new FileOutputStream(file.getAbsoluteFile());
			FileOutputStream stream = new FileOutputStream(file.AbsoluteFile);
			write(stream);
			stream.close();
		}

		/// <summary>
		/// Writes the message document content into a file in XML format, encoding content in UTF-8 (headers not included).
		/// </summary>
		/// <param name="stream"> a non null stream to write </param>
		/// <exception cref="IOException"> if the stream cannot be written
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void write(final OutputStream stream) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual void write(OutputStream stream)
		{
			Validate.notNull(stream, "the stream to write cannot be null");
			stream.write(message().GetBytes("UTF-8"));
		}

		/// <summary>
		/// @since 7.7 </summary>
		/// <returns> the business header or null if not set </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlTransient public BusinessHeader getBusinessHeader()
		public virtual BusinessHeader BusinessHeader
		{
			get
			{
				return businessHeader;
			}
			set
			{
				this.businessHeader = value;
			}
		}


		/// <summary>
		/// Returns the MX message identification.<br>
		/// Composed by the business process, functionality, variant and version.
		/// </summary>
		/// <returns> the constructed message id
		/// @since 7.7 </returns>
		public virtual MxId MxId
		{
			get
			{
				return new MxId(BusinessProcess, StringUtils.leftPad(Convert.ToString(Functionality), 3, "0"), StringUtils.leftPad(Convert.ToString(Variant), 3, "0"), StringUtils.leftPad(Convert.ToString(Version), 2, "0"));
			}
		}

		public virtual Element element()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.HashMap<String, String> properties = new java.util.HashMap<>();
			Dictionary<string, string> properties = new Dictionary<string, string>();
			// it didn't work as expected
			// properties.put(JAXBRIContext.DEFAULT_NAMESPACE_REMAP, namespace);
			try
			{
				JAXBContext context = JAXBContext.newInstance(Classes, properties);

				DOMResult res = new DOMResult();
				context.createMarshaller().marshal(this, res);
				Document doc = (Document) res.Node;

				return (Element) doc.FirstChild;
			}
			catch (Exception e)
			{
				log.log(Level.WARNING, "Error creating XML Document for MX", e);
				return null;
			}
		}

		/// <summary>
		/// Parses the XML string containing the Document element of an MX message into a specific instance of MX message object.
		/// <br>
		/// If the string is empty, does not contain an MX document, the message type cannot be 
		/// detected or an error occur reading and parsing the message content; this method returns null.
		/// <br>
		/// The implementation detects the message type and uses reflection to call the
		/// parser in the specific Mx subclass.
		/// <br>
		/// IMPORTANT: For the moment this is supported only in Prowide Integrator.
		/// To parse XML into the generic MxNode structure, or to parse business headers check <seealso cref="MxParser"/>
		/// </summary>
		/// <param name="xml"> string a string containing the Document of an MX message in XML format </param>
		/// <param name="id"> optional parameter to indicate the specific MX type to create; autodetected from namespace if null. </param>
		/// <returns> parser message or null if string content could not be parsed into an Mx
		/// 
		/// @since 7.8.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static AbstractMX parse(final String xml, com.prowidesoftware.swift.model.MxId id)
		public static AbstractMX parse(string xml, MxId id)
		{
			return Resolver.mxRead().read(xml, id);
		}

		/// <summary>
		/// Parses a file content into a specific instance of Mx. 
		/// <br>
		/// IMPORTANT: For the moment this is supported only in Prowide Integrator.
		/// To parse XML into the generic MxNode structure, or to parse business headers check <seealso cref="MxParser"/>
		/// </summary>
		/// <param name="file"> a file containing a swift MX message </param>
		/// <param name="id"> optional parameter to indicate the specific MX type to create; autodetected from namespace if null. </param>
		/// <returns> parser message or null if file content could not be parsed </returns>
		/// <exception cref="IOException"> if the file cannot be written </exception>
		/// <seealso cref= #parse(String, MxId)
		/// 
		/// @since 7.8.4 </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static AbstractMX parse(final File file, com.prowidesoftware.swift.model.MxId id) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static AbstractMX parse(File file, MxId id)
		{
			return parse(Lib.readFile(file), id);
		}

		/// <summary>
		/// Get a JSON representation of this MX	message.
		/// @since 7.10.3
		/// </summary>
		public virtual string toJson()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().registerTypeAdapter(AbstractMX.class, new AbstractMXAdapter()).registerTypeAdapter(javax.xml.datatype.XMLGregorianCalendar.class, new XMLGregorianCalendarAdapter()).setPrettyPrinting().create();
			Gson gson = (new GsonBuilder()).registerTypeAdapter(typeof(AbstractMX), new AbstractMXAdapter()).registerTypeAdapter(typeof(XMLGregorianCalendar), new XMLGregorianCalendarAdapter()).setPrettyPrinting().create();
			// we use AbstractMX and not this.getClass() in order to force usage of the adapter
			return gson.toJson(this, typeof(AbstractMX));
		}

		/// <summary>
		/// Used by subclasses to implement JSON deserialization. </summary>
		/// <param name="json"> a JSON representation of an MX message </param>
		/// <param name="classOfT"> the specific MX subclass </param>
		/// <returns> a specific deserialized MX message object
		/// @since 7.10.3 </returns>
		protected internal static T fromJson<T>(string json, Type classOfT)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().registerTypeAdapter(AbstractMX.class, new AbstractMXAdapter()).registerTypeAdapter(javax.xml.datatype.XMLGregorianCalendar.class, new XMLGregorianCalendarAdapter()).create();
			Gson gson = (new GsonBuilder()).registerTypeAdapter(typeof(AbstractMX), new AbstractMXAdapter()).registerTypeAdapter(typeof(XMLGregorianCalendar), new XMLGregorianCalendarAdapter()).create();
			return gson.fromJson(json, classOfT);
		}

		/// <summary>
		/// Creates an MX messages from its JSON representation. </summary>
		/// <param name="json"> a JSON representation of an MX message </param>
		/// <returns> a specific deserialized MX message object, for example MxPain00100108
		/// @since 7.10.3 </returns>
		public static AbstractMX fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().registerTypeAdapter(AbstractMX.class, new AbstractMXAdapter()).registerTypeAdapter(javax.xml.datatype.XMLGregorianCalendar.class, new XMLGregorianCalendarAdapter()).create();
			Gson gson = (new GsonBuilder()).registerTypeAdapter(typeof(AbstractMX), new AbstractMXAdapter()).registerTypeAdapter(typeof(XMLGregorianCalendar), new XMLGregorianCalendarAdapter()).create();
			return gson.fromJson(json, typeof(AbstractMX));
		}

	}

}