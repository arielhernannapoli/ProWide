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

	using Test = org.junit.Test;

	/// <summary>
	/// Test for Field252 and similar fields.
	/// 
	/// @since 7.8.8
	/// </summary>
	public class Field252Test : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("252", "MIR4567890123456789012345ENDMIR4567890123456789012345END11112222");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse252() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testParse252()
		{
			Field252 f = new Field252("MIR4567890123456789012345ENDMIR4567890123456789012345END11112222");
			assertNotNull("Parse of field failed", f);
			assertEquals("MIR4567890123456789012345END", f.getComponent1());
			assertEquals("MIR4567890123456789012345END", f.getComponent2());
			assertEquals("1111", f.getComponent3());
			assertEquals("2222", f.getComponent4());
		}

	}
}