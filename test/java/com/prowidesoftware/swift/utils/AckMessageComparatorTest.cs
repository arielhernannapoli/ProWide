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
namespace com.prowidesoftware.swift.utils
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Test = org.junit.Test;

	using SwiftParser = com.prowidesoftware.swift.io.parser.SwiftParser;
	using SwiftBlock1 = com.prowidesoftware.swift.model.SwiftBlock1;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;

	/// <summary>
	/// Swift message comparator for tests.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 4.0
	/// </summary>
	public class AckMessageComparatorTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1()
		public virtual void test1()
		{
			SwiftBlock1 b1 = new SwiftBlock1();
			b1.ApplicationId = "foo";
			b1.LogicalTerminal = "term";
			b1.SequenceNumber = "1234";
			b1.ServiceId = "99";
			b1.SessionNumber = "190";

			SwiftBlock1 b2 = new SwiftBlock1();
			b2.ApplicationId = "foo";
			b2.LogicalTerminal = "term";
			b2.SequenceNumber = "1234";
			b2.ServiceId = "99";
			b2.SessionNumber = "190";


			AckMessageComparator comp = new AckMessageComparator();
			assertTrue(comp.compareB1(b1, b2));

			b2.SequenceNumber = "99999999999999999999";
			b2.SessionNumber = "9999999999999999999999";

			/*
			 * Check that changing these values compare still returns true
			 */
			assertTrue(comp.compareB1(b1, b2));
		}

		internal string m = "{1:F01CARBVEC0AXXX6083000009}{2:I103CARAANC0XXXXN}{4:\n" + ":20:TCLIO200908132\n" + ":23B:CRED\n" + ":32A:090813VEF1000,\n" + ":50K:/01115446997234567890\n" + "RANGEL GUILARTE MADRIZ\n" + "R00000V01321705\n" + ":53B:/00010013800002000114\n" + "BANCO DEL CARIBE C.A.\n" + ":59:/00010013800020001146\n" + "BANCO DEL CARIBE C.A.\n" + ":71A:OUR\n" + ":72:/TIPO/410\n" + "-}";


		internal string m2 = "{1:F01CARBVEC0AXXX6083000009}{2:I103CARAANC0XXXXN}{4:\n" + ":20:TCLIO200908132\n" + ":23B:CRED\n" + ":32A:090813VEF1000,\n" + ":50K:/01115446997234567890\n" + "RANGEL GUILARTE MADRIZ\n" + "R00000V01321705\n" + ":53B:/00010013800002000114\n" + "BANCO DEL CARIBE C.A.\n" + ":59:/00010013800020001146\n" + "BANCO DEL CARIBE C.A.\n" + ":71A:OUR\n" + ":72:/TIPO/410\n" + "-}";

		internal string ack = "{1:F01CARBVEC0AXXX6083000009}{2:I103CARAANC0XXXXN}{4:\n" + ":20:TCLIO200908132\n" + ":23B:CRED\n" + ":32A:090813VEF1000,\n" + ":50K:/01115446997234567890\n" + "RANGEL GUILARTE MADRIZ\n" + "R00000V01321705\n" + ":53B:/00010013800002000114\n" + "BANCO DEL CARIBE C.A.\n" + ":59:/00010013800020001146\n" + "BANCO DEL CARIBE C.A.\n" + ":71A:OUR\n" + ":72:/TIPO/410\n" + "-}";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCompare() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testCompare()
		{
			AckMessageComparator c = new AckMessageComparator();
			SwiftMessage ackMsg = (new SwiftParser(ack)).message();
			SwiftMessage mMsg = (new SwiftParser(m)).message();
			assertEquals(m, m2);
			assertEquals(0, c.compare(ackMsg, mMsg));
			ackMsg.Block1.SequenceNumber = "X";
			ackMsg.Block1.SessionNumber = "X";
			assertEquals(0, c.compare(ackMsg, mMsg));
		}

	}

}