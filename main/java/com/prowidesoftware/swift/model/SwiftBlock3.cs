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
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Base class for SWIFT <b>User Header Block (block 3)</b>.
	/// <para>This block is optional, and contains special processing instructions.
	/// 
	/// @since 4.0
	/// </para>
	/// </summary>
	[Serializable]
	public class SwiftBlock3 : SwiftTagListBlock
	{
		private const long serialVersionUID = 4377884587811023149L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftBlock3).FullName);

		/// <summary>
		/// Default constructor
		/// </summary>
		public SwiftBlock3() : base()
		{
		}

		/// <summary>
		/// Constructor with tag initialization </summary>
		/// <param name="tags"> the list of tags to initialize
		/// 
		/// @since 5.0 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftBlock3(final java.util.List<Tag> tags)
		public SwiftBlock3(IList<Tag> tags) : this()
		{
			this.addTags(tags);
		}

		/// <summary>
		/// Sets the block number. Will cause an exception unless setting block number to 3. </summary>
		/// <param name="blockNumber"> the block number to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not the integer 3
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void setBlockNumber(final Integer blockNumber)
		protected internal override int? BlockNumber
		{
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'blockNumber' cannot be null");
				Validate.isTrue((int)value == 3, "blockNumber must be 3");
			}
		}

		/// <summary>
		/// Sets the block name. Will cause an exception unless setting block number to "3". </summary>
		/// <param name="blockName"> the block name to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not the string "3"
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void setBlockName(final String blockName)
		protected internal override string BlockName
		{
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'blockName' cannot be null");
				Validate.isTrue(value.CompareTo("3") == 0, "blockName must be string '3'");
			}
		}

		/// <summary>
		/// Returns the block number (the value 3 as an integer) </summary>
		/// <returns> Integer containing the block's number </returns>
		public override int? Number
		{
			get
			{
				return Convert.ToInt32(3);
			}
		}

		/// <summary>
		/// Returns the block name (the value 3 as a string) </summary>
		/// <returns> block name
		/// st
		/// @since 5.0 </returns>
		public override string Name
		{
			get
			{
				return "3";
			}
		}

		/// <summary>
		/// Indicates if the message is a Straight Through Processing (STP) </summary>
		/// <returns> true if the message is STP </returns>
		public virtual bool? STP
		{
			get
			{
				if (containsTag("119") && "STP".Equals(getTagValue("119"), StringComparison.CurrentCultureIgnoreCase))
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		/// This method will generate a MUR field (tag 108) with a timestamp using
		/// current time formatted as yyMMddHHmmssSSSS </summary>
		/// <param name="overwriteIfExist"> when true and field 108 already exist, its value will be overwriten with the generated timestamp
		/// @since 7.8.8 </param>
		public virtual void generateMUR(bool overwriteIfExist)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String MUR = (new java.text.SimpleDateFormat("yyMMddHHmmssSSSS").format(java.util.Calendar.getInstance().getTime()));
			string MUR = ((new SimpleDateFormat("yyMMddHHmmssSSSS")).format(new DateTime().Ticks));
			Tag t = getTagByName("108");
			if (t != null && overwriteIfExist)
			{
				log.fine("block 3 MUR value " + t.Value + " overwritten with generated MUR " + MUR);
				t.Value = MUR;
			}
			else
			{
				append(new Tag("108", MUR));
			}
		}

		/// <returns> a decorated block3 with helper methods to set only expected fields and in proper order
		/// @since 7.10.0 </returns>
		public virtual SwiftBlock3Builder builder()
		{
			return new SwiftBlock3Builder(this);
		}

	  /// <summary>
	  /// This method deserializes the JSON data into an block 3 object. </summary>
	  /// <seealso cref= #toJson()
	  /// @since 7.9.8 </seealso>
		public static SwiftBlock3 fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().create();
			Gson gson = (new GsonBuilder()).create();
			return gson.fromJson(json, typeof(SwiftBlock3));
		}

	}
}