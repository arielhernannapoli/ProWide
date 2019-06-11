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
namespace com.prowidesoftware.swift.io.parser
{

	using Before = org.junit.Before;
	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static junit.framework.TestCase.assertFalse;

	/// <summary>
	/// Similar test cases as in <seealso cref="SwiftParserStrinctTest"/> but using the lenient
	/// mode and checking the error list is not empty. In lenient mode exceptions are
	/// not thrown but the parsing issues are reported in the parser internal list
	/// of errors.
	/// </summary>
	public class SwiftParserLenientTest
	{
		protected internal VisibleParser parser;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			this.parser = new VisibleParser();
			this.parser.Configuration.Lenient = true;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock1InvalidValueSize() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock1InvalidValueSize()
		{
			parser.Data = "{1:012345678901}";
			parser.consumeBlock(null);
			assertError();
		}

		private void assertError()
		{
			assertFalse(parser.Errors.Count == 0);
			foreach (string error in parser.Errors)
			{
				Console.WriteLine(error);
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock1MissingClossingBracket() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock1MissingClossingBracket()
		{
			parser.Data = "{1:0123456789012345678901234";
			parser.consumeBlock(null);
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock1MissingClossingBracket2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock1MissingClossingBracket2()
		{
			parser.Data = "{1:0123456789012345678901234{2:I100BANKDEFFXXXXU3003}";
			parser.consumeBlock(null);
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock2InvalidValueSize() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock2InvalidValueSize()
		{
			parser.Data = "{1:F01FOOBARXXXXXX0000000000}{2:I100BANKDEFF3}";
			parser.consumeBlock(null); // block 1
			parser.consumeBlock(null); // block 2
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock2MissingClosingBracket() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock2MissingClosingBracket()
		{
			parser.Data = "{1:F01FOOBARXXXXXX0000000000}{2:I100BANKDEFFXXXXU3003";
			parser.consumeBlock(null); // block 1
			parser.consumeBlock(null); // block 2
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock2MissingClosingBracket2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock2MissingClosingBracket2()
		{
			parser.Data = "{1:F01FOOBARXXXXXX0000000000}{2:I100BANKDEFFXXXXU3003{3:{108:11111111}}";
			parser.consumeBlock(null); // block 1
			parser.consumeBlock(null); // block 2
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testConsumeBock3MissingClosingBracket() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testConsumeBock3MissingClosingBracket()
		{
			parser.Data = "{1:F01FOOBARXXXXXX0000000000}{2:I100BANKDEFFXXXXU3003}{3:{108:11111111}";
			parser.consumeBlock(null); // block 1
			parser.consumeBlock(null); // block 2
			parser.consumeBlock(null); // block 3
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4MissingClossingBracket() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock4MissingClossingBracket()
		{
			parser.Data = "{4:\r\n" + ":79:FOO";
			parser.consumeBlock(null);
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4MissingClossingBracket2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock4MissingClossingBracket2()
		{
			parser.Data = "{4:\r\n" + ":79:FOO\r\n";
			parser.consumeBlock(null);
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4MissingClossingBracket3() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock4MissingClossingBracket3()
		{
			parser.Data = "{4:\r\n" + ":79:FOO\r\n" + "-";
			parser.consumeBlock(null);
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4MissingClossingBracket4() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock4MissingClossingBracket4()
		{
			parser.Data = "{4:\r\n" + ":79:FOO\r\n" + "-{";
			parser.consumeBlock(null);
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4MissingClossingBracket5() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock4MissingClossingBracket5()
		{
			parser.Data = "{4:\r\n" + ":79:FOO\r\n" + "-{5:CHK:ABSH}";
			parser.consumeBlock(null);
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4MissingClossingHyphen() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock4MissingClossingHyphen()
		{
			parser.Data = "{4:\r\n" + ":79:FOO\r\n" + "}";
			parser.consumeBlock(null);
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4MissingClossingHyphen2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock4MissingClossingHyphen2()
		{
			parser.Data = "{4:\r\n" + ":79:FOO}";
			parser.consumeBlock(null);
			assertError();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBlock4ClossingBracketOk() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testBlock4ClossingBracketOk()
		{
			parser.Data = "{4:\r\n" + ":79:FOO\r\n" + "-}";
			parser.consumeBlock(null);
		}

	}
}