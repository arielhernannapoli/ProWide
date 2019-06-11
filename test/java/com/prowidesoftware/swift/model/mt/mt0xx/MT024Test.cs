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
	using Field142 = com.prowidesoftware.swift.model.field.Field142;
	using Field143 = com.prowidesoftware.swift.model.field.Field143;

	public class MT024Test
	{

		private string sample = "{1:F01VNDZBET2AXXX0000000000}{2:I024DYDYXXXXXXXXN}{4:" + "{140:111222333444555}" + "{142:200703051430}" + "{143:200703051530}}";
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse()
		public virtual void test_parse()
		{
			MT024 m = MT024.parse(sample);
			assertNotNull(m);

			assertNotNull(m.Field140);
			assertEquals("111222333444555", m.Field140.Value);

			assertNotNull(m.Field142);
			assertEquals("200703051430", m.Field142.Value);

			assertNotNull(m.Field143);
			assertEquals("200703051530", m.Field143.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create()
		public virtual void test_create()
		{
			MT024 m = new MT024();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field140("111222333444555"));
			m.append(new Field142("200703051430"));
			m.append(new Field143("200703051530"));

			assertEquals(sample, m.message());
		}
	}

}