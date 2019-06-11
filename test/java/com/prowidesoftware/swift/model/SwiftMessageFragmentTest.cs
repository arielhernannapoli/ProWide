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
namespace com.prowidesoftware.swift.model
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Test = org.junit.Test;

	/// <summary>
	/// Message fragment tests.
	/// 
	/// @since 4.0
	/// </summary>
	public class SwiftMessageFragmentTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFragment_no()
		public virtual void testFragment_no()
		{
			SwiftMessage m = new SwiftMessage(true);
			m.Block1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			m.Block2.Value = com.prowidesoftware.swift.Constants_Fields.B2_INPUT;
			m.Block3.append(new Tag("120:asdadad"));
			m.Block4.append(new Tag("120:asdadad"));
			m.Block5.append(new Tag("120:asdadad"));

			assertFalse(m.Fragment);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFragment_yesMiddle()
		public virtual void testFragment_yesMiddle()
		{
			SwiftMessage m = new SwiftMessage(true);
			m.Block1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			m.Block2.Value = com.prowidesoftware.swift.Constants_Fields.B2_INPUT;
			m.Block3.append(new Tag("120:asdadad"));
			m.Block4.append(new Tag("120:asdadad"));
			m.Block4.append(new Tag("202:0001"));
			m.Block4.append(new Tag("203:0002"));
			m.Block5.append(new Tag("120:asdadad"));

			assertTrue(m.Fragment);
			assertEquals(Convert.ToInt32(2), m.fragmentCount());
			assertEquals(Convert.ToInt32(1), m.fragmentNumber());
			assertFalse(m.LastFragment);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testFragment_yesLast()
		public virtual void testFragment_yesLast()
		{
			SwiftMessage m = new SwiftMessage(true);
			m.Block1.Value = com.prowidesoftware.swift.Constants_Fields.B1_DATA;
			m.Block2.Value = com.prowidesoftware.swift.Constants_Fields.B2_INPUT;
			m.Block3.append(new Tag("120:asdadad"));
			m.Block4.append(new Tag("120:asdadad"));
			m.Block4.append(new Tag("202:0002"));
			m.Block4.append(new Tag("203:0002"));
			m.Block5.append(new Tag("120:asdadad"));

			assertTrue(m.Fragment);
			assertEquals(Convert.ToInt32(2), m.fragmentCount());
			assertEquals(Convert.ToInt32(2), m.fragmentNumber());
			assertTrue(m.LastFragment);
		}
	}

}