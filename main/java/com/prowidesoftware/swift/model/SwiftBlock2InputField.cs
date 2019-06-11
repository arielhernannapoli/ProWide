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
	/// Full qualified names for attributes in block 2 input.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.7
	/// </summary>
	public sealed class SwiftBlock2InputField
	{
		/*
		 * common fields to block 2
		 */
		MessageType,
		public static readonly SwiftBlock2InputField MessageType = new SwiftBlock2InputField("MessageType", InnerEnum.MessageType);
		MessagePriority,
		public static readonly SwiftBlock2InputField MessagePriority = new SwiftBlock2InputField("MessagePriority", InnerEnum.MessagePriority);
		/*
		 * specific fields of input block
		 */
		ReceiverAddress,
		public static readonly SwiftBlock2InputField ReceiverAddress = new SwiftBlock2InputField("ReceiverAddress", InnerEnum.ReceiverAddress);
		DeliveryMonitoring,
		public static readonly SwiftBlock2InputField DeliveryMonitoring = new SwiftBlock2InputField("DeliveryMonitoring", InnerEnum.DeliveryMonitoring);
		ObsolescencePeriod
		public static readonly SwiftBlock2InputField ObsolescencePeriod = new SwiftBlock2InputField("ObsolescencePeriod", InnerEnum.ObsolescencePeriod);

		private static readonly IList<SwiftBlock2InputField> valueList = new List<SwiftBlock2InputField>();

		static SwiftBlock2InputField()
		{
			valueList.Add(MessageType);
			valueList.Add(MessagePriority);
			valueList.Add(ReceiverAddress);
			valueList.Add(DeliveryMonitoring);
			valueList.Add(ObsolescencePeriod);
		}

		public enum InnerEnum
		{
			MessageType,
			MessagePriority,
			ReceiverAddress,
			DeliveryMonitoring,
			ObsolescencePeriod
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public static IList<SwiftBlock2InputField> values()
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

		public static SwiftBlock2InputField valueOf(string name)
		{
			foreach (SwiftBlock2InputField enumInstance in SwiftBlock2InputField.values())
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