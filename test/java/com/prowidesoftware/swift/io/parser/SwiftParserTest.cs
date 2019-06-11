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
namespace com.prowidesoftware.swift.io.parser
{

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;
	using com.prowidesoftware.swift.model;
	using Before = org.junit.Before;
	using Ignore = org.junit.Ignore;
	using Test = org.junit.Test;
	using SAXException = org.xml.sax.SAXException;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// Swift parser tests using the default lenient (permissive) mode.
	/// 
	/// <para>In this configuration the parser will apply a best effort heuristic
	/// to read all blocks content. For instance it will read the block 4 regardless
	/// of the proper closing boundary -} and also will read the headers even if
	/// some fields are not present and the overall header size is incorrect.
	/// </para>
	/// </summary>
	public class SwiftParserTest
	{
		protected internal VisibleParser parser;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			this.parser = new VisibleParser();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadBlock() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadBlock()
		{
			parser.Data = "asdklajdkla{foobar}njdkasndkja}{not seen}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String m = parser.readUntilBlockEnds();
			string m = parser.readUntilBlockEnds();
			assertEquals("asdklajdkla{foobar}njdkasndkja", m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadBlock3() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadBlock3()
		{
			parser.Data = "3:{108:00750534912215}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String m = parser.readUntilBlockEnds();
			string m = parser.readUntilBlockEnds();
			assertEquals("3:{108:00750534912215}", m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadBlock4() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadBlock4()
		{
			parser.Data = "4:" + FINWriterVisitor.SWIFT_EOL + ":16R:GENL" + FINWriterVisitor.SWIFT_EOL + ":23G:NEWM" + FINWriterVisitor.SWIFT_EOL + ":98A::PREP//20050711" + FINWriterVisitor.SWIFT_EOL + ":16S:GENL" + FINWriterVisitor.SWIFT_EOL + ":16S:AMT" + FINWriterVisitor.SWIFT_EOL + ":16S:SETDET" + FINWriterVisitor.SWIFT_EOL + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String m = parser.readUntilBlockEnds();
			string m = parser.readUntilBlockEnds();
			assertEquals("4:\r\n" + ":16R:GENL\r\n" + ":23G:NEWM\r\n" + ":98A::PREP//20050711\r\n" + ":16S:GENL\r\n" + ":16S:AMT\r\n" + ":16S:SETDET\r\n" + "-", m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadBlockTwoInner() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadBlockTwoInner()
		{
			parser.Data = "3:{113:NOMF}{108:0510280086100051}{119:STP}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String m = parser.readUntilBlockEnds();
			string m = parser.readUntilBlockEnds();
			assertEquals("3:{113:NOMF}{108:0510280086100051}{119:STP}", m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIdentifyBlock1()
		public virtual void testIdentifyBlock1()
		{
			const string b = "1:F01MYBICFF0XXXX0000000000";
			assertEquals('1', parser.identifyBlock(b));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIdentifyBlock2()
		public virtual void testIdentifyBlock2()
		{
			const string b = "2:I541TTTTTL2XXXXXN";
			assertEquals('2', parser.identifyBlock(b));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetBlock4() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetBlock4()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:\r\n" + ":16R:GENL\r\n" + ":23G:NEWM\r\n" + ":98A::PREP//20050711\r\n" + ":16S:GENL\r\n" + ":16S:AMT\r\n" + ":16S:SETDET\r\n" + "-}");
			SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:\r\n" + ":16R:GENL\r\n" + ":23G:NEWM\r\n" + ":98A::PREP//20050711\r\n" + ":16S:GENL\r\n" + ":16S:AMT\r\n" + ":16S:SETDET\r\n" + "-}");
			assertNotNull(b4);
			assertEquals(6, b4.size());
			assertEquals("16R", b4.getTag(0).Name);
			assertEquals("98A", b4.getTag(2).Name);
			assertEquals("GENL", b4.getTag(0).Value);
			assertEquals(":PREP//20050711", b4.getTag(2).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetBlock4Brackets1() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetBlock4Brackets1()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:\r\n" + ":79:foobar{bad\r\n" + "-}");
			SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:\r\n" + ":79:foobar{bad\r\n" + "-}");
			assertNotNull(b4);
			assertEquals(1, b4.size());
			assertEquals("foobar{bad", b4.getTag(0).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetBlock4Brackets2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetBlock4Brackets2()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:\r\n" + ":79:foobar{bad\r\n" + "-}");
			SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:\r\n" + ":79:foobar{bad\r\n" + "-}");
			assertNotNull(b4);
			assertEquals(1, b4.size());
			assertEquals("foobar{bad", b4.getTag(0).Value);
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetBlock4WithMultiline() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetBlock4WithMultiline()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:" + SwiftParser.EOL + ":98A::SETT//20050708" + SwiftParser.EOL + ":90B::DEAL//ACTU/USD28,86" + SwiftParser.EOL + ":35B:ISIN US1112223330" + SwiftParser.EOL + "MY COMPANY" + SwiftParser.EOL + ":16S:TRADDET" + SwiftParser.EOL + ":16R:FIAC" + SwiftParser.EOL + ":36B::SETT//UNIT/370,00" + SwiftParser.EOL + ":97A::SAFE//111222" + SwiftParser.EOL + ":16S:FIAC" + SwiftParser.EOL + ":16R:SETDET" + "-}");
			SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:" + SwiftParser.EOL + ":98A::SETT//20050708" + SwiftParser.EOL + ":90B::DEAL//ACTU/USD28,86" + SwiftParser.EOL + ":35B:ISIN US1112223330" + SwiftParser.EOL + "MY COMPANY" + SwiftParser.EOL + ":16S:TRADDET" + SwiftParser.EOL + ":16R:FIAC" + SwiftParser.EOL + ":36B::SETT//UNIT/370,00" + SwiftParser.EOL + ":97A::SAFE//111222" + SwiftParser.EOL + ":16S:FIAC" + SwiftParser.EOL + ":16R:SETDET" + "-}");
			assertNotNull(b4);
			assertEquals(9, b4.size());
			assertEquals("35B", b4.getTag(2).Name);

			assertEquals("ISIN US1112223330" + SwiftParser.EOL + "MY COMPANY", b4.getTagByName("35B").Value);

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeTag16R() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeTag16R()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = parser.consumeTag(":16R:GENL\r\n");
			Tag t = parser.consumeTag(":16R:GENL\r\n");
			assertNotNull(t);
			assertEquals("16R", t.Name);
			assertEquals("GENL", t.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeTagWithBraquets() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeTagWithBraquets()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = parser.consumeTag(":50K:ABCD}EFG\r\n");
			Tag t = parser.consumeTag(":50K:ABCD}EFG\r\n");
			assertNotNull(t);
			assertEquals("50K", t.Name);
			assertEquals("ABCD}EFG", t.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadUntilBlockEnds1() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadUntilBlockEnds1()
		{
			parser.Data = "damskldmsakld}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String s = parser.readUntilBlockEnds();
			string s = parser.readUntilBlockEnds();
			assertEquals("damskldmsakld", s);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadUntilBlockEnds2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadUntilBlockEnds2()
		{
			parser.Data = "foo}{bar}";
			string s = parser.readUntilBlockEnds();
			assertEquals("foo", s);
			parser.findBlockStart();
			s = parser.readUntilBlockEnds();
			assertEquals("bar", s);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadUntilBlockEnds3() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadUntilBlockEnds3()
		{
			parser.Data = "foo}{bar}{as\r\nfoobar\nbye\r\n}";
			string s = parser.readUntilBlockEnds();
			assertEquals("foo", s);
			parser.findBlockStart();
			s = parser.readUntilBlockEnds();
			assertEquals("bar", s);
			parser.findBlockStart();
			s = parser.readUntilBlockEnds();
			assertEquals("as\r\nfoobar\nbye\r\n", s);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadUntilBlockEnds2WithNested() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadUntilBlockEnds2WithNested()
		{
			parser.Data = "foo{x}y{z}}{bar{feel}like{coding}today}";
			string s = parser.readUntilBlockEnds();
			assertEquals("foo{x}y{z}", s);
			parser.findBlockStart();
			s = parser.readUntilBlockEnds();
			assertEquals("bar{feel}like{coding}today", s);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadUntilBlockEnds2WithBraquets() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadUntilBlockEnds2WithBraquets()
		{
			parser.Data = "4:foo{xyz}4:bar{feellike{codingtoday\n-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String s = parser.readUntilBlockEnds();
			string s = parser.readUntilBlockEnds();
			assertEquals("4:foo{xyz}4:bar{feellike{codingtoday\n-", s);

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadUntilBlockEnds2WithBraquetsB() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadUntilBlockEnds2WithBraquetsB()
		{
			parser.Data = "4:bar{feellike{codingtoday}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String s = parser.readUntilBlockEnds();
			string s = parser.readUntilBlockEnds();
			/*
			 * We expect } in the last value because it is not a proper block termination, and the block
			 * actually ends by EOF, not the bracket
			 */
			assertEquals("4:bar{feellike{codingtoday}", s);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadBlock4WithStartingBraquetInFieldValue() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadBlock4WithStartingBraquetInFieldValue()
		{
			parser.Data = "4:" + FINWriterVisitor.SWIFT_EOL + ":16R:GENL" + FINWriterVisitor.SWIFT_EOL + ":23G:NEWM" + FINWriterVisitor.SWIFT_EOL + ":98A::PREP//20050711" + FINWriterVisitor.SWIFT_EOL + ":16S:GE{NL" + FINWriterVisitor.SWIFT_EOL + ":16S:AMT" + FINWriterVisitor.SWIFT_EOL + ":16S:SETDET" + FINWriterVisitor.SWIFT_EOL + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String m = parser.readUntilBlockEnds();
			string m = parser.readUntilBlockEnds();
			assertEquals("4:\r\n" + ":16R:GENL\r\n" + ":23G:NEWM\r\n" + ":98A::PREP//20050711\r\n" + ":16S:GE{NL\r\n" + ":16S:AMT\r\n" + ":16S:SETDET\r\n" + "-", m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReadBlock4WithClosingBraquetInFieldValue() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testReadBlock4WithClosingBraquetInFieldValue()
		{
			parser.Data = "4:" + FINWriterVisitor.SWIFT_EOL + ":16R:GENL" + FINWriterVisitor.SWIFT_EOL + ":23G:NEWM" + FINWriterVisitor.SWIFT_EOL + ":98A::PREP//20050711" + FINWriterVisitor.SWIFT_EOL + ":16S:GE}NL" + FINWriterVisitor.SWIFT_EOL + ":16S:AMT" + FINWriterVisitor.SWIFT_EOL + ":16S:SETDET" + FINWriterVisitor.SWIFT_EOL + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String m = parser.readUntilBlockEnds();
			string m = parser.readUntilBlockEnds();
			assertEquals("4:\r\n" + ":16R:GENL\r\n" + ":23G:NEWM\r\n" + ":98A::PREP//20050711\r\n" + ":16S:GE}NL\r\n" + ":16S:AMT\r\n" + ":16S:SETDET\r\n" + "-", m);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock1() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock1()
		{
			parser.Data = "{1:0123456789012345678901234}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock1 b = (SwiftBlock1) parser.consumeBlock(null);
			SwiftBlock1 b = (SwiftBlock1) parser.consumeBlock(null);
			assertNotNull(b);
			assertTrue(b is SwiftBlock1);
			assertEquals("0123456789012345678901234", b.BlockValue);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock2()
		{
			parser.Data = "{1:F01FOOBARXXXXXX0000000000}{2:I100BANKDEFFXXXXU3003}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock1 b = (SwiftBlock1) parser.consumeBlock(null);
			SwiftBlock1 b = (SwiftBlock1) parser.consumeBlock(null);
			assertNotNull(b);
			assertEquals(1, (int)b.Number);
			assertEquals("F01FOOBARXXXXXX0000000000", b.BlockValue);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock2 b2 = (SwiftBlock2) parser.consumeBlock(null);
			SwiftBlock2 b2 = (SwiftBlock2) parser.consumeBlock(null);
			assertNotNull(b2);
			assertEquals(2, (int)b2.Number);
			assertEquals("I100BANKDEFFXXXXU3003", b2.BlockValue);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock3() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock3()
		{
			parser.Data = "{1:F01FOOBARXXXXXX0000000000}{2:I541CITIGB2LXXXXN}{4:\r\n" + ":16R:GENL\r\n" + ":20C::SEME//2005070600000006\r\n" + ":23G:NEWM\r\n" + ":98A::PREP//20050706\r\n" + ":16S:GENL\r\n" + ":16R:TRADDET\r\n" + ":98A::TRAD//20050706\r\n" + ":98A::SETT//20050711\r\n" + ":90B::DEAL//ACTU/GBP1,38\r\n" + ":35B:ISIN GB0007192106\r\n" + "VODAFONE\r\n" + ":16S:TRADDET\r\n" + ":16R:FIAC\r\n" + ":36B::SETT//UNIT/5000,00\r\n" + ":97A::SAFE//6990457647\r\n" + ":16S:FIAC\r\n" + ":16R:SETDET\r\n" + ":22F::SETR//TRAD\r\n" + ":16R:SETPRTY\r\n" + ":95R::DEAG/CRST/382\r\n" + ":16S:SETPRTY\r\n" + ":16R:SETPRTY\r\n" + ":95P::SELL//ISNTGB2L\r\n" + ":16S:SETPRTY\r\n" + ":16R:SETPRTY\r\n" + ":95P::PSET//CRSTGB22\r\n" + ":16S:SETPRTY\r\n" + ":16R:AMT\r\n" + ":19A::SETT//GBP6958,31\r\n" + ":16S:AMT\r\n" + ":16S:SETDET\r\n" + "-}\r\n" + "";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock1 b1 = (SwiftBlock1) parser.consumeBlock(null);
			SwiftBlock1 b1 = (SwiftBlock1) parser.consumeBlock(null);
			assertNotNull(b1);
			assertEquals(1, (int)b1.Number);
			assertEquals("F01FOOBARXXXXXX0000000000", b1.BlockValue);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock2 b2 = (SwiftBlock2) parser.consumeBlock(null);
			SwiftBlock2 b2 = (SwiftBlock2) parser.consumeBlock(null);
			assertNotNull(b2);
			assertEquals(2, (int)b2.Number);
			assertEquals("I541CITIGB2LXXXXN", b2.BlockValue);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = (SwiftBlock4) parser.consumeBlock(null);
			SwiftBlock4 b4 = (SwiftBlock4) parser.consumeBlock(null);
			assertNotNull(b4);
			assertEquals(4, (int)b4.Number);
			//assertEquals("", b4.getBlockValue());

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock nil = parser.consumeBlock(null);
			SwiftBlock nil = parser.consumeBlock(null);
			assertNull(nil);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleBlockConsumerBlock3_1() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSimpleBlockConsumerBlock3_1()
		{
			parser.Data = "{3:{108:00112233}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock3 b3 = (SwiftBlock3) parser.consumeBlock(null);
			SwiftBlock3 b3 = (SwiftBlock3) parser.consumeBlock(null);
			assertNotNull(b3);
			assertTrue(b3 is SwiftBlock);
			assertTrue(b3.containsTag("108"));
			assertEquals("00112233", b3.getTagValue("108"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleBlockConsumerBlock3_2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSimpleBlockConsumerBlock3_2()
		{
			parser.Data = "{3:{108:00112233}{4:foobar}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock3 b3 = (SwiftBlock3) parser.consumeBlock(null);
			SwiftBlock3 b3 = (SwiftBlock3) parser.consumeBlock(null);
			assertNotNull(b3);
			assertTrue(b3 is SwiftBlock);
			assertTrue(b3.containsTag("108"));
			assertEquals("00112233", b3.getTagValue("108"));
			assertTrue(b3.containsTag("4"));
			assertEquals("foobar", b3.getTagValue("4"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleBlockConsumerBlock5_1() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSimpleBlockConsumerBlock5_1()
		{
			parser.Data = "{5:{108:00112233}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock5 b = (SwiftBlock5) parser.consumeBlock(null);
			SwiftBlock5 b = (SwiftBlock5) parser.consumeBlock(null);
			assertNotNull(b);
			assertTrue(b is SwiftBlock);
			assertTrue(b.containsTag("108"));
			assertEquals("00112233", b.getTagValue("108"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleBlockConsumerBlock5_2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSimpleBlockConsumerBlock5_2()
		{
			parser.Data = "{5:{108:00112233}{4:foobar}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock5 b = (SwiftBlock5) parser.consumeBlock(null);
			SwiftBlock5 b = (SwiftBlock5) parser.consumeBlock(null);
			assertNotNull(b);
			assertTrue(b is SwiftBlock);
			assertTrue(b.containsTag("108"));
			assertEquals("00112233", b.getTagValue("108"));
			assertTrue(b.containsTag("4"));
			assertEquals("foobar", b.getTagValue("4"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1539324() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBug1539324()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = "{1:"+com.prowidesoftware.swift.Constants_Fields.B1_DATA+"}{3:{n:v}}";
			string fin = "{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{3:{n:v}}";
			parser.Data = fin;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock1 b1 = (SwiftBlock1) parser.consumeBlock(null);
			SwiftBlock1 b1 = (SwiftBlock1) parser.consumeBlock(null);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock3 b3 = (SwiftBlock3) parser.consumeBlock(null);
			SwiftBlock3 b3 = (SwiftBlock3) parser.consumeBlock(null);
			assertTrue(b1 is SwiftBlock1);
			assertTrue(b3 is SwiftBlock3);
			assertEquals(com.prowidesoftware.swift.Constants_Fields.B1_DATA, ((SwiftBlock1)b1).Value);
			assertEquals(1, ((SwiftBlock3)b3).countAll());
			assertEquals("n", ((SwiftBlock3)b3).getTag(0).Name);
			assertEquals("v", ((SwiftBlock3)b3).getTag(0).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1539324_2() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBug1539324_2()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = "{1:"+com.prowidesoftware.swift.Constants_Fields.B1_DATA+"}{3:{n:v}}";
			string fin = "{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{3:{n:v}}";
			parser.Data = fin;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = parser.message();
			SwiftMessage msg = parser.message();
			assertEquals(com.prowidesoftware.swift.Constants_Fields.B1_DATA, msg.Block1.BlockValue);
			assertNull(msg.Block2);
			assertEquals("n", msg.Block3.getTag(0).Name);
			assertEquals("v", msg.Block3.getTag(0).Value);
			assertNull(msg.Block4);
			assertNull(msg.Block5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1539324_3() throws org.xml.sax.SAXException, java.io.IOException, javax.xml.parsers.ParserConfigurationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBug1539324_3()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = "{1:"+com.prowidesoftware.swift.Constants_Fields.B1_DATA+"}{3:{n:v}}";
			string fin = "{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{3:{n:v}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParser p = new SwiftParser(new java.io.StringReader(fin));
			SwiftParser p = new SwiftParser(new StringReader(fin));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = p.message();
			SwiftMessage msg = p.message();
			assertEquals(1, (int)msg.Block1.Number);
			assertEquals(com.prowidesoftware.swift.Constants_Fields.B1_DATA, msg.Block1.BlockValue);
			assertNull(msg.Block2);
			assertEquals(3, (int)msg.Block3.Number);
			assertEquals("n", msg.Block3.getTag(0).Name);
			assertEquals("v", msg.Block3.getTag(0).Value);
			assertNull(msg.Block4);
			assertNull(msg.Block5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOneTagSimilarToBug1540294_1() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testOneTagSimilarToBug1540294_1()
		{
			const string fin = "{4:\r\n" + ":t2:v2\r\n" + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParser p = new SwiftParser(new java.io.StringReader(fin));
			SwiftParser p = new SwiftParser(new StringReader(fin));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = p.message();
			SwiftMessage msg = p.message();
			assertNotNull(msg.Block4);
			assertEquals(1, msg.Block4.size());
			assertEquals("v2", msg.Block4.getTagValue("t2"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1601122_1() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBug1601122_1()
		{
			const string fin = "{5:{MAC:32D7EA50}{CHK:AB1538FB729E}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParser p = new SwiftParser(new java.io.StringReader(fin));
			SwiftParser p = new SwiftParser(new StringReader(fin));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = p.message();
			SwiftMessage msg = p.message();
			assertNotNull(msg.Block5);
			assertEquals(2, msg.Block5.size());
			assertEquals("32D7EA50", msg.Block5.getTagValue("MAC"));
			assertEquals("AB1538FB729E", msg.Block5.getTagValue("CHK"));
		}

		/*
		 * checks that text mixed with tags is handled as unparsed text
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleBlockConsumerBlock3_3_KnownToFail() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSimpleBlockConsumerBlock3_3_KnownToFail()
		{
			parser.Data = "{3:blockdata{108:00112233}{4:foobar}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock3 b = (SwiftBlock3) parser.consumeBlock(null);
			SwiftBlock3 b = (SwiftBlock3) parser.consumeBlock(null);
			assertNotNull(b);
			assertTrue(b is SwiftBlock);
			assertTrue(b.containsTag("108"));
			assertEquals("00112233", b.getTagValue("108"));
			assertTrue(b.containsTag("4"));
			assertEquals("foobar", b.getTagValue("4"));
			assertEquals(b.UnparsedTextsSize, new int?(1));
			assertEquals(b.unparsedTextGetText(0), "blockdata");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTag77Exceptions_1() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testTag77Exceptions_1()
		{
			const string m = "{1:F01FOOBARYYAXXX1234123456}{2:O1030811060227FOOBBSMMAXXX55529746000602270811N}{3:{113:NOMF}{108:0602021485081594}{119:STP}}{4:^M\r\n" + ":77E:  \r\n" + "ABCDEFG\r\n" + "-}{5:{MAC:80C69B21}{CHK:63035B4672E0}}\r\n" + "\r\n" + "";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = new SwiftParser(m).message();
			SwiftMessage msg = (new SwiftParser(m)).message();
			assertNotNull(msg);
			assertEquals(msg.Block4.getTagByName("77E").Value, "  \r\n" + "ABCDEFG");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTag77Exceptions_2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testTag77Exceptions_2()
		{
			const string m = "{1:F01FOOBARYYAXXX1234123456}{2:O1030811060227FOOBBSMMAXXX55529746000602270811N}{3:{113:NOMF}{108:0602021485081594}{119:STP}}{4:\r\n" + ":77E:\r\n" + "ABCDEFG\r\n" + "-}{5:{MAC:80C69B21}{CHK:63035B4672E0}}\r\n" + "\r\n" + "";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = new SwiftParser(m).message();
			SwiftMessage msg = (new SwiftParser(m)).message();
			assertNotNull(msg);
			assertEquals(msg.Block4.getTagByName("77E").Value, "\r\n" + "ABCDEFG");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTag77Exceptions_3() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testTag77Exceptions_3()
		{
			const string m = "{1:F01FOOBARYYAXXX1234123456}{2:O1030811060227FOOBBSMMAXXX55529746000602270811N}{3:{113:NOMF}{108:0602021485081594}{119:STP}}{4:\r\n" + ":77E::\r\n" + ":\r\n" + "QWERTYU\r\n" + "-}{5:{MAC:80C69B21}{CHK:63035B4672E0}}\r\n" + "\r\n" + "";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = new SwiftParser(m).message();
			SwiftMessage msg = (new SwiftParser(m)).message();
			assertNotNull(msg);
			assertEquals(msg.Block4.getTagByName("77E").Value, ":\r\n" + ":\r\n" + "QWERTYU");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTag77Exceptions_4() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testTag77Exceptions_4()
		{
			const string m = "{1:F01FOOBARYYAXXX1234123456}{2:O1030811060227FOOBBSMMAXXX55529746000602270811N}{3:{113:NOMF}{108:0602021485081594}{119:STP}}{4:\r\n" + ":77E:-\r\n" + ":\r\n" + "ZXCVBNM\r\n" + "-}{5:{MAC:80C69B21}{CHK:63035B4672E0}}\r\n" + "\r\n" + "";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = new SwiftParser(m).message();
			SwiftMessage msg = (new SwiftParser(m)).message();
			assertNotNull(msg);
			assertEquals(msg.Block4.getTagByName("77E").Value, "-\r\n" + ":\r\n" + "ZXCVBNM");
		}

		/// <summary>
		/// http://sourceforge.net/projects/wife/forums/forum/544818/topic/3399143
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_MT535_35B_with_colon() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test_MT535_35B_with_colon()
		{
			const string m = "{1:F01BFOOUS3IADNC0147771111}{2:O5350837080313FOOSGB2LIXXX06988488300803130437N}{3:{108:000952CQ1650453}}{4:\r\n" + ":16R:GENL\r\n" + ":28E:6/MORE\r\n" + ":20C::SEME//H200803121132222\r\n" + ":23G:NEWM\r\n" + ":98A::STAT//20080312\r\n" + ":22F::SFRE//DAIL\r\n" + ":22F::CODE//COMP\r\n" + ":22F::STTY//CUST\r\n" + ":22F::STBA//TRAD\r\n" + ":97A::SAFE//S 02500\r\n" + ":17B::ACTI//Y\r\n" + ":17B::AUDT//N\r\n" + ":17B::CONS//N\r\n" + ":16S:GENL\r\n" + ":16R:SUBSAFE\r\n" + ":16R:FIN\r\n" + ":35B:/US/AGGR_AVAI\r\n" + "AGGR=300, AVAI:=200\r\n" + ":16R:FIA\r\n" + ":12A::CLAS/ISIT/STF\r\n" + ":16S:FIA\r\n" + ":93B::AGGR//FAMT/300,\r\n" + ":93B::AVAI//FAMT/200,\r\n" + ":16R:SUBBAL\r\n" + ":93B::AGGR//FAMT/50,\r\n" + ":94F::SAFE//CUST/FOOSUS33\r\n" + ":70C::SUBB//REGISTRATION CODE MEMR\n" + ":16S:SUBBAL\r\n" + ":16S:FIN\r\n" + ":16R:FIN\r\n" + "-}";
					//				:35B:ISIN XS0222550880 4,125? LANXESS FIN.B.V.NT.V.05 21.6 :12
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = new SwiftParser(m).message();
			SwiftMessage msg = (new SwiftParser(m)).message();
			assertNotNull(msg);
			assertEquals(msg.Block4.getTagByName("35B").Value, "/US/AGGR_AVAI\r\nAGGR=300, AVAI:=200");
		}

		/// <summary>
		/// http://sourceforge.net/projects/wife/forums/forum/544818/topic/3399143
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_MT535_35B_with_colon_2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test_MT535_35B_with_colon_2()
		{
			const string m = "{1:F01BFOOUS3IADNC0147771111}{2:O5350837080313FOOSGB2LIXXX06988488300803130437N}{3:{108:000952CQ1650453}}{4:\r\n" + ":16R:GENL\r\n" + ":28E:6/MORE\r\n" + ":20C::SEME//H200803121132222\r\n" + ":23G:NEWM\r\n" + ":98A::STAT//20080312\r\n" + ":22F::SFRE//DAIL\r\n" + ":22F::CODE//COMP\r\n" + ":22F::STTY//CUST\r\n" + ":22F::STBA//TRAD\r\n" + ":97A::SAFE//S 02500\r\n" + ":17B::ACTI//Y\r\n" + ":17B::AUDT//N\r\n" + ":17B::CONS//N\r\n" + ":16S:GENL\r\n" + ":16R:SUBSAFE\r\n" + ":16R:FIN\r\n" + ":35B:ISIN XS0222550880\r\n" + "4,125? LANXESS FIN.B.V.NT.V.05 21.6\r\n" + ":16R:FIA\r\n" + ":12A::CLAS/ISIT/STF\r\n" + ":16S:FIA\r\n" + ":93B::AGGR//FAMT/300,\r\n" + ":93B::AVAI//FAMT/200,\r\n" + ":16R:SUBBAL\r\n" + ":93B::AGGR//FAMT/50,\r\n" + ":94F::SAFE//CUST/FOOSUS33\r\n" + ":70C::SUBB//REGISTRATION CODE MEMR\n" + ":16S:SUBBAL\r\n" + ":16S:FIN\r\n" + ":16R:FIN\r\n" + "-}";
					//":12\r\n" +
					/*
					 * within the field content, a colon ':' must never be used as the first character
					 * of a line (the combination 'CrLf:' always indicates a new field tag)
					 */
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = new SwiftParser(m).message();
			SwiftMessage msg = (new SwiftParser(m)).message();
			assertNotNull(msg);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPatchWalterBirch() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPatchWalterBirch()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = "{1:F01VONTCHZZAXXX7586415286}{2:I202CHASUS33XXXXN}{3:{108:129324618/1XXXXX}}{4:" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + ":20:129324618/1XXXXX" +com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + ":21:NONREF" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + ":32A:110705USD20079,39" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + ":57A:CITIUS33XXX" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + ":58A:NBSZCHZZXXX" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + ":72:/BNF/30.05.11 10000" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + "" + com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL + "-}{5:{CHK:88C7BBB37D50}}";
			string fin = "{1:F01VONTCHZZAXXX7586415286}{2:I202CHASUS33XXXXN}{3:{108:129324618/1XXXXX}}{4:" + FINWriterVisitor.SWIFT_EOL + ":20:129324618/1XXXXX" + FINWriterVisitor.SWIFT_EOL + ":21:NONREF" + FINWriterVisitor.SWIFT_EOL + ":32A:110705USD20079,39" + FINWriterVisitor.SWIFT_EOL + ":57A:CITIUS33XXX" + FINWriterVisitor.SWIFT_EOL + ":58A:NBSZCHZZXXX" + FINWriterVisitor.SWIFT_EOL + ":72:/BNF/30.05.11 10000" + FINWriterVisitor.SWIFT_EOL + "" + FINWriterVisitor.SWIFT_EOL + "-}{5:{CHK:88C7BBB37D50}}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParser p = new SwiftParser(new java.io.StringReader(fin));
			SwiftParser p = new SwiftParser(new StringReader(fin));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = p.message();
			SwiftMessage msg = p.message();
			assertNotNull(msg.Block1);
			assertNotNull(msg.Block4);
			assertEquals("Expected 6 tags but found " + msg.Block4.size() + ", " + msg.Block4.tagNamesList(), 6, msg.Block4.size());
			//		assertEquals("v1", msg.getBlock4().getTagValue("t1"));
			//		assertEquals("v2", msg.getBlock4().getTagValue("t2"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTagEndSearch()
		public virtual void testTagEndSearch()
		{
			const string s = "4:\n" + ":20:628735BKRU3X\n" + ":79:TO FOO\n" + "ATTN. FOO OPERATIONS\n" + "FROM.\n" + "RE.   JOE DOE A/C 1111\n" + "A/C: 961XXX\n" + ".\n" + "WE CONFIRM TO INCREASE THE FOLLOWING DEPOSIT FROM\n" + "RATE       10.0000\n" + ".\n" + "INSTRUCTIONS:\n" + "STATE STREET BANK AND TRUST CO, NA NEW YORK\n" + "SWIFT CODE: FOOSUS3N\n" + "VALUE 22 MAY 2012\n" + ".\n" + "REGARDS,\n" + "}\n" + "-";
			const int start = 21;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int end = this.parser.textTagEndBlock4(s, start, true);
			int end = this.parser.textTagEndBlock4(s, start, true);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String tag = s.substring(start, end - start);
			string tag = s.Substring(start, end - start);
			assertEquals('-', tag[tag.Length - 1]);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTagEndSearch1()
		public virtual void testTagEndSearch1()
		{
			const string s = ":79:foo\n" + "}\n" + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int end = this.parser.textTagEndBlock4(s, 0, true);
			int end = this.parser.textTagEndBlock4(s, 0, true);
			assertTrue(end + " mayor que largo total (" + s.Length + ")", end < s.Length);
			assertEquals('-', s[end]);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTicket28() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testTicket28()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:\r\n" + ":16R:GENL\r\n" + ":23G:NEWM\r\n" + ":98A::PREP//20050711\r\n" + ":16S:GENL\r\n" + ":16S:AMT\r\n" + ":16S:SETDET" + "-}");
			SwiftBlock4 b4 = SwiftParser.parseBlock4("{4:\r\n" + ":16R:GENL\r\n" + ":23G:NEWM\r\n" + ":98A::PREP//20050711\r\n" + ":16S:GENL\r\n" + ":16S:AMT\r\n" + ":16S:SETDET" + "-}");
			assertNotNull(b4);
			assertEquals(6, b4.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParserConfigurationCompare() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParserConfigurationCompare()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParserConfiguration faster = new SwiftParserConfiguration();
			SwiftParserConfiguration faster = new SwiftParserConfiguration();
			faster.ParseTextBlock = false;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long t1a = parse(new SwiftParserConfiguration(), 1000);
			long t1a = parse(new SwiftParserConfiguration(), 1000);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long t2a = parse(faster, 1000);
			long t2a = parse(faster, 1000);
			assertTrue(t1a > t2a);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private long parse(final SwiftParserConfiguration config, final int repetitions) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		private long parse(SwiftParserConfiguration config, int repetitions)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParser parser = new SwiftParser();
			SwiftParser parser = new SwiftParser();
			parser.Configuration = config;
			long cum = 0;
			SwiftMessage msg = null;
			for (int i = 0; i < repetitions; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long t0a = java.util.Calendar.getInstance().getTimeInMillis();
				long t0a = new DateTime().TimeInMillis;
				msg = parser.parse(sample_535);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long t1a = java.util.Calendar.getInstance().getTimeInMillis();
				long t1a = new DateTime().TimeInMillis;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long t = (t1a - t0a);
				long t = (t1a - t0a);
				cum = cum + t;
				assertNotNull(msg);
				if (config.ParseTextBlock)
				{
					assertFalse(msg.Block4.Empty);
				}
				else
				{
					assertTrue(msg.Block4.Empty);
				}
				if (config.ParseTrailerBlock)
				{
					assertFalse(msg.Block5.Empty);
				}
				else
				{
					assertTrue(msg.Block5.Empty);
				}
			}
			return cum;
		}

		internal string sample_535 = "{1:F01FOOBARXXAXXX0387240778}{2:O5350029060914FOOBARXXXXXX03549878070609140029N}{4:\n" + ":16R:GENL\n" + ":28E:00005/MORE\n" + ":20C::SEME//ICF2750609140005\n" + ":23G:NEWM\n" + ":98A::STAT//20060913\n" + ":22F::SFRE//DAIL\n" + ":22F::CODE//COMP\n" + ":22F::STTY//CUST\n" + ":22F::STBA//TRAD\n" + ":97A::SAFE//F275\n" + ":17B::ACTI//Y\n" + ":17B::AUDT//N\n" + ":17B::CONS//N\n" + ":16S:GENL\n" + ":16R:SUBSAFE\n" + ":16R:FIN\n" + ":35B:/US/31392EXH8\n" + "FEDERAL FOO MTG ASSN\n" + ":16R:FIA\n" + ":92A::CUFC//0,14528727\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/35732656,\n" + ":93B::AVAI//FAMT/35732656,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/35732656,\n" + ":93B::AVAI//FAMT/35732656,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31392E7B0\n" + "FEDERAL FOO MTG ASSN\n" + ":16R:FIA\n" + ":92A::CUFC//0,16255627\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/48864356,\n" + ":93B::AVAI//FAMT/48864356,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/48864356,\n" + ":93B::AVAI//FAMT/48864356,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31392FDB0\n" + "FEDERAL FOO MTG ASSN GTD\n" + ":16R:FIA\n" + ":92A::CUFC//0,30628171\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/15000000,\n" + ":93B::AVAI//FAMT/15000000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/15000000,\n" + ":93B::AVAI//FAMT/15000000,\n" + ":94F::SAFE//NCSD/DTCYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31392F6D4\n" + "FEDERAL FOO MTG ASSN\n" + ":16R:FIA\n" + ":92A::CUFC//0,35018015\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/22700000,\n" + ":93B::AVAI//FAMT/22700000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/22700000,\n" + ":93B::AVAI//FAMT/22700000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31392F6K8\n" + "FEDERAL FOO MTG ASSN\n" + ":16R:FIA\n" + ":92A::CUFC//0,1838114\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/43333333,\n" + ":93B::AVAI//FAMT/43333333,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/43333333,\n" + ":93B::AVAI//FAMT/43333333,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31392GVX0\n" + "FEDERAL FOO MTG ASSN\n" + ":16R:FIA\n" + ":92A::CUFC//0,27894901\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/7865000,\n" + ":93B::AVAI//FAMT/7865000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/7865000,\n" + ":93B::AVAI//FAMT/7865000,\n" + ":94F::SAFE//NCSD/DTCYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31392TSB4\n" + "FEDERAL HOME LN FOO CORP\n" + ":16R:FIA\n" + ":92A::CUFC//0,13866795\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/20000000,\n" + ":93B::AVAI//FAMT/20000000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/20000000,\n" + ":93B::AVAI//FAMT/20000000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/313921CX4\n" + "FEDERAL FOO MTG ASSN\n" + ":16R:FIA\n" + ":92A::CUFC//0,01834306\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/6409602,\n" + ":93B::AVAI//FAMT/6409602,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/6409602,\n" + ":93B::AVAI//FAMT/6409602,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31393AG84\n" + "FEDERAL FOO MTG ASSN MTN\n" + ":16R:FIA\n" + ":92A::CUFC//0,42466806\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/8000000,\n" + ":93B::AVAI//FAMT/8000000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/8000000,\n" + ":93B::AVAI//FAMT/8000000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31393BU94\n" + "FEDERAL FOO MTG ASSN\n" + ":16R:FIA\n" + ":92A::CUFC//0,28337156\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/23232171,\n" + ":93B::AVAI//FAMT/23232171,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/23232171,\n" + ":93B::AVAI//FAMT/23232171,\n" + ":94F::SAFE//NCSD/DTCYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31393BX75\n" + "FEDERAL FOO MTG ASSN GTD\n" + ":16R:FIA\n" + ":92A::CUFC//0,31807496\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/51600000,\n" + ":93B::AVAI//FAMT/51600000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/51600000,\n" + ":93B::AVAI//FAMT/51600000,\n" + ":94F::SAFE//NCSD/DTCYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31393UMQ3\n" + "FEDERAL FOO MTG ASSN REMIC\n" + ":16R:FIA\n" + ":92A::CUFC//0,53188477\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/1250000,\n" + ":93B::AVAI//FAMT/1250000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/1250000,\n" + ":93B::AVAI//FAMT/1250000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31393XFT9\n" + "FNMA FOO TRUST\n" + ":16R:FIA\n" + ":92A::CUFC//0,43229892\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/4375650,\n" + ":93B::AVAI//FAMT/4375650,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/4375650,\n" + ":93B::AVAI//FAMT/4375650,\n" + ":94F::SAFE//NCSD/DTCYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31394LBV3\n" + "FEDERAL HOME LN FOO CORP\n" + ":16R:FIA\n" + ":92A::CUFC//0,40350442\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/6000000,\n" + ":93B::AVAI//FAMT/6000000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/6000000,\n" + ":93B::AVAI//FAMT/6000000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31394R2J7\n" + "FEDERAL HOME LN FOO CORP\n" + ":16R:FIA\n" + ":92A::CUFC//0,18203448\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/8000000,\n" + ":93B::AVAI//FAMT/8000000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/8000000,\n" + ":93B::AVAI//FAMT/8000000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31394XVD5\n" + "FEDERAL HOME LN FOO CORP\n" + ":16R:FIA\n" + ":92A::CUFC//0,48144936\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/3000000,\n" + ":93B::AVAI//FAMT/3000000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/3000000,\n" + ":93B::AVAI//FAMT/3000000,\n" + ":94F::SAFE//NCSD/DTCYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31400PGE9\n" + "FNMA FOO 693297\n" + ":16R:FIA\n" + ":92A::CUFC//0,19077368\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/1235403,\n" + ":93B::AVAI//FAMT/1235403,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/1235403,\n" + ":93B::AVAI//FAMT/1235403,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31402QHS3\n" + "FNMA FOO 734741\n" + ":16R:FIA\n" + ":92A::CUFC//0,72142663\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/12735000,\n" + ":93B::AVAI//FAMT/12735000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/12735000,\n" + ":93B::AVAI//FAMT/12735000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31403NJ81\n" + "FNMA FOO 753687\n" + ":16R:FIA\n" + ":92A::CUFC//0,31380405\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/25005520,\n" + ":93B::AVAI//FAMT/25005520,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/25005520,\n" + ":93B::AVAI//FAMT/25005520,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31405N4A0\n" + "FNMA FOO 794717\n" + ":16R:FIA\n" + ":92A::CUFC//0,48266546\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/2885565,\n" + ":93B::AVAI//FAMT/2885565,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/2885565,\n" + ":93B::AVAI//FAMT/2885565,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31405PRS1\n" + "FNMA FOO 795297\n" + ":16R:FIA\n" + ":92A::CUFC//0,51848398\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/25000000,\n" + ":93B::AVAI//FAMT/25000000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/25000000,\n" + ":93B::AVAI//FAMT/25000000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31406RR72\n" + "FNMA FOO 817810\n" + ":16R:FIA\n" + ":92A::CUFC//0,000000\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/0,\n" + ":93B::AVAI//FAMT/N990692,\n" + ":93B::NAVL//FAMT/990692,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/0,\n" + ":93B::AVAI//FAMT/N990692,\n" + ":93B::NAVL//FAMT/990692,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31407RSB1\n" + "FNMA FOO 838514\n" + ":16R:FIA\n" + ":92A::CUFC//0,96155571\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/3650000,\n" + ":93B::NAVL//FAMT/3650000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/3650000,\n" + ":93B::NAVL//FAMT/3650000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31409KHC4\n" + "FNMA FOO 873327\n" + ":16R:FIA\n" + ":92A::CUFC//0,99073685\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/2586984,\n" + ":93B::AVAI//FAMT/2586984,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/2586984,\n" + ":93B::AVAI//FAMT/2586984,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31409KHD2\n" + "FNMA FOO 873328\n" + ":16R:FIA\n" + ":92A::CUFC//0,99026461\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/3900000,\n" + ":93B::AVAI//FAMT/3900000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/3900000,\n" + ":93B::AVAI//FAMT/3900000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31409KKH9\n" + "FNMA FOO 873396\n" + ":16R:FIA\n" + ":92A::CUFC//1,\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/7500000,\n" + ":93B::AVAI//FAMT/7500000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/7500000,\n" + ":93B::AVAI//FAMT/7500000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31409KLJ4\n" + "FNMA FOO 873429\n" + ":16R:FIA\n" + ":92A::CUFC//0,9867294\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/3989570,\n" + ":93B::AVAI//FAMT/3989570,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/3989570,\n" + ":93B::AVAI//FAMT/3989570,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31409KMR5\n" + "FNMA FOO 873468\n" + ":16R:FIA\n" + ":92A::CUFC//0,99476164\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/1056000,\n" + ":93B::AVAI//FAMT/1056000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/1056000,\n" + ":93B::AVAI//FAMT/1056000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31409KNL7\n" + "FNMA FOO 873495\n" + ":16R:FIA\n" + ":92A::CUFC//0,9892473\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/12500000,\n" + ":93B::AVAI//FAMT/12500000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/12500000,\n" + ":93B::AVAI//FAMT/12500000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16R:FIN\n" + ":35B:/US/31409KQP5\n" + "FNMA FOO 873562\n" + ":16R:FIA\n" + ":92A::CUFC//1,\n" + ":16S:FIA\n" + ":93B::AGGR//FAMT/7680000,\n" + ":93B::AVAI//FAMT/7680000,\n" + ":16R:SUBBAL\n" + ":93B::AGGR//FAMT/7680000,\n" + ":93B::AVAI//FAMT/7680000,\n" + ":94F::SAFE//NCSD/FRNYUS33\n" + ":16S:SUBBAL\n" + ":16S:FIN\n" + ":16S:SUBSAFE\n" + "-}{5:{MAC:E19445CF}{CHK:D625798DFC51}}";
						// sequence A - General Information
						// sequence B - Sub-safekeeping account
						//":16R:SUBBAL\n" +
						//":93C::PEND//FAMT/NAVL/990692,\n" +
						//":94F::SAFE//NCSD/FRNYUS33\n" +
						//":16S:SUBBAL\n" +
						//":16R:SUBBAL\n" +
						//":93C::PENR//FAMT/NAVL/990692,\n" +
						//":94F::SAFE//NCSD/FRNYUS33\n" +
						//":16S:SUBBAL\n" +
						//":16R:SUBBAL\n" +
						//":93C::PENR//FAMT/NAVL/3650000,\n" +
						//":94F::SAFE//NCSD/FRNYUS33\n" +
						//":16S:SUBBAL\n" +

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFieldStartingWithColon() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFieldStartingWithColon()
		{
			const string val = "/PY/OSA PAYMENT/BN/FOO LIMITED/BN1/6/F,HONGCHANG PLAZA,N\n" + ":6542670O2001,/BN2/SHENNAN ROAD EAST,LUOHU DIST,/BN3/SHENZHEN,CHINA/BI/12\n" + "44712009/BO/INFINITY HOME LIMITED ROOM 2105 FZ2250 TREND CTR 29-3\n" + "1 CH/BO3/EUNG LEE STREET CHAI WAN HK/CM/USD1,00/CA/1244712009/OB/\n" + "CHINA FOO BANK/PT/FT/PO/0005/OCMT/USD2620,80/XT/CD/REF/1029\n" + "200004099";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = "{1:"+com.prowidesoftware.swift.Constants_Fields.B1_DATA+"}{4:\n" + ":86:"+val+"\n" + "-}";
			string fin = "{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{4:\n" + ":86:" + val + "\n" + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParser p = new SwiftParser(new java.io.StringReader(fin));
			SwiftParser p = new SwiftParser(new StringReader(fin));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = p.message();
			SwiftMessage msg = p.message();
			assertEquals(1, msg.Block4.countAll());
			assertNotNull(msg.Block4.getTagByName("86"));
			assertEquals(val, msg.Block4.getTagByName("86").Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFieldStartingWithColonTrimmed() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFieldStartingWithColonTrimmed()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = "{1:"+com.prowidesoftware.swift.Constants_Fields.B1_DATA+"}{4:\n" + ":86:/FOO\n" + ":123BAR\n" + "-}";
			string fin = "{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{4:\n" + ":86:/FOO\n" + ":123BAR\n" + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParser p = new SwiftParser(new java.io.StringReader(fin));
			SwiftParser p = new SwiftParser(new StringReader(fin));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = p.message();
			SwiftMessage msg = p.message();
			assertEquals(1, msg.Block4.countAll());
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFieldStartingWithColonTrimmedColonAndText() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFieldStartingWithColonTrimmedColonAndText()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = "{1:"+com.prowidesoftware.swift.Constants_Fields.B1_DATA+"}{4:\n" + ":86:/FOO\n" + ":BAR\n" + "-}";
			string fin = "{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{4:\n" + ":86:/FOO\n" + ":BAR\n" + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftParser p = new SwiftParser(new java.io.StringReader(fin));
			SwiftParser p = new SwiftParser(new StringReader(fin));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage msg = p.message();
			SwiftMessage msg = p.message();
			assertEquals(1, msg.Block4.countAll());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeTagColons1() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeTagColons1()
		{
			Tag o = this.parser.consumeTag(":86:/FOO\n" + ":BAR\n");
			assertTrue(o.Value.Contains("BAR"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTagStartsTrue() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testTagStartsTrue()
		{
			assertTrue(tagStarts("20:"));
			assertTrue(tagStarts("20:foo"));
			assertTrue(tagStarts("20::foo"));
			assertTrue(tagStarts("20C:"));
			assertTrue(tagStarts("20C:foo"));
			assertTrue(tagStarts("20C::foo"));
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static final boolean tagStarts(final String str)
		private static bool tagStarts(string str)
		{
			SwiftParser p = new SwiftParser();
			return p.tagStarts(str, 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTagStartsFalse() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testTagStartsFalse()
		{
			assertFalse(tagStarts("20foo"));
			assertFalse(tagStarts("2:foo"));
			assertFalse(tagStarts("20CC:"));
			assertFalse(tagStarts("20c:"));
			assertFalse(tagStarts(":20foo"));
			assertFalse(tagStarts("20foo"));
			assertFalse(tagStarts(":/ account stuff:"));
			assertFalse(tagStarts(":905:"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAck1() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testAck1()
		{
			const string msg = "{1:F21OMFNCIABAXXX6368087500}{4:{177:1511041614}{451:0}}{1:F01OMFNCIABAXXX6368087500}{2:O1031542151104BCAOSNDPAXXX22438129121511041542N}{3:{113:0030}{108:001RTGS153030005}}{4:\n" + ":20:1234567890\n" + ":23B:CRED\n" + ":23E:SDVA\n" + ":26T:001\n" + ":32A:151104XOF27000000,\n" + ":50K:/0020121503484101\n" + "SOXNYFAYTONU VORYEAUGEIS\n" + ":53A:/D/D00030901\n" + "ECOCMLBA\n" + ":57A:/C/A00031061\n" + "OMFNCIAB\n" + ":59:/010010100100014010010160\n" + "FOO VOYAGES\n" + ":70:TRANSFERT\n" + ":71A:SHA\n" + ":72:/CODTYPTR/001\n" + "//REGLEMENT\n" + "-}{5:{MAC:00000000}{CHK:0AF226411593}}{S:{SPD:}{SAC:}{COP:P}}";
			SwiftMessage sm = (new SwiftParser(msg)).message();
			assertNotNull(sm);
			assertTrue(sm.Ack);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAck2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testAck2()
		{
			const string msg = "{1:F21OMFNCIABAXXX6368087504}{4:{177:1511041718}{451:0}}{1:F01OMFNCIABAXXX6368087504}{2:O1031746151104CCEICMCXAXXX64953042471511041646N}{4:\n" + ":20:1234567890\n" + ":23B:CRED\n" + ":32A:151104XOF14773500,\n" + ":50K:/00057 03363591001 84\n" + "FOO SARL \n" + "AKWA, FACE ANCIEN DIRECTION NOBRA\n" + "BP 1432 DOURAZLA\n" + "237 CAMEROUN\n" + ":57A:CBAOSNDA\n" + ":59:/SN 012 01201 036169011401 63\n" + "TSAEMOXU FOO INTERUNATIONALE SARL\n" + "DIAMNIADO, DAKAR\n" + "SENEGAL\n" + ":70:/INV/TFI-ZS-15002\n" + ":71A:SHA\n" + "-}{5:{MAC:00000000}{CHK:50085EDF60EC}}{S:{SPD:}{SAC:}{COP:P}}";
			SwiftMessage sm = (new SwiftParser(msg)).message();
			assertNotNull(sm);
			assertTrue(sm.Ack);
		}

		/// <summary>
		/// Extra data simple
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testExtraDataSimple() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testExtraDataSimple()
		{
			const string fin = "{1:F01MOSWRUMMAXXX0000000000}{2:I103COBADEFFXXXXN}{3:{108:02161OKP00130914}}{4:\n" + ":20:12345677890\n" + ":23B:CRED\n" + ":32A:160217EUR500,\n" + ":50K:/42301978502050100067\n" + "SHEPTUKHA VIKTORIA PAS45 15 362057\n" + "CCC MOSCOW MOSCOW UL. AVIACIONNAYA\n" + "DON. 99 KV. 123\n" + ":52D:BANK OF MOSCOW\n" + ":57A:CAIXESBBXXX\n" + ":59:/ES3021000122390200002631\n" + "FOO TRADE SL SPAIN CASTELLO D E\n" + "FOO PLACA JOC DE LA PILOTA , NU\n" + "M 1\n" + ":70:PAYMENT FOR NALOG ZA APARTAMENT\n" + ":71A:OUR\n" + ":72:/ACC/UR LIZO BBBB ))))))))::::::\n" + "-}foo";
			SwiftParser p = new SwiftParser(fin);
			SwiftMessage m = p.message();
			assertFalse(m.UnparsedTextsSize == 0);
		}

		/// <summary>
		/// Expected extra "}}}}" reported as error
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testExtraData() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testExtraData()
		{
			const string fin = "{1:F01MOSWRUMMAXXX0000000000}{2:I103COBADEFFXXXXN}{3:{108:02161OKP00130914}}{4:\n" + ":20:1234567890\n" + ":23B:CRED\n" + ":32A:160217EUR500,\n" + ":50K:/42301978502050100067\n" + "FOO VIKTORIA PAS45 15 362057\n" + "CCC MOSCOW MOSCOW UL. FOO\n" + "DON. 13 KV. 131\n" + ":52D:BANK OF MOSCOW\n" + ":57A:CAIXESBBXXX\n" + ":59:/ES3021000122390200002631\n" + "FOO TRADE SL SPAIN CASTELLO D E\n" + "FOO PLACA JOC DE LA PILOTA , NU\n" + "M 1\n" + ":70:PAYMENT FOR NALOG ZA APARTAMENT\n" + ":71A:OUR\n" + ":72:/ACC/UR LIZO BBBB ))))))))::::::\n" + "-}}}}}";
			SwiftParser p = new SwiftParser(fin);
			SwiftMessage m = p.message();
			assertFalse(m.UnparsedTextsSize == 0);
		}

		/*
		 * https://sourceforge.net/p/wife/bugs/80/
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse()
		{
			const string fin = "{1:F01TESTAR00AXXX7607663781}{2:O1010824170510TESTAR00AXXX94149133901705101425N}{4:\n" + ":20:DG942_171206-004\n" + ":28D:00001/00001\n" + ":50H:/344110001637\n" + "TESTAR00AXXX\n" + "Utrecht\n" + "Netherlands\n" + ":30:170502\n" + ":21:010735904\n" + ":32B:CNY14,00\n" + ":57A:CIBKCNBJ473\n" + ":59:/344110000361\n" + "CASH CUSTOMER I\n" + "TESTAR00AXXX\n" + "Utrecht\n" + "Netherlands\n" + ":70:/RFB/C767405OCP021001\n" + ":71A:SHA\n" + "-}{5:{CHK:B3BF0D846AFD}}";
			SwiftMessage msg = (new SwiftParser(fin)).message();
			assertNotNull(msg);
			assertNotNull(msg.Block1);
			assertNotNull(msg.Block2);
			assertNotNull(msg.Block4);
			assertNotNull(msg.Block5);
			assertEquals("TESTAR00AXXX", msg.Block1.LogicalTerminal);
			assertEquals("101", msg.Block2.MessageType);
			assertEquals("DG942_171206-004", msg.Block4.getFieldByName("20").Value);
		}

		/// <summary>
		/// Test parsing nested blocks as tags </summary>
		/// <exception cref="Exception"> </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Ignore public void testNestedBlocks() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testNestedBlocks()
		{
			string fin = "{1:F01OURSGB33AXXX0000000000}{2:O0961625170421ABLRXXXXGXXX00000000001704201625N}{3:{103:CLH}{108:SWIFTBICAXXX0000890}}{4:{1:F01PTY1US33AXXX0000000000}{2:I300PTY2GB33AXXXU3003}{3:{103:ABC}}{4:\n" + ":15A:\n" + ":20:R317703\n" + ":22A:NEWT\n" + "-}{5:{CHK:73AC90A7A3F1}{SYS:1309041018SMAIBE22AXXX0246001570}}}";

			// parse with SwiftMessage
			SwiftMessage sm = SwiftMessage.parse(fin);
			if (sm.isType(96))
			{
				SwiftBlock4 nested = sm.Block4;
				SwiftMessage mt = new SwiftMessage();
				if (nested.getTagByNumber(1) != null)
				{
					mt.addBlock(SwiftParser.parseBlock1(nested.getTagByNumber(1).Value));
				}
				if (nested.getTagByNumber(2) != null)
				{
					mt.addBlock(SwiftParser.parseBlock2(nested.getTagByNumber(2).Value));
				}
				if (nested.getTagByNumber(3) != null)
				{
					//System.out.println(nested.getTagByNumber(3).getValue());
					mt.addBlock(SwiftParser.parseBlock3(nested.getTagByNumber(3).Value));
				}
				if (nested.getTagByNumber(4) != null)
				{
					mt.addBlock(SwiftParser.parseBlock4(nested.getTagByNumber(4).Value));
				}
				if (nested.getTagByNumber(5) != null)
				{
					mt.addBlock(SwiftParser.parseBlock5(nested.getTagByNumber(5).Value));
				}
				assertNotNull(mt.Block1);
				assertNotNull(mt.Block2);
				assertNotNull(mt.Block3);
				assertNotNull(mt.Block4);
				assertNotNull(mt.Block5);
				assertEquals("F01PTY1US33AXXX0000000000", nested.getTagValue("1"));
				assertEquals("I300PTY2GB33AXXXU3003", nested.getTagValue("2"));
				assertEquals("{103:ABC}", nested.getTagValue("3"));
				assertEquals("\\n" + ":15A:\\n" + ":20:R317703\\n" + ":22A:NEWT\\n" + "-", nested.getTagValue("4"));
				assertEquals("{CHK:73AC90A7A3F1}{SYS:1309041018SMAIBE22AXXX0246001570}", nested.getTagValue("5"));
			}
		}
	}
}