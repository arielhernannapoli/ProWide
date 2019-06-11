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


	/// <summary>
	/// Interface to mark fields whose definition contain a currency.
	/// Note that if a field has a currency and it is optional, and the actual 
	/// field has not set the optional currency/ies then
	/// the call currencies() will return an empty list
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public interface CurrencyContainer : PatternContainer
	{

		/// <summary>
		/// Get a list of strings of currencies present in this field </summary>
		/// <returns> a list, with zero or more currencies in this field. </returns>
		IList<string> currencyStrings();

		/// <summary>
		/// Get the single currency contained in this field. </summary>
		/// <returns> null if no currency is contained - which should never happen, or throws an exception if more than one currency is present in this field.
		///  </returns>
		string currencyString();

		/// <summary>
		/// Utility method that creates a Currency for every string returned by <seealso cref="#currencyStrings()"/>
		/// 
		/// </summary>
		IList<Currency> currencies();

		/// <summary>
		/// Analog to <seealso cref="#currencyString()"/> </summary>
		/// <seealso cref= #currencyStrings() </seealso>
		/// <seealso cref= #currencyString() </seealso>
		Currency currency();

		/// <summary>
		/// set the currency of this field.
		/// If this field contains more than one currency then all currency components will be set.
		/// Individual setComponentNN should be used to set only one component of the field.
		/// </summary>
		void initializeCurrencies(string cur);

		/// <seealso cref= #initializeCurrencies(String) </seealso>
		void initializeCurrencies(Currency cur);

	}

}