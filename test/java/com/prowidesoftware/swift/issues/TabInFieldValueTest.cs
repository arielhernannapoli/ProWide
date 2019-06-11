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
namespace com.prowidesoftware.swift.issues
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;

	using Field61 = com.prowidesoftware.swift.model.field.Field61;
	using MT940 = com.prowidesoftware.swift.model.mt.mt9xx.MT940;
	using Test = org.junit.Test;

	/// <summary>
	/// https://sourceforge.net/p/wife/bugs/81/
	/// </summary>
	public class TabInFieldValueTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test()
		public virtual void test()
		{
			Field61 field = new Field61(":61:1804190419D56716,17NTRF\u000b//XXX 18041900259\n" + "FX-NORMAL TRANSACTION");
			assertNotNull(field);

			Field61 field2 = new Field61(":61:1804190419D56716,17NTRF\t//XXX 18041900259\n" + "FX-NORMAL TRANSACTION");
			assertNotNull(field2);
		}

		private const string REF_ACC_OWN = "REFERENCE_BB_ACCOUNTOWNER";
		private const string REF_ACC_OWN_TAB = "REFERENCE_\u000b\u000b_ACCOUNTOWNER";
		private const string REF_ACC_OWN_TAB2 = "\u000b\u000b";

		private const string MESSAGE = "{1:F01ABCDEFGHXXX0000000000}{2:I940WOWAUS6CUXXXX}{4:\n" + ":20:1234567890123456\n" + ":25:ABCDEFGHXXX/12345678\n" + ":28C:12345\n" + ":60F:C180418CNY0,00\n" + ":61:1804190419D93366,00NTRFREFERENCE_BB_ACCOUNTOWNER//NNN 123456789012\n" + "MULTITUDE\n" + ":86:/YYYY/\u000b\u000b MARKMS1234/PPPP/RRR93366,00/RASK/\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\n" + ":62F:C180419CNY0,00\n" + ":64:C180419CNY0,00\n" + "-}";

		private const string MESSAGE_TAB = "{1:F01ABCDEFGHXXX0000000000}{2:I940WOWAUS6CUXXXX}{4:\n" + ":20:1234567890123456\n" + ":25:ABCDEFGHXXX/12345678\n" + ":28C:12345\n" + ":60F:C180418CNY0,00\n" + ":61:1804190419D93366,00NTRFREFERENCE_\u000b\u000b_ACCOUNTOWNER//NNN 123456789012\n" + "MULTITUDE\n" + ":86:/YYYY/\u000b\u000b MARKMS1234/PPPP/RRR93366,00/RASK/\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\n" + ":62F:C180419CNY0,00\n" + ":64:C180419CNY0,00\n" + "-}";

		private const string MESSAGE_TAB2 = "{1:F01ABCDEFGHXXX0000000000}{2:I940WOWAUS6CUXXXX}{4:\n" + ":20:1234567890123456\n" + ":25:ABCDEFGHXXX/12345678\n" + ":28C:12345\n" + ":60F:C180418CNY0,00\n" + ":61:1804190419D93366,00NTRF\u000b\u000b//NNN 123456789012\n" + "MULTITUDE\n" + ":86:/YYYY/\u000b\u000b MARKMS1234/PPPP/RRR93366,00/RASK/\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\u000b\n" + ":62F:C180419CNY0,00\n" + ":64:C180419CNY0,00\n" + "-}";

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void test(final String expected, final String message)
		private void test(string expected, string message)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt9xx.MT940 mt940 = new com.prowidesoftware.swift.model.mt.mt9xx.MT940(message);
			MT940 mt940 = new MT940(message);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field61 field61 = mt940.getField61().get(0);
			Field61 field61 = mt940.Field61[0];
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String refAccOwn = field61.getReferenceForTheAccountOwner();
			string refAccOwn = field61.ReferenceForTheAccountOwner;
			assertEquals(expected, refAccOwn);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void message()
		public virtual void message()
		{
			test(REF_ACC_OWN, MESSAGE);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void messageTab()
		public virtual void messageTab()
		{
			test(REF_ACC_OWN_TAB, MESSAGE_TAB);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void messageTab2()
		public virtual void messageTab2()
		{
			test(REF_ACC_OWN_TAB2, MESSAGE_TAB2);
		}

	}

}