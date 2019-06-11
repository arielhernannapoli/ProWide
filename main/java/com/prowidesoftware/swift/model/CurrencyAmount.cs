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
namespace com.prowidesoftware.swift.model
{


	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;

	using AmountContainer = com.prowidesoftware.swift.model.field.AmountContainer;
	using CurrencyContainer = com.prowidesoftware.swift.model.field.CurrencyContainer;
	using Field = com.prowidesoftware.swift.model.field.Field;

	/// <summary>
	/// A simple POJO to represent money, an amount associated with a currency.
	/// <br>
	/// This might someday be replaced by an implementation of Java Money: https://java.net/projects/javamoney/pages/Home
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.8.8
	/// </summary>
	[Serializable]
	internal sealed class CurrencyAmount
	{
		private const long serialVersionUID = -7552352742105490377L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly Logger log = Logger.getLogger(typeof(CurrencyAmount).FullName);

		private readonly string currency;
		private readonly decimal amount;

		/// <param name="currency"> a not null currency </param>
		/// <param name="amount"> the value for the amount, may be null </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: CurrencyAmount(final java.util.Currency currency, final java.math.BigDecimal amount)
		internal CurrencyAmount(Currency currency, decimal amount) : this(currency.CurrencyCode, amount)
		{
		}

		/// <param name="currency"> a not null currency code </param>
		/// <param name="amount"> the value for the amount, may be null </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: CurrencyAmount(final String currency, final java.math.BigDecimal amount)
		internal CurrencyAmount(string currency, decimal amount) : base()
		{
			Validate.notNull(currency, "currency can not be null");
			this.currency = currency;
			if (amount == null)
			{
				this.amount = decimal.Zero;
			}
			else
			{
				this.amount = amount;
			}
		}

		/// <param name="currency"> a not null currency </param>
		/// <param name="value"> the value for the amount, may be null </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: CurrencyAmount(final java.util.Currency currency, Number amount)
		internal CurrencyAmount(Currency currency, Number amount) : this(currency.CurrencyCode, amount)
		{
		}

		/// <param name="currency"> a not null currency code </param>
		/// <param name="value"> the value for the amount, may be null </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: CurrencyAmount(final String currency, Number amount)
		internal CurrencyAmount(string currency, Number amount) : base()
		{
			this.currency = currency;
			if (amount == null)
			{
				this.amount = decimal.Zero;
			}
			else
			{
				if (amount is decimal)
				{
					this.amount = (decimal)amount;
				}
				else if (amount is long?)
				{
					this.amount = new decimal((long)((long?)amount));
				}
				else if (amount is int?)
				{
					this.amount = new decimal((int)((int?)amount));
				}
				else if (amount is short?)
				{
					this.amount = new decimal((int)((short?)amount));
				}
				else if (amount is double?)
				{
					/*
					 * we use valueOf instead of constructor because it uses a string under the covers to eliminate floating point rounding errors
					 */
					this.amount = decimal.valueOf((double)((double?)amount));
				}
				else
				{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
					throw new System.ArgumentException("class " + amount.GetType().FullName + " is not supported");
				}
			}
		}

		public string Currency
		{
			get
			{
				return currency;
			}
		}

		public decimal Amount
		{
			get
			{
				return amount;
			}
		}

		/// <summary>
		/// Creates a currency amount from an MT field.<br>
		/// The field must at least implement the <seealso cref="AmountContainer"/> interface and 
		/// either have a currency component or implements the <seealso cref="CurrencyContainer"/>
		/// For some fields like the signed 19A or the 62[F,M] which have a debit/credit mark
		/// component, the amount will be positive or negative accordingly.
		/// </summary>
		/// <param name="field"> a field with currency and amount components </param>
		/// <returns> the created currency amount object or null if field is null or invalid. </returns>
		/*
		 * Do not use API from MTs and Field classes here to avoid cyclic dependency in code generation
		 * Component numbers do not normally change, although keep code below in sync with fields 62FM, 19A and 33B. 
		 */
		internal static CurrencyAmount of(Field field)
		{
			if (field != null && field is AmountContainer)
			{
				/*
				 * amount from interface
				 */
				decimal amount = ((AmountContainer)field).amount();
				if (amount == null)
				{
					log.warning("cannot extract amount component from field " + field.Name + ":" + field.Value);
					return null;
				}

				/*
				 * special cases
				 */
				string currency = null;
				bool negative = false;
				if ("62F".Equals(field.Name) || "62M".Equals(field.Name))
				{
					currency = field.getComponent(3);
					negative = StringUtils.Equals("D", field.getComponent(1));
				}
				else if ("19A".Equals(field.Name))
				{
					negative = StringUtils.Equals("N", field.getComponent(2));
				}
				else if ("33B".Equals(field.Name))
				{
					currency = field.getComponent(1);
				}

				/*
				 * currency from interface
				 */
				if (currency == null && field is CurrencyContainer)
				{
					currency = ((CurrencyContainer)field).currencyString();
				}

				if (currency == null)
				{
					log.warning("cannot extract currency component from field " + field.Name + ":" + field.Value);
					return null;
				}

				if (negative)
				{
					amount = -amount;
				}
				return new CurrencyAmount(currency, amount);
			}
			return null;
		}

		/// <summary>
		/// Creates a currency amount from the first found field in the block </summary>
		/// <param name="fields">
		/// @return </param>
		internal static CurrencyAmount ofAny(SwiftTagListBlock block, params string[] fieldNames)
		{
			foreach (string fieldName in fieldNames)
			{
				Field field = block.getFieldByName(fieldName);
				if (field != null)
				{
					return of(field);
				}
			}
			return null;
		}

		/// <summary>
		/// Creates a currency amount from the sum of all given fields.
		/// Will return null if currencies not match. </summary>
		/// <param name="fields"> fields to sum, currency must be the same for all </param>
		/// <returns> total or null if cannot create amount from any field or if not all fields currency match </returns>
		internal static CurrencyAmount ofSum(params Field[] fields)
		{
			if (fields == null || fields.Length == 0)
			{
				return null;
			}
			decimal total = null;
			string currency = null;
			foreach (Field field in fields)
			{
				CurrencyAmount ca = of(field);
				if (ca == null)
				{
					return null;
				}
				if (total == null)
				{
					total = ca.Amount;
					currency = ca.Currency;
				}
				else if (StringUtils.Equals(currency, ca.Currency))
				{
					total = total + ca.Amount;
				}
				else
				{
					log.warning("cannot sum amounts with different currencies, expected " + currency + " and found " + ca.Currency + " in field " + field.Name + ":" + field.Value);
					return null;
				}
			}
			if (total != null && currency != null)
			{
				return new CurrencyAmount(currency, total);
			}
			else
			{
				return null;
			}
		}
	}

}