using System.Threading;

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

	using Field106 = com.prowidesoftware.swift.model.field.Field106;
	using Field108 = com.prowidesoftware.swift.model.field.Field108;
	using Field121 = com.prowidesoftware.swift.model.field.Field121;
	using Field165 = com.prowidesoftware.swift.model.field.Field165;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	/// <summary>
	/// Block3 tests.
	/// 
	/// @author sebastian
	/// @since 7.8.8
	/// </summary>
	public class SwiftBlock3Test
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testGenerateMUR() throws InterruptedException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testGenerateMUR()
		{
			SwiftBlock3 b = new SwiftBlock3();
			assertNull(b.getTagByName("108"));
			b.generateMUR(true);
			assertNotNull(b.getTagByName("108"));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String current = b.getTagByName("108").getValue();
			string current = b.getTagByName("108").Value;
			b.generateMUR(false);
			assertEquals(current, b.getTagByName("108").Value);
			Thread.Sleep(500);
			b.generateMUR(true);
			assertFalse("expected a different MUR after generateMUR(true)", StringUtils.Equals(current, b.getTagByName("108").Value));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsSTP()
		public virtual void testIsSTP()
		{
			SwiftBlock3 b = new SwiftBlock3();
			assertFalse(b.STP);
			b.append(new Tag("119", "STP"));
			assertTrue(b.STP);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBuilder()
		public virtual void testBuilder()
		{
			SwiftBlock3 b = new SwiftBlock3();
			b.builder().setField121(new Field121("foo")).setField106(new Field106("foo")).setField165(new Field165("foo")).setField106(new Field106("finalValue106")).setField108(new Field108("foo"));
			assertEquals(Field108.NAME, b.Tags[0].Name);
			assertEquals(Field106.NAME, b.Tags[1].Name);
			assertEquals(Field121.NAME, b.Tags[2].Name);
			assertEquals(Field165.NAME, b.Tags[3].Name);
			assertEquals(4, b.Tags.Count);
			assertEquals("finalValue106", b.getTagValue(Field106.NAME));
		}

	}

}