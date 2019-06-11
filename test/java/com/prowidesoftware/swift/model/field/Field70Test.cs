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
	/// Test for Field70 and similar fields.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class Field70Test : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("70", "a\nb\nc\nd");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField70()
		public virtual void testField70()
		{
			Field70 f = new Field70((string)null);
			assertNull(f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);

			f = new Field70("a");
			assertEquals("a", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);

			f = new Field70("a\nb");
			assertEquals("a", f.Component1);
			assertEquals("b", f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);

			f = new Field70("a\nb\nc");
			assertEquals("a", f.Component1);
			assertEquals("b", f.Component2);
			assertEquals("c", f.Component3);
			assertNull(f.Component4);

			f = new Field70("a\nb\nc\nd");
			assertEquals("a", f.Component1);
			assertEquals("b", f.Component2);
			assertEquals("c", f.Component3);
			assertEquals("d", f.Component4);
		}

	}
}