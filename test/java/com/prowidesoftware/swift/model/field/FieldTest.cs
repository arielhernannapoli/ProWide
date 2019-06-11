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
namespace com.prowidesoftware.swift.model.field
{

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// Test for base class Field.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class FieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSetComponent()
		public virtual void testSetComponent()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field f = new Field70E();
			Field f = new Field70E();
			f.setComponent(2, "world");
			assertNull(f.getComponent(1));
			assertEquals("world", f.getComponent(2));
			assertNull(f.getComponent(3));
			assertNull(f.getComponent(4));
			assertNull(f.getComponent(5));

			f.setComponent(2, "hello");
			assertNull(f.getComponent(1));
			assertEquals("hello", f.getComponent(2));
			assertNull(f.getComponent(3));
			assertNull(f.getComponent(4));
			assertNull(f.getComponent(5));

			f.setComponent(1, "cruel");
			assertEquals("cruel", f.getComponent(1));
			assertEquals("hello", f.getComponent(2));
			assertNull(f.getComponent(3));
			assertNull(f.getComponent(4));
			assertNull(f.getComponent(5));

			f.setComponent(2, null);
			assertEquals("cruel", f.getComponent(1));
			assertEquals(null, f.getComponent(2));
			assertNull(f.getComponent(3));
			assertNull(f.getComponent(4));
			assertNull(f.getComponent(5));

