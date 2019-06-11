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
	/// Test for Field98F and similar fields.
	/// :S/[S]/S<TIME2>
	/// 
	/// @since 6.0
	/// </summary>
	public class Field98FTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("98F", ":RDDT//ONGO160000", ":abc/def/ggggggggfffaaaaaa");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField98FString()
		public virtual void testField98FString()
		{
			Field98F f = null;

			f = new Field98F("");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field98F(":");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field98F("/");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field98F("//");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field98F("://");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field98F(":/");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field98F(":abc/");
			assertEquals("abc", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field98F(":abc/def");
			assertEquals("abc", f.Component1);
			assertEquals("def", f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field98F(":abc/def/ggg");
			assertEquals("abc", f.Component1);
			assertEquals("def", f.Component2);
			assertEquals("ggg", f.Component3);
			assertNull(f.getComponent4());

			f = new Field98F(":abc/def/aaaagggggg");
			assertEquals("abc", f.Component1);
			assertEquals("def", f.Component2);
			assertEquals("aaaa", f.Component3);
			assertEquals("gggggg", f.getComponent4());

			f = new Field98F(":abc/def/ggggggggaaaaaa");
			assertEquals("abc", f.Component1);
			assertEquals("def", f.Component2);
			assertEquals("gggggggg", f.Component3);
			assertEquals("aaaaaa", f.getComponent4());

			f = new Field98F(":abc/def/ggggggggfffaaaaaa");
			assertEquals("abc", f.Component1);
			assertEquals("def", f.Component2);
			assertEquals("ggggggggfff", f.Component3);
			assertEquals("aaaaaa", f.getComponent4());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse()
		public virtual void testParse()
		{
			Field98F f = new Field98F(":RDDT//ONGO160000");
			assertEquals("RDDT", f.Component1);
			assertNull(f.Component2);
			assertEquals("ONGO", f.Component3);
			assertEquals("160000", f.getComponent4());
		}

	}
}