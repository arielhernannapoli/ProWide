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
namespace com.prowidesoftware.swift.model
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Test = org.junit.Test;

	/// <summary>
	/// Tag tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class TagTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1()
		public virtual void test1()
		{
			Tag t = new Tag("");
			assertNull(t.Name);
			assertNull(t.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test2()
		public virtual void test2()
		{
			Tag t = new Tag(":foobar");
			assertEquals("foobar", t.Value);
			assertNull(t.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test3()
		public virtual void test3()
		{
			Tag t = new Tag("foobar:");
			assertEquals("foobar", t.Name);
			assertNull(t.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test4()
		public virtual void test4()
		{
			Tag t = new Tag("name:value");
			assertEquals("name", t.Name);
			assertEquals("value", t.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test5()
		public virtual void test5()
		{
			Tag t = new Tag("value");
			assertEquals("value", t.Value);
			assertNull(t.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test6()
		public virtual void test6()
		{
			Tag t = new Tag("a:b");
			assertEquals("a", t.Name);
			assertEquals("b", t.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test7()
		public virtual void test7()
		{
			Tag t = new Tag("a:");
			assertEquals("a", t.Name);
			assertEquals(null, t.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test8()
		public virtual void test8()
		{
			Tag t = new Tag(":b");
			assertEquals(null, t.Name);
			assertEquals("b", t.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_getLetterOption()
		public virtual void test_getLetterOption()
		{
			Tag t = new Tag("58A:value");
			assertEquals("58A", t.Name);
			assertEquals("value", t.Value);
			assertEquals("A", t.LetterOption);
			t = new Tag("58:value");
			assertEquals("58", t.Name);
			assertEquals("value", t.Value);
			assertNull(t.LetterOption);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_isNumber()
		public virtual void test_isNumber()
		{
			Tag t = new Tag("58A:value");
			assertEquals("58A", t.Name);
			assertEquals("value", t.Value);
			assertTrue(t.isNumber(58));
			assertFalse(t.isNumber(5));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetNumber()
		public virtual void testGetNumber()
		{
			Tag t = new Tag("20:value");
			assertEquals(Convert.ToInt32(20), t.Number);

			t = new Tag("32A:value");
			assertEquals(Convert.ToInt32(32), t.Number);

			t = new Tag("5:value");
			assertEquals(Convert.ToInt32(5), t.Number);

			t = new Tag("CHK:value");
			assertNull(t.Number);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testEquals()
		public virtual void testEquals()
		{
			assertEquals(new Tag(), new Tag());
			assertEquals(new Tag("a"), new Tag("a"));
			assertEquals(new Tag("20:a"), new Tag("20:a"));
			assertEquals(new Tag("50K:FOO1\nFOO2"), new Tag("50K:FOO1\nFOO2"));
			assertEquals(new Tag("50K:FOO1\r\nFOO2"), new Tag("50K:FOO1\r\nFOO2"));
			/*
			 * not equals
			 */
			assertNotEquals(new Tag("50K:FOO1\nFOO2"), new Tag("50K:FOO1\nFOO3"));
			assertNotEquals(new Tag("50K:FOO1\r\nFOO2"), new Tag("50K:FOO1\nFOO2"));
			assertNotEquals(new Tag("50K:FOO1\nFOO2"), new Tag("50K:FOO1\r\nFOO2"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testEqualsIgnoreCR()
		public virtual void testEqualsIgnoreCR()
		{
			assertTrue((new Tag()).equalsIgnoreCR(new Tag()));
			assertTrue((new Tag("a")).equalsIgnoreCR(new Tag("a")));
			assertTrue((new Tag("20:a")).equalsIgnoreCR(new Tag("20:a")));
			assertTrue((new Tag("50K:FOO1\nFOO2")).equalsIgnoreCR(new Tag("50K:FOO1\nFOO2")));
			assertTrue((new Tag("50K:FOO1\r\nFOO2")).equalsIgnoreCR(new Tag("50K:FOO1\r\nFOO2")));
			assertTrue((new Tag("50K:FOO1\r\nFOO2")).equalsIgnoreCR(new Tag("50K:FOO1\nFOO2")));
			assertTrue((new Tag("50K:FOO1\nFOO2")).equalsIgnoreCR(new Tag("50K:FOO1\r\nFOO2")));
			/*
			 * not equals
			 */
			assertFalse((new Tag("50K:FOO1\nFOO2")).equalsIgnoreCR(new Tag("50K:FOO1\nFOO3")));
		}

	}
}