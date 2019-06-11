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

	using Test = org.junit.Test;

	using SwiftBlock2Output = com.prowidesoftware.swift.model.SwiftBlock2Output;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;

	/// <summary>
	/// Test for SwiftParser main API and functions.
	/// 
	/// @since 4.0
	/// </summary>
	public class ParserAPITest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test103_1()
		public virtual void test103_1()
		{
			string messageToParse = "{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{3:{113:NOMF}{108:0510280086100057}{119:STP}}{4:\n" + ":20:D051026EUR100057\n" + ":13C:/RNCTIME/0802+0000\n" + ":23B:CRED\n" + ":32A:051028EUR6740,91\n" + ":33B:EUR6740,91\n" + ":50A:SSSSESMMXXX\n" + ":53A:BBBBESMMXXX\n" + ":57A:FOOBARYYXXX\n" + ":59:/ES0123456789012345671234\n" + "FOOOOO 1000 FOOBAR S.A.\n" + ":70:REDEMPTS. TRADEDATE 2222-10-26\n" + "/123123123: FOOVIMAR 2000 FOOBAR\n" + ":71A:SHA\n" + "-}{5:{MAC:D9D8FA56}{CHK:46E46A6460F2}}";

			SwiftMessage m = null;
			try
			{
				m = (new SwiftParser(messageToParse)).message();
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}

			//get a simple value tag
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") String val32a = m.getBlock3().getTagValue("32A");
			string val32a = m.Block3.getTagValue("32A");

			//get a repeated value tag
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") String[] list71 = m.getBlock3().getTagValues("71F");
			string[] list71 = m.Block3.getTagValues("71F");

			assertEquals("103", m.Type);

			//check b1
			assertEquals("F01FOOBARYYAXXX1234123456", m.Block1.BlockValue);
			assertEquals("F", m.Block1.ApplicationId);
			assertEquals("01", m.Block1.ServiceId);
			assertEquals("FOOBARYYAXXX", m.Block1.LogicalTerminal);
			assertEquals("1234", m.Block1.SessionNumber);
			assertEquals("123456", m.Block1.SequenceNumber);

			//check b2
			assertEquals("O1030803051028AAPBESMMAXXX54237368560510280803N", m.Block2.BlockValue);
			assertEquals("103", ((SwiftBlock2Output) m.Block2).MessageType);
			assertEquals("0803", ((SwiftBlock2Output) m.Block2).SenderInputTime);
			assertEquals("051028", ((SwiftBlock2Output) m.Block2).MIRDate);
			assertEquals("AAPBESMMAXXX", ((SwiftBlock2Output) m.Block2).MIRLogicalTerminal);
			assertEquals("5423", ((SwiftBlock2Output) m.Block2).MIRSessionNumber);
			assertEquals("736856", ((SwiftBlock2Output) m.Block2).MIRSequenceNumber);
			assertEquals("051028AAPBESMMAXXX5423736856", ((SwiftBlock2Output) m.Block2).MIR);
			assertEquals("051028", ((SwiftBlock2Output) m.Block2).ReceiverOutputDate);
			assertEquals("0803", ((SwiftBlock2Output) m.Block2).ReceiverOutputTime);
			assertEquals("N", ((SwiftBlock2Output) m.Block2).MessagePriority);

			//check b3
			assertEquals(3, m.Block3.countAll());
			assertEquals("NOMF", m.Block3.getTagValue("113"));
			assertEquals("0510280086100057", m.Block3.getTagValue("108"));
			assertEquals("STP", m.Block3.getTagValue("119"));

			//check b4
			assertEquals(11, m.Block4.countAll());
			assertEquals("D051026EUR100057", m.Block4.getTagValue("20"));
			assertEquals("/RNCTIME/0802+0000", m.Block4.getTagValue("13C"));
			assertEquals("CRED", m.Block4.getTagValue("23B"));
			assertEquals("051028EUR6740,91", m.Block4.getTagValue("32A"));
			assertEquals("EUR6740,91", m.Block4.getTagValue("33B"));
			assertEquals("SSSSESMMXXX", m.Block4.getTagValue("50A"));
			assertEquals("BBBBESMMXXX", m.Block4.getTagValue("53A"));
			assertEquals("FOOBARYYXXX", m.Block4.getTagValue("57A"));
			assertEquals("/ES0123456789012345671234\n" + "FOOOOO 1000 FOOBAR S.A.", m.Block4.getTagValue("59"));
			assertEquals("REDEMPTS. TRADEDATE 2222-10-26\n" + "/123123123: FOOVIMAR 2000 FOOBAR", m.Block4.getTagValue("70"));
			assertEquals("SHA", m.Block4.getTagValue("71A"));

			//check b5
			assertEquals(2, m.Block5.countAll());
			assertEquals("D9D8FA56", m.Block5.getTagValue("MAC"));
			assertEquals("46E46A6460F2", m.Block5.getTagValue("CHK"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test103_2()
		public virtual void test103_2()
		{
			string messageToParse = "{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{3:{113:NOMF}{108:0510280086100057}{119:STP}}{4:\n" + ":20:D051026EUR100057\n" + ":13C:/RNCTIME/0802+0000\n" + ":23B:CRED\n" + ":32A:051028EUR6740,91\n" + ":33B:EUR6740,91\n" + ":50A:SSSSESMMXXX\n" + ":53A:BBBBESMMXXX\n" + ":57A:FOOBARYYXXX\n" + ":59:/ES0123456789012345671234\n" + "FOOOOO 1000 FOOBAR S.A.\n" + ":70:REDEMPTS. TRADEDATE 2222-10-26\n" + "/123123123: FOOVIMAR 2000 FOOBAR\n" + ":71A:SHA\n" + "-}{5:{MAC:D9D8FA56}{CHK:46E46A6460F2}}";

			SwiftMessage m = null;
			try
			{
				m = (new SwiftParser()).parse(messageToParse);
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}

			assertEquals("103", m.Type);

			//check b1
			assertEquals("F01FOOBARYYAXXX1234123456", m.Block1.BlockValue);
			assertEquals("F", m.Block1.ApplicationId);
			assertEquals("01", m.Block1.ServiceId);
			assertEquals("FOOBARYYAXXX", m.Block1.LogicalTerminal);
			assertEquals("1234", m.Block1.SessionNumber);
			assertEquals("123456", m.Block1.SequenceNumber);

			//check b2
			assertEquals("O1030803051028AAPBESMMAXXX54237368560510280803N", m.Block2.BlockValue);
			assertEquals("103", ((SwiftBlock2Output) m.Block2).MessageType);
			assertEquals("0803", ((SwiftBlock2Output) m.Block2).SenderInputTime);
			assertEquals("051028", ((SwiftBlock2Output) m.Block2).MIRDate);
			assertEquals("AAPBESMMAXXX", ((SwiftBlock2Output) m.Block2).MIRLogicalTerminal);
			assertEquals("5423", ((SwiftBlock2Output) m.Block2).MIRSessionNumber);
			assertEquals("736856", ((SwiftBlock2Output) m.Block2).MIRSequenceNumber);
			assertEquals("051028AAPBESMMAXXX5423736856", ((SwiftBlock2Output) m.Block2).MIR);
			assertEquals("051028", ((SwiftBlock2Output) m.Block2).ReceiverOutputDate);
			assertEquals("0803", ((SwiftBlock2Output) m.Block2).ReceiverOutputTime);
			assertEquals("N", ((SwiftBlock2Output) m.Block2).MessagePriority);

			//check b3
			assertEquals(3, m.Block3.countAll());
			assertEquals("NOMF", m.Block3.getTagValue("113"));
			assertEquals("0510280086100057", m.Block3.getTagValue("108"));
			assertEquals("STP", m.Block3.getTagValue("119"));

			//check b4
			assertEquals(11, m.Block4.countAll());
			assertEquals("D051026EUR100057", m.Block4.getTagValue("20"));
			assertEquals("/RNCTIME/0802+0000", m.Block4.getTagValue("13C"));
			assertEquals("CRED", m.Block4.getTagValue("23B"));
			assertEquals("051028EUR6740,91", m.Block4.getTagValue("32A"));
			assertEquals("EUR6740,91", m.Block4.getTagValue("33B"));
			assertEquals("SSSSESMMXXX", m.Block4.getTagValue("50A"));
			assertEquals("BBBBESMMXXX", m.Block4.getTagValue("53A"));
			assertEquals("FOOBARYYXXX", m.Block4.getTagValue("57A"));
			assertEquals("/ES0123456789012345671234\n" + "FOOOOO 1000 FOOBAR S.A.", m.Block4.getTagValue("59"));
			assertEquals("REDEMPTS. TRADEDATE 2222-10-26\n" + "/123123123: FOOVIMAR 2000 FOOBAR", m.Block4.getTagValue("70"));
			assertEquals("SHA", m.Block4.getTagValue("71A"));

			//check b5
			assertEquals(2, m.Block5.countAll());
			assertEquals("D9D8FA56", m.Block5.getTagValue("MAC"));
			assertEquals("46E46A6460F2", m.Block5.getTagValue("CHK"));
		}

	}
}