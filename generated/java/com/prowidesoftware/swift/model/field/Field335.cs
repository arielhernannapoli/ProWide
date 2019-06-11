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
	/// <strong>SWIFT MT Field 335</strong>
	/// <para>
	/// Model and parser for field 335 of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>MIR</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>LogicalTerminalAddress</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>&lt;HHMM&gt;&lt;MIR&gt;&lt;MT&gt;&lt;LT&gt;[&lt;HHMM&gt;]</code></li>
	/// 		<li>parser pattern: <code>&lt;HHMM&gt;&lt;MIR&gt;NS[N]</code></li>
	/// 		<li>components pattern: <code>HRMZH</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field335 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable
	[Serializable]
	public class Field335 : Field
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 335
		/// </summary>
		public const string NAME = "335";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_335 = "335";
		public const string PARSER_PATTERN = "<HHMM><MIR>NS[N]";
		public const string COMPONENTS_PATTERN = "HRMZH";

		/// <summary>
		/// Component number for the Time Message Entered subfield
		/// </summary>
		public const int? TIME_MESSAGE_ENTERED = 1;

		/// <summary>
		/// Component number for the MIR subfield
		/// </summary>
		public const int? MIR_Renamed = 2;

		/// <summary>
		/// Component number for the MT subfield
		/// </summary>
		public const int? MT_Renamed = 3;

		/// <summary>
		/// Component number for the Receiver subfield
		/// </summary>
		public const int? RECEIVER = 4;

		/// <summary>
		/// Component number for the Time Last Delivery Attempt subfield
		/// </summary>
		public const int? TIME_LAST_DELIVERY_ATTEMPT = 5;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field335() : base(5)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field335(final String value)
		public Field335(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field335(final com.prowidesoftware.swift.model.Tag tag)
		public Field335(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "335"))
			{
				throw new System.ArgumentException("cannot create field 335 from tag " + tag.Name + ", tagname must match the name of the field.");
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
				if (value.Length >= 4)
				{
					setComponent1(StringUtils.Substring(value, 0, 4));
				}
				if (value.Length >= 32)
				{
					setComponent2(StringUtils.Substring(value, 4, 32));
				}
				if (value.Length > 32)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String toparse = org.apache.commons.lang3.StringUtils.substring(value, 32 - value);
					string toparse = StringUtils.Substring(value, 32 - value);
					if (toparse != null)
					{
						Component3 = SwiftParseUtils.getNumericPrefix(toparse);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String toparse2 = com.prowidesoftware.swift.model.field.SwiftParseUtils.getAlphaSuffix(toparse);
						string toparse2 = SwiftParseUtils.getAlphaSuffix(toparse);
						if (toparse2 != null)
						{
							setComponent4(SwiftParseUtils.getAlphaPrefix(toparse2));
							setComponent5(SwiftParseUtils.getNumericSuffix(toparse2));
						}
					}
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field335 newInstance(Field335 source)
		{
			Field335 cp = new Field335();
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
		public virtual string getComponent1()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the component1 as Calendar </summary>
		/// <returns> the component1 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime Component1AsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(1));
			}
		}

		/// <summary>
		/// Gets the Time Message Entered (component1). </summary>
		/// <returns> the Time Message Entered from component1 </returns>
		public virtual string getTimeMessageEntered()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the Time Message Entered (component1) as Calendar </summary>
		/// <returns> the Time Message Entered from component1 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime TimeMessageEnteredAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field335 setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the component1 from a Calendar object. </summary>
		/// <param name="component1"> the Calendar with the component1 content to set </param>
		public virtual Field335 setComponent1(DateTime component1)
		{
			setComponent(1, SwiftFormatUtils.getTime3(component1));
			return this;
		}

		/// <summary>
		/// Set the Time Message Entered (component1). </summary>
		/// <param name="component1"> the Time Message Entered to set </param>
		public virtual Field335 setTimeMessageEntered(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Time Message Entered (component1) from a Calendar object. </summary>
		/// <seealso cref= #setComponent1(java.util.Calendar) </seealso>
		/// <param name="component1"> Calendar with the Time Message Entered content to set </param>
		public virtual Field335 setTimeMessageEntered(DateTime component1)
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
		/// Gets the MIR (component2). </summary>
		/// <returns> the MIR from component2 </returns>
		public virtual string getMIR()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the MIR (component2) as MIR </summary>
		/// <returns> the MIR from component2 converted to MIR or null if cannot be converted </returns>
		public virtual com.prowidesoftware.swift.model.MIR MIRAsMIR
		{
			get
			{
				return SwiftFormatUtils.getMIR(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field335 setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a MIR object. </summary>
		/// <param name="component2"> the MIR with the component2 content to set </param>
		public virtual Field335 setComponent2(com.prowidesoftware.swift.model.MIR component2)
		{
			setComponent(2, SwiftFormatUtils.getMIR(component2));
			return this;
		}

		/// <summary>
		/// Set the MIR (component2). </summary>
		/// <param name="component2"> the MIR to set </param>
		public virtual Field335 setMIR(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the MIR (component2) from a MIR object. </summary>
		/// <seealso cref= #setComponent2(com.prowidesoftware.swift.model.MIR) </seealso>
		/// <param name="component2"> MIR with the MIR content to set </param>
		public virtual Field335 setMIR(com.prowidesoftware.swift.model.MIR component2)
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
		/// Gets the MT (component3). </summary>
		/// <returns> the MT from component3 </returns>
		public virtual string MT
		{
			get
			{
				return getComponent(3);
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field335 setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the MT (component3). </summary>
		/// <param name="component3"> the MT to set </param>
		public virtual Field335 setMT(string component3)
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
		/// Get the component4 as LogicalTerminalAddress </summary>
		/// <returns> the component4 converted to LogicalTerminalAddress or null if cannot be converted </returns>
		public virtual com.prowidesoftware.swift.model.LogicalTerminalAddress Component4AsLogicalTerminalAddress
		{
			get
			{
				return SwiftFormatUtils.getLTAddress(getComponent(4));
			}
		}

		/// <summary>
		/// Gets the Receiver (component4). </summary>
		/// <returns> the Receiver from component4 </returns>
		public virtual string getReceiver()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the Receiver (component4) as LogicalTerminalAddress </summary>
		/// <returns> the Receiver from component4 converted to LogicalTerminalAddress or null if cannot be converted </returns>
		public virtual com.prowidesoftware.swift.model.LogicalTerminalAddress ReceiverAsLogicalTerminalAddress
		{
			get
			{
				return SwiftFormatUtils.getLTAddress(getComponent(4));
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field335 setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the component4 from a LogicalTerminalAddress object. </summary>
		/// <param name="component4"> the LogicalTerminalAddress with the component4 content to set </param>
		public virtual Field335 setComponent4(com.prowidesoftware.swift.model.LogicalTerminalAddress component4)
		{
			setComponent(4, SwiftFormatUtils.getLTAddress(component4));
			return this;
		}

		/// <summary>
		/// Set the Receiver (component4). </summary>
		/// <param name="component4"> the Receiver to set </param>
		public virtual Field335 setReceiver(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Receiver (component4) from a LogicalTerminalAddress object. </summary>
		/// <seealso cref= #setComponent4(com.prowidesoftware.swift.model.LogicalTerminalAddress) </seealso>
		/// <param name="component4"> LogicalTerminalAddress with the Receiver content to set </param>
		public virtual Field335 setReceiver(com.prowidesoftware.swift.model.LogicalTerminalAddress component4)
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
		/// Get the component5 as Calendar </summary>
		/// <returns> the component5 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime Component5AsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(5));
			}
		}

		/// <summary>
		/// Gets the Time Last Delivery Attempt (component5). </summary>
		/// <returns> the Time Last Delivery Attempt from component5 </returns>
		public virtual string getTimeLastDeliveryAttempt()
		{
			return getComponent(5);
		}

		/// <summary>
		/// Get the Time Last Delivery Attempt (component5) as Calendar </summary>
		/// <returns> the Time Last Delivery Attempt from component5 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime TimeLastDeliveryAttemptAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(5));
			}
		}

		/// <summary>
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field335 setComponent5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the component5 from a Calendar object. </summary>
		/// <param name="component5"> the Calendar with the component5 content to set </param>
		public virtual Field335 setComponent5(DateTime component5)
		{
			setComponent(5, SwiftFormatUtils.getTime3(component5));
			return this;
		}

		/// <summary>
		/// Set the Time Last Delivery Attempt (component5). </summary>
		/// <param name="component5"> the Time Last Delivery Attempt to set </param>
		public virtual Field335 setTimeLastDeliveryAttempt(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Time Last Delivery Attempt (component5) from a Calendar object. </summary>
		/// <seealso cref= #setComponent5(java.util.Calendar) </seealso>
		/// <param name="component5"> Calendar with the Time Last Delivery Attempt content to set </param>
		public virtual Field335 setTimeLastDeliveryAttempt(DateTime component5)
		{
			setComponent5(component5);
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
		/// <returns> the static value of Field335.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field335.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "<HHMM><MIR><MT><LT>[<HHMM>]";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field335 get(final SwiftTagListBlock block)
		public static Field335 get(SwiftTagListBlock block)
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
			return new Field335(t);
		}

		/// <summary>
		/// Gets the first instance of Field335 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field335 get(final SwiftMessage msg)
		public static Field335 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field335 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field335> getAll(final SwiftMessage msg)
		public static IList<Field335> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field335 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field335> getAll(final SwiftTagListBlock block)
		public static IList<Field335> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field335> result = new java.util.ArrayList<>(arr.length);
				IList<Field335> result = new List<Field335>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field335(f));
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
				throw new System.ArgumentException("invalid component number " + component + " for field 335");
			}
			if (component == 1)
			{
				//time
				java.text.DateFormat f = new java.text.SimpleDateFormat("HH:mm", notNull(locale));
				DateTime cal = Component1AsCalendar;
				if (cal != null)
				{
					return f.format(cal.Ticks);
				}
			}
			if (component == 2)
			{
				//default format (as is)
				return getComponent(2);
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
				//time
				java.text.DateFormat f = new java.text.SimpleDateFormat("HH:mm", notNull(locale));
				DateTime cal = Component5AsCalendar;
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
				result.Add("Time Message Entered");
				result.Add("MIR");
				result.Add("MT");
				result.Add("Receiver");
				result.Add("Time Last Delivery Attempt");
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
				result[1] = "timeMessageEntered";
				result[2] = "mIR";
				result[3] = "mT";
				result[4] = "receiver";
				result[5] = "timeLastDeliveryAttempt";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field335 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field335 fromJson(final String json)
		public static Field335 fromJson(string json)
		{
			Field335 field = new Field335();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("timeMessageEntered") != null)
			{
				field.setComponent1(jsonObject.get("timeMessageEntered").AsString);
			}
			if (jsonObject.get("mIR") != null)
			{
				field.setComponent2(jsonObject.get("mIR").AsString);
			}
			if (jsonObject.get("mT") != null)
			{
				field.Component3 = jsonObject.get("mT").AsString;
			}
			if (jsonObject.get("receiver") != null)
			{
				field.setComponent4(jsonObject.get("receiver").AsString);
			}
			if (jsonObject.get("timeLastDeliveryAttempt") != null)
			{
				field.setComponent5(jsonObject.get("timeLastDeliveryAttempt").AsString);
			}
			return field;
		}


	}

}