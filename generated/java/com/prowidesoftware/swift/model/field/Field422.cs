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
	/// <strong>SWIFT MT Field 422</strong>
	/// <para>
	/// Model and parser for field 422 of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// 		<li><code>Character</code></li> 
	/// 		<li><code>String</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>12*(1!c/38x)</code></li>
	/// 		<li>parser pattern: <code>12*(S/S)</code></li>
	/// 		<li>components pattern: <code>cScScScScScScScScScScScS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field422 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable
	[Serializable]
	public class Field422 : Field
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 422
		/// </summary>
		public const string NAME = "422";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_422 = "422";
		public const string PARSER_PATTERN = "12*(S/S)";
		public const string COMPONENTS_PATTERN = "cScScScScScScScScScScScS";

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field422() : base(24)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field422(final String value)
		public Field422(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field422(final com.prowidesoftware.swift.model.Tag tag)
		public Field422(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "422"))
			{
				throw new System.ArgumentException("cannot create field 422 from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(24);
			/*
			 * This parser implementation needs review, the actual field format is not clear in the standard:
			 
			 * 422 <copy-message-data-text> 12*(1!c/38x) This field is only for use by Market Infrastructures 
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
					if (i < 24)
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
					Component24 = lastComponent.ToString();
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field422 newInstance(Field422 source)
		{
			Field422 cp = new Field422();
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
				//FIXME serialization 12*(S/S)
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
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field422 setComponent1(string component1)
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
		public virtual Field422 setComponent2(string component2)
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
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field422 setComponent3(string component3)
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
		public virtual Field422 setComponent4(string component4)
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
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field422 setComponent5(string component5)
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
		public virtual Field422 setComponent6(string component6)
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
		/// Set the component7. </summary>
		/// <param name="component7"> the component7 to set </param>
		public virtual Field422 setComponent7(string component7)
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
		public virtual Field422 setComponent8(string component8)
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
		/// Set the component9. </summary>
		/// <param name="component9"> the component9 to set </param>
		public virtual Field422 setComponent9(string component9)
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
		public virtual Field422 setComponent10(string component10)
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
		/// Set the component11. </summary>
		/// <param name="component11"> the component11 to set </param>
		public virtual Field422 setComponent11(string component11)
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
		public virtual Field422 setComponent12(string component12)
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
		/// Set the component13. </summary>
		/// <param name="component13"> the component13 to set </param>
		public virtual Field422 setComponent13(string component13)
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
		public virtual Field422 setComponent14(string component14)
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
		/// Set the component15. </summary>
		/// <param name="component15"> the component15 to set </param>
		public virtual Field422 setComponent15(string component15)
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
		public virtual Field422 setComponent16(string component16)
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
		/// Set the component17. </summary>
		/// <param name="component17"> the component17 to set </param>
		public virtual Field422 setComponent17(string component17)
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
		public virtual Field422 setComponent18(string component18)
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
		/// Set the component19. </summary>
		/// <param name="component19"> the component19 to set </param>
		public virtual Field422 setComponent19(string component19)
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
		public virtual Field422 setComponent20(string component20)
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
		/// Set the component21. </summary>
		/// <param name="component21"> the component21 to set </param>
		public virtual Field422 setComponent21(string component21)
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
		public virtual Field422 setComponent22(string component22)
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
		/// Set the component23. </summary>
		/// <param name="component23"> the component23 to set </param>
		public virtual Field422 setComponent23(string component23)
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
		public virtual Field422 setComponent24(string component24)
		{
			setComponent(24, component24);
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
		/// <returns> the static value of Field422.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field422.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "12*(1!c/38x)";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field422 get(final SwiftTagListBlock block)
		public static Field422 get(SwiftTagListBlock block)
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
			return new Field422(t);
		}

		/// <summary>
		/// Gets the first instance of Field422 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field422 get(final SwiftMessage msg)
		public static Field422 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field422 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field422> getAll(final SwiftMessage msg)
		public static IList<Field422> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field422 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field422> getAll(final SwiftTagListBlock block)
		public static IList<Field422> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field422> result = new java.util.ArrayList<>(arr.length);
				IList<Field422> result = new List<Field422>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field422(f));
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
			return 24;
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
			if (component < 1 || component > 24)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 422");
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
		/// This method deserializes the JSON data into a Field422 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field422 fromJson(final String json)
		public static Field422 fromJson(string json)
		{
			Field422 field = new Field422();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			return field;
		}


	}

}