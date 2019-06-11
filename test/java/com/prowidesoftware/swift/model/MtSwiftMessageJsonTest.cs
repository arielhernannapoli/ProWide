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

	using JsonObject = com.google.gson.JsonObject;
	using JsonParser = com.google.gson.JsonParser;
	using Test = org.junit.Test;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// Tests for JSON API in MtSwiftMessage
	/// </summary>
	public class MtSwiftMessageJsonTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMtSwiftMessageToJson()
		public virtual void testMtSwiftMessageToJson()
		{
			string fin = "{1:F01CARBVEC0ADDD0344000050}{2:I103CARAANC0XFFFN}{4:\n" + ":20:TBEXO200909031\n" + ":23B:CRED\n" + ":32A:090903VEF23453,\n" + ":50K:/01111001759234567890\n" + "ROMAN GUILLEN DOBOZI \n" + "R00000V0574734\n" + ":53B:/00010013800002001234\n" + "MI BANCO\n" + ":59:/00013500510020179998\n" + "PDVSA GAS\n" + "R00000V000034534\n" + ":71A:OUR\n" + ":72:/TIPO/422\n" + "-}";

			MtSwiftMessage m = new MtSwiftMessage(fin);

			SwiftMessageStatusInfo statusInfo = new SwiftMessageStatusInfo("comments", "creationUser", "name","data");
			IList<SwiftMessageStatusInfo> statusTrial = new List<SwiftMessageStatusInfo>();
			statusTrial.Add(statusInfo);
			m.StatusTrail = statusTrial;

			SwiftMessageNote swiftMessageNote = new SwiftMessageNote("creationUser","text");
			IList<SwiftMessageNote> notes = new List<SwiftMessageNote>();
			notes.Add(swiftMessageNote);
			m.Notes = notes;
			assertNotNull(m);
			string s = m.toJson();

			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);

			assertNull(o.get("mir"));
			assertNull(o.get("pde"));
			assertNull(o.get("pdm"));
			assertNull(o.get("mur"));
			assertEquals("ICARAANC0FFF103TBEXO200909031", o.get("uuid").AsString);
			assertTrue(o.get("statusTrail").AsJsonArray.size() == 1);
			assertEquals("comments", o.get("statusTrail").AsJsonArray.get(0).AsJsonObject.get("comments").AsString);
			assertTrue(o.get("notes").AsJsonArray.size() == 1);
			assertEquals("creationUser", o.get("notes").AsJsonArray.get(0).AsJsonObject.get("creationUser").AsString);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMtSwiftMessageFromJson()
		public virtual void testMtSwiftMessageFromJson()
		{
			string json = "{\n" + "  \"uuid\": \"ICARAANC0FFF103TBEXO200909031\",\n" + "  \"message\": \"{1:F01CARBVEC0ADDD0344000050}{2:I103CARAANC0XFFFN}{4:\\n:20:TBEXO200909031\\n:23B:CRED\\n:32A:090903VEF23453,\\n:50K:/01111001759234567890\\nROMAN GUILLEN DOBOZI \\nR00000V0574734\\n:53B:/00010013800002001234\\nMI BANCO\\n:59:/00013500510020179998\\nPDVSA GAS\\nR00000V000034534\\n:71A:OUR\\n:72:/TIPO/422\\n-}\",\n" + "  \"identifier\": \"fin.103\",\n" + "  \"sender\": \"CARBVEC0DDD\",\n" + "  \"receiver\": \"CARAANC0FFF\",\n" + "  \"direction\": \"outgoing\",\n" + "  \"checksum\": \"c82941778f70a0426ffc04321fa145ad\",\n" + "  \"checksumBody\": \"7d5e9d83c18a16664df1dfd9b1ebe8a6\",\n" + "  \"lastModified\": {\n" + "    \"year\": 2018,\n" + "    \"month\": 4,\n" + "    \"dayOfMonth\": 22,\n" + "    \"hourOfDay\": 0,\n" + "    \"minute\": 48,\n" + "    \"second\": 4\n" + "  },\n" + "  \"creationDate\": {\n" + "    \"year\": 2018,\n" + "    \"month\": 4,\n" + "    \"dayOfMonth\": 22,\n" + "    \"hourOfDay\": 0,\n" + "    \"minute\": 48,\n" + "    \"second\": 4\n" + "  },\n" + "  \"statusTrail\": [\n" + "    {\n" + "      \"name\": \"name\",\n" + "      \"comments\": \"comments\",\n" + "      \"creationDate\": {\n" + "        \"year\": 2018,\n" + "        \"month\": 4,\n" + "        \"dayOfMonth\": 22,\n" + "        \"hourOfDay\": 0,\n" + "        \"minute\": 48,\n" + "        \"second\": 4\n" + "      },\n" + "      \"creationUser\": \"creationUser\",\n" + "      \"data\": \"data\"\n" + "    }\n" + "  ],\n" + "  \"notes\": [\n" + "    {\n" + "      \"creationDate\": {\n" + "        \"year\": 2018,\n" + "        \"month\": 4,\n" + "        \"dayOfMonth\": 22,\n" + "        \"hourOfDay\": 0,\n" + "        \"minute\": 48,\n" + "        \"second\": 4\n" + "      },\n" + "      \"creationUser\": \"creationUser\",\n" + "      \"text\": \"text\"\n" + "    }\n" + "  ],\n" + "  \"properties\": {},\n" + "  \"fileFormat\": \"FIN\",\n" + "  \"reference\": \"TBEXO200909031\",\n" + "  \"currency\": \"VEF\",\n" + "  \"amount\": 23453,\n" + "  \"revisions\": []\n" + "}";


			MtSwiftMessage swiftMessage = MtSwiftMessage.fromJson(json);

			assertEquals("ICARAANC0FFF103TBEXO200909031", swiftMessage.Uuid);
			assertEquals("TBEXO200909031", swiftMessage.Reference);
			assertEquals("FIN", swiftMessage.FileFormat.ToString());
			assertEquals("fin.103", swiftMessage.Identifier);
			assertTrue(swiftMessage.StatusTrail.Count == 1);
			assertEquals("comments", swiftMessage.StatusTrail[0].Comments);
			assertTrue(swiftMessage.Notes.Count == 1);
			assertEquals("creationUser", swiftMessage.Notes[0].CreationUser);

			SwiftMessage sm = swiftMessage.modelMessage();
			assertNotNull(sm.Block1);
			assertNotNull(sm.Block2);
			assertNotNull(sm.Block4);
			assertTrue(sm.Block2.Input);
			assertEquals("TBEXO200909031", sm.Block4.getTagValue("20"));
			assertEquals("CARBVEC0ADDD", sm.Block1.LogicalTerminal);
			assertEquals("103", sm.Block2.MessageType);
			assertEquals("0344", sm.Block1.SessionNumber);
			assertNull(sm.Block5);
		}

	}

}