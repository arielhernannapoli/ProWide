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

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using IsoUtils = com.prowidesoftware.swift.utils.IsoUtils;

	/// <summary>
	/// Helper class to validate ISO Currency codes
	/// </summary>
	/// @deprecated use Java Currency instead 
	/// <seealso cref= IsoUtils#isValidISOCurrency(String)
	/// 
	/// @author www.prowidesoftware.com
	/// @since 3.3 </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use Java Currency instead") @ProwideDeprecated(phase3=TargetYear._2019) public class ISOCurrencies extends PropertyResource
	[Obsolete("use Java Currency instead")]
	public class ISOCurrencies : PropertyResource
	{
		private static readonly ISOCurrencies instance = new ISOCurrencies();

		/// <summary>
		/// Default constructor
		/// </summary>
		protected internal ISOCurrencies() : base()
		{
		}

		/// <summary>
		/// Get the unique instance of this object </summary>
		/// <returns> the object instance </returns>
		public static ISOCurrencies Instance
		{
			get
			{
				return instance;
			}
		}
		protected internal override string ResourceName
		{
			get
			{
				return "currencies.properties";
			}
		}

	}

}