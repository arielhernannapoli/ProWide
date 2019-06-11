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
	/// <strong>SWIFT MT Field 38G</strong>
	/// <para>
	/// Model and parser for field 38G of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>2n1a/2n1a</code></li>
	/// 		<li>parser pattern: <code>NS/NS</code></li>
	/// 		<li>components pattern: <code>NSNS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field38G extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable
	[Serializable]
	public class Field38G : Field
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 38G
		/// </summary>
		public const string NAME = "38G";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_38G = "38G";
		public const string PARSER_PATTERN = "NS/NS";
		public const string COMPONENTS_PATTERN = "NSNS";

		/// <summary>
		/// Component number for the Number From subfield
		/// </summary>
		public const int? NUMBER_FROM = 1;

		/// <summary>
		/// Component number for the Period From subfield
		/// </summary>
		public const int? PERIOD_FROM = 2;

		/// <summary>
		/// Component number for the Number To subfield
		/// </summary>
		public const int? NUMBER_TO = 3;

		/// <summary>
		/// Component number for the Period To subfield
		/// </summary>
		public const int? PERIOD_TO = 4;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field38G() : base(4)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field38G(final String value)
		public Field38G(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field38G(final com.prowidesoftware.swift.model.Tag tag)
		public Field38G(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "38G"))
			{
				throw new System.ArgumentException("cannot create field 38G from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(4);
			setComponent1(SwiftParseUtils.getNumericPrefix(StringUtils.substringBefore(value, "/")));
			Component2 = SwiftParseUtils.getAlphaSuffix(StringUtils.substringBefore(value, "/"));
			string toparse = SwiftParseUtils.getTokenSecond(value, "/");
			setComponent3(SwiftParseUtils.getNumericPrefix(toparse));
			Component4 = SwiftParseUtils.getAlphaSuffix(toparse);
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field38G newInstance(Field38G source)
		{
			Field38G cp = new Field38G();
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
				result.Append("/");
				append(result, 3);
				append(result, 4);
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
		/// Gets the Number From (component1). </summary>
		/// <returns> the Number From from component1 </returns>
		public virtual string getNumberFrom()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the Number From (component1) as Number </summary>
		/// <returns> the Number From from component1 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number NumberFromAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field38G setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the component1 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent1(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent1(String)
		/// </seealso>
		/// <param name="component1"> the Number with the component1 content to set </param>
		public virtual Field38G setComponent1(java.lang.Number component1)
		{
			if (component1 != null)
			{
				setComponent(1, Convert.ToString((int)component1));
			}
			return this;
		}

		/// <summary>
		/// Set the Number From (component1). </summary>
		/// <param name="component1"> the Number From to set </param>
		public virtual Field38G setNumberFrom(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Number From (component1) from a Number object. </summary>
		/// <seealso cref= #setComponent1(java.lang.Number) </seealso>
		/// <param name="component1"> Number with the Number From content to set </param>
		public virtual Field38G setNumberFrom(java.lang.Number component1)
		{
			setComponent1(component1);
			return this;
		}
		/// <summary>
		/// Gets the component2 </summary>
		/// <returns> the component2 </returns>
		public virtual string Component2
		{
			get
			{
				return getComponent(2);
			}
		}

		/// <summary>
		/// Same as getComponent(2) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent2AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component2AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent2AsString()", "Use use #getComponent(int) instead.");
				return getComponent(2);
			}
		}

		/// <summary>
		/// Gets the Period From (component2). </summary>
		/// <returns> the Period From from component2 </returns>
		public virtual string PeriodFrom
		{
			get
			{
				return getComponent(2);
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field38G setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Period From (component2). </summary>
		/// <param name="component2"> the Period From to set </param>
		public virtual Field38G setPeriodFrom(string component2)
		{
			setComponent(2, component2);
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
		/// Gets the Number To (component3). </summary>
		/// <returns> the Number To from component3 </returns>
		public virtual string getNumberTo()
		{
			return getComponent(3);
		}

		/// <summary>
		/// Get the Number To (component3) as Number </summary>
		/// <returns> the Number To from component3 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number NumberToAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(3));
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field38G setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the component3 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent3(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent3(String)
		/// </seealso>
		/// <param name="component3"> the Number with the component3 content to set </param>
		public virtual Field38G setComponent3(java.lang.Number component3)
		{
			if (component3 != null)
			{
				setComponent(3, Convert.ToString((int)component3));
			}
			return this;
		}

		/// <summary>
		/// Set the Number To (component3). </summary>
		/// <param name="component3"> the Number To to set </param>
		public virtual Field38G setNumberTo(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Number To (component3) from a Number object. </summary>
		/// <seealso cref= #setComponent3(java.lang.Number) </seealso>
		/// <param name="component3"> Number with the Number To content to set </param>
		public virtual Field38G setNumberTo(java.lang.Number component3)
		{
			setComponent3(component3);
			return this;
		}
		/// <summary>
		/// Gets the component4 </summary>
		/// <returns> the component4 </returns>
		public virtual string Component4
		{
			get
			{
				return getComponent(4);
			}
		}

		/// <summary>
		/// Same as getComponent(4) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent4AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component4AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent4AsString()", "Use use #getComponent(int) instead.");
				return getComponent(4);
			}
		}

		/// <summary>
		/// Gets the Period To (component4). </summary>
		/// <returns> the Period To from component4 </returns>
		public virtual string PeriodTo
		{
			get
			{
				return getComponent(4);
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field38G setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Period To (component4). </summary>
		/// <param name="component4"> the Period To to set </param>
		public virtual Field38G setPeriodTo(string component4)
		{
			setComponent(4, component4);
			return this;
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
		/// <returns> the static value of Field38G.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field38G.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "2n1a/2n1a";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field38G get(final SwiftTagListBlock block)
		public static Field38G get(SwiftTagListBlock block)
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
			return new Field38G(t);
		}

		/// <summary>
		/// Gets the first instance of Field38G in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field38G get(final SwiftMessage msg)
		public static Field38G get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field38G in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field38G> getAll(final SwiftMessage msg)
		public static IList<Field38G> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field38G from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field38G> getAll(final SwiftTagListBlock block)
		public static IList<Field38G> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field38G> result = new java.util.ArrayList<>(arr.length);
				IList<Field38G> result = new List<Field38G>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field38G(f));
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
			return 4;
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
			if (component < 1 || component > 4)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 38G");
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
				//default format (as is)
				return getComponent(4);
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
				result.Add("Number From");
				result.Add("Period From");
				result.Add("Number To");
				result.Add("Period To");
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
				result[1] = "numberFrom";
				result[2] = "periodFrom";
				result[3] = "numberTo";
				result[4] = "periodTo";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field38G object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field38G fromJson(final String json)
		public static Field38G fromJson(string json)
		{
			Field38G field = new Field38G();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("numberFrom") != null)
			{
				field.setComponent1(jsonObject.get("numberFrom").AsString);
			}
			if (jsonObject.get("periodFrom") != null)
			{
				field.Component2 = jsonObject.get("periodFrom").AsString;
			}
			if (jsonObject.get("numberTo") != null)
			{
				field.setComponent3(jsonObject.get("numberTo").AsString);
			}
			if (jsonObject.get("periodTo") != null)
			{
				field.Component4 = jsonObject.get("periodTo").AsString;
			}
			return field;
		}


	}

}