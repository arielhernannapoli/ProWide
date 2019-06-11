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
	/// <strong>SWIFT MT Field 425</strong>
	/// <para>
	/// Model and parser for field 425 of a SWIFT MT message.
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
	/// 		<li>validation pattern: <code>20*(2!c/37x)</code></li>
	/// 		<li>parser pattern: <code>20*(S/S)</code></li>
	/// 		<li>components pattern: <code>SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field425 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable
	[Serializable]
	public class Field425 : Field
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 425
		/// </summary>
		public const string NAME = "425";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_425 = "425";
		public const string PARSER_PATTERN = "20*(S/S)";
		public const string COMPONENTS_PATTERN = "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS";

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field425() : base(40)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field425(final String value)
		public Field425(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field425(final com.prowidesoftware.swift.model.Tag tag)
		public Field425(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "425"))
			{
				throw new System.ArgumentException("cannot create field 425 from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(40);
			/*
			 * This parser implementation needs review, the actual field format is not clear in the standard:
			 
			 * 422 <MI-message-data-text> 20*(2!c/37x) This field is only for use by Market Infrastructures 
			 * which have subscribed to the Market Infrastructure Resiliency Service (MIRS).
			 *
			 * It is not clear how to split one instance to the other between the 12 occurrences
			 */
			if (value != null)
			{
				string[] tokens = StringUtils.Split(value, "/");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder lastComponent = new StringBuilder();
				StringBuilder lastComponent = new StringBuilder();
				for (int i = 0; i < tokens.Length; i++)
				{
					if (i < 40)
					{
						//set all components sequentially, but the last one
						setComponent(i + 1, tokens[i]);
					}
					else
					{
						//the last component will include all the remaining string
						if (lastComponent.Length > 0)
						{
							lastComponent.Append("/");
						}
						lastComponent.Append(tokens[i]);
					}
				}
				if (lastComponent.Length > 0)
				{
					Component40 = lastComponent.ToString();
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field425 newInstance(Field425 source)
		{
			Field425 cp = new Field425();
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
				//FIXME serialization 20*(S/S)
				// @NotImplemented
				int notImplemented;
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
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field425 setComponent1(string component1)
		{
			setComponent(1, component1);
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
		public virtual Field425 setComponent2(string component2)
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
		public virtual Field425 setComponent3(string component3)
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
		public virtual Field425 setComponent4(string component4)
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
		public virtual Field425 setComponent5(string component5)
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
		public virtual Field425 setComponent6(string component6)
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
		public virtual Field425 setComponent7(string component7)
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
		public virtual Field425 setComponent8(string component8)
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
		public virtual Field425 setComponent9(string component9)
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
		public virtual Field425 setComponent10(string component10)
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
		public virtual Field425 setComponent11(string component11)
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
		public virtual Field425 setComponent12(string component12)
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
		public virtual Field425 setComponent13(string component13)
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
		public virtual Field425 setComponent14(string component14)
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
		public virtual Field425 setComponent15(string component15)
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
		public virtual Field425 setComponent16(string component16)
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
		public virtual Field425 setComponent17(string component17)
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
		public virtual Field425 setComponent18(string component18)
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
		public virtual Field425 setComponent19(string component19)
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
		public virtual Field425 setComponent20(string component20)
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
		public virtual Field425 setComponent21(string component21)
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
		public virtual Field425 setComponent22(string component22)
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
		public virtual Field425 setComponent23(string component23)
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
		public virtual Field425 setComponent24(string component24)
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
		public virtual Field425 setComponent25(string component25)
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
		public virtual Field425 setComponent26(string component26)
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
		public virtual Field425 setComponent27(string component27)
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
		public virtual Field425 setComponent28(string component28)
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
		public virtual Field425 setComponent29(string component29)
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
		public virtual Field425 setComponent30(string component30)
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
		public virtual Field425 setComponent31(string component31)
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
		public virtual Field425 setComponent32(string component32)
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
		public virtual Field425 setComponent33(string component33)
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
		public virtual Field425 setComponent34(string component34)
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
		public virtual Field425 setComponent35(string component35)
		{
			setComponent(35, component35);
			return this;
		}
		/// <summary>
		/// Gets the component36 </summary>
		/// <returns> the component36 </returns>
		public virtual string Component36
		{
			get
			{
				return getComponent(36);
			}
		}

		/// <summary>
		/// Same as getComponent(36) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent36AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component36AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent36AsString()", "Use use #getComponent(int) instead.");
				return getComponent(36);
			}
		}

		/// <summary>
		/// Set the component36. </summary>
		/// <param name="component36"> the component36 to set </param>
		public virtual Field425 setComponent36(string component36)
		{
			setComponent(36, component36);
			return this;
		}
		/// <summary>
		/// Gets the component37 </summary>
		/// <returns> the component37 </returns>
		public virtual string Component37
		{
			get
			{
				return getComponent(37);
			}
		}

		/// <summary>
		/// Same as getComponent(37) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent37AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component37AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent37AsString()", "Use use #getComponent(int) instead.");
				return getComponent(37);
			}
		}

		/// <summary>
		/// Set the component37. </summary>
		/// <param name="component37"> the component37 to set </param>
		public virtual Field425 setComponent37(string component37)
		{
			setComponent(37, component37);
			return this;
		}
		/// <summary>
		/// Gets the component38 </summary>
		/// <returns> the component38 </returns>
		public virtual string Component38
		{
			get
			{
				return getComponent(38);
			}
		}

		/// <summary>
		/// Same as getComponent(38) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent38AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component38AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent38AsString()", "Use use #getComponent(int) instead.");
				return getComponent(38);
			}
		}

		/// <summary>
		/// Set the component38. </summary>
		/// <param name="component38"> the component38 to set </param>
		public virtual Field425 setComponent38(string component38)
		{
			setComponent(38, component38);
			return this;
		}
		/// <summary>
		/// Gets the component39 </summary>
		/// <returns> the component39 </returns>
		public virtual string Component39
		{
			get
			{
				return getComponent(39);
			}
		}

		/// <summary>
		/// Same as getComponent(39) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent39AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component39AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent39AsString()", "Use use #getComponent(int) instead.");
				return getComponent(39);
			}
		}

		/// <summary>
		/// Set the component39. </summary>
		/// <param name="component39"> the component39 to set </param>
		public virtual Field425 setComponent39(string component39)
		{
			setComponent(39, component39);
			return this;
		}
		/// <summary>
		/// Gets the component40 </summary>
		/// <returns> the component40 </returns>
		public virtual string Component40
		{
			get
			{
				return getComponent(40);
			}
		}

		/// <summary>
		/// Same as getComponent(40) </summary>
		/// @deprecated use <seealso cref="#getComponent(int)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getComponent(int)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public java.lang.String getComponent40AsString()
		[Obsolete("use <seealso cref="#getComponent(int)"/> instead")]
		public virtual string Component40AsString
		{
			get
			{
				com.prowidesoftware.deprecation.DeprecationUtils.phase2(this.GetType(), "getComponent40AsString()", "Use use #getComponent(int) instead.");
				return getComponent(40);
			}
		}

		/// <summary>
		/// Set the component40. </summary>
		/// <param name="component40"> the component40 to set </param>
		public virtual Field425 setComponent40(string component40)
		{
			setComponent(40, component40);
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
		/// <returns> the static value of Field425.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field425.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "20*(2!c/37x)";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field425 get(final SwiftTagListBlock block)
		public static Field425 get(SwiftTagListBlock block)
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
			return new Field425(t);
		}

		/// <summary>
		/// Gets the first instance of Field425 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field425 get(final SwiftMessage msg)
		public static Field425 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field425 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field425> getAll(final SwiftMessage msg)
		public static IList<Field425> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field425 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field425> getAll(final SwiftTagListBlock block)
		public static IList<Field425> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field425> result = new java.util.ArrayList<>(arr.length);
				IList<Field425> result = new List<Field425>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field425(f));
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
			return 40;
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
			if (component < 1 || component > 40)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 425");
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
			if (component == 36)
			{
				//default format (as is)
				return getComponent(36);
			}
			if (component == 37)
			{
				//default format (as is)
				return getComponent(37);
			}
			if (component == 38)
			{
				//default format (as is)
				return getComponent(38);
			}
			if (component == 39)
			{
				//default format (as is)
				return getComponent(39);
			}
			if (component == 40)
			{
				//default format (as is)
				return getComponent(40);
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
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
				result.Add(null);
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
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field425 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field425 fromJson(final String json)
		public static Field425 fromJson(string json)
		{
			Field425 field = new Field425();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			return field;
		}


	}

}