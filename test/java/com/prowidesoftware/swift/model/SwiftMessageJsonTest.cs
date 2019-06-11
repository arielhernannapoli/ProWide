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

	using JsonArray = com.google.gson.JsonArray;
	using JsonObject = com.google.gson.JsonObject;
	using JsonParser = com.google.gson.JsonParser;
	using MT103 = com.prowidesoftware.swift.model.mt.mt1xx.MT103;
	using Test = org.junit.Test;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;
	using SwiftMessageComparator = com.prowidesoftware.swift.utils.SwiftMessageComparator;

	/// <summary>
	/// Test cases for SwiftMessage and blocks JSON API
	/// 
	/// @author psantamarina
	/// @since 7.9.8
	/// </summary>
	public class SwiftMessageJsonTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock1ToJson()
		public virtual void testBlock1ToJson()
		{
			SwiftBlock1 b1 = new SwiftBlock1("F","01","FOOSEDR0AXXX","0000","000000");
			string s = b1.toJson();

			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);
			assertEquals("F", o.get("applicationId").AsString);
			assertEquals("01", o.get("serviceId").AsString);
			assertEquals("FOOSEDR0AXXX", o.get("logicalTerminal").AsString);
			assertEquals("0000", o.get("sessionNumber").AsString);
			assertEquals("000000", o.get("sequenceNumber").AsString);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock1FromJson()
		public virtual void testBlock1FromJson()
		{
			string json = "{\"applicationId\":\"F\",\"serviceId\":\"01\",\"logicalTerminal\":\"FOOSEDR0AXXX\",\"sessionNumber\":\"0000\",\"sequenceNumber\":\"000000\"}";
			SwiftBlock1 b1 = SwiftBlock1.fromJson(json);
			assertEquals("F", b1.ApplicationId);
			assertEquals("01", b1.ServiceId);
			assertEquals("FOOSEDR0AXXX", b1.LogicalTerminal);
			assertEquals("0000", b1.SessionNumber);
			assertEquals("000000", b1.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock2InputToJson()
		public virtual void testBlock2InputToJson()
		{
			SwiftBlock2Input b1 = new SwiftBlock2Input("I103CARAANC0XXXXN");
			string s = b1.toJson();

			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);
			assertEquals("I", o.get("direction").AsString);
			assertEquals("CARAANC0XXXX", o.get("receiverAddress").AsString);
			assertEquals("103", o.get("messageType").AsString);
			assertEquals("N", o.get("messagePriority").AsString);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock2OutputToJson()
		public virtual void testBlock2OutputToJson()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX22221234560101031201N");
			string s = nout.toJson();

			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);
			assertFalse(nout.Input);
			assertEquals("O", o.get("direction").AsString);
			assertEquals("100", o.get("messageType").AsString);
			assertEquals("1200", o.get("senderInputTime").AsString);
			assertEquals("010103", o.get("receiverOutputDate").AsString);
			assertEquals("1201", o.get("receiverOutputTime").AsString);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock2InputFromJson()
		public virtual void testBlock2InputFromJson()
		{
			string s = "{\"direction\":\"I\",\"messageType\":\"103\",\"receiverAddress\":\"CARAANC0XXXX\",\"messagePriority\":\"N\",\"deliveryMonitoring\":\"2\",\"obsolescencePeriod\":\"003\"}";
			SwiftBlock2Input block2Input = SwiftBlock2Input.fromJson(s);
			assertTrue(block2Input.Input);
			assertEquals("103", block2Input.MessageType);
			assertEquals("CARAANC0XXXX", block2Input.ReceiverAddress);
			assertEquals("N", block2Input.MessagePriority);
			assertEquals("2", block2Input.DeliveryMonitoring);
			assertEquals("003", block2Input.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock2OutputFromJson()
		public virtual void testBlock2OutputFromJson()
		{
			string s = "{\"direction\":\"O\",\"messageType\":\"100\",\"senderInputTime\":\"1200\",\"MIRDate\":\"010103\",\"MIRLogicalTerminal\":\"BANKBEBBAXXX\",\"MIRSessionNumber\":\"2222\",\"MIRSequenceNumber\":\"123456\",\"receiverOutputDate\":\"010103\",\"receiverOutputTime\":\"1201\",\"messagePriority\":\"N\"}";

			SwiftBlock2Output block2Output = SwiftBlock2Output.fromJson(s);
			assertTrue(block2Output.Output);
			assertEquals("100", block2Output.MessageType);
			assertEquals("1200", block2Output.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", block2Output.MIR);
			assertEquals("010103", block2Output.ReceiverOutputDate);
			assertEquals("1201", block2Output.ReceiverOutputTime);
			assertEquals("N", block2Output.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock3ToJson()
		public virtual void testBlock3ToJson()
		{
			SwiftBlock3 b3 = new SwiftBlock3();
			b3.append(new Tag("113","SEPA"));
			b3.append(new Tag("108","ILOVESEPA"));

			string s = b3.toJson();
			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);
			assertTrue(o.get("tags").AsJsonArray.size() == 2);
			//TODO agregar mas asserts, ver testBlock1ToJson
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock3FromJson()
		public virtual void testBlock3FromJson()
		{
			string json = "{\"tags\":[{\"name\":\"113\",\"value\":\"SEPA\"},{\"name\":\"108\",\"value\":\"ILOVESEPA\"}]}";
			SwiftBlock3 b3 = SwiftBlock3.fromJson(json);
			assertTrue(b3.Tags.Count == 2);
			assertEquals("SEPA", b3.getTagValue("113"));
			assertEquals("ILOVESEPA", b3.getTagValue("108"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4ToJson()
		public virtual void testBlock4ToJson()
		{
			SwiftBlock4 b4 = new SwiftBlock4();
			b4.append(new Tag("20", "REFERENCE"));
			b4.append(new Tag("23B", "CRED"));

			string s = b4.toJson();
			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);
			assertTrue(o.get("tags").AsJsonArray.size() == 2);
			assertEquals("20", o.get("tags").AsJsonArray.get(0).AsJsonObject.get("name").AsString);
			assertEquals("23B",o.get("tags").AsJsonArray.get(1).AsJsonObject.get("name").AsString);
			assertEquals("REFERENCE",o.get("tags").AsJsonArray.get(0).AsJsonObject.get("value").AsString);
			assertEquals("CRED", o.get("tags").AsJsonArray.get(1).AsJsonObject.get("value").AsString);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4FromJson()
		public virtual void testBlock4FromJson()
		{
			string json = "{\"tags\":[{\"name\":\"20\",\"value\":\"REFERENCE\"},{\"name\":\"23B\",\"value\":\"CRED\"}]}";
			SwiftBlock4 b4 = SwiftBlock4.fromJson(json);
			assertTrue(b4.Tags.Count == 2);
			assertEquals("REFERENCE", b4.getTagValue("20"));
			assertEquals("CRED", b4.getTagValue("23B"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock5ToJson()
		public virtual void testBlock5ToJson()
		{
			SwiftBlock5 b5 = new SwiftBlock5();
			b5.append(new Tag("PDE"));
			b5.append(new Tag("CHK", "aaaa1111bbbb2222"));

			string s = b5.toJson();
			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);
			assertTrue(o.get("tags").AsJsonArray.size() == 2);

			assertEquals("PDE", o.get("tags").AsJsonArray.get(0).AsJsonObject.get("value").AsString);
			assertEquals("CHK",o.get("tags").AsJsonArray.get(1).AsJsonObject.get("name").AsString);
			assertEquals("aaaa1111bbbb2222", o.get("tags").AsJsonArray.get(1).AsJsonObject.get("value").AsString);

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock5FromJson()
		public virtual void testBlock5FromJson()
		{
			string json = "{\"tags\":[{\"name\":\"PDE\",\"value\":\"\"},{\"name\":\"CHK\",\"value\":\"aaaa1111bbbb2222\"}]}";
			SwiftBlock5 b5 = SwiftBlock5.fromJson(json);
			assertTrue(b5.Tags.Count == 2);

			assertEquals("", b5.getTagValue("PDE"));
			assertEquals("aaaa1111bbbb2222", b5.getTagValue("CHK"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSwiftBlockUserToJson()
		public virtual void testSwiftBlockUserToJson()
		{
			SwiftBlockUser bu = new SwiftBlockUser("P");
			bu.append(new Tag("PDE"));
			bu.append(new Tag("CHK", "aaaa1111bbbb2222"));

			string s = bu.toJson();
			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);
			assertTrue(o.get("tags").AsJsonArray.size() == 2);

			assertEquals("PDE", o.get("tags").AsJsonArray.get(0).AsJsonObject.get("value").AsString);
			assertEquals("CHK",o.get("tags").AsJsonArray.get(1).AsJsonObject.get("name").AsString);
			assertEquals("P", o.get("blockName").AsString);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSwiftBlockUserFromJson()
		public virtual void testSwiftBlockUserFromJson()
		{
			string json = "{\"blockName\":\"A\",\"tags\":[{\"name\":\"PDE\",\"value\":\"\"},{\"name\":\"CHK\",\"value\":\"aaaa1111bbbb2222\"}]}";
			SwiftBlockUser b = SwiftBlockUser.fromJson(json);
			assertTrue(b.Tags.Count == 2);

			assertEquals("", b.getTagValue("PDE"));
			assertEquals("aaaa1111bbbb2222", b.getTagValue("CHK"));
			assertEquals("A", b.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSwiftMessageToJson() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSwiftMessageToJson()
		{
			SwiftMessage m = MT103.parse("{1:F01FOOSEDR0AXXX0000000000}{3:{113:SEPA}{108:ILOVESEPA}}{2:I103FOORECV0XXXXN}{4:\n" + ":20:REFERENCE\n" + ":23B:CRED\n" + ":32A:130204USD1234567,89\n" + ":50K:/12345678901234567890\n" + "FOOBANKXXXXX\n" + ":59:/12345678901234567890\n" + "JOE DOE\n" + ":71A:OUR\n" + "-}").SwiftMessage;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String json = m.toJson();
			string json = m.toJson();

			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(json).AsJsonObject;

			assertNotNull(o);
			assertEquals(SwiftMessage.JSON_VERSION, o.get("version").AsInt);
			assertNotNull(o.get("timestamp"));
			assertNotNull(o.get("data"));

			JsonObject block4 = o.get("data").AsJsonObject.get("block4").AsJsonObject;
			assertNotNull(block4);

			JsonArray tags = block4.get("tags").AsJsonArray;
			assertEquals(6, tags.size());

			JsonObject tag50K = tags.get(3).AsJsonObject;
			assertNotNull(tag50K);

			assertEquals("/12345678901234567890\nFOOBANKXXXXX", tag50K.get("value").AsString);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSwiftMessageFromJsonWithBlock3() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSwiftMessageFromJsonWithBlock3()
		{
			string json = "{\n" + "  \"timestamp\": \"2018-04-19T02:31:26Z\",\n" + "  \"version\": 2,\n" + "  \"data\": {\n" + "    \"block1\": {\n" + "      \"applicationId\": \"F\",\n" + "      \"serviceId\": \"01\",\n" + "      \"logicalTerminal\": \"FOOSEDR0AXXX\",\n" + "      \"sessionNumber\": \"0000\",\n" + "      \"sequenceNumber\": \"000000\"\n" + "    },\n" + "    \"block2\": {\n" + "      \"receiverAddress\": \"FOORECV0XXXX\",\n" + "      \"messagePriority\": \"N\",\n" + "      \"messageType\": \"103\",\n" + "      \"direction\": \"I\"\n" + "    },\n" + "    \"block3\": {\n" + "      \"tags\": [\n" + "        {\n" + "          \"name\": \"113\",\n" + "          \"value\": \"SEPA\"\n" + "        },\n" + "        {\n" + "          \"name\": \"108\",\n" + "          \"value\": \"ILOVESEPA\"\n" + "        }\n" + "      ]\n" + "    },\n" + "    \"block4\": {\n" + "      \"tags\": [\n" + "        {\n" + "          \"name\": \"20\",\n" + "          \"value\": \"REFERENCE\"\n" + "        },\n" + "        {\n" + "          \"name\": \"23B\",\n" + "          \"value\": \"CRED\"\n" + "        },\n" + "        {\n" + "          \"name\": \"32A\",\n" + "          \"value\": \"130204USD1234567,89\"\n" + "        },\n" + "        {\n" + "          \"name\": \"50K\",\n" + "          \"value\": \"/12345678901234567890\\nFOOBANKXXXXX\"\n" + "        },\n" + "        {\n" + "          \"name\": \"59\",\n" + "          \"value\": \"/12345678901234567890\\nJOE DOE\"\n" + "        },\n" + "        {\n" + "          \"name\": \"71A\",\n" + "          \"value\": \"OUR\"\n" + "        }\n" + "      ]\n" + "    }\n" + "  }\n" + "}";

			SwiftMessage m = SwiftMessage.fromJson(json);
			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertTrue(m.Block2.Input);
			assertNotNull(m.Block3);
			assertNotNull(m.Block4);
			assertNull(m.Block5);
			assertEquals("SEPA", m.Block3.getTagValue("113"));
			assertEquals("/12345678901234567890\nFOOBANKXXXXX", m.Block4.getTagValue("50K"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSwiftMessageFromJson() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSwiftMessageFromJson()
		{
			string json = "{\n" + "  \"timestamp\": \"2018-04-16T03:57:16Z\",\n" + "  \"version\": 2,\n" + "  \"data\": {\n" + "    \"block1\": {\n" + "      \"applicationId\": \"F\",\n" + "      \"serviceId\": \"01\",\n" + "      \"logicalTerminal\": \"FOOSEDR0AXXX\",\n" + "      \"sessionNumber\": \"0000\",\n" + "      \"sequenceNumber\": \"000000\"\n" + "    },\n" + "    \"block2\": {\n" + "      \"input\": true,\n" + "      \"direction\": I,\n" + "      \"receiverAddress\": \"FOORECV0XXXX\",\n" + "      \"messagePriority\": \"N\",\n" + "      \"messageType\": \"103\"\n" + "    },\n" + "    \"block4\": {\n" + "      \"tags\": [\n" + "        {\n" + "          \"name\": \"20\",\n" + "          \"value\": \"REFERENCE\"\n" + "        },\n" + "        {\n" + "          \"name\": \"23B\",\n" + "          \"value\": \"CRED\"\n" + "        },\n" + "        {\n" + "          \"name\": \"32A\",\n" + "          \"value\": \"130204USD1234567,89\"\n" + "        },\n" + "        {\n" + "          \"name\": \"50K\",\n" + "          \"value\": \"/12345678901234567890\\nFOOBANKXXXXX\"\n" + "        },\n" + "        {\n" + "          \"name\": \"59\",\n" + "          \"value\": \"/12345678901234567890\\nJOE DOE\"\n" + "        },\n" + "        {\n" + "          \"name\": \"71A\",\n" + "          \"value\": \"OUR\"\n" + "        }\n" + "      ]\n" + "    }\n" + "  }\n" + "}";

			SwiftMessage m = SwiftMessage.fromJson(json);
			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertTrue(m.Block2.Input);
			assertNull(m.Block3);
			assertNotNull(m.Block4);
			assertNull(m.Block5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSwiftMessageFromJsonUserBlocks()
		public virtual void testSwiftMessageFromJsonUserBlocks()
		{
			string json = "{\n" + "  \"timestamp\": \"2018-04-25T02:22:10Z\",\n" + "  \"version\": 2,\n" + "  \"data\": {\n" + "    \"block1\": {\n" + "      \"applicationId\": \"F\",\n" + "      \"serviceId\": \"01\",\n" + "      \"logicalTerminal\": \"FOOSEDR0AXXX\",\n" + "      \"sessionNumber\": \"0000\",\n" + "      \"sequenceNumber\": \"000000\"\n" + "    },\n" + "    \"block2\": {\n" + "      \"receiverAddress\": \"FOORECV0XXXX\",\n" + "      \"messagePriority\": \"N\",\n" + "      \"messageType\": \"103\",\n" + "      \"direction\": \"I\"\n" + "    },\n" + "    \"block3\": {\n" + "      \"tags\": [\n" + "        {\n" + "          \"name\": \"113\",\n" + "          \"value\": \"SEPA\"\n" + "        },\n" + "        {\n" + "          \"name\": \"108\",\n" + "          \"value\": \"ILOVESEPA\"\n" + "        }\n" + "      ]\n" + "    },\n" + "    \"block4\": {\n" + "      \"tags\": [\n" + "        {\n" + "          \"name\": \"20\",\n" + "          \"value\": \"REFERENCE\"\n" + "        },\n" + "        {\n" + "          \"name\": \"23B\",\n" + "          \"value\": \"CRED\"\n" + "        },\n" + "        {\n" + "          \"name\": \"32A\",\n" + "          \"value\": \"130204USD1234567,89\"\n" + "        },\n" + "        {\n" + "          \"name\": \"50K\",\n" + "          \"value\": \"/12345678901234567890\\nFOOBANKXXXXX\"\n" + "        },\n" + "        {\n" + "          \"name\": \"59\",\n" + "          \"value\": \"/12345678901234567890\\nJOE DOE\"\n" + "        },\n" + "        {\n" + "          \"name\": \"71A\",\n" + "          \"value\": \"OUR\"\n" + "        }\n" + "      ]\n" + "    },\n" + "    \"userBlocks\": [\n" + "      {\n" + "       \"blockName\":\"P\",\n" + "        \"tags\": [\n" + "          {\n" + "            \"name\": \"20\",\n" + "            \"value\": \"REFERENCE\"\n" + "          },\n" + "          {\n" + "            \"name\": \"23B\",\n" + "            \"value\": \"CRED\"\n" + "          }\n" + "        ]\n" + "      },\n" + "      {\n" + "        \"tags\": [\n" + "          {\n" + "            \"name\": \"20\",\n" + "            \"value\": \"REFERENCE\"\n" + "          },\n" + "          {\n" + "            \"name\": \"23B\",\n" + "            \"value\": \"CRED\"\n" + "          }\n" + "        ]\n" + "      }\n" + "    ]\n" + "  }\n" + "}";

			SwiftMessage m = SwiftMessage.fromJson(json);
			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertNotNull(m.Block3);
			assertNotNull(m.Block4);
			assertNull(m.Block5);
			assertNotNull(m.UserBlocks);
			assertEquals("REFERENCE", m.Block4.getTagValue("20"));
			assertEquals("CRED", m.Block4.getTagValue("23B"));
			assertEquals("P", m.UserBlocks[0].Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSwiftMessageToJsonV1()
		public virtual void testSwiftMessageToJsonV1()
		{
			SwiftMessage m = MT103.parse("{1:F01FOOSEDR0AXXX0000000000}{3:{113:SEPA}{108:ILOVESEPA}}{2:I103FOORECV0XXXXN}{4:\n" + ":20:REFERENCE\n" + ":23B:CRED\n" + ":32A:130204USD1234567,89\n" + ":50K:/12345678901234567890\n" + "FOOBANKXXXXX\n" + ":59:/12345678901234567890\n" + "JOE DOE\n" + ":71A:OUR\n" + "-}").SwiftMessage;

			string toJsonV1SwiftMessage = m.toJsonV1();

			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(toJsonV1SwiftMessage).AsJsonObject;

			assertNotNull(o);
			assertEquals(SwiftMessage.JSON_VERSION, o.get("version").AsInt);
			assertNotNull(o.get("timestamp"));
			assertNotNull(o.get("data"));

			JsonObject block4 = o.get("data").AsJsonObject.get("block4").AsJsonObject;
			assertNotNull(block4);

			JsonArray tags = block4.get("tags").AsJsonArray;
			assertEquals(6, tags.size());

			JsonObject tag50K = tags.get(3).AsJsonObject;
			assertNotNull(tag50K);

			assertEquals("/12345678901234567890\nFOOBANKXXXXX", tag50K.get("value").AsString);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSwiftMessageToJsonAndFromJson()
		public virtual void testSwiftMessageToJsonAndFromJson()
		{
			SwiftMessage m = MT103.parse("{1:F01FOOSEDR0AXXX0000000000}{3:{113:SEPA}{108:ILOVESEPA}}{2:I103FOORECV0XXXXN}{4:\n" + ":20:REFERENCE\n" + ":23B:CRED\n" + ":32A:130204USD1234567,89\n" + ":50K:/12345678901234567890\n" + "FOOBANKXXXXX\n" + ":59:/12345678901234567890\n" + "JOE DOE\n" + ":71A:OUR\n" + "-}{5:{CHK:C77F8E009597}}").SwiftMessage;

			string toJsonSwiftMessage = m.toJson();

			SwiftMessage fromJsonSwiftMessage = SwiftMessage.fromJson(toJsonSwiftMessage);

			SwiftMessageComparator comp = new SwiftMessageComparator();

			assertTrue(comp.Compare(m, fromJsonSwiftMessage) == 0);
		}

	}

}