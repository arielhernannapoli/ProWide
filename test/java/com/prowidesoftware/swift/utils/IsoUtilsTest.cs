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

	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	/// <summary>
	/// test cases for <seealso cref="IsoUtils"/>
	/// 
	/// @author sebastian
	/// @since 7.9.2
	/// </summary>
	public class IsoUtilsTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCurrencies()
		public virtual void testCurrencies()
		{
			/*
			 * valid
			 */
			assertTrue(IsoUtils.Instance.isValidISOCurrency("EUR"));
			assertTrue(IsoUtils.Instance.isValidISOCurrency("USD"));
			assertTrue(IsoUtils.Instance.isValidISOCurrency("ARS"));
			assertTrue(IsoUtils.Instance.isValidISOCurrency("BYN"));
			assertTrue(IsoUtils.Instance.isValidISOCurrency("NGN"));
			/*
			 * invalid
			 */
			assertFalse(IsoUtils.Instance.isValidISOCurrency("usd"));
			assertFalse(IsoUtils.Instance.isValidISOCurrency(""));
			assertFalse(IsoUtils.Instance.isValidISOCurrency(null));
			assertFalse(IsoUtils.Instance.isValidISOCurrency("XYZ"));

			IsoUtils.Instance.Currencies.add("XYZ");
			assertTrue(IsoUtils.Instance.isValidISOCurrency("XYZ"));
			IsoUtils.Instance.Currencies.remove("XYZ");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCountries()
		public virtual void testCountries()
		{
			/*
			 * valid
			 */
			assertTrue(IsoUtils.Instance.isValidISOCountry("US"));
			assertTrue(IsoUtils.Instance.isValidISOCountry("AR"));
			assertTrue(IsoUtils.Instance.isValidISOCountry("BR"));
			assertTrue(IsoUtils.Instance.isValidISOCountry("XK")); //Kosovo, not currently in ISO
			/*
			 * invalid
			 */
			assertFalse(IsoUtils.Instance.isValidISOCountry("us"));
			assertFalse(IsoUtils.Instance.isValidISOCountry("Foo"));
			assertFalse(IsoUtils.Instance.isValidISOCountry(""));
			assertFalse(IsoUtils.Instance.isValidISOCountry(null));
			assertFalse(IsoUtils.Instance.isValidISOCountry("XX"));
			assertFalse(IsoUtils.Instance.isValidISOCountry("ZZ"));
			assertFalse(IsoUtils.Instance.isValidISOCountry("ar"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IllegalArgumentException.class) public void testAddCountry_1()
		public virtual void testAddCountry_1()
		{
			IsoUtils.Instance.addCountry(null);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IllegalArgumentException.class) public void testAddCountry_2()
		public virtual void testAddCountry_2()
		{
			IsoUtils.Instance.addCountry("33");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IllegalArgumentException.class) public void testAddCountry_3()
		public virtual void testAddCountry_3()
		{
			IsoUtils.Instance.addCountry("aa");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IllegalArgumentException.class) public void testAddCountry_4()
		public virtual void testAddCountry_4()
		{
			IsoUtils.Instance.addCountry("AAA");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAddCountry_5()
		public virtual void testAddCountry_5()
		{
			IsoUtils.Instance.addCountry("SZ");
			assertTrue(IsoUtils.Instance.isValidISOCountry("SZ"));
			IsoUtils.Instance.Countries.remove("SZ");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IllegalArgumentException.class) public void testAddCurrency_1()
		public virtual void testAddCurrency_1()
		{
			IsoUtils.Instance.addCurrency(null);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IllegalArgumentException.class) public void testAddCurrency_2()
		public virtual void testAddCurrency_2()
		{
			IsoUtils.Instance.addCurrency("333");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IllegalArgumentException.class) public void testAddCurrency_3()
		public virtual void testAddCurrency_3()
		{
			IsoUtils.Instance.addCurrency("aaa");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IllegalArgumentException.class) public void testAddCurrency_4()
		public virtual void testAddCurrency_4()
		{
			IsoUtils.Instance.addCurrency("AAAA");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAddCurrency_5()
		public virtual void testAddCurrency_5()
		{
			IsoUtils.Instance.addCurrency("DSZ");
			assertTrue(IsoUtils.Instance.isValidISOCurrency("DSZ"));
			IsoUtils.Instance.Currencies.remove("DSZ");
		}

	}

}