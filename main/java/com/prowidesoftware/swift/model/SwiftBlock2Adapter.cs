using System;

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

	using com.google.gson;


	public class SwiftBlock2Adapter : JsonSerializer<SwiftBlock2>, JsonDeserializer<SwiftBlock2>
	{

		private const string DIRECTION = "direction";

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public JsonElement serialize(final SwiftBlock2 swiftBlock2, Type type, final JsonSerializationContext jsonSerializationContext)
		public override JsonElement serialize(SwiftBlock2 swiftBlock2, Type type, JsonSerializationContext jsonSerializationContext)
		{

			JsonElement @object = jsonSerializationContext.serialize(swiftBlock2);

			string direction = "";

			if (swiftBlock2.Input)
			{
				direction = "I";
			}
			else
			{
				direction = "O";
			}

			@object.AsJsonObject.addProperty(DIRECTION,direction);

			return @object;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override public SwiftBlock2 deserialize(JsonElement jsonElement, Type type, JsonDeserializationContext jsonDeserializationContext) throws JsonParseException
		public override SwiftBlock2 deserialize(JsonElement jsonElement, Type type, JsonDeserializationContext jsonDeserializationContext)
		{
			JsonObject jsonObject = jsonElement.AsJsonObject;

			if ((jsonObject.get(DIRECTION) != null && jsonObject.get(DIRECTION).AsString.Equals("O")))
			{
				return getSwiftBlock2OutputObject(jsonObject);
			}
			else
			{
				// defult to INPUT
				return getSwiftBlock2InputObject(jsonObject);
			}
		}

		private SwiftBlock2Output getSwiftBlock2OutputObject(JsonObject jsonObject)
		{
			SwiftBlock2Output swiftBlock2Output = new SwiftBlock2Output();

			setSwiftBlock2Properties(swiftBlock2Output,jsonObject);

			// specific data for OUTPUT

			if (jsonObject.get("senderInputTime") != null)
			{
				swiftBlock2Output.SenderInputTime = jsonObject.get("senderInputTime").AsString;
			}

			if (jsonObject.get("MIRDate") != null)
			{
				swiftBlock2Output.MIRDate = jsonObject.get("MIRDate").AsString;
			}

			if (jsonObject.get("MIRLogicalTerminal") != null)
			{
				swiftBlock2Output.MIRLogicalTerminal = jsonObject.get("MIRLogicalTerminal").AsString;
			}

			if (jsonObject.get("MIRSessionNumber") != null)
			{
				swiftBlock2Output.MIRSessionNumber = jsonObject.get("MIRSessionNumber").AsString;
			}

			if (jsonObject.get("MIRSequenceNumber") != null)
			{
				swiftBlock2Output.MIRSequenceNumber = jsonObject.get("MIRSequenceNumber").AsString;
			}

			if (jsonObject.get("receiverOutputDate") != null)
			{
				swiftBlock2Output.ReceiverOutputDate = jsonObject.get("receiverOutputDate").AsString;
			}

			if (jsonObject.get("receiverOutputTime") != null)
			{
				swiftBlock2Output.ReceiverOutputTime = jsonObject.get("receiverOutputTime").AsString;
			}

			return swiftBlock2Output;
		}

		private SwiftBlock2Input getSwiftBlock2InputObject(JsonObject jsonObject)
		{
			SwiftBlock2Input swiftBlock2Input = new SwiftBlock2Input();

			setSwiftBlock2Properties(swiftBlock2Input,jsonObject);

			// specific data for INPUT

			if (jsonObject.get("receiverAddress") != null)
			{
				swiftBlock2Input.ReceiverAddress = jsonObject.get("receiverAddress").AsString;
			}

			if (jsonObject.get("deliveryMonitoring") != null)
			{
				swiftBlock2Input.DeliveryMonitoring = jsonObject.get("deliveryMonitoring").AsString;
			}

			if (jsonObject.get("obsolescencePeriod") != null)
			{
				swiftBlock2Input.ObsolescencePeriod = jsonObject.get("obsolescencePeriod").AsString;
			}

			return swiftBlock2Input;
		}

		private static void setSwiftBlock2Properties(SwiftBlock2 sb, JsonObject jsonObject)
		{
			if (jsonObject.get("messageType") != null)
			{
				sb.MessageType = jsonObject.get("messageType").AsString;
			}

			if (jsonObject.get("messagePriority") != null)
			{
				sb.MessagePriority = jsonObject.get("messagePriority").AsString;
			}
		}

	}

}