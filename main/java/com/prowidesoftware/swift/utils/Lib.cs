using System.Text;
using System.Threading;

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
namespace com.prowidesoftware.swift.utils
{

	using StringUtils = org.apache.commons.lang3.StringUtils;

	/// <summary>
	/// Miscellaneous helper functions.
	/// </summary>
	public class Lib
	{
		private Lib()
		{
		}

		/// <summary>
		/// Read the content of the given file into a string.
		/// </summary>
		/// <param name="filename"> the name of the file to be read </param>
		/// <seealso cref= #readFile(File)
		/// @since 7.6 </seealso>
		/// <exception cref="IOException"> if an error occurs during read </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String readFile(final String filename) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string readFile(string filename)
		{
			return readFile(new File(filename));
		}

		/// <summary>
		/// Read the content of the given file into a string, using UTF8 as default encoding </summary>
		/// <seealso cref= #readFile(File, String) </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String readFile(final File file) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string readFile(File file)
		{
			return readFile(file, null);
		}

		/// <summary>
		/// Read the content of the given file into a string.
		/// </summary>
		/// <param name="file"> the file to be read </param>
		/// <param name="encoding"> encoding to use, may be null in which case UTF-8 is used as default </param>
		/// <returns> the file contents or null if file is null or does not exist, or can't be read, or is not a file </returns>
		/// <exception cref="IOException"> if an error occurs during read </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String readFile(final File file, final String encoding) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string readFile(File file, string encoding)
		{
			if (file == null || !file.exists() || !file.canRead() || !file.File)
			{
				return null;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String charset = encoding != null? encoding : "UTF-8";
			string charset = encoding != null? encoding : "UTF-8";
			BufferedReader @in = new BufferedReader(new InputStreamReader(new FileInputStream(file), charset));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder((int) file.length());
			StringBuilder sb = new StringBuilder((int) file.length());
			try
			{
				int c = 0;
				while ((c = @in.read()) != -1)
				{
					sb.Append((char)c);
				}
			}
			finally
			{
				@in.close();
			}
			return sb.ToString();
		}

		/// <summary>
		/// Read a resource from classpath using the context classloader, using UTF8 as default encoding </summary>
		/// <seealso cref= #readResource(String, String)
		/// @since 7.10.0 </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String readResource(final String resource) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string readResource(string resource)
		{
			return readResource(resource, null);
		}

		/// <summary>
		/// Read a resource from classpath using the context classloader </summary>
		/// <param name="resource"> the resource name to read, must not be null </param>
		/// <param name="encoding"> optional, may be null in which case UTF-8 is used as default </param>
		/// <returns> read content or empty string if resource cannot be loaded </returns>
		/// <exception cref="IOException"> if the resource stream cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String readResource(final String resource, final String encoding) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string readResource(string resource, string encoding)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final InputStream is = Thread.currentThread().getContextClassLoader().getResourceAsStream(resource);
			InputStream @is = Thread.CurrentThread.ContextClassLoader.getResourceAsStream(resource);
			if (@is == null)
			{
				return StringUtils.EMPTY;
			}
			return readStream(@is, encoding);
		}

		/// <summary>
		/// Read the content of the given stream into a string.
		/// </summary>
		/// <param name="stream"> the contents to read </param>
		/// <returns> the read content </returns>
		/// <seealso cref= #readStream(InputStream, String) </seealso>
		/// <exception cref="IOException"> if the resource stream cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String readStream(final InputStream stream) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string readStream(InputStream stream)
		{
			return readStream(stream, null);
		}

		/// <summary>
		/// Read the content of the given stream into a string.
		/// </summary>
		/// <param name="stream"> the contents to read </param>
		/// <param name="enconding"> encoding to use, , may be null in which case UTF-8 is used as default </param>
		/// <returns> the read content </returns>
		/// <exception cref="IOException"> if the resource stream cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String readStream(final InputStream stream, final String enconding) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string readStream(InputStream stream, string enconding)
		{
			if (stream == null)
			{
				return null;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder out = new StringBuilder();
			StringBuilder @out = new StringBuilder();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String enc = enconding != null ? enconding : "UTF-8";
			string enc = enconding != null ? enconding : "UTF-8";
			using (Reader @in = new InputStreamReader(stream, enc))
			{
				int c = 0;
				while ((c = @in.read()) != -1)
				{
					@out.Append((char)c);
				}
			}
			return @out.ToString();
		}

		/// <summary>
		/// Read the content of the given reader into a string.
		/// </summary>
		/// <param name="reader"> the contents to read </param>
		/// <returns> the read content </returns>
		/// <exception cref="IOException"> if the resource stream cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String readReader(final Reader reader) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string readReader(Reader reader)
		{
			if (reader == null)
			{
				return null;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder out = new StringBuilder();
			StringBuilder @out = new StringBuilder();
			try
			{
				int c = 0;
				while ((c = reader.read()) != -1)
				{
					@out.Append((char) c);
				}
			}
			finally
			{
				reader.close();
			}
			return @out.ToString();
		}

	}
}