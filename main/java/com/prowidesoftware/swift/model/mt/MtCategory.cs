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

	/// <summary>
	/// Enumeration for MT messages categories.
	/// <br>
	/// The category is also included in the message type, as the first digit. For example
	/// for an MT103 the corresponding category is 1. 
	/// 
	/// @author sebastian
	/// @since 7.8.8
	/// </summary>
	public sealed class MtCategory
	{
		public static readonly MtCategory _0 = new MtCategory("_0", InnerEnum._0, "System Messages");
		public static readonly MtCategory _1 = new MtCategory("_1", InnerEnum._1, "Customer Payments and Cheques");
		public static readonly MtCategory _2 = new MtCategory("_2", InnerEnum._2, "Financial Institution Transfers");
		public static readonly MtCategory _3 = new MtCategory("_3", InnerEnum._3, "Foreign exchange, Money Markets and Derivatives");
		public static readonly MtCategory _4 = new MtCategory("_4", InnerEnum._4, "Collections and Cash Letters");
		public static readonly MtCategory _5 = new MtCategory("_5", InnerEnum._5, "Securities Markets");
		public static readonly MtCategory _6 = new MtCategory("_6", InnerEnum._6, "Commodities and Syndications");
		public static readonly MtCategory _7 = new MtCategory("_7", InnerEnum._7, "Documentary Credits and Guarantees");
		public static readonly MtCategory _8 = new MtCategory("_8", InnerEnum._8, "Travellers Cheques");
		public static readonly MtCategory _9 = new MtCategory("_9", InnerEnum._9, "Cash Management and Customer Status");

		private static readonly IList<MtCategory> valueList = new List<MtCategory>();

		static MtCategory()
		{
			valueList.Add(_0);
			valueList.Add(_1);
			valueList.Add(_2);
			valueList.Add(_3);
			valueList.Add(_4);
			valueList.Add(_5);
			valueList.Add(_6);
			valueList.Add(_7);
			valueList.Add(_8);
			valueList.Add(_9);
		}

		public enum InnerEnum
		{
			_0,
			_1,
			_2,
			_3,
			_4,
			_5,
			_6,
			_7,
			_8,
			_9
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		private string description;

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: MtCategory(final String description)
		internal MtCategory(string name, InnerEnum innerEnum, string description)
		{
			this.description = description;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		/// <summary>
		/// Convenient factory method to create a category enum value from an int </summary>
		/// <param name="cat"> a category number between 0 and 9 </param>
		/// <returns> the created category value or null if the parameter in is not a valid category number </returns>
		public static MtCategory valueOf(int cat)
		{
			if (cat >= 0 && cat <= 9)
			{
				return valueOf("_" + cat);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Returns the service number and description, for example:
		/// 01 - GPA/FIN Message (system and user-to-user)
		/// </summary>
		public String description()
		{
			return number().Substring(1) + " - " + this.description;
		}

		/// <summary>
		/// Returns this service id type number
		/// @since 7.8.8
		/// </summary>
		public String number()
		{
			return this.name().Substring(1);
		}


		public static IList<MtCategory> values()
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

		public static MtCategory valueOf(string name)
		{
			foreach (MtCategory enumInstance in MtCategory.values())
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