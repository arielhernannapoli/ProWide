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
	/// <strong>SWIFT MT Field 95Q</strong>
	/// <para>
	/// Model and parser for field 95Q of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
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
	/// 		<li>validation pattern: <code>:4!c//35x[$35x]0-3(***)</code></li>
	/// 		<li>parser pattern: <code>:S//S[$S]0-3</code></li>
	/// 		<li>components pattern: <code>SSSSS</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field95Q extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable, com.prowidesoftware.swift.model.field.GenericField, com.prowidesoftware.swift.model.field.MultiLineField
	[Serializable]
	public class Field95Q : Field, com.prowidesoftware.swift.model.field.GenericField, com.prowidesoftware.swift.model.field.MultiLineField
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 95Q
		/// </summary>
		public const string NAME = "95Q";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_95Q = "95Q";
		public const string PARSER_PATTERN = ":S//S[$S]0-3";
		public const string COMPONENTS_PATTERN = "SSSSS";

		/// <summary>
		/// Component number for the Qualifier subfield
		/// </summary>
		public const int? QUALIFIER = 1;

		/// <summary>
		/// Component number for the Name And Address subfield
		/// </summary>
		public const int? NAME_AND_ADDRESS = 2;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field95Q() : base(5)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field95Q(final String value)
		public Field95Q(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field95Q(final com.prowidesoftware.swift.model.Tag tag)
		public Field95Q(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "95Q"))
			{
				throw new System.ArgumentException("cannot create field 95Q from tag " + tag.Name + ", tagname must match the name of the field.");
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
			IList<string> lines = SwiftParseUtils.getLines(value);
			if (lines.Count > 0)
			{
				Component1 = SwiftParseUtils.getTokenFirst(lines[0], ":", "//");
				Component2 = SwiftParseUtils.getTokenSecond(lines[0], "//");
			}
			SwiftParseUtils.setComponentsFromLines(this, 3, null, 1, lines);
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field95Q newInstance(Field95Q source)
		{
			Field95Q cp = new Field95Q();
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
				appendInLines(result, 3, 5);
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
		public virtual Field95Q setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Qualifier (component1). </summary>
		/// <param name="component1"> the Qualifier to set </param>
		public virtual Field95Q setQualifier(string component1)
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
		/// Gets the Name And Address (component2). </summary>
		/// <returns> the Name And Address from component2 </returns>
		public virtual string NameAndAddressLine1
		{
			get
			{
				return getComponent(2);
			}
		}

		/// <summary>
		/// Gets the Name And Address (component3). </summary>
		/// <returns> the Name And Address from component3 </returns>
		public virtual string NameAndAddressLine2
		{
			get
			{
				return getComponent(3);
			}
		}

		/// <summary>
		/// Gets the Name And Address (component4). </summary>
		/// <returns> the Name And Address from component4 </returns>
		public virtual string NameAndAddressLine3
		{
			get
			{
				return getComponent(4);
			}
		}

		/// <summary>
		/// Gets the Name And Address (component5). </summary>
		/// <returns> the Name And Address from component5 </returns>
		public virtual string NameAndAddressLine4
		{
			get
			{
				return getComponent(5);
			}
		}

		/// <summary>
		/// Gets the Name And Address as a concatenation of component2 to component5. </summary>
		/// <returns> the Name And Address from components </returns>
		public virtual string NameAndAddress
		{
			get
			{
				StringBuilder result = new StringBuilder();
				for (int i = 2 ; i < 6 ; i++)
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
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field95Q setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Name And Address (component2). </summary>
		/// <param name="component2"> the Name And Address to set </param>
		public virtual Field95Q setNameAndAddressLine1(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Name And Address (component3). </summary>
		/// <param name="component3"> the Name And Address to set </param>
		public virtual Field95Q setNameAndAddressLine2(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Name And Address (component4). </summary>
		/// <param name="component4"> the Name And Address to set </param>
		public virtual Field95Q setNameAndAddressLine3(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Name And Address (component5). </summary>
		/// <param name="component5"> the Name And Address to set </param>
		public virtual Field95Q setNameAndAddressLine4(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the Name And Address splitting the parameter lines into components 2 to 5. </summary>
		/// <param name="value"> the Name And Address to set, may contain line ends and each line will be set to its correspondent component attribute </param>
		public virtual Field95Q setNameAndAddress(string value)
		{
			IList<string> lines = SwiftParseUtils.getLines(value);
			SwiftParseUtils.setComponentsFromLines(this, 2, 4, 0, lines);
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
		public virtual Field95Q setComponent3(string component3)
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
		public virtual Field95Q setComponent4(string component4)
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
		public virtual Field95Q setComponent5(string component5)
		{
			setComponent(5, component5);
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
		/// <returns> the static value of Field95Q.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field95Q.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return ":4!c//35x[$35x]0-3(***)";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field95Q get(final SwiftTagListBlock block)
		public static Field95Q get(SwiftTagListBlock block)
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
			return new Field95Q(t);
		}

		/// <summary>
		/// Gets the first instance of Field95Q in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field95Q get(final SwiftMessage msg)
		public static Field95Q get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field95Q in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field95Q> getAll(final SwiftMessage msg)
		public static IList<Field95Q> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field95Q from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field95Q> getAll(final SwiftTagListBlock block)
		public static IList<Field95Q> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field95Q> result = new java.util.ArrayList<>(arr.length);
				IList<Field95Q> result = new List<Field95Q>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field95Q(f));
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
			Field95Q cp = newInstance(this);
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
			Field95Q cp = newInstance(this);
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
			Field95Q cp = newInstance(this);
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
			if (component < 1 || component > 5)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 95Q");
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
				result.Add("Name And Address");
				result.Add("Name And Address 2");
				result.Add("Name And Address 3");
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
				result[1] = "qualifier";
				result[2] = "nameAndAddress";
				result[3] = "nameAndAddress2";
				result[4] = "nameAndAddress3";
				result[5] = "nameAndAddress4";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field95Q object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field95Q fromJson(final String json)
		public static Field95Q fromJson(string json)
		{
			Field95Q field = new Field95Q();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("qualifier") != null)
			{
				field.Component1 = jsonObject.get("qualifier").AsString;
			}
			if (jsonObject.get("nameAndAddress") != null)
			{
				field.Component2 = jsonObject.get("nameAndAddress").AsString;
			}
			if (jsonObject.get("nameAndAddress2") != null)
			{
				field.Component3 = jsonObject.get("nameAndAddress2").AsString;
			}
			if (jsonObject.get("nameAndAddress3") != null)
			{
				field.Component4 = jsonObject.get("nameAndAddress3").AsString;
			}
			if (jsonObject.get("nameAndAddress4") != null)
			{
				field.Component5 = jsonObject.get("nameAndAddress4").AsString;
			}
			return field;
		}


	}

}