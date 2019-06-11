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
namespace com.prowidesoftware.swift.model.mt
{

	using StringUtils = org.apache.commons.lang3.StringUtils;

	/// <summary>
	/// Available service identification values in MT header block 1.
	/// 
	/// @since 7.8.3
	/// </summary>
	public sealed class ServiceIdType
	{
		public static readonly ServiceIdType _01 = new ServiceIdType("_01", InnerEnum._01, "GPA/FIN Message (system and user-to-user)");
		public static readonly ServiceIdType _02 = new ServiceIdType("_02", InnerEnum._02, "GPA Login");
		public static readonly ServiceIdType _03 = new ServiceIdType("_03", InnerEnum._03, "GPA Select");
		public static readonly ServiceIdType _05 = new ServiceIdType("_05", InnerEnum._05, "FIN Quit");
		public static readonly ServiceIdType _06 = new ServiceIdType("_06", InnerEnum._06, "GPA Logout");
		public static readonly ServiceIdType _12 = new ServiceIdType("_12", InnerEnum._12, "GPA System Remove AP Request");
		public static readonly ServiceIdType _13 = new ServiceIdType("_13", InnerEnum._13, "GPA System Abort AP Confirmation");
		public static readonly ServiceIdType _14 = new ServiceIdType("_14", InnerEnum._14, "GPA System Remove LT Request");
		public static readonly ServiceIdType _15 = new ServiceIdType("_15", InnerEnum._15, "GPA System Abort LT Confirmation");
		public static readonly ServiceIdType _21 = new ServiceIdType("_21", InnerEnum._21, "GPA/FIN Message (ACK/NAK/UAK/UNK)");
		public static readonly ServiceIdType _22 = new ServiceIdType("_22", InnerEnum._22, "GPA Login ACK (LAK)");
		public static readonly ServiceIdType _23 = new ServiceIdType("_23", InnerEnum._23, "GPA Select ACK (SAK)");
		public static readonly ServiceIdType _25 = new ServiceIdType("_25", InnerEnum._25, "FIN Quit ACK");
		public static readonly ServiceIdType _26 = new ServiceIdType("_26", InnerEnum._26, "GPA Logout ACK");
		public static readonly ServiceIdType _33 = new ServiceIdType("_33", InnerEnum._33, "GPA User Abort AP Request");
		public static readonly ServiceIdType _35 = new ServiceIdType("_35", InnerEnum._35, "GPA User Abort LT Request");
		public static readonly ServiceIdType _42 = new ServiceIdType("_42", InnerEnum._42, "GPA Login NAK (LNK)");
		public static readonly ServiceIdType _43 = new ServiceIdType("_43", InnerEnum._43, "GPA Select NAK (SNK)");

		private static readonly IList<ServiceIdType> valueList = new List<ServiceIdType>();

		static ServiceIdType()
		{
			valueList.Add(_01);
			valueList.Add(_02);
			valueList.Add(_03);
			valueList.Add(_05);
			valueList.Add(_06);
			valueList.Add(_12);
			valueList.Add(_13);
			valueList.Add(_14);
			valueList.Add(_15);
			valueList.Add(_21);
			valueList.Add(_22);
			valueList.Add(_23);
			valueList.Add(_25);
			valueList.Add(_26);
			valueList.Add(_33);
			valueList.Add(_35);
			valueList.Add(_42);
			valueList.Add(_43);
		}

		public enum InnerEnum
		{
			_01,
			_02,
			_03,
			_05,
			_06,
			_12,
			_13,
			_14,
			_15,
			_21,
			_22,
			_23,
			_25,
			_26,
			_33,
			_35,
			_42,
			_43
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		private string description;

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: ServiceIdType(final String description)
		internal ServiceIdType(string name, InnerEnum innerEnum, string description)
		{
			this.description = description;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		/// <summary>
		/// Returns the service number and description, for example:
		/// 01 - GPA/FIN Message (system and user-to-user)
		/// </summary>
		public String description()
		{
			return number() + " - " + this.description;
		}

		/// <summary>
		/// Returns this service id type number
		/// @since 7.8.8
		/// </summary>
		public String number()
		{
			return this.name().Substring(1);
		}

		/// <summary>
		/// Returns true if the parameter number is a valid service id. 
		/// This method is null-safe.
		/// </summary>
		/// <param name="number"> the service id number to test, may be null </param>
		/// <returns> <code>true</code> if the parameter number is a valid service id
		/// @since 7.8.8 </returns>
		public static boolean valid(string number)
		{
			if (StringUtils.isNotEmpty(number))
			{
				try
				{
					valueOf("_" + number);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}
			return false;
		}


		public static IList<ServiceIdType> values()
		{
			return valueList;
		}

		public InnerEnum InnerEnumValue()
		{
			return innerEnumValue;
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static ServiceIdType valueOf(string name)
		{
			foreach (ServiceIdType enumInstance in ServiceIdType.values())
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}

}