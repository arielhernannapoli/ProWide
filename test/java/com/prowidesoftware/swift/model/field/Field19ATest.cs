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

	/// <summary>
	/// Test for Field19A and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field19ATest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("19A", ":abc//errr123", ":SETT//CHF178626,04");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField19AString()
		public virtual void testField19AString()
		{
			Field19A f = null;

			f = new Field19A((string)null);
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A("");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A("/");
			assertEquals("/", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A("//");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A("://");
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A(":/");
			assertEquals("/", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A("///");
			assertNull(f.Component1);
			assertNull(f.Component2); // the expected component is a letter, so it is not filled with the slash
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A(":///");
			assertNull(f.Component1);
			assertNull(f.Component2); // the expected component is a letter, so it is not filled with the slash
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A(":abc//");
			assertEquals("abc", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A(":abc//e");
			assertEquals("abc", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A(":abc//er");
			assertEquals("abc", f.Component1);
			assertNull(f.Component2);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A(":abc//err");
			assertEquals("abc", f.Component1);
			assertNull(f.Component2);
			assertEquals("err", f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A(":abc//errr");
			assertEquals("abc", f.Component1);
			assertEquals("e", f.Component2);
			assertEquals("rrr", f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A(":abc//errrxx");
			assertEquals("abc", f.Component1);
			assertEquals("e", f.Component2);
			assertEquals("rrrxx", f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field19A(":abc//errr123");
			assertEquals("abc", f.Component1);
			assertEquals("e", f.Component2);
			assertEquals("rrr", f.getComponent3());
			assertEquals(new decimal(123), new decimal((double)f.Component4AsNumber));

			f = new Field19A(":abc//errr123,");
			assertEquals("abc", f.Component1);
			assertEquals("e", f.Component2);
			assertEquals("rrr", f.getComponent3());
			assertEquals(new decimal(123), new decimal((double)f.Component4AsNumber));

			f = new Field19A(":abc//errr123,45");
			assertEquals("abc", f.Component1);
			assertEquals("e", f.Component2);
			assertEquals("rrr", f.getComponent3());
			assertEquals(new decimal(123.45), new decimal((double)f.Component4AsNumber));

			f = new Field19A(":abc//errr123,45,");
			assertEquals("abc", f.Component1);
			assertEquals("e", f.Component2);
			assertEquals("rrr", f.getComponent3());
			//log.fine("number:"+f.getComponent4().doubleValue());
			//assertNull(f.getComponent4());

			f = new Field19A(":abc//errr123.45");
			assertEquals("abc", f.Component1);
			assertEquals("e", f.Component2);
			assertEquals("rrr", f.getComponent3());
			//log.fine("number:"+f.getComponent4().doubleValue());
			//assertNull(f.getComponent4());

			f = new Field19A(":abc//errr123aaa");
			assertEquals("abc", f.Component1);
			assertEquals("e", f.Component2);
			assertEquals("rrr", f.getComponent3());
			//assertNull(f.getComponent4());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIssueAmountResolver() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testIssueAmountResolver()
		{
			Field19A f = new Field19A("SETT//CHF178626,04");
			object n = f.getComponentAs(4, typeof(Number));
			assertNotNull(n);
		}

	}
}