﻿using System;

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
	/// Test for Field69D and similar fields.
	/// Pattern: ":S//<DATE4><TIME2>/S"
	/// 
	/// @since 6.0
	/// </summary>
	public class Field69DTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("69D", ":ABC//20111224131415/DEF");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse69D()
		public virtual void testParse69D()
		{
			Field69D f = null;

			f = new Field69D((string)null);
			assertNull(f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.Component4);

			f = new Field69D("ABC");
			assertEquals("ABC", f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.Component4);

			f = new Field69D(":ABC");
			assertEquals("ABC", f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.Component4);

			f = new Field69D("ABC//");
			assertEquals("ABC", f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.Component4);

			f = new Field69D(":ABC//");
			assertEquals("ABC", f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.Component4);

			f = new Field69D(":ABC//20111224");
			assertEquals("ABC", f.Component1);
			assertEquals("20111224", f.getComponent2());
			assertEquals(2011, f.Component2AsCalendar.Year);
			assertEquals(12, f.Component2AsCalendar.Month);
			assertEquals(24, f.Component2AsCalendar.Day);
			assertNull(f.getComponent3());
			assertNull(f.Component4);

			f = new Field69D(":ABC//20111224131415");
			assertEquals("ABC", f.Component1);
			assertEquals("20111224", f.getComponent2());
			assertEquals(2011, f.Component2AsCalendar.Year);
			assertEquals(12, f.Component2AsCalendar.Month);
			assertEquals(24, f.Component2AsCalendar.Day);
			assertEquals("131415", f.getComponent3());
			assertEquals(1, f.Component3AsCalendar.Hour);
			assertEquals(14, f.Component3AsCalendar.Minute);
			assertEquals(15, f.Component3AsCalendar.Second);
			assertNull(f.Component4);

			f = new Field69D(":ABC//20111224131415/DEF");
			assertEquals("ABC", f.Component1);
			assertEquals("20111224", f.getComponent2());
			assertEquals(2011, f.Component2AsCalendar.Year);
			assertEquals(12, f.Component2AsCalendar.Month);
			assertEquals(24, f.Component2AsCalendar.Day);
			assertEquals("131415", f.getComponent3());
			assertEquals(13, f.Component3AsCalendar.get(DateTime.HOUR_OF_DAY));
			assertEquals(14, f.Component3AsCalendar.Minute);
			assertEquals(15, f.Component3AsCalendar.Second);
			assertEquals("DEF", f.Component4);
		}

	}
}