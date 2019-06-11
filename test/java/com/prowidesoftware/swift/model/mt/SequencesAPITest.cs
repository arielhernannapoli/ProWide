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

namespace com.prowidesoftware.swift.model.mt
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.fail;

	using Test = org.junit.Test;

	using Field16R = com.prowidesoftware.swift.model.field.Field16R;
	using Field16S = com.prowidesoftware.swift.model.field.Field16S;
	using Field20 = com.prowidesoftware.swift.model.field.Field20;
	using Field21 = com.prowidesoftware.swift.model.field.Field21;
	using Field22F = com.prowidesoftware.swift.model.field.Field22F;
	using Field23A = com.prowidesoftware.swift.model.field.Field23A;
	using Field30 = com.prowidesoftware.swift.model.field.Field30;
	using Field32B = com.prowidesoftware.swift.model.field.Field32B;
	using Field36 = com.prowidesoftware.swift.model.field.Field36;
	using Field59 = com.prowidesoftware.swift.model.field.Field59;
	using Field71G = com.prowidesoftware.swift.model.field.Field71G;
	using Field95P = com.prowidesoftware.swift.model.field.Field95P;
	using Field98A = com.prowidesoftware.swift.model.field.Field98A;
	using MT101 = com.prowidesoftware.swift.model.mt.mt1xx.MT101;
	using SequenceA = com.prowidesoftware.swift.model.mt.mt1xx.MT101.SequenceA;
	using SequenceB = com.prowidesoftware.swift.model.mt.mt1xx.MT101.SequenceB;
	using MT104 = com.prowidesoftware.swift.model.mt.mt1xx.MT104;
	using MT360 = com.prowidesoftware.swift.model.mt.mt3xx.MT360;
	using MT564 = com.prowidesoftware.swift.model.mt.mt5xx.MT564;
	using MT670 = com.prowidesoftware.swift.model.mt.mt6xx.MT670;

	/// <summary>
	/// Main test for MT sequences API
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.7
	/// </summary>
	public class SequencesAPITest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_01()
		public virtual void test_01()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt5xx.MT564 m = new com.prowidesoftware.swift.model.mt.mt5xx.MT564();
			MT564 m = new MT564();
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			assertNotNull(m.SequenceEList);
			assertEquals(1, m.SequenceEList.Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_02()
		public virtual void test_02()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt5xx.MT564 m = new com.prowidesoftware.swift.model.mt.mt5xx.MT564();
			MT564 m = new MT564();
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			assertNotNull(m.SequenceEList);
			assertEquals(2, m.SequenceEList.Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_03()
		public virtual void test_03()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt5xx.MT564 m = new com.prowidesoftware.swift.model.mt.mt5xx.MT564();
			MT564 m = new MT564();
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16R.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			assertNotNull(m.SequenceEList);
			assertEquals(1, m.SequenceEList.Count);
			assertNotNull(m.SequenceE1List);
			assertEquals(1, m.SequenceE1List.Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_04()
		public virtual void test_04()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt5xx.MT564 m = new com.prowidesoftware.swift.model.mt.mt5xx.MT564();
			MT564 m = new MT564();
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16R.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			assertNotNull(m.SequenceEList);
			assertEquals(2, m.SequenceEList.Count);
			assertNotNull(m.SequenceE1List);
			assertEquals(1, m.SequenceE1List.Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_05()
		public virtual void test_05()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt5xx.MT564 m = new com.prowidesoftware.swift.model.mt.mt5xx.MT564();
			MT564 m = new MT564();
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16R.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16R.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			assertNotNull(m.SequenceEList);
			assertEquals(2, m.SequenceEList.Count);
			assertNotNull(m.SequenceE1List);
			assertEquals(2, m.SequenceE1List.Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_06()
		public virtual void test_06()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt5xx.MT564 m = new com.prowidesoftware.swift.model.mt.mt5xx.MT564();
			MT564 m = new MT564();
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16R.NAME, MT564.SequenceE.START_END_16RS));
			m.append(new Tag(Field16R.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE1.START_END_16RS));
			m.append(new Tag(Field16S.NAME, MT564.SequenceE.START_END_16RS));
			assertNotNull(m.SequenceEList);
			assertEquals(2, m.SequenceEList.Count);
			assertNotNull(m.SequenceE1List);
			assertEquals(1, m.SequenceE1List.Count);
			/*
			 * nested call
			 */
			assertEquals(0, MT564.getSequenceE1List(m.SequenceEList[0]).Count);
			assertEquals(1, MT564.getSequenceE1List(m.SequenceEList[1]).Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_07()
		public virtual void test_07()
		{
			const string s = "{1:F01SWHQBEBBAXXX0001000001}{2:I564SWHQBEBBXBILN}{3:{108:495}}{4:\n" + ":16R:GENL\n" + ":20C::SEME//FU00003020000001\n" + ":20C::CORP//OTHR000000000302\n" + ":23G:NEWM\n" + ":22F::CAEV//OTHR\n" + ":22F::CAMV//MAND\n" + ":98C::PREP//20141204070253\n" + ":25D::PROC//PREU\n" + ":16S:GENL\n" + ":16R:USECU\n" + ":35B:ISIN AT0000A00GJ3\n" + "FOO 322 Euro\n" + " FOO Duration(T)\n" + ":16R:ACCTINFO\n" + ":97C::SAFE//GENR\n" + ":16S:ACCTINFO\n" + ":16S:USECU\n" + ":16R:CADETL\n" + ":98A::EFFD//20150129\n" + ":70G::WEBB//sssss\n" + ":16S:CADETL\n" + ":16R:ADDINFO\n" + ":70E::ADTX//Fondsfusion\n" + " FOO 322 Euro \n" + "FOO Duration\n" + ":70E::TXNR//Raiffeisen \n" + "Kapitalanlage Gesellschaft\n" + " m.b.H. informiert gem.\n" + " Paragraph133 Abs. 1 InvFG\n" + " 2011, dass\n" + ":16S:ADDINFO\n" + "-}";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt5xx.MT564 m = new com.prowidesoftware.swift.model.mt.mt5xx.MT564(s);
			MT564 m = new MT564(s);
			assertEquals(0, m.SequenceC.size());
			assertEquals(0, MT564.getSequenceC(m.SwiftMessage.Block4).size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_NPE()
		public virtual void test_NPE()
		{
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt5xx.MT564 m = new com.prowidesoftware.swift.model.mt.mt5xx.MT564("invalid message");
				MT564 m = new MT564("invalid message");
				m.SequenceA;
			}
			catch (System.NullReferenceException e)
			{
				fail(e.Message);
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test670_SequenceC() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test670_SequenceC()
		{
			MT670 m = (new MT670()).append(MT670.SequenceA2.newInstance(Field95P.tag("SSIR"))).append(MT670.SequenceB.newInstance(MT670.SequenceB2.newInstance(Field22F.tag("PMTH"))));
			assertTrue(m.SequenceC.Empty);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMT360() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testMT360()
		{
			MT360 m = (new MT360()).append(MT360.SequenceA.newInstance(Field23A.tag("FIXEDFIXED"))).append(MT360.SequenceB.newInstance()).append(MT360.SequenceE.newInstance());
			assertTrue(m.SequenceC.Empty);
			assertTrue(m.SequenceF.Empty);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNewSequenceA_MT101() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testNewSequenceA_MT101()
		{
			MT101 m = (new MT101()).append(MT101.SequenceA.newInstance(Field98A.emptyTag()));
			MT101.SequenceA A = m.SequenceA;
			assertNotNull(A);
			assertFalse(A.Empty);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNewSequenceB_MT101() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testNewSequenceB_MT101()
		{
			MT101 m = (new MT101()).append(MT101.SequenceB.newInstance(Field98A.emptyTag()));
			IList<MT101.SequenceB> Bs = m.SequenceBList;
			assertEquals(1, Bs.Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test104_SequenceC() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test104_SequenceC()
		{
			MT104 m = (new MT104()).append(MT104.SequenceA.newInstance(Field20.tag("FOO"), Field30.tag("FOO"))).append(MT104.SequenceB.newInstance(Field21.tag("FOO"), Field32B.tag("FOO"), Field59.tag("FOO"), Field36.tag("FOO"))).append(Field32B.tag("FOO"), Field71G.tag("FOO"));
			assertFalse(m.SequenceC.Empty);
			assertEquals(2, m.SequenceC.size());
			assertEquals(Field32B.NAME, m.SequenceC.getTag(0).Name);
			assertEquals(Field71G.NAME, m.SequenceC.getTag(1).Name);
		}
	}

}