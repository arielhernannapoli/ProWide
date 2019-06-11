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
	/// Test for Field92M and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field92MTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("92M", ":DDDD//EEEEEEEE123/FFFF");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField92MString()
		public virtual void testField92MString()
		{
			Field92M f = null;

			f = new Field92M("");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field92M(":");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field92M(":/");
			//assertTrue(StringUtils.isBlank(f.getComponent1()));
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field92M("://");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field92M(":///");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field92M(":DDDD");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field92M(":DDDD//");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field92M(":DDDD//EEEEEEEE");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.getComponent2());
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field92M(":DDDD//EEEEEEEE123/");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.getComponent2());
			assertEquals("123", f.getComponent3());
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field92M(":DDDD//EEEEEEEE123/FFFF");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.getComponent2());
			assertEquals("123", f.getComponent3());
			assertEquals("FFFF", f.getComponent4());
		}

	}
}