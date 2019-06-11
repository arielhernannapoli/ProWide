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

	using Lib = com.prowidesoftware.swift.utils.Lib;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Generic MT representation for <strong>service messages</strong> with service id 21 = GPA/FIN Message (ACK/NAK/UAK/UNK).
	/// It can hold both a positive or negative acknowledge.
	/// <br>
	/// For system messages, category 0, see the MT0xx classes.
	/// 
	/// @since 7.10.4
	/// </summary>
	public class ServiceMessage21 : AbstractMT
	{

		/// <param name="aMessage"> </param>
		/// <exception cref="RuntimeException"> if the message is not a service message with service id 21 (meaning positive or negative acknowledge) </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public ServiceMessage21(final com.prowidesoftware.swift.model.SwiftMessage aMessage)
		public ServiceMessage21(SwiftMessage aMessage) : base(aMessage)
		{
			Validate.isTrue(aMessage.ServiceMessage21);
		}

		/// <summary>
		/// Creates a new ServiceMessage21 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public ServiceMessage21(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public ServiceMessage21(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new ServiceMessage21 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public ServiceMessage21(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public ServiceMessage21(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new ServiceMessage21 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format </param>
		/// <exception cref="RuntimeException"> if the message is not a service message with service id 21 (meaning positive or negative acknowledge) </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public ServiceMessage21(final String fin)
		public ServiceMessage21(string fin) : base()
		{
			if (fin != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftMessage parsed = read(fin);
				SwiftMessage parsed = read(fin);
				if (parsed != null)
				{
					base.m = parsed;
					Validate.isTrue(parsed.ServiceMessage21);
				}
			}
		}

		/// <param name="swiftMessage"> </param>
		/// <exception cref="RuntimeException"> if the message is not a service message with service id 21 (meaning positive or negative acknowledge) </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static AbstractMT newInstance(final com.prowidesoftware.swift.model.SwiftMessage swiftMessage)
		public static AbstractMT newInstance(SwiftMessage swiftMessage)
		{
			return new ServiceMessage21(swiftMessage);
		}

		/// <summary>
		/// Creates an ServiceMessage21 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the ServiceMessage21 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #ServiceMessage21(String) </seealso>
		public static ServiceMessage21 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new ServiceMessage21(m.message());
		}

		/// <summary>
		/// Creates a new ServiceMessage21 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of ServiceMessage21 or null if stream is null or the message cannot be parsed </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static ServiceMessage21 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static ServiceMessage21 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new ServiceMessage21(stream);
		}

		/// <summary>
		/// Creates a new ServiceMessage21 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of ServiceMessage21 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static ServiceMessage21 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static ServiceMessage21 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new ServiceMessage21(file);
		}

		/// <summary>
		/// Creates a new ServiceMessage21 by parsing a String with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format </param>
		/// <returns> a new instance of ServiceMessage21 or null if; fin is null or the message cannot be parsed </returns>
		/// <exception cref="RuntimeException"> if the message is not a service message with service id 21 (meaning positive or negative acknowledge) </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static ServiceMessage21 parse(final String fin)
		public static ServiceMessage21 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new ServiceMessage21(fin);
		}

		/// <summary>
		/// Will always return null because service messages do not contain a message type.
		/// </summary>
		public override string MessageType
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Returns true if this message is an ACK (positive acknowledge).
		/// This is determined by testing if the value of field 451 is 0.
		/// If Field 451 is not present, returns false.
		/// </summary>
		public bool Ack
		{
			get
			{
				return this.m.Ack;
			}
		}

		/// <summary>
		/// Returns true if this message is an NACK (negative acknowledge).
		/// This is determined by testing if the value of field 451 is 1.
		/// If Field 451 is not present, returns false.
		/// </summary>
		public bool Nack
		{
			get
			{
				return this.m.Nack;
			}
		}

		/// <summary>
		/// Returns the error code present in NAK messages in field 405 </summary>
		/// <returns> error code found or null if the error code field is not present </returns>
		public virtual string ErrorCode
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final com.prowidesoftware.swift.model.Tag t = base.m.getBlock4().getTagByName("405");
				Tag t = base.m.Block4.getTagByName("405");
				if (t == null)
				{
					return null;
				}
				return t.asField().getComponent(1);
			}
		}

		/// <summary>
		/// Returns the error line present in NAK messages in field 405 </summary>
		/// <returns> error code found or null if the error code field is not present </returns>
		public virtual string ErrorLine
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final com.prowidesoftware.swift.model.Tag t = base.m.getBlock4().getTagByName("405");
				Tag t = base.m.Block4.getTagByName("405");
				if (t == null)
				{
					return null;
				}
				return t.asField().getComponent(2);
			}
		}

	}
}