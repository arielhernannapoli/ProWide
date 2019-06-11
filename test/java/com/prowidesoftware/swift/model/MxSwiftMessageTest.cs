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
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;


	using MT103 = com.prowidesoftware.swift.model.mt.mt1xx.MT103;
	using MT103_STP = com.prowidesoftware.swift.model.mt.mt1xx.MT103_STP;
	using MT202 = com.prowidesoftware.swift.model.mt.mt2xx.MT202;
	using MT202COV = com.prowidesoftware.swift.model.mt.mt2xx.MT202COV;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using JsonObject = com.google.gson.JsonObject;
	using JsonParser = com.google.gson.JsonParser;
	using Assert = org.junit.Assert;
	using Test = org.junit.Test;

	public class MxSwiftMessageTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRead() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRead()
		{
			File f = File.createTempFile("mx_", ".xml");
			MxSwiftMessage mx = new MxSwiftMessage(f);
			Assert.assertEquals(mx.Message, "");
			f.deleteOnExit();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadSimple() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadSimple()
		{
			File f = File.createTempFile("mx_", ".xml");
			FileOutputStream fos = new FileOutputStream(f);
			fos.write("<?xml version=\"1.0\" ?>".GetBytes());
			fos.write("<Document/>".GetBytes());
			fos.close();
			MxSwiftMessage mx = new MxSwiftMessage(f);
			Assert.assertTrue(StringUtils.contains(mx.Message, "Document"));
			f.deleteOnExit();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMetadataFromGrpHr()
		public virtual void testMetadataFromGrpHr()
		{
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.008.001.02\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.six-interbank-clearing.com/de/pacs.008.001.02.ch.01 pacs.008.001.02.ch.01.xsd\">" + "<FIToFICstmrCdtTrf>" + "	<GrpHdr>" + "		<MsgId>MSGID-0001</MsgId>" + "		<CreDtTm>2001-12-17T09:30:47Z</CreDtTm>" + "		<NbOfTxs>1</NbOfTxs>" + "		<IntrBkSttlmDt>2012-01-25</IntrBkSttlmDt>" + "		<SttlmInf><SttlmMtd>INDA</SttlmMtd></SttlmInf>" + "		<InstgAgt><FinInstnId><BIC>KBBECH20DSZ</BIC></FinInstnId></InstgAgt>" + "		<InstdAgt><FinInstnId><BIC>DRESDEF0VNZ</BIC></FinInstnId></InstdAgt>" + "	</GrpHdr>" + "	<CdtTrfTxInf>" + " </CdtTrfTxInf>" + "</FIToFICstmrCdtTrf>" + "</Document>";
			MxSwiftMessage mx = new MxSwiftMessage(xml);
			assertNotNull(mx);
			assertEquals("pacs.008.001.02", mx.Identifier);
			assertEquals("KBBECH20DSZ", mx.Sender);
			assertEquals("DRESDEF0VNZ", mx.Receiver);
			assertEquals("MSGID-0001", mx.Reference);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMetadataFromAppHdr()
		public virtual void testMetadataFromAppHdr()
		{
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<message>" + "<AppHdr xmlns:Ah=\"urn:swift:xsd$ahV10\">" + "<From>" + "	<Type>DN</Type>" + " <Id>cn=funds,o=abcdchzzwww,o=swift</Id>" + "</From>" + "<To>" + "	<Type>DN</Type>" + "	<Id>cn=funds,o=dcbadeff,o=swift</Id>" + "</To>" + "	<MsgRef>11308917</MsgRef>" + "	<CrDate>2013-12-23T15:50:00</CrDate>" + "</AppHdr>" + "<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.008.001.02\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.six-interbank-clearing.com/de/pacs.008.001.02.ch.01 pacs.008.001.02.ch.01.xsd\">" + "<FIToFICstmrCdtTrf>" + "	<GrpHdr>" + "		<MsgId>MSGID-0001</MsgId>" + "		<CreDtTm>2001-12-17T09:30:47Z</CreDtTm>" + "		<NbOfTxs>1</NbOfTxs>" + "		<IntrBkSttlmDt>2012-01-25</IntrBkSttlmDt>" + "		<SttlmInf><SttlmMtd>INDA</SttlmMtd></SttlmInf>" + "		<InstgAgt><FinInstnId><BIC>KBBECH20DSZ</BIC></FinInstnId></InstgAgt>" + "		<InstdAgt><FinInstnId><BIC>DRESDEF0VNZ</BIC></FinInstnId></InstdAgt>" + "	</GrpHdr>" + "	<CdtTrfTxInf>" + " </CdtTrfTxInf>" + "</FIToFICstmrCdtTrf>" + "</Document>" + "</message>";
			MxSwiftMessage mx = new MxSwiftMessage(xml);
			assertNotNull(mx);
			assertEquals("pacs.008.001.02", mx.Identifier);
			assertEquals("ABCDCHZZWWW", mx.Sender);
			assertEquals("DCBADEFFXXX", mx.Receiver);
			assertEquals("11308917", mx.Reference);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMetadataFromDocumentWithoutNamespace()
		public virtual void testMetadataFromDocumentWithoutNamespace()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = "<Document><setr.015.001.02><RltdRef><Ref>24512SWI67-IT</Ref><MsgNm>setr.013.001.01</MsgNm></RltdRef><SwtchExctnDtls><DealRef>IT56/89/90</DealRef><OrdrRef>20042402090912</OrdrRef><InvstmtAcctDtls><AcctId><Prtry><Id>A67367Z32-67</Id></Prtry></AcctId></InvstmtAcctDtls><AddtlCshIn Ccy=\"EUR\">200</AddtlCshIn><RedLegDtls><LegId>1</LegId><FinInstrmDtls><Id><ISIN>IT1111111111</ISIN></Id></FinInstrmDtls><UnitsNb><Unit>25</Unit></UnitsNb><NetAmt Ccy=\"EUR\">500</NetAmt><TradDtTm><Dt>2005-11-10</Dt></TradDtTm><PricDtls><Tp><Strd>SWIC</Strd></Tp><Val><Amt Ccy=\"EUR\">20</Amt></Val></PricDtls><CumDvddInd>true</CumDvddInd><PhysDlvryInd>false</PhysDlvryInd></RedLegDtls><SbcptLegDtls><LegId>2</LegId><FinInstrmDtls><Id><ISIN>IT2222222222</ISIN></Id></FinInstrmDtls><UnitsNb><Unit>100</Unit></UnitsNb><NetAmt Ccy=\"EUR\">700</NetAmt><TradDtTm><Dt>2005-11-10</Dt></TradDtTm><PricDtls><Tp><Strd>SWIC</Strd></Tp><Val><Amt Ccy=\"EUR\">7</Amt></Val></PricDtls><CumDvddInd>true</CumDvddInd><PhysDlvryInd>false</PhysDlvryInd></SbcptLegDtls></SwtchExctnDtls></setr.015.001.02></Document>";
			string xml = "<Document><setr.015.001.02><RltdRef><Ref>24512SWI67-IT</Ref><MsgNm>setr.013.001.01</MsgNm></RltdRef><SwtchExctnDtls><DealRef>IT56/89/90</DealRef><OrdrRef>20042402090912</OrdrRef><InvstmtAcctDtls><AcctId><Prtry><Id>A67367Z32-67</Id></Prtry></AcctId></InvstmtAcctDtls><AddtlCshIn Ccy=\"EUR\">200</AddtlCshIn><RedLegDtls><LegId>1</LegId><FinInstrmDtls><Id><ISIN>IT1111111111</ISIN></Id></FinInstrmDtls><UnitsNb><Unit>25</Unit></UnitsNb><NetAmt Ccy=\"EUR\">500</NetAmt><TradDtTm><Dt>2005-11-10</Dt></TradDtTm><PricDtls><Tp><Strd>SWIC</Strd></Tp><Val><Amt Ccy=\"EUR\">20</Amt></Val></PricDtls><CumDvddInd>true</CumDvddInd><PhysDlvryInd>false</PhysDlvryInd></RedLegDtls><SbcptLegDtls><LegId>2</LegId><FinInstrmDtls><Id><ISIN>IT2222222222</ISIN></Id></FinInstrmDtls><UnitsNb><Unit>100</Unit></UnitsNb><NetAmt Ccy=\"EUR\">700</NetAmt><TradDtTm><Dt>2005-11-10</Dt></TradDtTm><PricDtls><Tp><Strd>SWIC</Strd></Tp><Val><Amt Ccy=\"EUR\">7</Amt></Val></PricDtls><CumDvddInd>true</CumDvddInd><PhysDlvryInd>false</PhysDlvryInd></SbcptLegDtls></SwtchExctnDtls></setr.015.001.02></Document>";
			MxSwiftMessage mx = new MxSwiftMessage(xml);
			assertNotNull(mx);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMxId()
		public virtual void testMxId()
		{
			MxSwiftMessage m = new MxSwiftMessage();
			assertNull(m.MxId.BusinessProcess);
			assertNull(m.MxId.Functionality);
			assertNull(m.MxId.Variant);
			assertNull(m.MxId.Version);

			string xml = "<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.008.001.02\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.six-interbank-clearing.com/de/pacs.008.001.02.ch.01 pacs.008.001.02.ch.01.xsd\"></Document>";
			m = new MxSwiftMessage(xml);

			assertEquals(new MxId(MxBusinessProcess.pacs, "008", "001", "02"), m.MxId);
		}

	}

}