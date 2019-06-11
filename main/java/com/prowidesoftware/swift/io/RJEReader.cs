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
namespace com.prowidesoftware.swift.io
{


	/// <summary>
	/// Helper class to read RJE files.
	/// <br>
	/// File content is splitted, and the iterator returns the raw message content of
	/// each SWIFT message found in the file. API is also provided to read each message 
	/// parsed into an MT..
	/// <br>
	/// The reader can be initialized with a File, Stream or String.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8
	/// </summary>
	public class RJEReader : AbstractReader
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(RJEReader.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		private static readonly Logger log = Logger.getLogger(typeof(RJEReader).FullName);
		public const char SPLITCHAR = '$';

		private char splitChar_ = SPLITCHAR;

		/// <summary>
		/// Constructs a RJEReader to read messages from a given Reader instance
		/// </summary>
		public RJEReader(Reader r) : base(r)
		{
		}

		/// <summary>
		/// Constructs a RJEReader to read messages from a string
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public RJEReader(final String string)
		public RJEReader(string @string) : base(@string)
		{
		}

		/// <summary>
		/// Constructs a RJEReader to read messages from a stream using the default encoding
		/// 
		/// <para>If you need to read the stream with a different encoding you can use
		/// <seealso cref="com.prowidesoftware.swift.utils.Lib#readStream(InputStream, String)"/>
		/// with the constructor receiving the String content
		/// </para>
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public RJEReader(final java.io.InputStream stream)
		public RJEReader(InputStream stream) : base(stream)
		{
		}

		/// <summary>
		/// Constructs a RJEReader to read messages from a file
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public RJEReader(final java.io.File file) throws java.io.FileNotFoundException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public RJEReader(File file) : base(file)
		{
		}

		/// <summary>
		/// Returns true if the iterator has more messages
		/// </summary>
		/*
		 * sebastian abr 2016
		 * si el contenido es blank porque hay un separador al final del file
		 * esto devuelve true, cuando seria deseable que devuelva false
		 */
		public virtual bool hasNext()
		{
			try
			{
				return reader.ready();
			}
			catch (IOException)
			{
				return false;
			}
		}

		/// <summary>
		/// Returns the next message in the iterator in its raw format
		/// </summary>
		public override string next()
		{
			if (reader != null)
			{
				int c;
				StringBuilder sb = new StringBuilder();
				try
				{
					while ((c = reader.read()) != -1 && (c != splitChar_))
					{
						sb.Append((char)c);
					}
					if (c == -1)
					{
						reader.close();
					}
				}
				catch (IOException)
				{
					return null;
				}
				return sb.ToString();
			}
			return null;
		}

		/// <summary>
		/// Ovewrites the default standard split char <seealso cref="#SPLITCHAR"/> </summary>
		/// <param name="c"> a character to use as message separator
		/// @since 7.9.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setSplitChar_(final char c)
		public virtual char SplitChar_
		{
			set
			{
				this.splitChar_ = splitChar_;
			}
		}

	}
}