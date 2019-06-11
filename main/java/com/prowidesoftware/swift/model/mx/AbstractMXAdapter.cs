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

namespace com.prowidesoftware.swift.model.mx
{

	using com.google.gson;



	/// <summary>
	/// <seealso cref="AbstractMX"/> JSON serialization and deserialization implementation based on Gson.
	/// <para>
	/// The implementation relieas on the default object serialization that will fill the JSON structure
	/// with all content from the subclasses model (MX model in Integrator). On top of the default subclass
	/// data, this serializer will add the namespace and identifier (needed to clearly identify the message
	/// type in the generic deserialization)
	/// 
	/// @since 7.10.3
	/// </para>
	/// </summary>
	internal class AbstractMXAdapter : JsonSerializer<AbstractMX>, JsonDeserializer<AbstractMX>
	{

		private const string IDENTIFIER = "identifier";

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public JsonElement serialize(final AbstractMX mx, Type type, final JsonSerializationContext context)
		public override JsonElement serialize(AbstractMX mx, Type type, JsonSerializationContext context)
		{
			// default serialization
			// in Integrator this will fill the JSON structure with the complete MX message model
			JsonObject @object = context.serialize(mx).AsJsonObject;
			@object.addProperty("@xmlns", mx.Namespace);
			@object.addProperty(IDENTIFIER, mx.MxId.id());
			return @object;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override public AbstractMX deserialize(JsonElement json, Type typeOfT, JsonDeserializationContext context) throws JsonParseException
		public override AbstractMX deserialize(JsonElement json, Type typeOfT, JsonDeserializationContext context)
		{
			JsonObject jsonObject = json.AsJsonObject;
			JsonPrimitive prim = (JsonPrimitive) jsonObject.get(IDENTIFIER);
			if (prim == null)
			{
				throw new JsonParseException("Missing " + IDENTIFIER + " in JSON structure");
			}
			MxId id = new MxId(prim.AsString);

			Type klass = null;
			try
			{
				string className = "com.prowidesoftware.swift.model.mx.Mx" + id.camelized();
				klass = Type.GetType(className);
			}
			catch (ClassNotFoundException e)
			{
				throw new JsonParseException("Cannot find MX implementation for " + e.Message);
			}
			return context.deserialize(json, klass);
		}

	}

}