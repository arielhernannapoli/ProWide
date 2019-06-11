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
	/// <strong>SWIFT MT Field 98E</strong>
	/// <para>
	/// Model and parser for field 98E of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Currency</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>:4!c//&lt;DATE4&gt;&lt;TIME2&gt;[,3n][/[&lt;N&gt;]&lt;TIME3&gt;]</code></li>
	/// 		<li>parser pattern: <code>:S//&lt;DATE4&gt;&lt;TIME2&gt;[,S][/[c]&lt;TIME3&gt;]</code></li>
	/// 		<li>components pattern: <code>SDTNCW</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field98E extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.DateContainer, com.prowidesoftware.swift.model.field.GenericField
	[Serializable]
	public class Field98E : Field, DateContainer, com.prowidesoftware.swift.model.field.GenericField
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 98E
		/// </summary>
		public const string NAME = "98E";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_98E = "98E";
		public const string PARSER_PATTERN = ":S//<DATE4><TIME2>[,S][/[c]<TIME3>]";
		public const string COMPONENTS_PATTERN = "SDTNCW";

		/// <summary>
		/// Component number for the Qualifier subfield
		/// </summary>
		public const int? QUALIFIER = 1;

		/// <summary>
		/// Component number for the Date subfield
		/// </summary>
		public const int? DATE = 2;

		/// <summary>
		/// Component number for the Time subfield
		/// </summary>
		public const int? TIME = 3;

		/// <summary>
		/// Component number for the Decimals subfield
		/// </summary>
		public const int? DECIMALS = 4;

		/// <summary>
		/// Component number for the Sign subfield
		/// </summary>
		public const int? SIGN = 5;

		/// <summary>
		/// Component number for the UTC Indicator subfield
		/// </summary>
		public const int? UTC_INDICATOR = 6;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field98E() : base(6)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field98E(final String value)
		public Field98E(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field98E(final com.prowidesoftware.swift.model.Tag tag)
		public Field98E(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "98E"))
			{
				throw new System.ArgumentException("cannot create field 98E from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(6);
			Component1 = SwiftParseUtils.getTokenFirst(value, ":", "//");
			string toparse = SwiftParseUtils.getTokenSecondLast(value, "//"); // <DATE4><TIME2>[,S][/[c]<TIME3>]
			if (toparse != null)
			{
				if (toparse.Length >= 8)
				{
					setComponent2(StringUtils.Substring(toparse, 0, 8));
				}
				if (toparse.Length >= 14)
				{
					setComponent3(StringUtils.Substring(toparse, 8, 14));
				}
				if (toparse.Length > 14)
				{
					string toparse2 = StringUtils.Substring(toparse, 14 - toparse);
					setComponent4(SwiftParseUtils.getTokenFirst(toparse2, ",", "/"));
					string toparse3 = SwiftParseUtils.getTokenSecondLast(toparse2, "/");
					if (toparse3 != null)
					{
						if (toparse3.Length < 2)
						{
							setComponent5(toparse3);
						}
						else if (toparse3.Length == 2 || toparse3.Length == 4)
						{
							//HH or HH[MM]
							setComponent6(toparse3);
						}
						else if (toparse3.Length == 3 || toparse3.Length == 5)
						{
							//[N]HH or [N]HH[MM]
							setComponent5(StringUtils.Substring(toparse3, 0, 1));
							setComponent6(StringUtils.Substring(toparse3, 1 - toparse3));
						}
						else if (toparse3.Length > 4)
						{
							setComponent5(SwiftParseUtils.getAlphaPrefix(toparse3));
							setComponent6(SwiftParseUtils.getNumericSuffix(toparse3));
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
		public static Field98E newInstance(Field98E source)
		{
			Field98E cp = new Field98E();
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
				result.Append(":");
				append(result, 1);
				result.Append("//");
				append(result, 2);
				append(result, 3);
				if (getComponent4() != null)
				{
					result.Append(",").Append(getComponent4());
				}
				if (getComponent5() != null || getComponent6() != null)
				{
					result.Append("/");
					append(result, 5);
					append(result, 6);
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
		/// Gets the Qualifier (component1). </summary>
		/// <returns> the Qualifier from component1 </returns>
		public virtual string Qualifier
		{
			get
			{
				return getComponent(1);
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field98E setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Qualifier (component1). </summary>
		/// <param name="component1"> the Qualifier to set </param>
		public virtual Field98E setQualifier(string component1)
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
		public virtual Field98E setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the component2 from a Calendar object. </summary>
		/// <param name="component2"> the Calendar with the component2 content to set </param>
		public virtual Field98E setComponent2(DateTime component2)
		{
			setComponent(2, SwiftFormatUtils.getDate4(component2));
			return this;
		}

		/// <summary>
		/// Set the Date (component2). </summary>
		/// <param name="component2"> the Date to set </param>
		public virtual Field98E setDate(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Date (component2) from a Calendar object. </summary>
		/// <seealso cref= #setComponent2(java.util.Calendar) </seealso>
		/// <param name="component2"> Calendar with the Date content to set </param>
		public virtual Field98E setDate(DateTime component2)
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
				return SwiftFormatUtils.getTime2(getComponent(3));
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
				return SwiftFormatUtils.getTime2(getComponent(3));
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field98E setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the component3 from a Calendar object. </summary>
		/// <param name="component3"> the Calendar with the component3 content to set </param>
		public virtual Field98E setComponent3(DateTime component3)
		{
			setComponent(3, SwiftFormatUtils.getTime2(component3));
			return this;
		}

		/// <summary>
		/// Set the Time (component3). </summary>
		/// <param name="component3"> the Time to set </param>
		public virtual Field98E setTime(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Time (component3) from a Calendar object. </summary>
		/// <seealso cref= #setComponent3(java.util.Calendar) </seealso>
		/// <param name="component3"> Calendar with the Time content to set </param>
		public virtual Field98E setTime(DateTime component3)
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
		/// Gets the Decimals (component4). </summary>
		/// <returns> the Decimals from component4 </returns>
		public virtual string getDecimals()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the Decimals (component4) as Number </summary>
		/// <returns> the Decimals from component4 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number DecimalsAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(4));
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field98E setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the component4 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent4(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent4(String)
		/// </seealso>
		/// <param name="component4"> the Number with the component4 content to set </param>
		public virtual Field98E setComponent4(java.lang.Number component4)
		{
			if (component4 != null)
			{
				setComponent(4, Convert.ToString((int)component4));
			}
			return this;
		}

		/// <summary>
		/// Set the Decimals (component4). </summary>
		/// <param name="component4"> the Decimals to set </param>
		public virtual Field98E setDecimals(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Decimals (component4) from a Number object. </summary>
		/// <seealso cref= #setComponent4(java.lang.Number) </seealso>
		/// <param name="component4"> Number with the Decimals content to set </param>
		public virtual Field98E setDecimals(java.lang.Number component4)
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
		/// Get the component5 as Currency </summary>
		/// <returns> the component5 converted to Currency or null if cannot be converted </returns>
		public virtual java.util.Currency Component5AsCurrency
		{
			get
			{
				return SwiftFormatUtils.getCurrency(getComponent(5));
			}
		}

		/// <summary>
		/// Gets the Sign (component5). </summary>
		/// <returns> the Sign from component5 </returns>
		public virtual string getSign()
		{
			return getComponent(5);
		}

		/// <summary>
		/// Get the Sign (component5) as Currency </summary>
		/// <returns> the Sign from component5 converted to Currency or null if cannot be converted </returns>
		public virtual java.util.Currency SignAsCurrency
		{
			get
			{
				return SwiftFormatUtils.getCurrency(getComponent(5));
			}
		}

		/// <summary>
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field98E setComponent5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the component5 from a Currency object. </summary>
		/// <param name="component5"> the Currency with the component5 content to set </param>
		public virtual Field98E setComponent5(java.util.Currency component5)
		{
			setComponent(5, SwiftFormatUtils.getCurrency(component5));
			return this;
		}

		/// <summary>
		/// Set the Sign (component5). </summary>
		/// <param name="component5"> the Sign to set </param>
		public virtual Field98E setSign(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Sign (component5) from a Currency object. </summary>
		/// <seealso cref= #setComponent5(java.util.Currency) </seealso>
		/// <param name="component5"> Currency with the Sign content to set </param>
		public virtual Field98E setSign(java.util.Currency component5)
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
		/// Get the component6 as Calendar </summary>
		/// <returns> the component6 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime Component6AsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(6));
			}
		}

		/// <summary>
		/// Gets the UTC Indicator (component6). </summary>
		/// <returns> the UTC Indicator from component6 </returns>
		public virtual string getUTCIndicator()
		{
			return getComponent(6);
		}

		/// <summary>
		/// Get the UTC Indicator (component6) as Calendar </summary>
		/// <returns> the UTC Indicator from component6 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime UTCIndicatorAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getTime3(getComponent(6));
			}
		}

		/// <summary>
		/// Set the component6. </summary>
		/// <param name="component6"> the component6 to set </param>
		public virtual Field98E setComponent6(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the component6 from a Calendar object. </summary>
		/// <param name="component6"> the Calendar with the component6 content to set </param>
		public virtual Field98E setComponent6(DateTime component6)
		{
			setComponent(6, SwiftFormatUtils.getTime3(component6));
			return this;
		}

		/// <summary>
		/// Set the UTC Indicator (component6). </summary>
		/// <param name="component6"> the UTC Indicator to set </param>
		public virtual Field98E setUTCIndicator(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the UTC Indicator (component6) from a Calendar object. </summary>
		/// <seealso cref= #setComponent6(java.util.Calendar) </seealso>
		/// <param name="component6"> Calendar with the UTC Indicator content to set </param>
		public virtual Field98E setUTCIndicator(DateTime component6)
		{
			setComponent6(component6);
			return this;
		}

		public virtual IList<DateTime> dates()
		{
			IList<DateTime> result = new List<DateTime>();
			result.Add(SwiftFormatUtils.getDate4(getComponent(2)));
			result.Add(SwiftFormatUtils.getTime2(getComponent(3)));
			result.Add(SwiftFormatUtils.getTime3(getComponent(6)));
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
			   return true;
		   }
	   }

	   /// <summary>
	   /// Returns the issuer code (or Data Source Scheme or DSS).
	   /// The DSS is only present in some generic fields, when present, is equals to component two.
	   /// </summary>
	   /// <returns> DSS component value or null if the DSS is not set or not available for this field. </returns>
	   public override string DSS
	   {
		   get
		   {
			   return null;
		   }
	   }

	   /// <summary>
	   /// Checks if the issuer code (or Data Source Scheme or DSS) is present.
	   /// </summary>
	   /// <seealso cref= #getDSS() </seealso>
	   /// <returns> true if DSS is present, false otherwise. </returns>
	   public override bool DSSPresent
	   {
		   get
		   {
			   return DSS != null;
		   }
	   }

		/// <summary>
		/// Component number for the conditional qualifier subfield
		/// </summary>
		public const int? CONDITIONAL_QUALIFIER = 2;

	   /// <summary>
	   /// Gets the conditional qualifier.<br>
	   /// The conditional qualifier is the the component following the DSS of generic fields, being component 2 or 3 depending on the field structure definition.
	   /// </summary>
	   /// <returns> for generic fields returns the value of the conditional qualifier or null if not set or not applicable for this kind of field. </returns>
	   public override string ConditionalQualifier
	   {
		   get
		   {
			   return getComponent(CONDITIONAL_QUALIFIER);
		   }
	   }

	   public override string parserPattern()
	   {
			   return PARSER_PATTERN;
	   }

		/// <summary>
		/// Returns the field's name composed by the field number and the letter option (if any) </summary>
		/// <returns> the static value of Field98E.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field98E.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return ":4!c//<DATE4><TIME2>[,3n][/[<N>]<TIME3>]";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field98E get(final SwiftTagListBlock block)
		public static Field98E get(SwiftTagListBlock block)
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
			return new Field98E(t);
		}

		/// <summary>
		/// Gets the first instance of Field98E in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field98E get(final SwiftMessage msg)
		public static Field98E get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field98E in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field98E> getAll(final SwiftMessage msg)
		public static IList<Field98E> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field98E from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field98E> getAll(final SwiftTagListBlock block)
		public static IList<Field98E> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field98E> result = new java.util.ArrayList<>(arr.length);
				IList<Field98E> result = new List<Field98E>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field98E(f));
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
			return 6;
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
			if (component < 1 || component > 6)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 98E");
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
				//time with seconds
				java.text.DateFormat f = new java.text.SimpleDateFormat("HH:mm:ss", notNull(locale));
				DateTime cal = Component3AsCalendar;
				if (cal != null)
				{
					return f.format(cal.Ticks);
				}
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
			if (component == 6)
			{
				//time
				java.text.DateFormat f = new java.text.SimpleDateFormat("HH:mm", notNull(locale));
				DateTime cal = Component6AsCalendar;
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
				result.Add("Qualifier");
				result.Add("Date");
				result.Add("Time");
				result.Add("Decimals");
				result.Add("Sign");
				result.Add("UTC Indicator");
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
				result[1] = "qualifier";
				result[2] = "date";
				result[3] = "time";
				result[4] = "decimals";
				result[5] = "sign";
				result[6] = "uTCIndicator";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field98E object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field98E fromJson(final String json)
		public static Field98E fromJson(string json)
		{
			Field98E field = new Field98E();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("qualifier") != null)
			{
				field.Component1 = jsonObject.get("qualifier").AsString;
			}
			if (jsonObject.get("date") != null)
			{
				field.setComponent2(jsonObject.get("date").AsString);
			}
			if (jsonObject.get("time") != null)
			{
				field.setComponent3(jsonObject.get("time").AsString);
			}
			if (jsonObject.get("decimals") != null)
			{
				field.setComponent4(jsonObject.get("decimals").AsString);
			}
			if (jsonObject.get("sign") != null)
			{
				field.setComponent5(jsonObject.get("sign").AsString);
			}
			if (jsonObject.get("uTCIndicator") != null)
			{
				field.setComponent6(jsonObject.get("uTCIndicator").AsString);
			}
			return field;
		}


	}

}