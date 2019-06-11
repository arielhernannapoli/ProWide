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

namespace com.prowidesoftware.swift.model.mt.mt5xx
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	using Test = org.junit.Test;

	using Field22H = com.prowidesoftware.swift.model.field.Field22H;
	using Field95C = com.prowidesoftware.swift.model.field.Field95C;


	public class MT537Test
	{

	//	assertEquals(MT537.SequenceB.START_END_16RS, MT537.SequenceC3.START_END_16RS);

	//	assertEquals(MT537.SequenceB1.START_END_16RS, MT537.SequenceC3a.START_END_16RS);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1()
		public virtual void test1()
		{
			MT537 m = new MT537();
			m.append(MT537.SequenceA1.newInstance());
			assertTrue(m.SequenceB2aList.Count == 0);
			assertTrue(m.SequenceC1List.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test2()
		public virtual void test2()
		{
			MT537 m = new MT537();
			m.append(MT537.SequenceB2a.newInstance());
			assertTrue(m.SequenceA1List.Count == 0);
			assertTrue(m.SequenceC1List.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test3()
		public virtual void test3()
		{
			MT537 m = new MT537();
			m.append(MT537.SequenceC1.newInstance());
			assertTrue(m.SequenceA1List.Count == 0);
			assertTrue(m.SequenceB2aList.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testC2a()
		public virtual void testC2a()
		{
			MT537 m = new MT537();
			m.append(MT537.SequenceC.newInstance(MT537.SequenceC2.newInstance(MT537.SequenceC2a.newInstance())));
			assertEquals(1, MT537.getSequenceCList(m.SwiftMessage.Block4).Count);
			assertEquals(1, MT537.getSequenceC2List(m.SwiftMessage.Block4).Count);
			assertEquals(1, MT537.getSequenceC2aList(m.SwiftMessage.Block4).Count);

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testC2a_from_S285() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testC2a_from_S285()
		{
			SwiftTagListBlock C2_contents = (new SwiftTagListBlock()).append(Field22H.tag(":REDE//DELI")).append(MT537.SequenceC2a.newInstance(Field95C.tag(":DEAG")));
			MT537 m = (new MT537()).append(MT537.SequenceC.newInstance(MT537.SequenceC2.newInstance(C2_contents)));
			assertEquals(1, MT537.getSequenceCList(m.SwiftMessage.Block4).Count);
			assertEquals(1, MT537.getSequenceC2List(m.SwiftMessage.Block4).Count);
			assertEquals(1, MT537.getSequenceC2aList(m.SwiftMessage.Block4).Count);

			assertEquals(1, m.SequenceCList.Count);
			assertEquals(1, m.SequenceC2List.Count);
			assertEquals(1, m.SequenceC2aList.Count);

		}

	}

}