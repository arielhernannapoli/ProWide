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
namespace com.prowidesoftware.swift.model.field
{

	using JsonObject = com.google.gson.JsonObject;
	using JsonParser = com.google.gson.JsonParser;
	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	/// <summary>
	/// Test cases for fields JSON conversion
	/// @since 7.10.3
	/// </summary>
	public class FieldJsonTest
	{

		private JsonParser parser = new JsonParser();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void toJson()
		public virtual void toJson()
		{
			Field32A f32A = new Field32A("010203USD123,45");
			//{"name":"32A","date":"010203","currency":"USD","amount":"123"}

			JsonObject o = parser.parse(f32A.toJson()).AsJsonObject;
			assertEquals("32A", o.get("name").AsString);
			assertEquals("010203", o.get("date").AsString);
			assertEquals("USD", o.get("currency").AsString);
			assertEquals("123,45", o.get("amount").AsString);

			Field50D f50D = new Field50D("/D/1234\nFoo1\nFoo2\nFoo3");
			// {"name":"50D","dCMark":"D","account":"1234","nameAndAddress":"Foo1","nameAndAddress2":"Foo2","nameAndAddress3":"Foo3"}

			o = parser.parse(f50D.toJson()).AsJsonObject;
			assertEquals("50D", o.get("name").AsString);
			assertEquals("D", o.get("dCMark").AsString);
			assertEquals("1234", o.get("account").AsString);
			assertEquals("Foo1", o.get("nameAndAddress").AsString);
			assertEquals("Foo2", o.get("nameAndAddress2").AsString);
			assertEquals("Foo3", o.get("nameAndAddress3").AsString);

			Field15A f15A = new Field15A();
			// {"name":"15A"}

			o = parser.parse(f15A.toJson()).AsJsonObject;
			assertEquals("15A", o.get("name").AsString);
			assertNull(o.get("value"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void fromJson()
		public virtual void fromJson()
		{
			// check fromJson in specific Field classes
			string json32A = "{\"name\":\"32A\",\"date\":\"010203\",\"currency\":\"USD\",\"amount\":\"123,45\"}";
			Field32A f32A = Field32A.fromJson(json32A);
			assertEquals("010203", f32A.getDate());
			assertEquals("USD", f32A.getCurrency());
			assertEquals("123,45", f32A.getAmount());

			string json50D = "{\"name\":\"50D\",\"dCMark\":\"D\",\"account\":\"1234\",\"nameAndAddress\":\"Foo1\",\"nameAndAddress2\":\"Foo2\",\"nameAndAddress3\":\"Foo3\"}";
			Field50D f50D = Field50D.fromJson(json50D);
			assertEquals("D", f50D.DCMark);
			assertEquals("1234", f50D.Account);
			assertEquals("Foo1", f50D.NameAndAddressLine1);
			assertEquals("Foo2", f50D.NameAndAddressLine2);
			assertEquals("Foo3", f50D.NameAndAddressLine3);

			// check factory methods in Field
			Field32A f32Abis = (Field32A) Field.fromJson(json32A);
			assertEquals(f32A, f32Abis);
			Field50D f50Dbis = (Field50D) Field.fromJson(json50D);
			assertEquals(f50D, f50Dbis);
		}

	}

}