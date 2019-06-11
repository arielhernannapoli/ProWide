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

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertSame;

	using Before = org.junit.Before;
	using Test = org.junit.Test;

	/// <summary>
	/// Swift writer tests
	/// 
	/// @since 4.0
	/// </summary>
	public class MultilineUtilTest
	{

		private MultilineUtil util;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			this.util = new MultilineUtil();
		}

		/// <summary>
		/// Returns the same array if it is empty
		/// 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testEmpty()
		public virtual void testEmpty()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String [] lines = new String[0];
			string[] lines = new string[0];
			string[] got = util.removeInnerEmptyLines(lines);
			assertSame(lines, got);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReturnEmpty()
		public virtual void testReturnEmpty()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String [] lines = new String[10];
			string[] lines = new string[10];
			string[] got = util.removeInnerEmptyLines(lines);
			assertNotNull(got);
			assertEquals(0, got.Length);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testReturnEmptyKeep()
		public virtual void testReturnEmptyKeep()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String [] lines = new String[10];
			string[] lines = new string[10];
			string[] got = util.removeInnerEmptyLines(lines, true);
			assertNotNull(got);
			assertEquals(10, got.Length);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimple1()
		public virtual void testSimple1()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String [] lines = new String[3];
			string[] lines = new string[3];
			lines[0] = "foo";
			lines[1] = "    ";
			lines[2] = "bar";
			string[] got = util.removeInnerEmptyLines(lines);
			assertNotNull(got);
			assertEquals(2, got.Length);
			assertEquals("foo", got[0]);
			assertEquals("bar", got[1]);
		}
	}

}