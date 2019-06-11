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
	/// Full qualified names for attributes in block 2 output.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.7
	/// </summary>
	public sealed class SwiftBlock2OutputField
	{
		/*
		 * common fields to block 2
		 */
		MessageType,
		public static readonly SwiftBlock2OutputField MessageType = new SwiftBlock2OutputField("MessageType", InnerEnum.MessageType);
		MessagePriority,
		public static readonly SwiftBlock2OutputField MessagePriority = new SwiftBlock2OutputField("MessagePriority", InnerEnum.MessagePriority);
		/*
		 * specific fields of output block
		 */
		SenderInputTime,
		public static readonly SwiftBlock2OutputField SenderInputTime = new SwiftBlock2OutputField("SenderInputTime", InnerEnum.SenderInputTime);
		MIRDate,
		public static readonly SwiftBlock2OutputField MIRDate = new SwiftBlock2OutputField("MIRDate", InnerEnum.MIRDate);
		MIRLogicalTerminal,
		public static readonly SwiftBlock2OutputField MIRLogicalTerminal = new SwiftBlock2OutputField("MIRLogicalTerminal", InnerEnum.MIRLogicalTerminal);
		MIRSessionNumber,
		public static readonly SwiftBlock2OutputField MIRSessionNumber = new SwiftBlock2OutputField("MIRSessionNumber", InnerEnum.MIRSessionNumber);
		MIRSequenceNumber,
		public static readonly SwiftBlock2OutputField MIRSequenceNumber = new SwiftBlock2OutputField("MIRSequenceNumber", InnerEnum.MIRSequenceNumber);
		ReceiverOutputDate,
		public static readonly SwiftBlock2OutputField ReceiverOutputDate = new SwiftBlock2OutputField("ReceiverOutputDate", InnerEnum.ReceiverOutputDate);
		ReceiverOutputTime
		public static readonly SwiftBlock2OutputField ReceiverOutputTime = new SwiftBlock2OutputField("ReceiverOutputTime", InnerEnum.ReceiverOutputTime);

		private static readonly IList<SwiftBlock2OutputField> valueList = new List<SwiftBlock2OutputField>();

		static SwiftBlock2OutputField()
		{
			valueList.Add(MessageType);
			valueList.Add(MessagePriority);
			valueList.Add(SenderInputTime);
			valueList.Add(MIRDate);
			valueList.Add(MIRLogicalTerminal);
			valueList.Add(MIRSessionNumber);
			valueList.Add(MIRSequenceNumber);
			valueList.Add(ReceiverOutputDate);
			valueList.Add(ReceiverOutputTime);
		}

		public enum InnerEnum
		{
			MessageType,
			MessagePriority,
			SenderInputTime,
			MIRDate,
			MIRLogicalTerminal,
			MIRSessionNumber,
			MIRSequenceNumber,
			ReceiverOutputDate,
			ReceiverOutputTime
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public static IList<SwiftBlock2OutputField> values()
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

		public static SwiftBlock2OutputField valueOf(string name)
		{
			foreach (SwiftBlock2OutputField enumInstance in SwiftBlock2OutputField.values())
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