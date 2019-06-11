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
namespace com.prowidesoftware.swift.model.field
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	/// <summary>
	/// Test for Field34F and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field34FTest : AbstractFieldTest
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(Field34FTest.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(Field34FTest).FullName);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("34F", "aaab123,45");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField19AString()
		public virtual void testField19AString()
		{
			Field34F f = null;

			f = new Field34F((string)null);
			assertNull(f.getComponent1());
			assertNull(f.Component2);
			assertNull(f.getComponent3());

			f = new Field34F("");
			assertNull(f.getComponent1());
			assertNull(f.Component2);
			assertNull(f.getComponent3());

			f = new Field34F("a");
			assertNull(f.getComponent1());
			assertNull(f.Component2);
			assertNull(f.getComponent3());

			f = new Field34F("aa");
			assertNull(f.getComponent1());
			assertNull(f.Component2);
			assertNull(f.getComponent3());

			f = new Field34F("aaa");
			assertEquals("aaa", f.getComponent1());
			assertNull(f.Component2);
			assertNull(f.getComponent3());

			f = new Field34F("aaab");
			assertEquals("aaa", f.getComponent1());
			assertEquals("b", f.Component2);
			assertNull(f.getComponent3());

			f = new Field34F("aaabb");
			assertEquals("aaa", f.getComponent1());
			assertEquals("bb", f.Component2);
			assertNull(f.getComponent3());

			f = new Field34F("aaabb1");
			assertEquals("aaa", f.getComponent1());
			assertEquals("bb", f.Component2);
			assertEquals("1", f.getComponent3());

			f = new Field34F("aaab1");
			assertEquals("aaa", f.getComponent1());
			assertEquals("b", f.Component2);
			assertEquals("1", f.getComponent3());

			f = new Field34F("aaab1x");
			assertEquals("aaa", f.getComponent1());
			assertEquals("b", f.Component2);
			assertEquals("1x", f.getComponent3());

			f = new Field34F("aaab123");
			assertEquals("aaa", f.getComponent1());
			assertEquals("b", f.Component2);
			assertEquals("123", f.getComponent3());
			assertEquals(new decimal(123), new decimal((double)f.Component3AsNumber));

			f = new Field34F("aaab123,");
			assertEquals("aaa", f.getComponent1());
			assertEquals("b", f.Component2);
			assertEquals("123,", f.getComponent3());
			assertEquals(new decimal(123), new decimal((double)f.Component3AsNumber));

			f = new Field34F("aaab123,45");
			assertEquals("aaa", f.getComponent1());
			assertEquals("b", f.Component2);
			assertEquals("123,45", f.getComponent3());
			assertEquals(new decimal(123.45), new decimal((double)f.Component3AsNumber));

		}

	}
}