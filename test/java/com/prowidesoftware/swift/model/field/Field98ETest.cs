using System;

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
namespace com.prowidesoftware.swift.model.field
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Test = org.junit.Test;

	/// <summary>
	/// Test for Field98E and similar fields.
	/// :S//<DATE4><TIME2>[,S][/[c]<TIME3>]
	/// 
	/// @since 6.0
	/// </summary>
	public class Field98ETest : AbstractFieldTest
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(Field98ETest).FullName);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Test public void testSerialization()
		public override void testSerialization()
		{
			testSerializationImpl("98E", ":abc//12121212242424,33/N2020", ":abc//12121212242424,33");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testField98EString()
		public virtual void testField98EString()
		{
			Field98E f = null;

			f = new Field98E("");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E(":");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E("/");
			log.fine("f:" + f);
			assertEquals("/", f.Component1);
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E("//");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E("://");
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E(":/");
			assertEquals("/", f.Component1);
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E("///");
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E(":///");
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.Component1));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E(":abc//");
			assertEquals("abc", f.Component1);
			assertTrue(StringUtils.isBlank(f.getComponent2()));
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));

			f = new Field98E(":abc//12121212");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertTrue(StringUtils.isBlank(f.getComponent3()));
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E(":abc//12121212242424");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertEquals("242424", f.getComponent3());
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E(":abc//12121212242424,33");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertEquals("242424", f.getComponent3());
			assertEquals("33", f.getComponent4());
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E(":abc//12121212242424/N");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertEquals("242424", f.getComponent3());
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertEquals("N", f.getComponent5());
			assertTrue(StringUtils.isBlank(f.getComponent6()));

			f = new Field98E(":abc//12121212242424/N2020");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertEquals("242424", f.getComponent3());
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertEquals("N", f.getComponent5());
			assertEquals("2020", f.getComponent6());

			f = new Field98E(":abc//12121212242424/N20");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertEquals("242424", f.getComponent3());
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertEquals("N", f.getComponent5());
			assertEquals("20", f.getComponent6());

			f = new Field98E(":abc//12121212242424/20");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertEquals("242424", f.getComponent3());
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertEquals("20", f.getComponent6());

			f = new Field98E(":abc//12121212242424/2020");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertEquals("242424", f.getComponent3());
			assertTrue(StringUtils.isBlank(f.getComponent4()));
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertEquals("2020", f.getComponent6());

			f = new Field98E(":abc//12121212242424,33/2020");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertEquals("242424", f.getComponent3());
			assertEquals("33", f.getComponent4());
			assertTrue(StringUtils.isBlank(f.getComponent5()));
			assertEquals("2020", f.getComponent6());

			f = new Field98E(":abc//12121212242424,33/N2020");
			assertEquals("abc", f.Component1);
			assertEquals("12121212", f.getComponent2());
			assertEquals("242424", f.getComponent3());
			assertEquals("33", f.getComponent4());
			assertEquals("N", f.getComponent5());
			assertEquals("2020", f.getComponent6());
		}

	}
}