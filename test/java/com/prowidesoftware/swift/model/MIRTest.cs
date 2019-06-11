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
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	/// <summary>
	/// Test for Message Input Reference (MIR) model class.
	/// 
	/// @since 6.0
	/// </summary>
	public class MIRTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplitComponents() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSplitComponents()
		{
			MIR mir = new MIR("");
			assertNull(mir.getDate());
			assertNull(mir.LogicalTerminal);
			assertNull(mir.SessionNumber);
			assertNull(mir.SequenceNumber);

			mir = new MIR(null);
			assertNull(mir.getDate());
			assertNull(mir.LogicalTerminal);
			assertNull(mir.SessionNumber);
			assertNull(mir.SequenceNumber);

			mir = new MIR("1234567890");
			assertNull(mir.getDate());
			assertNull(mir.LogicalTerminal);
			assertNull(mir.SessionNumber);
			assertNull(mir.SequenceNumber);

			mir = new MIR("1234567890123456789012345678901234567890");
			assertNull(mir.getDate());
			assertNull(mir.LogicalTerminal);
			assertNull(mir.SessionNumber);
			assertNull(mir.SequenceNumber);

			mir = new MIR("091203BANKBEBBAXXX2222123456");
			assertEquals("091203", mir.getDate());
			assertEquals("BANKBEBBAXXX", mir.LogicalTerminal);
			assertEquals("2222", mir.SessionNumber);
			assertEquals("123456", mir.SequenceNumber);
		}

	}

}