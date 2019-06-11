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

namespace com.prowidesoftware.swift.model.mx
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNotNull;

	using Test = org.junit.Test;
	using Element = org.w3c.dom.Element;

	public class AbstractMXTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testElement()
		public virtual void testElement()
		{
			MockMsg m = new MockMsg();
			m.Content = "Hello World!";
			Element e = m.element();
			assertNotNull(e);
		}

	}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlRootElement final class MockMsg extends AbstractMX
	internal sealed class MockMsg : AbstractMX
	{
		private string content;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") @Override public Class[] getClasses()
		public override Type[] Classes
		{
			get
			{
				return new Type[]{typeof(MockMsg)};
			}
		}

		public override string Namespace
		{
			get
			{
				return "foo:namespace";
			}
		}

		public override string BusinessProcess
		{
			get
			{
				return null;
			}
		}

		public override int Functionality
		{
			get
			{
				return 0;
			}
		}

		public override int Variant
		{
			get
			{
				return 0;
			}
		}

		public override int Version
		{
			get
			{
				return 0;
			}
		}

		public string Content
		{
			get
			{
				return content;
			}
			set
			{
				this.content = value;
			}
		}


	}

}