using System;
using System.Collections;

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

	using ConversionService = com.prowidesoftware.swift.io.ConversionService;
	using SwiftParser = com.prowidesoftware.swift.io.parser.SwiftParser;
	using Field111 = com.prowidesoftware.swift.model.field.Field111;
	using Field119 = com.prowidesoftware.swift.model.field.Field119;
	using Field121 = com.prowidesoftware.swift.model.field.Field121;
	using AbstractMT = com.prowidesoftware.swift.model.mt.AbstractMT;
	using MTVariant = com.prowidesoftware.swift.model.mt.MTVariant;
	using MtCategory = com.prowidesoftware.swift.model.mt.MtCategory;
	using MT102 = com.prowidesoftware.swift.model.mt.mt1xx.MT102;
	using MT540 = com.prowidesoftware.swift.model.mt.mt5xx.MT540;
	using Test = org.junit.Test;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// General swift message tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class SwiftMessageTest
	{

		/// <summary>
		/// Ensure the message with data can be serialized
		/// </summary>
		/// <exception cref="IOException"> </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSerialization() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSerialization()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage(true);
			SwiftMessage m = new SwiftMessage(true);
			m.Block1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			m.Block2.Value = com.prowidesoftware.swift.Constants_Fields.B2_INPUT;
			m.Block3.append(new Tag("120:asdadad"));
			m.Block4.append(new Tag("120:asdadad"));
			m.Block5.append(new Tag("120:asdadad"));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlockUser bu = new SwiftBlockUser("S");
			SwiftBlockUser bu = new SwiftBlockUser("S");
			bu.append(new Tag("120:asdadad"));
			m.addUserBlock(bu);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.ByteArrayOutputStream b = new java.io.ByteArrayOutputStream();
			ByteArrayOutputStream b = new ByteArrayOutputStream();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.ObjectOutputStream oos = new java.io.ObjectOutputStream(b);
			ObjectOutputStream oos = new ObjectOutputStream(b);
			oos.writeObject(m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testClear() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testClear()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage();
			SwiftMessage m = new SwiftMessage();
			m.clear();
			assertEquals(0, m.BlockCount);
			assertNull(m.Block1);
			assertNull(m.Block2);
			assertNull(m.Block3);
			assertNull(m.Block4);
			assertNull(m.Block5);
			assertNull(m.UserBlocks);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNotInitializedConstructor() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testNotInitializedConstructor()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage(false);
			SwiftMessage m = new SwiftMessage(false);
			assertEquals(0, m.BlockCount);
			assertNull(m.Block1);
			assertNull(m.Block2);
			assertNull(m.Block3);
			assertNull(m.Block4);
			assertNull(m.Block5);
			assertNull(m.UserBlocks);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDefaultConstructor()
		public virtual void testDefaultConstructor()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage(true);
			SwiftMessage m = new SwiftMessage(true);

			assertNotNull(m.Block1);
			assertTrue(m.Block1 is SwiftBlock1);

			assertNotNull(m.Block2);
			assertTrue(m.Block2 is SwiftBlock2);

			assertNotNull(m.Block3);
			assertTrue(m.Block3 is SwiftBlock3);

			assertNotNull(m.Block4);
			assertTrue(m.Block4 is SwiftBlock4);

			assertNotNull(m.Block5);
			assertTrue(m.Block5 is SwiftBlock5);

			assertNotNull(m.UserBlocks);
			assertTrue(m.UserBlocks is IList);

			//expected 2 because empty blocks are not counted and block 1 and 2 have default attribute values
			assertEquals(2, m.BlockCount);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetBlockCount()
		public virtual void testGetBlockCount()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage();
			SwiftMessage m = new SwiftMessage();

			m.addBlock(new SwiftBlock1());

			m.Block1.ApplicationId = "F";
			assertEquals(1, m.BlockCount);

			m.addBlock(new SwiftBlock3());
			m.Block3.append(new Tag("n", "v"));
			assertEquals(2, m.BlockCount);

			m.clear();
			assertEquals(0, m.BlockCount);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetBlockCountBoolean()
		public virtual void testGetBlockCountBoolean()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage(false);
			SwiftMessage m = new SwiftMessage(false);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlockUser ub = new SwiftBlockUser();
			SwiftBlockUser ub = new SwiftBlockUser();
			m.addBlock(ub);

			m.addBlock(new SwiftBlock1());
			assertEquals(1, m.getBlockCount(false));
			assertEquals(2, m.BlockCount);

			m.Block1.ApplicationId = "F";
			assertEquals(2, m.BlockCount);

			m.Block1.ApplicationId = "F";
			assertEquals(1, m.getBlockCount(false));

			m.clear();
			assertEquals(0, m.BlockCount);
		}

		/// <summary>
		/// Message posted https://sourceforge.net/forum/message.php?msg_id=4430916
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPostedTimclarke_01()
		public virtual void testPostedTimclarke_01()
		{
			SwiftParser parser;
			SwiftMessage msg;

			const string messageOutput = "{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{3:{113:NOMF}{108:0510280086100057}{119:STP}}{4:\n" + ":20:D051026EUR100057\n" + ":13C:/RNCTIME/0802+0000\n" + ":23B:CRED\n" + ":32A:051028EUR6740,91\n" + ":33B:EUR6740,91\n" + ":50A:SSSSESMMXXX\n" + ":53A:BBBBESMMXXX\n" + ":57A:FOOBARYYXXX\n" + ":59:/ES0123456789012345671234\n" + "FOOOOO 1000 FOOBAR S.A.\n" + ":70:REDEMPTS. TRADEDATE 2222-10-26\n" + "/123123123: FOOVIMAR 2000 FOOBAR\n" + ":71A:SHA\n" + "-}{5:{MAC:D9D8FA56}{CHK:46E46A6460F2}}";

			const string messageInput = "{1:F01FOOBARXXAXXX3219604112}{2:I535FOOBARXXXXXXN}{4:\n" + ":16R:GENL\n" + ":28E:1/ONLY\n" + ":13A::STAT//086\n" + ":20C::SEME//ABC20070327P1\n" + ":23G:NEWM\n" + ":98A::STAT//20070327\n" + ":98C::PREP//20070328043657\n" + ":22F::SFRE//DAIL\n" + ":22F::CODE//COMP\n" + ":22F::STTY//CUST\n" + ":22F::STBA//TRAD\n" + ":97A::SAFE//ABC\n" + ":17B::ACTI//Y\n" + ":17B::CONS//Y\n" + ":16S:GENL\n" + ":16R:ADDINFO\n" + ":19A::HOLP//USD0,\n" + ":19A::HOLS//USD0,\n" + ":16S:ADDINFO\n" + "-}{5:{MAC:8A1FADA1}{CHK:B018C2CA74CD}}{S:{REF:I20070328.386482886.out/1/1}}";

			try
			{
			 parser = new SwiftParser(messageOutput);
			msg = parser.message();
			assertTrue(msg.Block2 is SwiftBlock2Output);

			assertFalse(msg.Block2.Input);
			SwiftBlock2Output b2o = (SwiftBlock2Output)msg.Block2;
			assertEquals(b2o.MessageType, "103");

			parser = new SwiftParser(messageInput);
			msg = parser.message();
			assertTrue(msg.Block2 is SwiftBlock2Input);

			//msSender = msg.getBlock2().getSender(); 
			//msPriority = msg.getBlock2().getMessagePriority();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
		}

		/// <summary>
		/// cover payment messages
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCOVMessage()
		public virtual void testCOVMessage()
		{
			SwiftParser parser;
			const string msg1s = "{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{3:{113:NOMF}{108:0510280086100057}{119:COV}}{4:\n" + ":20:D051026EUR100057\n" + ":13C:/RNCTIME/0802+0000\n" + ":23B:CRED\n" + ":32A:051028EUR6740,91\n" + ":33B:EUR6740,91\n" + ":50A:SSSSESMMXXX\n" + ":53A:BBBBESMMXXX\n" + ":57A:FOOBARYYXXX\n" + ":59:/ES0123456789012345671234\n" + "FOOOOO 1000 FOOBAR S.A.\n" + ":70:REDEMPTS. TRADEDATE 2222-10-26\n" + "/123123123: FOOVIMAR 2000 FOOBAR\n" + ":71A:SHA\n" + "-}{5:{MAC:D9D8FA56}{CHK:46E46A6460F2}}";
			const string msg2s = "{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{3:{113:NOMF}{108:0510280086100057}}{4:\n" + ":20:D051026EUR100057\n" + ":13C:/RNCTIME/0802+0000\n" + ":23B:CRED\n" + ":32A:051028EUR6740,91\n" + ":33B:EUR6740,91\n" + ":50A:SSSSESMMXXX\n" + ":53A:BBBBESMMXXX\n" + ":57A:FOOBARYYXXX\n" + ":59:/ES0123456789012345671234\n" + "FOOOOO 1000 FOOBAR S.A.\n" + ":70:REDEMPTS. TRADEDATE 2222-10-26\n" + "/123123123: FOOVIMAR 2000 FOOBAR\n" + ":71A:SHA\n" + "-}{5:{MAC:D9D8FA56}{CHK:46E46A6460F2}}";
			try
			{
				 parser = new SwiftParser(msg1s);
				 SwiftMessage msg1 = parser.message();
				assertTrue(msg1.COV);

				 parser = new SwiftParser(msg2s);
				 SwiftMessage msg2 = parser.message();
				assertFalse(msg2.COV);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
		}

		/// <summary>
		/// STP
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSTPMessage()
		public virtual void testSTPMessage()
		{
			SwiftParser parser;
			const string msg1s = "{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{3:{113:NOMF}{108:0510280086100057}{119:STP}}{4:\n" + ":20:D051026EUR100057\n" + ":13C:/RNCTIME/0802+0000\n" + ":23B:CRED\n" + ":32A:051028EUR6740,91\n" + ":33B:EUR6740,91\n" + ":50A:SSSSESMMXXX\n" + ":53A:BBBBESMMXXX\n" + ":57A:FOOBARYYXXX\n" + ":59:/ES0123456789012345671234\n" + "FOOOOO 1000 FOOBAR S.A.\n" + ":70:REDEMPTS. TRADEDATE 2222-10-26\n" + "/123123123: FOOVIMAR 2000 FOOBAR\n" + ":71A:SHA\n" + "-}{5:{MAC:D9D8FA56}{CHK:46E46A6460F2}}";
			const string msg2s = "{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{3:{113:NOMF}{108:0510280086100057}}{4:\n" + ":20:D051026EUR100057\n" + ":13C:/RNCTIME/0802+0000\n" + ":23B:CRED\n" + ":32A:051028EUR6740,91\n" + ":33B:EUR6740,91\n" + ":50A:SSSSESMMXXX\n" + ":53A:BBBBESMMXXX\n" + ":57A:FOOBARYYXXX\n" + ":59:/ES0123456789012345671234\n" + "FOOOOO 1000 FOOBAR S.A.\n" + ":70:REDEMPTS. TRADEDATE 2222-10-26\n" + "/123123123: FOOVIMAR 2000 FOOBAR\n" + ":71A:SHA\n" + "-}{5:{MAC:D9D8FA56}{CHK:46E46A6460F2}}";
			try
			{
				 parser = new SwiftParser(msg1s);
				 SwiftMessage msg1 = parser.message();
				assertTrue(msg1.STP);

				 parser = new SwiftParser(msg2s);
				 SwiftMessage msg2 = parser.message();
				assertFalse(msg2.STP);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testToMt() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testToMt()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage(true);
			 SwiftMessage m = new SwiftMessage(true);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock2Input b2 = new SwiftBlock2Input();
				SwiftBlock2Input b2 = new SwiftBlock2Input();
				b2.MessageType = "102";
				b2.Input = true;
				b2.MessagePriority = "N";
				b2.DeliveryMonitoring = "2";
				b2.ObsolescencePeriod = "020";
				b2.ReceiverAddress = "12345612XXXX";
				m.Block2 = b2;

			AbstractMT o = m.toMT();
			assertTrue("MT not an instance of 102", o is MT102);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testToMt_540() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testToMt_540()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage(true);
			 SwiftMessage m = new SwiftMessage(true);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock2Input b2 = new SwiftBlock2Input();
				SwiftBlock2Input b2 = new SwiftBlock2Input();
				b2.MessageType = "540";
				b2.Input = true;
				b2.MessagePriority = "N";
				b2.DeliveryMonitoring = "2";
				b2.ObsolescencePeriod = "020";
				b2.ReceiverAddress = "12345612XXXX";
				m.Block2 = b2;
			AbstractMT o = m.toMT();
			assertTrue("MT not an instance of 540", o is MT540);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void PDE()
		public virtual void PDE()
		{
			SwiftMessage m = new SwiftMessage();
			m.Block5 = new SwiftBlock5();
			m.Block5.append(new Tag("PDE", ""));
			string fin = (new ConversionService()).getFIN(m);
			assertEquals("{5:{PDE:}}", fin);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void isAck() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void isAck()
		{
			string msg = "{1:F21LITEBEBBAXXX0066000079}{4:{177:1104180901}{451:0}}{1:F01LITEBEBBAXXX0066000079}{2:I999LITEBEBBXXXXN}{4:\n" + ":20:TESTREF1\n" + ":79:This is text line 1\n" + "-}{5:{CHK:7602B010CF31}{TNG:}}";
			SwiftMessage m = (new SwiftParser()).parse(msg);
			assertTrue(m.Ack);
			assertFalse(m.Nack);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void getMtId() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void getMtId()
		{
			string msg = "{1:F01BICAUS11AXXX0000000000}{2:I202N}{4:\n" + ":20:asdfasdf\n" + "-}";
			SwiftParser p = new SwiftParser(msg);
			SwiftMessage m = p.message();
			assertNotNull(m.MtId);
			assertEquals("fin.202", m.MtId.id());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void isServiceMessage21() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void isServiceMessage21()
		{
			SwiftMessage m = SwiftMessage.parse("{1:F01BNPAFRPPZXXX0000000006}{2:O0111702040914DYLRXXXXCXXX00000000001702040914S}{4:{175:0914}{106:170204BNPAFRPPZXXX0000000007}{108:MyRef9}{175:0914}{107:170204MGTCBEBBXXXX0000000007}}{5:{CHK:ABCDEF123456}{SYS:}}");
			assertFalse(m.ServiceMessage);
			assertFalse(m.Ack);
			assertFalse(m.Nack);
			/*
			 * this one returns false because the method actually checks for service i2 21 (ACK/NACK)
			 */
			assertFalse(m.ServiceMessage21);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void isServiceMessage() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void isServiceMessage()
		{
			SwiftMessage m = SwiftMessage.parse("{1:F21BNPAFRPPZXXX0000000007}{4:{177:1702040914}{451:0}}{1:F01BNPAFRPPZXXX0000000007}{2:I103MGTCBEBBXXXXN}{3:{108:MyRef9}}{4:\n-}{5:{MAC:ABCD1234}{CHK:ABCDEF123456}}");
			assertTrue(m.ServiceMessage);
			assertTrue(m.Ack);
			assertFalse(m.Nack);
			/*
			 * this one returns true because the method actually checks for service i2 21 (ACK/NACK)
			 */
			assertTrue(m.ServiceMessage21);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSenderReceiver() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSenderReceiver()
		{
			/*
			 * incomming
			 */
			SwiftMessage m = SwiftMessage.parse("{1:F01FOOBARXXAXXX0387241036}{2:O9502352060913FOOBUS22XXXX18884819330609140052N}{4:\n:20:123456\n-}");
			assertEquals("FOOBUS22XXXX", m.Sender);
			assertEquals("FOOBARXXAXXX", m.Receiver);
			/*
			 * outgoing
			 */
			m = SwiftMessage.parse("{1:F01FOOBARAAAXXX3219604112}{2:I535FOOBUS22XXXXN}{4:\n:16R:GENL\n-}");
			assertEquals("FOOBARAAAXXX", m.Sender);
			assertEquals("FOOBUS22XXXX", m.Receiver);
			/*
			 * ack
			 */
			m = SwiftMessage.parse("{1:F21BNPAFRPPZXXX0000000007}{4:{177:1702040914}{451:0}}");
			assertEquals("BNPAFRPPZXXX", m.Sender);
			assertNull(m.Receiver);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetCategory() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetCategory()
		{
			SwiftMessage m = SwiftMessage.parse("{1:F01FOOBARXXAXXX0387241036}{2:O9502352060913YYYYYYYYYYYY18884819330609140052N}{4:\n:20:123456\n-}");
			assertEquals(MtCategory._9, m.Category);
			assertTrue(m.isCategory(MtCategory._9));
			assertTrue(m.isCategory(MtCategory._0, MtCategory._1, MtCategory._3, MtCategory._9));
			assertFalse(m.isCategory(MtCategory._8));
			m = SwiftMessage.parse("{1:F21BNPAFRPPZXXX0000000007}{4:{177:1702040914}{451:0}}");
			assertNull(m.Category);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCorrespondent() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testCorrespondent()
		{
			SwiftMessage m = SwiftMessage.parse("{1:F01FOOBARAAAXXX3219604112}{2:I535BBBBBBBXXXXXN}{4:\n:16R:GENL\n-}");
			assertEquals(new BIC("BBBBBBBXXXXX"), m.CorrespondentBIC);

			m = SwiftMessage.parse("{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{4:\n:16R:GENL\n-}");
			assertEquals(new BIC("AAPBESMMAXXX"), m.CorrespondentBIC);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testUUMID() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testUUMID()
		{
			SwiftMessage m = SwiftMessage.parse("{1:F01FOOBARAAAXXX3219604112}{2:I535BBBBBBBXXXXXN}{4:\n:16R:GENL\n-}");
			assertEquals("IBBBBBBBXXXX535", m.UUID);

			m = SwiftMessage.parse("{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{4:\n:16R:GENL\n-}");
			assertEquals("OAAPBESMMXXX103", m.UUID);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testUID() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testUID()
		{
			DateTime cal = new DateTime();
			cal.set(DateTime.YEAR, 2015);
			cal.set(DateTime.MONTH, 8);
			cal.set(DateTime.DAY_OF_MONTH, 27);

			SwiftMessage m = SwiftMessage.parse("{1:F01FOOBARAAAXXX3219604112}{2:I535BBBBBBBXXXXXN}{4:\n:16R:GENL\n-}");
			assertEquals("IBBBBBBBXXXX5351508270000001234", m.getUID(cal, 1234L));

			m = SwiftMessage.parse("{1:F01FOOBARYYAXXX1234123456}{2:O1030803051028AAPBESMMAXXX54237368560510280803N}{4:\n:16R:GENL\n-}");
			assertEquals("OAAPBESMMXXX1031508270000001234", m.getUID(cal, 1234L));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testServiceTypeIdentifier()
		public virtual void testServiceTypeIdentifier()
		{
			SwiftMessage m = new SwiftMessage();
			assertNull(m.ServiceTypeIdentifier);
			m.ServiceTypeIdentifier = "001";
			assertEquals("001", m.ServiceTypeIdentifier);
			m.ServiceTypeIdentifier = "002";
			assertEquals("002", m.ServiceTypeIdentifier);
			assertTrue(m.Block3.countByName(Field111.NAME) == 1);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testUETR()
		public virtual void testUETR()
		{
			SwiftMessage m = new SwiftMessage();
			assertNull(m.UETR);
			m.setUETR();
			assertNotNull(m.UETR);
			m.UETR = "eb6305c9-1f7f-49de-aed0-16487c27b42d";
			assertEquals("eb6305c9-1f7f-49de-aed0-16487c27b42d", m.UETR);
			m.UETR = "foo";
			assertEquals("foo", m.UETR);
			assertTrue(m.Block3.countByName(Field121.NAME) == 1);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testVariant()
		public virtual void testVariant()
		{
			SwiftMessage m = new SwiftMessage();
			assertFalse(m.STP);
			m.Variant = MTVariant.STP;
			assertTrue(m.STP);
			m.Variant = MTVariant.COV;
			assertFalse(m.STP);
			assertTrue(m.COV);
			m.Variant = MTVariant.REMIT;
			assertFalse(m.STP);
			assertFalse(m.COV);
			assertTrue(m.REMIT);
			assertTrue(m.Block3.countByName(Field119.NAME) == 1);
		}

	}
}