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
	/// Test for field 22C.
	/// 
	/// @author sebastian
	/// @since 7.9.3
	/// </summary>
	public class Field22CTest : AbstractFieldTest
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(Field22CTest.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(Field22CTest).FullName);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("22C", "AAAABB122C4CCCCDD", "CNFM2L0007GEBABB");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse22C()
		public virtual void testParse22C()
		{
			Field22C f = null;

			f = new Field22C((string)null);
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field22C("");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field22C("AAAA");
			assertEquals("AAAA", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field22C("AAAABB");
			assertEquals("AAAA", f.Component1);
			assertEquals("BB", f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field22C("AAAABB1234");
			assertEquals("AAAA", f.Component1);
			assertEquals("BB", f.Component2);
			assertEquals("1234", f.getComponent3());
			assertNull(f.Component4);
			assertNull(f.Component5);

			f = new Field22C("AAAABB1234CCCC");
			assertEquals("AAAA", f.Component1);
			assertEquals("BB", f.Component2);
			assertEquals("1234", f.getComponent3());
			assertEquals("CCCC", f.Component4);
			assertNull(f.Component5);

			f = new Field22C("AAAABB1234CCCCDD");
			assertEquals("AAAA", f.Component1);
			assertEquals("BB", f.Component2);
			assertEquals("1234", f.getComponent3());
			assertEquals("CCCC", f.Component4);
			assertEquals("DD", f.Component5);
		}

	}
}