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

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;

	/// <summary>
	/// Test for Field57A and similar fields.
	/// 
	/// @since 7.7
	/// </summary>
	public class Field57ATest : AbstractFieldTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("57A", "/D/1234\nFOOBAR", "/1234\nFOOBAR", "FOOBAR");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_getValue()
		public virtual void test_getValue()
		{
			Field57A f = new Field57A();
			f.Component1 = "";
			f.Component2 = "1234567890";
			f.setComponent3("FOOBARXX");
			assertEquals("//1234567890" + FINWriterVisitor.SWIFT_EOL + "FOOBARXX", f.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_getValue2()
		public virtual void test_getValue2()
		{
			Field57A f = new Field57A();
			f.Component2 = "1234567890";
			f.setComponent3("FOOBARXX");
			assertEquals("/1234567890" + FINWriterVisitor.SWIFT_EOL + "FOOBARXX", f.Value);
		}

	}
}