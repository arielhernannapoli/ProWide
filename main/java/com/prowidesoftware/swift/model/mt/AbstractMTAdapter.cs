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

namespace com.prowidesoftware.swift.model.mt
{

	using com.google.gson;
	using com.prowidesoftware.swift.model;
	using Field = com.prowidesoftware.swift.model.field.Field;


	/// <summary>
	/// Json serialization for AbstractMT and subclasses using Gson.
	/// @since 7.10.3
	/// </summary>
	public class AbstractMTAdapter : JsonSerializer<AbstractMT>, JsonDeserializer<AbstractMT>
	{

		private const string BLOCK1_FINAL_NAME = "basicHeaderBlock";
		private const string BLOCK2_FINAL_NAME = "applicationHeaderBlock";
		private const string BLOCK3_FINAL_NAME = "userHeaderBlock";
		private const string BLOCK4_FINAL_NAME = "textBlock";
		private const string BLOCK5_FINAL_NAME = "trailerBlock";

		public override JsonElement serialize(AbstractMT src, Type typeOfSrc, JsonSerializationContext context)
		{
			string json = src.m.toJson();
			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(json).AsJsonObject;
			JsonObject response = new JsonObject();

			response.addProperty("type","MT");

			if (src.m.Block1 != null)
			{
				// default serialization from SwiftMessage
				response.add(BLOCK1_FINAL_NAME, o.get("data").AsJsonObject.get("block1"));
			}

			if (src.m.Block2 != null)
			{
				// default serialization from SwiftMessage
				response.add(BLOCK2_FINAL_NAME, o.get("data").AsJsonObject.get("block2"));
			}

			if (src.m.Block3 != null && src.m.Block3.Tags.Count > 0)
			{
				setFinalBlockNameAndFields(response,"block3", src.m.Block3.Tags);
			}

			if (src.m.Block4 != null && src.m.Block4.Tags.Count > 0)
			{
				setFinalBlockNameAndFields(response,"block4", src.m.Block4.Tags);
			}

			if (src.m.Block5 != null && src.m.Block5.Tags.Count > 0)
			{
				// default serialization from SwiftMessage with tags renamed to fields
				JsonArray tags = o.get("data").AsJsonObject.get("block5").AsJsonObject.get("tags").AsJsonArray;
				JsonObject trailer = new JsonObject();
				trailer.add("fields", tags);
				response.add(BLOCK5_FINAL_NAME, trailer);
			}

			return response;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override public AbstractMT deserialize(JsonElement jsonElement, Type type, JsonDeserializationContext jsonDeserializationContext) throws JsonParseException
		public override AbstractMT deserialize(JsonElement jsonElement, Type type, JsonDeserializationContext jsonDeserializationContext)
		{
			JsonObject jsonObject = jsonElement.AsJsonObject;
			SwiftMessage swiftMessage = new SwiftMessage();

			SwiftBlock1 block1 = jsonDeserializationContext.deserialize(jsonObject.get(BLOCK1_FINAL_NAME), typeof(SwiftBlock1));
			if (block1 != null)
			{
				swiftMessage.addBlock(block1);
			}

			SwiftBlock2 block2 = jsonDeserializationContext.deserialize(jsonObject.get(BLOCK2_FINAL_NAME), typeof(SwiftBlock2));
			if (block2 != null)
			{
				swiftMessage.addBlock(block2);
			}

			JsonElement userHeaderBlock = jsonObject.get(BLOCK3_FINAL_NAME);
			if (userHeaderBlock != null)
			{
				JsonElement fields = userHeaderBlock.AsJsonObject.get("fields");
				if (fields != null)
				{
					SwiftBlock3 block3 = new SwiftBlock3();
					block3 = (SwiftBlock3) setFieldsOnBlock(fields, block3);
					swiftMessage.addBlock(block3);
				}
			}

			JsonElement textBlock = jsonObject.get(BLOCK4_FINAL_NAME);
			if (textBlock != null)
			{
				JsonElement fields = textBlock.AsJsonObject.get("fields");
				if (fields != null)
				{
					SwiftBlock4 block4 = new SwiftBlock4();
					block4 = (SwiftBlock4) setFieldsOnBlock(fields, block4);
					swiftMessage.addBlock(block4);
				}
			}

			JsonElement trailerBlock = jsonObject.get(BLOCK5_FINAL_NAME);
			if (trailerBlock != null)
			{
				JsonElement fields = trailerBlock.AsJsonObject.get("fields");
				if (fields != null)
				{
					SwiftBlock5 block5 = new SwiftBlock5();
					foreach (JsonElement element in fields.AsJsonArray)
					{
						Tag tag = new Tag();
						tag.Name = element.AsJsonObject.get("name").AsString;
						// trailer tags can have null value (for example PDE field)
						JsonElement valueElement = element.AsJsonObject.get("value");
						if (valueElement != null)
						{
							tag.Value = valueElement.AsString;
						}
						block5.append(tag);
					}
					swiftMessage.addBlock(block5);
				}
			}

			return swiftMessage.toMT();
		}

		private SwiftTagListBlock setFieldsOnBlock(JsonElement fields, SwiftTagListBlock block)
		{
			foreach (Field field in parseFields(fields))
			{
				block.append(field);
			}
			return block;
		}

		/// <summary>
		/// Parses the JSON array with fields into specific Field instances
		/// </summary>
		private static IList<Field> parseFields(JsonElement fieldsElement)
		{
			IList<Field> fields = new List<Field>();
			foreach (JsonElement element in fieldsElement.AsJsonArray)
			{
				Field field = Field.fromJson(element.ToString());
				if (field != null)
				{
					fields.Add(field);
				}
			}
			return fields;
		}


		private void setFinalBlockNameAndFields(JsonObject response, string blockName, IList<Tag> tags)
		{
			string finalBlockName = BLOCK4_FINAL_NAME;
			if (blockName.Equals("block3"))
			{
				finalBlockName = BLOCK3_FINAL_NAME;
			}
			else if (blockName.Equals("block5"))
			{
				finalBlockName = BLOCK5_FINAL_NAME;
			}
			JsonArray fields = getFieldsFromTags(tags);
			JsonObject block = new JsonObject();
			block.add("fields", fields);
			response.add(finalBlockName,block);
		}

		/// <summary>
		/// Converts the tag elements into fields, and the fields into json
		/// </summary>
		private JsonArray getFieldsFromTags(IList<Tag> tags)
		{
			JsonArray fields = new JsonArray();
			JsonParser parser = new JsonParser();
			foreach (Tag tag in tags)
			{
				string json = tag.asField().toJson();
				JsonObject jsonObj = parser.parse(json).AsJsonObject;
				fields.add(jsonObj);
			}
			return fields;
		}

	}


}