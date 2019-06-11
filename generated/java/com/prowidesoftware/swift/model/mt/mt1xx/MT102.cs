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
namespace com.prowidesoftware.swift.model.mt.mt1xx
{




	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using com.prowidesoftware.swift.@internal;
	using Type = com.prowidesoftware.swift.@internal.SequenceStyle.Type;
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 102 - Multiple Customer Credit Transfer</strong>
	/// 
	/// <para>
	/// SWIFT MT102 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="sequence">
	/// Sequence A (M)<ul><li class="field">Field 20  (M)</li>
	/// <li class="field">Field 23  (M)</li>
	/// <li class="field">Field 51 A (O)</li>
	/// <li class="field">Field 50 A,F,K (O)</li>
	/// <li class="field">Field 52 A,B,C (O)</li>
	/// <li class="field">Field 26 T (O)</li>
	/// <li class="field">Field 77 B (O)</li>
	/// <li class="field">Field 71 A (O)</li>
	/// <li class="field">Field 36  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence B (M) (repetitive)<ul><li class="field">Field 21  (M)</li>
	/// <li class="field">Field 32 B (M)</li>
	/// <li class="field">Field 50 A,F,K (O)</li>
	/// <li class="field">Field 52 A,B,C (O)</li>
	/// <li class="field">Field 57 A,C (O)</li>
	/// <li class="field">Field 59 A,F,NONE (M)</li>
	/// <li class="field">Field 70  (O)</li>
	/// <li class="field">Field 26 T (O)</li>
	/// <li class="field">Field 77 B (O)</li>
	/// <li class="field">Field 33 B (O)</li>
	/// <li class="field">Field 71 A (O)</li>
	/// <li class="field">Field 71 F (O) (repetitive)</li>
	/// <li class="field">Field 71 G (O)</li>
	/// <li class="field">Field 36  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence C (M)<ul><li class="field">Field 32 A (M)</li>
	/// <li class="field">Field 19  (O)</li>
	/// <li class="field">Field 71 G (O)</li>
	/// <li class="field">Field 13 C (O) (repetitive)</li>
	/// <li class="field">Field 53 A,C (O)</li>
	/// <li class="field">Field 54 A (O)</li>
	/// <li class="field">Field 72  (O)</li>
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
//ORIGINAL LINE: @Generated public class MT102 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT102 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT102).Name);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "102";

	// begin qualifiers constants	

		/// <summary>
		/// Constant for qualifier with value BEN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BEN = "BEN";
		[Obsolete]
		public const string BEN = "BEN";

		/// <summary>
		/// Constant for qualifier with value OUR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OUR = "OUR";
		[Obsolete]
		public const string OUR = "OUR";

