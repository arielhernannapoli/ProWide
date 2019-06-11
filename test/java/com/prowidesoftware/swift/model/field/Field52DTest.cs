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
	/// Test for Field52D and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field52DTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("52D", "//SC1111111\r\nXXX XX\r\n111 XXXXXXXXX XX XXXXXX", "/D/SC1111111");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test52D_issue6()
		public virtual void test52D_issue6()
		{
			Field52D f = new Field52D("//SC1111111\r\n" + "XXX XX\r\n" + "111 XXXXXXXXX XX XXXXXX");
			assertNull(f.Component1);
			assertEquals("/SC1111111", f.Component2);
			assertEquals("XXX XX", f.Component3);
			assertEquals("111 XXXXXXXXX XX XXXXXX", f.Component4);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test52D_2()
		public virtual void test52D_2()
		{
			Field52D f = new Field52D("/D/SC1111111\r\n");
			assertEquals("D", f.Component1);
			assertEquals("SC1111111", f.Component2);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test52D_3()
		public virtual void test52D_3()
		{
			Field52D f = new Field52D("/D2/SC1111111\r\n");
			assertNull(f.Component1);
			assertEquals("D2/SC1111111", f.Component2);
		}

	}
}