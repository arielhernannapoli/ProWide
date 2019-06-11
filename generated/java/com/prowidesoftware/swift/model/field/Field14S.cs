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
	/// <strong>SWIFT MT Field 14S</strong>
	/// <para>
	/// Model and parser for field 14S of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>String</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>3!a2!n[/&lt;HHMM&gt;/4!c]</code></li>
	/// 		<li>parser pattern: <code>SN[/&lt;HHMM&gt;/S]</code></li>
	/// 		<li>components pattern: <code>SNHS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field14S extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable
	[Serializable]
	public class Field14S : Field
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 14S
		/// </summary>
		public const string NAME = "14S";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_14S = "14S";
		public const string PARSER_PATTERN = "SN[/<HHMM>/S]";
		public const string COMPONENTS_PATTERN = "SNHS";

		/// <summary>
		/// Component number for the Source subfield
		/// </summary>
		public const int? SOURCE = 1;

		/// <summary>
		/// Component number for the Number subfield
		/// </summary>
		public const int? NUMBER = 2;

		/// <summary>
		/// Component number for the Time subfield
		/// </summary>
		public const int? TIME = 3;

		/// <summary>
		/// Component number for the Location subfield
		/// </summary>
		public const int? LOCATION = 4;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field14S() : base(4)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field14S(final String value)
		public Field14S(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field14S(final com.prowidesoftware.swift.model.Tag tag)
		public Field14S(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "14S"))
			{
				throw new System.ArgumentException("cannot create field 14S from tag " + tag.Name + ", tagname must match the name of the field.");
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
			if (value != null)
			{
				string left;
				string right = null;
				if (value.IndexOf('/') >= 0)
				{
					left = SwiftParseUtils.getTokenFirst(value, "/");
					right = SwiftParseUtils.getTokenSecondLast(value, "/");
				}
				else
				{
					left = value;
				}
				Component1 = SwiftParseUtils.getAlphaPrefix(left);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String second = getComponent1() == null ? left : org.apache.commons.lang3.StringUtils.substringAfter(left, getComponent1());
				string second = Component1 == null ? left : StringUtils.substringAfter(left, Component1);
				setComponent2(second);
				if (right != null)
				{
					setComponent3(SwiftParseUtils.getTokenFirst(right, "/"));
					Component4 = SwiftParseUtils.getTokenSecondLast(right, "/");
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field14S newInstance(Field14S source)
		{
			Field14S cp = new Field14S();
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
				if (getComponent3() != null || Component4 != null)
				{
					result.Append("/");
					append(result, 3);
					result.Append("/");
					append(result, 4);
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
		/// Gets the Source (component1). </summary>
		/// <returns> the Source from component1 </returns>
		public virtual string Source
		{
			get
			{
				return getComponent(1);
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field14S setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Source (component1). </summary>
		/// <param name="component1"> the Source to set </param>
		public virtual Field14S setSource(string component1)
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
		/// Gets the Number (component2). </summary>
		/// <returns> the Number from component2 </returns>
		public virtual string getNumber()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the Number (component2) as Number </summary>
		/// <returns> the Number from component2 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number NumberAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field14S setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent2(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent2(String)
		/// </seealso>
		/// <param name="component2"> the Number with the component2 content to set </param>
		public virtual Field14S setComponent2(java.lang.Number component2)
		{
			if (component2 != null)
			{
				setComponent(2, Convert.ToString((int)component2));
			}
			return this;
		}

		/// <summary>
		/// Set the Number (component2). </summary>
		/// <param name="component2"> the Number to set </param>
		public virtual Field14S setNumber(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Number (component2) from a Number object. </summary>
		/// <seealso cref= #setComponent2(java.lang.Number) </seealso>
		/// <param name="component2"> Number with the Number content to set </param>
		public virtual Field14S setNumber(java.lang.Number component2)
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
		/// Get the component3 as Calendar </summary>
		/// <returns> the component3 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime Component3AsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(3));
			}
		}

		/// <summary>
		/// Gets the Time (component3). </summary>
		/// <returns> the Time from component3 </returns>
		public virtual string getTime()
		{
			return getComponent(3);
		}

		/// <summary>
		/// Get the Time (component3) as Calendar </summary>
		/// <returns> the Time from component3 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime TimeAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(3));
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field14S setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the component3 from a Calendar object. </summary>
		/// <param name="component3"> the Calendar with the component3 content to set </param>
		public virtual Field14S setComponent3(DateTime component3)
		{
			setComponent(3, SwiftFormatUtils.getTime3(component3));
			return this;
		}

		/// <summary>
		/// Set the Time (component3). </summary>
		/// <param name="component3"> the Time to set </param>
		public virtual Field14S setTime(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Time (component3) from a Calendar object. </summary>
		/// <seealso cref= #setComponent3(java.util.Calendar) </seealso>
		/// <param name="component3"> Calendar with the Time content to set </param>
		public virtual Field14S setTime(DateTime component3)
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
		/// Gets the Location (component4). </summary>
		/// <returns> the Location from component4 </returns>
		public virtual string Location
		{
			get
			{
				return getComponent(4);
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field14S setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Location (component4). </summary>
		/// <param name="component4"> the Location to set </param>
		public virtual Field14S setLocation(string component4)
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
		   if (component == 3)
		   {
			   return true;
		   }
		   if (component == 4)
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
		/// <returns> the static value of Field14S.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field14S.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "3!a2!n[/<HHMM>/4!c]";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field14S get(final SwiftTagListBlock block)
		public static Field14S get(SwiftTagListBlock block)
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
			return new Field14S(t);
		}

		/// <summary>
		/// Gets the first instance of Field14S in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field14S get(final SwiftMessage msg)
		public static Field14S get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field14S in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field14S> getAll(final SwiftMessage msg)
		public static IList<Field14S> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field14S from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field14S> getAll(final SwiftTagListBlock block)
		public static IList<Field14S> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field14S> result = new java.util.ArrayList<>(arr.length);
				IList<Field14S> result = new List<Field14S>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field14S(f));
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
				throw new System.ArgumentException("invalid component number " + component + " for field 14S");
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
				//time
				java.text.DateFormat f = new java.text.SimpleDateFormat("HH:mm", notNull(locale));
				DateTime cal = Component3AsCalendar;
				if (cal != null)
				{
					return f.format(cal.Ticks);
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
				result.Add("Source");
				result.Add("Number");
				result.Add("Time");
				result.Add("Location");
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
				result[1] = "source";
				result[2] = "number";
				result[3] = "time";
				result[4] = "location";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field14S object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field14S fromJson(final String json)
		public static Field14S fromJson(string json)
		{
			Field14S field = new Field14S();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("source") != null)
			{
				field.Component1 = jsonObject.get("source").AsString;
			}
			if (jsonObject.get("number") != null)
			{
				field.setComponent2(jsonObject.get("number").AsString);
			}
			if (jsonObject.get("time") != null)
			{
				field.setComponent3(jsonObject.get("time").AsString);
			}
			if (jsonObject.get("location") != null)
			{
				field.Component4 = jsonObject.get("location").AsString;
			}
			return field;
		}


	}

}