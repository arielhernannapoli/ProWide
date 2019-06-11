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

	/// <summary>
	/// Test for Field26C and similar fields.
	/// 
	/// @since 6.4
	/// </summary>
	public class Field26CTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("26C", "A/B/CCCCCDDDDEEEE");
		}

		/// <summary>
		/// [S]/S/5!a4!aS
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField26C()
		public virtual void testField26C()
		{
			Field26C f = new Field26C((string)null);
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field26C("");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field26C("A");
			assertEquals("A", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field26C("A/");
			assertEquals("A", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field26C("A/B");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field26C("A/B/C");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertEquals("C", f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field26C("A/B/CCCCC");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertEquals("CCCCC", f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field26C("A/B/CCCCCD");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertEquals("CCCCC", f.Component3);
			assertEquals("D", f.Component4);
			assertNull(f.Component5);

			f = new Field26C("A/B/CCCCCDDDD");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertEquals("CCCCC", f.Component3);
			assertEquals("DDDD", f.Component4);
			assertNull(f.Component5);

			f = new Field26C("A/B/CCCCCDDDDEEEE");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertEquals("CCCCC", f.Component3);
			assertEquals("DDDD", f.Component4);
			assertEquals("EEEE", f.Component5);
		}

	}
}