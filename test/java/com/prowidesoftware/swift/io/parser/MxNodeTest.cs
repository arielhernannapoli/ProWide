﻿/*
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

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;


	using Test = org.junit.Test;

	using MxNode = com.prowidesoftware.swift.model.MxNode;

	/// <summary>
	/// Test cases for <seealso cref="MxParser"/> XML conversion into <seealso cref="MxNode"/>
	/// and content finder API on the parsed structure. 
	/// 
	/// @since 7.8.8
	/// </summary>
	public class MxNodeTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse01() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse01()
		{
			const string xml = "<FaceAmount>1234567.89</FaceAmount>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(xml).parse();
			MxNode doc = (new MxParser(xml)).parse();
			assertEquals("1234567.89", doc.findFirstByName("FaceAmount").Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse02() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse02()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:semt.002.002.03\">" + "   <Doc:SecuritiesBalanceCustodyReport.002V03>" + "      <Doc:Identification>" + "         <Doc:Identification>ICF2750609140005</Doc:Identification>" + "      </Doc:Identification>" + "      <Doc:Pagination>" + "         <Doc:PageNumber>00005</Doc:PageNumber>" + "         <Doc:LastPageIndicator>false</Doc:LastPageIndicator>" + "      </Doc:Pagination>" + "      <Doc:StatementGeneralDetails>" + "         <Doc:StatementDateTime>" + "            <Doc:Date>2006-09-13T00:00:00</Doc:Date>" + "         </Doc:StatementDateTime>" + "         <Doc:Frequency>" + "            <Doc:Code>DAIL</Doc:Code>" + "         </Doc:Frequency>" + "         <Doc:UpdateType>" + "            <Doc:Code>COMP</Doc:Code>" + "         </Doc:UpdateType>" + "         <Doc:StatementBasis>" + "            <Doc:Code>TRAD</Doc:Code>" + "         </Doc:StatementBasis>" + "         <Doc:ActivityIndicator>true</Doc:ActivityIndicator>" + "         <Doc:SubAccountIndicator>false</Doc:SubAccountIndicator>" + "      </Doc:StatementGeneralDetails>" + "      <Doc:SafekeepingAccount>" + "         <Doc:Identification>F275</Doc:Identification>" + "      </Doc:SafekeepingAccount>" + "      <Doc:BalanceForAccount>" + "         <Doc:FinancialInstrumentIdentification>" + "            <Doc:Identification>" + "               <Doc:OtherIdentification>" + "                  <Doc:Identification>31392EXH8</Doc:Identification>" + "                  <Doc:IdentificationSource>" + "                     <Doc:Domestic>US</Doc:Domestic>" + "                  </Doc:IdentificationSource>" + "               </Doc:OtherIdentification>" + "            </Doc:Identification>" + "            <Doc:Description>/US/31392EXH8 FEDERAL FOO MTG ASSN</Doc:Description>" + "         </Doc:FinancialInstrumentIdentification>" + "         <Doc:FinancialInstrumentAttributes>" + "            <Doc:CurrentFactor>0.14528727</Doc:CurrentFactor>" + "         </Doc:FinancialInstrumentAttributes>" + "         <Doc:AggregateBalance>" + "            <Doc:ShortLongIndicator>LONG</Doc:ShortLongIndicator>" + "            <Doc:Quantity>" + "               <Doc:Quantity>" + "                  <Doc:OriginalAndCurrentFace>" + "                     <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "                     <Doc:AmortisedValue>35732656.0</Doc:AmortisedValue>" + "                  </Doc:OriginalAndCurrentFace>" + "               </Doc:Quantity>" + "            </Doc:Quantity>" + "         </Doc:AggregateBalance>" + "         <Doc:AvailableBalance>" + "            <Doc:Quantity>" + "               <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "            </Doc:Quantity>" + "         </Doc:AvailableBalance>" + "         <Doc:SafekeepingPlace>" + "            <Doc:TypeAndIdentification>" + "               <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "               <Doc:Identification>FRNYUS33</Doc:Identification>" + "            </Doc:TypeAndIdentification>" + "         </Doc:SafekeepingPlace>" + "         <Doc:BalanceAtSafekeepingPlace>" + "            <Doc:SafekeepingPlace>" + "               <Doc:TypeAndIdentification>" + "                  <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "                  <Doc:Identification>FRNYUS33</Doc:Identification>" + "               </Doc:TypeAndIdentification>" + "            </Doc:SafekeepingPlace>" + "            <Doc:AggregateBalance>" + "               <Doc:ShortLongIndicator>LONG</Doc:ShortLongIndicator>" + "               <Doc:Quantity>" + "                  <Doc:Quantity>" + "                     <Doc:Quantity>" + "                        <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "                     </Doc:Quantity>" + "                  </Doc:Quantity>" + "               </Doc:Quantity>" + "            </Doc:AggregateBalance>" + "            <Doc:AvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:AvailableBalance>" + "         </Doc:BalanceAtSafekeepingPlace>" + "         <Doc:BalanceAtSafekeepingPlace>" + "            <Doc:SafekeepingPlace>" + "               <Doc:TypeAndIdentification>" + "                  <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "                  <Doc:Identification>FRNYUS33</Doc:Identification>" + "               </Doc:TypeAndIdentification>" + "            </Doc:SafekeepingPlace>" + "            <Doc:AggregateBalance>" + "               <Doc:ShortLongIndicator>LONG</Doc:ShortLongIndicator>" + "               <Doc:Quantity>" + "                  <Doc:Quantity>" + "                     <Doc:Quantity>" + "                        <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "                     </Doc:Quantity>" + "                  </Doc:Quantity>" + "               </Doc:Quantity>" + "            </Doc:AggregateBalance>" + "            <Doc:AvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:AvailableBalance>" + "         </Doc:BalanceAtSafekeepingPlace>" + "      </Doc:BalanceForAccount>" + "      <Doc:BalanceForAccount>" + "         <Doc:FinancialInstrumentIdentification>" + "            <Doc:Identification>" + "               <Doc:OtherIdentification>" + "                  <Doc:Identification>31406RR72</Doc:Identification>" + "                  <Doc:IdentificationSource>" + "                     <Doc:Domestic>US</Doc:Domestic>" + "                  </Doc:IdentificationSource>" + "               </Doc:OtherIdentification>" + "            </Doc:Identification>" + "            <Doc:Description>/US/31406RR72 FOO POOL 817810</Doc:Description>" + "         </Doc:FinancialInstrumentIdentification>" + "         <Doc:FinancialInstrumentAttributes>" + "            <Doc:CurrentFactor>0.0</Doc:CurrentFactor>" + "         </Doc:FinancialInstrumentAttributes>" + "         <Doc:AggregateBalance>" + "            <Doc:ShortLongIndicator>LONG</Doc:ShortLongIndicator>" + "            <Doc:Quantity>" + "               <Doc:Quantity>" + "                  <Doc:OriginalAndCurrentFace>" + "                     <Doc:FaceAmount>0.0</Doc:FaceAmount>" + "                     <Doc:AmortisedValue>0.0</Doc:AmortisedValue>" + "                  </Doc:OriginalAndCurrentFace>" + "               </Doc:Quantity>" + "            </Doc:Quantity>" + "         </Doc:AggregateBalance>" + "         <Doc:AvailableBalance>" + "            <Doc:Quantity>" + "               <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "            </Doc:Quantity>" + "         </Doc:AvailableBalance>" + "         <Doc:NotAvailableBalance>" + "            <Doc:Quantity>" + "               <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "            </Doc:Quantity>" + "         </Doc:NotAvailableBalance>" + "         <Doc:SafekeepingPlace>" + "            <Doc:TypeAndIdentification>" + "               <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "               <Doc:Identification>FRNYUS33</Doc:Identification>" + "            </Doc:TypeAndIdentification>" + "         </Doc:SafekeepingPlace>" + "         <Doc:BalanceAtSafekeepingPlace>" + "            <Doc:SafekeepingPlace>" + "               <Doc:TypeAndIdentification>" + "                  <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "                  <Doc:Identification>FRNYUS33</Doc:Identification>" + "               </Doc:TypeAndIdentification>" + "            </Doc:SafekeepingPlace>" + "            <Doc:AggregateBalance>" + "               <Doc:ShortLongIndicator>SHOR</Doc:ShortLongIndicator>" + "               <Doc:Quantity>" + "                  <Doc:Quantity>" + "                     <Doc:Quantity>" + "                        <Doc:FaceAmount>0.0</Doc:FaceAmount>" + "                     </Doc:Quantity>" + "                  </Doc:Quantity>" + "               </Doc:Quantity>" + "            </Doc:AggregateBalance>" + "            <Doc:AvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:AvailableBalance>" + "            <Doc:NotAvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:NotAvailableBalance>" + "         </Doc:BalanceAtSafekeepingPlace>" + "         <Doc:BalanceAtSafekeepingPlace>" + "            <Doc:SafekeepingPlace>" + "               <Doc:TypeAndIdentification>" + "                  <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "                  <Doc:Identification>FRNYUS33</Doc:Identification>" + "               </Doc:TypeAndIdentification>" + "            </Doc:SafekeepingPlace>" + "            <Doc:AggregateBalance>" + "               <Doc:ShortLongIndicator>SHOR</Doc:ShortLongIndicator>" + "               <Doc:Quantity>" + "                  <Doc:Quantity>" + "                     <Doc:Quantity>" + "                        <Doc:FaceAmount>0.0</Doc:FaceAmount>" + "                     </Doc:Quantity>" + "                  </Doc:Quantity>" + "               </Doc:Quantity>" + "            </Doc:AggregateBalance>" + "            <Doc:AvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:AvailableBalance>" + "            <Doc:NotAvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:NotAvailableBalance>" + "         </Doc:BalanceAtSafekeepingPlace>" + "      </Doc:BalanceForAccount>" + "   </Doc:SecuritiesBalanceCustodyReport.002V03>" + "</Doc:Document>";
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<Doc:Document xmlns:Doc=\"urn:swift:xsd:semt.002.002.03\">" + "   <Doc:SecuritiesBalanceCustodyReport.002V03>" + "      <Doc:Identification>" + "         <Doc:Identification>ICF2750609140005</Doc:Identification>" + "      </Doc:Identification>" + "      <Doc:Pagination>" + "         <Doc:PageNumber>00005</Doc:PageNumber>" + "         <Doc:LastPageIndicator>false</Doc:LastPageIndicator>" + "      </Doc:Pagination>" + "      <Doc:StatementGeneralDetails>" + "         <Doc:StatementDateTime>" + "            <Doc:Date>2006-09-13T00:00:00</Doc:Date>" + "         </Doc:StatementDateTime>" + "         <Doc:Frequency>" + "            <Doc:Code>DAIL</Doc:Code>" + "         </Doc:Frequency>" + "         <Doc:UpdateType>" + "            <Doc:Code>COMP</Doc:Code>" + "         </Doc:UpdateType>" + "         <Doc:StatementBasis>" + "            <Doc:Code>TRAD</Doc:Code>" + "         </Doc:StatementBasis>" + "         <Doc:ActivityIndicator>true</Doc:ActivityIndicator>" + "         <Doc:SubAccountIndicator>false</Doc:SubAccountIndicator>" + "      </Doc:StatementGeneralDetails>" + "      <Doc:SafekeepingAccount>" + "         <Doc:Identification>F275</Doc:Identification>" + "      </Doc:SafekeepingAccount>" + "      <Doc:BalanceForAccount>" + "         <Doc:FinancialInstrumentIdentification>" + "            <Doc:Identification>" + "               <Doc:OtherIdentification>" + "                  <Doc:Identification>31392EXH8</Doc:Identification>" + "                  <Doc:IdentificationSource>" + "                     <Doc:Domestic>US</Doc:Domestic>" + "                  </Doc:IdentificationSource>" + "               </Doc:OtherIdentification>" + "            </Doc:Identification>" + "            <Doc:Description>/US/31392EXH8 FEDERAL FOO MTG ASSN</Doc:Description>" + "         </Doc:FinancialInstrumentIdentification>" + "         <Doc:FinancialInstrumentAttributes>" + "            <Doc:CurrentFactor>0.14528727</Doc:CurrentFactor>" + "         </Doc:FinancialInstrumentAttributes>" + "         <Doc:AggregateBalance>" + "            <Doc:ShortLongIndicator>LONG</Doc:ShortLongIndicator>" + "            <Doc:Quantity>" + "               <Doc:Quantity>" + "                  <Doc:OriginalAndCurrentFace>" + "                     <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "                     <Doc:AmortisedValue>35732656.0</Doc:AmortisedValue>" + "                  </Doc:OriginalAndCurrentFace>" + "               </Doc:Quantity>" + "            </Doc:Quantity>" + "         </Doc:AggregateBalance>" + "         <Doc:AvailableBalance>" + "            <Doc:Quantity>" + "               <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "            </Doc:Quantity>" + "         </Doc:AvailableBalance>" + "         <Doc:SafekeepingPlace>" + "            <Doc:TypeAndIdentification>" + "               <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "               <Doc:Identification>FRNYUS33</Doc:Identification>" + "            </Doc:TypeAndIdentification>" + "         </Doc:SafekeepingPlace>" + "         <Doc:BalanceAtSafekeepingPlace>" + "            <Doc:SafekeepingPlace>" + "               <Doc:TypeAndIdentification>" + "                  <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "                  <Doc:Identification>FRNYUS33</Doc:Identification>" + "               </Doc:TypeAndIdentification>" + "            </Doc:SafekeepingPlace>" + "            <Doc:AggregateBalance>" + "               <Doc:ShortLongIndicator>LONG</Doc:ShortLongIndicator>" + "               <Doc:Quantity>" + "                  <Doc:Quantity>" + "                     <Doc:Quantity>" + "                        <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "                     </Doc:Quantity>" + "                  </Doc:Quantity>" + "               </Doc:Quantity>" + "            </Doc:AggregateBalance>" + "            <Doc:AvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:AvailableBalance>" + "         </Doc:BalanceAtSafekeepingPlace>" + "         <Doc:BalanceAtSafekeepingPlace>" + "            <Doc:SafekeepingPlace>" + "               <Doc:TypeAndIdentification>" + "                  <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "                  <Doc:Identification>FRNYUS33</Doc:Identification>" + "               </Doc:TypeAndIdentification>" + "            </Doc:SafekeepingPlace>" + "            <Doc:AggregateBalance>" + "               <Doc:ShortLongIndicator>LONG</Doc:ShortLongIndicator>" + "               <Doc:Quantity>" + "                  <Doc:Quantity>" + "                     <Doc:Quantity>" + "                        <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "                     </Doc:Quantity>" + "                  </Doc:Quantity>" + "               </Doc:Quantity>" + "            </Doc:AggregateBalance>" + "            <Doc:AvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>35732656.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:AvailableBalance>" + "         </Doc:BalanceAtSafekeepingPlace>" + "      </Doc:BalanceForAccount>" + "      <Doc:BalanceForAccount>" + "         <Doc:FinancialInstrumentIdentification>" + "            <Doc:Identification>" + "               <Doc:OtherIdentification>" + "                  <Doc:Identification>31406RR72</Doc:Identification>" + "                  <Doc:IdentificationSource>" + "                     <Doc:Domestic>US</Doc:Domestic>" + "                  </Doc:IdentificationSource>" + "               </Doc:OtherIdentification>" + "            </Doc:Identification>" + "            <Doc:Description>/US/31406RR72 FOO POOL 817810</Doc:Description>" + "         </Doc:FinancialInstrumentIdentification>" + "         <Doc:FinancialInstrumentAttributes>" + "            <Doc:CurrentFactor>0.0</Doc:CurrentFactor>" + "         </Doc:FinancialInstrumentAttributes>" + "         <Doc:AggregateBalance>" + "            <Doc:ShortLongIndicator>LONG</Doc:ShortLongIndicator>" + "            <Doc:Quantity>" + "               <Doc:Quantity>" + "                  <Doc:OriginalAndCurrentFace>" + "                     <Doc:FaceAmount>0.0</Doc:FaceAmount>" + "                     <Doc:AmortisedValue>0.0</Doc:AmortisedValue>" + "                  </Doc:OriginalAndCurrentFace>" + "               </Doc:Quantity>" + "            </Doc:Quantity>" + "         </Doc:AggregateBalance>" + "         <Doc:AvailableBalance>" + "            <Doc:Quantity>" + "               <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "            </Doc:Quantity>" + "         </Doc:AvailableBalance>" + "         <Doc:NotAvailableBalance>" + "            <Doc:Quantity>" + "               <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "            </Doc:Quantity>" + "         </Doc:NotAvailableBalance>" + "         <Doc:SafekeepingPlace>" + "            <Doc:TypeAndIdentification>" + "               <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "               <Doc:Identification>FRNYUS33</Doc:Identification>" + "            </Doc:TypeAndIdentification>" + "         </Doc:SafekeepingPlace>" + "         <Doc:BalanceAtSafekeepingPlace>" + "            <Doc:SafekeepingPlace>" + "               <Doc:TypeAndIdentification>" + "                  <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "                  <Doc:Identification>FRNYUS33</Doc:Identification>" + "               </Doc:TypeAndIdentification>" + "            </Doc:SafekeepingPlace>" + "            <Doc:AggregateBalance>" + "               <Doc:ShortLongIndicator>SHOR</Doc:ShortLongIndicator>" + "               <Doc:Quantity>" + "                  <Doc:Quantity>" + "                     <Doc:Quantity>" + "                        <Doc:FaceAmount>0.0</Doc:FaceAmount>" + "                     </Doc:Quantity>" + "                  </Doc:Quantity>" + "               </Doc:Quantity>" + "            </Doc:AggregateBalance>" + "            <Doc:AvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:AvailableBalance>" + "            <Doc:NotAvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:NotAvailableBalance>" + "         </Doc:BalanceAtSafekeepingPlace>" + "         <Doc:BalanceAtSafekeepingPlace>" + "            <Doc:SafekeepingPlace>" + "               <Doc:TypeAndIdentification>" + "                  <Doc:SafekeepingPlaceType>NCSD</Doc:SafekeepingPlaceType>" + "                  <Doc:Identification>FRNYUS33</Doc:Identification>" + "               </Doc:TypeAndIdentification>" + "            </Doc:SafekeepingPlace>" + "            <Doc:AggregateBalance>" + "               <Doc:ShortLongIndicator>SHOR</Doc:ShortLongIndicator>" + "               <Doc:Quantity>" + "                  <Doc:Quantity>" + "                     <Doc:Quantity>" + "                        <Doc:FaceAmount>0.0</Doc:FaceAmount>" + "                     </Doc:Quantity>" + "                  </Doc:Quantity>" + "               </Doc:Quantity>" + "            </Doc:AggregateBalance>" + "            <Doc:AvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:AvailableBalance>" + "            <Doc:NotAvailableBalance>" + "               <Doc:Quantity>" + "                  <Doc:FaceAmount>990692.0</Doc:FaceAmount>" + "               </Doc:Quantity>" + "            </Doc:NotAvailableBalance>" + "         </Doc:BalanceAtSafekeepingPlace>" + "      </Doc:BalanceForAccount>" + "   </Doc:SecuritiesBalanceCustodyReport.002V03>" + "</Doc:Document>";

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MxParser parser = new MxParser(xml);
			MxParser parser = new MxParser(xml);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode n = parser.parse();
			MxNode n = parser.parse();
			assertEquals("35732656.0", n.singlePathValue("/Document/SecuritiesBalanceCustodyReport.002V03/BalanceForAccount/AggregateBalance/Quantity/Quantity/OriginalAndCurrentFace/FaceAmount"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse03_attributes() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse03_attributes()
		{
			const string xml = "<FaceAmount Ccy='USD'>1234567.89</FaceAmount>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(xml).parse();
			MxNode doc = (new MxParser(xml)).parse();
			assertEquals("1234567.89", doc.findFirstByName("FaceAmount").Value);
			assertEquals("USD", doc.findFirstByName("FaceAmount").getAttribute("Ccy"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse04_ns() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse04_ns()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = "<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></AppHdr>";
			string xml = "<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\"><From></From></AppHdr>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(xml).parse();
			MxNode doc = (new MxParser(xml)).parse();
			assertEquals("urn:iso:std:iso:20022:tech:xsd:head.001.001.01", doc.findFirstByName("AppHdr").getAttribute("xmlns"));
			assertNotNull(doc.findFirst("AppHdr/From"));
			assertNull(doc.findFirst("AppHdr/From").getAttribute("xmlns"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFindFirst() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFindFirst()
		{
			string xml = "<a></a>";
			MxNode doc = (new MxParser(xml)).parse();
			assertNull(doc.singlePathValue("a"));

			xml = "<a>1</a>";
			doc = (new MxParser(xml)).parse();
			assertEquals("1", doc.singlePathValue("a"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFindFirstLevel2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFindFirstLevel2()
		{
			string xml = "<a><a>1</a></a>";
			MxNode doc = (new MxParser(xml)).parse();
			assertEquals("1", doc.singlePathValue("a/a"));

			xml = "<a><b>2</b></a>";
			doc = (new MxParser(xml)).parse();
			assertEquals("2", doc.singlePathValue("a/b"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFindFirstWithChildren() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFindFirstWithChildren()
		{
			const string xml = "<a>" + "		<b>1</b>" + "		<c>2</c>" + "</a>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(xml).parse();
			MxNode doc = (new MxParser(xml)).parse();
			assertNotNull(doc.singlePathValue("a/b"));
			assertNotNull(doc.singlePathValue("a/c"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFindFirstAbsoluteAndRelativePath() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFindFirstAbsoluteAndRelativePath()
		{
			const string xml = "<a><b><c>1</c></b></a>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(xml).parse();
			MxNode doc = (new MxParser(xml)).parse();
			/*
			 * absolute
			 */
			assertEquals("1", doc.singlePathValue("/a/b/c"));
			/*
			 * relative from root
			 */
			assertEquals("1", doc.singlePathValue("a/b/c"));
			/*
			 * invalid relative
			 */
			assertNull(doc.singlePathValue("b/c"));
			/*
			 * invalid absolute
			 */
			assertNull(doc.singlePathValue("/b/c"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFindByName() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFindByName()
		{
			const string xml = "<a>1</a>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(xml).parse();
			MxNode doc = (new MxParser(xml)).parse();
			assertNotNull(doc.findFirstByName("a"));
			assertEquals("1", doc.findFirstByName("a").Value);
			assertTrue(doc.findFirstByName("b") == null);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFindByNameLevel2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFindByNameLevel2()
		{
			const string xml = "<a><b>2</b><b>3</b></a>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(xml).parse();
			MxNode doc = (new MxParser(xml)).parse();
			assertNotNull(doc.findFirstByName("a"));
			assertNotNull(doc.findFirstByName("b"));
			assertEquals("2", doc.findFirstByName("b").Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFindByNameAndPath() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFindByNameAndPath()
		{
			const string xml = "<a>" + "	<b>" + "		<c>" + "			<d>4</d>" + "		</c>" + "	</b>" + "</a>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(xml).parse();
			MxNode doc = (new MxParser(xml)).parse();

			assertEquals("4", doc.singlePathValue("/a/b/c/d"));

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode b = (com.prowidesoftware.swift.model.MxNode) doc.findFirstByName("b");
			MxNode b = (MxNode) doc.findFirstByName("b");
			assertNotNull(b);

			assertEquals("4", b.singlePathValue("b/c/d"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadSample() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadSample()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.InputStream inputStream = getClass().getResourceAsStream("/mx_sample_document.xml");
			InputStream inputStream = this.GetType().getResourceAsStream("/mx_sample_document.xml");
			assertNotNull(inputStream);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(inputStream).parse();
			MxNode doc = (new MxParser(inputStream)).parse();
			assertNotNull(doc);
			doc.print();
			assertEquals("1", doc.singlePathValue("Document/GetAcct/MsgId/Id"));
			assertEquals("1", doc.singlePathValue("/Document/GetAcct/MsgId/Id"));
			assertEquals("1", doc.singlePathValue("Document/GetAcct/MsgId/Id/"));
			assertEquals("1", doc.singlePathValue("/Document/GetAcct/MsgId/Id/"));
			assertNull(doc.singlePathValue("/foobar"));
			assertNull(doc.singlePathValue("/foobar/1/2/3/4/5/6/7"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadSampleByNode() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadSampleByNode()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.InputStream inputStream = getClass().getResourceAsStream("/mx_sample_document.xml");
			InputStream inputStream = this.GetType().getResourceAsStream("/mx_sample_document.xml");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(inputStream).parse();
			MxNode doc = (new MxParser(inputStream)).parse();
			doc.print();
			MxNode n = (MxNode) doc.findFirstByName("Id");
			assertNotNull(n);
			assertEquals("1", n.Value);
			n = (MxNode) doc.findFirstByName("ID");
			assertNotNull(n);
			assertEquals("1", n.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPathApplicationHeader() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPathApplicationHeader()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.InputStream inputStream = getClass().getResourceAsStream("/mx_sample_header.xml");
			InputStream inputStream = this.GetType().getResourceAsStream("/mx_sample_header.xml");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode doc = new MxParser(inputStream).parse();
			MxNode doc = (new MxParser(inputStream)).parse();
			assertNotNull(doc);
			assertEquals("DN", doc.singlePathValue("AppHdr/From/Type"));
			assertEquals("DN", doc.singlePathValue("/AppHdr/From/Type"));
		}

	}

}