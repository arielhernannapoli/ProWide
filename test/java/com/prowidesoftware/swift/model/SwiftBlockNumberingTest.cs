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
namespace com.prowidesoftware.swift.model
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;

	using Test = org.junit.Test;

	/// <summary>
	/// Blocks numbering tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class SwiftBlockNumberingTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNumber_1()
		public virtual void testNumber_1()
		{
			SwiftBlock1 b = new SwiftBlock1();
			assertEquals(Convert.ToInt32(1), b.Number);
			assertEquals("1", b.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNumber_2Input()
		public virtual void testNumber_2Input()
		{
			SwiftBlock2 b = new SwiftBlock2Input();
			assertEquals(Convert.ToInt32(2), b.Number);
			assertEquals("2", b.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNumber_2Output()
		public virtual void testNumber_2Output()
		{
			SwiftBlock2 b = new SwiftBlock2Output();
			assertEquals(Convert.ToInt32(2), b.Number);
			assertEquals("2", b.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNumber_3()
		public virtual void testNumber_3()
		{
			SwiftBlock3 b = new SwiftBlock3();
			assertEquals(Convert.ToInt32(3), b.Number);
			assertEquals("3", b.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNumber_4()
		public virtual void testNumber_4()
		{
			SwiftBlock4 b = new SwiftBlock4();
			assertEquals(Convert.ToInt32(4), b.Number);
			assertEquals("4", b.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNumber_5()
		public virtual void testNumber_5()
		{
			SwiftBlock5 b = new SwiftBlock5();
			assertEquals(Convert.ToInt32(5), b.Number);
			assertEquals("5", b.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNumber_9()
		public virtual void testNumber_9()
		{
			SwiftBlockUser b = new SwiftBlockUser(9);
			assertEquals(Convert.ToInt32(9), b.Number);
			assertEquals("9", b.Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNumber_S()
		public virtual void testNumber_S()
		{
			SwiftBlockUser b = new SwiftBlockUser("S");
			assertEquals(Convert.ToInt32(-1), b.Number);
			assertEquals("S", b.Name);
		}
	}

}