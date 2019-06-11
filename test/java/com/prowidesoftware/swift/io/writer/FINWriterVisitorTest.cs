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
namespace com.prowidesoftware.swift.io.writer
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;


	using Before = org.junit.Before;
	using Test = org.junit.Test;

	using SwiftBlock1 = com.prowidesoftware.swift.model.SwiftBlock1;
	using SwiftBlock2Input = com.prowidesoftware.swift.model.SwiftBlock2Input;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using Tag = com.prowidesoftware.swift.model.Tag;

	/// <summary>
	/// Swift writer tests
	/// 
	/// @since 4.0
	/// </summary>
	public class FINWriterVisitorTest
	{

		private FINWriterVisitor visitor;
		private Writer io;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			this.io = new StringWriter();
			this.visitor = new FINWriterVisitor(this.io);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private String getResult()
		private string Result
		{
			get
			{
				return (this.getResult(""));
			}
		}

		private string getResult(string testName)
		{
			return this.io.ToString();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteBlock1()
		public virtual void testWriteBlock1()
		{
			SwiftMessage msg = new SwiftMessage(true);
			msg.Block1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;

			this.visitor.startBlock1(msg.Block1);
			this.visitor.value(msg.Block1, msg.Block1.Value);
			this.visitor.endBlock1(msg.Block1);
			assertEquals("{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}", getResult("testWriteBlock1"));
		}

		/// <summary>
		/// Default constructor of swift messages creates empty blocks
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteBlock1_2()
		public virtual void testWriteBlock1_2()
		{
			SwiftMessage msg = new SwiftMessage(true);
			msg.Block1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;

			msg.visit(this.visitor);
			assertEquals("{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{2:IN}{3:}{4:\r\n-}{5:}", getResult("testWriteBlock1_2"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteBlock1_3()
		public virtual void testWriteBlock1_3()
		{
			SwiftMessage msg = new SwiftMessage(true);
			msg.Block1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			msg.Block2 = null;
			msg.Block3 = null;

			msg.visit(this.visitor);
			assertEquals("{1:" + com.prowidesoftware.swift.Constants_Fields.B1_DATA + "}{4:\r\n-}{5:}", getResult("testWriteBlock1_3"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1690027_1()
		public virtual void testBug1690027_1()
		{
			SwiftMessage msg = new SwiftMessage(true);
			msg.Block1 = null;
			msg.Block2 = null;
			msg.Block3.append(new Tag("1:val1"));
			msg.Block3.append(new Tag("2:val2"));

			msg.visit(this.visitor);
			assertEquals("{3:{1:val1}{2:val2}}{4:\r\n-}{5:}", getResult("testBug1690027_1"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteBlock4()
		public virtual void testWriteBlock4()
		{
			SwiftMessage msg = new SwiftMessage(true);
			msg.Block1 = null;
			msg.Block2 = null;
			msg.Block3 = null;
			msg.Block5 = null;

			msg.Block4.append(new Tag("1:val1"));
			msg.Block4.append(new Tag("2:val2"));

			msg.visit(this.visitor);
			assertEquals("{4:\r\n:1:val1\r\n:2:val2\r\n-}", getResult("testWriteBlock4"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteBlock4_2()
		public virtual void testWriteBlock4_2()
		{
			SwiftMessage msg = new SwiftMessage(true);
			msg.Block1 = null;
			msg.Block2 = new SwiftBlock2Input("I028CARAANC0XXXXN");
			msg.Block3 = null;
			msg.Block5 = null;

			msg.Block4.append(new Tag("1:val1"));
			msg.Block4.append(new Tag("2:val2"));

			msg.visit(this.visitor);
			assertEquals("{2:I028CARAANC0XXXXN}{4:{1:val1}{2:val2}}", getResult("testWriteBlock4_2"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWriteBlock4_3()
		public virtual void testWriteBlock4_3()
		{
			SwiftMessage msg = new SwiftMessage(true);
			msg.Block1 = new SwiftBlock1("F01VNDZBET2AXXX0027000580");
			msg.Block2 = new SwiftBlock2Input("I028CARAANC0XXXXN");
			msg.Block3 = null;
			msg.Block5 = null;

			msg.Block4.append(new Tag("1:val1"));
			msg.Block4.append(new Tag("2:val2"));

			msg.visit(this.visitor);
			assertEquals("{1:F01VNDZBET2AXXX0027000580}{2:I028CARAANC0XXXXN}{4:{1:val1}{2:val2}}", getResult("testWriteBlock4_3"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBug1601122_1()
		public virtual void testBug1601122_1()
		{
			SwiftMessage msg = new SwiftMessage(true);
			msg.Block1 = null;
			msg.Block2 = null;
			msg.Block3 = null;
			msg.Block4 = null;

			msg.Block5.append(new Tag("MAC:valmac"));
			msg.Block5.append(new Tag("CHK:valchk"));

			msg.visit(this.visitor);
			assertEquals("{5:{MAC:valmac}{CHK:valchk}}", getResult("testBug1601122_1"));
		}

	}

}