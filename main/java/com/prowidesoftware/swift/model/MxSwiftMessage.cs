using System;
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
namespace com.prowidesoftware.swift.model
{


	using Gson = com.google.gson.Gson;
	using GsonBuilder = com.google.gson.GsonBuilder;
	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using MxParser = com.prowidesoftware.swift.io.parser.MxParser;
	using AbstractMX = com.prowidesoftware.swift.model.mx.AbstractMX;
	using BusinessHeader = com.prowidesoftware.swift.model.mx.BusinessHeader;
	using ApplicationHeader = com.prowidesoftware.swift.model.mx.dic.ApplicationHeader;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Container of raw representation of an MX (ISO 20022) SWIFT message, intended for message persistence.
	/// <para>
	/// The class holds the full xml content plus message identification metadata gathered from the application header.
	/// 
	/// </para>
	/// <para>
	/// Notice, the scope of Prowide MX model is the message payload (the actual message or body data) which is the fundamental
	/// purpose of the transmission. The transmission wrappers (overhead data) are excluded and intentionally ignored if found.
	/// 
	/// </para>
	/// <para>
	/// MX messages are uniquely identify by their business process, message functionality, variant and version.<br>
	/// Consider the following example: trea.001.001.02
	/// <ul>
	/// <li>trea refers to 'Treasury'</li>
	/// <li>001 refers to 'NDF opening (notification)'</li>
	/// <li>001 refers to the variant</li>
	/// <li>02 refers to the version message format, in this case version 2 of 'NDF opening' type.</li>
	/// </ul>
	/// 
	/// </para>
	/// <para>
	/// <em>businessProcess</em>: Alphabetic code in four positions (fixed length) identifying the Business Process
	/// <br>
	/// <em>functionality</em>: Alphanumeric code in three positions (fixed length) identifying the Message Functionality
	/// <br>
	/// <em>variant</em>: Numeric code in three positions (fixed length) identifying a particular flavor (variant) of Message Functionality
	/// <br>
	/// <em>version</em>: Numeric code in two positions (fixed length) identifying the version.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.0
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Entity(name = "mx") @DiscriminatorValue("mx") public class MxSwiftMessage extends AbstractSwiftMessage
	public class MxSwiftMessage : AbstractSwiftMessage
	{
		private const long serialVersionUID = -4394356007627575831L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MxSwiftMessage).FullName);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Enumerated(EnumType.STRING) @Column(length = 4, name = "business_process") private MxBusinessProcess businessProcess;
		private MxBusinessProcess businessProcess;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 3) private String functionality;
		private string functionality;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 3) private String variant;
		private string variant;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 2) private String version;
		private string version;

		public MxSwiftMessage() : base()
		{
		}

		/// <summary>
		/// Creates a new message reading the message the content from a string. 
		/// Performs a fast parsing of the header to identify the message 
		/// and gather metadata information for the object attributes.<br>
		/// 
		/// If the string contains several messages, the whole passed content will be
		/// save in the message attribute but identification and metadata will be parser
		/// from the first one found only.
		/// </summary>
		/// <seealso cref= AbstractSwiftMessage#AbstractSwiftMessage(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxSwiftMessage(final String xml)
		public MxSwiftMessage(string xml) : base(xml)
		{
		}

		/// <summary>
		/// Creates a new message reading the message the content from a string. 
		/// This is a static version of the constructor <seealso cref="#MxSwiftMessage(String)"/>
		/// 
		/// @since 7.7
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MxSwiftMessage parse(final String xml)
		public static MxSwiftMessage parse(string xml)
		{
			return new MxSwiftMessage(xml);
		}

		/// <summary>
		/// Creates a new message reading the message the content from an input stream.
		/// </summary>
		/// <seealso cref= #MxSwiftMessage(String) </seealso>
		/// <seealso cref= AbstractSwiftMessage#AbstractSwiftMessage(InputStream)
		/// @since 7.7 </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MxSwiftMessage(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MxSwiftMessage(InputStream stream) : base(stream)
		{
		}

		/// <summary>
		/// Creates a new message reading the message the content from an input stream. 
		/// This is a static version of the constructor <seealso cref="#MxSwiftMessage(InputStream)"/>
		/// 
		/// @since 7.7
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MxSwiftMessage parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MxSwiftMessage parse(InputStream stream)
		{
			return new MxSwiftMessage(stream);
		}

		/// <summary>
		/// Creates a new message reading the message the content from a file.
		/// </summary>
		/// <seealso cref= #MxSwiftMessage(String) </seealso>
		/// <seealso cref= AbstractSwiftMessage#AbstractSwiftMessage(File)
		/// @since 7.7 </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MxSwiftMessage(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MxSwiftMessage(File file) : base(file)
		{
		}

		/// <summary>
		/// Creates a new message reading the message the content from a file. 
		/// This is a static version of the constructor <seealso cref="#MxSwiftMessage(File)"/>
		/// 
		/// @since 7.7
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MxSwiftMessage parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MxSwiftMessage parse(File file)
		{
			return new MxSwiftMessage(file);
		}

		/// <summary>
		/// Creates a new message serializing to xml the parameter message object.
		/// <br>
		/// If the business header is present, the sender and receiver attributes will be set
		/// with content from the header; also the internal raw XML will include both
		/// AppHdr and Document under a root element tag "&lt;message&gt;", as returned by
		/// <seealso cref="AbstractMX#message(String)"/>
		/// <br>
		/// If the header is not present, sender and receiver will be left null and the raw internal
		/// xml will include just the Document element. 
		/// </summary>
		/// <param name="mx"> a message object </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxSwiftMessage(final com.prowidesoftware.swift.model.mx.AbstractMX mx)
		public MxSwiftMessage(AbstractMX mx) : base(mx.message("message"))
		{
		}

		/// <seealso cref= AbstractSwiftMessage#updateFromMessage()
		/// @since 7.7 </seealso>
		protected internal override void updateFromMessage()
		{
			_updateFromMessage(null);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void _updateFromMessage(final MxId id)
		private void _updateFromMessage(MxId id)
		{
			if (message() != null && message().Length > 0)
			{
				/*
				 * update sender, receiver and reference
				 * from business header or group header
				 */
				MxParser parser = new MxParser(this.message());
				BusinessHeader h = parser.parseBusinessHeader();
				if (!_update(h))
				{
					_update(parser.parse());
				}
				/*
				 * update identifier and namespace
				 */
				if (id != null)
				{
					_update(id);
				}
				else
				{
					_update(parser.detectMessage());
				}
			}
		}

		/// <summary>
		/// Updates the the attributes with the raw message and its metadata from the given raw (XML) message content.
		/// Wrapper around AppHdr/Document, if present, are preserved and ignored.
		/// </summary>
		/// <param name="xml"> the XML content of an MX message containing the Document and optional AppHdr elements </param>
		/// <seealso cref= #updateFromMessage()
		/// @since 7.8.4 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void updateFromXML(final String xml)
		public virtual void updateFromXML(string xml)
		{
			updateFromXML(xml, null);
		}

		/// <summary>
		/// Similar to <seealso cref="#updateFromXML(String)"/> but providing the corresponding MxId 
		/// to skip automatic detection for specific Mx type from content. </summary>
		/// <param name="xml"> the XML content of an MX message containing the Document and optional AppHdr elements </param>
		/// <param name="id"> the specific Mx type identification
		/// @since 7.8.4 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void updateFromXML(final String xml, final MxId id)
		public virtual void updateFromXML(string xml, MxId id)
		{
			Validate.notNull(xml, "the xml message parameter cannot be null");
			Message = xml;
			FileFormat = FileFormat.MX;
			_updateFromMessage(id);
		}

		/// <summary>
		/// Updates the the attributes with the raw message and its metadata from the given raw (XML) message content.
		/// </summary>
		/// <param name="mx"> the new message content </param>
		/// <seealso cref= #updateFromMessage()
		/// @since 7.8.4 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void updateFromModel(final com.prowidesoftware.swift.model.mx.AbstractMX mx)
		public virtual void updateFromModel(AbstractMX mx)
		{
			Validate.notNull(mx, "the mx parameter cannot be null");
			Message = mx.message("message", true);
			FileFormat = FileFormat.MX;
			/*
			 * update sender, receiver and reference
			 * from business header or group header
			 */
			if (!_update(mx.BusinessHeader))
			{
				MxParser parser = new MxParser(this.message());
				_update(parser.parse());
			}
			/*
			 * update identifier and namespace
			 */
			_update(mx.MxId);
		}

		/// <summary>
		/// Updates identifier and namespace related attributes from the given id object </summary>
		/// <param name="id"> </param>
		/// <returns> true if at least some property was updated </returns>
		private bool _update(MxId id)
		{
			if (id != null)
			{
				this.identifier = id.id();
				this.businessProcess = id.BusinessProcess;
				this.functionality = id.Functionality;
				this.variant = id.Variant;
				this.version = id.Version;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Updates sender, receiver and reference from parameter header </summary>
		/// <param name="h"> </param>
		/// <returns> true if at least some property was updated </returns>
		private bool _update(BusinessHeader h)
		{
			bool updated = false;
			if (h != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String from = h.from();
				string from = h.from();
				if (from != null)
				{
					base.sender = bic11(from);
					updated = true;
				}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String to = h.to();
				string to = h.to();
				if (to != null)
				{
					base.receiver = bic11(to);
					updated = true;
				}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String reference = h.reference();
				string reference = h.reference();
				if (reference != null)
				{
					Reference = h.reference();
					updated = true;
				}
			}
			return updated;
		}

		/// <summary>
		/// Updates sender, receiver and reference from the group header element (only present in a subset of Mx messages) </summary>
		/// <returns> true if at least some property was updated </returns>
		private bool _update(MxNode n)
		{
			bool updated = false;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MxNode groupHeader = n != null? n.findFirstByName("GrpHdr") : null;
			MxNode groupHeader = n != null? n.findFirstByName("GrpHdr") : null;
			if (groupHeader != null)
			{
				MxNode senderBic = groupHeader.findFirst("./InstgAgt/FinInstnId/BIC");
				if (senderBic != null)
				{
					sender = bic11(senderBic.Value);
					updated = true;
				}
				MxNode receiverBic = groupHeader.findFirst("./InstdAgt/FinInstnId/BIC");
				if (receiverBic != null)
				{
					receiver = bic11(receiverBic.Value);
					updated = true;
				}
				MxNode reference = groupHeader.findFirst("./MsgId");
				if (reference != null)
				{
					Reference = reference.Value;
					updated = true;
				}
			}
			return updated;
		}

		public virtual MxBusinessProcess BusinessProcess
		{
			get
			{
				return businessProcess;
			}
			set
			{
				this.businessProcess = value;
			}
		}


		public virtual string Functionality
		{
			get
			{
				return functionality;
			}
			set
			{
				this.functionality = value;
			}
		}


		public virtual string Variant
		{
			get
			{
				return variant;
			}
			set
			{
				this.variant = value;
			}
		}


		public virtual string Version
		{
			get
			{
				return version;
			}
			set
			{
				this.version = value;
			}
		}


		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}
			if (!base.Equals(o))
			{
				return false;
			}
			MxSwiftMessage that = (MxSwiftMessage) o;
			return businessProcess == that.businessProcess && Objects.Equals(functionality, that.functionality) && Objects.Equals(variant, that.variant) && Objects.Equals(version, that.version);
		}

		public override int GetHashCode()
		{
			return Objects.hash(base.GetHashCode(), businessProcess, functionality, variant, version);
		}

		/// @deprecated The internal metadata is set automatically from the message content when
		/// the object is constructed from String, File or Stream. This should not be updated from
		/// a decoupled namespace String to avoid inconsistencies between the stored raw message content
		/// and the metadata. 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("The internal metadata is set automatically from the message content when") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) protected void setDataFromNamespace(String namespace)
		[Obsolete("The internal metadata is set automatically from the message content when")]
		protected internal virtual string DataFromNamespace
		{
			set
			{
				DeprecationUtils.phase3(this.GetType(), "setDataFromNamespace(String)", "The internal metadata is set automatically from the message content when the object is constructed from String, File or Stream.");
				Validate.notNull(value, "namespace can not be null");
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String[] tokens = org.apache.commons.lang3.StringUtils.split(namespace, '.');
				string[] tokens = StringUtils.Split(value, '.');
				if (tokens == null || tokens.Length < 4)
				{
					throw new System.ArgumentException("Expected at least 4 tokens in namespace '" + value + "'");
				}
				// always last 4 tokens
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String bp = tokens[tokens.length-4];
				string bp = tokens[tokens.Length - 4];
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String func = tokens[tokens.length-3];
				string func = tokens[tokens.Length - 3];
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String var = tokens[tokens.length-2];
				string @var = tokens[tokens.Length - 2];
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String ver = tokens[tokens.length-1];
				string ver = tokens[tokens.Length - 1];
    
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final MxBusinessProcess bpEnum;
				MxBusinessProcess bpEnum;
				try
				{
					bpEnum = MxBusinessProcess.valueOf(bp);
				}
				catch (Exception e)
				{
					throw new System.ArgumentException("Unknown business process '" + bp + "'", e);
				}
				BusinessProcess = bpEnum;
				Functionality = func;
				Variant = @var;
				Version = ver;
			}
		}

		/// <summary>
		/// If present in the message content, returns the business header (SWIFT or ISO version)
		/// Notice this header is optional and may not be present. </summary>
		/// <seealso cref= MxParser#parseBusinessHeader() </seealso>
		/// <returns> found header or null if not present or cannot be parsed into a header object
		/// @since 7.8.4 </returns>
		public virtual BusinessHeader BusinessHeader
		{
			get
			{
				MxParser parser = new MxParser(this.message());
				return parser.parseBusinessHeader();
			}
		}

		/// <summary>
		/// This method has been deprecated because Mx message support two kind of headers,
		/// the one from SWIFT and the one from ISO. The Application Header returned here
		/// is the SWIFT version, currently deprecated and replaced by the ISO version. </summary>
		/// <seealso cref= #getBusinessHeader() </seealso>
		/// @deprecated use #getBusinessHeader() instead  
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use #getBusinessHeader() instead") @ProwideDeprecated(phase2=com.prowidesoftware.deprecation.TargetYear._2019) public com.prowidesoftware.swift.model.mx.dic.ApplicationHeader getApplicationHeader()
		[Obsolete("use #getBusinessHeader() instead")]
		public virtual ApplicationHeader ApplicationHeader
		{
			get
			{
				MxParser parser = new MxParser(this.message());
				BusinessHeader h = parser.parseBusinessHeader();
				if (h != null && h.ApplicationHeader != null)
				{
					return h.ApplicationHeader;
				}
				return null;
			}
			set
			{
	//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
				log.warning("Obsolete API call. The application header is no longer stored as class attribute in " + this.GetType().FullName);
			}
		}

		/// <summary>
		/// The application header is no longer stored as class attribute </summary>
		/// <seealso cref= #getApplicationHeader() </seealso> 
		/// @deprecated <seealso cref= #getApplicationHeader() </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("@see #getApplicationHeader()") @ProwideDeprecated(phase2=com.prowidesoftware.deprecation.TargetYear._2019) public void setApplicationHeader(com.prowidesoftware.swift.model.mx.dic.ApplicationHeader applicationHeader)

		/// <summary>
		/// Creates a full copy of the current message object into another message. </summary>
		/// <param name="msg"> target message
		/// @since 7.7 </param>
		/// <seealso cref= AbstractSwiftMessage#copyTo(AbstractSwiftMessage) </seealso>
		public virtual void copyTo(MxSwiftMessage msg)
		{
			base.copyTo(msg);
			msg.BusinessProcess = BusinessProcess;
			msg.Functionality = Functionality;
			msg.Variant = Variant;
			msg.Version = Version;
		}

		/// <summary>
		/// @since 7.8.6
		/// </summary>
		public override string ToString()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			sb.Append("MxSwiftMessage id=").Append(Id).Append(" message=").Append(Message);
			return sb.ToString();
		}

		/// <summary>
		/// This method deserializes the JSON data into an MX message object. </summary>
		/// <seealso cref= #toJson()
		/// @since 7.10.3 </seealso>
		public static MxSwiftMessage fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().create();
			Gson gson = (new GsonBuilder()).create();
			return gson.fromJson(json, typeof(MxSwiftMessage));
		}

		/// <summary>
		/// Returns this message MX identification </summary>
		/// <returns> the identification object for this message
		/// @since 7.10.4 </returns>
		public virtual MxId MxId
		{
			get
			{
				return new MxId(this.businessProcess, this.functionality, this.variant, this.version);
			}
		}

	}

}