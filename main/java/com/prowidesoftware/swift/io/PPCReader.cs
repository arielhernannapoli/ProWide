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
	/// Helper class to read DOS-PCC files.
	/// <br>
	/// File content is splitted, and the iterator returns the raw message content of
	/// each SWIFT message found in the file. API is also provided to read each message 
	/// parsed into an MT.
	/// <br>
	/// The reader can be initialized with a File, Stream or String.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8
	/// </summary>
	/*
	 * sebastian ago 2016: 
	 * According to documentation all messages must be precede with its ack.
	 * TODO: Remove the ack and parse the unparsed text here to return the actual MT
	 */
	public class PPCReader : AbstractReader
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		private static readonly Logger log = Logger.getLogger(typeof(PPCReader).FullName);

		internal const int BEGIN = 0x01;
		internal const int END = 0x03;
		internal const int NULL = 0x00;
		internal const int EMPTY = 0x20;

		private int curChar = 0;

		/// <summary>
		/// Constructs a PPCReader to read messages from a given Reader instance
		/// </summary>
		public PPCReader(Reader r) : base(r)
		{
		}

		/// <summary>
		/// Constructs a PPCReader to read messages from a string
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public PPCReader(final String string)
		public PPCReader(string @string) : base(@string)
		{
		}

		/// <summary>
		/// Constructs a PPCReader to read messages from a stream
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public PPCReader(final java.io.InputStream stream)
		public PPCReader(InputStream stream) : base(stream)
		{
		}

		/// <summary>
		/// Constructs a PPCReader to read messages from a file
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public PPCReader(final java.io.File file) throws java.io.FileNotFoundException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public PPCReader(File file) : base(file)
		{
		}

		/// <summary>
		/// Returns true if the iterator has more messages
		/// </summary>
		public virtual bool hasNext()
		{
			if (this.reader == null)
			{
				throw new IllegalStateException("reader is null");
			}
			while (curChar != -1 && curChar != BEGIN)
			{
				try
				{
					curChar = this.reader.read();
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final java.io.IOException e)
				catch (IOException e)
				{
					log.severe("IOException while reading: " + e);
					return false;
				}
			}
			return curChar == BEGIN;
		}

		/// <summary>
		/// Returns the next message in the iterator in its raw format
		/// </summary>
		public override string next()
		{
			if (curChar == BEGIN)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
				StringBuilder sb = new StringBuilder();

				bool done = false;
				do
				{
					try
					{
						curChar = this.reader.read();
					}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final java.io.IOException e)
					catch (IOException e)
					{
						log.severe("error reading: " + e);
						return sb.ToString();
					}
					if (curChar == -1 || curChar == END)
					{
						done = true;
					}
					else
					{
						sb.Append((char) curChar);
					}
				} while (!done);
				return sb.ToString();
			}
			else
			{
				throw new IllegalStateException("hasNext did not return true but this method was called");
			}
		}
	}

}