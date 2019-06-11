using System.Collections.Generic;

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
namespace com.prowidesoftware.swift.model
{

	using ConversionService = com.prowidesoftware.swift.io.ConversionService;
	using com.prowidesoftware.swift.model.field;
	using Before = org.junit.Before;
	using Test = org.junit.Test;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// Tag list block tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class SwiftTagListBlockTest
	{

		private SwiftTagListBlock b;
		private Tag t;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Before public void setUp()
		public virtual void setUp()
		{
			this.b = new SwiftBlock3();
			this.t = new Tag("n:v");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testContainsTag()
		public virtual void testContainsTag()
		{
			b.append(t);
			assertTrue(b.containsTag("n"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCountStartsWith()
		public virtual void testCountStartsWith()
		{
			b.append(new Tag("1", "FOO"));
			b.append(new Tag("1", "BAR"));
			b.append(new Tag("1", "FOO2"));
			b.append(new Tag("1", "FOO"));

			b.append(new Tag("2", "FOO"));
			b.append(new Tag("2", "BAR"));
			b.append(new Tag("2", "FOO2"));
			b.append(new Tag("2", "FOO"));

			b.append(new Tag("1", "FOO"));
			b.append(new Tag("1", "BAR"));
			b.append(new Tag("1", "FOO2"));
			b.append(new Tag("1", "FOO"));

			assertEquals(6, b.countTagsStarsWith("1", "FOO"));
			assertEquals(2, b.countTagsStarsWith("1", "FOO2"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testContainsAll()
		public virtual void testContainsAll()
		{
			b.append(t);
			b.append(new Tag("1", "val"));
			assertTrue(b.containsAllOf(t.Name, "1"));
			assertFalse(b.containsAllOf(t.Name, "2"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagValue()
		public virtual void testGetTagValue()
		{
			b.append(t);
			assertEquals("v", b.getTagValue("n"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagByName()
		public virtual void testGetTagByName()
		{
			b.append(t);
			Tag found = b.getTagByName("n");
			assertEquals(t, found);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsEmpty()
		public virtual void testIsEmpty()
		{
			assertTrue(b.Empty);
			b.append(t);
			assertFalse(b.Empty);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSize()
		public virtual void testSize()
		{
			assertEquals(0, b.size());
			b.append(t);
			assertEquals(1, b.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagCount()
		public virtual void testGetTagCount()
		{
			assertEquals(0, b.countAll());
			b.append(t);
			assertEquals(1, b.countAll());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagCountString()
		public virtual void testGetTagCountString()
		{
			b.append(t);
			b.append(t);
			b.append(t);
			assertEquals(3, b.countByName("n"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagValues()
		public virtual void testGetTagValues()
		{
			Tag t = new Tag("1:val1");
			b.append(t);

			string[] vals = b.getTagValues("foo");
			assertNotNull(vals);
			assertEquals(0, vals.Length);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagMap()
		public virtual void testGetTagMap()
		{
			IDictionary<string, string> m = b.TagMap;
			assertTrue(m.Count == 0);

			b.append(t);
			m = b.TagMap;

			assertEquals(1, m.Count);
			assertTrue(m.ContainsKey("n"));
			assertTrue(m.ContainsValue("v"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveTag()
		public virtual void testRemoveTag()
		{
			b.removeTag("");
			assertTrue(b.Empty);
			b.append(t);
			assertFalse(b.Empty);
			b.removeTag("n");
			assertTrue(b.Empty);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTagIterator()
		public virtual void testTagIterator()
		{
			b.getTags().Clear();
			IEnumerator<Tag> it = b.tagIterator();
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			assertFalse(it.hasNext());

			b.append(t);
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			assertEquals(t, b.tagIterator().next());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsTagBlock()
		public virtual void testIsTagBlock()
		{
			assertTrue(b.TagBlock);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagValuesEmpty2()
		public virtual void testGetTagValuesEmpty2()
		{
			string[] vals = b.getTagValues("foo");
			assertNotNull(vals);
			assertEquals(0, vals.Length);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagValues1()
		public virtual void testGetTagValues1()
		{
			Tag t = new Tag("1:val1");
			b.append(t);

			string[] vals = b.getTagValues("1");
			assertNotNull(vals);
			assertEquals(1, vals.Length);
			assertEquals("val1", vals[0]);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagValues2()
		public virtual void testGetTagValues2()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("1:val2"));

			string[] vals = b.getTagValues("1");
			assertNotNull(vals);
			assertEquals(2, vals.Length);
			assertEquals("val1", vals[0]);
			assertEquals("val2", vals[1]);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveAll1()
		public virtual void testRemoveAll1()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("1:val2"));

			int vals = b.removeAll("1");
			assertEquals(2, vals);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveAll2()
		public virtual void testRemoveAll2()
		{
			b.append(new Tag("a:val1"));
			b.append(new Tag("1:val1"));
			b.append(new Tag("b:val1"));
			b.append(new Tag("1:val1"));
			b.append(new Tag("c:val2"));

			int vals = b.removeAll("1");
			assertEquals(2, vals);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetTagsByName()
		public virtual void testgetTagsByName()
		{
			b.append(new Tag("a:val1"));
			b.append(new Tag("1:val1"));
			b.append(new Tag("b:val1"));
			b.append(new Tag("1:val2"));
			b.append(new Tag("c:val3"));

			Tag[] tags = b.getTagsByName("1");
			assertEquals(2, tags.Length);
			assertEquals("val1", tags[0].Value);
			assertEquals("val2", tags[1].Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetTagsByValue()
		public virtual void testgetTagsByValue()
		{
			b.append(new Tag("a:val1"));
			b.append(new Tag("1:val1"));
			b.append(new Tag("1:val2"));
			b.append(new Tag("c:val3"));
			b.append(new Tag("b:val1"));
			IList<Tag> tags = b.getTagsByValue("val1");

			assertEquals(3, tags.Count);
			assertEquals("a", tags[0].Name);
			assertEquals("1", tags[1].Name);
			assertEquals("b", tags[2].Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetTagsByContent()
		public virtual void testgetTagsByContent()
		{
			b.append(new Tag("a:val1aaa"));
			b.append(new Tag("1:dddval1"));
			b.append(new Tag("1:val2"));
			b.append(new Tag("c:val3"));
			b.append(new Tag("b:ffval1gg"));
			IList<Tag> tags = b.getTagsByContent("val1");

			assertEquals(3, tags.Count);
			assertEquals("a", tags[0].Name);
			assertEquals("1", tags[1].Name);
			assertEquals("b", tags[2].Name);
		}

		/// <summary>
		/// Normal test with starting and ending tag
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock01()
		public virtual void testgetSubBlock01()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));

			SwiftTagListBlock sb = b.getSubBlock(new Tag("2:val2"), new Tag("4:val4"));

			assertEquals(3, sb.size());
			assertEquals("2", sb.getTag(0).Name);
			assertEquals("3", sb.getTag(1).Name);
			assertEquals("4", sb.getTag(2).Name);
			assertEquals("val2", sb.getTag(0).Value);
			assertEquals("val3", sb.getTag(1).Value);
			assertEquals("val4", sb.getTag(2).Value);
		}

		/// <summary>
		/// Normal test with no ending tag
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock02()
		public virtual void testgetSubBlock02()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));

			SwiftTagListBlock sb = b.getSubBlock(new Tag("2:val2"), null);

			assertEquals(4, sb.size());
			assertEquals("2", sb.getTag(0).Name);
			assertEquals("3", sb.getTag(1).Name);
			assertEquals("4", sb.getTag(2).Name);
			assertEquals("5", sb.getTag(3).Name);
			assertEquals("val2", sb.getTag(0).Value);
			assertEquals("val3", sb.getTag(1).Value);
			assertEquals("val4", sb.getTag(2).Value);
			assertEquals("val5", sb.getTag(3).Value);
		}

		/// <summary>
		/// Normal test using block names
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock03()
		public virtual void testgetSubBlock03()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("16R:foo"));
			b.append(new Tag("3:val3"));
			b.append(new Tag("16S:foo"));
			b.append(new Tag("5:val5"));

			SwiftTagListBlock sb = b.getSubBlock("foo");

			assertEquals(3, sb.size());
			assertEquals("16R", sb.getTag(0).Name);
			assertEquals("3", sb.getTag(1).Name);
			assertEquals("16S", sb.getTag(2).Name);
			assertEquals("foo", sb.getTag(0).Value);
			assertEquals("val3", sb.getTag(1).Value);
			assertEquals("foo", sb.getTag(2).Value);
		}

		/// <summary>
		/// Test using block name, with nested sub blocks
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock04()
		public virtual void testgetSubBlock04()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("16R:foo"));
			b.append(new Tag("3:val3"));
			b.append(new Tag("16R:aaa"));
			b.append(new Tag("3:val3"));
			b.append(new Tag("16S:aaa"));
			b.append(new Tag("16S:foo"));
			b.append(new Tag("5:val5"));

			SwiftTagListBlock sb = b.getSubBlock("foo");

			assertEquals(6, sb.size());

			assertEquals("16R", sb.getTag(0).Name);
			assertEquals("foo", sb.getTag(0).Value);

			assertEquals("3", sb.getTag(1).Name);
			assertEquals("val3", sb.getTag(1).Value);

			assertEquals("16R", sb.getTag(2).Name);
			assertEquals("aaa", sb.getTag(2).Value);

			assertEquals("3", sb.getTag(3).Name);
			assertEquals("val3", sb.getTag(3).Value);

			assertEquals("16S", sb.getTag(4).Name);
			assertEquals("aaa", sb.getTag(4).Value);

			assertEquals("16S", sb.getTag(5).Name);
			assertEquals("foo", sb.getTag(5).Value);
		}

		/// <summary>
		/// Ending tag precedes starting tag
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock05()
		public virtual void testgetSubBlock05()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("3:val3"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("5:val5"));

			SwiftTagListBlock sb = b.getSubBlock(new Tag("2:val2"), new Tag("4:val4"));

			assertEquals(2, sb.size());
			assertEquals("2", sb.getTag(0).Name);
			assertEquals("val2", sb.getTag(0).Value);
			assertEquals("5", sb.getTag(1).Name);
			assertEquals("val5", sb.getTag(1).Value);
		}

		/// <summary>
		/// Normal test with starting and ending tag and multiple sub blocks
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock06()
		public virtual void testgetSubBlock06()
		{
			b.append(new Tag("99:foo"));
			b.append(new Tag("1:start"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:end"));
			b.append(new Tag("88:foo"));
			b.append(new Tag("1:start"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("3:end"));
			b.append(new Tag("77:foo"));

			IList<SwiftTagListBlock> sbs = b.getSubBlocks(new Tag("1:start"), new Tag("3:end"));

			assertEquals(2, sbs.Count);

			SwiftTagListBlock sb = sbs[0];
			assertEquals(3, sb.size());
			assertEquals("1", sb.getTag(0).Name);
			assertEquals("start", sb.getTag(0).Value);
			assertEquals("2", sb.getTag(1).Name);
			assertEquals("val2", sb.getTag(1).Value);
			assertEquals("3", sb.getTag(2).Name);
			assertEquals("end", sb.getTag(2).Value);

			SwiftTagListBlock sb2 = sbs[1];
			assertEquals(3, sb2.size());
			assertEquals("1", sb2.getTag(0).Name);
			assertEquals("start", sb2.getTag(0).Value);
			assertEquals("4", sb2.getTag(1).Name);
			assertEquals("val4", sb2.getTag(1).Value);
			assertEquals("3", sb2.getTag(2).Name);
			assertEquals("end", sb2.getTag(2).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplit()
		public virtual void testSplit()
		{
			b.append(new Tag("99:foo"));

			b.append(new Tag("1:start"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:end"));
			b.append(new Tag("88:foo"));

			b.append(new Tag("1:start"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("3:end"));
			b.append(new Tag("77:foo"));
			b.append(new Tag("77:foo"));

			IList<SwiftTagListBlock> sbs = b.splitByTagName("1");

			assertEquals(3, sbs.Count);

			SwiftTagListBlock sb = sbs[0];
			assertEquals(1, sb.size());
			assertEquals("99", sb.getTag(0).Name);

			SwiftTagListBlock sb2 = sbs[1];
			assertEquals(4, sb2.size());

			SwiftTagListBlock sb3 = sbs[2];
			assertEquals(5, sb3.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplitByNonexisting()
		public virtual void testSplitByNonexisting()
		{
			b.append(new Tag("99:foo"));
			b.append(new Tag("1:start"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:end"));
			b.append(new Tag("88:foo"));

			IList<SwiftTagListBlock> sbs = b.splitByTagName("XX");

			assertEquals(1, sbs.Count);
			assertEquals(5, sbs[0].size());
		}

		/// <summary>
		/// Normal test using block name and multiple sub blocks
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock07()
		public virtual void testgetSubBlock07()
		{
			b.append(new Tag("99:foo"));
			b.append(new Tag("16R:blockname"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("16S:blockname"));
			b.append(new Tag("88:foo"));
			b.append(new Tag("16R:blockname"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("16S:blockname"));
			b.append(new Tag("77:foo"));

			IList<SwiftTagListBlock> sbs = b.getSubBlocks("blockname");

			assertEquals(2, sbs.Count);

			SwiftTagListBlock sb = sbs[0];
			assertEquals(3, sb.size());
			assertEquals("16R", sb.getTag(0).Name);
			assertEquals("blockname", sb.getTag(0).Value);
			assertEquals("2", sb.getTag(1).Name);
			assertEquals("val2", sb.getTag(1).Value);
			assertEquals("16S", sb.getTag(2).Name);
			assertEquals("blockname", sb.getTag(2).Value);

			SwiftTagListBlock sb2 = sbs[1];
			assertEquals(3, sb2.size());
			assertEquals("16R", sb2.getTag(0).Name);
			assertEquals("blockname", sb2.getTag(0).Value);
			assertEquals("4", sb2.getTag(1).Name);
			assertEquals("val4", sb2.getTag(1).Value);
			assertEquals("16S", sb2.getTag(2).Name);
			assertEquals("blockname", sb2.getTag(2).Value);
		}

		/// <summary>
		/// Test using block name and multiple sub blocks, with nested sub blocks
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock08()
		public virtual void testgetSubBlock08()
		{
			b.append(new Tag("99:foo"));
			b.append(new Tag("16R:blockname"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("16S:blockname"));
			b.append(new Tag("88:foo"));
			b.append(new Tag("16R:blockname"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("16R:foo"));
			b.append(new Tag("66:foo"));
			b.append(new Tag("16S:foo"));
			b.append(new Tag("16S:blockname"));
			b.append(new Tag("77:foo"));

			IList<SwiftTagListBlock> sbs = b.getSubBlocks("blockname");

			assertEquals(2, sbs.Count);

			SwiftTagListBlock sb = sbs[0];
			assertEquals(3, sb.size());
			assertEquals("16R", sb.getTag(0).Name);
			assertEquals("blockname", sb.getTag(0).Value);
			assertEquals("2", sb.getTag(1).Name);
			assertEquals("val2", sb.getTag(1).Value);
			assertEquals("16S", sb.getTag(2).Name);
			assertEquals("blockname", sb.getTag(2).Value);

			SwiftTagListBlock sb2 = sbs[1];
			assertEquals(6, sb2.size());
			assertEquals("16R", sb2.getTag(0).Name);
			assertEquals("blockname", sb2.getTag(0).Value);
			assertEquals("4", sb2.getTag(1).Name);
			assertEquals("val4", sb2.getTag(1).Value);
			assertEquals("16R", sb2.getTag(2).Name);
			assertEquals("foo", sb2.getTag(2).Value);
			assertEquals("66", sb2.getTag(3).Name);
			assertEquals("foo", sb2.getTag(3).Value);
			assertEquals("16S", sb2.getTag(4).Name);
			assertEquals("foo", sb2.getTag(4).Value);
			assertEquals("16S", sb2.getTag(5).Name);
			assertEquals("blockname", sb2.getTag(5).Value);
		}

		/// <summary>
		/// Test using block name and multiple sub blocks, with nested sub blocks and missing ending tag
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock09()
		public virtual void testgetSubBlock09()
		{
			b.append(new Tag("99:foo"));
			b.append(new Tag("16R:blockname"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("16S:blockname"));
			b.append(new Tag("88:foo"));
			b.append(new Tag("16R:blockname"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("16R:foo"));
			b.append(new Tag("66:foo"));
			b.append(new Tag("16S:foo"));
			b.append(new Tag("77:foo"));

			IList<SwiftTagListBlock> sbs = b.getSubBlocks("blockname");

			assertEquals(2, sbs.Count);

			SwiftTagListBlock sb = sbs[0];
			assertEquals(3, sb.size());
			assertEquals("16R", sb.getTag(0).Name);
			assertEquals("blockname", sb.getTag(0).Value);
			assertEquals("2", sb.getTag(1).Name);
			assertEquals("val2", sb.getTag(1).Value);
			assertEquals("16S", sb.getTag(2).Name);
			assertEquals("blockname", sb.getTag(2).Value);

			SwiftTagListBlock sb2 = sbs[1];
			assertEquals(6, sb2.size());
			assertEquals("16R", sb2.getTag(0).Name);
			assertEquals("blockname", sb2.getTag(0).Value);
			assertEquals("4", sb2.getTag(1).Name);
			assertEquals("val4", sb2.getTag(1).Value);
			assertEquals("16R", sb2.getTag(2).Name);
			assertEquals("foo", sb2.getTag(2).Value);
			assertEquals("66", sb2.getTag(3).Name);
			assertEquals("foo", sb2.getTag(3).Value);
			assertEquals("16S", sb2.getTag(4).Name);
			assertEquals("foo", sb2.getTag(4).Value);
			assertEquals("77", sb2.getTag(5).Name);
			assertEquals("foo", sb2.getTag(5).Value);
		}

		/// <summary>
		/// Normal test with starting and ending tag names and multiple sub blocks
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock10()
		public virtual void testgetSubBlock10()
		{
			b.append(new Tag("99:foo"));
			b.append(new Tag("1:start"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:end"));
			b.append(new Tag("88:foo"));
			b.append(new Tag("1:start"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("3:end"));
			b.append(new Tag("77:foo"));

			IList<SwiftTagListBlock> sbs = b.getSubBlocks("1", "3");

			assertEquals(2, sbs.Count);

			SwiftTagListBlock sb = sbs[0];
			assertEquals(3, sb.size());
			assertEquals("1", sb.getTag(0).Name);
			assertEquals("start", sb.getTag(0).Value);
			assertEquals("2", sb.getTag(1).Name);
			assertEquals("val2", sb.getTag(1).Value);
			assertEquals("3", sb.getTag(2).Name);
			assertEquals("end", sb.getTag(2).Value);

			SwiftTagListBlock sb2 = sbs[1];
			assertEquals(3, sb2.size());
			assertEquals("1", sb2.getTag(0).Name);
			assertEquals("start", sb2.getTag(0).Value);
			assertEquals("4", sb2.getTag(1).Name);
			assertEquals("val4", sb2.getTag(1).Value);
			assertEquals("3", sb2.getTag(2).Name);
			assertEquals("end", sb2.getTag(2).Value);
		}

		/// <summary>
		/// Normal test with starting and ending tag names and multiple sub blocks
		/// using tag number for end boundary (regardless of letter option)
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock10b()
		public virtual void testgetSubBlock10b()
		{
			b.append(new Tag("99:foo"));
			b.append(new Tag("1:start"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3A:end"));
			b.append(new Tag("88:foo"));
			b.append(new Tag("1:start"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("3B:end"));
			b.append(new Tag("77:foo"));

			IList<SwiftTagListBlock> sbs = b.getSubBlocks("1", 3);

			assertEquals(2, sbs.Count);

			SwiftTagListBlock sb = sbs[0];
			assertEquals(3, sb.size());
			assertEquals("1", sb.getTag(0).Name);
			assertEquals("start", sb.getTag(0).Value);
			assertEquals("2", sb.getTag(1).Name);
			assertEquals("val2", sb.getTag(1).Value);
			assertEquals("3A", sb.getTag(2).Name);
			assertEquals("end", sb.getTag(2).Value);

			SwiftTagListBlock sb2 = sbs[1];
			assertEquals(3, sb2.size());
			assertEquals("1", sb2.getTag(0).Name);
			assertEquals("start", sb2.getTag(0).Value);
			assertEquals("4", sb2.getTag(1).Name);
			assertEquals("val4", sb2.getTag(1).Value);
			assertEquals("3B", sb2.getTag(2).Name);
			assertEquals("end", sb2.getTag(2).Value);
		}

		/// <summary>
		/// Not found
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testgetSubBlock11()
		public virtual void testgetSubBlock11()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));

			SwiftTagListBlock sb = b.getSubBlock(new Tag("7:val7"), new Tag("8:val8"));

			assertEquals(0, sb.size());
		}

		/// <summary>
		/// Not found
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testContainTag()
		public virtual void testContainTag()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			assertTrue(b.containsTag(new Tag("4:val4")));
			assertFalse(b.containsTag(new Tag("4:foo")));
			assertFalse(b.containsTag(new Tag("foo:val4")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testContainsField()
		public virtual void testContainsField()
		{
			b.append(new Tag("21E:"));
			b.append(new Tag("50B:"));
			assertTrue(b.containsField("50B"));
			assertTrue(b.containsField("50a"));
			assertTrue(b.containsField("21E"));
			assertTrue(b.containsField("21a"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFieldsByNameEmptyResult()
		public virtual void testFieldsByNameEmptyResult()
		{
			// empty result
			b.append(new Tag("1", "foo"));
			Field[] fieldsByName = b.getFieldsByName("2");
			assertEquals(0, fieldsByName.Length);

			// empty result with empty set
			Field[] o = (new SwiftTagListBlock()).getFieldsByName("");
			assertEquals(0, o.Length);

			o = (new SwiftTagListBlock()).getFieldsByName("1");
			assertEquals(0, o.Length);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFieldsByNameWildcards()
		public virtual void testFieldsByNameWildcards()
		{
			b.append(new Tag("95C", "foo"));
			Field[] fieldsByName = b.getFieldsByName("95a");
			assertEquals(1, fieldsByName.Length);

			b.append(new Tag("93", "bar"));
			fieldsByName = b.getFieldsByName("95a");
			assertEquals(1, fieldsByName.Length);

			b.append(new Tag("95C", "foo2"));
			fieldsByName = b.getFieldsByName("95a");
			assertEquals(2, fieldsByName.Length);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFieldsByNameBeing()
		public virtual void testFieldsByNameBeing()
		{
			b.append(new Tag("95C", "foo"));
			assertEquals(1, b.getFieldsByName("95a", "foo").Count);

			b.append(new Tag("93", "bar"));
			assertEquals(1, b.getFieldsByName("95a", "foo").Count);

			b.append(new Tag("95C", "foo"));
			b.append(new Tag("95C", "foo2"));
			b.append(new Tag("95C", "foo2"));
			b.append(new Tag("95C", "foo2"));
			assertEquals(2, b.getFieldsByName("95a", "foo").Count);
			assertEquals(3, b.getFieldsByName("95a", "foo2").Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTagsByNameBeing()
		public virtual void testTagsByNameBeing()
		{
			b.append(new Tag("95C", "foo"));
			assertEquals(1, b.getTagsByName("95a", "foo").Count);

			b.append(new Tag("93", "bar"));
			assertEquals(1, b.getTagsByName("95a", "foo").Count);

			b.append(new Tag("95C", "foo"));
			b.append(new Tag("95C", "foo2"));
			b.append(new Tag("95C", "foo2"));
			b.append(new Tag("95C", "foo2"));
			assertEquals(2, b.getTagsByName("95a", "foo").Count);
			assertEquals(3, b.getTagsByName("95a", "foo2").Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetTagIndex()
		public virtual void testGetTagIndex()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));

			assertEquals((int)0, (int)b.getTagIndex("1", null));
			assertEquals((int)2, (int)b.getTagIndex("3", new string[]{"A", "B", "K"}));
			assertEquals((int)3, (int)b.getTagIndex("4", new string[]{"A", "B", "K", ""}));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockAfterFirst() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockAfterFirst()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.getSubBlockAfterFirst("2", true);
			assertEquals(4, sb.size());
			assertEquals("val2", sb.getTag(0).Value);
			assertEquals("val5", sb.getTag(3).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockAfterFirst2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockAfterFirst2()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.getSubBlockAfterFirst("3K", true);
			assertEquals(3, sb.size());
			assertEquals("val3", sb.getTag(0).Value);
			assertEquals("val5", sb.getTag(2).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockAfterFirst3() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockAfterFirst3()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.getSubBlockAfterFirst("3K", false);
			assertEquals(5, sb.size());
			assertEquals("val4", sb.getTag(0).Value);
			assertEquals("val8", sb.getTag(4).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockAfterFirstLimit() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockAfterFirstLimit()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.getSubBlockAfterFirst("8", false);
			assertEquals(0, sb.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockAfterFirstLimit2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockAfterFirstLimit2()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.getSubBlockAfterFirst("1", false);
			assertEquals(7, sb.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockAfterFirstNotFound() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockAfterFirstNotFound()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.getSubBlockAfterFirst("99", false);
			assertEquals(0, sb.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockAfterFirstTag() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockAfterFirstTag()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.getSubBlockAfterFirst(new Tag("3K:val3"), false);
			assertEquals(5, sb.size());
			assertEquals("val4", sb.getTag(0).Value);
			assertEquals("val8", sb.getTag(4).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockBeforeFirst() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockBeforeFirst()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.getSubBlockBeforeFirst("2", false);
			assertEquals(1, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockBeforeLast() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockBeforeLast()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.getSubBlockBeforeLast("2", false);
			assertEquals(3, sb.size());
			assertEquals("val3", sb.getTag(2).Value);

			sb = b.getSubBlockBeforeLast("2", true);
			assertEquals(4, sb.size());
			assertEquals("val2", sb.getTag(3).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIndexOfLast() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testIndexOfLast()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("5:val5"));

			assertEquals(3, b.indexOfLast("2"));

			assertEquals(0, b.indexOfLast("1"));

			assertEquals(4, b.indexOfLast("5"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockAfterLast() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockAfterLast()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.getSubBlockAfterLast("2", false);
			assertEquals(1, sb.size());
			assertEquals("val5", sb.getTag(0).Value);

			sb = b.getSubBlockAfterLast("2", true);
			assertEquals(2, sb.size());
			assertEquals("val5", sb.getTag(1).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockBeforeFirst2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockBeforeFirst2()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.getSubBlockBeforeFirst("2", true);
			assertEquals(2, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
			assertEquals("val2", sb.getTag(1).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockBeforeFirst3() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockBeforeFirst3()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.getSubBlockBeforeFirst("3K", true);
			assertEquals(3, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
			assertEquals("val2", sb.getTag(1).Value);
			assertEquals("val3", sb.getTag(2).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockBeforeFirstFirst2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockBeforeFirstFirst2()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.getSubBlockBeforeFirst("3K", false);
			assertEquals(2, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
			assertEquals("val2", sb.getTag(1).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockBeforeFirstLimit() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockBeforeFirstLimit()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.getSubBlockBeforeFirst("1", false);
			assertEquals(0, sb.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockBeforeFirstLimit2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockBeforeFirstLimit2()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.getSubBlockBeforeFirst("8", false);
			assertEquals(7, sb.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockBeforeFirstNotFound() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockBeforeFirstNotFound()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.getSubBlockBeforeFirst("99", false);
			assertEquals(8, sb.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTrimAfterFirst() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testTrimAfterFirst()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.trimAfterFirst("4", false);
			assertEquals(3, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
			assertEquals("val3", sb.getTag(2).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemove() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemove()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			string sb = b.removeTag("3K");
			assertEquals("val3", sb);
			assertEquals(4, b.size());
		}

		/// <summary>
		/// Test for subblocks API with real case message
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockMT564()
		public virtual void testGetSubBlockMT564()
		{
			const string msg = "{1:F01MTGSUS6SAXXX3206837054}{2:O5641435070316CHASGB2LDGST07128160300703160735N}{3:{108:000255CQ8272245}}{4:\n" + ":16R:GENL\n" + ":20C::CORP//D455103\n" + ":20C::SEME//029206016\n" + ":23G:NEWM\n" + ":22F::CAEV//DVCA\n" + ":22F::CAMV//MAND\n" + ":98C::PREP//20070316143348\n" + ":25D::PROC//COMP\n" + ":16S:GENL\n" + ":16R:USECU\n" + ":35B:ISIN CH0011075394\n" + "/XX/5983816\n" + "ZURICH FIN SVS GRP\n" + "CHF0.10\n" + ":16R:ACCTINFO\n" + ":97A::SAFE//760043140\n" + ":94F::SAFE//CUST/UBSWCHZH80A\n" + ":93B::ELIG//UNIT/7000,\n" + ":16S:ACCTINFO\n" + ":16S:USECU\n" + ":16R:CADETL\n" + ":98A::XDTE//20111111\n" + ":98A::PAYD//20111111\n" + ":98A::RDTE//20111111\n" + ":92A::WITF//35,\n" + ":92A::GRSS//0,000001000\n" + ":16S:CADETL\n" + ":16R:CAOPTN\n" + ":13A::CAON//001\n" + ":22F::CAOP//CASH\n" + ":11A::OPTN//CHF\n" + ":17B::DFLT//Y\n" + ":98A::XDTE//20111111\n" + ":98A::PAYD//20111111\n" + ":98A::RDTE//20111111\n" + ":92A::GRSS//0,000001000\n" + ":16R:CASHMOVE\n" + ":22H::CRDB//CRED\n" + ":19B::ENTL//CHF0,01\n" + ":19B::GRSS//CHF0,01\n" + ":19B::NETT//CHF0,01\n" + ":98A::PAYD//20111111\n" + ":98A::VALU//20111111\n" + ":16S:CASHMOVE\n" + ":16S:CAOPTN\n" + "-}";
			//parse text message into SWIFT message object
			SwiftMessage o = (new ConversionService()).getMessageFromFIN(msg);
			IList<SwiftTagListBlock> sequencesB2 = o.Block4.getSubBlocks("ACCTINFO");
			IList<SwiftTagListBlock> sequencesC = o.Block4.getSubBlocks("INTSEC");

			foreach (SwiftTagListBlock seq in sequencesB2)
			{
				Field[] fields = seq.getFieldsByName("93B");
				assertEquals(1, fields.Length);
				Field93B f = (Field93B) fields[0];
				assertEquals(":ELIG//UNIT/7000,", f.Value);
			}

			assertTrue(sequencesC.Count == 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFilterByName() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFilterByName()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.filterByName(true, "1", "4", "7");
			assertEquals(3, sb.size());
			assertEquals("val7", sb.getTag(2).Value);
			sb = b.filterByName(false, "1", "4", "7");
			assertEquals(5, sb.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFilterByName2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFilterByName2()
		{
			SwiftTagListBlock sb = b.filterByName(true, "1", "4", "7");
			assertEquals(0, sb.size());

			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));

			sb = b.filterByName(false);
			assertEquals(8, sb.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFilterByNameOrdered() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testFilterByNameOrdered()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("3K:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));
			SwiftTagListBlock sb = b.filterByNameOrdered("1", "2", "4");
			assertEquals(2, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
			assertEquals("val2", sb.getTag(1).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetOptionalList() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetOptionalList()
		{

			b.append(new Tag("1:val1")); // entra, en primera fila de permitidos
			b.append(new Tag("2:val2")); // entra en la tercera
			b.append(new Tag("3:val3")); // no entra, de la tercera ya se consumui el priero, y de cada fila se acepta uno
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			b.append(new Tag("6:val6"));
			b.append(new Tag("7:val7"));
			b.append(new Tag("8:val8"));

			SwiftTagListBlock result = b.getOptionalList(new string[][]{new string[] {"1a", "1b", "1"}, new string[] {"2e", "2c"}, new string[] {"2", "3"}});

			assertEquals(2, result.size());
			assertEquals("val1", result.getTag(0).Value);
			assertEquals("val2", result.getTag(1).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetOptionalLists() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetOptionalLists()
		{
			appends(b, 1, 8);
			appends(b, 1, 8);

			IList<SwiftTagListBlock> result = b.getOptionalLists(new string[][]{new string[] {"1a", "1b", "1"}, new string[] {"2e", "2c"}, new string[] {"2", "3"}});

			assertNotNull(result);
			assertEquals(2, result.Count);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockDelimitedWithOptionalTail() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockDelimitedWithOptionalTail()
		{
			appends(b, 1, 8);

			string[] start = new string[]{"1"};
			string[] end = new string[]{"5c", "5b", "5"};
			string[] tail = new string[]{};
			SwiftTagListBlock result = b.getSubBlockDelimitedWithOptionalTail(start, end, tail);

			assertEquals("" + result.tagNamesList(), 5, result.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlocksDelimitedWithOptionalTail() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlocksDelimitedWithOptionalTail()
		{
			appends(b, 1, 8);
			appends(b, 1, 8);

			string[] start = new string[]{"1"};
			string[] end = new string[]{"5c", "5b", "5"};
			string[] tail = new string[]{};
			IList<SwiftTagListBlock> result = b.getSubBlocksDelimitedWithOptionalTail(start, end, tail);

			assertEquals(2, result.Count);
			assertEquals(5, result[0].size());
			assertEquals(5, result[1].size());

			tail = new string[]{"6a", "6"};
			result = b.getSubBlocksDelimitedWithOptionalTail(start, end, tail);
			assertEquals(2, result.Count);
			assertEquals(6, result[0].size());
			assertEquals(6, result[1].size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockDelimitedWithOptionalTail_304bugNPE() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockDelimitedWithOptionalTail_304bugNPE()
		{
			appends(b, 1, 4);

			string[] start = new string[]{"1"};
			string[] end = new string[]{"2"};
			string[] tail = new string[]{"3", "4"};
			SwiftTagListBlock result = b.getSubBlockDelimitedWithOptionalTail(start, end, tail);

			assertNotNull(result);
			assertEquals(4, result.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockDelimitedWithOptionalTail_Bug1() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockDelimitedWithOptionalTail_Bug1()
		{
			appends(b, 1, 9);

			string[] start = new string[]{"1"};
			string[] end = new string[]{"3"};
			string[] tail = new string[]{"6", "7"};
			SwiftTagListBlock result = b.getSubBlockDelimitedWithOptionalTail(start, end, tail);

			assertNotNull(result);
			assertEquals("returned: " + result.tagNamesList(), 3, result.size());
		}

		/*
		 * The getSubBlock includes the starting element in the result but excludes the ending one
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlock() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlock()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.getSubBlock(1, 2);
			assertEquals(1, sb.size());
			assertEquals("val2", sb.getTag(0).Value);

			sb = b.getSubBlock(1, 1 + 4);
			assertEquals(4, sb.size());
			assertEquals("val3", sb.getTag(1).Value);

			sb = b.getSubBlock(null, 1);
			assertEquals(1, sb.size());
			assertEquals("val1", sb.getTag(0).Value);

			sb = b.getSubBlock(4, null);
			assertEquals(1, sb.size());
			assertEquals("val5", sb.getTag(0).Value);

			sb = b.getSubBlock(0, 100);
			assertEquals(5, sb.size());
		}

		/*
		 * The sublist method includes both the starting and ending elements in the result
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSublist() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testSublist()
		{
			appends(b, 1, 10);

			SwiftTagListBlock sl = b.sublist(0, 1);
			assertEquals(2, sl.size());

			sl = b.sublist(null, null);
			assertEquals(b.size(), sl.size());
		}

		private void appends(SwiftTagListBlock block, int from, int to)
		{
			for (int i = from;i <= to;i++)
			{
				block.append(new Tag("" + i, "val" + i));
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveSubBlock() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveSubBlock()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:val4"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.removeSubBlock("TEST");
			assertEquals(5, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
			assertEquals("val2", sb.getTag(1).Value);
			assertEquals("val3", sb.getTag(2).Value);
			assertEquals("val4", sb.getTag(3).Value);
			assertEquals("val5", sb.getTag(4).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveSubBlock_2() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveSubBlock_2()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("16S:TEST"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.removeSubBlock("TEST");
			assertEquals(5, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
			assertEquals("val2", sb.getTag(1).Value);
			assertEquals("val3", sb.getTag(2).Value);
			assertEquals("TEST", sb.getTag(3).Value);
			assertEquals("val5", sb.getTag(4).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveSubBlock_3() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveSubBlock_3()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("16R:HELLO"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("16S:TEST"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.removeSubBlock("TEST");
			assertEquals(5, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
			assertEquals("HELLO", sb.getTag(1).Value);
			assertEquals("val3", sb.getTag(2).Value);
			assertEquals("TEST", sb.getTag(3).Value);
			assertEquals("val5", sb.getTag(4).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveSubBlock_4() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveSubBlock_4()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("16R:TEST"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("16S:TEST"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.removeSubBlock("TEST");
			assertEquals(2, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
			assertEquals("val5", sb.getTag(1).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveSubBlock_5() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveSubBlock_5()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("16R:TEST"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("16S:FOO"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.removeSubBlock("TEST");
			assertEquals(1, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveSubBlock_6() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveSubBlock_6()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("16R:TEST"));
			b.append(new Tag("3K:val3"));
			b.append(new Tag("4:FOO"));
			b.append(new Tag("5:val5"));
			SwiftTagListBlock sb = b.removeSubBlock("TEST");
			assertEquals(1, sb.size());
			assertEquals("val1", sb.getTag(0).Value);
		}

		/*
		 * https://github.com/prowide/prowide-core/issues/13
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveSubBlock_7() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveSubBlock_7()
		{
			b.append(Field20.tag("before"));

			// first sub-block
			b.append(Field16R.tag("SUBBAL"));
			b.append(Field20.tag("first block"));
			b.append(Field16S.tag("SUBBAL"));
			// second sub-block
			b.append(Field16R.tag("SUBBAL"));
			b.append(Field20.tag("second block"));
			b.append(Field16S.tag("SUBBAL"));

			b.append(Field20.tag("after"));

			SwiftTagListBlock sb = b.removeSubBlock("SUBBAL");
			assertEquals("before", sb.getTag(0).Value);
			assertEquals("SUBBAL", sb.getTag(1).Value);
			assertEquals("second block", sb.getTag(2).Value);
			assertEquals("SUBBAL", sb.getTag(3).Value);
			assertEquals("after", sb.getTag(4).Value);
			assertEquals(5, sb.size());
		}

		/*
		 * https://github.com/prowide/prowide-core/issues/13
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testRemoveSubBlocks() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testRemoveSubBlocks()
		{
			b.append(Field20.tag("before"));

			// first sub-block
			b.append(Field16R.tag("SUBBAL"));
			b.append(Field20.tag("first block"));
			b.append(Field16S.tag("SUBBAL"));
			// second sub-block
			b.append(Field16R.tag("SUBBAL"));
			b.append(Field20.tag("second block"));
			b.append(Field16S.tag("SUBBAL"));

			b.append(Field20.tag("after"));

			// remove all subblocks
			SwiftTagListBlock sb = b.removeSubBlocks("SUBBAL");
			assertEquals("before", sb.getTag(0).Value);
			assertEquals("after", sb.getTag(1).Value);
			assertEquals(2, sb.size());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testEmptyArrayReturn() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testEmptyArrayReturn()
		{
			Field[] arr = (new SwiftTagListBlock()).getFieldsByName("nn");
			assertNotNull(arr);
			assertEquals(0, arr.Length);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetFieldByName19A() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetFieldByName19A()
		{
			b.append(Field19A.tag(":SETT"));
			assertNotNull(b.getFieldByName(Field19A.NAME, "SETT"));
		}

		/// <summary>
		/// @since 7.8.5
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockByTagNames() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockByTagNames()
		{
			/*
			 * empty search and empty block
			 */
			SwiftTagListBlock result = b.getSubBlockByTagNames(0);
			assertNotNull(result);
			assertTrue(result.Empty);

			appends(b, 1, 9);

			/*
			 * filled block, empty search
			 */
			result = b.getSubBlockByTagNames(0);
			assertNotNull(result);
			assertTrue(result.Empty);

			/*
			 * single match on first tag
			 */
			result = b.getSubBlockByTagNames(0, "1");
			assertNotNull(result);
			assertEquals(1, result.size());
			assertEquals("1", result.getTag(0).Name);

			/*
			 * single match on second tag
			 */
			result = b.getSubBlockByTagNames(0, "2");
			assertNotNull(result);
			assertEquals(1, result.size());
			assertEquals("2", result.getTag(0).Name);

			/*
			 * the same with index above match
			 */
			result = b.getSubBlockByTagNames(8, "2");
			assertNotNull(result);
			assertTrue(result.Empty);

			/*
			 * same with index before match
			 */
			result = b.getSubBlockByTagNames(1, "2");
			assertNotNull(result);
			assertEquals(1, result.size());
			assertEquals("2", result.getTag(0).Name);

			/*
			 * double match on consecutive tags
			 */
			result = b.getSubBlockByTagNames(0, "2", "3");
			assertNotNull(result);
			assertEquals(2, result.size());
			assertEquals("2", result.getTag(0).Name);
			assertEquals("3", result.getTag(1).Name);

			/*
			 * double match on non-consecutive tags
			 */
			result = b.getSubBlockByTagNames(0, "2", "5");
			assertNotNull(result);
			assertEquals(2, result.size());
			assertEquals("2", result.getTag(0).Name);
			assertEquals("5", result.getTag(1).Name);

			/*
			 * single match because unordered search tags
			 */
			result = b.getSubBlockByTagNames(0, "5", "2");
			assertNotNull(result);
			assertEquals(1, result.size());
			assertEquals("2", result.getTag(0).Name);
		}

		/// <summary>
		/// @since 7.8.5
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlockByTagNames_repetition() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlockByTagNames_repetition()
		{
			b.append(new Tag("1", "1"));
			b.append(new Tag("2", "2"));
			b.append(new Tag("2", "2"));
			b.append(new Tag("2", "2"));
			b.append(new Tag("3", "3"));
			b.append(new Tag("4", "4"));

			/*
			 * simple case with repetition on block
			 */
			SwiftTagListBlock result = b.getSubBlockByTagNames(0, "2");
			assertNotNull(result);
			assertEquals(3, result.size());
			assertEquals("2", result.getTag(0).Name);
			assertEquals("2", result.getTag(1).Name);
			assertEquals("2", result.getTag(2).Name);

			/*
			 * same as above with other unmatched tags
			 */
			result = b.getSubBlockByTagNames(0, "foo", "2", "99");
			assertNotNull(result);
			assertEquals(3, result.size());
			assertEquals("2", result.getTag(0).Name);
			assertEquals("2", result.getTag(1).Name);
			assertEquals("2", result.getTag(2).Name);

			/*
			 * repetition on search tags does not produce any difference
			 */
			result = b.getSubBlockByTagNames(0, "2", "2", "2");
			assertNotNull(result);
			assertEquals(3, result.size());
			assertEquals("2", result.getTag(0).Name);
			assertEquals("2", result.getTag(1).Name);
			assertEquals("2", result.getTag(2).Name);
		}

		/// <summary>
		/// similar to <seealso cref="#testGetSubBlockByTagNames()"/> but getting
		/// multiple block instances
		/// @since 7.8.5
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGetSubBlocksByTagNames() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGetSubBlocksByTagNames()
		{
			/*
			 * empty search and empty block
			 */
			IList<SwiftTagListBlock> result = b.getSubBlocksByTagNames(0);
			assertNotNull(result);
			assertTrue(result.Count == 0);

			appends(b, 1, 9);

			/*
			 * filled block, empty search
			 */
			result = b.getSubBlocksByTagNames(0);
			assertNotNull(result);
			assertTrue(result.Count == 0);

			/*
			 * single match on first tag
			 */
			result = b.getSubBlocksByTagNames(0, "1");
			assertNotNull(result);
			assertEquals(1, result.Count);
			assertEquals(1, result[0].size());
			assertEquals("1", result[0].getTag(0).Name);

			/*
			 * single match on second tag
			 */
			result = b.getSubBlocksByTagNames(0, "2");
			assertNotNull(result);
			assertEquals(1, result.Count);
			assertEquals(1, result[0].size());
			assertEquals("2", result[0].getTag(0).Name);

			/*
			 * the same with index above match
			 */
			result = b.getSubBlocksByTagNames(8, "2");
			assertNotNull(result);
			assertTrue(result.Count == 0);

			/*
			 * same with index before match
			 */
			result = b.getSubBlocksByTagNames(1, "2");
			assertNotNull(result);
			assertEquals(1, result.Count);
			assertEquals(1, result[0].size());
			assertEquals("2", result[0].getTag(0).Name);

			/*
			 * double match on consecutive tags
			 */
			result = b.getSubBlocksByTagNames(0, "2", "3");
			assertNotNull(result);
			assertEquals(1, result.Count);
			assertEquals(2, result[0].size());
			assertEquals("2", result[0].getTag(0).Name);
			assertEquals("3", result[0].getTag(1).Name);

			/*
			 * double match on non-consecutive tags
			 */
			result = b.getSubBlocksByTagNames(0, "2", "5");
			assertNotNull(result);
			assertEquals(1, result.Count);
			assertEquals(2, result[0].size());
			assertEquals("2", result[0].getTag(0).Name);
			assertEquals("5", result[0].getTag(1).Name);

			/*
			 * single match because unordered search tags
			 */
			result = b.getSubBlocksByTagNames(0, "5", "2");
			assertNotNull(result);
			assertEquals(2, result.Count);
			//first pass will find 2
			assertEquals(1, result[0].size());
			assertEquals("2", result[0].getTag(0).Name);
			//second pass will find 5
			assertEquals(1, result[1].size());
			assertEquals("5", result[1].getTag(0).Name);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAdd_1()
		public virtual void testAdd_1()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:val3"));

			b.addTag(2,(new Tag("4:val4")));

			assertEquals(4, b.getTags().Count);
			assertEquals("val1", b.getTag(0).Value);
			assertEquals("val2", b.getTag(1).Value);
			assertEquals("val4", b.getTag(2).Value);
			assertEquals("val3", b.getTag(3).Value);

			assertEquals((int)2, (int)b.getTagIndex("4", null));
			assertEquals((int)3, (int)b.getTagIndex("3", null));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testAdd_2()
		public virtual void testAdd_2()
		{
			b.addTag(0, new Tag("1:val1"));
			b.addTag(1, new Tag("2:val2"));
			b.addTag(2, new Tag("3:val3"));

			assertEquals(3, b.getTags().Count);
			assertEquals("val1", b.getTag(0).Value);
			assertEquals("val2", b.getTag(1).Value);
			assertEquals("val3", b.getTag(2).Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected = IndexOutOfBoundsException.class) public void testAdd_3()
		public virtual void testAdd_3()
		{
			b.addTag(1, new Tag("1:val1"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSet()
		public virtual void testSet()
		{
			b.append(new Tag("1:val1"));
			b.append(new Tag("2:val2"));
			b.append(new Tag("3:val3"));
			b.setTag(2,(new Tag("15", "15")));
			assertEquals((int)2, (int)b.getTagIndex("15", null));
			assertNull(b.getTagIndex("3", null));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFieldByQualifiers()
		public virtual void testFieldByQualifiers()
		{
			// conditional qualifier is component 3
			b.append(new Tag("22F", ":AAAA//BBBB"));
			assertNotNull(b.getFieldByQualifiers("22F", "AAAA", "BBBB"));

			// DSS is ignored
			b.append(new Tag("22F", ":AAAA/DSS/CCCC"));
			assertNotNull(b.getFieldByQualifiers("22F", "AAAA", "CCCC"));

			// conditional qualifier is component 2
			b.append(new Tag("12C", ":AAAA//BBBB"));
			assertNotNull(b.getFieldByQualifiers("12C", "AAAA", "BBBB"));

			// not generic field
			b.append(new Tag("22K", "AAAA/BBBB"));
			assertNull(b.getFieldByQualifiers("22K", "AAAA", "BBBB"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSplitByTagName()
		public virtual void testSplitByTagName()
		{
			b.append(new Tag("20:foo"));
			b.append(new Tag("21:foo"));
			assertTrue(b.splitByTagName(22, null).Count == 0);
			assertTrue(b.splitByTagName(22, "L").Count == 0);

			b.append(new Tag("22L:foo"));
			assertTrue(b.splitByTagName(22, "M").Count == 0);
			assertEquals(1, b.splitByTagName(22, null).Count);
			assertEquals(1, b.splitByTagName(22, "L").Count);

			b.append(new Tag("32A:foo"));
			b.append(new Tag("22L:foo"));
			assertEquals(2, b.splitByTagName(22, null).Count);
			assertEquals(2, b.splitByTagName(22, "L").Count);

			b.append(new Tag("22M:foo"));
			b.append(new Tag("95P:foo"));
			assertEquals(3, b.splitByTagName(22, null).Count);
			assertEquals(2, b.splitByTagName(22, "L").Count);

			IList<SwiftTagListBlock> list1 = b.splitByTagName(22, null);
			assertEquals("22L", list1[0].getTag(0).Name);
			assertEquals("32A", list1[0].getTag(1).Name);
			assertEquals("22L", list1[1].getTag(0).Name);
			assertEquals("22M", list1[2].getTag(0).Name);
			assertEquals("95P", list1[2].getTag(1).Name);

			IList<SwiftTagListBlock> list2 = b.splitByTagName(22, "L");
			assertEquals("22L", list2[0].getTag(0).Name);
			assertEquals("32A", list2[0].getTag(1).Name);
			assertEquals("22L", list2[1].getTag(0).Name);
			assertEquals("22M", list2[1].getTag(1).Name);
			assertEquals("95P", list2[1].getTag(2).Name);
		}

	}
}