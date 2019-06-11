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
namespace com.prowidesoftware.swift.utils
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


	using Test = org.junit.Test;

	/// <summary>
	/// Test for SwiftFormatUtils.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class SwiftFormatUtilsTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetNumber() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetNumber()
		{
			assertNotNull(SwiftFormatUtils.getNumber("123"));
			assertEquals(123, ((int)SwiftFormatUtils.getNumber("123")));

			assertNotNull(SwiftFormatUtils.getNumber("123,"));
			assertEquals(new decimal(123), new decimal((double)SwiftFormatUtils.getNumber("123,")));

			//this test does not work but this format is not used
			//assertNotNull(SwiftFormatUtils.getNumber(",12"));
			//assertEquals(new BigDecimal(0.12), new BigDecimal(SwiftFormatUtils.getNumber(",12").doubleValue()));

			assertNotNull(SwiftFormatUtils.getNumber("1,2"));
			assertEquals(new double?(1.2), new double?((double)SwiftFormatUtils.getNumber("1,2")));

			assertNotNull(SwiftFormatUtils.getNumber("12,34"));
			assertEquals(new double?(12.34), new double?((double)SwiftFormatUtils.getNumber("12,34")));

			assertNotNull(SwiftFormatUtils.getNumber("12,3456"));
			assertEquals(new double?(12.3456), new double?((double)SwiftFormatUtils.getNumber("12,3456")));

			assertNotNull(SwiftFormatUtils.getNumber("0,"));
			assertEquals(new double?(0), new double?((double)SwiftFormatUtils.getNumber("0,")));

			assertNotNull(SwiftFormatUtils.getNumber("299000,34"));
			assertEquals(new double?(299000.34), new double?((double)SwiftFormatUtils.getNumber("299000,34")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetNumberWriter() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetNumberWriter()
		{
			assertEquals("12,", SwiftFormatUtils.getNumber(new decimal(12)));
			assertEquals("12,34", SwiftFormatUtils.getNumber(new decimal(12.34)));
			assertEquals("12,", SwiftFormatUtils.getNumber(new decimal(12.0)));
			assertEquals("123,", SwiftFormatUtils.getNumber(new decimal(123)));
			assertEquals("1,2", SwiftFormatUtils.getNumber(new decimal(1.2)));
			assertEquals("0,7", SwiftFormatUtils.getNumber(new decimal(0.7)));
			assertEquals("12,345", SwiftFormatUtils.getNumber(new decimal(12.345)));
			assertEquals("12,", SwiftFormatUtils.getNumber(12));
			assertEquals("12,3", SwiftFormatUtils.getNumber(12.3));
			assertEquals("12,34", SwiftFormatUtils.getNumber(12.34));
			assertEquals("12,345", SwiftFormatUtils.getNumber(12.345));
			assertEquals("12,3456", SwiftFormatUtils.getNumber(new decimal(12.3456)));
			assertEquals("12,34567", SwiftFormatUtils.getNumber(new decimal(12.34567)));
			assertEquals("12,345678", SwiftFormatUtils.getNumber(new decimal(12.345678)));
			assertEquals("12,3456789", SwiftFormatUtils.getNumber(new decimal(12.3456789)));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsHHMM() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testIsHHMM()
		{
			assertNotNull(SwiftFormatUtils.getHhmm("0000"));
			assertEquals(0, SwiftFormatUtils.getHhmm("0000").get(DateTime.HOUR_OF_DAY));
			assertEquals(0, SwiftFormatUtils.getHhmm("0000").Minute);

			assertNotNull(SwiftFormatUtils.getHhmm("1245"));
			assertEquals(12, SwiftFormatUtils.getHhmm("1245").get(DateTime.HOUR_OF_DAY));
			assertEquals(45, SwiftFormatUtils.getHhmm("1245").Minute);

			assertNotNull(SwiftFormatUtils.getHhmm("1359"));
			assertEquals(13, SwiftFormatUtils.getHhmm("1359").get(DateTime.HOUR_OF_DAY));
			assertEquals(59, SwiftFormatUtils.getHhmm("1359").Minute);

			assertNull(SwiftFormatUtils.getHhmm("0060"));
			assertNull(SwiftFormatUtils.getHhmm("2400"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsOffset() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testIsOffset()
		{
			assertNotNull(SwiftFormatUtils.getOffset("0000"));
			assertNotNull(SwiftFormatUtils.getOffset("1245"));
			assertNotNull(SwiftFormatUtils.getOffset("1300"));
			assertNotNull(SwiftFormatUtils.getOffset("1301"));
			assertNotNull(SwiftFormatUtils.getOffset("1359"));
			assertNull(SwiftFormatUtils.getOffset("0060"));
			assertNull(SwiftFormatUtils.getOffset("2400"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsDate2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testIsDate2()
		{
			// TODO add test for specific values to be parsed correctly
			assertNotNull(SwiftFormatUtils.getDate2("070131"));
			assertNotNull(SwiftFormatUtils.getDate2("070228"));
			assertNotNull(SwiftFormatUtils.getDate2("070430"));

			assertNull(SwiftFormatUtils.getDate2("070229"));
			assertNull(SwiftFormatUtils.getDate2("070132"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testLeapYear()
		public virtual void testLeapYear()
		{
			assertTrue(SwiftFormatUtils.isLeapYear(2016));
			assertFalse(SwiftFormatUtils.isLeapYear(2017));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsDate1_Leap() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testIsDate1_Leap()
		{
			if (SwiftFormatUtils.LeapYear)
			{
				assertNotNull(SwiftFormatUtils.getDate1("0229"));
			}
			else
			{
				assertNull(SwiftFormatUtils.getDate1("0229"));
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDecimalsInAmount() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testDecimalsInAmount()
		{
			assertEquals(0, SwiftFormatUtils.decimalsInAmount((string)null));
			assertEquals(0, SwiftFormatUtils.decimalsInAmount(""));
			assertEquals(0, SwiftFormatUtils.decimalsInAmount("1"));
			assertEquals(0, SwiftFormatUtils.decimalsInAmount("1,"));
			assertEquals(0, SwiftFormatUtils.decimalsInAmount("1127892189"));

			assertEquals(1, SwiftFormatUtils.decimalsInAmount("112789218,9"));
			assertEquals(1, SwiftFormatUtils.decimalsInAmount("112789,218,9"));
			assertEquals(1, SwiftFormatUtils.decimalsInAmount("112789,,,218,9"));
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDecimalsInAmountBigDecimal() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testDecimalsInAmountBigDecimal()
		{
			assertEquals(0, SwiftFormatUtils.decimalsInAmount((decimal)null));
			assertEquals(0, SwiftFormatUtils.decimalsInAmount(new decimal("1")));
			assertEquals(0, SwiftFormatUtils.decimalsInAmount(new decimal("1.00")));
			assertEquals(0, SwiftFormatUtils.decimalsInAmount("new BigDecimal(1127892189"));

			assertEquals(5, SwiftFormatUtils.decimalsInAmount(new decimal("11278.92189")));
			assertEquals(1, SwiftFormatUtils.decimalsInAmount(new decimal("112789218.9")));
			assertEquals(4, SwiftFormatUtils.decimalsInAmount(new decimal("112789.2189")));
		}

	}

}