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
namespace com.prowidesoftware.swift.model.mt.mt4xx
{




	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using com.prowidesoftware.swift.@internal;
	using Type = com.prowidesoftware.swift.@internal.SequenceStyle.Type;
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 416 - Advice of Non-Payment/Non-Acceptance</strong>
	/// 
	/// <para>
	/// SWIFT MT416 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="sequence">
	/// Sequence A - General Information (M)<ul><li class="field">Field 20  (M)</li>
	/// <li class="field">Field 21  (M)</li>
	/// <li class="field">Field 23 E (O)</li>
	/// <li class="field">Field 51 A (O)</li>
	/// <li class="field">Field 53 A,B (O)</li>
	/// <li class="field">Field 71 F (O)</li>
	/// <li class="field">Field 77 A (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence B - Non-Payment/Non-Acceptance Details (M) (repetitive)<ul><li class="field">Field 21 A (M)</li>
	/// <li class="field">Field 23 E (O)</li>
	/// <li class="field">Field 21 C (O)</li>
	/// <li class="field">Field 32 A,B,K (M)</li>
	/// <li class="field">Field 50 D (O)</li>
	/// <li class="field">Field 59  (O)</li>
	/// <li class="field">Field 71 F (O)</li>
	/// <li class="field">Field 77 A (O)</li>
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
//ORIGINAL LINE: @Generated public class MT416 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT416 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT416).Name);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "416";

	// begin qualifiers constants	

		/// <summary>
		/// Constant for qualifier with value AMAM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AMAM = "AMAM";
		[Obsolete]
		public const string AMAM = "AMAM";

		/// <summary>
		/// Constant for qualifier with value AMTL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AMTL = "AMTL";
		[Obsolete]
		public const string AMTL = "AMTL";

		/// <summary>
		/// Constant for qualifier with value AUTH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AUTH = "AUTH";
		[Obsolete]
		public const string AUTH = "AUTH";

		/// <summary>
		/// Constant for qualifier with value CHQB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CHQB = "CHQB";
		[Obsolete]
		public const string CHQB = "CHQB";

		/// <summary>
		/// Constant for qualifier with value CLOS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CLOS = "CLOS";
		[Obsolete]
		public const string CLOS = "CLOS";

		/// <summary>
		/// Constant for qualifier with value CMSW 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CMSW = "CMSW";
		[Obsolete]
		public const string CMSW = "CMSW";

		/// <summary>
		/// Constant for qualifier with value CMTO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CMTO = "CMTO";
		[Obsolete]
		public const string CMTO = "CMTO";

		/// <summary>
		/// Constant for qualifier with value CMZB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CMZB = "CMZB";
		[Obsolete]
		public const string CMZB = "CMZB";

		/// <summary>
		/// Constant for qualifier with value COLN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COLN = "COLN";
		[Obsolete]
		public const string COLN = "COLN";

		/// <summary>
		/// Constant for qualifier with value CORT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CORT = "CORT";
		[Obsolete]
		public const string CORT = "CORT";

		/// <summary>
		/// Constant for qualifier with value DRAW 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DRAW = "DRAW";
		[Obsolete]
		public const string DRAW = "DRAW";

		/// <summary>
		/// Constant for qualifier with value DUPL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DUPL = "DUPL";
		[Obsolete]
		public const string DUPL = "DUPL";

		/// <summary>
		/// Constant for qualifier with value EQUI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EQUI = "EQUI";
		[Obsolete]
		public const string EQUI = "EQUI";

		/// <summary>
		/// Constant for qualifier with value FRAU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FRAU = "FRAU";
		[Obsolete]
		public const string FRAU = "FRAU";

		/// <summary>
		/// Constant for qualifier with value FROZ 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FROZ = "FROZ";
		[Obsolete]
		public const string FROZ = "FROZ";

		/// <summary>
		/// Constant for qualifier with value FRWD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FRWD = "FRWD";
		[Obsolete]
		public const string FRWD = "FRWD";

		/// <summary>
		/// Constant for qualifier with value HOLD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String HOLD = "HOLD";
		[Obsolete]
		public const string HOLD = "HOLD";

		/// <summary>
		/// Constant for qualifier with value INCH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INCH = "INCH";
		[Obsolete]
		public const string INCH = "INCH";

		/// <summary>
		/// Constant for qualifier with value INSF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INSF = "INSF";
		[Obsolete]
		public const string INSF = "INSF";

		/// <summary>
		/// Constant for qualifier with value INSI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INSI = "INSI";
		[Obsolete]
		public const string INSI = "INSI";

		/// <summary>
		/// Constant for qualifier with value INTC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INTC = "INTC";
		[Obsolete]
		public const string INTC = "INTC";

		/// <summary>
		/// Constant for qualifier with value INVA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INVA = "INVA";
		[Obsolete]
		public const string INVA = "INVA";

		/// <summary>
		/// Constant for qualifier with value NACC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NACC = "NACC";
		[Obsolete]
		public const string NACC = "NACC";

		/// <summary>
		/// Constant for qualifier with value NAUT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NAUT = "NAUT";
		[Obsolete]
		public const string NAUT = "NAUT";

		/// <summary>
		/// Constant for qualifier with value NELI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NELI = "NELI";
		[Obsolete]
		public const string NELI = "NELI";

		/// <summary>
		/// Constant for qualifier with value NETS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NETS = "NETS";
		[Obsolete]
		public const string NETS = "NETS";

		/// <summary>
		/// Constant for qualifier with value NMAT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NMAT = "NMAT";
		[Obsolete]
		public const string NMAT = "NMAT";

		/// <summary>
		/// Constant for qualifier with value NPAY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NPAY = "NPAY";
		[Obsolete]
		public const string NPAY = "NPAY";

