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
namespace com.prowidesoftware.swift.io.writer
{


	using XMLTestCase = org.custommonkey.xmlunit.XMLTestCase;
	using XMLUnit = org.custommonkey.xmlunit.XMLUnit;
	using Before = org.junit.Before;
	using Test = org.junit.Test;
	using SAXException = org.xml.sax.SAXException;

	using SwiftBlock1 = com.prowidesoftware.swift.model.SwiftBlock1;
	using SwiftBlock2 = com.prowidesoftware.swift.model.SwiftBlock2;
	using SwiftBlock2Input = com.prowidesoftware.swift.model.SwiftBlock2Input;
	using SwiftBlock2Output = com.prowidesoftware.swift.model.SwiftBlock2Output;
	using SwiftBlock3 = com.prowidesoftware.swift.model.SwiftBlock3;
	using SwiftBlock4 = com.prowidesoftware.swift.model.SwiftBlock4;
	using SwiftBlock5 = com.prowidesoftware.swift.model.SwiftBlock5;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using Tag = com.prowidesoftware.swift.model.Tag;

	/// <summary>
	/// XML writer tests
	/// 
	/// @since 4.0
	/// </summary>
	public class XMLWriterVisitorTest : XMLTestCase
	{

		private XMLWriterVisitor visitor;
		private Writer io;
		private SwiftMessage msg;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			this.io = new StringWriter();
			this.visitor = new XMLWriterVisitor(this.io);
			this.msg = new SwiftMessage();
			this.msg.clear(); // some tests require that there are no extra blocks
			XMLUnit.IgnoreWhitespace = true;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private String getResult()
		private string Result
		{
			get
			{
				return (this.getResult(""));
			}
		}

