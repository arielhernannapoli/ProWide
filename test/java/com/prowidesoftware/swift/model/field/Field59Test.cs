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
namespace com.prowidesoftware.swift.model.field
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;

	/// <summary>
	/// Test for Field59 and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field59Test : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("59", "/acc\nbbb\nccc\nddd\neee");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue()
		public virtual void testGetValue()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field59 f = new Field59("/acc");
			Field59 f = new Field59("/acc");
			assertEquals("/acc", f.Value);
			f.Component2 = "c2";
			assertEquals("/acc\r\nc2", f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue2()
		public virtual void testGetValue2()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field59 f = new Field59("/acc\nbbb\nccc\nddd\neee");
			Field59 f = new Field59("/acc\nbbb\nccc\nddd\neee");
			assertEquals("acc", f.Component1);
			assertEquals("bbb", f.Component2);
			assertEquals("ccc", f.Component3);
			assertEquals("ddd", f.Component4);
			assertEquals("eee", f.Component5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue3()
		public virtual void testGetValue3()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field59 f = new Field59("bbb\nccc\nddd\neee");
			Field59 f = new Field59("bbb\nccc\nddd\neee");
			assertNull(f.Component1);
			assertEquals("bbb", f.Component2);
			assertEquals("ccc", f.Component3);
			assertEquals("ddd", f.Component4);
			assertEquals("eee", f.Component5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetWithLabelsRepetitions()
		public virtual void testGetWithLabelsRepetitions()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field59 f = new Field59("/1234\nccc\nddd\neee\nfff");
			Field59 f = new Field59("/1234\nccc\nddd\neee\nfff");
			assertEquals("1234", f.Account);
			assertEquals("ccc", f.NameAndAddressLine1);
			assertEquals("ddd", f.NameAndAddressLine2);
			assertEquals("eee", f.NameAndAddressLine3);
			assertEquals("fff", f.NameAndAddressLine4);
			assertEquals("ccc" + FINWriterVisitor.SWIFT_EOL + "ddd" + FINWriterVisitor.SWIFT_EOL + "eee" + FINWriterVisitor.SWIFT_EOL + "fff", f.NameAndAddress);
			f.Component3 = null;
			assertEquals("ccc" + FINWriterVisitor.SWIFT_EOL + "eee" + FINWriterVisitor.SWIFT_EOL + "fff", f.NameAndAddress);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSetWithLabelsRepetitions()
		public virtual void testSetWithLabelsRepetitions()
		{
			Field59 f = new Field59();
			f.Account = "1234";
			assertEquals("1234", f.Component1);

			f.NameAndAddressLine1 = "aaaa";
			assertEquals("aaaa", f.Component2);

			f.NameAndAddressLine2 = "bbbb";
			assertEquals("bbbb", f.Component3);

			f.NameAndAddressLine3 = "cccc";
			assertEquals("cccc", f.Component4);

			f.NameAndAddressLine4 = "dddd";
			assertEquals("dddd", f.Component5);

			f = new Field59();
			f.NameAndAddress = "aaaa\nbbbb\ncccc";
			assertEquals("aaaa" + FINWriterVisitor.SWIFT_EOL + "bbbb" + FINWriterVisitor.SWIFT_EOL + "cccc", f.NameAndAddress);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMultilineApiGetLine1Empty() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testMultilineApiGetLine1Empty()
		{
			assertNull((new Field59("")).getLine(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMultilineApiGetLine1Null() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testMultilineApiGetLine1Null()
		{
			assertNull((new Field59((string)null)).getLine(1));
		}

	}
}