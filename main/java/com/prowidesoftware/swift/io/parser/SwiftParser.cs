using System;
using System.Collections;
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
namespace com.prowidesoftware.swift.io.parser
{

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using com.prowidesoftware.swift.model;
	using Lib = com.prowidesoftware.swift.utils.Lib;
	using StringUtils = org.apache.commons.lang3.StringUtils;


	/// <summary>
	/// FIN Parser. This implementation now properly supports all system messages (i.e: messages for MT 0xx) and
	/// service messages (for example: ACK).<br>
	/// As part of this, the following is now also accepted:<br>
	/// <ul>
	/// <li>Block 4 may be a non-text block (for example: {4:{101:xx}{102:xx}})</li>
	/// <li>Support for unparsed texts (at message, block and tag levels)</li>
	/// <li>Support for user defined blocks (for example: {S:{T01:xxx}{T02:yyy}})</li>
	/// </ul><br>Field32A
	/// This is based in the old SwiftParser2, that is now deprecated.<br>
	/// 
	/// @author www.prowidesoftware.com
	/// </summary>
	public class SwiftParser
	{

		/// <summary>
		/// Helper constant with the content of <code>System.getProperty("line.separator", "\n")</code>
		/// </summary>
		public static readonly string EOL = System.getProperty("line.separator", "\n");

//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftParser).FullName);

		private Reader reader;

		private StringBuilder buffer;

		/// <summary>
		/// Reference to the current message being parsed.
		/// This should be used when some parsing decision needs to be made based on a previous item parsed,
		/// like a value in a previous tag or block.
		/// </summary>
		private SwiftMessage currentMessage;

		/// <summary>
		/// Errors found while parsing the message.
		/// </summary>
		private readonly IList<string> errors = new List<string>();

		private int lastBlockStartOffset = 0;

		/// <summary>
		/// @since 7.8
		/// </summary>
		private SwiftParserConfiguration configuration = new SwiftParserConfiguration();

		/// <summary>
		/// Constructor with an input stream for parsing a message </summary>
		/// <param name="is"> stream to read </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftParser(final InputStream is)
		public SwiftParser(InputStream @is) : this(new InputStreamReader(@is))
		{
		}

		/// <summary>
		/// Constructor with a reader for parsing a message </summary>
		/// <param name="r"> the Reader with the swift message to read </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftParser(final Reader r)
		public SwiftParser(Reader r) : this()
		{
			Reader = r;
		}

		/// <summary>
		/// Constructor with a String for parsing a message </summary>
		/// <param name="message"> the String with the swift message to read </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftParser(final String message)
		public SwiftParser(string message) : this(new StringReader(message))
		{
		}

		/// <summary>
		/// default constructor.<br>
		/// <b>NOTE</b>: If this constructor is called, setReader must be called to use the parser
		/// </summary>
		public SwiftParser() : base()
		{
		}

		/// <summary>
		/// Create a parser and feed it with the contents of the given file </summary>
		/// <param name="messageFile"> existing, readable file to read </param>
		/// <exception cref="IOException"> if an error occurs during read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public SwiftParser(final File messageFile) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public SwiftParser(File messageFile) : this(Lib.readFile(messageFile))
		{
		}

		/// <summary>
		/// sets the input reader.<br>
		/// <b>NOTE</b>: this resets the internal buffer </summary>
		/// <param name="r"> the reader to use </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setReader(final Reader r)
		public virtual Reader Reader
		{
			set
			{
				this.buffer = new StringBuilder();
				this.reader = value;
			}
		}

		/// <summary>
		/// sets the input data to the received string. </summary>
		/// <param name="data"> the data to use as input </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setData(final String data)
		public virtual string Data
		{
			set
			{
				Reader = new StringReader(value);
			}
		}

		/// <summary>
		/// Parse a SWIFT message into a data structure.
		/// 
		/// The implementation uses the default parser behaviour which is lenient and will do a best effort to
		/// read as much from the message content as possible regardless of the content and block boundaries
		/// beeing valid or not. For instance, it will read the headers even if the value length is incorrect,
		/// and it will read the text block (block 4) even if it is missing the closing hyphen and bracket. For
		/// more options check <seealso cref="#setConfiguration(SwiftParserConfiguration)"/>
		/// </summary>
		/// <returns> the parsed swift message object </returns>
		/// <exception cref="IOException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public SwiftMessage message() throws IOException
		public virtual SwiftMessage message()
		{

			// create a message and store for local reference
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage message = new SwiftMessage(false);
			SwiftMessage message = new SwiftMessage(false);
			this.currentMessage = message;

			// Clear all errors before starting the parse process
			this.errors.Clear();
			try
			{
				bool done = false;
				SwiftBlock b;
				do
				{
					// try to consume a block
					b = consumeBlock(message.UnparsedTexts);
					if (b != null)
					{
						this.currentMessage.addBlock(b);
					}
					else
					{
						done = true;
					}
				} while (!done);
			}
			finally
			{
				// Clean the reference to the message being parsed
				this.currentMessage = null;
			}

			return message;
		}

		/// @deprecated use <seealso cref="SwiftMessage#parse(String)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="SwiftMessage#parse(String)"/> instead") @ProwideDeprecated(phase2=com.prowidesoftware.deprecation.TargetYear._2019) public SwiftMessage parse(final String message) throws IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use <seealso cref="SwiftMessage#parse(String)"/> instead")]
		public virtual SwiftMessage parse(string message)
		{
			Data = message;
			return message();
		}

