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
	/// Test for Field37A and similar fields.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.4
	/// </summary>
	public class Field37ATest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("37A", "1234//131201AFOO/ABC");
		}

		/// <summary>
		/// N[//<DATE2>cS][/S]
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField37A()
		public virtual void testField37A()
		{
			Field37A f = new Field37A((string)null);
			assertNull(f.getComponent1());
			assertNull(f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.Component5);

			f = new Field37A("");
			assertNull(f.getComponent1());
			assertNull(f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.Component5);

			f = new Field37A("1234");
			assertEquals("1234", f.getComponent1());
			assertNull(f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.Component5);

			f = new Field37A("1234//");
			assertEquals("1234", f.getComponent1());
			assertNull(f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.Component5);

			f = new Field37A("1234//131201");
			assertEquals("1234", f.getComponent1());
			assertEquals("131201", f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.Component5);

			f = new Field37A("1234//131201A");
			assertEquals("1234", f.getComponent1());
			assertEquals("131201", f.getComponent2());
			assertEquals("A", f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.Component5);

			f = new Field37A("1234//131201AFOO");
			assertEquals("1234", f.getComponent1());
			assertEquals("131201", f.getComponent2());
			assertEquals("A", f.Component3);
			assertEquals("FOO", f.getComponent4());
			assertNull(f.Component5);

			f = new Field37A("1234//131201AFOO/ABC");
			assertEquals("1234", f.getComponent1());
			assertEquals("131201", f.getComponent2());
			assertEquals("A", f.Component3);
			assertEquals("FOO", f.getComponent4());
			assertEquals("ABC", f.Component5);
		}

	}
}