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
	/// <strong>SWIFT MT Field 79</strong>
	/// <para>
	/// Model and parser for field 79 of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>String</code></li> 
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
	/// 		<li>parser pattern: <code>S[$S]0-34</code></li>
	/// 		<li>components pattern: <code>SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field79 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.MultiLineField
	[Serializable]
	public class Field79 : Field, com.prowidesoftware.swift.model.field.MultiLineField
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 79
		/// </summary>
		public const string NAME = "79";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_79 = "79";
		public const string PARSER_PATTERN = "S[$S]0-34";
		public const string COMPONENTS_PATTERN = "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS";

		/// <summary>
		/// Component number for the Narrative subfield
		/// </summary>
		public const int? NARRATIVE = 1;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field79() : base(35)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field79(final String value)
		public Field79(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field79(final com.prowidesoftware.swift.model.Tag tag)
		public Field79(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "79"))
			{
				throw new System.ArgumentException("cannot create field 79 from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(35);
			IList<string> lines = SwiftParseUtils.getLines(value);
			SwiftParseUtils.setComponentsFromLines(this, 1, null, 0, lines);
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field79 newInstance(Field79 source)
		{
			Field79 cp = new Field79();
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
				appendInLines(result, 1, 35);
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
		/// Gets the Narrative (component1). </summary>
		/// <returns> the Narrative from component1 </returns>
		public virtual string NarrativeLine1
		{
			get
			{
				return getComponent(1);
			}
		}

		/// <summary>
		/// Gets the Narrative (component2). </summary>
		/// <returns> the Narrative from component2 </returns>
		public virtual string NarrativeLine2
		{
			get
			{
				return getComponent(2);
			}
		}

		/// <summary>
		/// Gets the Narrative (component3). </summary>
		/// <returns> the Narrative from component3 </returns>
		public virtual string NarrativeLine3
		{
			get
			{
				return getComponent(3);
			}
		}

		/// <summary>
		/// Gets the Narrative (component4). </summary>
		/// <returns> the Narrative from component4 </returns>
		public virtual string NarrativeLine4
		{
			get
			{
				return getComponent(4);
			}
		}

		/// <summary>
		/// Gets the Narrative (component5). </summary>
		/// <returns> the Narrative from component5 </returns>
		public virtual string NarrativeLine5
		{
			get
			{
				return getComponent(5);
			}
		}

		/// <summary>
		/// Gets the Narrative (component6). </summary>
		/// <returns> the Narrative from component6 </returns>
		public virtual string NarrativeLine6
		{
			get
			{
				return getComponent(6);
			}
		}

		/// <summary>
		/// Gets the Narrative (component7). </summary>
		/// <returns> the Narrative from component7 </returns>
		public virtual string NarrativeLine7
		{
			get
			{
				return getComponent(7);
			}
		}

		/// <summary>
		/// Gets the Narrative (component8). </summary>
		/// <returns> the Narrative from component8 </returns>
		public virtual string NarrativeLine8
		{
			get
			{
				return getComponent(8);
			}
		}

		/// <summary>
		/// Gets the Narrative (component9). </summary>
		/// <returns> the Narrative from component9 </returns>
		public virtual string NarrativeLine9
		{
			get
			{
				return getComponent(9);
			}
		}

		/// <summary>
		/// Gets the Narrative (component10). </summary>
		/// <returns> the Narrative from component10 </returns>
		public virtual string NarrativeLine10
		{
			get
			{
				return getComponent(10);
			}
		}

		/// <summary>
		/// Gets the Narrative (component11). </summary>
		/// <returns> the Narrative from component11 </returns>
		public virtual string NarrativeLine11
		{
			get
			{
				return getComponent(11);
			}
		}

		/// <summary>
		/// Gets the Narrative (component12). </summary>
		/// <returns> the Narrative from component12 </returns>
		public virtual string NarrativeLine12
		{
			get
			{
				return getComponent(12);
			}
		}

		/// <summary>
		/// Gets the Narrative (component13). </summary>
		/// <returns> the Narrative from component13 </returns>
		public virtual string NarrativeLine13
		{
			get
			{
				return getComponent(13);
			}
		}

		/// <summary>
		/// Gets the Narrative (component14). </summary>
		/// <returns> the Narrative from component14 </returns>
		public virtual string NarrativeLine14
		{
			get
			{
				return getComponent(14);
			}
		}

		/// <summary>
		/// Gets the Narrative (component15). </summary>
		/// <returns> the Narrative from component15 </returns>
		public virtual string NarrativeLine15
		{
			get
			{
				return getComponent(15);
			}
		}

		/// <summary>
		/// Gets the Narrative (component16). </summary>
		/// <returns> the Narrative from component16 </returns>
		public virtual string NarrativeLine16
		{
			get
			{
				return getComponent(16);
			}
		}

		/// <summary>
		/// Gets the Narrative (component17). </summary>
		/// <returns> the Narrative from component17 </returns>
		public virtual string NarrativeLine17
		{
			get
			{
				return getComponent(17);
			}
		}

		/// <summary>
		/// Gets the Narrative (component18). </summary>
		/// <returns> the Narrative from component18 </returns>
		public virtual string NarrativeLine18
		{
			get
			{
				return getComponent(18);
			}
		}

		/// <summary>
		/// Gets the Narrative (component19). </summary>
		/// <returns> the Narrative from component19 </returns>
		public virtual string NarrativeLine19
		{
			get
			{
				return getComponent(19);
			}
		}

		/// <summary>
		/// Gets the Narrative (component20). </summary>
		/// <returns> the Narrative from component20 </returns>
		public virtual string NarrativeLine20
		{
			get
			{
				return getComponent(20);
			}
		}

		/// <summary>
		/// Gets the Narrative (component21). </summary>
		/// <returns> the Narrative from component21 </returns>
		public virtual string NarrativeLine21
		{
			get
			{
				return getComponent(21);
			}
		}

		/// <summary>
		/// Gets the Narrative (component22). </summary>
		/// <returns> the Narrative from component22 </returns>
		public virtual string NarrativeLine22
		{
			get
			{
				return getComponent(22);
			}
		}

		/// <summary>
		/// Gets the Narrative (component23). </summary>
		/// <returns> the Narrative from component23 </returns>
		public virtual string NarrativeLine23
		{
			get
			{
				return getComponent(23);
			}
		}

		/// <summary>
		/// Gets the Narrative (component24). </summary>
		/// <returns> the Narrative from component24 </returns>
		public virtual string NarrativeLine24
		{
			get
			{
				return getComponent(24);
			}
		}

		/// <summary>
		/// Gets the Narrative (component25). </summary>
		/// <returns> the Narrative from component25 </returns>
		public virtual string NarrativeLine25
		{
			get
			{
				return getComponent(25);
			}
		}

		/// <summary>
		/// Gets the Narrative (component26). </summary>
		/// <returns> the Narrative from component26 </returns>
		public virtual string NarrativeLine26
		{
			get
			{
				return getComponent(26);
			}
		}

		/// <summary>
		/// Gets the Narrative (component27). </summary>
		/// <returns> the Narrative from component27 </returns>
		public virtual string NarrativeLine27
		{
			get
			{
				return getComponent(27);
			}
		}

		/// <summary>
		/// Gets the Narrative (component28). </summary>
		/// <returns> the Narrative from component28 </returns>
		public virtual string NarrativeLine28
		{
			get
			{
				return getComponent(28);
			}
		}

		/// <summary>
		/// Gets the Narrative (component29). </summary>
		/// <returns> the Narrative from component29 </returns>
		public virtual string NarrativeLine29
		{
			get
			{
				return getComponent(29);
			}
		}

		/// <summary>
		/// Gets the Narrative (component30). </summary>
		/// <returns> the Narrative from component30 </returns>
		public virtual string NarrativeLine30
		{
			get
			{
				return getComponent(30);
			}
		}

		/// <summary>
		/// Gets the Narrative (component31). </summary>
		/// <returns> the Narrative from component31 </returns>
		public virtual string NarrativeLine31
		{
			get
			{
				return getComponent(31);
			}
		}

		/// <summary>
		/// Gets the Narrative (component32). </summary>
		/// <returns> the Narrative from component32 </returns>
		public virtual string NarrativeLine32
		{
			get
			{
				return getComponent(32);
			}
		}

		/// <summary>
		/// Gets the Narrative (component33). </summary>
		/// <returns> the Narrative from component33 </returns>
		public virtual string NarrativeLine33
		{
			get
			{
				return getComponent(33);
			}
		}

		/// <summary>
		/// Gets the Narrative (component34). </summary>
		/// <returns> the Narrative from component34 </returns>
		public virtual string NarrativeLine34
		{
			get
			{
				return getComponent(34);
			}
		}

		/// <summary>
		/// Gets the Narrative (component35). </summary>
		/// <returns> the Narrative from component35 </returns>
		public virtual string NarrativeLine35
		{
			get
			{
				return getComponent(35);
			}
		}

		/// <summary>
		/// Gets the Narrative as a concatenation of component1 to component35. </summary>
		/// <returns> the Narrative from components </returns>
		public virtual string Narrative
		{
			get
			{
				StringBuilder result = new StringBuilder();
				for (int i = 1 ; i < 36 ; i++)
				{
					if (StringUtils.isNotBlank(getComponent(i)))
					{
						if (result.Length > 0)
						{
							result.Append(com.prowidesoftware.swift.io.writer.FINWriterVisitor.SWIFT_EOL);
						}
						result.Append(StringUtils.trimToEmpty(getComponent(i)));
					}
				}
				return result.ToString();
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field79 setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component1). </summary>
		/// <param name="component1"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component2). </summary>
		/// <param name="component2"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component3). </summary>
		/// <param name="component3"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component4). </summary>
		/// <param name="component4"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component5). </summary>
		/// <param name="component5"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component6). </summary>
		/// <param name="component6"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine6(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component7). </summary>
		/// <param name="component7"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine7(string component7)
		{
			setComponent(7, component7);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component8). </summary>
		/// <param name="component8"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine8(string component8)
		{
			setComponent(8, component8);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component9). </summary>
		/// <param name="component9"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine9(string component9)
		{
			setComponent(9, component9);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component10). </summary>
		/// <param name="component10"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine10(string component10)
		{
			setComponent(10, component10);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component11). </summary>
		/// <param name="component11"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine11(string component11)
		{
			setComponent(11, component11);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component12). </summary>
		/// <param name="component12"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine12(string component12)
		{
			setComponent(12, component12);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component13). </summary>
		/// <param name="component13"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine13(string component13)
		{
			setComponent(13, component13);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component14). </summary>
		/// <param name="component14"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine14(string component14)
		{
			setComponent(14, component14);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component15). </summary>
		/// <param name="component15"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine15(string component15)
		{
			setComponent(15, component15);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component16). </summary>
		/// <param name="component16"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine16(string component16)
		{
			setComponent(16, component16);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component17). </summary>
		/// <param name="component17"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine17(string component17)
		{
			setComponent(17, component17);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component18). </summary>
		/// <param name="component18"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine18(string component18)
		{
			setComponent(18, component18);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component19). </summary>
		/// <param name="component19"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine19(string component19)
		{
			setComponent(19, component19);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component20). </summary>
		/// <param name="component20"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine20(string component20)
		{
			setComponent(20, component20);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component21). </summary>
		/// <param name="component21"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine21(string component21)
		{
			setComponent(21, component21);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component22). </summary>
		/// <param name="component22"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine22(string component22)
		{
			setComponent(22, component22);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component23). </summary>
		/// <param name="component23"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine23(string component23)
		{
			setComponent(23, component23);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component24). </summary>
		/// <param name="component24"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine24(string component24)
		{
			setComponent(24, component24);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component25). </summary>
		/// <param name="component25"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine25(string component25)
		{
			setComponent(25, component25);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component26). </summary>
		/// <param name="component26"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine26(string component26)
		{
			setComponent(26, component26);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component27). </summary>
		/// <param name="component27"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine27(string component27)
		{
			setComponent(27, component27);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component28). </summary>
		/// <param name="component28"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine28(string component28)
		{
			setComponent(28, component28);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component29). </summary>
		/// <param name="component29"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine29(string component29)
		{
			setComponent(29, component29);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component30). </summary>
		/// <param name="component30"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine30(string component30)
		{
			setComponent(30, component30);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component31). </summary>
		/// <param name="component31"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine31(string component31)
		{
			setComponent(31, component31);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component32). </summary>
		/// <param name="component32"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine32(string component32)
		{
			setComponent(32, component32);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component33). </summary>
		/// <param name="component33"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine33(string component33)
		{
			setComponent(33, component33);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component34). </summary>
		/// <param name="component34"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine34(string component34)
		{
			setComponent(34, component34);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component35). </summary>
		/// <param name="component35"> the Narrative to set </param>
		public virtual Field79 setNarrativeLine35(string component35)
		{
			setComponent(35, component35);
			return this;
		}

		/// <summary>
		/// Set the Narrative splitting the parameter lines into components 1 to 35. </summary>
		/// <param name="value"> the Narrative to set, may contain line ends and each line will be set to its correspondent component attribute </param>
		public virtual Field79 setNarrative(string value)
		{
			IList<string> lines = SwiftParseUtils.getLines(value);
			SwiftParseUtils.setComponentsFromLines(this, 1, 35, 0, lines);
			return this;
		}
		/// <summary>
		/// Gets the component2 </summary>
		/// <returns> the component2 </returns>
		public virtual string Component2
		{
			get
			{
				return getComponent(2);
			}
		}

		/// <summary>
		/// Same as getComponent(2) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent2AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component2AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent2AsString()", "Use use #getComponent(int) instead.");
				return getComponent(2);
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field79 setComponent2(string component2)
		{
			setComponent(2, component2);
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
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field79 setComponent3(string component3)
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
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field79 setComponent4(string component4)
		{
			setComponent(4, component4);
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
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field79 setComponent5(string component5)
		{
			setComponent(5, component5);
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
		/// Set the component6. </summary>
		/// <param name="component6"> the component6 to set </param>
		public virtual Field79 setComponent6(string component6)
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
		/// Set the component7. </summary>
		/// <param name="component7"> the component7 to set </param>
		public virtual Field79 setComponent7(string component7)
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
		/// Set the component8. </summary>
		/// <param name="component8"> the component8 to set </param>
		public virtual Field79 setComponent8(string component8)
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
		/// Set the component9. </summary>
		/// <param name="component9"> the component9 to set </param>
		public virtual Field79 setComponent9(string component9)
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
		/// Set the component10. </summary>
		/// <param name="component10"> the component10 to set </param>
		public virtual Field79 setComponent10(string component10)
		{
			setComponent(10, component10);
			return this;
		}
		/// <summary>
		/// Gets the component11 </summary>
		/// <returns> the component11 </returns>
		public virtual string Component11
		{
			get
			{
				return getComponent(11);
			}
		}

		/// <summary>
		/// Same as getComponent(11) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent11AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component11AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent11AsString()", "Use use #getComponent(int) instead.");
				return getComponent(11);
			}
		}

		/// <summary>
		/// Set the component11. </summary>
		/// <param name="component11"> the component11 to set </param>
		public virtual Field79 setComponent11(string component11)
		{
			setComponent(11, component11);
			return this;
		}
		/// <summary>
		/// Gets the component12 </summary>
		/// <returns> the component12 </returns>
		public virtual string Component12
		{
			get
			{
				return getComponent(12);
			}
		}

		/// <summary>
		/// Same as getComponent(12) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent12AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component12AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent12AsString()", "Use use #getComponent(int) instead.");
				return getComponent(12);
			}
		}

		/// <summary>
		/// Set the component12. </summary>
		/// <param name="component12"> the component12 to set </param>
		public virtual Field79 setComponent12(string component12)
		{
			setComponent(12, component12);
			return this;
		}
		/// <summary>
		/// Gets the component13 </summary>
		/// <returns> the component13 </returns>
		public virtual string Component13
		{
			get
			{
				return getComponent(13);
			}
		}

		/// <summary>
		/// Same as getComponent(13) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent13AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component13AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent13AsString()", "Use use #getComponent(int) instead.");
				return getComponent(13);
			}
		}

		/// <summary>
		/// Set the component13. </summary>
		/// <param name="component13"> the component13 to set </param>
		public virtual Field79 setComponent13(string component13)
		{
			setComponent(13, component13);
			return this;
		}
		/// <summary>
		/// Gets the component14 </summary>
		/// <returns> the component14 </returns>
		public virtual string Component14
		{
			get
			{
				return getComponent(14);
			}
		}

		/// <summary>
		/// Same as getComponent(14) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent14AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component14AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent14AsString()", "Use use #getComponent(int) instead.");
				return getComponent(14);
			}
		}

		/// <summary>
		/// Set the component14. </summary>
		/// <param name="component14"> the component14 to set </param>
		public virtual Field79 setComponent14(string component14)
		{
			setComponent(14, component14);
			return this;
		}
		/// <summary>
		/// Gets the component15 </summary>
		/// <returns> the component15 </returns>
		public virtual string Component15
		{
			get
			{
				return getComponent(15);
			}
		}

		/// <summary>
		/// Same as getComponent(15) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent15AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component15AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent15AsString()", "Use use #getComponent(int) instead.");
				return getComponent(15);
			}
		}

		/// <summary>
		/// Set the component15. </summary>
		/// <param name="component15"> the component15 to set </param>
		public virtual Field79 setComponent15(string component15)
		{
			setComponent(15, component15);
			return this;
		}
		/// <summary>
		/// Gets the component16 </summary>
		/// <returns> the component16 </returns>
		public virtual string Component16
		{
			get
			{
				return getComponent(16);
			}
		}

		/// <summary>
		/// Same as getComponent(16) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent16AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component16AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent16AsString()", "Use use #getComponent(int) instead.");
				return getComponent(16);
			}
		}

		/// <summary>
		/// Set the component16. </summary>
		/// <param name="component16"> the component16 to set </param>
		public virtual Field79 setComponent16(string component16)
		{
			setComponent(16, component16);
			return this;
		}
		/// <summary>
		/// Gets the component17 </summary>
		/// <returns> the component17 </returns>
		public virtual string Component17
		{
			get
			{
				return getComponent(17);
			}
		}

		/// <summary>
		/// Same as getComponent(17) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent17AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component17AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent17AsString()", "Use use #getComponent(int) instead.");
				return getComponent(17);
			}
		}

		/// <summary>
		/// Set the component17. </summary>
		/// <param name="component17"> the component17 to set </param>
		public virtual Field79 setComponent17(string component17)
		{
			setComponent(17, component17);
			return this;
		}
		/// <summary>
		/// Gets the component18 </summary>
		/// <returns> the component18 </returns>
		public virtual string Component18
		{
			get
			{
				return getComponent(18);
			}
		}

		/// <summary>
		/// Same as getComponent(18) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent18AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component18AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent18AsString()", "Use use #getComponent(int) instead.");
				return getComponent(18);
			}
		}

		/// <summary>
		/// Set the component18. </summary>
		/// <param name="component18"> the component18 to set </param>
		public virtual Field79 setComponent18(string component18)
		{
			setComponent(18, component18);
			return this;
		}
		/// <summary>
		/// Gets the component19 </summary>
		/// <returns> the component19 </returns>
		public virtual string Component19
		{
			get
			{
				return getComponent(19);
			}
		}

		/// <summary>
		/// Same as getComponent(19) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent19AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component19AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent19AsString()", "Use use #getComponent(int) instead.");
				return getComponent(19);
			}
		}

		/// <summary>
		/// Set the component19. </summary>
		/// <param name="component19"> the component19 to set </param>
		public virtual Field79 setComponent19(string component19)
		{
			setComponent(19, component19);
			return this;
		}
		/// <summary>
		/// Gets the component20 </summary>
		/// <returns> the component20 </returns>
		public virtual string Component20
		{
			get
			{
				return getComponent(20);
			}
		}

		/// <summary>
		/// Same as getComponent(20) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent20AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component20AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent20AsString()", "Use use #getComponent(int) instead.");
				return getComponent(20);
			}
		}

		/// <summary>
		/// Set the component20. </summary>
		/// <param name="component20"> the component20 to set </param>
		public virtual Field79 setComponent20(string component20)
		{
			setComponent(20, component20);
			return this;
		}
		/// <summary>
		/// Gets the component21 </summary>
		/// <returns> the component21 </returns>
		public virtual string Component21
		{
			get
			{
				return getComponent(21);
			}
		}

		/// <summary>
		/// Same as getComponent(21) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent21AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component21AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent21AsString()", "Use use #getComponent(int) instead.");
				return getComponent(21);
			}
		}

		/// <summary>
		/// Set the component21. </summary>
		/// <param name="component21"> the component21 to set </param>
		public virtual Field79 setComponent21(string component21)
		{
			setComponent(21, component21);
			return this;
		}
		/// <summary>
		/// Gets the component22 </summary>
		/// <returns> the component22 </returns>
		public virtual string Component22
		{
			get
			{
				return getComponent(22);
			}
		}

		/// <summary>
		/// Same as getComponent(22) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent22AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component22AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent22AsString()", "Use use #getComponent(int) instead.");
				return getComponent(22);
			}
		}

		/// <summary>
		/// Set the component22. </summary>
		/// <param name="component22"> the component22 to set </param>
		public virtual Field79 setComponent22(string component22)
		{
			setComponent(22, component22);
			return this;
		}
		/// <summary>
		/// Gets the component23 </summary>
		/// <returns> the component23 </returns>
		public virtual string Component23
		{
			get
			{
				return getComponent(23);
			}
		}

		/// <summary>
		/// Same as getComponent(23) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent23AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component23AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent23AsString()", "Use use #getComponent(int) instead.");
				return getComponent(23);
			}
		}

		/// <summary>
		/// Set the component23. </summary>
		/// <param name="component23"> the component23 to set </param>
		public virtual Field79 setComponent23(string component23)
		{
			setComponent(23, component23);
			return this;
		}
		/// <summary>
		/// Gets the component24 </summary>
		/// <returns> the component24 </returns>
		public virtual string Component24
		{
			get
			{
				return getComponent(24);
			}
		}

		/// <summary>
		/// Same as getComponent(24) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent24AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component24AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent24AsString()", "Use use #getComponent(int) instead.");
				return getComponent(24);
			}
		}

		/// <summary>
		/// Set the component24. </summary>
		/// <param name="component24"> the component24 to set </param>
		public virtual Field79 setComponent24(string component24)
		{
			setComponent(24, component24);
			return this;
		}
		/// <summary>
		/// Gets the component25 </summary>
		/// <returns> the component25 </returns>
		public virtual string Component25
		{
			get
			{
				return getComponent(25);
			}
		}

		/// <summary>
		/// Same as getComponent(25) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent25AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component25AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent25AsString()", "Use use #getComponent(int) instead.");
				return getComponent(25);
			}
		}

		/// <summary>
		/// Set the component25. </summary>
		/// <param name="component25"> the component25 to set </param>
		public virtual Field79 setComponent25(string component25)
		{
			setComponent(25, component25);
			return this;
		}
		/// <summary>
		/// Gets the component26 </summary>
		/// <returns> the component26 </returns>
		public virtual string Component26
		{
			get
			{
				return getComponent(26);
			}
		}

		/// <summary>
		/// Same as getComponent(26) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent26AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component26AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent26AsString()", "Use use #getComponent(int) instead.");
				return getComponent(26);
			}
		}

		/// <summary>
		/// Set the component26. </summary>
		/// <param name="component26"> the component26 to set </param>
		public virtual Field79 setComponent26(string component26)
		{
			setComponent(26, component26);
			return this;
		}
		/// <summary>
		/// Gets the component27 </summary>
		/// <returns> the component27 </returns>
		public virtual string Component27
		{
			get
			{
				return getComponent(27);
			}
		}

		/// <summary>
		/// Same as getComponent(27) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent27AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component27AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent27AsString()", "Use use #getComponent(int) instead.");
				return getComponent(27);
			}
		}

		/// <summary>
		/// Set the component27. </summary>
		/// <param name="component27"> the component27 to set </param>
		public virtual Field79 setComponent27(string component27)
		{
			setComponent(27, component27);
			return this;
		}
		/// <summary>
		/// Gets the component28 </summary>
		/// <returns> the component28 </returns>
		public virtual string Component28
		{
			get
			{
				return getComponent(28);
			}
		}

		/// <summary>
		/// Same as getComponent(28) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent28AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component28AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent28AsString()", "Use use #getComponent(int) instead.");
				return getComponent(28);
			}
		}

		/// <summary>
		/// Set the component28. </summary>
		/// <param name="component28"> the component28 to set </param>
		public virtual Field79 setComponent28(string component28)
		{
			setComponent(28, component28);
			return this;
		}
		/// <summary>
		/// Gets the component29 </summary>
		/// <returns> the component29 </returns>
		public virtual string Component29
		{
			get
			{
				return getComponent(29);
			}
		}

		/// <summary>
		/// Same as getComponent(29) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent29AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component29AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent29AsString()", "Use use #getComponent(int) instead.");
				return getComponent(29);
			}
		}

		/// <summary>
		/// Set the component29. </summary>
		/// <param name="component29"> the component29 to set </param>
		public virtual Field79 setComponent29(string component29)
		{
			setComponent(29, component29);
			return this;
		}
		/// <summary>
		/// Gets the component30 </summary>
		/// <returns> the component30 </returns>
		public virtual string Component30
		{
			get
			{
				return getComponent(30);
			}
		}

		/// <summary>
		/// Same as getComponent(30) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent30AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component30AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent30AsString()", "Use use #getComponent(int) instead.");
				return getComponent(30);
			}
		}

		/// <summary>
		/// Set the component30. </summary>
		/// <param name="component30"> the component30 to set </param>
		public virtual Field79 setComponent30(string component30)
		{
			setComponent(30, component30);
			return this;
		}
		/// <summary>
		/// Gets the component31 </summary>
		/// <returns> the component31 </returns>
		public virtual string Component31
		{
			get
			{
				return getComponent(31);
			}
		}

		/// <summary>
		/// Same as getComponent(31) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent31AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component31AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent31AsString()", "Use use #getComponent(int) instead.");
				return getComponent(31);
			}
		}

		/// <summary>
		/// Set the component31. </summary>
		/// <param name="component31"> the component31 to set </param>
		public virtual Field79 setComponent31(string component31)
		{
			setComponent(31, component31);
			return this;
		}
		/// <summary>
		/// Gets the component32 </summary>
		/// <returns> the component32 </returns>
		public virtual string Component32
		{
			get
			{
				return getComponent(32);
			}
		}

		/// <summary>
		/// Same as getComponent(32) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent32AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component32AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent32AsString()", "Use use #getComponent(int) instead.");
				return getComponent(32);
			}
		}

		/// <summary>
		/// Set the component32. </summary>
		/// <param name="component32"> the component32 to set </param>
		public virtual Field79 setComponent32(string component32)
		{
			setComponent(32, component32);
			return this;
		}
		/// <summary>
		/// Gets the component33 </summary>
		/// <returns> the component33 </returns>
		public virtual string Component33
		{
			get
			{
				return getComponent(33);
			}
		}

		/// <summary>
		/// Same as getComponent(33) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent33AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component33AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent33AsString()", "Use use #getComponent(int) instead.");
				return getComponent(33);
			}
		}

		/// <summary>
		/// Set the component33. </summary>
		/// <param name="component33"> the component33 to set </param>
		public virtual Field79 setComponent33(string component33)
		{
			setComponent(33, component33);
			return this;
		}
		/// <summary>
		/// Gets the component34 </summary>
		/// <returns> the component34 </returns>
		public virtual string Component34
		{
			get
			{
				return getComponent(34);
			}
		}

		/// <summary>
		/// Same as getComponent(34) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent34AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component34AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent34AsString()", "Use use #getComponent(int) instead.");
				return getComponent(34);
			}
		}

		/// <summary>
		/// Set the component34. </summary>
		/// <param name="component34"> the component34 to set </param>
		public virtual Field79 setComponent34(string component34)
		{
			setComponent(34, component34);
			return this;
		}
		/// <summary>
		/// Gets the component35 </summary>
		/// <returns> the component35 </returns>
		public virtual string Component35
		{
			get
			{
				return getComponent(35);
			}
		}

		/// <summary>
		/// Same as getComponent(35) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent35AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component35AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent35AsString()", "Use use #getComponent(int) instead.");
				return getComponent(35);
			}
		}

		/// <summary>
		/// Set the component35. </summary>
		/// <param name="component35"> the component35 to set </param>
		public virtual Field79 setComponent35(string component35)
		{
			setComponent(35, component35);
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
		   if (component == 10)
		   {
			   return true;
		   }
		   if (component == 11)
		   {
			   return true;
		   }
		   if (component == 12)
		   {
			   return true;
		   }
		   if (component == 13)
		   {
			   return true;
		   }
		   if (component == 14)
		   {
			   return true;
		   }
		   if (component == 15)
		   {
			   return true;
		   }
		   if (component == 16)
		   {
			   return true;
		   }
		   if (component == 17)
		   {
			   return true;
		   }
		   if (component == 18)
		   {
			   return true;
		   }
		   if (component == 19)
		   {
			   return true;
		   }
		   if (component == 20)
		   {
			   return true;
		   }
		   if (component == 21)
		   {
			   return true;
		   }
		   if (component == 22)
		   {
			   return true;
		   }
		   if (component == 23)
		   {
			   return true;
		   }
		   if (component == 24)
		   {
			   return true;
		   }
		   if (component == 25)
		   {
			   return true;
		   }
		   if (component == 26)
		   {
			   return true;
		   }
		   if (component == 27)
		   {
			   return true;
		   }
		   if (component == 28)
		   {
			   return true;
		   }
		   if (component == 29)
		   {
			   return true;
		   }
		   if (component == 30)
		   {
			   return true;
		   }
		   if (component == 31)
		   {
			   return true;
		   }
		   if (component == 32)
		   {
			   return true;
		   }
		   if (component == 33)
		   {
			   return true;
		   }
		   if (component == 34)
		   {
			   return true;
		   }
		   if (component == 35)
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
		/// <returns> the static value of Field79.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field79.COMPONENTS_PATTERN </returns>
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
//ORIGINAL LINE: public static Field79 get(final SwiftTagListBlock block)
		public static Field79 get(SwiftTagListBlock block)
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
			return new Field79(t);
		}

		/// <summary>
		/// Gets the first instance of Field79 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field79 get(final SwiftMessage msg)
		public static Field79 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field79 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field79> getAll(final SwiftMessage msg)
		public static IList<Field79> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field79 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field79> getAll(final SwiftTagListBlock block)
		public static IList<Field79> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field79> result = new java.util.ArrayList<>(arr.length);
				IList<Field79> result = new List<Field79>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field79(f));
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
			return 35;
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
			Field79 cp = newInstance(this);
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
			Field79 cp = newInstance(this);
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
			Field79 cp = newInstance(this);
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
			if (component < 1 || component > 35)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 79");
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
				//default format (as is)
				return getComponent(5);
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
			if (component == 11)
			{
				//default format (as is)
				return getComponent(11);
			}
			if (component == 12)
			{
				//default format (as is)
				return getComponent(12);
			}
			if (component == 13)
			{
				//default format (as is)
				return getComponent(13);
			}
			if (component == 14)
			{
				//default format (as is)
				return getComponent(14);
			}
			if (component == 15)
			{
				//default format (as is)
				return getComponent(15);
			}
			if (component == 16)
			{
				//default format (as is)
				return getComponent(16);
			}
			if (component == 17)
			{
				//default format (as is)
				return getComponent(17);
			}
			if (component == 18)
			{
				//default format (as is)
				return getComponent(18);
			}
			if (component == 19)
			{
				//default format (as is)
				return getComponent(19);
			}
			if (component == 20)
			{
				//default format (as is)
				return getComponent(20);
			}
			if (component == 21)
			{
				//default format (as is)
				return getComponent(21);
			}
			if (component == 22)
			{
				//default format (as is)
				return getComponent(22);
			}
			if (component == 23)
			{
				//default format (as is)
				return getComponent(23);
			}
			if (component == 24)
			{
				//default format (as is)
				return getComponent(24);
			}
			if (component == 25)
			{
				//default format (as is)
				return getComponent(25);
			}
			if (component == 26)
			{
				//default format (as is)
				return getComponent(26);
			}
			if (component == 27)
			{
				//default format (as is)
				return getComponent(27);
			}
			if (component == 28)
			{
				//default format (as is)
				return getComponent(28);
			}
			if (component == 29)
			{
				//default format (as is)
				return getComponent(29);
			}
			if (component == 30)
			{
				//default format (as is)
				return getComponent(30);
			}
			if (component == 31)
			{
				//default format (as is)
				return getComponent(31);
			}
			if (component == 32)
			{
				//default format (as is)
				return getComponent(32);
			}
			if (component == 33)
			{
				//default format (as is)
				return getComponent(33);
			}
			if (component == 34)
			{
				//default format (as is)
				return getComponent(34);
			}
			if (component == 35)
			{
				//default format (as is)
				return getComponent(35);
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
				result.Add("Narrative");
				result.Add("Narrative 2");
				result.Add("Narrative 3");
				result.Add("Narrative 4");
				result.Add("Narrative 5");
				result.Add("Narrative 6");
				result.Add("Narrative 7");
				result.Add("Narrative 8");
				result.Add("Narrative 9");
				result.Add("Narrative 10");
				result.Add("Narrative 11");
				result.Add("Narrative 12");
				result.Add("Narrative 13");
				result.Add("Narrative 14");
				result.Add("Narrative 15");
				result.Add("Narrative 16");
				result.Add("Narrative 17");
				result.Add("Narrative 18");
				result.Add("Narrative 19");
				result.Add("Narrative 20");
				result.Add("Narrative 21");
				result.Add("Narrative 22");
				result.Add("Narrative 23");
				result.Add("Narrative 24");
				result.Add("Narrative 25");
				result.Add("Narrative 26");
				result.Add("Narrative 27");
				result.Add("Narrative 28");
				result.Add("Narrative 29");
				result.Add("Narrative 30");
				result.Add("Narrative 31");
				result.Add("Narrative 32");
				result.Add("Narrative 33");
				result.Add("Narrative 34");
				result.Add("Narrative 35");
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
				result[1] = "narrative";
				result[2] = "narrative2";
				result[3] = "narrative3";
				result[4] = "narrative4";
				result[5] = "narrative5";
				result[6] = "narrative6";
				result[7] = "narrative7";
				result[8] = "narrative8";
				result[9] = "narrative9";
				result[10] = "narrative10";
				result[11] = "narrative11";
				result[12] = "narrative12";
				result[13] = "narrative13";
				result[14] = "narrative14";
				result[15] = "narrative15";
				result[16] = "narrative16";
				result[17] = "narrative17";
				result[18] = "narrative18";
				result[19] = "narrative19";
				result[20] = "narrative20";
				result[21] = "narrative21";
				result[22] = "narrative22";
				result[23] = "narrative23";
				result[24] = "narrative24";
				result[25] = "narrative25";
				result[26] = "narrative26";
				result[27] = "narrative27";
				result[28] = "narrative28";
				result[29] = "narrative29";
				result[30] = "narrative30";
				result[31] = "narrative31";
				result[32] = "narrative32";
				result[33] = "narrative33";
				result[34] = "narrative34";
				result[35] = "narrative35";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field79 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field79 fromJson(final String json)
		public static Field79 fromJson(string json)
		{
			Field79 field = new Field79();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("narrative") != null)
			{
				field.Component1 = jsonObject.get("narrative").AsString;
			}
			if (jsonObject.get("narrative2") != null)
			{
				field.Component2 = jsonObject.get("narrative2").AsString;
			}
			if (jsonObject.get("narrative3") != null)
			{
				field.Component3 = jsonObject.get("narrative3").AsString;
			}
			if (jsonObject.get("narrative4") != null)
			{
				field.Component4 = jsonObject.get("narrative4").AsString;
			}
			if (jsonObject.get("narrative5") != null)
			{
				field.Component5 = jsonObject.get("narrative5").AsString;
			}
			if (jsonObject.get("narrative6") != null)
			{
				field.Component6 = jsonObject.get("narrative6").AsString;
			}
			if (jsonObject.get("narrative7") != null)
			{
				field.Component7 = jsonObject.get("narrative7").AsString;
			}
			if (jsonObject.get("narrative8") != null)
			{
				field.Component8 = jsonObject.get("narrative8").AsString;
			}
			if (jsonObject.get("narrative9") != null)
			{
				field.Component9 = jsonObject.get("narrative9").AsString;
			}
			if (jsonObject.get("narrative10") != null)
			{
				field.Component10 = jsonObject.get("narrative10").AsString;
			}
			if (jsonObject.get("narrative11") != null)
			{
				field.Component11 = jsonObject.get("narrative11").AsString;
			}
			if (jsonObject.get("narrative12") != null)
			{
				field.Component12 = jsonObject.get("narrative12").AsString;
			}
			if (jsonObject.get("narrative13") != null)
			{
				field.Component13 = jsonObject.get("narrative13").AsString;
			}
			if (jsonObject.get("narrative14") != null)
			{
				field.Component14 = jsonObject.get("narrative14").AsString;
			}
			if (jsonObject.get("narrative15") != null)
			{
				field.Component15 = jsonObject.get("narrative15").AsString;
			}
			if (jsonObject.get("narrative16") != null)
			{
				field.Component16 = jsonObject.get("narrative16").AsString;
			}
			if (jsonObject.get("narrative17") != null)
			{
				field.Component17 = jsonObject.get("narrative17").AsString;
			}
			if (jsonObject.get("narrative18") != null)
			{
				field.Component18 = jsonObject.get("narrative18").AsString;
			}
			if (jsonObject.get("narrative19") != null)
			{
				field.Component19 = jsonObject.get("narrative19").AsString;
			}
			if (jsonObject.get("narrative20") != null)
			{
				field.Component20 = jsonObject.get("narrative20").AsString;
			}
			if (jsonObject.get("narrative21") != null)
			{
				field.Component21 = jsonObject.get("narrative21").AsString;
			}
			if (jsonObject.get("narrative22") != null)
			{
				field.Component22 = jsonObject.get("narrative22").AsString;
			}
			if (jsonObject.get("narrative23") != null)
			{
				field.Component23 = jsonObject.get("narrative23").AsString;
			}
			if (jsonObject.get("narrative24") != null)
			{
				field.Component24 = jsonObject.get("narrative24").AsString;
			}
			if (jsonObject.get("narrative25") != null)
			{
				field.Component25 = jsonObject.get("narrative25").AsString;
			}
			if (jsonObject.get("narrative26") != null)
			{
				field.Component26 = jsonObject.get("narrative26").AsString;
			}
			if (jsonObject.get("narrative27") != null)
			{
				field.Component27 = jsonObject.get("narrative27").AsString;
			}
			if (jsonObject.get("narrative28") != null)
			{
				field.Component28 = jsonObject.get("narrative28").AsString;
			}
			if (jsonObject.get("narrative29") != null)
			{
				field.Component29 = jsonObject.get("narrative29").AsString;
			}
			if (jsonObject.get("narrative30") != null)
			{
				field.Component30 = jsonObject.get("narrative30").AsString;
			}
			if (jsonObject.get("narrative31") != null)
			{
				field.Component31 = jsonObject.get("narrative31").AsString;
			}
			if (jsonObject.get("narrative32") != null)
			{
				field.Component32 = jsonObject.get("narrative32").AsString;
			}
			if (jsonObject.get("narrative33") != null)
			{
				field.Component33 = jsonObject.get("narrative33").AsString;
			}
			if (jsonObject.get("narrative34") != null)
			{
				field.Component34 = jsonObject.get("narrative34").AsString;
			}
			if (jsonObject.get("narrative35") != null)
			{
				field.Component35 = jsonObject.get("narrative35").AsString;
			}
			return field;
		}


	}

}