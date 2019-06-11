using System.Collections.Generic;

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
namespace com.prowidesoftware.swift.io
{


	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;

	using SwiftParser = com.prowidesoftware.swift.io.parser.SwiftParser;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using AbstractMT = com.prowidesoftware.swift.model.mt.AbstractMT;

	/// <summary>
	/// Base class for message reader iterators.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8
	/// </summary>
	public abstract class AbstractReader : IEnumerator<string>, IEnumerable<string>
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		private static readonly Logger log = Logger.getLogger(typeof(AbstractReader).FullName);
		protected internal Reader reader = null;

		/// <summary>
		/// Constructs a reader to read messages from a given Reader instance
		/// </summary>
		public AbstractReader(Reader r)
		{
			this.reader = r;
		}

		/// <summary>
		/// Constructs a reader to read messages from a string </summary>
		/// <exception cref="IllegalArgumentException"> if string is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractReader(final String string)
		public AbstractReader(string @string)
		{
			Validate.notNull(@string, "string must not be null");
			this.reader = new StringReader(@string);
		}

		/// <summary>
		/// Constructs a reader to read messages from a stream </summary>
		/// <exception cref="IllegalArgumentException"> if stream is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractReader(final java.io.InputStream stream)
		public AbstractReader(InputStream stream)
		{
			Validate.notNull(stream, "stream must not be null");
			this.reader = new InputStreamReader(stream);
		}

		/// <summary>
		/// Constructs a reader to read messages from a file </summary>
		/// <exception cref="IllegalArgumentException"> if file is null </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public AbstractReader(final java.io.File file) throws java.io.FileNotFoundException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public AbstractReader(File file)
		{
			Validate.notNull(file, "file must not be null");
			Validate.isTrue(file.exists(), "Non existent file: " + file.AbsolutePath);
			this.reader = new FileReader(file);
		}

		public virtual IEnumerator<string> GetEnumerator()
		{
			return this;
		}

		public abstract string next();

		public override void remove()
		{
			throw new System.NotSupportedException("remove not avaiable in this implementation");
		}

		/// <summary>
		/// Reads the next raw content from the iterator and returns the message parsed into an MT.
		/// <para>IMPORTANT:<br>
		/// Since MTnnn model classes are implemented only for system and user-to-user messages 
		/// (categories 0 to 9) if an ACK/NAK (service id 21) message is found, the MT following 
		/// the system message is returned (not the ACK/NAK).<br>
		/// For other service messages (login, select, quit) this method will return null because 
		/// there is no MT representation to create.<br>
		/// If you need to deal with all type of messages (including service, system and user-to-user)
		/// you can use <seealso cref="#nextSwiftMessage()"/> instead.
		/// 
		/// </para>
		/// </summary>
		/// <returns> parsed message or null if content is blank </returns>
		/// <exception cref="IOException"> if the message content cannot be parsed into an MT </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.mt.AbstractMT nextMT() throws java.io.IOException
		public virtual AbstractMT nextMT()
		{
			SwiftMessage candidate = nextSwiftMessage();
			if (candidate != null)
			{
				if (candidate.ServiceMessage21)
				{
					/*
					 * message is an ACK/NACK, we parse the appended original message instead
					 */
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = candidate.getUnparsedTexts().getAsFINString();
					string fin = candidate.UnparsedTexts.AsFINString;
					SwiftParser parser = new SwiftParser(new ByteArrayInputStream(fin.GetBytes()));
					return parser.message().toMT();
				}
				else if (candidate.ServiceMessage)
				{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
					log.warning("nextMT in " + this.GetType().FullName + " is not intended for service messages, use nextSwiftMessage() instead");
					return null;
				}
				else
				{
					return candidate.toMT();
				}
			}
			return null;
		}

		/// <summary>
		/// Reads the next raw content from the iterator and returns the message parsed as a generic SwiftMessage.
		/// This method is convenient where the RJE content can include any type of message including
		/// service messages, system messages and user-to-user messages.
		/// </summary>
		/// <returns> parsed message or null if content is blank </returns>
		/// <exception cref="IOException"> if the message content cannot be parsed into a SwiftMessage
		/// @since 7.8.3 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.SwiftMessage nextSwiftMessage() throws java.io.IOException
		public virtual SwiftMessage nextSwiftMessage()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String msg = next();
			string msg = next();
			if (StringUtils.isNotBlank(msg))
			{
				SwiftParser parser = new SwiftParser(new ByteArrayInputStream(msg.GetBytes()));
				return parser.message();
			}
			log.warning("Ignoring blank message");
			return null;
		}

	}

}