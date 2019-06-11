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

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;

	/// <summary>
	/// Official variants for MT messages (not including closed user groups version of messages)
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8
	/// </summary>
	public sealed class MTVariant
	{
		STP = true,
		public static readonly MTVariant STP = new MTVariant("STP", InnerEnum.STP, true);
		REMIT = true,
		public static readonly MTVariant REMIT = new MTVariant("REMIT", InnerEnum.REMIT, true);
		COV = true,
		public static readonly MTVariant COV = new MTVariant("COV", InnerEnum.COV, true);

		/*
		 * this message variant was removed from the standard in SRU2017
		 */
		[System.Obsolete]
		IRSLST = false,
		public static readonly MTVariant IRSLST = new MTVariant("IRSLST", InnerEnum.IRSLST, false);

		/*
		 * this message variant was removed from the standard in SRU2017
		 */
		[System.Obsolete]
		W8BENO = false
		public static readonly MTVariant W8BENO = new MTVariant("W8BENO", InnerEnum.W8BENO, false);

		private static readonly IList<MTVariant> valueList = new List<MTVariant>();

		static MTVariant()
		{
			valueList.Add(STP);
			valueList.Add(REMIT);
			valueList.Add(COV);
			valueList.Add(IRSLST);
			valueList.Add(W8BENO);
		}

		public enum InnerEnum
		{
			STP,
			REMIT,
			COV,
			IRSLST,
			W8BENO
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		internal bool validationFlag = false;

		internal MTVariant(string name, InnerEnum innerEnum, bool validationFlag)
		{
			this.validationFlag = validationFlag;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		/// <summary>
		/// returns true if the variant is also a validation flag used in the user header block
		/// </summary>
		public boolean ValidationFlag
		{
			get
			{
				return this.validationFlag;
			}
		}

		public static IList<MTVariant> values()
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

		public static MTVariant valueOf(string name)
		{
			foreach (MTVariant enumInstance in MTVariant.values())
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