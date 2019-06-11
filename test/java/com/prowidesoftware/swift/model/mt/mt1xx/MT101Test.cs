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

namespace com.prowidesoftware.swift.model.mt.mt1xx
{

	using Field59 = com.prowidesoftware.swift.model.field.Field59;
	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	public class MT101Test
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1()
		public virtual void test1()
		{
			MT101 m = new MT101();
			assertNull(m.SwiftMessage.UETR);
			assertFalse(m.SwiftMessage.STP);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSequences()
		public virtual void testSequences()
		{
			MT101 mt = MT101.parse("{1:F01ABCDVEC0AXXX5480000053}{2:I101FOOBARAAXXXXN}{4:\n" + ":20:FILEREF2\n" + ":21R:UKSUPPLIER990901\n" + ":28D:1/1\n" + ":50H:/8754219990\n" + "MAG-NUM INC.\n" + "GENERAL A/C\n" + "BAHNOFFSTRASSE 30\n" + "ZURICH, SWITZERLAND\n" + ":30:020905\n" + ":21:TRANSREF1\n" + ":32B:GBP12500,\n" + ":59:/1091282\n" + "Beneficiary 1\n" + ":71A:OUR\n" + ":21:TRANSREF2\n" + ":32B:GBP15000,\n" + ":59:/8123560\n" + "Beneficiary 2\n" + ":71A:OUR\n" + ":21:TRANSREF3\n" + ":32B:GBP10000,\n" + ":59:/2179742\n" + "Beneficiary3\n" + ":71A:OUR\n" + "-}");
			IList<MT101.SequenceB> transfers = mt.SequenceBList;
			assertEquals(3, transfers.Count);
			assertEquals("TRANSREF3", transfers[2].getFieldByName("21").Value);
			assertEquals("Beneficiary3", ((Field59) transfers[2].getFieldByName("59")).NameAndAddressLine1);
		}

	}

}