		/// @deprecated use <seealso cref="#consumeBlock(UnparsedTextList)"/> instead of this, <code>consumeBlock(null)</code> is acceptable 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#consumeBlock(UnparsedTextList)"/> instead of this, <code>consumeBlock(null)</code> is acceptable") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) protected SwiftBlock consumeBlock() throws IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		[Obsolete("use <seealso cref="#consumeBlock(UnparsedTextList)"/> instead of this, <code>consumeBlock(null)</code> is acceptable")]
		protected internal virtual SwiftBlock consumeBlock()
		{
			DeprecationUtils.phase3(this.GetType(), "consumeBlock()", "Use consumeBlock(UnparsedTextList) instead of this, consumeBlock(null) is acceptable.");
			return consumeBlock(null);
		}

		/// <summary>
		/// Consume the next block of the message on the reader.
		/// This methods seeks to a block start, then identifies the block
		/// and calls the proper method to consume the block type
		/// that is coming, not all blocks are parsed in the same manner. </summary>
		/// <param name="unparsedReceiver"> may be null, the unparsedTextList that will receive the chunks that can not be identified sas part of the message
		/// </param>
		/// <returns> the next block in the reader or null if none was found (i.e: end of input) </returns>
		/// <exception cref="IOException"> if an error occurred during read </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected SwiftBlock consumeBlock(final UnparsedTextList unparsedReceiver) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		protected internal virtual SwiftBlock consumeBlock(UnparsedTextList unparsedReceiver)
		{

			// search for block start
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String unparsed = findBlockStart();
			string unparsed = findBlockStart();

			// si el string es no vacio agregarlo a unparsed texts

			// read the block contents
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String s = readUntilBlockEnds();
			string s = readUntilBlockEnds();
			if ("".Equals(s))
			{
				/* if we have an unparsed text add it to last block */
				if (unparsed.Length > 0)
				{
					if (unparsedReceiver == null)
					{
						log.warning("Unparsed text '" + unparsed + "' can not be reported since unparsedReceiver is null");
					}
					else
					{
						unparsedReceiver.addText(unparsed);
					}
				}
				return null;
			}

			// analyze if it is an unparsed text
			//
			// NOTE: This can happen when we have got a block 1 and there is already a block 1
			//
			if (s.StartsWith("1:", StringComparison.Ordinal) && this.currentMessage != null && this.currentMessage.Block1 != null)
			{

				// unparsed text => initialize value to append
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder utBuffer = new StringBuilder();
				StringBuilder utBuffer = new StringBuilder();
				utBuffer.Append("{");
				utBuffer.Append(s);
				utBuffer.Append("}");
				bool done = false;

				while (!done)
				{
					// try to read a block of data
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char data[] = new char[128];
					char[] data = new char[128];
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int size = this.reader.read(data);
					int size = this.reader.read(data);
					if (size > 0)
					{
						// append the read buffer
						utBuffer.Append(data);
					}
					else
					{
						// we are done
						done = true;
					}
				}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String unparsedText = utBuffer.toString();
				string unparsedText = utBuffer.ToString();

				// build an unparsed text list
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final UnparsedTextList list = processUnparsedText(unparsedText);
				UnparsedTextList list = processUnparsedText(unparsedText);
				if (list != null)
				{
					this.currentMessage.UnparsedTexts = list;
				}

				// no more reading
				return null;
			}

			// identify and create the proper block
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char blockId = identifyBlock(s);
			char blockId = identifyBlock(s);
			SwiftBlock b;
			if (blockId == ' ')
			{
				// block cannot be identified
				log.severe("unidentified block:" + s);
				throw new ProwideException("The block " + s + " could not be identified");
			}

			// create the block object
			b = createBlock(blockId, s);

			if (unparsed.Length > 0)
			{
				if (unparsedReceiver == null)
				{
					log.warning("Unparsed text '" + unparsed + "' can not be reported since unparsedReceiver is null");
				}
				else
				{
					unparsedReceiver.addText(unparsed);
				}
			}
			return b;
		}

		/// <summary>
		/// Creates the specific block instance consuming the extracted content </summary>
		/// <param name="blockId"> the block identifier, example: 1, 2, 3, 4, 5 </param>
		/// <param name="s"> the block content </param>
		/// <returns> a specific block instance with the parsed content </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private SwiftBlock createBlock(final char blockId, final String s) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		private SwiftBlock createBlock(char blockId, string s)
		{
			SwiftBlock b = null;

			// create the block object
			switch (blockId)
			{
				case '1': // block 1 (single valued)
					b = createBlock1(s);
					break;
				case '2': // block 2 (single valued)
					if (isInput(s))
					{
						b = createBlock2Input(s);
					}
					else
					{
						b = createBlock2Output(s);
					}
					break;
				case '3': // block 3 (tag list)
					b = tagListBlockConsume(new SwiftBlock3(), s);
					break;
				case '4': // block 4
					if (this.configuration.ParseTextBlock)
					{
						if (isTextBlock(s))
						{
							b = block4Consume(new SwiftBlock4(), s);
						}
						else
						{
							b = tagListBlockConsume(new SwiftBlock4(), s);
						}
					}
					else
					{
						b = new SwiftBlock4();
					}
					break;
				case '5': // block 5 (tag list)
					if (this.configuration.ParseTrailerBlock)
					{
						b = tagListBlockConsume(new SwiftBlock5(), s);
					}
					else
					{
						b = new SwiftBlock5();
					}
					break;
				default: // user defined block (tag list)
					if (this.configuration.ParseUserBlock)
					{
						b = tagListBlockConsume(new SwiftBlockUser(char.ToString(blockId)), s);
					}
					else
					{
						b = new SwiftBlockUser();
					}
					break;
			}
			return b;
		}

