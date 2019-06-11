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
namespace com.prowidesoftware.swift.model
{

	using Gson = com.google.gson.Gson;
	using GsonBuilder = com.google.gson.GsonBuilder;
	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using Field = com.prowidesoftware.swift.model.field.Field;
	using Field16R = com.prowidesoftware.swift.model.field.Field16R;
	using Field16S = com.prowidesoftware.swift.model.field.Field16S;
	using GenericField = com.prowidesoftware.swift.model.field.GenericField;
	using ArrayUtils = org.apache.commons.lang3.ArrayUtils;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Base class for SWIFT blocks that contain and arbitrary <b>set of fields</b> (3, 4, 5 and user blocks).<br>
	/// Specific block classes for each block should be instantiated.
	/// 
	/// @since 4.0
	/// </summary>
	[Serializable]
	public class SwiftTagListBlock : SwiftBlock, IEnumerable<Tag>
	{
		private const long serialVersionUID = -3753513588165638610L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftTagListBlock).FullName);
		private const string TAG_VALIDATION_MESSAGE = "parameter 'tag' cannot not be null";
		private const string NAME_VALIDATION_MESSAGE = "parameter 'name' cannot not be null";
		/// <summary>
		/// <em>Immutable</em>empty instance of this class.
		/// </summary>
		public static readonly SwiftTagListBlock EMPTY_LIST = emptyList();

		/// <summary>
		/// Contains instances of Tag in this block, used to store the block's fields. </summary>
		/// <seealso cref= Tag </seealso>
		private IList<Tag> tags = new List<Tag>();

		/// <summary>
		/// Default constructor, shouldn't be used normally.
		/// present only for subclasses
		/// </summary>
		public SwiftTagListBlock() : base()
		{
		}

		/// <summary>
		/// Intended to be used by search results in this class
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock(final List<Tag> tags)
		public SwiftTagListBlock(IList<Tag> tags) : this()
		{
			this.tags = tags;
		}

		/// <summary>
		/// Return an <em>immutable</em> empty list
		/// Only to initialize EMPTY_LIST constant private to avoid creating new objects for empty immutable lists
		/// @since 7.7
		/// </summary>
		private static SwiftTagListBlock emptyList()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<Tag> tagList = Collections.emptyList();
			IList<Tag> tagList = java.util.Collections.emptyList();
			return new SwiftTagListBlock(tagList);
		}

		/// <summary>
		/// Empty iterator to be used when an API that returns an Iterator does not return null.
		/// </summary>
		private sealed class EmptyItr : IEnumerator<Tag>
		{
			public bool hasNext()
			{
				return false;
			}

			public Tag next()
			{
				throw new NoSuchElementException();
			}

			public void remove()
			{
				throw new System.NotSupportedException("Can't remove on an empty iterator");
			}
		}

		/// <summary>
		/// Gets the internal List of tags in block. </summary>
		/// <returns> a List of Tag </returns>
		/// <seealso cref= Tag </seealso>
		public virtual IList<Tag> getTags()
		{
			return this.tags;
		}

		/// <summary>
		/// Iterate through tags in this block and return the first tag whose name matches the parameter.
		/// </summary>
		/// <param name="name"> the tag name to search, for example "32A" or "58" (letter option wildcard 'a' is not supported) </param>
		/// <returns> the first tag with the given name or null if none is found </returns>
		/// <exception cref="IllegalArgumentException"> if the name parameter is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Tag getTagByName(final String name)
		public virtual Tag getTagByName(string name)
		{
			Validate.notNull(name, NAME_VALIDATION_MESSAGE);
			foreach (Tag tag in this.tags)
			{
				if (StringUtils.Equals(tag.Name, name))
				{
					return tag;
				}
			}
			return null;
		}

		/// <summary>
		/// Gets the Tag at the given index in this block.
		/// </summary>
		/// <param name="index"> the index position of the tag to retrieve (zero based) </param>
		/// <returns> the Tag at the given index </returns>
		/// <exception cref="IndexOutOfBoundsException"> if the index is out of range </exception>
		/// <seealso cref= List#get(int) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Tag getTag(final int index)
		public virtual Tag getTag(int index)
		{
			return this.tags[index];
		}

		/// <summary>
		/// Tells if this block contains at least one tag with the given name.
		/// </summary>
		/// <seealso cref= #getTagByName(String) </seealso>
		/// <param name="name"> the tag name to search, for example "32A" or "58" (letter option wildcard 'a' is not supported) </param>
		/// <returns> true if a tag matching the given name is found </returns>
		/// <exception cref="IllegalArgumentException"> if the name parameter is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean containsTag(final String name)
		public virtual bool containsTag(string name)
		{
			return getTagByName(name) != null;
		}

		/// <summary>
		/// Tells if this block contains at least one tag with the given number (ignoring the letter option).
		/// For example: <code>containsTag(59)</code> will return true if there is any variant of 59, 59A, 59F, etc...
		/// </summary>
		/// <seealso cref= #getTagByNumber(int) </seealso>
		/// <param name="tagNumber"> the tag number to search </param>
		/// <returns> true if there is a tag with the given number regardless of the letter option </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean containsTag(final int tagNumber)
		public virtual bool containsTag(int tagNumber)
		{
			return getTagByNumber(tagNumber) != null;
		}

		/// <summary>
		/// Gets the value of the given tag or null if that tag is not found.<br>
		/// If the tag is present more than once, then this method retrieves the value of the first occurrence.
		/// </summary>
		/// <seealso cref= #getTagByName(String) </seealso>
		/// <param name="name"> the tag name to search, for example "32A" or "58" (letter option wildcard 'a' is not supported) </param>
		/// <returns> a String containing the value null if the tag is not found </returns>
		/// <exception cref="IllegalArgumentException"> if the name parameter is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getTagValue(final String name)
		public virtual string getTagValue(string name)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag tag = this.getTagByName(name);
			Tag tag = this.getTagByName(name);
			return tag != null ? tag.Value : null;
		}

		/// <summary>
		/// Gets all tags with the given name.
		/// If name is null all tags that contain block data will be returned.
		/// </summary>
		/// <param name="name"> the tags name to search, for example "32A" or "58" (letter option wildcard 'a' is not supported) </param>
		/// <returns> an array of tags or an empty array if no tags are found </returns>
		/// <exception cref="IllegalArgumentException"> if the name parameter is null </exception>
		/// <seealso cref= #getTagsByName(String, String) to find tags with letter option wildcard </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Tag[] getTagsByName(final String name)
		public virtual Tag[] getTagsByName(string name)
		{
			Validate.notNull(name, NAME_VALIDATION_MESSAGE);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<Tag> l = new ArrayList<>();
			IList<Tag> l = new List<Tag>();
			foreach (Tag tag in this.tags)
			{
				if (StringUtils.Equals(tag.Name, name))
				{
					l.Add(tag);
				}
			}
			return l.ToArray();
		}

		/// <summary>
		/// Get the first field with the given name, matching the given values for components 1 and 2.
		/// </summary>
		/// <param name="name"> the tag name to search, for example "32A" or "58" (letter option wildcard 'a' is not supported) </param>
		/// <param name="component1"> the string to match as component 1. </param>
		/// <param name="component2"> the string to match as component 2. </param>
		/// <returns> the first tag found matching the name and components values or null if none is found </returns>
		/// <exception cref="IllegalArgumentException"> if the name parameter is null
		/// @since 7.8 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Tag getTagByName(final String name, final String component1, final String component2)
		public virtual Tag getTagByName(string name, string component1, string component2)
		{
			foreach (Tag tag in getTagsByName(name))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field f = tag.asField();
				Field f = tag.asField();
				if (f != null && f.@is(component1) && StringUtils.Equals(f.getComponent(2), component2))
				{
					return tag;
				}
			}
			return null;
		}

		/// <summary>
		/// Search and retrieve the first tag with the given number.
		/// For example: For 59 will return any of 59, 59A, 59F, etc...
		/// </summary>
		/// <param name="tagNumber"> the tags number to search </param>
		/// <returns> the first tag with the given number or null if no tag is found. </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Tag getTagByNumber(final int tagNumber)
		public virtual Tag getTagByNumber(int tagNumber)
		{
			foreach (Tag tag in this.tags)
			{
				if (tag.isNumber(tagNumber))
				{
					return tag;
				}
			}
			return null;
		}

		/// <summary>
		/// Get all tags with a given number, regardless of the letter options.
		/// </summary>
		/// <param name="tagNumber"> the tags number to search </param>
		/// <returns> the tags matching the given number or an empty list if none is found.	  </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<Tag> getTagsByNumber(final int tagNumber)
		public virtual IList<Tag> getTagsByNumber(int tagNumber)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<Tag> result = new ArrayList<>();
			IList<Tag> result = new List<Tag>();
			foreach (Tag tag in this.tags)
			{
				if (tag.isNumber(tagNumber))
				{
					result.Add(tag);
				}
			}
			return result;
		}

		/// <summary>
		/// Returns the tags having the exact specified content as value, regardless of the tag name.<br>
		/// For example the field :98A::XDTE//20090818 will be included for parameter :XDTE//20090818
		/// <para>For partial match see <seealso cref="#getTagsByContent(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="value"> the value of tags to find </param>
		/// <returns> an list of tags or an empty list if none is found
		/// @since 6.0 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<Tag> getTagsByValue(final String value)
		public virtual IList<Tag> getTagsByValue(string value)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<Tag> result = new ArrayList<>();
			IList<Tag> result = new List<Tag>();
			foreach (Tag tag in this.tags)
			{
				if (StringUtils.Equals(tag.Value, value))
				{
					result.Add(tag);
				}
			}
			return result;
		}

		/// <summary>
		/// Returns the tags having the specified content as part of its value, regardless of the tag name.<br>
		/// For example the field :98A::XDTE//20090818 will be included for parameter XDTE
		/// <para>For exact value match see <seealso cref="#getTagsByValue(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="content"> partial value of the tags to find </param>
		/// <returns> an list of tags or an empty list if none is found
		/// @since 6.0 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<Tag> getTagsByContent(final String content)
		public virtual IList<Tag> getTagsByContent(string content)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<Tag> result = new ArrayList<>();
			IList<Tag> result = new List<Tag>();
			foreach (Tag tag in this.tags)
			{
				if (StringUtils.contains(tag.Value, content))
				{
					result.Add(tag);
				}
			}
			return result;
		}

		/// <summary>
		/// Gets the values for all tags matching the given name. 
		/// The tag list is searched in order, the value of all tag matching the name are added to the result. </summary>
		/// <seealso cref= #getTagsByName(String)
		/// </seealso>
		/// <param name="name"> the tag name to search, for example "32A" or "58" (letter option wildcard 'a' is not supported) </param>
		/// <returns> and array containing the values of all the matching tags or an empty array if none is found </returns>
		/// <exception cref="IllegalArgumentException"> if the name parameter is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String[] getTagValues(final String name)
		public virtual string[] getTagValues(string name)
		{
			Validate.notNull(name, NAME_VALIDATION_MESSAGE);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final ArrayList<String> result = new ArrayList<>();
			List<string> result = new List<string>();
			foreach (Tag tag in getTagsByName(name))
			{
				result.Add(tag.Value);
			}
			return result.ToArray();
		}

		/// <summary>
		/// Gets a Map that contains the the tag names as keys and the values as map value.
		/// If a field is present more than once, then the first instance is processed and the rest is ignored.
		/// </summary>
		/// <returns> a Map for the tags name and values </returns>
		public virtual IDictionary<string, string> TagMap
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Map<String, String> map = new HashMap<>(this.tags.size());
				IDictionary<string, string> map = new Dictionary<string, string>(this.tags.Count);
				foreach (Tag tag in this.tags)
				{
					if (!map.ContainsKey(tag.Name))
					{
						map[tag.Name] = tag.Value;
					}
				}
				return map;
			}
		}

		/// <summary>
		/// Gets the first field matching the given name.
		/// </summary>
		/// <param name="name"> the name of the field to match, may end with 'a' as wildcard to select any letter option, for example 50a will match both 50A and 50B </param>
		/// <returns> the found field instance or null if none is found with the given name </returns>
		/// <exception cref="IllegalArgumentException"> if the name parameter is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.field.Field getFieldByName(final String name)
		public virtual Field getFieldByName(string name)
		{
			return getFieldByName(name, null);
		}

		/// <summary>
		/// Gets all fields matching the given name.
		/// </summary>
		/// <param name="name"> the name of the field to match, may end with 'a' as wildcard to select any letter option, for example 50a will match both 50A and 50B </param>
		/// <returns> an array of matched fields or an empty array if none is found </returns>
		/// <exception cref="IllegalArgumentException"> if the name parameter is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.field.Field[] getFieldsByName(final String name)
		public virtual Field[] getFieldsByName(string name)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<? extends com.prowidesoftware.swift.model.field.Field> fields = getFieldsByName(name, null);
