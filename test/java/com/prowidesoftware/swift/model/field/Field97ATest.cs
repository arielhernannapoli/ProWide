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
	/// Test for Field97A and similar fields.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class Field97ATest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("97A", ":abc//def//ggg");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField97AString()
		public virtual void testField97AString()
		{
			Field97A f = null;

			f = new Field97A("");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));

			f = new Field97A(":");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));

			f = new Field97A("/");
			assertEquals("/", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));

			f = new Field97A("//");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));

			f = new Field97A("://");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));

			f = new Field97A(":/");
			assertEquals("/", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));

			f = new Field97A("///");
			assertEquals("/", f.Component2);
			assertTrue(StringUtils.isBlank(f.Component1));

			f = new Field97A(":///");
			assertEquals("/", f.Component2);
			assertTrue(StringUtils.isBlank(f.Component1));

			f = new Field97A(":abc//");
			assertEquals("abc", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));

			f = new Field97A(":abc//def");
			assertEquals("abc", f.Component1);
			assertEquals("def", f.Component2);

			f = new Field97A(":abc//def/ggg");
			assertEquals("abc", f.Component1);
			assertEquals("def/ggg", f.Component2);

			f = new Field97A(":abc//def/d/ggg");
			assertEquals("abc", f.Component1);
			assertEquals("def/d/ggg", f.Component2);

			f = new Field97A(":abc//def//ggg");
			assertEquals("abc", f.Component1);
			assertEquals("def//ggg", f.Component2);
		}

	}
}