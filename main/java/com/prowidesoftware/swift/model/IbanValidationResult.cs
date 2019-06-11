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
	/// To indicate the validation problem found when validating an IBAN </summary>
	/// <seealso cref= IBAN#validate()
	/// @since 7.9.7
	/// @author psantamarina </seealso>
	public sealed class IbanValidationResult
	{
		public static readonly IbanValidationResult OK = new IbanValidationResult("OK", InnerEnum.OK, "The IBAN is valid");

		public static readonly IbanValidationResult IBAN_IS_NULL = new IbanValidationResult("IBAN_IS_NULL", InnerEnum.IBAN_IS_NULL, "The IBAN is null");
		public static readonly IbanValidationResult IBAN_IS_EMPTY = new IbanValidationResult("IBAN_IS_EMPTY", InnerEnum.IBAN_IS_EMPTY, "The IBAN is empty");

		public static readonly IbanValidationResult MISSING_COUNTRY_CODE = new IbanValidationResult("MISSING_COUNTRY_CODE", InnerEnum.MISSING_COUNTRY_CODE, "The IBAN must start with the two letters ISO country code");
		public static readonly IbanValidationResult INVALID_COUNTRY_CODE_CHARSET = new IbanValidationResult("INVALID_COUNTRY_CODE_CHARSET", InnerEnum.INVALID_COUNTRY_CODE_CHARSET, "The country code must contain upper case letters and ${found} was found");
		public static readonly IbanValidationResult INVALID_COUNTRY_CODE = new IbanValidationResult("INVALID_COUNTRY_CODE", InnerEnum.INVALID_COUNTRY_CODE, "The country code ${found} is not a valid ISO country code or the country code is not configured for IBAN validations");

		public static readonly IbanValidationResult INVALID_CHARACTERS = new IbanValidationResult("INVALID_CHARACTERS", InnerEnum.INVALID_CHARACTERS, "Invalid character '${found}' found");
		public static readonly IbanValidationResult MISSING_CHECK_DIGITS = new IbanValidationResult("MISSING_CHECK_DIGITS", InnerEnum.MISSING_CHECK_DIGITS, "Missing check digits");
		public static readonly IbanValidationResult INVALID_CHECK_DIGITS_FORMAT = new IbanValidationResult("INVALID_CHECK_DIGITS_FORMAT", InnerEnum.INVALID_CHECK_DIGITS_FORMAT, "Expected 2 check digits and found ${found}");
		public static readonly IbanValidationResult IVALID_CHECK_DIGITS = new IbanValidationResult("IVALID_CHECK_DIGITS", InnerEnum.IVALID_CHECK_DIGITS, "The expected computed check digit is ${expectedCheckDigit} and ${found} was found");

		public static readonly IbanValidationResult MISSING_BBAN = new IbanValidationResult("MISSING_BBAN", InnerEnum.MISSING_BBAN, "Missing custom account number (BBAN)");
		public static readonly IbanValidationResult BBAN_MAX_LENGTH = new IbanValidationResult("BBAN_MAX_LENGTH", InnerEnum.BBAN_MAX_LENGTH, "The max length for the custom account number (BBAN) is ${expectedLength} and found ${foundLength}");

		public static readonly IbanValidationResult MISSING_BBAN_CONFIGURATION = new IbanValidationResult("MISSING_BBAN_CONFIGURATION", InnerEnum.MISSING_BBAN_CONFIGURATION, "Missing custom account number (BBAN) configuration for country ${found}");
		public static readonly IbanValidationResult BBAN_INVALID_LENGTH = new IbanValidationResult("BBAN_INVALID_LENGTH", InnerEnum.BBAN_INVALID_LENGTH, "Expected a ${expectedLength} characters length for the custom account number (BBAN) and found ${foundLength} in ${found}");
		public static readonly IbanValidationResult BBAN_INVALID_UPPER_CASE_LETTERS = new IbanValidationResult("BBAN_INVALID_UPPER_CASE_LETTERS", InnerEnum.BBAN_INVALID_UPPER_CASE_LETTERS, "The ${bbanEntryType} ${found} must contain only upper case letters");
		public static readonly IbanValidationResult BBAN_INVALID_DIGITS_OR_LETTERS = new IbanValidationResult("BBAN_INVALID_DIGITS_OR_LETTERS", InnerEnum.BBAN_INVALID_DIGITS_OR_LETTERS, "The ${bbanEntryType} ${found} must contain only digits or upper case letters");
		public static readonly IbanValidationResult BBAN_INVALID_DIGITS = new IbanValidationResult("BBAN_INVALID_DIGITS", InnerEnum.BBAN_INVALID_DIGITS, "The ${bbanEntryType} ${found} must contain only digits");

		public static readonly IbanValidationResult UNKNOWN = new IbanValidationResult("UNKNOWN", InnerEnum.UNKNOWN, "Unknown exception validating IBAN");

		private static readonly IList<IbanValidationResult> valueList = new List<IbanValidationResult>();

		static IbanValidationResult()
		{
			valueList.Add(OK);
			valueList.Add(IBAN_IS_NULL);
			valueList.Add(IBAN_IS_EMPTY);
			valueList.Add(MISSING_COUNTRY_CODE);
			valueList.Add(INVALID_COUNTRY_CODE_CHARSET);
			valueList.Add(INVALID_COUNTRY_CODE);
			valueList.Add(INVALID_CHARACTERS);
			valueList.Add(MISSING_CHECK_DIGITS);
			valueList.Add(INVALID_CHECK_DIGITS_FORMAT);
			valueList.Add(IVALID_CHECK_DIGITS);
			valueList.Add(MISSING_BBAN);
			valueList.Add(BBAN_MAX_LENGTH);
			valueList.Add(MISSING_BBAN_CONFIGURATION);
			valueList.Add(BBAN_INVALID_LENGTH);
			valueList.Add(BBAN_INVALID_UPPER_CASE_LETTERS);
			valueList.Add(BBAN_INVALID_DIGITS_OR_LETTERS);
			valueList.Add(BBAN_INVALID_DIGITS);
			valueList.Add(UNKNOWN);
		}

		public enum InnerEnum
		{
			OK,
			IBAN_IS_NULL,
			IBAN_IS_EMPTY,
			MISSING_COUNTRY_CODE,
			INVALID_COUNTRY_CODE_CHARSET,
			INVALID_COUNTRY_CODE,
			INVALID_CHARACTERS,
			MISSING_CHECK_DIGITS,
			INVALID_CHECK_DIGITS_FORMAT,
			IVALID_CHECK_DIGITS,
			MISSING_BBAN,
			BBAN_MAX_LENGTH,
			MISSING_BBAN_CONFIGURATION,
			BBAN_INVALID_LENGTH,
			BBAN_INVALID_UPPER_CASE_LETTERS,
			BBAN_INVALID_DIGITS_OR_LETTERS,
			BBAN_INVALID_DIGITS,
			UNKNOWN
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;


//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: IbanValidationResult(final String message)
		internal IbanValidationResult(string name, InnerEnum innerEnum, string message)
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
		/// Sets a "found" variable for messages text
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: void setFound(final String found)
		internal string Found
		{
			set
			{
				this.vars.put("found", value);
			}
		}

		/// <summary>
		/// Sets a "expectedLength" variable for messages text
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: void setExpectedLength(final int expectedLength)
		internal int ExpectedLength
		{
			set
			{
				this.vars.put("expectedLength", Convert.ToString(value));
			}
		}

		/// <summary>
		/// Sets a "foundLength" variable for messages text
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: void setFoundLength(final int foundLength)
		internal int FoundLength
		{
			set
			{
				this.vars.put("foundLength", Convert.ToString(value));
			}
		}

		/// <summary>
		/// Sets a "bbanEntryType" variable for messages text
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: void setBbanEntryType(final BbanEntryType type)
		internal BbanEntryType BbanEntryType
		{
			set
			{
				this.vars.put("bbanEntryType", value.name());
			}
		}

		/// <summary>
		/// Sets a "expectedCheckDigit" variable for messages text
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: void setExpectedCheckDigit(final String expectedCheckDigit)
		internal string ExpectedCheckDigit
		{
			set
			{
				this.vars.put("expectedCheckDigit", value);
			}
		}

		/// <returns> the validation message parameters set to the enum value </returns>
		public java.util.Map<String, String> vars()
		{
			return this.vars;
		}


		public static IList<IbanValidationResult> values()
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

		public static IbanValidationResult valueOf(string name)
		{
			foreach (IbanValidationResult enumInstance in IbanValidationResult.values())
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