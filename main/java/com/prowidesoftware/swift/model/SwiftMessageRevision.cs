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
	/// A revision is a snapshot of message content and is used to track the history of changes in a message.
	/// Applications may use to store revisions each time a message is edited.
	/// 
	/// <para>XML metadata may be used to override or augment these JPA annotations.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Entity @Table(name="swift_msg_revision") public class SwiftMessageRevision
	public class SwiftMessageRevision
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Id @GeneratedValue(strategy = GenerationType.IDENTITY) private Long id;
		private long? id;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(name = "creation_date") private java.util.Calendar creationDate = java.util.Calendar.getInstance();
		private DateTime creationDate = new DateTime();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 40, name="creation_user") private String creationUser;
		private string creationUser;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Lob private String message;
		private string message;

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
			SwiftMessageRevision that = (SwiftMessageRevision) o;
			return Objects.Equals(creationDate, that.creationDate) && Objects.Equals(creationUser, that.creationUser) && Objects.Equals(message, that.message);
		}

		public override int GetHashCode()
		{
			return Objects.hash(creationDate, creationUser, message);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Lob @Basic(fetch=LAZY) private String json;
		private string json;

		public SwiftMessageRevision() : base()
		{
		}

		/// <summary>
		/// Creates a message revision from a messages.<br> 
		/// Sets the revision message content with the actual message content. 
		/// And sets the revision creation date and creation user with information
		/// taken from the current status info. If the message has no status, this
		/// fields are left null. </summary>
		/// <param name="msg"> message for the snapshot </param>
		public SwiftMessageRevision(AbstractSwiftMessage msg) : base()
		{
			SwiftMessageStatusInfo status = msg.StatusInfo;
			if (status != null)
			{
				this.creationDate = status.CreationDate;
				this.creationUser = status.CreationUser;
			}
			this.message = msg.message();
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


		public virtual string CreationUser
		{
			get
			{
				return creationUser;
			}
			set
			{
				this.creationUser = value;
			}
		}


		public virtual string Message
		{
			get
			{
				return message;
			}
			set
			{
				this.message = value;
			}
		}


		public virtual string Json
		{
			get
			{
				return json;
			}
			set
			{
				this.json = value;
			}
		}


	}

}