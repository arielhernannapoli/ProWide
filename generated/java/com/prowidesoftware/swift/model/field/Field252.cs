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
	/// <strong>SWIFT MT Field 252</strong>
	/// <para>
	/// Model and parser for field 252 of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>MIR</code></li> 
	/// 		<li><code>MIR</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>&lt;MIR&gt;&lt;MIR&gt;[&lt;HHMM&gt;&lt;HHMM&gt;]</code></li>
	/// 		<li>parser pattern: <code>&lt;MIR&gt;&lt;MIR&gt;[&lt;HHMM&gt;&lt;HHMM&gt;]</code></li>
	/// 		<li>components pattern: <code>RRHH</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field252 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable
	[Serializable]
	public class Field252 : Field
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 252
		/// </summary>
		public const string NAME = "252";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_252 = "252";
		public const string PARSER_PATTERN = "<MIR><MIR>[<HHMM><HHMM>]";
		public const string COMPONENTS_PATTERN = "RRHH";

		/// <summary>
		/// Component number for the Start MIR subfield
		/// </summary>
		public const int? START_MIR = 1;

		/// <summary>
		/// Component number for the End MIR subfield
		/// </summary>
		public const int? END_MIR = 2;

		/// <summary>
		/// Component number for the Start Time subfield
		/// </summary>
		public const int? START_TIME = 3;

		/// <summary>
		/// Component number for the End Time subfield
		/// </summary>
		public const int? END_TIME = 4;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field252() : base(4)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field252(final String value)
		public Field252(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field252(final com.prowidesoftware.swift.model.Tag tag)
		public Field252(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "252"))
			{
				throw new System.ArgumentException("cannot create field 252 from tag " + tag.Name + ", tagname must match the name of the field.");
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
				if (value.Length >= 28)
				{
					setComponent1(StringUtils.Substring(value, 0, 28));
				}
				if (value.Length >= 56)
				{
					setComponent2(StringUtils.Substring(value, 28, 56));
				}
				if (value.Length >= 60)
				{
					setComponent3(StringUtils.Substring(value, 56, 60));
				}
				if (value.Length > 60)
				{
					setComponent4(StringUtils.Substring(value, 60 - value));
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field252 newInstance(Field252 source)
		{
			Field252 cp = new Field252();
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
		/// Get the component1 as MIR </summary>
		/// <returns> the component1 converted to MIR or null if cannot be converted </returns>
		public virtual com.prowidesoftware.swift.model.MIR Component1AsMIR
		{
			get
			{
				return SwiftFormatUtils.getMIR(getComponent(1));
			}
		}

		/// <summary>
		/// Gets the Start MIR (component1). </summary>
		/// <returns> the Start MIR from component1 </returns>
		public virtual string getStartMIR()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the Start MIR (component1) as MIR </summary>
		/// <returns> the Start MIR from component1 converted to MIR or null if cannot be converted </returns>
		public virtual com.prowidesoftware.swift.model.MIR StartMIRAsMIR
		{
			get
			{
				return SwiftFormatUtils.getMIR(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field252 setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the component1 from a MIR object. </summary>
		/// <param name="component1"> the MIR with the component1 content to set </param>
		public virtual Field252 setComponent1(com.prowidesoftware.swift.model.MIR component1)
		{
			setComponent(1, SwiftFormatUtils.getMIR(component1));
			return this;
		}

		/// <summary>
		/// Set the Start MIR (component1). </summary>
		/// <param name="component1"> the Start MIR to set </param>
		public virtual Field252 setStartMIR(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Start MIR (component1) from a MIR object. </summary>
		/// <seealso cref= #setComponent1(com.prowidesoftware.swift.model.MIR) </seealso>
		/// <param name="component1"> MIR with the Start MIR content to set </param>
		public virtual Field252 setStartMIR(com.prowidesoftware.swift.model.MIR component1)
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
		/// Get the component2 as MIR </summary>
		/// <returns> the component2 converted to MIR or null if cannot be converted </returns>
		public virtual com.prowidesoftware.swift.model.MIR Component2AsMIR
		{
			get
			{
				return SwiftFormatUtils.getMIR(getComponent(2));
			}
		}

		/// <summary>
		/// Gets the End MIR (component2). </summary>
		/// <returns> the End MIR from component2 </returns>
		public virtual string getEndMIR()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the End MIR (component2) as MIR </summary>
		/// <returns> the End MIR from component2 converted to MIR or null if cannot be converted </returns>
		public virtual com.prowidesoftware.swift.model.MIR EndMIRAsMIR
		{
			get
			{
				return SwiftFormatUtils.getMIR(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field252 setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a MIR object. </summary>
		/// <param name="component2"> the MIR with the component2 content to set </param>
		public virtual Field252 setComponent2(com.prowidesoftware.swift.model.MIR component2)
		{
			setComponent(2, SwiftFormatUtils.getMIR(component2));
			return this;
		}

		/// <summary>
		/// Set the End MIR (component2). </summary>
		/// <param name="component2"> the End MIR to set </param>
		public virtual Field252 setEndMIR(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the End MIR (component2) from a MIR object. </summary>
		/// <seealso cref= #setComponent2(com.prowidesoftware.swift.model.MIR) </seealso>
		/// <param name="component2"> MIR with the End MIR content to set </param>
		public virtual Field252 setEndMIR(com.prowidesoftware.swift.model.MIR component2)
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
		/// Gets the Start Time (component3). </summary>
		/// <returns> the Start Time from component3 </returns>
		public virtual string getStartTime()
		{
			return getComponent(3);
		}

		/// <summary>
		/// Get the Start Time (component3) as Calendar </summary>
		/// <returns> the Start Time from component3 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime StartTimeAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(3));
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field252 setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the component3 from a Calendar object. </summary>
		/// <param name="component3"> the Calendar with the component3 content to set </param>
		public virtual Field252 setComponent3(DateTime component3)
		{
			setComponent(3, SwiftFormatUtils.getTime3(component3));
			return this;
		}

		/// <summary>
		/// Set the Start Time (component3). </summary>
		/// <param name="component3"> the Start Time to set </param>
		public virtual Field252 setStartTime(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Start Time (component3) from a Calendar object. </summary>
		/// <seealso cref= #setComponent3(java.util.Calendar) </seealso>
		/// <param name="component3"> Calendar with the Start Time content to set </param>
		public virtual Field252 setStartTime(DateTime component3)
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
		/// Get the component4 as Calendar </summary>
		/// <returns> the component4 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime Component4AsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(4));
			}
		}

		/// <summary>
		/// Gets the End Time (component4). </summary>
		/// <returns> the End Time from component4 </returns>
		public virtual string getEndTime()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the End Time (component4) as Calendar </summary>
		/// <returns> the End Time from component4 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime EndTimeAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(4));
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field252 setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the component4 from a Calendar object. </summary>
		/// <param name="component4"> the Calendar with the component4 content to set </param>
		public virtual Field252 setComponent4(DateTime component4)
		{
			setComponent(4, SwiftFormatUtils.getTime3(component4));
			return this;
		}

		/// <summary>
		/// Set the End Time (component4). </summary>
		/// <param name="component4"> the End Time to set </param>
		public virtual Field252 setEndTime(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the End Time (component4) from a Calendar object. </summary>
		/// <seealso cref= #setComponent4(java.util.Calendar) </seealso>
		/// <param name="component4"> Calendar with the End Time content to set </param>
		public virtual Field252 setEndTime(DateTime component4)
		{
			setComponent4(component4);
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
		/// <returns> the static value of Field252.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field252.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "<MIR><MIR>[<HHMM><HHMM>]";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field252 get(final SwiftTagListBlock block)
		public static Field252 get(SwiftTagListBlock block)
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
			return new Field252(t);
		}

		/// <summary>
		/// Gets the first instance of Field252 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field252 get(final SwiftMessage msg)
		public static Field252 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field252 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field252> getAll(final SwiftMessage msg)
		public static IList<Field252> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field252 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field252> getAll(final SwiftTagListBlock block)
		public static IList<Field252> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field252> result = new java.util.ArrayList<>(arr.length);
				IList<Field252> result = new List<Field252>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field252(f));
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
				throw new System.ArgumentException("invalid component number " + component + " for field 252");
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
				//time
				java.text.DateFormat f = new java.text.SimpleDateFormat("HH:mm", notNull(locale));
				DateTime cal = Component4AsCalendar;
				if (cal != null)
				{
					return f.format(cal.Ticks);
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
				result.Add("Start MIR");
				result.Add("End MIR");
				result.Add("Start Time");
				result.Add("End Time");
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
				result[1] = "startMIR";
				result[2] = "endMIR";
				result[3] = "startTime";
				result[4] = "endTime";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field252 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field252 fromJson(final String json)
		public static Field252 fromJson(string json)
		{
			Field252 field = new Field252();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("startMIR") != null)
			{
				field.setComponent1(jsonObject.get("startMIR").AsString);
			}
			if (jsonObject.get("endMIR") != null)
			{
				field.setComponent2(jsonObject.get("endMIR").AsString);
			}
			if (jsonObject.get("startTime") != null)
			{
				field.setComponent3(jsonObject.get("startTime").AsString);
			}
			if (jsonObject.get("endTime") != null)
			{
				field.setComponent4(jsonObject.get("endTime").AsString);
			}
			return field;
		}


	}

}