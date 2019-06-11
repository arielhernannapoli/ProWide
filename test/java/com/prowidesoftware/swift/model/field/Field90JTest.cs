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
	import static org.junit.Assert.assertTrue;

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;

	/// <summary>
	/// Test for Field90J and similar fields.
	/// Pattern: ":S//S/SN/SN"
	/// 
	/// @since 6.0
	/// </summary>
	public class Field90JTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("90J", ":DDDD//EEEEEEEE/FFF123/GGG456");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField90JString()
		public virtual void testField90JString()
		{
			Field90J f = null;

			f = new Field90J("");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":/");
			//assertTrue(StringUtils.isBlank(f.getComponent1()));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J("://");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":///");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":DDDD");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":DDDD//");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":DDDD//EEEEEEEE");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":DDDD//EEEEEEEE/");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":DDDD//EEEEEEEE/FFF");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFF", f.getComponent3());
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":DDDD//EEEEEEEE/FFF123");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFF", f.getComponent3());
			assertEquals("123", f.getComponent4());
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":DDDD//EEEEEEEE/FFF123/");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFF", f.getComponent3());
			assertEquals("123", f.getComponent4());
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":DDDD//EEEEEEEE/FFF123/GGG");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFF", f.getComponent3());
			assertEquals("123", f.getComponent4());
			assertEquals("GGG", f.getComponent5());
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field90J(":DDDD//EEEEEEEE/FFF123/GGG456");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFF", f.getComponent3());
			assertEquals("123", f.getComponent4());
			assertEquals("GGG", f.getComponent5());
			assertEquals("456", f.getComponent6());
		}

	}
}