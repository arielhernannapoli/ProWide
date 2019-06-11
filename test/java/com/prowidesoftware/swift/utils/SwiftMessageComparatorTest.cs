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
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Test = org.junit.Test;

	using SwiftBlock1 = com.prowidesoftware.swift.model.SwiftBlock1;
	using SwiftBlock2Input = com.prowidesoftware.swift.model.SwiftBlock2Input;
	using SwiftBlock2Output = com.prowidesoftware.swift.model.SwiftBlock2Output;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;

	/// <summary>
	/// Swift message comparator for tests.
	/// 
	/// @author sebastian
	/// @since 7.8.8
	/// </summary>
	public class SwiftMessageComparatorTest
	{

		private readonly SwiftMessageComparator comp = new SwiftMessageComparator();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testB1()
		public virtual void testB1()
		{
			SwiftBlock1 b1 = new SwiftBlock1();
			assertTrue(comp.compareB1(b1, b1));

			b1.LogicalTerminal = "FOOBARXXXXX";
			assertTrue(comp.compareB1(b1, b1));

			b1.SequenceNumber = "123456";
			assertTrue(comp.compareB1(b1, b1));

			b1.SessionNumber = "1234";
			assertTrue(comp.compareB1(b1, b1));

			SwiftBlock1 b2 = new SwiftBlock1();
			b2.ApplicationId = b1.ApplicationId;
			b2.ServiceId = b1.ServiceId;
			b2.LogicalTerminal = b1.LogicalTerminal;
			b2.SequenceNumber = b1.SequenceNumber;
			b2.SessionNumber = b1.SessionNumber;
			assertTrue(comp.compareB1(b1, b2));

			b2.SequenceNumber = "666666";
			b2.SessionNumber = "4444";
			assertFalse(comp.compareB1(b1, b2));

			/*
			 * Check that changing these values compare still returns true
			 * with the ignore header session on true
			 */
			comp.IgnoreHeaderSession = true;
			assertTrue(comp.compareB1(b1, b2));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testB2()
		public virtual void testB2()
		{
			SwiftBlock2Input b1 = new SwiftBlock2Input("I103CARAANC0XXXXN");
			assertTrue(comp.compareB2(b1, b1));

			SwiftBlock2Input b2 = new SwiftBlock2Input("I103CARAANC0XXXXN");
			assertTrue(comp.compareB2(b1, b2));

			b2.DeliveryMonitoring = "3";
			assertFalse(comp.compareB2(b1, b2));

			SwiftBlock2Output b3 = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX22221234560101031201N");
			assertTrue(comp.compareB2(b3, b3));

			SwiftBlock2Output b4 = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX22221234560101031201N");
			assertTrue(comp.compareB2(b3, b4));

			b4.MessageType = "999";
			assertFalse(comp.compareB2(b3, b4));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFullMessage() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFullMessage()
		{
			assertTrue(comp.Compare(new SwiftMessage(), new SwiftMessage()) == 0);

			const string fin = "{1:F01CARBVEC0AXXX6083000009}{2:I103CARAANC0XXXXN}{4:\n" + ":20:TCLIO200908132\n" + ":23B:CRED\n" + ":32A:090813VEF1000,\n" + ":50K:/01115446997234567890\n" + "FOO GUILARTE MADRIZ\n" + "R00000V01321705\n" + ":53B:/00010013800002000114\n" + "BANCO DEL CARIBE C.A.\n" + ":59:/00010013800020001146\n" + "BANCO DEL CARIBE C.A.\n" + ":71A:OUR\n" + ":72:/TIPO/410\n" + "-}";
			SwiftMessage m1 = SwiftMessage.parse(fin);
			assertTrue(comp.Compare(m1, m1) == 0);

			SwiftMessage m2 = SwiftMessage.parse(fin);
			assertTrue(comp.Compare(m1, m2) == 0);

			m2.Block4.getTagByName("20").Value = "FOO";
			assertTrue(comp.Compare(m1, m2) != 0);

			comp.addTagnameToIgnore("20");
			assertTrue(comp.Compare(m1, m2) == 0);

			m2.Block4.getTagByName("53B").Value = "/00010013800002000114\r\nBANCO DEL CARIBE C.A.";
			assertTrue(comp.Compare(m1, m2) != 0);

			comp.IgnoreEolsInMultiline = true;
			assertTrue(comp.Compare(m1, m2) == 0);
		}
	}

}