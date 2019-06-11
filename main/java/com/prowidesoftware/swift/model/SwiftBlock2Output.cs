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
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Base class for SWIFT <b>Application Header Block (block 2)
	/// for OUTPUT (from SWIFT)</b>.<br>
	/// This block is used to construct messages that have been 
	/// <i>output</i> from the SWIFT network. From the application point
	/// of view, it correspond to the <i>RECEIVED</i> messages.<br><br>
	/// 
	/// <para>It's value is fixed-length and continuous with no field delimiters. 
	/// This class contains its elements as individual attributes for 
	/// easier management of the block value.
	/// 
	/// </para>
	/// <para>For a received message, a message being output from SWIFT, the 
	/// SwiftBlock2Output includes explicit information regarding the MIR. 
	/// This is sometimes confusing because it is an output block with an 
	/// input reference. The important thing to understand here is that the 
	/// MIR information is related to the original sender of the message that 
	/// has been received. The attributes of this header (block 2 output) are 
	/// explicitly documented as MIR information by SWIFT.
	/// 
	/// </para>
	/// <para>The MOR itself could be created combining information from block 1 
	/// and 2 but it usually does not make sense.
	/// 
	/// @since 4.0
	/// </para>
	/// </summary>
	/// <seealso cref= MIR </seealso>
	//TODO: add parameter checks (Validate.*) and complete javadocs 
	[Serializable]
	public class SwiftBlock2Output : SwiftBlock2
	{
		private const long serialVersionUID = 6067091531833134527L;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(SwiftBlock2.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftBlock2).FullName);
		private static readonly string SEPARATOR = "\", \n";

		/// <summary>
		/// String of 4 characters containing the input time with respect to the sender
		/// </summary>
		private string senderInputTime;

		/// <summary>
		/// Date part of the MIR in YYMMDD format.
		/// </summary>
		private string MIRDate_Renamed;

		/// <summary>
		/// String of 12 characters containing the logical terminal field of the MIR
		/// (address of the sender of the message).
		/// 
		/// </summary>
		private string MIRLogicalTerminal_Renamed;

		/// <summary>
		/// String of 4 characters containing the session number field of the MIR.
		/// 
		/// </summary>
		private string MIRSessionNumber_Renamed;

		/// <summary>
		/// String of 6 characters containing the sequence number field of the MIR.
		/// 
		/// </summary>
		private string MIRSequenceNumber_Renamed;

		/// <summary>
		/// String of 6 characters containing the Output date local 
		/// to the receiver, written in the following format: YYMMDD
		/// </summary>
		private string receiverOutputDate;

		/// <summary>
		/// String of 4 characters containing the Output time local 
		/// to the receiver, written in the following format: HHMM
		/// </summary>
		private string receiverOutputTime;

		/// <summary>
		/// Constructor for specific values
		/// </summary>
		/// <param name="messageType"> the message type </param>
		/// <param name="senderInputTime"> the input time </param>
		/// <param name="MIRDate"> date </param>
		/// <param name="MIRLogicalTerminal"> logical terminal </param>
		/// <param name="MIRSessionNumber"> session number </param>
		/// <param name="MIRSequenceNumber"> message sequence number </param>
		/// <param name="receiverOutputDate"> receiver date </param>
		/// <param name="receiverOutputTime"> receiver time </param>
		/// <param name="messagePriority"> the message priority (S=system, U=urgent, N=normal) </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftBlock2Output(final String messageType, final String senderInputTime, final String MIRDate, final String MIRLogicalTerminal, final String MIRSessionNumber, final String MIRSequenceNumber, final String receiverOutputDate, final String receiverOutputTime, final String messagePriority)
		public SwiftBlock2Output(string messageType, string senderInputTime, string MIRDate, string MIRLogicalTerminal, string MIRSessionNumber, string MIRSequenceNumber, string receiverOutputDate, string receiverOutputTime, string messagePriority) : base()
		{
			this.output = true;
			this.messageType = messageType;
			this.senderInputTime = senderInputTime;
			this.MIRDate_Renamed = MIRDate;
			this.MIRLogicalTerminal_Renamed = MIRLogicalTerminal;
			this.MIRSessionNumber_Renamed = MIRSessionNumber;
			this.MIRSequenceNumber_Renamed = MIRSequenceNumber;
			this.receiverOutputDate = receiverOutputDate;
			this.receiverOutputTime = receiverOutputTime;
			this.messagePriority = messagePriority;
		}

		/// <summary>
		/// Creates the block with lenient false, meaning it expects a fixed length value.
		/// Example of supported values:<br> 
		/// "O1001200970103BANKBEBBAXXX22221234569701031201N" or "2:O1001200970103BANKBEBBAXXX22221234569701031201N"
		/// </summary>
		/// <param name="value"> a fixed length string of 46 (starting with 'O') or 49 (starting with '2:O') characters containing the blocks value </param>
		/// <exception cref="IllegalArgumentException"> if parameter is not 47 or 49 characters </exception>
		/// <seealso cref= #SwiftBlock2Output(String, boolean) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftBlock2Output(final String value)
		public SwiftBlock2Output(string value) : this(value, false)
		{
		}

		/// <summary>
		/// Creates a block 2 output object setting attributes by parsing the string argument containing the blocks value. 
		/// This value can be in different flavors because some fields are optional.<br>
		/// </summary>
		/// <param name="value"> string containing the entire blocks value </param>
		/// <param name="lenient"> if true the value will be parsed with a best effort heuristic, if false it will throw a IllegalArgumentException if the value has an invalid total size </param>
		/// <seealso cref= #setValue(String, boolean)
		/// @since 7.7 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftBlock2Output(final String value, boolean lenient)
		public SwiftBlock2Output(string value, bool lenient) : base()
		{
			this.setValue(value, lenient);
		}

		/// <summary>
		/// Default Constructor
		/// </summary>
		public SwiftBlock2Output() : base()
		{
		}

		/// <summary>
		/// Copy constructor </summary>
		/// <param name="block"> an existing block2 to copy
		/// @since 7.10.4 </param>
		public SwiftBlock2Output(SwiftBlock2Output block) : this(block.MessageType, block.SenderInputTime, block.MIRDate, block.MIRLogicalTerminal, block.MIRSessionNumber, block.MIRSequenceNumber, block.ReceiverOutputDate, block.ReceiverOutputTime, block.MessagePriority)
		{
		}

		/// <summary>
		/// Sets the input time with respect to the sender
		/// </summary>
		/// <param name="senderInputTime"> 4 numbers HHMM </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setSenderInputTime(final String senderInputTime)
		public virtual string SenderInputTime
		{
			set
			{
				this.senderInputTime = value;
			}
			get
			{
				return senderInputTime;
			}
		}


		/// <summary>
		/// Sets the date the sender sent the message to SWIFT,
		/// from the MIR field
		/// </summary>
		/// <param name="MIRDate"> 6 numbers with date in format YYMMDD </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setMIRDate(final String MIRDate)
		public virtual string MIRDate
		{
			set
			{
				this.MIRDate_Renamed = value;
			}
			get
			{
				return this.MIRDate_Renamed;
			}
		}


		/// <summary>
		/// Sets the the full LT address of the sender of the message.
		/// </summary>
		/// <param name="MIRLogicalTerminal"> 12 characters full LT address </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setMIRLogicalTerminal(final String MIRLogicalTerminal)
		public virtual string MIRLogicalTerminal
		{
			set
			{
				this.MIRLogicalTerminal_Renamed = value;
			}
			get
			{
				return this.MIRLogicalTerminal_Renamed;
			}
		}

		/// <summary>
		/// Sets the the full LT address of the sender of the message.
		/// </summary>
		/// <seealso cref= LogicalTerminalAddress#getSenderLogicalTerminalAddress() </seealso>
		/// <param name="MIRLogicalTerminal"> 12 characters full LT address
		/// @since 7.6 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setMIRLogicalTerminal(final LogicalTerminalAddress MIRLogicalTerminal)
		public virtual LogicalTerminalAddress MIRLogicalTerminal
		{
			set
			{
				this.MIRLogicalTerminal_Renamed = value.SenderLogicalTerminalAddress;
			}
		}

		/// <summary>
		/// Creates a full LT address using the parameter BIC code and a default LT identifier,
		/// and sets the resulting address as MIR logical terminal address.
		/// </summary>
		/// <seealso cref= #setMIRLogicalTerminal(LogicalTerminalAddress) </seealso>
		/// <param name="bic">
		/// @since 7.6 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setSender(final BIC bic)
		public virtual BIC Sender
		{
			set
			{
				MIRLogicalTerminal = new LogicalTerminalAddress(value.Bic11);
			}
		}

		/// <summary>
		/// Completes if necessary and sets the LT address of the sender
		/// as MIR logical terminal address.<br>
		/// The sender addresses will be filled with proper default LT identifier and branch codes if not provided.
		/// </summary>
		/// <seealso cref= #setMIRLogicalTerminal(LogicalTerminalAddress)
		/// @since 7.6 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setSender(final String sender)
		public virtual string Sender
		{
			set
			{
				MIRLogicalTerminal = new LogicalTerminalAddress(value);
			}
		}


		/// <summary>
		/// Gets the sender's BIC code.<br>
		/// For output message the sender address is contained in this block2
		/// and not in the header block 1 as for input messages.
		/// </summary>
		/// <returns> sender BIC address </returns>
		/// <seealso cref= BIC
		/// @since 7.6 </seealso>
		public virtual BIC SenderBIC
		{
			get
			{
				return new BIC(this.MIRLogicalTerminal_Renamed);
			}
		}

		/// <summary>
		/// Sets the session number field of the MIR
		/// </summary>
		/// <param name="MIRSessionNumber"> 4 numbers </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setMIRSessionNumber(final String MIRSessionNumber)
		public virtual string MIRSessionNumber
		{
			set
			{
				this.MIRSessionNumber_Renamed = value;
			}
			get
			{
				return this.MIRSessionNumber_Renamed;
			}
		}


		/// <summary>
		/// Sets the sequence number field of the MIR
		/// </summary>
		/// <param name="MIRSequenceNumber"> 6 numbers </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setMIRSequenceNumber(final String MIRSequenceNumber)
		public virtual string MIRSequenceNumber
		{
			set
			{
				this.MIRSequenceNumber_Renamed = value;
			}
			get
			{
				return MIRSequenceNumber_Renamed;
			}
		}


		/// <summary>
		/// Gets the full MIR (Message Input Reference) string of 28 
		/// characters containing the sender's date, LT address,
		/// session and sequence:<br>
		/// for example YYMMDDBANKBEBBAXXX2222123456<br> </summary>
		/// <returns> a String with MIR, returns null if all MIR components are null </returns>
		public virtual string MIR
		{
			get
			{
				if (MIRDate_Renamed == null && MIRLogicalTerminal_Renamed == null && MIRSessionNumber_Renamed == null && MIRSequenceNumber_Renamed == null)
				{
					return null;
				}
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final StringBuilder v = new StringBuilder();
				StringBuilder v = new StringBuilder();
				if (MIRDate_Renamed != null)
				{
					v.Append(MIRDate_Renamed);
				}
				if (MIRLogicalTerminal_Renamed != null)
				{
					v.Append(MIRLogicalTerminal_Renamed);
				}
				if (MIRSessionNumber_Renamed != null)
				{
					v.Append(MIRSessionNumber_Renamed);
				}
				if (MIRSequenceNumber_Renamed != null)
				{
					v.Append(MIRSequenceNumber_Renamed);
				}
				return v.ToString();
			}
			set
			{
				setMIR(value, false);
			}
		}


		/// <summary>
		/// Sets the MIR (Message Input Reference) attributes by parsing the string argument containing the complete MIR value.<br>
		/// For example YYMMDDBANKBEBBAXXX2222123456<br>
		/// </summary>
		/// <param name="mir"> complete MIR string </param>
		/// <param name="lenient"> if true the value will be parsed with a best effort heuristic, if false it will throw a IllegalArgumentException if the value has an invalid total size </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setMIR(final String mir, boolean lenient)
		public virtual void setMIR(string mir, bool lenient)
		{
			if (!lenient)
			{
				Validate.notNull(mir);
				Validate.isTrue(mir.Length == 28, "expected a 28 characters string for MIR value and found a " + mir.Length + " string:" + mir);
			}
			if (mir != null)
			{
				int offset = 0;
				int len;

				len = 6;
				this.MIRDate = getValuePart(mir, offset, len);
				offset += len;

				len = 12;
				this.MIRLogicalTerminal = getValuePart(mir, offset, len);
				offset += len;

				len = 4;
				this.MIRSessionNumber = getValuePart(mir, offset, len);
				offset += len;

				if (lenient)
				{
					//get all remaining text
					this.MIRSequenceNumber = getValuePart(mir, offset, mir.Length);
				}
				else
				{
					len = 6;
					this.MIRSequenceNumber = getValuePart(mir, offset, len);
				}
			}
		}

		/// <summary>
		/// Sets the Output date local to the receiver, written in the following format: YYMMDD
		/// </summary>
		/// <param name="receiverOutputDate"> 6 characters in format YYMMDD </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setReceiverOutputDate(final String receiverOutputDate)
		public virtual string ReceiverOutputDate
		{
			set
			{
				this.receiverOutputDate = value;
			}
			get
			{
				return receiverOutputDate;
			}
		}


		/// <summary>
		/// Sets the Output time local to the receiver, written in the following format: HHMM
		/// </summary>
		/// <param name="receiverOutputTime"> String with 4 numbers </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setReceiverOutputTime(final String receiverOutputTime)
		public virtual string ReceiverOutputTime
		{
			set
			{
				this.receiverOutputTime = value;
			}
			get
			{
				return receiverOutputTime;
			}
		}


		/// <summary>
		/// Tell if this block is empty or not.
		/// This block is considered to be empty if all its attributes are set to null. </summary>
		/// <returns> <code>true</code> if all fields are null and false in other case </returns>
		public override bool Empty
		{
			get
			{
				return messageType == null && senderInputTime == null && MIR == null && receiverOutputDate == null && receiverOutputTime == null && messagePriority == null;
			}
		}

		/// <summary>
		/// Gets the fixed length block 2 value, as a result of
		/// concatenating its individual elements as follow:<br>
		/// Message Type +
		/// Sender Input Time +
		/// MIR +
		/// Receiver Output Date +
		/// Receiver Output Time +
		/// Message Priority.
		/// </summary>
		public override string Value
		{
			get
			{
				if (Empty)
				{
					return null;
				}
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final StringBuilder v = new StringBuilder("O");
				StringBuilder v = new StringBuilder("O");
				if (messageType != null)
				{
					v.Append(messageType);
				}
				if (senderInputTime != null)
				{
					v.Append(senderInputTime);
				}
				if (MIR != null)
				{
					v.Append(MIR);
				}
				if (receiverOutputDate != null)
				{
					v.Append(receiverOutputDate);
				}
				if (receiverOutputTime != null)
				{
					v.Append(receiverOutputTime);
				}
				if (messagePriority != null)
				{
					v.Append(messagePriority);
				}
				return v.ToString();
			}
			set
			{
				setValue(value, false);
			}
		}

		/// <seealso cref= #getValue() </seealso>
		public override string BlockValue
		{
			get
			{
				return Value;
			}
			set
			{
				Value = value;
			}
		}


		/// <summary>
		/// Sets the block's attributes by parsing the string argument containing the blocks value.<br>
		/// This value can be in different flavors because some fields are optional.<br>
		/// Example of supported values:<br>
		/// <pre>
		///   "O1001200970103BANKBEBBAXXX22221234569701031201" (46) or
		///   "2:O1001200970103BANKBEBBAXXX22221234569701031201" (48)   // used for service/system messages
		///   "O1001200970103BANKBEBBAXXX22221234569701031201N" (47) or
		///   "2:O1001200970103BANKBEBBAXXX22221234569701031201N" (49)
		/// </pre><br>
		/// </summary>
		/// <param name="value"> string containing the entire blocks value </param>
		/// <param name="lenient"> if true the value will be parsed with a best effort heuristic, if false it will throw a IllegalArgumentException if the value has an invalid total size </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setValue(final String value, boolean lenient)
		public virtual void setValue(string value, bool lenient)
		{
			if (lenient)
			{
				//leave all attributes as null (cleaning defaults)
				clean();
			}
			else
			{
				// check parameters
				Validate.notNull(value, "value must not be null");
			}

			if (value != null)
			{

				int slen = value.Length;

				if (!lenient)
				{
					// check parameters
					Validate.notNull(value, "value must not be null");
					Validate.isTrue(slen == 46 || slen == 48 || slen == 47 || slen == 49, "expected a string value of 46 and up to 49 chars and obtained a " + slen + " chars string: '" + value + "'");
				}

				// figure out the starting point and check the input value has proper optional
				int offset = 0;
				if (value.StartsWith("2:", StringComparison.Ordinal)) // accept 2:...
				{
					offset = 2;
				}

				slen -= offset;
				if (!lenient)
				{
					if (slen != 46 && slen != 47)
					{
						throw new System.ArgumentException("Value must match: O<mt><time><mir><date><time>[<pri>]");
					}
					if (char.ToUpper(value[offset]) != 'O')
					{
						throw new System.ArgumentException("Value must match: O<mt><time><mir><date><time>[<pri>]");
					}
				}
				offset++; // skip the output mark

				// separate value fragments
				int len = 3;
				this.MessageType = this.getValuePart(value, offset, len);
				offset += len;

				len = 4;
				this.SenderInputTime = this.getValuePart(value, offset, len);
				offset += len;

				len = 28;
				this.setMIR(this.getValuePart(value, offset, len), lenient);
				offset += len;

				len = 6;
				this.ReceiverOutputDate = this.getValuePart(value, offset, len);
				offset += len;

				len = 4;
				this.ReceiverOutputTime = this.getValuePart(value, offset, len);
				offset += len;

				if (lenient)
				{
					//get all remaining text
					this.MessagePriority = this.getValuePart(value, offset);
				}
				else
				{
					len = 1;
					this.MessagePriority = this.getValuePart(value, offset, len);
				}

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
			SwiftBlock2Output that = (SwiftBlock2Output) o;
			return Objects.Equals(senderInputTime, that.senderInputTime) && Objects.Equals(MIRDate_Renamed, that.MIRDate_Renamed) && Objects.Equals(MIRLogicalTerminal_Renamed, that.MIRLogicalTerminal_Renamed) && Objects.Equals(MIRSessionNumber_Renamed, that.MIRSessionNumber_Renamed) && Objects.Equals(MIRSequenceNumber_Renamed, that.MIRSequenceNumber_Renamed) && Objects.Equals(receiverOutputDate, that.receiverOutputDate) && Objects.Equals(receiverOutputTime, that.receiverOutputTime);
		}

		public override int GetHashCode()
		{
			return Objects.hash(base.GetHashCode(), senderInputTime, MIRDate_Renamed, MIRLogicalTerminal_Renamed, MIRSessionNumber_Renamed, MIRSequenceNumber_Renamed, receiverOutputDate, receiverOutputTime);
		}

		/// <summary>
		/// Legacy (version 1) json representation of this object.
		/// 
		/// <para>This implementation has been replaced by version 2, based on Gson.
		/// 
		/// </para>
		/// </summary>
		/// @deprecated use <seealso cref="#toJson()"/> instead
		/// @since 7.9.8 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#toJson()"/> instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public String toJsonV1()
		[Obsolete("use <seealso cref="#toJson()"/> instead")]
		public virtual string toJsonV1()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			sb.Append("{ \n");

			sb.Append(" \"messageType\" : \"").Append(messageType).Append(SEPARATOR);
			sb.Append(" \"senderInputTime\" : \"").Append(senderInputTime).Append(SEPARATOR);
			sb.Append(" \"MIRDate\" : \"").Append(MIRDate_Renamed).Append("\", \n");
			sb.Append(" \"MIRLogicalTerminal\" : \"").Append(MIRLogicalTerminal_Renamed).Append(SEPARATOR);
			sb.Append(" \"MIRSessionNumber\" : \"").Append(MIRSessionNumber_Renamed).Append(SEPARATOR);
			sb.Append(" \"MIRSequenceNumber\" : \"").Append(MIRSequenceNumber_Renamed).Append(SEPARATOR);
			sb.Append(" \"receiverOutputDate\" : \"").Append(receiverOutputDate).Append(SEPARATOR);
			sb.Append(" \"receiverOutputTime\" : \"").Append(receiverOutputTime).Append(SEPARATOR);
			sb.Append(" \"messagePriority\" : \"").Append(messagePriority).Append(SEPARATOR);

			sb.Append("} ");
			return sb.ToString();
		}

		/// <summary>
		/// Generic getter for block attributes based on qualified names from <seealso cref="SwiftBlock2OutputField"/> </summary>
		/// <param name="field"> field to get </param>
		/// <returns> field value or null if attribute is not set
		/// @since 7.7 </returns>
		public virtual string field(SwiftBlock2OutputField field)
		{
			switch (field.InnerEnumValue())
			{
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MessageType:
					return MessageType;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MessagePriority:
					return MessagePriority;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.SenderInputTime:
					return SenderInputTime;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MIRDate:
					return MIRDate;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MIRLogicalTerminal:
					return MIRLogicalTerminal;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MIRSessionNumber:
					return MIRSessionNumber;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MIRSequenceNumber:
					return MIRSequenceNumber;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.ReceiverOutputDate:
					return ReceiverOutputDate;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.ReceiverOutputTime:
					return ReceiverOutputTime;
				default:
					return null;

			}
		}

		/// <summary>
		/// Generic setter for block attributes based on qualified names from <seealso cref="SwiftBlock2OutputField"/> </summary>
		/// <param name="field"> field to get </param>
		/// <param name="value"> content to set
		/// @since 7.8 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setField(SwiftBlock2OutputField field, final String value)
		public virtual void setField(SwiftBlock2OutputField field, string value)
		{
			switch (field.InnerEnumValue())
			{
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MessageType:
					MessageType = value;
					break;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MessagePriority:
					MessagePriority = value;
					break;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.SenderInputTime:
					SenderInputTime = value;
					break;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MIRDate:
					MIRDate = value;
					break;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MIRLogicalTerminal:
					MIRLogicalTerminal = value;
					break;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MIRSessionNumber:
					MIRSessionNumber = value;
					break;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.MIRSequenceNumber:
					MIRSequenceNumber = value;
					break;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.ReceiverOutputDate:
					ReceiverOutputDate = value;
					break;
				case com.prowidesoftware.swift.model.SwiftBlock2OutputField.InnerEnum.ReceiverOutputTime:
					ReceiverOutputTime = value;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into an incoming (output) block 2 object. </summary>
		/// <seealso cref= #toJson()
		/// @since 7.9.8 </seealso>
		public static SwiftBlock2Output fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().create();
			Gson gson = (new GsonBuilder()).create();
			return gson.fromJson(json, typeof(SwiftBlock2Output));
		}
	}

}