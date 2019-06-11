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

	using Gson = com.google.gson.Gson;
	using GsonBuilder = com.google.gson.GsonBuilder;
	using TypeToken = com.google.gson.reflect.TypeToken;
	using Lib = com.prowidesoftware.swift.utils.Lib;
	using StringUtils = org.apache.commons.lang3.StringUtils;



	/// <summary>
	/// This singleton handles all the available BBAN structure entries.
	/// 
	/// <para>BBAN is short for Basic Bank Account Number. It represents a country-specific bank account number.
	/// The BBAN is the last part of the IBAN when used for international funds transfers.
	/// Every country has it's specific BBAN format and length depending on it's own standards.
	/// 
	/// @since 7.9.7
	/// @author psantamarina
	/// </para>
	/// </summary>
	public class BbanStructureValidations
	{
		[NonSerialized]
		private static final java;

		private static BbanStructureValidations instance = null;

		private static final Type REVIEW_TYPE = new TypeTokenAnonymousInnerClassHelper()
		.Type;
		private static string JSON_FILE = "BbanStructureValidations.json";

		private IList<BbanStructureDTO> bbanStructures = null;

		private BbanStructureValidations()
		{
			Gson gson = (new GsonBuilder()).registerTypeAdapter(typeof(BbanEntryType), new BbanEntryTypeDeserializer()).create();
			string reader = null;
			try
			{
				reader = Lib.readResource(JSON_FILE,null);
			}
			catch (IOException e)
			{
				log.log(Level.SEVERE, "Cannot load " + JSON_FILE + " from classpath, the BBAN structure validations will be initialized empty", e);
			}
			if (reader != null)
			{
				this.bbanStructures = gson.fromJson(reader, REVIEW_TYPE);
			}
		}

		public static BbanStructureValidations Instance
		{
			if (instance == null)
			{
				instance = new BbanStructureValidations();
			}
			return instance;
		}

		/// <summary>
		/// Gets the BBAN structure entries </summary>
		/// <returns> the list of all available BBAN structures entries. </returns>
		public IList<BbanStructureDTO> BbanStructures
		{
			return bbanStructures;
		}

		/// <summary>
		/// Sets the BBAN structure entries </summary>
		/// <param name="bbanStructures"> the list of BBAN structures entries to set. </param>
		/// <seealso cref= #add(BbanStructureDTO) </seealso>
		public void setBbanStructures(IList<BbanStructureDTO> bbanStructures)
		{
			this.bbanStructures = bbanStructures;
		}

		/// <summary>
		/// Gets the specific BBAN structure for a given country code. </summary>
		/// <param name="countryCode"> the country code to search (two letters ISO country code) </param>
		/// <returns> BbanStructure for specified country or null if country is not supported. </returns>
		/// <seealso cref= #contains(String) </seealso>
		public BbanStructureDTO forCountry(final string countryCode)
		{
			BbanStructureDTO bbanStructure = null;
			if (this.bbanStructures != null)
			{
				foreach (BbanStructureDTO structure in this.bbanStructures)
				{
					if (StringUtils.Equals(structure.Country_coode, countryCode))
					{
						bbanStructure = structure;
						break;
					}
				}
			}
			return bbanStructure;
		}

		/// <summary>
		/// Checks if the given country is configured for BBAN validations </summary>
		/// <param name="countryCode"> the country code to check (two letters ISO country code) </param>
		/// <returns> true if a BBAN structure exists for the given country </returns>
		public bool contains(final string countryCode)
		{
			return supportedCountries().Contains(countryCode);
		}

		/// <summary>
		/// Gets the list of countries configured for BBAN validation
		/// </summary>
		public IList<string> supportedCountries()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<String> countryCodes = new java.util.ArrayList<>(bbanStructures.size());
			IList<string> countryCodes = new List<string>(bbanStructures.Count);
			foreach (BbanStructureDTO structure in this.bbanStructures)
			{
				countryCodes.Add(structure.Country_coode);
			}
			return Collections.unmodifiableList(countryCodes);
		}

		/// <summary>
		/// Adds a new country BBAN structure configuration </summary>
		/// <param name="bbanStructure"> the specific BBAN configuration to add </param>
		public BbanStructureValidations add(final BbanStructureDTO bbanStructure)
		{
			if (this.bbanStructures == null)
			{
				this.bbanStructures = new List<BbanStructureDTO>();
			}
			if (contains(bbanStructure.Country_coode))
			{
				log.warning("Duplicate BBAN configuration for country " + bbanStructure.Country_coode);
			}
			this.bbanStructures.Add(bbanStructure);
			return this;
		}

	}
}