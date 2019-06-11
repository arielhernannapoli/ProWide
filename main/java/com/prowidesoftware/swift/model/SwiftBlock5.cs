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
	/// Base class for SWIFT <b>Trailer Block (block 5)</b>.
	/// 
	/// <para>Each SWIFT message has one or more trailers as required by
	/// the message exchange and security requirements. 
	/// System trailers, if applicable, follow user trailers.<br>
	/// 
	/// @since 4.0
	/// </para>
	/// </summary>
	[Serializable]
	public class SwiftBlock5 : SwiftTagListBlock
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(SwiftBlock5.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftBlock5).FullName);
		private const long serialVersionUID = 3114133378482486859L;

		/// <summary>
		/// Default constructor
		/// </summary>
		public SwiftBlock5() : base()
		{
		}

		/// <summary>
		/// Constructor with tag initialization </summary>
		/// <param name="tags"> the list of tags to initialize </param>
		/// <exception cref="IllegalArgumentException"> if parameter tags is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter tags is not composed of Strings
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftBlock5(final java.util.List<Tag> tags)
		public SwiftBlock5(IList<Tag> tags)
		{
			// sanity check
			Validate.notNull(tags, "parameter 'tags' cannot be null");

			this.addTags(tags);
		}

		/// <summary>
		/// Sets the block number. Will cause an exception unless setting block number to 5. </summary>
		/// <param name="blockNumber"> the block number to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not the integer 5
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void setBlockNumber(final Integer blockNumber)
		protected internal override int? BlockNumber
		{
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'blockNumber' cannot be null");
				Validate.isTrue((int)value == 5, "blockNumber must be 5");
			}
		}

		/// <summary>
		/// Sets the block name. Will cause an exception unless setting block number to "5". </summary>
		/// <param name="blockName"> the block name to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not the string "5"
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void setBlockName(final String blockName)
		protected internal override string BlockName
		{
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'blockName' cannot be null");
				Validate.isTrue(value.CompareTo("5") == 0, "blockName must be string '5'");
			}
		}

		/// <summary>
		/// Returns the block number (the value 5 as an integer) </summary>
		/// <returns> Integer containing the block's number </returns>
		public override int? Number
		{
			get
			{
				return Convert.ToInt32(5);
			}
		}

		/// <summary>
		/// Returns the block name (the value 5 as a string) </summary>
		/// <returns> block name
		/// 
		/// @since 5.0 </returns>
		public override string Name
		{
			get
			{
				return "5";
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a block 5 object. </summary>
		/// <seealso cref= #toJson()
		/// @since 7.9.8 </seealso>
		public static SwiftBlock5 fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().create();
			Gson gson = (new GsonBuilder()).create();
			return gson.fromJson(json, typeof(SwiftBlock5));
		}

	}
}