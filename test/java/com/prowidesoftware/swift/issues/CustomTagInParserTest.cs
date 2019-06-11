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
namespace com.prowidesoftware.swift.issues
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	using SwiftParser = com.prowidesoftware.swift.io.parser.SwiftParser;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using Tag = com.prowidesoftware.swift.model.Tag;

	/// <summary>
	/// Kantoro Erkulov
	/// https://sourceforge.net/p/wife/discussion/544818/thread/8ba75d64/?limit=25#09f0
	/// </summary>
	public class CustomTagInParserTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test()
		{
			const string fin = "{1:F01BIC0BANKAXXX0006222623}{2:I198BIC0BANKXXXXS}{4:\n" + ":20:my_ref\n" + ":CUSTOM_TAG:my_value\n" + "-}";
			SwiftParser swiftParser = new SwiftParser(fin);
			SwiftMessage swiftMessage = swiftParser.message();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.Tag t20 = swiftMessage.getBlock4().getTagByName("20");
			Tag t20 = swiftMessage.Block4.getTagByName("20");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.Tag tcustom = swiftMessage.getBlock4().getTagByName("CUSTOM_TAG");
			Tag tcustom = swiftMessage.Block4.getTagByName("CUSTOM_TAG");
			/*
			 * we expect this to be null because CUSTOM_TAG is not a proper tag name and since
			 * parser patch on October 2015 we check for proper tag names because a startign ':'
			 * is note sufficient to check for a starting colon because for some fields like
			 * 77E for example, it is allowed the field content to have a ':<CR><LF>' as the second line
			 * of its content.
			 */
			assertNull(tcustom);
			assertEquals("my_ref\n:CUSTOM_TAG:my_value", t20.Value);
		}

	}

}