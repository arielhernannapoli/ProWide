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
	/// Test for fields that define a special usage overriding the
	/// default structure definition.
	/// <br>
	/// The first two components with pattern [/DC][/account] are used to
	/// define a national clearing system code with a starting double slash //NCS
	/// and this information must be kept inside the object after parsing it
	/// (meaning the double slash presence cannot be lost after parse)
	/// <br>
	/// This behavior has been found in the standard for fields: 
	/// 52(ACD), 56(ACD), 57(ACD), 58(AD), and 59a.
	/// <br>
	/// This test mainly verify that a starting double slash is preserved 
	/// after serialization
	/// 
	/// 
	/// @author www.prowidesoftware.com
	/// 
	/// </summary>
	public class NationalClearingSystemComponentTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField52A()
		public virtual void testField52A()
		{
			Field52A f = new Field52A("//ATBBBBB\r\nABNANL2A");
			assertEquals("//ATBBBBB\r\nABNANL2A", f.Value);
			assertNull(f.DCMark);
			assertNull("", f.Component1);
			assertEquals("/ATBBBBB", f.Component2);
			assertEquals("ATBBBBB", f.Account); //account getter will trims the starting slash
			assertEquals("ABNANL2A", f.getBIC());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField52A_2()
		public virtual void testField52A_2()
		{
			Field52A f = new Field52A("/ATBBBBB\r\nABNANL2A");
			assertEquals("/ATBBBBB\r\nABNANL2A", f.Value);
			assertNull(f.DCMark);
			assertNull(f.Component1);
			assertEquals("ATBBBBB", f.Component2);
			assertEquals("ATBBBBB", f.Account);
			assertEquals("ABNANL2A", f.getBIC());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField52A_3()
		public virtual void testField52A_3()
		{
			Field52A f = new Field52A("/D/ATBBBBB\r\nABNANL2A");
			assertEquals("/D/ATBBBBB\r\nABNANL2A", f.Value);
			assertEquals("D", f.DCMark);
			assertEquals("D", f.Component1);
			assertEquals("ATBBBBB", f.Component2);
			assertEquals("ATBBBBB", f.Account);
			assertEquals("ABNANL2A", f.getBIC());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField52A_4()
		public virtual void testField52A_4()
		{
			Field52A f = new Field52A("/DA/TBBBBB\r\nABNANL2A");
			assertEquals("/DA/TBBBBB\r\nABNANL2A", f.Value);
			assertNull(f.DCMark);
			assertNull(f.Component1);
			assertEquals("DA/TBBBBB", f.Component2);
			assertEquals("DA/TBBBBB", f.Account);
			assertEquals("ABNANL2A", f.getBIC());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField52D()
		public virtual void testField52D()
		{
			Field52D f = new Field52D("//ATBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4");
			assertEquals("//ATBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4", f.Value);
			assertNull(f.DCMark);
			assertNull(f.Component1);
			assertEquals("/ATBBBBB",f.Component2);
			assertEquals("ATBBBBB", f.Account);
			assertEquals("ADDRESS1", f.NameAndAddressLine1);
			assertEquals("ADDRESS2", f.NameAndAddressLine2);
			assertEquals("ADDRESS3", f.NameAndAddressLine3);
			assertEquals("ADDRESS4", f.NameAndAddressLine4);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField56A()
		public virtual void testField56A()
		{
			Field56A f = new Field56A("//ATBBBBB\r\nABNANL2A");
			assertEquals("//ATBBBBB\r\nABNANL2A", f.Value);
			assertNull(f.DCMark);
			assertNull(f.Component1);
			assertEquals("/ATBBBBB", f.Component2);
			assertEquals("ATBBBBB", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField56C()
		public virtual void testField56C()
		{
			Field56C f = new Field56C("//ATBBBBB");
			assertEquals("//ATBBBBB", f.Value);
			assertEquals("/ATBBBBB", f.Component1);
			assertEquals("ATBBBBB", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField56D()
		public virtual void testField56D()
		{
			Field56D f = new Field56D("//ATBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4");
			assertEquals("//ATBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4", f.Value);
			assertNull(f.DCMark);
			assertNull(f.Component1);
			assertEquals("/ATBBBBB", f.Component2);
			assertEquals("ATBBBBB", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField57A()
		public virtual void testField57A()
		{
			Field57A f = new Field57A("//ATBBBBB\r\nABNANL2A");
			assertEquals("//ATBBBBB\r\nABNANL2A",f.Value);
			assertNull(f.DCMark);
			assertNull(f.Component1);
			assertEquals("/ATBBBBB", f.Component2);
			assertEquals("ATBBBBB", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField57C()
		public virtual void testField57C()
		{
			Field57C f = new Field57C("//ATBBBBB");
			assertEquals("//ATBBBBB", f.Value);
			assertEquals("/ATBBBBB", f.Component1);
			assertEquals("ATBBBBB", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField57D()
		public virtual void testField57D()
		{
			Field57D f = new Field57D("//ATBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4");
			assertEquals("//ATBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4", f.Value);
			assertNull(f.DCMark);
			assertNull(f.Component1);
			assertEquals("/ATBBBBB", f.Component2);
			assertEquals("ATBBBBB", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField58A()
		public virtual void testField58A()
		{
			Field58A f = new Field58A("//ATBBBBB\r\nABNANL2A");
			assertEquals("//ATBBBBB\r\nABNANL2A", f.Value);
			assertNull(f.DCMark);
			assertNull(f.Component1);
			assertEquals("/ATBBBBB", f.Component2);
			assertEquals("ATBBBBB", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField58D()
		public virtual void testField58D()
		{
			Field58D f = new Field58D("//ATBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4");
			assertEquals("//ATBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4", f.Value);
			assertNull(f.DCMark);
			assertNull(f.Component1);
			assertEquals("/ATBBBBB", f.Component2);
			assertEquals("ATBBBBB",f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField59()
		public virtual void testField59()
		{
			Field59 f = new Field59("//CHBBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4");
			assertEquals("//CHBBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4", f.Value);
			assertEquals("/CHBBBBBB", f.Component1);
			assertEquals("CHBBBBBB", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField59_2()
		public virtual void testField59_2()
		{
			Field59 f = new Field59("/CHBBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4");
			assertEquals("/CHBBBBBB\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4", f.Value);
			assertEquals("CHBBBBBB", f.Component1);
			assertEquals("CHBBBBBB", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField59_3()
		public virtual void testField59_3()
		{
			Field59 f = new Field59("///\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4");
			assertEquals("///\r\nADDRESS1\r\nADDRESS2\r\nADDRESS3\r\nADDRESS4", f.Value);
			assertEquals("//", f.Component1);
			assertEquals("", f.Account);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField59A()
		public virtual void testField59A()
		{
			Field59A f = new Field59A("//CHBBBBBB\r\nABNANL2A");
			assertEquals("//CHBBBBBB\r\nABNANL2A", f.Value);
			assertEquals("/CHBBBBBB", f.Component1);
			assertEquals("CHBBBBBB", f.Account);
		}

	}
}