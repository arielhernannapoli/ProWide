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
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	/// <summary>
	/// Test for Field32B and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field32BTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("32B", "USD123");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField32B()
		public virtual void testField32B()
		{
			Field32B f = new Field32B("USD123");
			assertEquals("USD", f.getComponent1());
			assertEquals("123", f.getComponent2());
			assertEquals(new double?(123), new double?((double)f.Component2AsNumber));

			f = new Field32B("123");
			assertNull(f.getComponent1());
			assertEquals("123", f.getComponent2());
			assertEquals(new double?(123), new double?((double)f.Component2AsNumber));

			f = new Field32B("USD");
			assertEquals("USD", f.getComponent1());
			assertNull(f.getComponent2());
			assertNull(f.Component2AsNumber);

			f = new Field32B("USD123,");
			assertEquals("USD", f.getComponent1());
			assertEquals("123,", f.getComponent2());
			assertEquals(new double?(123), new double?((double)f.Component2AsNumber));

			f = new Field32B("USD123,45");
			assertEquals("USD", f.getComponent1());
			assertEquals("123,45", f.getComponent2());
			assertEquals(new double?(123.45), new double?((double)f.Component2AsNumber));
		}

	}
}