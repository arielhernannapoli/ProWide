﻿using System;
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
	/// <strong>SWIFT MT Field 77H</strong>
	/// <para>
	/// Model and parser for field 77H of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>6a[/&lt;DATE4&gt;][//&lt;YEAR&gt;]</code></li>
	/// 		<li>parser pattern: <code>S[/S][//S]</code></li>
	/// 		<li>components pattern: <code>SDY</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field77H extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.DateContainer, com.prowidesoftware.swift.model.field.MultiLineField
	[Serializable]
	public class Field77H : Field, DateContainer, com.prowidesoftware.swift.model.field.MultiLineField
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 77H
		/// </summary>
		public const string NAME = "77H";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_77H = "77H";
		public const string PARSER_PATTERN = "S[/S][//S]";
		public const string COMPONENTS_PATTERN = "SDY";

		/// <summary>
		/// Component number for the Type Of Agreement subfield
		/// </summary>
		public const int? TYPE_OF_AGREEMENT = 1;

		/// <summary>
		/// Component number for the Date subfield
		/// </summary>
		public const int? DATE = 2;

		/// <summary>
		/// Component number for the Version subfield
		/// </summary>
		public const int? VERSION = 3;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field77H() : base(3)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field77H(final String value)
		public Field77H(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field77H(final com.prowidesoftware.swift.model.Tag tag)
		public Field77H(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "77H"))
			{
				throw new System.ArgumentException("cannot create field 77H from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(3);
			Component1 = SwiftParseUtils.getTokenFirst(value, null, "/");
			string toparse = SwiftParseUtils.getTokenSecondLast(value, "/");
			setComponent2(SwiftParseUtils.getTokenFirst(toparse, "//"));
			setComponent3(SwiftParseUtils.getTokenSecondLast(toparse, "//"));
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field77H newInstance(Field77H source)
		{
			Field77H cp = new Field77H();
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
				if (getComponent2() != null)
				{
					result.Append("/").Append(getComponent2());
				}
				if (getComponent3() != null)
				{
					result.Append("//").Append(getComponent3());
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
		/// Gets the Type Of Agreement (component1). </summary>
		/// <returns> the Type Of Agreement from component1 </returns>
		public virtual string TypeOfAgreement
		{
			get
			{
				return getComponent(1);
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field77H setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Type Of Agreement (component1). </summary>
		/// <param name="component1"> the Type Of Agreement to set </param>
		public virtual Field77H setTypeOfAgreement(string component1)
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
		/// Get the component2 as Calendar </summary>
		/// <returns> the component2 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime Component2AsCalendar
		{
			get
			{
				return SwiftFormatUtils.getDate4(getComponent(2));
			}
		}

		/// <summary>
		/// Gets the Date (component2). </summary>
		/// <returns> the Date from component2 </returns>
		public virtual string getDate()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the Date (component2) as Calendar </summary>
		/// <returns> the Date from component2 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime DateAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getDate4(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field77H setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a Calendar object. </summary>
		/// <param name="component2"> the Calendar with the component2 content to set </param>
		public virtual Field77H setComponent2(DateTime component2)
		{
			setComponent(2, SwiftFormatUtils.getDate4(component2));
			return this;
		}

		/// <summary>
		/// Set the Date (component2). </summary>
		/// <param name="component2"> the Date to set </param>
		public virtual Field77H setDate(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Date (component2) from a Calendar object. </summary>
		/// <seealso cref= #setComponent2(java.util.Calendar) </seealso>
		/// <param name="component2"> Calendar with the Date content to set </param>
		public virtual Field77H setDate(DateTime component2)
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
				return SwiftFormatUtils.getYear(getComponent(3));
			}
		}

		/// <summary>
		/// Gets the Version (component3). </summary>
		/// <returns> the Version from component3 </returns>
		public virtual string getVersion()
		{
			return getComponent(3);
		}

		/// <summary>
		/// Get the Version (component3) as Calendar </summary>
		/// <returns> the Version from component3 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime VersionAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getYear(getComponent(3));
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field77H setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the component3 from a Calendar object. </summary>
		/// <param name="component3"> the Calendar with the component3 content to set </param>
		public virtual Field77H setComponent3(DateTime component3)
		{
			setComponent(3, SwiftFormatUtils.getYear(component3));
			return this;
		}

		/// <summary>
		/// Set the Version (component3). </summary>
		/// <param name="component3"> the Version to set </param>
		public virtual Field77H setVersion(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Version (component3) from a Calendar object. </summary>
		/// <seealso cref= #setComponent3(java.util.Calendar) </seealso>
		/// <param name="component3"> Calendar with the Version content to set </param>
		public virtual Field77H setVersion(DateTime component3)
		{
			setComponent3(component3);
			return this;
		}

		public virtual IList<DateTime> dates()
		{
			IList<DateTime> result = new List<DateTime>();
			result.Add(SwiftFormatUtils.getDate4(getComponent(2)));
			result.Add(SwiftFormatUtils.getYear(getComponent(3)));
			return result;
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
		   if (component == 2)
		   {
			   return true;
		   }
		   if (component == 3)
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
		/// <returns> the static value of Field77H.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field77H.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "6a[/<DATE4>][//<YEAR>]";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field77H get(final SwiftTagListBlock block)
		public static Field77H get(SwiftTagListBlock block)
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
			return new Field77H(t);
		}

		/// <summary>
		/// Gets the first instance of Field77H in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field77H get(final SwiftMessage msg)
		public static Field77H get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field77H in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field77H> getAll(final SwiftMessage msg)
		public static IList<Field77H> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field77H from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field77H> getAll(final SwiftTagListBlock block)
		public static IList<Field77H> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field77H> result = new java.util.ArrayList<>(arr.length);
				IList<Field77H> result = new List<Field77H>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field77H(f));
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
			return 3;
		}

		/// <summary>
		/// Returns a specific line from the field's value.<br>
		/// </summary>
		/// <seealso cref= MultiLineField#getLine(int) </seealso>
		/// <param name="line"> a reference to a specific line in the field, first line being 1 </param>
		/// <returns> line content or null if not present or if line number is above the expected
		/// @since 7.7 </returns>
		public virtual string getLine(int line)
		{
			return getLine(line, 0);
		}

		/// <summary>
		/// Returns a specific line from the field's value.<br>
		/// </summary>
		/// <seealso cref= MultiLineField#getLine(int, int) </seealso>
		/// <param name="line"> a reference to a specific line in the field, first line being 1 </param>
		/// <param name="offset"> an optional component number used as offset when counting lines </param>
		/// <returns> line content or null if not present or if line number is above the expected
		/// @since 7.7 </returns>
		public virtual string getLine(int line, int offset)
		{
			Field77H cp = newInstance(this);
			return getLine(cp, line, null, offset);
		}

		/// <summary>
		/// Returns the field value split into lines.<br>
		/// </summary>
		/// <seealso cref= MultiLineField#getLines() </seealso>
		/// <returns> lines content or empty list if field's value is empty
		/// @since 7.7 </returns>
		public virtual IList<string> Lines
		{
			get
			{
				return SwiftParseUtils.getLines(Value);
			}
		}

		/// <summary>
		/// Returns the field value starting at the offset component, split into lines.<br>
		/// </summary>
		/// <seealso cref= MultiLineField#getLines(int) </seealso>
		/// <param name="offset"> an optional component number used as offset when counting lines </param>
		/// <returns> found lines or empty list if lines are not present or the offset is invalid
		/// @since 7.7 </returns>
		public virtual IList<string> getLines(int offset)
		{
			Field77H cp = newInstance(this);
			return SwiftParseUtils.getLines(getLine(cp, null, null, offset));
		}

		/// <summary>
		/// Returns a specific subset of lines from the field's value, given a range.<br>
		/// </summary>
		/// <seealso cref= MultiLineField#getLinesBetween(int, int ) </seealso>
		/// <param name="start"> a reference to a specific line in the field, first line being 1 </param>
		/// <param name="end"> a reference to a specific line in the field, must be greater than start </param>
		/// <returns> found lines or empty list if value is empty
		/// @since 7.7 </returns>
		public virtual IList<string> getLinesBetween(int start, int end)
		{
			return getLinesBetween(start, end, 0);
		}

		/// <summary>
		/// Returns a specific subset of lines from the field's value, starting at the offset component.<br>
		/// </summary>
		/// <seealso cref= MultiLineField#getLinesBetween(int start, int end, int offset) </seealso>
		/// <param name="start"> a reference to a specific line in the field, first line being 1 </param>
		/// <param name="end"> a reference to a specific line in the field, must be greater than start </param>
		/// <param name="offset"> an optional component number used as offset when counting lines </param>
		/// <returns> found lines or empty list if lines are not present or the offset is invalid
		/// @since 7.7 </returns>
		public virtual IList<string> getLinesBetween(int start, int end, int offset)
		{
			Field77H cp = newInstance(this);
			return SwiftParseUtils.getLines(getLine(cp, start, end, offset));
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
			if (component < 1 || component > 3)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 77H");
			}
			if (component == 1)
			{
				//default format (as is)
				return getComponent(1);
			}
			if (component == 2)
			{
				//date
				java.text.DateFormat f = java.text.DateFormat.getDateInstance(java.text.DateFormat.DEFAULT, notNull(locale));
				DateTime cal = Component2AsCalendar;
				if (cal != null)
				{
					return f.format(cal.Ticks);
				}
			}
			if (component == 3)
			{
				//default format (as is)
				return getComponent(3);
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
				result.Add("Type Of Agreement");
				result.Add("Date");
				result.Add("Version");
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
				result[1] = "typeOfAgreement";
				result[2] = "date";
				result[3] = "version";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field77H object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field77H fromJson(final String json)
		public static Field77H fromJson(string json)
		{
			Field77H field = new Field77H();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("typeOfAgreement") != null)
			{
				field.Component1 = jsonObject.get("typeOfAgreement").AsString;
			}
			if (jsonObject.get("date") != null)
			{
				field.setComponent2(jsonObject.get("date").AsString);
			}
			if (jsonObject.get("version") != null)
			{
				field.setComponent3(jsonObject.get("version").AsString);
			}
			return field;
		}


	}

}