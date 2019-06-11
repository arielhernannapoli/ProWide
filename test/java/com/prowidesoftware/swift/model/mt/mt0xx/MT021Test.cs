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

	using Field108 = com.prowidesoftware.swift.model.field.Field108;
	using Field202 = com.prowidesoftware.swift.model.field.Field202;
	using Field203 = com.prowidesoftware.swift.model.field.Field203;
	using Field280 = com.prowidesoftware.swift.model.field.Field280;
	using Field281 = com.prowidesoftware.swift.model.field.Field281;
	using Field431 = com.prowidesoftware.swift.model.field.Field431;

	public class MT021Test
	{

		private string sample1 = "{1:F01VNDZBET2AXXX0000000000}{2:I021DYDYXXXXXXXXN}{4:" + "{202:0002}" + "{203:0002}" + "{280:1047010517VNDZBET2AXXX0026000410Y}" + "{108:PRIORITY 2}" + "{431:01}" + "{281:1156010517VNDZBET2AXXX0027000584Y}}";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse1()
		public virtual void test_parse1()
		{
			MT021 m = MT021.parse(sample1);
			assertNotNull(m);

			assertNotNull(m.Field202);
			assertEquals("0002", m.Field202[0].Value);

			assertNotNull(m.Field203);
			assertEquals("0002", m.Field203[0].Value);

			assertNotNull(m.Field280);
			assertEquals("1047010517VNDZBET2AXXX0026000410Y", m.Field280.Value);

			assertNotNull(m.Field108);
			assertEquals("PRIORITY 2", m.Field108.Value);

			assertNotNull(m.Field431);
			assertEquals("01", m.Field431.Value);

			assertNotNull(m.Field281);
			assertEquals("1156010517VNDZBET2AXXX0027000584Y", m.Field281.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create1()
		public virtual void test_create1()
		{
			MT021 m = new MT021();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field202("0002"));
			m.append(new Field203("0002"));
			m.append(new Field280("1047010517VNDZBET2AXXX0026000410Y"));
			m.append(new Field108("PRIORITY 2"));
			m.append(new Field431("01"));
			m.append(new Field281("1156010517VNDZBET2AXXX0027000584Y"));

			assertEquals(sample1, m.message());
		}

	}

}