		/// <summary>
		/// Constant for qualifier with value SHA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SHA = "SHA";
		[Obsolete]
		public const string SHA = "SHA";

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT102 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT102 content </param>
		public MT102(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT102 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT102 content, the parameter can not be null </param>
		/// <seealso cref= #MT102(String) </seealso>
		public MT102(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT102 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT102 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT102(String)
		/// @since 7.7 </seealso>
		public static MT102 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT102(m);
		}

		/// <summary>
		/// Creates and initializes a new MT102 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT102() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT102 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT102(final String sender, final String receiver)
		public MT102(string sender, string receiver) : base(102, sender, receiver)
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
		/// <seealso cref= #MT102(String, String) </seealso>
		/// @deprecated Use instead <code>new MT102(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT102(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT102(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT102(sender, receiver)</code> instead")]
		public MT102(int messageType, string sender, string receiver) : base(102, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT102(int, String, String)", "Use the constructor MT102(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT102 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT102(final String fin)
		public MT102(string fin) : base()
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
				log.warning("Creating an MT102 object from FIN content with a Service Message. Check if the MT102 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT102 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT102 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT102 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT102 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT102 parse(final String fin)
		public static MT102 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT102(fin);
		}

		/// <summary>
		/// Creates a new MT102 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT102(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT102(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT102 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT102 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT102 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT102 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT102(stream);
		}

		/// <summary>
		/// Creates a new MT102 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT102(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT102(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT102 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT102 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT102 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT102 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT102(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "102";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT102 append(final SwiftTagListBlock block)
		public override MT102 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT102 append(final Tag... tags)
		public override MT102 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT102 append(final Field... fields)
		public override MT102 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT102 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT102 message </param>
		/// <returns> a new instance of MT102
		/// @since 7.10.3 </returns>
		public static MT102 fromJson(string json)
		{
			return (MT102) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 20, 
		/// or null if none is found.<br>
		/// The first occurrence of field 20 at MT102 is expected to be the only one.
		/// </summary>
		/// <returns> a Field20 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field20 Field20
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("20");
				Tag t = tag("20");
				if (t != null)
				{
					return new Field20(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 23, 
		/// or null if none is found.<br>
		/// The first occurrence of field 23 at MT102 is expected to be the only one.
		/// </summary>
		/// <returns> a Field23 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field23 Field23
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("23");
				Tag t = tag("23");
				if (t != null)
				{
					return new Field23(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 51A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 51A at MT102 is expected to be the only one.
		/// </summary>
		/// <returns> a Field51A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field51A Field51A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("51A");
				Tag t = tag("51A");
				if (t != null)
				{
					return new Field51A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 32A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 32A at MT102 is expected to be the only one.
		/// </summary>
		/// <returns> a Field32A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field32A Field32A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("32A");
				Tag t = tag("32A");
				if (t != null)
				{
					return new Field32A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 19, 
		/// or null if none is found.<br>
		/// The first occurrence of field 19 at MT102 is expected to be the only one.
		/// </summary>
		/// <returns> a Field19 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field19 Field19
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("19");
				Tag t = tag("19");
				if (t != null)
				{
					return new Field19(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 53A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 53A at MT102 is expected to be the only one.
		/// </summary>
		/// <returns> a Field53A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field53A Field53A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("53A");
				Tag t = tag("53A");
				if (t != null)
				{
					return new Field53A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 53C, 
		/// or null if none is found.<br>
		/// The first occurrence of field 53C at MT102 is expected to be the only one.
		/// </summary>
		/// <returns> a Field53C object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field53C Field53C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("53C");
				Tag t = tag("53C");
				if (t != null)
				{
					return new Field53C(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 54A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 54A at MT102 is expected to be the only one.
		/// </summary>
		/// <returns> a Field54A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field54A Field54A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("54A");
				Tag t = tag("54A");
				if (t != null)
				{
					return new Field54A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 72, 
		/// or null if none is found.<br>
		/// The first occurrence of field 72 at MT102 is expected to be the only one.
		/// </summary>
		/// <returns> a Field72 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field72 Field72
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("72");
				Tag t = tag("72");
				if (t != null)
				{
					return new Field72(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 21, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 21 at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field21 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field21> Field21
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field21> result = new java.util.ArrayList<>();
				IList<Field21> result = new List<Field21>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("21");
				Tag[] tags = tags("21");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field21(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 32B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 32B at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field32B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field32B> Field32B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field32B> result = new java.util.ArrayList<>();
				IList<Field32B> result = new List<Field32B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("32B");
				Tag[] tags = tags("32B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field32B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 50A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 50A at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field50A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field50A> Field50A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field50A> result = new java.util.ArrayList<>();
				IList<Field50A> result = new List<Field50A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("50A");
				Tag[] tags = tags("50A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field50A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 50F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 50F at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field50F objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field50F> Field50F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field50F> result = new java.util.ArrayList<>();
				IList<Field50F> result = new List<Field50F>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("50F");
				Tag[] tags = tags("50F");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field50F(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 50K, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 50K at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field50K objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field50K> Field50K
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field50K> result = new java.util.ArrayList<>();
				IList<Field50K> result = new List<Field50K>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("50K");
				Tag[] tags = tags("50K");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field50K(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 52A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 52A at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field52A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field52A> Field52A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field52A> result = new java.util.ArrayList<>();
				IList<Field52A> result = new List<Field52A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("52A");
				Tag[] tags = tags("52A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field52A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 52B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 52B at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field52B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field52B> Field52B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field52B> result = new java.util.ArrayList<>();
				IList<Field52B> result = new List<Field52B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("52B");
				Tag[] tags = tags("52B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field52B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 52C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 52C at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field52C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field52C> Field52C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field52C> result = new java.util.ArrayList<>();
				IList<Field52C> result = new List<Field52C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("52C");
				Tag[] tags = tags("52C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field52C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 57A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 57A at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field57A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field57A> Field57A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field57A> result = new java.util.ArrayList<>();
				IList<Field57A> result = new List<Field57A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("57A");
				Tag[] tags = tags("57A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field57A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 57C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 57C at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field57C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field57C> Field57C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field57C> result = new java.util.ArrayList<>();
				IList<Field57C> result = new List<Field57C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("57C");
				Tag[] tags = tags("57C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field57C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 59A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 59A at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field59A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field59A> Field59A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field59A> result = new java.util.ArrayList<>();
				IList<Field59A> result = new List<Field59A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("59A");
				Tag[] tags = tags("59A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field59A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 59F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 59F at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field59F objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field59F> Field59F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field59F> result = new java.util.ArrayList<>();
				IList<Field59F> result = new List<Field59F>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("59F");
				Tag[] tags = tags("59F");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field59F(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 59, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 59 at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field59 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field59> Field59
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field59> result = new java.util.ArrayList<>();
				IList<Field59> result = new List<Field59>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("59");
				Tag[] tags = tags("59");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field59(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 70, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 70 at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field70 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field70> Field70
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field70> result = new java.util.ArrayList<>();
				IList<Field70> result = new List<Field70>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("70");
				Tag[] tags = tags("70");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field70(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 26T, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 26T at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field26T objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field26T> Field26T
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field26T> result = new java.util.ArrayList<>();
				IList<Field26T> result = new List<Field26T>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("26T");
				Tag[] tags = tags("26T");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field26T(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 77B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 77B at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field77B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field77B> Field77B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field77B> result = new java.util.ArrayList<>();
				IList<Field77B> result = new List<Field77B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("77B");
				Tag[] tags = tags("77B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field77B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 33B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 33B at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field33B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field33B> Field33B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field33B> result = new java.util.ArrayList<>();
				IList<Field33B> result = new List<Field33B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("33B");
				Tag[] tags = tags("33B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field33B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 71A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 71A at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field71A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field71A> Field71A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field71A> result = new java.util.ArrayList<>();
				IList<Field71A> result = new List<Field71A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("71A");
				Tag[] tags = tags("71A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field71A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 71F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 71F at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field71F objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field71F> Field71F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field71F> result = new java.util.ArrayList<>();
				IList<Field71F> result = new List<Field71F>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("71F");
				Tag[] tags = tags("71F");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field71F(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 71G, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 71G at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field71G objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field71G> Field71G
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field71G> result = new java.util.ArrayList<>();
				IList<Field71G> result = new List<Field71G>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("71G");
				Tag[] tags = tags("71G");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field71G(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 36, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 36 at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field36 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field36> Field36
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field36> result = new java.util.ArrayList<>();
				IList<Field36> result = new List<Field36>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("36");
				Tag[] tags = tags("36");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field36(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 13C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 13C at MT102 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field13C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field13C> Field13C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field13C> result = new java.util.ArrayList<>();
				IList<Field13C> result = new List<Field13C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("13C");
				Tag[] tags = tags("13C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field13C(tag.Value));
					}
				}
				return result;
			}
		}


	// BaseSequenceCodeGenerator [seq=A]
		/// <summary>
		/// Class to model Sequence "A" in MT 102
		/// </summary>
		public class SequenceA : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceA() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceA(final SwiftTagListBlock content)
			internal SequenceA(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// First mandatory tag name of the sequence: <em>"20"  </em>.
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			public static readonly string[] START = new string[] {"20"};

			/// <summary>
			/// Last mandatory tag name of the sequence: <em>"23"  </em>
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			protected internal static readonly string[] END = new string[] {"23"};

			/// <summary>
			/// List of optional tags after the last mandatory tag
			/// </summary>
			protected internal static readonly string[] TAIL = new string[]{"51A", "50A", "50F", "50K", "52A", "52B", "52C", "26T", "77B", "71A", "36"};

			/// <summary>
			/// Same as <seealso cref="#newInstance(int, int, Tag...)"/> using zero for the indexes </summary>
			/// <param name="tags"> the list of tags to set as sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public static SequenceA newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceA newInstance(params Tag[] tags)
			{
				return newInstance(0, 0, tags);
			}

			/// <summary>
			/// Creates a sequence with starting and ending tags set to the indicated tags in from the
			/// <seealso cref="#START"/> and <seealso cref="#END"/> lists of mandatory fields, and with the content between
			/// the starting and ending tag initialized with the given optional tags.
			/// </summary>
			/// <param name="start"> a zero-based index within the list of mandatory starting tags in the sequence </param>
			/// <param name="end"> a zero-based index within the list of mandatory ending tags in the sequence </param>
			/// <param name="tags"> the list of tags to set as sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public static SequenceA newInstance(final int start, final int end, final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceA newInstance(int start, int end, params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA result = new SequenceA();
				SequenceA result = new SequenceA();
				result.append(new Tag(START[start], ""));
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				result.append(new Tag(END[end], ""));
				return result;
			}
		}
		 /// <summary>
		 /// Get the single occurrence of SequenceA delimited by leading tag and end, with an optional tail.
		 /// The presence of this method indicates that this sequence can occur only once according to the Standard.
		 /// If block 4 is empty this method returns null.
		 /// </summary>
		 /// <returns> the found sequence or an empty sequence if none is found </returns>
		 /// <seealso cref= SwiftTagListBlock#getSubBlockDelimitedWithOptionalTail(String[], String[], String[]) </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public SequenceA getSequenceA()
		public virtual SequenceA SequenceA
		{
			get
			{
				return getSequenceA(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceA delimited by leading tag and end, with an optional tail.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// If block 4 is empty this method returns null.
		/// </summary>
		/// <seealso cref= SwiftTagListBlock#getSubBlockDelimitedWithOptionalTail(String[], String[], String[]) </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceA within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public SequenceA getSequenceA(SwiftTagListBlock parentSequence)
		public virtual SequenceA getSequenceA(SwiftTagListBlock parentSequence)
		{
			if (parentSequence != null && !parentSequence.Empty)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock content = parentSequence.getSubBlockDelimitedWithOptionalTail(SequenceA.START, SequenceA.END, SequenceA.TAIL);
				SwiftTagListBlock content = parentSequence.getSubBlockDelimitedWithOptionalTail(SequenceA.START, SequenceA.END, SequenceA.TAIL);
				if (log.isLoggable(java.util.logging.Level.FINE))
				{
					if (content == null)
					{
						log.fine("content for sequence SequenceA: is null");
					}
					else
					{
						log.fine("content for sequence SequenceA: " + content.tagNamesList());
					}
				}
				if (content == null)
				{
					return new SequenceA();
				}
				else
				{
					return new SequenceA(content);
				}
			}
			return null;
		}


	// BaseSequenceCodeGenerator [seq=B]
		/// <summary>
		/// Class to model Sequence "B" in MT 102
		/// </summary>
		public class SequenceB : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceB() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceB(final SwiftTagListBlock content)
			internal SequenceB(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// First mandatory tag name of the sequence: <em>"21"  </em>.
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			public static readonly string[] START = new string[] {"21"};

			/// <summary>
			/// Last mandatory tag name of the sequence: <em>"59A", "59F", "59"  </em>
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			protected internal static readonly string[] END = new string[] {"59A", "59F", "59"};

			/// <summary>
			/// List of optional tags after the last mandatory tag
			/// </summary>
			protected internal static readonly string[] TAIL = new string[]{"70", "26T", "77B", "33B", "71A", "71F", "71G", "36"};

			/// <summary>
			/// Same as <seealso cref="#newInstance(int, int, Tag...)"/> using zero for the indexes </summary>
			/// <param name="tags"> the list of tags to set as sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public static SequenceB newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceB newInstance(params Tag[] tags)
			{
				return newInstance(0, 0, tags);
			}

			/// <summary>
			/// Creates a sequence with starting and ending tags set to the indicated tags in from the
			/// <seealso cref="#START"/> and <seealso cref="#END"/> lists of mandatory fields, and with the content between
			/// the starting and ending tag initialized with the given optional tags.
			/// </summary>
			/// <param name="start"> a zero-based index within the list of mandatory starting tags in the sequence </param>
			/// <param name="end"> a zero-based index within the list of mandatory ending tags in the sequence </param>
			/// <param name="tags"> the list of tags to set as sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public static SequenceB newInstance(final int start, final int end, final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceB newInstance(int start, int end, params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB result = new SequenceB();
				SequenceB result = new SequenceB();
				result.append(new Tag(START[start], ""));
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				result.append(new Tag(END[end], ""));
				return result;
			}
		}
		/// <summary>
		/// Get the list of SequenceB delimited by leading tag and end, with an optional tail.
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard.
		/// If message is empty or no sequences are found <em>an empty list</em> is returned.
		/// </summary>
		/// <seealso cref= SwiftTagListBlock#getSubBlocksDelimitedWithOptionalTail(String[], String[], String[]) </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceB within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public static java.util.List<SequenceB> getSequenceBList(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceB> getSequenceBList(SwiftTagListBlock parentSequence)
		{
			if (parentSequence != null && !parentSequence.Empty)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceB> result = new java.util.ArrayList<>();
				IList<SequenceB> result = new List<SequenceB>();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> bs = parentSequence.getSubBlocksDelimitedWithOptionalTail(SequenceB.START, SequenceB.END, SequenceB.TAIL);
				IList<SwiftTagListBlock> bs = parentSequence.getSubBlocksDelimitedWithOptionalTail(SequenceB.START, SequenceB.END, SequenceB.TAIL);
				if (bs != null && bs.Count > 0)
				{
					foreach (SwiftTagListBlock s in bs)
					{
						result.Add(new SequenceB(s));
					}
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();
		}

		/// <summary>
		/// Get the list of SequenceB delimited by leading tag and end, with an optional tail.
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard.
		/// If message is empty or no sequences are found <em>an empty list</em> is returned.
		/// </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SwiftTagListBlock#getSubBlocksDelimitedWithOptionalTail(String[], String[], String[]) </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public java.util.List<SequenceB> getSequenceBList()
		public virtual IList<SequenceB> SequenceBList
		{
			get
			{
				return getSequenceBList(base.SwiftMessageNotNullOrException.Block4);
			}
		}


	// SliceHeurisitcCodeGenerator [tagnames=[32A], type=END_OF_MESSAGE, delimiterIncludedInSequence=true ]
		/// <summary>
		/// Class to model Sequence "C" in MT 102
		/// </summary>
		public class SequenceC : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceC() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceC(final SwiftTagListBlock content)
			internal SequenceC(SwiftTagListBlock content) : base(content.getTags())
			{
			}


		}
		/// <summary>
		/// Get the single occurrence of SequenceC slicing head or tail of the tags with delimiter ${s.getTagNames().get(0)}
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// <em>NOTE: if the tag delimiter is not found this method returns null.</em>
		/// </summary>
		/// <returns> the found sequence, an empty sequence if none is found, or null if the delimiter is not found </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_SLICE) public SequenceC getSequenceC()
		public virtual SequenceC SequenceC
		{
			get
			{
				return getSequenceC(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceC slicing head or tail of the tags with delimiter ${s.getTagNames().get(0)}
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// <em>NOTE: if the tag delimiter is not found this method returns null.</em>
		/// </summary>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceC within the complete message </param>
		/// <returns> the found sequence, an empty sequence if none is found, or null if the delimiter is not found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_SLICE) public SequenceC getSequenceC(SwiftTagListBlock parentSequence)
		public virtual SequenceC getSequenceC(SwiftTagListBlock parentSequence) // SliceHeurisitcCodeGenerator [tagnames=[32A], type=END_OF_MESSAGE, delimiterIncludedInSequence=true ]
		{
			if (parentSequence != null && !parentSequence.Empty)
			{
				// sequence is tail of message
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock content = parentSequence.getSubBlockAfterLast("32A", true);
				SwiftTagListBlock content = parentSequence.getSubBlockAfterLast("32A", true);
				if (content == null)
				{
					return null;
				}
				return new SequenceC(content);
			}
			return null;
		}




	}

}