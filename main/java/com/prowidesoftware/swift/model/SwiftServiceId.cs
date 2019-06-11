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
namespace com.prowidesoftware.swift.model
{

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using ServiceIdType = com.prowidesoftware.swift.model.mt.ServiceIdType;

	/// <summary>
	/// Class to hold valid service id values.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0 </summary>
	/// @deprecated use <seealso cref="ServiceIdType instead"/> 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @ProwideDeprecated(phase4=TargetYear._2019) @Deprecated public class SwiftServiceId
	[Obsolete]
	public class SwiftServiceId
	{
		private const long serialVersionUID = 3435194171796145884L;

		/// <summary>
		/// Constant for Service ID 01
		/// </summary>
		public static readonly SwiftServiceId _01 = new SwiftServiceId("01");
		/// <summary>
		/// Constant for Service ID 02
		/// </summary>
		public static readonly SwiftServiceId _02 = new SwiftServiceId("02");
		/// <summary>
		/// Constant for Service ID 03
		/// </summary>
		public static readonly SwiftServiceId _03 = new SwiftServiceId("03");
		/// <summary>
		/// Constant for Service ID 05
		/// </summary>
		public static readonly SwiftServiceId _05 = new SwiftServiceId("05");
		/// <summary>
		/// Constant for Service ID 06
		/// </summary>
		public static readonly SwiftServiceId _06 = new SwiftServiceId("06");
		/// <summary>
		/// Constant for Service ID 12
		/// </summary>
		public static readonly SwiftServiceId _12 = new SwiftServiceId("12");
		/// <summary>
		/// Constant for Service ID 13
		/// </summary>
		public static readonly SwiftServiceId _13 = new SwiftServiceId("13");
		/// <summary>
		/// Constant for Service ID 14
		/// </summary>
		public static readonly SwiftServiceId _14 = new SwiftServiceId("14");
		/// <summary>
		/// Constant for Service ID 15
		/// </summary>
		public static readonly SwiftServiceId _15 = new SwiftServiceId("15");
		/// <summary>
		/// Constant for Service ID 21
		/// </summary>
		public static readonly SwiftServiceId _21 = new SwiftServiceId("21");
		/// <summary>
		/// Constant for Service ID 22
		/// </summary>
		public static readonly SwiftServiceId _22 = new SwiftServiceId("22");
		/// <summary>
		/// Constant for Service ID 23
		/// </summary>
		public static readonly SwiftServiceId _23 = new SwiftServiceId("23");
		/// <summary>
		/// Constant for Service ID 25
		/// </summary>
		public static readonly SwiftServiceId _25 = new SwiftServiceId("25");
		/// <summary>
		/// Constant for Service ID 26
		/// </summary>
		public static readonly SwiftServiceId _26 = new SwiftServiceId("26");
		/// <summary>
		/// Constant for Service ID 33
		/// </summary>
		public static readonly SwiftServiceId _33 = new SwiftServiceId("33");
		/// <summary>
		/// Constant for Service ID 35
		/// </summary>
		public static readonly SwiftServiceId _35 = new SwiftServiceId("35");
		/// <summary>
		/// Constant for Service ID 42
		/// </summary>
		public static readonly SwiftServiceId _42 = new SwiftServiceId("42");
		/// <summary>
		/// Constant for Service ID 43
		/// </summary>
		public static readonly SwiftServiceId _43 = new SwiftServiceId("43");

		/// <param name="name"> </param>
		protected internal SwiftServiceId(string name)
		{
			DeprecationUtils.phase3(this.GetType(), null, "Use the enumeration ServiceIdType instead.");
		}

		/// <summary>
		/// Tell if name is a valid service id, true if it is, and false in any other
		/// case. This method is null-safe.
		/// </summary>
		/// <param name="name">
		///            the name to test as service id, may be null </param>
		/// <returns> <code>true</code> if the parameter name is a valid service id
		/// @since 6.0 </returns>
		/// @deprecated use <seealso cref="ServiceIdType#valid(String)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static boolean contains(String name)
		public static bool contains(string name)
		{
			DeprecationUtils.phase3(typeof(SwiftServiceId), "contains(String)", "Use the enumeration ServiceIdType instead.");
			return false;
		}

	}

}