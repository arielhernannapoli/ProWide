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
namespace com.prowidesoftware.swift.model.mt.mt3xx
{




	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using com.prowidesoftware.swift.@internal;
	using Type = com.prowidesoftware.swift.@internal.SequenceStyle.Type;
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 350 - Advice of Loan/Deposit Interest Payment</strong>
	/// 
	/// <para>
	/// SWIFT MT350 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="sequence">
	/// Sequence A (M)<ul><li class="field">Field 15 A (M)</li>
	/// <li class="field">Field 20  (M)</li>
	/// <li class="field">Field 21  (O)</li>
	/// <li class="field">Field 22 A (M)</li>
	/// <li class="field">Field 94 A (O)</li>
	/// <li class="field">Field 22 C (M)</li>
	/// <li class="field">Field 21 N (O)</li>
	/// <li class="field">Field 82 A,D,J (M)</li>
	/// <li class="field">Field 87 A,D,J (M)</li>
	/// <li class="field">Field 83 A,D,J (O)</li>
	/// <li class="field">Field 72  (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence B (M)<ul><li class="field">Field 15 B (M)</li>
	/// <li class="field">Field 30 G (M)</li>
	/// <li class="field">Field 32 B (M)</li>
	/// <li class="field">Field 30 V (M)</li>
	/// <li class="field">Field 34 B (M)</li>
	/// <li class="field">Field 37 M (M)</li>
	/// <li class="field">Field 14 D (M)</li>
	/// <li class="field">Field 30 F (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence C (M)<ul><li class="field">Field 15 C (M)</li>
	/// <li class="field">Field 53 A,D,J (O)</li>
	/// <li class="field">Field 86 A,D,J (O)</li>
	/// <li class="field">Field 56 A,D,J (O)</li>
	/// <li class="field">Field 57 A,D,J (M)</li>
	/// <li class="field">Field 58 A,D,J (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence D (O)<ul><li class="field">Field 15 D (M)</li>
	/// <li class="field">Field 34 B (M)</li>
	/// <li class="field">Field 33 B (M)</li>
	/// <li class="field">Field 36  (O)</li>
	/// <li class="sequence">
	/// Sequence D1 (O)<ul><li class="field">Field 37 L (M)</li>
	/// <li class="field">Field 33 E (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence D2 (O)<ul><li class="field">Field 71 F (M)</li>
	/// <li class="field">Field 37 L (O)</li>
	/// <li class="field">Field 33 E (O)</li>
	/// </ul></li>
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
//ORIGINAL LINE: @Generated public class MT350 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT350 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT350).Name);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "350";

	// begin qualifiers constants	

		/// <summary>
		/// Constant for qualifier with value 30E/360 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String _30E_360 = "30E/360";
		[Obsolete]
		public const string _30E_360 = "30E/360";

		/// <summary>
		/// Constant for qualifier with value 360/360 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String _360_360 = "360/360";
		[Obsolete]
		public const string _360_360 = "360/360";

		/// <summary>
		/// Constant for qualifier with value ACT/360 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ACT_360 = "ACT/360";
		[Obsolete]
		public const string ACT_360 = "ACT/360";

		/// <summary>
		/// Constant for qualifier with value ACT/365 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ACT_365 = "ACT/365";
		[Obsolete]
		public const string ACT_365 = "ACT/365";

		/// <summary>
		/// Constant for qualifier with value ADVC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ADVC = "ADVC";
		[Obsolete]
		public const string ADVC = "ADVC";

		/// <summary>
		/// Constant for qualifier with value AFI/365 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AFI_365 = "AFI/365";
		[Obsolete]
		public const string AFI_365 = "AFI/365";

		/// <summary>
		/// Constant for qualifier with value AGNT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AGNT = "AGNT";
		[Obsolete]
		public const string AGNT = "AGNT";

		/// <summary>
		/// Constant for qualifier with value AMND 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AMND = "AMND";
		[Obsolete]
		public const string AMND = "AMND";

		/// <summary>
		/// Constant for qualifier with value BILA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BILA = "BILA";
		[Obsolete]
		public const string BILA = "BILA";

		/// <summary>
		/// Constant for qualifier with value CANC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CANC = "CANC";
		[Obsolete]
		public const string CANC = "CANC";