		/// <summary>
		/// Constant for qualifier with value OTHR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OTHR = "OTHR";
		[Obsolete]
		public const string OTHR = "OTHR";

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
		/// Constant for qualifier with value REVO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REVO = "REVO";
		[Obsolete]
		public const string REVO = "REVO";

		/// <summary>
		/// Constant for qualifier with value RFDD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RFDD = "RFDD";
		[Obsolete]
		public const string RFDD = "RFDD";

		/// <summary>
		/// Constant for qualifier with value RTGS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RTGS = "RTGS";
		[Obsolete]
		public const string RTGS = "RTGS";

		/// <summary>
		/// Constant for qualifier with value RTND 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RTND = "RTND";
		[Obsolete]
		public const string RTND = "RTND";

		/// <summary>
		/// Constant for qualifier with value SDVA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SDVA = "SDVA";
		[Obsolete]
		public const string SDVA = "SDVA";

		/// <summary>
		/// Constant for qualifier with value STLD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String STLD = "STLD";
		[Obsolete]
		public const string STLD = "STLD";

		/// <summary>
		/// Constant for qualifier with value STOP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String STOP = "STOP";
		[Obsolete]
		public const string STOP = "STOP";

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

		/// <summary>
		/// Constant for qualifier with value URGP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String URGP = "URGP";
		[Obsolete]
		public const string URGP = "URGP";

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT416 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT416 content </param>
		public MT416(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT416 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT416 content, the parameter can not be null </param>
		/// <seealso cref= #MT416(String) </seealso>
		public MT416(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT416 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT416 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT416(String)
		/// @since 7.7 </seealso>
		public static MT416 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT416(m);
		}

		/// <summary>
		/// Creates and initializes a new MT416 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT416() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT416 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT416(final String sender, final String receiver)
		public MT416(string sender, string receiver) : base(416, sender, receiver)
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
		/// <seealso cref= #MT416(String, String) </seealso>
		/// @deprecated Use instead <code>new MT416(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT416(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT416(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT416(sender, receiver)</code> instead")]
		public MT416(int messageType, string sender, string receiver) : base(416, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT416(int, String, String)", "Use the constructor MT416(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT416 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT416(final String fin)
		public MT416(string fin) : base()
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
				log.warning("Creating an MT416 object from FIN content with a Service Message. Check if the MT416 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT416 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT416 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT416 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT416 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT416 parse(final String fin)
		public static MT416 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT416(fin);
		}

		/// <summary>
		/// Creates a new MT416 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT416(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT416(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT416 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT416 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT416 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT416 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT416(stream);
		}

		/// <summary>
		/// Creates a new MT416 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT416(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT416(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT416 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT416 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT416 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT416 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT416(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "416";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT416 append(final SwiftTagListBlock block)
		public override MT416 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT416 append(final Tag... tags)
		public override MT416 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT416 append(final Field... fields)
		public override MT416 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT416 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT416 message </param>
		/// <returns> a new instance of MT416
		/// @since 7.10.3 </returns>
		public static MT416 fromJson(string json)
		{
			return (MT416) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 20, 
		/// or null if none is found.<br>
		/// The first occurrence of field 20 at MT416 is expected to be the only one.
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
		/// The first occurrence of field 21 at MT416 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 51A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 51A at MT416 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 53A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 53A at MT416 is expected to be the only one.
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
		/// The first occurrence of field 53B at MT416 is expected to be the only one.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 21A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 21A at MT416 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field21A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field21A> Field21A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field21A> result = new java.util.ArrayList<>();
				IList<Field21A> result = new List<Field21A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("21A");
				Tag[] tags = tags("21A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field21A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 23E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 23E at MT416 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 21C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 21C at MT416 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field21C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field21C> Field21C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field21C> result = new java.util.ArrayList<>();
				IList<Field21C> result = new List<Field21C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("21C");
				Tag[] tags = tags("21C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field21C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 32A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 32A at MT416 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 32B at MT416 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 32K at MT416 are expected at one sequence or across several sequences.
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

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 50D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 50D at MT416 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field50D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field50D> Field50D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field50D> result = new java.util.ArrayList<>();
				IList<Field50D> result = new List<Field50D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("50D");
				Tag[] tags = tags("50D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field50D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 59, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 59 at MT416 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 71F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 71F at MT416 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 77A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 77A at MT416 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field77A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field77A> Field77A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field77A> result = new java.util.ArrayList<>();
				IList<Field77A> result = new List<Field77A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("77A");
				Tag[] tags = tags("77A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field77A(tag.Value));
					}
				}
				return result;
			}
		}


	// BaseSequenceCodeGenerator [seq=A]
		/// <summary>
		/// Class to model Sequence "A" in MT 416
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
			/// Last mandatory tag name of the sequence: <em>"21"  </em>
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			protected internal static readonly string[] END = new string[] {"21"};

			/// <summary>
			/// List of optional tags after the last mandatory tag
			/// </summary>
			protected internal static readonly string[] TAIL = new string[]{"23E", "51A", "53A", "53B", "71F", "77A"};

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
		/// Class to model Sequence "B" in MT 416
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
			/// First mandatory tag name of the sequence: <em>"21A"  </em>.
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			public static readonly string[] START = new string[] {"21A"};

			/// <summary>
			/// Last mandatory tag name of the sequence: <em>"32A", "32B", "32K"  </em>
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			protected internal static readonly string[] END = new string[] {"32A", "32B", "32K"};

			/// <summary>
			/// List of optional tags after the last mandatory tag
			/// </summary>
			protected internal static readonly string[] TAIL = new string[]{"50D", "59", "71F", "77A"};

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




	}

}