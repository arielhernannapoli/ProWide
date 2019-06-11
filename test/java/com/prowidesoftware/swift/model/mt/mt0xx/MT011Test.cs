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

	using Field106 = com.prowidesoftware.swift.model.field.Field106;
	using Field107 = com.prowidesoftware.swift.model.field.Field107;
	using Field108 = com.prowidesoftware.swift.model.field.Field108;
	using Field175 = com.prowidesoftware.swift.model.field.Field175;


	public class MT011Test
	{

		private string sample = "{1:F01VNDZBET2AXXX0000000000}{2:I011DYDYXXXXXXXXN}{4:" + "{175:1608}" + "{106:010605VNDZBET2AXXX0017000375}" + "{108:TEST 1}" + "{175:1508}" + "{107:010605VNDZGBT2AXXX0017000244}}";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse()
		public virtual void test_parse()
		{
			MT011 m = MT011.parse(sample);
			assertNotNull(m);

			assertNotNull(m.Field175);
			assertEquals("1608", m.Field175[0].Value);

			assertNotNull(m.Field106);
			assertEquals("010605VNDZBET2AXXX0017000375", m.Field106.Value);

			assertNotNull(m.Field108);
			assertEquals("TEST 1", m.Field108.Value);

			assertNotNull(m.Field175);
			assertEquals("1508", m.Field175[1].Value);

			assertNotNull(m.Field107);
			assertEquals("010605VNDZGBT2AXXX0017000244", m.Field107.Value);

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create()
		public virtual void test_create()
		{
			MT011 m = new MT011();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field175("1608"));
			m.append(new Field106("010605VNDZBET2AXXX0017000375"));
			m.append(new Field108("TEST 1"));
			m.append(new Field175("1508"));
			m.append(new Field107("010605VNDZGBT2AXXX0017000244"));

			assertEquals(sample, m.message());
		}
	}
}