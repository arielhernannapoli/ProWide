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
namespace com.prowidesoftware.swift.model
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Before = org.junit.Before;
	using Test = org.junit.Test;

	using ConversionService = com.prowidesoftware.swift.io.ConversionService;
	using SwiftParser = com.prowidesoftware.swift.io.parser.SwiftParser;

	/// <summary>
	/// Unparsed text lists tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class UnparsedTextListTest
	{

		private const string someText = "[some text]";
		private const string someMsg = "{1:test}";
		private const string finMsg = "{1:F01BANKBEBBAXXX2222123456}";

		private UnparsedTextList t = null;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			t = new UnparsedTextList();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_toString()
		public virtual void test_toString()
		{
			assertEquals(t.AsFINString, "");
			t.addText(someText);
			assertEquals(t.AsFINString, someText);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_staticIsMessage()
		public virtual void test_staticIsMessage()
		{
			assertFalse(UnparsedTextList.isMessage(someText));
			assertTrue(UnparsedTextList.isMessage(someMsg));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_addText()
		public virtual void test_addText()
		{
			t.addText(someText);
			assertEquals(t.size(), new int?(1));
			assertEquals(t.getText(0), someText);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_isMessage()
		public virtual void test_isMessage()
		{
			t.addText(someText);
			t.addText(someMsg);
			assertFalse(t.isMessage(0));
			assertTrue(t.isMessage(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_size()
		public virtual void test_size()
		{
			assertEquals(t.size(), new int?(0));
			t.addText(someText);
			assertEquals(t.size(), new int?(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_getTextOK()
		public virtual void test_getTextOK()
		{
			t.addText(someText);
			t.addText(someMsg);
			assertEquals(t.getText(0), someText);
			assertEquals(t.getText(1), someMsg);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IndexOutOfBoundsException.class) public void test_getTextBAD()
		public virtual void test_getTextBAD()
		{
			assertNull(t.getText(-1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_getTextAsMessageOK()
		public virtual void test_getTextAsMessageOK()
		{
			t.addText(finMsg);
			assertNotNull(t.getTextAsMessage(0));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IndexOutOfBoundsException.class) public void test_getTextAsMessageBAD()
		public virtual void test_getTextAsMessageBAD()
		{
			assertNull(t.getTextAsMessage(-1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_addTextMessage()
		public virtual void test_addTextMessage()
		{
			// create a message and get it's string representation
			ConversionService cService = new ConversionService();
			SwiftMessage msg = cService.getMessageFromFIN(finMsg);
			string msgString = cService.getFIN(msg);

			// add the message
			t.addText(msg);

			// check things out
			assertEquals(t.size(), new int?(1));
			assertEquals(t.getText(0), msgString);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_removeIndexOK()
		public virtual void test_removeIndexOK()
		{
			t.addText(someText);
			t.addText(someMsg);
			t.removeText(0);
			assertEquals(t.getText(0), someMsg);
			assertEquals(t.size(), new int?(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IndexOutOfBoundsException.class) public void test_removeIndexBAD()
		public virtual void test_removeIndexBAD()
		{
			t.removeText(1);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_removeText()
		public virtual void test_removeText()
		{
			t.addText(someText);
			t.addText(someMsg);
			t.removeText(someText);
			assertEquals(t.getText(0), someMsg);
			assertEquals(t.size(), new int?(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_BlockTexts()
		public virtual void test_BlockTexts()
		{
			t.addText(someText);
			t.addText(someMsg);
			SwiftBlock3 b3 = new SwiftBlock3();
			b3.UnparsedTexts = t;

			assertEquals(2, (int)b3.UnparsedTextsSize);
			assertNotNull(b3.UnparsedTexts.getText(0));
			assertEquals(someText, b3.UnparsedTexts.getText(0));
			assertNotNull(b3.UnparsedTexts.getText(1));
			assertEquals(someMsg, b3.UnparsedTexts.getText(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_bug2822350() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test_bug2822350()
		{
			string m = "{1:F01DEUTDEFFZP1V1284289805}{2:O9402239090403DEUTDEFFZXXX12842898050904032239N}{3:{108: }}{4:\r\n" + ":20:1234567890" + ":25:60001218710100\r\n" + ":28C:00029/001\r\n" + ":60F:D090331EUR61,02\r\n" + ":61:090402C1951,77NSECNONREF\r\n" + ":86: /REMI/WERTPAPIERE WERTPAPIERKENN-NR. FOO WERTPAPIER-VERKAUF\r\n" + "FIL/DEPOT-NR: 600/012187100 FOO STRATEGIEPTF OFFENSIV UI INH.ANT. A DO\r\n" + "05050643103 310309020409\r\n" + ":62F:C090403EUR1890,75\r\n" + ":64:C090403EUR1890,75\r\n" + "-}{5:{CHK:000000000000}}";

			StringBuilder sb = new StringBuilder();
			for (int i = 0;i < 3;i++)
			{
				sb.Append(m);
			}

			SwiftParser parser = new SwiftParser();
			SwiftMessage msg = parser.parse(sb.ToString());

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") SwiftMessage m2 = parser.parse(msg.getUnparsedTexts().getText(0));
			SwiftMessage m2 = parser.parse(msg.UnparsedTexts.getText(0));

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") SwiftMessage m3 = parser.parse(msg.getUnparsedTexts().getText(1));
			SwiftMessage m3 = parser.parse(msg.UnparsedTexts.getText(1));
		}

	}

}