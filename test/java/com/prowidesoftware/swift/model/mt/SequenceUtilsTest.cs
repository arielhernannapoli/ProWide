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

namespace com.prowidesoftware.swift.model.mt
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;

	using Test = org.junit.Test;

	using MT535 = com.prowidesoftware.swift.model.mt.mt5xx.MT535;
	using MT536 = com.prowidesoftware.swift.model.mt.mt5xx.MT536;
	using MT537 = com.prowidesoftware.swift.model.mt.mt5xx.MT537;
	using MT538 = com.prowidesoftware.swift.model.mt.mt5xx.MT538;
	using MT564 = com.prowidesoftware.swift.model.mt.mt5xx.MT564;
	using MT566 = com.prowidesoftware.swift.model.mt.mt5xx.MT566;
	using MT575 = com.prowidesoftware.swift.model.mt.mt5xx.MT575;
	using MT576 = com.prowidesoftware.swift.model.mt.mt5xx.MT576;
	using MT586 = com.prowidesoftware.swift.model.mt.mt5xx.MT586;
	using MT670 = com.prowidesoftware.swift.model.mt.mt6xx.MT670;
	using MT671 = com.prowidesoftware.swift.model.mt.mt6xx.MT671;

	public class SequenceUtilsTest
	{
		/*
		 * Si falla alguno de estos tests quiere decir que ya no es necesario  este codigo y podria volverse a 
		 * la generacion basica.
		 * Esto asegura las precondiciones que implican generar el codigo, como es un static de un lib, 
		 * el codegen no lo referencia mas al no estar vigente pero seguiria estando el metodo
		 */

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition535() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition535()
		{
			assertEquals(MT535.SequenceB1b1.START_END_16RS, MT535.SequenceB1c.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition536() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition536()
		{
			assertEquals(MT536.SequenceA1.START_END_16RS, MT536.SequenceB1a1.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition537() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition537()
		{
			assertEquals(MT537.SequenceA1.START_END_16RS, MT537.SequenceB2a.START_END_16RS);
			assertEquals(MT537.SequenceA1.START_END_16RS, MT537.SequenceC1.START_END_16RS);
			assertEquals(MT537.SequenceB.START_END_16RS, MT537.SequenceC3.START_END_16RS);
			assertEquals(MT537.SequenceB1.START_END_16RS, MT537.SequenceC3a.START_END_16RS);
			assertEquals(MT537.SequenceB2b.START_END_16RS, MT537.SequenceC2.START_END_16RS);
			assertEquals(MT537.SequenceB2b1.START_END_16RS, MT537.SequenceC2a.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition538() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition538()
		{
			assertEquals(MT538.SequenceA1.START_END_16RS, MT538.SequenceB2a1.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition564() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition564()
		{
			assertEquals(MT564.SequenceB1.START_END_16RS, MT564.SequenceE1a.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition566() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition566()
		{
			assertEquals(MT566.SequenceB1.START_END_16RS, MT566.SequenceD1a.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition575() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition575()
		{
			assertEquals(MT575.SequenceA1.START_END_16RS, MT575.SequenceB1a1.START_END_16RS);
			assertEquals(MT575.SequenceA1.START_END_16RS, MT575.SequenceC1.START_END_16RS);

			assertEquals(MT575.SequenceB1a4.START_END_16RS, MT575.SequenceC2a.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition576() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition576()
		{
			assertEquals(MT576.SequenceA1.START_END_16RS, MT576.SequenceB2a.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition586() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition586()
		{
			assertEquals(MT586.SequenceA1.START_END_16RS, MT586.SequenceB1.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition670() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition670()
		{
			assertEquals(MT670.SequenceB2.START_END_16RS, MT670.SequenceC.START_END_16RS);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPrecondition671() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void testPrecondition671()
		{
			assertEquals(MT671.SequenceB2.START_END_16RS, MT671.SequenceC.START_END_16RS);
		}
	}

}