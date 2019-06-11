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
namespace com.prowidesoftware.swift.model.mt
{

	using Gson = com.google.gson.Gson;
	using GsonBuilder = com.google.gson.GsonBuilder;
	using ConversionService = com.prowidesoftware.swift.io.ConversionService;
	using IConversionService = com.prowidesoftware.swift.io.IConversionService;
	using SwiftParser = com.prowidesoftware.swift.io.parser.SwiftParser;
	using SwiftWriter = com.prowidesoftware.swift.io.writer.SwiftWriter;
	using com.prowidesoftware.swift.model;
	using Field = com.prowidesoftware.swift.model.field.Field;
	using Lib = com.prowidesoftware.swift.utils.Lib;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;



	/// <summary>
	/// Base class for specific MTs.<br>
	/// This class implements several high level delegate methods of SwiftMessage.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public abstract class AbstractMT : AbstractMessage, JsonSerializable
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly Logger log = Logger.getLogger(typeof(AbstractMT).FullName);
		protected internal SwiftMessage m;
		private const string GETSEQUENCE = "getSequence";
		/// <param name="m"> swift message to model as a particular MT </param>
		public AbstractMT(SwiftMessage m) : base(MessageStandardType.MT)
		{
			this.m = m;
		}

		/// <summary>
		/// Creates a particular MT initialized with a new SwiftMessage.
		/// All blocks are initialized.
		/// </summary>
		public AbstractMT() : base(MessageStandardType.MT)
		{
			this.m = new SwiftMessage(true);
			if (MessageType != null)
			{
				this.m.Block2.MessageType = MessageType;
			}
		}

