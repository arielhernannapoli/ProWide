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
	/// Test for Field32K and similar fields.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class Field32KTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("32K", "D123AAAEUR1234,56", "123AAAEUR1234,56");
		}

		/// <summary>
		/// cNS<CUR>N
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField32K()
		public virtual void testField32K()
		{
			Field32K f = new Field32K((string)null);
			assertNull(f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());

			f = new Field32K("");
			assertNull(f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());

			f = new Field32K("D");
			assertEquals("D", f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());

			f = new Field32K("D123");
			assertEquals("D", f.Component1);
			assertEquals("123", f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());

			f = new Field32K("D123EUR");
			assertEquals("D", f.Component1);
			assertEquals("123", f.getComponent2());
			assertNull(f.Component3);
			assertEquals("EUR", f.getComponent4());
			assertNull(f.getComponent5());

			f = new Field32K("D123AAAEUR");
			assertEquals("D", f.Component1);
			assertEquals("123", f.getComponent2());
			assertEquals("AAA", f.Component3);
			assertEquals("EUR", f.getComponent4());
			assertNull(f.getComponent5());

			f = new Field32K("D123AAAEUR1234,56");
			assertEquals("D", f.Component1);
			assertEquals("123", f.getComponent2());
			assertEquals("AAA", f.Component3);
			assertEquals("EUR", f.getComponent4());
			assertEquals("1234,56", f.getComponent5());
		}

	}
}