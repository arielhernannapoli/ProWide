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
namespace com.prowidesoftware.swift.io.parser
{


	using XMLTestCase = org.custommonkey.xmlunit.XMLTestCase;
	using XMLUnit = org.custommonkey.xmlunit.XMLUnit;
	using Before = org.junit.Before;
	using Test = org.junit.Test;
	using SAXException = org.xml.sax.SAXException;

	using MxStructureInfo = com.prowidesoftware.swift.io.parser.MxParser.MxStructureInfo;
	using MxBusinessProcess = com.prowidesoftware.swift.model.MxBusinessProcess;
	using MxId = com.prowidesoftware.swift.model.MxId;
	using BusinessHeader = com.prowidesoftware.swift.model.mx.BusinessHeader;
	using ApplicationHeader = com.prowidesoftware.swift.model.mx.dic.ApplicationHeader;
	using BusinessApplicationHeaderV01 = com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01;

	/// <summary>
	/// Test cases for <seealso cref="MxParser"/> header parsing, message detection, analysis and strip API.
	/// 
	/// @since 7.6
	/// </summary>
	public class MxParserTest : XMLTestCase
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			XMLUnit.IgnoreWhitespace = true;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private com.prowidesoftware.swift.model.mx.BusinessHeader parseHeaderFromSample(final String sample) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		private BusinessHeader parseHeaderFromSample(string sample)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.InputStream inputStream = getClass().getResourceAsStream("/"+sample);
			InputStream inputStream = this.GetType().getResourceAsStream("/" + sample);
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mx.BusinessHeader h = new MxParser(inputStream).parseBusinessHeader();
				BusinessHeader h = (new MxParser(inputStream)).parseBusinessHeader();
				return h;
			}
			finally
			{
				inputStream.close();
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void assertSampleApplicationHeader(final com.prowidesoftware.swift.model.mx.BusinessHeader bh)
		private void assertSampleApplicationHeader(BusinessHeader bh)
		{
			assertNotNull(bh);
			ApplicationHeader h = bh.ApplicationHeader;
			assertNotNull(h);
			assertEquals("DN", h.From.Type);
			assertEquals("cn=funds,ou=abcdchzz,o=swift", h.From.Id);
			assertEquals("DN", h.To.Type);
			assertEquals("cn=funds,ou=dcbadeff,o=swift", h.To.Id);
			assertEquals("11308917", h.MsgRef);
			assertNotNull(h.CrDate);
			assertNull(h.Dup);
			assertNull(h.MsgName);
			assertNull(h.SvcName);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParseApplicationHeader_null() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParseApplicationHeader_null()
		{
			assertNull(parseHeaderFromSample("mx_sample_document.xml"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParseApplicationHeader_sample_header() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParseApplicationHeader_sample_header()
		{
			assertSampleApplicationHeader(parseHeaderFromSample("mx_sample_header.xml"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParseApplicationHeader_sample_payload() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParseApplicationHeader_sample_payload()
		{
			assertSampleApplicationHeader(parseHeaderFromSample("mx_sample_payload.xml"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParseApplicationHeader_sample_payload_mq() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParseApplicationHeader_sample_payload_mq()
		{
			/*
			 * <Ah:AppHdr xmlns:Ah="urn:swift:xsd:$ahV10">
			<Ah:MsgRef>SCRRQ01</Ah:MsgRef>
			<Ah:CrDate>2006-09-18T17:11:28.359</Ah:CrDate>
			</Ah:AppHdr>
			 */
			BusinessHeader bh = parseHeaderFromSample("app_to_mqsq.xml");
			assertNotNull(bh);
			ApplicationHeader h = bh.ApplicationHeader;
			assertNotNull(h);
			assertEquals("SCRRQ01", h.MsgRef);
			assertNotNull(h.CrDate);
			//assertEquals("2006-09-18T17:11:28.359", h.getCrDate());
			assertEquals(2006, h.CrDate.Year);
			assertEquals(9, h.CrDate.Month);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParseApplicationHeader_sample_request_wrapper() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParseApplicationHeader_sample_request_wrapper()
		{
			assertSampleApplicationHeader(parseHeaderFromSample("mx_sample_request_wrapper.xml"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParseBusinessApplicationHeader_sample() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParseBusinessApplicationHeader_sample()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mx.BusinessHeader bh = new MxParser(sampleBAH).parseBusinessHeader();
			BusinessHeader bh = (new MxParser(sampleBAH)).parseBusinessHeader();
			assertSampleBusinessApplicationHeader(bh);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParseApplicationHeader()
		public virtual void testParseApplicationHeader()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = "<h:AppHdr xmlns:h=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">"+ "   <h:Fr>"+ "      <h:FIId>"+ "         <h:FinInstnId>"+ "            <h:Nm>Not available</h:Nm>"+ "         </h:FinInstnId>"+ "      </h:FIId>"+ "   </h:Fr>"+ "   <h:To>"+ "      <h:FIId>"+ "         <h:FinInstnId>"+ "            <h:Nm>Not available</h:Nm>"+ "         </h:FinInstnId>"+ "      </h:FIId>"+ "   </h:To>"+ "   <h:BizMsgIdr>AAAAAAAAAA222222</h:BizMsgIdr>"+ "   <h:MsgDefIdr>seev.037.002.02</h:MsgDefIdr>"+ "   <h:CreDt>2017-08-08T16:58:01Z</h:CreDt>"+ "</h:AppHdr>";
			string xml = "<h:AppHdr xmlns:h=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">" + "   <h:Fr>" + "      <h:FIId>" + "         <h:FinInstnId>" + "            <h:Nm>Not available</h:Nm>" + "         </h:FinInstnId>" + "      </h:FIId>" + "   </h:Fr>" + "   <h:To>" + "      <h:FIId>" + "         <h:FinInstnId>" + "            <h:Nm>Not available</h:Nm>" + "         </h:FinInstnId>" + "      </h:FIId>" + "   </h:To>" + "   <h:BizMsgIdr>AAAAAAAAAA222222</h:BizMsgIdr>" + "   <h:MsgDefIdr>seev.037.002.02</h:MsgDefIdr>" + "   <h:CreDt>2017-08-08T16:58:01Z</h:CreDt>" + "</h:AppHdr>";
			MxParser p = new MxParser(xml);
			BusinessApplicationHeaderV01 h = p.parseBusinessApplicationHeaderV01();
			assertNotNull(h);
			assertEquals("Not available", h.Fr.FIId.FinInstnId.Nm);
			assertEquals("Not available", h.To.FIId.FinInstnId.Nm);
			assertEquals("AAAAAAAAAA222222", h.BizMsgIdr);
			assertEquals("seev.037.002.02", h.MsgDefIdr);
			assertNotNull(h.CreDt);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDetectMessage() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testDetectMessage()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
			assertMxId((new MxParser(xml)).detectMessage());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDetectMessage2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testDetectMessage2()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Foo:Document xmlns:Foo=\"urn:swift:xsd:camt.003.001.04\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Foo:Document xmlns:Foo=\"urn:swift:xsd:camt.003.001.04\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
			assertMxId((new MxParser(xml)).detectMessage());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDetectMessage3() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testDetectMessage3()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Document xmlns=\"urn:swift:xsd:camt.003.001.04\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"></Doc:Document>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Document xmlns=\"urn:swift:xsd:camt.003.001.04\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"></Doc:Document>";
			assertMxId((new MxParser(xml)).detectMessage());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDetectMessage4() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testDetectMessage4()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Document xmlns=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Document xmlns=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>";
			assertMxId((new MxParser(xml)).detectMessage());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDetectMessage5() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testDetectMessage5()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>";
			assertMxId((new MxParser(xml)).detectMessage());
		}

		/*
		 * bank to bank namespace
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDetectMessage6() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testDetectMessage6()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:swift.eni$camt.003.001.04\"></Doc:Document>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:swift.eni$camt.003.001.04\"></Doc:Document>";
			assertMxId((new MxParser(xml)).detectMessage());
		}

		internal virtual void assertMxId(MxId id)
		{
			assertNotNull("detected id is null", id);
			assertEquals(MxBusinessProcess.camt, id.BusinessProcess);
			assertEquals("003", id.Functionality);
			assertEquals("001", id.Variant);
			assertEquals("04", id.Version);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAnalizeMessage() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testAnalizeMessage()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>";
			MxStructureInfo info = (new MxParser(xml)).analyzeMessage();
			assertNull(info.Exception);
			assertTrue(info.containsDocument());
			assertFalse(info.containsHeader());
			assertFalse(info.containsWrapper());
			assertEquals(info.DocumentNamespace, "urn:swift:xsd:camt.003.001.04");
			assertEquals(info.DocumentPrefix, "Doc");
			assertNull(info.HeaderNamespace);
			assertNull(info.HeaderPrefix);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAnalizeMessage2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testAnalizeMessage2()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Document xmlns=\"urn:swift:xsd:camt.003.001.04\"></Document>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Document xmlns=\"urn:swift:xsd:camt.003.001.04\"></Document>";
			MxStructureInfo info = (new MxParser(xml)).analyzeMessage();
			assertNull(info.Exception);
			assertTrue(info.containsDocument());
			assertFalse(info.containsHeader());
			assertFalse(info.containsWrapper());
			assertEquals(info.DocumentNamespace, "urn:swift:xsd:camt.003.001.04");
			assertNull(info.DocumentPrefix);
			assertNull(info.HeaderNamespace);
			assertNull(info.HeaderPrefix);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAnalizeMessage3() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testAnalizeMessage3()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></AppHdr>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></AppHdr>";
			MxStructureInfo info = (new MxParser(xml)).analyzeMessage();
			assertNull(info.Exception);
			assertFalse(info.containsDocument());
			assertTrue(info.containsHeader());
			assertFalse(info.containsWrapper());
			assertNull(info.DocumentNamespace);
			assertNull(info.DocumentPrefix);
			assertEquals(info.HeaderNamespace, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01");
			assertNull(info.HeaderPrefix);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAnalizeMessage4() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testAnalizeMessage4()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<h:AppHdr xmlns:h=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></h:AppHdr>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<h:AppHdr xmlns:h=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></h:AppHdr>";
			MxStructureInfo info = (new MxParser(xml)).analyzeMessage();
			assertNull(info.Exception);
			assertFalse(info.containsDocument());
			assertTrue(info.containsHeader());
			assertFalse(info.containsWrapper());
			assertNull(info.DocumentNamespace);
			assertNull(info.DocumentPrefix);
			assertEquals(info.HeaderNamespace, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01");
			assertEquals(info.HeaderPrefix, "h");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAnalizeMessage5() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testAnalizeMessage5()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<message>" + "<h:AppHdr xmlns:h=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></h:AppHdr>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>" + "</message>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<message>" + "<h:AppHdr xmlns:h=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></h:AppHdr>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>" + "</message>";
			MxStructureInfo info = (new MxParser(xml)).analyzeMessage();
			assertNull(info.Exception);
			assertTrue(info.containsDocument());
			assertTrue(info.containsHeader());
			assertTrue(info.containsWrapper());
			assertEquals(info.DocumentNamespace, "urn:swift:xsd:camt.003.001.04");
			assertEquals(info.DocumentPrefix, "Doc");
			assertEquals(info.HeaderNamespace, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01");
			assertEquals(info.HeaderPrefix, "h");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAnalizeMessage6() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testAnalizeMessage6()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></foo>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></foo>";
			MxStructureInfo info = (new MxParser(xml)).analyzeMessage();
			assertNotNull(info.Exception);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAnalizeMessage7() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testAnalizeMessage7()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml ="<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
			MxStructureInfo info = (new MxParser(xml)).analyzeMessage();
			assertNotNull(info.Exception);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testStrip() throws java.io.IOException, org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testStrip()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String h = "<h:AppHdr xmlns:h=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></h:AppHdr>";
			string h = "<h:AppHdr xmlns:h=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></h:AppHdr>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String d = "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>";
			string d = "<Doc:Document xmlns:Doc=\"urn:swift:xsd:camt.003.001.04\"></Doc:Document>";
			MxParser parser = new MxParser("<?xml version=\"1.0\" encoding=\"UTF-8\"?><message>" + h + d + "</message>");
			assertEquals(h, parser.stripHeader());
			assertEquals(d, parser.stripDocument());

			/*
			 * no document
			 */
			parser = new MxParser("<?xml version=\"1.0\" encoding=\"UTF-8\"?><message>" + h + "</message>");
			assertEquals(h, parser.stripHeader());
			assertNull(parser.stripDocument());

			/*
			 * no header
			 */
			parser = new MxParser("<?xml version=\"1.0\" encoding=\"UTF-8\"?><message>" + d + "</message>");
			assertNull(parser.stripHeader());
			assertXMLEqual(d, parser.stripDocument());
		}

		/// <summary>
		/// This test sample contains a non-standard envelope, and a document with a supplementary data containing an embedded MX.
		/// It is used to validate the analyze and strip API properly detect the main MX information ignoring the embedded suplementary MX. </summary>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="SAXException">  </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFullSample() throws java.io.IOException, org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFullSample()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String document = "<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:seev.036.002.07\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n" + "<CorpActnMvmntConf>\n" + "		<MvmntPrlimryAdvcId>\n" + "			<Id>2016120815902666</Id>\n" + "		</MvmntPrlimryAdvcId>\n" + "		<CorpActnGnlInf>\n" + "			<CorpActnEvtId>12345678</CorpActnEvtId>\n" + "			<OffclCorpActnEvtId>US12345678</OffclCorpActnEvtId>\n" + "			<EvtTp><Cd>PDEF</Cd></EvtTp>\n" + "			<FinInstrmId>\n" + "				<OthrId>\n" + "					<Id>172311HA3</Id>\n" + "					<Tp><Cd>CUSP</Cd></Tp>\n" + "				</OthrId>\n" + "				<Desc>FOOOWSR05.000JD21BE</Desc>\n" + "			</FinInstrmId>\n" + "		</CorpActnGnlInf>\n" + "	<SplmtryData>\n" + "		<Envlp>\n" + "			<Document xmlns=\"urn:swift:xsd:supl.011.001.04\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n" + "				<DTCCCACOSD1>\n" + "					<CorpActnGnlInf>\n" + "						<PlcAndNm>/Document/CorpActnMvmntConf/CorpActnGnlInf</PlcAndNm>\n" + "						<EvtGrp>REDM</EvtGrp>\n" + "						<RedId>1379145963</RedId>\n" + "					</CorpActnGnlInf>\n" + "					<CorpActnConfSctiesMvmntDtls>\n" + "						<PlcAndNm>foo</PlcAndNm>\n" + "						<CdtDbtInd>CRDT</CdtDbtInd>\n" + "						<PyoutTp>SECU</PyoutTp>\n" + "						<MtrtyDt>2017-12-01</MtrtyDt>\n" + "					</CorpActnConfSctiesMvmntDtls>\n" + "				</DTCCCACOSD1>\n" + "			</Document>\n" + "		</Envlp>\n" + "	</SplmtryData>\n" + "</CorpActnMvmntConf>\n" + "</Document>\n";
			string document = "<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:seev.036.002.07\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n" + "<CorpActnMvmntConf>\n" + "		<MvmntPrlimryAdvcId>\n" + "			<Id>2016120815902666</Id>\n" + "		</MvmntPrlimryAdvcId>\n" + "		<CorpActnGnlInf>\n" + "			<CorpActnEvtId>12345678</CorpActnEvtId>\n" + "			<OffclCorpActnEvtId>US12345678</OffclCorpActnEvtId>\n" + "			<EvtTp><Cd>PDEF</Cd></EvtTp>\n" + "			<FinInstrmId>\n" + "				<OthrId>\n" + "					<Id>172311HA3</Id>\n" + "					<Tp><Cd>CUSP</Cd></Tp>\n" + "				</OthrId>\n" + "				<Desc>FOOOWSR05.000JD21BE</Desc>\n" + "			</FinInstrmId>\n" + "		</CorpActnGnlInf>\n" + "	<SplmtryData>\n" + "		<Envlp>\n" + "			<Document xmlns=\"urn:swift:xsd:supl.011.001.04\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n" + "				<DTCCCACOSD1>\n" + "					<CorpActnGnlInf>\n" + "						<PlcAndNm>/Document/CorpActnMvmntConf/CorpActnGnlInf</PlcAndNm>\n" + "						<EvtGrp>REDM</EvtGrp>\n" + "						<RedId>1379145963</RedId>\n" + "					</CorpActnGnlInf>\n" + "					<CorpActnConfSctiesMvmntDtls>\n" + "						<PlcAndNm>foo</PlcAndNm>\n" + "						<CdtDbtInd>CRDT</CdtDbtInd>\n" + "						<PyoutTp>SECU</PyoutTp>\n" + "						<MtrtyDt>2017-12-01</MtrtyDt>\n" + "					</CorpActnConfSctiesMvmntDtls>\n" + "				</DTCCCACOSD1>\n" + "			</Document>\n" + "		</Envlp>\n" + "	</SplmtryData>\n" + "</CorpActnMvmntConf>\n" + "</Document>\n";

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = "<?xml version=\"1.0\"?>\n" + "<env:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:env=\"CDTS-SUBMIT\">\n" + "	<env:Body>\n" + "		<cdtPrefix>\n" + "			<cdtprVersion>01</cdtprVersion>\n" + "			<cdtprOperation>SUBMIT</cdtprOperation>\n" + "			<cdtprFunction>REDMS1O</cdtprFunction>\n" + "			<cdtprDirectionFlag>O</cdtprDirectionFlag>\n" + "		</cdtPrefix>\n" + "		<cdtDataDescription>\n" + "			<cdtddVersion>01</cdtddVersion>\n" + "			<cdtddFirmId>DTCCUS3NRED</cdtddFirmId>\n" + "		</cdtDataDescription>\n" + "		<cdtBusinessData>\n" + sampleBAH + document + "		</cdtBusinessData>\n" + "	</env:Body>\n" + "</env:Envelope>";
			string xml = "<?xml version=\"1.0\"?>\n" + "<env:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:env=\"CDTS-SUBMIT\">\n" + "	<env:Body>\n" + "		<cdtPrefix>\n" + "			<cdtprVersion>01</cdtprVersion>\n" + "			<cdtprOperation>SUBMIT</cdtprOperation>\n" + "			<cdtprFunction>REDMS1O</cdtprFunction>\n" + "			<cdtprDirectionFlag>O</cdtprDirectionFlag>\n" + "		</cdtPrefix>\n" + "		<cdtDataDescription>\n" + "			<cdtddVersion>01</cdtddVersion>\n" + "			<cdtddFirmId>DTCCUS3NRED</cdtddFirmId>\n" + "		</cdtDataDescription>\n" + "		<cdtBusinessData>\n" + sampleBAH + document + "		</cdtBusinessData>\n" + "	</env:Body>\n" + "</env:Envelope>";

			MxParser p = new MxParser(xml);
			assertEquals(new MxId("seev.036.002.07"), p.detectMessage());
			MxStructureInfo info = p.analyzeMessage();
			assertTrue(info.containsDocument());
			assertTrue(info.containsHeader());
			assertTrue(info.containsWrapper());
			assertEquals("urn:iso:std:iso:20022:tech:xsd:seev.036.002.07", info.DocumentNamespace);
			assertNull(info.DocumentPrefix);
			assertEquals("urn:iso:std:iso:20022:tech:xsd:head.001.001.01", info.HeaderNamespace);
			assertNull(info.HeaderPrefix);
			assertNull(info.Exception);
			assertXMLEqual(sampleBAH, p.stripHeader());
			assertXMLEqual(document, p.stripDocument());
		}

		public static readonly string sampleBAH = "<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n" + "<Fr> \n" + "	<FIId>\n" + "		<FinInstnId>\n" + "			<BICFI>FOOCUS3NXXX</BICFI>\n" + "			<ClrSysMmbId>\n" + "				<ClrSysId>\n" + "					<Prtry>T2S</Prtry>\n" + "				</ClrSysId>\n" + "				<MmbId>ADMNUSERLUXCSDT1</MmbId>\n" + "			</ClrSysMmbId>\n" + "			<Othr>\n" + "				<Id>FOOTXE2SXXX</Id>\n" + "				</Othr> \n" + "		</FinInstnId> \n" + "	</FIId> \n" + "</Fr> \n" + "<To> \n" + "	<FIId>\n" + "		<FinInstnId>\n" + "			<BICFI>ABICUS33</BICFI>\n" + "			<Othr>\n" + "				<Id>AARBDE5W100</Id>\n" + "			</Othr>\n" + "		</FinInstnId> \n" + "	</FIId> \n" + "</To> \n" + "<BizMsgIdr>2012111915360885</BizMsgIdr>\n" + "<MsgDefIdr>seev.031.002.03</MsgDefIdr> \n" + "<BizSvc>CSD</BizSvc> \n" + "<CreDt>2015-08-27T08:59:00Z</CreDt>\n" + "</AppHdr>";

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void assertSampleBusinessApplicationHeader(final com.prowidesoftware.swift.model.mx.BusinessHeader bh)
		public static void assertSampleBusinessApplicationHeader(BusinessHeader bh)
		{
			assertNotNull(bh);
			BusinessApplicationHeaderV01 bah = bh.BusinessApplicationHeader;
			assertNotNull(bah);
			/*
			 * From
			 */
			assertNotNull(bah.Fr);
			assertNotNull(bah.Fr.FIId);
			assertNotNull(bah.Fr.FIId.FinInstnId);
			assertEquals("FOOCUS3NXXX", bah.Fr.FIId.FinInstnId.BICFI);
			assertEquals("T2S", bah.Fr.FIId.FinInstnId.ClrSysMmbId.ClrSysId.Prtry);
			assertEquals("ADMNUSERLUXCSDT1", bah.Fr.FIId.FinInstnId.ClrSysMmbId.MmbId);
			/*
			 * To
			 */
			assertNotNull(bah.To);
			assertNotNull(bah.To.FIId);
			assertNotNull(bah.To.FIId.FinInstnId);
			assertEquals("ABICUS33", bah.To.FIId.FinInstnId.BICFI);
			assertEquals("AARBDE5W100", bah.To.FIId.FinInstnId.Othr.Id);
			/*
			 * Reference, date, etc
			 */
			assertEquals("2012111915360885", bah.BizMsgIdr);
			assertEquals("seev.031.002.03", bah.MsgDefIdr);
			assertEquals("CSD", bah.BizSvc);
			assertNotNull(bah.CreDt);
			assertEquals(2015, bah.CreDt.Year);
			assertEquals(8, bah.CreDt.Month);
		}

	}

}