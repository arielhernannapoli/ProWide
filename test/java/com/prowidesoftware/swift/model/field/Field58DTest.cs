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
	/// Test for Field58D and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field58DTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("58D", "/00010001380002000114");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test58D()
		public virtual void test58D()
		{
			Field58D f = new Field58D((string)null);
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("/D");
			assertEquals("D", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("/D/");
			assertEquals("D", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("/D/1234");
			assertEquals("D", f.Component1);
			assertEquals("1234", f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("/D/1234/56");
			assertEquals("D", f.Component1);
			assertEquals("1234/56", f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("abcd");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertEquals("abcd", f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("/D/1234\nabcd");
			assertEquals("D", f.Component1);
			assertEquals("1234", f.Component2);
			assertEquals("abcd", f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("/D\nabcd");
			assertEquals("D", f.Component1);
			assertNull(f.Component2);
			assertEquals("abcd", f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("/1234\nabcd");
			assertNull(f.Component1);
			assertEquals("1234", f.Component2);
			assertEquals("abcd", f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("/00010001380002000114");
			assertEquals("00010001380002000114", f.Component2);
			assertNull(f.Component1);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);

			f = new Field58D("/D/1234\nabcd\nefgh\nijkl\nmnop");
			assertEquals("D", f.Component1);
			assertEquals("1234", f.Component2);
			assertEquals("abcd", f.Component3);
			assertEquals("efgh", f.Component4);
			assertEquals("ijkl", f.Component5);
			assertEquals("mnop", f.Component6);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValueDisplay()
		public virtual void testGetValueDisplay()
		{
			Field58D f = new Field58D("/00010001380002000114");
			assertEquals("00010001380002000114", f.Component2);
			assertNull(f.Component1);
			assertNull(f.Component3);
		}

	}
}