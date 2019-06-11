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
	using SwiftParser = com.prowidesoftware.swift.io.parser.SwiftParser;
	using SwiftParserConfiguration = com.prowidesoftware.swift.io.parser.SwiftParserConfiguration;
	using XMLParser = com.prowidesoftware.swift.io.parser.XMLParser;
	using SwiftWriter = com.prowidesoftware.swift.io.writer.SwiftWriter;
	using XMLWriterVisitor = com.prowidesoftware.swift.io.writer.XMLWriterVisitor;
	using com.prowidesoftware.swift.model.field;
	using com.prowidesoftware.swift.model.mt;
	using IMessageVisitor = com.prowidesoftware.swift.utils.IMessageVisitor;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;
	using ToStringBuilder = org.apache.commons.lang3.builder.ToStringBuilder;


	/// <summary>
	/// Base class for swift messages.
	/// 
	/// <para>This class is a generic data structure container for SWIFT messages.
	/// 
	/// </para>
	/// <para><em>This is a low level java representation of an MT. If you are looking for
	/// a class more suitable to be persisted see <seealso cref="MtSwiftMessage"/></em>
	/// 
	/// </para>
	/// <para>Instances of this class may have a list of unparsed texts (UnparsedTextList).
	/// For easy access, methods have been created that first ensure the lists exists (the
	/// real object is created and then call the base method).<br>
	/// However, not all the base list methods have been implemented. If you need to use not
	/// exposed functionality, retrieve the underlying list with (see getUnparsedTexts method).
	/// </para>
	/// </summary>
	[Serializable]
	public class SwiftMessage : JsonSerializable
	{
		private const long serialVersionUID = 8094995269559985432L;

//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftMessage).FullName);

		internal const int JSON_VERSION = 2;
		private const string INVALID_NAME_BLOCK = "Invalid name for User Defined Blocks (";
		private const string MESSAGE_IS_NOT_A_FRAGMENT = "message is not a fragment";

		/// <summary>
		/// Block 1
		/// </summary>
		private SwiftBlock1 block1;

		/// <summary>
		/// Block 2
		/// </summary>
		private SwiftBlock2 block2;

		/// <summary>
		/// Block 3
		/// </summary>
		private SwiftBlock3 block3;

		/// <summary>
		/// Block 4
		/// </summary>
		private SwiftBlock4 block4;

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
			SwiftMessage that = (SwiftMessage) o;
			return Objects.Equals(block1, that.block1) && Objects.Equals(block2, that.block2) && Objects.Equals(block3, that.block3) && Objects.Equals(block4, that.block4) && Objects.Equals(block5, that.block5) && Objects.Equals(userBlocks, that.userBlocks) && Objects.Equals(unparsedTexts, that.unparsedTexts);
		}

		public override int GetHashCode()
		{
			return Objects.hash(block1, block2, block3, block4, block5, userBlocks, unparsedTexts);
		}

		/// <summary>
		/// Block 5
		/// </summary>
		private SwiftBlock5 block5;

		/// <summary>
		/// Placeholder for the root of the sequences parsed in this message </summary>
		/// @deprecated to retrieve fields in sequences use the AbstractMT model 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("to retrieve fields in sequences use the AbstractMT model") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) private SequenceNode parsedSequences;
		[Obsolete("to retrieve fields in sequences use the AbstractMT model")]
		private SequenceNode parsedSequences;

		/// <summary>
		/// User defined blocks
		/// List of <seealso cref="SwiftBlockUser"/>.
		/// 
		/// @since 5.0
		/// </summary>
		private IList<SwiftBlockUser> userBlocks;

		/// <summary>
		/// List of unparsed texts. For performance reasons, this will be null until really needed.
		/// </summary>
		private UnparsedTextList unparsedTexts = null;

		/// <summary>
		/// Identification of the message when persisted </summary>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) protected Long id;
		[Obsolete("use persistence mapping in the AbstractSwiftMessage model instead")]
		protected internal long? id;

		/// <summary>
		/// Default constructor.
		/// Must be called since here is performed default handler registration </summary>
		/// <seealso cref= #SwiftMessage(boolean) </seealso>
		public SwiftMessage() : base()
		{
		}

		/// <summary>
		/// Constructor that initializes blocks </summary>
		/// <param name="initBlocks"> when false the message will not have any blocks when constructed, if true blocks are created, just like with default constructor </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftMessage(final boolean initBlocks)
		public SwiftMessage(bool initBlocks) : base()
		{
			if (initBlocks)
			{
				this.block1 = new SwiftBlock1();
				this.block2 = new SwiftBlock2Input();
				this.block3 = new SwiftBlock3();
				this.block4 = new SwiftBlock4();
				this.block5 = new SwiftBlock5();
				this.userBlocks = new List<>();
			}
		}

		/// <summary>
		/// Constructor for an unparsed text list that initializes blocks </summary>
		/// <param name="initBlocks"> when false the message will not have any blocks when constructed, if true blocks are created, just like with default consturctor </param>
		/// <param name="unparsedText"> the list of unparsed texts </param>
		/// <seealso cref= SwiftMessage#SwiftMessage() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftMessage(final boolean initBlocks, final UnparsedTextList unparsedText)
		public SwiftMessage(bool initBlocks, UnparsedTextList unparsedText) : this(initBlocks)
		{

			// base constructor

			// set the unparsed text list
			this.unparsedTexts = unparsedText;
		}

		/// <summary>
		/// Constructor for an unparsed text list </summary>
		/// <param name="unparsedText"> the list of unparsed texts </param>
		/// <seealso cref= SwiftMessage#SwiftMessage() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftMessage(final UnparsedTextList unparsedText)
		public SwiftMessage(UnparsedTextList unparsedText) : this()
		{

			// base constructor

			// set the unparsed text list
			this.unparsedTexts = unparsedText;
		}

		/// <summary>
		/// Parses a the string content into a SwiftMessage. 
		/// 
		/// <para>If the file contains more than a message it will parse the first one.
		/// If the string is empty, does not contain any MT message, the message type is not set or 
		/// an error occurs reading and parsing the message content; this method returns null.
		/// 
		/// </para>
		/// <para>The implementation uses the default parser behaviour which is lenient and will do a best effort to
		/// read as much from the message content as possible regardless of the content and block boundaries
		/// beeing valid or not. For instance, it will read the headers even if the value length is incorrect,
		/// and it will read the text block (block 4) even if it is missing the closing hyphen and bracket. For
		/// more options check <seealso cref="SwiftParser#setConfiguration(SwiftParserConfiguration)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="fin"> string a string containing a swift MT message </param>
		/// <returns> parser message or null if string content could not be parsed </returns>
		/// <exception cref="IOException">
		/// 
		/// @since 7.8.8 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public final static SwiftMessage parse(final String fin) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static SwiftMessage parse(string fin)
		{
			return (new SwiftParser(fin)).message();
		}

		/// <summary>
		/// Get the block number specified by b.
		/// </summary>
		/// <param name="b"> the block number to retrieve, must be greater or equal to 1 and smaller or equal to 5. </param>
		/// <returns> the block number specified in this message </returns>
		/// <exception cref="IllegalArgumentException"> if b &lt; 1 or b &gt; 5 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftBlock getBlock(final int b)
		public virtual SwiftBlock getBlock(int b)
		{
			// sanity check
			Validate.isTrue(1 <= b && b <= 5, "block index must be 1-5 (was " + b + ")");

			switch (b)
			{
				case 1:
					return this.block1;
				case 2:
					return this.block2;
				case 3:
					return this.block3;
				case 4:
					return this.block4;
				case 5:
					return this.block5;
				default:
					log.severe("Invalid block number " + b + ". Expected numbers are 1 to 5");
					// should not be reached
					return null;
			}
		}

		/// <summary>
		/// Commons-lang reflection toString implementation
		/// </summary>
		public override string ToString()
		{
			return ToStringBuilder.reflectionToString(this);
		}

		/// <summary>
		/// Add a block to this message.
		/// <para>Notes: on user blocks, no checks are done, on swift blocks, block number
		/// must be non null and have a value from 1-5 both inclusive
		/// 
		/// </para>
		/// </summary>
		/// <param name="b"> the block to add, may be null in which case nothing happens </param>
		/// <exception cref="IllegalArgumentException"> b is null or the method getInt in the block returns a value out of range (non user blocks) </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void addBlock(final SwiftBlock b)
		public virtual void addBlock(SwiftBlock b)
		{
			Validate.notNull(b);

			// support for user blocks in this method is useful for XML parser and other code that
			// takes advantages of using SwiftTagListBlock
			if (b is SwiftBlockUser)
			{
				addUserBlock((SwiftBlockUser) b);
			}
			else
			{
				Validate.notNull(b.Number, "SwiftBlock.getNumber() is null");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int index = b.getNumber().intValue();
				int index = (int)b.Number;
				Validate.isTrue(index >= 1 && index <= 5, "SwiftBlock.getNumber int did not return an int between 1-5");
				switch (index)
				{
					case 1:
						Block1 = (SwiftBlock1) b;
						break;
					case 2:
						Block2 = (SwiftBlock2) b;
						break;
					case 3:
						Block3 = (SwiftBlock3) b;
						break;
					case 4:
						Block4 = (SwiftBlock4) b;
						break;
					case 5:
						Block5 = (SwiftBlock5) b;
						break;
					default:
						log.severe("Invalid block number " + b + ". Expected numbers are 1 to 5");
						break;
				}
			}
		}

		/// <summary>
		/// Attempt to identify the current message type (MT).
		/// </summary>
		/// <param name="type"> must be a valid registered handler id </param>
		/// <returns> true if this message is successfully identified as the given MT and false in other case	 * </returns>
		/// <exception cref="IllegalArgumentException"> if parameter type is null or not a valid type (i.e: 3 chars len) </exception>
		/// <seealso cref= SwiftBlock2#getMessageType() </seealso>
		/// <seealso cref= #getType()
		/// </seealso>
		/// @deprecated this method has been deprecated in favor of <seealso cref="#isType(int)"/> which provides a safer API just passing an int number for the message type 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("this method has been deprecated in favor of <seealso cref="#isType(int)"/> which provides a safer API just passing an int number for the message type") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public boolean isMT(final String type)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("this method has been deprecated in favor of <seealso cref="#isType(int)"/> which provides a safer API just passing an int number for the message type")]
		public virtual bool isMT(string type)
		{
			DeprecationUtils.phase2(this.GetType(), "isMT(String)", "Use isType(int) instead.");
			// sanity check
			Validate.notNull(type);
			Validate.isTrue(type.Length == 3, "The string must be exactly 3 chars size (type=" + type + ")");
			return Type != null && Type.Equals(type);
		}

		/// <summary>
		/// Tell the message type associated with this object if a block 2 is present.
		/// </summary>
		/// <returns> a String containing the SWIFT numeric code for the message types or null if the message does not have a block 2. </returns>
		/// <seealso cref= SwiftBlock2#getMessageType() </seealso>
		public virtual string Type
		{
			get
			{
				if (this.block2 != null)
				{
					return this.block2.MessageType;
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Visit the current message with the given visitor.
		/// This is a simple implementation of the visitor pattern.
		/// </summary>
		/// <param name="visitor"> the visitor to use </param>
		/// <exception cref="IllegalArgumentException"> if parameter visitor is null </exception>
		/// <seealso cref= SwiftWriter#writeMessage(SwiftMessage, java.io.Writer) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void visit(final com.prowidesoftware.swift.utils.IMessageVisitor visitor)
		public virtual void visit(IMessageVisitor visitor)
		{
			Validate.notNull(visitor);

			// start visiting
			visitor.startMessage(this);

			// visit block 1 and value
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock1 b1 = this.block1;
			SwiftBlock1 b1 = this.block1;
			if (b1 != null)
			{
				visitor.startBlock1(b1);
				visitor.value(b1, b1.Value);
				visitor.endBlock1(b1);
			}

			// visit block 2 and value
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock2 b2 = this.block2;
			SwiftBlock2 b2 = this.block2;
			if (b2 != null)
			{
				visitor.startBlock2(b2);
				visitor.value(b2, b2.Value);
				visitor.endBlock2(b2);
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock3 b3 = this.block3;
			SwiftBlock3 b3 = this.block3;
			if (b3 != null)
			{
				visitor.startBlock3(b3);
				visit(b3, visitor);
				visitor.endBlock3(b3);
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = this.block4;
			SwiftBlock4 b4 = this.block4;
			if (b4 != null)
			{
				visitor.startBlock4(b4);
				visit(b4, visitor);
				visitor.endBlock4(b4);
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock5 b5 = this.block5;
			SwiftBlock5 b5 = this.block5;
			if (b5 != null)
			{
				visitor.startBlock5(b5);
				visit(b5, visitor);
				visitor.endBlock5(b5);
			}

			// visit user defined blocks
			if (this.userBlocks != null)
			{

				// visit every user defined block
				for (int i = 0; i < this.userBlocks.Count; i++)
				{

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlockUser userBlock = this.userBlocks.get(i);
					SwiftBlockUser userBlock = this.userBlocks[i];
					if (userBlock != null)
					{
						visitor.startBlockUser(userBlock);
						visit(userBlock, visitor);
						visitor.endBlockUser(userBlock);
					}
				}
			}

			// stop visiting
			visitor.endMessage(this);
		}

		/// <summary>
		/// Visit a Block 3 (SwiftBlock3), i.e: call the tag method for block 3
		/// This method is called from <seealso cref="#visit(IMessageVisitor)"/> but may be used independently, in such case,
		/// the startBlockX and endBlockX in the visitor will not be called.
		/// <para>To serialize in SWIFT native format with block boundaries check <seealso cref="SwiftWriter#writeBlock3(SwiftBlock3, java.io.Writer)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="block"> the block containing the tags to visit </param>
		/// <param name="visitor"> the visitor to use </param>
		/// <exception cref="IllegalArgumentException"> if parameter block or visitor are null
		/// 
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void visit(final SwiftBlock3 block, final com.prowidesoftware.swift.utils.IMessageVisitor visitor)
		public static void visit(SwiftBlock3 block, IMessageVisitor visitor)
		{
			// sanity check
			Validate.notNull(block);
			Validate.notNull(visitor);

			// iterate thru tags
			for (final IEnumerator<Tag> it = block.tagIterator(); it.hasNext();)
			{
				visitor.tag(block, it.next());
			}
		}

		/// <summary>
		/// Visit a Block 4 (SwiftBlock4), i.e: call the tag method for block 4
		/// This method is called from <seealso cref="#visit(IMessageVisitor)"/> but may be used independently, in such case,
		/// the startBlockX and endBlockX in the visitor will not be called.
		/// <para>To serialize in SWIFT native format with block boundaries check <seealso cref="SwiftWriter#writeBlock4(SwiftBlock4, java.io.Writer)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="block"> the block containing the tags to visit </param>
		/// <param name="visitor"> the visitor to use </param>
		/// <exception cref="IllegalArgumentException"> if parameter block or visitor are null
		/// 
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void visit(final SwiftBlock4 block, final com.prowidesoftware.swift.utils.IMessageVisitor visitor)
		public static void visit(SwiftBlock4 block, IMessageVisitor visitor)
		{
			// sanity check
			Validate.notNull(block);
			Validate.notNull(visitor);

			// iterate thru tags
			for (final IEnumerator<Tag> it = block.tagIterator(); it.hasNext();)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = it.next();
				Tag t = it.next();
				visitor.tag(block, t);
			}
		}

		/// <summary>
		/// Visit a Block 5 (SwiftBlock5), i.e: call the tag method for block 4
		/// This method is called from <seealso cref="#visit(IMessageVisitor)"/> but may be used independently, in such case,
		/// the startBlockX and endBlockX in the visitor will not be called.
		/// <para>To serialize in SWIFT native format with block boundaries check <seealso cref="SwiftWriter#writeBlock5(SwiftBlock5, java.io.Writer)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="block"> the block containing the tags to visit </param>
		/// <param name="visitor"> the visitor to use </param>
		/// <exception cref="IllegalArgumentException"> if parameter block or visitor are null
		/// 
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void visit(final SwiftBlock5 block, final com.prowidesoftware.swift.utils.IMessageVisitor visitor)
		public static void visit(SwiftBlock5 block, IMessageVisitor visitor)
		{
			// sanity check
			Validate.notNull(block);
			Validate.notNull(visitor);

			// iterate thru tags
			for (final IEnumerator<Tag> it = block.tagIterator(); it.hasNext();)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = it.next();
				Tag t = it.next();
				visitor.tag(block, t);
			}
		}

		/// <summary>
		/// Visit a User Defined Block (SwiftBlockUser), i.e: call the tag method for block 4
		/// This method is called from <seealso cref="#visit(IMessageVisitor)"/> but may be used independently, in such case,
		/// the startBlockX and endBlockX in the visitor will not be called.
		/// </summary>
		/// <param name="block"> the block containing the tags to visit </param>
		/// <param name="visitor"> the visitor to use </param>
		/// <exception cref="IllegalArgumentException"> if parameter block or visitor are null
		/// 
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void visit(final SwiftBlockUser block, final com.prowidesoftware.swift.utils.IMessageVisitor visitor)
		public static void visit(SwiftBlockUser block, IMessageVisitor visitor)
		{
			// sanity check
			Validate.notNull(block);
			Validate.notNull(visitor);

			// iterate thru tags
			for (final IEnumerator<Tag> it = block.tagIterator(); it.hasNext();)
			{

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = it.next();
				Tag t = it.next();
				visitor.tag(block, t);
			}
		}

		/// <summary>
		/// Get the unique identifier of this message </summary>
		/// <returns> the message id </returns>
		/// <seealso cref= #id </seealso>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public Long getId()
		[Obsolete("use persistence mapping in the AbstractSwiftMessage model instead")]
		public virtual long? Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}

		/// <summary>
		/// Set the unique identifier of this message </summary>
		/// <param name="id"> the id to be set </param>
		/// <seealso cref= #id </seealso>
		/// @deprecated use persistence mapping in the AbstractSwiftMessage model instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use persistence mapping in the AbstractSwiftMessage model instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public void setId(final Long id)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:

		/// <summary>
		/// Get the number of blocks in this message, including the user blocks </summary>
		/// <returns> an int greater or equal to zero </returns>
		public virtual int BlockCount
		{
			get
			{
				return this.getBlockCount(true);
			}
		}

		/// <summary>
		/// Get the number of blocks in this message, optionally including the user blocks.<br>
		/// A block is summed if it is not null and is not empty.
		/// <b><em>NOTE: that isEmpty() will be called in each block, the behavior of isEmpty is block
		/// dependent</em></b>
		/// </summary>
		/// <param name="includeUserBlocks"> indicates whether or not user defined blocks should be counted </param>
		/// <returns> an int greater or equal to zero </returns>
		/// <seealso cref= SwiftBlock1#isEmpty() </seealso>
		/// <seealso cref= SwiftBlock2Input#isEmpty() </seealso>
		/// <seealso cref= SwiftBlock2Output#isEmpty() </seealso>
		/// <seealso cref= SwiftBlock3#isEmpty() </seealso>
		/// <seealso cref= SwiftBlock4#isEmpty() </seealso>
		/// <seealso cref= SwiftBlock5#isEmpty() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int getBlockCount(final Boolean includeUserBlocks)
		public virtual int getBlockCount(bool? includeUserBlocks)
		{

			// count the basic blocks
			int count = 0;
			if (this.block1 != null && !this.block1.Empty)
			{
				count++;
			}
			if (this.block2 != null && !this.block2.Empty)
			{
				count++;
			}
			if (this.block3 != null && !this.block3.Empty)
			{
				count++;
			}
			if (this.block4 != null && !this.block4.Empty)
			{
				count++;
			}
			if (this.block5 != null && !this.block5.Empty)
			{
				count++;
			}

			// count user defined blocks (if requested to do so)
			if ((bool)includeUserBlocks && this.userBlocks != null)
			{
				count += this.userBlocks.Count;
			}

			return count;
		}

		/// <summary>
		/// Get block number 1 of this message, may be null if not set </summary>
		/// <returns> the block 1 of the message or null </returns>
		public virtual SwiftBlock1 Block1
		{
			get
			{
				return this.block1;
			}
			set
			{
				this.block1 = value;
			}
		}


		/// <summary>
		/// Get block number 2 of this message, may be null if not set </summary>
		/// <returns> the block 2 of the message or null </returns>
		public virtual SwiftBlock2 Block2
		{
			get
			{
				return this.block2;
			}
			set
			{
				this.block2 = value;
			}
		}


		/// <summary>
		/// Get block number 3 of this message, may be null if not set </summary>
		/// <returns> the block 3 of the message or null </returns>
		public virtual SwiftBlock3 Block3
		{
			get
			{
				return this.block3;
			}
			set
			{
				this.block3 = value;
			}
		}


		/// <summary>
		/// Get block number 4 of this message, may be null if not set </summary>
		/// <returns> the block 4 of the message or null </returns>
		public virtual SwiftBlock4 Block4
		{
			get
			{
				return this.block4;
			}
			set
			{
				this.block4 = value;
			}
		}


		/// <summary>
		/// Get block number 5 of this message, may be null if not set </summary>
		/// <returns> the block 5 of the message or null </returns>
		public virtual SwiftBlock5 Block5
		{
			get
			{
				return this.block5;
			}
			set
			{
				this.block5 = value;
			}
		}


		/// <summary>
		/// Finds the position of a given User Defined Block in the internal list </summary>
		/// <param name="blockName"> the block name to find may be empty or null, in which case this method does nothing </param>
		/// <returns> the position or -1 if not found
		/// 
		/// @since 5.0 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int getUserBlockPosition(final String blockName)
		public virtual int getUserBlockPosition(string blockName)
		{
			// check parameters
			if (StringUtils.isBlank(blockName) || (this.userBlocks == null)) //check user blocks array
			{
				return -1;
			}

			// start scanning the list
			for (int i = 0; i < this.userBlocks.Count; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlockUser userBlock = (SwiftBlockUser) this.userBlocks.get(i);
				SwiftBlockUser userBlock = (SwiftBlockUser) this.userBlocks[i];
				if (userBlock != null && StringUtils.Equals(userBlock.Name, blockName))
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// Get the list of List of <seealso cref="SwiftBlockUser"/> user defined blocks.
		/// The requested object may be null if the message was cleared or not initialized.
		/// </summary>
		/// <returns> the list or user blocks or null
		/// @since 5.0 </returns>
		public virtual IList<SwiftBlockUser> UserBlocks
		{
			get
			{
				return this.userBlocks;
			}
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'userBlocks' cannot be null");
    
				// setup the new list
				this.userBlocks = value;
			}
		}


		/// <summary>
		/// Get a user defined block by name, may be null if not set
		/// </summary>
		/// <param name="blockName"> the name of the block to find </param>
		/// <returns> the requested user defined block or null </returns>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter blockName has an invalid block name
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftBlockUser getUserBlock(final String blockName)
		public virtual SwiftBlockUser getUserBlock(string blockName)
		{
			// sanity check
			Validate.notNull(blockName, "parameter 'blockName' cannot be null");

			// find the block position
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int pos = getUserBlockPosition(blockName);
			int pos = getUserBlockPosition(blockName);
			if (pos != -1)
			{
				return this.userBlocks[pos];
			}

			return null;
		}

		/// <summary>
		/// Get a user defined block by number, may be null if not set
		/// </summary>
		/// <param name="blockNumber"> the number of the block to find </param>
		/// <returns> the requested user defined block or null </returns>
		/// <exception cref="IllegalArgumentException"> if parameter userBlock is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter userBlock has an invalid block name
		/// 
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftBlockUser getUserBlock(final Integer blockNumber)
		public virtual SwiftBlockUser getUserBlock(int? blockNumber)
		{
			// sanity check
			Validate.notNull(blockNumber, "parameter 'blockNumber' cannot be null");

			return this.getUserBlock(blockNumber.ToString());
		}

		/// <summary>
		/// Add a user defined block to the message (if the block already exists, it is replaced) </summary>
		/// <param name="userBlock"> the user defined block </param>
		/// <exception cref="IllegalArgumentException"> if parameter userBlock is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter userBlock has an invalid block name
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void addUserBlock(final SwiftBlockUser userBlock)
		public virtual void addUserBlock(SwiftBlockUser userBlock)
		{
			// sanity check
			Validate.notNull(userBlock);
			Validate.isTrue((bool)userBlock.ValidName, INVALID_NAME_BLOCK + userBlock.Name + ")");

			if (this.userBlocks == null)
			{
				this.userBlocks = new List<SwiftBlockUser>();
			}

			// find the block position (if it's already there)
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int pos = getUserBlockPosition(userBlock.getName());
			int pos = getUserBlockPosition(userBlock.Name);
			if (pos != -1)
			{
				this.userBlocks.Insert(pos, userBlock);
			}
			else
			{
				this.userBlocks.Add(userBlock);
			}
		}

		/// <summary>
		/// removes a user defined block to the message (if the block does not exists, nothing is done) </summary>
		/// <param name="blockNumber"> the block number to remove </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockNumber is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter blockNumber is invalid
		/// @since 5.0 </exception>
		/// <seealso cref= SwiftBlockUser#isValidName(Integer) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void removeUserBlock(final Integer blockNumber)
		public virtual void removeUserBlock(int? blockNumber)
		{
			// sanity check
			Validate.notNull(blockNumber, "parameter 'blockNumber' cannot be null");
			Validate.isTrue((bool)SwiftBlockUser.isValidName(blockNumber), INVALID_NAME_BLOCK + blockNumber.ToString() + ")");

			this.removeUserBlock(blockNumber.ToString());
		}

		/// <summary>
		/// removes a user defined block to the message (if the block does not exists, nothing is done) </summary>
		/// <param name="blockName"> the block name to remove </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is null </exception>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is invalid
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void removeUserBlock(final String blockName)
		public virtual void removeUserBlock(string blockName)
		{
			// sanity check
			Validate.notNull(blockName, "parameter 'blockName' cannot be null");
			Validate.isTrue((bool)SwiftBlockUser.isValidName(blockName), INVALID_NAME_BLOCK + blockName + ")");

			// find the block position (if it's there)
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int pos = getUserBlockPosition(blockName);
			int pos = getUserBlockPosition(blockName);
			if (pos != -1)
			{
				this.userBlocks.RemoveAt(pos);
			}
		}

		/// <summary>
		/// remove all blocks from these message, including user blocks
		/// </summary>
		public virtual void clear()
		{
			// release all blocks
			this.block1 = null;
			this.block2 = null;
			this.block3 = null;
			this.block4 = null;
			this.block5 = null;

			// release user blocks
			this.userBlocks = null;
		}

		/// <summary>
		/// Checks if the message is a fragment </summary>
		/// <returns> true if the message is a fragment
		/// 
		/// @since 5.0 </returns>
		public virtual bool? Fragment
		{
			get
			{
				// get the block 4 (if exists)
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final SwiftBlock4 b4 = this.block4;
				SwiftBlock4 b4 = this.block4;
				if (b4 != null)
				{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String t202 = b4.getTagValue("202");
					string t202 = b4.getTagValue("202");
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String t203 = b4.getTagValue("203");
					string t203 = b4.getTagValue("203");
    
					// if both tag exists => this is a fragment
					return t202 != null && t203 != null ? true : false;
				}
				return false;
			}
		}

		/// <summary>
		/// Checks if the message is the last fragment </summary>
		/// <returns> true if the message is the last fragment of a fragmented message
		/// 
		/// @since 5.0 </returns>
		public virtual bool? LastFragment
		{
			get
			{
				if (!(bool)this.Fragment)
				{
					return (false);
				}
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Integer count = this.fragmentCount();
				int? count = this.fragmentCount();
				try
				{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Integer number = this.fragmentNumber();
					int? number = this.fragmentNumber();
					return (int)count == (int)number ? true : false;
				}
	//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
	//ORIGINAL LINE: catch (final UnsupportedOperationException e)
				catch (System.NotSupportedException e)
				{
					throw new IllegalStateException("Invalid call to islastFragment for a non fragmented message", e);
				}
			}
		}

		/// <summary>
		/// Gets the total number of fragments of a fragmented message as informed in tag 203.
		/// </summary>
		/// <returns> the total number of fragments or zero if the message is not fragmented
		/// @since 5.0 </returns>
		public virtual int? fragmentCount()
		{
			// if this is not a fragment => 0
			if (!(bool)this.Fragment)
			{
				return new int?(0);
			}

			// get the block 4 and tag 203 (they BOTH exists here)
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String t203 = this.block4.getTagValue("203");
			string t203 = this.block4.getTagValue("203");

			// process the number
			int? _t203;
			try
			{
				_t203 = new int?(Convert.ToInt32(t203, 10));
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final NumberFormatException nfe)
			catch (mberFormatException)
			{
				throw new System.NotSupportedException(MESSAGE_IS_NOT_A_FRAGMENT);
			}

			return _t203;
		}

		/// <summary>
		/// Gets the number of this fragment
		/// </summary>
		/// <returns> the number of this fragment </returns>
		/// <exception cref="UnsupportedOperationException"> if the message is not a part of a fragmented message
		/// @since 5.0 </exception>
		public virtual int? fragmentNumber()
		{
			// if this is not a fragment => 0
			if (!(bool)this.Fragment)
			{
				throw new System.NotSupportedException(MESSAGE_IS_NOT_A_FRAGMENT);
			}

			// get the block 4 and tag 203 (they BOTH exists here)
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String t202 = this.block4.getTagValue("202");
			string t202 = this.block4.getTagValue("202");

			// process the number
			int? _t202;
			try
			{
				_t202 = new int?(Convert.ToInt32(t202, 10));
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final NumberFormatException nfe)
			catch (mberFormatException)
			{
				throw new System.NotSupportedException(MESSAGE_IS_NOT_A_FRAGMENT);
			}

			return _t202;
		}

		/// <summary>
		/// Gets the signature of the message (looks for an S block then the MDG tag)
		/// </summary>
		/// <returns> the signature of the message (or null if none exists)
		/// @since 7.10.4 </returns>
		public virtual string Signature
		{
			get
			{
    
				// prepare the result
				string signature = null;
    
				// get the S block (create if it does not exist in the message)
				SwiftBlockUser sBlock = getUserBlock("S");
				if (sBlock != null)
				{
    
					// get the MDG tag from the block
					Tag mdg = sBlock.getTagByName("MDG");
					if (mdg != null)
					{
    
						// get the signature from the tag
						signature = mdg.Value;
					}
				}
    
				return signature;
			}
		}

		/// <summary>
		/// Sets the signature for the message (adds an S block with the MDG tag)
		/// </summary>
		/// <param name="signature"> the signature to set in block S </param>
		/// <returns> <code>this</code>
		/// @since 7.10.4 </returns>
		public virtual SwiftMessage setSignature(string signature)
		{

			// get the S block (create if it does not exist in the message)
			SwiftBlockUser sBlock = getUserBlock("S");
			if (sBlock == null)
			{

				// create the block
				sBlock = new SwiftBlockUser("S");

				// add the block to the message
				addUserBlock(sBlock);
			}

			// remove any MDG tag from the block (if present)
			Tag mdg = sBlock.getTagByName("MDG");
			if (mdg == null)
			{

				// create the tag
				mdg = new Tag();
				mdg.Name = "MDG";
				sBlock.append(mdg);
			}

			// set the signature on the tag
			mdg.Value = signature;

			return this;
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
		/// returns the unparsed text list </summary>
		/// <returns> the unparsed text attached to this message </returns>
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
		/// <returns> the count of unparsed texts attached to this message </returns>
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
		/// <returns> the unparsed text at position index parsed into a SwiftMessage object </returns>
		/// <exception cref="IllegalArgumentException"> if parameter index is null </exception>
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
		/// Checks if the message is a cover payment, based on the content of the User Header (block3). </summary>
		/// <returns> true if 119:COV is found at User Header (block3) </returns>
		public virtual bool COV
		{
			get
			{
				if (this.block3 != null)
				{
					return this.block3.containsTag(Field119.tag(MTVariant.COV.name()));
				}
				return false;
			}
		}

		/// <summary>
		/// Checks if the message is Straight Through Processing (STP), based on the content of the User Header (block3). </summary>
		/// <returns> true if 119:STP is found at User Header (block3) </returns>
		public virtual bool STP
		{
			get
			{
				if (this.block3 != null)
				{
					return this.block3.containsTag(Field119.tag(MTVariant.STP.name()));
				}
				return false;
			}
		}

		/// <summary>
		/// Checks if the message is a remit, based on the content of the User Header (block3). </summary>
		/// <returns> true if 119:REMIT is found at User Header (block3)
		/// @since 7.7 </returns>
		public virtual bool REMIT
		{
			get
			{
				if (this.block3 != null)
				{
					return this.block3.containsTag(Field119.tag(MTVariant.REMIT.name()));
				}
				return false;
			}
		}

		/// <summary>
		/// Gets the message sender BIC from the message headers.
		/// <para>For outgoing messages this is the the logical terminal at block 1,
		/// and for incoming messages this is logical terminal at the MIR of block 2.
		/// </para>
		/// <para>for service message (example acknowledges) always returns the logical terminal from block1
		/// 
		/// </para>
		/// </summary>
		/// <returns> the proper sender address or null if blocks 1 or 2 are not found or incomplete </returns>
		public virtual string Sender
		{
			get
			{
				try
				{
					if (ServiceMessage || Direction == MessageIOType.outgoing)
					{
						return this.block1 == null ? null : this.block1.LogicalTerminal;
					}
					else if (Direction == MessageIOType.incoming)
					{
						if (this.block2 != null)
						{
							return ((SwiftBlock2Output) this.block2).MIRLogicalTerminal;
						}
					}
				}
	//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
	//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
					log.severe("Exception ocurred while retrieving sender's BIC from message data: " + e);
				}
				return null;
			}
		}

		/// <summary>
		/// Gets the message receiver BIC from the message headers.
		/// <para>For outgoing messages this is the receiver address at block 2,
		/// and for incoming messages this is logical terminal at block 1.
		/// </para>
		/// <para>for service message (example acknowledges) always returns null
		/// 
		/// </para>
		/// </summary>
		/// <returns> the proper receiver address or null if blocks 1 or 2 are not found or incomplete </returns>
		public virtual string Receiver
		{
			get
			{
				try
				{
					if (ServiceMessage)
					{
						return null;
					}
					else if (Direction == MessageIOType.incoming)
					{
						return this.block1.LogicalTerminal;
					}
					else if (Direction == MessageIOType.outgoing)
					{
						return ((SwiftBlock2Input) this.block2).ReceiverAddress;
					}
					else
					{
						return null;
					}
				}
	//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
	//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
					log.severe("Exception ocurred while retrieving receiver's BIC from message data: " + e);
					return null;
				}
			}
		}

		/// <summary>
		/// Get all fields with the given name in the block 4.
		/// <em>Only direct naming is supported, 55a notation is NOT SUPPORTED</em>.
		/// </summary>
		/// <param name="names"> list of names to add in fields to search </param>
		/// <returns> a list with fields matching the given names. an empty list if none found </returns>
		/// <exception cref="IllegalArgumentException"> if names is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public List<Field> fields(final String... names)
		public virtual IList<Field> fields(params string[] names)
		{
			Validate.notNull(names, "names is null");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<Field>result = new ArrayList<>();
			<Field> result = new List<Field>();
			foreach (String n in names)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag[] tl = this.block4.getTagsByName(n);
				Tag[] tl = this.block4.getTagsByName(n);
				if (tl != null && tl.Length > 0)
				{
					foreach (Tag t in tl)
					{
						result.add(t.asField());
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Checks all blocks (1 to 5) and if a block is empty, it is removed from the message.
		/// @since 6.4
		/// </summary>
		public virtual void removeEmptyBlocks()
		{
			if (this.block1 != null && this.block1.Empty)
			{
				this.block1 = null;
			}
			if (this.block2 != null && this.block2.Empty)
			{
				this.block2 = null;
			}
			if (this.block3 != null && this.block3.Empty)
			{
				this.block3 = null;
			}
			if (this.block4 != null && this.block4.Empty)
			{
				this.block4 = null;
			}
			if (this.block5 != null && this.block5.Empty)
			{
				this.block5 = null;
			}
		}

		/// <summary>
		/// Gets message type as an int or -1 if an error occurs or it is not set </summary>
		/// <returns> the message type number or -1 if the message type is invalid or block 2 not present (for instance if the message is a service message)
		/// @since 6.4.1 </returns>
		public virtual int TypeInt
		{
			get
			{
				if (ServiceMessage)
				{
					return -1;
				}
				try
				{
					return Convert.ToInt32(Type);
				}
	//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
	//ORIGINAL LINE: catch (final NumberFormatException e)
				catch (NumberFormatException e)
				{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String text = "Error converting type to int " + getType();
					string text = "Error converting type to int " + Type;
					log.warning(text);
					log.log(Level.FINEST, text, e);
					return -1;
				}
			}
		}

		/// <summary>
		/// Returns the message direction from block 2 or null if block 2 is not found or incomplete
		/// @since 7.0
		/// </summary>
		public virtual MessageIOType Direction
		{
			get
			{
				try
				{
					if (this.block2 == null)
					{
						log.info("Requesting direction on a message without block2, can't determine direction. set log level to finer to view more details");
						log.finest("Message: " + this);
					}
					else
					{
						if (this.block2.Output)
						{
							return MessageIOType.incoming;
						}
						else if (this.block2.Input)
						{
							return MessageIOType.outgoing;
						}
					}
				}
	//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
	//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
					log.severe("Unexpected exception ocurred while determining direction from message data: " + e);
				}
				return null;
			}
		}

		/// <summary>
		/// Returns true if the message is outgoing (sent to SWIFT), false other case; using the direction attribute.
		/// If block 2 is missign or direction cannot be determined, returns false.
		/// @since 7.8.4
		/// </summary>
		public virtual bool Outgoing
		{
			get
			{
				return Direction == MessageIOType.outgoing;
			}
		}

		/// <seealso cref= #isOutgoing()
		/// @since 7.8.4 </seealso>
		public virtual bool Input
		{
			get
			{
				return Outgoing;
			}
		}

		/// <summary>
		/// Returns true if the message is incoming (received from SWIFT), false other case; using the direction attribute.
		/// If block 2 is missign or direction cannot be determined, returns false.
		/// @since 7.8.4
		/// </summary>
		public virtual bool Incoming
		{
			get
			{
				return Direction == MessageIOType.incoming;
			}
		}

		/// <seealso cref= #isIncoming()
		/// @since 7.8.4 </seealso>
		public virtual bool Output
		{
			get
			{
				return Incoming;
			}
		}

		/// <summary>
		/// Gets PDE (Possible Duplicate Emission) flag from the trailer block or null if the trailer or the PDE field is not present
		/// @since 7.0
		/// </summary>
		public virtual string PDE
		{
			get
			{
				return this.block5 != null? this.block5.getTagValue("PDE") : null;
			}
		}

		/// <summary>
		/// Gets PDM from the trailer block or null if the trailer or the PDM field is not present
		/// @since 7.0
		/// </summary>
		public virtual string PDM
		{
			get
			{
				return this.block5 != null? this.block5.getTagValue("PDM") : null;
			}
		}

		/// <summary>
		/// The MIR (Message Input Reference) is a String of 28 characters, always local to the sender of the message.
		/// It includes the date the sender sent the message to SWIFT, followed by the full LT address of the sender of the
		/// message, and the sender's session and sequence to SWIFT: YYMMDD BANKBEBBAXXX 2222 123456.
		/// It is only available in incoming messages (received from SWIFT).
		/// @since 7.0
		/// </summary>
		public virtual string MIR
		{
			get
			{
				if (this.block2 != null && this.block2.Output)
				{
					return ((SwiftBlock2Output) this.block2).MIR;
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Gets MUR (Message User Reference) from the user header block or null if the user header or MUR are not present.
		/// <para>The MUR is the Message User Reference used by applications for reconciliation with ACK.
		/// It is a free-format field in which users may specify their own reference of up to 16 characters
		/// of the permitted character set, and it is contained in a 108 field at the message user header (block 3).
		/// @since 7.0
		/// </para>
		/// </summary>
		public virtual string MUR
		{
			get
			{
				return this.block3 != null? this.block3.getTagValue(Field108.NAME) : null;
			}
		}

		/// <summary>
		/// Sets the MUR (Message User Reference) in the user header block.
		/// <para>If a MUR field is present, its value will be overwritten.
		/// </para>
		/// <para>The MUR is the Message User Reference used by applications for reconciliation with ACK.
		/// It is a free-format field in which users may specify their own reference of up to 16 characters
		/// of the permitted character set, and it is contained in a 108 field at the message user header (block 3).
		/// </para>
		/// </summary>
		/// <param name="mur"> a non blank MUR value to set, if value is blank this method does nothing </param>
		/// <returns> this
		/// @since 7.10.4 </returns>
		public virtual SwiftMessage setMUR(string mur)
		{
			if (StringUtils.isNotBlank(mur))
			{
				if (this.block3 == null)
				{
					this.block3 = new SwiftBlock3();
				}
				this.block3.builder().Field108 = new Field108(mur);
			}
			return this;
		}

		/// <summary>
		/// Gets a UUID (User Unique Identifier) for the message conformed by:
		/// 
		/// <ul>
		/// 	<li>Direction: A single-character direction indicator; "I" for an outgoing message (input to the network) and "O" for an incoming message (output from the network). Defaults to "I".</li>
		/// 	<li>The correspondent BIC 11 code; the receiver for an outgoing messages and the sender for an incoming message.</li>
		/// 	<li>Message type: the 3-character number identifying the specific message.</li>
		/// <li>Reference: field 20 or field 20C:SEME returned by <seealso cref="SwiftMessageUtils#reference(SwiftMessage)"/></li>
		/// </ul>
		/// 
		/// <para>Notice despite the name this identifier is unique only in the context of a specific message management platform,
		/// since all its values could be repeated from one installation to another. To make it completely unique in your
		/// application context, consider using <seealso cref="#getUID(Calendar, Long)"/>
		/// @since 7.0
		/// </para>
		/// </summary>
		public virtual string UUID
		{
			get
			{
				StringBuilder uuid = new StringBuilder();
				if (Incoming)
				{
					uuid.Append("O");
				}
				else
				{
					uuid.Append("I");
				}
				BIC corresp = CorrespondentBIC;
				if (corresp != null)
				{
					uuid.Append(corresp.Bic11);
				}
				uuid.Append(StringUtils.trimToEmpty(Type));
				uuid.Append(StringUtils.trimToEmpty(SwiftMessageUtils.reference(this)));
				return uuid.ToString();
			}
		}

		/// <summary>
		/// Gets a UID (Unique Identifier) for the message appending a suffix to the UUID generated with <seealso cref="#getUUID()"/>.
		/// 
		/// <para>The suffix is a system-generated value that can help uniquely identify a message. The suffix generated by this method is similar to the suffix
		/// used by SWIFT Alliance Lite. The first part is the creation date of the message in YYMMDD format, a six-digit number. The second part consists of 
		/// 1-10 left padded digit number generated from the container application/system incremental identifier.
		/// 
		/// </para>
		/// </summary>
		/// <param name="created"> optional creation date, if provided, the YYMMDD will be appended as first part of the suffix </param>
		/// <param name="id"> optional incremental identifier number from the application, if provided it will be appended as second part of the suffix </param>
		/// <returns> the created UID
		/// @since 7.9.5 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getUID(final Calendar created, final Long id)
		public virtual string getUID(DateTime created, long? id)
		{
			StringBuilder suffix = new StringBuilder();
			if (created != null)
			{
				SimpleDateFormat sdf = new SimpleDateFormat("yyMMdd");
				suffix.Append(sdf.format(created.Ticks));
			}
			if (id != null)
			{
				suffix.Append(StringUtils.leftPad(Convert.ToString(id), 10, "0"));
			}
			if (suffix.Length == 0)
			{
				log.warning("The computed suffix for message UID is blank, provide either the creation date or the numeric identifier as parameters for getUID");
			}
			return UUID + suffix.ToString();
		}

		public virtual SequenceNode ParsedSequences
		{
			get
			{
				return parsedSequences;
			}
			set
			{
				this.parsedSequences = value;
			}
		}


		/// <summary>
		/// return first results of fields() or null if none </summary>
		/// <param name="name"> </param>
		/// <seealso cref= #fields(String...) </seealso>
		/// <returns> null if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Field field(final String name)
		public virtual Field field(string name)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<Field> l = fields(name);
			IList<Field> l = fields(name);
			if (l.Count == 0)
			{
				return null;
			}
			return l[0];
		}

		/// <summary>
		/// Checks if the message is linked to other message based on the presence of a LINK sequence. </summary>
		/// <returns> true if the message has a LINK sequence, false if it hasn't, and null if cannot determine
		/// 
		/// @since 7.4 </returns>
		public virtual bool? Linked
		{
			get
			{
				if (this.block4 != null)
				{
					return !this.block4.getSubBlock("LINK").Empty;
				}
				return null;
			}
		}

		/// <summary>
		/// Return the message's LINK sequences if any. </summary>
		/// <returns> a block containing the found linkage sequences or null if cannot determine
		/// 
		/// @since 7.4 </returns>
		public virtual IList<SwiftTagListBlock> Linkages
		{
			get
			{
				if (this.block4 != null)
				{
					return this.block4.getSubBlocks("LINK");
				}
				return null;
			}
		}

		/// <summary>
		/// Legacy (version 1) json representation of this object.
		/// 
		/// <para>This implementation has been replaced by version 2, based on Gson.
		/// The main difference is in block4 where the new version serializes the list
		/// of Tag under a field named "tags", and in block 2 where the direction (I/O)
		/// has been explicitly added.
		/// 
		/// </para>
		/// </summary>
		/// @deprecated use <seealso cref="#toJson()"/> instead
		/// @since 7.9.8 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#toJson()"/> instead") @ProwideDeprecated(phase2 = com.prowidesoftware.deprecation.TargetYear._2019) public String toJsonV1()
		[Obsolete("use <seealso cref="#toJson()"/> instead")]
		public virtual string toJsonV1()
		{
			/*
			 * Return an ISO 8601 combined date and time string for current timestamp
			 */
			DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'", Locale.ENGLISH);
			dateFormat.TimeZone = TimeZone.getTimeZone("UTC");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String ts = dateFormat.format(Calendar.getInstance().getTime());
			string ts = dateFormat.format(new DateTime().Ticks);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			sb.Append("{ \"version\" : ").Append(JSON_VERSION).Append(",\n");

			sb.Append(" \"timestamp\" : \"").Append(ts).Append("\",\n");

			sb.Append(" \"data\" : { \n");

			sb.Append("\"block1\" : \n");
			if (this.block1 == null)
			{
				sb.Append(" {}");
			}
			else
			{
				sb.Append(this.block1.toJson());
			}
			sb.Append(",\n");

			sb.Append("\"block2\" : \n");
			if (this.block2 == null)
			{
				sb.Append(" {}");
			}
			else
			{
				sb.Append(this.block2.toJson());
			}
			sb.Append(",\n"); // block

			appendBlock("3", sb, this.block3);
			sb.Append(',');
			appendBlock("4", sb, this.block4);
			sb.Append(',');
			appendBlock("5", sb, this.block5);

			// add user blocks add if present - requires starting with a comma
			if (this.userBlocks != null && this.userBlocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Iterator<SwiftBlockUser> ubit = this.userBlocks.iterator();
				IEnumerator<SwiftBlockUser> ubit = this.userBlocks.GetEnumerator();
				sb.Append(',');
				sb.Append("\"userblocks\" : [ \n");
				while (ubit.MoveNext())
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlockUser ub = ubit.Current;
					SwiftBlockUser ub = ubit.Current;
					sb.Append("{ ");
					sb.Append("\"name\" :  \"").Append(ub.Name).Append("\",\n \"tags\" : ");
					sb.Append(ub.toJson());
					sb.Append("}\n");
				}
				sb.Append("] \n");
			}

			sb.Append("}\n"); // data
			sb.Append("}\n"); // message

			return sb.ToString();
		}

		/// <summary>
		/// Get a json representation of this object.
		/// <br>
		/// Generated JSON string will contain additional properties with
		/// version number and timestamp, while the actual SwiftMessage
		/// serialization is put into a data element.<br>
		/// 
		/// Example:<br>
		/// <pre>
		/// { "version": 2, "timestamp": "2016-08-26T23:57:36Z", data": {
		/// "block1": {
		/// 		"applicationId": "F",
		/// 		"serviceId": "01",
		/// 		"logicalTerminal": "FOOSEDR0AXXX",
		/// 		"sessionNumber": "0000",
		/// 		"sequenceNumber": "000000"
		/// } ,
		/// "block2": {
		///  	"messageType": "103",
		///  	"receiverAddress": "FOORECV0XXXX",
		///  	"messagePriority": "N",
		///  	"deliveryMonitoring": "null",
		///  	"obsolescencePeriod": "null"
		///  }
		///  "block4": {
		///  	"tags": [
		///  		{ "20": "REFERENCE" },
		///  		{ "23B": "CRED" },
		///  		{ "32A": "130204USD1234567,89" },
		///  		{ "50K": "/12345678901234567890\nFOOBANKXXXXX" },
		///  		{ "59": "/12345678901234567890\nJOE DOE" },
		///  		{ "71A": "OUR" }
		///  		]
		///  	}
		///  }
		///  </pre>
		/// 
		/// @since 7.5
		/// </summary>
		public virtual string toJson()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().registerTypeAdapter(SwiftMessage.class, new SwiftMessageAdapter()).registerTypeAdapter(SwiftBlock2.class, new SwiftBlock2Adapter()).setPrettyPrinting().create();
			Gson gson = (new GsonBuilder()).registerTypeAdapter(typeof(SwiftMessage), new SwiftMessageAdapter()).registerTypeAdapter(typeof(SwiftBlock2), new SwiftBlock2Adapter()).setPrettyPrinting().create();
			return gson.toJson(this);
		}

		/// <summary>
		/// This method deserializes the JSON data into a message object.
		/// </summary>
		/// <seealso cref= #toJson()
		/// @since 7.9.8 </seealso>
		public static SwiftMessage fromJson(string json)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().registerTypeAdapter(SwiftMessage.class, new SwiftMessageAdapter()).registerTypeAdapter(SwiftBlock2.class, new SwiftBlock2Adapter()).create();
			Gson gson = (new GsonBuilder()).registerTypeAdapter(typeof(SwiftMessage), new SwiftMessageAdapter()).registerTypeAdapter(typeof(SwiftBlock2), new SwiftBlock2Adapter()).create();
			return gson.fromJson(json,typeof(SwiftMessage));
		}

		/// <summary>
		/// Gets a proprietary XML representation of this message.<br>
		/// Notice: it is neither a standard nor the MX version of this MT. </summary>
		/// <seealso cref= XMLWriterVisitor </seealso>
		/// <seealso cref= XMLParser </seealso>
		/// <returns> the MT message serialized into the proprietary XML
		/// @since 7.8.4 </returns>
		public string toXml()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.StringWriter w = new java.io.StringWriter();
			StringWriter w = new StringWriter();
			visit(new XMLWriterVisitor(w, true));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String xml = w.getBuffer().toString();
			string xml = w.Buffer.ToString();
			if (log.isLoggable(Level.FINEST))
			{
				log.finest("xml: " + xml);
			}
			return xml;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void appendBlock(final String blockName, final StringBuilder sb, final SwiftTagListBlock b)
		private void appendBlock(string blockName, StringBuilder sb, SwiftTagListBlock b)
		{
			sb.Append("\"block" + blockName + "\" : \n");
			if (b == null)
			{
				sb.Append("{ }");
			}
			else
			{
				sb.Append(b.toJson());
			}
			sb.Append("\n"); // block
		}

		/// <summary>
		/// Get the MTxxx instance that corresponds to the current message type.
		/// <para>If you have a MT102 in a SwiftMessage, this method is the same as invoking
		/// <code>new MT102(SwiftMessage)</code>.
		/// </para>
		/// <para>For messages with service id 21 = GPA/FIN Message (ACK/NAK/UAK/UNK) it will
		/// return an instance of <seealso cref="ServiceMessage21"/>.
		/// 
		/// </para>
		/// </summary>
		/// <returns> created specific MT object or null if the message type is not set or an error occurs during message creation  </returns>
		public virtual AbstractMT toMT()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String type = getType();
			string type = Type;
			if (type == null)
			{
				if (ServiceMessage21)
				{
					return ServiceMessage21.newInstance(this);
				}
				log.warning("Cannot determine the message type from application header (block 2)");
			}
			else
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder className = new StringBuilder();
				StringBuilder className = new StringBuilder();
				className.Append("com.prowidesoftware.swift.model.mt.mt");
				className.Append(Convert.ToString((char) type[0]));
				className.Append("xx.MT");
				className.Append(type);
				if (STP)
				{
					if (isType(102, 103))
					{
						className.Append("_STP");
					}
					else
					{
						log.warning("Unexpected STP flag in MT " + Type);
					}
				}
				else if (REMIT)
				{
					if (isType(103))
					{
						className.Append("_REMIT");
					}
					else
					{
						log.warning("Unexpected REMIT flag in MT " + Type);
					}
				}
				else if (COV)
				{
					if (isType(202, 205))
					{
						className.Append("COV");
					}
					else
					{
						log.warning("Unexpected COV flag in MT " + Type);
					}
				}
				log.finer("About to create an instance of " + className);
				try
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Class mtClass = Class.forName(className.toString());
					Type mtClass = Type.GetType(className.ToString());
					return (AbstractMT) mtClass.GetConstructor(typeof(SwiftMessage)).newInstance(this);
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
					log.warning("Could not create instance of " + className + ": " + e);
				}
			}
			return null;
		}

		/// <summary>
		/// <para>Returns true if the message type is equal to the given number.
		/// </para>
		/// <para>Notice this method only checks the message type number but can be combined with any
		/// message variant check such as <seealso cref="#isSTP()"/>, <seealso cref="#isREMIT()"/> or <seealso cref="#isCOV()"/>
		/// to determine the message kind precisely.
		/// </para>
		/// <para>The implementation uses <seealso cref="#getTypeInt()"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="type"> message type number to check </param>
		/// <returns> true if message type matches, false if does not match or cannot be determined because the message content is invalid
		/// @since 7.8.9 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean isType(final int type)
		public virtual bool isType(int type)
		{
			return TypeInt == type;
		}

		/// <summary>
		/// Returns true if the message type is equal to one of the given numbers.
		/// The implementation uses <seealso cref="#getTypeInt()"/> </summary>
		/// <param name="types"> message type numbers to check </param>
		/// <returns> true if message type matches, false if does not match or cannot be determined because the message content is invalid
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean isType(final int... types)
		public virtual bool isType(params int[] types)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int mt = getTypeInt();
			int mt = TypeInt;
			foreach (int t in types)
			{
				if (mt == t)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns true if the message category is equal to one of the given by parameter </summary>
		/// <param name="categories"> the categories 0 to 9 to check </param>
		/// <returns> true if message category, false if does not match or cannot be determined because the message content is invalid or the categories parameter contains values other than 0 to 9
		/// @since 7.8.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public final boolean isCategory(final MtCategory... categories)
		public bool isCategory(params MtCategory[] categories)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MtCategory cat = getCategory();
			MtCategory cat = Category;
			foreach (MtCategory t in categories)
			{
				if (cat == t)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns the message category from the message type.
		/// This implementation uses <seealso cref="#getType()"/> to retrieve the message type of the message. </summary>
		/// <returns> the category found as the first digit of the message type or null if block 2 is not found or the message type is not category number </returns>
		public MtCategory Category
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String type = getType();
				string type = Type;
				if (type != null)
				{
					try
					{
						return MtCategory.valueOf("_" + type.Substring(0, 1));
					}
	//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
	//ORIGINAL LINE: catch (final Exception e)
					catch (Exception e)
					{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String text = "Error extracting category from message type " + getType();
						string text = "Error extracting category from message type " + Type;
						log.warning(text);
						log.log(Level.FINEST, text, e);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Returns true if message service id is anything but 01 = GPA/FIN Message (system and user-to-user)
		/// 
		/// @since 7.8.8
		/// </summary>
		public bool ServiceMessage
		{
			get
			{
				if (this.block1 == null)
				{
					return false;
				}
				return this.block1.ServiceIdType != ServiceIdType._01;
			}
		}

		/// <summary>
		/// Returns true if message service id is 21 = GPA/FIN Message (ACK/NAK/UAK/UNK)
		/// 
		/// <para>IMPORTANT: Note despite the method name this will NOT return true for FIN system messages (category 0).
		/// It is just useful to detect acknowledges.<br>
		/// To check for system messages use <seealso cref="#isCategory(MtCategory...)"/> instead, passing zero as parameter
		/// 
		/// </para>
		/// </para>
		/// </summary>
		/// <para>@deprecated this method is kept for backward compatibility but was replace by <seealso cref="#isServiceMessage21()"/> which
		/// reflects what the method returns properly. Notice a "system message" is actually a message with category 0, which is 
		/// not the same as a "service message".
		/// 
		/// @since 7.8 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("this method is kept for backward compatibility but was replace by <seealso cref="#isServiceMessage21()"/> which") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public boolean isSystemMessage()
		[Obsolete("this method is kept for backward compatibility but was replace by <seealso cref="#isServiceMessage21()"/> which")]
		public virtual bool SystemMessage
		{
			get
			{
				DeprecationUtils.phase2(this.GetType(), "isSystemMessage()", "Despite the method name this will NOT return true for FIN system messages (category 0), use isServiceMessage21() instead.");
				return ServiceMessage21;
			}
		}

		/// <summary>
		/// Returns true if message service id is 21 = GPA/FIN Message (ACK/NAK/UAK/UNK) </summary>
		/// <returns> true if it is a service message for acknowledgment, false if not or header is null and service id cannot be determined
		/// @since 7.8.9 </returns>
		public virtual bool ServiceMessage21
		{
			get
			{
				if (this.block1 == null)
				{
					return false;
				}
				return this.block1.ServiceIdType == ServiceIdType._21;
			}
		}

		/// <summary>
		/// Returns true if this message is an ACK.
		/// This is determined by testing first if it is a system message, and second
		/// the value of tag 451
		/// 
		/// @since 7.8
		/// </summary>
		public virtual bool Ack
		{
			get
			{
				if (ServiceMessage21)
				{
					if (this.block4 == null)
					{
						return false;
					}
					return StringUtils.Equals(this.block4.getTagValue(Field451.NAME), "0");
				}
				return false;
			}
		}

		/// <summary>
		/// Returns true if this message is an NACK.
		/// This is determined by testing first if it is a system message, and second
		/// the value of tag 451
		/// 
		/// @since 7.8
		/// </summary>
		public virtual bool Nack
		{
			get
			{
				if (ServiceMessage21)
				{
					if (this.block4 == null)
					{
						return false;
					}
					return StringUtils.Equals(this.block4.getTagValue(Field451.NAME), "1");
				}
				return false;
			}
		}

		/// <returns> the corresponding MT variant or null if flag field is not present
		/// @since 7.8 </returns>
		public virtual MTVariant Variant
		{
			get
			{
				if (COV)
				{
					return MTVariant.COV;
				}
				else if (STP)
				{
					return MTVariant.STP;
				}
				else if (REMIT)
				{
					return MTVariant.REMIT;
				}
				return null;
			}
			set
			{
				if (!value.ValidationFlag)
				{
					log.warning("Field " + Field199.NAME + " should be used only for validation flags and not for " + value.name());
				}
				if (this.block3 == null)
				{
					this.block3 = new SwiftBlock3();
				}
				this.block3.builder().Field119 = new Field119(value.name());
			}
		}

		/// <summary>
		/// Get a list of unique tagname contained in this message </summary>
		/// <returns> the list of tagnames or an empty list, does not return null ever
		/// @since 7.8 </returns>
		public virtual IList<string> TagNames
		{
			get
			{
				if (this.block4 == null || this.block4.Empty)
				{
					return java.util.Collections.emptyList();
				}
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final List<String> result = new ArrayList<>();
				IList<string> result = new List<string>();
				foreach (Tag t in this.block4.Tags)
				{
					if (!result.Contains(t.Name))
					{
						result.Add(t.Name);
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Returns the MT message identification.<br>
		/// Composed by the business process, message type and variant.
		/// Example: fin.103.STP
		/// </summary>
		/// <returns> the constructed message id or null if message is a service message
		/// @since 7.8.4 </returns>
		public virtual MtId MtId
		{
			get
			{
				if (ServiceMessage)
				{
					return null;
				}
				else
				{
					return new MtId(Type, Variant);
				}
			}
		}

		/// <summary>
		/// Returns the correspondent BIC code from the headers.<br>
		/// For an outgoing message, the BIC address identifies the receiver of the message. Where for an incoming message it identifies the sender of the message. </summary>
		/// <returns> the correspondent BIC code or null if headers are not properly set
		/// @since 7.9.5 </returns>
		public virtual BIC CorrespondentBIC
		{
			get
			{
				if (Outgoing)
				{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String receiver = getReceiver();
					string receiver = Receiver;
					if (receiver != null)
					{
						return new BIC(receiver);
					}
				}
				if (Incoming)
				{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String sender = getSender();
					string sender = Sender;
					if (sender != null)
					{
						return new BIC(sender);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Gets the Service Type Identifier (field 111 from block 3).
		/// <para>This field is used by the SWIFT gpi service to track payments messages (category 1 and 2).
		/// 
		/// </para>
		/// </summary>
		/// <returns> the Service Type Identifier value or null if block3 or field 111 in block3 are not present
		/// @since 7.10.0 </returns>
		public virtual string ServiceTypeIdentifier
		{
			get
			{
				return this.block3 != null? this.block3.getTagValue(Field111.NAME) : null;
			}
			set
			{
				if (this.block3 == null)
				{
					this.block3 = new SwiftBlock3();
				}
				this.block3.builder().Field111 = new Field111(value);
			}
		}


		/// <summary>
		/// Gets the Unique End to End Transaction Reference (field 121 from block 3).
		/// <para>This field is used by the SWIFT gpi service to track payments messages (category 1 and 2).
		/// </para>
		/// </summary>
		/// <returns> the UETR value or null if block3 or field 121 in block3 are not present
		/// 
		/// @since 7.10.0 </returns>
		public virtual string UETR
		{
			get
			{
				return this.block3 != null? this.block3.getTagValue(Field121.NAME) : null;
			}
			set
			{
				if (this.block3 == null)
				{
					this.block3 = new SwiftBlock3();
				}
				this.block3.builder().Field121 = new Field121(value);
			}
		}


		/// <summary>
		/// Creates and sets the Unique End to End Transaction Reference (field 121 in block 3).
		/// <para>If the field already exists, its value will be updated
		/// </para>
		/// <para>This field is used by the SWIFT gpi service to track payments messages (category 1 and 2).
		/// 
		/// </para>
		/// </summary>
		/// <returns> the UETR created (new value of field 121 in block3 after the operation)
		/// @since 7.10.0 </returns>
		public virtual string setUETR()
		{
			UUID uuid = UUID.randomUUID();
			string uuid36 = uuid.ToString();
			UETR = uuid36;
			return uuid36;
		}


		/// <summary>
		/// Returns true if the message is part of the Global Payments Initiative (gpi) and
		/// thus requires the mandatory UETR for tracking within SWIFT gpi service. </summary>
		/// <returns> true if the message type is 103, 202 or 205 in any variant
		/// @since 7.10.0 </returns>
		/// <seealso cref= #setUETR() </seealso>
		public virtual bool Gpi
		{
			get
			{
				return isType(103, 202, 205);
			}
		}

	}
}