			f.setComponent(5, "bye");
			assertEquals("cruel", f.getComponent(1));
			assertNull(f.getComponent(2));
			assertNull(f.getComponent(3));
			assertNull(f.getComponent(4));
			assertEquals("bye", f.getComponent(5));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testJoinComponents_01()
		public virtual void testJoinComponents_01()
		{
			Field f = new Field70E();
			f.setComponent(1, "1");
			f.setComponent(2, "2");
			f.setComponent(3, "3");
			f.setComponent(4, "4");
			f.setComponent(5, "");

			assertEquals("1234", f.joinComponents(0, false));
			assertEquals("123", f.joinComponents(0, true));
			assertEquals("234", f.joinComponents(1, false));
			assertEquals("23", f.joinComponents(1, true));
			assertEquals("34", f.joinComponents(2, false));
			assertEquals("3", f.joinComponents(2, true));
			assertEquals("4", f.joinComponents(3, false));
			assertEquals("", f.joinComponents(3, true));
			assertEquals("", f.joinComponents(4, false));
			assertEquals("", f.joinComponents(4, true));
			assertEquals("", f.joinComponents(5, false));
			assertEquals("", f.joinComponents(5, true));

			f = new Field70E();
			f.setComponent(1, "1");
			f.setComponent(2, "2");
			f.setComponent(3, "3");
			f.setComponent(4, "4");
			f.setComponent(5, null);

			assertEquals("1234", f.joinComponents(0, false));
			assertEquals("123", f.joinComponents(0, true));
			assertEquals("234", f.joinComponents(1, false));
			assertEquals("23", f.joinComponents(1, true));
			assertEquals("34", f.joinComponents(2, false));
			assertEquals("3", f.joinComponents(2, true));
			assertEquals("4", f.joinComponents(3, false));
			assertEquals("", f.joinComponents(3, true));
			assertEquals("", f.joinComponents(4, false));
			assertEquals("", f.joinComponents(4, true));
			assertEquals("", f.joinComponents(5, false));
			assertEquals("", f.joinComponents(5, true));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testJoinComponents_02()
		public virtual void testJoinComponents_02()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field32A f = new Field32A();
			Field32A f = new Field32A();
			f.setAmount("123,");
			assertEquals("123,", f.joinComponents(0));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFindComponentStartingWith()
		public virtual void testFindComponentStartingWith()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field f = new Field70E();
			Field f = new Field70E();
			f.setComponent(1, "1234");
			f.setComponent(2, "2345");
			f.setComponent(3, "hello world");
			f.setComponent(4, "4567");
			f.setComponent(5, "8901");

			assertEquals("hello world", f.findComponentStartingWith("hello"));
			assertNull(f.findComponentStartingWith("foo"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValueByCodeword()
		public virtual void testGetValueByCodeword()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field f = new Field70E();
			Field f = new Field70E();
			f.setComponent(1, "/ACC/BLABLABLA");
			f.setComponent(2, "//BLABLABLA");
			f.setComponent(3, "/INS/CITIUS33MIA");
			f.setComponent(4, "//BLABLABLA");

			assertEquals("CITIUS33MIA", f.getValueByCodeword("INS"));
			assertNull(f.getValueByCodeword("foo"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetName()
		public virtual void testGetName()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field32A f = new Field32A("");
			Field32A f = new Field32A("");
			assertEquals("32A", f.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testLabel1()
		public virtual void testLabel1()
		{
			assertEquals("Transaction Reference Number", Field.getLabel("20", "199", null, new Locale("en")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testLabel2()
		public virtual void testLabel2()
		{
			assertEquals("Currency", Field.getLabel("11A", "500", "B1", new Locale("en")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValueByCodewordWorkaround()
		public virtual void testGetValueByCodewordWorkaround()
		{
		//TODO add API for partyfields structure like field 83J
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field83J f = new Field83J("/ACCT/006-6005XXXXXX\n/NAME/JF ASIAN TOTAL RETURN BOND FUND");
			Field83J f = new Field83J("/ACCT/006-6005XXXXXX\n/NAME/JF ASIAN TOTAL RETURN BOND FUND");
			assertEquals("006-6005XXXXXX", StringUtils.substringBetween(f.Component1, "/ACCT/", "\n"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTicket31()
		public virtual void testTicket31()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field32A f = new Field32A();
			Field32A f = new Field32A();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.math.BigDecimal set = new java.math.BigDecimal(1000);
			decimal set = new decimal(1000);
			f.setAmount(set);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.math.BigDecimal got = f.getAmountBigDecimal();
			decimal got = f.AmountBigDecimal;
			assertEquals(set, got);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testLetterOption() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testLetterOption()
		{
			assertEquals(Convert.ToChar('A'), (new Field59A()).letterOption());
			assertEquals(null, (new Field59()).letterOption());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsLetterOption() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testIsLetterOption()
		{
			assertTrue((new Field59A()).isLetterOption('A'));
			assertTrue((new Field56B()).isLetterOption('B'));
			assertFalse((new Field59()).isLetterOption('B'));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNumericConversion()
		public virtual void testNumericConversion()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field32A f = new Field32A("130901USD10,1");
			Field32A f = new Field32A("130901USD10,1");
			assertEquals(new decimal("10.1"), f.AmountBigDecimal);
			assertEquals(new decimal("10.1"), f.Component3AsNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReflection_01()
		public virtual void testReflection_01()
		{
			Field f = Field.getField(new Tag("20C", "foo"));
			assertNotNull(f);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReflection_02()
		public virtual void testReflection_02()
		{
			Field f = Field.getField("20C", "foo");
			assertNotNull(f);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReflection_03()
		public virtual void testReflection_03()
		{
			Field f = Field.getField("20C", null);
			assertNotNull(f);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testValidName()
		public virtual void testValidName()
		{
			/*
			 * ok
			 */
			assertTrue(Field.validName("20"));
			assertTrue(Field.validName("20C"));
			assertTrue(Field.validName("22a"));
			assertTrue(Field.validName("108"));
			/*
			 * not ok
			 */
			assertFalse(Field.validName("2022"));
			assertFalse(Field.validName("20b"));
			assertFalse(Field.validName("20CD"));
			assertFalse(Field.validName("a20C"));
			assertFalse(Field.validName("2"));
			assertFalse(Field.validName("C"));
			assertFalse(Field.validName(""));
			assertFalse(Field.validName(null));
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testLines_01()
		public virtual void testLines_01()
		{
			Field95Q f = new Field95Q(":INVE//JOE DOE");
			assertEquals(":INVE//JOE DOE", f.getLine(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testLines_02()
		public virtual void testLines_02()
		{
			Field95Q f = new Field95Q(":INVE//JOE DOE");
			assertEquals("JOE DOE", f.getLine(1, Field95Q.NAME_AND_ADDRESS));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testLines_03()
		public virtual void testLines_03()
		{
			Field50K f = new Field50K("/12345");
			assertEquals(1, f.Lines.Count);
			assertEquals("/12345", f.getLine(1));
			assertNull(f.getLine(2));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testLines_04()
		public virtual void testLines_04()
		{
			Field50K f = new Field50K("ABC");
			assertEquals(1, f.Lines.Count);
			assertNull(f.getLine(1));
			assertEquals("ABC", f.getLine(2));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testLines_05()
		public virtual void testLines_05()
		{
			Field50K f = new Field50K("ABC");
			assertEquals(1, f.Lines.Count);
			assertNull(f.getLine(1));
			assertEquals("ABC", f.getLine(2));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorFromTag_01()
		public virtual void testConstructorFromTag_01()
		{
			Tag t = new Tag("32A", "121212USD1234,5");
			Field32A f = new Field32A(t);
			assertEquals("121212", f.getComponent1());
			assertEquals("USD", f.getComponent2());
			assertEquals("1234,5", f.getComponent3());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorFromTag_02()
		public virtual void testConstructorFromTag_02()
		{
			Tag t = new Tag("20", "121212USD1234,5");
			try
			{
				new Field32A(t);
				fail("exception expected");
			}
			catch (System.ArgumentException)
			{
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsValues()
		public virtual void testIsValues()
		{
			Field95Q f = new Field95Q(":INVE//JOE DOE");
			assertTrue(f.@is("FOO", "INVE", "ABC"));
			assertFalse(f.@is("FOO", "BAR", "ABC"));
		}

	}
}