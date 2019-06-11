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
	/// <strong>SWIFT MT Field 260</strong>
	/// <para>
	/// Model and parser for field 260 of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>LogicalTerminalAddress</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Number</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>&lt;LT&gt;&lt;DATE2&gt;&lt;HHMM&gt;&lt;HHMM&gt;[4!n]</code></li>
	/// 		<li>parser pattern: <code>&lt;LT&gt;&lt;DATE2&gt;&lt;HHMM&gt;&lt;HHMM&gt;[N]</code></li>
	/// 		<li>components pattern: <code>ZEHHN</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field260 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.DateContainer
	[Serializable]
	public class Field260 : Field, DateContainer
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 260
		/// </summary>
		public const string NAME = "260";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_260 = "260";
		public const string PARSER_PATTERN = "<LT><DATE2><HHMM><HHMM>[N]";
		public const string COMPONENTS_PATTERN = "ZEHHN";

		/// <summary>
		/// Component number for the LT Address subfield
		/// </summary>
		public const int? LT_ADDRESS = 1;

		/// <summary>
		/// Component number for the Date subfield
		/// </summary>
		public const int? DATE = 2;

		/// <summary>
		/// Component number for the Start Time subfield
		/// </summary>
		public const int? START_TIME = 3;

		/// <summary>
		/// Component number for the End Time subfield
		/// </summary>
		public const int? END_TIME = 4;

		/// <summary>
		/// Component number for the Session Number subfield
		/// </summary>
		public const int? SESSION_NUMBER = 5;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field260() : base(5)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field260(final String value)
		public Field260(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field260(final com.prowidesoftware.swift.model.Tag tag)
		public Field260(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "260"))
			{
				throw new System.ArgumentException("cannot create field 260 from tag " + tag.Name + ", tagname must match the name of the field.");
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
			if (value != null)
			{
				if (value.Length >= 12)
				{
					setComponent1(StringUtils.Substring(value, 0, 12));
				}
				if (value.Length >= 18)
				{
					setComponent2(StringUtils.Substring(value, 12, 18));
				}
				if (value.Length >= 22)
				{
					setComponent3(StringUtils.Substring(value, 18, 22));
				}
				if (value.Length >= 26)
				{
					setComponent4(StringUtils.Substring(value, 22, 26));
				}
				if (value.Length > 26)
				{
					setComponent5(StringUtils.Substring(value, 26 - value));
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field260 newInstance(Field260 source)
		{
			Field260 cp = new Field260();
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
				append(result, 5);
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
		/// Get the component1 as LogicalTerminalAddress </summary>
		/// <returns> the component1 converted to LogicalTerminalAddress or null if cannot be converted </returns>
		public virtual com.prowidesoftware.swift.model.LogicalTerminalAddress Component1AsLogicalTerminalAddress
		{
			get
			{
				return SwiftFormatUtils.getLTAddress(getComponent(1));
			}
		}

		/// <summary>
		/// Gets the LT Address (component1). </summary>
		/// <returns> the LT Address from component1 </returns>
		public virtual string getLTAddress()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the LT Address (component1) as LogicalTerminalAddress </summary>
		/// <returns> the LT Address from component1 converted to LogicalTerminalAddress or null if cannot be converted </returns>
		public virtual com.prowidesoftware.swift.model.LogicalTerminalAddress LTAddressAsLogicalTerminalAddress
		{
			get
			{
				return SwiftFormatUtils.getLTAddress(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field260 setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the component1 from a LogicalTerminalAddress object. </summary>
		/// <param name="component1"> the LogicalTerminalAddress with the component1 content to set </param>
		public virtual Field260 setComponent1(com.prowidesoftware.swift.model.LogicalTerminalAddress component1)
		{
			setComponent(1, SwiftFormatUtils.getLTAddress(component1));
			return this;
		}

		/// <summary>
		/// Set the LT Address (component1). </summary>
		/// <param name="component1"> the LT Address to set </param>
		public virtual Field260 setLTAddress(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the LT Address (component1) from a LogicalTerminalAddress object. </summary>
		/// <seealso cref= #setComponent1(com.prowidesoftware.swift.model.LogicalTerminalAddress) </seealso>
		/// <param name="component1"> LogicalTerminalAddress with the LT Address content to set </param>
		public virtual Field260 setLTAddress(com.prowidesoftware.swift.model.LogicalTerminalAddress component1)
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
		/// Get the component2 as Calendar </summary>
		/// <returns> the component2 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime Component2AsCalendar
		{
			get
			{
				return SwiftFormatUtils.getDate2(getComponent(2));
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
				return SwiftFormatUtils.getDate2(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field260 setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a Calendar object. </summary>
		/// <param name="component2"> the Calendar with the component2 content to set </param>
		public virtual Field260 setComponent2(DateTime component2)
		{
			setComponent(2, SwiftFormatUtils.getDate2(component2));
			return this;
		}

		/// <summary>
		/// Set the Date (component2). </summary>
		/// <param name="component2"> the Date to set </param>
		public virtual Field260 setDate(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Date (component2) from a Calendar object. </summary>
		/// <seealso cref= #setComponent2(java.util.Calendar) </seealso>
		/// <param name="component2"> Calendar with the Date content to set </param>
		public virtual Field260 setDate(DateTime component2)
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
		public virtual Field260 setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the component3 from a Calendar object. </summary>
		/// <param name="component3"> the Calendar with the component3 content to set </param>
		public virtual Field260 setComponent3(DateTime component3)
		{
			setComponent(3, SwiftFormatUtils.getTime3(component3));
			return this;
		}

		/// <summary>
		/// Set the Start Time (component3). </summary>
		/// <param name="component3"> the Start Time to set </param>
		public virtual Field260 setStartTime(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Start Time (component3) from a Calendar object. </summary>
		/// <seealso cref= #setComponent3(java.util.Calendar) </seealso>
		/// <param name="component3"> Calendar with the Start Time content to set </param>
		public virtual Field260 setStartTime(DateTime component3)
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
		public virtual Field260 setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the component4 from a Calendar object. </summary>
		/// <param name="component4"> the Calendar with the component4 content to set </param>
		public virtual Field260 setComponent4(DateTime component4)
		{
			setComponent(4, SwiftFormatUtils.getTime3(component4));
			return this;
		}

		/// <summary>
		/// Set the End Time (component4). </summary>
		/// <param name="component4"> the End Time to set </param>
		public virtual Field260 setEndTime(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the End Time (component4) from a Calendar object. </summary>
		/// <seealso cref= #setComponent4(java.util.Calendar) </seealso>
		/// <param name="component4"> Calendar with the End Time content to set </param>
		public virtual Field260 setEndTime(DateTime component4)
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
		/// Gets the Session Number (component5). </summary>
		/// <returns> the Session Number from component5 </returns>
		public virtual string getSessionNumber()
		{
			return getComponent(5);
		}

		/// <summary>
		/// Get the Session Number (component5) as Number </summary>
		/// <returns> the Session Number from component5 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number SessionNumberAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(5));
			}
		}

		/// <summary>
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field260 setComponent5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the component5 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent5(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent5(String)
		/// </seealso>
		/// <param name="component5"> the Number with the component5 content to set </param>
		public virtual Field260 setComponent5(java.lang.Number component5)
		{
			if (component5 != null)
			{
				setComponent(5, Convert.ToString((int)component5));
			}
			return this;
		}

		/// <summary>
		/// Set the Session Number (component5). </summary>
		/// <param name="component5"> the Session Number to set </param>
		public virtual Field260 setSessionNumber(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Session Number (component5) from a Number object. </summary>
		/// <seealso cref= #setComponent5(java.lang.Number) </seealso>
		/// <param name="component5"> Number with the Session Number content to set </param>
		public virtual Field260 setSessionNumber(java.lang.Number component5)
		{
			setComponent5(component5);
			return this;
		}

		public virtual IList<DateTime> dates()
		{
			IList<DateTime> result = new List<DateTime>();
			result.Add(SwiftFormatUtils.getDate2(getComponent(2)));
			result.Add(SwiftFormatUtils.getTime3(getComponent(3)));
			result.Add(SwiftFormatUtils.getTime3(getComponent(4)));
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
		/// <returns> the static value of Field260.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field260.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "<LT><DATE2><HHMM><HHMM>[4!n]";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field260 get(final SwiftTagListBlock block)
		public static Field260 get(SwiftTagListBlock block)
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
			return new Field260(t);
		}

		/// <summary>
		/// Gets the first instance of Field260 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field260 get(final SwiftMessage msg)
		public static Field260 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field260 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field260> getAll(final SwiftMessage msg)
		public static IList<Field260> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field260 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field260> getAll(final SwiftTagListBlock block)
		public static IList<Field260> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field260> result = new java.util.ArrayList<>(arr.length);
				IList<Field260> result = new List<Field260>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field260(f));
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
				throw new System.ArgumentException("invalid component number " + component + " for field 260");
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
				result.Add("LT Address");
				result.Add("Date");
				result.Add("Start Time");
				result.Add("End Time");
				result.Add("Session Number");
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
				result[1] = "lTAddress";
				result[2] = "date";
				result[3] = "startTime";
				result[4] = "endTime";
				result[5] = "sessionNumber";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field260 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field260 fromJson(final String json)
		public static Field260 fromJson(string json)
		{
			Field260 field = new Field260();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("lTAddress") != null)
			{
				field.setComponent1(jsonObject.get("lTAddress").AsString);
			}
			if (jsonObject.get("date") != null)
			{
				field.setComponent2(jsonObject.get("date").AsString);
			}
			if (jsonObject.get("startTime") != null)
			{
				field.setComponent3(jsonObject.get("startTime").AsString);
			}
			if (jsonObject.get("endTime") != null)
			{
				field.setComponent4(jsonObject.get("endTime").AsString);
			}
			if (jsonObject.get("sessionNumber") != null)
			{
				field.setComponent5(jsonObject.get("sessionNumber").AsString);
			}
			return field;
		}


	}

}