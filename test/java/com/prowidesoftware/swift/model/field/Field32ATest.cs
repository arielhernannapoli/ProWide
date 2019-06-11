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

	/// <summary>
	/// Test for Field32A and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field32ATest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("32A", "010203USD123", "081001VEF30625,00");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse32A() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse32A()
		{
			Field32A f = new Field32A("010203USD123");
			assertNotNull("Parse of field failed", f);
			assertEquals(2001, f.Component1AsCalendar.Year);
			assertEquals(1, f.Component1AsCalendar.Month);
			assertEquals(3, f.Component1AsCalendar.Day);
			assertEquals("USD", f.getComponent2());
			assertEquals(new decimal(123), new decimal((double)f.Component3AsNumber));
			//081001VEF30625,00
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse32A_2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse32A_2()
		{
			Field32A f = new Field32A("010203USD123dss");
			assertNotNull("Parse of field failed", f);
			assertNotNull("Parse of field date failed", f.Component1AsCalendar);
			assertEquals(2001, f.Component1AsCalendar.Year);
			assertEquals(2, f.Component1AsCalendar.Month);
			assertEquals(3, f.Component1AsCalendar.Day);
			assertEquals("USD", f.getComponent2());
			assertEquals("123dss", f.getComponent3());
			assertEquals(new decimal(123), new decimal((double)f.Component3AsNumber));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse32A_3() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse32A_3()
		{
			Field32A f = new Field32A("999999USD123");
			assertNotNull("Parse of field failed", f);
			assertNull(f.Component1AsCalendar);
			assertEquals("USD", f.getComponent2());
			assertEquals(new decimal(123), new decimal((double)f.Component3AsNumber));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse32A_4() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse32A_4()
		{
			Field32A f = new Field32A("081001VEF30625,");
			assertNotNull("Parse of field failed", f);
			assertNotNull(f.Component1AsCalendar);
			assertEquals("VEF", f.getComponent2());
			assertEquals(new decimal(30625.00), new decimal((double)f.Component3AsNumber));

			f = new Field32A("081001VEF30625,00");
			assertNotNull("Parse of field failed", f);
			assertNotNull(f.Component1AsCalendar);
			assertEquals("VEF", f.getComponent2());
			assertEquals(new decimal(30625.00), new decimal((double)f.Component3AsNumber));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse32A_Amount() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse32A_Amount()
		{
			Field32A f = new Field32A("081001VEF30625,00");
			assertNotNull("Parse of field failed", f);
			assertEquals("VEF", f.getComponent2());
			assertEquals(new decimal(30625.00), new decimal((double)f.Component3AsNumber));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse32A_Amount_2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse32A_Amount_2()
		{
			Field32A f = new Field32A("081001VEF30625,67");
			assertNotNull("Parse of field failed", f);
			assertEquals("VEF", f.getComponent2());
			assertEquals(new decimal(30625.67), new decimal((double)f.Component3AsNumber));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTicket32()
		public virtual void testTicket32()
		{
			Field32A f = new Field32A("070813GBP,");
			assertEquals(null, f.getAmount());

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTicketAmountSize()
		public virtual void testTicketAmountSize()
		{
			Field32A f = new Field32A("051028EUR1765432,");
			assertNotNull("Parse of field failed", f);
			assertEquals("EUR", f.getComponent2());
			assertEquals(new decimal(1765432), new decimal((double)f.Component3AsNumber));
		}

	}
}