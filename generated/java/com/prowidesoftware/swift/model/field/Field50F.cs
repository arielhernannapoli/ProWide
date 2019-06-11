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
	/// <strong>SWIFT MT Field 50F</strong>
	/// <para>
	/// Model and parser for field 50F of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>String</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>CUSTOM</code></li>
	/// 		<li>parser pattern: <code>S$S/S[$S/S]0-3</code></li>
	/// 		<li>components pattern: <code>SNSNSNSNS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field50F extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.MultiLineField
	[Serializable]
	public class Field50F : Field, com.prowidesoftware.swift.model.field.MultiLineField
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 50F
		/// </summary>
		public const string NAME = "50F";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_50F = "50F";
		public const string PARSER_PATTERN = "S$S/S[$S/S]0-3";
		public const string COMPONENTS_PATTERN = "SNSNSNSNS";

		/// <summary>
		/// Component number for the Party Identifier subfield
		/// </summary>
		public const int? PARTY_IDENTIFIER = 1;

		/// <summary>
		/// Component number for the Number 1 subfield
		/// </summary>
		public const int? NUMBER_1 = 2;

		/// <summary>
		/// Component number for the Name And Address 1 subfield
		/// </summary>
		public const int? NAME_AND_ADDRESS_1 = 3;

		/// <summary>
		/// Component number for the Number 2 subfield
		/// </summary>
		public const int? NUMBER_2 = 4;

		/// <summary>
		/// Component number for the Name And Address 2 subfield
		/// </summary>
		public const int? NAME_AND_ADDRESS_2 = 5;

		/// <summary>
		/// Component number for the Number 3 subfield
		/// </summary>
		public const int? NUMBER_3 = 6;

		/// <summary>
		/// Component number for the Name And Address 3 subfield
		/// </summary>
		public const int? NAME_AND_ADDRESS_3 = 7;

		/// <summary>
		/// Component number for the Number 4 subfield
		/// </summary>
		public const int? NUMBER_4 = 8;

		/// <summary>
		/// Component number for the Name And Address 4 subfield
		/// </summary>
		public const int? NAME_AND_ADDRESS_4 = 9;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field50F() : base(9)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field50F(final String value)
		public Field50F(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field50F(final com.prowidesoftware.swift.model.Tag tag)
		public Field50F(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "50F"))
			{
				throw new System.ArgumentException("cannot create field 50F from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(9);
			IList<string> lines = SwiftParseUtils.getLines(value);
			if (lines.Count > 0)
			{
				Component1 = lines[0];
				if (lines.Count > 1)
				{
					setComponent2(SwiftParseUtils.getTokenFirst(lines[1], "/"));
					Component3 = SwiftParseUtils.getTokenSecondLast(lines[1], "/");
				}
				if (lines.Count > 2)
				{
					setComponent4(SwiftParseUtils.getTokenFirst(lines[2], "/"));
					Component5 = SwiftParseUtils.getTokenSecondLast(lines[2], "/");
				}
				if (lines.Count > 3)
				{
					setComponent6(SwiftParseUtils.getTokenFirst(lines[3], "/"));
					Component7 = SwiftParseUtils.getTokenSecondLast(lines[3], "/");
				}
				if (lines.Count > 4)
				{
					setComponent8(SwiftParseUtils.getTokenFirst(lines[4], "/"));
					Component9 = SwiftParseUtils.getTokenSecondLast(lines[4], "/");
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field50F newInstance(Field50F source)
		{
			Field50F cp = new Field50F();
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
				if (getComponent2() != null || Component3 != null)
				{
					result.Append(com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL);
					append(result, 2);
					result.Append("/");
					append(result, 3);
				}
				if (getComponent4() != null || Component5 != null)
				{
					result.Append(com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL);
					append(result, 4);
					result.Append("/");
					append(result, 5);
				}
				if (getComponent6() != null || Component7 != null)
				{
					result.Append(com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL);
					append(result, 6);
					result.Append("/");
					append(result, 7);
				}
				if (getComponent8() != null || Component9 != null)
				{
					result.Append(com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL);
					append(result, 8);
					result.Append("/");
					append(result, 9);
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
		/// Gets the Party Identifier (component1). </summary>
		/// <returns> the Party Identifier from component1 </returns>
		public virtual string PartyIdentifier
		{
			get
			{
				return getComponent(1);
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field50F setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Party Identifier (component1). </summary>
		/// <param name="component1"> the Party Identifier to set </param>
		public virtual Field50F setPartyIdentifier(string component1)
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
		/// Gets the Number 1 (component2). </summary>
		/// <returns> the Number 1 from component2 </returns>
		public virtual string getNumber1()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the Number 1 (component2) as Number </summary>
		/// <returns> the Number 1 from component2 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Number1AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field50F setComponent2(string component2)
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
		public virtual Field50F setComponent2(java.lang.Number component2)
		{
			if (component2 != null)
			{
				setComponent(2, Convert.ToString((int)component2));
			}
			return this;
		}

		/// <summary>
		/// Set the Number 1 (component2). </summary>
		/// <param name="component2"> the Number 1 to set </param>
		public virtual Field50F setNumber1(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Number 1 (component2) from a Number object. </summary>
		/// <seealso cref= #setComponent2(java.lang.Number) </seealso>
		/// <param name="component2"> Number with the Number 1 content to set </param>
		public virtual Field50F setNumber1(java.lang.Number component2)
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
		/// Gets the Name And Address 1 (component3). </summary>
		/// <returns> the Name And Address 1 from component3 </returns>
		public virtual string NameAndAddress1
		{
			get
			{
				return getComponent(3);
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field50F setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Name And Address 1 (component3). </summary>
		/// <param name="component3"> the Name And Address 1 to set </param>
		public virtual Field50F setNameAndAddress1(string component3)
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
		/// Gets the Number 2 (component4). </summary>
		/// <returns> the Number 2 from component4 </returns>
		public virtual string getNumber2()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the Number 2 (component4) as Number </summary>
		/// <returns> the Number 2 from component4 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Number2AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(4));
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field50F setComponent4(string component4)
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
		public virtual Field50F setComponent4(java.lang.Number component4)
		{
			if (component4 != null)
			{
				setComponent(4, Convert.ToString((int)component4));
			}
			return this;
		}

		/// <summary>
		/// Set the Number 2 (component4). </summary>
		/// <param name="component4"> the Number 2 to set </param>
		public virtual Field50F setNumber2(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Number 2 (component4) from a Number object. </summary>
		/// <seealso cref= #setComponent4(java.lang.Number) </seealso>
		/// <param name="component4"> Number with the Number 2 content to set </param>
		public virtual Field50F setNumber2(java.lang.Number component4)
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
		/// Gets the Name And Address 2 (component5). </summary>
		/// <returns> the Name And Address 2 from component5 </returns>
		public virtual string NameAndAddress2
		{
			get
			{
				return getComponent(5);
			}
		}

		/// <summary>
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field50F setComponent5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Name And Address 2 (component5). </summary>
		/// <param name="component5"> the Name And Address 2 to set </param>
		public virtual Field50F setNameAndAddress2(string component5)
		{
			setComponent(5, component5);
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
		/// Gets the Number 3 (component6). </summary>
		/// <returns> the Number 3 from component6 </returns>
		public virtual string getNumber3()
		{
			return getComponent(6);
		}

		/// <summary>
		/// Get the Number 3 (component6) as Number </summary>
		/// <returns> the Number 3 from component6 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Number3AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(6));
			}
		}

		/// <summary>
		/// Set the component6. </summary>
		/// <param name="component6"> the component6 to set </param>
		public virtual Field50F setComponent6(string component6)
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
		public virtual Field50F setComponent6(java.lang.Number component6)
		{
			if (component6 != null)
			{
				setComponent(6, Convert.ToString((int)component6));
			}
			return this;
		}

		/// <summary>
		/// Set the Number 3 (component6). </summary>
		/// <param name="component6"> the Number 3 to set </param>
		public virtual Field50F setNumber3(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the Number 3 (component6) from a Number object. </summary>
		/// <seealso cref= #setComponent6(java.lang.Number) </seealso>
		/// <param name="component6"> Number with the Number 3 content to set </param>
		public virtual Field50F setNumber3(java.lang.Number component6)
		{
			setComponent6(component6);
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
		/// Gets the Name And Address 3 (component7). </summary>
		/// <returns> the Name And Address 3 from component7 </returns>
		public virtual string NameAndAddress3
		{
			get
			{
				return getComponent(7);
			}
		}

		/// <summary>
		/// Set the component7. </summary>
		/// <param name="component7"> the component7 to set </param>
		public virtual Field50F setComponent7(string component7)
		{
			setComponent(7, component7);
			return this;
		}

		/// <summary>
		/// Set the Name And Address 3 (component7). </summary>
		/// <param name="component7"> the Name And Address 3 to set </param>
		public virtual Field50F setNameAndAddress3(string component7)
		{
			setComponent(7, component7);
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
		/// Gets the Number 4 (component8). </summary>
		/// <returns> the Number 4 from component8 </returns>
		public virtual string getNumber4()
		{
			return getComponent(8);
		}

		/// <summary>
		/// Get the Number 4 (component8) as Number </summary>
		/// <returns> the Number 4 from component8 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Number4AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(8));
			}
		}

		/// <summary>
		/// Set the component8. </summary>
		/// <param name="component8"> the component8 to set </param>
		public virtual Field50F setComponent8(string component8)
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
		public virtual Field50F setComponent8(java.lang.Number component8)
		{
			if (component8 != null)
			{
				setComponent(8, Convert.ToString((int)component8));
			}
			return this;
		}

		/// <summary>
		/// Set the Number 4 (component8). </summary>
		/// <param name="component8"> the Number 4 to set </param>
		public virtual Field50F setNumber4(string component8)
		{
			setComponent(8, component8);
			return this;
		}

		/// <summary>
		/// Set the Number 4 (component8) from a Number object. </summary>
		/// <seealso cref= #setComponent8(java.lang.Number) </seealso>
		/// <param name="component8"> Number with the Number 4 content to set </param>
		public virtual Field50F setNumber4(java.lang.Number component8)
		{
			setComponent8(component8);
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
		/// Gets the Name And Address 4 (component9). </summary>
		/// <returns> the Name And Address 4 from component9 </returns>
		public virtual string NameAndAddress4
		{
			get
			{
				return getComponent(9);
			}
		}

		/// <summary>
		/// Set the component9. </summary>
		/// <param name="component9"> the component9 to set </param>
		public virtual Field50F setComponent9(string component9)
		{
			setComponent(9, component9);
			return this;
		}

		/// <summary>
		/// Set the Name And Address 4 (component9). </summary>
		/// <param name="component9"> the Name And Address 4 to set </param>
		public virtual Field50F setNameAndAddress4(string component9)
		{
			setComponent(9, component9);
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
		   if (component == 4)
		   {
			   return true;
		   }
		   if (component == 5)
		   {
			   return true;
		   }
		   if (component == 6)
		   {
			   return true;
		   }
		   if (component == 7)
		   {
			   return true;
		   }
		   if (component == 8)
		   {
			   return true;
		   }
		   if (component == 9)
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
		/// <returns> the static value of Field50F.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field50F.COMPONENTS_PATTERN </returns>
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
//ORIGINAL LINE: public static Field50F get(final SwiftTagListBlock block)
		public static Field50F get(SwiftTagListBlock block)
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
			return new Field50F(t);
		}

		/// <summary>
		/// Gets the first instance of Field50F in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field50F get(final SwiftMessage msg)
		public static Field50F get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field50F in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field50F> getAll(final SwiftMessage msg)
		public static IList<Field50F> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field50F from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field50F> getAll(final SwiftTagListBlock block)
		public static IList<Field50F> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field50F> result = new java.util.ArrayList<>(arr.length);
				IList<Field50F> result = new List<Field50F>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field50F(f));
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
			return 9;
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
			Field50F cp = newInstance(this);
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
			Field50F cp = newInstance(this);
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
			Field50F cp = newInstance(this);
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
			if (component < 1 || component > 9)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 50F");
			}
			if (component == 1)
			{
				//special case for party identifier in field 50F
				if (StringUtils.StartsWith(getComponent(1), "/"))
				{
					return getComponent(1).Substring(1);
				}
				else
				{
					return getComponent(1);
				}
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
				//default format (as is)
				return getComponent(7);
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
				//default format (as is)
				return getComponent(9);
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
				result.Add("Party Identifier");
				result.Add("Number 1");
				result.Add("Name And Address 1");
				result.Add("Number 2");
				result.Add("Name And Address 2");
				result.Add("Number 3");
				result.Add("Name And Address 3");
				result.Add("Number 4");
				result.Add("Name And Address 4");
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
				result[1] = "partyIdentifier";
				result[2] = "number1";
				result[3] = "nameAndAddress1";
				result[4] = "number2";
				result[5] = "nameAndAddress2";
				result[6] = "number3";
				result[7] = "nameAndAddress3";
				result[8] = "number4";
				result[9] = "nameAndAddress4";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field50F object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field50F fromJson(final String json)
		public static Field50F fromJson(string json)
		{
			Field50F field = new Field50F();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("partyIdentifier") != null)
			{
				field.Component1 = jsonObject.get("partyIdentifier").AsString;
			}
			if (jsonObject.get("number1") != null)
			{
				field.setComponent2(jsonObject.get("number1").AsString);
			}
			if (jsonObject.get("nameAndAddress1") != null)
			{
				field.Component3 = jsonObject.get("nameAndAddress1").AsString;
			}
			if (jsonObject.get("number2") != null)
			{
				field.setComponent4(jsonObject.get("number2").AsString);
			}
			if (jsonObject.get("nameAndAddress2") != null)
			{
				field.Component5 = jsonObject.get("nameAndAddress2").AsString;
			}
			if (jsonObject.get("number3") != null)
			{
				field.setComponent6(jsonObject.get("number3").AsString);
			}
			if (jsonObject.get("nameAndAddress3") != null)
			{
				field.Component7 = jsonObject.get("nameAndAddress3").AsString;
			}
			if (jsonObject.get("number4") != null)
			{
				field.setComponent8(jsonObject.get("number4").AsString);
			}
			if (jsonObject.get("nameAndAddress4") != null)
			{
				field.Component9 = jsonObject.get("nameAndAddress4").AsString;
			}
			return field;
		}

		/// <summary>
		/// Specific implementation for field 50F using dynamic labels based on line identifiers.
		/// 
		/// <para>For components 3, 5, 7 and 9 this implementation will return the labels provided by
		/// <seealso cref="#getLabelForLineNumber(String)"/> while for all other cases it will return the
		/// default label.
		/// 
		/// </para>
		/// <para>
		/// Also since the party identifier can be an account or a code plus the identifier,
		/// then for component 1 if the value starts with a slash, this implementation will return
		/// "Account" as label instead of the generic "Party Identifier".
		/// 
		/// </para>
		/// </summary>
		/// <param name="number"> a component number </param>
		/// <returns> english label for the field component
		/// 
		/// @since 7.9.5 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public String getComponentLabel(final int number)
		public override string getComponentLabel(int number)
		{
			if (number == 1 && StringUtils.StartsWith(Component1, "/"))
			{
				return "Account";
			}
			if (number == 3 || number == 5 || number == 7 || number == 9)
			{
				string label = getLabelForLineNumber(getComponent(number - 1));
				if (label != null)
				{
					return label;
				}
			}
			return base.getComponentLabel(number);
		}

		/// <summary>
		/// Return the line labels based on the structured line number identification as follows:
		/// 
		/// <ul> 
		/// 	<li>1 -&gt; Name of the Ordering Customer</li>
		/// 	<li>2 -&gt; Address Line</li>
		/// 	<li>3 -&gt; Country and Town</li>
		/// 	<li>4 -&gt; Date of Birth</li>
		/// 	<li>5 -&gt; Place of Birth</li>
		/// 	<li>6 -&gt; Customer Identification Number</li>
		/// 	<li>7 -&gt; National Identity Number</li>
		/// 	<li>8 -&gt; Additional Information</li>
		/// 	<li>For any other number returns null</li>
		/// </ul>
		/// 
		/// <para>This is used in <seealso cref="#getComponentLabel(int)"/> to determine a suitable label dynamically
		/// based on the line identifiers. For example if the field value is this:
		/// <pre>
		/// NIDN/DE/121231234342
		/// 1/MANN GEORG
		/// 6/DE/ABC BANK/1234578293
		/// </pre>
		/// The components will be parsed as follows:
		/// <ul>
		/// 	<li>1 -&gt; NIDN/DE/121231234342</li>
		/// 	<li>2 -&gt; 1</li>
		/// 	<li>2 -&gt; MANN GEORG</li>
		/// 	<li>4 -&gt; 6</li>
		/// 	<li>5 -&gt; DE/ABC BANK/1234578293</li>
		/// </ul>
		/// 
		/// </para>
		/// <para>
		/// Then the component label for component 5 will be "Customer Identification Number" because it is the
		/// details subfield for a line identified with number 6.
		/// 
		/// </para>
		/// </summary>
		/// <param name="lineIdentifier"> the line number identifier, 1 to 8 according to the specification. </param>
		/// <returns> the line label
		/// @since 7.9.5 </returns>
		public virtual string getLabelForLineNumber(string lineIdentifier)
		{
			if (StringUtils.isNumeric(StringUtils.trimToNull(lineIdentifier)))
			{
				int number = Convert.ToInt32(lineIdentifier.Trim());
				if (number == 1)
				{
					return "Name of the Ordering Customer";
				}
				else if (number == 2)
				{
					return "Address Line";
				}
				else if (number == 3)
				{
					return "Country and Town";
				}
				else if (number == 4)
				{
					return "Date of Birth";
				}
				else if (number == 5)
				{
					return "Place of Birth";
				}
				else if (number == 6)
				{
					return "Customer Identification Number";
				}
				else if (number == 7)
				{
					return "National Identity Number";
				}
				else if (number == 8)
				{
					return "Additional Information";
				}
			}
			return null;
		}

		/// <summary>
		/// Get the details (right part of the line) based on the line identification number.
		/// This API is specific for the structured field 50F. </summary>
		/// <param name="lineIdentifier"> a line number in the range of 1 to 8 </param>
		/// <returns> the details for the found lines or empty list if non is found or the line number is incorrect
		/// @since 7.10.4 </returns>
		public virtual IList<string> detailsByNumber(int lineIdentifier)
		{
			IList<string> result = new List<string>();
			string number = Convert.ToString(lineIdentifier);
			if (StringUtils.Equals(number, getComponent2()) && StringUtils.isNotBlank(Component3))
			{
				result.Add(Component3);
			}
			if (StringUtils.Equals(number, getComponent4()) && StringUtils.isNotBlank(Component5))
			{
				result.Add(Component5);
			}
			if (StringUtils.Equals(number, getComponent6()) && StringUtils.isNotBlank(Component7))
			{
				result.Add(Component7);
			}
			if (StringUtils.Equals(number, getComponent8()) && StringUtils.isNotBlank(Component9))
			{
				result.Add(Component9);
			}
			return result;
		}

		/// <summary>
		/// Check if the line identified by a given number is present.
		/// This API is specific for the structured field 50F. </summary>
		/// <param name="lineIdentifier"> a line number in the range of 1 to 8 </param>
		/// <returns> true if the structured content includes the line identified by the given number
		/// @since 7.10.4 </returns>
		public virtual bool contains(int lineIdentifier)
		{
			string number = Convert.ToString(lineIdentifier);
			if (StringUtils.Equals(number, getComponent2()) && StringUtils.isNotBlank(Component3))
			{
				return true;
			}
			if (StringUtils.Equals(number, getComponent4()) && StringUtils.isNotBlank(Component5))
			{
				return true;
			}
			if (StringUtils.Equals(number, getComponent6()) && StringUtils.isNotBlank(Component7))
			{
				return true;
			}
			if (StringUtils.Equals(number, getComponent8()) && StringUtils.isNotBlank(Component9))
			{
				return true;
			}
			return false;
		}
	}

}