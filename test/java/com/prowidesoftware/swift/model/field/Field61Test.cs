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

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;


	using Test = org.junit.Test;

	/// <summary>
	/// Test for Field61 and similar fields.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class Field61Test : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("61", "081027C858,28NOPT12716219\n1524/6006/TESORO NACIONAL", "1001060106D341,34N422NONREF\r\nFURTHER REFERENCE", "090227C291553,62NAYG13391140\n1524/6009/TRASPASO AUTOMATICO AL", "020626D120000,NCOLABCD//12345", "1512290201EDZ0000000002,2222FBNKNONREF", "170717D203336,94NTRFR016341554//2395200  \n01P");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse61_01()
		public virtual void testParse61_01()
		{
			string v1 = "081027C266181,86NOPT12715201";
			string v2 = "081027C858,28NOPT12716219";
			string v3 = "081024C10215,NOPT12710361";
			string v4 = "081027C858,28NOPT12716219\n1524/6006/TESORO NACIONAL";

			Field61 f = null;

			f = new Field61(v1);
			assertNotNull(f);
			assertEquals("266181,86", f.getComponent5());
			assertEquals("N", f.getComponent(Field61.TRANSACTION_TYPE));
			assertEquals("OPT", f.getComponent(Field61.IDENTIFICATION_CODE));
			assertEquals("12715201", f.Component8);

			f = new Field61(v2);
			assertNotNull(f);
			assertEquals("858,28", f.getComponent5());
			assertEquals("N", f.getComponent(Field61.TRANSACTION_TYPE));
			assertEquals("OPT", f.getComponent(Field61.IDENTIFICATION_CODE));
			assertEquals("12716219", f.Component8);

			f = new Field61(v3);
			assertNotNull(f);
			assertEquals(new decimal(10215), new decimal((double)f.Component5AsNumber));
			assertEquals("N", f.getComponent(Field61.TRANSACTION_TYPE));
			assertEquals("OPT", f.getComponent(Field61.IDENTIFICATION_CODE));
			assertEquals("12710361", f.Component8);

			f = new Field61(v4);
			assertNotNull(f);
			assertEquals("N", f.getComponent(Field61.TRANSACTION_TYPE));
			assertEquals("OPT", f.getComponent(Field61.IDENTIFICATION_CODE));

			f = new Field61("090227C291553,62NAYG13391140" + "\n" + "1524/6009/TRASPASO AUTOMATICO AL");
			assertNotNull(f);
			assertEquals(new decimal(291553.62), new decimal((double)f.Component5AsNumber));

			assertFalse(291553.9962 == (double)f.Component5AsNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_02()
		public virtual void testParse_02()
		{
			string val = "081024" + "C" + "10215,NOPT12710361\n" + "1524/6006/TESORO NACIONAL";
			Field61 f = new Field61(val);
			assertNotNull(f);
			assertEquals(2008, f.Component1AsCalendar.Year);
			assertEquals(10, f.Component1AsCalendar.Month);
			assertEquals(24, f.Component1AsCalendar.Day);
			assertEquals(new decimal(10215), new decimal((double)f.Component5AsNumber));
			assertEquals("10215,", f.getComponent5());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_issue5()
		public virtual void test_issue5()
		{
			Field61 f = new Field61("1001060106D341,34N422NONREF\r\nFURTHER REFERENCE");
			assertEquals("100106", f.getComponent1());
			assertEquals("0106", f.getComponent2());
			assertEquals("D", f.Component3);
			assertNull(f.Component4);
			assertEquals("341,34", f.getComponent5());
			assertEquals("N", f.Component6);
			assertEquals("422", f.Component7);
			assertEquals("NONREF", f.Component8);
			assertNull(f.Component9);
			assertEquals("FURTHER REFERENCE", f.Component10);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_03()
		public virtual void testParse_03()
		{
			Field61 f = new Field61("020626D120000,NCOLABCD//12345");
			assertNotNull(f);
			assertEquals("020626", f.getComponent(Field61.VALUE_DATE));
			assertEquals("D", f.getComponent(Field61.DC_MARK));
			assertEquals("120000,", f.getComponent(Field61.AMOUNT));
			assertEquals("N", f.getComponent(Field61.TRANSACTION_TYPE));
			assertEquals("COL", f.getComponent(Field61.IDENTIFICATION_CODE));
			assertEquals("ABCD", f.getComponent(Field61.REFERENCE_FOR_THE_ACCOUNT_OWNER));
			assertEquals("12345", f.getComponent(Field61.REFERENCE_OF_THE_ACCOUNT_SERVICING_INSTITUTION));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_04()
		public virtual void testParse_04()
		{
			Field61 f = new Field61("150903C41,98N059NONREF");
			assertNotNull(f);
			assertEquals("150903", f.getComponent(Field61.VALUE_DATE));
			assertEquals("C", f.getComponent(Field61.DC_MARK));
			assertEquals("41,98", f.getComponent(Field61.AMOUNT));
			assertEquals("N", f.getComponent(Field61.TRANSACTION_TYPE));
			assertEquals("059", f.getComponent(Field61.IDENTIFICATION_CODE));
			assertEquals("NONREF", f.getComponent(Field61.REFERENCE_FOR_THE_ACCOUNT_OWNER));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_05()
		public virtual void testParse_05()
		{
			Field61 f = new Field61("1512171218RCF23423,S202//23sdf\nssdfsd");
			assertNotNull(f);
			assertEquals("151217", f.getComponent1());
			assertEquals("1218", f.getComponent2());
			assertEquals("RC", f.Component3);
			assertEquals("F", f.Component4);
			assertEquals("23423,", f.getComponent5());
			assertEquals("S", f.Component6);
			assertEquals("202", f.Component7);
			assertNull(f.Component8);
			assertEquals("23sdf", f.Component9);
			assertEquals("ssdfsd", f.Component10);
		}

		/// <summary>
		/// https://sourceforge.net/p/wife/bugs/61/
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_DCMark()
		public virtual void test_DCMark()
		{

			/// <summary>
			/// C  Credit
			/// D  Debit
			/// EC Expected Credit
			/// ED Expected Debit
			/// RC Reversal of Credit (debit entry)
			/// RD Reversal of Debit (credit entry)
			/// </summary>
			Field61 field61 = null;

			field61 = new Field61("1512290201C0000000002,2222FBNKNONREF");
			assertEquals("C", field61.DCMark);

			field61 = new Field61("1512290201D0000000002,2222FBNKNONREF");
			assertEquals("D", field61.DCMark);

			field61 = new Field61("1512290201RC0000000002,2222FBNKNONREF");
			assertEquals("RC", field61.DCMark);

			field61 = new Field61("1512290201RD0000000002,2222FBNKNONREF");
			assertEquals("RD", field61.DCMark);

			field61 = new Field61("1512290201EC0000000002,2222FBNKNONREF");
			assertEquals("EC", field61.DCMark);

			field61 = new Field61("1512290201ED0000000002,2222FBNKNONREF");
			assertEquals("ED", field61.DCMark);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_DCMArk_with_funds_code()
		public virtual void test_DCMArk_with_funds_code()
		{
			/// <summary>
			/// C  Credit
			/// D  Debit
			/// EC Expected Credit
			/// ED Expected Debit
			/// RC Reversal of Credit (debit entry)
			/// RD Reversal of Debit (credit entry)
			/// </summary>
			Field61 field61 = null;

			field61 = new Field61("1512290201CZ0000000002,2222FBNKNONREF");
			assertEquals("C", field61.DCMark);
			assertEquals("Z", field61.FundsCode);

			field61 = new Field61("1512290201DZ0000000002,2222FBNKNONREF");
			assertEquals("D", field61.DCMark);
			assertEquals("Z", field61.FundsCode);

			field61 = new Field61("1512290201RCZ0000000002,2222FBNKNONREF");
			assertEquals("RC", field61.DCMark);
			assertEquals("Z", field61.FundsCode);

			field61 = new Field61("1512290201RDZ0000000002,2222FBNKNONREF");
			assertEquals("RD", field61.DCMark);
			assertEquals("Z", field61.FundsCode);

			field61 = new Field61("1512290201ECZ0000000002,2222FBNKNONREF");
			assertEquals("EC", field61.DCMark);
			assertEquals("Z", field61.FundsCode);

			field61 = new Field61("1512290201EDZ0000000002,2222FBNKNONREF");
			assertEquals("ED", field61.DCMark);
			assertEquals("Z", field61.FundsCode);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPreserveWhitespaces()
		public virtual void testPreserveWhitespaces()
		{
			Field61 f = new Field61("170717D203336,94NTRFR016341554//2395200  \n01P");
			assertEquals("170717", f.getComponent1());
			assertNull(f.getComponent2());
			assertEquals("D", f.Component3);
			assertNull(f.Component4);
			assertEquals("203336,94", f.getComponent5());
			assertEquals("N", f.Component6);
			assertEquals("TRF", f.Component7);
			assertEquals("R016341554", f.Component8);
			assertEquals("2395200  ", f.Component9);
			assertEquals("01P", f.Component10);
		}

	}
}