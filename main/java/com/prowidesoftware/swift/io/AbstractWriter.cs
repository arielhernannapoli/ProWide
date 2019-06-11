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
	/// Base implementation for message writers.
	/// <br>
	/// Messages are converted into its FIN representation and written
	/// into the output file with proper delimiters and length.
	/// <br>
	/// The writer can be used in two different ways:
	/// <ul>
	/// <li>Writing messages directly into given Writer object, using the
	/// static write call method.</li>
	/// <li>Instantiating the writer for a particular File or stream, calling
	/// the write methods and closing the writer when all messages has been written</li>
	/// </ul>
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8
	/// </summary>
	public abstract class AbstractWriter
	{
		protected internal Writer writer = null;

		/// <summary>
		/// Constructs a writer to write content into a given Writer instance. </summary>
		/// <param name="writer"> </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractWriter(final java.io.Writer writer)
		public AbstractWriter(Writer writer)
		{
			this.writer = writer;
		}

		/// <summary>
		/// Constructs a writer to write content into a file. </summary>
		/// <param name="file"> </param>
		/// <exception cref="FileNotFoundException">  </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public AbstractWriter(final java.io.File file) throws java.io.FileNotFoundException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public AbstractWriter(File file)
		{
			this.writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file)));
		}

		/// <summary>
		/// Constructs a writer to write content into a file. </summary>
		/// <param name="filename"> file to create </param>
		/// <exception cref="FileNotFoundException">  </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public AbstractWriter(final String filename) throws java.io.FileNotFoundException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public AbstractWriter(string filename)
		{
			this.writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(filename)));
		}

		/// <summary>
		/// Constructs a writer to write content into a given stream. </summary>
		/// <param name="stream"> </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractWriter(final java.io.OutputStream stream)
		public AbstractWriter(OutputStream stream)
		{
			this.writer = new BufferedWriter(new OutputStreamWriter(stream));
		}

		/// <summary>
		/// Close the stream. </summary>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void close() throws java.io.IOException
		public virtual void close()
		{
			if (this.writer != null)
			{
				this.writer.close();
			}
		}

		/// <summary>
		/// Flush the stream. </summary>
		/// <exception cref="IOException"> if an I/O error occurs </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void flush() throws java.io.IOException
		public virtual void flush()
		{
			if (this.writer != null)
			{
				this.writer.flush();
			}
		}

	}

}