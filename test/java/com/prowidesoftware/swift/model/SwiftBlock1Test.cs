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
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.fail;
	using JsonObject = com.google.gson.JsonObject;
	using JsonParser = com.google.gson.JsonParser;

	using Before = org.junit.Before;
	using Test = org.junit.Test;

	/// <summary>
	/// Block1 tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class SwiftBlock1Test
	{

		private SwiftBlock1 b;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			b = new SwiftBlock1();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSetValue()
		public virtual void testSetValue()
		{
			b.Value = "F01BANKBEBBAXXX1234567890";
			assertEquals("F", b.ApplicationId);
			assertEquals("01", b.ServiceId);
			assertEquals("BANKBEBBAXXX", b.LogicalTerminal);
			assertEquals("1234", b.SessionNumber);
			assertEquals("567890", b.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSetValue_2()
		public virtual void testSetValue_2()
		{
			b.Value = "1:F01BANKBEBBAXXX1234567890";
			assertEquals("F", b.ApplicationId);
			assertEquals("01", b.ServiceId);
			assertEquals("BANKBEBBAXXX", b.LogicalTerminal);
			assertEquals("1234", b.SessionNumber);
			assertEquals("567890", b.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSetValue_3()
		public virtual void testSetValue_3()
		{
			try
			{
				//set an invalid length value
				b.Value = "1:F01BANKBEBBAXXX12345678";
			}
			catch (System.ArgumentException)
			{
				return;
			}
			fail("IllegalArgumentException not thrown");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSetValue_4()
		public virtual void testSetValue_4()
		{
			try
			{
				//set an invalid starting substring
				b.Value = "a:F01BANKBEBBAXXX1234567890";
			}
			catch (System.ArgumentException)
			{
				return;
			}
			fail("IllegalArgumentException not thrown");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructor()
		public virtual void testConstructor()
		{
			SwiftBlock1 bb = new SwiftBlock1("F01BANKBEBBAXXX1234567890");
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBAXXX", bb.LogicalTerminal);
			assertEquals("1234", bb.SessionNumber);
			assertEquals("567890", bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructor_2()
		public virtual void testConstructor_2()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F01BANKBEBBAXXX1234567890");
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBAXXX", bb.LogicalTerminal);
			assertEquals("1234", bb.SessionNumber);
			assertEquals("567890", bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructor_3()
		public virtual void testConstructor_3()
		{
			SwiftBlock1 bb = new SwiftBlock1("F01BANKBEBBXXXX1234567890");
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBXXXX", bb.LogicalTerminal);
			assertEquals("1234", bb.SessionNumber);
			assertEquals("567890", bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructor_4()
		public virtual void testConstructor_4()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F01BANKBEBBCXXX1234567890");
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBCXXX", bb.LogicalTerminal);
			assertEquals("1234", bb.SessionNumber);
			assertEquals("567890", bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue()
		public virtual void testGetValue()
		{
			string value = "F01BANKBEBBAXXX1234567890";
			b.Value = value;
			assertEquals(value, b.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsEmptyAndSize()
		public virtual void testIsEmptyAndSize()
		{
			//assertTrue(b.isEmpty());
			//assertTrue(b.size() == 0);
			b.Value = "F01BANKBEBBAXXX1234567890";
			assertFalse(b.Empty);
			assertTrue(b.size() == 25);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient()
		public virtual void testConstructorLenient()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F01BANKBEBBAXXX1234567890", true);
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBAXXX", bb.LogicalTerminal);
			assertEquals("1234", bb.SessionNumber);
			assertEquals("567890", bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_lessThanExpected()
		public virtual void testConstructorLenient_lessThanExpected()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F01BANKBEBBAXXX123456789", true);
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBAXXX", bb.LogicalTerminal);
			assertEquals("1234", bb.SessionNumber);
			assertEquals("56789", bb.SequenceNumber); //less than expected
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_moreThanExpected()
		public virtual void testConstructorLenient_moreThanExpected()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F01BANKBEBBAXXX1234567890123", true);
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBAXXX", bb.LogicalTerminal);
			assertEquals("1234", bb.SessionNumber);
			assertEquals("567890123", bb.SequenceNumber); //more than expected
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_noSequeceNumber()
		public virtual void testConstructorLenient_noSequeceNumber()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F01BANKBEBBAXXX1234", true);
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBAXXX", bb.LogicalTerminal);
			assertEquals("1234", bb.SessionNumber);
			assertNull(bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_noSession()
		public virtual void testConstructorLenient_noSession()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F01BANKBEBBAXXX", true);
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBAXXX", bb.LogicalTerminal);
			assertNull(bb.SessionNumber);
			assertNull(bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_incompleteLogicalTerminal()
		public virtual void testConstructorLenient_incompleteLogicalTerminal()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F01BANKBEBBA", true);
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertEquals("BANKBEBBA", bb.LogicalTerminal); //missign branch code
			assertNull(bb.SessionNumber);
			assertNull(bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_missignLogicalTerminal()
		public virtual void testConstructorLenient_missignLogicalTerminal()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F01", true);
			assertEquals("F", bb.ApplicationId);
			assertEquals("01", bb.ServiceId);
			assertNull(bb.LogicalTerminal);
			assertNull(bb.SessionNumber);
			assertNull(bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_missignServiceId()
		public virtual void testConstructorLenient_missignServiceId()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:F", true);
			assertEquals("F", bb.ApplicationId);
			assertNull(bb.ServiceId);
			assertNull(bb.LogicalTerminal);
			assertNull(bb.SessionNumber);
			assertNull(bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_missignApplicationId()
		public virtual void testConstructorLenient_missignApplicationId()
		{
			SwiftBlock1 bb = new SwiftBlock1("1:", true);
			assertNull(bb.ApplicationId);
			assertNull(bb.ServiceId);
			assertNull(bb.LogicalTerminal);
			assertNull(bb.SessionNumber);
			assertNull(bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_empty()
		public virtual void testConstructorLenient_empty()
		{
			SwiftBlock1 bb = new SwiftBlock1("", true);
			assertNull(bb.ApplicationId);
			assertNull(bb.ServiceId);
			assertNull(bb.LogicalTerminal);
			assertNull(bb.SessionNumber);
			assertNull(bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConstructorLenient_null()
		public virtual void testConstructorLenient_null()
		{
			SwiftBlock1 bb = new SwiftBlock1(null, true);
			assertNull(bb.ApplicationId);
			assertNull(bb.ServiceId);
			assertNull(bb.LogicalTerminal);
			assertNull(bb.SessionNumber);
			assertNull(bb.SequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCopyConstructor()
		public virtual void testCopyConstructor()
		{
			SwiftBlock1 a = new SwiftBlock1("F01BANKBEBBAXXX1234567890");
			SwiftBlock1 b = new SwiftBlock1(a);
			assertEquals(a.Value, b.Value);
		}

	}

}