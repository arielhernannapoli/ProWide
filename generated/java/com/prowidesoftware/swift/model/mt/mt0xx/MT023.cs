using System;
using System.Collections.Generic;

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
namespace com.prowidesoftware.swift.model.mt.mt0xx
{




	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 023 - Retrieved Message (History)</strong>
	/// 
	/// <para>
	/// SWIFT MT023 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="field">Field 202  (M)</li>
	/// <li class="field">Field 203  (M)</li>
	/// <li class="field">Field 280  (M) (repetitive)</li>
	/// <li class="field">Field 108  (O) (repetitive)</li>
	/// <li class="field">Field 431  (O) (repetitive)</li>
	/// <li class="field">Field 281  (O) (repetitive)</li>
	/// <li class="sequence">
	/// Sequence _A - Next Retrieval Criteria (M)<ul><li class="sequence">
	/// Sequence _A1 - MIR range (O)<ul><li class="field">Field 252  (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _A2 - MOR range (O)<ul><li class="field">Field 254  (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _A3 - Message input type (O)<ul><li class="field">Field 255  (M)</li>
	/// <li class="field">Field 152  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _A4 - Category input type (O)<ul><li class="field">Field 256  (M)</li>
	/// <li class="field">Field 152  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _A5 - Input time range (O)<ul><li class="field">Field 257  (M)</li>
	/// <li class="field">Field 152  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _A6 - Message output type (O)<ul><li class="field">Field 258  (M)</li>
	/// <li class="field">Field 153  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _A7 - Category output type (O)<ul><li class="field">Field 259  (M)</li>
	/// <li class="field">Field 153  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _A8 - Output time range (O)<ul><li class="field">Field 260  (M)</li>
	/// <li class="field">Field 153  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _A9 - Retrieval error code (O)<ul><li class="field">Field 421  (M)</li>
	/// <li class="field">Field 152  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _A10 - Retrieval error code (O)<ul><li class="field">Field 421  (M)</li>
	/// <li class="field">Field 153  (O)</li>
	/// </ul></li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence _B (O)<ul><li class="field">Field 202  (M)</li>
	/// <li class="field">Field 203  (M)</li>
	/// <li class="field">Field 421  (M)</li>
	/// </ul></li>
	/// </ul></div>
	/// 
	/// 
	/// </para>
	/// <para>
	/// This source code is specific to release <strong>SRU 2018</strong>
	/// </para>
	/// <para>
	/// For additional resources check <a href="https://www.prowidesoftware.com/resources">https://www.prowidesoftware.com/resources</a>
	/// </para>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Generated public class MT023 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT023 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT023).FullName);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "023";

