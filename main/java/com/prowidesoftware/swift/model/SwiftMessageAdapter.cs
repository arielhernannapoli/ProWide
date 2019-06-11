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

	using com.google.gson;


	public class SwiftMessageAdapter : JsonDeserializer<SwiftMessage>, JsonSerializer<SwiftMessage>
	{

		public override JsonElement serialize(SwiftMessage src, Type typeOfSrc, JsonSerializationContext context)
		{
			JsonObject @object = new JsonObject();
			DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'", Locale.ENGLISH);
			dateFormat.TimeZone = TimeZone.getTimeZone("UTC");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String ts = dateFormat.format(Calendar.getInstance().getTime());
			string ts = dateFormat.format(new DateTime().Ticks);
			@object.addProperty("timestamp", ts);
			@object.addProperty("version", src.JSON_VERSION);

			JsonObject objectBlocks = new JsonObject();
			objectBlocks.add("block1",context.serialize(src.Block1));
			objectBlocks.add("block2",context.serialize(src.Block2, typeof(SwiftBlock2)));
			objectBlocks.add("block3",context.serialize(src.Block3));
			objectBlocks.add("block4",context.serialize(src.Block4));
			objectBlocks.add("block5",context.serialize(src.Block5));
			//TODO agregar user blocks

			@object.add("data", objectBlocks);

			return @object;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override public SwiftMessage deserialize(JsonElement jsonElement, Type type, JsonDeserializationContext jsonDeserializationContext) throws JsonParseException
		public override SwiftMessage deserialize(JsonElement jsonElement, Type type, JsonDeserializationContext jsonDeserializationContext)
		{

			JsonObject jsonArray = jsonElement.AsJsonObject.get("data").AsJsonObject;

			SwiftBlock1 block1 = jsonDeserializationContext.deserialize(jsonArray.get("block1"),typeof(SwiftBlock1));

			SwiftBlock2 block2 = jsonDeserializationContext.deserialize(jsonArray.get("block2"),typeof(SwiftBlock2));

			SwiftBlock3 block3 = jsonDeserializationContext.deserialize(jsonArray.get("block3"),typeof(SwiftBlock3));

			SwiftBlock4 block4 = jsonDeserializationContext.deserialize(jsonArray.get("block4"),typeof(SwiftBlock4));

			SwiftBlock5 block5 = jsonDeserializationContext.deserialize(jsonArray.get("block5"),typeof(SwiftBlock5));

			IList<SwiftBlockUser> blockUsers = new List<SwiftBlockUser>();

			if (jsonArray.get("userBlocks") != null)
			{
				foreach (JsonElement blockUser in jsonArray.get("userBlocks").AsJsonArray)
				{
					blockUsers.Add((SwiftBlockUser)jsonDeserializationContext.deserialize(blockUser,typeof(SwiftBlockUser)));
				}
			}

			SwiftMessage sm = new SwiftMessage();

			if (block1 != null)
			{
				sm.addBlock(block1);
			}

			if (block2 != null)
			{
				sm.addBlock(block2);
			}

			if (block3 != null)
			{
				sm.addBlock(block3);
			}

			if (block4 != null)
			{
				sm.addBlock(block4);
			}

			if (block5 != null)
			{
				sm.addBlock(block5);
			}

			if (blockUsers != null && blockUsers.Count > 0)
			{
				sm.UserBlocks = blockUsers;
			}

			return sm;
		}
	}

}