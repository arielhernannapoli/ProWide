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

	using Field102 = com.prowidesoftware.swift.model.field.Field102;
	using Field106 = com.prowidesoftware.swift.model.field.Field106;
	using Field175 = com.prowidesoftware.swift.model.field.Field175;
	using Field432 = com.prowidesoftware.swift.model.field.Field432;
	using Field619 = com.prowidesoftware.swift.model.field.Field619;

	public class MT019Test
	{

		private string sample = "{1:F01VNDZBET2AXXX0000000000}{2:I019DYDYXXXXXXXXN}{4:" + "{175:0604}" + "{106:140901VNDZBET2AXXX0021000443}" + "{102:BBBNBEBBAXXX}" + "{432:12}" + "{619:CPY}" + "}";
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse()
		public virtual void test_parse()
		{
			MT019 m = MT019.parse(sample);
			assertNotNull(m);

			assertNotNull(m.Field175);
			assertEquals("0604", m.Field175.Value);

			assertNotNull(m.Field106);
			assertEquals("140901VNDZBET2AXXX0021000443", m.Field106.Value);

			assertNotNull(m.Field102);
			assertEquals("BBBNBEBBAXXX", m.Field102.Value);

			assertNotNull(m.Field432);
			assertEquals("12", m.Field432.Value);

			assertNotNull(m.Field619);
			assertEquals("CPY", m.Field619.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create()
		public virtual void test_create()
		{
			MT019 m = new MT019();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field175("0604"));
			m.append(new Field106("140901VNDZBET2AXXX0021000443"));
			m.append(new Field102("BBBNBEBBAXXX"));
			m.append(new Field432("12"));
			m.append(new Field619("CPY"));

			assertEquals(sample, m.message());
		}
	}

}