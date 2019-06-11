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
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.fail;

	using Before = org.junit.Before;
	using Test = org.junit.Test;

	/// <summary>
	/// Block2 input tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class SwiftBlock2InputTest
	{

		internal SwiftBlock2Input @in;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			@in = new SwiftBlock2Input();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_1a()
		public virtual void testInput_1a()
		{
			@in.Value = "2:I103BANKDEFFXXXXU3003";
			assertTrue(@in.Input);
			assertEquals("103", @in.MessageType);
			assertEquals("BANKDEFFXXXX", @in.ReceiverAddress);
			assertEquals("U", @in.MessagePriority);
			assertEquals("3", @in.DeliveryMonitoring);
			assertEquals("003", @in.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_1b()
		public virtual void testInput_1b()
		{
			@in.Value = "2:I103BANKDEFFXXXXU3";
			assertTrue(@in.Input);
			assertEquals("103", @in.MessageType);
			assertEquals("BANKDEFFXXXX", @in.ReceiverAddress);
			assertEquals("U", @in.MessagePriority);
			assertEquals("3", @in.DeliveryMonitoring);
			assertNull(@in.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_1c()
		public virtual void testInput_1c()
		{
			@in.Value = "2:I103BANKDEFFXXXXU";
			assertTrue(@in.Input);
			assertEquals("103", @in.MessageType);
			assertEquals("BANKDEFFXXXX", @in.ReceiverAddress);
			assertEquals("U", @in.MessagePriority);
			assertNull(@in.DeliveryMonitoring);
			assertNull(@in.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_2a()
		public virtual void testInput_2a()
		{
			@in.Value = "I103BANKDEFFXXXXU3003";
			assertTrue(@in.Input);
			assertEquals("103", @in.MessageType);
			assertEquals("BANKDEFFXXXX", @in.ReceiverAddress);
			assertEquals("U", @in.MessagePriority);
			assertEquals("3", @in.DeliveryMonitoring);
			assertEquals("003", @in.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_2b()
		public virtual void testInput_2b()
		{
			@in.Value = "I103BANKDEFFXXXXU3";
			assertTrue(@in.Input);
			assertEquals("103", @in.MessageType);
			assertEquals("BANKDEFFXXXX", @in.ReceiverAddress);
			assertEquals("U", @in.MessagePriority);
			assertEquals("3", @in.DeliveryMonitoring);
			assertNull(@in.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_2c()
		public virtual void testInput_2c()
		{
			@in.Value = "I103BANKDEFFXXXXU";
			assertTrue(@in.Input);
			assertEquals("103", @in.MessageType);
			assertEquals("BANKDEFFXXXX", @in.ReceiverAddress);
			assertEquals("U", @in.MessagePriority);
			assertNull(@in.DeliveryMonitoring);
			assertNull(@in.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_3()
		public virtual void testInput_3()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I103BANKDEFFXXXXU3003");
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertEquals("BANKDEFFXXXX", nin.ReceiverAddress);
			assertEquals("U", nin.MessagePriority);
			assertEquals("3", nin.DeliveryMonitoring);
			assertEquals("003", nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_4()
		public virtual void testInput_4()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("I103BANKDEFFXXXXU3003");
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertEquals("BANKDEFFXXXX", nin.ReceiverAddress);
			assertEquals("U", nin.MessagePriority);
			assertEquals("3", nin.DeliveryMonitoring);
			assertEquals("003", nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_5()
		public virtual void testInput_5()
		{
			try
			{
				//set an invalid length value
				@in.Value = "I103BANKDEFFXXXXU300";
			}
			catch (System.ArgumentException)
			{
				return;
			}
			fail("IllegalArgumentException not thrown");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_6()
		public virtual void testInput_6()
		{
			try
			{
				//set an invalid starting substring
				@in.Value = "O103BANKDEFFXXXXU3003";
			}
			catch (System.ArgumentException)
			{
				return;
			}
			fail("IllegalArgumentException not thrown");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_7()
		public virtual void testInput_7()
		{
			try
			{
				//set an invalid starting substring
				@in.Value = "1:I103BANKDEFFXXXXU3003";
			}
			catch (System.ArgumentException)
			{
				return;
			}
			fail("IllegalArgumentException not thrown");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInputGetValue()
		public virtual void testInputGetValue()
		{
			string value = "I103BANKDEFFXXXXU3003";
			@in.Value = value;
			assertEquals(value, @in.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsEmptyAndSize()
		public virtual void testIsEmptyAndSize()
		{
			@in.MessagePriority = null;
			assertTrue(@in.Empty);
			assertTrue(@in.size() == 0);
			@in.Value = "I103BANKDEFFXXXXU3003";
			assertFalse(@in.Empty);
			assertTrue(@in.size() == 21);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_Lenient()
		public virtual void testInput_Lenient()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I103BANKDEFFXXXXU3003", true);
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertEquals("BANKDEFFXXXX", nin.ReceiverAddress);
			assertEquals("U", nin.MessagePriority);
			assertEquals("3", nin.DeliveryMonitoring);
			assertEquals("003", nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientLessThanExpected()
		public virtual void testInput_LenientLessThanExpected()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I103BANKDEFFXXXXU300", true);
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertEquals("BANKDEFFXXXX", nin.ReceiverAddress);
			assertEquals("U", nin.MessagePriority);
			assertEquals("3", nin.DeliveryMonitoring);
			assertEquals("00", nin.ObsolescencePeriod); //less than expected
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientMoreThanExpected()
		public virtual void testInput_LenientMoreThanExpected()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I103BANKDEFFXXXXU300399", true);
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertEquals("BANKDEFFXXXX", nin.ReceiverAddress);
			assertEquals("U", nin.MessagePriority);
			assertEquals("3", nin.DeliveryMonitoring);
			assertEquals("00399", nin.ObsolescencePeriod); //more than expected
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientMissignObsolencePeriod()
		public virtual void testInput_LenientMissignObsolencePeriod()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I103BANKDEFFXXXXU3", true);
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertEquals("BANKDEFFXXXX", nin.ReceiverAddress);
			assertEquals("U", nin.MessagePriority);
			assertEquals("3", nin.DeliveryMonitoring);
			assertNull(nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientMissignDeliveryMonitoring()
		public virtual void testInput_LenientMissignDeliveryMonitoring()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I103BANKDEFFXXXXU", true);
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertEquals("BANKDEFFXXXX", nin.ReceiverAddress);
			assertEquals("U", nin.MessagePriority);
			assertNull(nin.DeliveryMonitoring);
			assertNull(nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientMissignPriority()
		public virtual void testInput_LenientMissignPriority()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I103BANKDEFFXXXX", true);
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertEquals("BANKDEFFXXXX", nin.ReceiverAddress);
			assertNull(nin.MessagePriority);
			assertNull(nin.DeliveryMonitoring);
			assertNull(nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientMissignLTBranch()
		public virtual void testInput_LenientMissignLTBranch()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I103BANKDEFFX", true);
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertEquals("BANKDEFFX", nin.ReceiverAddress);
			assertNull(nin.MessagePriority);
			assertNull(nin.DeliveryMonitoring);
			assertNull(nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientMissignLT()
		public virtual void testInput_LenientMissignLT()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I103", true);
			assertTrue(nin.Input);
			assertEquals("103", nin.MessageType);
			assertNull(nin.ReceiverAddress);
			assertNull(nin.MessagePriority);
			assertNull(nin.DeliveryMonitoring);
			assertNull(nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientMissignType()
		public virtual void testInput_LenientMissignType()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:I", true);
			assertTrue(nin.Input);
			assertNull(nin.MessageType);
			assertNull(nin.ReceiverAddress);
			assertNull(nin.MessagePriority);
			assertNull(nin.DeliveryMonitoring);
			assertNull(nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientMissignInputOututIndication()
		public virtual void testInput_LenientMissignInputOututIndication()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("2:", true);
			assertTrue(nin.Input);
			assertNull(nin.MessageType);
			assertNull(nin.ReceiverAddress);
			assertNull(nin.MessagePriority);
			assertNull(nin.DeliveryMonitoring);
			assertNull(nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientEmpty()
		public virtual void testInput_LenientEmpty()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input("", true);
			assertTrue(nin.Input);
			assertNull(nin.MessageType);
			assertNull(nin.ReceiverAddress);
			assertNull(nin.MessagePriority);
			assertNull(nin.DeliveryMonitoring);
			assertNull(nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInput_LenientNull()
		public virtual void testInput_LenientNull()
		{
			SwiftBlock2Input nin = new SwiftBlock2Input(null, true);
			assertTrue(nin.Input);
			assertNull(nin.MessageType);
			assertNull(nin.ReceiverAddress);
			assertNull(nin.MessagePriority);
			assertNull(nin.DeliveryMonitoring);
			assertNull(nin.ObsolescencePeriod);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCopyConstructor()
		public virtual void testCopyConstructor()
		{
			SwiftBlock2Input a = new SwiftBlock2Input("I103BANKDEFFXXXXU3003");
			SwiftBlock2Input b = new SwiftBlock2Input(a);
			assertEquals(a.Value, b.Value);
		}

	}

}