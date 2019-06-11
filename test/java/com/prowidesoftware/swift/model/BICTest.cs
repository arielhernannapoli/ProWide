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

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertFalse;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Test = org.junit.Test;

	/// <summary>
	/// BIC model testing
	/// 
	/// </summary>
	public class BICTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testParse()
		public virtual void testParse()
		{
			BIC b = new BIC(null);
			assertNull(b.Institution);
			assertNull(b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			b = new BIC("");
			assertNull(b.Institution);
			assertNull(b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			b = new BIC("I");
			assertEquals("I", b.Institution);
			assertNull(b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			b = new BIC("IIII");
			assertEquals("IIII", b.Institution);
			assertNull(b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			b = new BIC("IIIIC");
			assertEquals("IIII", b.Institution);
			assertEquals("C", b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			b = new BIC("IIIICC");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertNull(b.Location);
			assertNull(b.Branch);
			b = new BIC("IIIICCL");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertEquals("L", b.Location);
			assertNull(b.Branch);
			b = new BIC("IIIICCLL");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertEquals("LL", b.Location);
			assertNull(b.Branch);
			b = new BIC("IIIICCLLB");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertEquals("LL", b.Location);
			assertEquals("B", b.Branch);
			b = new BIC("IIIICCLLBBBBBB");
			assertEquals("IIII", b.Institution);
			assertEquals("CC", b.Country);
			assertEquals("LL", b.Location);
			assertEquals("BBBBB", b.Branch); //one B is dropped as LT identifier
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsValid()
		public virtual void testIsValid()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final BIC b = new BIC("foo");
			BIC b = new BIC("foo");
			assertFalse(b.Valid);
			assertEquals(BicValidationResult.INVALID_LENGTH, b.validate());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsValid2()
		public virtual void testIsValid2()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final BIC b = new BIC("FOOOESHU");
			BIC b = new BIC("FOOOESHU");
			assertTrue(b.Valid);
			assertEquals(BicValidationResult.OK, b.validate());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsValid3()
		public virtual void testIsValid3()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final BIC b = new BIC("FOOBAR22XXX");
			BIC b = new BIC("FOOBAR22XXX");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean valid = b.isValid();
			bool valid = b.Valid;
			assertTrue(valid);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsValid4()
		public virtual void testIsValid4()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final BIC b = new BIC("AZADAEKWXXX");
			BIC b = new BIC("AZADAEKWXXX");
			BicValidationResult result = b.validate();
			assertEquals(BicValidationResult.OK, result);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsValidBadCountry()
		public virtual void testIsValidBadCountry()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final BIC b = new BIC("FOOOAAHU");
			BIC b = new BIC("FOOOAAHU");
			assertFalse(b.Valid);
			assertEquals(BicValidationResult.INVALID_COUNTRY, b.validate());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsValidAlphanumeric()
		public virtual void testIsValidAlphanumeric()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final BIC b = new BIC("FO-OAR11");
			BIC b = new BIC("FO-OAR11");
			assertFalse(b.Valid);
			assertEquals(BicValidationResult.INVALID_INSTITUTION_CHARSET, b.validate());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testIsValidUppercase()
		public virtual void testIsValidUppercase()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final BIC b = new BIC("FOoOAR12");
			BIC b = new BIC("FOoOAR12");
			assertFalse(b.Valid);
			assertEquals(BicValidationResult.INVALID_INSTITUTION_CHARSET, b.validate());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testTestAndTraining()
		public virtual void testTestAndTraining()
		{
			assertTrue((new BIC("FOOOOO00AB")).TestAndTraining);
			assertFalse((new BIC("")).TestAndTraining);
			assertFalse((new BIC("FOOOOOAUAB")).TestAndTraining);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBIC8()
		public virtual void testBIC8()
		{
			assertEquals("FOOOOOHU", (new BIC("FOOOOOHUAXXX")).Bic8);
			assertEquals("FOOOOOHU", (new BIC("FOOOOOHUXXX")).Bic8);
			assertEquals("FOOOOOHU", (new BIC("FOOOOOHU")).Bic8);
			assertNull((new BIC("FOO")).Bic8);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testBIC11()
		public virtual void testBIC11()
		{
			assertEquals("FOOOOOHUXXX", (new BIC("FOOOOOHUAXXX")).Bic11); //LT is picked up as part of the branch
			assertEquals("FOOOOOHUXXX", (new BIC("FOOOOOHUXXX")).Bic11);
			assertEquals("FOOOOOHUXXX", (new BIC("FOOOOOHU")).Bic11);
			assertNull((new BIC("FOO")).Bic8);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testDistinguishedName()
		public virtual void testDistinguishedName()
		{
			assertEquals("o=bacoarb1,o=swift", (new BIC("BACOARB1")).distinguishedName());
			assertEquals("o=bacoarb1,o=swift", (new BIC("BACOARB1XXX")).distinguishedName());
			assertEquals("ou=0be,o=bacoarb1,o=swift", (new BIC("BACOARB10BE")).distinguishedName());
		}

	}

}