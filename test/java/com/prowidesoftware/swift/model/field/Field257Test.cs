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

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;

	/// <summary>
	/// Test for Field257 and similar fields.
	/// 
	/// @since 7.8.8
	/// </summary>
	public class Field257Test : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("257", EXAMPLE1_FIELD_257, EXAMPLE2_FIELD_257);
		}

		/// <summary>
		/// <input-time-range>
		/// <lt-identifier> 4!a2!a2!c1!c
		/// <branch-code> 3!c
		/// <date> 6!n
		/// <time-range> 4!n4!n
		/// [<session-number> 4!n]
		/// 
		/// 
		/// Ejemplos:
		/// FOOBARXXXXXX731019121213139999
		/// FOOBARABCDEF210117111122223333
		/// </summary>
		private static string EXAMPLE1_FIELD_257 = "FOOBARXXXXXX731019121213139999";
		private static string EXAMPLE2_FIELD_257 = "FOOBARABCDEF210117111122223333";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse257Ex1() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse257Ex1()
		{
			Field257 f = new Field257(EXAMPLE1_FIELD_257);
			assertNotNull("Parse of field failed", f);
			assertEquals("FOOBARXXXXXX", f.getComponent1());
			assertEquals("731019", f.getComponent2());
			assertEquals("1212", f.getComponent3());
			assertEquals("1313", f.getComponent4());
			assertEquals("9999", f.getComponent5());

			f = new Field257("FOOBARXXXXXX");
			assertEquals("FOOBARXXXXXX", f.getComponent1());
			assertNull(f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());

			f = new Field257("FOOBARXXXXXX731019");
			assertEquals("FOOBARXXXXXX", f.getComponent1());
			assertEquals("731019", f.getComponent2());
			assertNull(f.getComponent3());
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());

			f = new Field257("FOOBARXXXXXX7310191212");
			assertEquals("FOOBARXXXXXX", f.getComponent1());
			assertEquals("731019", f.getComponent2());
			assertEquals("1212", f.getComponent3());
			assertNull(f.getComponent4());
			assertNull(f.getComponent5());

			f = new Field257("FOOBARXXXXXX73101912121313");
			assertEquals("FOOBARXXXXXX", f.getComponent1());
			assertEquals("731019", f.getComponent2());
			assertEquals("1212", f.getComponent3());
			assertEquals("1313", f.getComponent4());
			assertNull(f.getComponent5());

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse257Ex2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse257Ex2()
		{
			Field257 f = new Field257(EXAMPLE2_FIELD_257);
			assertNotNull("Parse of field failed", f);
			assertEquals("FOOBARABCDEF", f.getComponent1());
			assertEquals("210117", f.getComponent2());
			assertEquals("1111", f.getComponent3());
			assertEquals("2222", f.getComponent4());
			assertEquals("3333", f.getComponent5());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue1()
		public virtual void testGetValue1()
		{
			Field257 f = new Field257();
			string v = EXAMPLE1_FIELD_257;
			f = new Field257(v);
			assertEquals(StringUtils.replace(v, "\n", FINWriterVisitor.SWIFT_EOL), f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue2()
		public virtual void testGetValue2()
		{
			Field257 f = new Field257();
			string v = EXAMPLE2_FIELD_257;
			f = new Field257(v);
			assertEquals(StringUtils.replace(v, "\n", FINWriterVisitor.SWIFT_EOL), f.Value);
		}

	}
}