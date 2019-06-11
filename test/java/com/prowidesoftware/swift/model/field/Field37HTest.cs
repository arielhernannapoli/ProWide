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
	import static org.junit.Assert.*;

	using Test = org.junit.Test;

	public class Field37HTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("37H", "D9,75", "DN123");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse37H_1() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse37H_1()
		{
			Field37H f = new Field37H("D123");
			assertNotNull("Parse of field failed", f);
			assertEquals("D", f.Component1);
			assertNull(f.Component2);
			assertEquals("123", f.getComponent(3));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse37H_2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse37H_2()
		{
			Field37H f = new Field37H("DN123");
			assertNotNull("Parse of field failed", f);
			assertEquals("D", f.Component1);
			assertEquals("N", f.Component2);
			assertEquals("123", f.getComponent(3));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse37H_3() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse37H_3()
		{
			Field37H f = new Field37H("HelloWorld123");
			assertNotNull("Parse of field failed", f);
			assertEquals("HelloWorl", f.Component1);
			assertEquals("d", f.Component2);
			assertEquals("123", f.getComponent(3));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse37H_4() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse37H_4()
		{
			Field37H f = new Field37H("DN");
			assertNotNull("Parse of field failed", f);
			assertEquals("D", f.Component1);
			assertEquals("N", f.Component2);
			assertNull(f.getComponent(3));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse37H_5() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse37H_5()
		{
			Field37H f = new Field37H("HelloWorld");
			assertNotNull("Parse of field failed", f);
			assertEquals("HelloWorl", f.Component1);
			assertEquals("d", f.Component2);
			assertNull(f.getComponent(3));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse37H_6() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse37H_6()
		{
			Field37H f = new Field37H("D9,75");
			assertNotNull("Parse of field failed", f);
			assertEquals("D", f.Component1);
			assertNull(f.Component2);
			assertEquals("9,75", f.getComponent(3));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFromMt935() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFromMt935()
		{
			Field37H f = new Field37H("D9,75\n");
			assertEquals("D", f.Component1);
			assertNull(f.Component2);
			assertEquals(new decimal("9.75"), f.getComponentAs(3, typeof(Number)));
		}

	}
}