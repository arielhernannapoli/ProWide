﻿using System;

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

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Test = org.junit.Test;

	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using Tag = com.prowidesoftware.swift.model.Tag;

	public class MT199Test : BaseMessageTestcase
	{


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test199_01() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test199_01()
		{
			string s = "{1:F01CARBVEC0AXXX8321000092}{2:I199FOOBARAAXXXXN}{4:\n" + ":20:24986614073\n" + ":79:TO.   HSBC INTERNATIONAL TRUSTEE LIMITED\n" + "ATTN. FOO LAM / FOO CHENG - FAX NO. 11112222\n" + "FROM. JF ASSET MANAGEMENT LIMITED\n" + "RE.   JF ASIA ABSOLUTE RETURN FUND\n" + "A/C: 614073\n" + ".\n" + "- STOCK BORROWING\n" + "BORROWER. JF ASIA ABSOLUTE RETURN FUND\n" + "LENDER.   J.P. MORGAN SECURITIES LTD LONDON\n" + "STOCK.    HSBC TAIWAN FOO FD (ISIN: )\n" + "QUANTITY. 400,000\n" + "MARGIN PRICE.    USD5.1234567\n" + "COLLATERAL EQUI. USD2,049,382.68\n" + "TRADE DATE.      23 MAR 2012\n" + "SETTLEMENT DATE. 23 MAR 2012\n" + "PERIOD.          OPEN-ENDED\n" + "RATE.            -4.0(REBATE RATE)\n" + "DIVIDEND TERMS.  100 PCT GROSS\n" + "SETTLEMENT.\n" + "PLEASE RECEIVE THE CAPTIONED SHARES FROM THE\n" + "DEPOSITORY TRUST CO, FOO A/C JP MORGAN\n" + "SECURITIES LTD. A/C NO. THIRD PARTY A/C NO. 123\n" + "ON SETTLEMENT DATE FREE OF PAYMENT.\n" + "COLLATERAL.\n" + "PLEASE REMIT THE STOCK BORROWING CASH COLLATERAL\n" + "OF USD1,234,567.89 TO JPMORGAN CHASE BANK, NEW\n" + "YORK (CHASUS33) ABA 1234567, BENE:  FOO LONDON\n" + "(JPMSGB2L) A/C 0123-45-678, CREDIT TO: JF ASIA\n" + "ABSOLUTE RETURN FUND A/C 1234 UPON INSTRUCTION\n" + "MATCHED AND COMPLETION OF STOCK SETTLEMENT.\n" + "PLEASE NOTIFY US WITHIN 24 HOURS IF ANY\n" + "DISCREPANCY FOUND, OTHERWISE THE DETAILS STATED\n" + "ABOVE WILL BE TREATED AS CORRECT.\n" + ".\n" + "1\n" + "2\n" + "3\n" + "4\n" + "-}";
			SwiftMessage msg = (new SwiftParser(s)).message();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String value = msg.getBlock4().getTagByName("79").getValue();
			string value = msg.Block4.getTagByName("79").Value;
			assertEquals("\n4", value.Substring(value.Length - 2));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test199_02() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test199_02()
		{
			string s = "{1:F01CARBVEC0AXXX8321000092}{2:I199FOOBARAAXXXXN}{4:\n" + ":20:628735BKRU3X\n" + ":79:TO.   CITIBANK NA (NEW YORK)\n" + "ATTN. ANTHONY FOO/BONI FOO - ABC OPERATIONS\n" + "FROM.\n" + "RE.   FOO SUB A/C 12345\n" + "A/C: 961XXX\n" + ".\n" + "WE CONFIRM TO INCREASE THE FOLLOWING DEPOSIT FROM\n" + "USD100,027.78 TO USD150,000.00.\n" + "TRADED     01 MAY 2012\n" + "VALUE      01 MAY 2012\n" + "MATURITY   02 MAY 2012\n" + "AMOUNT     USD150,000.00\n" + "RATE       10.0000\n" + ".\n" + "INSTRUCTIONS:\n" + "PLEASE RECEIVE USD49,972.22 FROM\n" + "STATE STREET BANK AND TRUST CO, NA NEW YORK\n" + "SWIFT CODE: FOOSUS3N\n" + "CHIPS UID263760\n" + "VALUE 01 MAY 2012\n" + ".\n" + "REGARDS,\n" + "}\n" + "-}";
			SwiftMessage msg = (new SwiftParser(s)).message();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String value = msg.getBlock4().getTagByName("79").getValue();
			string value = msg.Block4.getTagByName("79").Value;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char lastChar = value.charAt(value.length()-1);
			char lastChar = value[value.Length - 1];
			assertEquals('}', lastChar);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test199_03() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test199_03()
		{
			string s = "{1:F01CARBVEC0AXXX8321000092}{2:I199FOOBARAAXXXXN}{4:\n" + ":20:628735BKRU3X\n" + ":79:TO.   FOO NA (HONG KONG)\n" + "FOO\n" + "REGARDS,\n" + "{\n" + "-}"; //invalid character
			SwiftMessage msg = (new SwiftParser(s)).message();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String value = msg.getBlock4().getTagByName("79").getValue();
			string value = msg.Block4.getTagByName("79").Value;
			assertEquals('{', value[value.Length - 1]);
			assertTrue("Invalid character (opening bracked) not properly included in value", value.EndsWith("{", StringComparison.Ordinal));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test199_04() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test199_04()
		{
			string s = "{1:F01CARBVEC0AXXX8321000092}{2:I199FOOBARAAXXXXN}{4:\n" + ":20:628735BKRU3X\n" + ":79:foo\n" + "}\n" + "-}"; //invalid character
			SwiftMessage msg = (new SwiftParser(s)).message();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String value = msg.getBlock4().getTagByName("79").getValue();
			string value = msg.Block4.getTagByName("79").Value;
			assertEquals("foo\n}", value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test199_05() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test199_05()
		{
			string s = "{1:F01CARBVEC0AXXX8321000092}{2:I199FOOBARAAXXXXN}{4:\n" + ":20:628735BKRU3X\n" + ":79:foo\n" + "}\n" + ":13C:bar\n" + "-}"; //invalid character
			SwiftMessage msg = (new SwiftParser(s)).message();

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.Tag t13 = msg.getBlock4().getTagByName("13C");
			Tag t13 = msg.Block4.getTagByName("13C");
			assertNotNull(t13);
			assertEquals("bar", t13.Value);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String value = msg.getBlock4().getTagByName("79").getValue();
			string value = msg.Block4.getTagByName("79").Value;
			assertEquals("foo\n}", value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test199_06() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test199_06()
		{
			string s = "{4:\n" + ":79:foo\n" + "}\n" + "-}"; //invalid character
			SwiftMessage msg = (new SwiftParser(s)).message();

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String value = msg.getBlock4().getTagByName("79").getValue();
			string value = msg.Block4.getTagByName("79").Value;
			assertEquals("foo\n}", value);
		}

	}

}