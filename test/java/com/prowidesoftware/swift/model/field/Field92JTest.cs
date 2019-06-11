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
	/// Test for Field92J and similar fields.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class Field92JTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("92J", ":DDDD/EEEEEEEE/FFFF/EUR1234,56/AAAA");
		}

		/// <summary>
		/// ':'4!c'/'[8c]'/'4!c'/'<CUR><AMOUNT>15['/'4!c]
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField92JString()
		public virtual void testField92JString()
		{
			Field92J f = null;

			f = new Field92J("");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":/");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J("://");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":///");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":////");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/EEEEEEEE");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/EEEEEEEE/");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertTrue(StringUtils.isBlank(f.Component3));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/EEEEEEEE/FFFF");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD//FFFF");
			assertEquals("DDDD", f.Component1);
			assertTrue(StringUtils.isBlank(f.Component2));
			assertEquals("FFFF", f.Component3);
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/EEEEEEEE/FFFF/EUR");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertEquals("EUR", f.getComponent4());
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/EEEEEEEE/FFFF/EUR1234");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertEquals("EUR", f.getComponent4());
			assertEquals("1234", f.getComponent5());
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/EEEEEEEE/FFFF/EUR1234,");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertEquals("EUR", f.getComponent4());
			assertEquals("1234,", f.getComponent5());
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/EEEEEEEE/FFFF/EUR1234,56");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertEquals("EUR", f.getComponent4());
			assertEquals("1234,56", f.getComponent5());
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/EEEEEEEE/FFFF/EUR1234,56/");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertEquals("EUR", f.getComponent4());
			assertEquals("1234,56", f.getComponent5());
			assertTrue(StringUtils.isBlank(f.Component6));

			f = new Field92J(":DDDD/EEEEEEEE/FFFF/EUR1234,56/AAAA");
			assertEquals("DDDD", f.Component1);
			assertEquals("EEEEEEEE", f.Component2);
			assertEquals("FFFF", f.Component3);
			assertEquals("EUR", f.getComponent4());
			assertEquals("1234,56", f.getComponent5());
			assertEquals("AAAA", f.Component6);
		}

	}
}