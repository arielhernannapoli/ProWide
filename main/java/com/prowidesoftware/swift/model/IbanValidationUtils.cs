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

	using IsoUtils = com.prowidesoftware.swift.utils.IsoUtils;

	/// <summary>
	/// Helper API for IBAN validation
	/// @since 7.9.7
	/// @author psantamarina
	/// </summary>
	internal class IbanValidationUtils
	{

		internal const string IBAN_DEFAULT_CHECK_DIGIT = "00";

		private const int MOD = 97;
		private const long MAX = 999999999;
		private const int MAX_BBAN_LENGTH = 30;

		// Suppress default constructor for noninstantiability
		private IbanValidationUtils()
		{
			throw new AssertionError();
		}

		/// <summary>
		/// Checks the IBAN country code </summary>
		/// <returns> problem found or null if country code is OK </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static IbanValidationResult validateCountryCode(final String iban)
		internal static IbanValidationResult validateCountryCode(string iban)
		{
			// check if iban contains 2 char country code
			if (iban.Length < IBAN.COUNTRY_CODE_LENGTH)
			{
				return IbanValidationResult.MISSING_COUNTRY_CODE;
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String countryCode = IBAN.getCountryCode(iban);
			string countryCode = IBAN.getCountryCode(iban);

			// check case sensitivity
			if (!countryCode.Equals(countryCode.ToUpper()) || !char.IsLetter(countryCode[0]) || !char.IsLetter(countryCode[1]))
			{
				IbanValidationResult result = IbanValidationResult.INVALID_COUNTRY_CODE_CHARSET;
				result.Found = countryCode;
				return result;
			}

			if (!IsoUtils.Instance.isValidISOCountry(countryCode))
			{
				IbanValidationResult result = IbanValidationResult.INVALID_COUNTRY_CODE;
				result.Found = countryCode;
				return result;
			}

			return null;
		}

		/// <summary>
		/// Checks the check digits are present </summary>
		/// <returns> problem found or null if OK </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static IbanValidationResult validateCheckDigitPresence(final String iban)
		internal static IbanValidationResult validateCheckDigitPresence(string iban)
		{
			// check if iban contains 2 digit check digit
			if (iban.Length < IBAN.COUNTRY_CODE_LENGTH + IBAN.CHECK_DIGIT_LENGTH)
			{
				return IbanValidationResult.MISSING_CHECK_DIGITS;
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String checkDigit = IBAN.getCheckDigits(iban);
			string checkDigit = IBAN.getCheckDigits(iban);

			// check digits
			if (!char.IsDigit(checkDigit[0]) || !char.IsDigit(checkDigit[1]))
			{
				IbanValidationResult result = IbanValidationResult.INVALID_CHECK_DIGITS_FORMAT;
				result.Found = checkDigit;
				return result;
			}
			return null;
		}

		/// <summary>
		/// Checks the BBAN is present </summary>
		/// <returns> problem found or null if OK
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static IbanValidationResult validateBbanPresence(final String iban)
		internal static IbanValidationResult validateBbanPresence(string iban)
		{
			if (iban.Length <= IBAN.COUNTRY_CODE_LENGTH + IBAN.CHECK_DIGIT_LENGTH)
			{
				return IbanValidationResult.MISSING_BBAN;
			}
			return null;
		}

		/// <summary>
		/// Validates Bban max length </summary>
		/// <param name="bban"> the BBAN part of the IBAN to check </param>
		/// <returns> problem found or null if OK
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static IbanValidationResult validateBbanMaxLength(final String bban)
		internal static IbanValidationResult validateBbanMaxLength(string bban)
		{
			if (bban.Length > MAX_BBAN_LENGTH)
			{
				IbanValidationResult result = IbanValidationResult.BBAN_MAX_LENGTH;
				result.ExpectedLength = MAX_BBAN_LENGTH;
				result.FoundLength = bban.Length;
				return result;
			}
			return null;
		}

		/// <summary>
		/// Validates Bban length </summary>
		/// <param name="bban"> the BBAN part of the IBAN to check </param>
		/// <param name="structure"> structure to check </param>
		/// <returns> problem found or null if OK
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static IbanValidationResult validateBban(final String bban, final BbanStructureDTO structure)
		internal static IbanValidationResult validateBban(string bban, BbanStructureDTO structure)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int expectedBbanLength = getBbanLengh(structure);
			int expectedBbanLength = getBbanLengh(structure);

			if (expectedBbanLength != bban.Length)
			{
				IbanValidationResult result = IbanValidationResult.BBAN_INVALID_LENGTH;
				result.Found = bban;
				result.FoundLength = bban.Length;
				result.ExpectedLength = expectedBbanLength;
				return result;
			}

			int bbanEntryOffset = 0;
			foreach (BbanStructureEntryDTO entry in structure.Validation_rules)
			{

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int entryLength = entry.getLength();
				int entryLength = entry.Length;

				string entryValue = bban.Substring(bbanEntryOffset, entryLength);

				bbanEntryOffset = bbanEntryOffset + entryLength;

				// validate character type
				IbanValidationResult result = validateBbanEntryCharacterType(entry, entryValue);
				if (result != null)
				{
					return result;
				}

			}
			return null;
		}

		/// <summary>
		/// Returns bban's length.
		/// </summary>
		/// <param name="bbanStructure"> BbanStructureDTO </param>
		/// <returns> Returns bban's length
		/// @since 7.9.7 </returns>
		private static int getBbanLengh(BbanStructureDTO bbanStructure)
		{
			int length = 0;
			foreach (BbanStructureEntryDTO entry in bbanStructure.Validation_rules)
			{
				length += entry.Length;
			}
			return length;
		}

		/// <summary>
		/// Checks the check digits are present </summary>
		/// <returns> problem found or null if OK
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static IbanValidationResult validateBbanEntryCharacterType(final BbanStructureEntryDTO entry, final String entryValue)
		private static IbanValidationResult validateBbanEntryCharacterType(BbanStructureEntryDTO entry, string entryValue)
		{
			if (SwiftCharsetUtils.@is(entryValue, entry.CharacterType) != SwiftCharsetUtils.OK)
			{
				IbanValidationResult result = null;
				switch (entry.CharacterType)
				{
					case a:
						result = IbanValidationResult.BBAN_INVALID_UPPER_CASE_LETTERS;
						break;
					case c:
						result = IbanValidationResult.BBAN_INVALID_DIGITS_OR_LETTERS;
						break;
					case n:
						result = IbanValidationResult.BBAN_INVALID_DIGITS;
						break;

					default:
						break;

				}
				if (result != null)
				{
					result.Found = entryValue;
					result.BbanEntryType = entry.getEntryType();
					return result;
				}
			}
			return null;
		}

		/// <summary>
		/// Validates the check digits </summary>
		/// <returns> problem found or null if OK
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static IbanValidationResult validateCheckDigit(final String iban)
		internal static IbanValidationResult validateCheckDigit(string iban)
		{
			if (calculateMod(iban) != 1)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String checkDigit = IBAN.getCheckDigits(iban);
				string checkDigit = IBAN.getCheckDigits(iban);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String expectedCheckDigit = calculateCheckDigit(iban);
				string expectedCheckDigit = calculateCheckDigit(iban);
				IbanValidationResult result = IbanValidationResult.IVALID_CHECK_DIGITS;
				result.ExpectedCheckDigit = expectedCheckDigit;
				result.Found = checkDigit;
				return result;
			}
			return null;
		}

		/// <summary>
		/// Validates the IBAN characters numeric range </summary>
		/// <returns> problem found or null if OK
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static IbanValidationResult validateCharacters(final String iban)
		internal static IbanValidationResult validateCharacters(string iban)
		{
			for (int i = 0; i < iban.Length; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int numericValue = Character.getNumericValue(iban.charAt(i));
				int numericValue = char.getNumericValue(iban[i]);
				if (numericValue < 0 || numericValue > 35)
				{
					IbanValidationResult result = IbanValidationResult.INVALID_CHARACTERS;
					result.Found = Convert.ToString(iban[i]);
					return result;
				}
			}
			return null;
		}

		/// <summary>
		/// Calculates Iban
		/// <a href="http://en.wikipedia.org/wiki/ISO_13616#Generating_IBAN_check_digits">Check Digit</a>.
		/// </summary>
		/// <param name="iban"> string value </param>
		/// <returns> check digit as String
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static String calculateCheckDigit(final String iban)
		private static string calculateCheckDigit(string iban)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String reformattedIban = replaceCheckDigit(iban, IBAN_DEFAULT_CHECK_DIGIT);
			string reformattedIban = replaceCheckDigit(iban, IBAN_DEFAULT_CHECK_DIGIT);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int modResult = calculateMod(reformattedIban);
			int modResult = calculateMod(reformattedIban);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int checkDigitIntValue = (98 - modResult);
			int checkDigitIntValue = (98 - modResult);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String checkDigit = Integer.toString(checkDigitIntValue);
			string checkDigit = Convert.ToString(checkDigitIntValue);
			return checkDigitIntValue > 9 ? checkDigit : "0" + checkDigit;
		}

		/// <summary>
		/// Returns an iban with replaced check digit.
		/// </summary>
		/// <param name="iban"> The iban </param>
		/// <returns> The iban without the check digit
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static String replaceCheckDigit(final String iban, final String checkDigit)
		private static string replaceCheckDigit(string iban, string checkDigit)
		{
			return IBAN.getCountryCode(iban) + checkDigit + IBAN.getBban(iban);
		}

		/// <summary>
		/// Calculates
		/// <a href="http://en.wikipedia.org/wiki/ISO_13616#Modulo_operation_on_IBAN">Iban Modulo</a>.
		/// </summary>
		/// <param name="iban"> String value </param>
		/// <returns> modulo 97
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static int calculateMod(final String iban)
		private static int calculateMod(string iban)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String reformattedIban = IBAN.getBban(iban) + IBAN.getCountryCode(iban) + IBAN.getCheckDigits(iban);
			string reformattedIban = IBAN.getBban(iban) + IBAN.getCountryCode(iban) + IBAN.getCheckDigits(iban);
			long total = 0;
			for (int i = 0; i < reformattedIban.Length; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int numericValue = Character.getNumericValue(reformattedIban.charAt(i));
				int numericValue = char.getNumericValue(reformattedIban[i]);
				total = (numericValue > 9 ? total * 100 : total * 10) + numericValue;
				if (total > MAX)
				{
					total = (total % MOD);
				}
			}
			return (int)(total % MOD);
		}

	}
}