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
	/// <strong>SWIFT MT Field 32Q</strong>
	/// <para>
	/// Model and parser for field 32Q of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Currency</code></li> 
	/// 		<li><code>Currency</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>&lt;CUR&gt;/&lt;CUR&gt;</code></li>
	/// 		<li>parser pattern: <code>S/S</code></li>
	/// 		<li>components pattern: <code>CC</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field32Q extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.CurrencyContainer
	[Serializable]
	public class Field32Q : Field, CurrencyContainer
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 32Q
		/// </summary>
		public const string NAME = "32Q";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_32Q = "32Q";
		public const string PARSER_PATTERN = "S/S";
		public const string COMPONENTS_PATTERN = "CC";

		/// <summary>
		/// Component number for the Currency 1 subfield
		/// </summary>
		public const int? CURRENCY_1 = 1;

		/// <summary>
		/// Component number for the Currency 2 subfield
		/// </summary>
		public const int? CURRENCY_2 = 2;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field32Q() : base(2)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field32Q(final String value)
		public Field32Q(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field32Q(final com.prowidesoftware.swift.model.Tag tag)
		public Field32Q(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "32Q"))
			{
				throw new System.ArgumentException("cannot create field 32Q from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(2);
			setComponent1(SwiftParseUtils.getTokenFirst(value, "/"));
			setComponent2(SwiftParseUtils.getTokenSecond(value, "/"));
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field32Q newInstance(Field32Q source)
		{
			Field32Q cp = new Field32Q();
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
				result.Append("/");
				append(result, 2);
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
		/// Get the component1 as Currency </summary>
		/// <returns> the component1 converted to Currency or null if cannot be converted </returns>
		public virtual Currency Component1AsCurrency
		{
			get
			{
				return SwiftFormatUtils.getCurrency(getComponent(1));
			}
		}

		/// <summary>
		/// Gets the Currency 1 (component1). </summary>
		/// <returns> the Currency 1 from component1 </returns>
		public virtual string getCurrency1()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the Currency 1 (component1) as Currency </summary>
		/// <returns> the Currency 1 from component1 converted to Currency or null if cannot be converted </returns>
		public virtual Currency Currency1AsCurrency
		{
			get
			{
				return SwiftFormatUtils.getCurrency(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field32Q setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the component1 from a Currency object. </summary>
		/// <param name="component1"> the Currency with the component1 content to set </param>
		public virtual Field32Q setComponent1(Currency component1)
		{
			setComponent(1, SwiftFormatUtils.getCurrency(component1));
			return this;
		}

		/// <summary>
		/// Set the Currency 1 (component1). </summary>
		/// <param name="component1"> the Currency 1 to set </param>
		public virtual Field32Q setCurrency1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Currency 1 (component1) from a Currency object. </summary>
		/// <seealso cref= #setComponent1(java.util.Currency) </seealso>
		/// <param name="component1"> Currency with the Currency 1 content to set </param>
		public virtual Field32Q setCurrency1(Currency component1)
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
		/// Gets the Currency 2 (component2). </summary>
		/// <returns> the Currency 2 from component2 </returns>
		public virtual string getCurrency2()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the Currency 2 (component2) as Currency </summary>
		/// <returns> the Currency 2 from component2 converted to Currency or null if cannot be converted </returns>
		public virtual Currency Currency2AsCurrency
		{
			get
			{
				return SwiftFormatUtils.getCurrency(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field32Q setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a Currency object. </summary>
		/// <param name="component2"> the Currency with the component2 content to set </param>
		public virtual Field32Q setComponent2(Currency component2)
		{
			setComponent(2, SwiftFormatUtils.getCurrency(component2));
			return this;
		}

		/// <summary>
		/// Set the Currency 2 (component2). </summary>
		/// <param name="component2"> the Currency 2 to set </param>
		public virtual Field32Q setCurrency2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Currency 2 (component2) from a Currency object. </summary>
		/// <seealso cref= #setComponent2(java.util.Currency) </seealso>
		/// <param name="component2"> Currency with the Currency 2 content to set </param>
		public virtual Field32Q setCurrency2(Currency component2)
		{
			setComponent2(component2);
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
		/// <returns> the static value of Field32Q.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field32Q.COMPONENTS_PATTERN </returns>
		public sealed override string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "<CUR>/<CUR>";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field32Q get(final SwiftTagListBlock block)
		public static Field32Q get(SwiftTagListBlock block)
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
			return new Field32Q(t);
		}

		/// <summary>
		/// Gets the first instance of Field32Q in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field32Q get(final SwiftMessage msg)
		public static Field32Q get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field32Q in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field32Q> getAll(final SwiftMessage msg)
		public static IList<Field32Q> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field32Q from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field32Q> getAll(final SwiftTagListBlock block)
		public static IList<Field32Q> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field32Q> result = new java.util.ArrayList<>(arr.length);
				IList<Field32Q> result = new List<Field32Q>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field32Q(f));
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
			return 2;
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
			if (component < 1 || component > 2)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 32Q");
			}
			if (component == 1)
			{
				//default format (as is)
				return getComponent(1);
			}
			if (component == 2)
			{
				//default format (as is)
				return getComponent(2);
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
				result.Add("Currency 1");
				result.Add("Currency 2");
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
				result[1] = "currency1";
				result[2] = "currency2";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field32Q object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field32Q fromJson(final String json)
		public static Field32Q fromJson(string json)
		{
			Field32Q field = new Field32Q();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("currency1") != null)
			{
				field.setComponent1(jsonObject.get("currency1").AsString);
			}
			if (jsonObject.get("currency2") != null)
			{
				field.setComponent2(jsonObject.get("currency2").AsString);
			}
			return field;
		}


	}

}