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
namespace com.prowidesoftware.swift.model.mt
{

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using Lib = com.prowidesoftware.swift.utils.Lib;


	/// <summary>
	/// Use <seealso cref="ServiceMessage21 instead"/>
	/// @since 7.8
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @ProwideDeprecated(phase2 = TargetYear._2020) public class AckSystemMessage extends ServiceMessage21
	[Obsolete]
	public class AckSystemMessage : ServiceMessage21
	{

		/// <param name="aMessage"> </param>
		/// <exception cref="RuntimeException"> if the message is not a service message with service id 21 (meaning positive or negative acknowledge) </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AckSystemMessage(final com.prowidesoftware.swift.model.SwiftMessage aMessage)
		public AckSystemMessage(SwiftMessage aMessage) : base(aMessage)
		{
		}

		/// <param name="swiftMessage"> </param>
		/// <exception cref="RuntimeException"> if the message is not a service message with service id 21 (meaning positive or negative acknowledge) </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static AbstractMT newInstance(final com.prowidesoftware.swift.model.SwiftMessage swiftMessage)
		public static AbstractMT newInstance(SwiftMessage swiftMessage)
		{
			return new AckSystemMessage(swiftMessage);
		}

		/// <summary>
		/// Creates an AckSystemMessage initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the AckSystemMessage content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #AckSystemMessage(String)
		/// @since 7.8.9 </seealso>
		public static AckSystemMessage parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new AckSystemMessage(m.message());
		}

		/// <summary>
		/// Creates a new AckSystemMessage by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format.
		/// @since 7.8.9 </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public AckSystemMessage(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public AckSystemMessage(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new AckSystemMessage by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of AckSystemMessage or null if stream is null or the message cannot be parsed 
		/// @since 7.8.9 </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static AckSystemMessage parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static AckSystemMessage parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new AckSystemMessage(stream);
		}

		/// <summary>
		/// Creates a new AckSystemMessage by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format.
		/// @since 7.8.9 </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public AckSystemMessage(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public AckSystemMessage(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new AckSystemMessage by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of AckSystemMessage or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed
		/// @since 7.8.9 </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static AckSystemMessage parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static AckSystemMessage parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new AckSystemMessage(file);
		}

		/// <summary>
		/// Creates a new AckSystemMessage by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format </param>
		/// <exception cref="RuntimeException"> if the message is not a service message with service id 21 (meaning positive or negative acknowledge)
		/// @since 7.8.9 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AckSystemMessage(final String fin)
		public AckSystemMessage(string fin) : base(fin)
		{
		}

		/// <summary>
		/// Creates a new AckSystemMessage by parsing a String with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format </param>
		/// <returns> a new instance of AckSystemMessage or null if; fin is null or the message cannot be parsed </returns>
		/// <exception cref="RuntimeException"> if the message is not a service message with service id 21 (meaning positive or negative acknowledge)
		/// @since 7.8.9 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static AckSystemMessage parse(final String fin)
		public static AckSystemMessage parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new AckSystemMessage(fin);
		}

	}
}