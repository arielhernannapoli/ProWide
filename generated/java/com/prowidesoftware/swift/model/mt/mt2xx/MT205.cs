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
namespace com.prowidesoftware.swift.model.mt.mt2xx
{




	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 205 - Financial Institution Transfer Execution</strong>
	/// 
	/// <para>
	/// SWIFT MT205 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="field">Field 20  (M)</li>
	/// <li class="field">Field 21  (M)</li>
	/// <li class="field">Field 13 C (O) (repetitive)</li>
	/// <li class="field">Field 32 A (M)</li>
	/// <li class="field">Field 52 A,D (M)</li>
	/// <li class="field">Field 53 A,B,D (O)</li>
	/// <li class="field">Field 56 A,D (O)</li>
	/// <li class="field">Field 57 A,B,D (O)</li>
	/// <li class="field">Field 58 A,D (M)</li>
	/// <li class="field">Field 72  (O)</li>
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
//ORIGINAL LINE: @Generated public class MT205 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT205 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT205).FullName);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "205";

	// begin qualifiers constants	

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT205 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT205 content </param>
		public MT205(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT205 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT205 content, the parameter can not be null </param>
		/// <seealso cref= #MT205(String) </seealso>
		public MT205(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT205 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT205 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT205(String)
		/// @since 7.7 </seealso>
		public static MT205 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT205(m);
		}

		/// <summary>
		/// Creates and initializes a new MT205 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT205() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT205 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT205(final String sender, final String receiver)
		public MT205(string sender, string receiver) : base(205, sender, receiver)
		{
			// initialize the SWIFT gpi service unique end to end transaction reference
			m.setUETR();
		}

		/// <summary>
		/// <em>DO NOT USE THIS METHOD</em>
		/// It is kept for compatibility but will be removed very soon, since the
		/// <code>messageType</code> parameter is actually ignored.
		/// </summary>
		/// <param name="messageType"> the message type number </param>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <seealso cref= #MT205(String, String) </seealso>
		/// @deprecated Use instead <code>new MT205(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT205(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT205(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT205(sender, receiver)</code> instead")]
		public MT205(int messageType, string sender, string receiver) : base(205, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT205(int, String, String)", "Use the constructor MT205(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT205 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT205(final String fin)
		public MT205(string fin) : base()
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
				log.warning("Creating an MT205 object from FIN content with a Service Message. Check if the MT205 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT205 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT205 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT205 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT205 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT205 parse(final String fin)
		public static MT205 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT205(fin);
		}

		/// <summary>
		/// Creates a new MT205 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT205(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT205(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT205 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT205 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT205 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT205 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT205(stream);
		}

		/// <summary>
		/// Creates a new MT205 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT205(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT205(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT205 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT205 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT205 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT205 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT205(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "205";
			}
		}

		/// <summary>
		/// Gets the Unique End to End Transaction Reference (field 121 from block 3).
		/// <para>
		/// This field is used by the SWIFT gpi service to track payments messages.
		/// 
		/// </para>
		/// </summary>
		/// <returns> the UETR value or null if block3 or field 121 in block3 are not present
		/// @since 7.10.0 </returns>
		public virtual string UETR
		{
			get
			{
				if (this.SwiftMessage == null)
				{
					return null;
				}
				else
				{
					return this.SwiftMessage.UETR;
				}
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT205 append(final SwiftTagListBlock block)
		public override MT205 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT205 append(final Tag... tags)
		public override MT205 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT205 append(final Field... fields)
		public override MT205 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT205 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT205 message </param>
		/// <returns> a new instance of MT205
		/// @since 7.10.3 </returns>
		public static MT205 fromJson(string json)
		{
			return (MT205) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 20, 
		/// or null if none is found.<br>
		/// The first occurrence of field 20 at MT205 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 21, 
		/// or null if none is found.<br>
		/// The first occurrence of field 21 at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field21 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field21 Field21
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("21");
				Tag t = tag("21");
				if (t != null)
				{
					return new Field21(t.Value);
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
		/// The first occurrence of field 32A at MT205 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 52A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 52A at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field52A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field52A Field52A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("52A");
				Tag t = tag("52A");
				if (t != null)
				{
					return new Field52A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 52D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 52D at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field52D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field52D Field52D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("52D");
				Tag t = tag("52D");
				if (t != null)
				{
					return new Field52D(t.Value);
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
		/// The first occurrence of field 53A at MT205 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 53B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 53B at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field53B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field53B Field53B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("53B");
				Tag t = tag("53B");
				if (t != null)
				{
					return new Field53B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 53D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 53D at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field53D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field53D Field53D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("53D");
				Tag t = tag("53D");
				if (t != null)
				{
					return new Field53D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 56A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 56A at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field56A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field56A Field56A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("56A");
				Tag t = tag("56A");
				if (t != null)
				{
					return new Field56A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 56D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 56D at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field56D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field56D Field56D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("56D");
				Tag t = tag("56D");
				if (t != null)
				{
					return new Field56D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 57A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 57A at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field57A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field57A Field57A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("57A");
				Tag t = tag("57A");
				if (t != null)
				{
					return new Field57A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 57B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 57B at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field57B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field57B Field57B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("57B");
				Tag t = tag("57B");
				if (t != null)
				{
					return new Field57B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 57D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 57D at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field57D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field57D Field57D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("57D");
				Tag t = tag("57D");
				if (t != null)
				{
					return new Field57D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 58A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 58A at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field58A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field58A Field58A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("58A");
				Tag t = tag("58A");
				if (t != null)
				{
					return new Field58A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 58D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 58D at MT205 is expected to be the only one.
		/// </summary>
		/// <returns> a Field58D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field58D Field58D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("58D");
				Tag t = tag("58D");
				if (t != null)
				{
					return new Field58D(t.Value);
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
		/// The first occurrence of field 72 at MT205 is expected to be the only one.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 13C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 13C at MT205 are expected at one sequence or across several sequences.
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




	}

}