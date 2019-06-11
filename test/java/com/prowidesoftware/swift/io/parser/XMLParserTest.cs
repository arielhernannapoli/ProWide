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
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;



	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;
	using Document = org.w3c.dom.Document;
	using Node = org.w3c.dom.Node;
	using SAXException = org.xml.sax.SAXException;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using MT103 = com.prowidesoftware.swift.model.mt.mt1xx.MT103;

	/// <summary>
	/// XML parser tests
	/// 
	/// @since 4.0
	/// </summary>
	public class XMLParserTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse()
		public virtual void testParse()
		{
			string xml = "<message>\n" + "<block1>\n" + "	<applicationId>F</applicationId>\n" + "	<serviceId>01</serviceId>\n" + "	<logicalTerminal>BANKBEBBAXXX</logicalTerminal>\n" + "	<sessionNumber>2222</sessionNumber>\n" + "	<sequenceNumber>123456</sequenceNumber>\n" + "</block1>\n" + "<block4>\n" + "	<tag>\n" + "		<name>t1</name>\n" + "		<value>v1</value>\n" + "	</tag>\n" + "</block4>\n" + "</message>";
			XMLParser p = new XMLParser();
			SwiftMessage m = p.parse(xml);
			assertNotNull(m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse2()
		public virtual void testParse2()
		{
			string xml = "<message>\n" + "<block1>\n" + "	<applicationId>F</applicationId>\n" + "	<serviceId>01</serviceId>\n" + "	<logicalTerminal>BANKBEBBAXXX</logicalTerminal>\n" + "	<sessionNumber>2222</sessionNumber>\n" + "	<sequenceNumber>123456</sequenceNumber>\n" + "</block1>\n" + "<block2 type=\"input\">\n" + "	<messageType>100</messageType>\n" + "	<receiverAddress>BANKDEFFXXXX</receiverAddress>\n" + "	<messagePriority>U</messagePriority>\n" + "	<deliveryMonitoring>3</deliveryMonitoring>\n" + "	<obsolescencePeriod>003</obsolescencePeriod>\n" + "</block2>\n" + "</message>";
			XMLParser p = new XMLParser();
			SwiftMessage m = p.parse(xml);
			assertNotNull(m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse3()
		public virtual void testParse3()
		{
			string xml = "<message>\n" + "<block1>\n" + "	<applicationId>F</applicationId>\n" + "	<serviceId>01</serviceId>\n" + "	<logicalTerminal>BANKBEBBAXXX</logicalTerminal>\n" + "	<sessionNumber>2222</sessionNumber>\n" + "	<sequenceNumber>123456</sequenceNumber>\n" + "</block1>\n" + "<block2 type=\"output\">\n" + "	<messageType>100</messageType>\n" + "	<senderInputTime>1200</senderInputTime>\n" + "	<MIRDate>970103</MIRDate>\n" + "	<MIRLogicalTerminal>BANKBEBBAXXX</MIRLogicalTerminal>\n" + "	<MIRSessionNumber>2222</MIRSessionNumber>\n" + "	<MIRSequenceNumber>123456</MIRSequenceNumber>\n" + "	<receiverOutputDate>970103</receiverOutputDate>\n" + "	<receiverOutputTime>1201</receiverOutputTime>\n" + "	<messagePriority>N</messagePriority>\n" + "</block2>\n" + "</message>";
			XMLParser p = new XMLParser();
			SwiftMessage m = p.parse(xml);
			assertNotNull(m);
		}

		/// <summary>
		/// Test for w3 dom parsing behavior </summary>
		/// <exception cref="ParserConfigurationException"> </exception>
		/// <exception cref="SAXException"> </exception>
		/// <exception cref="IOException"> </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNode() throws javax.xml.parsers.ParserConfigurationException, org.xml.sax.SAXException, java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testNode()
		{
			const string text = "<tag>line1\r\nline2</tag>";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.parsers.DocumentBuilder db = javax.xml.parsers.DocumentBuilderFactory.newInstance().newDocumentBuilder();
			DocumentBuilder db = DocumentBuilderFactory.newInstance().newDocumentBuilder();
			InputStream @is = new ByteArrayInputStream(text.GetBytes("UTF-8"));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.w3c.dom.Document doc = db.parse(is);
			Document doc = db.parse(@is);
			Node n = doc.FirstChild;
			//this proves that DOM parser removes original carriage return characters from XML
			assertEquals("line1\nline2", n.FirstChild.NodeValue);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCRLF_replace()
		public virtual void testCRLF_replace()
		{
			string text = "aaa\nbbb";
			text = StringUtils.replace(text, "\n", FINWriterVisitor.SWIFT_EOL);
			assertEquals("aaa\r\nbbb", text);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNull()
		public virtual void testNull()
		{
			string xml = "<message>\n" + "\n" + "<block1>\n" + "\n" + "	<applicationId>F</applicationId>\n" + "\n" + "	<serviceId>01</serviceId>\n" + "\n" + "	<logicalTerminal>CECAESMMA017</logicalTerminal>\n" + "\n" + "	<sessionNumber>0000</sessionNumber>\n" + "\n" + "	<sequenceNumber>000000</sequenceNumber>\n" + "\n" + "</block1>\n" + "\n" + "<block2 type=\"input\">\n" + "\n" + "	<messageType>320</messageType>\n" + "\n" + "	<receiverAddress>CAAMES2AXXXX</receiverAddress>\n" + "\n" + "	<messagePriority>N</messagePriority>\n" + "\n" + "</block2>\n" + "\n" + "<block4>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>15A</name>\n" + "\n" + "		<value></value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>20</name>\n" + "\n" + "		<value>00005586-090224</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>22A</name>\n" + "\n" + "		<value>NEWT</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>22B</name>\n" + "\n" + "		<value>CONF</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>22C</name>\n" + "\n" + "		<value>CAAM2A0001CECAMM</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>82A</name>\n" + "\n" + "		<value>CECAESMM017</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>87A</name>\n" + "\n" + "		<value>CAAMES2AXXX</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>15B</name>\n" + "\n" + "		<value></value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>17R</name>\n" + "\n" + "		<value>L</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>30T</name>\n" + "\n" + "		<value>20090224</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>30V</name>\n" + "\n" + "		<value>20090224</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>30P</name>\n" + "\n" + "		<value>20090225</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>32B</name>\n" + "\n" + "		<value>EUR111,00</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>30X</name>\n" + "\n" + "		<value>20090225</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>34E</name>\n" + "\n" + "		<value>NEUR0,00</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>37G</name>\n" + "\n" + "		<value>1,</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>14D</name>\n" + "\n" + "		<value>ACT/360</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>15C</name>\n" + "\n" + "		<value></value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>53A</name>\n" + "\n" + "		<value>CECAESMM017</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>58A</name>\n" + "\n" + "		<value>CAAMES2AXXX</value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>15D</name>\n" + "\n" + "		<value></value>\n" + "\n" + "	</tag>\n" + "\n" + "	<tag>\n" + "\n" + "		<name>57A</name>\n" + "\n" + "		<value>CECAESMM017</value>\n" + "\n" + "	</tag>\n" + "\n" + "</block4>\n" + "\n" + "</message>";
			XMLParser p = new XMLParser();
			SwiftMessage m = p.parse(xml);
			assertNotNull(m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFieldFormat()
		public virtual void testFieldFormat()
		{
			string xml = "<message>\n" + "<block1>\n" + "	<applicationId>F</applicationId>\n" + "	<serviceId>01</serviceId>\n" + "	<logicalTerminal>TESTUS00AXXX</logicalTerminal>\n" + "	<sessionNumber>0816</sessionNumber>\n" + "	<sequenceNumber>000001</sequenceNumber>\n" + "</block1>\n" + "<block2 type=\"input\">\n" + "	<messageType>103</messageType>\n" + "	<receiverAddress>FOONUS33XXXX</receiverAddress>\n" + "	<messagePriority>N</messagePriority>\n" + "</block2>\n" + "<block4>\n" + "<field>\n" + "	<name>20</name>\n" + "	<component number=\"1\">prueba</component>\n" + "</field>\n" + "<field>\n" + "	<name>23B</name>\n" + "	<component number=\"1\">CRED</component>\n" + "</field>\n" + "<field>\n" + "	<name>32A</name>\n" + "	<component number=\"1\">160621</component>\n" + "	<component number=\"2\">USD</component>\n" + "	<component number=\"3\">123123,22</component>\n" + "</field>\n" + "<field>\n" + "	<name>50A</name>\n" + "	<component number=\"1\">234523452345345234</component>\n" + "	<component number=\"2\">CITIZAJXTRD</component>\n" + "</field>\n" + "<field>\n" + "	<name>52A</name>\n" + "	<component number=\"2\">23423421343</component>\n" + "	<component number=\"3\">ITAUKYKTXXX</component>\n" + "</field>\n" + "<field>\n" + "	<name>59A</name>\n" + "	<component number=\"1\">24523523452345</component>\n" + "	<component number=\"2\">HSBCVNVXXXX</component>\n" + "</field>\n" + "<field>\n" + "	<name>71A</name>\n" + "	<component number=\"1\">SHA</component>\n" + "</field>\n" + "</block4>\n" + "</message>";
			XMLParser p = new XMLParser();
			SwiftMessage m = p.parse(xml);
			assertNotNull(m);
			MT103 mt = new MT103(m);

			assertNotNull(mt.Field20);
			assertNotNull("prueba", mt.Field20.Component1);

			assertNotNull(mt.Field23B);
			assertNotNull("CRED", mt.Field23B.Component1);

			assertNotNull(mt.Field32A);
			assertNotNull("160621", mt.Field32A.Component1);
			assertNotNull("USD", mt.Field32A.Component1);
			assertNotNull("123123,22", mt.Field32A.Component1);

			assertNotNull(mt.Field50A);
			assertNotNull("234523452345345234", mt.Field50A.Component1);
			assertNotNull("CITIZAJXTRD", mt.Field50A.Component1);

			assertNotNull(mt.Field52A);
			assertNotNull("23423421343", mt.Field52A.Component2);
			assertNotNull("ITAUKYKTXXX", mt.Field52A.Component3);

			assertNotNull(mt.Field59A);
			assertNotNull("24523523452345", mt.Field59A.Component1);
			assertNotNull("HSBCVNVXXXX", mt.Field59A.Component2);

			assertNotNull(mt.Field71A);
			assertNotNull("SHA", mt.Field71A.Component1);
		}

	}


}