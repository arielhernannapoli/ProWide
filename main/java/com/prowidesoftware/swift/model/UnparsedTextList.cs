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

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using ConversionService = com.prowidesoftware.swift.io.ConversionService;
	using Validate = org.apache.commons.lang3.Validate;
	using ToStringBuilder = org.apache.commons.lang3.builder.ToStringBuilder;


	/// <summary>
	/// <para>List of unparsed texts for messages, blocks or tags.<br>
	/// For performance reasons, the
	/// unparsed texts are stored directly as strings inside this list object. The need then
	/// for this object (as opposed to directly using a List) is for some functionality
	/// aggregation, specially if you consider that the same is used in all levels of the
	/// message structure.
	/// 
	/// </para>
	/// <para>It is expected that classes that use this object do not create unnecessary instances of
	/// this (also for performance reasons). The motive become obvious when you consider that
	/// an average SWIFT message will have 4 blocks (1, 2, 3 and 4) and that block 4 will have
	/// at least 20 tags (so the count of instances of this will be: 1 for the message, 4 for the
	/// blocks and 20 for the tags, giving 25). For more complex messages, the number is near
	/// linear with the number of tags, while at the same time, most of those messages will have
	/// no unparsed texts.
	/// 
	/// </para>
	/// <para>For this, it is expected that the message, block and tag objects will have some convenience
	/// methods to access this class methods only if they have a valid object.
	/// 
	/// </para>
	/// <para>This class will be used in four different scenarios:
	/// 
	/// </para>
	/// <para>1) SERVICE MESSAGES (for example: ACK)
	/// 
	/// </para>
	/// <para>It's been reported that Swift Alliance Access appends the original message to the ACK on
	/// delivery. In this case, the appended original message will be attached to the ACK as an
	/// unparsed text
	/// 
	/// </para>
	/// <para>2) SOME SYSTEM MESSAGES (for example: MT 021, Retrieval Response)
	/// 
	/// </para>
	/// <para>In this case, as per documentation, the retrieved message is appended in block 4, after
	/// the tags of the message. In this case, the original (retrieved) message is appended to
	/// block 4 as an unparsed text.
	/// 
	/// </para>
	/// <para>3) SOME REPORT MESSAGES (for example: MT 056, LT History Report)
	/// 
	/// </para>
	/// <para>In this case, complete messages (one or more) are appended to a tag value.
	/// An example of this is MT 056 (LT History Report) where the original login request and
	/// the associated login response (optional) are appended to TAG 270 value. Here, two
	/// unparsed texts are appended to tag 270 of the parsed message.
	/// 
	/// </para>
	/// <para>4) USER DEFINED BLOCKS
	/// 
	/// </para>
	/// <para>As part of the user defined blocks support, we have decided to append the (complete) original
	/// block text as an unparsed text to the User Block (class SwiftBlockUser) to allow for some
	/// degree of liberty regarding data encoding in these blocks (however, these user defined blocks
	/// where designed considering that they behave as standard block 3 or 5.
	/// 
	/// @since 5.0
	/// </para>
	/// </summary>
	[Serializable]
	public class UnparsedTextList
	{
		private const long serialVersionUID = 7302986014143689797L;
		private const string WRITER_MESSAGE = "parameter 'index' cannot be null";

		/// <summary>
		/// Unique identifier of the unparsed texts list.
		/// Mainly used for persistence services. </summary>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) private Long id;
		[Obsolete("use persistence mapping in the AbstractSwiftMessage model instead")]
		private long? id;

		/// <summary>
		/// list of unparsed texts
		/// 
		/// @since 5.0
		/// </summary>
		private IList<string> texts = new List<string>();

		/// <summary>
		/// Default Constructor 
		/// </summary>
		public UnparsedTextList() : base()
		{
		}

		/// <summary>
		/// Constructor from a collection of texts </summary>
		/// <param name="texts"> the list of unparsed texts to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter texts is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter texts has elements of class other than String </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public UnparsedTextList(final Collection<String> texts)
		public UnparsedTextList(ICollection<string> texts)
		{
			// sanity check
			Validate.notNull(texts, "parameter 'texts' cannot be null");
			this.texts = new List<>(texts);
		}

		/// <summary>
		/// Get the unique identifier of this unparsed text list or null if it is not set </summary>
		/// <returns> the unique identifier </returns>
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
		/// Sets the unique identifier of this unparsed text list </summary>
		/// <param name="id"> the unique identifier to set. </param>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public void setId(final Long id)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:

		/// <summary>
		/// gets as FIN string, conforming a String object with the concatenation of the unparsed texts. </summary>
		/// <returns> String concatenation of the unparsed texts </returns>
		public virtual string AsFINString
		{
			get
			{
				// performance optimization
				if (this.texts.Count == 0)
				{
					return ("");
				}
    
				// visit every unparsed text
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final StringBuilder s = new StringBuilder();
				StringBuilder s = new StringBuilder();
				for (final IEnumerator<string> itr = this.texts.GetEnumerator(); itr.hasNext();)
				{
					s.Append(itr.next());
				}
				;
    
				return (s.ToString());
			}
		}

		/// <summary>
		/// convert this to string
		/// </summary>
		public override string ToString()
		{
			return (ToStringBuilder.reflectionToString(this));
		}

		/// <summary>
		/// decides if it is likely that an unparsed text is a SWIFT FIN message.<br>
		/// It is considered that a text it is likely to be message if it contains
		/// the text "{1:". </summary>
		/// <param name="text"> the text to analyze </param>
		/// <returns> true if the text is likely to be a SWIFT message </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Boolean isMessage(final String text)
		public static bool? isMessage(string text)
		{
			// sanity check and evaluation
			return Convert.ToBoolean((text != null && (text.IndexOf("{1:", StringComparison.Ordinal) >= 0)));
		}

		/// <summary>
		/// returns the full list of unparsed texts </summary>
		/// <returns> the list of texts </returns>
		public virtual IList<string> Texts
		{
			get
			{
				return (this.texts);
			}
			set
			{
				// setup the new list
				this.texts = value;
			}
		}


		/// <summary>
		/// get the number of unparsed texts </summary>
		/// <returns> the number of unparsed texts </returns>
		public virtual int? size()
		{
			// sanity check and evaluation
			return new int?(this.texts.Count);
		}

		/// <summary>
		/// decides if a specific text (by index) is likely a SWIFT FIN message. Exceptions are inherited from
		/// base implementation methods. </summary>
		/// <param name="index"> the unparsed text number </param>
		/// <returns> true if the text at position index is likely to be a SWIFT message </returns>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		/// <exception cref="IndexOutOfBoundsException"> if parameter index is out of bounds </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Boolean isMessage(final Integer index)
		public virtual bool? isMessage(int? index)
		{
			return (UnparsedTextList.isMessage(this.getText(index)));
		}

		/// <summary>
		/// get an unparsed text </summary>
		/// <param name="index"> the unparsed text number </param>
		/// <returns> the requested text </returns>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		/// <exception cref="IndexOutOfBoundsException"> if parameter index is out of bounds </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getText(final Integer index)
		public virtual string getText(int? index)
		{
			// sanity check
			Validate.notNull(index, WRITER_MESSAGE);

			return ((string) this.texts[(int)index]);
		}

		/// <summary>
		/// get an unparsed text as a parsed swift message </summary>
		/// <param name="index"> the unparsed text number </param>
		/// <returns> the text at position index parsed into a SwiftMessage object </returns>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		/// <exception cref="IndexOutOfBoundsException"> if parameter index is out of bounds  </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftMessage getTextAsMessage(final Integer index)
		public virtual SwiftMessage getTextAsMessage(int? index)
		{
			// sanity check
			Validate.notNull(index, WRITER_MESSAGE);

			// create a conversion class
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.io.ConversionService cService = new com.prowidesoftware.swift.io.ConversionService();
			ConversionService cService = new ConversionService();
			return (cService.getMessageFromFIN((string) this.texts[(int)index]));
		}

		/// <summary>
		/// adds a new unparsed text </summary>
		/// <param name="text"> the unparsed text to append </param>
		/// <exception cref="IllegalArgumentException"> if parameter text is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void addText(final String text)
		public virtual void addText(string text)
		{
			// sanity check
			Validate.notNull(text, "parameter 'text' cannot be null");

			// append the text
			this.texts.Add(text);
		}

		/// <summary>
		/// adds a new unparsed text from a message </summary>
		/// <param name="message"> the message to be appended </param>
		/// <exception cref="IllegalArgumentException"> if parameter message is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void addText(final SwiftMessage message)
		public virtual void addText(SwiftMessage message)
		{
			// sanity check
			Validate.notNull(message, "parameter 'message' cannot be null");

			// get the text version of the message
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.io.ConversionService cService = new com.prowidesoftware.swift.io.ConversionService();
			ConversionService cService = new ConversionService();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String msg = cService.getFIN(message);
			string msg = cService.getFIN(message);

			// add the text
			this.addText(msg);
		}

		/// <summary>
		/// removes an unparsed text </summary>
		/// <param name="index"> the index of the text to remove </param>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		/// <exception cref="IndexOutOfBoundsException"> if parameter index is out of bounds </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void removeText(final Integer index)
		public virtual void removeText(int? index)
		{
			// sanity check
			Validate.notNull(index, WRITER_MESSAGE);

			// remove the text
			this.texts.Remove((int)index);
		}

		/// <summary>
		/// removes an unparsed text </summary>
		/// <param name="index"> the index of the text to remove </param>
		/// <exception cref="IndexOutOfBoundsException"> if parameter index is out of bounds </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void removeText(final int index)
		public virtual void removeText(int index)
		{
			// remove the text
			this.texts.RemoveAt(index);
		}

		/// <summary>
		/// removes an unparsed text </summary>
		/// <param name="text"> the text value to remove (uses equals) </param>
		/// <exception cref="IllegalArgumentException"> if parameter text is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void removeText(final String text)
		public virtual void removeText(string text)
		{
			// sanity check
			Validate.notNull(text, "parameter 'text' cannot be null");

			// remove the text (if it exists)
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int pos = this.texts.indexOf(text);
			int pos = this.texts.IndexOf(text);
			if (pos != -1)
			{
				this.texts.RemoveAt(pos);
			}
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
			UnparsedTextList that = (UnparsedTextList) o;
			return Objects.Equals(texts, that.texts);
		}

		public override int GetHashCode()
		{
			return Objects.hash(texts);
		}
	}

}