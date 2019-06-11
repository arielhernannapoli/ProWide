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
namespace com.prowidesoftware.swift.io
{

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;


	/// @deprecated us <seealso cref="RJEReader"/> instead 
	/// @author www.prowidesoftware.com 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("us <seealso cref="RJEReader"/> instead") @ProwideDeprecated(phase4=TargetYear._2019) public class ReaderIterator extends RJEReader
	[Obsolete("us <seealso cref="RJEReader"/> instead")]
	public class ReaderIterator : RJEReader
	{

		public ReaderIterator(Reader r) : base(r)
		{
			DeprecationUtils.phase3(this.GetType(), null, "Use RJEReader instead.");
		}

		public static ReaderIterator fromResource(string @string)
		{
			InputStream s = typeof(ReaderIterator).ClassLoader.getResourceAsStream(@string);
			if (s != null)
			{
				return new ReaderIterator(new InputStreamReader(s));
			}
			return null;
		}

	}
}