		/// <summary>
		/// Create an input message for the given type setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// </summary>
		/// <param name="messageType"> the message type </param>
		/// <seealso cref= #AbstractMT(int, String, String)
		/// @since 7.6 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractMT(final int messageType)
		public AbstractMT(int messageType) : this(messageType, BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates a new input message for the given type setting the given sender and receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided. For the message type, if the indicated number is below 100 the
		/// category 0 will be assumed (meaning 10 will be set as 010).
		/// </summary>
		/// <param name="messageType"> message type to create </param>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.6 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractMT(final int messageType, final String sender, final String receiver)
		public AbstractMT(int messageType, string sender, string receiver) : base(MessageStandardType.MT)
		{
			this.m = new SwiftMessage(true);
			this.m.Block1.Sender = sender;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock2Input b2 = new SwiftBlock2Input();
			SwiftBlock2Input b2 = new SwiftBlock2Input();

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder type = new StringBuilder();
			StringBuilder type = new StringBuilder();
			if (messageType < 100)
			{
				type.Append("0");
			}
			type.Append(messageType);
			b2.MessageType = type.ToString();

			b2.Input = true;
			b2.MessagePriority = "N";
			b2.Receiver = receiver;
			this.m.Block2 = b2;
		}

		/// <summary>
		/// Parses a the string content into the MTxxx that corresponds to the found message type. 
		/// If the file contains more than a message it will parse the first one. 
		/// If the string is empty, does not contain any MT message, the message type is not set or 
		/// an error occurs reading and parsing the message content; this method returns null.
		/// </summary>
		/// <param name="fin"> string a string containing a swift MT message </param>
		/// <returns> parser message or null if string content could not be parsed </returns>
		/// <exception cref="IOException"> if the message content cannot be read
		/// 
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static AbstractMT parse(final String fin) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static AbstractMT parse(string fin)
		{
			return (new SwiftParser(fin)).message().toMT();
		}

		/// <summary>
		/// Parses a the stream content into the MTxxx that corresponds to the found message type. 
		/// </summary>
		/// <param name="stream"> a stream containing a swift MT message </param>
		/// <returns> parser message or null if stream content could not be parsed </returns>
		/// <exception cref="IOException"> if the stream content cannot be read </exception>
		/// <seealso cref= #parse(String)
		/// 
		/// @since 7.7 </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static AbstractMT parse(final InputStream stream) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static AbstractMT parse(InputStream stream)
		{
			return (new SwiftParser(stream)).message().toMT();
		}

		/// <summary>
		/// Parses a the file content into the MTxxx that corresponds to the found message type. 
		/// </summary>
		/// <param name="file"> a file containing a swift MT message </param>
		/// <returns> parser message or null if file content could not be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read </exception>
		/// <seealso cref= #parse(String)
		/// 
		/// @since 7.7 </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static AbstractMT parse(final File file) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static AbstractMT parse(File file)
		{
			return (new SwiftParser(Lib.readFile(file))).message().toMT();
		}

		/// <returns> the swift message object modeled as this particular MT </returns>
		public virtual SwiftMessage SwiftMessage
		{
			get
			{
				return m;
			}
			set
			{
				this.m = value;
			}
		}

		/// <summary>
		/// Get the swift message guaranteeing a non null return.
		/// If the message is null an illegal state exception is thrown </summary>
		/// <returns> the swift message set 
		/// @since 7.7 </returns>
		protected internal virtual SwiftMessage SwiftMessageNotNullOrException
		{
			get
			{
				if (this.m == null)
				{
					throw new IllegalStateException("SwiftMessage is null");
				}
				return m;
			}
		}


		/// <returns> application id from block 1 </returns>
		/// <seealso cref= SwiftBlock1#getApplicationId() </seealso>
		public virtual string ApplicationId
		{
			get
			{
				if (SwiftMessage == null)
				{
					throw new IllegalStateException("SwiftMessage was not initialized");
				}
				if (m.Block1 != null)
				{
					return m.Block1.ApplicationId;
				}
				else
				{
					return null;
				}
			}
		}

		/// <returns> service id from block 1 </returns>
		/// <seealso cref= SwiftBlock1#getServiceId() </seealso>
		public virtual string ServiceId
		{
			get
			{
				if (SwiftMessage == null)
				{
					throw new IllegalStateException("SwiftMessage was not initialized");
				}
				if (m.Block1 != null)
				{
					return m.Block1.ServiceId;
				}
				else
				{
					return null;
				}
			}
		}

		/// <returns> logical terminal from block 1 </returns>
		/// <seealso cref= SwiftBlock1#getLogicalTerminal() </seealso>
		public virtual string LogicalTerminal
		{
			get
			{
				if (SwiftMessage == null)
				{
					throw new IllegalStateException("SwiftMessage was not initialized");
				}
				if (m.Block1 != null)
				{
					return m.Block1.LogicalTerminal;
				}
				else
				{
					return null;
				}
			}
		}

		/// <returns> session number from block 1 </returns>
		/// <seealso cref= SwiftBlock1#getSessionNumber() </seealso>
		public virtual string SessionNumber
		{
			get
			{
				if (SwiftMessage == null)
				{
					throw new IllegalStateException("SwiftMessage was not initialized");
				}
				if (m.Block1 != null)
				{
					return m.Block1.SessionNumber;
				}
				else
				{
					return null;
				}
			}
		}

		/// <returns> sequence number from block 1 </returns>
		/// <seealso cref= SwiftBlock1#getSequenceNumber() </seealso>
		public virtual string SequenceNumber
		{
			get
			{
				if (SwiftMessage == null)
				{
					throw new IllegalStateException("SwiftMessage was not initialized");
				}
				if (m.Block1 != null)
				{
					return m.Block1.SequenceNumber;
				}
				else
				{
					return null;
				}
			}
		}

		/// <returns> message priority from block 2 </returns>
		/// <seealso cref= com.prowidesoftware.swift.model.SwiftBlock2#getMessagePriority() </seealso>
		public virtual string MessagePriority
		{
			get
			{
				if (SwiftMessage == null)
				{
					throw new IllegalStateException("SwiftMessage was not initialized");
				}
				if (m.Block2 != null)
				{
					return m.Block2.MessagePriority;
				}
				else
				{
					return null;
				}
			}
		}

		/// <returns> true if message is an input message sent to SWIFTNet, false otherwise </returns>
		/// <seealso cref= SwiftMessage#isOutgoing() </seealso>
		public virtual bool Input
		{
			get
			{
				if (SwiftMessage == null)
				{
					throw new IllegalStateException("SwiftMessage was not initialized");
				}
				return m.Input;
			}
		}

		/// <returns> true if the message is outgoing (sent to SWIFT), false other case; using the direction attribute. </returns>
		/// <seealso cref= SwiftMessage#isOutgoing()
		/// @since 7.8.4 </seealso>
		public virtual bool Outgoing
		{
			get
			{
				return Input;
			}
		}

		/// <returns> true if message is an output message received from SWIFTNet, false otherwise </returns>
		/// <seealso cref= SwiftMessage#isIncoming() </seealso>
		public virtual bool Output
		{
			get
			{
				if (SwiftMessage == null)
				{
					throw new IllegalStateException("SwiftMessage was not initialized");
				}
				return m.Output;
			}
		}

		/// <returns> true if the message is incoming (received from SWIFT), false other case; using the direction attribute. </returns>
		/// <seealso cref= SwiftMessage#isIncoming()
		/// @since 7.8.4 </seealso>
		public virtual bool Incoming
		{
			get
			{
				return Output;
			}
		}

		/// <summary>
		/// Sets the logical terminal field of the header block 1 (the message is assumed to be of type input).
		/// The sender addresses will be filled with proper default LT identifier and branch codes if not provided.<br>
		/// 
		/// Notice this method only makes sense when building input messages (messages that are going to be sent to swift). 
		/// To emulate a received message from swift, the sender information must be put at block 2.
		/// 
		/// @since 6.4 </summary>
		/// <seealso cref= SwiftBlock1#setSender(String) </seealso>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		public virtual string Sender
		{
			set
			{
				if (SwiftMessage == null)
				{
					this.m = new SwiftMessage(true);
				}
				SwiftMessage.Block1.Sender = value;
			}
			get
			{
				if (SwiftMessage != null)
				{
					return SwiftMessage.Sender;
				}
				return null;
			}
		}

		/// <summary>
		/// Sets the logical terminal field of the header block 1 with the parameter BIC code and default LT identifier
		/// (the message is assumed to be of type input).<br>
		/// 
		/// Notice this method only makes sense when building input messages (messages that are going to be sent to swift). 
		/// To emulate a received message from swift, the sender information must be put at block 2.
		/// 
		/// @since 6.4 </summary>
		/// <seealso cref= SwiftBlock1#setLogicalTerminal(BIC) </seealso>
		/// <param name="bic"> a BIC code </param>
		public virtual BIC Sender
		{
			set
			{
				if (SwiftMessage == null)
				{
					this.m = new SwiftMessage(true);
				}
				SwiftMessage.Block1.LogicalTerminal = value;
			}
		}


		/// <summary>
		/// Sets the logical terminal field of the application header block 2. 
		/// The receiver addresses will be filled with proper default LT identifier and branch codes if not provided.<br>
		/// 
		/// Notice this method only makes sense when building input messages (messages that are going to be sent to swift). 
		/// To emulate a received message from swift, a call to this method has no effect, and the receiver information 
		/// must be manually set in block 1.
		/// 
		/// @since 6.4 </summary>
		/// <seealso cref= SwiftBlock2Input#setReceiver(String) </seealso>
		/// <param name="receiver"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		public virtual string Receiver
		{
			set
			{
				if (SwiftMessage == null)
				{
					this.m = new SwiftMessage(true);
				}
				SwiftBlock2 b2 = SwiftMessage.Block2;
				if (b2.Input)
				{
					((SwiftBlock2Input)b2).Receiver = value;
				}
			}
			get
			{
				if (SwiftMessage != null)
				{
					return SwiftMessage.Receiver;
				}
				return null;
			}
		}

		/// <summary>
		/// Sets the logical terminal field of the application header block 2.<br> 
		/// 
		/// Notice this method only makes sense when building input messages (messages that are going to be sent to swift). 
		/// To emulate a received message from swift, a call to this method has no effect, and the receiver information 
		/// must be manually set in block 1.
		/// 
		/// @since 6.4 </summary>
		/// <seealso cref= SwiftBlock2Input#setReceiver(String) </seealso>
		/// <param name="bic"> a BIC code </param>
		public virtual BIC Receiver
		{
			set
			{
				Receiver = value.Bic11;
			}
		}


		/// <summary>
		/// Adds the given field to the body block in the last position </summary>
		/// <param name="f"> a field to add </param>
		public virtual void addField(Field f)
		{
			if (SwiftMessage == null)
			{
				this.m = new SwiftMessage();
			}
			SwiftMessage.Block4.append(f);
		}

		/// <summary>
		/// Get this message as string containing the FIN message (SWIFT MT message).
		/// </summary>
		/// <returns> a string with the FIN format representation of the message
		/// @since 7.7 </returns>
		public virtual string message()
		{
			IConversionService srv = new ConversionService();
			return srv.getFIN(this.m);
		}

		/// <summary>
		/// Returns this message type according to the specific class.
		/// </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public abstract string MessageType {get;}

		/// <summary>
		/// Convenience method to get the list of sequences named <code>name</code> from this message without creating the MTXXX class.
		/// 
		/// <code>getSequenceList("A")</code>
		/// is the same as 
		/// <code>((CastToSpecificMT)getMT()).getSequenceAList()</code>
		/// 
		/// <em>The requested sequence must be repetitive</em> for non repetitive sequences use getSequence(name) 
		/// 
		/// @since 7.6 </summary>
		/// <param name="name"> the sequence alpha numeric identifier such as A1a </param>
		/// <returns> found sequences or empty list </returns>
		/// <seealso cref= #getSequence(String) </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unchecked") public java.util.List<SwiftTagListBlock> getSequenceList(final String name)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual IList<SwiftTagListBlock> getSequenceList(string name)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String methodName = GETSEQUENCE+name+"List";
			string methodName = GETSEQUENCE + name + "List";
			object o = invokeHere(methodName, this, null);
			return (IList<SwiftTagListBlock>)o;
		}

