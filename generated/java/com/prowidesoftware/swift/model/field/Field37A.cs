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
	/// <strong>SWIFT MT Field 37A</strong>
	/// <para>
	/// Model and parser for field 37A of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>&lt;AMOUNT&gt;12[//&lt;DATE2&gt;&lt;DM&gt;3n][/16x]</code></li>
	/// 		<li>parser pattern: <code>N[//&lt;DATE2&gt;cS][/S]</code></li>
	/// 		<li>components pattern: <code>NESNS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field37A extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.DateContainer, com.prowidesoftware.swift.model.field.AmountContainer
	[Serializable]
	public class Field37A : Field, DateContainer, AmountContainer
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 37A
		/// </summary>
		public const string NAME = "37A";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_37A = "37A";
		public const string PARSER_PATTERN = "N[//<DATE2>cS][/S]";
		public const string COMPONENTS_PATTERN = "NESNS";

		/// <summary>
		/// Component number for the Rate subfield
		/// </summary>
		public const int? RATE = 1;

		/// <summary>
		/// Component number for the Date subfield
		/// </summary>
		public const int? DATE = 2;

		/// <summary>
		/// Component number for the D/M Mark subfield
		/// </summary>
		public const int? DM_MARK = 3;

		/// <summary>
		/// Component number for the Number of Days/Months subfield
		/// </summary>
		public const int? NUMBER_OF_DAYSMONTHS = 4;

		/// <summary>
		/// Component number for the Information subfield
		/// </summary>
		public const int? INFORMATION = 5;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field37A() : base(5)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field37A(final String value)
		public Field37A(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field37A(final com.prowidesoftware.swift.model.Tag tag)
		public Field37A(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "37A"))
			{
				throw new System.ArgumentException("cannot create field 37A from tag " + tag.Name + ", tagname must match the name of the field.");
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
			setComponent1(SwiftParseUtils.getTokenFirst(value, "//"));
			string toparse = SwiftParseUtils.getTokenSecond(value, "//");
			if (toparse != null)
			{
				if (toparse.Length >= 6)
				{
					setComponent2(StringUtils.Substring(toparse, 0, 6));
				}
				if (toparse.Length >= 7)
				{
					Component3 = StringUtils.Substring(toparse, 6, 7);
				}
				if (toparse.Length > 7)
				{
					string toparse2 = StringUtils.Substring(toparse, 7 - toparse);
					setComponent4(SwiftParseUtils.getTokenFirst(toparse2, "/"));
					Component5 = SwiftParseUtils.getTokenSecondLast(toparse2, "/");
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field37A newInstance(Field37A source)
		{
			Field37A cp = new Field37A();
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
				if (getComponent2() != null || Component3 != null || getComponent4() != null)
				{
					result.Append("//");
					append(result, 2);
					append(result, 3);
					append(result, 4);
				}
				if (Component5 != null)
				{
					result.Append("/").Append(Component5);
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
		/// Gets the Rate (component1). </summary>
		/// <returns> the Rate from component1 </returns>
		public virtual string getRate()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the Rate (component1) as Number </summary>
		/// <returns> the Rate from component1 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number RateAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field37A setComponent1(string component1)
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
		public virtual Field37A setComponent1(java.lang.Number component1)
		{
			setComponent(1, SwiftFormatUtils.getNumber(component1));
			return this;
		}

		/// <summary>
		/// Set the Rate (component1). </summary>
		/// <param name="component1"> the Rate to set </param>
		public virtual Field37A setRate(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Rate (component1) from a Number object. </summary>
		/// <seealso cref= #setComponent1(java.lang.Number) </seealso>
		/// <param name="component1"> Number with the Rate content to set </param>
		public virtual Field37A setRate(java.lang.Number component1)
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
		public virtual Field37A setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a Calendar object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component2"> the Calendar with the component2 content to set </param>
		public virtual Field37A setComponent2(DateTime component2)
		{
			setComponent(2, SwiftFormatUtils.getDate2(component2));
			return this;
		}

		/// <summary>
		/// Set the Date (component2). </summary>
		/// <param name="component2"> the Date to set </param>
		public virtual Field37A setDate(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Date (component2) from a Calendar object. </summary>
		/// <seealso cref= #setComponent2(java.util.Calendar) </seealso>
		/// <param name="component2"> Calendar with the Date content to set </param>
		public virtual Field37A setDate(DateTime component2)
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
		/// Gets the D/M Mark (component3). </summary>
		/// <returns> the D/M Mark from component3 </returns>
		public virtual string DMMark
		{
			get
			{
				return getComponent(3);
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field37A setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the D/M Mark (component3). </summary>
		/// <param name="component3"> the D/M Mark to set </param>
		public virtual Field37A setDMMark(string component3)
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
		/// Gets the Number of Days/Months (component4). </summary>
		/// <returns> the Number of Days/Months from component4 </returns>
		public virtual string getNumberofDaysMonths()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the Number of Days/Months (component4) as Number </summary>
		/// <returns> the Number of Days/Months from component4 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number NumberofDaysMonthsAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(4));
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field37A setComponent4(string component4)
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
		public virtual Field37A setComponent4(java.lang.Number component4)
		{
			setComponent(4, SwiftFormatUtils.getNumber(component4));
			return this;
		}

		/// <summary>
		/// Set the Number of Days/Months (component4). </summary>
		/// <param name="component4"> the Number of Days/Months to set </param>
		public virtual Field37A setNumberofDaysMonths(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Number of Days/Months (component4) from a Number object. </summary>
		/// <seealso cref= #setComponent4(java.lang.Number) </seealso>
		/// <param name="component4"> Number with the Number of Days/Months content to set </param>
		public virtual Field37A setNumberofDaysMonths(java.lang.Number component4)
		{
			setComponent4(component4);
			return this;
		}
		/// <summary>
		/// Gets the component5 </summary>
		/// <returns> the component5 </returns>
		public virtual string Component5
		{
			get
			{
				return getComponent(5);
			}
		}

		/// <summary>
		/// Same as getComponent(5) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent5AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component5AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent5AsString()", "Use use #getComponent(int) instead.");
				return getComponent(5);
			}
		}

		/// <summary>
		/// Gets the Information (component5). </summary>
		/// <returns> the Information from component5 </returns>
		public virtual string Information
		{
			get
			{
				return getComponent(5);
			}
		}

		/// <summary>
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field37A setComponent5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Information (component5). </summary>
		/// <param name="component5"> the Information to set </param>
		public virtual Field37A setInformation(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		public virtual IList<DateTime> dates()
		{
			IList<DateTime> result = new List<DateTime>();
			result.Add(SwiftFormatUtils.getDate2(getComponent(2)));
			return result;
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
		   if (component == 2)
		   {
			   return true;
		   }
		   if (component == 3)
		   {
			   return true;
		   }
		   if (component == 4)
		   {
			   return true;
		   }
		   if (component == 5)
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
		/// <returns> the static value of Field37A.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field37A.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "<AMOUNT>12[//<DATE2><DM>3n][/16x]";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field37A get(final SwiftTagListBlock block)
		public static Field37A get(SwiftTagListBlock block)
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
			return new Field37A(t);
		}

		/// <summary>
		/// Gets the first instance of Field37A in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field37A get(final SwiftMessage msg)
		public static Field37A get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field37A in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field37A> getAll(final SwiftMessage msg)
		public static IList<Field37A> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field37A from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field37A> getAll(final SwiftTagListBlock block)
		public static IList<Field37A> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field37A> result = new java.util.ArrayList<>(arr.length);
				IList<Field37A> result = new List<Field37A>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field37A(f));
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
				throw new System.ArgumentException("invalid component number " + component + " for field 37A");
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
				//default format (as is)
				return getComponent(3);
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
				//default format (as is)
				return getComponent(5);
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
				result.Add("Rate");
				result.Add("Date");
				result.Add("D/M Mark");
				result.Add("Number of Days/Months");
				result.Add("Information");
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
				result[1] = "rate";
				result[2] = "date";
				result[3] = "dMMark";
				result[4] = "numberofDaysMonths";
				result[5] = "information";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field37A object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field37A fromJson(final String json)
		public static Field37A fromJson(string json)
		{
			Field37A field = new Field37A();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("rate") != null)
			{
				field.setComponent1(jsonObject.get("rate").AsString);
			}
			if (jsonObject.get("date") != null)
			{
				field.setComponent2(jsonObject.get("date").AsString);
			}
			if (jsonObject.get("dMMark") != null)
			{
				field.Component3 = jsonObject.get("dMMark").AsString;
			}
			if (jsonObject.get("numberofDaysMonths") != null)
			{
				field.setComponent4(jsonObject.get("numberofDaysMonths").AsString);
			}
			if (jsonObject.get("information") != null)
			{
				field.Component5 = jsonObject.get("information").AsString;
			}
			return field;
		}


	}

}