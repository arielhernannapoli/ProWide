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
namespace com.prowidesoftware.swift.model
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;


	using Test = org.junit.Test;

	using Field13A = com.prowidesoftware.swift.model.field.Field13A;
	using Field13B = com.prowidesoftware.swift.model.field.Field13B;
	using Field13C = com.prowidesoftware.swift.model.field.Field13C;
	using Field15A = com.prowidesoftware.swift.model.field.Field15A;
	using Field15B = com.prowidesoftware.swift.model.field.Field15B;
	using Field15C = com.prowidesoftware.swift.model.field.Field15C;
	using Field15D = com.prowidesoftware.swift.model.field.Field15D;
	using Field16R = com.prowidesoftware.swift.model.field.Field16R;
	using Field16S = com.prowidesoftware.swift.model.field.Field16S;
	using Field32A = com.prowidesoftware.swift.model.field.Field32A;
	using Field32B = com.prowidesoftware.swift.model.field.Field32B;
	using Field33A = com.prowidesoftware.swift.model.field.Field33A;
	using Field34B = com.prowidesoftware.swift.model.field.Field34B;
	using MT502 = com.prowidesoftware.swift.model.mt.mt5xx.MT502;
	using MT535 = com.prowidesoftware.swift.model.mt.mt5xx.MT535;

	public class SwiftMessageUtilsTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplitByField15()
		public virtual void testSplitByField15()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage sm = new SwiftMessage(true);
			SwiftMessage sm = new SwiftMessage(true);
			sm.Block4.append(Field15B.emptyTag()).append(Field32A.emptyTag());
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Map<String, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(sm);
			IDictionary<string, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(sm);
			assertNotNull(map);
			assertTrue(map.ContainsKey("B"));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock list = map.get("B");
			SwiftTagListBlock list = map["B"];
			assertNotNull(list);
			assertEquals(2, list.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplitByField15LetterOption()
		public virtual void testSplitByField15LetterOption()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage sm = new SwiftMessage(true);
			SwiftMessage sm = new SwiftMessage(true);
			sm.Block4.append(Field15A.emptyTag()).append(Field33A.emptyTag()).append(Field15B.emptyTag()).append(Field32A.emptyTag()).append(Field15B.emptyTag()).append(Field32B.emptyTag()).append(Field32B.emptyTag());

			IList<SwiftTagListBlock> Bs = SwiftMessageUtils.splitByField15(sm, "B");
			assertNotNull(Bs);
			assertEquals(2, Bs.Count);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock list0 = Bs.get(0);
			SwiftTagListBlock list0 = Bs[0];
			assertNotNull(list0);
			assertEquals(2, list0.size());

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock list1 = Bs.get(1);
			SwiftTagListBlock list1 = Bs[1];
			assertNotNull(list1);
			assertEquals(3, list1.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplitByField15LetterOptionIntercalado()
		public virtual void testSplitByField15LetterOptionIntercalado()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage sm = new SwiftMessage(true);
			SwiftMessage sm = new SwiftMessage(true);
			sm.Block4.append(Field15A.emptyTag()).append(Field33A.emptyTag()).append(Field15B.emptyTag()).append(Field15C.emptyTag()).append(Field32A.emptyTag()).append(Field15B.emptyTag()).append(Field32B.emptyTag()).append(Field32B.emptyTag());

			IList<SwiftTagListBlock> Bs = SwiftMessageUtils.splitByField15(sm, "B");
			assertNotNull(Bs);
			assertEquals(2, Bs.Count);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock list0 = Bs.get(0);
			SwiftTagListBlock list0 = Bs[0];
			assertNotNull(list0);
			assertEquals(1, list0.size());

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock list1 = Bs.get(1);
			SwiftTagListBlock list1 = Bs[1];
			assertNotNull(list1);
			assertEquals(3, list1.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplitByField15LetterOptionPrimero()
		public virtual void testSplitByField15LetterOptionPrimero()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage sm = new SwiftMessage(true);
			SwiftMessage sm = new SwiftMessage(true);
			sm.Block4.append(Field15A.emptyTag()).append(Field33A.emptyTag()).append(Field15B.emptyTag()).append(Field15C.emptyTag()).append(Field32A.emptyTag()).append(Field15B.emptyTag()).append(Field32B.emptyTag()).append(Field32B.emptyTag());

			IList<SwiftTagListBlock> Bs = SwiftMessageUtils.splitByField15(sm, "A");
			assertNotNull(Bs);
			assertEquals(1, Bs.Count);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock list0 = Bs.get(0);
			SwiftTagListBlock list0 = Bs[0];
			assertNotNull(list0);
			assertEquals(2, list0.size());

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplitByField15LetterOptionUltimo()
		public virtual void testSplitByField15LetterOptionUltimo()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage sm = new SwiftMessage(true);
			SwiftMessage sm = new SwiftMessage(true);
			sm.Block4.append(Field15A.emptyTag()).append(Field33A.emptyTag()).append(Field15B.emptyTag()).append(Field15C.emptyTag()).append(Field32A.emptyTag()).append(Field15B.emptyTag()).append(Field32B.emptyTag()).append(Field32B.emptyTag()).append(Field15D.emptyTag()).append(Field34B.emptyTag()).append(Field34B.emptyTag()).append(Field34B.emptyTag()).append(Field34B.emptyTag());

			IList<SwiftTagListBlock> Bs = SwiftMessageUtils.splitByField15(sm, "D");
			assertNotNull(Bs);
			assertEquals(1, Bs.Count);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock list0 = Bs.get(0);
			SwiftTagListBlock list0 = Bs[0];
			assertNotNull(list0);
			assertEquals(5, list0.size());

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCreateSubsequenceWithParentsB_502() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testCreateSubsequenceWithParentsB_502()
		{
			SwiftTagListBlock o = SwiftMessageUtils.createSubsequenceWithParents(typeof(MT502), "B", Field13A.emptyTag(), Field13B.emptyTag(), Field13C.emptyTag());
			assertEquals(5, o.size());
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCreateSubsequenceWithParentsA() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testCreateSubsequenceWithParentsA()
		{
			SwiftTagListBlock o = SwiftMessageUtils.createSubsequenceWithParents(typeof(MT535), "A", Field13A.emptyTag());
			assertEquals(3, o.size());
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCreateSubsequenceWithParentsA1() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testCreateSubsequenceWithParentsA1()
		{
			SwiftTagListBlock o = SwiftMessageUtils.createSubsequenceWithParents(typeof(MT535), "A1", Field13A.emptyTag());
			assertEquals(5, o.size());
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCreateSubsequenceWithParentsA1_order() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testCreateSubsequenceWithParentsA1_order()
		{
			SwiftTagListBlock o = SwiftMessageUtils.createSubsequenceWithParents(typeof(MT535), "A1", Field13A.emptyTag());
			assertEquals(5, o.size());
			assertEquals(MT535.SequenceA.START_END_16RS, o.getTag(0).Value);
			assertEquals(Field16R.NAME, o.getTag(0).Name);

			assertEquals(MT535.SequenceA1.START_END_16RS, o.getTag(1).Value);
			assertEquals(Field16R.NAME, o.getTag(1).Name);

			assertEquals("13A", o.getTag(2).Name);

			assertEquals(MT535.SequenceA1.START_END_16RS, o.getTag(3).Value);
			assertEquals(Field16S.NAME, o.getTag(3).Name);

			assertEquals(MT535.SequenceA.START_END_16RS, o.getTag(4).Value);
			assertEquals(Field16S.NAME, o.getTag(4).Name);
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCreateSubsequenceWithParentsB1b1() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testCreateSubsequenceWithParentsB1b1()
		{
			SwiftTagListBlock o = SwiftMessageUtils.createSubsequenceWithParents(typeof(MT535), "B1b1", Field13A.emptyTag());
			assertEquals(9, o.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveInnerSequences() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveInnerSequences()
		{
			MT535 m = (new MT535()).append(MT535.SequenceA.newInstance(MT535.SequenceA1.newInstance(Field13C.tag("foo1")).append(Field13C.tag("foo2"))));
			SwiftTagListBlock sublist = SwiftMessageUtils.removeInnerSequences(m.SequenceA);

			assertEquals(3, sublist.size());
			assertEquals("foo2", sublist.getTag(1).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testcurrencyAmountFromMessage() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testcurrencyAmountFromMessage()
		{
			const string fin = "{1:F01CCRTIT2TX36A0000000000}{2:I101PPABPLPKXXXXN}{3:{108:YSGU193268223XXX}}{4:\n" + ":20:4C2W0S0V8AM6X7OH\n" + ":28D:00001/00001\n" + ":50H:/PL66160011270003012399999999\n" + "FOO\n" + ":30:131119\n" + ":21:ZCAR1HI1HF3STLJO\n" + ":32B:PLN2044,10\n" + ":59:/PL74175000090000000001905201\n" + "POLONIA FOO HOTEL\n" + "AL FOOLIMSKIE 45\n" + "00-692\n" + "PL WARSAWA\n" + ":70:1/34530/13\n" + ":71A:SHA\n" + "-}";
			CurrencyAmount ca = SwiftMessageUtils.currencyAmount(SwiftMessage.parse(fin));
			assertNotNull(ca);
			assertEquals("PLN", ca.Currency);
			assertEquals(new decimal("2044.10"), ca.Amount);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testcurrencyAmountFromSystemMessage() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testcurrencyAmountFromSystemMessage()
		{
			const string fin = "{1:F21BNPAFRPPZXXX0000000002}{4:{177:1702090741}{451:0}}{1:F01BNPAFRPPZXXX0000000002}{2:I103BNPAFRPPXXXXN}{3:{108:REF1}}{4:\n" + ":20:WITHMUR\n" + "-}{5:{MAC:ABCD1234}{CHK:ABCDEF123456}}";
			CurrencyAmount ca = SwiftMessageUtils.currencyAmount(SwiftMessage.parse(fin));
			assertNull(ca);
		}

	}

}