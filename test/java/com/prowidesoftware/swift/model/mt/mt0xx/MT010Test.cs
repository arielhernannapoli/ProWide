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
	using Field104 = com.prowidesoftware.swift.model.field.Field104;
	using Field106 = com.prowidesoftware.swift.model.field.Field106;
	using Field108 = com.prowidesoftware.swift.model.field.Field108;
	using Field431 = com.prowidesoftware.swift.model.field.Field431;


	public class MT010Test
	{

		private string sample = "{1:F01VNDZBET2AXXX0000000000}{2:I010DYDYXXXXXXXXN}{4:" + "{106:010517VNDZBET2AXXX0026000409}" + "{108:PRIORITY}" + "{431:07}" + "{102:VNZDBET2XXXX}" + "{104:U}}";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse()
		public virtual void test_parse()
		{
			MT010 m = MT010.parse(sample);
			assertNotNull(m);

			assertNotNull(m.Field106);
			assertEquals("010517VNDZBET2AXXX0026000409", m.Field106.Value);

			assertNotNull(m.Field108);
			assertEquals("PRIORITY", m.Field108.Value);

			assertNotNull(m.Field431);
			assertEquals("07", m.Field431.Value);

			assertNotNull(m.Field102);
			assertEquals("VNZDBET2XXXX", m.Field102.Value);

			assertNotNull(m.Field104);
			assertEquals("U", m.Field104.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create()
		public virtual void test_create()
		{
			MT010 m = new MT010();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field106("010517VNDZBET2AXXX0026000409"));
			m.append(new Field108("PRIORITY"));
			m.append(new Field431("07"));
			m.append(new Field102("VNZDBET2XXXX"));
			m.append(new Field104("U"));
			assertEquals(sample, m.message());
		}
	}
}