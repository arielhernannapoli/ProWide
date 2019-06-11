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

	using Test = org.junit.Test;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// Test for Field50F and similar fields.
	/// 
	/// @since 6.0
	/// </summary>
	public class Field50FTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("50F", "FFF\nA/B\nC/D\nE/F", "AAAA/BB/CCCCCCCC/DD1234567\n" + "1/JOHN SMITH\n" + "2/HIGH STREET 6, APT 6C\n" + "3/BE/BRUSSELS", "/123456\n1/JOHN SMITH", "CODE/AR\n1/JOHN SMITH", "/12345678\n" + "1/SMITH JOHN\n" + "2/299, PARK AVENUE\n" + "3/US/NEW YORK, NY 10017", "/BE30001216371411\n" + "1/PHILIPS MARK\n" + "4/19720830\n" + "5/BE/BRUSSELS", "DRLC/BE/BRUSSELS/NB0949042\n" + "1/DUPONT JACQUES\n" + "2/HIGH STREET 6, APT 6C\n" + "3/BE/BRUSSELS", "NIDN/DE/121231234342\n" + "1/MANN GEORG\n" + "6/DE/ABC BANK/1234578293");
		}

		/// <summary>
		/// 50F: 
		/// First line can have different formats
		/// <"/"34x> | <4!a"/"<CC>"/"27x><CrLf>
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSerialization2()
		public virtual void testSerialization2()
		{
			Field50F f = new Field50F();
			assertEquals("", f.Value);

			f.Component1 = "/1234567";
			assertEquals("/1234567", f.Value);

			f.Component1 = "1234567";
			assertEquals("1234567", f.Value); //the slash will not be added

			f.Component1 = "1234/AR/ABC";
			assertEquals("1234/AR/ABC", f.Value);

			f.setComponent2("1");
			f.Component3 = "ABC";
			assertEquals("1234/AR/ABC" + FINWriterVisitor.SWIFT_EOL + "1/ABC", f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_01()
		public virtual void testParse_01()
		{
			Field50F f = new Field50F("FFF");
			assertEquals("FFF", f.Component1);
			assertNull(f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.Component5);
			assertNull(f.getComponent6());
			assertNull(f.Component7);
			assertNull(f.getComponent8());
			assertNull(f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_02()
		public virtual void testParse_02()
		{
			Field50F f = new Field50F("FFF\nA");
			assertEquals("FFF", f.Component1);
			assertEquals("A", f.getComponent2());
			assertNull(f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.Component5);
			assertNull(f.getComponent6());
			assertNull(f.Component7);
			assertNull(f.getComponent8());
			assertNull(f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_03()
		public virtual void testParse_03()
		{
			Field50F f = new Field50F("FFF\nA/B");
			assertEquals("FFF", f.Component1);
			assertEquals("A", f.getComponent2());
			assertEquals("B", f.Component3);
			assertNull(f.getComponent4());
			assertNull(f.Component5);
			assertNull(f.getComponent6());
			assertNull(f.Component7);
			assertNull(f.getComponent8());
			assertNull(f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_04()
		public virtual void testParse_04()
		{
			Field50F f = new Field50F("FFF\nA/B\nC");
			assertEquals("FFF", f.Component1);
			assertEquals("A", f.getComponent2());
			assertEquals("B", f.Component3);
			assertEquals("C", f.getComponent4());
			assertNull(f.Component5);
			assertNull(f.getComponent6());
			assertNull(f.Component7);
			assertNull(f.getComponent8());
			assertNull(f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_05()
		public virtual void testParse_05()
		{
			Field50F f = new Field50F("FFF\nA/B\nC/D");
			assertEquals("FFF", f.Component1);
			assertEquals("A", f.getComponent2());
			assertEquals("B", f.Component3);
			assertEquals("C", f.getComponent4());
			assertEquals("D", f.Component5);
			assertNull(f.getComponent6());
			assertNull(f.Component7);
			assertNull(f.getComponent8());
			assertNull(f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_06()
		public virtual void testParse_06()
		{
			Field50F f = new Field50F("FFF\nA/B\nC/D\nE");
			assertEquals("FFF", f.Component1);
			assertEquals("A", f.getComponent2());
			assertEquals("B", f.Component3);
			assertEquals("C", f.getComponent4());
			assertEquals("D", f.Component5);
			assertEquals("E", f.getComponent6());
			assertNull(f.Component7);
			assertNull(f.getComponent8());
			assertNull(f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_07()
		public virtual void testParse_07()
		{
			Field50F f = new Field50F("FFF\nA/B\nC/D\nE/F");
			assertEquals("FFF", f.Component1);
			assertEquals("A", f.getComponent2());
			assertEquals("B", f.Component3);
			assertEquals("C", f.getComponent4());
			assertEquals("D", f.Component5);
			assertEquals("E", f.getComponent6());
			assertEquals("F", f.Component7);
			assertNull(f.getComponent8());
			assertNull(f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_08()
		public virtual void testParse_08()
		{
			Field50F f = new Field50F("FFF\nA/B\nC/D\nE/F\nG");
			assertEquals("FFF", f.Component1);
			assertEquals("A", f.getComponent2());
			assertEquals("B", f.Component3);
			assertEquals("C", f.getComponent4());
			assertEquals("D", f.Component5);
			assertEquals("E", f.getComponent6());
			assertEquals("F", f.Component7);
			assertEquals("G", f.getComponent8());
			assertNull(f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_09()
		public virtual void testParse_09()
		{
			Field50F f = new Field50F("FFF\nA/B\nC/D\nE/F\nG/H");
			assertEquals("FFF", f.Component1);
			assertEquals("A", f.getComponent2());
			assertEquals("B", f.Component3);
			assertEquals("C", f.getComponent4());
			assertEquals("D", f.Component5);
			assertEquals("E", f.getComponent6());
			assertEquals("F", f.Component7);
			assertEquals("G", f.getComponent8());
			assertEquals("H", f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_10()
		public virtual void testParse_10()
		{
			Field50F f = new Field50F("AAAA/BB/CCCCCCCC/DD1234567\n" + "1/JOHN SMITH\n" + "2/HIGH STREET 6, APT 6C\n" + "3/BE/BRUSSELS");
			assertEquals("AAAA/BB/CCCCCCCC/DD1234567", f.Component1);
			assertEquals("1", f.getComponent2());
			assertEquals("JOHN SMITH", f.Component3);
			assertEquals("2", f.getComponent4());
			assertEquals("HIGH STREET 6, APT 6C", f.Component5);
			assertEquals("3", f.getComponent6());
			assertEquals("BE/BRUSSELS", f.Component7);
			assertNull(f.getComponent8());
			assertNull(f.Component9);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse_11()
		public virtual void testParse_11()
		{
			/*
			 * test sample value
			 */
			const string value = "/1234567890\r\n" + "1/JOHN SMITH\r\n" + "2/HIGH STREET 6, APT 6C\r\n" + "3/BE/BRUSSELS";

			/*
			 * parse value into components
			 */
			Field50F f = new Field50F(value);

			/*
			 * assert each parsed component
			 */
			assertEquals("/1234567890", f.Component1);
			assertEquals("1", f.getComponent2());
			assertEquals("JOHN SMITH", f.Component3);
			assertEquals("2", f.getComponent4());
			assertEquals("HIGH STREET 6, APT 6C", f.Component5);
			assertEquals("3", f.getComponent6());
			assertEquals("BE/BRUSSELS", f.Component7);
			assertNull(f.getComponent8());
			assertNull(f.Component9);

			/*
			 * serialize field components into plain value
			 * and assert match with original value
			 */
			assertEquals(value, f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDynamicLabels()
		public virtual void testDynamicLabels()
		{
			Field50F f = new Field50F("/12345678\n" + "1/SMITH JOHN\n" + "2/299, PARK AVENUE\n" + "3/US/NEW YORK, NY 10017");
			assertEquals("Account", f.getComponentLabel(1));
			assertEquals("Name of the Ordering Customer", f.getComponentLabel(3));
			assertEquals("Address Line", f.getComponentLabel(5));
			assertEquals("Country and Town", f.getComponentLabel(7));

			f = new Field50F("/BE30001216371411\n" + "1/PHILIPS MARK\n" + "4/19720830\n" + "5/BE/BRUSSELS");
			assertEquals("Account", f.getComponentLabel(1));
			assertEquals("Name of the Ordering Customer", f.getComponentLabel(3));
			assertEquals("Date of Birth", f.getComponentLabel(5));
			assertEquals("Place of Birth", f.getComponentLabel(7));

			f = new Field50F("DRLC/BE/BRUSSELS/NB0949042\n" + "1/DUPONT JACQUES\n" + "2/HIGH STREET 6, APT 6C\n" + "3/BE/BRUSSELS");
			assertEquals("Party Identifier", f.getComponentLabel(1));
			assertEquals("Name of the Ordering Customer", f.getComponentLabel(3));
			assertEquals("Address Line", f.getComponentLabel(5));
			assertEquals("Country and Town", f.getComponentLabel(7));

			f = new Field50F("NIDN/DE/121231234342\n" + "1/MANN GEORG\n" + "6/DE/ABC BANK/1234578293");
			assertEquals("Party Identifier", f.getComponentLabel(1));
			assertEquals("Name of the Ordering Customer", f.getComponentLabel(3));
			assertEquals("Customer Identification Number", f.getComponentLabel(5));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAddedAPI()
		public virtual void testAddedAPI()
		{
			const string value = "/1234567890\r\n" + "1/JOHN SMITH\r\n" + "2/HIGH STREET 6, APT 6C\r\n" + "3/BE/BRUSSELS";
			Field50F f = new Field50F(value);

			assertTrue(f.contains(1));
			assertEquals("JOHN SMITH", f.detailsByNumber(1)[0]);
			assertTrue(f.contains(2));
			assertEquals("HIGH STREET 6, APT 6C", f.detailsByNumber(2)[0]);
			assertTrue(f.contains(3));
			assertEquals("BE/BRUSSELS", f.detailsByNumber(3)[0]);
			assertFalse(f.contains(4));
			assertFalse(f.contains(5));
			assertFalse(f.contains(6));
			assertFalse(f.contains(7));
			assertFalse(f.contains(8));
		}

	}
}