		/// <summary>
		/// Creates the block 1, dealing with the <seealso cref="IllegalArgumentException"/> in case of lenient mode
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SwiftBlock1 createBlock1(final String s)
		private SwiftBlock1 createBlock1(string s)
		{
			try
			{
				return new SwiftBlock1(s, false);
			}
			catch (System.ArgumentException e)
			{
				if (this.configuration.Lenient)
				{
					// if configuration is lenient we record the default strict parsing error and try again in lenient mode
					this.errors.Add(e.Message);
					return new SwiftBlock1(s, true);
				}
				else
				{
					throw e;
				}
			}
		}

		/// <summary>
		/// Creates the block 2, dealing with the <seealso cref="IllegalArgumentException"/> in case of lenient mode
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SwiftBlock2Input createBlock2Input(final String s)
		private SwiftBlock2Input createBlock2Input(string s)
		{
			try
			{
				return new SwiftBlock2Input(s, false);
			}
			catch (System.ArgumentException e)
			{
				if (this.configuration.Lenient)
				{
					// if configuration is lenient we record the default strict parsing error and try again in lenient mode
					this.errors.Add(e.Message);
					return new SwiftBlock2Input(s, true);
				}
				else
				{
					throw e;
				}
			}
		}

		/// <summary>
		/// Creates the block 2, dealing with the <seealso cref="IllegalArgumentException"/> in case of lenient mode
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SwiftBlock2Output createBlock2Output(final String s)
		private SwiftBlock2Output createBlock2Output(string s)
		{
			try
			{
				return new SwiftBlock2Output(s, false);
			}
			catch (System.ArgumentException e)
			{
				if (this.configuration.Lenient)
				{
					// if configuration is lenient we record the default strict parsing error and try again in lenient mode
					this.errors.Add(e.Message);
					return new SwiftBlock2Output(s, true);
				}
				else
				{
					throw e;
				}
			}
		}

		/// <summary>
		/// Attempt to detect if block 2 refers to an input or output message.
		/// If the parameter block content is not well-formed will return false as default. </summary>
		/// <param name="s"> the block 2 value (as a FIN value) for example I100BANKDEFFXXXXU3003 or 2:I100BANKDEFFXXXXU3003 </param>
		/// <returns> whether it's an input block 2 (true) or an output one (false) </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static boolean isInput(final String s)
		private static bool isInput(string s)
		{
			// try to find out the in/out type
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int i = s.indexOf(':');
			int i = s.IndexOf(':');
			char? ch = null;
			if (i >= 0 && (i + 1) < s.Length)
			{
				// check for input mark after ':'
				ch = s[i + 1];
			}
			else if (s.Length > 0)
			{
				// check start
				ch = s[0];
			}
			return ch != null && char.ToUpper(ch) == 'I';
		}

