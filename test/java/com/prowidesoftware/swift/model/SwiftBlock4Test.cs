﻿/*
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
namespace com.prowidesoftware.swift.model
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
	using JsonObject = com.google.gson.JsonObject;
	using JsonParser = com.google.gson.JsonParser;

	using Test = org.junit.Test;

	using SwiftMessageComparator = com.prowidesoftware.swift.utils.SwiftMessageComparator;

	/// <summary>
	/// test cases for block 4 API
	/// 
	/// @author sebastian
	/// @since 7.8.8
	/// </summary>
	public class SwiftBlock4Test
	{

		private readonly SwiftMessageComparator comp = new SwiftMessageComparator();

		/// <summary>
		/// Null and Empty blocks
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveEmptySequencesNull()
		public virtual void testRemoveEmptySequencesNull()
		{
			assertNull(SwiftBlock4.removeEmptySequences(null));
			SwiftBlock4 b4 = SwiftBlock4.removeEmptySequences(new SwiftBlock4());
			assertTrue(b4.Empty);
		}

		/// <summary>
		/// Nothing to remove
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveEmptySequencesNOP()
		public virtual void testRemoveEmptySequencesNOP()
		{
			SwiftBlock4 b = new SwiftBlock4();
			b.append(new Tag("20", "FOO"));
			b.append(new Tag("21", "FOO"));
			b.append(new Tag("16R", "FOO"));
			b.append(new Tag("20", "FOO"));
			b.append(new Tag("16S", "FOO"));
			b.append(new Tag("20", "FOO"));
			b.append(new Tag("15A", "FOO"));
			b.append(new Tag("20", "FOO"));
			SwiftBlock4 clean = SwiftBlock4.removeEmptySequences(b);
			assertTrue(comp.compareTagListBlock(b, clean));
		}

		/// <summary>
		/// 16RS removed
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveEmptySequences16RS()
		public virtual void testRemoveEmptySequences16RS()
		{
			SwiftBlock4 b = new SwiftBlock4();
			b.append(new Tag("20", "FOO"));
			b.append(new Tag("21", "FOO"));
			b.append(new Tag("16R", "FOO"));
			b.append(new Tag("16S", "FOO"));
			b.append(new Tag("20", "FOO"));
			b.append(new Tag("15A", "FOO"));
			b.append(new Tag("20", "FOO"));
			SwiftBlock4 clean = SwiftBlock4.removeEmptySequences(b);
			assertFalse(comp.compareTagListBlock(b, clean));
			assertEquals(5, clean.size());
			assertEquals(b.getTag(0), clean.getTag(0));
			assertEquals(b.getTag(1), clean.getTag(1));
			assertEquals(b.getTag(4), clean.getTag(2));
			assertEquals(b.getTag(5), clean.getTag(3));
			assertEquals(b.getTag(6), clean.getTag(4));
		}

		/// <summary>
		/// 15a removed
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveEmptySequences15a()
		public virtual void testRemoveEmptySequences15a()
		{
			SwiftBlock4 b = new SwiftBlock4();
			b.append(new Tag("20", "FOO"));
			b.append(new Tag("15A", ""));
			b.append(new Tag("15B", ""));
			b.append(new Tag("20", "FOO"));
			b.append(new Tag("15C", ""));
			SwiftBlock4 clean = SwiftBlock4.removeEmptySequences(b);
			assertFalse(comp.compareTagListBlock(b, clean));
			assertEquals(3, clean.size());
			assertEquals(b.getTag(0), clean.getTag(0));
			assertEquals(b.getTag(2), clean.getTag(1));
			assertEquals(b.getTag(3), clean.getTag(2));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveEmptySequences15a_2()
		public virtual void testRemoveEmptySequences15a_2()
		{
			SwiftBlock4 b = new SwiftBlock4();
			b.append(new Tag("15A", ""));
			b.append(new Tag("20", "FOO"));
			b.append(new Tag("15B", ""));
			b.append(new Tag("15C", ""));
			b.append(new Tag("15D", ""));
			b.append(new Tag("15E", ""));
			b.append(new Tag("17W", "Y"));
			SwiftBlock4 clean = SwiftBlock4.removeEmptySequences(b);
			assertFalse(comp.compareTagListBlock(b, clean));
			assertEquals("15A", clean.getTag(0).Name);
			assertEquals("20", clean.getTag(1).Name);
			assertEquals("15E", clean.getTag(2).Name);
			assertEquals("17W", clean.getTag(3).Name);
			assertEquals(4, clean.size());
		}

	}

}