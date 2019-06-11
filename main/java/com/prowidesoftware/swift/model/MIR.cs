﻿using System;
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


	using SwiftFormatUtils = com.prowidesoftware.swift.utils.SwiftFormatUtils;

	/// <summary>
	/// This class models and parses the Message Input Reference (MIR), 
	/// String of 28 characters, always local to the sender of the message.
	/// It includes the date the sender sent the message to SWIFT,
	/// followed by the full LT address of the sender of the 
	/// message, and the sender's session and sequence to SWIFT.
	/// YYMMDD BANKBEBBAXXX 2222 123456<br><br>
	/// 
	/// <para>MIR and MOR are messages unique identifiers containing the date, 
	/// logical terminal (including branch code), session and sequence numbers. 
	/// Nevertheless this identifiers can be confusing sometimes because they must 
	/// be thought from SWIFT perspective.
	/// 
	/// </para>
	/// <para>A message created by the sender user/application is considered an 
	/// INPUT message, because it gets into the SWIFT network. When the message 
	/// is delivered and gets out of the network it is considered an OUTPUT message. 
	/// Therefore the headers of a sent message are not exactly the same as the 
	/// headers of the received message at the destination party. Analogous the 
	/// headers of a message that the receiving user/application gets from SWIFT 
	/// are not exactly the same as the headers when the message was created and 
	/// sent by the sending party.
	///  
	/// </para>
	/// <para>The usage of MIR and MOR are clear when analyzing system messages. 
	/// A non delivery warning for example, includes the original MIR of the 
	/// sent message, but not the MOR because the message was not delivered yet. 
	/// But a delivery confirmation on the other hand, includes both, the sender’s MIR 
	/// and the receiver’s MOR.<br>
	/// System messages provide MIR/MOR information using fields 106 and 107 respectively.
	/// 
	/// @since 6.0
	/// </para>
	/// </summary>
	public class MIR
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MIR).FullName);

		/// <param name="date"> </param>
		/// <param name="logicalTerminal"> </param>
		/// <param name="sessionNumber"> </param>
		/// <param name="sequenceNumber"> </param>
		public MIR(string date, string logicalTerminal, string sessionNumber, string sequenceNumber) : base()
		{
			this.date = date;
			this.logicalTerminal = logicalTerminal;
			this.sessionNumber = sessionNumber;
			this.sequenceNumber = sequenceNumber;
		}

		/// <summary>
		/// Creates a MIR object parsing the literal string value. 
		/// If the value is incorrect (cannot be parsed) the object will not be initialized. </summary>
		/// <param name="value"> the MIR value, it is expected to 28 characters length </param>
		public MIR(string value) : base()
		{
			if (value != null && value.Length == 28)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder(value);
				StringBuilder sb = new StringBuilder(value);

				int offset = 0;
				int len;

				len = 6;
				this.date = Convert.ToString(sb.subSequence(offset, offset + len));
				offset += len;

				len = 12;
				this.logicalTerminal = Convert.ToString(sb.subSequence(offset, offset + len));
				offset += len;

				len = 4;
				this.sessionNumber = Convert.ToString(sb.subSequence(offset, offset + len));
				offset += len;

				len = 6;
				this.sequenceNumber = Convert.ToString(sb.subSequence(offset, offset + len));
			}
			else
			{
				log.severe("invalid MIR value " + value);
			}
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		public MIR() : base()
		{
		}

		/// <summary>
		/// 6 characters string containing the date field of the MIR.
		/// </summary>
		private string date;

		/// <summary>
		/// String of 12 characters containing the logical terminal field of the MIR
		/// (address of the sender of the message). </summary>
		/// <seealso cref= "MIR on the WIFE Wiki" </seealso>
		private string logicalTerminal;

		/// <summary>
		/// String of 4 characters containing the session number field of the MIR. </summary>
		/// <seealso cref= "MIR on the WIFE Wiki" </seealso>
		private string sessionNumber;

		/// <summary>
		/// String of 6 characters containing the sequence number field of the MIR. </summary>
		/// <seealso cref= "MIR on the WIFE Wiki" </seealso>
		private string sequenceNumber;

		/// <returns> the date </returns>
		public virtual string getDate()
		{
			return date;
		}

		/// <param name="date"> a date formatted as YYMMDD </param>
		public virtual void setDate(string date)
		{
			this.date = date;
		}

		/// <summary>
		/// Sets a date from a calendar, formatting it as YYMMDD </summary>
		/// <param name="date"> a date
		/// @since 7.10.4 </param>
		public virtual void setDate(DateTime date)
		{
			this.date = SwiftFormatUtils.getDate2(date);
		}

		/// <returns> the logical terminal </returns>
		public virtual string LogicalTerminal
		{
			get
			{
				return logicalTerminal;
			}
			set
			{
				this.logicalTerminal = value;
			}
		}


		/// <returns> the session number </returns>
		public virtual string SessionNumber
		{
			get
			{
				return sessionNumber;
			}
			set
			{
				this.sessionNumber = value;
			}
		}


		/// <returns> the sequence number </returns>
		public virtual string SequenceNumber
		{
			get
			{
				return sequenceNumber;
			}
			set
			{
				this.sequenceNumber = value;
			}
		}


		/// <summary>
		/// Gets the full MIR (Message Input Reference) string of 28 
		/// characters containing the sender's date, LT address,
		/// session and sequence:<br>
		/// for example YYMMDDBANKBEBBAXXX2222123456<br>
		/// </summary>
		/// <returns> a String with MIR, returns null if all MIR components are null </returns>
		public virtual string MIR
		{
			get
			{
				if (date == null && logicalTerminal == null && sessionNumber == null && sequenceNumber == null)
				{
					return null;
				}
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final StringBuilder v = new StringBuilder();
				StringBuilder v = new StringBuilder();
				if (date != null)
				{
					v.Append(date);
				}
				if (logicalTerminal != null)
				{
					v.Append(logicalTerminal);
				}
				if (sessionNumber != null)
				{
					v.Append(sessionNumber);
				}
				if (sequenceNumber != null)
				{
					v.Append(sequenceNumber);
				}
				return v.ToString();
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
			MIR mir = (MIR) o;
			return Objects.Equals(date, mir.date) && Objects.Equals(logicalTerminal, mir.logicalTerminal) && Objects.Equals(sessionNumber, mir.sessionNumber) && Objects.Equals(sequenceNumber, mir.sequenceNumber);
		}

		public override int GetHashCode()
		{
			return Objects.hash(date, logicalTerminal, sessionNumber, sequenceNumber);
		}

		/// <summary>
		/// Returns this MIR date as Calendar.
		/// This implementation uses <seealso cref="SwiftFormatUtils#getDate2(String)"/> </summary>
		/// <returns> the parsed date or null if MIR date is invalid or not set
		/// @since 7.8.8 </returns>
		public DateTime DateAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getDate2(this.date);
			}
		}
	}
}