		private string getResult(string testName)
		{
			msg.visit(visitor);
			return this.io.ToString();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testEmpty() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testEmpty()
		{
			msg.Block1 = null;
			msg.Block2 = null;
			msg.Block3 = null;
			msg.Block4 = null;
			msg.Block5 = null;

			assertXMLEqual("<message/>", getResult("testEmpty"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testEmptyBlocks() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testEmptyBlocks()
		{
			msg.Block1 = new SwiftBlock1();
			msg.Block1.ApplicationId = null;
			msg.Block1.ServiceId = null;
			msg.Block1.SessionNumber = null;
			msg.Block1.SequenceNumber = null;
			msg.Block2 = new SwiftBlock2Input();
			msg.Block2.MessagePriority = null;
			msg.Block3 = new SwiftBlock3();
			msg.Block4 = new SwiftBlock4();
			msg.Block5 = new SwiftBlock5();

			string xml = "<message><block1/>\n<block2/>\n<block3/>\n<block4/>\n<block5/>\n</message>";
			assertXMLEqual(xml, getResult("testEmptyBlocks"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWithTags() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testWithTags()
		{
			string xml = "<message>" + com.prowidesoftware.swift.Constants_Fields.B1_DATA_XML + "\n<block4>" + "\n\t<tag>" + "\n\t\t<name>t1</name>" + "\n\t\t<value>v1</value>" + "\n\t</tag>" + "\n</block4>" + "\n</message>";
			msg.clear();
			SwiftBlock1 b1 = new SwiftBlock1();
			b1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			SwiftBlock4 b4 = new SwiftBlock4();
			b4.append(new Tag("t1:v1"));
			msg.Block1 = b1;
			msg.Block4 = b4;
			assertXMLEqual(xml, getResult("testWithTags"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1539324_1() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBug1539324_1()
		{
			SwiftBlock1 b1 = new SwiftBlock1();
			b1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			msg.Block1 = b1;

			SwiftBlock2 b2 = new SwiftBlock2Input();
			b2.Value = com.prowidesoftware.swift.Constants_Fields.B2_INPUT;
			msg.Block2 = b2;

			string xml = "<message>\n" + com.prowidesoftware.swift.Constants_Fields.B1_DATA_XML + com.prowidesoftware.swift.Constants_Fields.B2_INPUT_XML + "</message>";
			assertXMLEqual(xml, getResult("testBug1539324_1"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1539324_2() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBug1539324_2()
		{
			SwiftBlock1 b1 = new SwiftBlock1();
			b1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			msg.Block1 = b1;

			SwiftBlock3 b3 = new SwiftBlock3();
			b3.append(new Tag("n:v"));
			msg.Block3 = b3;

			msg.Block2 = new SwiftBlock2Input();
			msg.Block2.MessagePriority = null;
			msg.Block4 = new SwiftBlock4();
			msg.Block5 = new SwiftBlock5();

			string xml = "<message>\n" + com.prowidesoftware.swift.Constants_Fields.B1_DATA_XML + "<block2></block2>\n" + "<block3>" + "\n\t<tag>" + "\n\t\t<name>n</name>" + "\n\t\t<value>v</value>" + "\n\t</tag>" + "\n</block3>" + "\n<block4>\n</block4>" + "\n<block5>\n</block5>" + "\n</message>";
			assertXMLEqual(xml, getResult("testBug1539324_2"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1540294_1() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBug1540294_1()
		{
			msg.clear();
			SwiftBlock4 b4 = new SwiftBlock4();
			b4.append(new Tag("t1", "v1"));
			b4.append(new Tag("t2", "v2"));
			msg.Block4 = b4;

			string xml = "<message>\n" + "<block4>" + "\n\t<tag>" + "\n\t\t<name>t1</name>" + "\n\t\t<value>v1</value>" + "\n\t</tag>" + "\n\t<tag>" + "\n\t\t<name>t2</name>" + "\n\t\t<value>v2</value>" + "\n\t</tag>" + "\n</block4>" + "</message>";
			assertXMLEqual(xml, getResult("testBug1540294_1"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock2Output_1() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock2Output_1()
		{
			msg.clear();
			SwiftBlock1 b1 = new SwiftBlock1();
			b1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			msg.Block1 = b1;

			SwiftBlock2 b2 = new SwiftBlock2Output();
			b2.Value = com.prowidesoftware.swift.Constants_Fields.B2_OUTPUT;
			msg.Block2 = b2;

			string xml = "<message>\n" + com.prowidesoftware.swift.Constants_Fields.B1_DATA_XML + com.prowidesoftware.swift.Constants_Fields.B2_OUTPUT_XML + "</message>";
			assertXMLEqual(xml, getResult("testBlock2Output_1"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock2Output() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock2Output()
		{
			msg.clear();

			SwiftBlock2 b2 = new SwiftBlock2Output();
			b2.Value = com.prowidesoftware.swift.Constants_Fields.B2_OUTPUT;
			msg.Block2 = b2;

			string xml = "<message>\n" + com.prowidesoftware.swift.Constants_Fields.B2_OUTPUT_XML + "</message>";
			string got = getResult("testBlock2Output");
			assertXMLEqual(xml, got);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTagSerialization() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testTagSerialization()
		{
			msg.clear();
			SwiftBlock4 b4 = new SwiftBlock4();
			b4.append(new Tag("26C", "/LONDON/UNFOOGOLD"));
			msg.Block4 = b4;

			string xml = "<message>\n" + "<block4>" + "\n\t<tag>" + "\n\t\t<name>26C</name>" + "\n\t\t<value>/LONDON/UNFOOGOLD</value>" + "\n\t</tag>" + "\n</block4>" + "</message>";
			assertXMLEqual(xml, getResult("testTagSerialization"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFieldSerialization() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFieldSerialization()
		{
			msg.clear();
			msg.Block4 = new SwiftBlock4();

			msg.Block4.append(new Tag("26C", "/LONDON/UNFOOGOLD"));
			//workaround
			//mt.getSwiftMessage().getBlock4().append(new Tag("26C", "/LONDON/UNFOOGOLD"));

			string xml = "<message>\n" + "<block4>" + "\n\t<tag>" + "\n\t\t<name>26C</name>" + "\n\t\t<value>/LONDON/UNFOOGOLD</value>" + "\n\t</tag>" + "\n</block4>" + "</message>";
			assertXMLEqual(xml, getResult("testFieldSerialization"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWithTags_asField() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testWithTags_asField()
		{
			string xml = "<message>" + com.prowidesoftware.swift.Constants_Fields.B1_DATA_XML + "\n<block4>" + "\n\t<field>" + "\n\t\t<name>16R</name>" + "\n\t\t<component number=\"1\">TEST</component>" + "\n\t</field>" + "\n</block4>" + "\n</message>";
			msg.clear();
			SwiftBlock1 b1 = new SwiftBlock1();
			b1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			SwiftBlock4 b4 = new SwiftBlock4();
			b4.append(new Tag("16R:TEST"));
			msg.Block1 = b1;
			msg.Block4 = b4;
			this.visitor = new XMLWriterVisitor(this.io, true);
			assertXMLEqual(xml, getResult("testWithTags"));
		}

	}

}