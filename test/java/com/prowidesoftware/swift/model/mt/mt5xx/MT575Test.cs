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


	public class MT575Test
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1()
		public virtual void test1()
		{
			MT575 m = new MT575();
			m.append(MT575.SequenceA1.newInstance());
			assertTrue(m.SequenceB1a1List.Count == 0);
			assertTrue(m.SequenceC1List.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test2()
		public virtual void test2()
		{
			MT575 m = new MT575();
			m.append(MT575.SequenceB1a1.newInstance());
			assertTrue(m.SequenceA1List.Count == 0);
			assertTrue(m.SequenceC1List.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test3()
		public virtual void test3()
		{
			MT575 m = new MT575();
			m.append(MT575.SequenceC1.newInstance());
			assertTrue(m.SequenceA1List.Count == 0);
			assertTrue(m.SequenceB1a1List.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test4()
		public virtual void test4()
		{
			MT575 m = new MT575();
			m.append(MT575.SequenceB1a4.newInstance());
			assertTrue(m.SequenceC2aList.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test5()
		public virtual void test5()
		{
			MT575 m = new MT575();
			m.append(MT575.SequenceC2a.newInstance());
			assertTrue(m.SequenceB1a4List.Count == 0);
		}

	}

}