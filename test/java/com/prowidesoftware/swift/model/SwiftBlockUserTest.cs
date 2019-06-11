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
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Before = org.junit.Before;
	using Test = org.junit.Test;

	/// <summary>
	/// User blocks tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class SwiftBlockUserTest
	{

		private SwiftMessage m = null;
		private SwiftBlockUser buS = null;
		private SwiftBlockUser bu9 = null;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			m = new SwiftMessage();
			buS = new SwiftBlockUser("S");
			bu9 = new SwiftBlockUser("9");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_ValidNames()
		public virtual void test_ValidNames()
		{
			// numbers 0 or 6 are valid
			assertTrue(SwiftBlockUser.isValidName(0));
			assertTrue(SwiftBlockUser.isValidName(6));

			// numbers 0 or 6 are valid
			assertTrue(SwiftBlockUser.isValidName("0"));
			assertTrue(SwiftBlockUser.isValidName("6"));

			// single letters are valid
			assertTrue(SwiftBlockUser.isValidName("A"));
			assertTrue(SwiftBlockUser.isValidName("z"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_InValidNames()
		public virtual void test_InValidNames()
		{
			// numbers 1-5 are invalid
			assertFalse(SwiftBlockUser.isValidName(1));
			assertFalse(SwiftBlockUser.isValidName(2));
			assertFalse(SwiftBlockUser.isValidName(3));
			assertFalse(SwiftBlockUser.isValidName(4));
			assertFalse(SwiftBlockUser.isValidName(5));

			// srings 1-5 are invalid
			assertFalse(SwiftBlockUser.isValidName("1"));
			assertFalse(SwiftBlockUser.isValidName("2"));
			assertFalse(SwiftBlockUser.isValidName("3"));
			assertFalse(SwiftBlockUser.isValidName("4"));
			assertFalse(SwiftBlockUser.isValidName("5"));

			// other strings are invalid
			assertFalse(SwiftBlockUser.isValidName(""));
			assertFalse(SwiftBlockUser.isValidName("AB"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_block_S()
		public virtual void test_block_S()
		{
			m.addUserBlock(buS);
			assertTrue(m.getUserBlock("S") == buS);
			m.removeUserBlock("S");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_addBlock_9()
		public virtual void test_addBlock_9()
		{
			assertEquals(null, m.UserBlocks);
			m.addUserBlock(bu9);
			assertEquals(1, m.UserBlocks.Count);
			assertTrue(m.getUserBlock(9) == bu9);
			m.removeUserBlock(9);
			assertEquals(0, m.UserBlocks.Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_addBlock_9String()
		public virtual void test_addBlock_9String()
		{
			m.addUserBlock(bu9);
			assertTrue(m.getUserBlock("9") == bu9);
			m.removeUserBlock("9");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_getBlock_1()
		public virtual void test_getBlock_1()
		{
			assertNull(m.getUserBlock(1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=IllegalArgumentException.class) public void test_removeBlock_1()
		public virtual void test_removeBlock_1()
		{
			// FIXME why does this test fail? IAE is thrown and expected...
			m.removeUserBlock(1);
		}

		/// <summary>
		/// Remove UserBlock using a string for block naming
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveBlockUserStringName() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveBlockUserStringName()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage(false);
			SwiftMessage m = new SwiftMessage(false);
			assertEquals(0, m.BlockCount);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlockUser bu = new SwiftBlockUser("S");
			SwiftBlockUser bu = new SwiftBlockUser("S");
			bu.append(new Tag("120:asdadad"));
			m.addUserBlock(bu);
			assertEquals(1, m.BlockCount);
			assertEquals(bu, m.getUserBlock("S"));

			m.removeUserBlock("S");
			assertEquals(0, m.BlockCount);
			assertNull(m.getUserBlock("S"));
		}

		/// <summary>
		/// Remove UserBlock using an integer for block naming
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveBlockUserNumberName() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveBlockUserNumberName()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage m = new SwiftMessage(false);
			SwiftMessage m = new SwiftMessage(false);
			assertEquals(0, m.BlockCount);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlockUser bu = new SwiftBlockUser(6);
			SwiftBlockUser bu = new SwiftBlockUser(6);
			bu.append(new Tag("120:asdadad"));
			m.addUserBlock(bu);
			assertEquals(1, m.BlockCount);
			assertEquals(bu, m.getUserBlock(6));

			m.removeUserBlock(6);
			assertEquals(0, m.BlockCount);
			assertNull(m.getUserBlock(6));
		}
	}

}