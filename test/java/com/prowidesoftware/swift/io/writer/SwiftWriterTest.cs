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
namespace com.prowidesoftware.swift.io.writer
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;


	using Test = org.junit.Test;

	using SwiftParser = com.prowidesoftware.swift.io.parser.SwiftParser;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using Tag = com.prowidesoftware.swift.model.Tag;

	/// <summary>
	/// Swift writer tests
	/// 
	/// @since 4.0
	/// </summary>
	public class SwiftWriterTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testEmpty()
		public virtual void testEmpty()
		{
			SwiftMessage m = new SwiftMessage(true);
			m.Block1.clean();
			m.Block2.clean();
			StringWriter buf = new StringWriter();
			SwiftWriter.writeMessage(m, buf);
			assertEquals("{1:}{2:}{3:}{4:\r\n-}{5:}", getResult("testEmpty", buf));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimple()
		public virtual void testSimple()
		{
			SwiftMessage m = new SwiftMessage(true);

			m.Block1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			m.Block2.Value = com.prowidesoftware.swift.Constants_Fields.B2_INPUT;
			m.Block3.append(new Tag(":helloworld"));
			m.Block4.append(new Tag("k:val"));
			m.Block5.append(new Tag("foo:dacatadat"));

			StringWriter buf = new StringWriter();
			SwiftWriter.writeMessage(m, buf);
			assertEquals("{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{2:" + com.prowidesoftware.swift.Constants_Fields.B2_INPUT + "}{3:{helloworld}}{4:\r\n" + ":k:val\r\n" + "-}{5:{foo:dacatadat}}", getResult("testSimple", buf));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteParsedMessage() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testWriteParsedMessage()
		{
			string m1 = "{1:F01GENODEFFAXXX4321100001}{2:O1030711060804MARKDEFFAXXX12342000010608040711N}{4:\n" + ":20:TEST-IBAN001\n" + ":13C:/SNDTIME/0701+0200\n" + ":13C:/RNCTIME/0701+0200\n" + ":23B:CRED\n" + ":32A:060804EUR18001,01\n" + ":33B:EUR18001,01\n" + ":50K:KUNDE WO FOO FOO\n" + "SYMMACH. FOO OREOKASTRO-DIAVATA\n" + "GR-57008 FOO\n" + "GREECE\n" + ":52A://TAGRPRNKGRAAXXX052/S/20115\n" + "PRNKGRAAXXX\n" + ":57A:GENODE51LOS\n" + ":59:/DE66593922000000045500\n" + "FOO DER VOLKS-RAIFFEISENBANK\n" + "RAIFFEISENPLATZ\n" + "D-66787 WADGASSEN-HOSTENBACH\n" + "GERMANY\n" + ":70:TEST IBAN 01P DE\n" + "IBAN FOO\n" + ":71A:SHA\n" + "-}{5:{MAC:11111111}{CHK:222222222222}}\n" + "";
			string result = parseAndWrite(m1);
			BufferedReader expected = new BufferedReader(new StringReader(m1));
			BufferedReader obtained = new BufferedReader(new StringReader(result));

			string l1, l2;

			l1 = expected.readLine();
			l2 = obtained.readLine();
			while (l1 != null && l2 != null)
			{
				// There is a known issue in block 5 writing
				if (l1.IndexOf("{5:", StringComparison.Ordinal) < 0)
				{
					assertEquals(l1, l2);
				}
				l1 = expected.readLine();
				l2 = obtained.readLine();
			}
		}

		/// <summary>
		/// Parse the given message and write it using FIN Writer
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private String parseAndWrite(String m1) throws java.io.IOException
		private string parseAndWrite(string m1)
		{
			SwiftParser p = new SwiftParser(new StringReader(m1));
			SwiftMessage msg = p.message();
			StringWriter writer = new StringWriter();
			SwiftWriter.writeMessage(msg, writer);
			string result = writer.Buffer.ToString();
			return result;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private String getResult(java.io.StringWriter buf)
		private string getResult(StringWriter buf)
		{
			return (getResult("", buf));
		}

		private string getResult(string testName, StringWriter buf)
		{
			return buf.ToString();
		}

	}
}