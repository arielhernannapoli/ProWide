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

	using Validate = org.apache.commons.lang3.Validate;


	using Gson = com.google.gson.Gson;
	using GsonBuilder = com.google.gson.GsonBuilder;

	/// <summary>
	/// Base class for SWIFT <b>User "ad-hoc" Blocks</b> (blocks with number other than 1-5 or names).<br>
	/// <br>
	/// The assumption is that these User Defined Blocks are used and defined as tag blocks (meaning
	/// that these blocks behave like a block 3 or 5).<br>
	/// <br>
	/// <b>NOTE:</b> this is not part of SWIFT standard, but seems to be common practice for
	/// users to append some locally defined blocks to annotate messages in a semi-compatible
	/// way (for example: add block 9 for some local information or block "S" for system reference).<br>
	/// <br>
	/// 
	/// @author www.prowidesoftware.com
	/// @since 5.0
	/// </summary>
	[Serializable]
	public class SwiftBlockUser : SwiftTagListBlock
	{
		private const long serialVersionUID = -6506492203870561424L;
		private const string MESSAGE_VALIDATOR = "parameter 'blockNumber' cannot be null";

		/// <summary>
		/// Indicates the position of this user block in a message when persisted.
		/// This value is used to remember the positions of the blocks inside 
		/// a message when persisted. This value may not be set when persistence
		/// is not used and should not be used by clients.
		/// </summary>
		protected internal int? sortKey;

		/// <summary>
		/// Block name. For integer numbered blocks, this will be the block number
		/// converted to string. For other blocks (for example: "S"), this will be
		/// the block real identifier and block number (if requested) will be -1.
		/// 
		/// @since 5.0
		/// </summary>
		protected internal string blockName;

		/// <summary>
		/// Default constructor
		/// 
		/// @since 5.0
		/// </summary>
		public SwiftBlockUser()
		{
			this.BlockName = "0";
		}

		/// <summary>
		/// Constructor for empty numbered user block </summary>
		/// <param name="blockNumber"> the block number to initialize </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockNumber is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter blockNumber is not a valid User Defined Block number (values 6..9)
		/// @since 5.0 </exception>
		public SwiftBlockUser(int? blockNumber)
		{
			// sanity check
			Validate.notNull(blockNumber, MESSAGE_VALIDATOR);
			Validate.isTrue((bool)SwiftBlockUser.isValidName(blockNumber), "'blockNumber' is not a valid User Defined Block number");

			this.BlockNumber = blockNumber;
		}

		/// <summary>
		/// Constructor for numbered user block with tag initialization </summary>
		/// <param name="blockNumber"> the block number to initialize </param>
		/// <param name="tags"> the list of tags to initialize </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockNumber or tags are null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter blockNumber is not a valid User Defined Block number (values 6..9) </exception>
		/// <exception cref="IllegalArgumentException"> if parameter tags is not composed of Strings
		/// @since 5.0 </exception>
		public SwiftBlockUser(int? blockNumber, IList<Tag> tags)
		{
			// sanity check
			Validate.notNull(blockNumber, MESSAGE_VALIDATOR);
			Validate.isTrue((bool)SwiftBlockUser.isValidName(blockNumber), "'blockNumber' is not a valid User Defined Block number");

			this.BlockNumber = blockNumber;
			this.addTags(tags);
		}

		/// <summary>
		/// Constructor for named user block </summary>
		/// <param name="blockName"> the block name to initialize </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not a valid User Defined Block name (single letter)
		/// @since 5.0 </exception>
		public SwiftBlockUser(string blockName)
		{
			// sanity check
			Validate.notNull(blockName, "parameter 'blockName' cannot be null");
			Validate.isTrue((bool)SwiftBlockUser.isValidName(blockName), "'blockName' is not a valid User Defined Block name");

			this.BlockName = blockName;
		}

		/// <summary>
		/// Constructor for named user block with tag initialization </summary>
		/// <param name="blockName"> the block name to initialize </param>
		/// <param name="tags"> the list of tags to initialize </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName or tags are null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not a valid User Defined Block name (single letter) </exception>
		/// <exception cref="IllegalArgumentException"> if parameter tags is not composed of Strings
		/// @since 5.0 </exception>
		public SwiftBlockUser(string blockName, IList<Tag> tags)
		{
			// sanity check
			Validate.notNull(blockName, "parameter 'blockName' cannot be null");
			Validate.isTrue((bool)SwiftBlockUser.isValidName(blockName), "'blockName' is not a valid User Defined Block name");

			this.BlockName = blockName;
			this.addTags(tags);
		}

		/// <summary>
		/// Returns the block number (if it can be converted to an integer, -1 otherwise). </summary>
		/// <returns> Integer containing the block's name as an integer or -1 if the block name is not numeric </returns>
		public override int? Number
		{
			get
			{
				// assume -1 (not numeric) and try to convert
				int? blockNumber = new int?(-1);
				try
				{
					blockNumber = int.decode(blockName);
				}
				catch (NumberFormatException)
				{
				}
				return (blockNumber);
			}
		}

		/// <seealso cref= #getBlockName() </seealso>
		public override string Name
		{
			get
			{
				return (this.BlockName);
			}
		}

		/// <summary>
		/// The block name. </summary>
		/// <returns> the block name
		/// 
		/// @since 5.0 </returns>
		public virtual string BlockName
		{
			get
			{
				return (this.blockName);
			}
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'blockName' cannot be null");
				Validate.isTrue((bool)SwiftBlockUser.isValidName(value), "'" + value + "' is not a valid User Defined Block name");
    
				// store the new name
				this.blockName = value;
			}
		}

		/// <summary>
		/// Sets the block number. This really sets <code><seealso cref="#blockName"/></code> </summary>
		/// <param name="blockNumber"> the block number to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockNumber is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter blockNumber is not a valid User Defined Block number (values 6..9)
		/// @since 5.0 </exception>
		protected internal override int? BlockNumber
		{
			set
			{
				// sanity check
				Validate.notNull(value, MESSAGE_VALIDATOR);
				Validate.isTrue((bool)SwiftBlockUser.isValidName(value), "'" + value + "' is not a valid User Defined Block number");
    
				this.blockName = value != null ? value.ToString() : null;
			}
		}


		/// <summary>
		/// Checks if the block name (and or number) is valid for a user defined block.
		/// The block name is considered valid if its numeric value is other than 1-5 and
		/// if its named identification value is a one char string, for example "S". </summary>
		/// <returns> true if the block name and number are valid 
		/// 
		/// @since 5.0 </returns>
		protected internal virtual bool? ValidName
		{
			get
			{
				return (SwiftBlockUser.isValidName(this.Name, this.Number));
			}
		}

		/// <summary>
		/// Checks if the block name and are valid for a user defined block. </summary>
		/// <param name="blockName"> the block name </param>
		/// <param name="blockNumber"> the block number </param>
		/// <returns> true if the block name and number are valid 
		/// 
		/// @since 5.0 </returns>
		public static bool? isValidName(string blockName, int? blockNumber)
		{
			return Convert.ToBoolean((bool)SwiftBlockUser.isValidName(blockName) && (bool)SwiftBlockUser.isValidName(blockNumber));
		}

		/// <summary>
		/// Checks if the block name is valid for a user defined block. </summary>
		/// <param name="blockName"> the block name </param>
		/// <returns> true if the block name and number are valid 
		/// 
		/// @since 5.0 </returns>
		public static bool? isValidName(string blockName)
		{
			// name and number must be defined
			if (blockName == null)
			{
				return (false);
			}

			// try as a number
			try
			{
				int? num = int.decode(blockName);
				if (!(bool)SwiftBlockUser.isValidName(num))
				{
					return (false);
				}
			}
			catch (NumberFormatException)
			{
				// do nothing (it was not a number)
			}

			// for named blocks, the name must be only one letter
			if (blockName.Length != 1)
			{
				return (false);
			}

			// only upper or lower case letters
			char c = char.ToLower(blockName[0]);
			if (!(('0' <= c && c <= '9') || ('a' <= c && c <= 'z')))
			{
				return (false);
			}

			return (true);
		}

		/// <summary>
		/// Checks if the block number is valid for a user defined block.
		/// Invalid blocks are blocks null or values 1-5 inclusive, all other values are considered valid.
		/// </summary>
		/// <param name="blockNumber"> the block number </param>
		/// <returns> true if the block name and number are valid 
		/// 
		/// @since 5.0 </returns>
		public static bool? isValidName(int? blockNumber)
		{
			// name and number must be defined
			if (blockNumber == null)
			{
				return (false);
			}

			// block number must not be 1-5
			if ((int)blockNumber != -1)
			{
				if (1 <= (int)blockNumber && (int)blockNumber <= 5)
				{
					return (false);
				}
			}

			return (true);
		}

		/// <summary>
		/// get the sortkey of this user block when persisted </summary>
		/// <returns> an integer with the current sortkey </returns>
		/// <seealso cref= #sortKey </seealso>
		public virtual int? SortKey
		{
			get
			{
				return (sortKey);
			}
			set
			{
				this.sortKey = value;
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
			if (!base.Equals(o))
			{
				return false;
			}
			SwiftBlockUser tags = (SwiftBlockUser) o;
			return Objects.Equals(sortKey, tags.sortKey) && Objects.Equals(blockName, tags.blockName);
		}

		public override int GetHashCode()
		{
			return Objects.hash(base.GetHashCode(), sortKey, blockName);
		}

		/// <summary>
		/// This method deserializes the JSON data into an user block object. </summary>
		/// <seealso cref= #toJson()
		/// @since 7.9.8 </seealso>
		public static SwiftBlockUser fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().create();
			Gson gson = (new GsonBuilder()).create();
			return gson.fromJson(json, typeof(SwiftBlockUser));
		}
	}

}