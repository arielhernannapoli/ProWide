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
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	using Test = org.junit.Test;

	/// <summary>
	/// Test for SwiftParseUtils.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class SwiftParseUtilsTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplitComponents() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSplitComponents()
		{
			assertEquals(0, (SwiftParseUtils.splitComponents(null, null, null)).Count);
			assertEquals(0, (SwiftParseUtils.splitComponents(null, null, "/")).Count);
			assertEquals(0, (SwiftParseUtils.splitComponents(null, ":", null)).Count);

			assertEquals(1, (SwiftParseUtils.splitComponents("foo", null, null)).Count);
			assertEquals("foo", (SwiftParseUtils.splitComponents("foo", null, null))[0]);

			assertEquals(1, (SwiftParseUtils.splitComponents("foo", ":", null)).Count);
			assertEquals("foo", (SwiftParseUtils.splitComponents("foo", ":", null))[0]);

			assertEquals(1, (SwiftParseUtils.splitComponents(":foo", ":", null)).Count);
			assertEquals("foo", (SwiftParseUtils.splitComponents(":foo", ":", null))[0]);

			assertEquals(1, (SwiftParseUtils.splitComponents("::foo", ":", null)).Count);
			assertEquals(":foo", (SwiftParseUtils.splitComponents("::foo", ":", null))[0]);

			assertEquals(1, (SwiftParseUtils.splitComponents(":foo//", ":", "//")).Count);
			assertEquals("foo", (SwiftParseUtils.splitComponents(":foo//", ":", "//"))[0]);

			assertEquals(2, (SwiftParseUtils.splitComponents(":foo//abc", ":", "//")).Count);
			assertEquals("foo", (SwiftParseUtils.splitComponents(":foo//abc", ":", "//"))[0]);
			assertEquals("abc", (SwiftParseUtils.splitComponents(":foo//abc", ":", "//"))[1]);

			assertEquals(2, (SwiftParseUtils.splitComponents("foo//abc", ":", "//")).Count);
			assertEquals("foo", (SwiftParseUtils.splitComponents("foo//abc", ":", "//"))[0]);
			assertEquals("abc", (SwiftParseUtils.splitComponents("foo//abc", ":", "//"))[1]);

			assertEquals(1, (SwiftParseUtils.splitComponents(":foo/abc", ":", "//")).Count);
			assertEquals("foo/abc", (SwiftParseUtils.splitComponents(":foo/abc", ":", "//"))[0]);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetAlphaPrefix() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetAlphaPrefix()
		{
			assertNull(SwiftParseUtils.getAlphaPrefix(null));
			assertNull(SwiftParseUtils.getAlphaPrefix(""));
			assertNull(SwiftParseUtils.getAlphaPrefix("12342"));
			assertNull(SwiftParseUtils.getAlphaPrefix("3"));
			assertNull(SwiftParseUtils.getAlphaPrefix("1asdf"));
			assertEquals("a", SwiftParseUtils.getAlphaPrefix("a"));
			assertEquals("ABC", SwiftParseUtils.getAlphaPrefix("ABC"));
			assertEquals("ABC", SwiftParseUtils.getAlphaPrefix("ABC234234"));
			assertEquals("ABC", SwiftParseUtils.getAlphaPrefix("ABC234234asd"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetAlphaSuffix() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetAlphaSuffix()
		{
			assertNull(SwiftParseUtils.getAlphaSuffix(null));
			assertNull(SwiftParseUtils.getAlphaSuffix(""));
			assertNull(SwiftParseUtils.getAlphaSuffix("12342"));
			assertNull(SwiftParseUtils.getAlphaSuffix("3"));
			assertEquals("a", SwiftParseUtils.getAlphaSuffix("a"));
			assertEquals("ABC", SwiftParseUtils.getAlphaSuffix("ABC"));
			assertEquals("ABC", SwiftParseUtils.getAlphaSuffix("234234ABC"));
			assertEquals("ABC234234asd", SwiftParseUtils.getAlphaSuffix("ABC234234asd"));
			assertEquals("ABC", SwiftParseUtils.getAlphaSuffix("2342,34ABC"));
			assertEquals("ABC", SwiftParseUtils.getAlphaSuffix("2342,ABC"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetNumericPrefix() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetNumericPrefix()
		{
			assertNull(SwiftParseUtils.getNumericPrefix(null));
			assertNull(SwiftParseUtils.getNumericPrefix(""));
			assertNull(SwiftParseUtils.getNumericPrefix("asdfD"));
			assertNull(SwiftParseUtils.getNumericPrefix("s"));
			assertEquals("1", SwiftParseUtils.getNumericPrefix("1ABC"));
			assertEquals("1", SwiftParseUtils.getNumericPrefix("1"));
			assertEquals("234234", SwiftParseUtils.getNumericPrefix("234234ABC234234"));
			assertEquals("123,45", SwiftParseUtils.getNumericPrefix("123,45ABC234234asd"));
			assertEquals("123,", SwiftParseUtils.getNumericPrefix("123,ABC234234asd"));
			assertEquals(",", SwiftParseUtils.getNumericPrefix(",ABC234234asd"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetNumericSuffix() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetNumericSuffix()
		{
			assertNull(SwiftParseUtils.getNumericSuffix(null));
			assertNull(SwiftParseUtils.getNumericSuffix(""));
			assertNull(SwiftParseUtils.getNumericSuffix("asdfD"));
			assertNull(SwiftParseUtils.getNumericSuffix("s"));
			assertEquals("1", SwiftParseUtils.getNumericSuffix("ABC1"));
			assertEquals("1", SwiftParseUtils.getNumericSuffix("1"));
			assertEquals("234234", SwiftParseUtils.getNumericSuffix("ABC234234"));
			assertEquals("234234asd", SwiftParseUtils.getNumericSuffix("ABC234234asd"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTokenFirst() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetTokenFirst()
		{
			assertNull(SwiftParseUtils.getTokenFirst(null, null, null));
			assertNull(SwiftParseUtils.getTokenFirst("", "", ""));
			assertNull(SwiftParseUtils.getTokenFirst(null, null, "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst("foo", null, null));
			assertEquals("foo", SwiftParseUtils.getTokenFirst("foo", ":", null));
			assertEquals("foo", SwiftParseUtils.getTokenFirst("foo", null, "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst("foo", ":", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo", ":", null));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo", ":", null));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo/", ":", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo//", ":", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo//abc", ":", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo/abc/", ":", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo/abc/def", ":", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo//abc/def", ":", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo//abc/def/", ":", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenFirst(":foo//abc/def////asdsd", ":", "/"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTokenSecond() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetTokenSecond()
		{
			assertNull(SwiftParseUtils.getTokenSecond(null, null));
			assertNull(SwiftParseUtils.getTokenSecond("", ""));
			assertNull(SwiftParseUtils.getTokenSecond(null, "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo", null));
			assertNull(SwiftParseUtils.getTokenSecond("foo", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo/", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//abc", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//abc/", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//abc/jhs", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//abc/lksjdf//", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("/foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("abc/foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("abc/foo/def", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("abc/foo/def/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("abc/foo/def//", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("abc/foo/def/hsjs/slkdjf//dsd", "/"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTokenSecondWithPrefix() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetTokenSecondWithPrefix()
		{
			assertNull(SwiftParseUtils.getTokenSecond(null, null, null));
			assertNull(SwiftParseUtils.getTokenSecond("", "", ""));
			assertNull(SwiftParseUtils.getTokenSecond(null, null, "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo", null, null));
			assertNull(SwiftParseUtils.getTokenSecond("foo", "/", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo/", ":", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//", "/", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//abc", "/", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//abc/", "/", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//abc/jhs", "/", "/"));
			assertNull(SwiftParseUtils.getTokenSecond("foo//abc/lksjdf//", "/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("//foo", "/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("/abc/foo", "/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("/abc/foo/def", "/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("/abc/foo/def/", "/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("/abc/foo/def//", "/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecond("/abc/foo/def/hsjs/slkdjf//dsd", "/", "/"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTokenSecondLast() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetTokenSecondLast()
		{
			assertNull(SwiftParseUtils.getTokenSecondLast(null, null));
			assertNull(SwiftParseUtils.getTokenSecondLast("", ""));
			assertNull(SwiftParseUtils.getTokenSecondLast(null, "/"));
			assertNull(SwiftParseUtils.getTokenSecondLast("foo", null));
			assertNull(SwiftParseUtils.getTokenSecondLast("foo", "/"));
			assertNull(SwiftParseUtils.getTokenSecondLast("foo/", "/"));
			assertNotNull(SwiftParseUtils.getTokenSecondLast("foo//abc", "/"));
			assertNotNull(SwiftParseUtils.getTokenSecondLast("foo//abc/", "/"));
			assertNotNull(SwiftParseUtils.getTokenSecondLast("foo//abc/jhs", "/"));
			assertNotNull(SwiftParseUtils.getTokenSecondLast("foo//abc/lksjdf//", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecondLast("/foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecondLast("abc/foo", "/"));
			assertEquals("/", SwiftParseUtils.getTokenSecondLast("foo//", "/"));
			assertEquals("foo/def", SwiftParseUtils.getTokenSecondLast("abc/foo/def", "/"));
			assertEquals("foo/def/", SwiftParseUtils.getTokenSecondLast("abc/foo/def/", "/"));
			assertEquals("foo/def//", SwiftParseUtils.getTokenSecondLast("abc/foo/def//", "/"));
			assertEquals("foo/def/hsjs/slkdjf//dsd", SwiftParseUtils.getTokenSecondLast("abc/foo/def/hsjs/slkdjf//dsd", "/"));
			assertEquals("/", SwiftParseUtils.getTokenSecondLast("//", "/"));
			assertEquals("/", SwiftParseUtils.getTokenSecondLast("///", "//"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTokenSecondLastWithPrefix() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetTokenSecondLastWithPrefix()
		{
			assertNull(SwiftParseUtils.getTokenSecondLast(null, null, null));
			assertNull(SwiftParseUtils.getTokenSecondLast("", "", ""));
			assertNull(SwiftParseUtils.getTokenSecondLast(null, "/", "/"));
			assertNull(SwiftParseUtils.getTokenSecondLast("/foo", null, null));
			assertNull(SwiftParseUtils.getTokenSecondLast("/foo", "/", "/"));
			assertNull(SwiftParseUtils.getTokenSecondLast("/foo/", "/", "/"));
			assertNotNull(SwiftParseUtils.getTokenSecondLast("/foo//abc", "/", "/"));
			assertNotNull(SwiftParseUtils.getTokenSecondLast("/foo//abc/", "/", "/"));
			assertNotNull(SwiftParseUtils.getTokenSecondLast("/foo//abc/jhs", "/", "/"));
			assertNotNull(SwiftParseUtils.getTokenSecondLast("/foo//abc/lksjdf//", "/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecondLast("//foo", "/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenSecondLast("/abc/foo", "/", "/"));
			assertEquals("/", SwiftParseUtils.getTokenSecondLast("/foo//", "/", "/"));
			assertEquals("foo/def", SwiftParseUtils.getTokenSecondLast("/abc/foo/def", "/", "/"));
			assertEquals("foo/def/", SwiftParseUtils.getTokenSecondLast(":abc/foo/def/", ":", "/"));
			assertEquals("foo/def//", SwiftParseUtils.getTokenSecondLast(":abc/foo/def//", ":", "/"));
			assertEquals("foo/def/hsjs/slkdjf//dsd", SwiftParseUtils.getTokenSecondLast(":abc/foo/def/hsjs/slkdjf//dsd", ":", "/"));
			assertEquals("/", SwiftParseUtils.getTokenSecondLast("://", ":", "/"));
			assertEquals("/", SwiftParseUtils.getTokenSecondLast(":///", ":", "//"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTokenThird() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetTokenThird()
		{
			assertNull(SwiftParseUtils.getTokenThird(null, null));
			assertNull(SwiftParseUtils.getTokenThird("", ""));
			assertNull(SwiftParseUtils.getTokenThird(null, "/"));
			assertNull(SwiftParseUtils.getTokenThird("ddd", null));
			assertNull(SwiftParseUtils.getTokenThird("ddd", "/"));
			assertNull(SwiftParseUtils.getTokenThird("ddd/", "/"));
			assertNull(SwiftParseUtils.getTokenThird("ddd//", "/"));
			assertNull(SwiftParseUtils.getTokenThird("ddd/sss/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenThird("fff/ddd/foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenThird("fff//foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenThird("//foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenThird("fff/ddd/foo/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenThird("fff/ddd/foo//", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenThird("fff/ddd/foo/foo/foo//foo", "/"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTokenThirdLast() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetTokenThirdLast()
		{
			assertNull(SwiftParseUtils.getTokenThirdLast(null, null));
			assertNull(SwiftParseUtils.getTokenThirdLast("", ""));
			assertNull(SwiftParseUtils.getTokenThirdLast(null, "/"));
			assertNull(SwiftParseUtils.getTokenThirdLast("ddd", null));
			assertNull(SwiftParseUtils.getTokenThirdLast("ddd", "/"));
			assertNull(SwiftParseUtils.getTokenThirdLast("ddd/", "/"));
			assertNull(SwiftParseUtils.getTokenThirdLast("ddd//", "/"));
			assertNull(SwiftParseUtils.getTokenThirdLast("ddd/sss/", "/"));
			assertEquals("/", SwiftParseUtils.getTokenThirdLast("fff/ddd//", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenThirdLast("fff/ddd/foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenThirdLast("fff//foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenThirdLast("//foo", "/"));
			assertEquals("foo/", SwiftParseUtils.getTokenThirdLast("fff/ddd/foo/", "/"));
			assertEquals("foo//", SwiftParseUtils.getTokenThirdLast("fff/ddd/foo//", "/"));
			assertEquals("foo/foo/foo//foo", SwiftParseUtils.getTokenThirdLast("fff/ddd/foo/foo/foo//foo", "/"));
			assertEquals("/foo", SwiftParseUtils.getTokenThirdLast("///foo", "/"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTokenForth() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetTokenForth()
		{
			assertNull(SwiftParseUtils.getTokenForth(null, null));
			assertNull(SwiftParseUtils.getTokenForth("", ""));
			assertNull(SwiftParseUtils.getTokenForth(null, "/"));
			assertNull(SwiftParseUtils.getTokenForth("ddd", null));
			assertNull(SwiftParseUtils.getTokenForth("ddd", "/"));
			assertNull(SwiftParseUtils.getTokenForth("ddd/", "/"));
			assertNull(SwiftParseUtils.getTokenForth("ddd//", "/"));
			assertNull(SwiftParseUtils.getTokenForth("ddd/sss/", "/"));
			assertNull(SwiftParseUtils.getTokenForth("ddd/sss//", "/"));
			assertNull(SwiftParseUtils.getTokenForth("ddd/sss/eee/", "/"));
			assertNull(SwiftParseUtils.getTokenForth("ddd/sss/eee//", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenForth("fff/ddd/eee/foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenForth("fff///foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenForth("///foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenForth("fff/eee/ddd/foo/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenForth("fff/eee/ddd/foo//", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenForth("fff/eee/ddd/foo/foo/foo//foo", "/"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTokenForthLast() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetTokenForthLast()
		{
			assertNull(SwiftParseUtils.getTokenForthLast(null, null));
			assertNull(SwiftParseUtils.getTokenForthLast("", ""));
			assertNull(SwiftParseUtils.getTokenForthLast(null, "/"));
			assertNull(SwiftParseUtils.getTokenForthLast("ddd", null));
			assertNull(SwiftParseUtils.getTokenForthLast("ddd", "/"));
			assertNull(SwiftParseUtils.getTokenForthLast("ddd/", "/"));
			assertNull(SwiftParseUtils.getTokenForthLast("ddd//", "/"));
			assertNull(SwiftParseUtils.getTokenForthLast("ddd/sss/", "/"));
			assertNull(SwiftParseUtils.getTokenForthLast("ddd/sss//", "/"));
			assertNull(SwiftParseUtils.getTokenForthLast("ddd/sss/eee/", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenForthLast("fff/ddd/eee/foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenForthLast("fff///foo", "/"));
			assertEquals("foo", SwiftParseUtils.getTokenForthLast("///foo", "/"));
			assertEquals("/", SwiftParseUtils.getTokenForthLast("fff/eee/ddd//", "/"));
			assertEquals("foo/", SwiftParseUtils.getTokenForthLast("fff/eee/ddd/foo/", "/"));
			assertEquals("foo//", SwiftParseUtils.getTokenForthLast("fff/eee/ddd/foo//", "/"));
			assertEquals("foo/foo/foo//foo", SwiftParseUtils.getTokenForthLast("fff/eee/ddd/foo/foo/foo//foo", "/"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemovePrefix() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemovePrefix()
		{
			assertNull(SwiftParseUtils.removePrefix(null, null));
			assertNull(SwiftParseUtils.removePrefix(null, ""));
			assertNull(SwiftParseUtils.removePrefix(null, "/"));
			assertEquals("", SwiftParseUtils.removePrefix("", null));
			assertEquals("aaa", SwiftParseUtils.removePrefix("aaa", null));
			assertEquals("aaa", SwiftParseUtils.removePrefix("aaa", "/"));
			assertEquals("aaa", SwiftParseUtils.removePrefix("/aaa", "/"));
			assertEquals("/aaa", SwiftParseUtils.removePrefix("//aaa", "/"));
		}

	}

}