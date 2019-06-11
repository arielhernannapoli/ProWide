﻿using System;
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
namespace com.prowidesoftware.swift.model.mt.mt4xx
{




	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 422 - Advice of Fate and Request for Instructions</strong>
	/// 
	/// <para>
	/// SWIFT MT422 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="sequence">
	/// Sequence _A (M) (repetitive)<ul><li class="field">Field 20  (M)</li>
	/// <li class="field">Field 21  (M)</li>
	/// <li class="field">Field 32 A,B,K (O)</li>
	/// </ul></li>
	/// <li class="field">Field 72  (O)</li>
	/// <li class="field">Field 75  (O)</li>
	/// <li class="field">Field 76  (O)</li>
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
//ORIGINAL LINE: @Generated public class MT422 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT422 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT422).FullName);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "422";

	// begin qualifiers constants	

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT422 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT422 content </param>
		public MT422(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT422 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT422 content, the parameter can not be null </param>
		/// <seealso cref= #MT422(String) </seealso>
		public MT422(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT422 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT422 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT422(String)
		/// @since 7.7 </seealso>
		public static MT422 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT422(m);
		}

		/// <summary>
		/// Creates and initializes a new MT422 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT422() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT422 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT422(final String sender, final String receiver)
		public MT422(string sender, string receiver) : base(422, sender, receiver)
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
		/// <seealso cref= #MT422(String, String) </seealso>
		/// @deprecated Use instead <code>new MT422(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT422(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT422(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT422(sender, receiver)</code> instead")]
		public MT422(int messageType, string sender, string receiver) : base(422, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT422(int, String, String)", "Use the constructor MT422(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT422 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT422(final String fin)
		public MT422(string fin) : base()
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
				log.warning("Creating an MT422 object from FIN content with a Service Message. Check if the MT422 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT422 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT422 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT422 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT422 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT422 parse(final String fin)
		public static MT422 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT422(fin);
		}

		/// <summary>
		/// Creates a new MT422 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT422(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT422(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT422 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT422 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT422 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT422 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT422(stream);
		}

		/// <summary>
		/// Creates a new MT422 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT422(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT422(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT422 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT422 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT422 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT422 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT422(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "422";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT422 append(final SwiftTagListBlock block)
		public override MT422 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT422 append(final Tag... tags)
		public override MT422 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT422 append(final Field... fields)
		public override MT422 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT422 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT422 message </param>
		/// <returns> a new instance of MT422
		/// @since 7.10.3 </returns>
		public static MT422 fromJson(string json)
		{
			return (MT422) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 72, 
		/// or null if none is found.<br>
		/// The first occurrence of field 72 at MT422 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 75, 
		/// or null if none is found.<br>
		/// The first occurrence of field 75 at MT422 is expected to be the only one.
		/// </summary>
		/// <returns> a Field75 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field75 Field75
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("75");
				Tag t = tag("75");
				if (t != null)
				{
					return new Field75(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 76, 
		/// or null if none is found.<br>
		/// The first occurrence of field 76 at MT422 is expected to be the only one.
		/// </summary>
		/// <returns> a Field76 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field76 Field76
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("76");
				Tag t = tag("76");
				if (t != null)
				{
					return new Field76(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 20, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 20 at MT422 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field20 objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field20> Field20
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field20> result = new java.util.ArrayList<>();
				IList<Field20> result = new List<Field20>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("20");
				Tag[] tags = tags("20");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field20(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 21, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 21 at MT422 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 32A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 32A at MT422 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field32A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field32A> Field32A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field32A> result = new java.util.ArrayList<>();
				IList<Field32A> result = new List<Field32A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("32A");
				Tag[] tags = tags("32A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field32A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 32B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 32B at MT422 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 32K, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 32K at MT422 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field32K objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field32K> Field32K
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field32K> result = new java.util.ArrayList<>();
				IList<Field32K> result = new List<Field32K>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("32K");
				Tag[] tags = tags("32K");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field32K(tag.Value));
					}
				}
				return result;
			}
		}




	}

}