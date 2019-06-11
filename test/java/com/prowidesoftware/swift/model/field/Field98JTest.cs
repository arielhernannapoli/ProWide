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
	/// Test for field 98J and similar fields.
	/// 
	/// @author sebastian
	/// @since 7.9.3
	/// </summary>
	public class Field98JTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("98J", ":FOO//121212121111/ABCDUSAAXXX");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField98JString()
		public virtual void testField98JString()
		{
			Field98J f = null;

			f = new Field98J("");
			assertNull(f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field98J(":");
			assertNull(f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field98J("//");
			assertNull(f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field98J("://");
			assertNull(f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field98J(":abc//");
			assertEquals("abc", f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field98J(":abc//11111111");
			assertEquals("abc", f.Component1);
			assertEquals("11111111", f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field98J(":abc//111111112222");
			assertEquals("abc", f.Component1);
			assertEquals("11111111", f.getComponent2());
			assertEquals("2222", f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field98J(":abc//111111112222/foo");
			assertEquals("abc", f.Component1);
			assertEquals("11111111", f.getComponent2());
			assertEquals("2222", f.getComponent3());
			assertEquals("foo", f.getComponent4());
		}

	}
}