﻿/*
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
	import static org.junit.Assert.assertTrue;

	using Test = org.junit.Test;

	public class MT535Test
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1()
		public virtual void test1()
		{
			MT535 m = new MT535();
			m.append(MT535.SequenceB1b.newInstance(MT535.SequenceB1b1.newInstance()));
			assertTrue(m.SequenceB1cList.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1a()
		public virtual void test1a()
		{
			MT535 m = new MT535();
			m.append(MT535.SequenceB.newInstance(MT535.SequenceB1b1.newInstance()));
			assertTrue(m.SequenceB1cList.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1b()
		public virtual void test1b()
		{
			MT535 m = new MT535();
			m.append(MT535.SequenceB1b1.newInstance());
			assertTrue(m.SequenceB1cList.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test2()
		public virtual void test2()
		{
			MT535 m = new MT535();
			m.append(MT535.SequenceB1.newInstance(MT535.SequenceB1c.newInstance()));
			assertTrue(m.SequenceB1b1List.Count == 0);
		}

	}

}