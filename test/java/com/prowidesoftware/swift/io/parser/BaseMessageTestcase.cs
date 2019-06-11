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
namespace com.prowidesoftware.swift.io.parser
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.fail;


	using SwiftBlock1 = com.prowidesoftware.swift.model.SwiftBlock1;
	using SwiftBlock2 = com.prowidesoftware.swift.model.SwiftBlock2;
	using SwiftBlock3 = com.prowidesoftware.swift.model.SwiftBlock3;
	using SwiftBlock4 = com.prowidesoftware.swift.model.SwiftBlock4;
	using SwiftBlock5 = com.prowidesoftware.swift.model.SwiftBlock5;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using Tag = com.prowidesoftware.swift.model.Tag;

	/// <summary>
	/// Base class for tests of specific message types
	/// 
	/// @since 4.0
	/// </summary>
	public abstract class BaseMessageTestcase
	{

		protected internal SwiftBlock1 b1;
		protected internal SwiftBlock2 b2;
		protected internal SwiftBlock3 b3;
		protected internal SwiftBlock4 b4;
		protected internal SwiftBlock5 b5;
		protected internal SwiftMessage o;
		protected internal Tag[] tags;
		protected internal Tag t;
		protected internal string messageToParse;

		protected internal virtual SwiftParser buildParser(string filename)
		{
			InputStream @is = getInputStream(filename);
			SwiftParser parser = new SwiftParser(@is);
			return parser;
		}

		protected internal virtual InputStream getInputStream(string filename)
		{
			InputStream @is = this.GetType().getResourceAsStream(filename);
			if (@is == null)
			{
				fail(filename + " not found in classpath");
			}
			return @is;
		}

		protected internal virtual string readMessageFromInputStream(InputStream @is)
		{
			// prepare the output
			string s = null;
			try
			{
				StringBuilder msgBuf = new StringBuilder();

				// append until $ or EOF
				int c;
				do
				{
					c = @is.read();
					if (c != '$' && c != -1)
					{
						msgBuf.Append((char) c);
					}
				} while (c != '$' && c != -1);

				// check for end of input
				if (msgBuf.Length > 0)
				{
					s = msgBuf.ToString();
				}
			}
			catch (IOException e)
			{
				fail("Reading input file: FAILED [" + e.Message + "]");
			}
			return (s);
		}

		protected internal virtual SwiftMessage parseMessage(string msg)
		{
			o = null;
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParser parser = new SwiftParser(new java.io.StringReader(msg));
				SwiftParser parser = new SwiftParser(new StringReader(msg));
				o = parser.message();
				if (o != null)
				{
					this.b1 = o.Block1;
					this.b2 = o.Block2;
					this.b3 = o.Block3;
					this.b4 = o.Block4;
					this.b5 = o.Block5;
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
				fail("Parsing of: " + msg + " failed: " + e);
			}
			assertNotNull(o);
			return o;
		}

		protected internal virtual SwiftMessage parseResource(string m)
		{
			o = null;
			try
			{
				o = buildParser(m).message();
				if (o != null)
				{
					this.b1 = o.Block1;
					this.b2 = o.Block2;
					this.b3 = o.Block3;
					this.b4 = o.Block4;
					this.b5 = o.Block5;
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
				fail("Parsing of: " + m + " failed: " + e);
			}
			assertNotNull(o);
			return o;
		}

		/// <summary>
		/// Asserts that the given message and blocks 1-5 are not null </summary>
		/// <param name="o"> the swift message </param>
		protected internal virtual void assertAllBlocksNonNull(SwiftMessage o)
		{
			assertNotNull(o);
			assertNotNull("Block 1 is null", o.Block1);
			assertNotNull("Block 2 is null", o.Block2);
			assertNotNull("Block 3 is null", o.Block3);
			assertNotNull("Block 4 is null", o.Block4);
			assertNotNull("Block 5 is null", o.Block5);
		}

	}

}