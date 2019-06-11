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
	/// Test for Field69F and similar fields.
	/// Pattern: ":4!c//4!c/<DATE4><TIME2> "
	/// 
	/// @since 6.0
	/// </summary>
	public class Field69FTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("69F", ":ABC//DEF/20111224131415");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse69F()
		public virtual void testParse69F()
		{
			Field69F f = null;

			f = new Field69F((string)null);
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field69F("ABC");
			assertEquals("ABC", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field69F(":ABC");
			assertEquals("ABC", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field69F("ABC//");
			assertEquals("ABC", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field69F(":ABC//");
			assertEquals("ABC", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field69F(":ABC//DEF");
			assertEquals("ABC", f.Component1);
			assertEquals("DEF", f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field69F(":ABC//DEF/20111224131415");
			assertEquals("ABC", f.Component1);
			assertEquals("DEF", f.Component2);
			assertEquals("20111224", f.getComponent3());
			assertEquals(2011, f.Component3AsCalendar.Year);
			assertEquals(12, f.Component3AsCalendar.Month);
			assertEquals(24, f.Component3AsCalendar.Day);
			assertEquals("131415", f.getComponent4());
			assertEquals(1, f.Component4AsCalendar.Hour);
			assertEquals(14, f.Component4AsCalendar.Minute);
			assertEquals(15, f.Component4AsCalendar.Second);
		}

	}
}