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
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	using Field19A = com.prowidesoftware.swift.model.field.Field19A;
	using Field20 = com.prowidesoftware.swift.model.field.Field20;
	using Field32A = com.prowidesoftware.swift.model.field.Field32A;
	using Field33B = com.prowidesoftware.swift.model.field.Field33B;
	using Field62F = com.prowidesoftware.swift.model.field.Field62F;

	/// <summary>
	/// Test cases for currency amount containers
	/// 
	/// @author sebastian
	/// @since 7.8.8
	/// </summary>
	public class CurrencyAmountTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCurrencyAmountFromField()
		public virtual void testCurrencyAmountFromField()
		{
			CurrencyAmount ca = CurrencyAmount.of(new Field32A("121212USD1234,"));
			assertEquals("USD", ca.Currency);
			assertEquals(new decimal("1234"), ca.Amount);

			assertNull(CurrencyAmount.of(new Field20("FOO")));

			ca = CurrencyAmount.of(new Field19A(":AAAA//EUR567,8"));
			assertEquals("EUR", ca.Currency);
			assertEquals(new decimal("567.8"), ca.Amount);

			ca = CurrencyAmount.of(new Field19A(":AAAA//NEUR567,8"));
			assertEquals("EUR", ca.Currency);
			assertEquals(new decimal("-567.8"), ca.Amount);

			ca = CurrencyAmount.of(new Field33B("ARS1,"));
			assertEquals("ARS", ca.Currency);
			assertEquals(new decimal("1"), ca.Amount);

			ca = CurrencyAmount.of(new Field62F("121212USD1234,"));
			assertEquals("USD", ca.Currency);
			assertEquals(new decimal("1234"), ca.Amount);

			ca = CurrencyAmount.of(new Field62F("D121212USD1234,"));
			assertEquals("USD", ca.Currency);
			assertEquals(new decimal("-1234"), ca.Amount);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCurrencyAmountSum()
		public virtual void testCurrencyAmountSum()
		{
			CurrencyAmount ca = CurrencyAmount.ofSum(new Field32A("121212USD1000,1"), new Field33B("USD2000,1"), new Field62F("121212USD3000,1"));
			assertEquals("USD", ca.Currency);
			assertEquals(new decimal("6000.3"), ca.Amount);

			ca = CurrencyAmount.ofSum(new Field32A("121212USD5000,1"), new Field33B("USD5000,1"), new Field62F("D121212USD3000,1"));
			assertEquals("USD", ca.Currency);
			assertEquals(new decimal("7000.1"), ca.Amount);
		}
	}

}