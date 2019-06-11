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

	/// <summary>
	/// Full qualified names for attributes in block 1.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.7
	/// </summary>
	public sealed class SwiftBlock1Field
	{
		ApplicationId,
		public static readonly SwiftBlock1Field ApplicationId = new SwiftBlock1Field("ApplicationId", InnerEnum.ApplicationId);
		ServiceId,
		public static readonly SwiftBlock1Field ServiceId = new SwiftBlock1Field("ServiceId", InnerEnum.ServiceId);
		LogicalTerminal,
		public static readonly SwiftBlock1Field LogicalTerminal = new SwiftBlock1Field("LogicalTerminal", InnerEnum.LogicalTerminal);
		SessionNumber,
		public static readonly SwiftBlock1Field SessionNumber = new SwiftBlock1Field("SessionNumber", InnerEnum.SessionNumber);
		SequenceNumber
		public static readonly SwiftBlock1Field SequenceNumber = new SwiftBlock1Field("SequenceNumber", InnerEnum.SequenceNumber);

		private static readonly IList<SwiftBlock1Field> valueList = new List<SwiftBlock1Field>();

		static SwiftBlock1Field()
		{
			valueList.Add(ApplicationId);
			valueList.Add(ServiceId);
			valueList.Add(LogicalTerminal);
			valueList.Add(SessionNumber);
			valueList.Add(SequenceNumber);
		}

		public enum InnerEnum
		{
			ApplicationId,
			ServiceId,
			LogicalTerminal,
			SessionNumber,
			SequenceNumber
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public static IList<SwiftBlock1Field> values()
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

		public static SwiftBlock1Field valueOf(string name)
		{
			foreach (SwiftBlock1Field enumInstance in SwiftBlock1Field.values())
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