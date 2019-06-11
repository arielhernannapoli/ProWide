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
	import static org.junit.Assert.assertNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Test = org.junit.Test;

	/// <summary>
	/// MT900 tests
	/// 
	/// @since 6.3
	/// </summary>
	public class MT900Test : BaseMessageTestcase
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testImproperBlock4Ending()
		public virtual void testImproperBlock4Ending()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I900FOOBARXXXXXXN}{4:\n" + ":20:628735BKRU3X\n" + ":79:TO.   FOOBANK NA (HONG KONG)\n" + "ATTN. FOO - FOO OPERATIONS\n" + "FROM.\n" + "RE.   FOO  SUB A/C 123456\n" + "A/C: 961XXX\n" + ".\n" + "WE CONFIRM TO INCREASE THE FOLLOWING DEPOSIT FROM\n" + ".\n" + "INSTRUCTIONS:\n" + ".\n" + "REGARDS,\n" + "}" + "{5:{CHK:12C48A7C53B2}}{S:{REF:I20070404.763727356.out/1/1}}";

			parseMessage(messageToParse);
			assertEquals("900", this.o.Type);

			assertNull(b5);
			string expected = "out/1/1}}";
			string last = b4.getTagByName("79").Value;
			last = StringHelperClass.SubstringSpecial(last, last.Length - expected.Length, last.Length);
			assertEquals(expected, last);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingEOBandB5()
		public virtual void testMissingEOBandB5()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I900FOOBARXXXXXXN}{4:\n" + ":20:628735BKRU3X\n" + ":79:TO FOO\n" + "REGARDS,\n" + "{" + "{5:{CHK:12C48A7C53B2}}{S:{REF:I20070404.763727356.out/1/1}}";

				parseMessage(messageToParse);
				assertEquals("900", this.o.Type);
				assertNull(b5);
				string expected = "out/1/1}}";
				string last = b4.getTagByName("79").Value;
				last = StringHelperClass.SubstringSpecial(last, last.Length - expected.Length, last.Length);
				assertEquals(expected, last);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingEOBAndEOF()
		public virtual void testMissingEOBAndEOF()
		{
				messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I900FOOBARXXXXXXN}{4:\n" + ":20:628735BKRU3X\n" + ":79:TO FOO\n" + "INSTRUCTIONS:\n" + "{";

				parseMessage(messageToParse);
				assertEquals("900", this.o.Type);

				string last = b4.getTagByName("79").Value;
				assertTrue(last.EndsWith("\n{", StringComparison.Ordinal));
		}

	}
}