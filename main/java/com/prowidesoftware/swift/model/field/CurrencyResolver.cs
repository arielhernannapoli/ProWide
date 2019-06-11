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


	public class CurrencyResolver
	{

		public static IList<string> resolveComponentsPattern(string pattern, IList<string> components)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<String> result = new java.util.ArrayList<>();
			IList<string> result = new List<string>();
			if (pattern != null)
			{
				if (pattern.IndexOf('C') >= 0)
				{
					for (int i = 0;i < pattern.Length;i++)
					{
						if (pattern[i] == 'C')
						{
							result.Add(components[i]);
						}
					}
				}
			}
			return result;
		}

		public static Currency resolveCurrency(CurrencyContainer o)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String s = resolveCurrencyString(o);
			string s = resolveCurrencyString(o);
			if (s == null)
			{
				return null;
			}
			return Currency.getInstance(s);
		}

		public static string resolveCurrencyString(CurrencyContainer o)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<String> list = o.currencyStrings();
			IList<string> list = o.currencyStrings();
			if (list.Count > 0)
			{
				return list[0];
			}
			return null;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void resolveSetCurrency(final CurrencyContainer cc, final java.util.Currency cur)
		public static void resolveSetCurrency(CurrencyContainer cc, Currency cur)
		{

		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void resolveSetCurrency(final CurrencyContainer cc, final String cur)
		public static void resolveSetCurrency(CurrencyContainer cc, string cur)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String pat = cc.componentsPattern();
			string pat = cc.componentsPattern();
			Field f = (Field)cc;
			for (int i = 0;i < pat.Length;i++)
			{
				if (pat[i] == 'C')
				{
					f.setComponent(i, cur);
				}
			}
		}
	}

}