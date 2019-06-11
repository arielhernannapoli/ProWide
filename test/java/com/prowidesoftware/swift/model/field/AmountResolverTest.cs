using System.Collections.Generic;

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
	import static org.junit.Assert.assertNotNull;


	using Test = org.junit.Test;

	public class AmountResolverTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testResolveField32A()
		public virtual void testResolveField32A()
		{
			Field32A f = new Field32A("130901USD10");
			assertEquals(new decimal(10), AmountResolver.amount(f));

			f = new Field32A("130901USD10,");
			assertEquals(new decimal(10), AmountResolver.amount(f));

			f = new Field32A("130901USD10,1");
			assertEquals(new decimal("10.1"), AmountResolver.amount(f));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testResolveField32B()
		public virtual void testResolveField32B()
		{
			Field32B f = new Field32B("USD10");
			assertEquals(new decimal(10), AmountResolver.amount(f));

			f = new Field32B("USD10,");
			assertEquals(new decimal(10), AmountResolver.amount(f));

			f = new Field32B("USD10,1");
			assertEquals(new decimal("10.1"), AmountResolver.amount(f));

		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testResolveField32B_JPY()
		public virtual void testResolveField32B_JPY()
		{
			Field32B _32B = new Field32B("JPY21000000,");
			assertNotNull(_32B.amount());
			assertEquals(new decimal("21000000"), _32B.amount());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testResolve90F_multiple()
		public virtual void testResolve90F_multiple()
		{
			Field90F _90F = new Field90F(":AAAA//BBBB/EUR1234,56/CCCC/23456,78");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<java.math.BigDecimal> amounts = _90F.amounts();
			IList<decimal> amounts = _90F.amounts();
			assertNotNull(amounts);
			assertEquals(2, amounts.Count);
			assertEquals(new decimal("1234.56"), amounts[0]);
			assertEquals(new decimal("23456.78"), amounts[1]);
		}

	}

}