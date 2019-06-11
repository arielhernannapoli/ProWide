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

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;

	/// <summary>
	/// Test for Field133 and similar fields.
	/// 
	/// @since 7.8.8
	/// </summary>
	public class Field133Test : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("133", EXAMPLE1_FIELD_133, EXAMPLE2_FIELD_133, EXAMPLE3_FIELD_133, EXAMPLE4_FIELD_133);
		}

		/// <summary>
		/// <original-broadcast-number>
		/// "B"|"S""XXX"
		/// "HQ"|"HK"|"NL"|"US"4!n
		/// 
		/// B User-initiated Broadcast
		/// S SWIFT-initiated Broadcast
		/// XXX indicates an unsequenced Broadcast (that is for selected countries)
		/// HQ Broadcast issued from La Hulpe
		/// HK Broadcast issued from Hong Kong
		/// NL Broadcast issued from Netherlands
		/// US Broadcast issued from the United States
		/// 4!n 4 digit Broadcast number
		/// 
		/// Ejemplos:
		/// BAZEUS1111
		/// SAAUNZ2101
		/// BJBDHQ1506
		/// SCCXHK9999
		/// 
		/// @plucero
		/// Note: Unsequenced Broadcast cannot contain numbers.
		/// </summary>

		private static string EXAMPLE1_FIELD_133 = "BAZEUS1111";
		private static string EXAMPLE2_FIELD_133 = "SAAUNZ2101";
		private static string EXAMPLE3_FIELD_133 = "BJBDHQ1506";
		private static string EXAMPLE4_FIELD_133 = "SCCXHK9999";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse()
		public virtual void testParse()
		{
			Field133 f = new Field133();

			f = new Field133(EXAMPLE1_FIELD_133);
			assertEquals("B", f.Component1);
			assertEquals("AZE", f.Component2);
			assertEquals("US", f.Component3);
			assertEquals("1111", f.getComponent4());

			f = new Field133(EXAMPLE2_FIELD_133);
			assertEquals("S", f.Component1);
			assertEquals("AAU", f.Component2);
			assertEquals("NZ", f.Component3);
			assertEquals("2101", f.getComponent4());

			f = new Field133(EXAMPLE3_FIELD_133);
			assertEquals("B", f.Component1);
			assertEquals("JBD", f.Component2);
			assertEquals("HQ", f.Component3);
			assertEquals("1506", f.getComponent4());

			f = new Field133(EXAMPLE4_FIELD_133);
			assertEquals("S", f.Component1);
			assertEquals("CCX", f.Component2);
			assertEquals("HK", f.Component3);
			assertEquals("9999", f.getComponent4());

			f = new Field133("B");
			assertEquals("B", f.Component1);
			assertNull(f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field133("BAZE");
			assertEquals("B", f.Component1);
			assertEquals("AZE", f.Component2);
			assertNull(f.Component3);
			assertNull(f.getComponent4());

			f = new Field133("BAZEUS");
			assertEquals("B", f.Component1);
			assertEquals("AZE", f.Component2);
			assertEquals("US", f.Component3);
			assertNull(f.getComponent4());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue1()
		public virtual void testGetValue1()
		{
			Field133 f = new Field133();
			string v = EXAMPLE1_FIELD_133;
			f = new Field133(v);
			assertEquals(StringUtils.replace(v, "\n", FINWriterVisitor.SWIFT_EOL), f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue2()
		public virtual void testGetValue2()
		{
			Field133 f = new Field133();
			string v = EXAMPLE2_FIELD_133;
			f = new Field133(v);
			assertEquals(StringUtils.replace(v, "\n", FINWriterVisitor.SWIFT_EOL), f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue3()
		public virtual void testGetValue3()
		{
			Field133 f = new Field133();
			string v = EXAMPLE3_FIELD_133;
			f = new Field133(v);
			assertEquals(StringUtils.replace(v, "\n", FINWriterVisitor.SWIFT_EOL), f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue4()
		public virtual void testGetValue4()
		{
			Field133 f = new Field133();
			string v = EXAMPLE4_FIELD_133;
			f = new Field133(v);
			assertEquals(StringUtils.replace(v, "\n", FINWriterVisitor.SWIFT_EOL), f.Value);
		}

	}
}