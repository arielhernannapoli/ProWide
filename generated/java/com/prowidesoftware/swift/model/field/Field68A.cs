using System;
using System.Collections.Generic;
using System.Text;

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

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;


	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using SwiftFormatUtils = com.prowidesoftware.swift.utils.SwiftFormatUtils;

	using JsonObject = com.google.gson.JsonObject;
	using JsonParser = com.google.gson.JsonParser;

	/// <summary>
	/// <strong>SWIFT MT Field 68A</strong>
	/// <para>
	/// Model and parser for field 68A of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Currency</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>6n&lt;CUR&gt;6n/2n[/&lt;AMOUNT&gt;15][//10x]</code></li>
	/// 		<li>parser pattern: <code>NSN/N[/N][//S]</code></li>
	/// 		<li>components pattern: <code>NCNNNS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field68A extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.CurrencyContainer, com.prowidesoftware.swift.model.field.AmountContainer
	[Serializable]
	public class Field68A : Field, CurrencyContainer, AmountContainer
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 68A
		/// </summary>
		public const string NAME = "68A";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_68A = "68A";
		public const string PARSER_PATTERN = "NSN/N[/N][//S]";
		public const string COMPONENTS_PATTERN = "NCNNNS";

		/// <summary>
		/// Component number for the Number subfield
		/// </summary>
		public const int? NUMBER = 1;

		/// <summary>
		/// Component number for the Currency subfield
		/// </summary>
		public const int? CURRENCY = 2;

		/// <summary>
		/// Component number for the Denomination subfield
		/// </summary>
		public const int? DENOMINATION = 3;

		/// <summary>
		/// Component number for the Mode subfield
		/// </summary>
		public const int? MODE = 4;

		/// <summary>
		/// Component number for the Amount subfield
		/// </summary>
		public const int? AMOUNT = 5;

		/// <summary>
		/// Component number for the Product Code subfield
		/// </summary>
		public const int? PRODUCT_CODE = 6;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field68A() : base(6)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field68A(final String value)
		public Field68A(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field68A(final com.prowidesoftware.swift.model.Tag tag)
		public Field68A(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "68A"))
			{
				throw new System.ArgumentException("cannot create field 68A from tag " + tag.Name + ", tagname must match the name of the field.");
			}
			parse(tag.Value);
		}

		/// <summary>
		/// Parses the parameter value into the internal components structure.
		/// <br>
		/// Used to update all components from a full new value, as an alternative
		/// to setting individual components. Previous component values are overwritten.
		/// </summary>
		/// <param name="value"> complete field value including separators and CRLF
		/// @since 7.8 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public void parse(final String value)
		public override void parse(string value)
		{
			init(6);
			string toparse = SwiftParseUtils.getTokenFirst(value, "/");
			setComponent1(SwiftParseUtils.getNumericPrefix(toparse));
			string toparse2 = SwiftParseUtils.getAlphaSuffix(toparse);
			setComponent2(SwiftParseUtils.getAlphaPrefix(toparse2));
			setComponent3(SwiftParseUtils.getNumericSuffix(toparse2));
			setComponent4(SwiftParseUtils.getTokenSecond(value, "/"));
			toparse = SwiftParseUtils.getTokenThirdLast(value, "/");
			setComponent5(SwiftParseUtils.getTokenFirst(toparse, "//"));
			Component6 = SwiftParseUtils.getTokenSecond(toparse, "//");
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field68A newInstance(Field68A source)
		{
			Field68A cp = new Field68A();
			cp.Components = new List<>(source.Components);
			return cp;
		}

		/// <summary>
		/// Serializes the fields' components into the single string value (SWIFT format)
		/// </summary>
		public override string Value
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final StringBuilder result = new StringBuilder();
				StringBuilder result = new StringBuilder();
				append(result, 1);
				append(result, 2);
				append(result, 3);
				result.Append("/");
				append(result, 4);
				if (getComponent5() != null)
				{
					result.Append("/").Append(getComponent5());
				}
				if (Component6 != null)
				{
					result.Append("//").Append(Component6);
				}
				return result.ToString();
			}
		}

		/// <summary>
		/// Create a Tag with this field name and the given value.
		/// Shorthand for <code>new Tag(NAME, value)</code> </summary>
		/// <seealso cref= #NAME
		/// @since 7.5 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.Tag tag(final String value)
		public static Tag tag(string value)
		{
			return new Tag(NAME, value);
		}

		/// <summary>
		/// Create a Tag with this field name and an empty string as value
		/// Shorthand for <code>new Tag(NAME, "")</code> </summary>
		/// <seealso cref= #NAME
		/// @since 7.5 </seealso>
		public static Tag emptyTag()
		{
			return new Tag(NAME, "");
		}

		/// <summary>
		/// Gets the component1 </summary>
		/// <returns> the component1 </returns>
		public virtual string getComponent1()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the component1 as Number </summary>
		/// <returns> the component1 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component1AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(1));
			}
		}

		/// <summary>
		/// Gets the Number (component1). </summary>
		/// <returns> the Number from component1 </returns>
		public virtual string getNumber()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the Number (component1) as Number </summary>
		/// <returns> the Number from component1 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number NumberAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field68A setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the component1 from a Number object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component1"> the Number with the component1 content to set </param>
		public virtual Field68A setComponent1(java.lang.Number component1)
		{
			setComponent(1, SwiftFormatUtils.getNumber(component1));
			return this;
		}

		/// <summary>
		/// Set the Number (component1). </summary>
		/// <param name="component1"> the Number to set </param>
		public virtual Field68A setNumber(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Number (component1) from a Number object. </summary>
		/// <seealso cref= #setComponent1(java.lang.Number) </seealso>
		/// <param name="component1"> Number with the Number content to set </param>
		public virtual Field68A setNumber(java.lang.Number component1)
		{
			setComponent1(component1);
			return this;
		}
		/// <summary>
		/// Gets the component2 </summary>
		/// <returns> the component2 </returns>
		public virtual string getComponent2()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the component2 as Currency </summary>
		/// <returns> the component2 converted to Currency or null if cannot be converted </returns>
		public virtual Currency Component2AsCurrency
		{
			get
			{
				return SwiftFormatUtils.getCurrency(getComponent(2));
			}
		}

		/// <summary>
		/// Gets the Currency (component2). </summary>
		/// <returns> the Currency from component2 </returns>
		public virtual string getCurrency()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the Currency (component2) as Currency </summary>
		/// <returns> the Currency from component2 converted to Currency or null if cannot be converted </returns>
		public virtual Currency CurrencyAsCurrency
		{
			get
			{
				return SwiftFormatUtils.getCurrency(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field68A setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a Currency object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component2"> the Currency with the component2 content to set </param>
		public virtual Field68A setComponent2(Currency component2)
		{
			setComponent(2, SwiftFormatUtils.getCurrency(component2));
			return this;
		}

		/// <summary>
		/// Set the Currency (component2). </summary>
		/// <param name="component2"> the Currency to set </param>
		public virtual Field68A setCurrency(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Currency (component2) from a Currency object. </summary>
		/// <seealso cref= #setComponent2(java.util.Currency) </seealso>
		/// <param name="component2"> Currency with the Currency content to set </param>
		public virtual Field68A setCurrency(Currency component2)
		{
			setComponent2(component2);
			return this;
		}
		/// <summary>
		/// Gets the component3 </summary>
		/// <returns> the component3 </returns>
		public virtual string getComponent3()
		{
			return getComponent(3);
		}

		/// <summary>
		/// Get the component3 as Number </summary>
		/// <returns> the component3 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component3AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(3));
			}
		}

		/// <summary>
		/// Gets the Denomination (component3). </summary>
		/// <returns> the Denomination from component3 </returns>
		public virtual string getDenomination()
		{
			return getComponent(3);
		}

		/// <summary>
		/// Get the Denomination (component3) as Number </summary>
		/// <returns> the Denomination from component3 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number DenominationAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(3));
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field68A setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the component3 from a Number object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component3"> the Number with the component3 content to set </param>
		public virtual Field68A setComponent3(java.lang.Number component3)
		{
			setComponent(3, SwiftFormatUtils.getNumber(component3));
			return this;
		}

		/// <summary>
		/// Set the Denomination (component3). </summary>
		/// <param name="component3"> the Denomination to set </param>
		public virtual Field68A setDenomination(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Denomination (component3) from a Number object. </summary>
		/// <seealso cref= #setComponent3(java.lang.Number) </seealso>
		/// <param name="component3"> Number with the Denomination content to set </param>
		public virtual Field68A setDenomination(java.lang.Number component3)
		{
			setComponent3(component3);
			return this;
		}
		/// <summary>
		/// Gets the component4 </summary>
		/// <returns> the component4 </returns>
		public virtual string getComponent4()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the component4 as Number </summary>
		/// <returns> the component4 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component4AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(4));
			}
		}

		/// <summary>
		/// Gets the Mode (component4). </summary>
		/// <returns> the Mode from component4 </returns>
		public virtual string getMode()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the Mode (component4) as Number </summary>
		/// <returns> the Mode from component4 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number ModeAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(4));
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field68A setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the component4 from a Number object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component4"> the Number with the component4 content to set </param>
		public virtual Field68A setComponent4(java.lang.Number component4)
		{
			setComponent(4, SwiftFormatUtils.getNumber(component4));
			return this;
		}

		/// <summary>
		/// Set the Mode (component4). </summary>
		/// <param name="component4"> the Mode to set </param>
		public virtual Field68A setMode(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Mode (component4) from a Number object. </summary>
		/// <seealso cref= #setComponent4(java.lang.Number) </seealso>
		/// <param name="component4"> Number with the Mode content to set </param>
		public virtual Field68A setMode(java.lang.Number component4)
		{
			setComponent4(component4);
			return this;
		}
		/// <summary>
		/// Gets the component5 </summary>
		/// <returns> the component5 </returns>
		public virtual string getComponent5()
		{
			return getComponent(5);
		}

		/// <summary>
		/// Get the component5 as Number </summary>
		/// <returns> the component5 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component5AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(5));
			}
		}

		/// <summary>
		/// Gets the Amount (component5). </summary>
		/// <returns> the Amount from component5 </returns>
		public virtual string getAmount()
		{
			return getComponent(5);
		}

		/// <summary>
		/// Get the Amount (component5) as Number </summary>
		/// <returns> the Amount from component5 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number AmountAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(5));
			}
		}

		/// <summary>
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field68A setComponent5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the component5 from a Number object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component5"> the Number with the component5 content to set </param>
		public virtual Field68A setComponent5(java.lang.Number component5)
		{
			setComponent(5, SwiftFormatUtils.getNumber(component5));
			return this;
		}

		/// <summary>
		/// Set the Amount (component5). </summary>
		/// <param name="component5"> the Amount to set </param>
		public virtual Field68A setAmount(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Amount (component5) from a Number object. </summary>
		/// <seealso cref= #setComponent5(java.lang.Number) </seealso>
		/// <param name="component5"> Number with the Amount content to set </param>
		public virtual Field68A setAmount(java.lang.Number component5)
		{
			setComponent5(component5);
			return this;
		}
		/// <summary>
		/// Gets the component6 </summary>
		/// <returns> the component6 </returns>
		public virtual string Component6
		{
			get
			{
				return getComponent(6);
			}
		}

		/// <summary>
		/// Same as getComponent(6) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent6AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component6AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent6AsString()", "Use use #getComponent(int) instead.");
				return getComponent(6);
			}
		}

		/// <summary>
		/// Gets the Product Code (component6). </summary>
		/// <returns> the Product Code from component6 </returns>
		public virtual string ProductCode
		{
			get
			{
				return getComponent(6);
			}
		}

		/// <summary>
		/// Set the component6. </summary>
		/// <param name="component6"> the component6 to set </param>
		public virtual Field68A setComponent6(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the Product Code (component6). </summary>
		/// <param name="component6"> the Product Code to set </param>
		public virtual Field68A setProductCode(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		public virtual IList<string> currencyStrings()
		{
			return CurrencyResolver.resolveComponentsPattern(COMPONENTS_PATTERN, components);
		}

		public virtual IList<Currency> currencies()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<String> l = currencyStrings();
			IList<string> l = currencyStrings();
			if (l.Count == 0)
			{
				return java.util.Collections.emptyList();
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<java.util.Currency> result = new java.util.ArrayList<>();
			IList<Currency> result = new List<Currency>();
			foreach (string s in l)
			{
				result.Add(Currency.getInstance(s));
			}
			return result;
		}

		public virtual Currency currency()
		{
			return CurrencyResolver.resolveCurrency(this);
		}

		public virtual string currencyString()
		{
			return CurrencyResolver.resolveCurrencyString(this);
		}

		public virtual void initializeCurrencies(string cur)
		{
			CurrencyResolver.resolveSetCurrency(this, cur);
		}

		public virtual void initializeCurrencies(Currency cur)
		{
			CurrencyResolver.resolveSetCurrency(this, cur);
		}

		/// <seealso cref= AmountResolver#amounts(Field) </seealso>
		public virtual IList<decimal> amounts()
		{
			return AmountResolver.amounts(this);
		}

		/// <seealso cref= AmountResolver#amount(Field) </seealso>
		public virtual decimal amount()
		{
			return AmountResolver.amount(this);
		}

	   /// <summary>
	   /// Given a component number it returns true if the component is optional,
	   /// regardless of the field being mandatory in a particular message.<br>
	   /// Being the field's value conformed by a composition of one or several 
	   /// internal component values, the field may be present in a message with
	   /// a proper value but with some of its internal components not set.
	   /// </summary>
	   /// <param name="component"> component number, first component of a field is referenced as 1 </param>
	   /// <returns> true if the component is optional for this field, false otherwise </returns>
	   public override bool isOptional(int component)
	   {
		   if (component == 5)
		   {
			   return true;
		   }
		   if (component == 6)
		   {
			   return true;
		   }
		   return false;
	   }

	   /// <summary>
	   /// Returns true if the field is a GENERIC FIELD as specified by the standard.
	   /// </summary>
	   /// <returns> true if the field is generic, false otherwise </returns>
	   public override bool Generic
	   {
		   get
		   {
			   return false;
		   }
	   }

	   public override string parserPattern()
	   {
			   return PARSER_PATTERN;
	   }

		/// <summary>
		/// Returns the field's name composed by the field number and the letter option (if any) </summary>
		/// <returns> the static value of Field68A.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field68A.COMPONENTS_PATTERN </returns>
		public sealed override string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "6n<CUR>6n/2n[/<AMOUNT>15][//10x]";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field68A get(final SwiftTagListBlock block)
		public static Field68A get(SwiftTagListBlock block)
		{
			if (block == null || block.Empty)
			{
				return null;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.Tag t = block.getTagByName(NAME);
			Tag t = block.getTagByName(NAME);
			if (t == null)
			{
				return null;
			}
			return new Field68A(t);
		}

		/// <summary>
		/// Gets the first instance of Field68A in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field68A get(final SwiftMessage msg)
		public static Field68A get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field68A in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field68A> getAll(final SwiftMessage msg)
		public static IList<Field68A> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field68A from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field68A> getAll(final SwiftTagListBlock block)
		public static IList<Field68A> getAll(SwiftTagListBlock block)
		{
			if (block == null || block.Empty)
			{
				return java.util.Collections.emptyList();
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.Tag[] arr = block.getTagsByName(NAME);
			Tag[] arr = block.getTagsByName(NAME);
			if (arr != null && arr.Length > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<Field68A> result = new java.util.ArrayList<>(arr.length);
				IList<Field68A> result = new List<Field68A>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field68A(f));
				}
				return result;
			}
			return java.util.Collections.emptyList();
		}

		/// <summary>
		/// Returns the defined amount of components.<br>
		/// This is not the amount of components present in the field instance, but the total amount of components 
		/// that this field accepts as defined. 
		/// @since 7.7
		/// </summary>
		public override int componentsSize()
		{
			return 6;
		}

		/// <summary>
		/// Returns a localized suitable for showing to humans string of a field component.<br>
		/// </summary>
		/// <param name="component"> number of the component to display </param>
		/// <param name="locale"> optional locale to format date and amounts, if null, the default locale is used </param>
		/// <returns> formatted component value or null if component number is invalid or not present </returns>
		/// <exception cref="IllegalArgumentException"> if component number is invalid for the field
		/// @since 7.8 </exception>
		public override string getValueDisplay(int component, Locale locale)
		{
			if (component < 1 || component > 6)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 68A");
			}
			if (component == 1)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component1AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 2)
			{
				//default format (as is)
				return getComponent(2);
			}
			if (component == 3)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component3AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 4)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component4AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 5)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component5AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 6)
			{
				//default format (as is)
				return getComponent(6);
			}
			return null;
		}

		/// <summary>
		/// Returns english label for components.
		/// <br>
		/// The index in the list is in sync with specific field component structure. </summary>
		/// <seealso cref= #getComponentLabel(int)
		/// @since 7.8.4 </seealso>
		protected internal override IList<string> ComponentLabels
		{
			get
			{
				IList<string> result = new List<string>();
				result.Add("Number");
				result.Add("Currency");
				result.Add("Denomination");
				result.Add("Mode");
				result.Add("Amount");
				result.Add("Product Code");
				return result;
			}
		}

		/// <summary>
		/// Returns a mapping between component numbers and their label in camel case format.
		/// @since 7.10.3
		/// </summary>
		protected internal override IDictionary<int?, string> ComponentMap
		{
			get
			{
				IDictionary<int?, string> result = new Dictionary<int?, string>();
				result[1] = "number";
				result[2] = "currency";
				result[3] = "denomination";
				result[4] = "mode";
				result[5] = "amount";
				result[6] = "productCode";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field68A object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field68A fromJson(final String json)
		public static Field68A fromJson(string json)
		{
			Field68A field = new Field68A();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("number") != null)
			{
				field.setComponent1(jsonObject.get("number").AsString);
			}
			if (jsonObject.get("currency") != null)
			{
				field.setComponent2(jsonObject.get("currency").AsString);
			}
			if (jsonObject.get("denomination") != null)
			{
				field.setComponent3(jsonObject.get("denomination").AsString);
			}
			if (jsonObject.get("mode") != null)
			{
				field.setComponent4(jsonObject.get("mode").AsString);
			}
			if (jsonObject.get("amount") != null)
			{
				field.setComponent5(jsonObject.get("amount").AsString);
			}
			if (jsonObject.get("productCode") != null)
			{
				field.Component6 = jsonObject.get("productCode").AsString;
			}
			return field;
		}


	}

}