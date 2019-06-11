using System;
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
namespace com.prowidesoftware.swift.utils
{

	using Validate = org.apache.commons.lang3.Validate;
	using StringUtils = org.apache.commons.lang3.StringUtils;


	/// <summary>
	/// Helper API to check country and currency codes using Java <seealso cref="Currency"/> and <seealso cref="Locale"/> API.
	/// 
	/// <para>The list of valid currency and country codes can be manipulated after initialization in order to
	/// change or add new values. This can be particularly helpful when the application is not running on 
	/// the latest Java version and a currency change or addition has not yet been updated in the used JRE.
	/// 
	/// @author sebastian
	/// @since 7.9.2
	/// </para>
	/// </summary>
	public sealed class IsoUtils
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly Logger log = Logger.getLogger(typeof(IsoUtils).FullName);

		private Set<string> currencies;
		private Set<string> countries;

		private static IsoUtils instance;

		private IsoUtils()
		{
			currencies = new HashSet<>();
			foreach (Currency currency in Currency.AvailableCurrencies)
			{
				string val = currency.CurrencyCode;
				if (!currencies.contains(val))
				{
					currencies.add(val);
				}
			}
			// Jul 2016: Belorussia changed currency from 974 (BYR) to 933 (BYN)
			if (!currencies.contains("BYN"))
			{
				currencies.add("BYN");
			}

			countries = new HashSet<> (Locale.ISOCountries);
			// Add country code for Kosovo, not yet in ISO but used by SWIFT
			if (!countries.contains("XK"))
			{
				countries.add("XK");
			}

			log.info("IsoUtils initialized with " + currencies.size() + " currency codes and " + countries.size() + " country codes");
		}

		public static IsoUtils Instance
		{
			get
			{
				lock (typeof(IsoUtils))
				{
					if (instance == null)
					{
						lock (typeof(IsoUtils))
						{
							if (instance == null)
							{
								instance = new IsoUtils();
							}
						}
					}
					return instance;
				}
			}
		}

		public Set<string> Currencies
		{
			get
			{
				return currencies;
			}
			set
			{
				this.currencies = value;
			}
		}


		public Set<string> Countries
		{
			get
			{
				return countries;
			}
			set
			{
				this.countries = value;
			}
		}


		/// <summary>
		/// Checks if the currency code is a valid ISO currency using Java <seealso cref="Currency"/> </summary>
		/// <param name="currencyCode"> a three letters capitalized currency code, example: USD </param>
		/// <returns> true if currency code is valid, false if it is blank or not valid </returns>
		public bool isValidISOCurrency(string currencyCode)
		{
			if (StringUtils.length(currencyCode) == 3)
			{
				return currencies.contains(currencyCode);
			}
			return false;
		}

		/// <summary>
		/// Checks if the country code is a valid ISO country using Java <seealso cref="Locale#getISOCountries()"/> </summary>
		/// <param name="countryCode"> a two letters capitalized country code, example: US </param>
		/// <returns> true if country code is valid, false if it is blank or not valid </returns>
		public bool isValidISOCountry(string countryCode)
		{
			if (StringUtils.length(countryCode) == 2)
			{
				return countries.contains(countryCode);
			}
			return false;
		}

		/// <summary>
		/// Adds the given country code to the current list of codes, verifying that it does not exist previously. </summary>
		/// <param name="countryCode"> a two capital letters country code, for example: XK </param>
		/// <exception cref="IllegalArgumentException"> if the parameter code is null or not two uppercase letters
		/// @since 7.9.7 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void addCountry(final String countryCode)
		public void addCountry(string countryCode)
		{
			Validate.isTrue(countryCode != null && countryCode.Length == 2 && countryCode.matches("[A-Z]*"), "The country code must by indicated with two uppercase letters");
			if (!countries.contains(countryCode))
			{
				countries.add(countryCode);
			}
		}

		/// <summary>
		/// Adds the given currency code to the current list of codes, verifying that it does not exist previously. </summary>
		/// <param name="currencyCode"> a three capital letters currency code, for example: ARS </param>
		/// <exception cref="IllegalArgumentException"> if the parameter code is null or not three uppercase letters
		/// @since 7.9.7 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void addCurrency(final String currencyCode)
		public void addCurrency(string currencyCode)
		{
			Validate.isTrue(currencyCode != null && currencyCode.Length == 3 && currencyCode.matches("[A-Z]*"), "The currency code must by indicated with three uppercase letters");
			if (!currencies.contains(currencyCode))
			{
				currencies.add(currencyCode);
			}
		}

	}
}