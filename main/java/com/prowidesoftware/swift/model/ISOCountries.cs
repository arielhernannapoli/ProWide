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
	/// Helper class to validate ISO Country codes
	/// </summary>
	/// @deprecated use Java <seealso cref="Locale#getISOCountries()"/> instead 
	/// <seealso cref= IsoUtils#isValidISOCountry(String)
	/// 
	/// @author www.prowidesoftware.com
	/// @since 3.3 </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use Java <seealso cref="Locale#getISOCountries()"/> instead") @ProwideDeprecated(phase3=TargetYear._2019) public class ISOCountries extends PropertyResource
	[Obsolete("use Java <seealso cref="Locale#getISOCountries()"/> instead")]
	public class ISOCountries : PropertyResource
	{
		private static readonly ISOCountries instance = new ISOCountries();

		/// <summary>
		/// Default constructor
		/// </summary>
		protected internal ISOCountries() : base()
		{
		}

		/// <summary>
		/// Get the unique instance of this object </summary>
		/// <returns> the object instance </returns>
		public static ISOCountries Instance
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
				return "countries.properties";
			}
		}

	}

}