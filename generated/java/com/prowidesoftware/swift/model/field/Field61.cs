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
	/// <strong>SWIFT MT Field 61</strong>
	/// <para>
	/// Model and parser for field 61 of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>Calendar</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>CUSTOM</code></li>
	/// 		<li>parser pattern: <code>CUSTOM</code></li>
	/// 		<li>components pattern: <code>EJSSNSSSSS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field61 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.AmountContainer, com.prowidesoftware.swift.model.field.MultiLineField
	[Serializable]
	public class Field61 : Field, AmountContainer, com.prowidesoftware.swift.model.field.MultiLineField
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 61
		/// </summary>
		public const string NAME = "61";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_61 = "61";
		public const string PARSER_PATTERN = "CUSTOM";
		public const string COMPONENTS_PATTERN = "EJSSNSSSSS";

		/// <summary>
		/// Component number for the Value Date subfield
		/// </summary>
		public const int? VALUE_DATE = 1;

		/// <summary>
		/// Component number for the Entry Date subfield
		/// </summary>
		public const int? ENTRY_DATE = 2;

		/// <summary>
		/// Component number for the D/C Mark subfield
		/// </summary>
		public const int? DC_MARK = 3;

		/// <summary>
		/// Component number for the Funds Code subfield
		/// </summary>
		public const int? FUNDS_CODE = 4;

		/// <summary>
		/// Component number for the Amount subfield
		/// </summary>
		public const int? AMOUNT = 5;

		/// <summary>
		/// Component number for the Transaction Type subfield
		/// </summary>
		public const int? TRANSACTION_TYPE = 6;

		/// <summary>
		/// Component number for the Identification Code subfield
		/// </summary>
		public const int? IDENTIFICATION_CODE = 7;

		/// <summary>
		/// Component number for the Reference For The Account Owner subfield
		/// </summary>
		public const int? REFERENCE_FOR_THE_ACCOUNT_OWNER = 8;

		/// <summary>
		/// Component number for the Reference Of The Account Servicing Institution subfield
		/// </summary>
		public const int? REFERENCE_OF_THE_ACCOUNT_SERVICING_INSTITUTION = 9;

		/// <summary>
		/// Component number for the Supplementary Details subfield
		/// </summary>
		public const int? SUPPLEMENTARY_DETAILS = 10;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field61() : base(10)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field61(final String value)
		public Field61(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field61(final com.prowidesoftware.swift.model.Tag tag)
		public Field61(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "61"))
			{
				throw new System.ArgumentException("cannot create field 61 from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(10);
		  //parse code from merge file
		  parseCustom(value);
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field61 newInstance(Field61 source)
		{
			Field61 cp = new Field61();
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
				// CUSTOM pattern for field 61
				append(result, 1);
				append(result, 2);
				append(result, 3);
				append(result, 4);
				append(result, 5);
				append(result, 6);
				append(result, 7);
				append(result, 8);
				if (Component9 != null)
				{
					result.Append("//");
					result.Append(Component9);
				}
				if (Component10 != null)
				{
					result.Append(com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL);
					result.Append(Component10);
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
		/// Get the component1 as Calendar </summary>
		/// <returns> the component1 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime Component1AsCalendar
		{
			get
			{
				return SwiftFormatUtils.getDate2(getComponent(1));
			}
		}

		/// <summary>
		/// Gets the Value Date (component1). </summary>
		/// <returns> the Value Date from component1 </returns>
		public virtual string getValueDate()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the Value Date (component1) as Calendar </summary>
		/// <returns> the Value Date from component1 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime ValueDateAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getDate2(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field61 setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the component1 from a Calendar object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component1"> the Calendar with the component1 content to set </param>
		public virtual Field61 setComponent1(DateTime component1)
		{
			setComponent(1, SwiftFormatUtils.getDate2(component1));
			return this;
		}

		/// <summary>
		/// Set the Value Date (component1). </summary>
		/// <param name="component1"> the Value Date to set </param>
		public virtual Field61 setValueDate(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Value Date (component1) from a Calendar object. </summary>
		/// <seealso cref= #setComponent1(java.util.Calendar) </seealso>
		/// <param name="component1"> Calendar with the Value Date content to set </param>
		public virtual Field61 setValueDate(DateTime component1)
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
				return SwiftFormatUtils.getMonthDay(getComponent(2));
			}
		}

		/// <summary>
		/// Gets the Entry Date (component2). </summary>
		/// <returns> the Entry Date from component2 </returns>
		public virtual string getEntryDate()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the Entry Date (component2) as Calendar </summary>
		/// <returns> the Entry Date from component2 converted to Calendar or null if cannot be converted </returns>
		public virtual DateTime EntryDateAsCalendar
		{
			get
			{
				return SwiftFormatUtils.getMonthDay(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field61 setComponent2(string component2)
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
		public virtual Field61 setComponent2(DateTime component2)
		{
			setComponent(2, SwiftFormatUtils.getMonthDay(component2));
			return this;
		}

		/// <summary>
		/// Set the Entry Date (component2). </summary>
		/// <param name="component2"> the Entry Date to set </param>
		public virtual Field61 setEntryDate(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Entry Date (component2) from a Calendar object. </summary>
		/// <seealso cref= #setComponent2(java.util.Calendar) </seealso>
		/// <param name="component2"> Calendar with the Entry Date content to set </param>
		public virtual Field61 setEntryDate(DateTime component2)
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
		/// Gets the D/C Mark (component3). </summary>
		/// <returns> the D/C Mark from component3 </returns>
		public virtual string DCMark
		{
			get
			{
				return getComponent(3);
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field61 setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the D/C Mark (component3). </summary>
		/// <param name="component3"> the D/C Mark to set </param>
		public virtual Field61 setDCMark(string component3)
		{
			setComponent(3, component3);
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
		/// Gets the Funds Code (component4). </summary>
		/// <returns> the Funds Code from component4 </returns>
		public virtual string FundsCode
		{
			get
			{
				return getComponent(4);
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field61 setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Funds Code (component4). </summary>
		/// <param name="component4"> the Funds Code to set </param>
		public virtual Field61 setFundsCode(string component4)
		{
			setComponent(4, component4);
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
		/// Gets the Amount (component5). </summary>
		/// <returns> the Amount from component5 </returns>
		public virtual string getAmount()
		{
			return getComponent(5);
		}

		/// <summary>
		/// Get the Amount (component5) as Number </summary>
		/// <returns> the Amount from component5 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number AmountAsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(5));
			}
		}

		/// <summary>
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field61 setComponent5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the component5 from a Number object.
		/// <br>
		/// Parses the Number into a SWIFT amount with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="component5"> the Number with the component5 content to set </param>
		public virtual Field61 setComponent5(java.lang.Number component5)
		{
			setComponent(5, SwiftFormatUtils.getNumber(component5));
			return this;
		}

		/// <summary>
		/// Set the Amount (component5). </summary>
		/// <param name="component5"> the Amount to set </param>
		public virtual Field61 setAmount(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Amount (component5) from a Number object. </summary>
		/// <seealso cref= #setComponent5(java.lang.Number) </seealso>
		/// <param name="component5"> Number with the Amount content to set </param>
		public virtual Field61 setAmount(java.lang.Number component5)
		{
			setComponent5(component5);
			return this;
		}
		/// <summary>
		/// Gets the component6 </summary>
		/// <returns> the component6 </returns>
		public virtual string Component6
		{
			get
			{
				return getComponent(6);
			}
		}

		/// <summary>
		/// Same as getComponent(6) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent6AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component6AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent6AsString()", "Use use #getComponent(int) instead.");
				return getComponent(6);
			}
		}

		/// <summary>
		/// Gets the Transaction Type (component6). </summary>
		/// <returns> the Transaction Type from component6 </returns>
		public virtual string TransactionType
		{
			get
			{
				return getComponent(6);
			}
		}

		/// <summary>
		/// Set the component6. </summary>
		/// <param name="component6"> the component6 to set </param>
		public virtual Field61 setComponent6(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the Transaction Type (component6). </summary>
		/// <param name="component6"> the Transaction Type to set </param>
		public virtual Field61 setTransactionType(string component6)
		{
			setComponent(6, component6);
			return this;
		}
		/// <summary>
		/// Gets the component7 </summary>
		/// <returns> the component7 </returns>
		public virtual string Component7
		{
			get
			{
				return getComponent(7);
			}
		}

		/// <summary>
		/// Same as getComponent(7) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent7AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component7AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent7AsString()", "Use use #getComponent(int) instead.");
				return getComponent(7);
			}
		}

		/// <summary>
		/// Gets the Identification Code (component7). </summary>
		/// <returns> the Identification Code from component7 </returns>
		public virtual string IdentificationCode
		{
			get
			{
				return getComponent(7);
			}
		}

		/// <summary>
		/// Set the component7. </summary>
		/// <param name="component7"> the component7 to set </param>
		public virtual Field61 setComponent7(string component7)
		{
			setComponent(7, component7);
			return this;
		}

		/// <summary>
		/// Set the Identification Code (component7). </summary>
		/// <param name="component7"> the Identification Code to set </param>
		public virtual Field61 setIdentificationCode(string component7)
		{
			setComponent(7, component7);
			return this;
		}
		/// <summary>
		/// Gets the component8 </summary>
		/// <returns> the component8 </returns>
		public virtual string Component8
		{
			get
			{
				return getComponent(8);
			}
		}

		/// <summary>
		/// Same as getComponent(8) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent8AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component8AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent8AsString()", "Use use #getComponent(int) instead.");
				return getComponent(8);
			}
		}

		/// <summary>
		/// Gets the Reference For The Account Owner (component8). </summary>
		/// <returns> the Reference For The Account Owner from component8 </returns>
		public virtual string ReferenceForTheAccountOwner
		{
			get
			{
				return getComponent(8);
			}
		}

		/// <summary>
		/// Set the component8. </summary>
		/// <param name="component8"> the component8 to set </param>
		public virtual Field61 setComponent8(string component8)
		{
			setComponent(8, component8);
			return this;
		}

		/// <summary>
		/// Set the Reference For The Account Owner (component8). </summary>
		/// <param name="component8"> the Reference For The Account Owner to set </param>
		public virtual Field61 setReferenceForTheAccountOwner(string component8)
		{
			setComponent(8, component8);
			return this;
		}
		/// <summary>
		/// Gets the component9 </summary>
		/// <returns> the component9 </returns>
		public virtual string Component9
		{
			get
			{
				return getComponent(9);
			}
		}

		/// <summary>
		/// Same as getComponent(9) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent9AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component9AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent9AsString()", "Use use #getComponent(int) instead.");
				return getComponent(9);
			}
		}

		/// <summary>
		/// Gets the Reference Of The Account Servicing Institution (component9). </summary>
		/// <returns> the Reference Of The Account Servicing Institution from component9 </returns>
		public virtual string ReferenceOfTheAccountServicingInstitution
		{
			get
			{
				return getComponent(9);
			}
		}

		/// <summary>
		/// Set the component9. </summary>
		/// <param name="component9"> the component9 to set </param>
		public virtual Field61 setComponent9(string component9)
		{
			setComponent(9, component9);
			return this;
		}

		/// <summary>
		/// Set the Reference Of The Account Servicing Institution (component9). </summary>
		/// <param name="component9"> the Reference Of The Account Servicing Institution to set </param>
		public virtual Field61 setReferenceOfTheAccountServicingInstitution(string component9)
		{
			setComponent(9, component9);
			return this;
		}
		/// <summary>
		/// Gets the component10 </summary>
		/// <returns> the component10 </returns>
		public virtual string Component10
		{
			get
			{
				return getComponent(10);
			}
		}

		/// <summary>
		/// Same as getComponent(10) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent10AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component10AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent10AsString()", "Use use #getComponent(int) instead.");
				return getComponent(10);
			}
		}

		/// <summary>
		/// Gets the Supplementary Details (component10). </summary>
		/// <returns> the Supplementary Details from component10 </returns>
		public virtual string SupplementaryDetails
		{
			get
			{
				return getComponent(10);
			}
		}

		/// <summary>
		/// Set the component10. </summary>
		/// <param name="component10"> the component10 to set </param>
		public virtual Field61 setComponent10(string component10)
		{
			setComponent(10, component10);
			return this;
		}

		/// <summary>
		/// Set the Supplementary Details (component10). </summary>
		/// <param name="component10"> the Supplementary Details to set </param>
		public virtual Field61 setSupplementaryDetails(string component10)
		{
			setComponent(10, component10);
			return this;
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
		   if (component == 4)
		   {
			   return true;
		   }
		   if (component == 9)
		   {
			   return true;
		   }
		   if (component == 10)
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
		/// <returns> the static value of Field61.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field61.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "CUSTOM";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field61 get(final SwiftTagListBlock block)
		public static Field61 get(SwiftTagListBlock block)
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
			return new Field61(t);
		}

		/// <summary>
		/// Gets the first instance of Field61 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field61 get(final SwiftMessage msg)
		public static Field61 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field61 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field61> getAll(final SwiftMessage msg)
		public static IList<Field61> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field61 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field61> getAll(final SwiftTagListBlock block)
		public static IList<Field61> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field61> result = new java.util.ArrayList<>(arr.length);
				IList<Field61> result = new List<Field61>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field61(f));
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
			return 10;
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
			Field61 cp = newInstance(this);
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
			Field61 cp = newInstance(this);
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
			Field61 cp = newInstance(this);
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
			if (component < 1 || component > 10)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 61");
			}
			if (component == 1)
			{
				//date
				java.text.DateFormat f = java.text.DateFormat.getDateInstance(java.text.DateFormat.DEFAULT, notNull(locale));
				DateTime cal = Component1AsCalendar;
				if (cal != null)
				{
					return f.format(cal.Ticks);
				}
			}
			if (component == 2)
			{
				//monthday
				java.text.DateFormat f = new java.text.SimpleDateFormat("MMM", notNull(locale));
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
				//default format (as is)
				return getComponent(4);
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
			if (component == 6)
			{
				//default format (as is)
				return getComponent(6);
			}
			if (component == 7)
			{
				//default format (as is)
				return getComponent(7);
			}
			if (component == 8)
			{
				//default format (as is)
				return getComponent(8);
			}
			if (component == 9)
			{
				//default format (as is)
				return getComponent(9);
			}
			if (component == 10)
			{
				//default format (as is)
				return getComponent(10);
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
				result.Add("Value Date");
				result.Add("Entry Date");
				result.Add("D/C Mark");
				result.Add("Funds Code");
				result.Add("Amount");
				result.Add("Transaction Type");
				result.Add("Identification Code");
				result.Add("Reference For The Account Owner");
				result.Add("Reference Of The Account Servicing Institution");
				result.Add("Supplementary Details");
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
				result[1] = "valueDate";
				result[2] = "entryDate";
				result[3] = "dCMark";
				result[4] = "fundsCode";
				result[5] = "amount";
				result[6] = "transactionType";
				result[7] = "identificationCode";
				result[8] = "referenceForTheAccountOwner";
				result[9] = "referenceOfTheAccountServicingInstitution";
				result[10] = "supplementaryDetails";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field61 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field61 fromJson(final String json)
		public static Field61 fromJson(string json)
		{
			Field61 field = new Field61();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("valueDate") != null)
			{
				field.setComponent1(jsonObject.get("valueDate").AsString);
			}
			if (jsonObject.get("entryDate") != null)
			{
				field.setComponent2(jsonObject.get("entryDate").AsString);
			}
			if (jsonObject.get("dCMark") != null)
			{
				field.Component3 = jsonObject.get("dCMark").AsString;
			}
			if (jsonObject.get("fundsCode") != null)
			{
				field.Component4 = jsonObject.get("fundsCode").AsString;
			}
			if (jsonObject.get("amount") != null)
			{
				field.setComponent5(jsonObject.get("amount").AsString);
			}
			if (jsonObject.get("transactionType") != null)
			{
				field.Component6 = jsonObject.get("transactionType").AsString;
			}
			if (jsonObject.get("identificationCode") != null)
			{
				field.Component7 = jsonObject.get("identificationCode").AsString;
			}
			if (jsonObject.get("referenceForTheAccountOwner") != null)
			{
				field.Component8 = jsonObject.get("referenceForTheAccountOwner").AsString;
			}
			if (jsonObject.get("referenceOfTheAccountServicingInstitution") != null)
			{
				field.Component9 = jsonObject.get("referenceOfTheAccountServicingInstitution").AsString;
			}
			if (jsonObject.get("supplementaryDetails") != null)
			{
				field.Component10 = jsonObject.get("supplementaryDetails").AsString;
			}
			return field;
		}


		/// <summary>
		/// Custom parser for Field61.
		/// 
		/// <para>
		/// Uses semantic information to split components 3 and 4 (assuming component 3 can only be D, C, RD, RC).
		/// It also splits VAR-SEQU-1 into components 7 and 8.
		/// 
		/// </para>
		/// <para>MT=940, 942
		/// <br>
		/// &lt;DATE2&gt;[&lt;DATE1&gt;]2a[1a]&lt;NUMBER&gt;15&lt;SUB-6&gt;&lt;VAR-SEQU-1&gt;[’CRLF’&lt;ERI-F61&gt;]
		/// 
		/// </para>
		/// <para>
		/// MT=other, i.e. : 608, 950, 970, 972, n92, n95, n96
		/// <br>
		/// &lt;DATE2&gt;[&lt;DATE1&gt;]2a[1a]&lt;NUMBER&gt;15&lt;SUB-6&gt;&lt;VAR-SEQU-1&gt;[’CRLF’34x](**)
		/// </para>
		/// </summary>
		protected internal virtual void parseCustom(string value)
		{
			//thanks to Mark Karatovic for his contribution on this implementation.
			<string> lines = SwiftParseUtils.getLines(value);
			if (lines.Empty)
			{
				return;
			}
			/*
			 * parse dates
			 */
			string dates = SwiftParseUtils.getNumericPrefix(lines.get(0));
			int dates_length = dates != null ? dates.Length : 0;
			if (dates_length >= 6)
			{
				setComponent1(StringUtils.Substring(dates, 0, 6));
			}
			if (dates_length >= 10)
			{
				setComponent2(StringUtils.Substring(dates, 6 - dates));
			}
			string toparse = StringHelperClass.SubstringSpecial(StringUtils, lines.get(0), dates_length);

			/*
			 * parse component 3 and 4 (DC mark and optional funds code)
			 */
			string comp3and4 = SwiftParseUtils.getAlphaPrefix(toparse);
			if (comp3and4 != null)
			{
				if (comp3and4[0] == 'R' || comp3and4[0] == 'E')
				{
					/*
					 EC Expected Credit
					 ED Expected Debit
					 RC Reversal of Credit (debit entry)
					 RD Reversal of Debit (credit entry)
					*/
					if (comp3and4.Length >= 2)
					{
						Component3 = StringUtils.Substring(comp3and4, 0, 2);
					}
					if (comp3and4.Length >= 3)
					{
						Component4 = StringUtils.Substring(comp3and4, 2 - comp3and4);
					}
				}
				else
				{
					/*
					 C  Credit
					 D  Debit
					*/
					if (comp3and4.Length >= 1)
					{
						Component3 = StringUtils.Substring(comp3and4, 0, 1);
					}
					if (comp3and4.Length >= 2)
					{
						Component4 = StringUtils.Substring(comp3and4, 1 - comp3and4);
					}
				}

				string toparse2 = StringUtils.Substring(toparse, comp3and4.Length - toparse);

				/*
				 * parse component 5
				 */
				string comp5 = SwiftParseUtils.getNumericPrefix(toparse2);
				int comp5_length = comp5 != null ? comp5.Length : 0;
				setComponent5(comp5);

				/*
				 * parse <SUB-6> into components 6 and 7
				 */
				string toparse3 = StringUtils.Substring(toparse2, comp5_length - toparse2);
				string toParseTxnCode = StringUtils.Substring(toparse3, 0, 4);
				Component6 = StringUtils.Substring(toParseTxnCode, 0, 1);
				Component7 = StringUtils.Substring(toParseTxnCode, 1 - toParseTxnCode);

				int toParseTxnCodeLength = toParseTxnCode != null ? toParseTxnCode.Length : 0;
				string toparse4 = StringUtils.Substring(toparse3, toParseTxnCodeLength - toparse3);

				/*
				 * parse <VAR-SEQU-1> into components 8 and 9
				 */
				Component8 = StringUtils.substringBefore(toparse4, "//");
				Component9 = StringUtils.substringAfter(toparse4, "//");
			}

			if (lines.size() > 1)
			{
				Component10 = lines.get(1);
			}
		}
	}

}