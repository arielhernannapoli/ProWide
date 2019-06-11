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


	/// <summary>
	/// Container for a specific country BBAN structure.
	/// 
	/// <para>BBAN is short for Basic Bank Account Number. It represents a country-specific bank account number.
	/// The BBAN is the last part of the IBAN when used for international funds transfers.
	/// Every country has it's specific BBAN format and length depending on it's own standards.
	/// 
	/// @since 7.9.7
	/// @author psantamarina
	/// </para>
	/// </summary>
	public class BbanStructureDTO
	{
		/// <summary>
		/// The country code.
		/// </summary>
		private string country_code;

		/// <summary>
		/// The validation rules list.
		/// </summary>
		private IList<BbanStructureEntryDTO> validation_rules = null;

		/// <summary>
		/// Gets validation rules list.
		/// </summary>
		/// <returns> the validation rules list. </returns>
		public virtual IList<BbanStructureEntryDTO> Validation_rules
		{
			get
			{
				return validation_rules;
			}
			set
			{
				this.validation_rules = value;
			}
		}


		/// <summary>
		/// Gets country code.
		/// </summary>
		/// <returns> the country code </returns>
		public virtual string Country_coode
		{
			get
			{
				return country_code;
			}
			set
			{
				this.country_code = value;
			}
		}


	}

}