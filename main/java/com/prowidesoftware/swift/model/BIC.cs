using System;
using System.Collections.Generic;
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

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using IsoUtils = com.prowidesoftware.swift.utils.IsoUtils;
	using StringUtils = org.apache.commons.lang3.StringUtils;

	/// <summary>
	/// Helper class to process BIC information.
	/// 
	/// <para>Bank Identifier Codes (also known as SWIFT-BIC, BIC, SWIFT ID or SWIFT code) is a unique identification code for
	/// both financial and non-financial institutions. When assigned to a non-financial institution, the code may also be
	/// known as a Business Entity Identifier or BEI.
	/// 
	/// </para>
	/// <para>It is composed by:
	/// <ul>
	/// 	<li>4 letters: institution code or bank code.
	/// 	<li>2 letters: ISO 3166-1 alpha-2 country code
	/// 	<li>2 letters or digits: location code
	/// 	<li>3 letters: branch code
	/// </ul>
	/// 
	/// @since 3.3
	/// </para>
	/// </summary>
	public class BIC
	{
		/// <summary>
		/// Fake "test &amp; training" BIC with 8 chars for testing
		/// @since 7.6
		/// </summary>
		[NonSerialized]
		public const string TEST8 = "TESTARZZ";

		private class TypeTokenAnonymousInnerClassHelper : com.google.gson.reflect.TypeToken<IList<BbanStructureDTO>>
		{
			public TypeTokenAnonymousInnerClassHelper()
			{
			}

		}

		/// <summary>
		/// Fake Logical terminal address for testing,
		/// consisting of a fake "test &amp; training" BIC of 12 chars
		/// (including the terminal identification)
		/// 
		/// @since 7.6 </summary>
		/// <seealso cref= SwiftBlock1#getLogicalTerminal() </seealso>
		[NonSerialized]
		public const string TEST12 = "TESTARZZAXXX";

		/// <summary>
		/// Constant value with which all partner bics start 
		/// @since 7.8
		/// </summary>
		public const string PARTNER_PREFIX = "PTS";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) private String invalidCause = null;
		[Obsolete]
		private string invalidCause = null;

		private string institution_Renamed = null;
		private string country_Renamed = null;
		private string location = null;
		protected internal string branch = null;
		private string subtype = null;

		/// <summary>
		/// Constructor with a BIC8 or BIC11 code.
		/// 
		/// <para>For BIC codes with 12 characters (meaning it includes the logical terminal identifier) use
		/// <seealso cref="LogicalTerminalAddress"/> instead. This implementation will drop the LT identifier if a
		/// 12 characters full logical terminal addess is passed as parameter.
		/// 
		/// </para>
		/// <para>If the code is longer than 11 characters, the remainder will be store as part of the branch code.
		/// 
		/// </para>
		/// </summary>
		/// <param name="bic"> the BIC code to use in this BIC (8 or 11 chars) </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public BIC(final String bic)
		public BIC(string bic) : base()
		{
			parse(bic);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void parse(final String bic)
		protected internal virtual void parse(string bic)
		{
			if (bic != null)
			{
				this.institution_Renamed = StringUtils.trimToNull(StringUtils.Substring(bic,0, 4));
				this.country_Renamed = StringUtils.trimToNull(StringUtils.Substring(bic,4, 6));
				this.location = StringUtils.trimToNull(StringUtils.Substring(bic,6, 8));
				if (bic.Length >= 12)
				{
					// drop LT identifier
					this.branch = StringUtils.trimToNull(StringUtils.Substring(bic, 9 - bic));
				}
				else
				{
					this.branch = StringUtils.trimToNull(StringUtils.Substring(bic, 8 - bic));
				}
			}
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		public BIC() : base()
		{
		}

		/// <summary>
		/// Get a string with information about why the BIC was found invalid </summary>
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
		/// Validates the BIC structure.
		/// 
		/// <para>If the code is not valid a text description of the invalid cause is set in <seealso cref="#getInvalidCause()"/>
		/// 
		/// </para>
		/// </summary>
		/// <seealso cref= #validate() for details regarding the validation checks or if you need structured details of the validation
		/// problem found.
		/// </seealso>
		/// <returns> true if the BIC is valid and false otherwise </returns>
		public virtual bool Valid
		{
			get
			{
				BicValidationResult result = validate();
				if (result == BicValidationResult.OK)
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
		/// Validates the BIC structure.
		/// 
		/// <para>Checks the syntax of the BIC, verifying: the total length is 8, 11 or 12 (LT identifier), the country is a
		/// valid ISO country code using <seealso cref="IsoUtils"/>, the institution is composed by upper case letters and the
		/// location and branch are composed by upper case letter or digits.
		/// 
		/// </para>
		/// <para>This method does not validate against any BIC directory.
		/// 
		/// </para>
		/// </summary>
		/// <returns> BicValidationResult with detailed information of the validation problem found
		/// @since 7.10.3 </returns>
		public virtual BicValidationResult validate()
		{
			if (this.institution_Renamed == null || this.country_Renamed == null || this.location == null)
			{
				return BicValidationResult.INVALID_LENGTH;
			}
			if (this.institution_Renamed.Length != 4)
			{
				BicValidationResult result = BicValidationResult.INVALID_INSTITUTION_LENGTH;
				result.Found = this.institution_Renamed;
				return result;
			}
			if (this.country_Renamed.Length != 2)
			{
				BicValidationResult result = BicValidationResult.INVALID_COUNTRY_LENGTH;
				result.Found = this.country_Renamed;
				return result;
			}
			if (this.location.Length != 2)
			{
				BicValidationResult result = BicValidationResult.INVALID_LOCATION_LENGTH;
				result.Found = this.location;
				return result;
			}
			if (this.branch != null && this.branch.Length != 3)
			{
				BicValidationResult result = BicValidationResult.INVALID_BRANCH_LENGTH;
				result.Found = this.branch;
				return result;
			}
			if (!isUpperCase(this.institution_Renamed))
			{
				BicValidationResult result = BicValidationResult.INVALID_INSTITUTION_CHARSET;
				result.Found = this.institution_Renamed;
				return result;
			}
			if (!IsoUtils.Instance.isValidISOCountry(this.country_Renamed))
			{
				BicValidationResult result = BicValidationResult.INVALID_COUNTRY;
				result.Found = this.country_Renamed;
				return result;
			}
			if (!isUpperCaseOrDigit(this.location))
			{
				BicValidationResult result = BicValidationResult.INVALID_LOCATION_CHARSET;
				result.Found = this.location;
				return result;
			}
			if (this.branch != null && !isUpperCaseOrDigit(this.branch))
			{
				BicValidationResult result = BicValidationResult.INVALID_BRANCH_CHARSET;
				result.Found = this.branch;
				return result;
			}
			return BicValidationResult.OK;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private boolean isUpperCase(final String text)
		private bool isUpperCase(string text)
		{
			for (int i = 0; i < text.Length; i++)
			{
				if (!char.IsUpper(text[i]))
				{
					return false;
				}
			}
			return true;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private boolean isUpperCaseOrDigit(final String text)
		private bool isUpperCaseOrDigit(string text)
		{
			for (int i = 0; i < text.Length; i++)
			{
				if (!char.IsUpper(text[i]) && !char.IsDigit(text[i]))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// It returns the last three that conform the branch or null if branch is not present.
		/// 
		/// @since 7.8.5 </summary>
		/// <returns> the BIC's branch part or null if not found. </returns>
		public virtual string Branch
		{
			get
			{
				return this.branch;
			}
			set
			{
				this.branch = value;
			}
		}

		/// <summary>
		/// Returns the branch code or XXX as default
		/// @since 7.10.3
		/// @return
		/// </summary>
		public virtual string BranchOrDefault
		{
			get
			{
				return this.branch != null? this.branch : "XXX";
			}
		}

		/// <summary>
		/// Returns ths subtype code.
		/// Notice this information is not part of the BIC code, it must be explicitly set with <seealso cref="#setSubtype(String)"/>
		/// @since 7.4
		/// </summary>
		public virtual string Subtype
		{
			get
			{
				return subtype;
			}
			set
			{
				this.subtype = value;
			}
		}


		/// <summary>
		/// Returns true if the BIC is a Test &amp; Training BIC code.
		/// <para>In SWIFT’s FIN messaging system, a BIC with a zero in the 8th position is a Test &amp; Training BIC, and as
		/// such it cannot be used in production FIN messages.
		/// 
		/// </para>
		/// </summary>
		/// <returns> true if it is a Test &amp; Training BIC, false if is not or if the condition cannot be determined
		/// @since 7.6 </returns>
		public virtual bool TestAndTraining
		{
			get
			{
				if (this.location != null)
				{
					return this.location[1] == '0';
				}
				return false;
			}
		}

		/// <summary>
		/// Returns true if the BIC is not live (not connected) on the network.
		/// 
		/// <para>BICs can identify not only financial institutions but also non-financial ones
		/// either connected or not connected to the SWIFT network.
		/// 
		/// </para>
		/// <para>A BIC of an institution which is <strong>not connected</strong> to the SWIFT network
		/// still has a location code with the digit 1 at the end (for instance AFSEUS31). 
		/// BICs like that are called non-SWIFT BICs (or BIC 1).
		/// 
		/// </para>
		/// <para>In SWIFT’s FIN messaging system, a BIC with a one in the 8th position is a Non-Live BIC.
		/// 
		/// </para>
		/// <para>Note this is not the opposite of <seealso cref="#isLive()"/>
		/// 
		/// </para>
		/// </summary>
		/// <returns> true if it is a Non-Live BIC, false if is not or if the condition cannot be determined
		/// @since 7.7 </returns>
		public virtual bool NonLive
		{
			get
			{
				if (this.location != null)
				{
					return this.location[1] == '1';
				}
				return false;
			}
		}

		/// <summary>
		/// Returns true if the BIC is live (connected and not test &amp; training) on the network.
		/// 
		/// <para>BICs can identify not only financial institutions but also non-financial ones
		/// either connected or not connected to the SWIFT network.
		/// 
		/// </para>
		/// <para>In SWIFT’s FIN messaging system, a BIC with a character different than zero (that would be Test &amp;
		/// Training) or one (that would be non-connected) in the 8th position is a Live BIC.
		/// 
		/// </para>
		/// <para>Note this is not the opposite of <seealso cref="#isNonLive()"/>
		/// 
		/// </para>
		/// </summary>
		/// <returns> true if it is a Non-Live BIC, false if is not or if the condition cannot be determined
		/// @since 7.7 </returns>
		public virtual bool Live
		{
			get
			{
				if (this.location != null)
				{
					return this.location[1] != '0' && this.location[1] != '1';
				}
				return false;
			}
		}

		/// <summary>
		/// Returns the first 8 characters of the BIC code, composed by the institution code, country and location.
		/// </summary>
		/// <returns> the bic8 or null if the BIC has less than 8 characters
		/// @since 7.6 </returns>
		public virtual string Bic8
		{
			get
			{
				if (this.institution_Renamed != null && this.country_Renamed != null && this.location != null)
				{
					return this.institution_Renamed + this.country_Renamed + this.location;
				}
				else
				{
					return null;
				}
			}
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}
			BIC bic = (BIC) o;
			return Objects.Equals(institution_Renamed, bic.institution_Renamed) && Objects.Equals(country_Renamed, bic.country_Renamed) && Objects.Equals(location, bic.location) && Objects.Equals(branch, bic.branch) && Objects.Equals(subtype, bic.subtype);
		}

		public override int GetHashCode()
		{
			return Objects.hash(institution_Renamed, country_Renamed, location, branch, subtype);
		}

		/// <summary>
		/// Returns the BIC code with 11 characters composed by institution code, country, location and branch.
		/// <para>If the branch is not present, then XXX will be used as default branch.
		/// 
		/// </para>
		/// </summary>
		/// <returns> the bic11 or null if the BIC has less than 8 characters
		/// @since 7.6 </returns>
		public virtual string Bic11
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String bic8 = getBic8();
				string bic8 = Bic8;
				if (bic8 != null)
				{
					return bic8 + BranchOrDefault;
				}
				return null;
			}
		}

		/// <summary>
		/// @since 7.7 </summary>
		/// @deprecated use <seealso cref="#getCountry()"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) @Deprecated public String country()
		[Obsolete]
		public virtual string country()
		{
			return Country;
		}

		/// <summary>
		/// @since 7.8.5 </summary>
		/// @deprecated use <seealso cref="#getInstitution()"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) @Deprecated public String institution()
		[Obsolete]
		public virtual string institution()
		{
			return Institution;
		}

		/// <summary>
		/// Returns the Distinguished Name (DN) for this BIC.
		/// 
		/// <para>The created DN always includes the BIC8 and "swift" and
		/// if the branch is present and not "XXX" it will also be included
		/// as organization unit (ou)
		/// 
		/// </para>
		/// </summary>
		/// <returns> ou=&lt;branch&gt;,o=&lt;bic8&gt;,o=swift
		/// @since 7.9.3 </returns>
		public virtual string distinguishedName()
		{
			StringBuilder result = new StringBuilder();
			if (this.branch != null && !this.branch.Equals("XXX"))
			{
				result.Append("ou=").Append(StringUtils.lowerCase(this.branch)).Append(",");
			}
			result.Append("o=").Append(StringUtils.lowerCase(Bic8)).Append(",o=swift");
			return result.ToString();
		}

		public override string ToString()
		{
			return Bic11;
		}

		/// <summary>
		/// @since 7.10.3 </summary>
		/// <returns> the institution identifier part of the BIC </returns>
		public virtual string Institution
		{
			get
			{
				return institution_Renamed;
			}
			set
			{
				this.institution_Renamed = value;
			}
		}


		/// <summary>
		/// @since 7.10.3 </summary>
		/// <returns> the country part of the BIC </returns>
		public virtual string Country
		{
			get
			{
				return country_Renamed;
			}
			set
			{
				this.country_Renamed = value;
			}
		}


		/// <summary>
		/// @since 7.10.3 </summary>
		/// <returns> the location part of the BIC </returns>
		public virtual string Location
		{
			get
			{
				return location;
			}
			set
			{
				this.location = value;
			}
		}



	}
}