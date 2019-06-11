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
	/// Test for Field70E and similar fields.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class Field70ETest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("70E", ":2134//goobar", "://goobar");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField70EString()
		public virtual void testField70EString()
		{
			Field70E f = new Field70E();

			f = new Field70E(":2134//");
			assertEquals("2134", f.Component1);

			f = new Field70E(":2134//goobar");
			assertEquals("2134", f.Component1);
			assertEquals("goobar", f.Component2);

			f = new Field70E("://goobar");
			assertEquals("goobar", f.Component2);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField70EString2()
		public virtual void testField70EString2()
		{
			Field70E f = new Field70E("://goobar");
			assertEquals("goobar", f.Component2);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField70ELines()
		public virtual void testField70ELines()
		{
			Field70E f = new Field70E("://goobar");
			assertEquals("goobar", f.Component2);
			assertNull(f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);
			assertNull(f.Component7);
			assertNull(f.Component8);
			assertNull(f.Component9);
			assertNull(f.Component10);
			assertNull(f.Component11);

			f = new Field70E("://goobar\nAAAA");
			assertEquals("goobar", f.Component2);
			assertEquals("AAAA", f.Component3);
			assertNull(f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);
			assertNull(f.Component7);
			assertNull(f.Component8);
			assertNull(f.Component9);
			assertNull(f.Component10);
			assertNull(f.Component11);

			f = new Field70E("://goobar\nAAAA\nBBBB");
			assertEquals("goobar", f.Component2);
			assertEquals("AAAA", f.Component3);
			assertEquals("BBBB", f.Component4);
			assertNull(f.Component5);
			assertNull(f.Component6);
			assertNull(f.Component7);
			assertNull(f.Component8);
			assertNull(f.Component9);
			assertNull(f.Component10);
			assertNull(f.Component11);

			//remaining lines are ignored by parser
			f = new Field70E("://goobar\nAAAA\nBBBB\nCCCC\nDDDD\nEEEE\nFFFF\nGGGG\nHHHH\nIIII\nJJJJ\nKKKK");
			assertEquals("goobar", f.Component2);
			assertEquals("AAAA", f.Component3);
			assertEquals("BBBB", f.Component4);
			assertEquals("CCCC", f.Component5);
			assertEquals("DDDD", f.Component6);
			assertEquals("EEEE", f.Component7);
			assertEquals("FFFF", f.Component8);
			assertEquals("GGGG", f.Component9);
			assertEquals("HHHH", f.Component10);
			assertEquals("IIII", f.Component11);
		}

	}
}