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


	using Validate = org.apache.commons.lang3.Validate;

	using AbstractMT = com.prowidesoftware.swift.model.mt.AbstractMT;

	/// <summary>
	/// Helper API to write MT messages into DOS-PCC files. </summary>
	/// <seealso cref= AbstractWriter
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8 </seealso>
	/*
	 * sebastian ago 2016: 
	 * According to documentation all messages must be precede with its ack.
	 * TODO: Use SwiftMessageFactory to create and prepend the ACK here
	 */
	public class PPCWriter : AbstractWriter
	{
		private static int SECTOR = 512;

		/// <summary>
		/// Constructs a PPCWriter to write content into a given Writer instance. </summary>
		/// <param name="writer"> </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public PPCWriter(final java.io.Writer writer)
		public PPCWriter(Writer writer) : base(writer)
		{
		}

		/// <summary>
		/// Constructs a PPCWriter to write content into a file. </summary>
		/// <param name="file"> </param>
		/// <exception cref="FileNotFoundException">  </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public PPCWriter(final java.io.File file) throws java.io.FileNotFoundException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public PPCWriter(File file) : base(file)
		{
		}

		/// <summary>
		/// Constructs a PPCWriter to write content into a file. </summary>
		/// <param name="filename"> file to create </param>
		/// <exception cref="FileNotFoundException">  </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public PPCWriter(final String filename) throws java.io.FileNotFoundException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public PPCWriter(string filename) : base(filename)
		{
		}

		/// <summary>
		/// Constructs a PPCWriter to write content into a given stream. </summary>
		/// <param name="stream"> </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public PPCWriter(final java.io.OutputStream stream)
		public PPCWriter(OutputStream stream) : base(stream)
		{
		}

		/// <summary>
		/// Writes the message content into the internal writer in DOS-PPC format. </summary>
		/// <param name="msg"> SWIFT MT content to write </param>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void write(final String msg) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual void write(string msg)
		{
			write(msg, base.writer);
		}

		/// <summary>
		/// Writes the message into the internal writer in DOS-PPC format </summary>
		/// <param name="msg"> message to write </param>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void write(final com.prowidesoftware.swift.model.mt.AbstractMT msg) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual void write(AbstractMT msg)
		{
			write(msg, this.writer);
		}

		/// <summary>
		/// Writes the message into the writer in DOS-PPC format </summary>
		/// <param name="msg"> message to write </param>
		/// <param name="writer"> </param>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static void write(final com.prowidesoftware.swift.model.mt.AbstractMT msg, final java.io.Writer writer) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static void write(AbstractMT msg, Writer writer)
		{
			Validate.notNull(msg, "message to write cannot be null");
			write(msg.message(), writer);
		}

		/// <summary>
		/// Writes the message content into the writer in DOS-PPC format </summary>
		/// <param name="msg"> SWIFT MT content to write </param>
		/// <param name="writer"> </param>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
		/*
		 * According to the specification content should be written in 8-bit ASCII
		 * We use Java default, UTF-8, that is compatible for SWIFT message content.
		 */
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static void write(final String msg, final java.io.Writer writer) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static void write(string msg, Writer writer)
		{
			Validate.notNull(writer, "writer has not been initialized");
			Validate.notNull(msg, "message to write cannot be null");
			writer.write(PPCReader.BEGIN);
			writer.write(msg);
			writer.write(PPCReader.END);

			// pad to fill sector length
			int length = msg.Length + 2;
			int pad = requiredPadding(length);
			for (int i = 0; i < pad; i++)
			{
				writer.write(PPCReader.EMPTY);
			}
		}

		/// <summary>
		/// Computes the padding to match the sector multiple
		/// Thanks https://github.com/safet-habibija for the fix </summary>
		/// <param name="length"> current message length </param>
		/// <returns> number of empty characters to append as padding </returns>
		private static int requiredPadding(int length)
		{
			return (SECTOR - (length % SECTOR)) % SECTOR;
		}

	}

}