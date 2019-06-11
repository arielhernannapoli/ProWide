using System.Collections.Generic;

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
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	using SwiftBlock2Input = com.prowidesoftware.swift.model.SwiftBlock2Input;
	using Tag = com.prowidesoftware.swift.model.Tag;

	/// <summary>
	/// MT541 tests
	/// 
	/// @since 4.0
	/// </summary>
	public class MT541Test : BaseMessageTestcase
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test541_1()
		public virtual void test541_1()
		{
			messageToParse = "{1:F01FOOBARXXXXXX1234123456}{2:I541FOOOFRPPXXXXN}{4:\n" + ":16R:GENL\n" + ":20C::SEME//2005080800000944\n" + ":23G:NEWM\n" + ":98A::PREP//20050808\n" + ":16S:GENL\n" + ":16R:TRADDET\n" + ":98A::TRAD//20050803\n" + ":98A::SETT//20050808\n" + ":90B::DEAL//ACTU/EUR11,11\n" + ":35B:ISIN FR1234567111\n" + "FRA.FOOOBAR\n" + ":70E::SPRO//4042\n" + ":16S:TRADFOO\n" + ":16R:FIAC\n" + ":36B::SETT//UNIT/1000,00\n" + ":97A::SAFE//123456789\n" + ":16S:FIAC\n" + ":16R:SETDET\n" + ":22F::SETR//TRAD\n" + ":16R:SETPRTY\n" + ":95R::DEAG/FOOV/1234\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::SELL//FOOOFRPP\n" + ":97A::SAFE//123456789\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::PSET//FOOVFRPP\n" + ":16S:SETPRTY\n" + ":16R:AMT\n" + ":19A::SETT//EUR123456,50\n" + ":16S:AMT\n" + ":16S:SETDET\n" + "-}";

			assertEquals("541", (parseMessage(messageToParse)).Type);

			//check b1
			assertEquals("F01FOOBARXXXXXX1234123456", b1.BlockValue);
			assertEquals("F", b1.ApplicationId);
			assertEquals("01", b1.ServiceId);
			assertEquals("FOOBARXXXXXX", b1.LogicalTerminal);
			assertEquals("1234", b1.SessionNumber);
			assertEquals("123456", b1.SequenceNumber);

			//check b2
			assertEquals("I541FOOOFRPPXXXXN", b2.BlockValue);
			assertEquals("541", ((SwiftBlock2Input)b2).MessageType);
			assertEquals("FOOOFRPPXXXX", ((SwiftBlock2Input)b2).ReceiverAddress);
			assertEquals("N", ((SwiftBlock2Input)b2).MessagePriority);
			assertNull(((SwiftBlock2Input)b2).DeliveryMonitoring);
			assertNull(((SwiftBlock2Input)b2).ObsolescencePeriod);

			assertEquals(32, b4.countAll());

			IList<Tag> b4Tags = b4.Tags;
			int pos = 0;

			t = (Tag) b4Tags[pos++];
			assertEquals("16R", t.Name);
			assertEquals("GENL", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("20C", t.Name);
			assertEquals(":SEME//2005080800000944", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("23G", t.Name);
			assertEquals("NEWM", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("98A", t.Name);
			assertEquals(":PREP//20050808", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16S", t.Name);
			assertEquals("GENL", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16R", t.Name);
			assertEquals("TRADDET", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("98A", t.Name);
			assertEquals(":TRAD//20050803", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("98A", t.Name);
			assertEquals(":SETT//20050808", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("90B", t.Name);
			assertEquals(":DEAL//ACTU/EUR11,11", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("35B", t.Name);
			assertEquals("ISIN FR1234567111\n" + "FRA.FOOOBAR", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("70E", t.Name);
			assertEquals(":SPRO//4042", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16S", t.Name);
			assertEquals("TRADFOO", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16R", t.Name);
			assertEquals("FIAC", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("36B", t.Name);
			assertEquals(":SETT//UNIT/1000,00", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("97A", t.Name);
			assertEquals(":SAFE//123456789", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16S", t.Name);
			assertEquals("FIAC", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16R", t.Name);
			assertEquals("SETDET", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("22F", t.Name);
			assertEquals(":SETR//TRAD", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16R", t.Name);
			assertEquals("SETPRTY", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("95R", t.Name);
			assertEquals(":DEAG/FOOV/1234", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16S", t.Name);
			assertEquals("SETPRTY", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16R", t.Name);
			assertEquals("SETPRTY", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("95P", t.Name);
			assertEquals(":SELL//FOOOFRPP", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("97A", t.Name);
			assertEquals(":SAFE//123456789", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16S", t.Name);
			assertEquals("SETPRTY", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16R", t.Name);
			assertEquals("SETPRTY", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("95P", t.Name);
			assertEquals(":PSET//FOOVFRPP", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16S", t.Name);
			assertEquals("SETPRTY", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16R", t.Name);
			assertEquals("AMT", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("19A", t.Name);
			assertEquals(":SETT//EUR123456,50", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16S", t.Name);
			assertEquals("AMT", t.Value);

			t = (Tag) b4Tags[pos++];
			assertEquals("16S", t.Name);
			assertEquals("SETDET", t.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test541_2()
		public virtual void test541_2()
		{
			messageToParse = "{1:F01FOOBARXXXXXX0000000000}{2:I541FOOOFRPPXXXXN}{4:\n" + ":16R:GENL\n" + ":20C::SEME//2002071500000614\n" + ":23G:NEWM\n" + ":98A::PREP//20020715\n" + ":16S:GENL\n" + ":16R:TRADDET\n" + ":98A::TRAD//20020713\n" + ":98A::SETT//20020718\n" + ":90B::DEAL//ACTU/EUR22,22\n" + ":35B:ISIN FR1234567890\n" + "FOO DE FRAN\n" + ":70E::SPRO//1234\n" + ":16S:TRADDET\n" + ":16R:FIAC\n" + ":36B::SETT//UNIT/321,00\n" + ":97A::SAFE//123456789\n" + ":16S:FIAC\n" + ":16R:SETDET\n" + ":22F::SETR//TRAD\n" + ":16R:SETPRTY\n" + ":95R::DEAG/SICV/4042\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::SELL//FOOOFRPP\n" + ":97A::SAFE//123456789\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::PSET//SICVFRPP\n" + ":16S:SETPRTY\n" + ":16R:AMT\n" + ":19A::SETT//EUR123456,78\n" + ":16S:AMT\n" + ":16S:SETDET\n" + "-}";
			assertEquals("541", (parseMessage(messageToParse)).Type);
			assertEquals("F01FOOBARXXXXXX0000000000", b1.BlockValue);
			assertEquals("I541FOOOFRPPXXXXN", b2.BlockValue);
			assertEquals(32, b4.countAll());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test541_3()
		public virtual void test541_3()
		{
			messageToParse = "{1:F01FOOBARXXXXXX4321654321}{2:I541FOOOARPPXXXXN}{4:\n" + ":16R:GENL\n" + ":20C::SEME//2007071800000923\n" + ":23G:NEWM\n" + ":98A::PREP//20070718\n" + ":16S:GENL\n" + ":16R:TRADDET\n" + ":98A::TRAD//20070714\n" + ":98A::SETT//20070719\n" + ":90B::DEAL//ACTU/EUR12,34\n" + ":35B:ISIN FR1234567890\n" + "FOO UAP\n" + ":70E::SPRO//4321\n" + ":16S:TRADDET\n" + ":16R:FIAC\n" + ":36B::SETT//UNIT/222,22\n" + ":97A::SAFE//123456789\n" + ":16S:FIAC\n" + ":16R:SETDET\n" + ":22F::SETR//TRAD\n" + ":16R:SETPRTY\n" + ":95R::DEAG/SICV/4321\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::SELL//FOOOARPP\n" + ":97A::SAFE//123456789\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::PSET//SICVARPP\n" + ":16S:SETPRTY\n" + ":16R:AMT\n" + ":19A::SETT//EUR123456,78\n" + ":16S:AMT\n" + ":16S:SETDET\n" + "-}";
			assertEquals("541", (parseMessage(messageToParse)).Type);
			assertEquals("F01FOOBARXXXXXX4321654321", b1.BlockValue);
			assertEquals("I541FOOOARPPXXXXN", b2.BlockValue);
			assertEquals(32, b4.countAll());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test541_4()
		public virtual void test541_4()
		{
			messageToParse = "{1:F01FOOBARXXXXXX1234123456}{2:I541FOOODEFFXCUSN}{4:\n" + ":16R:GENL\n" + ":20C::SEME//2001071800001228\n" + ":23G:NEWM\n" + ":98A::PREP//20010718\n" + ":16S:GENL\n" + ":16R:TRADDET\n" + ":98A::TRAD//20010713\n" + ":98A::SETT//20010715\n" + ":90B::DEAL//ACTU/EUR8,88\n" + ":35B:ISIN DE1234567890\n" + "FOOO CREATI\n" + ":16S:TRADDET\n" + ":16R:FIAC\n" + ":36B::SETT//UNIT/6666,66\n" + ":97A::SAFE//123456789\n" + ":16S:FIAC\n" + ":16R:SETDET\n" + ":22F::SETR//TRAD\n" + ":16R:SETPRTY\n" + ":95R::DEAG/AAKV/9876\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::SELL//AAKVDEFF\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::PSET//AAKVDEFF\n" + ":16S:SETPRTY\n" + ":16R:AMT\n" + ":19A::SETT//EUR123456,78\n" + ":16S:AMT\n" + ":16S:SETDET\n" + "-}";
			assertEquals("541", (parseMessage(messageToParse)).Type);
			assertEquals("F01FOOBARXXXXXX1234123456", b1.BlockValue);
			assertEquals("I541FOOODEFFXCUSN", b2.BlockValue);
			assertEquals(30, b4.countAll());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test541_5()
		public virtual void test541_5()
		{
			messageToParse = "{1:F01FOOBARXXXXXX0000000000}{2:I541FOOOUS33XASTN}{4:\n" + ":16R:GENL\n" + ":20C::SEME//2005071300000248\n" + ":23G:NEWM\n" + ":98A::PREP//20050713\n" + ":16S:GENL\n" + ":16R:TRADDET\n" + ":98A::TRAD//20050708\n" + ":98A::SETT//20050713\n" + ":90B::DEAL//ACTU/USD18,81\n" + ":35B:ISIN US1234567890\n" + "FOOOO SYS\n" + ":70E::SPRO//050\n" + ":16S:TRADDET\n" + ":16R:FIAC\n" + ":36B::SETT//UNIT/1234,00\n" + ":97A::SAFE//123456789\n" + ":16S:FIAC\n" + ":16R:SETDET\n" + ":22F::SETR//TRAD\n" + ":16R:SETPRTY\n" + ":95R::DEAG/DTCYID/050\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::SELL//MSNYUS11\n" + ":16S:SETPRTY\n" + ":16R:SETPRTY\n" + ":95P::PSET//DTCYUS11\n" + ":16S:SETPRTY\n" + ":16R:AMT\n" + ":19A::SETT//EUR123456,78\n" + ":16S:AMT\n" + ":16S:SETDET\n" + "-}";
			assertEquals("541", (parseMessage(messageToParse)).Type);
			assertEquals("F01FOOBARXXXXXX0000000000", b1.BlockValue);
			assertEquals("I541FOOOUS33XASTN", b2.BlockValue);
			assertEquals(31, b4.countAll());
		}

	}

}