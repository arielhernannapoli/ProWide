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

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	/// <summary>
	/// Test for Field98D and similar fields.
	/// <DATE4><TIME2>[,S][/[c]<TIME3>]
	/// 
	/// @author sebastian
	/// @since 7.8.8
	/// </summary>
	public class Field98DTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("98D", "20150827121212/a10");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField98D()
		public virtual void testField98D()
		{
			Field98D f = null;

			f = new Field98D("");
			assertNull(f.getComponent1());
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());
			assertEquals("", f.Value);

			f = new Field98D("20150827");
			assertEquals("20150827", f.getComponent1());
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());
			assertEquals("20150827", f.Value);

			f = new Field98D("20150827121212");
			assertEquals("20150827", f.getComponent1());
			assertEquals("121212", f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());
			assertEquals("20150827121212", f.Value);

			f = new Field98D("20150827121212,FOO");
			assertEquals("20150827", f.getComponent1());
			assertEquals("121212", f.getComponent2());
			assertEquals("FOO", f.getComponent3());
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());
			assertEquals("20150827121212,FOO", f.Value);

			f = new Field98D("20150827121212,FOO/a");
			assertEquals("20150827", f.getComponent1());
			assertEquals("121212", f.getComponent2());
			assertEquals("FOO", f.getComponent3());
			assertEquals("a", f.getComponent4());
			assertNull(f.getComponent5());
			assertEquals("20150827121212,FOO/a", f.Value);

			f = new Field98D("20150827121212,FOO/a");
			assertEquals("20150827", f.getComponent1());
			assertEquals("121212", f.getComponent2());
			assertEquals("FOO", f.getComponent3());
			assertEquals("a", f.getComponent4());
			assertNull(f.getComponent5());
			assertEquals("20150827121212,FOO/a", f.Value);

			f = new Field98D("20150827121212,FOO/a1020");
			assertEquals("20150827", f.getComponent1());
			assertEquals("121212", f.getComponent2());
			assertEquals("FOO", f.getComponent3());
			assertEquals("a", f.getComponent4());
			assertEquals("1020", f.getComponent5());
			assertEquals("20150827121212,FOO/a1020", f.Value);

			f = new Field98D("20150827121212,FOO/a10");
			assertEquals("20150827", f.getComponent1());
			assertEquals("121212", f.getComponent2());
			assertEquals("FOO", f.getComponent3());
			assertEquals("a", f.getComponent4());
			assertEquals("10", f.getComponent5());
			assertEquals("20150827121212,FOO/a10", f.Value);

			f = new Field98D("20150827121212/a10");
			assertEquals("20150827", f.getComponent1());
			assertEquals("121212", f.getComponent2());
			assertNull(f.getComponent3());
			assertEquals("a", f.getComponent4());
			assertEquals("10", f.getComponent5());
			assertEquals("20150827121212/a10", f.Value);
		}

	}
}