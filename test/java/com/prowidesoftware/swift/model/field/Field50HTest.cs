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

	using Test = org.junit.Test;


	/// <summary>
	/// Test for Field50H and similar fields.
	/// 
	/// </summary>
	public class Field50HTest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("50H", "/0000001111000000\r\nBNPPARIBAS\r\n66 VICTOIRE\r\nPARIS");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetValue()
		public virtual void testGetValue()
		{
			Field50H f = new Field50H("/0000001111000000\r\nBNPPARIBAS\r\n66 VICTOIRE\r\nPARIS\r\n");
			assertEquals(f.Component1, "0000001111000000");
			assertEquals(f.Component2, "BNPPARIBAS");
			assertEquals(f.Component3, "66 VICTOIRE");
			assertEquals(f.Component4, "PARIS");
		}

	}
}