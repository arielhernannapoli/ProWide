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
	/// <strong>SWIFT MT Field 77</strong>
	/// <para>
	/// Model and parser for field 77 of a SWIFT MT message.
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
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>35z[$35z]0-19</code></li>
	/// 		<li>parser pattern: <code>S[$S]0-19</code></li>
	/// 		<li>components pattern: <code>SSSSSSSSSSSSSSSSSSSS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field77 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.MultiLineField
	[Serializable]
	public class Field77 : Field, com.prowidesoftware.swift.model.field.MultiLineField
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 77
		/// </summary>
		public const string NAME = "77";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_77 = "77";
		public const string PARSER_PATTERN = "S[$S]0-19";
		public const string COMPONENTS_PATTERN = "SSSSSSSSSSSSSSSSSSSS";

		/// <summary>
		/// Component number for the Narrative subfield
		/// </summary>
		public const int? NARRATIVE = 1;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field77() : base(20)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field77(final String value)
		public Field77(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field77(final com.prowidesoftware.swift.model.Tag tag)
		public Field77(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "77"))
			{
				throw new System.ArgumentException("cannot create field 77 from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(20);
			IList<string> lines = SwiftParseUtils.getLines(value);
			SwiftParseUtils.setComponentsFromLines(this, 1, null, 0, lines);
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field77 newInstance(Field77 source)
		{
			Field77 cp = new Field77();
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
				appendInLines(result, 1, 20);
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
		/// Gets the Narrative as a concatenation of component1 to component20. </summary>
		/// <returns> the Narrative from components </returns>
		public virtual string Narrative
		{
			get
			{
				StringBuilder result = new StringBuilder();
				for (int i = 1 ; i < 21 ; i++)
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
		public virtual Field77 setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component1). </summary>
		/// <param name="component1"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component2). </summary>
		/// <param name="component2"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component3). </summary>
		/// <param name="component3"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component4). </summary>
		/// <param name="component4"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component5). </summary>
		/// <param name="component5"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component6). </summary>
		/// <param name="component6"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine6(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component7). </summary>
		/// <param name="component7"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine7(string component7)
		{
			setComponent(7, component7);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component8). </summary>
		/// <param name="component8"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine8(string component8)
		{
			setComponent(8, component8);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component9). </summary>
		/// <param name="component9"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine9(string component9)
		{
			setComponent(9, component9);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component10). </summary>
		/// <param name="component10"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine10(string component10)
		{
			setComponent(10, component10);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component11). </summary>
		/// <param name="component11"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine11(string component11)
		{
			setComponent(11, component11);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component12). </summary>
		/// <param name="component12"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine12(string component12)
		{
			setComponent(12, component12);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component13). </summary>
		/// <param name="component13"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine13(string component13)
		{
			setComponent(13, component13);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component14). </summary>
		/// <param name="component14"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine14(string component14)
		{
			setComponent(14, component14);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component15). </summary>
		/// <param name="component15"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine15(string component15)
		{
			setComponent(15, component15);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component16). </summary>
		/// <param name="component16"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine16(string component16)
		{
			setComponent(16, component16);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component17). </summary>
		/// <param name="component17"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine17(string component17)
		{
			setComponent(17, component17);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component18). </summary>
		/// <param name="component18"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine18(string component18)
		{
			setComponent(18, component18);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component19). </summary>
		/// <param name="component19"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine19(string component19)
		{
			setComponent(19, component19);
			return this;
		}

		/// <summary>
		/// Set the Narrative (component20). </summary>
		/// <param name="component20"> the Narrative to set </param>
		public virtual Field77 setNarrativeLine20(string component20)
		{
			setComponent(20, component20);
			return this;
		}

		/// <summary>
		/// Set the Narrative splitting the parameter lines into components 1 to 20. </summary>
		/// <param name="value"> the Narrative to set, may contain line ends and each line will be set to its correspondent component attribute </param>
		public virtual Field77 setNarrative(string value)
		{
			IList<string> lines = SwiftParseUtils.getLines(value);
			SwiftParseUtils.setComponentsFromLines(this, 1, 20, 0, lines);
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
		public virtual Field77 setComponent2(string component2)
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
		public virtual Field77 setComponent3(string component3)
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
		public virtual Field77 setComponent4(string component4)
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
		public virtual Field77 setComponent5(string component5)
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
		public virtual Field77 setComponent6(string component6)
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
		public virtual Field77 setComponent7(string component7)
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
		public virtual Field77 setComponent8(string component8)
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
		public virtual Field77 setComponent9(string component9)
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
		public virtual Field77 setComponent10(string component10)
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
		public virtual Field77 setComponent11(string component11)
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
		public virtual Field77 setComponent12(string component12)
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
		public virtual Field77 setComponent13(string component13)
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
		public virtual Field77 setComponent14(string component14)
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
		public virtual Field77 setComponent15(string component15)
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
		public virtual Field77 setComponent16(string component16)
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
		public virtual Field77 setComponent17(string component17)
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
		public virtual Field77 setComponent18(string component18)
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
		public virtual Field77 setComponent19(string component19)
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
		public virtual Field77 setComponent20(string component20)
		{
			setComponent(20, component20);
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
		/// <returns> the static value of Field77.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field77.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "35z[$35z]0-19";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field77 get(final SwiftTagListBlock block)
		public static Field77 get(SwiftTagListBlock block)
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
			return new Field77(t);
		}

		/// <summary>
		/// Gets the first instance of Field77 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field77 get(final SwiftMessage msg)
		public static Field77 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field77 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field77> getAll(final SwiftMessage msg)
		public static IList<Field77> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field77 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field77> getAll(final SwiftTagListBlock block)
		public static IList<Field77> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field77> result = new java.util.ArrayList<>(arr.length);
				IList<Field77> result = new List<Field77>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field77(f));
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
			return 20;
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
			Field77 cp = newInstance(this);
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
			Field77 cp = newInstance(this);
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
			Field77 cp = newInstance(this);
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
			if (component < 1 || component > 20)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 77");
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
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field77 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field77 fromJson(final String json)
		public static Field77 fromJson(string json)
		{
			Field77 field = new Field77();
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
			return field;
		}


	}

}