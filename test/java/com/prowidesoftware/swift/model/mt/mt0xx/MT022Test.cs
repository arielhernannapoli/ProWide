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
	using Field251 = com.prowidesoftware.swift.model.field.Field251;
	using Field252 = com.prowidesoftware.swift.model.field.Field252;
	using Field253 = com.prowidesoftware.swift.model.field.Field253;
	using Field254 = com.prowidesoftware.swift.model.field.Field254;
	using Field258 = com.prowidesoftware.swift.model.field.Field258;
	using Field259 = com.prowidesoftware.swift.model.field.Field259;
	using Field260 = com.prowidesoftware.swift.model.field.Field260;

	public class MT022Test
	{

		private string sample1 = "{1:F01VNDZBET2AXXX0000000000}{2:I022DYDYXXXXXXXXN}{4:" + "{102:VNDZBET2AXXX}" + "{251:010605VNDZBET2AXXX0017000375}}";

		private string sample2 = "{1:F01VNDZBET2AXXX0000000000}{2:I022DYDYXXXXXXXXN}{4:" + "{102:VNDZBET2AXXX}" + "{251:050822VNDZBET2AXXX0529001624}}";

		private string sample3 = "{1:F01VNDZBET2AXXX0000000000}{2:I022DYDYXXXXXXXXN}{4:" + "{102:VNDZBET2AXXX}" + "{252:050822VNDZBET2AXXX0294001093050822VNDZBET2AXXX0294001096}}";

		private string sample4 = "{1:F01VNDZBET2AXXX0000000000}{2:I022DYDYXXXXXXXXN}{4:" + "{102:VNDZBET2AXXX}" + "{253:050823VNDZBET2AXXX0042000211}}";

		private string sample5 = "{1:F01VNDZBET2AXXX0000000000}{2:I022DYDYXXXXXXXXN}{4:" + "{102:VNDZBET2AXXX}" + "{254:050822VNDZBET2AXXX0025000093050822VNDZBET2AXXX002500009714501454}}";

		private string sample6 = "{1:F01VNDZBET2AXXX0000000000}{2:I022DYDYXXXXXXXXN}{4:" + "{102:VNDZBET2AXXX}" + "{258:VNDZBET2AXXX002599905082214501454}}";

		private string sample7 = "{1:F01VNDZBET2AXXX0000000000}{2:I022DYDYXXXXXXXXN}{4:" + "{102:VNDZBET2AXXX}" + "{259:VNDZBET2AXXX0025905082214501454}}";

		private string sample8 = "{1:F01VNDZBET2AXXX0000000000}{2:I022DYDYXXXXXXXXN}{4:" + "{102:VNDZBET2AXXX}" + "{260:VNDZBET2AXXX050822145014540025}}";

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse1()
		public virtual void test_parse1()
		{
			MT022 m = MT022.parse(sample1);
			assertNotNull(m);

			assertNotNull(m.Field102);
			assertEquals("VNDZBET2AXXX", m.Field102.Value);

			assertNotNull(m.Field251);
			assertEquals("010605VNDZBET2AXXX0017000375", m.Field251.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse2()
		public virtual void test_parse2()
		{
			MT022 m = MT022.parse(sample2);
			assertNotNull(m);

			assertNotNull(m.Field102);
			assertEquals("VNDZBET2AXXX", m.Field102.Value);

			assertNotNull(m.Field251);
			assertEquals("050822VNDZBET2AXXX0529001624", m.Field251.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse3()
		public virtual void test_parse3()
		{
			MT022 m = MT022.parse(sample3);
			assertNotNull(m);

			assertNotNull(m.Field102);
			assertEquals("VNDZBET2AXXX", m.Field102.Value);

			assertNotNull(m.Field252);
			assertEquals("050822VNDZBET2AXXX0294001093050822VNDZBET2AXXX0294001096", m.Field252.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse4()
		public virtual void test_parse4()
		{
			MT022 m = MT022.parse(sample4);
			assertNotNull(m);

			assertNotNull(m.Field102);
			assertEquals("VNDZBET2AXXX", m.Field102.Value);

			assertNotNull(m.Field253);
			assertEquals("050823VNDZBET2AXXX0042000211", m.Field253.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse5()
		public virtual void test_parse5()
		{
			MT022 m = MT022.parse(sample5);
			assertNotNull(m);

			assertNotNull(m.Field102);
			assertEquals("VNDZBET2AXXX", m.Field102.Value);

			assertNotNull(m.Field254);
			assertEquals("050822VNDZBET2AXXX0025000093050822VNDZBET2AXXX002500009714501454", m.Field254.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse6()
		public virtual void test_parse6()
		{
			MT022 m = MT022.parse(sample6);
			assertNotNull(m);

			assertNotNull(m.Field102);
			assertEquals("VNDZBET2AXXX", m.Field102.Value);

			assertNotNull(m.Field258);
			assertEquals("VNDZBET2AXXX002599905082214501454", m.Field258.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse7()
		public virtual void test_parse7()
		{
			MT022 m = MT022.parse(sample7);
			assertNotNull(m);

			assertNotNull(m.Field102);
			assertEquals("VNDZBET2AXXX", m.Field102.Value);

			assertNotNull(m.Field259);
			assertEquals("VNDZBET2AXXX0025905082214501454", m.Field259.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_parse8()
		public virtual void test_parse8()
		{
			MT022 m = MT022.parse(sample8);
			assertNotNull(m);

			assertNotNull(m.Field102);
			assertEquals("VNDZBET2AXXX", m.Field102.Value);

			assertNotNull(m.Field260);
			assertEquals("VNDZBET2AXXX050822145014540025", m.Field260.Value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create1()
		public virtual void test_create1()
		{
			MT022 m = new MT022();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field102("VNDZBET2AXXX"));
			m.append(new Field251("010605VNDZBET2AXXX0017000375"));

			assertEquals(sample1, m.message());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create2()
		public virtual void test_create2()
		{
			MT022 m = new MT022();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field102("VNDZBET2AXXX"));
			m.append(new Field251("050822VNDZBET2AXXX0529001624"));

			assertEquals(sample2, m.message());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create3()
		public virtual void test_create3()
		{
			MT022 m = new MT022();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field102("VNDZBET2AXXX"));
			m.append(new Field252("050822VNDZBET2AXXX0294001093050822VNDZBET2AXXX0294001096"));

			assertEquals(sample3, m.message());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create4()
		public virtual void test_create4()
		{
			MT022 m = new MT022();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field102("VNDZBET2AXXX"));
			m.append(new Field253("050823VNDZBET2AXXX0042000211"));

			assertEquals(sample4, m.message());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create5()
		public virtual void test_create5()
		{
			MT022 m = new MT022();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field102("VNDZBET2AXXX"));
			m.append(new Field254("050822VNDZBET2AXXX0025000093050822VNDZBET2AXXX002500009714501454"));

			assertEquals(sample5, m.message());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create6()
		public virtual void test_create6()
		{
			MT022 m = new MT022();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field102("VNDZBET2AXXX"));
			m.append(new Field258("VNDZBET2AXXX002599905082214501454"));

			assertEquals(sample6, m.message());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create7()
		public virtual void test_create7()
		{
			MT022 m = new MT022();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field102("VNDZBET2AXXX"));
			m.append(new Field259("VNDZBET2AXXX0025905082214501454"));

			assertEquals(sample7, m.message());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test_create8()
		public virtual void test_create8()
		{
			MT022 m = new MT022();
			m.Sender = "VNDZBET2AXXX";
			m.Receiver = "DYDYXXXXFXXX";
			m.append(new Field102("VNDZBET2AXXX"));
			m.append(new Field260("VNDZBET2AXXX050822145014540025"));

			assertEquals(sample8, m.message());
		}

	}

}