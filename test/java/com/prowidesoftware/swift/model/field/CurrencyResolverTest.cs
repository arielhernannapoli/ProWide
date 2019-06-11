using System.Collections.Generic;

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

	using Test = org.junit.Test;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;

	public class CurrencyResolverTest
	{
		private sealed class DummyCurrencyContainer : CurrencyContainer
		{
			private readonly CurrencyResolverTest outerInstance;

			internal <string> currencies_Renamed;

			internal DummyCurrencyContainer(CurrencyResolverTest outerInstance, IList<string> list)
			{
				this.outerInstance = outerInstance;
				this.currencies_Renamed = list;
			}
			public string componentsPattern()
			{
				// TODO Auto-generated method stub
				return null;
			}
			public string parserPattern()
			{
				// TODO Auto-generated method stub
				return null;
			}
			public IList<string> currencyStrings()
			{
				return this.currencies_Renamed;
			}
			public string currencyString()
			{
				// TODO Auto-generated method stub
				return null;
			}
			public IList<Currency> currencies()
			{
				// TODO Auto-generated method stub
				return null;
			}
			public Currency currency()
			{
				// TODO Auto-generated method stub
				return null;
			}
			public void initializeCurrencies(string cur)
			{
				// TODO Auto-generated method stub

			}
			public void initializeCurrencies(Currency cur)
			{
				// TODO Auto-generated method stub

			}

		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testResolveComponentsPattern()
		public virtual void testResolveComponentsPattern()
		{
			IList<string> components = new List<string>();
			components.Add("c1");
			components.Add("c2");
			components.Add("c3");
			components.Add("c4");
			components.Add("c5");

			IList<string> o = CurrencyResolver.resolveComponentsPattern("SC", components);
			assertEquals(1, o.Count);
			assertEquals("c2", o[0]);

			o = CurrencyResolver.resolveComponentsPattern("CS", components);
			assertEquals(1, o.Count);
			assertEquals("c1", o[0]);

			o = CurrencyResolver.resolveComponentsPattern("SCS", components);
			assertEquals(1, o.Count);
			assertEquals("c2", o[0]);

		}

		// FIXME fallo por un refactor que dejo mal el dummy container
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testResolveCurrency()
		public virtual void testResolveCurrency()
		{
			IList<string> list = new List<string>();
			list.Add("USD");
			DummyCurrencyContainer o = new DummyCurrencyContainer(this, list);
			assertEquals("USD", CurrencyResolver.resolveCurrencyString(o));
		}
	}

}