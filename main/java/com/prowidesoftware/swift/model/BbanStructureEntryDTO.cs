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

	using Expose = com.google.gson.annotations.Expose;
	using SerializedName = com.google.gson.annotations.SerializedName;

	/// <summary>
	/// The bban structure entry.
	/// @since 7.9.7
	/// @author psantamarina
	/// </summary>
	public class BbanStructureEntryDTO
	{

		/// <summary>
		/// The Entry type.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SerializedName("entry_type") @Expose private BbanEntryType entryType;
		private BbanEntryType entryType;

		/// <summary>
		/// The character type.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SerializedName("character_type") @Expose private SwiftCharset characterType;
		private SwiftCharset characterType;

		/// <summary>
		/// The length.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SerializedName("length") @Expose private int length;
		private int length;


		/// <summary>
		/// Gets entry type.
		/// </summary>
		/// <returns> the entry type </returns>
		public virtual BbanEntryType getEntryType()
		{
			return entryType;
		}

		/// <summary>
		/// Sets entry type.
		/// </summary>
		/// <param name="entryType"> the entry type </param>
		public virtual void setEntryType(string entryType)
		{
			this.entryType = BbanEntryType.fromString(entryType);
		}

		/// <summary>
		/// Gets character type
		/// </summary>
		/// <returns> the character type. </returns>
		public virtual SwiftCharset CharacterType
		{
			get
			{
				return characterType;
			}
			set
			{
				this.characterType = value;
			}
		}


		/// <summary>
		/// Gets length
		/// </summary>
		/// <returns> the length. </returns>
		public virtual int Length
		{
			get
			{
				return length;
			}
			set
			{
				this.length = value;
			}
		}


	}

}