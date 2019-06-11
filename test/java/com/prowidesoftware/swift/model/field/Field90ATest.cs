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
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	public class Field90ATest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("90A", ":AAAA//BBBB/N123", ":AAAA//BBBB/123", ":DEAL//YIEL/N1234,5");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse90A_1() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse90A_1()
		{
			Field90A f = new Field90A(":AAAA//BBBB/N123");
			assertNotNull("Parse of field failed", f);
			assertEquals("AAAA", f.Component1);
			assertEquals("BBBB", f.Component2);
			assertEquals("N", f.Component3);
			assertEquals("123", f.getComponent4());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse90A_2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse90A_2()
		{
			Field90A f = new Field90A(":AAAA//BBBB/123");
			assertNotNull("Parse of field failed", f);
			assertEquals("AAAA", f.Component1);
			assertEquals("BBBB", f.Component2);
			assertNull(f.Component3);
			assertEquals("123", f.getComponent4());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse90A_3() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse90A_3()
		{
			Field90A f = new Field90A(":DEAL//YIEL/N1234,5");
			assertNotNull("Parse of field failed", f);

			assertEquals("DEAL", f.Qualifier);
			assertEquals("DEAL", f.getComponent(Field90A.QUALIFIER));
			assertEquals("DEAL", f.Component1);

			assertEquals("YIEL", f.PercentageTypeCode);
			assertEquals("YIEL", f.getComponent(Field90A.PERCENTAGE_TYPE_CODE));
			assertEquals("YIEL", f.Component2);

			/*
			 * get the sign code, if not present this methods will return null
			 */
			assertEquals("N", f.Sign);
			assertEquals("N", f.getComponent(Field90A.SIGN));
			assertEquals("N", f.Component3);

			assertEquals("1234,5", f.getPrice());
			assertEquals("1234,5", f.getComponent(Field90A.PRICE));
			assertEquals("1234,5", f.getComponent4());
			assertEquals(new decimal("1234.5"), f.PriceAsNumber);
		}

	}
}