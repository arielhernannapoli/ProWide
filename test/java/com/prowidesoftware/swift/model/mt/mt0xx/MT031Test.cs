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

	using Field177 = com.prowidesoftware.swift.model.field.Field177;
	using Field303 = com.prowidesoftware.swift.model.field.Field303;

	public class MT031Test
	{

		private string sample1 = "{1:F01VNDZBET2AXXX0000000000}{2:I031DYDYXXXXXXXXN}{4:" + "{303:A}" + "{177:0106050000}" + "{177:0106052359}}";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse()
		public virtual void test_parse()
		{
			MT031 m = MT031.parse(sample1);
			assertNotNull(m);

			assertNotNull(m.Field303);
			assertEquals("A", m.Field303.Value);

			assertNotNull(m.Field177);
			assertEquals("0106050000", m.Field177[0].Value);

			assertNotNull(m.Field177);
			assertEquals("0106052359", m.Field177[1].Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create()
		public virtual void test_create()
		{
			MT031 m = new MT031();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field303("A"));
			m.append(new Field177("0106050000"));
			m.append(new Field177("0106052359"));

			assertEquals(sample1, m.message());

		}
	}

}