using System;

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
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	/// <summary>
	/// LT address model testing
	/// 
	/// @since 7.6
	/// </summary>
	public class LogicalTerminalAddressTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse()
		public virtual void testParse()
		{
			LogicalTerminalAddress b = new LogicalTerminalAddress(null);
			assertNull(b.Institution);
			assertNull(b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("");
			assertNull(b.Institution);
			assertNull(b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("I");
			assertEquals("I", b.Institution);
			assertNull(b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("IIII");
			assertEquals("IIII", b.Institution);
			assertNull(b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("IIIIC");
			assertEquals("IIII", b.Institution);
			assertEquals("C", b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("IIIICC");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("IIIICCL");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertEquals("L", b.Location);
			assertNull(b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("IIIICCLL");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertEquals("LL", b.Location);
			assertNull(b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("IIIICCLLB");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertEquals("LL", b.Location);
			assertEquals("B", b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("IIIICCLLBBB");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertEquals("LL", b.Location);
			assertEquals("BBB", b.Branch);
			assertNull(b.LTIdentifier);
			b = new LogicalTerminalAddress("IIIICCLLABBB");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertEquals("LL", b.Location);
			assertEquals('A', (char)b.LTIdentifier);
			assertEquals("BBB", b.Branch);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetLogicalTerminalIdentifier()
		public virtual void testGetLogicalTerminalIdentifier()
		{
			assertEquals("A", Convert.ToString((new LogicalTerminalAddress("FOOOOOHUAXXX")).LTIdentifier));
			assertNull((new LogicalTerminalAddress("FOOOOOHUXXX")).LTIdentifier);
			assertNull((new LogicalTerminalAddress("FOOOOOHU")).LTIdentifier);
			assertNull((new LogicalTerminalAddress("")).LTIdentifier);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSenderLT()
		public virtual void testSenderLT()
		{
			assertEquals("FOOOOOHUAXXX", (new LogicalTerminalAddress("FOOOOOHUAXXX")).SenderLogicalTerminalAddress);
			assertEquals("FOOOOOHUAXXX", (new LogicalTerminalAddress("FOOOOOHUXXXX")).SenderLogicalTerminalAddress);
			assertEquals("FOOOOOHUAXXX", (new LogicalTerminalAddress("FOOOOOHUXXX")).SenderLogicalTerminalAddress);
			assertEquals("FOOOOOHUAXXX", (new LogicalTerminalAddress("FOOOOOHU")).SenderLogicalTerminalAddress);
			assertNull((new LogicalTerminalAddress("FOO")).SenderLogicalTerminalAddress);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReceiverLT()
		public virtual void testReceiverLT()
		{
			assertEquals("FOOOOOHUXXXX", (new LogicalTerminalAddress("FOOOOOHUXXXX")).ReceiverLogicalTerminalAddress);
			assertEquals("FOOOOOHUXXXX", (new LogicalTerminalAddress("FOOOOOHUAXXX")).ReceiverLogicalTerminalAddress);
			assertEquals("FOOOOOHUXXXX", (new LogicalTerminalAddress("FOOOOOHUXXX")).ReceiverLogicalTerminalAddress);
			assertEquals("FOOOOOHUXXXX", (new LogicalTerminalAddress("FOOOOOHU")).ReceiverLogicalTerminalAddress);
			assertNull((new LogicalTerminalAddress("FOO")).ReceiverLogicalTerminalAddress);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetBranchBIC12()
		public virtual void testGetBranchBIC12()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final LogicalTerminalAddress lt = new LogicalTerminalAddress("FOOOOOHUABCD");
			LogicalTerminalAddress lt = new LogicalTerminalAddress("FOOOOOHUABCD");
			assertEquals('A', (char)lt.LTIdentifier);
			assertEquals("BCD", lt.Branch);
			assertEquals("FOOOOOHUBCD", lt.Bic11);
		}

	}

}