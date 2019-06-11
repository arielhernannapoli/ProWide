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

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;

	/// <summary>
	/// Enumeration of messages flow types.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.0
	/// </summary>
	public sealed class MessageIOType
	{
		/// <summary>
		/// Message coming to the institution from SWIFT network
		/// </summary>
		incoming,
		public static readonly MessageIOType incoming = new MessageIOType("incoming", InnerEnum.incoming);
		/// <summary>
		/// Message produced in the institution to be introduced (or already did) in the SWIFT network
		/// </summary>
		outgoing,
		public static readonly MessageIOType outgoing = new MessageIOType("outgoing", InnerEnum.outgoing);
		/// <summary>
		/// Messages coming from and going to the swift network
		/// </summary>
		both
		public static readonly MessageIOType both = new MessageIOType("both", InnerEnum.both);

		private static readonly IList<MessageIOType> valueList = new List<MessageIOType>();

		static MessageIOType()
		{
			valueList.Add(incoming);
			valueList.Add(outgoing);
			valueList.Add(both);
		}

		public enum InnerEnum
		{
			incoming,
			outgoing,
			both
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public static boolean isValid(string ioType)
		{
			Validate.notNull(ioType, "ioType can not be null");
			foreach (MessageIOType t in values())
			{
				if (StringUtils.Equals(ioType.Trim(), t.name()))
				{
					return true;
				}
			}
			return false;
		}

		public boolean Incoming
		{
			get
			{
				return this == MessageIOType.incoming;
			}
		}
		public boolean Outgoing
		{
			get
			{
				return this == MessageIOType.outgoing;
			}
		}
		public boolean Both
		{
			get
			{
				return this == MessageIOType.both;
			}
		}

		public static IList<MessageIOType> values()
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

		public static MessageIOType valueOf(string name)
		{
			foreach (MessageIOType enumInstance in MessageIOType.values())
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