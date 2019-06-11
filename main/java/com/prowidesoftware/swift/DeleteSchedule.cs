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
namespace com.prowidesoftware.swift
{

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;


	/// <summary>
	/// Used to mark classes / methods or fields that are deprecated and will eventually be removed. 
	/// @since 7.6 </summary>
	/// @deprecated this has been strongly improved and replaced by <seealso cref="ProwideDeprecated"/> 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Retention(RetentionPolicy.SOURCE) @Deprecated @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public class DeleteSchedule extends System.Attribute
	[Obsolete]
	public class DeleteSchedule : System.Attribute
	{

		/// <summary>
		/// Year by which it is scheduled to be removed.
		/// It may not be specified.
		/// This is intended for cases where replacing the code to be deleted do not have trivial replacement
		/// </summary>
		int value() default 0;
		/// <summary>
		/// Month (1-12) of the year by which it is scheduled to be removed.
		/// If not specified January
		/// </summary>
		int month() default 1;

		/// <summary>
		/// Optional URL with explanation or sample code 
		/// </summary>
		string url() default "";
	}

}