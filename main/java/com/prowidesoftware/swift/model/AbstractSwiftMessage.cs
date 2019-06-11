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
namespace com.prowidesoftware.swift.model
{

	using Gson = com.google.gson.Gson;
	using GsonBuilder = com.google.gson.GsonBuilder;
	using Lib = com.prowidesoftware.swift.utils.Lib;
	using ArrayUtils = org.apache.commons.lang3.ArrayUtils;
	using StringUtils = org.apache.commons.lang3.StringUtils;


	/// <summary>
	/// Base class for common attributes of MT and MX SWIFT messages intended for messages persistence.
	/// 
	/// <para>This class hierarchy is designed as a container of the raw message contents (xml for MX and FIN for MT)
	/// plus minimal message metadata. The extra data contains several common attributes for all messages, and
	/// the subclasses add additional information mainly to identify the specific message type.
	/// 
	/// </para>
	/// <para>This minimal abstraction make this model optimal for an ORM mapping (ex: for Hibernate) to store
	/// all messages in a single and simple table.
	/// 
	/// </para>
	/// <para>XML metadata may be used to override or augment these JPA annotations.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.0
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Entity @Table(name = "swift_msg", indexes = { @Index(name = "x_chk", columnList = "checksum"), @Index(name = "x_chkbody", columnList = "checksum_body"), @Index(name = "x_cd", columnList = "checksum_body"), @Index(name = "x_mir", columnList = "checksum"), @Index(name = "x_mur", columnList = "checksum_body"), @Index(name = "x_uuid", columnList = "checksum_body") }) @Inheritance(strategy = InheritanceType.SINGLE_TABLE) @DiscriminatorColumn(name = "type", length = 2) public abstract class AbstractSwiftMessage implements java.io.Serializable, com.prowidesoftware.JsonSerializable
	[Serializable]
	public abstract class AbstractSwiftMessage : JsonSerializable
			//MT and MX
			//MT only
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(AbstractSwiftMessage).FullName);
		private const long serialVersionUID = 3769865560736793606L;

		/// <summary>
		/// Identifier constant for acknowledge service messages
		/// @since 7.8.8
		/// </summary>
		protected internal const string IDENTIFIER_ACK = "ACK";

		/// <summary>
		/// Identifier constant for non-acknowledge service messages
		/// @since 7.8.8
		/// </summary>
		protected internal const string IDENTIFIER_NAK = "NAK";

		/// <summary>
		/// Unique identifier (used for ORM mapped to the table record id)
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Id @GeneratedValue(strategy = GenerationType.IDENTITY) private Long id;
		private long? id;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Lob private String message;
		private string message_Renamed;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 40) protected String identifier;
		protected internal string identifier;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 12) protected String sender;
		protected internal string sender;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 12) protected String receiver;
		protected internal string receiver;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Enumerated(EnumType.STRING) @Column(length = 8) private MessageIOType direction;
		private MessageIOType direction;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 32, name = "checksum") private String checksum;
		private string checksum;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 32, name = "checksum_body") private String checksumBody;
		private string checksumBody;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(name = "last_modified") private Calendar lastModified = Calendar.getInstance();
		private DateTime lastModified = new DateTime();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(name = "creation_date") private Calendar creationDate = Calendar.getInstance();
		private DateTime creationDate = new DateTime();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @OneToMany(orphanRemoval = true, cascade = CascadeType.ALL) @JoinColumn(name = "msg_id", nullable = false) @OrderColumn(name = "sort_key") private List<SwiftMessageStatusInfo> statusTrail = new ArrayList<>();
		private IList<SwiftMessageStatusInfo> statusTrail = new List<SwiftMessageStatusInfo>();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 50) private String status;
		private string status;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @OneToMany(orphanRemoval = true, cascade = CascadeType.ALL) @JoinColumn(name = "msg_id", nullable = false) @OrderColumn(name = "sort_key") private List<SwiftMessageNote> notes = new ArrayList<>();
		private IList<SwiftMessageNote> notes = new List<SwiftMessageNote>();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @ElementCollection @CollectionTable(name = "swift_msg_properties", joinColumns = @JoinColumn(name = "id")) @MapKeyColumn(name = "property_key", length = 200) @Column(name = "property_value") @Lob private Map<String, String> properties = new HashMap<>();
		private IDictionary<string, string> properties = new Dictionary<string, string>(); //only applies to the value
		//@Fetch(FetchMode.SELECT)

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 100) private String filename;
		private string filename;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient private FileFormat fileFormat;
		private FileFormat fileFormat;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 35) private String reference;
		private string reference;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 3) private String currency;
		private string currency;

		private decimal amount;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @OneToMany(orphanRemoval = true, cascade = CascadeType.ALL) @JoinColumn(name = "msg_id", nullable = false) @OrderColumn(name = "sort_key") private List<SwiftMessageRevision> revisions = new ArrayList<>();
		private IList<SwiftMessageRevision> revisions = new List<SwiftMessageRevision>();

		/// <summary>
		/// @since 7.10.8
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Temporal(TemporalType.DATE) private java.util.Calendar valueDate;
		private DateTime valueDate;

		/// <summary>
		/// @since 7.10.8
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Temporal(TemporalType.DATE) private java.util.Calendar tradeDate;
		private DateTime tradeDate;

		/// <summary>
		/// Empty constructor provided for ORM persistence.
		/// On most situations this objects are constructed with message data as parameter.
		/// @since 7.7
		/// </summary>
		public AbstractSwiftMessage() : base()
		{
		}

		/// <summary>
		/// Creates a new message reading the message the content from a string. 
		/// Uses abstract method @link {<seealso cref="#updateFromMessage()"/>} to fill the specific metadata attributes.<br>
		/// 
		/// The complete string content will be read and set as raw message content, but if the stringt contains 
		/// multiple messages, only the first one will be used for metadata and message identification.
		/// </summary>
		/// <param name="content"> a swift message content
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected AbstractSwiftMessage(final String content)
		protected internal AbstractSwiftMessage(string content) : base()
		{
			this.message_Renamed = content;
			updateFromMessage();
		}

		/// <seealso cref= AbstractSwiftMessage#AbstractSwiftMessage(String)
		/// @since 7.8.4 </seealso>
		/// <param name="content"> the raw message content </param>
		/// <param name="fileFormat"> the content specific format </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected AbstractSwiftMessage(final String content, final FileFormat fileFormat)
		protected internal AbstractSwiftMessage(string content, FileFormat fileFormat) : base()
		{
			this.message_Renamed = content;
			this.fileFormat = fileFormat;
			updateFromMessage();
		}

		/// <summary>
		/// Creates a new message reading the message the content from an input stream, using UTF-8 as encoding.
		/// Uses abstract method {<seealso cref="#updateFromMessage()"/>} to fill the specific metadata attributes.<br>
		/// 
		/// The complete stream content will be read and set as raw message content, but if the stream contains 
		/// multiple messages, only the first one will be used for metadata and message identification.
		/// </summary>
		/// <param name="stream"> a stream with the raw mesasge content to read
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected AbstractSwiftMessage(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		protected internal AbstractSwiftMessage(InputStream stream) : base()
		{
			this.message_Renamed = Lib.readStream(stream);
			updateFromMessage();
		}

		/// <seealso cref= #AbstractSwiftMessage(InputStream) </seealso>
		/// <param name="stream"> a stream with the raw mesasge content to read </param>
		/// <param name="fileFormat"> the specific content format </param>
		/// <exception cref="IOException"> if an error occur reading the stream
		/// @since 7.8.4 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected AbstractSwiftMessage(final java.io.InputStream stream, final FileFormat fileFormat) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		protected internal AbstractSwiftMessage(InputStream stream, FileFormat fileFormat) : base()
		{
			this.message_Renamed = Lib.readStream(stream);
			this.fileFormat = fileFormat;
			updateFromMessage();
		}

		/// <summary>
		/// Creates a new message reading the message the content from a file. 
		/// Uses abstract method {<seealso cref="#updateFromMessage()"/>} to fill the specific metadata attributes.<br>
		/// 
		/// The complete file content will be read and set as raw message content, but if the file contains 
		/// multiple messages, only the first one will be used for metadata and message identification.
		/// </summary>
		/// <param name="file"> an existing file name containing only one message.
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected AbstractSwiftMessage(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		protected internal AbstractSwiftMessage(File file) : base()
		{
			this.message_Renamed = Lib.readFile(file);
			this.filename = file.AbsolutePath;
			updateFromMessage();
		}

		/// <seealso cref= #AbstractSwiftMessage(File) </seealso>
		/// <param name="file"> a file with the raw mesasge content to read </param>
		/// <param name="fileFormat"> the specific file content format </param>
		/// <exception cref="IOException"> if an error occur reading the file
		/// @since 7.8.4 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected AbstractSwiftMessage(final java.io.File file, final FileFormat fileFormat) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		protected internal AbstractSwiftMessage(File file, FileFormat fileFormat) : base()
		{
			this.message_Renamed = Lib.readFile(file);
			this.filename = file.AbsolutePath;
			this.fileFormat = fileFormat;
			updateFromMessage();
		}

		/// <summary>
		/// Updates the object attributes with metadata parsed from the message raw content:
		/// identifier, sender, receiver, direction and specific data for the implementing subclass.<br/>
		/// 
		/// @since 7.7
		/// </summary>
		protected internal abstract void updateFromMessage();

		/// <summary>
		/// Returns the persisted message unique identifier.
		/// </summary>
		public virtual long? Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}


		/// <summary>
		/// Raw message content. FIN for MTS, and XML for MX.
		/// </summary>
		public virtual string Message
		{
			get
			{
				return message_Renamed;
			}
			set
			{
				this.message_Renamed = value;
			}
		}

		/// <summary>
		/// Returns the internal swift message in its original raw format.
		/// Same as <seealso cref="#getMessage()"/>
		/// </summary>
		/// <returns> raw content of the message
		/// @since 7.7 </returns>
		public virtual string message()
		{
			return message_Renamed;
		}


		/// <summary>
		/// Message type identification as specify by SWIFT.
		/// <ul>
		/// 	<li>For MT: fin.&lt;msgtype&gt;[.&lt;mug|variant&gt;] for example fin.103.STP, fin.103.REMIT, fin.202, fin.202.COV</li>
		/// 	<li>For MX: &lt;bus.area>.&lt;msgtype&gt;.&lt;variant&gt;.&lt;version&gt; for example: camt.034.001.02, ifds.001.001.01</li> </summary>
		/// 	<li>For acknowledge service messages <seealso cref= <seealso cref="AbstractSwiftMessage#IDENTIFIER_ACK"/></li> </seealso>
		/// 	<li>For non-acknowledge service messages <seealso cref= <seealso cref="AbstractSwiftMessage#IDENTIFIER_NAK"/></li>
		/// 	<li>For other service messages the identifier is left <code>null</code></li>
		/// </ul> </seealso>
		public virtual string Identifier
		{
			get
			{
				return identifier;
			}
			set
			{
				this.identifier = value;
			}
		}


		/// <summary>
		/// Proprietary checksum computed for the whole raw message content, helpful for integrity verification or duplicates detection.
		/// 
		/// <para>At the moment this is only implemented for MT messages
		/// </para>
		/// </summary>
		/// <seealso cref= SwiftMessageUtils#calculateChecksum(SwiftMessage) </seealso>
		//TODO implement the same for MX, computing hash on XSLT normalized version of the XML
		public virtual string Checksum
		{
			get
			{
				return checksum;
			}
			set
			{
				this.checksum = value;
			}
		}


		/// <summary>
		/// Gets the proprietary checksum calculated for the text block (block 4) only in MT or Document only in MX, helpful for integrity verification or duplicates detection.
		/// 
		/// <para>At the moment this is only implemented for MT messages
		/// </para>
		/// </summary>
		/// <seealso cref= SwiftMessageUtils#calculateChecksum(SwiftBlock4)
		/// @since 7.9.5 </seealso>
		//TODO implement the same for MX, computing hash on XSLT normalized version of the XML
		public virtual string ChecksumBody
		{
			get
			{
				return checksumBody;
			}
			set
			{
				this.checksumBody = value;
			}
		}


		/// <summary>
		/// Last modification date and time.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlTransient public Calendar getLastModified()
		public virtual DateTime LastModified
		{
			get
			{
				return lastModified;
			}
			set
			{
				this.lastModified = value;
			}
		}


		/// <summary>
		/// Creation date and time.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlTransient public Calendar getCreationDate()
		public virtual DateTime CreationDate
		{
			get
			{
				return creationDate;
			}
			set
			{
				this.creationDate = value;
			}
		}


		/// <summary>
		/// User comments attached to this message.
		/// </summary>
		public virtual IList<SwiftMessageNote> Notes
		{
			get
			{
				return notes;
			}
			set
			{
				this.notes = value;
			}
		}


		/// <summary>
		/// Flexible property container to extend message metadata.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlTransient public Map<String, String> getProperties()
		public virtual IDictionary<string, string> Properties
		{
			get
			{
				return properties;
			}
			set
			{
				this.properties = value;
			}
		}


		/// <summary>
		/// Status history for this message.
		/// current status is the last one in the list.
		/// </summary>
		public virtual IList<SwiftMessageStatusInfo> StatusTrail
		{
			get
			{
				return statusTrail;
			}
			set
			{
				this.statusTrail = value;
			}
		}


		/// <summary>
		/// Get the name of the last status set to this message, or <code>null</code> if none is found.
		/// </summary>
		public virtual string getStatus()
		{
			return status;
		}

		/// <summary>
		/// Sets the status attribute. Notice that this method does not update the status trail. </summary>
		/// <seealso cref= #addStatus(SwiftMessageStatusInfo) </seealso>
		/// <param name="status"> the current message status name </param>
		public virtual void setStatus(string status)
		{
			this.status = status;
		}

		/// <summary>
		/// Senders BIC11 code.<br>
		/// For MT messages this is the BIC11 portion of the sender logical terminal; for outgoing messages the LT at block 1 
		/// is used, and for incoming messages it is the LT at the MIR of block 2.
		/// For MX messages this is the (capitalized) BIC information in the "From" tag of the Application Header.
		/// </summary>
		public virtual string Sender
		{
			get
			{
				return sender;
			}
			set
			{
				this.sender = value;
			}
		}


		/// <summary>
		/// Receivers BIC11 code.<br>
		/// For MT messages this is the BIC11 portion of the receiver logical terminal; for outgoing messages the LT at 
		/// block 2 is used, and for incoming messages it is the LT at block 1.
		/// For MX messages this is the (capitalized) BIC information in the "To" tag of the Application Header.
		/// </summary>
		public virtual string Receiver
		{
			get
			{
				return receiver;
			}
			set
			{
				this.receiver = value;
			}
		}


		/// <summary>
		/// Direction from application perspective;
		/// message is sent to SWIFT are outgoing and
		/// messages received from SWIFT are incoming.
		/// </summary>
		public virtual MessageIOType Direction
		{
			get
			{
				return direction;
			}
			set
			{
				this.direction = value;
			}
		}


		/// <summary>
		/// Original filename if applies.
		/// </summary>
		public virtual string Filename
		{
			get
			{
				return filename;
			}
			set
			{
				this.filename = value;
			}
		}


		[NonSerialized]
		public const string PROPERTY_NAME = "name";

		/// <summary>
		/// Get the value of the property under the <seealso cref="#PROPERTY_NAME"/> key or <code>null</code> if not found
		/// </summary>
		public virtual string MessageName
		{
			get
			{
				IDictionary<string, string> p = Properties;
				if (p != null && p.ContainsKey(PROPERTY_NAME) && StringUtils.isNotBlank(p[PROPERTY_NAME]))
				{
					return p[PROPERTY_NAME];
				}
				return null;
			}
		}

		/// <summary>
		/// Adds a status to the message's status trail and current status attribute, initializing the statuses trail list if necessary. </summary>
		/// <param name="status"> the status to add </param>
		public virtual void addStatus(SwiftMessageStatusInfo status)
		{
			if (status != null)
			{
				if (this.StatusTrail == null)
				{
					this.StatusTrail = new List<SwiftMessageStatusInfo>();
				}
				this.statusTrail.Add(status);
				setStatus(status.Name);
			}
		}

		/// <returns> true if the message is outgoing (sent to SWIFT), false other case; using the direction attribute. </returns>
		public virtual bool Outgoing
		{
			get
			{
				return this.direction == MessageIOType.outgoing;
			}
		}

		/// <seealso cref= #isOutgoing() </seealso>
		public virtual bool Input
		{
			get
			{
				return Outgoing;
			}
		}

		/// <returns> true if the message is incoming (received from SWIFT), false other case; using the direction attribute. </returns>
		public virtual bool? Incoming
		{
			get
			{
				return this.direction == MessageIOType.incoming;
			}
		}

		/// <seealso cref= #isIncoming() </seealso>
		public virtual bool? Output
		{
			get
			{
				return Incoming;
			}
		}

		/// <seealso cref= #addStatus(SwiftMessageStatusInfo) </seealso>
		public virtual void setStatus(SwiftMessageStatusInfo status)
		{
			addStatus(status);
		}

		/// <summary>
		/// Returns true if the current status is equals to the parameter status </summary>
		/// <param name="status"> a status name </param>
		public virtual bool isStatus(string status)
		{
			return StringUtils.Equals(status, getStatus());
		}

		/// <summary>
		/// Returns true if the current status is equals to the parameter status </summary>
		/// <param name="status"> a status enum keyFget </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public boolean isStatus(Enum status)
		public virtual bool isStatus(Enum status)
		{
			if (status != null)
			{
				return isStatus(status.name());
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Retrieves from the status trail, the current status info; or <code>null</code> if none is found.
		/// </summary>
		public virtual SwiftMessageStatusInfo StatusInfo
		{
			get
			{
				IList<SwiftMessageStatusInfo> l = StatusTrail;
				if (l != null && l.Count > 0)
				{
					return l[l.Count - 1];
				}
				return null;
			}
		}

		/// <summary>
		/// Retrieves from the status trail, the status info before the current one; or <code>null</code> if none is found.
		/// </summary>
		public virtual SwiftMessageStatusInfo PreviousStatusInfo
		{
			get
			{
				IList<SwiftMessageStatusInfo> l = StatusTrail;
				if (l != null && l.Count >= 2)
				{
					return l[l.Count - 2];
				}
				return null;
			}
		}

		/// <summary>
		/// Tell if this message has any of the given statuses in his status <b>trail</b> </summary>
		/// <param name="statuses"> a list of statuses to check in the status trail </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public boolean contains(Enum... statuses)
		public virtual bool contains(params Enum[] statuses)
		{
			bool result = false;
			IList<SwiftMessageStatusInfo> l = StatusTrail;
			if (l != null && l.Count > 0)
			{
				foreach (SwiftMessageStatusInfo s in StatusTrail)
				{
					foreach (Enum e in statuses)
					{
						if (e != null && StringUtils.Equals(s.Name, e.name()))
						{
							result = true;
						}
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Tell if this message has any of the given statuses in his status <b>trail</b> </summary>
		/// <param name="statuses"> a list of statuses to check in the status trail </param>
		public virtual bool contains(params string[] statuses)
		{
			bool result = false;
			IList<SwiftMessageStatusInfo> l = StatusTrail;
			if (l != null && l.Count > 0)
			{
				foreach (SwiftMessageStatusInfo s in StatusTrail)
				{
					foreach (string e in statuses)
					{
						if (e != null && StringUtils.Equals(s.Name, e))
						{
							result = true;
						}
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Tell if this message has any of the given statuses as <b>current</b> status </summary>
		/// <param name="statuses"> a list of status names to check </param>
		public virtual bool isStatus(params string[] statuses)
		{
			foreach (string s in statuses)
			{
				if (isStatus(s))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Tell if this message has any of the given statuses as <b>current</b> status </summary>
		/// <param name="statuses"> a list of status enum keys to check </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public boolean isStatus(Enum... statuses)
		public virtual bool isStatus(params Enum[] statuses)
		{
			foreach (Enum e in statuses)
			{
				if (e != null && isStatus(e.name()))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Get the last saved status data of this message or empty string if not found </summary>
		/// <param name="statuses"> an array of statuses to check data into, if <code>null</code> all message statuses are checked for data </param>
		/// <returns> the most recent (last) status data found </returns>
		public virtual string getLastData(params string[] statuses)
		{
			IList<SwiftMessageStatusInfo> l = StatusTrail;
			if (l != null && l.Count > 0)
			{
				for (int i = l.Count - 1; i >= 0 ;i--)
				{
					string d = l[i].Data;
					if (d != null && (statuses == null || ArrayUtils.contains(statuses, l[i].Name)))
					{
						return d;
					}
				}
			}
			return "";
		}

		/// <summary>
		/// Same as <seealso cref="#getLastData(String...)"/> passing a null array parameter
		/// </summary>
		public virtual string LastData
		{
			get
			{
				return getLastData((string[])null);
			}
		}

		/// <summary>
		/// Finds the first status info from the status trail, with a name matching any of the given status names, or returns <code>null</code> if not found
		/// This method is similar to <seealso cref="#findStatusInfoLast(String...)"/> but checks the status trail in ascending order from oldest to latest.
		/// @since 7.8.8
		/// </summary>
		public virtual SwiftMessageStatusInfo findStatusInfo(params string[] statusNames)
		{
			IList<SwiftMessageStatusInfo> l = StatusTrail;
			if (l != null && l.Count > 0)
			{
				foreach (SwiftMessageStatusInfo sms in l)
				{
					if (ArrayUtils.contains(statusNames, sms.Name))
					{
						return sms;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Finds the first status info from the status trail, with the given name or returns <code>null</code> if not found </summary>
		/// <seealso cref= #findStatusInfo(String...) </seealso>
		public virtual SwiftMessageStatusInfo findStatusInfo(string statusName)
		{
			string[] statuses = new string[] {statusName};
			return findStatusInfo(statuses);
		}

		/// <summary>
		/// Finds the last status info from the status trail, with a name matching any of the given status names, or returns <code>null</code> if not found.
		/// This method is similar to <seealso cref="#findStatusInfo(String...)"/> but checks the status trail in descending order from latest to oldest.
		/// @since 7.8.8
		/// </summary>
		public virtual SwiftMessageStatusInfo findStatusInfoLast(params string[] statusNames)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftMessageStatusInfo> l = getStatusTrail();
			IList<SwiftMessageStatusInfo> l = StatusTrail;
			if (l != null && l.Count > 0)
			{
				for (int i = l.Count - 1; i >= 0 ;i--)
				{
					if (ArrayUtils.contains(statusNames, l[i].Name))
					{
						return l[i];
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Finds the last status info from the status trail, with the given name or returns <code>null</code> if not found </summary>
		/// <seealso cref= #findStatusInfoLast(String...)
		/// @since 7.8.8 </seealso>
		public virtual SwiftMessageStatusInfo findStatusInfoLast(string statusName)
		{
			string[] statuses = new string[] {statusName};
			return findStatusInfoLast(statuses);
		}

		/// <summary>
		/// Adds a new note to the messages, initializing the note list if necessary. </summary>
		/// <param name="n"> note to add </param>
		public virtual void addNote(SwiftMessageNote n)
		{
			if (notes == null)
			{
				notes = new List<>();
			}
			notes.Add(n);
		}

		/// <summary>
		/// Iterate message properties and truncate all needed values issuing a log entry for each truncated one
		/// </summary>
		public virtual void sanityCheckProperties()
		{
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Map<String, String> p = getProperties();
				IDictionary<string, string> p = Properties;
				foreach (KeyValuePair<string, string> entry in p)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String v = entry.getValue();
					string v = entry.Value;
					if (v != null && v.Length > 500)
					{
						log.severe("Value for key=" + entry.Key + " too long, will be truncated. value=" + v);
						p[entry.Key] = v.Substring(0, 500);
					}
					if (entry.Key.length() > 200)
					{
						log.severe("Key too long: " + entry.Key + " will be truncated");
						p.Remove(entry.Key);
						p[entry.Key.Substring(0, 200)] = v;
					}
				}
			}
			catch (Exception e)
			{
				log.log(java.util.logging.Level.WARNING, "Error cheking properties", e);
			}
		}

		/// <summary>
		/// Get the value of the property under the given key or <code>null</code> if the key is not found or its value is empty
		/// </summary>
		public virtual string getProperty(string key)
		{
			if (this.properties != null)
			{
				return StringUtils.trimToNull(this.properties[key]);
			}
			return null;
		}

		/// <seealso cref= #getProperty(String) </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public String getProperty(Enum key)
		public virtual string getProperty(Enum key)
		{
			return getProperty(key.name());
		}

		/// <summary>
		/// Sets a property using the given key and value, if the key exists the value is overwritten.
		/// </summary>
		public virtual void setProperty(string key, string value)
		{
			if (this.properties == null)
			{
				this.properties = new Dictionary<>();
			}
			if (StringUtils.isNotBlank(value))
			{
				this.properties[key] = value;
			}
		}

		/// <seealso cref= #setProperty(String, String) </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public void setProperty(Enum key, String value)
		public virtual void setProperty(Enum key, string value)
		{
			setProperty(key.name(), value);
		}

		/// <summary>
		/// Returns true if the message has a property with the given key name and value "true"
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean getPropertyBoolean(final String key)
		public virtual bool getPropertyBoolean(string key)
		{
			return propertyEquals("true", key);
		}

		/// <seealso cref= #getPropertyBoolean(String) </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public boolean getPropertyBoolean(final Enum key)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual bool getPropertyBoolean(Enum key)
		{
			return getPropertyBoolean(key.name());
		}

		/// <summary>
		/// Checks if a given property has a specific value </summary>
		/// <param name="key"> the property key to check </param>
		/// <param name="expectedValue"> the expected value </param>
		/// <returns> true if the property is set and the value matches, false otherwise
		/// @since 7.10.4 </returns>
		public virtual bool propertyEquals(string key, string expectedValue)
		{
			return StringUtils.Equals(expectedValue, getProperty(key));
		}

		/// <seealso cref= #propertyEquals(String, String)
		/// @since 7.10.4 </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public boolean propertyEquals(Enum key, String expectedValue)
		public virtual bool propertyEquals(Enum key, string expectedValue)
		{
			return propertyEquals(key.name(), expectedValue);
		}

		/// <seealso cref= #propertyEquals(String, String)
		/// @since 7.10.4 </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public boolean propertyEquals(Enum key, Enum expectedValue)
		public virtual bool propertyEquals(Enum key, Enum expectedValue)
		{
			return propertyEquals(key.name(), expectedValue.name());
		}

		/// <summary>
		/// Returns the internal unique id as fixed length string, padded with zeros. </summary>
		/// <returns> string with 10 characters with this message identifier </returns>
		public virtual string PaddedId
		{
			get
			{
				string id = this.id != null? this.id.ToString() : "0";
				return StringUtils.leftPad(id, 10, "0");
			}
		}

		/// <summary>
		/// Creates a full copy of the current message object into another message.
		/// <para>The implementation works as a copy constructor. All attributes are replicated into
		/// new instances in the target message. The only fields that are not copied are the Long id
		/// because they are intended for ORM (persistence) autogeneration. Preexisting data in the
		/// target message will be overwritten.
		/// </para>
		/// </summary>
		/// <param name="msg"> target message
		/// @since 7.7 </param>
		public virtual void copyTo(AbstractSwiftMessage msg)
		{
			msg.Message = Message;
			msg.Identifier = Identifier;
			msg.Sender = Sender;
			msg.Receiver = Receiver;
			msg.Direction = Direction;
			msg.Checksum = Checksum;
			msg.ChecksumBody = ChecksumBody;
			msg.LastModified = LastModified;
			msg.CreationDate = CreationDate;

			msg.StatusTrail = null;
			foreach (SwiftMessageStatusInfo status in StatusTrail)
			{
				msg.addStatus(new SwiftMessageStatusInfo(status.Comments, status.CreationDate, status.CreationUser, status.Name, status.Data));
			}
			msg.setStatus(getStatus());

			msg.Notes = null;
			foreach (SwiftMessageNote note in Notes)
			{
				SwiftMessageNote copy = new SwiftMessageNote(note.CreationUser, note.Text);
				copy.CreationDate = note.CreationDate;
				msg.addNote(copy);
			}

			msg.Properties = Properties;
			msg.Filename = Filename;
			msg.FileFormat = FileFormat;
			msg.Reference = Reference;
			msg.Currency = Currency;
			msg.Amount = Amount;
			msg.ValueDate = ValueDate;
			msg.TradeDate = TradeDate;

			msg.Revisions = null;
			foreach (SwiftMessageRevision rev in Revisions)
			{
				SwiftMessageRevision copy = new SwiftMessageRevision();
				copy.CreationDate = rev.CreationDate;
				copy.CreationUser = rev.CreationUser;
				copy.Message = rev.Message;
				copy.Json = rev.Json;
				msg.addRevision(copy);
			}
		}

		/// <summary>
		/// Snapshots of message content used to track its changes history
		/// @since 7.8 </summary>
		/// <returns> this message revisions or empty list if none is set </returns>
		public virtual IList<SwiftMessageRevision> Revisions
		{
			get
			{
				return revisions;
			}
			set
			{
				this.revisions = value;
			}
		}


		/// <summary>
		/// Adds a new revision to the messages, initializing the revision list if necessary. </summary>
		/// <param name="revision"> revision to add
		/// @since 7.8 </param>
		public virtual void addRevision(SwiftMessageRevision revision)
		{
			if (this.revisions == null)
			{
				this.revisions = new List<>();
			}
			this.revisions.Add(revision);
		}

		/// <summary>
		/// Creates a new revision of the message and adds it to the revision list. </summary>
		/// <seealso cref= SwiftMessageRevision#SwiftMessageRevision(AbstractSwiftMessage)
		/// @since 7.8 </seealso>
		/// <returns> the revision added </returns>
		public virtual SwiftMessageRevision createRevision()
		{
			SwiftMessageRevision rev = new SwiftMessageRevision(this);
			addRevision(rev);
			return rev;
		}

		/// <summary>
		/// @since 7.10.8
		/// </summary>
		public virtual DateTime ValueDate
		{
			get
			{
				return valueDate;
			}
			set
			{
				this.valueDate = value;
			}
		}


		/// <summary>
		/// @since 7.10.8
		/// </summary>
		public virtual DateTime TradeDate
		{
			get
			{
				return tradeDate;
			}
			set
			{
				this.tradeDate = value;
			}
		}


		/// <summary>
		/// True if the message is an <seealso cref="MtSwiftMessage"/>, false otherwise
		/// @since 7.8
		/// </summary>
		public virtual bool MT
		{
			get
			{
				return this.GetType().Name.StartsWith("Mt", StringComparison.Ordinal);
			}
		}

		/// <summary>
		/// True if the message is an <seealso cref="MxSwiftMessage"/>, false otherwise
		/// @since 7.8
		/// </summary>
		public virtual bool MX
		{
			get
			{
				return this.GetType().Name.StartsWith("Mx", StringComparison.Ordinal);
			}
		}

		/// <summary>
		/// Returns the enumeration value corresponding to this message. </summary>
		/// <returns> standard enumeration value or null if messages cannot be identified as either standard
		/// @since 7.8.3 </returns>
		public virtual MessageStandardType messageStandardType()
		{
			if (MT)
			{
				return MessageStandardType.MT;
			}
			else if (MX)
			{
				return MessageStandardType.MX;
			}
			return null;
		}

		/// <summary>
		/// Original file format if applies. 
		/// @since 7.8.4 </summary>
		/// <returns> this message file format if any is set </returns>
		public virtual FileFormat FileFormat
		{
			get
			{
				return this.fileFormat;
			}
			set
			{
				this.fileFormat = value;
			}
		}


		/// <summary>
		/// Message reference
		/// </summary>
		public virtual string Reference
		{
			get
			{
				return reference;
			}
			set
			{
				this.reference = value;
			}
		}


		/// <summary>
		/// Main currency </summary>
		/// <returns> the main currency or <code>null</code> if non is present or does not apply for this message type
		/// @since 7.8.8 </returns>
		public virtual string Currency
		{
			get
			{
				return currency;
			}
			set
			{
				this.currency = value;
			}
		}


		/// <summary>
		/// Main amount </summary>
		/// <returns> the main amount or <code>null</code> if non is present or does not apply for this message type
		/// @since 7.8.8 </returns>
		public virtual decimal Amount
		{
			get
			{
				return amount;
			}
			set
			{
				this.amount = value;
			}
		}


		/// <summary>
		/// Applies the parameter regex to the message identifier.
		/// <br>
		/// <para>
		/// Notice the identifier will contain:
		/// <ul>
		/// <li>For MT: fin.&lt;msgtype&gt;[.&lt;mug|variant&gt;] for example fin.103.STP, fin.103.REMIT, fin.202, fin.202.COV</li>
		/// <li>For MX: &lt;bus.area&gt;.&lt;msgtype&gt;.&lt;variant&gt;.&lt;version&gt; for example: camt.034.001.02, ifds.001.001.01</li>
		/// </ul>
		/// So for example <code>fin.*</code> matches all MT messages, <code>fin.*STP</code> matches all STP MT messages
		/// and <code>camt.*</code> matches all MX messages in the category camt. 
		/// 
		/// 
		/// @since 7.8.4
		/// </para>
		/// </summary>
		/// <param name="regex"> to match </param>
		/// <returns> true if regex match identifier, false otherwise </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean match(final String regex)
		public virtual bool match(string regex)
		{
			return this.identifier != null && StringUtils.isNotBlank(regex) && this.identifier.matches(regex);
		}

		/// <summary>
		/// If the amount is set, returns its currency and value formatted using the default locale. </summary>
		/// <seealso cref= #getAmount() </seealso>
		/// <seealso cref= #formattedAmount(Locale, boolean) </seealso>
		/// <returns> formatted amount for example USD 123,456.78 or empty string if amount is not set
		/// @since 7.8.8 </returns>
		public virtual string formattedAmount()
		{
			return formattedAmount(null, true);
		}

		/// <summary>
		/// If the amount is set, returns its value formatted for the given locale. </summary>
		/// <seealso cref= #getAmount() </seealso>
		/// <param name="locale"> a specific locale to use or <code>null</code> to use the current default locale </param>
		/// <param name="includeCurrency"> if true and the currency is set, the formatted value will be prefixed by the currency symbol </param>
		/// <returns> formatted amount for example USD 123,456.78 or empty string if amount is not set
		/// @since 7.8.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String formattedAmount(final Locale locale, boolean includeCurrency)
		public virtual string formattedAmount(Locale locale, bool includeCurrency)
		{
			StringBuilder result = new StringBuilder();
			if (this.amount != null)
			{
				if (includeCurrency && this.currency != null)
				{
					result.Append(this.currency);
					result.Append(" ");
				}
				NumberFormat formatter = locale != null? NumberFormat.getInstance(locale) : NumberFormat.Instance;
				result.Append(formatter.format(this.amount));
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns true if this message identifier is <seealso cref="#IDENTIFIER_ACK"/>
		/// 
		/// <para>The implementation does not check the inner content of the message.
		/// 
		/// </para>
		/// <para>It is safe to use this method to check if message is effectively 
		/// and acknowledge only when the API is used with the provided subclasses
		/// for MT and MX and when the identifier has not been altered by the accesor.
		///  
		/// </para>
		/// </summary>
		/// <returns> true if the identifier is <seealso cref="#IDENTIFIER_ACK"/> false otherwise
		/// @since 7.8.8 </returns>
		public virtual bool identifiedAsACK()
		{
			return StringUtils.Equals(this.identifier, IDENTIFIER_ACK);
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
			AbstractSwiftMessage that = (AbstractSwiftMessage) o;
			return Objects.Equals(message_Renamed, that.message_Renamed) && Objects.Equals(identifier, that.identifier) && Objects.Equals(sender, that.sender) && Objects.Equals(receiver, that.receiver) && direction == that.direction && Objects.Equals(checksum, that.checksum) && Objects.Equals(checksumBody, that.checksumBody) && Objects.Equals(lastModified, that.lastModified) && Objects.Equals(creationDate, that.creationDate) && Objects.Equals(statusTrail, that.statusTrail) && Objects.Equals(status, that.status) && Objects.Equals(notes, that.notes) && Objects.Equals(properties, that.properties) && Objects.Equals(filename, that.filename) && fileFormat == that.fileFormat && Objects.Equals(reference, that.reference) && Objects.Equals(currency, that.currency) && Objects.Equals(amount, that.amount) && Objects.Equals(revisions, that.revisions) && Objects.Equals(valueDate, that.valueDate) && Objects.Equals(tradeDate, that.tradeDate);
		}

		public override int GetHashCode()
		{
			return Objects.hash(message_Renamed, identifier, sender, receiver, direction, checksum, checksumBody, lastModified, creationDate, statusTrail, status, notes, properties, filename, fileFormat, reference, currency, amount, revisions, valueDate, tradeDate);
		}

		/// <summary>
		/// Returns true if this message identifier is <seealso cref="#IDENTIFIER_NAK"/>
		/// 
		/// <para>The implementation does not check the inner content of the message.
		/// 
		/// </para>
		/// <para>It is safe to use this method to check if message is effectively 
		/// and non-acknowledge only when the API is used with the provided subclasses
		/// for MT and MX and when the identifier has not been altered by the accesor.
		///  
		/// </para>
		/// </summary>
		/// <returns> true if the identifier is <seealso cref="#IDENTIFIER_NAK"/> false otherwise
		/// @since 7.8.8 </returns>
		public virtual bool identifiedAsNAK()
		{
			return StringUtils.Equals(this.identifier, IDENTIFIER_NAK);
		}

		/// <summary>
		/// Creates a BIC11 from the given address. 
		/// If the address contains a logical terminal it wil be dropped.
		/// If the address does not contain a branch, the default XXX will be used </summary>
		/// <param name="address"> a BIC8, BIC11 or full logical terminal address (BIC12) </param>
		/// <returns> the bic11 or null if address is null
		/// @since 7.9.5 </returns>
		/// <seealso cref= BIC#getBic11() </seealso>
		protected internal virtual string bic11(string address)
		{
			if (address != null)
			{
				return (new BIC(address)).Bic11;
			}
			return null;
		}

		/// <summary>
		/// Returns the correspondent BIC code from the headers.<br>
		/// For an outgoing message, the BIC address identifies the receiver of the message. Where for an incoming message it identifies the sender of the message. </summary>
		/// <returns> the correspondent BIC code or null if headers are not properly set
		/// @since 7.9.5 </returns>
		public virtual BIC CorrespondentBIC
		{
			get
			{
				if (Outgoing)
				{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String receiver = getReceiver();
					string receiver = Receiver;
					if (receiver != null)
					{
						return new BIC(receiver);
					}
				}
				if (Incoming)
				{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String sender = getSender();
					string sender = Sender;
					if (sender != null)
					{
						return new BIC(sender);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// The year when the message was created, extracted from the <seealso cref="#getCreationDate()"/>
		/// Helper read-only property useful for faceting search </summary>
		/// <returns> the year in YYYY format
		/// @since 7.9.7 </returns>
		public virtual string CreationYear
		{
			get
			{
				return Convert.ToString(creationDate.Year);
			}
		}

		/// <summary>
		/// The month when the message was created, extracted from the <seealso cref="#getCreationDate()"/>
		/// Helper read-only property useful for faceting search </summary>
		/// <returns> the month number, 1 based and padded with zero, such as 01, 02, 12
		/// @since 7.9.7 </returns>
		public virtual string CreationMonth
		{
			get
			{
				int imonth = creationDate.Month + 1;
				return (imonth < 10 ? "0" : "") + Convert.ToString(imonth);
			}
		}

		/// <summary>
		/// The day of month when the message was created, extracted from the <seealso cref="#getCreationDate()"/>
		/// Helper read-only property useful for faceting search </summary>
		/// <returns> the day of month, padded with zero, such as 01, 02, 31
		/// @since 7.9.7 </returns>
		public virtual string CreationDayOfMonth
		{
			get
			{
				int iday = creationDate.Day;
				return (iday < 10 ? "0" : "") + Convert.ToString(iday);
			}
		}

		/// <summary>
		/// Gets a JSON representation of this message.
		/// @since 7.10.3
		/// </summary>
		public virtual string toJson()
		{
			return toJsonImpl();
		}

		/// <summary>
		/// Isolated Json implementation, useful for mocked test </summary>
		/// <returns> json serialization using Gson
		/// @since 7.10.6 </returns>
		protected internal virtual string toJsonImpl()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().setPrettyPrinting().create();
			Gson gson = (new GsonBuilder()).setPrettyPrinting().create();
			return gson.toJson(this);
		}

		/// <summary>
		/// For MT messages returns the category number and for MX messages return the business process.
		/// For example for MT103 returns 1 and for pacs.004.001.06 returns pacs </summary>
		/// <returns> a string with the category or empty if the identifier is invalid or not present
		/// @since 7.10.4 </returns>
		public virtual string Category
		{
			get
			{
				if (StringUtils.isBlank(this.identifier))
				{
					return "";
				}
				if (MT)
				{
					return (new MtId(this.identifier)).category();
				}
				else
				{
					MxBusinessProcess proc = (new MxId(this.identifier)).BusinessProcess;
					if (proc != null)
					{
						return proc.name();
					}
				}
				return "";
			}
		}

		/// <summary>
		/// Get the message type.<br>
		/// For MTs this is the MT type number present in the identifier attribute. For example for fin.103.STP returns 103
		/// For MX returns the same as #getIdentifier()
		/// </summary>
		public virtual string MessageType
		{
			get
			{
				if (this.identifier != null && MT)
				{
					return this.identifier.replaceAll("\\D+","");
				}
				else
				{
					return Identifier;
				}
			}
		}

	}
}