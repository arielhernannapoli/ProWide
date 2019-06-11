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
	/// Full qualified names for attributes in block 2.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.7
	/// </summary>
	public sealed class SwiftBlock2Field
	{
		MessageType,
		public static readonly SwiftBlock2Field MessageType = new SwiftBlock2Field("MessageType", InnerEnum.MessageType);
		MessagePriority
		public static readonly SwiftBlock2Field MessagePriority = new SwiftBlock2Field("MessagePriority", InnerEnum.MessagePriority);

		private static readonly IList<SwiftBlock2Field> valueList = new List<SwiftBlock2Field>();

		static SwiftBlock2Field()
		{
			valueList.Add(MessageType);
			valueList.Add(MessagePriority);
		}

		public enum InnerEnum
		{
			MessageType,
			MessagePriority
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public static IList<SwiftBlock2Field> values()
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

		public static SwiftBlock2Field valueOf(string name)
		{
			foreach (SwiftBlock2Field enumInstance in SwiftBlock2Field.values())
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