using System;

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
namespace com.prowidesoftware.swift.io.parser
{

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using SwiftBlock = com.prowidesoftware.swift.model.SwiftBlock;
	using SwiftTagListBlock = com.prowidesoftware.swift.model.SwiftTagListBlock;
	using Tag = com.prowidesoftware.swift.model.Tag;
	using UnparsedTextList = com.prowidesoftware.swift.model.UnparsedTextList;



	/// <summary>
	/// Simple class that increases visibility of parser methods in 
	/// order to unit tests them.
	/// 
	/// @since 4.0
	/// </summary>
	public sealed class VisibleParser : SwiftParser
	{

		public VisibleParser() : base()
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void simpleBlockConsumer(com.prowidesoftware.swift.model.SwiftBlock b, String s) throws java.io.IOException
		public void simpleBlockConsumer(SwiftBlock b, string s)
		{
			base.tagListBlockConsume((SwiftTagListBlock) b, s);
		}

		public VisibleParser(InputStream @is) : base(@is)
		{
		}

		public VisibleParser(Reader r) : base(r)
		{
		}

		protected internal override char identifyBlock(string s)
		{
			return base.identifyBlock(s);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public String findBlockStart() throws java.io.IOException
		public override string findBlockStart()
		{
			return base.findBlockStart();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.Tag consumeTag(String br) throws java.io.IOException
		public Tag consumeTag(string br)
		{
			if (br.StartsWith("{", StringComparison.Ordinal))
			{
				br = br.Substring(1);
			}
			if (br.EndsWith("}", StringComparison.Ordinal))
			{
				br = br.Substring(0, br.Length - 1);
			}
			if (br.StartsWith(":", StringComparison.Ordinal))
			{
				br = br.Substring(1);
			}
			return base.consumeTag(br, null);
		}

		/// @deprecated use <seealso cref="#consumeBlock(UnparsedTextList)"/> instead of this, <code>consumeBlock(null)</code> is acceptable 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#consumeBlock(com.prowidesoftware.swift.model.UnparsedTextList)"/> instead of this, <code>consumeBlock(null)</code> is acceptable") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public com.prowidesoftware.swift.model.SwiftBlock consumeBlock() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		[Obsolete("use <seealso cref="#consumeBlock(com.prowidesoftware.swift.model.UnparsedTextList)"/> instead of this, <code>consumeBlock(null)</code> is acceptable")]
		public override SwiftBlock consumeBlock()
		{
			DeprecationUtils.phase3(this.GetType(), "consumeBlock()", "Use consumeBlock(UnparsedTextList) instead, where consumeBlock() is acceptable.");
			return base.consumeBlock();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public String readUntilBlockEnds() throws java.io.IOException
		public override string readUntilBlockEnds()
		{
			return base.readUntilBlockEnds();
		}

		public int textTagEndBlock4(string s, int start, bool? isTextBlock)
		{
			return base.textTagEndBlock4(s, start, isTextBlock);
		}

	}
}