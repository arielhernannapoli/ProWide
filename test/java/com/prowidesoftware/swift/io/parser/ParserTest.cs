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
namespace com.prowidesoftware.swift.io.parser
{
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.fail;


	using Ignore = org.junit.Ignore;
	using Test = org.junit.Test;

	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using MT101 = com.prowidesoftware.swift.model.mt.mt1xx.MT101;

	public class ParserTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParseoIso15022()
		public virtual void testParseoIso15022()
		{
			parseMessage("MT320.txt");
			parseMessage("SWIFTMT300_0000039099_0002.txt");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFormateoIso15022()
		public virtual void testFormateoIso15022()
		{
			parseMessage("MT320.xml");
			parseMessage("SWIFTMT300_0000039099_0002.xml");
		}

		/*
		 * https://sourceforge.net/p/wife/bugs/80/
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse101()
		public virtual void testParse101()
		{
			SwiftMessage msg = parseMessage("mt101.fin");
			assertMT101(msg);
		}

		/*
		 * https://sourceforge.net/p/wife/bugs/80/
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse101Stream() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse101Stream()
		{
			MT101 mt = MT101.parse(this.GetType().getResourceAsStream("/mt101.fin"));
			SwiftMessage msg = mt.SwiftMessage;
			assertMT101(msg);
		}

		/*
		 * https://sourceforge.net/p/wife/bugs/80/
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Ignore("requires absolute path for file") @Test public void testParse101File() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse101File()
		{
			MT101 mt = MT101.parse(new File("/home/foo/src/prowide-core/src/test/resourcesmt101.fin"));
			SwiftMessage msg = mt.SwiftMessage;
			assertMT101(msg);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void assertMT101(final com.prowidesoftware.swift.model.SwiftMessage msg)
		private void assertMT101(SwiftMessage msg)
		{
			assertNotNull(msg);
			assertNotNull(msg.Block1);
			assertNotNull(msg.Block2);
			assertNotNull(msg.Block4);
			assertNotNull(msg.Block5);
			assertEquals("TESTAR00AXXX", msg.Block1.LogicalTerminal);
			assertEquals("101", msg.Block2.MessageType);
			assertEquals("DG942_171206-004", msg.Block4.getFieldByName("20").Value);
		}

		protected internal virtual void formatMessage(string messagePath)
		{
			try
			{
				ByteArrayOutputStream baos = new ByteArrayOutputStream();
				InputStream @is = typeof(ParserTest).getResourceAsStream(messagePath);
				int c;
				while ((c = @is.read()) != -1)
				{
					baos.write(c);
				}
				baos.close();
				string xml = StringHelperClass.NewString(baos.toByteArray());
				assertNotNull(xml);
			}
			catch (Exception t)
			{
				Console.WriteLine(t.ToString());
				Console.Write(t.StackTrace);
				fail("error while processing: " + messagePath);
			}
		}

		protected internal virtual SwiftMessage parseMessage(string messagePath)
		{
			InputStream input = typeof(ParserTest).getResourceAsStream("/" + messagePath);
			SwiftParser p = new SwiftParser(input);
			try
			{
				return p.message();
			}
			catch (Exception t)
			{
				Console.WriteLine(t.ToString());
				Console.Write(t.StackTrace);
				fail("error while processing: " + messagePath);
			}
			return null;
		}

	}

}