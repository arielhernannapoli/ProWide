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
	/// <strong>SWIFT MT Field 32K</strong>
	/// <para>
	/// Model and parser for field 32K of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Currency</code></li> 
	/// 		<li><code>Number</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>&lt;DM&gt;3!n2!a&lt;CUR&gt;&lt;AMOUNT&gt;15</code></li>
	/// 		<li>parser pattern: <code>cNS&lt;CUR&gt;N</code></li>
	/// 		<li>components pattern: <code>SNSCN</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field32K extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.CurrencyContainer, com.prowidesoftware.swift.model.field.AmountContainer
	[Serializable]
	public class Field32K : Field, CurrencyContainer, AmountContainer
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 32K
		/// </summary>
		public const string NAME = "32K";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_32K = "32K";
		public const string PARSER_PATTERN = "cNS<CUR>N";
		public const string COMPONENTS_PATTERN = "SNSCN";

		/// <summary>
		/// Component number for the D/M Mark subfield
		/// </summary>
		public const int? DM_MARK = 1;

		/// <summary>
		/// Component number for the Number of Days/Months subfield
		/// </summary>
		public const int? NUMBER_OF_DAYSMONTHS = 2;

		/// <summary>
		/// Component number for the Code subfield
		/// </summary>
		public const int? CODE = 3;

		/// <summary>
		/// Component number for the Currency subfield
		/// </summary>
		public const int? CURRENCY = 4;

		/// <summary>
		/// Component number for the Amount subfield
		/// </summary>
		public const int? AMOUNT = 5;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field32K() : base(5)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field32K(final String value)
		public Field32K(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field32K(final com.prowidesoftware.swift.model.Tag tag)
		public Field32K(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "32K"))
			{
				throw new System.ArgumentException("cannot create field 32K from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(5);
			Component1 = SwiftParseUtils.getAlphaPrefix(value);
			string toparse = SwiftParseUtils.getNumericSuffix(value);
			setComponent2(SwiftParseUtils.getNumericPrefix(toparse));
			string toparse2 = SwiftParseUtils.getAlphaSuffix(toparse);
			setComponent5(SwiftParseUtils.getNumericSuffix(toparse2));
			string toparse3 = SwiftParseUtils.getAlphaPrefix(toparse2);
			if (toparse3 != null)
			{
				if (toparse3.Length >= 3)
				{
					setComponent4(StringUtils.Substring(toparse3, toparse3.Length - 3, toparse3.Length));
				}
				if (toparse3.Length >= 4)
				{
					Component3 = StringUtils.Substring(toparse3, 0, toparse3.Length - 3);
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field32K newInstance(Field32K source)
		{
			Field32K cp = new Field32K();
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
				result.Append(joinComponents());
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
		public virtual string Component1
		{
			get
			{
				return getComponent(1);
			}
		}

		/// <summary>
		/// Same as getComponent(1) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent1AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component1AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent1AsString()", "Use use #getComponent(int) instead.");
				return getComponent(1);
			}
		}

		/// <summary>
		/// Gets the D/M Mark (component1). </summary>
		/// <returns> the D/M Mark from component1 </returns>
		public virtual string DMMark
		{
			get
			{
				return getComponent(1);
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field32K setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the D/M Mark (component1). </summary>
		/// <param name="component1"> the D/M Mark to set </param>
		public virtual Field32K setDMMark(string component1)
		{
			setComponent(1, component1);
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
		/// Get the component2 as Number </summary>
		/// <returns> the component2 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component2AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(2));
			}
		}

		/// <summary>
		/// Gets the Number of Days/Months (component2). </summary>
		/// <returns> the Number of Days/Months from component2 </returns>
		public virtual string getNumberofDaysMonths()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the Number of Days/Months (component2) as Number </summary>
		/// <returns> the Number of Days/Months from component2 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number NumberofDaysMonthsAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field32K setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a Number object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component2"> the Number with the component2 content to set </param>
		public virtual Field32K setComponent2(java.lang.Number component2)
		{
			setComponent(2, SwiftFormatUtils.getNumber(component2));
			return this;
		}

		/// <summary>
		/// Set the Number of Days/Months (component2). </summary>
		/// <param name="component2"> the Number of Days/Months to set </param>
		public virtual Field32K setNumberofDaysMonths(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Number of Days/Months (component2) from a Number object. </summary>
		/// <seealso cref= #setComponent2(java.lang.Number) </seealso>
		/// <param name="component2"> Number with the Number of Days/Months content to set </param>
		public virtual Field32K setNumberofDaysMonths(java.lang.Number component2)
		{
			setComponent2(component2);
			return this;
		}
		/// <summary>
		/// Gets the component3 </summary>
		/// <returns> the component3 </returns>
		public virtual string Component3
		{
			get
			{
				return getComponent(3);
			}
		}

		/// <summary>
		/// Same as getComponent(3) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent3AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component3AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent3AsString()", "Use use #getComponent(int) instead.");
				return getComponent(3);
			}
		}

		/// <summary>
		/// Gets the Code (component3). </summary>
		/// <returns> the Code from component3 </returns>
		public virtual string Code
		{
			get
			{
				return getComponent(3);
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field32K setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Code (component3). </summary>
		/// <param name="component3"> the Code to set </param>
		public virtual Field32K setCode(string component3)
		{
			setComponent(3, component3);
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
		/// Get the component4 as Currency </summary>
		/// <returns> the component4 converted to Currency or null if cannot be converted </returns>
		public virtual Currency Component4AsCurrency
		{
			get
			{
				return SwiftFormatUtils.getCurrency(getComponent(4));
			}
		}

		/// <summary>
		/// Gets the Currency (component4). </summary>
		/// <returns> the Currency from component4 </returns>
		public virtual string getCurrency()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the Currency (component4) as Currency </summary>
		/// <returns> the Currency from component4 converted to Currency or null if cannot be converted </returns>
		public virtual Currency CurrencyAsCurrency
		{
			get
			{
				return SwiftFormatUtils.getCurrency(getComponent(4));
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field32K setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the component4 from a Currency object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component4"> the Currency with the component4 content to set </param>
		public virtual Field32K setComponent4(Currency component4)
		{
			setComponent(4, SwiftFormatUtils.getCurrency(component4));
			return this;
		}

		/// <summary>
		/// Set the Currency (component4). </summary>
		/// <param name="component4"> the Currency to set </param>
		public virtual Field32K setCurrency(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Currency (component4) from a Currency object. </summary>
		/// <seealso cref= #setComponent4(java.util.Currency) </seealso>
		/// <param name="component4"> Currency with the Currency content to set </param>
		public virtual Field32K setCurrency(Currency component4)
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
		public virtual Field32K setComponent5(string component5)
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
		public virtual Field32K setComponent5(java.lang.Number component5)
		{
			setComponent(5, SwiftFormatUtils.getNumber(component5));
			return this;
		}

		/// <summary>
		/// Set the Amount (component5). </summary>
		/// <param name="component5"> the Amount to set </param>
		public virtual Field32K setAmount(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Amount (component5) from a Number object. </summary>
		/// <seealso cref= #setComponent5(java.lang.Number) </seealso>
		/// <param name="component5"> Number with the Amount content to set </param>
		public virtual Field32K setAmount(java.lang.Number component5)
		{
			setComponent5(component5);
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
		/// <returns> the static value of Field32K.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field32K.COMPONENTS_PATTERN </returns>
		public sealed override string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "<DM>3!n2!a<CUR><AMOUNT>15";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field32K get(final SwiftTagListBlock block)
		public static Field32K get(SwiftTagListBlock block)
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
			return new Field32K(t);
		}

		/// <summary>
		/// Gets the first instance of Field32K in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field32K get(final SwiftMessage msg)
		public static Field32K get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field32K in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field32K> getAll(final SwiftMessage msg)
		public static IList<Field32K> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field32K from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field32K> getAll(final SwiftTagListBlock block)
		public static IList<Field32K> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field32K> result = new java.util.ArrayList<>(arr.length);
				IList<Field32K> result = new List<Field32K>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field32K(f));
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
			return 5;
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
			if (component < 1 || component > 5)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 32K");
			}
			if (component == 1)
			{
				//default format (as is)
				return getComponent(1);
			}
			if (component == 2)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component2AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 3)
			{
				//default format (as is)
				return getComponent(3);
			}
			if (component == 4)
			{
				//default format (as is)
				return getComponent(4);
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
				result.Add("D/M Mark");
				result.Add("Number of Days/Months");
				result.Add("Code");
				result.Add("Currency");
				result.Add("Amount");
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
				result[1] = "dMMark";
				result[2] = "numberofDaysMonths";
				result[3] = "code";
				result[4] = "currency";
				result[5] = "amount";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field32K object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field32K fromJson(final String json)
		public static Field32K fromJson(string json)
		{
			Field32K field = new Field32K();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("dMMark") != null)
			{
				field.Component1 = jsonObject.get("dMMark").AsString;
			}
			if (jsonObject.get("numberofDaysMonths") != null)
			{
				field.setComponent2(jsonObject.get("numberofDaysMonths").AsString);
			}
			if (jsonObject.get("code") != null)
			{
				field.Component3 = jsonObject.get("code").AsString;
			}
			if (jsonObject.get("currency") != null)
			{
				field.setComponent4(jsonObject.get("currency").AsString);
			}
			if (jsonObject.get("amount") != null)
			{
				field.setComponent5(jsonObject.get("amount").AsString);
			}
			return field;
		}


	}

}