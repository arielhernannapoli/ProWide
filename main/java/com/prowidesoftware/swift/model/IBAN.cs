using System;
using System.Text;

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

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using StringUtils = org.apache.commons.lang3.StringUtils;

	/// <summary>
	/// Utility class to validate IBAN codes.
	/// <para>
	/// The IBAN consists of a ISO 3166-1 alpha-2 country code, followed by two check
	/// digits (represented by kk in the examples below), and up to thirty alphanumeric
	/// characters for the domestic bank account number, called the BBAN (Basic Bank
	/// Account Number).
	/// </para>
	/// <para>
	/// Exampe usage scenario<br>
	/// <pre>IBAN iban = new IBAN("ES2153893489");
	/// if (iban.isValid())
	/// 		System.out.println("ok");
	/// else
	/// 		System.out.println("problem with iban: "+iban.getInvalidCause());
	/// </pre>
	/// 
	/// @since 3.3
	/// </para>
	/// </summary>
	public class IBAN
	{
		[NonSerialized]
		private static final java;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) private String invalidCause = null;
		[Obsolete]
		private string invalidCause = null;

		private string iban;

		private const int COUNTRY_CODE_INDEX = 0;
		internal const int COUNTRY_CODE_LENGTH = 2;
		private const int CHECK_DIGIT_INDEX = COUNTRY_CODE_LENGTH;
		internal const int CHECK_DIGIT_LENGTH = 2;
		private static readonly int BBAN_INDEX = CHECK_DIGIT_INDEX + CHECK_DIGIT_LENGTH;
		private const string INVALIDA_IBAN_LENGTH = "Invalid IBAN length in";

		/// <summary>
		/// Get the IBAN </summary>
		/// <returns> a string with the IBAN </returns>
		public virtual string Iban
		{
			get
			{
				return iban;
			}
			set
			{
				this.iban = value;
			}
		}


		/// <summary>
		/// Create an IBAN object with the given iban code.
		/// This constructor does not perform any validation on the iban, only </summary>
		/// <param name="iban"> </param>
		public IBAN(string iban)
		{
			this.iban = iban;
		}

		/// <summary>
		/// Checks if the IBAN number is valid.
		/// <para>If the number is not valid a text description of the invalid cause is set in <seealso cref="#getInvalidCause()"/>
		/// 
		/// </para>
		/// </summary>
		/// <seealso cref= #validate() for details regarding the validation checks or if you need structured details of the validation
		/// problem found.
		/// </seealso>
		/// <returns> <code>true</code> if the IBAN is valid and <code>false</code> in other case </returns>
		public virtual bool Valid
		{
			get
			{
				IbanValidationResult result = validate();
				if (result == IbanValidationResult.OK)
				{
					return true;
				}
				else
				{
					this.invalidCause = result.message();
					return false;
				}
			}
		}

		/// <summary>
		/// Check an IBAN number throwing an exception with validation details if it is not valid.
		/// 
		/// <para>Validates that the length is at least 5 chars: composed by a valid 2 letters ISO country code,
		/// 2 verifying digits, and 1 BBAN. The verification digits are also computed and verified.
		/// For the BBAN validation the specific per country structure must be defined either in the
		/// BbanStructureValidations.json file or by API in the <seealso cref="BbanStructureValidations"/> instance.
		/// 
		/// </para>
		/// </summary>
		/// <returns> IbanFormatStatus with detailed information of the validation problem found </returns>
		public virtual IbanValidationResult validate()
		{
			if (iban == null)
			{
				return IbanValidationResult.IBAN_IS_NULL;
			}
			if (iban.Length == 0)
			{
				return IbanValidationResult.IBAN_IS_EMPTY;
			}

			IbanValidationResult result = null;
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String code = removeNonAlpha(this.iban);
				string code = removeNonAlpha(this.iban);

				result = IbanValidationUtils.validateCountryCode(code);

				if (result == null)
				{
					result = IbanValidationUtils.validateCheckDigitPresence(code);
				}

				if (result == null)
				{
					result = IbanValidationUtils.validateBbanPresence(code);
				}

				if (result == null)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String bban = getBban(code);
					string bban = getBban(code);

					result = IbanValidationUtils.validateBbanMaxLength(bban);

					if (result == null)
					{
						/*
						 * load specific structure for country
						 */
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String country = getCountryCode(code);
						string country = getCountryCode(code);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final BbanStructureDTO structure = BbanStructureValidations.getInstance().forCountry(country);
						BbanStructureDTO structure = BbanStructureValidations.Instance.forCountry(country);
						if (structure == null)
						{
							result = IbanValidationResult.MISSING_BBAN_CONFIGURATION;
							result.Found = country;
						}
						else
						{
							result = IbanValidationUtils.validateBban(bban, structure);
						}
					}
				}

				if (result == null)
				{
					result = IbanValidationUtils.validateCharacters(code);
				}
				if (result == null)
				{
					result = IbanValidationUtils.validateCheckDigit(code);
				}

			}
			catch (Exception)
			{
				return IbanValidationResult.UNKNOWN;
			}

			if (result != null)
			{
				return result;
			}
			else
			{
				return IbanValidationResult.OK;
			}
		}

		/// @deprecated use <seealso cref="IBAN#translateChars(StringBuilder)"/> 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="IBAN#translateChars(StringBuilder)"/>") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public String translateChars(final StringBuffer bban)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use <seealso cref="IBAN#translateChars(StringBuilder)"/>")]
		public virtual string translateChars(StringBuilder bban)
		{
			DeprecationUtils.phase2(this.GetType(), "translateChars(StringBuffer)", "Use translateChars(StringBuilder) instead.");
			return translateChars(new StringBuilder(bban));
		}

		/// <summary>
		/// Translate letters to numbers, also ignoring non alphanumeric characters
		/// </summary>
		/// <param name="bban"> </param>
		/// <returns> the translated value </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String translateChars(final StringBuilder bban)
		public virtual string translateChars(StringBuilder bban)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder result = new StringBuilder();
			StringBuilder result = new StringBuilder();
			for (int i = 0;i < bban.Length;i++)
			{
				char c = bban[i];
				if (char.IsLetter(c))
				{
					result.Append(char.getNumericValue(c));
				}
				else
				{
					result.Append((char)c);
				}
			}
			return result.ToString();
		}

		/// 
		/// <param name="iban"> </param>
		/// <returns> the resulting IBAN </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String removeNonAlpha(final String iban)
		public virtual string removeNonAlpha(string iban)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder result = new StringBuilder();
			StringBuilder result = new StringBuilder();
			for (int i = 0;i < iban.Length;i++)
			{
				char c = iban[i];
				if (char.IsLetter(c) || char.IsDigit(c))
				{
					result.Append((char)c);
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Get a string with information about why the IBAN was found invalid </summary>
		/// <returns> a human readable (english) string </returns>
		/// @deprecated use the <seealso cref="#validate()"/> method to get a detailed result of the validation problem found 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use the <seealso cref="#validate()"/> method to get a detailed result of the validation problem found") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public String getInvalidCause()
		[Obsolete("use the <seealso cref="#validate()"/> method to get a detailed result of the validation problem found")]
		public virtual string InvalidCause
		{
			get
			{
				return invalidCause;
			}
		}

		/// <summary>
		/// Gets the BBAN (custom account number) part of the IBAN </summary>
		/// <returns> the custom account part of the IBAN or null if the IBAN has an invalid length
		/// @since 7.9.7
		/// @author psantamarina </returns>
		public virtual string Bban
		{
			get
			{
				if (StringUtils.isNotEmpty(this.iban))
				{
					try
					{
						return getBban(this.iban);
					}
					catch (System.IndexOutOfRangeException e)
					{
						log.log(Level.FINER, INVALIDA_IBAN_LENGTH + this.iban, e);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Gets the BBAN (custom account number) part of the given IBAN
		/// </summary>
		/// <param name="iban"> a well-formed IBAN </param>
		/// <returns> the custom account part of the IBAN </returns>
		/// <exception cref="IndexOutOfBoundsException"> if the IBAN length is wrong
		/// @since 7.9.7
		/// @author psantamarina </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String getBban(final String iban) throws IndexOutOfBoundsException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string getBban(string iban)
		{
			return iban.Substring(BBAN_INDEX);
		}

		/// <summary>
		/// Gets the check digits part of the IBAN </summary>
		/// <returns> the check digits (two digits as String) of the IBAN or null if the IBAN has an invalid length
		/// @since 7.9.7
		/// @author psantamarina </returns>
		public virtual string CheckDigits
		{
			get
			{
				if (StringUtils.isNotEmpty(this.iban))
				{
					try
					{
						return getCheckDigits(this.iban);
					}
					catch (System.IndexOutOfRangeException e)
					{
						log.log(Level.FINER, INVALIDA_IBAN_LENGTH + this.iban, e);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Gets the check digits part of the given IBAN.
		/// </summary>
		/// <param name="iban"> a well-formed IBAN </param>
		/// <returns> the check digits (two digits as String) </returns>
		/// <exception cref="IndexOutOfBoundsException"> if the IBAN length is wrong
		/// @since 7.9.7
		/// @author psantamarina </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String getCheckDigits(final String iban) throws IndexOutOfBoundsException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string getCheckDigits(string iban)
		{
			return iban.Substring(CHECK_DIGIT_INDEX, CHECK_DIGIT_LENGTH);
		}

		/// <summary>
		/// Gets the country code part of the IBAN </summary>
		/// <returns> the two letters ISO country code of the IBAN or null if the IBAN has an invalid length
		/// @since 7.9.7
		/// @author psantamarina </returns>
		public virtual string CountryCode
		{
			get
			{
				if (StringUtils.isNotEmpty(this.iban))
				{
					try
					{
						return getCountryCode(this.iban);
					}
					catch (System.IndexOutOfRangeException e)
					{
						log.log(Level.FINER, INVALIDA_IBAN_LENGTH + this.iban, e);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Gets the country code part of the given IBAN.
		/// </summary>
		/// <param name="iban"> a well-formed IBAN </param>
		/// <returns> the two letters ISO country code </returns>
		/// <exception cref="IndexOutOfBoundsException"> if the IBAN length is wrong
		/// @since 7.9.7
		/// @author psantamarina </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static String getCountryCode(final String iban) throws IndexOutOfBoundsException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static string getCountryCode(string iban)
		{
			return iban.Substring(COUNTRY_CODE_INDEX, COUNTRY_CODE_LENGTH);
		}

	}
}