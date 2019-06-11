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
namespace com.prowidesoftware.swift.model.field
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	/// <summary>
	/// Test for fields getLine API.
	/// 
	/// @since 7.7
	/// </summary>
	public class GetLineTest
	{

		/// <summary>
		/// Simplest case
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test01()
		public virtual void test01()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD\nEEEE\nFFFF\nGGGG");
			Field35B f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD\nEEEE\nFFFF\nGGGG");
			assertEquals("ISIN HELLO", f.getLine(1));
			assertEquals("AAAA", f.getLine(2));
			assertEquals("BBBB", f.getLine(3));
			assertEquals("CCCC", f.getLine(4));
			assertEquals("DDDD", f.getLine(5));
			//remaining lines are ignored by copy constructor
			assertNull(f.getLine(6));
			assertNull(f.getLine(7));
			assertNull(f.getLine(8));
		}

		/// <summary>
		/// Missing component 2
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test02()
		public virtual void test02()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("ISIN \nAAAA\nBBBB\nCCCC\nDDDD");
			Field35B f = new Field35B("ISIN \nAAAA\nBBBB\nCCCC\nDDDD");
			assertEquals("ISIN", f.getLine(1));
			assertEquals("AAAA", f.getLine(2));
			assertEquals("BBBB", f.getLine(3));
			assertEquals("CCCC", f.getLine(4));
			assertEquals("DDDD", f.getLine(5));
		}

		/// <summary>
		/// Missing first line
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test03()
		public virtual void test03()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("AAAA\nBBBB\nCCCC\nDDDD");
			Field35B f = new Field35B("AAAA\nBBBB\nCCCC\nDDDD");
			assertNull(f.getLine(1));
			assertEquals("AAAA", f.getLine(2));
			assertEquals("BBBB", f.getLine(3));
			assertEquals("CCCC", f.getLine(4));
			assertEquals("DDDD", f.getLine(5));
		}

		/// <summary>
		/// Missing first two lines
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test04()
		public virtual void test04()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("BBBB\nCCCC\nDDDD");
			Field35B f = new Field35B("BBBB\nCCCC\nDDDD");
			assertNull(f.getLine(1));
			assertEquals("BBBB", f.getLine(2));
			assertEquals("CCCC", f.getLine(3));
			assertEquals("DDDD", f.getLine(4));
			assertNull(f.getLine(5));
		}

		/// <summary>
		/// Using offset
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test05()
		public virtual void test05()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD");
			Field35B f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD");
			assertEquals("AAAA", f.getLine(1, Field35B.DESCRIPTION));
			assertEquals("BBBB", f.getLine(2, Field35B.DESCRIPTION));
			assertEquals("CCCC", f.getLine(3, Field35B.DESCRIPTION));
			assertEquals("DDDD", f.getLine(4, Field35B.DESCRIPTION));
		}

		/// <summary>
		/// Using offset and missing fields
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test06()
		public virtual void test06()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("ISIN \nAAAA\nBBBB\nCCCC\nDDDD");
			Field35B f = new Field35B("ISIN \nAAAA\nBBBB\nCCCC\nDDDD");
			assertEquals("AAAA", f.getLine(1, Field35B.DESCRIPTION));
			assertEquals("BBBB", f.getLine(2, Field35B.DESCRIPTION));
			assertEquals("CCCC", f.getLine(3, Field35B.DESCRIPTION));
			assertEquals("DDDD", f.getLine(4, Field35B.DESCRIPTION));
		}

		/// <summary>
		/// Using offset and missing fields
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test07()
		public virtual void test07()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("AAAA\nBBBB\nCCCC\nDDDD");
			Field35B f = new Field35B("AAAA\nBBBB\nCCCC\nDDDD");
			assertEquals("AAAA", f.getLine(1, Field35B.DESCRIPTION));
			assertEquals("BBBB", f.getLine(2, Field35B.DESCRIPTION));
			assertEquals("CCCC", f.getLine(3, Field35B.DESCRIPTION));
			assertEquals("DDDD", f.getLine(4, Field35B.DESCRIPTION));
		}

		/// <summary>
		/// Using offset
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test08()
		public virtual void test08()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD");
			Field35B f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD");
			/*
			 * plain lines
			 */
			assertEquals("ISIN HELLO", f.getLine(1));
			assertEquals("AAAA", f.getLine(2));
			assertEquals("BBBB", f.getLine(3));
			assertEquals("CCCC", f.getLine(4));
			assertEquals("DDDD", f.getLine(5));
			/*
			 * lines numbered since de description component
			 */
			assertEquals("AAAA", f.getLine(1, Field35B.DESCRIPTION));
			assertEquals("BBBB", f.getLine(2, Field35B.DESCRIPTION));
			assertEquals("CCCC", f.getLine(3, Field35B.DESCRIPTION));
			assertEquals("DDDD", f.getLine(4, Field35B.DESCRIPTION));
		}

		/// <summary>
		/// Empty
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test09()
		public virtual void test09()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B();
			Field35B f = new Field35B();
			assertNull(f.getLine(1));
			assertNull(f.getLine(2));
			assertNull(f.getLine(3));
			assertNull(f.getLine(4));
			assertNull(f.getLine(5));
		}

		/// <summary>
		/// Empty
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test10()
		public virtual void test10()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("");
			Field35B f = new Field35B("");
			assertNull(f.getLine(1));
			assertNull(f.getLine(2));
			assertNull(f.getLine(3));
			assertNull(f.getLine(4));
			assertNull(f.getLine(5));
		}

		/// <summary>
		/// Null
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test11()
		public virtual void test11()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B((String)null);
			Field35B f = new Field35B((string)null);
			assertNull(f.getLine(1));
			assertNull(f.getLine(2));
			assertNull(f.getLine(3));
			assertNull(f.getLine(4));
			assertNull(f.getLine(5));
		}

		/// <summary>
		/// Empty
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test12()
		public virtual void test12()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field59 f = new Field59("");
			Field59 f = new Field59("");
			assertNull(f.getLine(1));
			assertNull(f.getLine(2));
			assertNull(f.getLine(3));
			assertNull(f.getLine(4));
			assertNull(f.getLine(5));
		}

		/// <summary>
		/// Null
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test13()
		public virtual void test13()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field59 f = new Field59((String)null);
			Field59 f = new Field59((string)null);
			assertNull(f.getLine(1));
			assertNull(f.getLine(2));
			assertNull(f.getLine(3));
			assertNull(f.getLine(4));
			assertNull(f.getLine(5));
		}

		/// <summary>
		/// Using offset
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test14()
		public virtual void test14()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field35B f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD");
			Field35B f = new Field35B("ISIN HELLO\nAAAA\nBBBB\nCCCC\nDDDD");

			assertEquals("ISIN HELLO", f.getLinesBetween(1, 1)[0]);
			assertEquals(1, f.getLinesBetween(1, 1).Count);

			assertEquals("AAAA", f.getLinesBetween(2, 2)[0]);
			assertEquals(1, f.getLinesBetween(2, 2).Count);

			assertEquals("ISIN HELLO", f.getLinesBetween(1, 2)[0]);
			assertEquals("AAAA", f.getLinesBetween(1, 2)[1]);
			assertEquals(2, f.getLinesBetween(1, 2).Count);

			assertEquals("BBBB", f.getLinesBetween(3, 5, Field35B.ISIN_Renamed)[0]);
			assertEquals("CCCC", f.getLinesBetween(3, 5, Field35B.ISIN_Renamed)[1]);
			assertEquals("DDDD", f.getLinesBetween(3, 5, Field35B.ISIN_Renamed)[2]);
			assertEquals(3, f.getLinesBetween(3, 5, Field35B.ISIN_Renamed).Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test15()
		public virtual void test15()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field53B f = new Field53B("/1234\nBANK");
			Field53B f = new Field53B("/1234\nBANK");
			assertEquals("/1234", f.getLine(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test16()
		public virtual void test16()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field53B f = new Field53B("//1234\nBANK");
			Field53B f = new Field53B("//1234\nBANK");
			assertEquals("//1234", f.getLine(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test17()
		public virtual void test17()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field50H f = new Field50H("/8754219990\n" + "MAG-NUM INC.\n" + "GENERAL A/C\n" + "BANHOFFSTRASSE 30\n" + "ZURICH, SWITZERLAND");
			Field50H f = new Field50H("/8754219990\n" + "MAG-NUM INC.\n" + "GENERAL A/C\n" + "BANHOFFSTRASSE 30\n" + "ZURICH, SWITZERLAND");
			assertEquals("/8754219990", f.getLine(1));
			assertEquals("/8754219990", f.getLine(1, 0));
			assertEquals("MAG-NUM INC.", f.getLine(2));
			assertEquals("MAG-NUM INC.", f.getLine(1, Field50H.NAME_AND_ADDRESS));
			assertEquals("GENERAL A/C", f.getLine(2, Field50H.NAME_AND_ADDRESS));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test18()
		public virtual void test18()
		{
			Field95Q f = new Field95Q(":INVE//JOE DOE");
			assertEquals(":INVE//JOE DOE", f.getLine(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test19()
		public virtual void test19()
		{
			Field95Q f = new Field95Q(":INVE//JOE DOE");
			assertEquals("JOE DOE", f.getLine(1, Field95Q.NAME_AND_ADDRESS));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test19b()
		public virtual void test19b()
		{
			Field95Q f = new Field95Q(":INVE//JOE DOE\n/FOO");
			IList<string> lines = f.getLinesBetween(1, 2, Field95Q.NAME_AND_ADDRESS);
			/*
			 * the separators ":" and "//" are removed
			 */
			assertEquals("JOE DOE", lines[0]);
			/*
			 * the "/" prefix is kept
			 */
			assertEquals("/FOO", lines[1]);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test19c()
		public virtual void test19c()
		{
			Field95Q f = new Field95Q(":INVE//JOE DOE\n/FOO");
			IList<string> lines = f.getLinesBetween(1, 2);
			/*
			 * the separators ":" and "//" are kept because there is no component offset involved
			 */
			assertEquals(":INVE//JOE DOE", lines[0]);
			/*
			 * the "/" prefix is kept
			 */
			assertEquals("/FOO", lines[1]);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test19d() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test19d()
		{
			Field35B f = new Field35B("/US/31392EXH8\nFEDERAL NATL MTG ASSN");
			assertEquals("/US/31392EXH8", f.getLine(2));
			/*
			 * the starting slash will not be returned because the query includes an offset
			 */
			assertEquals("US/31392EXH8", f.getLine(1, Field35B.DESCRIPTION));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test20()
		public virtual void test20()
		{
			Field50K f = new Field50K("/12345");
			assertEquals(1, f.Lines.Count);
			assertEquals("/12345", f.getLine(1));
			assertNull(f.getLine(2));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test21()
		public virtual void test21()
		{
			Field50K f = new Field50K("ABC");
			assertEquals(1, f.Lines.Count);
			assertNull(f.getLine(1));
			assertEquals("ABC", f.getLine(2));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test22()
		public virtual void test22()
		{
			Field50K f = new Field50K("ABC");
			assertEquals(1, f.Lines.Count);
			assertNull(f.getLine(1));
			assertEquals("ABC", f.getLine(2));
		}
	}

}