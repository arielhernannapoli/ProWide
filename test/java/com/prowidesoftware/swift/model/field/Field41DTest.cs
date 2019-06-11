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
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Before = org.junit.Before;
	using Test = org.junit.Test;

	/// 
	/// <summary>
	/// @author www.prowidesoftware.com
	/// </summary>
	public class Field41DTest : AbstractFieldTest
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(Field41DTest.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(Field41DTest).FullName);
		internal Field41D f = null;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setup()
		public virtual void setup()
		{
			f = null;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("41D", "ANY BANK\r\nBY NEGOTIATION", "A\r\nB\r\nC\r\nD\r\nE");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse1()
		public virtual void testParse1()
		{
			f = new Field41D("ANY BANK\r\n" + "BY NEGOTIATION\n");
			assertNotNull(f.Component1);
			assertNotNull(f.Component5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse2()
		public virtual void testParse2()
		{
			f = new Field41D("A");
			assertEquals("A", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse3()
		public virtual void testParse3()
		{
			f = new Field41D("A\r\nB");
			assertEquals("A", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertEquals("B", f.Component5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse4()
		public virtual void testParse4()
		{
			f = new Field41D("A\r\nB\r\nC");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertEquals("C", f.Component5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse5()
		public virtual void testParse5()
		{
			f = new Field41D("A\r\nB\r\nC\r\nD");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertEquals("C", f.Component3);
			assertNull(f.Component4);
			assertEquals("D", f.Component5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse6()
		public virtual void testParse6()
		{
			f = new Field41D("A\r\nB\r\nC\r\nD\r\nE");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertEquals("C", f.Component3);
			assertEquals("D", f.Component4);
			assertEquals("E", f.Component5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse7()
		public virtual void testParse7()
		{
			f = new Field41D("A\r\nB\r\nC\r\nD\r\nE\r\nFOO");
			assertEquals("A", f.Component1);
			assertEquals("B", f.Component2);
			assertEquals("C", f.Component3);
			assertEquals("D", f.Component4);
			assertEquals("E", f.Component5);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testName() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testName()
		{
			string s = "c1\nc5";
			Field41D f = new Field41D(s);
			assertFalse(StringUtils.isEmpty(f.Component5));
		}

	}
}