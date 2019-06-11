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
	/// Comments associated to a message for application only usage (not part of the standard).
	/// 
	/// <para>XML metadata may be used to override or augment these JPA annotations.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.0
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Entity @Table(name="swift_msg_note") public class SwiftMessageNote
	public class SwiftMessageNote
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Id @GeneratedValue(strategy = GenerationType.IDENTITY) private Long id;
		private long? id;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(name = "creation_date") private java.util.Calendar creationDate;
		private DateTime creationDate;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 40, name="creation_user") private String creationUser;
		private string creationUser;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Lob private String text;
		private string text;

		public SwiftMessageNote() : base()
		{
		}

		public SwiftMessageNote(string creationUser, string text) : base()
		{
			this.creationDate = new DateTime();
			this.creationUser = creationUser;
			this.text = text;
		}

		/// <returns> the id </returns>
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


		/// <returns> the creationDate </returns>
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


		/// <returns> the text </returns>
		public virtual string Text
		{
			get
			{
				return text;
			}
			set
			{
				this.text = value;
			}
		}


	}

}