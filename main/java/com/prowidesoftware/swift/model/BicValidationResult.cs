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
namespace com.prowidesoftware.swift.model
{

	using StrSubstitutor = org.apache.commons.lang3.text.StrSubstitutor;


	/// <summary>
	/// To indicate the validation problem found when validating a BIC </summary>
	/// <seealso cref= BIC#validate()
	/// @since 7.10.3
	/// @author sebastian </seealso>
	public sealed class BicValidationResult
	{
		public static readonly BicValidationResult OK = new BicValidationResult("OK", InnerEnum.OK, "The BIC code is valid");

		public static readonly BicValidationResult INVALID_LENGTH = new BicValidationResult("INVALID_LENGTH", InnerEnum.INVALID_LENGTH, "The BIC code must contain at least 8 characters with the institution (4), country (2) and location code (2)");
		public static readonly BicValidationResult INVALID_INSTITUTION_LENGTH = new BicValidationResult("INVALID_INSTITUTION_LENGTH", InnerEnum.INVALID_INSTITUTION_LENGTH, "The institution code must contain 4 characters and ${length} were found in ${found}");
		public static readonly BicValidationResult INVALID_COUNTRY_LENGTH = new BicValidationResult("INVALID_COUNTRY_LENGTH", InnerEnum.INVALID_COUNTRY_LENGTH, "The country code must contain 2 characters and ${length} were found in ${found}");
		public static readonly BicValidationResult INVALID_LOCATION_LENGTH = new BicValidationResult("INVALID_LOCATION_LENGTH", InnerEnum.INVALID_LOCATION_LENGTH, "The location code must contain 2 characters and ${length} were found in ${found}");
		public static readonly BicValidationResult INVALID_BRANCH_LENGTH = new BicValidationResult("INVALID_BRANCH_LENGTH", InnerEnum.INVALID_BRANCH_LENGTH, "The branch code must contain 3 characters and ${length} were found in ${found}");
		public static readonly BicValidationResult INVALID_INSTITUTION_CHARSET = new BicValidationResult("INVALID_INSTITUTION_CHARSET", InnerEnum.INVALID_INSTITUTION_CHARSET, "The institution code can only contain uppercase letters and ${found} was found");
		public static readonly BicValidationResult INVALID_COUNTRY = new BicValidationResult("INVALID_COUNTRY", InnerEnum.INVALID_COUNTRY, "Invalid country code ${found}");
		public static readonly BicValidationResult INVALID_LOCATION_CHARSET = new BicValidationResult("INVALID_LOCATION_CHARSET", InnerEnum.INVALID_LOCATION_CHARSET, "The location code can only contain uppercase letters or digits and ${found} was found");
		public static readonly BicValidationResult INVALID_BRANCH_CHARSET = new BicValidationResult("INVALID_BRANCH_CHARSET", InnerEnum.INVALID_BRANCH_CHARSET, "The branch code can only contain uppercase letters or digits and ${found} was found");

		private static readonly IList<BicValidationResult> valueList = new List<BicValidationResult>();

		static BicValidationResult()
		{
			valueList.Add(OK);
			valueList.Add(INVALID_LENGTH);
			valueList.Add(INVALID_INSTITUTION_LENGTH);
			valueList.Add(INVALID_COUNTRY_LENGTH);
			valueList.Add(INVALID_LOCATION_LENGTH);
			valueList.Add(INVALID_BRANCH_LENGTH);
			valueList.Add(INVALID_INSTITUTION_CHARSET);
			valueList.Add(INVALID_COUNTRY);
			valueList.Add(INVALID_LOCATION_CHARSET);
			valueList.Add(INVALID_BRANCH_CHARSET);
		}

		public enum InnerEnum
		{
			OK,
			INVALID_LENGTH,
			INVALID_INSTITUTION_LENGTH,
			INVALID_COUNTRY_LENGTH,
			INVALID_LOCATION_LENGTH,
			INVALID_BRANCH_LENGTH,
			INVALID_INSTITUTION_CHARSET,
			INVALID_COUNTRY,
			INVALID_LOCATION_CHARSET,
			INVALID_BRANCH_CHARSET
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: BicValidationResult(final String message)
		internal BicValidationResult(string name, InnerEnum innerEnum, string message)
		{
			this.message = message;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		private string message;
		private IDictionary<String, String> vars = new java.util.HashMap<String, String>();

		/// <summary>
		/// Validation problem description including expected and found content when necessary
		/// </summary>
		public String message()
		{
			// this legacy class has been migrated to apache commons-text
			// we avoid adding the new dependency until it is further required
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.commons.lang3.text.StrSubstitutor sub = new org.apache.commons.lang3.text.StrSubstitutor(this.vars);
			StrSubstitutor sub = new StrSubstitutor(this.vars);
			return sub.replace(this.message);
		}

		/// <summary>
		/// Sets a "found" and "length" variable for messages text
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: void setFound(final String found)
		internal string Found
		{
			set
			{
				this.vars.put("found", value);
				if (value != null)
				{
					this.vars.put("length", Convert.ToString(value.Length));
				}
			}
		}

		/// <returns> the validation message parameters set to the enum value </returns>
		private java.util.Map<String, String> vars()
		{
			return this.vars;
		}


		public static IList<BicValidationResult> values()
		{
			return valueList;
		}

		public InnerEnum InnerEnumValue()
		{
			return innerEnumValue;
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static BicValidationResult valueOf(string name)
		{
			foreach (BicValidationResult enumInstance in BicValidationResult.values())
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}
}