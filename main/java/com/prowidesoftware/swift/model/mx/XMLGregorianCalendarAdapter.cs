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
	/// Helper class for Gson serialization and deserialization of XMLGregorianCalendar
	/// @since 7.10.3
	/// </summary>
	public class XMLGregorianCalendarAdapter : JsonSerializer<XMLGregorianCalendar>, JsonDeserializer<XMLGregorianCalendar>
	{

		private const string YEAR = "year";
		private const string MONTH = "month";
		private const string DAY = "day";
		private const string TIMEZONE = "timezone";
		private const string HOUR = "hour";
		private const string MINUTE = "minute";
		private const string SECOND = "second";
		private const string FRACTIONAL = "fractionalSecond";

		public override JsonElement serialize(XMLGregorianCalendar cal, Type type, JsonSerializationContext jsonSerializationContext)
		{
			JsonObject obj = new JsonObject();
			obj.addProperty(YEAR, cal.Year);
			obj.addProperty(MONTH, cal.Month);
			obj.addProperty(DAY, cal.Day);
			obj.addProperty(TIMEZONE, cal.Timezone);
			obj.addProperty(HOUR, cal.Hour);
			obj.addProperty(MINUTE, cal.Minute);
			obj.addProperty(SECOND, cal.Second);
			obj.addProperty(FRACTIONAL, cal.FractionalSecond);
			return obj;
			// this alternative implementation is not working
			//return new JsonPrimitive(cal.toXMLFormat());
		}

		public override XMLGregorianCalendar deserialize(JsonElement jsonElement, Type type, JsonDeserializationContext jsonDeserializationContext)
		{
			try
			{
				JsonObject obj = jsonElement.AsJsonObject;
				XMLGregorianCalendar xmlGregCalendar = DatatypeFactory.newInstance().newXMLGregorianCalendar(obj.get(YEAR).AsInt, obj.get(MONTH).AsInt, obj.get(DAY).AsInt, obj.get(HOUR).AsInt, obj.get(MINUTE).AsInt, obj.get(SECOND).AsInt, 0, obj.get(TIMEZONE).AsInt);
				xmlGregCalendar.FractionalSecond = obj.get(FRACTIONAL).AsBigDecimal;
				return xmlGregCalendar;
				// use the line below as implementation in Java 8
				//return DatatypeFactory.newInstance().newXMLGregorianCalendar(jsonElement.getAsString());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
				return null;
			}
		}

	}
}