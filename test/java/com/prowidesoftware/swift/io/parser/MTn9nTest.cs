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
namespace com.prowidesoftware.swift.io.parser
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;

	using Test = org.junit.Test;

	/// <summary>
	/// Test cases for Mts n92, n95 and n96
	/// </summary>
	public class MTn9nTest : BaseMessageTestcase
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test192_1()
		public virtual void test192_1()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I192FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":11S:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("192", (parseMessage(messageToParse)).Type);
			assertEquals(3, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("11S"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test192_2()
		public virtual void test192_2()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I192FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":11S:FOO\n" + ":79:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("192", (parseMessage(messageToParse)).Type);
			assertEquals(4, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("11S"));
			assertEquals("FOO", b4.getTagValue("79"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test192_3()
		public virtual void test192_3()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I192FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":11S:FOO\n" + ":79:FOO\n" + ":52A:FOO\n" + ":23G:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("192", (parseMessage(messageToParse)).Type);
			assertEquals(6, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("11S"));
			assertEquals("FOO", b4.getTagValue("79"));
			assertEquals("FOO", b4.getTagValue("52A"));
			assertEquals("FOO", b4.getTagValue("23G"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test192_4()
		public virtual void test192_4()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I192FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":11S:FOO\n" + ":52A:FOO\n" + ":23G:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("192", (parseMessage(messageToParse)).Type);
			assertEquals(5, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("11S"));
			assertEquals("FOO", b4.getTagValue("52A"));
			assertEquals("FOO", b4.getTagValue("23G"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test192_5()
		public virtual void test192_5()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I192FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":11S:FOO\n" + ":59:FOO\n" + "FOO2\n" + ":23G:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("192", (parseMessage(messageToParse)).Type);
			assertEquals(5, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("11S"));
			assertEquals("FOO\nFOO2", b4.getTagValue("59"));
			assertEquals("FOO", b4.getTagValue("23G"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test195_1()
		public virtual void test195_1()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I195FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":75:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("195", (parseMessage(messageToParse)).Type);
			assertEquals(3, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("75"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test195_2()
		public virtual void test195_2()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I195FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":75:FOO\n" + ":79:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("195", (parseMessage(messageToParse)).Type);
			assertEquals(4, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("75"));
			assertEquals("FOO", b4.getTagValue("79"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test195_3()
		public virtual void test195_3()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I195FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":75:FOO\n" + ":79:FOO\n" + ":20:FOO\n" + ":21:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("195", (parseMessage(messageToParse)).Type);
			assertEquals(6, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("75"));
			assertEquals("FOO", b4.getTagValue("79"));
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test195_4()
		public virtual void test195_4()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I195FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":75:FOO\n" + ":11R:FOO\n" + ":21:FOO\n" + ":52A:FOO\n" + ":23G:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("195", (parseMessage(messageToParse)).Type);
			assertEquals(7, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("75"));
			assertEquals("FOO", b4.getTagValue("11R"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("52A"));
			assertEquals("FOO", b4.getTagValue("23G"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test195_5()
		public virtual void test195_5()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I195FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":75:FOO\n" + ":11R:FOO\n" + ":21:FOO\n" + ":52A:FOO\n" + ":23G:FOO\n" + ":59:FOO\n" + "FOO2\n" + ":20:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("195", (parseMessage(messageToParse)).Type);
			assertEquals(9, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("75"));
			assertEquals("FOO", b4.getTagValue("11R"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("52A"));
			assertEquals("FOO", b4.getTagValue("23G"));
			assertEquals("FOO\nFOO2", b4.getTagValue("59"));
			assertEquals("FOO", b4.getTagValue("20"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test196_1()
		public virtual void test196_1()
		{
			messageToParse = "{1:F01FOOBARXXAXXX3227607589}{2:I196FOOBARXXXXXXN}{4:\n" + ":20:FOO\n" + ":21:FOO\n" + ":75:FOO\n" + ":11R:FOO\n" + ":21:FOO\n" + ":52A:FOO\n" + ":23G:FOO\n" + ":59:FOO\n" + "FOO2\n" + ":20:FOO\n" + "-}{5:{MAC:0D3E6718}{CHK:76FFBA03C41F}}";
			assertEquals("196", (parseMessage(messageToParse)).Type);
			assertEquals(9, b4.countAll());
			assertEquals("FOO", b4.getTagValue("20"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("75"));
			assertEquals("FOO", b4.getTagValue("11R"));
			assertEquals("FOO", b4.getTagValue("21"));
			assertEquals("FOO", b4.getTagValue("52A"));
			assertEquals("FOO", b4.getTagValue("23G"));
			assertEquals("FOO\nFOO2", b4.getTagValue("59"));
			assertEquals("FOO", b4.getTagValue("20"));
		}

	}
}