		/// <summary>
		/// consumes a tag list block (i.e: block 3, block 5 or user defined block)
		/// </summary>
		/// <param name="b"> the block to set up tags into </param>
		/// <param name="s"> the block data to process </param>
		/// <returns> the processed block (the parameter b) </returns>
		/// <exception cref="IOException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected SwiftTagListBlock tagListBlockConsume(final SwiftTagListBlock b, final String s) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		protected internal virtual SwiftTagListBlock tagListBlockConsume(SwiftTagListBlock b, string s)
		{
			// start processing the block data
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int start = s.indexOf(':');
			int start = s.IndexOf(':');
			if (start >= 0 && (start + 1) < s.Length)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String data = s.substring(start + 1);
				string data = s.Substring(start + 1);

				/*
				 * Enter a loop that will read any block or inner data
				 * The idea is to accept equally these strings:
				 * {block1}{block2}
				 * data1{block1}data2{block2}data3
				 */
				for (int i = 0; i < data.Length; i++)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char c = data.charAt(i);
					char c = data[i];
					if (c == '{')
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int end = data.indexOf('}', i);
						int end = data.IndexOf('}', i);
						if (end >= 0 && data.Length > end)
						{

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String inner = StringHelperClass.SubstringSpecial(data, i + 1, end);
							string inner = StringHelperClass.SubstringSpecial(data, i + 1, end);
							// Seek the cursor to last 'processed' position
							i = end;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = new Tag(inner);
							Tag t = new Tag(inner);
							log.finest("" + t);
							b.append(t);
						}
					}
					else
					{
						// read all the characters until data end or a new '{'
						int end;
						for (end = i; end < data.Length && data[end] != '{'; end++)
						{
						}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String unparsedText = data.substring(i, end - i).trim();
						string unparsedText = data.Substring(i, end - i).Trim();
						if (!"".Equals(unparsedText))
						{
							b.unparsedTextAddText(unparsedText);
						}
						i = end - 1;
					}
				}
			}

			return b;
		}

		/// <summary>
		/// Parses a block 4 from an input string. This method supports the two possible formats of
		/// a swift block 4:<br>
		/// <ul>
		/// <li><b>Text mode</b>: this is the common block 4 for categories 1 to 9.</li>
		/// <li><b>Tag mode</b>: this is the same format as for blocks 3 and 5. This format is used by
		/// service messages (for example: ACK) and system messages (category 0).</li>
		/// </ul><br>
		/// </summary>
		/// <param name="b"> the block to set up tags into </param>
		/// <param name="s"> the block data to process </param>
		/// <returns> the processed block (the parameter b) </returns>
		/// <exception cref="IOException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected SwiftBlock4 block4Consume(final SwiftBlock4 b, final String s) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		protected internal virtual SwiftBlock4 block4Consume(SwiftBlock4 b, string s)
		{
			/*
			 * Note that if the block4 is a text block last character is -, which is part of the EOB
			 * since the parser removes the last }
			 */

			// process by "tokenizing" the input, this meaning:
			// - skip the "4:" (block identifier)
			// - scan for a tag start character (maybe '{' or ':')
			//   - if start is '{' => find tag end by balancing braces => split tag (considering unparsed texts)
			//   - if start is ':' => find tag end as '<CR><LF>:[X]' => split tag (no unparsed texts)
			// - detect block end as '<CR><LF>-}' or '}'
			//
			int start = 0;
			if (s[start] == '4')
			{
				start++;
			}
			if (s[start] == ':')
			{
				start++;
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean isTextBlock = isTextBlock(s);
			bool isTextBlock = isTextBlock(s);

			Tag lastTag = null;
			// start processing tags
			while (start < s.Length)
			{

				// position ourselves at something meaningful
				int begin = start;
				char c = ' ', prev ;
				do
				{
					prev = c;
					c = s[start++];
				} while (start < s.Length && c != ':' && c != '{' && !(prev == '-' && c == '}'));

				// check if we must correct end of unparsed text by "-}" (we don't want "-" to be unparsed text)
				int ignore = 0;
				if (c == '}')
				{
					if (s[start - 1] == '-')
					{
						ignore = 1;
					}
				}

				// check if we skipped a block unparsed text
				string unparsedText = s.Substring(begin, start - ignore - 1 - begin).Trim();
				if (!"".Equals(unparsedText))
				{
					b.unparsedTextAddText(unparsedText);
				}

				// if no more buffer => terminate
				if (start == s.Length)
				{
					continue;
				}

				// decide what are we looking at (notice that "-}" is detected by "}")
				int end = 0;
				string tag = null;
				string tagUnparsedText = null;
				switch (c)
				{
				case '}':
					// force termination only if ending string is -}
					if ((isTextBlock && ignore == 1) || !isTextBlock)
					{
						start = s.Length;
					}
					/*
					 * De la terminacion anterior debemos contemplar que termino el mensaje de alguna forma porque
					 * parece que no se esta detectando bien y entra en loop infinito (bug reportado de hecho)
					 */
					/// TODO review this log seems to be part of an infinite loop
					log.severe("malformed message: exit by bracket");
					//				break;
					goto case ':';
				case ':':
					// get the tag text
					end = textTagEndBlock4(s, start, isTextBlock);
					tag = s.Substring(start, end - start);
					break;
				case '{':
					// two things are possible here:
					// A) this is an unparsed text (i.e: the tag id is 1)
					// B) this is a valid tag (i.e: the tag id is not one)
					if (s.StartsWith("1:", start))
					{
						//
						// CASE A (an unparsed text)
						//

						// keep our position
						begin = start > 0 ? start - 1 : 0;
						end = begin + 1;
						while (end < s.Length && !s.StartsWith("{1:", end))
						{
							end = blockTagEnd(s, end + 1);
						}

						// get the unparsed text
						unparsedText = s.Substring(begin, end - begin);

						// add the unparsed text
						b.unparsedTextAddText(unparsedText);
					}
					else
					{
						//
						// CASE B (a tag)
						//

						// get the tag text
						end = blockTagEnd(s, start);
						tag = s.Substring(start, end - 1 - start);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int utPos = tag.indexOf("{1:");
						int utPos = tag.IndexOf("{1:", StringComparison.Ordinal);
						if (utPos != -1)
						{
							// separate unparsed texts from value
							tagUnparsedText = tag.Substring(utPos);
							tag = tag.Substring(0, utPos);
						}
					}
					break;
				} // switch(c)

				// process the tag (only if we have a tag)
				if (tag != null)
				{

					// process the tag
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = consumeTag(tag, tagUnparsedText);
					Tag t = consumeTag(tag, tagUnparsedText);
					if (t != null)
					{
						b.append(t);
						lastTag = t;
					}
				}

				// continue processing from the end of this tag
				start = end;
			}

			// Strip EOB from last tags value
			stripEOB(lastTag);

			return b;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void stripEOB(final Tag lastTag)
		private void stripEOB(Tag lastTag)
		{
			if (lastTag != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String v = lastTag.getValue();
				string v = lastTag.Value;
				if (v != null)
				{
					/*
					 * In the parser we support both \r\n or \n as line separator
					 */
					if (v.EndsWith("\r\n-", StringComparison.Ordinal))
					{
						lastTag.Value = v.Substring(0, v.Length - 3);
					}
					else if (v.EndsWith("\n-", StringComparison.Ordinal))
					{
						lastTag.Value = v.Substring(0, v.Length - 2);
					}
				}
			}
		}

		/// <summary>
		/// finds the end of a text tag (i.e: ":TAG:VALUE"). This is used to parse block 4.<br>
		/// The function search the string looking for the occurrence of any of the sequences:<br>
		/// <ul>
		/// <li>"[LBR]:[X]"</li>
		/// <li>"[LBR]}"</li>
		/// <li>"[LBR]{"</li>
		/// <li>"}"</li>
		/// </ul>
		/// where "[LBR]" stands for any of: "[CR]", "[LF]" or "[CR][LF]"
		/// and "[X]" is any character other than [CR] and [LF].<br>
		/// Then considers the end of the tag as <b>NOT</b> containing the found sequence.<br>
		/// <b>NOTE</b>: the condition "-}" cannot happen because the terminating dash is already removed.<br>
		/// 
		/// renamed to state clearly that this search is only used in block4Consume
		/// </summary>
		/// <param name="s"> the FIN input text </param>
		/// <param name="start"> the position to start analysis at </param>
		/// <returns> the position where the tag ends (excluding the &lt;CR&gt;&lt;LF&gt;) </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected int textTagEndBlock4(final String s, int start, final boolean isTextBlock)
		protected internal virtual int textTagEndBlock4(string s, int start, bool isTextBlock)
		{

			int i = start;

			// start scanning for tag end
			for (; i < s.Length; i++)
			{

				// check if we found tag end
				char c = s[i];
				if (c == '\r' || c == '\n')
				{

					// keep this position
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int begin = i;
					int begin = i;

					// repeat cause "\r\n", accept "\n\r" also
					if ((i + 1) == s.Length)
					{
						break;
					}
					c = s[++i];
					if (c == '\r' || c == '\n')
					{
						if ((i + 1) == s.Length)
						{
							break;
						}
						c = s[++i];
					}

					// if open brace => it's a proper tag end (mixing BLOCK and TEXT tags, rare but...)
					// if closing brace => it's a proper tag end (because of block end)
					if ((!isTextBlock) && (c == '{' || c == '}'))
					{
						// found it
						i = begin;
						break;
					}
					// if it's a colon followed by a character different than CR or LF (':x') => it's a proper tag end
					// because we have reached a new line with a beginning new tag.
					// Note: It is note sufficient to check for a starting colon because for some fields like
					// 77E for example, it is allowed the field content to have a ':<CR><LF>' as the second line
					// of its content.
					else if (c == ':' && i < s.Length) // prevent index out of bounds
					{
						// check if :xxx matches a new starting tag or not, break only if matches valid start of tag
						if (tagStarts(s, (i + 1)))
						{
							i = begin;
							break;
						}
					}

					// not matched => skip current char and continue
					i = begin;
					continue;
				}

				// check if we found block end (as "-}")
				if (c == '-')
				{

					// check for closing brace
					c = (i + 1) < s.Length ? s[i + 1] : ' ';
					if (c == '}' && isTextBlock)
					{
						break;
					}
				}

				// check if we found block end (as "}")
				if (c == '}' && !isTextBlock)
				{
					break;
				}
			}

			return i;
		}

		/// <summary>
		/// Evaluates if the string at the given position has the format nn[a]:
		/// which means it is a proper tag start.
		/// <para>This method could be overwritten by a subclass to provide more permissive
		/// tag identifiers (for example, to parse non-compliant messages).
		/// 
		/// </para>
		/// </summary>
		/// <param name="s"> string to evaluate </param>
		/// <param name="i"> starting position in the string to evaluate </param>
		/// <returns> true if at the given position there is a tag start
		/// @since 7.10.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected boolean tagStarts(final String s, int i)
		protected internal virtual bool tagStarts(string s, int i)
		{
			int length = s.Length;
			/*
			 * at least three characters, where first and second characters must be digits
			 */
			if (i + 2 < length && char.IsDigit(s[i]) && char.IsDigit(s[i + 1]))
			{
				/*
				 * third character must be ':' or letter option (A-Z) immediately followed by another character with ':'
				 */
				char c3 = s[i + 2];
				if (c3 == ':')
				{
					/*
					 * no letter option
					 */
					return true;
				}
				else if (char.IsUpper(c3) && (i + 3) < length && s[i + 3] == ':')
				{
					/*
					 * with letter option
					 */
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Finds the end of a block tag (i.e: "{TAG:VALUE}"). This is used to parse blocks other than 4.<br>
		/// The function search the string looking for the occurrence of the sequence "}". It is important to
		/// note that curly braces are balanced along the search. </summary>
		/// <param name="s"> the FIN input text </param>
		/// <param name="start"> the position to start analysis at </param>
		/// <returns> the position where the tag ends (including the "}") </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private int blockTagEnd(final String s, int start)
		private int blockTagEnd(string s, int start)
		{
			// scan until end or end of string
			int balance = 0;
			char c;
			do
			{
				// analyze this position
				switch ((c = s[start++]))
				{
				case '{':
					balance++;
					break;
				case '}':
					balance--;
					break;
				}
			} while (start < s.Length && (balance >= 0 || (balance == 0 && c != '}')));
			return start;
		}

		/// <summary>
		/// Process the input as a tag. That is: split name and value (and possibly unparsed texts).<br>
		/// The received buffer contains only the pertinent data for the tag (name and value). Trailing
		/// [CR][LF] on the text <b>MUST</b> not be present.
		/// </summary>
		/// <param name="buffer"> the buffer containing the tag </param>
		/// <param name="unparsedText"> the unparsed text to assign (use null if none is wanted).
		/// This single text is fragmented in multiple texts if there are more than one message. </param>
		/// <returns> a swift Tag </returns>
		/// <exception cref="IOException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected Tag consumeTag(final String buffer, final String unparsedText) throws IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		protected internal virtual Tag consumeTag(string buffer, string unparsedText)
		{
			// separate name and value
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int sep = buffer.indexOf(':');
			int sep = buffer.IndexOf(':');
			string name = null;
			string value;
			if (sep != -1)
			{
				name = buffer.Substring(0, sep);
				value = buffer.Substring(sep + 1);
			}
			else
			{
				value = buffer;
			}

			// ignore empty tags (most likely, an "{}" in an unparsed text...)
			if (StringUtils.isEmpty(name) && StringUtils.isEmpty(value))
			{
				return null; // no tag...
			}

			// remove terminating [CR][LF] (or any combination)
			int size = value.Length;
			if (size > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char c = value.charAt(size - 1);
				char c = value[size - 1];
				if (c == '\r' || c == '\n')
				{
					size--;
				}
			}
			if (size > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char c = value.charAt(size - 1);
				char c = value[size - 1];
				if (c == '\r' || c == '\n')
				{
					size--;
				}
			}
			if (size != value.Length)
			{
				value = value.Substring(0, size);
			}

			// build the tag
			//
			// NOTE: if we will use different Tag classes, here is the instantiation point
			//
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = new Tag();
			Tag t = new Tag();
			if (name != null)
			{
				t.Name = name;
				t.Value = value;
			}
			else
			{
				log.severe("Avoiding tag with null name and value " + value);
				throw new System.ArgumentException("Field cannot have a null tag name");
			}

			// if there is unparsed text => process it
			if (unparsedText != null)
			{
				t.UnparsedTexts = processUnparsedText(unparsedText);
			}

			return t;
		}

		/// <summary>
		/// this method receives a string that is a sequence of unparsed text and splits it into
		/// different unparsed texts. The algorithm is to split on message begin (i.e: "{1:" and
		/// balance curly braces). This last thing ensures that a single message with unparsed text
		/// inner messages is treated as one single unparsed text.<br>
		/// That is:<br>
		/// 
		/// <pre>
		/// {1:...}                 -- message block 1
		/// {4:...                  -- message block 4
		///    {1:...}              -- \
		///    {4:...               -- | one single unparsed text
		///        {1:...}          -- | for block 4
		///        {4:...}          -- /
		///    }
		/// }
		/// </pre>
		/// </summary>
		/// <param name="unparsedText"> the unparsed text to split (this parameter cannot be <b>null</b>). </param>
		/// <returns> the list of unparsed texts. This can be <b>null</b> if the input is the empty string. </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private UnparsedTextList processUnparsedText(final String unparsedText)
		private UnparsedTextList processUnparsedText(string unparsedText)
		{
			// prepare to process
			UnparsedTextList list = null;

			// we start a new unparsed text at every "{1:"
			int start = 0;
			while (start < unparsedText.Length)
			{

				// find the block end (balancing braces)
				int end = start + 1;
				while ((end + 1) < unparsedText.Length && !unparsedText.StartsWith("{1:", end))
				{
					end = blockTagEnd(unparsedText, end + 1);

					// include trailing white spaces
					while (end < unparsedText.Length && char.IsWhiteSpace(unparsedText[end]))
					{
						end++;
					}
				}

				// separate a text
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String text = unparsedText.substring(start, end - start).trim();
				string text = unparsedText.Substring(start, end - start).Trim();
				if (!"".Equals(text))
				{

					// add it to the list (create it if needed)
					if (list == null)
					{
						list = new UnparsedTextList();
					}
					list.addText(text);
				}

				// continue with next text
				start = end;
			}

			return list;
		}

		/// <summary>
		/// Identify the block to be consumed.
		/// </summary>
		/// <param name="s"> the block identifier </param>
		/// <returns> the block identifier or a space if the block can not be identified </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected char identifyBlock(final String s)
		protected internal virtual char identifyBlock(string s)
		{
			if (s != null && s.Length > 1)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char c = s.charAt(0);
				char c = s[0];
				if ('0' <= c && c <= '9')
				{
					return c;
				}
				if ('a' <= c && c <= 'z')
				{
					return c;
				}
				if ('A' <= c && c <= 'Z')
				{
					return c;
				}
			}
			return ' ';
		}

		/// <summary>
		/// Reads the buffer until end of block is reached.
		/// The initial character of the block must be already consumed and the
		/// reader has to be ready to consume the first character inside the block
		/// 
		/// <para>This method assumes that the starting block character was consumed
		/// because that is required in order to identify the start of a block, and
		/// call this method which reads until this block ends.
		/// 
		/// </para>
		/// </summary>
		/// <returns> a string with the block contents </returns>
		/// <exception cref="IOException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected String readUntilBlockEnds() throws IOException
		protected internal virtual string readUntilBlockEnds()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int start = buffer==null? 0 : buffer.length();
			int start = buffer == null? 0 : buffer.Length;
			int len = 0;
			int c;

			/*
			 * Best effort reading includes this End Of Block (EOB) logic:
			 * first proper end of block or last block start.
			 */
			bool checkNested = true;

			// starts holds the amount of blockstart chars encountered, when this method
			// is called, the initial block start was consumed, and therefore, this is initialized in 1
			// this is needed to be able to include inner {} inside blocks
			int starts = 1;
			bool done = false;
			int count = 0;
			bool? isTextBlock = null;

			//iterate until proper block end or EOF
			while (!done)
			{
				c = Char;
				// check if we can set the textblock flag first
				if (isTextBlock == null && count++ >=3)
				{
					isTextBlock = TextBlock;
					if (isTextBlock)
					{
						checkNested = false;
					}
				}
				// found EOF?
				if (c == -1)
				{
					// if we have read something and we reach the end of file without a proper closing bracket
					if (len > 0)
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String error = "Missing or invalid closing bracket in block " + buffer.charAt(start);
						string error = "Missing or invalid closing bracket in block " + buffer[start];
						if (configuration.Lenient)
						{
							// if the configuration is lenient we report the error and continue
							this.errors.Add(error);
						}
						else
						{
							// if the configuration is not lenient, we abort the parsing with exception
							throw new System.ArgumentException(error);
						}
					}
					done = true;
				}
				else
				{
					if (checkNested && isBlockStart((char) c))
					{
						starts++;
					}
					if (isBlockEnd(isTextBlock, c))
					{
						if (checkNested)
						{
							starts--;
							if (starts == 0)
							{
								done = true;
							}
							else
							{
								len++;
							}
						}
						else
						{
							done = true;
						}
					}
					else
					{
						len++;
					}
				}
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int end = start + len;
			int end = start + len;

			return buffer.Substring(start, end - start);
		}

		private bool TextBlock
		{
			get
			{
				// hack to report as block4 only text blocks 4 , check data in buffer
				if (this.lastBlockStartOffset >= 0 && buffer.Length > this.lastBlockStartOffset)
				{
					return isTextBlock(buffer.Substring(this.lastBlockStartOffset));
				}
				return false;
			}
		}

		/// <summary>
		/// Determines if the given string is the start of a textblock
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private boolean isTextBlock(final String s)
		private bool isTextBlock(string s)
		{
			// hack to report as block4 only text blocks 4 , check data in buffer
			if (s.Length < 3)
			{
				return false;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int offset;
			int offset;
			if (s[0] == '{')
			{
				offset = 1;
			}
			else
			{
				offset = 0;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char c1 = s.charAt(offset+0);
			char c1 = s[offset + 0];
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char c2 = s.charAt(offset+1);
			char c2 = s[offset + 1];
			if (c1 == '4' && c2 == ':')
			{
				int c = offset + 2;
				char tmp;
				while ((offset + c) < s.Length)
				{
					tmp = s[offset + c];
					c++;
					if (tmp == '{')
					{
						return false;
					}
					else if (tmp == ':')
					{
						return true;
					}
				}
				// Notice: for all 4: default is true since it's more lenient than tagmode
				return true;
			}
			return false;
		}

		/// <returns> true if current char is } or for text block buffer is [LF]-} </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private final boolean isBlockEnd(final Boolean isTextBlock, final int curChar)
		private bool isBlockEnd(bool? isTextBlock, int curChar)
		{
			// check buffer
			if (isBlockEnd((char) curChar))
			{
				if ((isTextBlock != null) && (bool)isTextBlock)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char ult = buffer.charAt(buffer.length()-2);
					char ult = buffer[buffer.Length - 2];
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char antUlt = buffer.charAt(buffer.length()-3);
					char antUlt = buffer[buffer.Length - 3];
					if (antUlt == '\n' && ult == '-')
					{
						return true;
					}
				}
				else
				{
					return true;
				}
			}
			return false;
		}

		/// <returns> true if parameter char is a closing bracket </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static final boolean isBlockEnd(final char c)
		private static bool isBlockEnd(char c)
		{
			return c == '}';
		}

		/// <summary>
		/// read on the reader until a block start character or EOF is reached. </summary>
		/// <exception cref="IOException"> if thrown during read </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: protected String findBlockStart() throws IOException
		protected internal virtual string findBlockStart()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder textUntilBlock = new StringBuilder();
			StringBuilder textUntilBlock = new StringBuilder();
			int c;
			do
			{
				c = Char;
				textUntilBlock.Append((char)c);
			} while (c != -1 && !isBlockStart((char) c));
			if (textUntilBlock.Length > 0)
			{
				// el ultimo char es EOF of {, sea cual sea lo borramos
				textUntilBlock.Remove(textUntilBlock.Length - 1, 1);
			}

			// debug code
			//if (textUntilBlock.length()>0) log.fine("textUntilBlock: "+textUntilBlock.toString());

			return textUntilBlock.Length > 0 ? textUntilBlock.ToString() : StringUtils.EMPTY;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private boolean isBlockStart(final char c)
		private bool isBlockStart(char c)
		{
			if (c == '{')
			{
				lastBlockStartOffset = buffer.Length - 1;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Read a char from stream and append it to the inner buffer </summary>
		/// <returns> the next char read </returns>
		/// <exception cref="IOException"> if an error occurs during read </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private final int getChar() throws IOException
		private int Char
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final int c = reader.read();
				int c = reader.read();
				if (c >= 0)
				{
					buffer.Append((char) c);
				}
				return c;
			}
		}

		/// <summary>
		/// Get a copy of the errors found during the parsing of the message.
		/// <para>You can manipulate this copy without affecting the original list.
		/// 
		/// </para>
		/// </summary>
		/// <returns> a copy of the list of errors found </returns>
		public virtual IList<string> Errors
		{
			get
			{
				return new ArrayList(this.errors);
			}
		}

		/// <summary>
		/// Gets the current parse configuration
		/// @since 7.8 </summary>
		/// <seealso cref= SwiftParserConfiguration </seealso>
		public virtual SwiftParserConfiguration Configuration
		{
			get
			{
				return configuration;
			}
			set
			{
				this.configuration = value;
			}
		}


		/// <summary>
		/// Parses a string containing the text block of an MT message </summary>
		/// <param name="s"> block content starting with "{4:\r\n" and ending with "\r\n-}" </param>
		/// <returns> content parsed into a block 4 or an empty block 4 if string cannot be parsed </returns>
		/// <exception cref="IOException">
		/// @since 7.8.4 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static SwiftBlock4 parseBlock4(String s) throws IOException
		public static SwiftBlock4 parseBlock4(string s)
		{
			SwiftBlock4 b4 = new SwiftBlock4();
			string toParse = s;
			if (toParse.StartsWith("{", StringComparison.Ordinal))
			{
				toParse = toParse.Substring(1);
			}
			if (toParse.EndsWith("}", StringComparison.Ordinal))
			{
				toParse = toParse.Substring(0, toParse.Length - 1);
			}
			SwiftParser parser = new SwiftParser();
			return parser.block4Consume(b4, toParse);
		}

		/// <summary>
		/// Parses a string containing an MT message block 3 content </summary>
		/// <param name="s"> block content starting with "{3:" and ending with "}" </param>
		/// <returns> content parsed into a block 3 or an empty block 3 if string cannot be parsed </returns>
		/// <exception cref="IOException">
		/// @since 7.8.6 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static SwiftBlock3 parseBlock3(String s) throws IOException
		public static SwiftBlock3 parseBlock3(string s)
		{
			SwiftBlock3 b3 = new SwiftBlock3();
			SwiftParser parser = new SwiftParser();
			return (SwiftBlock3) parser.tagListBlockConsume(b3, s);
		}

		/// <summary>
		/// Parses a string containing an MT message block 5 content </summary>
		/// <param name="s"> block content starting with "{5:" and ending with "}" </param>
		/// <returns> content parsed into a block 5 or an empty block 5 if string cannot be parsed </returns>
		/// <exception cref="IOException">
		/// @since 7.8.6 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static SwiftBlock5 parseBlock5(String s) throws IOException
		public static SwiftBlock5 parseBlock5(string s)
		{
			SwiftBlock5 b5 = new SwiftBlock5();
			SwiftParser parser = new SwiftParser();
			return (SwiftBlock5) parser.tagListBlockConsume(b5, s);
		}

		/// <summary>
		/// Parses a string containing an MT message block 1 content </summary>
		/// <param name="s"> block content starting with "{1:" and ending with "}" </param>
		/// <returns> content parsed into a block 1 or an empty block 1 if string cannot be parsed </returns>
		/// <exception cref="IOException">
		/// @since 7.8.6 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static SwiftBlock1 parseBlock1(String s) throws IOException
		public static SwiftBlock1 parseBlock1(string s)
		{
			return new SwiftBlock1(StringUtils.strip(s, "{}"), true);
		}

		/// <summary>
		/// Parses a string containing an MT message block 2 content.
		/// <para>Will return either a <seealso cref="SwiftBlock2Input"/> or <seealso cref="SwiftBlock2Output"/> depending
		/// on the parameter block content.
		/// 
		/// </para>
		/// </summary>
		/// <param name="s"> block content starting with "{2:" and ending with "}" </param>
		/// <returns> content parsed into a block 2 or an empty block 2 if string cannot be parsed </returns>
		/// <exception cref="IOException">
		/// @since 7.8.6 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static SwiftBlock2 parseBlock2(String s) throws IOException
		public static SwiftBlock2 parseBlock2(string s)
		{
			if (isInput(s))
			{
				return new SwiftBlock2Input(StringUtils.strip(s, "{}"), true);
			}
			else
			{
				return new SwiftBlock2Output(StringUtils.strip(s, "{}"), true);
			}
		}

		/// <summary>
		/// Parses a string containing an MT message block 2 input content (outgoing message sent to SWIFT).
		/// <para>If you don't know the container message direction, user <seealso cref="#parseBlock2(String)"/> instead.
		/// 
		/// </para>
		/// </summary>
		/// <param name="s"> block content starting with "{2:I" and ending with "}" </param>
		/// <returns> content parsed into a block 2 or an empty block 2 if string cannot be parsed </returns>
		/// <exception cref="IOException">
		/// @since 7.8.6 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static SwiftBlock2Input parseBlock2Input(String s) throws IOException
		public static SwiftBlock2Input parseBlock2Input(string s)
		{
			return new SwiftBlock2Input(StringUtils.strip(s, "{}"), true);
		}

		/// <summary>
		/// Parses a string containing an MT message block 2 output content (incoming message received from SWIFT).
		/// <para>If you don't know the container message direction, user <seealso cref="#parseBlock2(String)"/> instead.
		/// 
		/// </para>
		/// </summary>
		/// <param name="s"> block content starting with "{2:O" and ending with "}" </param>
		/// <returns> content parsed into a block 2 or an empty block 2 if string cannot be parsed </returns>
		/// <exception cref="IOException">
		/// @since 7.8.6 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static SwiftBlock2Output parseBlock2Output(String s) throws IOException
		public static SwiftBlock2Output parseBlock2Output(string s)
		{
			return new SwiftBlock2Output(StringUtils.strip(s, "{}"), true);
		}

	}

}