﻿/*
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
namespace com.prowidesoftware.swift.io.parser
{

	/// <summary>
	/// Container class for MT parser parameters.
	/// This can be passed to the parser to control fine grain details of the process.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8
	/// </summary>
	public class SwiftParserConfiguration
	{
		private bool lenient = true;
		private bool parseTextBlock = true;
		private bool parseTrailerBlock = true;
		private bool parseUserBlock = true;

		/// <summary>
		/// Indicates whether the parser is permissive or not. Defaults to true, meaning the parser will do a best effort
		/// to read as much from the message content as possible regardless of the content and block boundaries beeing valid
		/// or not. For instance, it will read the headers even if the value length is incorrect, and it will read the text
		/// block (block 4) even if it is missing the closing hyphen and bracket.
		/// 
		/// <para>When set to false, the parser will be strict, and will throw <seealso cref="IllegalArgumentException"/> when the headers
		/// block 1 and 2 have an incorrect value and when a block is not properly ended with the closing bracket or with
		/// the hyphen plus bracket in case of the block 4. Notice the strict mode does not imply the parser will do syntax
		/// and semantic validation though.
		/// </para>
		/// </summary>
		public virtual bool Lenient
		{
			get
			{
				return lenient;
			}
			set
			{
				this.lenient = value;
			}
		}


		/// <summary>
		/// Defines if the text block (block 4) will be parsed.
		/// Defaults to true.
		/// </summary>
		public virtual bool ParseTextBlock
		{
			get
			{
				return parseTextBlock;
			}
			set
			{
				this.parseTextBlock = value;
			}
		}


		/// <summary>
		/// Defines if the trailer block (block 5) will be parsed.
		/// Defaults to true.
		/// </summary>
		public virtual bool ParseTrailerBlock
		{
			get
			{
				return parseTrailerBlock;
			}
			set
			{
				this.parseTrailerBlock = value;
			}
		}


		/// <summary>
		/// Defines if the optional user block will be parsed.
		/// Defaults to true.
		/// </summary>
		public virtual bool ParseUserBlock
		{
			get
			{
				return parseUserBlock;
			}
			set
			{
				this.parseUserBlock = value;
			}
		}

	}

}