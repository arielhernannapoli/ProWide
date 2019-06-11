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
namespace com.prowidesoftware.swift.model
{


	/// <summary>
	/// Status tracking record for application only usage (not part of the standard).<br>
	/// The status name identifier is modeled with plain String, nevertheless 
	/// the usage of an application specific enumeration is encourage; 
	/// constructors and methods with raw Enum parameters are provided.
	/// 
	/// <para>XML metadata may be used to override or augment these JPA annotations.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.0
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Entity @Table(name="swift_msg_status") public class SwiftMessageStatusInfo implements Cloneable
	public class SwiftMessageStatusInfo : ICloneable
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(SwiftMessageStatusInfo.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftMessageStatusInfo).FullName);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Id @GeneratedValue(strategy = GenerationType.IDENTITY) private Long id;
		private long? id;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 50) private String name;
		private string name;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 200) private String comments;
		private string comments;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(name = "creation_date") private java.util.Calendar creationDate = java.util.Calendar.getInstance();
		private DateTime creationDate = new DateTime();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 40, name="creation_user") private String creationUser;
		private string creationUser;

		/// <summary>
		/// Additional information regarding messages changes and manipulation through status changes.
		/// Intended for example to store JSON output from the process that generated the status. 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Lob @Basic(fetch=LAZY) private String data;
		private string data;

		/// <summary>
		/// No arguments constructor
		/// </summary>
		public SwiftMessageStatusInfo() : base()
		{
			this.creationDate = new DateTime(); //this cannot be null, default to now
		}

		/// <summary>
		/// Constructor with parameter for all fields. </summary>
		/// <param name="comments"> optional user comments associated to the message </param>
		/// <param name="creationDate"> date and time of status creation </param>
		/// <param name="creationUser"> user that creates the status </param>
		/// <param name="name"> status name </param>
		/// <param name="data"> optional additional text data associated to the status processing </param>
		public SwiftMessageStatusInfo(string comments, DateTime creationDate, string creationUser, string name, string data) : this()
		{
			this.comments = comments;
			this.creationDate = creationDate;
			this.creationUser = creationUser;
			this.name = name;
			this.data = data;
		}

		/// <seealso cref= #SwiftMessageStatusInfo(String, Calendar, String, String) 
		/// with null data. </seealso>
		public SwiftMessageStatusInfo(string comments, DateTime creationDate, string creationUser, string name) : this(comments, creationUser, name, null)
		{
			if (creationDate != null)
			{
				this.creationDate = creationDate;
			}
		}

		/// <seealso cref= #SwiftMessageStatusInfo(String, Calendar, String, String) 
		/// with creationDate initialized to now (Calendar.getInstance()). </seealso>
		public SwiftMessageStatusInfo(string comments, string creationUser, string name, string data) : this(comments, new DateTime(), creationUser, name, data)
		{
		}

		/// <seealso cref= #SwiftMessageStatusInfo(String, Calendar, String, String) 
		/// with creationDate initialized to now (Calendar.getInstance()) and null data. </seealso>
		public SwiftMessageStatusInfo(string comments, string creationUser, string name) : this(comments, new DateTime(), creationUser, name, null)
		{
		}

		/// <seealso cref= #SwiftMessageStatusInfo(String, Calendar, String, String)
		/// with Enum..name() and null data. </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public SwiftMessageStatusInfo(String comments, java.util.Calendar creationDate, String creationUser, Enum name)
		public SwiftMessageStatusInfo(string comments, DateTime creationDate, string creationUser, Enum name) : this(comments, creationUser, name.name(), null)
		{
			if (creationDate != null)
			{
				this.creationDate = creationDate;
			}
		}

		/// <seealso cref= #SwiftMessageStatusInfo(String, Calendar, String, String)
		/// with Enum..name(), creationDate initialized to now (Calendar.getInstance()). </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public SwiftMessageStatusInfo(String comments, String creationUser, Enum name, String data)
		public SwiftMessageStatusInfo(string comments, string creationUser, Enum name, string data) : this(comments, new DateTime(), creationUser, name.name(), data)
		{
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
			SwiftMessageStatusInfo that = (SwiftMessageStatusInfo) o;
			return Objects.Equals(name, that.name) && Objects.Equals(comments, that.comments) && Objects.Equals(creationDate, that.creationDate) && Objects.Equals(creationUser, that.creationUser);
		}

		public override int GetHashCode()
		{
			return Objects.hash(name, comments, creationDate, creationUser);
		}

		/// <seealso cref= #SwiftMessageStatusInfo(String, Calendar, String, String) 
		/// with Enum..name(), creationDate initialized to now (Calendar.getInstance()) and null data. </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public SwiftMessageStatusInfo(String comments, String creationUser, Enum name)
		public SwiftMessageStatusInfo(string comments, string creationUser, Enum name) : this(comments, new DateTime(), creationUser, name.name(), null)
		{
		}

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


		public virtual string Name
		{
			get
			{
				return name;
			}
		}

		public virtual SwiftMessageStatusInfo setName(string name)
		{
			this.name = name;
			return this;
		}

		public virtual string Comments
		{
			get
			{
				return comments;
			}
		}

		public virtual SwiftMessageStatusInfo setComments(string comments)
		{
			this.comments = comments;
			return this;
		}

		public virtual DateTime CreationDate
		{
			get
			{
				return creationDate;
			}
		}

		public virtual SwiftMessageStatusInfo setCreationDate(DateTime creationDate)
		{
			this.creationDate = creationDate;
			return this;
		}

		public virtual string CreationUser
		{
			get
			{
				return creationUser;
			}
		}

		public virtual SwiftMessageStatusInfo setCreationUser(string creationUser)
		{
			this.creationUser = creationUser;
			return this;
		}

		public virtual string Data
		{
			get
			{
				return data;
			}
		}

		public virtual SwiftMessageStatusInfo setData(string data)
		{
			this.data = data;
			return this;
		}

		public override string ToString()
		{
			return this.name;
		}

		public override object clone()
		{
			SwiftMessageStatusInfo result = new SwiftMessageStatusInfo();
			result.Comments = Comments;
			result.CreationDate = CreationDate;
			result.CreationUser = CreationUser;
			result.Data = Data;
			result.Id = Id;
			result.Name = Name;
			return result;
		}

	}

}