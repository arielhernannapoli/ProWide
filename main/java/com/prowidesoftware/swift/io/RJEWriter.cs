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

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;
	using AbstractMT = com.prowidesoftware.swift.model.mt.AbstractMT;
	using Validate = org.apache.commons.lang3.Validate;

	/// <summary>
	/// Helper API to write MT messages into RJE files. </summary>
	/// <seealso cref= AbstractWriter
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8 </seealso>
	public class RJEWriter : AbstractWriter
	{

		private int count = 0;

		private char splitChar = RJEReader.SPLITCHAR;

		private const string MESSAGE_TO_WRITE_CONDITION = "message to write cannot be null";
		private const string WRITER_MESSAGE = "writer has not been initialized";


		/// <summary>
		/// Constructs a RJEWriter to write content into a given Writer instance. </summary>
		/// <param name="writer"> </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public RJEWriter(final Writer writer)
		public RJEWriter(Writer writer) : base(writer)
		{
		}

		/// <summary>
		/// Constructs a RJEWriter to write content into a file. </summary>
		/// <param name="file"> </param>
		/// <exception cref="FileNotFoundException">  </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public RJEWriter(final File file) throws FileNotFoundException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public RJEWriter(File file) : base(file)
		{
		}

		/// <summary>
		/// Constructs a RJEWriter to write content into a file. </summary>
		/// <param name="filename"> file to create </param>
		/// <exception cref="FileNotFoundException">  </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public RJEWriter(final String filename) throws FileNotFoundException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public RJEWriter(string filename) : base(filename)
		{
		}

		/// <summary>
		/// Constructs a RJEWriter to write content into a given stream. </summary>
		/// <param name="stream"> </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public RJEWriter(final OutputStream stream)
		public RJEWriter(OutputStream stream) : base(stream)
		{
		}

		/// <summary>
		/// Writes the message content into the internal writer in RJE format. </summary>
		/// <param name="msg"> SWIFT MT content to write </param>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void write(final String msg) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual void write(string msg)
		{
			_write(msg, base.writer);
		}

		/// <summary>
		/// Writes the message into the internal writer in RJE format </summary>
		/// <param name="msg"> message to write </param>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void write(final com.prowidesoftware.swift.model.mt.AbstractMT msg) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual void write(AbstractMT msg)
		{
			_write(msg.message(), this.writer);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void _write(final String msg, final Writer writer) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		private void _write(string msg, Writer writer)
		{
			Validate.notNull(writer, WRITER_MESSAGE);
			Validate.notNull(msg, MESSAGE_TO_WRITE_CONDITION);
			if (count > 0)
			{
				writer.write(FINWriterVisitor.SWIFT_EOL);
				writer.write(splitChar);
				writer.write(FINWriterVisitor.SWIFT_EOL);
			}
			writer.write(msg);
			count++;
		}

		/// <seealso cref= #write(String, Writer) </seealso>
		/// <param name="msg"> message to write </param>
		/// <param name="writer"> </param>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static void write(final com.prowidesoftware.swift.model.mt.AbstractMT msg, final Writer writer) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static void write(AbstractMT msg, Writer writer)
		{
			Validate.notNull(msg, MESSAGE_TO_WRITE_CONDITION);
			write(msg.message(), writer);
		}

		/// <summary>
		/// Static implementation to write the message content into the parameter writer in RJE format.
		/// 
		/// <para>IMPORTANT: this method will always append a trailing CRLF and $ at the end which
		/// in some platforms can be rejected as an invalid RJE file. For a more compliant version
		/// use the non static implementation of the write calls, to ensure the split separator
		/// is present only between messages but not after the last one. Also notice this method
		/// implementation cannot use custom split separator chars.
		/// 
		/// </para>
		/// </summary>
		/// <param name="msg"> SWIFT MT content to write </param>
		/// <param name="writer"> </param>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static void write(final String msg, final Writer writer) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static void write(string msg, Writer writer)
		{
			Validate.notNull(writer, WRITER_MESSAGE);
			Validate.notNull(msg, MESSAGE_TO_WRITE_CONDITION);
			writer.write(msg);
			writer.write(FINWriterVisitor.SWIFT_EOL);
			writer.write(RJEReader.SPLITCHAR);
			writer.write(FINWriterVisitor.SWIFT_EOL);
		}

		/// <summary>
		/// Ovewrites the default standard split char <seealso cref="RJEReader#SPLITCHAR"/> </summary>
		/// <param name="c"> a character to use as message separator
		/// @since 7.9.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setSplitChar(final char c)
		public virtual char SplitChar
		{
			set
			{
				this.splitChar = splitChar;
			}
		}

	}

}