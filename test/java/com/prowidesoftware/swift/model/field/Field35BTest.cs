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

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;

	/// <summary>
	/// Test for Field35B and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field35BTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("35B", "ISIN HELLO\nAAAA\nBBBB\nCCCC", "AAAA\nBBBB\nCCCC\nDDDD");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse()
		public virtual void testParse()
		{
			Field35B f = new Field35B();

			//remaining lines are ignored by parser
			f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD\nEEEE\nFFFF\nGGGG");
			assertEquals("ISIN", f.Component1);
			assertEquals("HELLO", f.Component2);
			assertEquals("AAAA", f.Component3);
			assertEquals("BBBB", f.Component4);
			assertEquals("CCCC", f.Component5);
			assertEquals("DDDD", f.Component6);

			f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC");
			assertEquals("ISIN", f.Component1);
			assertEquals("HELLO", f.Component2);
			assertEquals("AAAA", f.Component3);
			assertEquals("BBBB", f.Component4);
			assertEquals("CCCC", f.Component5);
			assertNull(f.Component6);

			f = new Field35B("ISIN HELLO");
			assertEquals("ISIN", f.Component1);
			assertEquals("HELLO", f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field35B("ISINHELLO");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertEquals("ISINHELLO", f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field35B(" ISINHELLO");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertEquals(" ISINHELLO", f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue()
		public virtual void testGetValue()
		{
			Field35B f = new Field35B();
			string v = "ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD";
			f = new Field35B(v);
			assertEquals(StringUtils.replace(v, "\n", FINWriterVisitor.SWIFT_EOL), f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue_2()
		public virtual void testGetValue_2()
		{
			Field35B f = new Field35B();
			string v = "ISIN 123456789012\nAAAA\nBBBB\nCCCC\nDDDD";
			f = new Field35B(v);
			assertEquals(StringUtils.replace(v, "\n", FINWriterVisitor.SWIFT_EOL), f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue_3()
		public virtual void testGetValue_3()
		{
			Field35B f = new Field35B();
			string v = "AAAA\nBBBB\nCCCC\nDDDD";
			f = new Field35B(v);
			assertEquals(StringUtils.replace(v, "\n", FINWriterVisitor.SWIFT_EOL), f.Value);
		}

	}
}