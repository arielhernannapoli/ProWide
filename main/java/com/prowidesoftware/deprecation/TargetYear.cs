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
namespace com.prowidesoftware.deprecation
{

	/// <summary>
	/// Target year for which a deprecation operation is scheduled.
	/// Mainly used for tracking items in codebase.
	/// 
	/// @author miguel
	/// @since 7.8.1
	/// 
	/// </summary>
	public sealed class TargetYear
	{
		_2019,
		public static readonly TargetYear _2019 = new TargetYear("_2019", InnerEnum._2019);
		_2020,
		public static readonly TargetYear _2020 = new TargetYear("_2020", InnerEnum._2020);
		_2021
		public static readonly TargetYear _2021 = new TargetYear("_2021", InnerEnum._2021);

		private static readonly IList<TargetYear> valueList = new List<TargetYear>();

		static TargetYear()
		{
			valueList.Add(_2019);
			valueList.Add(_2020);
			valueList.Add(_2021);
		}

		public enum InnerEnum
		{
			_2019,
			_2020,
			_2021
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public static IList<TargetYear> values()
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

		public static TargetYear valueOf(string name)
		{
			foreach (TargetYear enumInstance in TargetYear.values())
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