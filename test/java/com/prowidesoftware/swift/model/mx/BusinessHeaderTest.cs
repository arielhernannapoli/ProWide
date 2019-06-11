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

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;


	using XMLAssert = org.custommonkey.xmlunit.XMLAssert;
	using XpathException = org.custommonkey.xmlunit.exceptions.XpathException;
	using Test = org.junit.Test;
	using SAXException = org.xml.sax.SAXException;

	using ApplicationHeader = com.prowidesoftware.swift.model.mx.dic.ApplicationHeader;
	using BranchAndFinancialInstitutionIdentification5 = com.prowidesoftware.swift.model.mx.dic.BranchAndFinancialInstitutionIdentification5;
	using BranchData2 = com.prowidesoftware.swift.model.mx.dic.BranchData2;
	using BusinessApplicationHeaderV01 = com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01;
	using EntityIdentification = com.prowidesoftware.swift.model.mx.dic.EntityIdentification;
	using FinancialInstitutionIdentification8 = com.prowidesoftware.swift.model.mx.dic.FinancialInstitutionIdentification8;
	using Party9Choice = com.prowidesoftware.swift.model.mx.dic.Party9Choice;
	using PostalAddress6 = com.prowidesoftware.swift.model.mx.dic.PostalAddress6;
	using TestUtils = com.prowidesoftware.swift.utils.TestUtils;

	/// <summary>
	/// Test cases for readign and writing MX headers
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8
	/// </summary>
	public class BusinessHeaderTest
	{

		/*
		 * ISO header
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteBAH() throws javax.xml.transform.TransformerConfigurationException, org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException, javax.xml.transform.TransformerException, org.custommonkey.xmlunit.exceptions.XpathException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testWriteBAH()
		{
			BusinessApplicationHeaderV01 bah = new BusinessApplicationHeaderV01();
			bah.Fr = new Party9Choice();
			bah.Fr.FIId = new BranchAndFinancialInstitutionIdentification5();

			bah.Fr.FIId.FinInstnId = new FinancialInstitutionIdentification8();
			bah.Fr.FIId.FinInstnId.BICFI = "BIC";

			bah.Fr.FIId.BrnchId = new BranchData2();
			bah.Fr.FIId.BrnchId.Id = "id";
			bah.Fr.FIId.BrnchId.Nm = "name";
			bah.Fr.FIId.BrnchId.PstlAdr = new PostalAddress6();
			bah.Fr.FIId.BrnchId.PstlAdr.Ctry = "AR";

			BusinessHeader header = new BusinessHeader();
			header.BusinessApplicationHeader = bah;

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = header.xml();
			string xml = header.xml();

			assertNotNull(xml);

			XMLAssert.assertXpathEvaluatesTo("BIC", TestUtils.patch("/AppHdr/Fr/FIId/FinInstnId/BICFI"), xml);
			XMLAssert.assertXpathEvaluatesTo("id", TestUtils.patch("/AppHdr/Fr/FIId/BrnchId/Id"), xml);
			XMLAssert.assertXpathEvaluatesTo("name", TestUtils.patch("/AppHdr/Fr/FIId/BrnchId/Nm"), xml);
		}

		/*
		 * SWIFT header
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteBH() throws javax.xml.transform.TransformerConfigurationException, org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException, javax.xml.transform.TransformerException, org.custommonkey.xmlunit.exceptions.XpathException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testWriteBH()
		{
			ApplicationHeader ah = new ApplicationHeader();
			ah.From = new EntityIdentification();
			ah.From.Id = "id";

			BusinessHeader header = new BusinessHeader();
			header.ApplicationHeader = ah;

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = header.xml();
			string xml = header.xml();

			assertNotNull(xml);

			XMLAssert.assertXpathEvaluatesTo("id", TestUtils.patch("/AppHdr/From/Id"), xml);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteEmpty()
		public virtual void testWriteEmpty()
		{
			BusinessHeader header = new BusinessHeader();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = header.xml();
			string xml = header.xml();
			assertNull(xml);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAHFromTo()
		public virtual void testAHFromTo()
		{
			BusinessHeader h = new BusinessHeader(new ApplicationHeader());

			h.ApplicationHeader.From = new EntityIdentification();
			h.ApplicationHeader.From.Type = "BIC";
			h.ApplicationHeader.From.Id = "FOOBARXX";
			h.ApplicationHeader.To = new EntityIdentification();
			h.ApplicationHeader.To.Type = "BIC";
			h.ApplicationHeader.To.Id = "ABCFOOXX";
			assertEquals("FOOBARXX", h.from());
			assertEquals("ABCFOOXX", h.to());

			h.ApplicationHeader.From.Type = "DN";
			h.ApplicationHeader.From.Id = "cn=funds,o=abcdchzz,o=swift";
			h.ApplicationHeader.To = new EntityIdentification();
			h.ApplicationHeader.To.Type = "DN";
			h.ApplicationHeader.To.Id = "cn=funds,o=dcbadeff,o=swift";
			assertEquals("ABCDCHZZ", h.from());
			assertEquals("DCBADEFF", h.to());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBAHFromTo()
		public virtual void testBAHFromTo()
		{
			BusinessHeader h = new BusinessHeader(new BusinessApplicationHeaderV01());

			h.BusinessApplicationHeader.Fr = new Party9Choice();
			h.BusinessApplicationHeader.Fr.FIId = new BranchAndFinancialInstitutionIdentification5();
			h.BusinessApplicationHeader.Fr.FIId.FinInstnId = new FinancialInstitutionIdentification8();
			h.BusinessApplicationHeader.Fr.FIId.FinInstnId.BICFI = "FOOBARXX";
			h.BusinessApplicationHeader.To = new Party9Choice();
			h.BusinessApplicationHeader.To.FIId = new BranchAndFinancialInstitutionIdentification5();
			h.BusinessApplicationHeader.To.FIId.FinInstnId = new FinancialInstitutionIdentification8();
			h.BusinessApplicationHeader.To.FIId.FinInstnId.BICFI = "ABCFOOXX";
			assertEquals("FOOBARXX", h.from());
			assertEquals("ABCFOOXX", h.to());
		}

	}

}