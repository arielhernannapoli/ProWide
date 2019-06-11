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
	using ConversionService = com.prowidesoftware.swift.io.ConversionService;
	using AbstractMT = com.prowidesoftware.swift.model.mt.AbstractMT;
	using MTVariant = com.prowidesoftware.swift.model.mt.MTVariant;
	using ServiceIdType = com.prowidesoftware.swift.model.mt.ServiceIdType;
	using EnumUtils = org.apache.commons.lang3.EnumUtils;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;



	/// <summary>
	/// Container of raw representations of an MT (ISO 15022) SWIFT message, intended for message persistence.
	/// The class holds the full FIN message content plus minimal message identification metadata.<br>
	/// @since 7.0
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Entity(name = "mt") @DiscriminatorValue("mt") public class MtSwiftMessage extends AbstractSwiftMessage
	public class MtSwiftMessage : AbstractSwiftMessage
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MtSwiftMessage).FullName);
		private const long serialVersionUID = -5972656648349958815L;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 35) private String pde;
		private string pde;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 35) private String pdm;
		private string pdm;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 28, name = "mir") private String mir;
		private string mir;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 16, name = "mur") private String mur;
		private string mur;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Column(length = 31, name = "uuid") private String uuid;
		private string uuid;

		public MtSwiftMessage() : base()
		{
		}

		/// <summary>
		/// Creates a new message reading the message the content from a string.
		/// Performs a fast parsing of the header and trailer blocks to identify the message
		/// and gather metadata information for the object attributes.
		/// 
		/// <para>If the string contains several messages, the whole passed content will be
		/// save in the message attribute but identification and metadata will be parser
		/// from the first one found only.
		/// 
		/// </para>
		/// <para>Notice that if an ACK/NAK followed by the original
		/// message is passed, this object will represent the ACK/NAK.
		/// 
		/// </para>
		/// <para>File format is set to <seealso cref="FileFormat#FIN"/>
		/// 
		/// </para>
		/// </summary>
		/// <seealso cref= AbstractSwiftMessage#AbstractSwiftMessage(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MtSwiftMessage(final String fin)
		public MtSwiftMessage(string fin) : base(fin, FileFormat.FIN)
		{
		}

		/// <summary>
		/// Creates a new message reading the message the content from a string.
		/// This is a static version of the constructor <seealso cref="#MtSwiftMessage(String)"/>
		/// 
		/// @since 7.7
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MtSwiftMessage parse(final String fin)
		public static MtSwiftMessage parse(string fin)
		{
			return new MtSwiftMessage(fin);
		}

		/// <summary>
		/// Creates a new message reading the message the content from an input stream.
		/// <br>
		/// File format is set to <seealso cref="FileFormat#FIN"/>
		/// </summary>
		/// <seealso cref= #MtSwiftMessage(String) </seealso>
		/// <seealso cref= AbstractSwiftMessage#AbstractSwiftMessage(InputStream)
		/// @since 7.7 </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MtSwiftMessage(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MtSwiftMessage(InputStream stream) : base(stream, FileFormat.FIN)
		{
		}

		/// <summary>
		/// Creates a new message reading the message the content from an input stream.
		/// This is a static version of the constructor <seealso cref="#MtSwiftMessage(InputStream)"/>
		/// 
		/// @since 7.7
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MtSwiftMessage parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MtSwiftMessage parse(InputStream stream)
		{
			return new MtSwiftMessage(stream);
		}

		/// <summary>
		/// Creates a new message reading the message the content from a file.
		/// <br>
		/// File format is set to <seealso cref="FileFormat#FIN"/>
		/// </summary>
		/// <seealso cref= #MtSwiftMessage(String) </seealso>
		/// <seealso cref= AbstractSwiftMessage#AbstractSwiftMessage(File)
		/// @since 7.7 </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MtSwiftMessage(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MtSwiftMessage(File file) : base(file, FileFormat.FIN)
		{
		}

		/// <summary>
		/// Creates a new message reading the message the content from a file.
		/// This is a static version of the constructor <seealso cref="#MtSwiftMessage(File)"/>
		/// 
		/// @since 7.7
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MtSwiftMessage parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MtSwiftMessage parse(File file)
		{
			return new MtSwiftMessage(file);
		}

		/// <seealso cref= AbstractSwiftMessage#updateFromMessage()
		/// @since 7.7 </seealso>
		/// <exception cref="IllegalArgumentException"> if the source format is not <seealso cref="FileFormat#FIN"/> or if the message cannot be parsed into a <seealso cref="MtSwiftMessage"/> object </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override protected void updateFromMessage() throws IllegalArgumentException
		protected internal override void updateFromMessage()
		{
			if (FileFormat != FileFormat.FIN)
			{
				throw new System.ArgumentException("expected source format " + FileFormat.FIN + " and found " + FileFormat);
			}
			Validate.notNull(Message, "the raw message attribute cannot be null");
			SwiftMessage model = null;
			try
			{
				model = SwiftMessage.parse(Message);
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final java.io.IOException e)
			catch (IOException e)
			{
				log.log(Level.SEVERE, "the raw message parameter could not be parsed into a SwiftMessage", e);
			}
			if (model == null)
			{
				throw new System.ArgumentException("the raw message parameter could not be parsed into a SwiftMessage");
			}
			else
			{
				updateAttributes(model);
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void updateAttributes(final SwiftMessage model)
		private void updateAttributes(SwiftMessage model)
		{
			FileFormat = FileFormat.FIN;
			if (model.ServiceMessage21)
			{
				if (model.UnparsedTextsSize > 0)
				{
					/*
					 * set identifier for system aknowledge
					 */
					if (model.Ack)
					{
						base.identifier = IDENTIFIER_ACK;
					}
					else if (model.Nack)
					{
						base.identifier = IDENTIFIER_NAK;
					}
					/*
					 * try to parse the appended original message (if any)
					 * to gather receiver and reference information
					 */
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage original = model.getUnparsedTexts().getTextAsMessage(0);
					SwiftMessage original = model.UnparsedTexts.getTextAsMessage(0);
					if (original != null)
					{
						base.receiver = bic11(original.Receiver);
						Direction = original.Direction;
						Reference = SwiftMessageUtils.reference(original);
					}
				}
			}
			else if (model.Block1 != null && model.Block1.ServiceIdType == ServiceIdType._01)
			{
				Identifier = model.MtId.id();
				Receiver = bic11(model.Receiver);
				Direction = model.Direction;
				Reference = SwiftMessageUtils.reference(model);
				CurrencyAmount currencyAmount = SwiftMessageUtils.currencyAmount(model);
				if (currencyAmount != null)
				{
					Currency = currencyAmount.Currency;
					Amount = currencyAmount.Amount;
				}
				ValueDate = SwiftMessageUtils.valueDate(model);
				TradeDate = SwiftMessageUtils.tradeDate(model);
			}
			Sender = bic11(model.Sender);
			Checksum = SwiftMessageUtils.calculateChecksum(model);
			ChecksumBody = SwiftMessageUtils.calculateChecksum(model.Block4);
			Pde = model.PDE;
			Pdm = model.PDM;
			Mir = model.MIR;
			Mur = model.MUR;
			Uuid = model.UUID;
			LastModified = new DateTime();
		}

		/// <summary>
		/// Creates an MtSwiftMessage from a SwiftMessage. </summary>
		/// <seealso cref= #updateFromModel(SwiftMessage) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MtSwiftMessage(final SwiftMessage model)
		public MtSwiftMessage(SwiftMessage model) : base()
		{
			updateFromModel(model);
		}

		/// <summary>
		/// Updates the the attributes with the raw message and its metadata from the given raw (FIN) message content.
		/// </summary>
		/// <param name="fin"> the new message content </param>
		/// <seealso cref= #updateFromMessage() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void updateFromFIN(final String fin)
		public virtual void updateFromFIN(string fin)
		{
			Validate.notNull(fin, "the raw message parameter cannot be null");
			Message = fin;
			FileFormat = FileFormat.FIN;
			updateFromMessage();
		}

		/// <summary>
		/// Updates the derived attributes from the current raw (FIN) message attribute.
		/// This is similar to create a new message instance from string content.
		/// </summary>
		public virtual void updateFromFIN()
		{
			updateFromMessage();
		}

		/// <summary>
		/// The SwiftMessage is serialized to its FIN raw format to set the internal raw message attribute.
		/// And the header attributes are set with data from the parameter SwiftMessage.
		/// Notice that the SwiftMessage is not stored as internal attribute.
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void updateFromModel(final SwiftMessage model)
		public virtual void updateFromModel(SwiftMessage model)
		{
			Validate.notNull(model, "the model message cannot be null");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = (new com.prowidesoftware.swift.io.ConversionService()).getFIN(model);
			string fin = (new ConversionService()).getFIN(model);
			Validate.notNull(fin, "the raw message could not be created from the SwiftMessage parameter");
			Message = fin;
			updateAttributes(model);
		}

		/// <summary>
		/// The AbstractMT is serialized to its FIN raw format to set the internal raw message attribute.
		/// And the header attributes are set with data from the parameter AbstractMT.
		/// Notice that the AbstractMT is not stored as internal attribute.
		/// 
		/// @since 7.8.4
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void updateFromModel(final com.prowidesoftware.swift.model.mt.AbstractMT mt)
		public virtual void updateFromModel(AbstractMT mt)
		{
			Validate.notNull(mt, "the model message cannot be null");
			updateFromModel(mt.SwiftMessage);
		}

		/// <summary>
		/// Parses the raw message content into a <seealso cref="SwiftMessage"/> object. </summary>
		/// <returns> the parsed message or null if the raw content is not set or cannot be parsed
		/// @since 7.8.9 </returns>
		public virtual SwiftMessage modelMessage()
		{
			if (Message != null)
			{
				try
				{
					return SwiftMessage.parse(message());
				}
				catch (IOException e)
				{
					log.log(Level.WARNING, "error converting FIN text to model: " + e.Message, e);
				}
			}
			return null;
		}

		/// @deprecated The internal model message is no longer kept as class attribute to avoid 
		/// inconsistencies between the raw format and the parsed data. To update the internal raw
		/// format from a model object use <seealso cref="#updateFromModel(SwiftMessage)"/> instead of this setter. 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("The internal model message is no longer kept as class attribute to avoid") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public void setModelMessage(final SwiftMessage modelMessage)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("The internal model message is no longer kept as class attribute to avoid")]
		public virtual SwiftMessage ModelMessage
		{
			set
			{
				DeprecationUtils.phase3(this.GetType(), "setModelMessage(SwiftMessage)", "Use updateFromModel(SwiftMessage) instead.");
				updateFromModel(value);
			}
		}

		/// <summary>
		/// Get the integer value of the <seealso cref="#getMessageType()"/>
		/// or null if the identifier attribute is not set or not a number
		/// </summary>
		public virtual int? MessageTypeInt
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String number = getMessageType();
				string number = MessageType;
				if (number != null && StringUtils.isNumeric(number))
				{
					return Convert.ToInt32(number);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Get the value of the property under the <seealso cref="#PROPERTY_NAME"/> key or the result of <seealso cref="#getMessageType()"/> </summary>
		/// <returns> the set message name or message type </returns>
		public override string MessageName
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String name = base.getMessageName();
				string name = base.MessageName;
				if (name != null)
				{
					return name;
				}
				else
				{
					return MessageType;
				}
			}
		}

		/// <summary>
		/// Tell if this message is any of the given types.
		/// </summary>
		/// <param name="type"> a variable list of integers for testing to match as the current message type </param>
		/// <returns> <code>true</code> if the current message type is any of the integers given as parameters, and <code>false</code> in any other case </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean isType(final Integer... type)
		public virtual bool isType(params int?[] type)
		{
			foreach (Integer integer in type)
			{
				if (isType((int)integer))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Test if this message is a given specific type.
		/// </summary>
		/// <param name="type"> the message type given as int, to test </param>
		/// <returns> <code>true</code> if this message type is the <code>type</code> given, or <code>false</code> in any other case </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean isType(final int type)
		public virtual bool isType(int type)
		{
			int? typeInt = MessageTypeInt;
			if (typeInt != null)
			{
				return typeInt == type;
			}
			return false;
		}

		public override string ToString()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			sb.Append("MtSwiftMessage id=").Append(Id).Append(" message=").Append(Message);
			return sb.ToString();
		}

		/// <summary>
		/// Gets PDE (Possible Duplicate Emission) flag from the trailer block or null if the trailer or the PDE field is not present </summary>
		/// <returns> the PDE flag or null </returns>
		public virtual string Pde
		{
			get
			{
				return pde;
			}
			set
			{
				this.pde = value;
			}
		}


		/// <summary>
		/// Gets PDM from the trailer block or null if the trailer or the PDM field is not present </summary>
		/// <returns> PDM flag or null </returns>
		public virtual string Pdm
		{
			get
			{
				return pdm;
			}
			set
			{
				this.pde = value;
			}
		}


		/// <summary>
		/// Gets the MIR (Message Input Reference) </summary>
		/// <seealso cref= SwiftMessage#getMIR() </seealso>
		public virtual string Mir
		{
			get
			{
				return mir;
			}
			set
			{
				this.mir = value;
			}
		}


		/// <summary>
		/// Gets the MUR (Message User Reference) from block 3 </summary>
		/// <seealso cref= SwiftMessage#getMUR() </seealso>
		/// <returns> the MUR or null if not present in the message </returns>
		public virtual string Mur
		{
			get
			{
				return mur;
			}
			set
			{
				this.mur = value;
			}
		}


		/// <summary>
		/// Gets a UUID (User Unique Identifier) </summary>
		/// <seealso cref= SwiftMessage#getUUID() </seealso>
		public virtual string Uuid
		{
			get
			{
				return uuid;
			}
			set
			{
				this.uuid = value;
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
			MtSwiftMessage that = (MtSwiftMessage) o;
			return Objects.Equals(pde, that.pde) && Objects.Equals(pdm, that.pdm) && Objects.Equals(mir, that.mir) && Objects.Equals(mur, that.mur) && Objects.Equals(uuid, that.uuid);
		}

		public override int GetHashCode()
		{
			return Objects.hash(base.GetHashCode(), pde, pdm, mir, mur, uuid);
		}

		/// <summary>
		/// Creates a full copy of the current message object into another message. </summary>
		/// <param name="msg"> target message
		/// @since 7.7 </param>
		/// <seealso cref= AbstractSwiftMessage#copyTo(AbstractSwiftMessage) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void copyTo(final MtSwiftMessage msg)
		public virtual void copyTo(MtSwiftMessage msg)
		{
			base.copyTo(msg);
			msg.Mir = Mir;
			msg.Mur = Mur;
			msg.Pde = Pde;
			msg.Pdm = Pdm;
			msg.Uuid = Uuid;
		}

		/// <summary>
		/// This method deserializes the JSON data into an MT message object.
		/// 
		/// @since 7.10.3
		/// </summary>
		public static MtSwiftMessage fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().create();
			Gson gson = (new GsonBuilder()).create();
			return gson.fromJson(json, typeof(MtSwiftMessage));
		}

		/// <summary>
		/// Returns the message type variant </summary>
		/// <returns> the variant or null if the message has no variant
		/// @since 7.10.4 </returns>
		public virtual MTVariant Variant
		{
			get
			{
				string s = StringUtils.substringAfterLast(this.identifier, ".");
				if (EnumUtils.isValidEnum(typeof(MTVariant), s))
				{
					return MTVariant.valueOf(s);
				}
				return null;
			}
		}

		/// <summary>
		/// Returns this message MT identification </summary>
		/// <returns> the identification object for this message
		/// @since 7.10.4 </returns>
		public virtual MtId MtId
		{
			get
			{
				return new MtId(MessageType, Variant);
			}
		}

	}

}