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

	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// Test for <seealso cref="AbstractSwiftMessage"/> model API
	/// 
	/// @since 7.8.4
	/// </summary>
	public class AbstractSwiftMessageTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void match()
		public virtual void match()
		{
			MtSwiftMessage msg = new MtSwiftMessage();
			assertFalse(msg.match(""));
			assertFalse(msg.match(null));

			msg.Identifier = "";
			assertFalse(msg.match(""));
			assertFalse(msg.match(null));

			msg.Identifier = "fin.103";
			assertFalse(msg.match(""));
			assertFalse(msg.match(null));
			assertTrue(msg.match("fin.103"));
			assertTrue(msg.match("fin.*"));
			assertFalse(msg.match("fin.*STP"));

			msg.Identifier = "camt.002.002.01";
			assertTrue(msg.match("camt.*"));
			assertTrue(msg.match("camt.*01"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void category()
		public virtual void category()
		{
			MtSwiftMessage mt = new MtSwiftMessage();
			assertEquals("", mt.Category);

			mt.Identifier = "";
			assertEquals("", mt.Category);

			mt.Identifier = "fin.103";
			assertEquals("1", mt.Category);

			MxSwiftMessage mx = new MxSwiftMessage();
			assertEquals("", mx.Category);

			mx.Identifier = "";
			assertEquals("", mx.Category);

			mx.Identifier = "camt.002.002.01";
			assertEquals("camt", mx.Category);
		}

	}

}