		/// <summary>
		/// Get the sequence with a given name from the given subblock </summary>
		/// <param name="name"> the name of the sequence to get. Must not be null </param>
		/// <param name="block"> the block from where to get the sequence
		/// 
		/// This method invokes the static version of <seealso cref="#getSequenceList(String)"/> </param>
		/// <seealso cref= #getSequenceList(String)
		/// </seealso>
		/// <returns> found sequences or empty list
		/// @since 7.8.1 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unchecked") public java.util.List<SwiftTagListBlock> getSequenceList(final String name, final SwiftTagListBlock block)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual IList<SwiftTagListBlock> getSequenceList(string name, SwiftTagListBlock block) // cant make static, but should be
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String methodName = GETSEQUENCE+name+"List";
			string methodName = GETSEQUENCE + name + "List";
			return (IList<SwiftTagListBlock>) invokeHere(methodName, this, block);
		}

		/// <summary>
		/// Test if the MT class contains a getSequenceXList method
		/// @since 7.8 </summary>
		/// <seealso cref= #getSequenceList(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean containsSequenceList(final String name)
		public virtual bool containsSequenceList(string name)
		{
			try
			{
				return this.GetType().GetMethod(GETSEQUENCE + name + "List") != null;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Test if the MT class contains a getSequenceX method
		/// @since 7.8 </summary>
		/// <seealso cref= #getSequence(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean containsSequence(final String name)
		public virtual bool containsSequence(string name)
		{
			try
			{
				return this.GetType().GetMethod(GETSEQUENCE + name) != null;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// @since 7.6 </summary>
		/// <param name="methodName"> a method to invoke </param>
		/// <returns> result from reflection call </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private Object invokeHere(final String methodName, final Object where, final SwiftTagListBlock argument)
		private object invokeHere(string methodName, object @where, SwiftTagListBlock argument)
		{
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Method method = argument==null ? getClass().getMethod(methodName) : getClass().getMethod(methodName, SwiftTagListBlock.class);
				Method method = argument == null ? this.GetType().GetMethod(methodName) : this.GetType().GetMethod(methodName, typeof(SwiftTagListBlock));
				if (argument == null)
				{
					return method.invoke(@where);
				}
				return method.invoke(@where, argument);
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final NoSuchMethodException e)
			catch (NoSuchMethodException e)
			{
				log.log(Level.FINE, "Method " + methodName + " does not exist in " + this.GetType(), e);
			}
			catch (Exception e)
			{
				log.log(Level.WARNING, "An error occured while invoking " + methodName + " in " + @where, e);
			}
			return null;
		}

		/// <summary>
		/// Convenience method to get a sequence named <code>name</code> from this message without creating the MTXXX class.
		/// 
		/// <code>getSequence("A")</code>
		/// is the same as 
		/// <code>((CastToSpecificMT)getMT()).getSequenceA()</code>
		///  
		/// <em>The requested sequence must NOT be repetitive</em> for repetitive sequences use getSequenceList(name)
		/// @since 7.6 </summary>
		/// <param name="name"> the sequence alpha numeric identifier such as A1a </param>
		/// <returns> found sequence or empty sequence block </returns>
		/// <seealso cref= #getSequenceList(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSequence(final String name)
		public virtual SwiftTagListBlock getSequence(string name)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String methodName = GETSEQUENCE+name;
			string methodName = GETSEQUENCE + name;
			object o = invokeHere(methodName, this, null);
			return (SwiftTagListBlock)o;
		}

		/// <summary>
		/// Get the sequence with the given name from the tags in block invoking the proper static method in the mt class
		/// </summary>
		/// <param name="name"> the name of the sequence to get </param>
		/// <param name="block"> the block where to extract the sequence from </param>
		/// <returns> found sequence or empty sequence block
		/// @since 7.8.1 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSequence(final String name, final SwiftTagListBlock block)
		public virtual SwiftTagListBlock getSequence(string name, SwiftTagListBlock block) // cant make static, but should be
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String methodName = GETSEQUENCE+name;
			string methodName = GETSEQUENCE + name;
			object o = invokeHere(methodName, this, block);
			return (SwiftTagListBlock)o;
		}

		public override string ToString()
		{
			return "AbstractMT [m=" + m + "]";
		}

		/// <summary>
		/// Sets the signature to the message
		/// </summary>
		/// <param name="signature"> the signature to set in block S </param>
		/// <returns> <code>this</code> </returns>
		/// <exception cref="IllegalStateException"> if the internal SwiftMessage object is null
		/// @since 7.10.4 </exception>
		public virtual AbstractMT setSignature(string signature)
		{

			// sanity check
			if (SwiftMessage == null)
			{
				throw new IllegalStateException("SwiftMessage was not initialized");
			}

			// set the signature
			SwiftMessage.Signature = signature;

			return (this);
		}

		/// <summary>
		/// Gets the signature of the message (looks for an S block then the MDG tag)
		/// </summary>
		/// <returns> the signature of the message (or null if none exists)
		/// @since 7.10.4 </returns>
		public virtual string Signature
		{
			get
			{
    
				return (SwiftMessage != null ? SwiftMessage.Signature : null);
			}
		}

		/// <summary>
		/// Create a blank message for the given category setting TEST bics as sender and receiver </summary>
		/// <param name="messageType"> the message type </param>
		/// <returns> created message object </returns>
		/// <seealso cref= #create(int, String, String)
		/// @since 7.6 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static AbstractMT create(final int messageType)
		public static AbstractMT create(int messageType)
		{
			return create(messageType, BIC.TEST8, BIC.TEST8);
		}
		/// <summary>
		/// Create a blank message for the given category setting the given sender and receiver BICs </summary>
		/// <param name="messageType"> the message type </param>
		/// <param name="sender"> the sender BIC11 code </param>
		/// <param name="receiver"> the receiver BIC11 code </param>
		/// <returns> created message object
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static AbstractMT create(final int messageType, final String sender, final String receiver)
		public static AbstractMT create(int messageType, string sender, string receiver)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage sm = new SwiftMessage(true);
			SwiftMessage sm = new SwiftMessage(true);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock2Input b2 = new SwiftBlock2Input();
			SwiftBlock2Input b2 = new SwiftBlock2Input();
			b2.MessageType = Convert.ToInt32(messageType).ToString();
			b2.Input = true;
			// TODO revisar valores de inicializacion
			b2.MessagePriority = "N";
			b2.DeliveryMonitoring = "2";
			b2.ObsolescencePeriod = "020";
			sm.Block2 = b2;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final AbstractMT result = sm.toMT();
			AbstractMT result = sm.toMT();
			result.Sender = StringUtils.rightPad(sender, 12, 'X');
			result.Receiver = StringUtils.rightPad(receiver, 12, 'X');
			return result;
		}

		/// <summary>
		/// Add all tags from block to the end of the block4 </summary>
		/// <param name="block"> a block to append </param>
		/// <returns> this same object for chained calls
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractMT append(final SwiftTagListBlock block)
		public virtual AbstractMT append(SwiftTagListBlock block)
		{
			Validate.notNull(block);
			if (!block.Empty)
			{
				b4().addTags(block.getTags());
			}
			return this;
		}
		/// <summary>
		/// Add all tags to the end of the block4 </summary>
		/// <param name="tags"> a list of tags to add </param>
		/// <returns> this same object for chained calls
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractMT append(final Tag... tags)
		public virtual AbstractMT append(params Tag[] tags)
		{
			Validate.notNull(tags);
			if (tags.Length > 0)
			{
				foreach (Tag t in tags)
				{
					b4().append(t);
				}
			}
			return this;
		}
		/// <summary>
		/// Add all the fields to the end of the block4 </summary>
		/// <param name="fields"> a list of fields to add </param>
		/// <returns> this same object for chained calls
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractMT append(final com.prowidesoftware.swift.model.field.Field... fields)
		public virtual AbstractMT append(params Field[] fields)
		{
			Validate.notNull(fields);
			if (fields.Length > 0)
			{
				foreach (Field t in fields)
				{
					b4().append(t);
				}
			}
			return this;
		}
		private SwiftBlock4 b4()
		{
			if (this.m == null)
			{
				throw new IllegalStateException("SwiftMessage is null");
			}
			else
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = this.m.getBlock4();
				SwiftBlock4 b4 = this.m.Block4;
				if (b4 == null)
				{
					this.m.Block4 = new SwiftBlock4();
					return this.m.Block4;
				}
				return b4;
			}
		}

		/// <summary>
		/// Base implementation for subclasses static parse.
		/// 
		/// @since 7.7
		/// </summary>
		protected internal static SwiftMessage read(string fin)
		{
			try
			{
				return SwiftMessage.parse(fin);
			}
			catch (IOException e)
			{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
				log.severe("An error occured while reading FIN :" + e.GetType().FullName);
				log.log(Level.SEVERE, "Read exception");
				log.log(Level.SEVERE, "Read exception while parsing " + fin, e);
			}
			return null;
		}

		/// <summary>
		/// Writes the message into a file with its message content in the FIN format.
		/// </summary>
		/// <param name="file"> a not null file to write, if it does not exists, it will be created </param>
		/// <exception cref="IOException"> if the file cannot be written
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void write(File file) throws IOException
		public virtual void write(File file)
		{
			Validate.notNull(file, "the file to write cannot be null");
			Validate.notNull(this.m, "the message to write cannot be null");
			bool created = file.createNewFile();
			if (created)
			{
				log.fine("new file created: " + file.AbsolutePath);
			}
			FileWriter fw = new FileWriter(file.AbsoluteFile);
			this.m.removeEmptyBlocks();
			SwiftWriter.writeMessage(this.m, fw);
			fw.close();
		}

		/// <summary>
		/// Writes the message into a given output stream with its message content in the FIN format, 
		/// encoding content in UTF-8.
		/// </summary>
		/// <param name="stream"> a non null stream to write </param>
		/// <exception cref="IOException"> if the stream cannot be written
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void write(OutputStream stream) throws IOException
		public virtual void write(OutputStream stream)
		{
			Validate.notNull(stream, "the stream to write cannot be null");
			Validate.notNull(this.m, "the message to write cannot be null");
			stream.write(message().GetBytes("UTF-8"));
		}

		/// <summary>
		/// Returns the JSON representation of the SwiftMessage attribute </summary>
		/// @deprecated use <seealso cref="#toJson()"/> instead 
		/// <seealso cref= #toJson() </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#toJson()"/> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase2=com.prowidesoftware.deprecation.TargetYear._2019) public String json()
		[Obsolete("use <seealso cref="#toJson()"/> instead")]
		public virtual string json()
		{
			Validate.notNull(this.m, "the message cannot be null");
			return this.m.toJson();
		}

		/// <summary>
		/// Returns the message content in XML format.<br>
		/// The XML created is the internal format defined and used by Prowide Core.<br>
		/// Notice: it is neither a standard nor the MX version of this MT.
		/// 
		/// @since 7.7
		/// </summary>
		public virtual string xml()
		{
			Validate.notNull(this.m, "the message cannot be null");
			return this.m.toXml();
		}

		/// <summary>
		/// Returns true if the message is the same type as the indicated by parameter.
		/// </summary>
		/// <param name="type"> a three digits number indicating a SWIFT MT type </param>
		/// <returns> true if the message is the same type, false if not or if the message type cannot be determined.
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean isType(final Integer type)
		public virtual bool isType(int? type)
		{
			return this.m.TypeInt == type;
		}

		/// <summary>
		/// Get the given sequence from the msg
		/// </summary>
		/// <param name="msg"> the message to extract the sequence from </param>
		/// <param name="sequence"> the sequence name </param>
		/// <returns> the given sequence or null if msg is null, sequence is null or the message can not be converted to MT 
		/// @since 7.7 </returns>
		/// <seealso cref= SwiftMessage#toMT() </seealso>
		/// @deprecated use <code>msg.toMT().getSequence(sequence)</code> instead of this method 
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SwiftTagListBlock getSequence(final SwiftMessage msg, final String sequence)
		public static SwiftTagListBlock getSequence(SwiftMessage msg, string sequence)
		{
			if (msg != null && sequence != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final AbstractMT amt = msg.toMT();
				AbstractMT amt = msg.toMT();
				if (amt != null)
				{
					return amt.getSequence(sequence);
				}
			}
			return null;
		}

		/// <returns> the corresponding MT variant or null if flag field is not present
		/// @since 7.8 </returns>
		public virtual MTVariant Variant
		{
			get
			{
				return this.m.Variant;
			}
		}

		public virtual string nameFromClass()
		{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
			return StringUtils.substringAfter(this.GetType().FullName, ".MT");
		}

		/// <summary>
		/// Returns the MT message identification.<br>
		/// Composed by the business process, message type and variant.
		/// Example: fin.103.STP
		/// </summary>
		/// <returns> the constructed message id
		/// @since 7.8.4 </returns>
		public virtual MtId MtId
		{
			get
			{
				return new MtId(MessageType, Variant);
			}
		}

		/// <summary>
		/// Returns a tag or null if tag not found </summary>
		/// <param name="tagName"> tag name to find including letter option, example "33B" </param>
		/// <returns> found tag or null
		/// @since 7.8.9 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected Tag tag(final String tagName)
		protected internal virtual Tag tag(string tagName)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage _m = getSwiftMessageNotNullOrException();
			SwiftMessage _m = SwiftMessageNotNullOrException;
			if (_m.Block4 == null)
			{
				log.info("block4 is null");
				return null;
			}
			return _m.Block4.getTagByName(tagName);
		}

		/// <summary>
		/// Returns an array of tags or null if non is found </summary>
		/// <param name="tagName"> tag name to find including letter option, example "33B" </param>
		/// <returns> found tags or null
		/// @since 7.8.9 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected Tag[] tags(final String tagName)
		protected internal virtual Tag[] tags(string tagName)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage _m = getSwiftMessageNotNullOrException();
			SwiftMessage _m = SwiftMessageNotNullOrException;
			if (_m.Block4 == null)
			{
				log.info("block4 is null");
				return null;
			}
			else
			{
				return _m.Block4.getTagsByName(tagName);
			}
		}

		/// <summary>
		/// Get a json representation of this message with expanded fields content.
		/// @since 7.10.3
		/// </summary>
		public virtual string toJson()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().registerTypeAdapter(AbstractMT.class, new AbstractMTAdapter()).setPrettyPrinting().create();
			Gson gson = (new GsonBuilder()).registerTypeAdapter(typeof(AbstractMT), new AbstractMTAdapter()).setPrettyPrinting().create();
			return gson.toJson(this,typeof(AbstractMT));
		}

		/// <summary>
		/// This method deserializes the JSON data into a specific MT object. </summary>
		/// <param name="json"> a JSON representation of an MT message </param>
		/// <returns> a specific deserialized MT message object, for example MT103
		/// @since 7.10.3 </returns>
		public static AbstractMT fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().registerTypeAdapter(AbstractMT.class, new AbstractMTAdapter()).registerTypeAdapter(SwiftBlock2.class, new SwiftBlock2Adapter()).create();
			Gson gson = (new GsonBuilder()).registerTypeAdapter(typeof(AbstractMT), new AbstractMTAdapter()).registerTypeAdapter(typeof(SwiftBlock2), new SwiftBlock2Adapter()).create();
			return gson.fromJson(json, typeof(AbstractMT));
		}

		/// <summary>
		/// Gets the block 4 complete ordered list of fields </summary>
		/// <returns> return a list of Tag as a FieldNN instance or empty list if non is found
		/// @since 7.10.3 </returns>
		public virtual IList<Field> Fields
		{
			get
			{
				IList<Field> fields = new List<Field>();
				foreach (Tag tag in this.m.Block4.Tags)
				{
					fields.Add(tag.asField());
				}
				return fields;
			}
		}

	}
}