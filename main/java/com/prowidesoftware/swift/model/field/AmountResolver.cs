﻿using System;
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

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Helper API to detect amount component in fields.
	/// </summary>
	public class AmountResolver
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		private static readonly Logger log = Logger.getLogger(typeof(AmountResolver).FullName);

		/// @deprecated use <seealso cref="#amounts(Field)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#amounts(Field)"/> instead") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static java.util.List<java.math.BigDecimal> amounts(final Field f, final int... component)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use <seealso cref="#amounts(Field)"/> instead")]
		public static IList<decimal> amounts(Field f, params int[] component)
		{
			DeprecationUtils.phase3(typeof(AmountResolver), "amounts(File, int ...)", "Use amounts(Field) instead.");
			return amounts(f);
		}

		/// <summary>
		/// Gets the amounts of the given field by reading it's components pattern.
		/// All index of 'N', number, in the pattern are looked for and returned as amount.
		/// 
		/// <em>See the returns notes</em>
		/// </summary>
		/// <param name="f"> the field where to extract the amounts, must not be null
		/// </param>
		/// <returns> a list of BigDecimal with the numbers found in the numeric components or an empty list if none is found.
		/// Missing or invalid numeric components are ignored; meaning if a components expected to be a number is not present 
		/// or it is not a valid number or Field.getComponent(index,Number.class) fails, that component is not included in the
		/// result list.
		/// </returns>
		/// <seealso cref= Field#getComponentAs(int, Class)
		/// @since 7.8.9 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<java.math.BigDecimal> amounts(final Field f)
		public static IList<decimal> amounts(Field f)
		{
			Validate.notNull(f);
			IList<decimal> amounts = new List<decimal>();
			int i = StringUtils.IndexOf(f.componentsPattern(), 'N', StringComparison.Ordinal);
			while (i >= 0)
			{
				decimal amount = amount(f, i + 1);
				if (amount != null)
				{
					amounts.Add(amount);
				}
				i = StringUtils.IndexOf(f.componentsPattern(), 'N', i + 1);
			}
			return amounts;
		}

		/// <summary>
		/// Gets the amount of the given field by reading it's components pattern.
		/// The first index of 'N', number, is returned as amount.
		/// 
		/// <em>See the returns notes</em>
		/// </summary>
		/// <param name="f"> the field where to extract the amount, must not be null
		/// </param>
		/// <returns> a BigDecimal with the number found in the first numeric component or null if there is
		/// 	no numeric component in the field. It may also return null if Field.getComponent(index,Number.class) fails
		/// 	for that component
		/// </returns>
		/// <seealso cref= Field#getComponentAs(int, Class)
		/// @since 7.8 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.math.BigDecimal amount(final Field f)
		public static decimal amount(Field f)
		{
			Validate.notNull(f);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int i = org.apache.commons.lang3.StringUtils.indexOf(f.componentsPattern(), 'N');
			int i = StringUtils.IndexOf(f.componentsPattern(), 'N', StringComparison.Ordinal);
			if (i >= 0)
			{
				return amount(f, i + 1);
			}
			return null;
		}

		/// <summary>
		/// Returns the indicated component as BigDecimal </summary>
		/// <param name="f"> the field </param>
		/// <param name="component"> a component number (1 based) </param>
		/// <returns> the BigDecimal for the amount or null if component is not found or is not a Number
		/// @since 7.8.9 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static java.math.BigDecimal amount(final Field f, int component)
		private static decimal amount(Field f, int component)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Number n = (Number) f.getComponentAs(component, Number.class);
			Number n = (Number) f.getComponentAs(component, typeof(Number));
			if (n == null)
			{
				log.warning("getComponentAs(" + (component) + ", Number.class) returned null for field " + f);
				return null;
			}
			return new decimal(n.ToString());
		}
	}

}