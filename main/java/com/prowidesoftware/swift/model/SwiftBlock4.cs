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

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;

	using Gson = com.google.gson.Gson;
	using GsonBuilder = com.google.gson.GsonBuilder;

	/// <summary>
	/// Base class for SWIFT <b>Body Block (block 4)</b>.<br>
	/// This block is where the actual message content is specified 
	/// and is what most users see. Generally the other blocks are 
	/// stripped off before presentation. It mainly contains a list of
	/// tags and its format representation, which is variable 
	/// length and requires use of CRLF as a field delimiter.<br>
	/// 
	/// @author www.prowidesoftware.com
	/// @since 4.0
	/// </summary>
	[Serializable]
	public class SwiftBlock4 : SwiftTagListBlock
	{
		private const long serialVersionUID = -623730182521597955L;

		/// <summary>
		/// Default constructor
		/// </summary>
		public SwiftBlock4() : base()
		{
		}

		/// <summary>
		/// Constructor with tag initialization </summary>
		/// <param name="tags"> the list of tags to initialize </param>
		/// <exception cref="IllegalArgumentException"> if parameter tags is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter tags is not composed of Strings
		/// @since 5.0 </exception>
		public SwiftBlock4(IList<Tag> tags)
		{
			// sanity check
			Validate.notNull(tags, "parameter 'tags' cannot be null");

			this.addTags(tags);
		}

		/// <summary>
		/// Sets the block number. Will cause an exception unless setting block number to 4. </summary>
		/// <param name="blockNumber"> the block number to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not the integer 4
		/// @since 5.0 </exception>
		protected internal override int? BlockNumber
		{
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'blockNumber' cannot be null");
				Validate.isTrue((int)value == 4, "blockNumber must be 4");
			}
		}

		/// <summary>
		/// Sets the block name. Will cause an exception unless setting block number to "4". </summary>
		/// <param name="blockName"> the block name to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not the string "4"
		/// @since 5.0 </exception>
		protected internal override string BlockName
		{
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'blockName' cannot be null");
				Validate.isTrue(value.CompareTo("4") == 0, "blockName must be string '4'");
			}
		}

		/// <summary>
		/// Returns the block number (the value 4 as an integer) </summary>
		/// <returns> Integer containing the block's number </returns>
		public override int? Number
		{
			get
			{
				return Convert.ToInt32(4);
			}
		}

		/// <summary>
		/// Returns the block name (the value 4 as a string) </summary>
		/// <returns> block name
		/// 
		/// @since 5.0 </returns>
		public override string Name
		{
			get
			{
				return ("4");
			}
		}

		/// <summary>
		/// Creates a new block with all empty sequences removed.
		/// <br>
		/// <para>The implementation uses as sequence boundaries the fields: 16R, 16S and 15a.
		/// Two consecutive 16R (start of sequence) and 16S (end of sequence) with the same qualifier 
		/// are considered an empty sequence so both boundary fields 16R and 16S will be dropped. 
		/// For field 15a (start of sequence) there is no end of sequence boundary so if two consecutive
		/// 15a are found, the first one will be dropped. Also a 15a at the end of the block will be 
		/// considered and empty sequence.
		/// 
		/// </para>
		/// </summary>
		/// <param name="b4"> a block with sequences to filter </param>
		/// <returns> a new block containing all tags that are outside a empty 16R/S or 15a sub-block, or null if the parameter block is null
		/// @since 7.8.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SwiftBlock4 removeEmptySequences(final SwiftBlock4 b4)
		public static SwiftBlock4 removeEmptySequences(SwiftBlock4 b4)
		{
			if (b4 == null)
			{
				return null;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Stack<Tag> stack = new java.util.Stack<Tag>();
			Stack<Tag> stack = new Stack<Tag>();
			foreach (Tag t in b4.Tags)
			{
				if (stack.Count > 0 && StringUtils.Equals(t.Name, "16S") && StringUtils.Equals(stack.Peek().Name, "16R") && StringUtils.Equals(stack.Peek().Value, t.Value))
				{
					/*
					 * found an empty 16R 16S pair
					 */
					stack.Pop();
				}
				else if (t.isNumber(15) && stack.Count > 0 && stack.Peek().isNumber(15))
				{
					/*
					 * found two consecutive 15a
					 */
					stack.Pop(); //remove the previous seq start
					stack.Push(t); //keep this new sequence for the moment
				}
				else
				{
					stack.Push(t);
				}
			}
			if (stack.Count > 0 && stack.Peek().isNumber(15))
			{
				/*
				 * if last field is 15a remove it because it is starting
				 * a sequence with no tags.
				 */
				stack.Pop();
			}
			return new SwiftBlock4(new List<>(stack));
		}

		/// <summary>
		/// This method deserializes the JSON data into an block 4 object. </summary>
		/// <seealso cref= #toJson()
		/// @since 7.9.8 </seealso>
		public static SwiftBlock4 fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().create();
			Gson gson = (new GsonBuilder()).create();
			return gson.fromJson(json, typeof(SwiftBlock4));
		}

	}
}