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
namespace com.prowidesoftware.swift.model
{

	using JsonDeserializationContext = com.google.gson.JsonDeserializationContext;
	using JsonDeserializer = com.google.gson.JsonDeserializer;
	using JsonElement = com.google.gson.JsonElement;
	using JsonParseException = com.google.gson.JsonParseException;


	/// <summary>
	/// Basic Bank Account Number Entry Types.
	/// @since 7.9.7
	/// @author psantamarina
	/// </summary>
	public sealed class BbanEntryType
	{
		public static readonly BbanEntryType BANK_CODE = new BbanEntryType("BANK_CODE", InnerEnum.BANK_CODE, "bank_code");
		public static readonly BbanEntryType BRANCH_CODE = new BbanEntryType("BRANCH_CODE", InnerEnum.BRANCH_CODE, "branch_code");
		public static readonly BbanEntryType ACCOUNT_NUMBER = new BbanEntryType("ACCOUNT_NUMBER", InnerEnum.ACCOUNT_NUMBER, "account_number");
		public static readonly BbanEntryType NATIONAL_CHECK_DIGIT = new BbanEntryType("NATIONAL_CHECK_DIGIT", InnerEnum.NATIONAL_CHECK_DIGIT, "national_check_digit");
		public static readonly BbanEntryType ACCOUNT_TYPE = new BbanEntryType("ACCOUNT_TYPE", InnerEnum.ACCOUNT_TYPE, "account_type");
		public static readonly BbanEntryType OWNER_ACCOUNT_NUMBER = new BbanEntryType("OWNER_ACCOUNT_NUMBER", InnerEnum.OWNER_ACCOUNT_NUMBER, "owner_account_number");
		public static readonly BbanEntryType IDENTIFICATION_NUMBER = new BbanEntryType("IDENTIFICATION_NUMBER", InnerEnum.IDENTIFICATION_NUMBER, "identification_number");

		private static readonly IList<BbanEntryType> valueList = new List<BbanEntryType>();

		static BbanEntryType()
		{
			valueList.Add(BANK_CODE);
			valueList.Add(BRANCH_CODE);
			valueList.Add(ACCOUNT_NUMBER);
			valueList.Add(NATIONAL_CHECK_DIGIT);
			valueList.Add(ACCOUNT_TYPE);
			valueList.Add(OWNER_ACCOUNT_NUMBER);
			valueList.Add(IDENTIFICATION_NUMBER);
		}

		public enum InnerEnum
		{
			BANK_CODE,
			BRANCH_CODE,
			ACCOUNT_NUMBER,
			NATIONAL_CHECK_DIGIT,
			ACCOUNT_TYPE,
			OWNER_ACCOUNT_NUMBER,
			IDENTIFICATION_NUMBER
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		private string text;

		internal BbanEntryType(string name, InnerEnum innerEnum, string text)
		{
			this.text = text;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public String Text
		{
			get
			{
				return this.text;
			}
		}

		public static BbanEntryType fromString(string text)
		{
			foreach (BbanEntryType b in BbanEntryType.values())
			{
				if (b.text.equalsIgnoreCase(text))
				{
					return b;
				}
			}
			return null;
		}


		public static IList<BbanEntryType> values()
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

		public static BbanEntryType valueOf(string name)
		{
			foreach (BbanEntryType enumInstance in BbanEntryType.values())
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}

	internal class BbanEntryTypeDeserializer : JsonDeserializer<BbanEntryType>
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override public BbanEntryType deserialize(com.google.gson.JsonElement json, Type typeOfT, com.google.gson.JsonDeserializationContext context) throws com.google.gson.JsonParseException
		public override BbanEntryType deserialize(JsonElement json, Type typeOfT, JsonDeserializationContext context)
		{
			BbanEntryType[] scopes = BbanEntryType.values();
			foreach (BbanEntryType scope in scopes)
			{
				if (scope.Text.Equals(json.AsString))
				{
					return scope;
				}
			}
			return null;
		}
	}


}