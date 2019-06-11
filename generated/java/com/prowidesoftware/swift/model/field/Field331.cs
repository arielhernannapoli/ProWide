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
	/// <strong>SWIFT MT Field 331</strong>
	/// <para>
	/// Model and parser for field 331 of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>4!n&lt;DATE2&gt;&lt;HHMM&gt;&lt;DATE2&gt;&lt;HHMM&gt;3!n6!n6!n6!n6!n6!n6!n</code></li>
	/// 		<li>parser pattern: <code>4!N&lt;DATE2&gt;&lt;HHMM&gt;&lt;DATE2&gt;&lt;HHMM&gt;3!N6!N6!N6!N6!N6!N6!N</code></li>
	/// 		<li>components pattern: <code>NEHEHNNNNNNN</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field331 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.DateContainer
	[Serializable]
	public class Field331 : Field, DateContainer
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 331
		/// </summary>
		public const string NAME = "331";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_331 = "331";
		public const string PARSER_PATTERN = "4!N<DATE2><HHMM><DATE2><HHMM>3!N6!N6!N6!N6!N6!N6!N";
		public const string COMPONENTS_PATTERN = "NEHEHNNNNNNN";

		/// <summary>
		/// Component number for the Session Number subfield
		/// </summary>
		public const int? SESSION_NUMBER = 1;

		/// <summary>
		/// Component number for the Date Session Opened subfield
		/// </summary>
		public const int? DATE_SESSION_OPENED = 2;

		/// <summary>
		/// Component number for the Time Session Opened subfield
		/// </summary>
		public const int? TIME_SESSION_OPENED = 3;

		/// <summary>
		/// Component number for the Date Session Closed subfield
		/// </summary>
		public const int? DATE_SESSION_CLOSED = 4;

		/// <summary>
		/// Component number for the Time Session Closed subfield
		/// </summary>
		public const int? TIME_SESSION_CLOSED = 5;

		/// <summary>
		/// Component number for the Reason For Closure subfield
		/// </summary>
		public const int? REASON_FOR_CLOSURE = 6;

		/// <summary>
		/// Component number for the Quantity Of Messages Sent subfield
		/// </summary>
		public const int? QUANTITY_OF_MESSAGES_SENT = 7;

		/// <summary>
		/// Component number for the Quantity Of Messages Received subfield
		/// </summary>
		public const int? QUANTITY_OF_MESSAGES_RECEIVED = 8;

		/// <summary>
		/// Component number for the First Input Sequence Number subfield
		/// </summary>
		public const int? FIRST_INPUT_SEQUENCE_NUMBER = 9;

		/// <summary>
		/// Component number for the Last Input Sequence Number subfield
		/// </summary>
		public const int? LAST_INPUT_SEQUENCE_NUMBER = 10;

		/// <summary>
		/// Component number for the First Output Sequence Number subfield
		/// </summary>
		public const int? FIRST_OUTPUT_SEQUENCE_NUMBER = 11;

		/// <summary>
		/// Component number for the Last Output Sequence Number subfield
		/// </summary>
		public const int? LAST_OUTPUT_SEQUENCE_NUMBER = 12;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field331() : base(12)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field331(final String value)
		public Field331(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field331(final com.prowidesoftware.swift.model.Tag tag)
		public Field331(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "331"))
			{
				throw new System.ArgumentException("cannot create field 331 from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(12);
			if (value != null)
			{
				if (value.Length >= 4)
				{
					setComponent1(StringUtils.Substring(value, 0, 4));
				}
				if (value.Length >= 10)
				{
					setComponent2(StringUtils.Substring(value, 4, 10));
				}
				if (value.Length >= 14)
				{
					setComponent3(StringUtils.Substring(value, 10, 14));
				}
				if (value.Length >= 20)
				{
					setComponent4(StringUtils.Substring(value, 14, 20));
				}
				if (value.Length >= 24)
				{
					setComponent5(StringUtils.Substring(value, 20, 24));
				}
				if (value.Length >= 27)
				{
					setComponent6(StringUtils.Substring(value, 24, 27));
				}
				string toparse = StringUtils.Substring(value, 27 - value);
				SwiftParseUtils.setComponentsFromTokens(this, 7, 12, 6, toparse);
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field331 newInstance(Field331 source)
		{
			Field331 cp = new Field331();
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
		/// Gets the Session Number (component1). </summary>
		/// <returns> the Session Number from component1 </returns>
		public virtual string getSessionNumber()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the Session Number (component1) as Number </summary>
		/// <returns> the Session Number from component1 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number SessionNumberAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field331 setComponent1(string component1)
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
		public virtual Field331 setComponent1(java.lang.Number component1)
		{
			if (component1 != null)
			{
				setComponent(1, Convert.ToString((int)component1));
			}
			return this;
		}

		/// <summary>
		/// Set the Session Number (component1). </summary>
		/// <param name="component1"> the Session Number to set </param>
		public virtual Field331 setSessionNumber(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Session Number (component1) from a Number object. </summary>
		/// <seealso cref= #setComponent1(java.lang.Number) </seealso>
		/// <param name="component1"> Number with the Session Number content to set </param>
		public virtual Field331 setSessionNumber(java.lang.Number component1)
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
		/// Gets the Date Session Opened (component2). </summary>
		/// <returns> the Date Session Opened from component2 </returns>
		public virtual string getDateSessionOpened()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the Date Session Opened (component2) as Calendar </summary>
		/// <returns> the Date Session Opened from component2 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime DateSessionOpenedAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getDate2(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field331 setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a Calendar object. </summary>
		/// <param name="component2"> the Calendar with the component2 content to set </param>
		public virtual Field331 setComponent2(DateTime component2)
		{
			setComponent(2, SwiftFormatUtils.getDate2(component2));
			return this;
		}

		/// <summary>
		/// Set the Date Session Opened (component2). </summary>
		/// <param name="component2"> the Date Session Opened to set </param>
		public virtual Field331 setDateSessionOpened(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Date Session Opened (component2) from a Calendar object. </summary>
		/// <seealso cref= #setComponent2(java.util.Calendar) </seealso>
		/// <param name="component2"> Calendar with the Date Session Opened content to set </param>
		public virtual Field331 setDateSessionOpened(DateTime component2)
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
		/// Gets the Time Session Opened (component3). </summary>
		/// <returns> the Time Session Opened from component3 </returns>
		public virtual string getTimeSessionOpened()
		{
			return getComponent(3);
		}

		/// <summary>
		/// Get the Time Session Opened (component3) as Calendar </summary>
		/// <returns> the Time Session Opened from component3 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime TimeSessionOpenedAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(3));
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field331 setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the component3 from a Calendar object. </summary>
		/// <param name="component3"> the Calendar with the component3 content to set </param>
		public virtual Field331 setComponent3(DateTime component3)
		{
			setComponent(3, SwiftFormatUtils.getTime3(component3));
			return this;
		}

		/// <summary>
		/// Set the Time Session Opened (component3). </summary>
		/// <param name="component3"> the Time Session Opened to set </param>
		public virtual Field331 setTimeSessionOpened(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Time Session Opened (component3) from a Calendar object. </summary>
		/// <seealso cref= #setComponent3(java.util.Calendar) </seealso>
		/// <param name="component3"> Calendar with the Time Session Opened content to set </param>
		public virtual Field331 setTimeSessionOpened(DateTime component3)
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
				return SwiftFormatUtils.getDate2(getComponent(4));
			}
		}

		/// <summary>
		/// Gets the Date Session Closed (component4). </summary>
		/// <returns> the Date Session Closed from component4 </returns>
		public virtual string getDateSessionClosed()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the Date Session Closed (component4) as Calendar </summary>
		/// <returns> the Date Session Closed from component4 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime DateSessionClosedAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getDate2(getComponent(4));
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field331 setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the component4 from a Calendar object. </summary>
		/// <param name="component4"> the Calendar with the component4 content to set </param>
		public virtual Field331 setComponent4(DateTime component4)
		{
			setComponent(4, SwiftFormatUtils.getDate2(component4));
			return this;
		}

		/// <summary>
		/// Set the Date Session Closed (component4). </summary>
		/// <param name="component4"> the Date Session Closed to set </param>
		public virtual Field331 setDateSessionClosed(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Date Session Closed (component4) from a Calendar object. </summary>
		/// <seealso cref= #setComponent4(java.util.Calendar) </seealso>
		/// <param name="component4"> Calendar with the Date Session Closed content to set </param>
		public virtual Field331 setDateSessionClosed(DateTime component4)
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
		/// Gets the Time Session Closed (component5). </summary>
		/// <returns> the Time Session Closed from component5 </returns>
		public virtual string getTimeSessionClosed()
		{
			return getComponent(5);
		}

		/// <summary>
		/// Get the Time Session Closed (component5) as Calendar </summary>
		/// <returns> the Time Session Closed from component5 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime TimeSessionClosedAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(5));
			}
		}

		/// <summary>
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field331 setComponent5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the component5 from a Calendar object. </summary>
		/// <param name="component5"> the Calendar with the component5 content to set </param>
		public virtual Field331 setComponent5(DateTime component5)
		{
			setComponent(5, SwiftFormatUtils.getTime3(component5));
			return this;
		}

		/// <summary>
		/// Set the Time Session Closed (component5). </summary>
		/// <param name="component5"> the Time Session Closed to set </param>
		public virtual Field331 setTimeSessionClosed(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Time Session Closed (component5) from a Calendar object. </summary>
		/// <seealso cref= #setComponent5(java.util.Calendar) </seealso>
		/// <param name="component5"> Calendar with the Time Session Closed content to set </param>
		public virtual Field331 setTimeSessionClosed(DateTime component5)
		{
			setComponent5(component5);
			return this;
		}
		/// <summary>
		/// Gets the component6 </summary>
		/// <returns> the component6 </returns>
		public virtual string getComponent6()
		{
			return getComponent(6);
		}

		/// <summary>
		/// Get the component6 as Number </summary>
		/// <returns> the component6 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component6AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(6));
			}
		}

		/// <summary>
		/// Gets the Reason For Closure (component6). </summary>
		/// <returns> the Reason For Closure from component6 </returns>
		public virtual string getReasonForClosure()
		{
			return getComponent(6);
		}

		/// <summary>
		/// Get the Reason For Closure (component6) as Number </summary>
		/// <returns> the Reason For Closure from component6 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number ReasonForClosureAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(6));
			}
		}

		/// <summary>
		/// Set the component6. </summary>
		/// <param name="component6"> the component6 to set </param>
		public virtual Field331 setComponent6(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the component6 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent6(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent6(String)
		/// </seealso>
		/// <param name="component6"> the Number with the component6 content to set </param>
		public virtual Field331 setComponent6(java.lang.Number component6)
		{
			if (component6 != null)
			{
				setComponent(6, Convert.ToString((int)component6));
			}
			return this;
		}

		/// <summary>
		/// Set the Reason For Closure (component6). </summary>
		/// <param name="component6"> the Reason For Closure to set </param>
		public virtual Field331 setReasonForClosure(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the Reason For Closure (component6) from a Number object. </summary>
		/// <seealso cref= #setComponent6(java.lang.Number) </seealso>
		/// <param name="component6"> Number with the Reason For Closure content to set </param>
		public virtual Field331 setReasonForClosure(java.lang.Number component6)
		{
			setComponent6(component6);
			return this;
		}
		/// <summary>
		/// Gets the component7 </summary>
		/// <returns> the component7 </returns>
		public virtual string getComponent7()
		{
			return getComponent(7);
		}

		/// <summary>
		/// Get the component7 as Number </summary>
		/// <returns> the component7 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component7AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(7));
			}
		}

		/// <summary>
		/// Gets the Quantity Of Messages Sent (component7). </summary>
		/// <returns> the Quantity Of Messages Sent from component7 </returns>
		public virtual string getQuantityOfMessagesSent()
		{
			return getComponent(7);
		}

		/// <summary>
		/// Get the Quantity Of Messages Sent (component7) as Number </summary>
		/// <returns> the Quantity Of Messages Sent from component7 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number QuantityOfMessagesSentAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(7));
			}
		}

		/// <summary>
		/// Set the component7. </summary>
		/// <param name="component7"> the component7 to set </param>
		public virtual Field331 setComponent7(string component7)
		{
			setComponent(7, component7);
			return this;
		}

		/// <summary>
		/// Set the component7 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent7(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent7(String)
		/// </seealso>
		/// <param name="component7"> the Number with the component7 content to set </param>
		public virtual Field331 setComponent7(java.lang.Number component7)
		{
			if (component7 != null)
			{
				setComponent(7, Convert.ToString((int)component7));
			}
			return this;
		}

		/// <summary>
		/// Set the Quantity Of Messages Sent (component7). </summary>
		/// <param name="component7"> the Quantity Of Messages Sent to set </param>
		public virtual Field331 setQuantityOfMessagesSent(string component7)
		{
			setComponent(7, component7);
			return this;
		}

		/// <summary>
		/// Set the Quantity Of Messages Sent (component7) from a Number object. </summary>
		/// <seealso cref= #setComponent7(java.lang.Number) </seealso>
		/// <param name="component7"> Number with the Quantity Of Messages Sent content to set </param>
		public virtual Field331 setQuantityOfMessagesSent(java.lang.Number component7)
		{
			setComponent7(component7);
			return this;
		}
		/// <summary>
		/// Gets the component8 </summary>
		/// <returns> the component8 </returns>
		public virtual string getComponent8()
		{
			return getComponent(8);
		}

		/// <summary>
		/// Get the component8 as Number </summary>
		/// <returns> the component8 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component8AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(8));
			}
		}

		/// <summary>
		/// Gets the Quantity Of Messages Received (component8). </summary>
		/// <returns> the Quantity Of Messages Received from component8 </returns>
		public virtual string getQuantityOfMessagesReceived()
		{
			return getComponent(8);
		}

		/// <summary>
		/// Get the Quantity Of Messages Received (component8) as Number </summary>
		/// <returns> the Quantity Of Messages Received from component8 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number QuantityOfMessagesReceivedAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(8));
			}
		}

		/// <summary>
		/// Set the component8. </summary>
		/// <param name="component8"> the component8 to set </param>
		public virtual Field331 setComponent8(string component8)
		{
			setComponent(8, component8);
			return this;
		}

		/// <summary>
		/// Set the component8 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent8(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent8(String)
		/// </seealso>
		/// <param name="component8"> the Number with the component8 content to set </param>
		public virtual Field331 setComponent8(java.lang.Number component8)
		{
			if (component8 != null)
			{
				setComponent(8, Convert.ToString((int)component8));
			}
			return this;
		}

		/// <summary>
		/// Set the Quantity Of Messages Received (component8). </summary>
		/// <param name="component8"> the Quantity Of Messages Received to set </param>
		public virtual Field331 setQuantityOfMessagesReceived(string component8)
		{
			setComponent(8, component8);
			return this;
		}

		/// <summary>
		/// Set the Quantity Of Messages Received (component8) from a Number object. </summary>
		/// <seealso cref= #setComponent8(java.lang.Number) </seealso>
		/// <param name="component8"> Number with the Quantity Of Messages Received content to set </param>
		public virtual Field331 setQuantityOfMessagesReceived(java.lang.Number component8)
		{
			setComponent8(component8);
			return this;
		}
		/// <summary>
		/// Gets the component9 </summary>
		/// <returns> the component9 </returns>
		public virtual string getComponent9()
		{
			return getComponent(9);
		}

		/// <summary>
		/// Get the component9 as Number </summary>
		/// <returns> the component9 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component9AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(9));
			}
		}

		/// <summary>
		/// Gets the First Input Sequence Number (component9). </summary>
		/// <returns> the First Input Sequence Number from component9 </returns>
		public virtual string getFirstInputSequenceNumber()
		{
			return getComponent(9);
		}

		/// <summary>
		/// Get the First Input Sequence Number (component9) as Number </summary>
		/// <returns> the First Input Sequence Number from component9 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number FirstInputSequenceNumberAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(9));
			}
		}

		/// <summary>
		/// Set the component9. </summary>
		/// <param name="component9"> the component9 to set </param>
		public virtual Field331 setComponent9(string component9)
		{
			setComponent(9, component9);
			return this;
		}

		/// <summary>
		/// Set the component9 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent9(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent9(String)
		/// </seealso>
		/// <param name="component9"> the Number with the component9 content to set </param>
		public virtual Field331 setComponent9(java.lang.Number component9)
		{
			if (component9 != null)
			{
				setComponent(9, Convert.ToString((int)component9));
			}
			return this;
		}

		/// <summary>
		/// Set the First Input Sequence Number (component9). </summary>
		/// <param name="component9"> the First Input Sequence Number to set </param>
		public virtual Field331 setFirstInputSequenceNumber(string component9)
		{
			setComponent(9, component9);
			return this;
		}

		/// <summary>
		/// Set the First Input Sequence Number (component9) from a Number object. </summary>
		/// <seealso cref= #setComponent9(java.lang.Number) </seealso>
		/// <param name="component9"> Number with the First Input Sequence Number content to set </param>
		public virtual Field331 setFirstInputSequenceNumber(java.lang.Number component9)
		{
			setComponent9(component9);
			return this;
		}
		/// <summary>
		/// Gets the component10 </summary>
		/// <returns> the component10 </returns>
		public virtual string getComponent10()
		{
			return getComponent(10);
		}

		/// <summary>
		/// Get the component10 as Number </summary>
		/// <returns> the component10 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component10AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(10));
			}
		}

		/// <summary>
		/// Gets the Last Input Sequence Number (component10). </summary>
		/// <returns> the Last Input Sequence Number from component10 </returns>
		public virtual string getLastInputSequenceNumber()
		{
			return getComponent(10);
		}

		/// <summary>
		/// Get the Last Input Sequence Number (component10) as Number </summary>
		/// <returns> the Last Input Sequence Number from component10 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number LastInputSequenceNumberAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(10));
			}
		}

		/// <summary>
		/// Set the component10. </summary>
		/// <param name="component10"> the component10 to set </param>
		public virtual Field331 setComponent10(string component10)
		{
			setComponent(10, component10);
			return this;
		}

		/// <summary>
		/// Set the component10 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent10(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent10(String)
		/// </seealso>
		/// <param name="component10"> the Number with the component10 content to set </param>
		public virtual Field331 setComponent10(java.lang.Number component10)
		{
			if (component10 != null)
			{
				setComponent(10, Convert.ToString((int)component10));
			}
			return this;
		}

		/// <summary>
		/// Set the Last Input Sequence Number (component10). </summary>
		/// <param name="component10"> the Last Input Sequence Number to set </param>
		public virtual Field331 setLastInputSequenceNumber(string component10)
		{
			setComponent(10, component10);
			return this;
		}

		/// <summary>
		/// Set the Last Input Sequence Number (component10) from a Number object. </summary>
		/// <seealso cref= #setComponent10(java.lang.Number) </seealso>
		/// <param name="component10"> Number with the Last Input Sequence Number content to set </param>
		public virtual Field331 setLastInputSequenceNumber(java.lang.Number component10)
		{
			setComponent10(component10);
			return this;
		}
		/// <summary>
		/// Gets the component11 </summary>
		/// <returns> the component11 </returns>
		public virtual string getComponent11()
		{
			return getComponent(11);
		}

		/// <summary>
		/// Get the component11 as Number </summary>
		/// <returns> the component11 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component11AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(11));
			}
		}

		/// <summary>
		/// Gets the First Output Sequence Number (component11). </summary>
		/// <returns> the First Output Sequence Number from component11 </returns>
		public virtual string getFirstOutputSequenceNumber()
		{
			return getComponent(11);
		}

		/// <summary>
		/// Get the First Output Sequence Number (component11) as Number </summary>
		/// <returns> the First Output Sequence Number from component11 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number FirstOutputSequenceNumberAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(11));
			}
		}

		/// <summary>
		/// Set the component11. </summary>
		/// <param name="component11"> the component11 to set </param>
		public virtual Field331 setComponent11(string component11)
		{
			setComponent(11, component11);
			return this;
		}

		/// <summary>
		/// Set the component11 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent11(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent11(String)
		/// </seealso>
		/// <param name="component11"> the Number with the component11 content to set </param>
		public virtual Field331 setComponent11(java.lang.Number component11)
		{
			if (component11 != null)
			{
				setComponent(11, Convert.ToString((int)component11));
			}
			return this;
		}

		/// <summary>
		/// Set the First Output Sequence Number (component11). </summary>
		/// <param name="component11"> the First Output Sequence Number to set </param>
		public virtual Field331 setFirstOutputSequenceNumber(string component11)
		{
			setComponent(11, component11);
			return this;
		}

		/// <summary>
		/// Set the First Output Sequence Number (component11) from a Number object. </summary>
		/// <seealso cref= #setComponent11(java.lang.Number) </seealso>
		/// <param name="component11"> Number with the First Output Sequence Number content to set </param>
		public virtual Field331 setFirstOutputSequenceNumber(java.lang.Number component11)
		{
			setComponent11(component11);
			return this;
		}
		/// <summary>
		/// Gets the component12 </summary>
		/// <returns> the component12 </returns>
		public virtual string getComponent12()
		{
			return getComponent(12);
		}

		/// <summary>
		/// Get the component12 as Number </summary>
		/// <returns> the component12 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component12AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(12));
			}
		}

		/// <summary>
		/// Gets the Last Output Sequence Number (component12). </summary>
		/// <returns> the Last Output Sequence Number from component12 </returns>
		public virtual string getLastOutputSequenceNumber()
		{
			return getComponent(12);
		}

		/// <summary>
		/// Get the Last Output Sequence Number (component12) as Number </summary>
		/// <returns> the Last Output Sequence Number from component12 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number LastOutputSequenceNumberAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(12));
			}
		}

		/// <summary>
		/// Set the component12. </summary>
		/// <param name="component12"> the component12 to set </param>
		public virtual Field331 setComponent12(string component12)
		{
			setComponent(12, component12);
			return this;
		}

		/// <summary>
		/// Set the component12 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent12(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent12(String)
		/// </seealso>
		/// <param name="component12"> the Number with the component12 content to set </param>
		public virtual Field331 setComponent12(java.lang.Number component12)
		{
			if (component12 != null)
			{
				setComponent(12, Convert.ToString((int)component12));
			}
			return this;
		}

		/// <summary>
		/// Set the Last Output Sequence Number (component12). </summary>
		/// <param name="component12"> the Last Output Sequence Number to set </param>
		public virtual Field331 setLastOutputSequenceNumber(string component12)
		{
			setComponent(12, component12);
			return this;
		}

		/// <summary>
		/// Set the Last Output Sequence Number (component12) from a Number object. </summary>
		/// <seealso cref= #setComponent12(java.lang.Number) </seealso>
		/// <param name="component12"> Number with the Last Output Sequence Number content to set </param>
		public virtual Field331 setLastOutputSequenceNumber(java.lang.Number component12)
		{
			setComponent12(component12);
			return this;
		}

		public virtual IList<DateTime> dates()
		{
			IList<DateTime> result = new List<DateTime>();
			result.Add(SwiftFormatUtils.getDate2(getComponent(2)));
			result.Add(SwiftFormatUtils.getTime3(getComponent(3)));
			result.Add(SwiftFormatUtils.getDate2(getComponent(4)));
			result.Add(SwiftFormatUtils.getTime3(getComponent(5)));
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
		/// <returns> the static value of Field331.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field331.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "4!n<DATE2><HHMM><DATE2><HHMM>3!n6!n6!n6!n6!n6!n6!n";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field331 get(final SwiftTagListBlock block)
		public static Field331 get(SwiftTagListBlock block)
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
			return new Field331(t);
		}

		/// <summary>
		/// Gets the first instance of Field331 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field331 get(final SwiftMessage msg)
		public static Field331 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field331 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field331> getAll(final SwiftMessage msg)
		public static IList<Field331> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field331 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field331> getAll(final SwiftTagListBlock block)
		public static IList<Field331> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field331> result = new java.util.ArrayList<>(arr.length);
				IList<Field331> result = new List<Field331>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field331(f));
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
			return 12;
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
			if (component < 1 || component > 12)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 331");
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
				//date
				java.text.DateFormat f = java.text.DateFormat.getDateInstance(java.text.DateFormat.DEFAULT, notNull(locale));
				DateTime cal = Component4AsCalendar;
				if (cal != null)
				{
					return f.format(cal.Ticks);
				}
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
			if (component == 6)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component6AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 7)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component7AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 8)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component8AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 9)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component9AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 10)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component10AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 11)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component11AsNumber;
				if (n != null)
				{
					return f.format(n);
				}
			}
			if (component == 12)
			{
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component12AsNumber;
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
				result.Add("Session Number");
				result.Add("Date Session Opened");
				result.Add("Time Session Opened");
				result.Add("Date Session Closed");
				result.Add("Time Session Closed");
				result.Add("Reason For Closure");
				result.Add("Quantity Of Messages Sent");
				result.Add("Quantity Of Messages Received");
				result.Add("First Input Sequence Number");
				result.Add("Last Input Sequence Number");
				result.Add("First Output Sequence Number");
				result.Add("Last Output Sequence Number");
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
				result[1] = "sessionNumber";
				result[2] = "dateSessionOpened";
				result[3] = "timeSessionOpened";
				result[4] = "dateSessionClosed";
				result[5] = "timeSessionClosed";
				result[6] = "reasonForClosure";
				result[7] = "quantityOfMessagesSent";
				result[8] = "quantityOfMessagesReceived";
				result[9] = "firstInputSequenceNumber";
				result[10] = "lastInputSequenceNumber";
				result[11] = "firstOutputSequenceNumber";
				result[12] = "lastOutputSequenceNumber";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field331 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field331 fromJson(final String json)
		public static Field331 fromJson(string json)
		{
			Field331 field = new Field331();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("sessionNumber") != null)
			{
				field.setComponent1(jsonObject.get("sessionNumber").AsString);
			}
			if (jsonObject.get("dateSessionOpened") != null)
			{
				field.setComponent2(jsonObject.get("dateSessionOpened").AsString);
			}
			if (jsonObject.get("timeSessionOpened") != null)
			{
				field.setComponent3(jsonObject.get("timeSessionOpened").AsString);
			}
			if (jsonObject.get("dateSessionClosed") != null)
			{
				field.setComponent4(jsonObject.get("dateSessionClosed").AsString);
			}
			if (jsonObject.get("timeSessionClosed") != null)
			{
				field.setComponent5(jsonObject.get("timeSessionClosed").AsString);
			}
			if (jsonObject.get("reasonForClosure") != null)
			{
				field.setComponent6(jsonObject.get("reasonForClosure").AsString);
			}
			if (jsonObject.get("quantityOfMessagesSent") != null)
			{
				field.setComponent7(jsonObject.get("quantityOfMessagesSent").AsString);
			}
			if (jsonObject.get("quantityOfMessagesReceived") != null)
			{
				field.setComponent8(jsonObject.get("quantityOfMessagesReceived").AsString);
			}
			if (jsonObject.get("firstInputSequenceNumber") != null)
			{
				field.setComponent9(jsonObject.get("firstInputSequenceNumber").AsString);
			}
			if (jsonObject.get("lastInputSequenceNumber") != null)
			{
				field.setComponent10(jsonObject.get("lastInputSequenceNumber").AsString);
			}
			if (jsonObject.get("firstOutputSequenceNumber") != null)
			{
				field.setComponent11(jsonObject.get("firstOutputSequenceNumber").AsString);
			}
			if (jsonObject.get("lastOutputSequenceNumber") != null)
			{
				field.setComponent12(jsonObject.get("lastOutputSequenceNumber").AsString);
			}
			return field;
		}


	}

}