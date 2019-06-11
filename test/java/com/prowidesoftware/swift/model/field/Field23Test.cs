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
	/// Test for Field23 and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field23Test : AbstractFieldTest
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(Field23Test.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(Field23Test).FullName);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("23", "abcd/efgh/ijk/VEF//aaa");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse23()
		public virtual void testParse23()
		{
			Field23 f = null;

			f = new Field23((string)null);
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field23("");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field23("abcd");
			assertEquals("abcd", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field23("abcd/");
			assertEquals("abcd", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field23("abcd/efgh");
			assertEquals("abcd", f.Component1);
			assertEquals("efgh", f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field23("abcd/efgh/");
			assertEquals("abcd", f.Component1);
			assertEquals("efgh", f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field23("abcd/efgh/ijk");
			assertEquals("abcd", f.Component1);
			assertEquals("efgh", f.Component2);
			assertEquals("ijk", f.Component3);
			assertNull(f.getComponent4());

			f = new Field23("abcd/efgh/ijk/");
			assertEquals("abcd", f.Component1);
			assertEquals("efgh", f.Component2);
			assertEquals("ijk", f.Component3);
			assertNull(f.getComponent4());

			f = new Field23("abcd/efgh/ijk/VEF");
			assertEquals("abcd", f.Component1);
			assertEquals("efgh", f.Component2);
			assertEquals("ijk", f.Component3);
			assertEquals("VEF", f.getComponent4());

			f = new Field23("abcd/efgh/ijk/VEF/");
			assertEquals("abcd", f.Component1);
			assertEquals("efgh", f.Component2);
			assertEquals("ijk", f.Component3);
			assertEquals("VEF/", f.getComponent4());

			f = new Field23("abcd/efgh/ijk/VEF//");
			assertEquals("abcd", f.Component1);
			assertEquals("efgh", f.Component2);
			assertEquals("ijk", f.Component3);
			assertEquals("VEF//", f.getComponent4());

			f = new Field23("abcd/efgh/ijk/VEF//aaa");
			assertEquals("abcd", f.Component1);
			assertEquals("efgh", f.Component2);
			assertEquals("ijk", f.Component3);
			assertEquals("VEF//aaa", f.getComponent4());
		}

	}
}