//JAVA TO C# CONVERTER TODO TASK: Java wildcard generics are not converted to .NET:
			IList<?> fields = getFieldsByName(name, null);
			return fields.ToArray();
		}

		/// <summary>
		/// Gets the first field matching the given name and first component value.
		/// This is particularly helpful to find generic field by its qualifier.
		/// </summary>
		/// <param name="name"> the name of the field to match, may end with 'a' as wildcard to select any letter option, for example 50a will match both 50A and 50B </param>
		/// <param name="componentValue"> expected value for component 1 in the matched field, or null to return the first field matching the name </param>
		/// <returns> the first matching field or null if none is found
		/// 
		/// @since 7.5 </returns>
		/// <exception cref="IllegalArgumentException"> if name parameter is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.field.Field getFieldByName(final String name, final String componentValue)
		public virtual Field getFieldByName(string name, string componentValue)
		{
			Validate.notNull(name, NAME_VALIDATION_MESSAGE);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean wildcard = name.endsWith("a");
			bool wildcard = name.EndsWith("a", StringComparison.Ordinal);
			foreach (Tag tag in this.tags)
			{
				if (matchesName(wildcard, tag.Name, name))
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field field = tag.asField();
					Field field = tag.asField();
					if (field == null)
					{
						log.warning("Could not create field instance of " + tag);
					}
					else if (componentValue == null || field.@is(componentValue))
					{
						return field;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Gets all fields matching the given name and first component value.
		/// </summary>
		/// <param name="name"> the name of the field to match, may end with 'a' as wildcard to select any letter option, for example 50a will match both 50A and 50B </param>
		/// <param name="componentValue"> expected value for component 1 in the matched fields, or null to return all fields matching the name </param>
		/// <returns> a list of matching fields or an empty list if none is found
		/// @since 7.6 </returns>
		/// <exception cref="IllegalArgumentException"> if name parameter is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<? extends com.prowidesoftware.swift.model.field.Field> getFieldsByName(final String name, final String componentValue)
//JAVA TO C# CONVERTER TODO TASK: Java wildcard generics are not converted to .NET:
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<? extends com.prowidesoftware.swift.model.field.Field> getFieldsByName(final String name, final String componentValue)
//JAVA TO C# CONVERTER TODO TASK: Java wildcard generics are not converted to .NET:
		public virtual IList<?> getFieldsByName(string name, string componentValue) where ? : com.prowidesoftware.swift.model.field.Field
		{
			Validate.notNull(name, NAME_VALIDATION_MESSAGE);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean wildcard = name.endsWith("a");
			bool wildcard = name.EndsWith("a", StringComparison.Ordinal);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<com.prowidesoftware.swift.model.field.Field> l = new ArrayList<>();
			IList<Field> l = new List<Field>();
			foreach (Tag tag in this.tags)
			{
				if (matchesName(wildcard, tag.Name, name))
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field field = tag.asField();
					Field field = tag.asField();
					if (field == null)
					{
						log.warning("Could not create field instance of " + tag);
					}
					else if (componentValue == null || field.@is(componentValue))
					{
						l.Add(field);
					}
				}
			}
			return l;
		}

		/// <summary>
		/// Gets all tag instances matching the given name and first component value.
		/// </summary>
		/// <param name="name"> the name of the field to match, may end with 'a' as wildcard to select any letter option, for example 50a will match both 50A and 50B </param>
		/// <param name="componentValue"> expected value for component 1 in the matched fields, or null to return all fields matching the name </param>
		/// <returns> a list of matching tags or an empty list if none is found
		/// @since 7.10.6 </returns>
		/// <exception cref="IllegalArgumentException"> if name parameter is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<Tag> getTagsByName(final String name, final String componentValue)
		public virtual IList<Tag> getTagsByName(string name, string componentValue)
		{
			Validate.notNull(name, NAME_VALIDATION_MESSAGE);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean wildcard = name.endsWith("a");
			bool wildcard = name.EndsWith("a", StringComparison.Ordinal);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<Tag> l = new ArrayList<>();
			IList<Tag> l = new List<Tag>();
			foreach (Tag tag in this.tags)
			{
				if (matchesName(wildcard, tag.Name, name))
				{
					if (componentValue == null)
					{
						l.Add(tag);
					}
					else
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field field = tag.asField();
						Field field = tag.asField();
						if (field != null && field.@is(componentValue))
						{
							l.Add(tag);
						}
					}
				}
			}
			return l;
		}

		/// <summary>
		/// Returns true if the found fieldname matches the expected name </summary>
		/// <param name="wildcard"> if true the match will ignore letter options </param>
		/// <param name="found"> current field name </param>
		/// <param name="expected"> the expected value </param>
		/// <returns> true if matches considering the optional wildcard
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private boolean matchesName(boolean wildcard, final String found, final String expected)
		private bool matchesName(bool wildcard, string found, string expected)
		{
			if (wildcard)
			{
				return StringUtils.StartsWith(found, expected.Substring(0, expected.Length - 1));
			}
			else
			{
				return StringUtils.Equals(found, expected);
			}
		}

		/// <summary>
		/// Shortcut to <seealso cref="#getTag(int)"/>.getField() </summary>
		/// <seealso cref= #getTag(int)
		/// </seealso>
		/// <param name="index"> the index position of the field to retrieve (zero based) </param>
		/// <returns> the field at the given index </returns>
		/// <exception cref="IndexOutOfBoundsException"> if the index is out of range </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.field.Field getField(final int index)
		public virtual Field getField(int index)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag tag = getTag(index);
			Tag tag = getTag(index);
			if (tag != null)
			{
				return tag.asField();
			}
			return null;
		}

		/// <summary>
		/// Gets all fields matching the given name, matching also the first and second component values.<br>
		/// For example, for parameters 22F, OPTF and FOO it will match 22F::OPTF/FOO/QCAS but not 22F::OPTF//QCAS
		/// </summary>
		/// <seealso cref= #getFieldByQualifiers(String, String, String) </seealso>
		/// <param name="name"> the name of the field to match, may end with 'a' as wildcard to select any letter option, for example 50a will match both 50A and 50B </param>
		/// <param name="component1"> the expected value for the component 1 of the matched field </param>
		/// <param name="component2"> the expected value for the component 2 of the matched field </param>
		/// <returns> the first matching field or null if none is found with the given name and component values
		/// @since 7.5 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.field.Field getFieldByName(final String name, final String component1, final String component2)
		public virtual Field getFieldByName(string name, string component1, string component2)
		{
			foreach (Field field in getFieldsByName(name, component1))
			{
				if (StringUtils.Equals(field.getComponent(2), component2))
				{
					return field;
				}
			}
			return null;
		}

		/// <summary>
		/// Gets all generic fields matching the given name and qualifiers.<br>
		/// For example, for parameters 22F, OPTF and QCAS it will match 22F::OPTF//QCAS or 22F::OPTF/DSS/QCAS
		/// </summary>
		/// <seealso cref= #getFieldByName(String, String) </seealso>
		/// <seealso cref= GenericField </seealso>
		/// <param name="name"> the name of the field to match, may end with 'a' as wildcard to select any letter option, for example 50a will match both 50A and 50B </param>
		/// <param name="qualifier"> the expected value for the component 1 of the matched field </param>
		/// <param name="conditionalQualifier"> the expected value for the conditional qualifier component (usually 2 or 3) of the matched field </param>
		/// <returns> the first matching field or null if none is found with the given name and expected component values </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.field.Field getFieldByQualifiers(final String name, final String qualifier, final String conditionalQualifier)
		public virtual Field getFieldByQualifiers(string name, string qualifier, string conditionalQualifier)
		{
			foreach (Field field in getFieldsByName(name, qualifier))
			{
				if (field is GenericField)
				{
					if (StringUtils.Equals(((GenericField)field).ConditionalQualifier, conditionalQualifier))
					{
						return field;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Search and retrieve the first Field with the given number.
		/// For example: for 59 will return any of 59, 59A, 59F, etc...
		/// </summary>
		/// <param name="fieldNumber"> the field number to search </param>
		/// <returns> the first instance of the given field in the message or null if none is found </returns>
		/// <seealso cref= #getTagByNumber(int) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.field.Field getFieldByNumber(final int fieldNumber)
		public virtual Field getFieldByNumber(int fieldNumber)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = getTagByNumber(fieldNumber);
			Tag t = getTagByNumber(fieldNumber);
			if (t != null)
			{
				return t.asField();
			}
			return null;
		}

		/// <summary>
		/// Get all Fields of a given number.<br>
		/// For example: for 59 will return any of 59, 59A, 59F, etc...
		/// </summary>
		/// <param name="fieldNumber"> the field number to search </param>
		/// <returns> the fields matching the given number or an empty list if none is found.
		/// </returns>
		/// <seealso cref= #getTagsByNumber(int) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<? extends com.prowidesoftware.swift.model.field.Field> getFieldsByNumber(final int fieldNumber)
//JAVA TO C# CONVERTER TODO TASK: Java wildcard generics are not converted to .NET:
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<? extends com.prowidesoftware.swift.model.field.Field> getFieldsByNumber(final int fieldNumber)
//JAVA TO C# CONVERTER TODO TASK: Java wildcard generics are not converted to .NET:
		public virtual IList<?> getFieldsByNumber(int fieldNumber) where ? : com.prowidesoftware.swift.model.field.Field
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<com.prowidesoftware.swift.model.field.Field> result = new ArrayList<>();
			IList<Field> result = new List<Field>();
			foreach (Tag tag in getTagsByNumber(fieldNumber))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field f = tag.asField();
				Field f = tag.asField();
				if (f == null)
				{
					throw new System.ArgumentException("Unable to create field for tagname " + tag.Name);
				}
				else
				{
					result.Add(f);
				}
			}
			return result;
		}

		/// <summary>
		/// Gets the first field matching the given number and component value.
		/// For example: for 59 will return any of 59, 59A, 59F, etc...
		/// </summary>
		/// <param name="fieldNumber"> the field number to search </param>
		/// <param name="componentValue"> expected value for component 1 in the matched field </param>
		/// <returns> the first matching field or null if none is found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.field.Field getFieldByNumber(final int fieldNumber, final String componentValue)
		public virtual Field getFieldByNumber(int fieldNumber, string componentValue)
		{
			foreach (Field field in getFieldsByNumber(fieldNumber))
			{
				if (field.@is(componentValue))
				{
					return field;
				}
			}
			return null;
		}

		/// <summary>
		/// Tell if this block contains at least a field with the given name </summary>
		/// <param name="name"> the name of the field to match, may end with 'a' as wildcard to select any letter option, for example 50a will match both 50A and 50B </param>
		/// <returns> true if this field exists at lease once, false in other case </returns>
		/// <seealso cref= #getFieldsByName(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean containsField(final String name)
		public virtual bool containsField(string name)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field[] arr = getFieldsByName(name);
			Field[] arr = getFieldsByName(name);
			return (arr != null) && arr.Length > 0;
		}

		/// @deprecated use <seealso cref="#append(Tag)"/> instead of this 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#append(Tag)"/> instead of this") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public void addTag(final Tag t)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use <seealso cref="#append(Tag)"/> instead of this")]
		public virtual void addTag(Tag t)
		{
			DeprecationUtils.phase3(this.GetType(), "addTag(Tag)", "Use append(Tag) instead.");
			// sanity check
			Validate.notNull(t, "parameter 't' cannot not be null");

			if (log.isLoggable(Level.FINEST))
			{
				log.finest("Adding Tag [" + t + "]");
			}
			if (this.tags == null)
			{
				this.tags = new List<>();
			}
			this.tags.Add(t);
		}
		/// @deprecated use <seealso cref="#append(Field)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#append(com.prowidesoftware.swift.model.field.Field)"/> instead") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public void add(final com.prowidesoftware.swift.model.field.Field f)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use <seealso cref="#append(com.prowidesoftware.swift.model.field.Field)"/> instead")]
		public virtual void add(Field f)
		{
			DeprecationUtils.phase3(this.GetType(), "add(Field)", "Use append(Field) instead.");
			append(new Tag(f.Name, f.Value));
		}

		/// @deprecated renamed to <seealso cref="#countByName(String)"/> 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("renamed to <seealso cref="#countByName(String)"/>") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public int getTagCount(final String key)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("renamed to <seealso cref="#countByName(String)"/>")]
		public virtual int getTagCount(string key)
		{
			DeprecationUtils.phase3(this.GetType(), "getTagCount(String)", "Use countByName(String) instead.");
			return countByName(key);
		}

		/// <summary>
		/// Counts how many tags with the given name are present in the block.
		/// </summary>
		/// <param name="name"> the name of the tag </param>
		/// <returns> the amount of tags with the given name in the block </returns>
		/// <exception cref="IllegalArgumentException"> if tagname key is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int countByName(final String name)
		public virtual int countByName(string name)
		{
			Validate.notNull(name, NAME_VALIDATION_MESSAGE);
			int count = 0;
			foreach (Tag tag in this.tags)
			{
				if (StringUtils.Equals(tag.Name, name))
				{
					count++;
				}
			}
			return count;
		}

		/// <summary>
		/// convert this to string
		/// </summary>
		public override string ToString()
		{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
			return (new StringBuilder()).Append(this.GetType().FullName).Append("[").Append(tags == null ? "tags=null" : tags.ToString()).Append("]").ToString();
		}

		/// <summary>
		/// Remove the tag with the given name in the block.
		/// If more than one instance of the given name is
		/// found the first instance is removed while the
		/// rest remains untouched.
		/// </summary>
		/// <param name="name"> the name of the tag to remove must not be null </param>
		/// <returns> the value of the removed tag </returns>
		/// <exception cref="IllegalArgumentException"> if parameter name is null </exception>
		/// <seealso cref= #removeAll(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String removeTag(final String name)
		public virtual string removeTag(string name)
		{
			Validate.notNull(name, NAME_VALIDATION_MESSAGE);
			int i = 0;
			foreach (Tag t in tags)
			{
				if (StringUtils.Equals(t.Name, name))
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag r = tags.remove(i);
					Tag r = tags.Remove(i);
					return r.Value;
				}
				i++;
			}
			return null;
		}

		/// <summary>
		/// Remove all tags in the current block that match the given name.
		/// If name is an invalid tag no error is thrown. There is no difference by using this method
		/// to tell if a tag was present or not. for quering the block for existing tags
		/// <seealso cref="#containsTag(String)"/> must be used.
		/// </summary>
		/// <param name="name"> the name of the tag to remove. may be null in which case the tags containing 'block data' will be removed </param>
		/// <returns> the amount of tags removed </returns>
		/// <exception cref="IllegalArgumentException"> if parameter name is null </exception>
		/// <seealso cref= #removeTag(String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int removeAll(final String name)
		public virtual int removeAll(string name)
		{
			Validate.notNull(name, "parameter 'name' cannot not be null");
			int removed = 0;
			foreach (Tag t in getTagsByName(name))
			{
				this.tags.Remove(t);
				removed++;
			}
			return removed;
		}

		/// <summary>
		/// Gets a Iterator for the tags in this block or null if no tags are present on the block an empty iterator is returned.
		/// </summary>
		/// <returns> an Iterator that may or may not contain objects of type Tag </returns>
		/// <seealso cref= Tag </seealso>
		public virtual IEnumerator<Tag> tagIterator()
		{
			if (this.tags == null || this.tags.Count == 0)
			{
				if (log.isLoggable(Level.FINE))
				{
					log.fine("No tags in block, returning empty iterator");
				}
				return new EmptyItr();
			}
			return this.tags.GetEnumerator();
		}

		/// <summary>
		/// Add all tags in the List argument to the current blocks. Current tags will not be removed. </summary>
		/// <param name="tags"> the list of tags to add </param>
		/// <exception cref="IllegalArgumentException"> if parameter name is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void addTags(final List<Tag> tags)
		public virtual void addTags(IList<Tag> tags)
		{
			Validate.notNull(tags, "parameter 'tags' cannot not be null");
			thisTagsNotNull().AddRange(tags);
		}

		/// <summary>
		/// Adds a tag at the specified position in this tag list.
		/// Shifts the element currently at that position (if any) and any subsequent elements to the right (adds one to their indices). </summary>
		/// <param name="tag"> the tag to add </param>
		/// <param name="index"> index at which the specified tag is to be inserted (zero based) </param>
		/// <exception cref="IllegalArgumentException"> if parameter name is null </exception>
		/// <exception cref="IndexOutOfBoundsException"> if the index is out of range (index &lt; 0 || index &gt;= size())
		/// @since 7.9.7 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void addTag(int index, final Tag tag)
		public virtual void addTag(int index, Tag tag)
		{
			// sanity check
			Validate.notNull(tag, TAG_VALIDATION_MESSAGE);
			thisTagsNotNull().Insert(index,tag);
		}

		/// <summary>
		/// returns this.tags checking before if it is null, and then creating a new array list for it
		/// </summary>
		private IList<Tag> thisTagsNotNull()
		{
			if (this.tags == null)
			{
				this.tags = new List<>();
			}
			return this.tags;
		}

		/// @deprecated use <seealso cref="#countAll()"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#countAll()"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public int getTagCount()
		[Obsolete("use <seealso cref="#countAll()"/> instead")]
		public virtual int TagCount
		{
			get
			{
				DeprecationUtils.phase2(this.GetType(), "getTagCount()", "Use countAll() instead.");
				return countAll();
			}
		}

		/// <summary>
		/// Gets the number of tags in this taglist </summary>
		/// <returns> zero or the amount of tags contained in the block
		///  </returns>		public virtual int countAll()
		{
			 return (this.tags == null ? 0 : tags.Count);
		}

		 /// <summary>
		 /// Replaces the tag at the specified position in this tag list with the specified tag.
		 /// </summary>
		 /// <param name="index"> index of the tag to replace (zero based) </param>
		 /// <param name="tag"> tag to be stored at the specified position </param>
		 /// <returns> the tag previously at the specified position </returns>
		 /// <exception cref="IllegalArgumentException"> if parameter name is null </exception>
		 /// <exception cref="IndexOutOfBoundsException"> if the index is out of range (index &lt; 0 || index &gt;= size())
		 /// @since 7.9.7 </exception>
		 public virtual Tag setTag(int index, Tag tag)
		 {
			 // sanity check
			 Validate.notNull(tag, TAG_VALIDATION_MESSAGE);
			 return this.tags[index] = tag;
		 }

		/// <summary>
		/// Set tag in the list of tags of this block.
		/// </summary>
		/// <param name="tags"> the tags of the block, may be null to remove all the tags of the block </param>
		/// <exception cref="IllegalArgumentException"> if parameter tags is not null and contains elements of class other than Tag </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setTags(final List<Tag> tags)
		public virtual void setTags(IList<Tag> tags)
		{
			this.tags = tags;
		}

		 /// <param name="tags"> tags to set </param>
		 /// <seealso cref= #setTags(List) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setTags(final Tag[] tags)
		 public virtual void setTags(Tag[] tags)
		 {
			 IList<Tag> list = new List<Tag>();
			 list.AddRange(tags);
			 setTags(list);
		 }

		 /// <summary>
		 /// Tells if the block contains at least one Tag.
		 /// </summary>
		 /// <returns> true if the block contains at least one Tag and false in other case </returns>
		 public virtual bool Empty
		 {
			 get
			 {
				 return (this.tags == null || this.tags.Count == 0);
			 }
		 }

		 /// <summary>
		 /// Tells the amount of fields contained in the block, may be zero. </summary>
		 /// <returns> zero if tags is null or empty or the amount of tags in this object </returns>
		 public virtual int size()
		 {
			 return (this.tags == null ? 0 : this.tags.Count);
		 }

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}
			if (!base.Equals(o))
			{
				return false;
			}
			SwiftTagListBlock tags1 = (SwiftTagListBlock) o;
			return Objects.Equals(tags, tags1.tags);
		}

		public override int GetHashCode()
		{
			return Objects.hash(base.GetHashCode(), tags);
		}

		/// <summary>
		/// Get all sub blocks using the starting and ending Tags as block boundaries.<br>
		/// The starting and end tags are included in the resulting sub blocks.
		/// <br>
		/// Tag compare is done using <seealso cref="Tag#equalsIgnoreCR(Tag)"/> (not object references).
		/// </summary>
		/// <param name="start"> starting tag </param>
		/// <param name="end"> ending tag </param>
		/// <returns> a list of <code>SwiftTagListBlock</code> new blocks containing the found tags (the list can be empty if no tags are found)
		///  
		/// @since 6.0 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<SwiftTagListBlock> getSubBlocks(final Tag start, final Tag end)
		 public virtual IList<SwiftTagListBlock> getSubBlocks(Tag start, Tag end)
		 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftTagListBlock> result = new ArrayList<>();
			 IList<SwiftTagListBlock> result = new List<SwiftTagListBlock>();

			 SwiftTagListBlock toAdd = null;
			 bool blockFound = false;
			 foreach (Tag t in this.tags)
			 {
				 if (blockFound)
				 {
					 toAdd.append(t);
					 if (end != null && end.equalsIgnoreCR(t))
					 {
						 result.Add(toAdd);
						 blockFound = false;
						 toAdd = null;
					 }
				 }
				 else
				 {
					 if (start.equalsIgnoreCR(t))
					 {
						 toAdd = new SwiftTagListBlock();
						 toAdd.append(t);
						 blockFound = true;
					 }
				 }
			 }
			 //if necessary, we add the last found sub block
			 if (toAdd != null)
			 {
				 result.Add(toAdd);
			 }

			 return result;
		 }

		/// <summary>
		/// Gets all sub blocks with a specific name, using ISO 15022 FIN block structure definitions.
		/// It searches for a starting 16R field (with blockName as value) and its correspondent 16S
		/// field (with blockName as value) as block boundaries.
		/// </summary>
		/// <param name="blockName"> block name, used for block </param>
		/// <returns> a list containing the found tags (the list can be empty if no tags are found) </returns>
		/// <seealso cref= #getSubBlocks(Tag, Tag)
		/// 
		/// @since 6.0 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<SwiftTagListBlock> getSubBlocks(final String blockName)
		 public virtual IList<SwiftTagListBlock> getSubBlocks(string blockName)
		 {
			return getSubBlocks(new Tag("16R", blockName), new Tag("16S", blockName));
		 }

		 /// <summary>
		 /// Get all sub blocks using the starting and ending Tag names as block boundaries (Tag values are ignored).
		 /// The starting and end tags are included in the resulting sub blocks.<br>
		 /// This method is particularly useful to get sub blocks that are not bounded by 16R and 16S fields.
		 /// </summary>
		 /// <param name="startTagName"> starting tag name </param>
		 /// <param name="endTagName"> ending tag name </param>
		 /// <returns> a list of <code>SwiftTagListBlock</code> new blocks containing the found tags (the list can be empty if no tags are found)
		 /// 
		 /// @since 6.0 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<SwiftTagListBlock> getSubBlocks(final String startTagName, final String endTagName)
		 public virtual IList<SwiftTagListBlock> getSubBlocks(string startTagName, string endTagName)
		 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag start = new Tag(startTagName, "");
			 Tag start = new Tag(startTagName, "");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag end = new Tag(endTagName, "");
			 Tag end = new Tag(endTagName, "");
			 return _getSubBlocks(start.Number, start.LetterOption, end.Number, end.LetterOption);
		 }

		 /// <summary>
		 /// Get all sub blocks using the starting and ending Tag numbers as block boundaries (Tag values are ignored).
		 /// The starting and end tags are included in the resulting sub blocks.<br>
		 /// This method is particularly useful to get sub blocks that are not bounded by 16R and 16S fields.
		 /// </summary>
		 /// <param name="startTagNumber"> starting tag number regardless of the letter option </param>
		 /// <param name="endTagNumber"> ending tag number regardless of the letter option </param>
		 /// <returns> a list of <code>SwiftTagListBlock</code> new blocks containing the found tags (the list can be empty if no tags are found)
		 /// 
		 /// @since 6.2 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<SwiftTagListBlock> getSubBlocks(final int startTagNumber, final int endTagNumber)
		 public virtual IList<SwiftTagListBlock> getSubBlocks(int startTagNumber, int endTagNumber)
		 {
			 return _getSubBlocks(startTagNumber, null, endTagNumber, null);
		 }

		 /// <summary>
		 /// Get all sub blocks using the starting Tag name and ending Tag number as block boundaries (Tag values are ignored).
		 /// The starting and end tags are included in the resulting sub blocks.<br>
		 /// </summary>
		 /// <param name="startTagName"> starting tag name </param>
		 /// <param name="endTagNumber"> ending tag number regardless of the letter option </param>
		 /// <returns> a list of <code>SwiftTagListBlock</code> new blocks containing the found tags (the list can be empty if no tags are found)
		 /// 
		 /// @since 6.2 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<SwiftTagListBlock> getSubBlocks(final String startTagName, final int endTagNumber)
		 public virtual IList<SwiftTagListBlock> getSubBlocks(string startTagName, int endTagNumber)
		 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag start = new Tag(startTagName, "");
			 Tag start = new Tag(startTagName, "");
			 return _getSubBlocks(start.Number, start.LetterOption, endTagNumber, null);
		 }

		 /// <summary>
		 /// Get all sub blocks using the starting Tag number and ending Tag name as block boundaries (Tag values are ignored).
		 /// The starting and end tags are included in the resulting sub blocks.<br>
		 /// </summary>
		 /// <param name="startTagNumber"> starting tag name number regardless of the letter option </param>
		 /// <param name="endTagName"> ending tag name </param>
		 /// <returns> a list of <code>SwiftTagListBlock</code> new blocks containing the found tags (the list can be empty if no tags are found)
		 /// 
		 /// @since 6.2 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<SwiftTagListBlock> getSubBlocks(final int startTagNumber, final String endTagName)
		 public virtual IList<SwiftTagListBlock> getSubBlocks(int startTagNumber, string endTagName)
		 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag end = new Tag(endTagName, "");
			 Tag end = new Tag(endTagName, "");
			 return _getSubBlocks(startTagNumber, null, end.Number, end.LetterOption);
		 }

		/// <summary>
		/// Helper method to get subblocks on different boundaries combinations </summary>
		/// <param name="startTagNumber"> mandatory starting tag number paramenter </param>
		/// <param name="startTagLetter"> optional starting tag letter option </param>
		/// <param name="endTagNumber"> mandatory ending tag number paramenter </param>
		/// <param name="endTagLetter"> optional ending tag letter option </param>
		/// <returns> the found subblocks </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private List<SwiftTagListBlock> _getSubBlocks(final int startTagNumber, final String startTagLetter, final int endTagNumber, final String endTagLetter)
		private IList<SwiftTagListBlock> _getSubBlocks(int startTagNumber, string startTagLetter, int endTagNumber, string endTagLetter)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftTagListBlock> result = new ArrayList<>();
			IList<SwiftTagListBlock> result = new List<SwiftTagListBlock>();

			SwiftTagListBlock toAdd = null;
			bool blockFound = false;
			foreach (Tag t in this.tags)
			{
				if (blockFound)
				{
					toAdd.append(t);
					if ((endTagLetter != null && StringUtils.Equals(t.Name, endTagNumber + endTagLetter)) || (endTagLetter == null && t.isNumber(endTagNumber)))
					{
						result.Add(toAdd);
						blockFound = false;
						toAdd = null;
					}
				}
				else
				{
					if ((startTagLetter != null && StringUtils.Equals(t.Name, startTagNumber + startTagLetter)) || (startTagLetter == null && t.isNumber(startTagNumber)))
					{
						toAdd = new SwiftTagListBlock();
						toAdd.append(t);
						blockFound = true;
					}
				}
			}
			//if necessary, we add the last found sub block
			if (toAdd != null)
			{
				result.Add(toAdd);
			}

			return result;
		}

		/// <summary>
		/// Get all tags between the first occurrence of the starting Tag name and the first occurrence of an optional ending Tag name.
		/// If the ending Tag name is null or not found after the starting Tag name, it returns all tags until end of block.
		/// The starting and end tags are included in the resulting block.
		/// </summary>
		/// <param name="startTagName"> starting tag name </param>
		/// <param name="endTagName"> ending tag name or null </param>
		/// <returns> a new block containing the found tags (the block can be empty if no tags are found)
		/// 
		/// @since 6.0 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlock(final String startTagName, final String endTagName)
		public virtual SwiftTagListBlock getSubBlock(string startTagName, string endTagName)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftTagListBlock> l = getSubBlocks(startTagName, endTagName);
			IList<SwiftTagListBlock> l = getSubBlocks(startTagName, endTagName);
			if (l.Count == 0)
			{
				return new SwiftTagListBlock();
			}
			else
			{
				return l[0];
			}
		}

		/// <summary>
		/// Gets all tags of a specific sub block, searching for the first occurrence of the starting 16R field (with blockName as value)
		/// and its correspondent 16S field (with blockName as value).
		/// </summary>
		/// <param name="blockName"> block name, used for block </param>
		/// <returns> a new block containing the found tags (the block can be empty if no tags are found) </returns>
		/// <seealso cref= #getSubBlock(Tag, Tag)
		/// 
		/// @since 6.0 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlock(final String blockName)
		public virtual SwiftTagListBlock getSubBlock(string blockName)
		{
			return getSubBlock(new Tag("16R", blockName), new Tag("16S", blockName));
		}

		/// <summary>
		/// Get all tags between the first occurrence of the starting Tag and the first occurrence of an optional ending Tag.
		/// If the ending Tag is null or not found after the starting Tag, it returns all tags until end of block.
		/// The starting and end tags are included in the resulting block.
		/// </summary>
		/// <param name="start"> starting tag </param>
		/// <param name="end"> ending tag or null </param>
		/// <returns> a new block containing the found tags (the block can be empty if no tags are found)
		/// 
		/// @since 6.0 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlock(final Tag start, final Tag end)
		public virtual SwiftTagListBlock getSubBlock(Tag start, Tag end)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftTagListBlock> l = getSubBlocks(start, end);
			IList<SwiftTagListBlock> l = getSubBlocks(start, end);
			if (l.Count == 0)
			{
				return new SwiftTagListBlock();
			}
			else
			{
				return l[0];
			}
		}

		/// <summary>
		/// Creates a new block containing the list of tags between the given indexes: from, inclusive, and to, exclusive.<br>
		/// Similar to the substring method of String, but for a list of Tag instead of an array of characters.
		/// For getting a 'view' only sublist use <seealso cref="List#subList(int, int)"/>
		/// For a new block containing both boundary elements included use <seealso cref="#sublist(Integer, Integer)"/>
		/// </summary>
		/// <param name="from"> may be null in which case is equivalent to zero </param>
		/// <param name="to"> may be null or larger than the list size, in which case is equivalent to the index of the last available item. </param>
		/// <returns> a <em>new</em> list with the tags found between given indexes in this tag list </returns>
		/// <exception cref="IllegalArgumentException"> if from is bigger than to. </exception>
		/// <seealso cref= List#subList(int, int) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlock(final Integer from, final Integer to)
		public virtual SwiftTagListBlock getSubBlock(int? from, int? to)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int f = from == null ? 0 : from;
			int f = from == null ? 0 : from;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int t = to == null || to >this.tags.size()-1 ? this.tags.size() : to;
			int t = to == null || to > this.tags.Count - 1 ? this.tags.Count : to;
			if (f > t)
			{
				throw new System.ArgumentException("from index (" + f + ") cannot be bigger than to index (" + t + ")");
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = new SwiftTagListBlock();
			SwiftTagListBlock result = new SwiftTagListBlock();
			result.addTags(this.tags.subList(f, t));
			return result;
		}

		/// <summary>
		/// @since 6.5 </summary>
		/// @deprecated use #getSubBlock(Integer, Integer) instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use #getSubBlock(Integer, Integer) instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public SwiftTagListBlock getSubBlockByIndex(final Integer startIndex, final Integer endIndex)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use #getSubBlock(Integer, Integer) instead")]
		public virtual SwiftTagListBlock getSubBlockByIndex(int? startIndex, int? endIndex)
		{
			return getSubBlock(startIndex, endIndex);
		}

		/// <summary>
		/// Get a new list with the elements contained between start and end, both inclusive.
		/// Both start and end <em>may be null</em>.
		/// For a new block excluding the end index use <seealso cref="#getSubBlock(Integer, Integer)"/>
		/// </summary>
		/// <param name="start"> start index, zero based. if null = zero </param>
		/// <param name="end"> last index, zero based, null means last element </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock sublist(final Integer start, final Integer end)
		public virtual SwiftTagListBlock sublist(int? start, int? end)
		{
			if (tags == null || tags.Count == 0)
			{
				throw new IllegalStateException("No tags in this list");
			}
			if ((start != null && start < 0) || (end != null && (end + 1)>this.tags.Count) || (start != null && end != null && start > end))
			{
				throw new System.ArgumentException("start: " + start + ", end: " + end + ", size=" + this.tags.Count);
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = new SwiftTagListBlock();
			SwiftTagListBlock result = new SwiftTagListBlock();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int s = start == null ? 0 : start;
			int s = start == null ? 0 : start;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int e = end == null ? this.tags.size()-1 : end;
			int e = end == null ? this.tags.Count - 1 : end;
			for (int i = s; i <= e ; i++)
			{
				result.append(this.tags[i]);
			}
			return result;
		}

		/// <summary>
		/// To indicate which part of the data is selected
		/// </summary>
		private enum SearchSelection
		{
			BEFORE,
			AFTER
		}

		/// <summary>
		/// To indicate how the boundary to find
		/// </summary>
		private enum SearchBoundary
		{
			/*
			 * search using tag name
			 */
			FIRST_TAG_NAME,
			/*
			 * search using tag and ignore CR method
			 */
			FIRST_TAG_IGNORE_CR,
			/*
			 * search using tag name
			 */
			LAST_TAG_NAME
		}

		/// <summary>
		/// Helper method to get subblocks on different search criteria </summary>
		/// <param name="tag"> mandatory tag paramenter </param>
		/// <param name="includeDelimiterInResult"> if true, the found boundary tag will be the first item in the returned block </param>
		/// <param name="searchSelection"> mandatory search selection criteria. </param>
		/// <param name="searchBoundary"> mandatory limit search criteria. </param>
		/// <returns> the found subblocks </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SwiftTagListBlock _searchSubBlockByCriteria(final Tag tag, final boolean includeDelimiterInResult, SearchSelection searchSelection, SearchBoundary searchBoundary)
		private SwiftTagListBlock _searchSubBlockByCriteria(Tag tag, bool includeDelimiterInResult, SearchSelection searchSelection, SearchBoundary searchBoundary)
		{

			SwiftTagListBlock result = new SwiftTagListBlock();

			int index = getIndexByCriteria(searchBoundary, tag);

			if (index >= 0)
			{
				//boundary tag found
				if (includeDelimiterInResult)
				{
					if (searchSelection == SearchSelection.AFTER)
					{
						result = getSubBlock(index, null);
					}
					else
					{
						result = getSubBlock(null, index + 1);
					}
				}
				else
				{

					bool hasDelimiterCriteria = (searchSelection == SearchSelection.AFTER && index < this.tags.Count - 1) || (searchSelection == SearchSelection.BEFORE && index < this.tags.Count);

					if (hasDelimiterCriteria)
					{
						if (searchSelection == SearchSelection.AFTER)
						{
							result = getSubBlock(index + 1, null);
						}
						else
						{
							if (index != 0)
							{
								result = getSubBlock(null, index);
							}
						}
					}
				}
			}
			else if (searchSelection == SearchSelection.BEFORE)
			{
				result.addTags(this.tags);
			}

			return result;
		}

		 /// <summary>
		 /// Get the index by search criteria tag or -1 if not found or precondition is not meet </summary>
		 /// <param name="criteria"> mandatory search criteria see (FIRST, FIRST_IGNORE_CR or LAST). </param>
		 /// <param name="tag"> the tag that will be used to calculate the index of the list of tags. </param>
		 /// <returns> a 0-based index of the found tag or -1 if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private int getIndexByCriteria(SearchBoundary criteria, final Tag tag)
		private int getIndexByCriteria(SearchBoundary criteria, Tag tag)
		{
			switch (criteria)
			{
				case com.prowidesoftware.swift.model.SwiftTagListBlock.SearchBoundary.FIRST_TAG_NAME:
					return indexOfFirst(tag.name);
				case com.prowidesoftware.swift.model.SwiftTagListBlock.SearchBoundary.FIRST_TAG_IGNORE_CR:
					return indexOfFirstIgnoreCR(tag);
				case com.prowidesoftware.swift.model.SwiftTagListBlock.SearchBoundary.LAST_TAG_NAME:
					return indexOfLast(tag.name);
				default:
					return -1;
			}
		}

		/// <summary>
		/// Gets a subblock after the first tag with the given tagname.
		/// The given separator tag is included in the result </summary>
		/// @deprecated use <seealso cref="#getSubBlockAfterFirst(String, boolean)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getSubBlockAfterFirst(String, boolean)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public SwiftTagListBlock getSubBlockAfterFirst(final String tagname)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use <seealso cref="#getSubBlockAfterFirst(String, boolean)"/> instead")]
		public virtual SwiftTagListBlock getSubBlockAfterFirst(string tagname)
		{
			DeprecationUtils.phase2(this.GetType(), "getSubBlockAfterFirst(String)", "Use getSubBlockAfterFirst(String, boolean) instead.");
			return getSubBlockAfterFirst(tagname, true);
		}

		/// <summary>
		/// Gets a subblock after the first tag with the given name.
		/// <br>
		/// Creates a new <seealso cref="SwiftTagListBlock"/> that contains all tags after the first instance
		/// of a tag with the given tagname.
		/// </summary>
		/// <param name="tagname"> the tag that will be used for splitting </param>
		/// <param name="includeBoundaryInResult"> if true, the found boundary tag will be the first item in the returned block </param>
		/// <returns> a new block with the trimmed content </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlockAfterFirst(final String tagname, final boolean includeBoundaryInResult)
		public virtual SwiftTagListBlock getSubBlockAfterFirst(string tagname, bool includeBoundaryInResult)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag tag = new Tag(tagname, "");
			Tag tag = new Tag(tagname, "");
			return _searchSubBlockByCriteria(tag, includeBoundaryInResult, SearchSelection.AFTER, SearchBoundary.FIRST_TAG_NAME);
		}

		/// <summary>
		/// Gets the subblock after the first instance of a given tag boundary.
		/// <br>
		/// All elements after the first instance of the given tag will be included in the result.
		/// If the boundary tag is null or not found in the block, an empty block will be returned.
		/// <br>
		/// Tag compare is done using <seealso cref="Tag#equalsIgnoreCR(Tag)"/> (not object references).
		/// </summary>
		/// <param name="tag"> the tag that will be used for splitting </param>
		/// <param name="includeBoundaryInResult"> if true, the found boundary tag will be the first item in the returned block </param>
		/// <returns> a new block with the trimmed content
		/// @since 7.9.3 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlockAfterFirst(final Tag tag, final boolean includeBoundaryInResult)
		public virtual SwiftTagListBlock getSubBlockAfterFirst(Tag tag, bool includeBoundaryInResult)
		{
			return _searchSubBlockByCriteria(tag, includeBoundaryInResult, SearchSelection.AFTER, SearchBoundary.FIRST_TAG_IGNORE_CR);
		}

		/// <summary>
		/// Gets the subblock after the last tag with the given name.
		/// <br>
		/// All elements after the last instance of a tag with the given name will be included in the result.
		/// If the tag name is null or no tag with the given name is found in the block, an empty block will be returned.
		/// </summary>
		/// <param name="tagname"> the name of the tag that will be used for for splitting </param>
		/// <param name="includeBoundaryInResult"> if true, the found boundary tag will be the first item in the returned block </param>
		/// <returns> a new block with the trimmed content </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlockAfterLast(final String tagname, final boolean includeBoundaryInResult)
		public virtual SwiftTagListBlock getSubBlockAfterLast(string tagname, bool includeBoundaryInResult)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag tag = new Tag(tagname, "");
			Tag tag = new Tag(tagname, "");
			return _searchSubBlockByCriteria(tag, includeBoundaryInResult, SearchSelection.AFTER, SearchBoundary.LAST_TAG_NAME);
		}

		/// <summary>
		/// Gets the subblock before the first tag with the given tagname.
		/// <br>
		/// Creates a new <seealso cref="SwiftTagListBlock"/> that contains all tags before the first instance
		/// of a tag with the given tagname.
		/// </summary>
		/// <param name="tagname"> the name of the tag that will be used for splitting </param>
		/// <param name="includeBoundaryInResult"> if true, the found boundary tag will be the last item in the returned block </param>
		/// <returns> a new block with the trimmed content </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlockBeforeFirst(final String tagname, final boolean includeBoundaryInResult)
		public virtual SwiftTagListBlock getSubBlockBeforeFirst(string tagname, bool includeBoundaryInResult)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag tag = new Tag(tagname, "");
			Tag tag = new Tag(tagname, "");
			return _searchSubBlockByCriteria(tag, includeBoundaryInResult, SearchSelection.BEFORE, SearchBoundary.FIRST_TAG_NAME);
		}

		/// <summary>
		/// Gets the subblock with all tags until tha last tag with the given name
		/// </summary>
		/// <param name="tagname"> the name of the tag that will be used for splitting </param>
		/// <param name="includeBoundaryInResult"> if true, the found boundary tag will be the last item in the returned block </param>
		/// <returns> the tags contained until the first instance of tagname </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlockBeforeLast(final String tagname, final boolean includeBoundaryInResult)
		public virtual SwiftTagListBlock getSubBlockBeforeLast(string tagname, bool includeBoundaryInResult)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag tag = new Tag(tagname, "");
			Tag tag = new Tag(tagname, "");
			return _searchSubBlockByCriteria(tag, includeBoundaryInResult, SearchSelection.BEFORE, SearchBoundary.LAST_TAG_NAME);
		}

		/// <summary>
		/// Get the index of the given tag in the list.
		/// </summary>
		/// <param name="startTagNumber"> the number of the tag, without any letter option </param>
		/// <param name="letterOptions"> list of letter options to search, an empty string is accepted to search no letter option </param>
		/// <returns> the index inside the internal list of the given tag, null if the tag is not  found
		/// @since 6.5 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Integer getTagIndex(final String startTagNumber, final String [] letterOptions)
		public virtual int? getTagIndex(string startTagNumber, string[] letterOptions)
		{
			for (int i = 0; i < this.tags.Count; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = this.tags.get(i);
				Tag t = this.tags[i];
				if (StringUtils.StartsWith(t.Name, startTagNumber))
				{
					// check letter options
					if (letterOptions == null || letterOptions.Length < 1)
					{
						return i;
					}
					else
					{
						foreach (String l in letterOptions)
						{
							if (StringUtils.Equals(t.Name, startTagNumber + l))
							{
								return i;
							}
						}
					}
				}
			}
			return null;
		}

		 /// <summary>
		 /// Iterates the internal list of tags and returns true if there is at least one tag equals to the given one.
		 /// </summary>
		 /// <param name="t"> the tag to search in tags </param>
		 /// <returns> true if tag is found
		 /// @since 6.0 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean containsTag(final Tag t)
		 public virtual bool containsTag(Tag t)
		 {
			 if (this.tags == null || this.tags.Count == 0)
			 {
				 return false;
			 }
			 foreach (Tag tag in this.tags)
			 {
				 if (tag.Equals(t))
				 {
					 return true;
				 }
			 }
			 return false;
		 }

		 /// <summary>
		 /// Split the given list with the given tagname.
		 /// Beware if the tagname is not found the entire list of tags is returned.
		 /// </summary>
		 /// @deprecated use <seealso cref="#splitByTagName(int, String)"/> instead where the result is empty when the boundary field is not found 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#splitByTagName(int, String)"/> instead where the result is empty when the boundary field is not found") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2020) public List<SwiftTagListBlock> splitByTagName(final String tagName)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		 [Obsolete("use <seealso cref="#splitByTagName(int, String)"/> instead where the result is empty when the boundary field is not found")]
		 public virtual IList<SwiftTagListBlock> splitByTagName(string tagName)
		 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftTagListBlock> result = new ArrayList<>();
			 IList<SwiftTagListBlock> result = new List<SwiftTagListBlock>();
			 if (this.tags.Count == 0 || !containsTag(tagName))
			 {
				 result.Add(this);
			 }
			 else
			 {
				 SwiftTagListBlock b = new SwiftTagListBlock();
				 b.append(tags[0]);
				 for (int i = 1;i < tags.Count;i++)
				 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = tags.get(i);
					 Tag t = tags[i];
					 if (StringUtils.Equals(tagName, t.Name))
					 {
						 result.Add(b);
						 b = new SwiftTagListBlock();
					 }
					 b.append(t);
				 }
				 // el ultimo no queda agregado
				 if (!result.Contains(b))
				 {
					 result.Add(b);
				 }
			 }
			 return result;
		 }

		 /// <summary>
		 /// Get the index of the last tagname in the list or -1 if not found or any precondition is not met </summary>
		 /// <returns> a 0-based index of the found tag or -1 if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int indexOfLast(final String tagname)
		 public virtual int indexOfLast(string tagname)
		 {
			 int result = -1;
			 if (this.tags != null && this.tags.Count > 0)
			 {

				 for (int i = 0;i < this.tags.Count;i++)
				 {
					 if (StringUtils.Equals(tagname, this.tags[i].Name))
					 {
						 result = i;
					 }
				 }
			 }
			 return result;
		 }

		 /// <summary>
		 /// Get the index of the last tagname with the given value in the list or -1 if not found or any precondition is not met </summary>
		 /// <returns> a 0-based index of the found tag or -1 if not found
		 /// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int indexOfLastValue(final String tagname, final String value)
		 public virtual int indexOfLastValue(string tagname, string value)
		 {
			 int result = -1;
			 if (this.tags != null && this.tags.Count > 0)
			 {

				 for (int i = 0;i < this.tags.Count;i++)
				 {
					 if (StringUtils.Equals(tagname, this.tags[i].Name) && StringUtils.Equals(value, this.tags[i].Value))
					 {
						 result = i;
					 }
				 }
			 }
			 return result;
		 }

		/// <summary>
		/// Get the index of the last of any tagnames in the list or -1 if not found or any precondition is not met. </summary>
		/// <param name="tagnames"> a variable list of tagnames to search. <em>Exact match only, wildcards NOT accepted</em> </param>
		/// <returns> the <em>zero based</em> index of the last tag found with the given name or <em>-1 if not found</em> </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int indexOfAnyLast(final String... tagnames)
		 public virtual int indexOfAnyLast(params string[] tagnames)
		 {
			 int result = -1;
			 if (this.tags != null && this.tags.Count > 0)
			 {
				 for (int i = 0;i < this.tags.Count;i++)
				 {
					 foreach (String tn in tagnames)
					 {
						 if (StringUtils.Equals(tn, this.tags[i].Name))
						 {
							 result = i;
						 }
					 }
				 }
			 }
			 return result;
		 }

		 /// <summary>
		 /// Get the index of the last of any tagnames after the given index in the list or -1 if not found or any precondition is not met
		 /// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int indexOfAnyLastAfterIndex(final int index, final String... tagnames)
		 public virtual int indexOfAnyLastAfterIndex(int index, params string[] tagnames)
		 {
			 int result = -1;
			 if (this.tags != null && this.tags.Count > 0)
			 {
				 for (int i = index;i < this.tags.Count;i++)
				 {
					 foreach (String tn in tagnames)
					 {
						 if (StringUtils.Equals(tn, this.tags[i].Name))
						 {
							 result = i;
						 }
					 }
				 }
			 }
			 return result;
		 }

		 /// <summary>
		 /// Gets the index of the first tag with the same name and value of in th list ignoring carriage returns characters in tag values, or -1 if not found or any precondition is not met </summary>
		 /// <returns> a 0-based index of the found tag or -1 if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private int indexOfFirstIgnoreCR(final Tag tag)
		 private int indexOfFirstIgnoreCR(Tag tag)
		 {
			 if (this.tags != null && this.tags.Count > 0)
			 {

				 for (int i = 0;i < this.tags.Count;i++)
				 {
					 if (this.tags[i].equalsIgnoreCR(tag))
					 {
						 return i;
					 }
				 }
			 }
			 return -1;
		 }

		/// <summary>
		/// Gets the index of the first tag with the given name in this tag list </summary>
		/// <returns> a 0-based index of the found tag or -1 if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int indexOfFirst(final String tagname)
		public virtual int indexOfFirst(string tagname)
		{
			if (this.tags != null && this.tags.Count > 0)
			{

				for (int i = 0;i < this.tags.Count;i++)
				{
					if (StringUtils.Equals(tagname, this.tags[i].Name))
					{
						return i;
					}
				}
			}
			return -1;
		}

		 /// <summary>
		 /// Gets the index of the first tag in this tag list, with the given name and value </summary>
		 /// <param name="tagname"> the name of the tag to find </param>
		 /// <param name="value"> the value of the tag to find </param>
		 /// <returns> a 0-based index of the found tag or -1 if not found
		 /// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int indexOfFirstValue(final String tagname, final String value)
		 public virtual int indexOfFirstValue(string tagname, string value)
		 {
			 return indexOfFirstValue(tagname, value, false);
		 }

		/// <summary>
		/// Gets the index of the first tag in this tag list, with the given name and value </summary>
		/// <param name="tagname"> the name of the tag to find </param>
		/// <param name="value"> the value of the tag to find </param>
		/// <param name="ignoreCR"> if true the compare will ignore combination of CR and LF when comparing the value </param>
		/// <returns> a 0-based index of the found tag or -1 if not found
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private int indexOfFirstValue(final String tagname, final String value, boolean ignoreCR)
		private int indexOfFirstValue(string tagname, string value, bool ignoreCR)
		{
			if (this.tags != null && this.tags.Count > 0)
			{
				for (int i = 0; i < this.tags.Count; i++)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = this.tags.get(i);
					Tag t = this.tags[i];
					if ((ignoreCR && t.equalsIgnoreCR(new Tag(tagname, value))) || (!ignoreCR && StringUtils.Equals(tagname, t.Name) && StringUtils.Equals(value, t.Value)))
					{
						return i;
					}
				}
			}
			return -1;
		}

		/// <summary>
		/// Gets the index of the first tag matching any of the given names </summary>
		/// <returns> a 0-based index of the found tag or -1 if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int indexOfAnyFirst(final String... tagnames)
		 public virtual int indexOfAnyFirst(params string[] tagnames)
		 {
			 if (this.tags != null && this.tags.Count > 0)
			 {
				 for (int i = 0; i < this.tags.Count; i++)
				 {
					 foreach (String tn in tagnames)
					 {
						 if (StringUtils.Equals(tn, this.tags[i].Name))
						 {
							 return i;
						 }
					 }
				 }
			 }
			 return -1;
		 }

		 /// <summary>
		 /// Gets the index of the first tag matching any of the given names after the given index in the tag list </summary>
		 /// <returns> a 0-based index of the found tag or -1 if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int indexOfAnyFirstAfterIndex(final int index, final String... tagnames)
		 public virtual int indexOfAnyFirstAfterIndex(int index, params string[] tagnames)
		 {
			 if (this.tags != null && this.tags.Count > 0)
			 {
				 for (int i = index; i < this.tags.Count; i++)
				 {
					 foreach (String tn in tagnames)
					 {
						 if (StringUtils.Equals(tn, this.tags[i].Name))
						 {
							 return i;
						 }
					 }
				 }
			 }
			 return -1;
		 }

		/// @deprecated use <seealso cref="#getSubBlockBeforeFirst(String, boolean)"/> 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#getSubBlockBeforeFirst(String, boolean)"/>") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public SwiftTagListBlock trimAfterFirst(final String tagname, final boolean includeBoundaryInResult)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use <seealso cref="#getSubBlockBeforeFirst(String, boolean)"/>")]
		public virtual SwiftTagListBlock trimAfterFirst(string tagname, bool includeBoundaryInResult)
		{
			return getSubBlockBeforeFirst(tagname, includeBoundaryInResult);
		}

	  /// <summary>
	  /// Removes a sub block using fields 16R and 16S with the given block name as boundary.
	  /// 
	  /// <para>It searches for a starting 16R field (with blockName as value) and its correspondent 16S
	  /// field (with blockName as value) as block boundaries and removes those fields from the result.
	  /// </para>
	  /// <para>If the searched block is not found (starting field 16R not present) the result will be just
	  /// a copy from this block. If the end boundary is not found (ending field field 16S not present),
	  /// trims all fields after the start boundary 16R.
	  /// </para>
	  /// <para>If several instances of the searched block are present, only the first one will be removed.
	  /// </para>
	  /// <para>The boundary fields 16R and 16S are also removed from the result.
	  /// 
	  /// </para>
	  /// </summary>
	  /// <param name="blockName"> block name, for example "SUBBAL" to search for 16R:SUBBAL and 16S:SUBBAL as boundaries </param>
	  /// <returns> a new block with the trimmed content
	  /// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock removeSubBlock(final String blockName)
		public virtual SwiftTagListBlock removeSubBlock(string blockName)
		{
			return removeSubBlock(blockName, false);
		}

		/// <summary>
		/// Remove all sub blocks with the given name (using fields 16R and 16S as boundaries).
		/// <para>
		/// The implementation is similar to <seealso cref="#removeSubBlock(String)"/> but will remove all found
		/// instances of the sub block.
		/// 
		/// </para>
		/// </summary>
		/// <seealso cref= #removeSubBlock(String) </seealso>
		/// <param name="blockName"> block name, for example "SUBBAL" to search for 16R:SUBBAL and 16S:SUBBAL as boundaries </param>
		/// <returns> a new block with the trimmed content
		/// @since 7.10.3 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock removeSubBlocks(final String blockName)
		public virtual SwiftTagListBlock removeSubBlocks(string blockName)
		{
			return removeSubBlock(blockName, true);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SwiftTagListBlock removeSubBlock(final String blockName, boolean removeAll)
		private SwiftTagListBlock removeSubBlock(string blockName, bool removeAll)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = new SwiftTagListBlock();
			SwiftTagListBlock result = new SwiftTagListBlock();
			bool inBlock = false;
			bool blockRemoved = false;
			foreach (Tag t in this.tags)
			{
				if (blockRemoved && !removeAll)
				{
					 // sub block already removed, keep all remaining tags
					 result.append(t);
				}
				else
				{
					if (Field16R.tag(blockName).Equals(t) && !inBlock)
					{
						// start boundary found
						inBlock = true;
					}
					else if (Field16S.tag(blockName).Equals(t) && inBlock)
					{
						// end boundary found
						inBlock = false;
						// we are done
						blockRemoved = true;
					}
					else if (!inBlock)
					{
						// keep all tags but the one in the searched block
						result.append(t);
					}
				}
			}
			return result;
		}

		 /// <summary>
		 /// Tell if this block contains any of the given name tags.
		 /// this is a shorthand for avoiding repeated calls to <seealso cref="#containsTag(String)"/>. </summary>
		 /// <param name="name"> the list of tags to check, if null or empty this method will return false without further action
		 /// @since 7.0 </param>
		 /// <seealso cref= #containsTag(String) </seealso>
		 /// <seealso cref= #containsAllOf(String...) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean containsAnyOf(final String... name)
		 public virtual bool containsAnyOf(params string[] name)
		 {
			 if (name != null && name.Length > 0)
			 {
				 foreach (String s in name)
				 {
					 if (containsTag(s))
					 {
						 return true;
					 }
				 }
			 }
			 return false;
		 }

		 /// <summary>
		 /// Tell if this block contains all of the given name tags.
		 /// this is a shorthand for avoiding repeated calls to <seealso cref="#containsTag(String)"/>. </summary>
		 /// <param name="name"> the list of tags to check, if null or empty this method will return false without further action
		 /// @since 7.4 </param>
		 /// <seealso cref= #containsTag(String) </seealso>
		 /// <seealso cref= #containsAnyOf(String...) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean containsAllOf(final String... name)
		 public virtual bool containsAllOf(params string[] name)
		 {
			 if (name != null && name.Length > 0)
			 {
				 foreach (String s in name)
				 {
					 if (!containsTag(s))
					 {
						 return false;
					 }
				 }
				 return true;
			 }
			 return false;
		 }

		 /// <summary>
		 /// Returns a new block that includes (true) or excludes (false), depending on <code>includeOrExclude</code> flag
		 /// all tags with names matching any of the parameter names.<br>
		 /// Once a tagname is matched, it is removed from the list of tags to be matched, causing to be only included/excluded the first instance of every tagname.<br>
		 /// For example: 1, 2, 3, 4, 5, 6 filter by names 2, 4, 5 will return 1, 3, 6.
		 /// </summary>
		 /// <param name="include"> if true include all tags with given names, if false include all tags with a name <em>not</em> in names </param>
		 /// <param name="names"> list of tagnames to match </param>
		 /// <returns> a new list, an empty list if empty message, preconditions not met or nothing found
		 /// @since 7.2 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock filterByName(final boolean include, final String... names)
		 public virtual SwiftTagListBlock filterByName(bool include, params string[] names)
		 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = new SwiftTagListBlock();
			 SwiftTagListBlock result = new SwiftTagListBlock();
			 if (names.Length == 0)
			 {
				 if (include)
				 {
					 // do nothing, will return empty list later
				 }
				 else
				 {
					 // return all current tags since none is to be excluded
					 result.setTags(getTags());
				 }
			 }
			 else
			 {
				 string[] tagnames = names;
				 foreach (Tag t in this.tags)
				 {
					 // see if tag names is matched first
					 bool matched = false;
					 for (int j = 0; !matched && j < tagnames.Length; j++)
					 {
						 if (StringUtils.Equals(t.Name, tagnames[j]))
						 {
							 matched = true;
							 tagnames = ArrayUtils.remove(tagnames, j);
						 }
					 }
					 if (matched && include)
					 {
						 result.append(t);
					 }
					 if ((!matched) && !include)
					 {
						 result.append(t);
					 }
				 }
			 }
			 return result;
		 }

		 /// <summary>
		 /// Returns a new block that includes all tags with names matching any of the parameter names until a non matching tag is found.<br>
		 /// Once a tagname is matched, it is removed from the list of tags to be matched, causing to be only included/excluded the first instance of every tagname.<br>
		 /// For example: 1, 2, 3, 9, 4, 5, 6 filter by names 1, 2, 3, 4 will return 1, 2, 3.
		 /// </summary>
		 /// <param name="names"> list of tagnames to match </param>
		 /// <returns> a new list, an empty list if empty message, preconditions not met or nothing found
		 /// @since 7.2 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock filterByNameOrdered(final String... names)
		 public virtual SwiftTagListBlock filterByNameOrdered(params string[] names)
		 {
			 string[] tagnames = names;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = new SwiftTagListBlock();
			 SwiftTagListBlock result = new SwiftTagListBlock();
			 foreach (Tag t in getTags())
			 {
				 bool matched = false;
				 for (int j = 0; !matched && j < tagnames.Length; j++)
				 {
					 if (StringUtils.Equals(t.Name, tagnames[j]))
					 {
						 matched = true;
						 tagnames = (string[]) ArrayUtils.remove(tagnames, j);
						 result.append(t);
					 }
				 }
				 if (!matched)
				 {
					 break;
				 }
			 }
			 return result;
		 }

		/// @deprecated use <seealso cref="#getSubBlockBeforeFirst(String, boolean)"/> 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public SwiftTagListBlock removeAfterFirst(final String tagname, final boolean includeBoundaryInResult)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual SwiftTagListBlock removeAfterFirst(string tagname, bool includeBoundaryInResult)
		{
			DeprecationUtils.phase2(this.GetType(), "removeAfterFirst(String, boolean)", "Use getSubBlockBeforeFirst(String, boolean) instead.");
			return getSubBlockBeforeFirst(tagname, includeBoundaryInResult);
		}

		/// @deprecated use <seealso cref="#getSubBlockAfterFirst(String, boolean)"/> 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public SwiftTagListBlock removeUntilFirst(final String tagname, final boolean includeBoundaryInResult)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public virtual SwiftTagListBlock removeUntilFirst(string tagname, bool includeBoundaryInResult)
		{
			DeprecationUtils.phase2(this.GetType(), "removeUntilFirst(String, boolean)", "Use getSubBlockAfterFirst(String, boolean) instead.");
			return getSubBlockAfterFirst(tagname, includeBoundaryInResult);
		}

		 /// <summary>
		 /// Get all subblocks in message that start with tag with tagname, end with tag named endName and optionally, may be null, have optionalTail tag names at the end of the secuence
		 /// </summary>
		 /// <param name="start"> name of the tag that identifies the begin of the sequence </param>
		 /// <param name="end"> name of the tag that identifies the end of the sequence </param>
		 /// <param name="tail"> names of tags that are optional and belong to the sequence, the must be after endName </param>
		 /// <returns> an empty list if none found or prerequisites not met </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<SwiftTagListBlock> getSubBlocksDelimitedWithOptionalTail(final String[] start, final String[] end, final String[] tail)
		 public virtual IList<SwiftTagListBlock> getSubBlocksDelimitedWithOptionalTail(string[] start, string[] end, string[] tail)
		 {
			 if (tags != null && tags.Count > 0)
			 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftTagListBlock> result = new ArrayList<>();
				 IList<SwiftTagListBlock> result = new List<SwiftTagListBlock>();
				 int offset = 0;
				 bool done = false;
				 while (!done)
				 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int s = indexOfAnyFirstAfterIndex(offset, start);
					 int s = indexOfAnyFirstAfterIndex(offset, start);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int e = indexOfAnyFirstAfterIndex(s+1, end);
					 int e = indexOfAnyFirstAfterIndex(s + 1, end);

					 offset = e;
					 if (s == -1 || e == -1)
					 {
						 done = true;
					 }
					 else if (e >= s)
					 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock l = sublist(s, e);
						 SwiftTagListBlock l = sublist(s, e);
						 if (tail != null && tail.Length > 0)
						 {
							 bool abort = false;
							 for (int i = e+1;i < tags.Count && !abort;i++)
							 {
								 bool added = false;
								 foreach (String tn in tail)
								 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag tag = tags.get(i);
									 Tag tag = tags[i];
									 if (StringUtils.Equals(tag.Name, tn))
									 {
										 l.append(tag);
										 offset++;
										 added = true;
									 }
								 }
								 if (!added)
								 {
									 abort = true;
								 }
							 }
						 }
						 result.Add(l);
					 }
				 }

				 return result;
			 }
			 return java.util.Collections.emptyList();
		 }

		 /// <summary>
		 /// Similar to <seealso cref="#getSubBlockByTagNames(Integer, String...)"/> but will return
		 /// all matches for the indicated subblock </summary>
		 /// <returns> a list of found subblocks or empty if non matched
		 /// @since 7.8.5 </returns>
		 /// <returns> a list with the found blocks </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<SwiftTagListBlock> getSubBlocksByTagNames(final Integer startIndex, final String... searchTags)
		 public virtual IList<SwiftTagListBlock> getSubBlocksByTagNames(int? startIndex, params string[] searchTags)
		 {
			 IList<SwiftTagListBlock> result = new List<SwiftTagListBlock>();
			 int start = startIndex != null? startIndex : 0;
			 while (start < tags.Count)
			 {
				 SwiftTagListBlock found = new SwiftTagListBlock();
				 start = getSubBlockByTagNames(found, start, searchTags);
				 // continue on the tag following the last found
				 start++;
				 if (found.Empty)
				 {
					 break;
				 }
				 else
				 {
					 result.Add(found);
				 }
			 }
			 return result;
		 }

		 /// <summary>
		 /// Find a sub block given a comprehensive ordered list of search tag names.
		 /// <para>
		 /// For example given the block [20, 21, 32A, 54, 36, 36, 58B, 72] 
		 /// <ul> 
		 /// 	<li>search tags [32A, 36, 72] will return the subblock [32A, 36, 36, 72] notice repetitions are returned</li>
		 /// 	<li>search tags [36, 32A, 72] will return the subblock [36, 36, 72] notice order in search is important</li>
		 /// 	<li>search tags [36, 99, 72] will return the subblock [36, 36, 72] notice partial match is also returned</li>
		 /// </ul>
		 /// 
		 /// </para>
		 /// </summary>
		 /// <param name="startIndex"> optional starting offset, defaults to zero to search from the beginning of the block </param>
		 /// <param name="searchTags"> a list of tags to search, in order, for example: 20, 59A, 50K, 72 </param>
		 /// <returns> a new block with the found tags or an empty block if search produces no matches
		 /// @since 7.8.5 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlockByTagNames(final Integer startIndex, final String... searchTags)
		 public virtual SwiftTagListBlock getSubBlockByTagNames(int? startIndex, params string[] searchTags)
		 {
			 SwiftTagListBlock block = new SwiftTagListBlock();
			 getSubBlockByTagNames(block, startIndex, searchTags);
			 return block;
		 }

		/// <summary>
		/// Implementation for <seealso cref="#getSubBlockByTagNames(Integer, String...)"/> and <seealso cref="#getSubBlocksByTagNames(Integer, String...)"/> </summary>
		/// <param name="target"> a not null block where found fields will be appended </param>
		/// <param name="startIndex"> optional starting offset, defaults to zero to search from the beginning of the block </param>
		/// <param name="searchTags"> a list of tags to search, in order, for example: 20, 59A, 50K, 72 </param>
		/// <returns> the tag index of the last field added to the target block, useful to get multiple blocks
		/// @since 7.10.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private int getSubBlockByTagNames(final SwiftTagListBlock target, final Integer startIndex, final String... searchTags)
		 private int getSubBlockByTagNames(SwiftTagListBlock target, int? startIndex, params string[] searchTags)
		 {
			 int tagsIndex = startIndex != null? startIndex : 0;
			 int searchIndex = 0;
			 int lastAddedIndex = tagsIndex;
			 /*
			  * this loops does a linear iteration on message tags and
			  * several iterations on the search tags.
			  */
			 while (tagsIndex < tags.Count && searchIndex < searchTags.Length)
			 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag candidate = tags.get(tagsIndex);
				 Tag candidate = tags[tagsIndex];
				 /*
				  * try to match on search tags, from current search index
				  * up to end of search tags list
				  */
				 for (int j = searchIndex; j < searchTags.Length; j++)
				 {
					 if (candidate.Name.Equals(searchTags[j]))
					 {
						 /*
						  * save matched tag
						  */
						 target.append(candidate);
						 searchIndex = j;
						 lastAddedIndex = tagsIndex;
						 break;
					 }
				 }
				 if (searchIndex == searchTags.Length)
				 {
					 /*
					  * if we finished iteration on search and matched something, 
					  * break loop and return matched sub block.
					  */
					 if (!target.Empty)
					 {
						 return lastAddedIndex;
					 }
					 else
					 {
						 /*
						  * initialize iteration on search tags
						  */
						 searchIndex = 0;
					 }
				 }
				 tagsIndex++;
			 }
			 return lastAddedIndex;
		 }

		 /// <summary>
		 /// Get the first found sub block in message that start with tag with tagname, end with tag named endName and optionally, may be null, have optionalTail tag names at the end of the secuence </summary>
		 /// <param name="start"> name of the tag that identifies the begin of the sequence </param>
		 /// <param name="end"> name of the tag that identifies the end of the sequence </param>
		 /// <param name="tail"> names of tags that are optional and belong to the sequence, the must be after endName </param>
		 /// <returns> the found block or null if prerequisites are not met </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getSubBlockDelimitedWithOptionalTail(final String[] start, final String[] end, final String[] tail)
		 public virtual SwiftTagListBlock getSubBlockDelimitedWithOptionalTail(string[] start, string[] end, string[] tail)
		 {
			 if (tags != null && tags.Count > 0)
			 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int s = indexOfAnyFirst(start);
				 int s = indexOfAnyFirst(start);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int e = indexOfAnyFirstAfterIndex(s+1, end);
				 int e = indexOfAnyFirstAfterIndex(s + 1, end);

				 if (s != -1 && e != -1 && e >= s)
				 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = sublist(s, e);
					 SwiftTagListBlock result = sublist(s, e);
					 if (tail == null || tail.Length == 0)
					 {
						 return result;
					 }
					 bool abort = false;
					 for (int i = e+1;i < tags.Count && !abort;i++)
					 {
						 bool added = false;
						 foreach (String tn in tail)
						 {
							 if (StringUtils.Equals(tags[i].Name, tn))
							 {
								 result.append(tags[i]);
								 added = true;
							 }
						 }
						 if (!added)
						 {
							 abort = true;
						 }
					 }
					 return result;
				 }
			 }
			 return null;
		 }

		 /// <seealso cref= #getOptionalList(String[][], int) </seealso>
		 /// <param name="optionalTags"> the rows of optional tags </param>
		 /// <returns> a new block with the found fields </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getOptionalList(final String[][] optionalTags)
		 public virtual SwiftTagListBlock getOptionalList(string[][] optionalTags)
		 {
			 return getOptionalList(optionalTags, 0);
		 }

		/// <summary>
		/// Search a sequence of optional tags. inside each row, only one is matched.
		/// stop conditions: a tag is not in the optional row being processed or any future row or there are no more rows </summary>
		/// <param name="optionalTags"> the rows of optional tags </param>
		/// <param name="startAt"> the starting index, zero-based </param>
		/// <returns> a new block with the found fields </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock getOptionalList(final String[][] optionalTags, final int startAt)
		 public virtual SwiftTagListBlock getOptionalList(string[][] optionalTags, int startAt)
		 {
			 if (this.tags != null && this.tags.Count > 0)
			 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = new SwiftTagListBlock();
				 SwiftTagListBlock result = new SwiftTagListBlock();
				 bool done = false;
				 int t = startAt;
				 int rowPointer = 0;
				 do
				 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag tag = this.tags.get(t++);
					 Tag tag = this.tags[t++];
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int rowIndex = findTagInRowSince(tag, rowPointer, optionalTags);
					 int rowIndex = findTagInRowSince(tag, rowPointer, optionalTags);
					 if (rowIndex >= 0)
					 {
						 rowPointer = rowIndex + 1;
						 result.append(tag);
					 }
					 else
					 {
						 // no se encontro, ni aca ni en lo que queda el tag,
						 done = true;
					 }
				 } while (!done);
				 return result;
			 }
			 return null;
		 }

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private int findTagInRowSince(final Tag tag, final int rowPointer, final String[][] optionalTags)
		 private int findTagInRowSince(Tag tag, int rowPointer, string[][] optionalTags)
		 {
			 for (int r = rowPointer;r < optionalTags.Length;r++)
			 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String[] row = optionalTags[r];
				 string[] row = optionalTags[r];
				 for (int i = 0;i < row.Length;i++)
				 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String op = row[i];
					 string op = row[i];
					 if (StringUtils.Equals(tag.Name, op))
					 {
						 return r;
					 }
				 }
			 }
			 return -1;
		 }

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<SwiftTagListBlock> getOptionalLists(final String[][] optionalTags)
		 public virtual IList<SwiftTagListBlock> getOptionalLists(string[][] optionalTags)
		 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftTagListBlock> result = new ArrayList<>();
			 IList<SwiftTagListBlock> result = new List<SwiftTagListBlock>();
			 if (this.tags != null && this.tags.Count > 0)
			 {
				 bool done = false;
				 int offset = 0;
				 while (!done)
				 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock o = getOptionalList(optionalTags, offset);
					 SwiftTagListBlock o = getOptionalList(optionalTags, offset);
					 offset += o.size();

					 if (offset > this.tags.Count || o.Empty)
					 {
						 done = true;
					 }
					 if (!o.Empty)
					 {
						 result.Add(o);
					 }
				 }
			 }
			 return result;
		 }

		 public virtual IList<string> tagNamesList()
		 {
			 if (this.tags == null || this.tags.Count == 0)
			 {
				 return java.util.Collections.emptyList();
			 }
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<String> result = new ArrayList<>();
			 IList<string> result = new List<string>();
			 foreach (Tag t in this.tags)
			 {
				 result.Add(t.Name);
			 }
			 return result;
		 }

		 /// <summary>
		 /// Counts tags starting with the given value </summary>
		 /// <param name="name"> the exact name of the tag to be matched </param>
		 /// <param name="value"> the value that will be used to test if tag value startsWith </param>
		 /// <seealso cref= Tag#startsWith(String) </seealso>
		 /// <returns> the count result </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int countTagsStarsWith(final String name, final String value)
		 public virtual int countTagsStarsWith(string name, string value)
		 {
			 int result = 0;
			 if (this.tags != null && this.tags.Count > 0)
			 {
				 foreach (Tag t in this.tags)
				 {
					 if (StringUtils.Equals(name, t.Name) && t.StartsWith(value, StringComparison.Ordinal))
					 {
						 result++;
					 }
				 }
			 }
			 return result;
		 }

		 /// <summary>
		 /// Return a new block with all tags until the first tagname with the given name that start with startsWith </summary>
		 /// <param name="name"> a field name </param>
		 /// <param name="startsWith"> the starting field content to search </param>
		 /// <returns> a new block with the trimmed content </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock removeAfterFirstStartsWith(final String name, final String startsWith)
		 public virtual SwiftTagListBlock removeAfterFirstStartsWith(string name, string startsWith)
		 {
			 if (this.tags == null || this.tags.Count > 0)
			 {
				 return new SwiftTagListBlock();
			 }

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<Tag> tags = new ArrayList<>();
			 IList<Tag> tags = new List<Tag>();
			 bool done = false;
			 for (int i = 0;i < this.tags.Count && !done;i++)
			 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = this.tags.get(i);
				 Tag t = this.tags[i];
				 if (StringUtils.Equals(t.Name, name) && t.StartsWith(startsWith, StringComparison.Ordinal))
				 {
					 done = true;
				 }
				 else
				 {
					 tags.Add(t);
				 }
			 }
			 return new SwiftTagListBlock(tags);
		 }

		/// <summary>
		/// Legacy (version 1) json representation of this object.
		/// 
		/// <para>This implementation has been replaced by version 2, based on Gson.
		/// The main difference is the list of tags in the new version is serialized
		/// as a named field "tags".
		/// 
		/// </para>
		/// </summary>
		/// @deprecated use <seealso cref="#toJson()"/> instead
		/// @since 7.9.8 
		/// <returns> a string with the message content serialized as JSON </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#toJson()"/> instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public String toJsonV1()
		[Obsolete("use <seealso cref="#toJson()"/> instead")]
		public virtual string toJsonV1()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			sb.Append("[ \n");
			if (this.tags != null && this.tags.Count > 0)
			{
				for (int i = 0;i < this.tags.Count;i++)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = this.tags.get(i);
					Tag t = this.tags[i];
					sb.Append("{ \"").Append(t.Name).Append("\" : \"").Append(escapeJson(t.Value)).Append("\" }");
					if (i + 1 < this.tags.Count)
					{
						sb.Append(',');
					}
					sb.Append('\n');
				}
			}
			sb.Append("]");
			return sb.ToString();
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String escapeJson(final String value)
		 private string escapeJson(string value)
		 {
			 string tmp = StringUtils.replace(value, "\n", "\\n");
			 tmp = StringUtils.replace(tmp, "\"", "\\\"");
			 tmp = StringUtils.remove(tmp, "\r");
			 return tmp;
		 }

		/// <summary>
		/// Get a json representation of this block.
		/// 
		/// Example:<br>
		/// <pre>
		/// {
		///  "tags": [
		///  {
		///  "name": "113",
		///  "value": "SEPA"
		///  },
		///  {
		///  "name": "20",
		///  "value": "REFERENCE"
		///  }
		///  ]
		/// }
		///  </pre>
		/// 
		/// @since 7.9.8 </summary>
		/// <returns> a string with the message content serialized as JSON </returns>
		public virtual string toJson()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().create();
			Gson gson = (new GsonBuilder()).create();
			return gson.toJson(this);
		}

		 /// <summary>
		 /// Appends all tags in block to the contents of this block </summary>
		 /// <param name="block"> a block to append </param>
		 /// <returns> the current instance </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock append(final SwiftTagListBlock block)
		 public virtual SwiftTagListBlock append(SwiftTagListBlock block)
		 {
			 if ((block != null) && !block.Empty)
			 {
				 this.tags.AddRange(block.getTags());
			 }
			 return this;
		 }

		 /// <summary>
		 /// Appends all blocks to the end of this one.
		 /// </summary>
		 /// <param name="blocks"> may be null or empty, if so nothing happens </param>
		 /// <returns> the current updated list
		 /// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock append(final SwiftTagListBlock... blocks)
		 public virtual SwiftTagListBlock append(params SwiftTagListBlock[] blocks)
		 {
			 if ((blocks != null) && blocks.Length > 0)
			 {
				 foreach (SwiftTagListBlock b in blocks)
				 {
					 this.tags.AddRange(b.Tags);
				 }
			 }
			 return this;
		 }

		 /// <summary>
		 /// Add the given tag to the end of the list </summary>
		 /// <param name="tag"> the tag to add, must not be null </param>
		 /// <returns> <code>this</code> </returns>
		 /// <exception cref="IllegalArgumentException"> if tag is null
		 /// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock append(final Tag tag)
		 public virtual SwiftTagListBlock append(Tag tag)
		 {
			 Validate.notNull(tag);
			 this.tags.Add(tag);
			 return this;
		 }

		 /// <summary>
		 /// Appends all tags to the current block </summary>
		 /// <param name="tags"> the tags to append. may be null in which case nothing happens </param>
		 /// <returns> <code>this</code>
		 /// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock append(final Tag... tags)
		 public virtual SwiftTagListBlock append(params Tag[] tags)
		 {
			 if ((tags != null) && tags.Length > 0)
			 {
				 foreach (Tag t in tags)
				 {
					 this.tags.Add(t);
				 }
			 }
			 return this;
		 }

		 /// <summary>
		 /// Add the given field to the end of the list. 
		 /// The Field components are serialized into a plain value usign the getValue implementation 
		 /// of the Field object, and this created value is use for the internal Tag actually set into
		 /// the block.
		 /// </summary>
		 /// <param name="field"> the field to add, must not be null </param>
		 /// <returns> <code>this</code> </returns>
		 /// <exception cref="IllegalArgumentException"> if field is null
		 /// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock append(final com.prowidesoftware.swift.model.field.Field field)
		 public virtual SwiftTagListBlock append(Field field)
		 {
			 Validate.notNull(field);
			 this.tags.Add(field.asTag());
			 return this;
		 }

		 /// <summary>
		 /// Appends all fields to the current block </summary>
		 /// <param name="fields"> the fields to append. may be null in which case nothing happens </param>
		 /// <returns> <code>this</code>
		 /// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftTagListBlock append(final com.prowidesoftware.swift.model.field.Field... fields)
		 public virtual SwiftTagListBlock append(params Field[] fields)
		 {
			 if ((fields != null) && fields.Length > 0)
			 {
				 foreach (Field f in fields)
				 {
					 append(f);
				 }
			 }
			 return this;
		 }

		 public virtual IEnumerator<Tag> GetEnumerator()
		 {
			 if (this.tags == null)
			 {
				 System.Linq.Enumerable.Empty<Tag>().GetEnumerator();
			 }
			 return this.tags.GetEnumerator();
		 }

		 /// <summary>
		 /// Get the content of this tag block as a Tag array.
		 /// Returns an empty array if this list is empty.
		 /// </summary>
		 /// <returns> this block taqs objects as array
		 /// @since 7.8 </returns>
		 public virtual Tag[] asTagArray()
		 {
			 if (this.size() > 0)
			 {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag[] result = new Tag[this.size()];
				 Tag[] result = new Tag[this.size()];
				 int i = 0;
				 foreach (Tag t in this.tags)
				 {
					 result[i++] = t;
				 }
				 return result;
			 }
			 return new Tag[0];
		 }

		 /// <summary>
		 /// Removes all tags from the backing storage. </summary>
		 /// <returns> this
		 /// @since 7.8 </returns>
		 public virtual SwiftTagListBlock clear()
		 {
			 if (this.tags != null)
			 {
				 this.tags.Clear();
			 }
			 return this;
		 }

		 public override string Name
		 {
			 get
			 {
				//unused
				return null;
			 }
		 }

		 public override int? Number
		 {
			 get
			 {
				//unused
				return null;
			 }
		 }

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void setBlockName(final String blockName)
		 protected internal override string BlockName
		 {
			 set
			 {
				//unused
			 }
		 }

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void setBlockNumber(final Integer blockNumber)
		 protected internal override int? BlockNumber
		 {
			 set
			 {
				//unused
			 }
		 }

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void visit(final TagVisitor visitor)
		 public virtual void visit(TagVisitor visitor)
		 {
			if (visitor != null)
			{
				if (this.tags != null && this.tags.Count > 0)
				{
					foreach (Tag t in this.tags)
					{
						visitor.onTag(t);
					}
				}
			}
		 }

		/// <summary>
		/// Return the list of fields in this block.
		/// <para>THe implementation iterates the existing Tag objects and for each
		/// calls the <seealso cref="Tag#asField()"/> method to create the corresponding
		/// Field instance
		/// </para>
		/// </summary>
		/// <returns> a list of fields in this block or an empty list if the block is empty
		/// @since 7.10.4 </returns>
		public virtual IList<Field> fields()
		{
			IList<Field> fields = new List<Field>();
			 foreach (Tag tag in this.tags)
			 {
				 fields.Add(tag.asField());
			 }
			 return fields;
		}

		/// <summary>
		/// Helper method to retrieve all sequences starting with the parameter field.
		/// The boundary field can be indicated with or without the letter option. For example if number 15
		/// is passed with null letter option, this is like splitting by 15a (15A, 15B, 15C, etc..), each time
		/// a field 15 is found a new split is done regardless of the letter option. Converselly if a specific
		/// letter option is passed, the split is done when that particular number and letter combination is found.
		/// If the boundary field is nor present, the result will be empty. </summary>
		/// <param name="tagNumber"> the tag number </param>
		/// <param name="letterOption"> optional letter option, if null, split is done by tag number for any letter option </param>
		/// <returns> found subsequences or an empty list if boundary tag is not found
		/// @since 7.10.4 </returns>
		public virtual IList<SwiftTagListBlock> splitByTagName(int tagNumber, string letterOption)
		{
			if (letterOption != null)
			{
				Validate.isTrue(StringUtils.length(letterOption) == 1, "letter option must be only one character");
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftTagListBlock> result = new ArrayList<>();
			IList<SwiftTagListBlock> result = new List<SwiftTagListBlock>();
			SwiftTagListBlock currentBlock = null;
			foreach (Tag t in this.tags)
			{
				if (t.Number == tagNumber)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String letter = t.getLetterOption();
					string letter = t.LetterOption;
					if (letterOption == null || letterOption.Equals(letter))
					{
						currentBlock = new SwiftTagListBlock();
						result.Add(currentBlock);
					}
				}
				if (currentBlock != null)
				{
					currentBlock.append(t);
				}
			}
			return result;
		}

	}

}