	// begin qualifiers constants	

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT023 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT023 content </param>
		public MT023(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT023 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT023 content, the parameter can not be null </param>
		/// <seealso cref= #MT023(String) </seealso>
		public MT023(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT023 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT023 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT023(String)
		/// @since 7.7 </seealso>
		public static MT023 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT023(m);
		}

		/// <summary>
		/// Creates and initializes a new MT023 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT023() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT023 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT023(final String sender, final String receiver)
		public MT023(string sender, string receiver) : base(23, sender, receiver)
		{
		}

		/// <summary>
		/// <em>DO NOT USE THIS METHOD</em>
		/// It is kept for compatibility but will be removed very soon, since the
		/// <code>messageType</code> parameter is actually ignored.
		/// </summary>
		/// <param name="messageType"> the message type number </param>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <seealso cref= #MT023(String, String) </seealso>
		/// @deprecated Use instead <code>new MT023(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT023(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT023(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT023(sender, receiver)</code> instead")]
		public MT023(int messageType, string sender, string receiver) : base(23, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT023(int, String, String)", "Use the constructor MT023(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT023 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT023(final String fin)
		public MT023(string fin) : base()
		{
			if (fin != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftMessage parsed = read(fin);
				SwiftMessage parsed = read(fin);
				if (parsed != null)
				{
					base.m = parsed;
					sanityCheck(parsed);
				}
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void sanityCheck(final SwiftMessage param)
		private void sanityCheck(SwiftMessage param)
		{
			if (param.ServiceMessage)
			{
				log.warning("Creating an MT023 object from FIN content with a Service Message. Check if the MT023 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT023 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT023 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT023 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT023 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT023 parse(final String fin)
		public static MT023 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT023(fin);
		}

		/// <summary>
		/// Creates a new MT023 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT023(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT023(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT023 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT023 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT023 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT023 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT023(stream);
		}

		/// <summary>
		/// Creates a new MT023 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT023(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT023(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT023 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT023 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT023 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT023 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT023(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "023";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT023 append(final SwiftTagListBlock block)
		public override MT023 append(SwiftTagListBlock block)
		{
			base.append(block);
			return this;
		}

		/// <summary>
		/// Add all tags to the end of the block4.
		/// </summary>
		/// <param name="tags"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT023 append(final Tag... tags)
		public override MT023 append(params Tag[] tags)
		{
			base.append(tags);
			return this;
		}

		/// <summary>
		/// Add all the fields to the end of the block4.
		/// </summary>
		/// <param name="fields"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT023 append(final Field... fields)
		public override MT023 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT023 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT023 message </param>
		/// <returns> a new instance of MT023
		/// @since 7.10.3 </returns>
		public static MT023 fromJson(string json)
		{
			return (MT023) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 252, 
		/// or null if none is found.<br>
		/// The first occurrence of field 252 at MT023 is expected to be the only one.
		/// </summary>
		/// <returns> a Field252 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field252 Field252
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("252");
				Tag t = tag("252");
				if (t != null)
				{
					return new Field252(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 254, 
		/// or null if none is found.<br>
		/// The first occurrence of field 254 at MT023 is expected to be the only one.
		/// </summary>
		/// <returns> a Field254 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field254 Field254
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("254");
				Tag t = tag("254");
				if (t != null)
				{
					return new Field254(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 255, 
		/// or null if none is found.<br>
		/// The first occurrence of field 255 at MT023 is expected to be the only one.
		/// </summary>
		/// <returns> a Field255 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field255 Field255
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("255");
				Tag t = tag("255");
				if (t != null)
				{
					return new Field255(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 256, 
		/// or null if none is found.<br>
		/// The first occurrence of field 256 at MT023 is expected to be the only one.
		/// </summary>
		/// <returns> a Field256 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field256 Field256
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("256");
				Tag t = tag("256");
				if (t != null)
				{
					return new Field256(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 257, 
		/// or null if none is found.<br>
		/// The first occurrence of field 257 at MT023 is expected to be the only one.
		/// </summary>
		/// <returns> a Field257 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field257 Field257
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("257");
				Tag t = tag("257");
				if (t != null)
				{
					return new Field257(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 258, 
		/// or null if none is found.<br>
		/// The first occurrence of field 258 at MT023 is expected to be the only one.
		/// </summary>
		/// <returns> a Field258 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field258 Field258
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("258");
				Tag t = tag("258");
				if (t != null)
				{
					return new Field258(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 259, 
		/// or null if none is found.<br>
		/// The first occurrence of field 259 at MT023 is expected to be the only one.
		/// </summary>
		/// <returns> a Field259 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field259 Field259
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("259");
				Tag t = tag("259");
				if (t != null)
				{
					return new Field259(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 260, 
		/// or null if none is found.<br>
		/// The first occurrence of field 260 at MT023 is expected to be the only one.
		/// </summary>
		/// <returns> a Field260 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field260 Field260
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("260");
				Tag t = tag("260");
				if (t != null)
				{
					return new Field260(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 280, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 280 at MT023 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field280 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field280> Field280
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field280> result = new java.util.ArrayList<>();
				IList<Field280> result = new List<Field280>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("280");
				Tag[] tags = tags("280");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field280(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 108, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 108 at MT023 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field108 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field108> Field108
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field108> result = new java.util.ArrayList<>();
				IList<Field108> result = new List<Field108>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("108");
				Tag[] tags = tags("108");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field108(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 431, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 431 at MT023 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field431 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field431> Field431
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field431> result = new java.util.ArrayList<>();
				IList<Field431> result = new List<Field431>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("431");
				Tag[] tags = tags("431");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field431(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 281, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 281 at MT023 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field281 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field281> Field281
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field281> result = new java.util.ArrayList<>();
				IList<Field281> result = new List<Field281>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("281");
				Tag[] tags = tags("281");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field281(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 152, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 152 at MT023 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field152 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field152> Field152
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field152> result = new java.util.ArrayList<>();
				IList<Field152> result = new List<Field152>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("152");
				Tag[] tags = tags("152");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field152(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 153, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 153 at MT023 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field153 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field153> Field153
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field153> result = new java.util.ArrayList<>();
				IList<Field153> result = new List<Field153>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("153");
				Tag[] tags = tags("153");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field153(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 421, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 421 at MT023 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field421 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field421> Field421
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field421> result = new java.util.ArrayList<>();
				IList<Field421> result = new List<Field421>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("421");
				Tag[] tags = tags("421");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field421(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 202, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 202 at MT023 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field202 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field202> Field202
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field202> result = new java.util.ArrayList<>();
				IList<Field202> result = new List<Field202>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("202");
				Tag[] tags = tags("202");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field202(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 203, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 203 at MT023 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field203 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field203> Field203
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field203> result = new java.util.ArrayList<>();
				IList<Field203> result = new List<Field203>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("203");
				Tag[] tags = tags("203");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field203(tag.Value));
					}
				}
				return result;
			}
		}




	}

}