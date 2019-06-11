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

	using Field103 = com.prowidesoftware.swift.model.field.Field103;
	using Field177 = com.prowidesoftware.swift.model.field.Field177;
	using Field243 = com.prowidesoftware.swift.model.field.Field243;

	public class MT028Test
	{

		private string sample1 = "{1:F01VNDZBET2AXXX0000000000}{2:I028DYDYXXXXXXXXN}{4:" + "{103:TGT}{243:1}}";

		private string sample2 = "{1:F01VNDZBET2AXXX0000000000}{2:I028DYDYXXXXXXXXN}{4:" + "{103:TGT}{243:2}{177:0106051000}}";

		private string sample3 = "{1:F01VNDZBET2AXXX0000000000}{2:I028DYDYXXXXXXXXN}{4:" + "{103:TGT}{243:1}{177:0106052200}{177:0106062359}}";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse()
		public virtual void test_parse()
		{
			MT028 m = MT028.parse(sample1);
			assertNotNull(m);

			assertNotNull(m.Field103);
			assertEquals("TGT", m.Field103.Value);

			assertNotNull(m.Field243);
			assertEquals("1", m.Field243.Value);

			m = MT028.parse(sample2);

			assertNotNull(m.Field103);
			assertEquals("TGT", m.Field103.Value);

			assertNotNull(m.Field243);
			assertEquals("2", m.Field243.Value);

			assertNotNull(m.Field177);
			assertEquals("0106051000", m.Field177[0].Value);

			m = MT028.parse(sample3);

			assertNotNull(m.Field103);
			assertEquals("TGT", m.Field103.Value);

			assertNotNull(m.Field243);
			assertEquals("1", m.Field243.Value);

			assertNotNull(m.Field177);
			assertEquals("0106052200", m.Field177[0].Value);

			assertNotNull(m.Field177);
			assertEquals("0106062359", m.Field177[1].Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create()
		public virtual void test_create()
		{
			MT028 m = new MT028();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field103("TGT"));
			m.append(new Field243("1"));

			assertEquals(sample1, m.message());

			m = new MT028();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field103("TGT"));
			m.append(new Field243("2"));
			m.append(new Field177("0106051000"));

			assertEquals(sample2, m.message());

			m = new MT028();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field103("TGT"));
			m.append(new Field243("1"));
			m.append(new Field177("0106052200"));
			m.append(new Field177("0106062359"));

			assertEquals(sample3, m.message());
		}
	}

}