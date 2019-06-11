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
	/// Enumeration of messages standard types.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.8.3
	/// </summary>
	public sealed class MessageStandardType
	{
		MT,
		public static readonly MessageStandardType MT = new MessageStandardType("MT", InnerEnum.MT);
		MX
		public static readonly MessageStandardType MX = new MessageStandardType("MX", InnerEnum.MX);

		private static readonly IList<MessageStandardType> valueList = new List<MessageStandardType>();

		static MessageStandardType()
		{
			valueList.Add(MT);
			valueList.Add(MX);
		}

		public enum InnerEnum
		{
			MT,
			MX
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public boolean MT
		{
			get
			{
				return this == MT;
			}
		}
		public boolean MX
		{
			get
			{
				return this == MX;
			}
		}

		public static IList<MessageStandardType> values()
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

		public static MessageStandardType valueOf(string name)
		{
			foreach (MessageStandardType enumInstance in MessageStandardType.values())
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