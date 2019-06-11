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
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;

	/// <summary>
	/// Test for Field50K and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field50KTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("50K", "/acc", "/acc\nbbb\nccc\nddd\neee");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSerialization2()
		public virtual void testSerialization2()
		{
			Field50K f = new Field50K("/345345234534\nSDFGSDFGSDFGSD");
			assertNotNull(f.Value);
			assertEquals("/345345234534" + FINWriterVisitor.SWIFT_EOL + "SDFGSDFGSDFGSD", f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue()
		public virtual void testGetValue()
		{
			Field50K f = new Field50K("/acc");
			assertEquals("/acc", f.Value);
			f.Component2 = "c2";
			assertEquals("/acc\r\nc2", f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue2()
		public virtual void testGetValue2()
		{
			Field50K f = new Field50K("/acc\nbbb\nccc\nddd\neee");
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
			Field50K f = new Field50K("bbb\nccc\nddd\neee");
			assertNull(f.Component1);
			assertEquals("bbb", f.Component2);
			assertEquals("ccc", f.Component3);
			assertEquals("ddd", f.Component4);
			assertEquals("eee", f.Component5);
		}

	}
}