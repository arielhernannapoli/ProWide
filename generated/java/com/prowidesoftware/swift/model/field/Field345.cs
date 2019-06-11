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
	/// <strong>SWIFT MT Field 345</strong>
	/// <para>
	/// Model and parser for field 345 of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
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
	/// 		<li>validation pattern: <code>[3!c]*10</code></li>
	/// 		<li>parser pattern: <code>3!S*10</code></li>
	/// 		<li>components pattern: <code>MMMMMMMMMM</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field345 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable
	[Serializable]
	public class Field345 : Field
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 345
		/// </summary>
		public const string NAME = "345";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_345 = "345";
		public const string PARSER_PATTERN = "3!S*10";
		public const string COMPONENTS_PATTERN = "MMMMMMMMMM";

		/// <summary>
		/// Component number for the MT1 subfield
		/// </summary>
		public const int? MT1_Renamed = 1;

		/// <summary>
		/// Component number for the MT2 subfield
		/// </summary>
		public const int? MT2_Renamed = 2;

		/// <summary>
		/// Component number for the MT3 subfield
		/// </summary>
		public const int? MT3_Renamed = 3;

		/// <summary>
		/// Component number for the MT4 subfield
		/// </summary>
		public const int? MT4_Renamed = 4;

		/// <summary>
		/// Component number for the MT5 subfield
		/// </summary>
		public const int? MT5_Renamed = 5;

		/// <summary>
		/// Component number for the MT6 subfield
		/// </summary>
		public const int? MT6_Renamed = 6;

		/// <summary>
		/// Component number for the MT7 subfield
		/// </summary>
		public const int? MT7_Renamed = 7;

		/// <summary>
		/// Component number for the MT8 subfield
		/// </summary>
		public const int? MT8_Renamed = 8;

		/// <summary>
		/// Component number for the MT9 subfield
		/// </summary>
		public const int? MT9_Renamed = 9;

		/// <summary>
		/// Component number for the MT10 subfield
		/// </summary>
		public const int? MT10_Renamed = 10;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field345() : base(10)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field345(final String value)
		public Field345(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field345(final com.prowidesoftware.swift.model.Tag tag)
		public Field345(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "345"))
			{
				throw new System.ArgumentException("cannot create field 345 from tag " + tag.Name + ", tagname must match the name of the field.");
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
			if (value != null)
			{
				SwiftParseUtils.setComponentsFromTokens(this, 1, 10, 3, value);
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field345 newInstance(Field345 source)
		{
			Field345 cp = new Field345();
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
		public virtual string Component1
		{
			get
			{
				return getComponent(1);
			}
		}

		/// <summary>
		/// Gets the MT1 (component1). </summary>
		/// <returns> the MT1 from component1 </returns>
		public virtual string MT1
		{
			get
			{
				return getComponent(1);
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field345 setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the MT1 (component1). </summary>
		/// <param name="component1"> the MT1 to set </param>
		public virtual Field345 setMT1(string component1)
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
		/// Gets the MT2 (component2). </summary>
		/// <returns> the MT2 from component2 </returns>
		public virtual string MT2
		{
			get
			{
				return getComponent(2);
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field345 setComponent2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the MT2 (component2). </summary>
		/// <param name="component2"> the MT2 to set </param>
		public virtual Field345 setMT2(string component2)
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
		/// Gets the MT3 (component3). </summary>
		/// <returns> the MT3 from component3 </returns>
		public virtual string MT3
		{
			get
			{
				return getComponent(3);
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field345 setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the MT3 (component3). </summary>
		/// <param name="component3"> the MT3 to set </param>
		public virtual Field345 setMT3(string component3)
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
		/// Gets the MT4 (component4). </summary>
		/// <returns> the MT4 from component4 </returns>
		public virtual string MT4
		{
			get
			{
				return getComponent(4);
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field345 setComponent4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the MT4 (component4). </summary>
		/// <param name="component4"> the MT4 to set </param>
		public virtual Field345 setMT4(string component4)
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
		/// Gets the MT5 (component5). </summary>
		/// <returns> the MT5 from component5 </returns>
		public virtual string MT5
		{
			get
			{
				return getComponent(5);
			}
		}

		/// <summary>
		/// Set the component5. </summary>
		/// <param name="component5"> the component5 to set </param>
		public virtual Field345 setComponent5(string component5)
		{
			setComponent(5, component5);
			return this;
		}

		/// <summary>
		/// Set the MT5 (component5). </summary>
		/// <param name="component5"> the MT5 to set </param>
		public virtual Field345 setMT5(string component5)
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
		/// Gets the MT6 (component6). </summary>
		/// <returns> the MT6 from component6 </returns>
		public virtual string MT6
		{
			get
			{
				return getComponent(6);
			}
		}

		/// <summary>
		/// Set the component6. </summary>
		/// <param name="component6"> the component6 to set </param>
		public virtual Field345 setComponent6(string component6)
		{
			setComponent(6, component6);
			return this;
		}

		/// <summary>
		/// Set the MT6 (component6). </summary>
		/// <param name="component6"> the MT6 to set </param>
		public virtual Field345 setMT6(string component6)
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
		/// Gets the MT7 (component7). </summary>
		/// <returns> the MT7 from component7 </returns>
		public virtual string MT7
		{
			get
			{
				return getComponent(7);
			}
		}

		/// <summary>
		/// Set the component7. </summary>
		/// <param name="component7"> the component7 to set </param>
		public virtual Field345 setComponent7(string component7)
		{
			setComponent(7, component7);
			return this;
		}

		/// <summary>
		/// Set the MT7 (component7). </summary>
		/// <param name="component7"> the MT7 to set </param>
		public virtual Field345 setMT7(string component7)
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
		/// Gets the MT8 (component8). </summary>
		/// <returns> the MT8 from component8 </returns>
		public virtual string MT8
		{
			get
			{
				return getComponent(8);
			}
		}

		/// <summary>
		/// Set the component8. </summary>
		/// <param name="component8"> the component8 to set </param>
		public virtual Field345 setComponent8(string component8)
		{
			setComponent(8, component8);
			return this;
		}

		/// <summary>
		/// Set the MT8 (component8). </summary>
		/// <param name="component8"> the MT8 to set </param>
		public virtual Field345 setMT8(string component8)
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
		/// Gets the MT9 (component9). </summary>
		/// <returns> the MT9 from component9 </returns>
		public virtual string MT9
		{
			get
			{
				return getComponent(9);
			}
		}

		/// <summary>
		/// Set the component9. </summary>
		/// <param name="component9"> the component9 to set </param>
		public virtual Field345 setComponent9(string component9)
		{
			setComponent(9, component9);
			return this;
		}

		/// <summary>
		/// Set the MT9 (component9). </summary>
		/// <param name="component9"> the MT9 to set </param>
		public virtual Field345 setMT9(string component9)
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
		/// Gets the MT10 (component10). </summary>
		/// <returns> the MT10 from component10 </returns>
		public virtual string MT10
		{
			get
			{
				return getComponent(10);
			}
		}

		/// <summary>
		/// Set the component10. </summary>
		/// <param name="component10"> the component10 to set </param>
		public virtual Field345 setComponent10(string component10)
		{
			setComponent(10, component10);
			return this;
		}

		/// <summary>
		/// Set the MT10 (component10). </summary>
		/// <param name="component10"> the MT10 to set </param>
		public virtual Field345 setMT10(string component10)
		{
			setComponent(10, component10);
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
		/// <returns> the static value of Field345.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field345.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "[3!c]*10";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field345 get(final SwiftTagListBlock block)
		public static Field345 get(SwiftTagListBlock block)
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
			return new Field345(t);
		}

		/// <summary>
		/// Gets the first instance of Field345 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field345 get(final SwiftMessage msg)
		public static Field345 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field345 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field345> getAll(final SwiftMessage msg)
		public static IList<Field345> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field345 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field345> getAll(final SwiftTagListBlock block)
		public static IList<Field345> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field345> result = new java.util.ArrayList<>(arr.length);
				IList<Field345> result = new List<Field345>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field345(f));
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
				throw new System.ArgumentException("invalid component number " + component + " for field 345");
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
				result.Add("MT1");
				result.Add("MT2");
				result.Add("MT3");
				result.Add("MT4");
				result.Add("MT5");
				result.Add("MT6");
				result.Add("MT7");
				result.Add("MT8");
				result.Add("MT9");
				result.Add("MT10");
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
				result[1] = "mT1";
				result[2] = "mT2";
				result[3] = "mT3";
				result[4] = "mT4";
				result[5] = "mT5";
				result[6] = "mT6";
				result[7] = "mT7";
				result[8] = "mT8";
				result[9] = "mT9";
				result[10] = "mT10";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field345 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field345 fromJson(final String json)
		public static Field345 fromJson(string json)
		{
			Field345 field = new Field345();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("mT1") != null)
			{
				field.Component1 = jsonObject.get("mT1").AsString;
			}
			if (jsonObject.get("mT2") != null)
			{
				field.Component2 = jsonObject.get("mT2").AsString;
			}
			if (jsonObject.get("mT3") != null)
			{
				field.Component3 = jsonObject.get("mT3").AsString;
			}
			if (jsonObject.get("mT4") != null)
			{
				field.Component4 = jsonObject.get("mT4").AsString;
			}
			if (jsonObject.get("mT5") != null)
			{
				field.Component5 = jsonObject.get("mT5").AsString;
			}
			if (jsonObject.get("mT6") != null)
			{
				field.Component6 = jsonObject.get("mT6").AsString;
			}
			if (jsonObject.get("mT7") != null)
			{
				field.Component7 = jsonObject.get("mT7").AsString;
			}
			if (jsonObject.get("mT8") != null)
			{
				field.Component8 = jsonObject.get("mT8").AsString;
			}
			if (jsonObject.get("mT9") != null)
			{
				field.Component9 = jsonObject.get("mT9").AsString;
			}
			if (jsonObject.get("mT10") != null)
			{
				field.Component10 = jsonObject.get("mT10").AsString;
			}
			return field;
		}


	}

}