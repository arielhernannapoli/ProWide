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
	/// <strong>SWIFT MT Field 343</strong>
	/// <para>
	/// Model and parser for field 343 of a SWIFT MT message.
	/// 
	/// </para>
	/// <para>Subfields (components) Data types
	/// <ol> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// 		<li><code>Number</code></li> 
	/// </ol>
	/// 
	/// </para>
	/// <para>Structure definition
	/// <ul>
	/// 		<li>validation pattern: <code>5!n 5!n 5!n 5!n</code></li>
	/// 		<li>parser pattern: <code>N&lt;SPACE&gt;N&lt;SPACE&gt;N&lt;SPACE&gt;N</code></li>
	/// 		<li>components pattern: <code>NNNN</code></li>
	/// </ul>
	///		 
	/// </para>
	/// <para>
	/// This class complies with standard release <strong>SRU2018</strong>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") @Generated public class Field343 extends com.prowidesoftware.swift.model.field.Field implements java.io.Serializable
	[Serializable]
	public class Field343 : Field
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;

		private const long serialVersionUID = 1L;
		/// <summary>
		/// Constant with the field name 343
		/// </summary>
		public const string NAME = "343";
		/// <summary>
		/// same as NAME, intended to be clear when using static imports
		/// </summary>
		public const string F_343 = "343";
		public const string PARSER_PATTERN = "N<SPACE>N<SPACE>N<SPACE>N";
		public const string COMPONENTS_PATTERN = "NNNN";

		/// <summary>
		/// Component number for the Region Time Count 1 subfield
		/// </summary>
		public const int? REGION_TIME_COUNT_1 = 1;

		/// <summary>
		/// Component number for the Region Time Count 2 subfield
		/// </summary>
		public const int? REGION_TIME_COUNT_2 = 2;

		/// <summary>
		/// Component number for the Region Time Count 3 subfield
		/// </summary>
		public const int? REGION_TIME_COUNT_3 = 3;

		/// <summary>
		/// Component number for the Region Time Count 4 subfield
		/// </summary>
		public const int? REGION_TIME_COUNT_4 = 4;

		/// <summary>
		/// Default constructor. Creates a new field setting all components to null.
		/// </summary>
		public Field343() : base(4)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value. </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field343(final String value)
		public Field343(string value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter tag.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <exception cref="IllegalArgumentException"> if the parameter tag is null or its tagname does not match the field name
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field343(final com.prowidesoftware.swift.model.Tag tag)
		public Field343(Tag tag) : this()
		{
			if (tag == null)
			{
				throw new System.ArgumentException("tag cannot be null.");
			}
			if (!StringUtils.Equals(tag.Name, "343"))
			{
				throw new System.ArgumentException("cannot create field 343 from tag " + tag.Name + ", tagname must match the name of the field.");
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
			init(4);
			string[] values = StringUtils.Split(value);
			if (values != null)
			{
				int component = 1;
				foreach (string v in values)
				{
					setComponent(component, v);
					component++;
				}
			}
		}

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
		public static Field343 newInstance(Field343 source)
		{
			Field343 cp = new Field343();
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
				result.Append(" ");
				append(result, 2);
				result.Append(" ");
				append(result, 3);
				result.Append(" ");
				append(result, 4);
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
		/// Gets the Region Time Count 1 (component1). </summary>
		/// <returns> the Region Time Count 1 from component1 </returns>
		public virtual string getRegionTimeCount1()
		{
			return getComponent(1);
		}

		/// <summary>
		/// Get the Region Time Count 1 (component1) as Number </summary>
		/// <returns> the Region Time Count 1 from component1 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number RegionTimeCount1AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(1));
			}
		}

		/// <summary>
		/// Set the component1. </summary>
		/// <param name="component1"> the component1 to set </param>
		public virtual Field343 setComponent1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the component1 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent1(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent1(String)
		/// </seealso>
		/// <param name="component1"> the Number with the component1 content to set </param>
		public virtual Field343 setComponent1(java.lang.Number component1)
		{
			if (component1 != null)
			{
				setComponent(1, Convert.ToString((int)component1));
			}
			return this;
		}

		/// <summary>
		/// Set the Region Time Count 1 (component1). </summary>
		/// <param name="component1"> the Region Time Count 1 to set </param>
		public virtual Field343 setRegionTimeCount1(string component1)
		{
			setComponent(1, component1);
			return this;
		}

		/// <summary>
		/// Set the Region Time Count 1 (component1) from a Number object. </summary>
		/// <seealso cref= #setComponent1(java.lang.Number) </seealso>
		/// <param name="component1"> Number with the Region Time Count 1 content to set </param>
		public virtual Field343 setRegionTimeCount1(java.lang.Number component1)
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
		/// Gets the Region Time Count 2 (component2). </summary>
		/// <returns> the Region Time Count 2 from component2 </returns>
		public virtual string getRegionTimeCount2()
		{
			return getComponent(2);
		}

		/// <summary>
		/// Get the Region Time Count 2 (component2) as Number </summary>
		/// <returns> the Region Time Count 2 from component2 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number RegionTimeCount2AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(2));
			}
		}

		/// <summary>
		/// Set the component2. </summary>
		/// <param name="component2"> the component2 to set </param>
		public virtual Field343 setComponent2(string component2)
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
		public virtual Field343 setComponent2(java.lang.Number component2)
		{
			if (component2 != null)
			{
				setComponent(2, Convert.ToString((int)component2));
			}
			return this;
		}

		/// <summary>
		/// Set the Region Time Count 2 (component2). </summary>
		/// <param name="component2"> the Region Time Count 2 to set </param>
		public virtual Field343 setRegionTimeCount2(string component2)
		{
			setComponent(2, component2);
			return this;
		}

		/// <summary>
		/// Set the Region Time Count 2 (component2) from a Number object. </summary>
		/// <seealso cref= #setComponent2(java.lang.Number) </seealso>
		/// <param name="component2"> Number with the Region Time Count 2 content to set </param>
		public virtual Field343 setRegionTimeCount2(java.lang.Number component2)
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
		/// Get the component3 as Number </summary>
		/// <returns> the component3 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number Component3AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(3));
			}
		}

		/// <summary>
		/// Gets the Region Time Count 3 (component3). </summary>
		/// <returns> the Region Time Count 3 from component3 </returns>
		public virtual string getRegionTimeCount3()
		{
			return getComponent(3);
		}

		/// <summary>
		/// Get the Region Time Count 3 (component3) as Number </summary>
		/// <returns> the Region Time Count 3 from component3 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number RegionTimeCount3AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(3));
			}
		}

		/// <summary>
		/// Set the component3. </summary>
		/// <param name="component3"> the component3 to set </param>
		public virtual Field343 setComponent3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the component3 from a Number object.
		/// <br>
		/// <em>If the component being set is a fixed length number, the argument will not be 
		/// padded.</em> It is recommended for these cases to use the setComponent3(String) 
		/// method.
		/// </summary>
		/// <seealso cref= #setComponent3(String)
		/// </seealso>
		/// <param name="component3"> the Number with the component3 content to set </param>
		public virtual Field343 setComponent3(java.lang.Number component3)
		{
			if (component3 != null)
			{
				setComponent(3, Convert.ToString((int)component3));
			}
			return this;
		}

		/// <summary>
		/// Set the Region Time Count 3 (component3). </summary>
		/// <param name="component3"> the Region Time Count 3 to set </param>
		public virtual Field343 setRegionTimeCount3(string component3)
		{
			setComponent(3, component3);
			return this;
		}

		/// <summary>
		/// Set the Region Time Count 3 (component3) from a Number object. </summary>
		/// <seealso cref= #setComponent3(java.lang.Number) </seealso>
		/// <param name="component3"> Number with the Region Time Count 3 content to set </param>
		public virtual Field343 setRegionTimeCount3(java.lang.Number component3)
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
		/// Gets the Region Time Count 4 (component4). </summary>
		/// <returns> the Region Time Count 4 from component4 </returns>
		public virtual string getRegionTimeCount4()
		{
			return getComponent(4);
		}

		/// <summary>
		/// Get the Region Time Count 4 (component4) as Number </summary>
		/// <returns> the Region Time Count 4 from component4 converted to Number or null if cannot be converted </returns>
		public virtual java.lang.Number RegionTimeCount4AsNumber
		{
			get
			{
				return SwiftFormatUtils.getNumber(getComponent(4));
			}
		}

		/// <summary>
		/// Set the component4. </summary>
		/// <param name="component4"> the component4 to set </param>
		public virtual Field343 setComponent4(string component4)
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
		public virtual Field343 setComponent4(java.lang.Number component4)
		{
			if (component4 != null)
			{
				setComponent(4, Convert.ToString((int)component4));
			}
			return this;
		}

		/// <summary>
		/// Set the Region Time Count 4 (component4). </summary>
		/// <param name="component4"> the Region Time Count 4 to set </param>
		public virtual Field343 setRegionTimeCount4(string component4)
		{
			setComponent(4, component4);
			return this;
		}

		/// <summary>
		/// Set the Region Time Count 4 (component4) from a Number object. </summary>
		/// <seealso cref= #setComponent4(java.lang.Number) </seealso>
		/// <param name="component4"> Number with the Region Time Count 4 content to set </param>
		public virtual Field343 setRegionTimeCount4(java.lang.Number component4)
		{
			setComponent4(component4);
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
		/// <returns> the static value of Field343.NAME </returns>
		public override string Name
		{
			get
			{
				return NAME;
			}
		}

		/// <summary>
		/// Returns the field's components pattern </summary>
		/// <returns> the static value of Field343.COMPONENTS_PATTERN </returns>
		public override sealed string componentsPattern()
		{
			return COMPONENTS_PATTERN;
		}

		/// <summary>
		/// Returns the field's validators pattern
		/// </summary>
		public override sealed string validatorPattern()
		{
			return "5!n 5!n 5!n 5!n";
		}

		/// <summary>
		/// Gets the first occurrence form the tag list or null if not found. </summary>
		/// <returns> null if not found o block is null or empty </returns>
		/// <param name="block"> may be null or empty  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field343 get(final SwiftTagListBlock block)
		public static Field343 get(SwiftTagListBlock block)
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
			return new Field343(t);
		}

		/// <summary>
		/// Gets the first instance of Field343 in the given message. </summary>
		/// <param name="msg"> may be empty or null </param>
		/// <returns> null if not found or msg is empty or null </returns>
		/// <seealso cref= #get(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field343 get(final SwiftMessage msg)
		public static Field343 get(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return null;
			}
			return get(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field343 in the given message
		/// an empty list is returned if none found. </summary>
		/// <param name="msg"> may be empty or null in which case an empty list is returned </param>
		/// <seealso cref= #getAll(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field343> getAll(final SwiftMessage msg)
		public static IList<Field343> getAll(SwiftMessage msg)
		{
			if (msg == null || msg.Block4 == null || msg.Block4.Empty)
			{
				return java.util.Collections.emptyList();
			}
			return getAll(msg.Block4);
		}

		/// <summary>
		/// Gets a list of all occurrences of the field Field343 from the given block
		/// an empty list is returned if none found.
		/// </summary>
		/// <param name="block"> may be empty or null in which case an empty list is returned  </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<Field343> getAll(final SwiftTagListBlock block)
		public static IList<Field343> getAll(SwiftTagListBlock block)
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
//ORIGINAL LINE: final java.util.List<Field343> result = new java.util.ArrayList<>(arr.length);
				IList<Field343> result = new List<Field343>(arr.Length);
				foreach (Tag f in arr)
				{
					result.Add(new Field343(f));
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
			return 4;
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
			if (component < 1 || component > 4)
			{
				throw new System.ArgumentException("invalid component number " + component + " for field 343");
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
				//number, amount, rate
				java.text.NumberFormat f = java.text.NumberFormat.getNumberInstance(notNull(locale));
				f.MaximumFractionDigits = 13;
				Number n = Component3AsNumber;
				if (n != null)
				{
					return f.format(n);
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
				result.Add("Region Time Count 1");
				result.Add("Region Time Count 2");
				result.Add("Region Time Count 3");
				result.Add("Region Time Count 4");
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
				result[1] = "regionTimeCount1";
				result[2] = "regionTimeCount2";
				result[3] = "regionTimeCount3";
				result[4] = "regionTimeCount4";
				return result;
			}
		}

		/// <summary>
		/// This method deserializes the JSON data into a Field343 object. </summary>
		/// <param name="json"> JSON structure including tuples with label and value for all field components </param>
		/// <returns> a new field instance with the JSON data parsed into field components or an empty field id the JSON is invalid
		/// @since 7.10.3 </returns>
		/// <seealso cref= Field#fromJson(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field343 fromJson(final String json)
		public static Field343 fromJson(string json)
		{
			Field343 field = new Field343();
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			if (jsonObject.get("regionTimeCount1") != null)
			{
				field.setComponent1(jsonObject.get("regionTimeCount1").AsString);
			}
			if (jsonObject.get("regionTimeCount2") != null)
			{
				field.setComponent2(jsonObject.get("regionTimeCount2").AsString);
			}
			if (jsonObject.get("regionTimeCount3") != null)
			{
				field.setComponent3(jsonObject.get("regionTimeCount3").AsString);
			}
			if (jsonObject.get("regionTimeCount4") != null)
			{
				field.setComponent4(jsonObject.get("regionTimeCount4").AsString);
			}
			return field;
		}


	}

}