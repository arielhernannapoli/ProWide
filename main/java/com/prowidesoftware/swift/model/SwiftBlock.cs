using System;

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
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using ToStringBuilder = org.apache.commons.lang3.builder.ToStringBuilder;

	/// <summary>
	/// Base class for a generic SWIFT block.<br> 
	/// This is an <b>abstract</b> class so specific block classes for each block (block 1, 2, 3, etc...)
	/// should be instantiated.<br>
	/// <br>
	/// Instances of this class may have a list of unparsed texts (UnparsedTextList).
	/// For easy access, methods have been created that first ensure the lists exists (the
	/// real object is created and then call the base method).<br>
	/// However, not all the base list methods have been implemented. If you need to use not
	/// exposed functionality, retrieve the underlying list with (see getUnparsedTexts method)<br>
	/// 
	/// @author www.prowidesoftware.com
	/// </summary>
	//TODO: add parameter checks (Validate.*) and complete javadocs 
	[Serializable]
	public abstract class SwiftBlock
	{
		private const long serialVersionUID = -6993261477630953757L;

		/// <summary>
		/// Unique identifier of the swift block.
		/// Mainly used for persistence services. </summary>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) protected Long id;
		[Obsolete("use persistence mapping in the AbstractSwiftMessage model instead")]
		protected internal long? id;

		/// <summary>
		/// List of unparsed texts. For performance reasons, this will be null until really needed.
		/// </summary>
		protected internal UnparsedTextList unparsedTexts = null;

		/// <summary>
		/// Only valid for block2, only when using hibernate for persistence
		/// </summary>
		protected internal bool? input;
		/// <summary>
		/// Only valid for block2, only when using hibernate for persistence
		/// </summary>
		protected internal bool? output;

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
			SwiftBlock that = (SwiftBlock) o;
			return Objects.Equals(unparsedTexts, that.unparsedTexts);
		}

		public override int GetHashCode()
		{
			return Objects.hash(unparsedTexts);
		}

		/// <summary>
		/// helper for hibernate mapping
		/// </summary>
		protected internal string blockType;

		/// <returns> a string identifying block type or null if not implemented </returns>
		public virtual string BlockType
		{
			get
			{
				return blockType;
			}
			set
			{
				this.blockType = value;
			}
		}


		/// <summary>
		/// Default constructor, shouldn't be used normally.
		/// <b>DO NOT USE</b>: present only for subclasses
		/// </summary>
		public SwiftBlock()
		{

		}

		/// <summary>
		/// Constructor for an unparsed text list </summary>
		/// <param name="unparsedText"> the list of unparsed texts </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftBlock(final UnparsedTextList unparsedText)
		public SwiftBlock(UnparsedTextList unparsedText)
		{

			// set the unparsed text list
			this.unparsedTexts = unparsedText;
		}

		/// <summary>
		/// Sets the block number (this method is to be overwrite for derived classes). </summary>
		/// <param name="blockNumber"> the block number to set
		/// 
		/// @since 5.0 </param>
		protected internal abstract int? BlockNumber {set;}

		/// <summary>
		/// Sets the block name (this method is to be overwrite for derived classes). </summary>
		/// <param name="blockName"> the block name to set
		/// 
		/// @since 5.0 </param>
		protected internal abstract string BlockName {set;}

		/// <summary>
		/// Returns the block number (this method is to be overwritten for derived classes). </summary>
		/// <returns> Integer containing the block's number </returns>
		public abstract int? Number {get;}

		/// <summary>
		/// Returns the block name (this method is to be overwritten for derived classes). </summary>
		/// <returns> block name
		/// 
		/// @since 5.0 </returns>
		public abstract string Name {get;}

		/// <summary>
		/// Get the unique identifier of this block or null if it is not set </summary>
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
		/// Sets the unique identifier of this block </summary>
		/// <param name="id"> the unique identifier to set. </param>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public void setId(final Long id)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:

		public override string ToString()
		{
			return ToStringBuilder.reflectionToString(this);
		}

		/// <summary>
		/// Tell if this block is a block that contains a list of tags (3-5) or is a block with fixed length value (1-2) </summary>
		/// <returns> <code>true</code> if this object contains a list of tags (which may be empty or null </returns>
		public virtual bool TagBlock
		{
			get
			{
				return this is SwiftTagListBlock;
			}
		}

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
		/// Returns the unparsed text list attached to the Block. </summary>
		/// <returns> the unparsed texts attached to the block </returns>
		public virtual UnparsedTextList UnparsedTexts
		{
			get
			{
				// create the list if needed
				unparsedTextVerify();
				return this.unparsedTexts;
			}
			set
			{
				this.unparsedTexts = value;
			}
		}


		/// <summary>
		/// returns the size of the unparsed text list </summary>
		/// <returns> the count of unparsed test attached to the block </returns>
		public virtual int? UnparsedTextsSize
		{
			get
			{
				// no list => size is zero...
				if (this.unparsedTexts == null)
				{
					return Convert.ToInt32(0);
				}
				return this.unparsedTexts.size();
			}
		}

		/// <summary>
		/// decides if a specific text (by index) is likely a SWIFT FIN message. Exceptions are inherited from
		/// base implementation methods. </summary>
		/// <param name="index"> the unparsed text number </param>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		/// <exception cref="IndexOutOfBoundsException"> if parameter index is out of bounds </exception>
		/// <returns> true if the unparsed text at position index is a full SWIFT Message </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Boolean unparsedTextIsMessage(final Integer index)
		public virtual bool? unparsedTextIsMessage(int? index)
		{
			// create the list if needed
			unparsedTextVerify();
			return this.unparsedTexts.isMessage(index);
		}

		/// <summary>
		/// get an unparsed text </summary>
		/// <param name="index"> the unparsed text number </param>
		/// <returns> the requested text </returns>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		/// <exception cref="IndexOutOfBoundsException"> if parameter index is out of bounds </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String unparsedTextGetText(final Integer index)
		public virtual string unparsedTextGetText(int? index)
		{
			// create the list if needed
			unparsedTextVerify();
			return this.unparsedTexts.getText(index);
		}

		/// <summary>
		/// get an unparsed text as a parsed swift message </summary>
		/// <param name="index"> the unparsed text number </param>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
		/// <returns> the blocks unparsed text at position index, parsed into a SwiftMessage object </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftMessage unparsedTextGetAsMessage(final Integer index)
		public virtual SwiftMessage unparsedTextGetAsMessage(int? index)
		{
			// create the list if needed
			unparsedTextVerify();
			return this.unparsedTexts.getTextAsMessage(index);
		}

		/// <summary>
		/// adds a new unparsed text </summary>
		/// <param name="text"> the unparsed text to append </param>
		/// <exception cref="IllegalArgumentException"> if parameter text is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void unparsedTextAddText(final String text)
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
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void unparsedTextAddText(final SwiftMessage message)
		public virtual void unparsedTextAddText(SwiftMessage message)
		{
			// create the list if needed
			unparsedTextVerify();
			this.unparsedTexts.addText(message);
		}

		/// <summary>
		/// Only valid for block2, only when using hibernate for persistence </summary>
		/// <returns> true if the message block type is <code>2I</code> </returns>
		/// @deprecated use <seealso cref="#getBlockType()"/> 
		public virtual bool? Input
		{
			get
			{
				return Convert.ToBoolean(StringUtils.Equals(BlockType, "2I"));
			}
			set
			{
				this.input = value;
			}
		}


		/// <summary>
		/// Only valid for block2, only when using hibernate for persistence </summary>
		/// <returns> <code>true</code> if message block type is <code>2O</code> </returns>
		/// @deprecated use <seealso cref="#getBlockType()"/> 
		public virtual bool? Output
		{
			get
			{
				return Convert.ToBoolean(StringUtils.Equals(BlockType, "2O"));
			}
			set
			{
				this.output = value;
			}
		}

	}

}