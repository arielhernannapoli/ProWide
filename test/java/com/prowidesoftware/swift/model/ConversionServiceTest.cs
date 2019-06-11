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


	using XMLTestCase = org.custommonkey.xmlunit.XMLTestCase;
	using XMLUnit = org.custommonkey.xmlunit.XMLUnit;
	using Before = org.junit.Before;
	using Test = org.junit.Test;
	using SAXException = org.xml.sax.SAXException;

	using ConversionService = com.prowidesoftware.swift.io.ConversionService;
	using IConversionService = com.prowidesoftware.swift.io.IConversionService;
	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;
	using SwiftWriter = com.prowidesoftware.swift.io.writer.SwiftWriter;


	/// <summary>
	/// Conversion services test.
	/// 
	/// @since 4.0
	/// </summary>
	public class ConversionServiceTest : XMLTestCase
	{

		private IConversionService srv;
		private SwiftMessage msg;
		private string fin = "{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{3:{108:P22VUXC43C6J3NLD}}{4:\n" + ":20:AMLX985338-D4E5E\n" + ":23B:CRED\n" + ":32A:051018EUR66969,52\n" + ":33B:EUR66969,52\n" + ":50K:FOO SA\n" + ":53A:DEUTDEFF\n" + ":54A://RT\n" + "FOOBARYY\n" + ":59:/-\n" + "Tressis SA\n" + ":70:/CS BD ST EUR B\n" + "REDEMPTION AMLX985338\n" + ":71A:OUR\n" + "-}{5:{MAC:52F48656}{CHK:24C40F1FF931}}";
		private UnparsedTextList unparsedTexts;
		private string someMsgText = "{1:L02VNDZBET2AXXX}{4:{501:05134200001900000513420000190000B8D33C65}{110:001}}";
		private string someText = "hello world";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before protected void setUp() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		protected internal virtual void setUp()
		{
			srv = new ConversionService();
			msg = new SwiftMessage();

			unparsedTexts = new UnparsedTextList();
			unparsedTexts.addText(this.someMsgText);
			unparsedTexts.addText(this.someText);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getFIN(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetFINFromObj()
		public virtual void testGetFINFromObj()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("113:NOMT"));
			msg.Block3.append(new Tag("108", "P22VUXC43C6J3NLD"));
			string fin = srv.getFIN(msg);
			assertEquals("{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{3:{113:NOMT}{108:P22VUXC43C6J3NLD}}", fin);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getFIN(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetFINFromObj2()
		public virtual void testGetFINFromObj2()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("108", "P22VUXC43C6J3NLD"));
			string fin = srv.getFIN(msg);
			assertEquals("{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{3:{108:P22VUXC43C6J3NLD}}", fin);
		}


		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getFIN(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetFINFromObj3_unparsedText()
		public virtual void testGetFINFromObj3_unparsedText()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("113:NOMT"));
			msg.Block3.append(new Tag("108", "P22VUXC43C6J3NLD"));

			msg.UnparsedTexts = this.unparsedTexts;

			string fin = srv.getFIN(msg);
			assertEquals("{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{3:{113:NOMT}{108:P22VUXC43C6J3NLD}}" + this.someMsgText, fin);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getFIN(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetFINFromObj4_unparsedText()
		public virtual void testGetFINFromObj4_unparsedText()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("113:NOMT"));
			msg.Block3.append(new Tag("108", "P22VUXC43C6J3NLD"));

			msg.Block3.UnparsedTexts = this.unparsedTexts;

			string fin = srv.getFIN(msg);
			assertEquals("{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{3:{113:NOMT}{108:P22VUXC43C6J3NLD}" + this.someMsgText + "}", fin);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getFIN(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetFINFromObj5_unparsedText()
		public virtual void testGetFINFromObj5_unparsedText()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("113:NOMT"));
			msg.Block3.append(new Tag("108", "P22VUXC43C6J3NLD"));

			msg.Block3.getTagByName("113").UnparsedTexts = this.unparsedTexts;

			string fin = srv.getFIN(msg);
			assertEquals("{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{3:{113:NOMT" + this.someMsgText + "}{108:P22VUXC43C6J3NLD}}", fin);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getFIN(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetFINThroughXML()
		public virtual void testGetFINThroughXML()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("108:P22VUXC43C6J3NLD"));

			string xml = SwiftWriter.getInternalXml(msg);
			assertNotNull(xml);
			string fin = srv.getFIN(xml);
			assertEquals("{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{3:{108:P22VUXC43C6J3NLD}}", fin);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getFIN(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetFINThroughXML_2()
		public virtual void testGetFINThroughXML_2()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("113:NOMT"));
			msg.Block3.append(new Tag("108:P22VUXC43C6J3NLD"));

			string xml = SwiftWriter.getInternalXml(msg);
			assertNotNull(xml);
			string fin = srv.getFIN(xml);
			assertEquals("{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{3:{113:NOMT}{108:P22VUXC43C6J3NLD}}", fin);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getFIN(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetFINThroughXML_3()
		public virtual void testGetFINThroughXML_3()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlockUser("Z"));
			msg.getUserBlock("Z").append(new Tag("1:val1"));
			msg.getUserBlock("Z").append(new Tag("2:val2"));

			string xml = SwiftWriter.getInternalXml(msg);
			assertNotNull(xml);
			string fin = srv.getFIN(xml);
			assertEquals("{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{Z:{1:val1}{2:val2}}", fin);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjFromXML_block1()
		public virtual void testGetObjFromXML_block1()
		{
			string xml = "<message>" + com.prowidesoftware.swift.Constants_Fields.B1_DATA_XML + "</message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertNotNull(msg);
			assertNotNull(msg.Block1);
			assertNull(msg.Block2);
			assertNull(msg.Block3);
			assertNull(msg.Block4);
			assertNull(msg.Block5);
			assertEquals(com.prowidesoftware.swift.Constants_Fields.B1_DATA, msg.Block1.Value);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjFromXML_block2input()
		public virtual void testGetObjFromXML_block2input()
		{
			string xml = "<message>" + com.prowidesoftware.swift.Constants_Fields.B2_INPUT_XML + "</message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertNotNull(msg);
			assertNull(msg.Block1);
			assertNotNull(msg.Block2);
			assertNull(msg.Block3);
			assertNull(msg.Block4);
			assertNull(msg.Block5);
			assertEquals(com.prowidesoftware.swift.Constants_Fields.B2_INPUT, msg.Block2.BlockValue);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjFromXML_block2output()
		public virtual void testGetObjFromXML_block2output()
		{
			string xml = "<message>" + com.prowidesoftware.swift.Constants_Fields.B2_OUTPUT_XML + "</message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertNotNull(msg);
			assertNull(msg.Block1);
			assertNotNull(msg.Block2);
			assertNull(msg.Block3);
			assertNull(msg.Block4);
			assertNull(msg.Block5);
			assertEquals(com.prowidesoftware.swift.Constants_Fields.B2_OUTPUT, msg.Block2.BlockValue);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjFromXML_block3()
		public virtual void testGetObjFromXML_block3()
		{
			string xml = "<message><block3><tag><name>108</name><value>P22VUXC43C6J3NLD</value></tag></block3></message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertNotNull(msg);
			assertNull(msg.Block1);
			assertNull(msg.Block2);
			assertNotNull(msg.Block3);
			assertNull(msg.Block4);
			assertNull(msg.Block5);
			assertNotNull(msg.Block3);
			assertNotNull(msg.Block3.getTagByName("108"));
			assertEquals("P22VUXC43C6J3NLD", msg.Block3.getTagByName("108").Value);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjFromXML_block5()
		public virtual void testGetObjFromXML_block5()
		{
			string xml = "<message><block5><tag><name>MAC</name><value>52F48656</value></tag><tag><name>CHK</name><value>24C40F1FF931</value></tag></block5></message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertNotNull(msg);
			assertNull(msg.Block1);
			assertNull(msg.Block2);
			assertNull(msg.Block3);
			assertNull(msg.Block4);
			assertNotNull(msg.Block5);
			assertFalse(msg.Block5.Empty);
			assertEquals("52F48656", msg.Block5.getTag(0).Value);
			assertEquals("24C40F1FF931", msg.Block5.getTagByName("CHK").Value);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjFromXML_blockUser()
		public virtual void testGetObjFromXML_blockUser()
		{
			string xml = "<message><block name=\"Z\"><tag><name>1</name><value>val1</value></tag><tag><name>2</name><value>val2</value></tag></block></message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertNotNull(msg);
			assertNull(msg.Block1);
			assertNull(msg.Block2);
			assertNull(msg.Block3);
			assertNull(msg.Block4);
			assertNull(msg.Block5);
			assertNotNull(msg.getUserBlock("Z"));
			assertEquals("val1", msg.getUserBlock("Z").getTag(0).Value);
			assertEquals("val2", msg.getUserBlock("Z").getTagByName("2").Value);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getXml(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjThroughXML()
		public virtual void testGetObjThroughXML()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("108:P22VUXC43C6J3NLD"));

			string xml = srv.getXml(msg);
			SwiftMessage m = srv.getMessageFromXML(xml);
			assertNotNull(m);
			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertNotNull(m.Block3);

			assertEquals("F01FOOBARYYAXXX8669486759", m.Block1.BlockValue);
			assertEquals("O1030831051017CRESLULLCXXX10194697810510170831N", m.Block2.BlockValue);
			assertEquals("P22VUXC43C6J3NLD", m.Block3.getTag(0).Value);
			assertEquals("P22VUXC43C6J3NLD", m.Block3.getTagValue("108"));
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getXml(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjThroughXML_2()
		public virtual void testGetObjThroughXML_2()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlockUser("Z"));
			msg.getUserBlock("Z").append(new Tag("1:val1"));

			string xml = srv.getXml(msg);
			SwiftMessage m = srv.getMessageFromXML(xml);
			assertNotNull(m);
			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertNotNull(m.getUserBlock("Z"));

			assertEquals("F01FOOBARYYAXXX8669486759", m.Block1.BlockValue);
			assertEquals("O1030831051017CRESLULLCXXX10194697810510170831N", m.Block2.BlockValue);
			assertEquals("val1", m.getUserBlock("Z").getTag(0).Value);
			assertEquals("val1", m.getUserBlock("Z").getTagValue("1"));
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getXml(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjThroughXML3_MsgUnparsedText()
		public virtual void testGetObjThroughXML3_MsgUnparsedText()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("108:P22VUXC43C6J3NLD"));

			msg.UnparsedTexts = this.unparsedTexts;

			string xml = srv.getXml(msg);
			SwiftMessage m = srv.getMessageFromXML(xml);
			assertNotNull(m);
			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertNotNull(m.Block3);
			assertEquals("F01FOOBARYYAXXX8669486759", m.Block1.BlockValue);
			assertEquals("O1030831051017CRESLULLCXXX10194697810510170831N", m.Block2.BlockValue);
			assertEquals("P22VUXC43C6J3NLD", m.Block3.getTag(0).Value);
			assertEquals("P22VUXC43C6J3NLD", m.Block3.getTagValue("108"));
			assertEquals(2, (int)m.UnparsedTextsSize);
			assertEquals(this.someMsgText, m.UnparsedTexts.getText(0));
			assertEquals(this.someText, m.UnparsedTexts.getText(1));
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getXml(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjThroughXML4_BlockUnparsedText()
		public virtual void testGetObjThroughXML4_BlockUnparsedText()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("108:P22VUXC43C6J3NLD"));

			msg.Block1.UnparsedTexts = this.unparsedTexts;
			msg.Block2.UnparsedTexts = this.unparsedTexts;
			msg.Block3.UnparsedTexts = this.unparsedTexts;

			string xml = srv.getXml(msg);
			assertNotNull(xml);
			SwiftMessage m = srv.getMessageFromXML(xml);
			assertNotNull(m);
			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertNotNull(m.Block3);

			assertEquals("F01FOOBARYYAXXX8669486759", m.Block1.BlockValue);
			assertEquals("O1030831051017CRESLULLCXXX10194697810510170831N", m.Block2.BlockValue);
			assertEquals("P22VUXC43C6J3NLD", m.Block3.getTag(0).Value);
			assertEquals("P22VUXC43C6J3NLD", m.Block3.getTagValue("108"));

			assertEquals(2, (int)m.Block1.UnparsedTextsSize);
			assertEquals(this.someMsgText, m.Block1.UnparsedTexts.getText(0));
			assertEquals(this.someText, m.Block1.UnparsedTexts.getText(1));

			assertEquals(2, (int)m.Block2.UnparsedTextsSize);
			assertEquals(this.someMsgText, m.Block2.UnparsedTexts.getText(0));
			assertEquals(this.someText, m.Block2.UnparsedTexts.getText(1));

			assertEquals(2, (int)m.Block3.UnparsedTextsSize);
			assertEquals(this.someMsgText, m.Block3.UnparsedTexts.getText(0));
			assertEquals(this.someText, m.Block3.UnparsedTexts.getText(1));
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getXml(net.sourceforge.wife.swift.model.SwiftMessage)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjThroughXML5_TagUnparsedText()
		public virtual void testGetObjThroughXML5_TagUnparsedText()
		{
			msg.clear();
			msg.addBlock(new SwiftBlock1("F01FOOBARYYAXXX8669486759"));
			msg.addBlock(new SwiftBlock2Output("O1030831051017CRESLULLCXXX10194697810510170831N"));
			msg.addBlock(new SwiftBlock3());
			msg.Block3.append(new Tag("108:P22VUXC43C6J3NLD"));

			msg.Block3.getTagByName("108").UnparsedTexts = this.unparsedTexts;

			string xml = srv.getXml(msg);
			SwiftMessage m = srv.getMessageFromXML(xml);
			assertNotNull(m);
			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertNotNull(m.Block3);

			assertEquals("F01FOOBARYYAXXX8669486759", m.Block1.BlockValue);
			assertEquals("O1030831051017CRESLULLCXXX10194697810510170831N", m.Block2.BlockValue);
			assertEquals("P22VUXC43C6J3NLD", m.Block3.getTag(0).Value);
			assertEquals("P22VUXC43C6J3NLD", m.Block3.getTagValue("108"));

			assertEquals(2, (int)m.Block3.getTagByName("108").UnparsedTextsSize);
			assertEquals(this.someMsgText, m.Block3.getTagByName("108").UnparsedTexts.getText(0));
			assertEquals(this.someText, m.Block3.getTagByName("108").UnparsedTexts.getText(1));
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromFIN(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjFromFIN_block4()
		public virtual void testGetObjFromFIN_block4()
		{
			string xml = srv.getXml(fin);
			SwiftMessage m = srv.getMessageFromXML(xml);
			assertNotNull(m);
			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertNotNull(m.Block3);
			assertNotNull(m.Block4);
			assertNotNull(m.Block5);

			assertEquals("F01FOOBARYYAXXX8669486759", m.Block1.BlockValue);
			SwiftBlock4 b = m.Block4;
			assertEquals(10, b.countAll());
			assertEquals("AMLX985338-D4E5E", b.getTagValue("20"));
			assertEquals("CRED", b.getTagValue("23B"));
			assertEquals("051018EUR66969,52", b.getTagValue("32A"));
			assertEquals("OUR", b.getTagValue("71A"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1539324() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBug1539324()
		{
			string fin = "{1:F01FOOBARYYAXXX8669486759}{3:{108:P22VUXC43C6J3NLD}}";
			string xml = srv.getXml(fin);
			XMLUnit.IgnoreWhitespace = true;
			string expected = "<message>\n" + "\n<block1>" + "\n\t<applicationId>F</applicationId>" + "\n\t<serviceId>01</serviceId>" + "\n\t<logicalTerminal>FOOBARYYAXXX</logicalTerminal>" + "\n\t<sessionNumber>8669</sessionNumber>" + "\n\t<sequenceNumber>486759</sequenceNumber>" + "\n</block1>" + "\n<block3>" + "\n\t<tag>" + "\n\t\t<name>108</name>" + "\n\t\t<value>P22VUXC43C6J3NLD</value>" + "\n\t</tag>" + "\n</block3>" + "\n</message>";
			assertXMLEqual(expected, xml);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1539324_2() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBug1539324_2()
		{
			string fin = "{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{3:" + com.prowidesoftware.swift.Constants_Fields.B3_DATA + "}";
			msg = srv.getMessageFromFIN(fin);
			assertNull(msg.Block2);
			assertNull(msg.Block4);
			assertNull(msg.Block5);
			assertEquals(com.prowidesoftware.swift.Constants_Fields.B1_DATA, msg.Block1.Value);
			assertEquals(2, msg.Block3.countAll());
			assertEquals("v", msg.Block3.getTagByName("n").Value);
			assertEquals("v2", msg.Block3.getTagByName("n2").Value);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromFIN(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjFromFIN()
		public virtual void testGetObjFromFIN()
		{
			ConversionService srv;
			string fin = "{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{3:{108:P22VUXC43C6J3NLD}}{4:\n" + ":20:AMLX985338-D4E5E\n" + ":23B:CRED\n" + ":32A:051018EUR66969,52\n" + ":33B:EUR66969,52\n" + ":50K:Tressis SA\n" + ":53A:DEUTDEFF\n" + ":54A://RT\n" + "FOOBARYY\n" + ":59:/-\n" + "Tressis SA\n" + ":70:/CS BD ST EUR B\n" + "REDEMPTION AMLX985338\n" + ":71A:OUR\n" + "-}{5:{MAC:52F48656}{CHK:24C40F1FF931}}";


			srv = new ConversionService();
			msg = new SwiftMessage();

			SwiftMessage m = srv.getMessageFromFIN(fin);

			assertNotNull(m.Block1);
			assertNotNull(m.Block2);
			assertNotNull(m.Block3);
			assertNotNull(m.Block4);
			assertNotNull(m.Block5);

			assertEquals("F01FOOBARYYAXXX8669486759", m.Block1.BlockValue);
			assertEquals(2, m.Block5.countAll());

			assertEquals("MAC", m.Block5.getTag(0).Name);
			assertEquals("52F48656", m.Block5.getTag(0).Value);

			assertEquals("CHK", m.Block5.getTag(1).Name);
			assertEquals("24C40F1FF931", m.Block5.getTag(1).Value);

			assertEquals(1, m.Block3.countAll());
			assertEquals("108", m.Block3.getTag(0).Name);
			assertEquals("P22VUXC43C6J3NLD", m.Block3.getTag(0).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadEmptyBlock1()
		public virtual void testReadEmptyBlock1()
		{
			SwiftMessage m = srv.getMessageFromXML("<message><block1/></message>");
			assertNotNull(m);
			assertNotNull(m.Block1);
			assertNull(m.Block2);
			assertNull(m.Block3);
			assertNull(m.Block4);
			assertNull(m.Block5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadEmptyBlock2()
		public virtual void testReadEmptyBlock2()
		{
			SwiftMessage m = srv.getMessageFromXML("<message><block2 type=\"input\"/></message>");
			assertNotNull(m);
			assertNull(m.Block1);
			assertNotNull(m.Block2);
			assertNull(m.Block3);
			assertNull(m.Block4);
			assertNull(m.Block5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetObjFromIncompleteXML()
		public virtual void testGetObjFromIncompleteXML()
		{
			string xml = "<message><block1><serviceId>01</serviceId></block1></message>";
			SwiftMessage m = srv.getMessageFromXML(xml);
			assertNotNull(m);
			assertNotNull(m.Block1);
			//assertNull(m.getBlock1().getApplicationId());
			assertEquals("01", m.Block1.ServiceId);
			assertNull(m.Block1.LogicalTerminal);
			//assertNull(m.getBlock1().getSessionNumber());
			//assertNull(m.getBlock1().getSequenceNumber());
			assertNull(m.Block2);
			assertNull(m.Block3);
			assertNull(m.Block4);
			assertNull(m.Block5);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCRLF_0()
		public virtual void testCRLF_0()
		{
			string xml = "<message><block4><tag><name>58</name><value>line1</value></tag></block4></message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertEquals("line1", msg.Block4.getTagByName("58").Value);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCRLF_1()
		public virtual void testCRLF_1()
		{
			string xml = "<message><block4><tag><name>58</name><value>line1\nline2</value></tag></block4></message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertEquals("line1\r\nline2", msg.Block4.getTagByName("58").Value);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCRLF_2()
		public virtual void testCRLF_2()
		{
			string xml = "<message><block4><tag><name>58</name><value>line1\r\nline2</value></tag></block4></message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertEquals("line1\r\nline2", msg.Block4.getTagByName("58").Value);
		}

		/// <summary>
		/// Test method for <seealso cref="net.sourceforge.wife.services.ConversionService#getMessageFromXML(java.lang.String)"/>.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCRLF_3()
		public virtual void testCRLF_3()
		{
			string xml = "<message><block4><tag><name>58</name><value>line1\r\nline2\r\nline3</value></tag></block4></message>";
			SwiftMessage msg = srv.getMessageFromXML(xml);
			assertEquals("line1\r\nline2\r\nline3", msg.Block4.getTagByName("58").Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBackAndForthXMLConversion1()
		public virtual void testBackAndForthXMLConversion1()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = "{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{4:" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + ":57A:/123456789" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + "FOOBARYY" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + "-}";
			string fin = "{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{4:" + FINWriterVisitor.SWIFT_EOL + ":57A:/123456789" + FINWriterVisitor.SWIFT_EOL + "FOOBARYY" + FINWriterVisitor.SWIFT_EOL + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = srv.getXml(fin);
			string xml = srv.getXml(fin);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin2 = srv.getFIN(xml);
			string fin2 = srv.getFIN(xml);
			assertEquals(fin, fin2);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBackAndForthXMLConversion2()
		public virtual void testBackAndForthXMLConversion2()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = "{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{4:" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + ":57A:/D/123456789" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + "FOOBARYY" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + "-}";
			string fin = "{1:F01FOOBARYYAXXX8669486759}{2:O1030831051017CRESLULLCXXX10194697810510170831N}{4:" + FINWriterVisitor.SWIFT_EOL + ":57A:/D/123456789" + FINWriterVisitor.SWIFT_EOL + "FOOBARYY" + FINWriterVisitor.SWIFT_EOL + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = srv.getXml(fin);
			string xml = srv.getXml(fin);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin2 = srv.getFIN(xml);
			string fin2 = srv.getFIN(xml);
			assertEquals(fin, fin2);
		}

	}

}