		/// <summary>
		/// Constant for qualifier with value DUPL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DUPL = "DUPL";
		[Obsolete]
		public const string DUPL = "DUPL";

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT350 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT350 content </param>
		public MT350(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT350 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT350 content, the parameter can not be null </param>
		/// <seealso cref= #MT350(String) </seealso>
		public MT350(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT350 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT350 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT350(String)
		/// @since 7.7 </seealso>
		public static MT350 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT350(m);
		}

		/// <summary>
		/// Creates and initializes a new MT350 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT350() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT350 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT350(final String sender, final String receiver)
		public MT350(string sender, string receiver) : base(350, sender, receiver)
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
		/// <seealso cref= #MT350(String, String) </seealso>
		/// @deprecated Use instead <code>new MT350(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT350(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT350(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT350(sender, receiver)</code> instead")]
		public MT350(int messageType, string sender, string receiver) : base(350, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT350(int, String, String)", "Use the constructor MT350(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT350 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT350(final String fin)
		public MT350(string fin) : base()
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
				log.warning("Creating an MT350 object from FIN content with a Service Message. Check if the MT350 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT350 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT350 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT350 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT350 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT350 parse(final String fin)
		public static MT350 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT350(fin);
		}

		/// <summary>
		/// Creates a new MT350 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT350(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT350(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT350 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT350 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT350 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT350 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT350(stream);
		}

		/// <summary>
		/// Creates a new MT350 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT350(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT350(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT350 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT350 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT350 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT350 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT350(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "350";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT350 append(final SwiftTagListBlock block)
		public override MT350 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT350 append(final Tag... tags)
		public override MT350 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT350 append(final Field... fields)
		public override MT350 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT350 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT350 message </param>
		/// <returns> a new instance of MT350
		/// @since 7.10.3 </returns>
		public static MT350 fromJson(string json)
		{
			return (MT350) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 15A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15A at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field15A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field15A Field15A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("15A");
				Tag t = tag("15A");
				if (t != null)
				{
					return new Field15A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 20, 
		/// or null if none is found.<br>
		/// The first occurrence of field 20 at MT350 is expected to be the only one.
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
		/// The first occurrence of field 21 at MT350 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 22A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 22A at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field22A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field22A Field22A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("22A");
				Tag t = tag("22A");
				if (t != null)
				{
					return new Field22A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 94A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 94A at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field94A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field94A Field94A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("94A");
				Tag t = tag("94A");
				if (t != null)
				{
					return new Field94A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 22C, 
		/// or null if none is found.<br>
		/// The first occurrence of field 22C at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field22C object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field22C Field22C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("22C");
				Tag t = tag("22C");
				if (t != null)
				{
					return new Field22C(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 21N, 
		/// or null if none is found.<br>
		/// The first occurrence of field 21N at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field21N object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field21N Field21N
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("21N");
				Tag t = tag("21N");
				if (t != null)
				{
					return new Field21N(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 82A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 82A at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field82A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field82A Field82A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("82A");
				Tag t = tag("82A");
				if (t != null)
				{
					return new Field82A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 82D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 82D at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field82D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field82D Field82D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("82D");
				Tag t = tag("82D");
				if (t != null)
				{
					return new Field82D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 82J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 82J at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field82J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field82J Field82J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("82J");
				Tag t = tag("82J");
				if (t != null)
				{
					return new Field82J(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 87A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 87A at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field87A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field87A Field87A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("87A");
				Tag t = tag("87A");
				if (t != null)
				{
					return new Field87A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 87D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 87D at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field87D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field87D Field87D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("87D");
				Tag t = tag("87D");
				if (t != null)
				{
					return new Field87D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 87J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 87J at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field87J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field87J Field87J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("87J");
				Tag t = tag("87J");
				if (t != null)
				{
					return new Field87J(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 83A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 83A at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field83A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field83A Field83A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("83A");
				Tag t = tag("83A");
				if (t != null)
				{
					return new Field83A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 83D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 83D at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field83D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field83D Field83D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("83D");
				Tag t = tag("83D");
				if (t != null)
				{
					return new Field83D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 83J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 83J at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field83J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field83J Field83J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("83J");
				Tag t = tag("83J");
				if (t != null)
				{
					return new Field83J(t.Value);
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
		/// The first occurrence of field 72 at MT350 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 15B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15B at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field15B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field15B Field15B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("15B");
				Tag t = tag("15B");
				if (t != null)
				{
					return new Field15B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 30G, 
		/// or null if none is found.<br>
		/// The first occurrence of field 30G at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field30G object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field30G Field30G
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("30G");
				Tag t = tag("30G");
				if (t != null)
				{
					return new Field30G(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 32B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 32B at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field32B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field32B Field32B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("32B");
				Tag t = tag("32B");
				if (t != null)
				{
					return new Field32B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 30V, 
		/// or null if none is found.<br>
		/// The first occurrence of field 30V at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field30V object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field30V Field30V
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("30V");
				Tag t = tag("30V");
				if (t != null)
				{
					return new Field30V(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 37M, 
		/// or null if none is found.<br>
		/// The first occurrence of field 37M at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field37M object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field37M Field37M
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("37M");
				Tag t = tag("37M");
				if (t != null)
				{
					return new Field37M(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 14D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 14D at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field14D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field14D Field14D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("14D");
				Tag t = tag("14D");
				if (t != null)
				{
					return new Field14D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 30F, 
		/// or null if none is found.<br>
		/// The first occurrence of field 30F at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field30F object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field30F Field30F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("30F");
				Tag t = tag("30F");
				if (t != null)
				{
					return new Field30F(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 15C, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15C at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field15C object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field15C Field15C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("15C");
				Tag t = tag("15C");
				if (t != null)
				{
					return new Field15C(t.Value);
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
		/// The first occurrence of field 53A at MT350 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 53D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 53D at MT350 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 53J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 53J at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field53J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field53J Field53J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("53J");
				Tag t = tag("53J");
				if (t != null)
				{
					return new Field53J(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 86A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 86A at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field86A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field86A Field86A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("86A");
				Tag t = tag("86A");
				if (t != null)
				{
					return new Field86A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 86D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 86D at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field86D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field86D Field86D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("86D");
				Tag t = tag("86D");
				if (t != null)
				{
					return new Field86D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 86J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 86J at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field86J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field86J Field86J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("86J");
				Tag t = tag("86J");
				if (t != null)
				{
					return new Field86J(t.Value);
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
		/// The first occurrence of field 56A at MT350 is expected to be the only one.
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
		/// The first occurrence of field 56D at MT350 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 56J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 56J at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field56J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field56J Field56J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("56J");
				Tag t = tag("56J");
				if (t != null)
				{
					return new Field56J(t.Value);
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
		/// The first occurrence of field 57A at MT350 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 57D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 57D at MT350 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 57J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 57J at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field57J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field57J Field57J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("57J");
				Tag t = tag("57J");
				if (t != null)
				{
					return new Field57J(t.Value);
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
		/// The first occurrence of field 58A at MT350 is expected to be the only one.
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
		/// The first occurrence of field 58D at MT350 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 58J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 58J at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field58J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field58J Field58J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("58J");
				Tag t = tag("58J");
				if (t != null)
				{
					return new Field58J(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 15D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15D at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field15D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field15D Field15D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("15D");
				Tag t = tag("15D");
				if (t != null)
				{
					return new Field15D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 33B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 33B at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field33B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field33B Field33B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("33B");
				Tag t = tag("33B");
				if (t != null)
				{
					return new Field33B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 36, 
		/// or null if none is found.<br>
		/// The first occurrence of field 36 at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field36 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field36 Field36
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("36");
				Tag t = tag("36");
				if (t != null)
				{
					return new Field36(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 71F, 
		/// or null if none is found.<br>
		/// The first occurrence of field 71F at MT350 is expected to be the only one.
		/// </summary>
		/// <returns> a Field71F object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field71F Field71F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("71F");
				Tag t = tag("71F");
				if (t != null)
				{
					return new Field71F(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 34B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 34B at MT350 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field34B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field34B> Field34B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field34B> result = new java.util.ArrayList<>();
				IList<Field34B> result = new List<Field34B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("34B");
				Tag[] tags = tags("34B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field34B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 37L, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 37L at MT350 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field37L objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field37L> Field37L
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field37L> result = new java.util.ArrayList<>();
				IList<Field37L> result = new List<Field37L>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("37L");
				Tag[] tags = tags("37L");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field37L(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 33E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 33E at MT350 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field33E objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field33E> Field33E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field33E> result = new java.util.ArrayList<>();
				IList<Field33E> result = new List<Field33E>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("33E");
				Tag[] tags = tags("33E");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field33E(tag.Value));
					}
				}
				return result;
			}
		}


	// BaseSequenceCodeGenerator [seq=A]
		/// <summary>
		/// Class to model Sequence "A" in MT 350
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.SPLIT_BY_15) public static class SequenceA extends SwiftTagListBlock
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

			public static readonly Tag START_TAG = Field15A.emptyTag();
			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public static SequenceA newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceA newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA result = new SequenceA();
				SequenceA result = new SequenceA();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.7 </returns>
			public static SequenceA newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA result = new SequenceA();
				SequenceA result = new SequenceA();
				result.append(START_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceA newInstance(final SwiftTagListBlock... sequences)
			public static SequenceA newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA result = new SequenceA();
				SequenceA result = new SequenceA();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				return result;
			}

		}
		/// <summary>
		/// Get the single occurrence of SequenceA using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// 
		/// @since 7.7 </summary>
		/// <returns> a new sequence that may be empty, <em>never returns null</em> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceA getSequenceA()
		public virtual SequenceA SequenceA
		{
			get
			{
				return getSequenceA(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceA using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// </summary>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceA within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceA getSequenceA(SwiftTagListBlock parentSequence)
		public virtual SequenceA getSequenceA(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Map<String, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			IDictionary<string, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			if (map.ContainsKey("A"))
			{
				return new SequenceA(map["A"]);
			}
			return new SequenceA();
		}


	// BaseSequenceCodeGenerator [seq=B]
		/// <summary>
		/// Class to model Sequence "B" in MT 350
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.SPLIT_BY_15) public static class SequenceB extends SwiftTagListBlock
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

			public static readonly Tag START_TAG = Field15B.emptyTag();
			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public static SequenceB newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceB newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB result = new SequenceB();
				SequenceB result = new SequenceB();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.7 </returns>
			public static SequenceB newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB result = new SequenceB();
				SequenceB result = new SequenceB();
				result.append(START_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceB newInstance(final SwiftTagListBlock... sequences)
			public static SequenceB newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB result = new SequenceB();
				SequenceB result = new SequenceB();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				return result;
			}

		}
		/// <summary>
		/// Get the single occurrence of SequenceB using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// 
		/// @since 7.7 </summary>
		/// <returns> a new sequence that may be empty, <em>never returns null</em> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceB getSequenceB()
		public virtual SequenceB SequenceB
		{
			get
			{
				return getSequenceB(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceB using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// </summary>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceB within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceB getSequenceB(SwiftTagListBlock parentSequence)
		public virtual SequenceB getSequenceB(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Map<String, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			IDictionary<string, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			if (map.ContainsKey("B"))
			{
				return new SequenceB(map["B"]);
			}
			return new SequenceB();
		}


	// BaseSequenceCodeGenerator [seq=C]
		/// <summary>
		/// Class to model Sequence "C" in MT 350
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.SPLIT_BY_15) public static class SequenceC extends SwiftTagListBlock
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

			public static readonly Tag START_TAG = Field15C.emptyTag();
			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public static SequenceC newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceC newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC result = new SequenceC();
				SequenceC result = new SequenceC();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.7 </returns>
			public static SequenceC newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC result = new SequenceC();
				SequenceC result = new SequenceC();
				result.append(START_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceC newInstance(final SwiftTagListBlock... sequences)
			public static SequenceC newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC result = new SequenceC();
				SequenceC result = new SequenceC();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				return result;
			}

		}
		/// <summary>
		/// Get the single occurrence of SequenceC using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// 
		/// @since 7.7 </summary>
		/// <returns> a new sequence that may be empty, <em>never returns null</em> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceC getSequenceC()
		public virtual SequenceC SequenceC
		{
			get
			{
				return getSequenceC(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceC using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// </summary>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceC within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceC getSequenceC(SwiftTagListBlock parentSequence)
		public virtual SequenceC getSequenceC(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Map<String, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			IDictionary<string, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			if (map.ContainsKey("C"))
			{
				return new SequenceC(map["C"]);
			}
			return new SequenceC();
		}


	// BaseSequenceCodeGenerator [seq=D]
		/// <summary>
		/// Class to model Sequence "D" in MT 350
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.SPLIT_BY_15) public static class SequenceD extends SwiftTagListBlock
		public class SequenceD : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceD() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceD(final SwiftTagListBlock content)
			internal SequenceD(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			public static readonly Tag START_TAG = Field15D.emptyTag();
			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public static SequenceD newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceD newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD result = new SequenceD();
				SequenceD result = new SequenceD();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.7 </returns>
			public static SequenceD newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD result = new SequenceD();
				SequenceD result = new SequenceD();
				result.append(START_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceD newInstance(final SwiftTagListBlock... sequences)
			public static SequenceD newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD result = new SequenceD();
				SequenceD result = new SequenceD();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				return result;
			}

		}
		/// <summary>
		/// Get the single occurrence of SequenceD using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// 
		/// @since 7.7 </summary>
		/// <returns> a new sequence that may be empty, <em>never returns null</em> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceD getSequenceD()
		public virtual SequenceD SequenceD
		{
			get
			{
				return getSequenceD(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceD using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// </summary>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceD within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceD getSequenceD(SwiftTagListBlock parentSequence)
		public virtual SequenceD getSequenceD(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Map<String, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			IDictionary<string, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			if (map.ContainsKey("D"))
			{
				return new SequenceD(map["D"]);
			}
			return new SequenceD();
		}


	// BaseSequenceCodeGenerator [seq=D1]
		/// <summary>
		/// Class to model Sequence "D1" in MT 350
		/// </summary>
		public class SequenceD1 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceD1() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceD1(final SwiftTagListBlock content)
			internal SequenceD1(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// First mandatory tag name of the sequence: <em>"37L"  </em>.
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			public static readonly string[] START = new string[] {"37L"};

			/// <summary>
			/// Last mandatory tag name of the sequence: <em>"33E"  </em>
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			protected internal static readonly string[] END = new string[] {"33E"};

			/// <summary>
			/// List of optional tags after the last mandatory tag
			/// </summary>
			protected internal static readonly string[] TAIL = new string[]{ };

			/// <summary>
			/// Same as <seealso cref="#newInstance(int, int, Tag...)"/> using zero for the indexes </summary>
			/// <param name="tags"> the list of tags to set as sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public static SequenceD1 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceD1 newInstance(params Tag[] tags)
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public static SequenceD1 newInstance(final int start, final int end, final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceD1 newInstance(int start, int end, params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1 result = new SequenceD1();
				SequenceD1 result = new SequenceD1();
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
		 /// Get the single occurrence of SequenceD1 delimited by leading tag and end, with an optional tail.
		 /// The presence of this method indicates that this sequence can occur only once according to the Standard.
		 /// If block 4 is empty this method returns null.
		 /// </summary>
		 /// <returns> the found sequence or an empty sequence if none is found </returns>
		 /// <seealso cref= SwiftTagListBlock#getSubBlockDelimitedWithOptionalTail(String[], String[], String[]) </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public SequenceD1 getSequenceD1()
		public virtual SequenceD1 SequenceD1
		{
			get
			{
				return getSequenceD1(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceD1 delimited by leading tag and end, with an optional tail.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// If block 4 is empty this method returns null.
		/// </summary>
		/// <seealso cref= SwiftTagListBlock#getSubBlockDelimitedWithOptionalTail(String[], String[], String[]) </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceD1 within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public SequenceD1 getSequenceD1(SwiftTagListBlock parentSequence)
		public virtual SequenceD1 getSequenceD1(SwiftTagListBlock parentSequence)
		{
			if (parentSequence != null && !parentSequence.Empty)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock content = parentSequence.getSubBlockDelimitedWithOptionalTail(SequenceD1.START, SequenceD1.END, SequenceD1.TAIL);
				SwiftTagListBlock content = parentSequence.getSubBlockDelimitedWithOptionalTail(SequenceD1.START, SequenceD1.END, SequenceD1.TAIL);
				if (log.isLoggable(java.util.logging.Level.FINE))
				{
					if (content == null)
					{
						log.fine("content for sequence SequenceD1: is null");
					}
					else
					{
						log.fine("content for sequence SequenceD1: " + content.tagNamesList());
					}
				}
				if (content == null)
				{
					return new SequenceD1();
				}
				else
				{
					return new SequenceD1(content);
				}
			}
			return null;
		}




	}

}