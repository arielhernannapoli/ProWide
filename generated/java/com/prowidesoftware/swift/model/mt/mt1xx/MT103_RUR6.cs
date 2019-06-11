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
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 103_RUR6 - Single Customer Credit Transfer</strong>
	/// 
	/// <para>
	/// SWIFT MT103_RUR6 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="field">Field 20  (M)</li>
	/// <li class="field">Field 23 B (M)</li>
	/// <li class="field">Field 23 E (O) (repetitive)</li>
	/// <li class="field">Field 26 T (O)</li>
	/// <li class="field">Field 32 A (M)</li>
	/// <li class="field">Field 33 B (O)</li>
	/// <li class="field">Field 36  (O)</li>
	/// <li class="field">Field 50 A,F,K (M)</li>
	/// <li class="field">Field 52 A,D (O)</li>
	/// <li class="field">Field 53 B (O)</li>
	/// <li class="field">Field 56 A,D (O)</li>
	/// <li class="field">Field 57 A,D (O)</li>
	/// <li class="field">Field 59 NONE (M)</li>
	/// <li class="field">Field 70  (M)</li>
	/// <li class="field">Field 71 A (M)</li>
	/// <li class="field">Field 71 F (O) (repetitive)</li>
	/// <li class="field">Field 71 G (O)</li>
	/// <li class="field">Field 72  (M)</li>
	/// <li class="field">Field 77 B (O)</li>
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
//ORIGINAL LINE: @Generated public class MT103_RUR6 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT103_RUR6 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT103_RUR6).FullName);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "103_RUR6";

	// begin qualifiers constants	

		/// <summary>
		/// Constant for qualifier with value BEN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BEN = "BEN";
		[Obsolete]
		public const string BEN = "BEN";

		/// <summary>
		/// Constant for qualifier with value CHQB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CHQB = "CHQB";
		[Obsolete]
		public const string CHQB = "CHQB";

		/// <summary>
		/// Constant for qualifier with value CORT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CORT = "CORT";
		[Obsolete]
		public const string CORT = "CORT";

		/// <summary>
		/// Constant for qualifier with value CRED 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CRED = "CRED";
		[Obsolete]
		public const string CRED = "CRED";

		/// <summary>
		/// Constant for qualifier with value CRTS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CRTS = "CRTS";
		[Obsolete]
		public const string CRTS = "CRTS";

		/// <summary>
		/// Constant for qualifier with value HOLD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String HOLD = "HOLD";
		[Obsolete]
		public const string HOLD = "HOLD";

		/// <summary>
		/// Constant for qualifier with value INTC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INTC = "INTC";
		[Obsolete]
		public const string INTC = "INTC";

		/// <summary>
		/// Constant for qualifier with value OUR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OUR = "OUR";
		[Obsolete]
		public const string OUR = "OUR";

		/// <summary>
		/// Constant for qualifier with value PHOB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PHOB = "PHOB";
		[Obsolete]
		public const string PHOB = "PHOB";

		/// <summary>
		/// Constant for qualifier with value PHOI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PHOI = "PHOI";
		[Obsolete]
		public const string PHOI = "PHOI";

		/// <summary>
		/// Constant for qualifier with value PHON 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PHON = "PHON";
		[Obsolete]
		public const string PHON = "PHON";

		/// <summary>
		/// Constant for qualifier with value REPA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REPA = "REPA";
		[Obsolete]
		public const string REPA = "REPA";

		/// <summary>
		/// Constant for qualifier with value SDVA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SDVA = "SDVA";
		[Obsolete]
		public const string SDVA = "SDVA";

		/// <summary>
		/// Constant for qualifier with value SHA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SHA = "SHA";
		[Obsolete]
		public const string SHA = "SHA";

		/// <summary>
		/// Constant for qualifier with value SPAY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SPAY = "SPAY";
		[Obsolete]
		public const string SPAY = "SPAY";

		/// <summary>
		/// Constant for qualifier with value SPRI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SPRI = "SPRI";
		[Obsolete]
		public const string SPRI = "SPRI";

		/// <summary>
		/// Constant for qualifier with value SSTD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SSTD = "SSTD";
		[Obsolete]
		public const string SSTD = "SSTD";

		/// <summary>
		/// Constant for qualifier with value TELB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TELB = "TELB";
		[Obsolete]
		public const string TELB = "TELB";

		/// <summary>
		/// Constant for qualifier with value TELE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TELE = "TELE";
		[Obsolete]
		public const string TELE = "TELE";

		/// <summary>
		/// Constant for qualifier with value TELI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TELI = "TELI";
		[Obsolete]
		public const string TELI = "TELI";

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT103_RUR6 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT103_RUR6 content </param>
		public MT103_RUR6(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT103_RUR6 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT103_RUR6 content, the parameter can not be null </param>
		/// <seealso cref= #MT103_RUR6(String) </seealso>
		public MT103_RUR6(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT103_RUR6 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT103_RUR6 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT103_RUR6(String)
		/// @since 7.7 </seealso>
		public static MT103_RUR6 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT103_RUR6(m);
		}

		/// <summary>
		/// Creates and initializes a new MT103_RUR6 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT103_RUR6() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT103_RUR6 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT103_RUR6(final String sender, final String receiver)
		public MT103_RUR6(string sender, string receiver) : base(103, sender, receiver)
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
		/// <seealso cref= #MT103_RUR6(String, String) </seealso>
		/// @deprecated Use instead <code>new MT103_RUR6(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT103_RUR6(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT103_RUR6(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT103_RUR6(sender, receiver)</code> instead")]
		public MT103_RUR6(int messageType, string sender, string receiver) : base(103, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT103_RUR6(int, String, String)", "Use the constructor MT103_RUR6(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT103_RUR6 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT103_RUR6(final String fin)
		public MT103_RUR6(string fin) : base()
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
				log.warning("Creating an MT103_RUR6 object from FIN content with a Service Message. Check if the MT103_RUR6 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT103_RUR6 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT103_RUR6 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT103_RUR6 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT103_RUR6 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT103_RUR6 parse(final String fin)
		public static MT103_RUR6 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT103_RUR6(fin);
		}

		/// <summary>
		/// Creates a new MT103_RUR6 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT103_RUR6(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT103_RUR6(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT103_RUR6 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT103_RUR6 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT103_RUR6 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT103_RUR6 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT103_RUR6(stream);
		}

		/// <summary>
		/// Creates a new MT103_RUR6 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT103_RUR6(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT103_RUR6(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT103_RUR6 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT103_RUR6 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT103_RUR6 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT103_RUR6 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT103_RUR6(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "103";
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
//ORIGINAL LINE: @Override public MT103_RUR6 append(final SwiftTagListBlock block)
		public override MT103_RUR6 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT103_RUR6 append(final Tag... tags)
		public override MT103_RUR6 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT103_RUR6 append(final Field... fields)
		public override MT103_RUR6 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT103_RUR6 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT103_RUR6 message </param>
		/// <returns> a new instance of MT103_RUR6
		/// @since 7.10.3 </returns>
		public static MT103_RUR6 fromJson(string json)
		{
			return (MT103_RUR6) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 20, 
		/// or null if none is found.<br>
		/// The first occurrence of field 20 at MT103_RUR6 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 23B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 23B at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field23B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field23B Field23B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("23B");
				Tag t = tag("23B");
				if (t != null)
				{
					return new Field23B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 26T, 
		/// or null if none is found.<br>
		/// The first occurrence of field 26T at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field26T object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field26T Field26T
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("26T");
				Tag t = tag("26T");
				if (t != null)
				{
					return new Field26T(t.Value);
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
		/// The first occurrence of field 32A at MT103_RUR6 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 33B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 33B at MT103_RUR6 is expected to be the only one.
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
		/// The first occurrence of field 36 at MT103_RUR6 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 50A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 50A at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field50A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field50A Field50A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("50A");
				Tag t = tag("50A");
				if (t != null)
				{
					return new Field50A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 50F, 
		/// or null if none is found.<br>
		/// The first occurrence of field 50F at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field50F object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field50F Field50F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("50F");
				Tag t = tag("50F");
				if (t != null)
				{
					return new Field50F(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 50K, 
		/// or null if none is found.<br>
		/// The first occurrence of field 50K at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field50K object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field50K Field50K
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("50K");
				Tag t = tag("50K");
				if (t != null)
				{
					return new Field50K(t.Value);
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
		/// The first occurrence of field 52A at MT103_RUR6 is expected to be the only one.
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
		/// The first occurrence of field 52D at MT103_RUR6 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 53B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 53B at MT103_RUR6 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 56A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 56A at MT103_RUR6 is expected to be the only one.
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
		/// The first occurrence of field 56D at MT103_RUR6 is expected to be the only one.
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
		/// The first occurrence of field 57A at MT103_RUR6 is expected to be the only one.
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
		/// The first occurrence of field 57D at MT103_RUR6 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 59, 
		/// or null if none is found.<br>
		/// The first occurrence of field 59 at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field59 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field59 Field59
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("59");
				Tag t = tag("59");
				if (t != null)
				{
					return new Field59(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 70, 
		/// or null if none is found.<br>
		/// The first occurrence of field 70 at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field70 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field70 Field70
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("70");
				Tag t = tag("70");
				if (t != null)
				{
					return new Field70(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 71A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 71A at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field71A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field71A Field71A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("71A");
				Tag t = tag("71A");
				if (t != null)
				{
					return new Field71A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 71G, 
		/// or null if none is found.<br>
		/// The first occurrence of field 71G at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field71G object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field71G Field71G
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("71G");
				Tag t = tag("71G");
				if (t != null)
				{
					return new Field71G(t.Value);
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
		/// The first occurrence of field 72 at MT103_RUR6 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 77B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 77B at MT103_RUR6 is expected to be the only one.
		/// </summary>
		/// <returns> a Field77B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field77B Field77B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("77B");
				Tag t = tag("77B");
				if (t != null)
				{
					return new Field77B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 23E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 23E at MT103_RUR6 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field23E objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field23E> Field23E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field23E> result = new java.util.ArrayList<>();
				IList<Field23E> result = new List<Field23E>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("23E");
				Tag[] tags = tags("23E");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field23E(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 71F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 71F at MT103_RUR6 are expected at one sequence or across several sequences.
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




	}

}