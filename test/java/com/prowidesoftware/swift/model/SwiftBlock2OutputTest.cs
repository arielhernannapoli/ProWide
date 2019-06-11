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
	/// Block2 output tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class SwiftBlock2OutputTest
	{

		internal SwiftBlock2Output @out;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			@out = new SwiftBlock2Output();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput()
		public virtual void testOutput()
		{
			@out.Value = "2:O1001200010103BANKBEBBAXXX22221234560101031201N";
			assertFalse(@out.Input);
			assertEquals("100", @out.MessageType);
			assertEquals("1200", @out.SenderInputTime);

			assertEquals("010103", @out.MIRDate);
			assertEquals("BANKBEBBAXXX", @out.MIRLogicalTerminal);
			assertEquals("2222", @out.MIRSessionNumber);
			assertEquals("123456", @out.MIRSequenceNumber);
			assertEquals("010103BANKBEBBAXXX2222123456", @out.MIR);

			assertEquals("010103", @out.ReceiverOutputDate);
			assertEquals("1201", @out.ReceiverOutputTime);
			assertEquals("N", @out.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_2()
		public virtual void testOutput_2()
		{
			@out.Value = "O1001200010103BANKBEBBAXXX22221234560101031201N";
			assertFalse(@out.Input);
			assertEquals("100", @out.MessageType);
			assertEquals("1200", @out.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", @out.MIR);
			assertEquals("010103", @out.ReceiverOutputDate);
			assertEquals("1201", @out.ReceiverOutputTime);
			assertEquals("N", @out.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_3()
		public virtual void testOutput_3()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("2:O1001200010103BANKBEBBAXXX22221234560101031201N");
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", nout.MIR);
			assertEquals("010103", nout.ReceiverOutputDate);
			assertEquals("1201", nout.ReceiverOutputTime);
			assertEquals("N", nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_4()
		public virtual void testOutput_4()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX22221234560101031201N");
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", nout.MIR);
			assertEquals("010103", nout.ReceiverOutputDate);
			assertEquals("1201", nout.ReceiverOutputTime);
			assertEquals("N", nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_5()
		public virtual void testOutput_5()
		{
			try
			{
				//set an invalid length value
				@out.Value = "O1001200010103BANKBEBBAXXX222212345601010";
			}
			catch (System.ArgumentException)
			{
				return;
			}
			fail("IllegalArgumentException not thrown");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_6()
		public virtual void testOutput_6()
		{
			try
			{
				//set an invalid starting substring
				@out.Value = "I1001200010103BANKBEBBAXXX22221234560101031201N";
			}
			catch (System.ArgumentException)
			{
				return;
			}
			fail("IllegalArgumentException not thrown");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_7()
		public virtual void testOutput_7()
		{
			try
			{
				//set an invalid starting substring
				@out.Value = "1:O1001200010103BANKBEBBAXXX22221234560101031201N";
			}
			catch (System.ArgumentException)
			{
				return;
			}
			fail("IllegalArgumentException not thrown");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutputGetValue()
		public virtual void testOutputGetValue()
		{
			string value = "O1001200010103BANKBEBBAXXX22221234560101031201N";
			@out.Value = value;
			assertEquals(value, @out.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutputMIR()
		public virtual void testOutputMIR()
		{
			@out.MIR = "YYMMDDBANKBEBBAXXX2222123456";
			assertEquals("YYMMDD", @out.MIRDate);
			assertEquals("BANKBEBBAXXX", @out.MIRLogicalTerminal);
			assertEquals("2222", @out.MIRSessionNumber);
			assertEquals("123456", @out.MIRSequenceNumber);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutputMIR_2()
		public virtual void testOutputMIR_2()
		{
			try
			{
				//set an invalid length string
				@out.MIR = "YYMMDDBANKBEBBAXXX2222123";
			}
			catch (System.ArgumentException)
			{
				return;
			}
			fail("IllegalArgumentException not thrown");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsEmptyAndSize()
		public virtual void testIsEmptyAndSize()
		{
			@out.MessagePriority = null;
			assertTrue(@out.Empty);
			assertTrue(@out.size() == 0);
			@out.Value = "O1001200010103BANKBEBBAXXX22221234560101031201N";
			assertFalse(@out.Empty);
			assertTrue(@out.size() == 47);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_Lenient()
		public virtual void testOutput_Lenient()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX22221234560101031201N", true);
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", nout.MIR);
			assertEquals("010103", nout.ReceiverOutputDate);
			assertEquals("1201", nout.ReceiverOutputTime);
			assertEquals("N", nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientMoreThanExpected()
		public virtual void testOutput_LenientMoreThanExpected()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX22221234560101031201NAA", true);
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", nout.MIR);
			assertEquals("010103", nout.ReceiverOutputDate);
			assertEquals("1201", nout.ReceiverOutputTime);
			assertEquals("NAA", nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientMissingPriority()
		public virtual void testOutput_LenientMissingPriority()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX22221234560101031201", true);
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", nout.MIR);
			assertEquals("010103", nout.ReceiverOutputDate);
			assertEquals("1201", nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientInvalidOutputTime()
		public virtual void testOutput_LenientInvalidOutputTime()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX222212345601010312", true);
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", nout.MIR);
			assertEquals("010103", nout.ReceiverOutputDate);
			assertEquals("12", nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientMissingOutputTime()
		public virtual void testOutput_LenientMissingOutputTime()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX2222123456010103", true);
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", nout.MIR);
			assertEquals("010103", nout.ReceiverOutputDate);
			assertNull(nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientMissingOutputDate()
		public virtual void testOutput_LenientMissingOutputDate()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX2222123456", true);
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX2222123456", nout.MIR);
			assertNull(nout.ReceiverOutputDate);
			assertNull(nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientInvalidMIR()
		public virtual void testOutput_LenientInvalidMIR()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX222212", true);
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertEquals("010103BANKBEBBAXXX222212", nout.MIR);
			assertNull(nout.ReceiverOutputDate);
			assertNull(nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientMissingMIR()
		public virtual void testOutput_LenientMissingMIR()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O1001200", true);
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertEquals("1200", nout.SenderInputTime);
			assertNull(nout.MIR);
			assertNull(nout.ReceiverOutputDate);
			assertNull(nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientMissingInputTime()
		public virtual void testOutput_LenientMissingInputTime()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O100", true);
			assertFalse(nout.Input);
			assertEquals("100", nout.MessageType);
			assertNull(nout.SenderInputTime);
			assertNull(nout.MIR);
			assertNull(nout.ReceiverOutputDate);
			assertNull(nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientMissingType()
		public virtual void testOutput_LenientMissingType()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("O", true);
			assertFalse(nout.Input);
			assertNull(nout.MessageType);
			assertNull(nout.SenderInputTime);
			assertNull(nout.MIR);
			assertNull(nout.ReceiverOutputDate);
			assertNull(nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientMissingInputOutputIndication()
		public virtual void testOutput_LenientMissingInputOutputIndication()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("2:", true);
			assertFalse(nout.Input);
			assertNull(nout.MessageType);
			assertNull(nout.SenderInputTime);
			assertNull(nout.MIR);
			assertNull(nout.ReceiverOutputDate);
			assertNull(nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientEmpty()
		public virtual void testOutput_LenientEmpty()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output("", true);
			assertFalse(nout.Input);
			assertNull(nout.MessageType);
			assertNull(nout.SenderInputTime);
			assertNull(nout.MIR);
			assertNull(nout.ReceiverOutputDate);
			assertNull(nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testOutput_LenientNull()
		public virtual void testOutput_LenientNull()
		{
			SwiftBlock2Output nout = new SwiftBlock2Output(null, true);
			assertFalse(nout.Input);
			assertNull(nout.MessageType);
			assertNull(nout.SenderInputTime);
			assertNull(nout.MIR);
			assertNull(nout.ReceiverOutputDate);
			assertNull(nout.ReceiverOutputTime);
			assertNull(nout.MessagePriority);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSetMIR()
		public virtual void testSetMIR()
		{
			SwiftBlock2Output b = new SwiftBlock2Output();
			b.setMIR("010103BANKBEBBAXXX2222123456", true);
			assertEquals("010103BANKBEBBAXXX2222123456", b.MIR);
			MIR mir = new MIR(b.MIR);
			assertEquals("010103", mir.getDate());
			assertEquals("BANKBEBBAXXX", mir.LogicalTerminal);
			assertEquals("2222", mir.SessionNumber);
			assertEquals("123456", mir.SequenceNumber);

			b.setMIR("010103BANKBEBBAXXX2222", true);
			assertEquals("010103BANKBEBBAXXX2222", b.MIR);

			b.setMIR("010103BANKBEBBAXXX", true);
			assertEquals("010103BANKBEBBAXXX", b.MIR);

			b.setMIR("010103", true);
			assertEquals("010103", b.MIR);

			b.setMIR("FOO", true);
			assertEquals("FOO", b.MIR);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCopyConstructor()
		public virtual void testCopyConstructor()
		{
			SwiftBlock2Output a = new SwiftBlock2Output("O1001200010103BANKBEBBAXXX22221234560101031201N");
			SwiftBlock2Output b = new SwiftBlock2Output(a);
			assertEquals(a.Value, b.Value);
		}

	}

}