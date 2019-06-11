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

	using MTVariant = com.prowidesoftware.swift.model.mt.MTVariant;
	using MT103 = com.prowidesoftware.swift.model.mt.mt1xx.MT103;
	using MT103_STP = com.prowidesoftware.swift.model.mt.mt1xx.MT103_STP;
	using MT202 = com.prowidesoftware.swift.model.mt.mt2xx.MT202;
	using MT202COV = com.prowidesoftware.swift.model.mt.mt2xx.MT202COV;
	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// Test for <seealso cref="MtSwiftMessage"/> model API
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8
	/// </summary>
	public class MtSwiftMessageTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetModelMessage()
		public virtual void testGetModelMessage()
		{
			string fin = "{1:F01CARBVEC0AXXX8321000092}{2:I199FOOBARAAXXXXN}{4:\n" + ":20:ABC\n" + "-}";
			MtSwiftMessage mtsm = new MtSwiftMessage(fin);
			assertNotNull(mtsm.FileFormat);
			assertEquals(FileFormat.FIN, mtsm.FileFormat);
			SwiftMessage sm = mtsm.modelMessage();
			assertNotNull(sm);
			assertNotNull(sm.Block4);
			assertEquals(1, sm.Block4.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSystemMessage()
		public virtual void testSystemMessage()
		{
			string fin = "{1:F21LITEBEBBADSZ0066000079}{4:{177:1104180901}{451:0}}\n" + "{1:F01LITEBEBBADSZ0066000079}{2:I999FOOEBEBBXABCN}{4:\n" + ":20:TESTREF1\n" + ":79:This is text line 1\n" + "-}{5:{CHK:7602B010CF31}{TNG:}}";
			MtSwiftMessage m = new MtSwiftMessage(fin);
			assertEquals(AbstractSwiftMessage.IDENTIFIER_ACK, m.Identifier);
			assertEquals("LITEBEBBDSZ", m.Sender);
			/*
			 * data from original message
			 */
			assertEquals(m.Direction, MessageIOType.outgoing);
			assertEquals("TESTREF1", m.Reference);
			assertEquals("FOOEBEBBABC", m.Receiver);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void updateFromIncompleteModel()
		public virtual void updateFromIncompleteModel()
		{
			MtSwiftMessage m = new MtSwiftMessage();
			SwiftMessage sm = new SwiftMessage();
			sm.addBlock(new SwiftBlock1());
			sm.addBlock(new SwiftBlock2Input());
			sm.Block2.MessageType = "202";
			m.updateFromModel(sm);
			assertEquals("fin.202", m.Identifier);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIdentifier()
		public virtual void testIdentifier()
		{
			MtSwiftMessage m = new MtSwiftMessage();
			assertNull(m.Identifier);

			m = new MtSwiftMessage((new MT103()).SwiftMessage);
			assertEquals("fin.103", m.Identifier);

			m = new MtSwiftMessage((new MT103_STP()).SwiftMessage);
			assertEquals("fin.103.STP", m.Identifier);

			m = new MtSwiftMessage((new MT202()).SwiftMessage);
			assertEquals("fin.202", m.Identifier);

			m = new MtSwiftMessage((new MT202COV()).SwiftMessage);
			assertEquals("fin.202.COV", m.Identifier);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIdentifierAndIsType()
		public virtual void testIdentifierAndIsType()
		{
			MtSwiftMessage m = new MtSwiftMessage();
			assertNull(m.Identifier);
			assertFalse(m.isType(103));

			m = new MtSwiftMessage((new MT103()).SwiftMessage);
			assertTrue(m.isType(103));
			assertFalse(m.isType(202));

			m = new MtSwiftMessage((new MT103_STP()).SwiftMessage);
			assertTrue(m.isType(103));
			assertFalse(m.isType(202));

			m = new MtSwiftMessage((new MT202()).SwiftMessage);
			assertFalse(m.isType(103));
			assertTrue(m.isType(202));

			m = new MtSwiftMessage((new MT202COV()).SwiftMessage);
			assertFalse(m.isType(103));
			assertTrue(m.isType(202));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testVariant()
		public virtual void testVariant()
		{
			MtSwiftMessage m = new MtSwiftMessage();
			assertNull(m.Variant);

			m = new MtSwiftMessage((new MT103()).SwiftMessage);
			assertNull(m.Variant);

			m = new MtSwiftMessage((new MT103_STP()).SwiftMessage);
			assertEquals(MTVariant.STP, m.Variant);

			m = new MtSwiftMessage((new MT202()).SwiftMessage);
			assertNull(m.Variant);

			m = new MtSwiftMessage((new MT202COV()).SwiftMessage);
			assertEquals(MTVariant.COV, m.Variant);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMtId()
		public virtual void testMtId()
		{
			MtSwiftMessage m = new MtSwiftMessage();
			assertNull(m.MtId.MessageType);
			assertNull(m.MtId.Variant);

			m = new MtSwiftMessage((new MT103()).SwiftMessage);
			assertEquals(new MtId("103"), m.MtId);

			m = new MtSwiftMessage((new MT103_STP()).SwiftMessage);
			assertEquals(new MtId("103", "STP"), m.MtId);

			m = new MtSwiftMessage((new MT202()).SwiftMessage);
			assertEquals(new MtId("202"), m.MtId);

			m = new MtSwiftMessage((new MT202COV()).SwiftMessage);
			assertEquals(new MtId("202", "COV"), m.MtId);
		}

	}

}