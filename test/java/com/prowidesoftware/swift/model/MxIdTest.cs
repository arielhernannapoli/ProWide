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

namespace com.prowidesoftware.swift.model
{

	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.*;

	public class MxIdTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNamespaceConstructor1()
		public virtual void testNamespaceConstructor1()
		{
			MxId mid = new MxId("urn:iso:std:iso:20022:tech:xsd:acmt.015.001.02");
			assertEquals(MxBusinessProcess.acmt, mid.BusinessProcess);
			assertEquals("015", mid.Functionality);
			assertEquals("001", mid.Variant);
			assertEquals("02", mid.Version);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNamespaceConstructor2()
		public virtual void testNamespaceConstructor2()
		{
			MxId mid = new MxId("urn:swift:xsd:tsmt.039.001.02");
			assertEquals(MxBusinessProcess.tsmt, mid.BusinessProcess);
			assertEquals("039", mid.Functionality);
			assertEquals("001", mid.Variant);
			assertEquals("02", mid.Version);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMatches()
		public virtual void testMatches()
		{
			assertTrue((new MxId()).Equals(new MxId()));

			MxId id1 = new MxId(MxBusinessProcess.pain.name(), null, null, null);
			assertEquals(MxBusinessProcess.pain, id1.BusinessProcess);
			assertTrue(id1.matches("pain.001.001.03"));
			assertTrue(id1.matches(new MxId("pain.001.001.03")));
			assertFalse(id1.matches("camt.001.001.03"));
			assertFalse(id1.matches(new MxId("camt.001.001.03")));

			MxId id2 = new MxId(MxBusinessProcess.pain.name(), "", "", "");
			assertEquals(MxBusinessProcess.pain, id1.BusinessProcess);
			assertTrue(id2.matches("pain.001.001.03"));
			assertTrue(id2.matches(new MxId("pain", "001", "001", null)));
			assertTrue(id2.matches(new MxId("pain", "001", "001", "")));
			assertFalse(id2.matches("camt.001.001.03"));

			MxId id3 = (new MxId()).setBusinessProcess(MxBusinessProcess.pain);
			assertEquals(MxBusinessProcess.pain, id3.BusinessProcess);
			assertTrue(id3.matches("pain.001.001.03"));
			assertFalse(id3.matches("camt.001.001.03"));

			MxId id4 = new MxId("urn:iso:std:iso:20022:tech:xsd:pain.001.002.03");
			assertEquals(MxBusinessProcess.pain, id4.BusinessProcess);
			assertEquals("001", id4.Functionality);
			assertEquals("002", id4.Variant);
			assertEquals("03", id4.Version);
			assertTrue(id4.matches("pain.001.002.03"));
			assertFalse(id4.matches("pain.001.002.04"));
			assertFalse(id4.matches("pain.001.003.03"));
			assertFalse(id4.matches("pain.002.002.03"));
			assertFalse(id4.matches("pacs.001.002.04"));
			assertFalse(id4.matches("camt.001.001.03"));
		}

	}

}