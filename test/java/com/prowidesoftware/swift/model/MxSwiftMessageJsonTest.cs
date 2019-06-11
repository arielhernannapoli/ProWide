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
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Assert = org.junit.Assert;
	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;

	/// <summary>
	/// Tests for JSON API in MxSwiftMessage
	/// </summary>
	public class MxSwiftMessageJsonTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMxSwiftMessageToJson()
		public virtual void testMxSwiftMessageToJson()
		{
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<message>" + "<AppHdr xmlns:Ah=\"urn:swift:xsd$ahV10\">" + "<From>" + "	<Type>DN</Type>" + " <Id>cn=funds,o=abcdchzzwww,o=swift</Id>" + "</From>" + "<To>" + "	<Type>DN</Type>" + "	<Id>cn=funds,o=dcbadeff,o=swift</Id>" + "</To>" + "	<MsgRef>11308917</MsgRef>" + "	<CrDate>2013-12-23T15:50:00</CrDate>" + "</AppHdr>" + "<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.008.001.02\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.six-interbank-clearing.com/de/pacs.008.001.02.ch.01 pacs.008.001.02.ch.01.xsd\">" + "<FIToFICstmrCdtTrf>" + "	<GrpHdr>" + "		<MsgId>MSGID-0001</MsgId>" + "		<CreDtTm>2001-12-17T09:30:47Z</CreDtTm>" + "		<NbOfTxs>1</NbOfTxs>" + "		<IntrBkSttlmDt>2012-01-25</IntrBkSttlmDt>" + "		<SttlmInf><SttlmMtd>INDA</SttlmMtd></SttlmInf>" + "		<InstgAgt><FinInstnId><BIC>KBBECH20DSZ</BIC></FinInstnId></InstgAgt>" + "		<InstdAgt><FinInstnId><BIC>DRESDEF0VNZ</BIC></FinInstnId></InstdAgt>" + "	</GrpHdr>" + "	<CdtTrfTxInf>" + " </CdtTrfTxInf>" + "</FIToFICstmrCdtTrf>" + "</Document>" + "</message>";
			MxSwiftMessage mx = new MxSwiftMessage(xml);

			string s = mx.toJson();

			JsonParser parser = new JsonParser();
			JsonObject o = parser.parse(s).AsJsonObject;

			assertNotNull(o);
			assertEquals("001", o.get("variant").AsString);
			assertEquals("02", o.get("version").AsString);
			assertEquals("008", o.get("functionality").AsString);
			assertEquals("pacs.008.001.02", o.get("identifier").AsString);
			assertEquals("ABCDCHZZWWW", o.get("sender").AsString);
			assertEquals("DCBADEFFXXX", o.get("receiver").AsString);
			assertEquals("11308917", o.get("reference").AsString);
			Assert.assertTrue(StringUtils.contains(mx.Message, "Document"));
			Assert.assertTrue(StringUtils.contains(mx.Message, "2012-01-25"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMxSwiftMessageFromJson()
		public virtual void testMxSwiftMessageFromJson()
		{
			string json = "{\n" + "  \"businessProcess\": \"pacs\",\n" + "  \"functionality\": \"008\",\n" + "  \"variant\": \"001\",\n" + "  \"version\": \"02\",\n" + "  \"message\": \"\\u003c?xml version\\u003d\\\"1.0\\\" encoding\\u003d\\\"UTF-8\\\"?\\u003e\\u003cmessage\\u003e\\u003cAppHdr xmlns:Ah\\u003d\\\"urn:swift:xsd$ahV10\\\"\\u003e\\u003cFrom\\u003e\\t\\u003cType\\u003eDN\\u003c/Type\\u003e \\u003cId\\u003ecn\\u003dfunds,o\\u003dabcdchzzwww,o\\u003dswift\\u003c/Id\\u003e\\u003c/From\\u003e\\u003cTo\\u003e\\t\\u003cType\\u003eDN\\u003c/Type\\u003e\\t\\u003cId\\u003ecn\\u003dfunds,o\\u003ddcbadeff,o\\u003dswift\\u003c/Id\\u003e\\u003c/To\\u003e\\t\\u003cMsgRef\\u003e11308917\\u003c/MsgRef\\u003e\\t\\u003cCrDate\\u003e2013-12-23T15:50:00\\u003c/CrDate\\u003e\\u003c/AppHdr\\u003e\\u003cDocument xmlns\\u003d\\\"urn:iso:std:iso:20022:tech:xsd:pacs.008.001.02\\\" xmlns:xsi\\u003d\\\"http://www.w3.org/2001/XMLSchema-instance\\\" xsi:schemaLocation\\u003d\\\"http://www.six-interbank-clearing.com/de/pacs.008.001.02.ch.01 pacs.008.001.02.ch.01.xsd\\\"\\u003e\\u003cFIToFICstmrCdtTrf\\u003e\\t\\u003cGrpHdr\\u003e\\t\\t\\u003cMsgId\\u003eMSGID-0001\\u003c/MsgId\\u003e\\t\\t\\u003cCreDtTm\\u003e2001-12-17T09:30:47Z\\u003c/CreDtTm\\u003e\\t\\t\\u003cNbOfTxs\\u003e1\\u003c/NbOfTxs\\u003e\\t\\t\\u003cIntrBkSttlmDt\\u003e2012-01-25\\u003c/IntrBkSttlmDt\\u003e\\t\\t\\u003cSttlmInf\\u003e\\u003cSttlmMtd\\u003eINDA\\u003c/SttlmMtd\\u003e\\u003c/SttlmInf\\u003e\\t\\t\\u003cInstgAgt\\u003e\\u003cFinInstnId\\u003e\\u003cBIC\\u003eKBBECH20DSZ\\u003c/BIC\\u003e\\u003c/FinInstnId\\u003e\\u003c/InstgAgt\\u003e\\t\\t\\u003cInstdAgt\\u003e\\u003cFinInstnId\\u003e\\u003cBIC\\u003eDRESDEF0VNZ\\u003c/BIC\\u003e\\u003c/FinInstnId\\u003e\\u003c/InstdAgt\\u003e\\t\\u003c/GrpHdr\\u003e\\t\\u003cCdtTrfTxInf\\u003e \\u003c/CdtTrfTxInf\\u003e\\u003c/FIToFICstmrCdtTrf\\u003e\\u003c/Document\\u003e\\u003c/message\\u003e\",\n" + "  \"identifier\": \"pacs.008.001.02\",\n" + "  \"sender\": \"ABCDCHZZWWW\",\n" + "  \"receiver\": \"DCBADEFFXXX\",\n" + "  \"lastModified\": {\n" + "    \"year\": 2018,\n" + "    \"month\": 4,\n" + "    \"dayOfMonth\": 18,\n" + "    \"hourOfDay\": 0,\n" + "    \"minute\": 25,\n" + "    \"second\": 48\n" + "  },\n" + "  \"creationDate\": {\n" + "    \"year\": 2018,\n" + "    \"month\": 4,\n" + "    \"dayOfMonth\": 18,\n" + "    \"hourOfDay\": 0,\n" + "    \"minute\": 25,\n" + "    \"second\": 48\n" + "  },\n" + "  \"statusTrail\": [],\n" + "  \"notes\": [],\n" + "  \"properties\": {},\n" + "  \"reference\": \"11308917\",\n" + "  \"revisions\": []\n" + "}";

			MxSwiftMessage mx = MxSwiftMessage.fromJson(json);
			assertEquals("001", mx.Variant);
			assertEquals("02", mx.Version);
			assertEquals("008", mx.Functionality);
			assertEquals("pacs.008.001.02", mx.Identifier);
			assertEquals("ABCDCHZZWWW", mx.Sender);
			assertEquals("DCBADEFFXXX", mx.Receiver);
			assertEquals("11308917", mx.Reference);
			assertEquals(2018, mx.LastModified.Year);
			assertEquals(4, mx.LastModified.Month);
			assertEquals(18, mx.LastModified.Day);
			assertEquals(25, mx.LastModified.Minute);
			assertEquals(48, mx.LastModified.Second);
		}

	}

}