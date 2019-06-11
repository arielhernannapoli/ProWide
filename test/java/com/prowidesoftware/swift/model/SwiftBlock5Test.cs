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

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
	using JsonObject = com.google.gson.JsonObject;
	using JsonParser = com.google.gson.JsonParser;

	using Test = org.junit.Test;

	using SwiftMessageComparator = com.prowidesoftware.swift.utils.SwiftMessageComparator;


	public class SwiftBlock5Test
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock5ToJson()
		public virtual void testBlock5ToJson()
		{

			Tag t1 = new Tag();
			t1.Name = "20";
			t1.Value = "REFERENCE";

			Tag t2 = new Tag();
			t2.Name = "23B";
			t2.Value = "CRED";

			IList<Tag> tagList = new List<Tag>();
			tagList.Add(t1);
			tagList.Add(t2);

			SwiftBlock4 b4 = new SwiftBlock4(tagList);
			string s = b4.toJson();
			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);
			assertTrue(o.get("tags").AsJsonArray.size() == 2);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock5FromJson()
		public virtual void testBlock5FromJson()
		{
			string json = "{\"tags\":[{\"name\":\"113\",\"value\":\"SEPA\"},{\"name\":\"108\",\"value\":\"ILOVESEPA\"}]}";
			SwiftBlock5 b5 = SwiftBlock5.fromJson(json);
			assertTrue(b5.Tags.Count == 2);
			assertEquals("SEPA", b5.getTagValue("113"));
			assertEquals("ILOVESEPA", b5.getTagValue("108"));
		}
	}

}