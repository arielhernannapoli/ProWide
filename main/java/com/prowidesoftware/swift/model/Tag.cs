using System;
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

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using Field = com.prowidesoftware.swift.model.field.Field;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Representation of a swift field in a message.
	/// 
	/// <para>The "Tag" naming is used in the SWIFT standard to refer the fields identifiers
	/// composed by a number and an optional letter option, for example 32A. This class
	/// is used to model the complete field structure including both the field name ("Tag")
	/// and the field value.
	/// 
	/// </para>
	/// <para>Instances of this class may have a list of unparsed texts (UnparsedTextList).
	/// For easy access, methods have been created that first ensure the lists exists (the
	/// real object is created and then call the base method).<br>
	/// However, not all the base list methods have been implemented. If you need to use not
	/// exposed functionality, retrieve the underlying list with (see <seealso cref="#getUnparsedTexts()"/>)
	///  
	/// @author www.prowidesoftware.com
	/// </para>
	/// </summary>
	[Serializable]
	public class Tag
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(Tag).FullName);

		private const long serialVersionUID = -1066430327311949399L;

		/// <summary>
		/// Unique identified when this tag is a persisted element </summary>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) protected Long id;
		[Obsolete("use persistence mapping in the AbstractSwiftMessage model instead")]
		protected internal long? id;

		/// <summary>
		/// Indicates the position of this tag in a message when persisted.
		/// This value is used to remember the positions of the tags inside 
		/// a block when persisted. This value may not be set when persistence
		/// is not used and should not be used by clients. </summary>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) @Deprecated protected Integer sortKey;
		[Obsolete]
		protected internal int? sortKey;

		/// <summary>
		/// Name of the tag, usually a number that may be followed by a letter.
		/// This value may be null.
		/// </summary>
		protected internal string name;

		/// <summary>
		/// Value of the corresponding tag.
		/// </summary>
		protected internal string value;

		/// <summary>
		/// List of unparsed texts. For performance reasons, this will be null until really needed.
		/// </summary>
		protected internal UnparsedTextList unparsedTexts = null;

		/// <summary>
		/// Reference to the sequence node, if any, that this tags belongs to. </summary>
		/// @deprecated to retrieve fields in sequences use the AbstractMT model 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("to retrieve fields in sequences use the AbstractMT model") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) protected transient SequenceNode sequence = null;
		[Obsolete("to retrieve fields in sequences use the AbstractMT model"), NonSerialized]
		protected internal SequenceNode sequence = null;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Tag()
		{
		}

		/// <summary>
		/// Create a tag from the value in inner.
		/// <para>
		/// If inner contains one ':' character, the string before is set as the tag name and the rest as the value.
		/// If inner contains more than one ':' characters, then the first value is used as previously described.
		/// If no ':' character is found the whole string is set as the tag value and the tag name is kept null (useful for bloc data)
		/// 
		/// </para>
		/// <para>
		/// Maps:
		/// <pre>
		/// "" -&gt; name=null, value=null
		/// "foo" -&gt; name=null, value=foo
		/// ":foo" -&gt; name=null, value=foo
		/// "foo:" -&gt; name=foo, value=null
		/// "foo:bar" -&gt; name=foo, value=bar
		/// </pre>
		/// 
		/// </para>
		/// </summary>
		/// <param name="inner"> the string to build the tag </param>
		/// <exception cref="IllegalArgumentException"> if inner is null </exception>
		public Tag(string inner)
		{

			// sanity check
			Validate.notNull(inner, "parameter 'inner' cannot be null");

			// analyze how to split the inner value
			int i = inner.IndexOf(':');
			if (i >= 0)
			{
				if (i > 0)
				{
					this.name = inner.Substring(0, i);
				}
				if (i + 1 < inner.Length)
				{
					this.value = inner.Substring(i + 1);
				}
			}
			else
			{
				if (inner.Length > 0)
				{
					this.value = inner;
				}
			}
		}

		/// <summary>
		/// Create a tag with the given tagname and value </summary>
		/// <param name="tagname"> name of this tag </param>
		/// <param name="value"> the value of this tag </param>
		/// <exception cref="IllegalArgumentException"> if parameter tagname or value are null </exception>
		public Tag(string tagname, string value)
		{

			// sanity check
			Validate.notNull(tagname, "parameter 'tagname' cannot be null");
			Validate.notNull(value, "parameter 'value' cannot be null");

			this.name = tagname;
			this.value = value;
		}

		/// <summary>
		/// Constructor for an unparsed text list </summary>
		/// <param name="unparsedText"> the list of unparsed texts </param>
		/// <seealso cref= Tag#Tag() </seealso>
		public Tag(UnparsedTextList unparsedText) : this()
		{

			// base constructor

			// set the unparsed text list
			this.unparsedTexts = unparsedText;
		}

		/// <summary>
		/// Constructor for tag encoded value and an unparsed text list </summary>
		/// <param name="inner"> the string to build the tag </param>
		/// <param name="unparsedText"> the list of unparsed texts </param>
		/// <exception cref="IllegalArgumentException"> if parameter inner is null </exception>
		/// <seealso cref= Tag#Tag(String) </seealso>
		public Tag(string inner, UnparsedTextList unparsedText) : this(inner)
		{

			// base constructor

			// set the unparsed text list
			this.unparsedTexts = unparsedText;
		}

		/// <summary>
		/// Constructor for tag name and value and an unparsed text list </summary>
		/// <param name="tagname"> name of this tag </param>
		/// <param name="value"> the value of this tag </param>
		/// <param name="unparsedText"> the list of unparsed texts </param>
		/// <exception cref="IllegalArgumentException"> if parameter tagname or value are null </exception>
		/// <seealso cref= Tag#Tag(String,String) </seealso>
		public Tag(string tagname, string value, UnparsedTextList unparsedText) : this(tagname, value)
		{

			// base constructor

			// set the unparsed text list
			this.unparsedTexts = unparsedText;
		}

		/// <summary>
		/// Get the name of this tag </summary>
		/// <returns> a string with the current tag name </returns>
		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
    
				// sanity check
				Validate.notNull(value, "parameter 'name' cannot be null");
    
				this.name = value;
			}
		}


		/// <summary>
		/// Get the value of the tag.<br> 
		/// Notice that in some cases the value can be null,
		/// for example the value of the "DLM" tag in this block:<br> 
		/// {5:{CHK:F9351591947F}{SYS:1610010606VNDZBET2AXXX0019000381}{DLM:}}
		/// 
		/// </summary>
		/// <returns> a string with the value of the tag or null if the value was not set </returns>
		//TODO review parser implementation and check if always null is set or empty string
		public virtual string Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}


		public override string ToString()
		{
			return (new StringBuilder()).Append("Tag[").Append(name).Append(":").Append(value).Append("]").ToString();
		}

		/// <summary>
		/// Get the unique identifier of the tag if it is persisted </summary>
		/// <returns> the unique id or null if it is not a persistent object </returns>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public Long getId()
		[Obsolete("use persistence mapping in the AbstractSwiftMessage model instead")]
		public virtual long? Id
		{
			get
			{
				return id;
			}
			set
			{
    
				this.id = value;
			}
		}

		/// <summary>
		/// Set the unique identifier of the tag if it is persisted </summary>
		/// <param name="id"> the id to be set </param>
		/// <seealso cref= #sortKey </seealso>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public void setId(Long id)

		/// <summary>
		/// get the sortkey of this tag </summary>
		/// <returns> an integer with the current sortkey </returns>
		/// <seealso cref= #sortKey </seealso>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public Integer getSortKey()
		[Obsolete("use persistence mapping in the AbstractSwiftMessage model instead")]
		public virtual int? SortKey
		{
			get
			{
				return sortKey;
			}
			set
			{
				this.sortKey = value;
			}
		}

		/// <summary>
		/// Set the sortkey of this tag.
		/// This value may be changed by clients when persistence is used and the order of the tags
		/// in a message are being modified. </summary>
		/// <param name="sortKey"> the new sortkey </param>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public void setSortKey(Integer sortKey)

		/// <summary>
		/// verifies that the unparsed text list exists
		/// </summary>
		protected internal virtual void unparsedTextVerify()
		{
			if (this.unparsedTexts == null)
			{
				this.unparsedTexts = new UnparsedTextList();
			}
		}

		/// <summary>
		/// returns the unparsed text list </summary>
		/// <returns> the unparsed text attached to this tag object </returns>
		public virtual UnparsedTextList UnparsedTexts
		{
			get
			{
    
				// create the list if needed
				unparsedTextVerify();
				return (this.unparsedTexts);
			}
			set
			{
    
				this.unparsedTexts = value;
			}
		}


		/// <summary>
		/// returns the size of the unparsed text list </summary>
		/// <returns> the count of unparsed texts attached to this tag object </returns>
		public virtual int? UnparsedTextsSize
		{
			get
			{
    
				// no list => size is zero...
				if (this.unparsedTexts == null)
				{
					return new int?(0);
				}
				return this.unparsedTexts.size();
			}
		}

		/// <summary>
		/// decides if a specific text (by index) is likely a SWIFT FIN message. Exceptions are inherited from
		/// base implementation methods. </summary>
		/// <param name="index"> the unparsed text number </param>
		/// <returns> true if the unparsed text at position index is a full SWIFT message </returns>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		/// <exception cref="IndexOutOfBoundsException"> if parameter index is out of bounds </exception>
		public virtual bool? unparsedTextIsMessage(int? index)
		{

			// create the list if needed
			unparsedTextVerify();
			return (this.unparsedTexts.isMessage(index));
		}

		/// <summary>
		/// get an unparsed text </summary>
		/// <param name="index"> the unparsed text number </param>
		/// <returns> the requested text </returns>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		/// <exception cref="IndexOutOfBoundsException"> if parameter index is out of bounds </exception>
		public virtual string unparsedTextGetText(int? index)
		{

			// create the list if needed
			unparsedTextVerify();
			return (this.unparsedTexts.getText(index));
		}

		/// <summary>
		/// get an unparsed text as a parsed swift message </summary>
		/// <param name="index"> the unparsed text number </param>
		/// <returns> the unparsed text at position index parsed into a SwiftMessage object </returns>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		public virtual SwiftMessage unparsedTextGetAsMessage(int? index)
		{

			// create the list if needed
			unparsedTextVerify();
			return (this.unparsedTexts.getTextAsMessage(index));
		}

		/// <summary>
		/// adds a new unparsed text </summary>
		/// <param name="text"> the unparsed text to append </param>
		/// <exception cref="IllegalArgumentException"> if parameter text is null </exception>
		public virtual void unparsedTextAddText(string text)
		{

			// create the list if needed
			unparsedTextVerify();
			this.unparsedTexts.addText(text);
		}

		/// <summary>
		/// adds a new unparsed text from a message </summary>
		/// <param name="message"> the message to be appended </param>
		/// <exception cref="IllegalArgumentException"> if parameter message is null </exception>
		public virtual void unparsedTextAddText(SwiftMessage message)
		{

			// create the list if needed
			unparsedTextVerify();
			this.unparsedTexts.addText(message);
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
			Tag tag = (Tag) o;
			return Objects.Equals(sortKey, tag.sortKey) && Objects.Equals(name, tag.name) && Objects.Equals(value, tag.value) && Objects.Equals(unparsedTexts, tag.unparsedTexts) && Objects.Equals(sequence, tag.sequence);
		}

		public override int GetHashCode()
		{
			return Objects.hash(sortKey, name, value, unparsedTexts, sequence);
		}

		/// <summary>
		/// Similar to <seealso cref="#equals(Object)"/> but ignoring carriage returns characters in tag values.
		/// Meaning CRLF in any of the tags will match both CRLF in the other tag and just LF in the other tag </summary>
		/// <param name="other"> another tag to compare </param>
		/// <returns> true if both tags are equals despite the CR
		/// @since 7.9.3 </returns>
		public virtual bool equalsIgnoreCR(Tag other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (name == null)
			{
				if (other.name != null)
				{
					return false;
				}
			}
			else if (!name.Equals(other.name))
			{
				return false;
			}
			if (sortKey == null)
			{
				if (other.sortKey != null)
				{
					return false;
				}
			}
			else if (!sortKey.Equals(other.sortKey))
			{
				return false;
			}
			if (unparsedTexts == null)
			{
				if (other.unparsedTexts != null)
				{
					return false;
				}
			}
			else if (!unparsedTexts.Equals(other.unparsedTexts))
			{
				return false;
			}
			if (value == null)
			{
				if (other.value != null)
				{
					return false;
				}
			}
			else if (!StringUtils.replace(value, "\r", "").Equals(StringUtils.replace(other.value, "\r", "")))
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Attempt to parse the tag name as an integer.
		/// <em>Note that for 15A this method will return -1</em>
		/// </summary>
		/// <returns> the resulting value of parsing the tagname as an integer or -1 if an error occurs </returns>
		public virtual int NameAsInt
		{
			get
			{
				try
				{
					return Convert.ToInt32(this.name);
				}
				catch (Exception)
				{
					return -1;
				}
			}
		}

		/// <summary>
		/// Tells if this tagname is a given number, so the integer 58 will match 58A and 58D.
		/// </summary>
		/// <param name="n"> the number that this tagname will be compared to </param>
		/// <returns> <code>true</code> if this tagname starts with the given number or <code>false</code> in any other case </returns>
		public virtual bool isNumber(int n)
		{
			return this.name != null && Number != null && Number.Equals(n);
		}

		/// <summary>
		/// Iterate the current tagname and return only number as told by <seealso cref="Character#isDigit(char)"/>
		/// </summary>
		/// <returns> an integer containing the numeric of the tagname or null if no digits are found
		/// @since 6.2 </returns>
		public virtual int? Number
		{
			get
			{
				if (this.name != null)
				{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
					StringBuilder sb = new StringBuilder();
					for (int i = 0;i < this.name.Length;i++)
					{
						char c = this.name[i];
						if (char.IsDigit(c))
						{
							sb.Append(c);
						}
					}
					if (sb.Length > 0)
					{
						return Convert.ToInt32(sb.ToString());
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Iterate the current tagname and return only letters as told by <seealso cref="Character#isLetter(char)"/>
		/// </summary>
		/// <returns> a string containing only letter characters of the tagname or null if no letters are found </returns>
		public virtual string LetterOption
		{
			get
			{
				if (this.name != null)
				{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
					StringBuilder sb = new StringBuilder();
					for (int i = 0;i < this.name.Length;i++)
					{
						char c = this.name[i];
						if (char.IsLetter(c))
						{
							sb.Append(c);
						}
					}
					if (sb.Length > 0)
					{
						return sb.ToString();
					}
				}
				return null;
			}
		}

		/// @deprecated use <seealso cref="#asField()"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#asField()"/> instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public com.prowidesoftware.swift.model.field.Field getField()
		[Obsolete("use <seealso cref="#asField()"/> instead")]
		public virtual Field Field
		{
			get
			{
				return Field.getField(this);
			}
		}

		/// <summary>
		/// Tell if this tag value contains any of the given values.
		/// This method is case sensitive. It handles null values. </summary>
		/// <param name="values"> variable list of values to test </param>
		/// <returns> <code>true</code> if the value of this tag is one of the given values. 
		/// returns <code>false</code> in any other case, including a null or empty list of values </returns>
		public virtual bool contains(params string[] values)
		{
			if (values != null && values.Length > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String _v = getValue();
				string _v = Value;
				foreach (string v in values)
				{
					if (StringUtils.contains(_v, v))
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Shorthand equivalent to calling first <seealso cref="#setName(String)"/> and then <seealso cref="#setValue(String)"/> </summary>
		/// <param name="name"> the tagname </param>
		/// <param name="value"> the tagvalue </param>
		public virtual void setNameValue(string name, string value)
		{
			Name = name;
			Value = value;
		}

		/// <summary>
		/// equivalent to StringUtils.startsWith(tag.getValue(), prefix)
		/// </summary>
		public virtual bool StartsWith(string prefix)
		{
			return StringUtils.StartsWith(Value, prefix);
		}

		/// <summary>
		/// equivalent to StringUtils.contains(tag.getValue(), searchStr)
		/// </summary>
		public virtual bool contains(string searchStr)
		{
			return StringUtils.contains(Value, searchStr);
		}

		/// <summary>
		/// Creates a Field instance for the given Tag object. </summary>
		/// <returns> a specific field object (example: Field32A) or null if exceptions occur during object creation. </returns>
		/// <seealso cref= Field#getField(Tag) </seealso>
		public virtual Field asField()
		{
			return Field.getField(this);
		}

	}

}