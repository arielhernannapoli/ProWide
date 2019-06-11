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
	import static org.junit.Assert.assertTrue;

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;

	/// <summary>
	/// Test for Field93C and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field93CTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("93C", ":DDDD//EEEEEEEE/FFFF/E1234");
		}

		/// <summary>
		/// :S//S/S/[c]N
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField93CString()
		public virtual void testField93CString()
		{
			Field93C f = null;

			f = new Field93C("");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":/");
			//assertTrue(StringUtils.isBlank(f.getComponent1()));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C("://");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":///");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":////");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":DDDD");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":DDDD//");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":DDDD//EEEEEEEE");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":DDDD//EEEEEEEE/");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":DDDD//");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":DDDD//EEEEEEEE/FFFF");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertTrue(StringUtils.isBlank(f.Component4));
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":DDDD//EEEEEEEE/FFFF/E");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertEquals("E", f.Component4);
			assertTrue(StringUtils.isBlank(f.getComponent5()));

			f = new Field93C(":DDDD//EEEEEEEE/FFFF/E1234");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertEquals("E", f.Component4);
			assertEquals("1234", f.getComponent5());
		}

	}
}