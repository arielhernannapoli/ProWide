﻿using System;

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
	/// <strong>MT 068 - Undelivered Report Rules</strong>
	/// 
	/// <para>
	/// SWIFT MT068 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="field">Field 302  (M)</li>
	/// <li class="field">Field 341  (M)</li>
	/// <li class="field">Field 301  (O)</li>
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
//ORIGINAL LINE: @Generated public class MT068 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT068 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT068).FullName);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "068";

	// begin qualifiers constants	

		/// <summary>
		/// Constant for qualifier with value N 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String N = "N";
		[Obsolete]
		public const string N = "N";

		/// <summary>
		/// Constant for qualifier with value Y 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String Y = "Y";
		[Obsolete]
		public const string Y = "Y";

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT068 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT068 content </param>
		public MT068(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT068 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT068 content, the parameter can not be null </param>
		/// <seealso cref= #MT068(String) </seealso>
		public MT068(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT068 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT068 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT068(String)
		/// @since 7.7 </seealso>
		public static MT068 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT068(m);
		}

		/// <summary>
		/// Creates and initializes a new MT068 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT068() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT068 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT068(final String sender, final String receiver)
		public MT068(string sender, string receiver) : base(68, sender, receiver)
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
		/// <seealso cref= #MT068(String, String) </seealso>
		/// @deprecated Use instead <code>new MT068(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT068(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT068(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT068(sender, receiver)</code> instead")]
		public MT068(int messageType, string sender, string receiver) : base(68, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT068(int, String, String)", "Use the constructor MT068(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT068 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT068(final String fin)
		public MT068(string fin) : base()
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
				log.warning("Creating an MT068 object from FIN content with a Service Message. Check if the MT068 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT068 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT068 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT068 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT068 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT068 parse(final String fin)
		public static MT068 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT068(fin);
		}

		/// <summary>
		/// Creates a new MT068 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT068(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT068(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT068 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT068 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT068 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT068 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT068(stream);
		}

		/// <summary>
		/// Creates a new MT068 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT068(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT068(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT068 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT068 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT068 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT068 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT068(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "068";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT068 append(final SwiftTagListBlock block)
		public override MT068 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT068 append(final Tag... tags)
		public override MT068 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT068 append(final Field... fields)
		public override MT068 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT068 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT068 message </param>
		/// <returns> a new instance of MT068
		/// @since 7.10.3 </returns>
		public static MT068 fromJson(string json)
		{
			return (MT068) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 302, 
		/// or null if none is found.<br>
		/// The first occurrence of field 302 at MT068 is expected to be the only one.
		/// </summary>
		/// <returns> a Field302 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field302 Field302
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("302");
				Tag t = tag("302");
				if (t != null)
				{
					return new Field302(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 341, 
		/// or null if none is found.<br>
		/// The first occurrence of field 341 at MT068 is expected to be the only one.
		/// </summary>
		/// <returns> a Field341 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field341 Field341
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("341");
				Tag t = tag("341");
				if (t != null)
				{
					return new Field341(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 301, 
		/// or null if none is found.<br>
		/// The first occurrence of field 301 at MT068 is expected to be the only one.
		/// </summary>
		/// <returns> a Field301 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field301 Field301
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("301");
				Tag t = tag("301");
				if (t != null)
				{
					return new Field301(t.Value);
				}
				else
				{
					return null;
				}
			}
		}




	}

}