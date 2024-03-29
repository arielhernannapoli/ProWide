﻿/*
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

	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// Test for Field59F and similar fields.
	/// 
	/// @since 7.8.9
	/// </summary>
	public class Field59FTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("59F", "/MT27SBMT59999999026977001\n" + "1/FOO LTD\n" + "2/99 FOO RD\n" + "2/GZIRA\n" + "3/MT/MALTA", "/CR79015202220005614288\n" + "1/Name 1\n" + "2/Address 1\n" + "2/Address 2\n" + "3/DZ/1000");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue()
		public virtual void testGetValue()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field59F f = new Field59F("/MT27SBMT59999999026977001\n" + "1/FOO LTD\n" + "2/99 FOO RD\n" + "2/GZIRA\n" + "3/MT/MALTA");
			Field59F f = new Field59F("/MT27SBMT59999999026977001\n" + "1/FOO LTD\n" + "2/99 FOO RD\n" + "2/GZIRA\n" + "3/MT/MALTA");
			assertEquals("MT27SBMT59999999026977001", f.Component1);

			assertTrue(f.contains(1));
			assertEquals("1", f.getComponent2());
			assertEquals("FOO LTD", f.Component3);
			assertEquals("FOO LTD", f.detailsByNumber(1)[0]);

			assertTrue(f.contains(2));
			assertEquals("2", f.getComponent4());
			assertEquals("99 FOO RD", f.Component5);
			assertEquals("99 FOO RD", f.detailsByNumber(2)[0]);
			assertEquals("2", f.getComponent6());
			assertEquals("GZIRA", f.Component7);
			assertEquals("GZIRA", f.detailsByNumber(2)[1]);
			assertEquals(2, f.detailsByNumber(2).Count);

			assertTrue(f.contains(3));
			assertEquals("3", f.getComponent8());
			assertEquals("MT/MALTA", f.Component9);
			assertEquals("MT/MALTA", f.detailsByNumber(3)[0]);

			assertFalse(f.contains(4));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue2()
		public virtual void testGetValue2()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Field59F f = new Field59F("/CR79015202220005614288\n" + "1/Name 1\n" + "2/Address 1\n" + "2/Address 2\n" + "3/DZ/1000");
			Field59F f = new Field59F("/CR79015202220005614288\n" + "1/Name 1\n" + "2/Address 1\n" + "2/Address 2\n" + "3/DZ/1000");
				assertEquals("CR79015202220005614288", f.Component1);
				assertEquals("1", f.getComponent2());
				assertEquals("Name 1", f.Component3);
				assertEquals("2", f.getComponent4());
				assertEquals("Address 1", f.Component5);
				assertEquals("2", f.getComponent6());
				assertEquals("Address 2", f.Component7);
				assertEquals("3", f.getComponent8());
				assertEquals("DZ/1000", f.Component9);
		}

	}
}