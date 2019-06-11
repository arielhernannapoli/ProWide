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

namespace com.prowidesoftware.swift.model.mt.mt0xx
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;

	using Test = org.junit.Test;

	using Field140 = com.prowidesoftware.swift.model.field.Field140;
	using Field144 = com.prowidesoftware.swift.model.field.Field144;
	using Field251 = com.prowidesoftware.swift.model.field.Field251;

	public class MT025Test
	{

		private string sample = "{1:F01VNDZBET2AXXX0000000000}{2:I025DYDYXXXXXXXXN}{4:" + "{251:061220BANKBEBBAXXX0074005566}" + "{140:123456789012345}" + "{144:00}}";
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse()
		public virtual void test_parse()
		{
			MT025 m = MT025.parse(sample);
			assertNotNull(m);

			assertNotNull(m.Field251);
			assertEquals("061220BANKBEBBAXXX0074005566", m.Field251.Value);

			assertNotNull(m.Field140);
			assertEquals("123456789012345", m.Field140.Value);

			assertNotNull(m.Field144);
			assertEquals("00", m.Field144.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create()
		public virtual void test_create()
		{
			MT025 m = new MT025();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field251("061220BANKBEBBAXXX0074005566"));
			m.append(new Field140("123456789012345"));
			m.append(new Field144("00"));

			assertEquals(sample, m.message());
		}
	}

}