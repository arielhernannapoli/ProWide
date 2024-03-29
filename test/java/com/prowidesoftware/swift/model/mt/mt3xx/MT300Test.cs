﻿using System.Collections.Generic;

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

namespace com.prowidesoftware.swift.model.mt.mt3xx
{

	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;

	public class MT300Test
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1()
		public virtual void test1()
		{
			string fin = "{1:F01ABCDSKB0AXXX1024007372}{2:O3001920140829ABCDHUH0AXXX21390371231409011800N}{4:\n" + ":15A:\n" + ":20:712443\n" + ":22A:NEWT\n" + ":22C:FOO12345678\n" + ":17U:N\n" + ":82A:ABCDHUH0XXX\n" + ":87A:ABCDSKB0XXX\n" + ":15B:\n" + ":30T:20140829\n" + ":30V:20140902\n" + ":36:232,1\n" + ":32B:USD200000,\n" + ":53A:BOFAUS30XXX\n" + ":57A:BOFAUS30XXX\n" + ":33B:HUF46420000,\n" + ":53A:ABCDHUH0XXX\n" + ":57A:/1178200781106853\n" + "ABCDHUH0XXX\n" + ":15E:\n" + ":22L:ESMA1\n" + ":22M:W3MOO00A18\n" + ":22N:00OTP00KS00FWD000000000000000123\n" + ":22L:ESMA2\n" + ":22L:ESMA3\n" + ":22M:W3MOO00A19\n" + ":22N:00OTP00KS00FWD000000000000000234\n" + ":22M:W3MOO00A20\n" + ":22N:00OTP00KS00FWD000000000000000345\n" + ":22L:ESMA4\n" + "-}";
			MT300 m = MT300.parse(fin);

			// test getter for E1

			IList<MT300.SequenceE1> found = m.SequenceE1List;

			assertEquals(4, found.Count);

			assertEquals(3, found[0].size());
			assertEquals("ESMA1", found[0].getTag(0).Value);
			assertEquals("W3MOO00A18", found[0].getTag(1).Value);
			assertEquals("00OTP00KS00FWD000000000000000123", found[0].getTag(2).Value);

			assertEquals(1, found[1].size());
			assertEquals("ESMA2", found[1].getTag(0).Value);

			assertEquals(5, found[2].size());
			assertEquals("ESMA3", found[2].getTag(0).Value);
			assertEquals("W3MOO00A19", found[2].getTag(1).Value);
			assertEquals("00OTP00KS00FWD000000000000000234", found[2].getTag(2).Value);
			assertEquals("W3MOO00A20", found[2].getTag(3).Value);
			assertEquals("00OTP00KS00FWD000000000000000345", found[2].getTag(4).Value);

			assertEquals(1, found[3].size());
			assertEquals("ESMA4", found[3].getTag(0).Value);

			// test nested getter for E1a

			IList<MT300.SequenceE1a> sublist = MT300.getSequenceE1aList(found[2]);
			assertEquals(2, sublist.Count);
			assertEquals("W3MOO00A19", found[2].getTag(1).Value);
			assertEquals("00OTP00KS00FWD000000000000000234", found[2].getTag(2).Value);
			assertEquals("W3MOO00A20", found[2].getTag(3).Value);
			assertEquals("00OTP00KS00FWD000000000000000345", found[2].getTag(4).Value);
		}

	}

}