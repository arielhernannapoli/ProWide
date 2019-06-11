using System;

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
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;

	/// <summary>
	/// Test for Field11R and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field11RTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("11R", "100\n091019", "100\n091019\n1234123456");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSerialization2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSerialization2()
		{
			Field11R field11r = new Field11R();
			field11r.Component1 = "103";
			field11r.setComponent2(new DateTime());
			field11r.setComponent3(1);
			assertFalse(StringUtils.isBlank(field11r.asTag().Value));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParser()
		public virtual void testParser()
		{
			Field11R f = new Field11R((string)null);
			assertNull(f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field11R("100");
			assertEquals("100", f.Component1);
			assertEquals("100", f.MT);
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field11R("100\n091019");
			assertEquals("100", f.Component1);
			assertEquals("100", f.MT);
			assertEquals("091019", f.getComponent2());
			assertEquals(2009, f.Component2AsCalendar.Year);
			assertEquals(10, f.Component2AsCalendar.Month + 1); //MONTH is zero based at Calendar
			assertEquals(19, f.Component2AsCalendar.Day);
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field11R("100\n091019\nabc");
			assertEquals("100", f.Component1);
			assertEquals("100", f.MT);
			assertEquals("091019", f.getComponent2());
			assertEquals(2009, f.Component2AsCalendar.Year);
			assertEquals(10, f.Component2AsCalendar.Month + 1);
			assertEquals(19, f.Component2AsCalendar.Day);
			assertEquals("abc", f.getComponent3());
			assertNull(f.getComponent4());

			f = new Field11R("100\n091019\n1234567890");
			assertEquals("1234", f.getComponent3());
			assertEquals("567890", f.getComponent4());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSetters()
		public virtual void testSetters()
		{
			Field11R f = new Field11R();
			f.Component1 = "103";
			f.setComponent2("151111");
			f.setComponent3("4444666666");
			assertEquals("103", f.Component1);
			assertEquals("151111", f.getComponent2());
			assertEquals("4444666666", f.getComponent3());
			assertNull(f.getComponent4());
			assertEquals("103" + FINWriterVisitor.SWIFT_EOL + "151111" + FINWriterVisitor.SWIFT_EOL + "4444666666", f.Value);

			f = new Field11R();
			f.Component1 = "103";
			f.setComponent2("151111");
			f.setComponent3("4444");
			f.setComponent4("666666");
			assertEquals("103", f.Component1);
			assertEquals("151111", f.getComponent2());
			assertEquals("4444", f.getComponent3());
			assertEquals("666666", f.getComponent4());
			assertEquals("103" + FINWriterVisitor.SWIFT_EOL + "151111" + FINWriterVisitor.SWIFT_EOL + "4444666666", f.Value);

			f = new Field11R();
			f.Component1 = "103";
			DateTime cal = new DateTime();
			cal.set(DateTime.YEAR, 2015);
			cal.set(DateTime.MONTH, 10);
			cal.set(DateTime.DAY_OF_MONTH, 19);
			f.setComponent2(cal);
			f.setComponent3("4444");
			f.setComponent4("666666");
			assertEquals("103", f.Component1);
			assertEquals("151019", f.getComponent2());
			assertEquals("4444", f.getComponent3());
			assertEquals("666666", f.getComponent4());
			assertEquals("103" + FINWriterVisitor.SWIFT_EOL + "151019" + FINWriterVisitor.SWIFT_EOL + "4444666666", f.Value);

			f = new Field11R();
			f.Component1 = "103";
			f.setComponent2("151111");
			f.setComponent3(4444);
			f.setComponent4(666666);
			assertEquals("103", f.Component1);
			assertEquals("151111", f.getComponent2());
			assertEquals("4444", f.getComponent3());
			assertEquals("666666", f.getComponent4());
			assertEquals("103" + FINWriterVisitor.SWIFT_EOL + "151111" + FINWriterVisitor.SWIFT_EOL + "4444666666", f.Value);

			f = new Field11R();
			f.Component1 = "103";
			f.setComponent2("151111");
			f.setComponent3(4);
			f.setComponent4(6);
			assertEquals("103", f.Component1);
			assertEquals("151111", f.getComponent2());
			assertEquals("4", f.getComponent3());
			assertEquals("6", f.getComponent4());
			assertEquals("103" + FINWriterVisitor.SWIFT_EOL + "151111" + FINWriterVisitor.SWIFT_EOL + "46", f.Value);
		}

	}
}