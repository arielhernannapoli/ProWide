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
namespace com.prowidesoftware.swift.model.mt.mt6xx
{




	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using com.prowidesoftware.swift.@internal;
	using Type = com.prowidesoftware.swift.@internal.SequenceStyle.Type;
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 620 - Commodity Fixed Loan/Deposit Confirmation</strong>
	/// 
	/// <para>
	/// SWIFT MT620 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="sequence">
	/// Sequence A (M)<ul><li class="field">Field 15 A (M)</li>
	/// <li class="field">Field 20  (M)</li>
	/// <li class="field">Field 21  (O)</li>
	/// <li class="field">Field 22 A (M)</li>
	/// <li class="field">Field 94 A (O)</li>
	/// <li class="field">Field 22 B (M)</li>
	/// <li class="field">Field 21 N (O)</li>
	/// <li class="field">Field 82 A,D,J (M)</li>
	/// <li class="field">Field 87 A,D,J (M)</li>
	/// <li class="field">Field 83 A,D,J (O)</li>
	/// <li class="field">Field 26 C (M)</li>
	/// <li class="field">Field 77 D (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence B (M)<ul><li class="field">Field 15 B (M)</li>
	/// <li class="field">Field 17 R (M)</li>
	/// <li class="field">Field 30 T (M)</li>
	/// <li class="field">Field 30 V (M)</li>
	/// <li class="field">Field 30 P (M)</li>
	/// <li class="field">Field 32 B,F (M)</li>
	/// <li class="field">Field 32 H,R (O)</li>
	/// <li class="field">Field 30 X (O)</li>
	/// <li class="field">Field 34 E,J (M)</li>
	/// <li class="field">Field 37 G (M)</li>
	/// <li class="field">Field 14 D (M)</li>
	/// <li class="field">Field 30 F (O)</li>
	/// <li class="field">Field 38 J (O)</li>
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
	/// Sequence D (M)<ul><li class="field">Field 15 D (M)</li>
	/// <li class="field">Field 53 A,D,J (O)</li>
	/// <li class="field">Field 86 A,D,J (O)</li>
	/// <li class="field">Field 56 A,D,J (O)</li>
	/// <li class="field">Field 57 A,D,J (M)</li>
	/// <li class="field">Field 58 A,D,J (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence E (O)<ul><li class="field">Field 15 E (M)</li>
	/// <li class="field">Field 53 A,D,J (O)</li>
	/// <li class="field">Field 86 A,D,J (O)</li>
	/// <li class="field">Field 56 A,D,J (O)</li>
	/// <li class="field">Field 57 A,D,J (M)</li>
	/// <li class="field">Field 58 A,D,J (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence F (O)<ul><li class="field">Field 15 F (M)</li>
	/// <li class="field">Field 53 A,D,J (O)</li>
	/// <li class="field">Field 86 A,D,J (O)</li>
	/// <li class="field">Field 56 A,D,J (O)</li>
	/// <li class="field">Field 57 A,D,J (M)</li>
	/// <li class="field">Field 58 A,D,J (O)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence G (O)<ul><li class="field">Field 15 G (M)</li>
	/// <li class="sequence">
	/// Sequence G1 (M)<ul><li class="field">Field 37 L (M)</li>
	/// <li class="field">Field 33 B,J (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence G2 (O)<ul><li class="field">Field 36  (O)</li>
	/// <li class="field">Field 33 E,J (O)</li>
	/// </ul></li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence H (O)<ul><li class="field">Field 15 H (M)</li>
	/// <li class="field">Field 29 A (O)</li>
	/// <li class="field">Field 24 D (O)</li>
	/// <li class="field">Field 84 A,B,D,J (O)</li>
	/// <li class="field">Field 85 A,B,D,J (O)</li>
	/// <li class="field">Field 88 A,D,J (O)</li>
	/// <li class="field">Field 71 F (O)</li>
	/// <li class="field">Field 26 H (O)</li>
	/// <li class="field">Field 21 G (O)</li>
	/// <li class="field">Field 22 Z (O)</li>
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
//ORIGINAL LINE: @Generated public class MT620 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT620 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT620).Name);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "620";

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
		/// Constant for qualifier with value ALLOC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ALLOC = "ALLOC";
		[Obsolete]
		public const string ALLOC = "ALLOC";

		/// <summary>
		/// Constant for qualifier with value ALUM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ALUM = "ALUM";
		[Obsolete]
		public const string ALUM = "ALUM";

		/// <summary>
		/// Constant for qualifier with value AMEG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AMEG = "AMEG";
		[Obsolete]
		public const string AMEG = "AMEG";

		/// <summary>
		/// Constant for qualifier with value AMND 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AMND = "AMND";
		[Obsolete]
		public const string AMND = "AMND";

		/// <summary>
		/// Constant for qualifier with value ANUG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ANUG = "ANUG";
		[Obsolete]
		public const string ANUG = "ANUG";

		/// <summary>
		/// Constant for qualifier with value B 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String B = "B";
		[Obsolete]
		public const string B = "B";

		/// <summary>
		/// Constant for qualifier with value BILA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BILA = "BILA";
		[Obsolete]
		public const string BILA = "BILA";

		/// <summary>
		/// Constant for qualifier with value BRIT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BRIT = "BRIT";
		[Obsolete]
		public const string BRIT = "BRIT";

		/// <summary>
		/// Constant for qualifier with value BROK 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BROK = "BROK";
		[Obsolete]
		public const string BROK = "BROK";

		/// <summary>
		/// Constant for qualifier with value CANC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CANC = "CANC";
		[Obsolete]
		public const string CANC = "CANC";

		/// <summary>
		/// Constant for qualifier with value CFR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CFR = "CFR";
		[Obsolete]
		public const string CFR = "CFR";

		/// <summary>
		/// Constant for qualifier with value CIF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CIF = "CIF";
		[Obsolete]
		public const string CIF = "CIF";

		/// <summary>
		/// Constant for qualifier with value CIP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CIP = "CIP";
		[Obsolete]
		public const string CIP = "CIP";

		/// <summary>
		/// Constant for qualifier with value COIN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COIN = "COIN";
		[Obsolete]
		public const string COIN = "COIN";

		/// <summary>
		/// Constant for qualifier with value CONF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CONF = "CONF";
		[Obsolete]
		public const string CONF = "CONF";

		/// <summary>
		/// Constant for qualifier with value COPP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COPP = "COPP";
		[Obsolete]
		public const string COPP = "COPP";

		/// <summary>
		/// Constant for qualifier with value CORO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CORO = "CORO";
		[Obsolete]
		public const string CORO = "CORO";

		/// <summary>
		/// Constant for qualifier with value CPT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CPT = "CPT";
		[Obsolete]
		public const string CPT = "CPT";

		/// <summary>
		/// Constant for qualifier with value D 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String D = "D";
		[Obsolete]
		public const string D = "D";

		/// <summary>
		/// Constant for qualifier with value DAF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DAF = "DAF";
		[Obsolete]
		public const string DAF = "DAF";

		/// <summary>
		/// Constant for qualifier with value DDP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DDP = "DDP";
		[Obsolete]
		public const string DDP = "DDP";

		/// <summary>
		/// Constant for qualifier with value DDU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DDU = "DDU";
		[Obsolete]
		public const string DDU = "DDU";

		/// <summary>
		/// Constant for qualifier with value DEQ 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DEQ = "DEQ";
		[Obsolete]
		public const string DEQ = "DEQ";

		/// <summary>
		/// Constant for qualifier with value DES 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DES = "DES";
		[Obsolete]
		public const string DES = "DES";

		/// <summary>
		/// Constant for qualifier with value DTD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DTD = "DTD";
		[Obsolete]
		public const string DTD = "DTD";

		/// <summary>
		/// Constant for qualifier with value DUCA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DUCA = "DUCA";
		[Obsolete]
		public const string DUCA = "DUCA";

		/// <summary>
		/// Constant for qualifier with value DUPL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DUPL = "DUPL";
		[Obsolete]
		public const string DUPL = "DUPL";

		/// <summary>
		/// Constant for qualifier with value ELEC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ELEC = "ELEC";
		[Obsolete]
		public const string ELEC = "ELEC";

		/// <summary>
		/// Constant for qualifier with value EXW 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EXW = "EXW";
		[Obsolete]
		public const string EXW = "EXW";

		/// <summary>
		/// Constant for qualifier with value FAS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FAS = "FAS";
		[Obsolete]
		public const string FAS = "FAS";

		/// <summary>
		/// Constant for qualifier with value FCA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FCA = "FCA";
		[Obsolete]
		public const string FCA = "FCA";

		/// <summary>
		/// Constant for qualifier with value FOB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FOB = "FOB";
		[Obsolete]
		public const string FOB = "FOB";

		/// <summary>
		/// Constant for qualifier with value FRFR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FRFR = "FRFR";
		[Obsolete]
		public const string FRFR = "FRFR";

		/// <summary>
		/// Constant for qualifier with value GECU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String GECU = "GECU";
		[Obsolete]
		public const string GECU = "GECU";

		/// <summary>
		/// Constant for qualifier with value GOLD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String GOLD = "GOLD";
		[Obsolete]
		public const string GOLD = "GOLD";

		/// <summary>
		/// Constant for qualifier with value IRID 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String IRID = "IRID";
		[Obsolete]
		public const string IRID = "IRID";

		/// <summary>
		/// Constant for qualifier with value KRUG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String KRUG = "KRUG";
		[Obsolete]
		public const string KRUG = "KRUG";

		/// <summary>
		/// Constant for qualifier with value L 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String L = "L";
		[Obsolete]
		public const string L = "L";

		/// <summary>
		/// Constant for qualifier with value LBTY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LBTY = "LBTY";
		[Obsolete]
		public const string LBTY = "LBTY";

		/// <summary>
		/// Constant for qualifier with value LEAD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LEAD = "LEAD";
		[Obsolete]
		public const string LEAD = "LEAD";

		/// <summary>
		/// Constant for qualifier with value LOC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOC = "LOC";
		[Obsolete]
		public const string LOC = "LOC";

		/// <summary>
		/// Constant for qualifier with value M 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String M = "M";
		[Obsolete]
		public const string M = "M";

		/// <summary>
		/// Constant for qualifier with value MAPL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MAPL = "MAPL";
		[Obsolete]
		public const string MAPL = "MAPL";

		/// <summary>
		/// Constant for qualifier with value MATU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MATU = "MATU";
		[Obsolete]
		public const string MATU = "MATU";

		/// <summary>
		/// Constant for qualifier with value MEXP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MEXP = "MEXP";
		[Obsolete]
		public const string MEXP = "MEXP";

		/// <summary>
		/// Constant for qualifier with value NBUF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NBUF = "NBUF";
		[Obsolete]
		public const string NBUF = "NBUF";

		/// <summary>
		/// Constant for qualifier with value NEWT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NEWT = "NEWT";
		[Obsolete]
		public const string NEWT = "NEWT";

		/// <summary>
		/// Constant for qualifier with value NICK 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NICK = "NICK";
		[Obsolete]
		public const string NICK = "NICK";

		/// <summary>
		/// Constant for qualifier with value NOBL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NOBL = "NOBL";
		[Obsolete]
		public const string NOBL = "NOBL";

		/// <summary>
		/// Constant for qualifier with value NSOV 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NSOV = "NSOV";
		[Obsolete]
		public const string NSOV = "NSOV";

		/// <summary>
		/// Constant for qualifier with value OSMI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OSMI = "OSMI";
		[Obsolete]
		public const string OSMI = "OSMI";

		/// <summary>
		/// Constant for qualifier with value OSOV 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OSOV = "OSOV";
		[Obsolete]
		public const string OSOV = "OSOV";

		/// <summary>
		/// Constant for qualifier with value OTH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OTH = "OTH";
		[Obsolete]
		public const string OTH = "OTH";

		/// <summary>
		/// Constant for qualifier with value OTHR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OTHR = "OTHR";
		[Obsolete]
		public const string OTHR = "OTHR";

		/// <summary>
		/// Constant for qualifier with value PALL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PALL = "PALL";
		[Obsolete]
		public const string PALL = "PALL";

		/// <summary>
		/// Constant for qualifier with value PHON 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PHON = "PHON";
		[Obsolete]
		public const string PHON = "PHON";

		/// <summary>
		/// Constant for qualifier with value PLAT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PLAT = "PLAT";
		[Obsolete]
		public const string PLAT = "PLAT";

		/// <summary>
		/// Constant for qualifier with value POIL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String POIL = "POIL";
		[Obsolete]
		public const string POIL = "POIL";

		/// <summary>
		/// Constant for qualifier with value RHOD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RHOD = "RHOD";
		[Obsolete]
		public const string RHOD = "RHOD";

		/// <summary>
		/// Constant for qualifier with value ROLL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ROLL = "ROLL";
		[Obsolete]
		public const string ROLL = "ROLL";

		/// <summary>
		/// Constant for qualifier with value RUTH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RUTH = "RUTH";
		[Obsolete]
		public const string RUTH = "RUTH";

		/// <summary>
		/// Constant for qualifier with value SAEG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SAEG = "SAEG";
		[Obsolete]
		public const string SAEG = "SAEG";

		/// <summary>
		/// Constant for qualifier with value SECU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SECU = "SECU";
		[Obsolete]
		public const string SECU = "SECU";

		/// <summary>
		/// Constant for qualifier with value SILV 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SILV = "SILV";
		[Obsolete]
		public const string SILV = "SILV";

		/// <summary>
		/// Constant for qualifier with value STAT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String STAT = "STAT";
		[Obsolete]
		public const string STAT = "STAT";

		/// <summary>
		/// Constant for qualifier with value STEE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String STEE = "STEE";
		[Obsolete]
		public const string STEE = "STEE";

		/// <summary>
		/// Constant for qualifier with value TINA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TINA = "TINA";
		[Obsolete]
		public const string TINA = "TINA";

		/// <summary>
		/// Constant for qualifier with value TITA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TITA = "TITA";
		[Obsolete]
		public const string TITA = "TITA";

		/// <summary>
		/// Constant for qualifier with value UNALL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String UNALL = "UNALL";
		[Obsolete]
		public const string UNALL = "UNALL";

		/// <summary>
		/// Constant for qualifier with value VREN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String VREN = "VREN";
		[Obsolete]
		public const string VREN = "VREN";

		/// <summary>
		/// Constant for qualifier with value ZINC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ZINC = "ZINC";
		[Obsolete]
		public const string ZINC = "ZINC";

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT620 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT620 content </param>
		public MT620(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT620 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT620 content, the parameter can not be null </param>
		/// <seealso cref= #MT620(String) </seealso>
		public MT620(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT620 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT620 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT620(String)
		/// @since 7.7 </seealso>
		public static MT620 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT620(m);
		}

		/// <summary>
		/// Creates and initializes a new MT620 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT620() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT620 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT620(final String sender, final String receiver)
		public MT620(string sender, string receiver) : base(620, sender, receiver)
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
		/// <seealso cref= #MT620(String, String) </seealso>
		/// @deprecated Use instead <code>new MT620(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT620(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT620(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT620(sender, receiver)</code> instead")]
		public MT620(int messageType, string sender, string receiver) : base(620, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT620(int, String, String)", "Use the constructor MT620(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT620 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT620(final String fin)
		public MT620(string fin) : base()
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
				log.warning("Creating an MT620 object from FIN content with a Service Message. Check if the MT620 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT620 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT620 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT620 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT620 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT620 parse(final String fin)
		public static MT620 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT620(fin);
		}

		/// <summary>
		/// Creates a new MT620 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT620(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT620(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT620 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT620 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT620 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT620 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT620(stream);
		}

		/// <summary>
		/// Creates a new MT620 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT620(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT620(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT620 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT620 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT620 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT620 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT620(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "620";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT620 append(final SwiftTagListBlock block)
		public override MT620 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT620 append(final Tag... tags)
		public override MT620 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT620 append(final Field... fields)
		public override MT620 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT620 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT620 message </param>
		/// <returns> a new instance of MT620
		/// @since 7.10.3 </returns>
		public static MT620 fromJson(string json)
		{
			return (MT620) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 15A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15A at MT620 is expected to be the only one.
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
		/// The first occurrence of field 20 at MT620 is expected to be the only one.
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
		/// The first occurrence of field 21 at MT620 is expected to be the only one.
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
		/// The first occurrence of field 22A at MT620 is expected to be the only one.
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
		/// The first occurrence of field 94A at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 22B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 22B at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field22B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field22B Field22B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("22B");
				Tag t = tag("22B");
				if (t != null)
				{
					return new Field22B(t.Value);
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
		/// The first occurrence of field 21N at MT620 is expected to be the only one.
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
		/// The first occurrence of field 82A at MT620 is expected to be the only one.
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
		/// The first occurrence of field 82D at MT620 is expected to be the only one.
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
		/// The first occurrence of field 82J at MT620 is expected to be the only one.
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
		/// The first occurrence of field 87A at MT620 is expected to be the only one.
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
		/// The first occurrence of field 87D at MT620 is expected to be the only one.
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
		/// The first occurrence of field 87J at MT620 is expected to be the only one.
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
		/// The first occurrence of field 83A at MT620 is expected to be the only one.
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
		/// The first occurrence of field 83D at MT620 is expected to be the only one.
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
		/// The first occurrence of field 83J at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 26C, 
		/// or null if none is found.<br>
		/// The first occurrence of field 26C at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field26C object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field26C Field26C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("26C");
				Tag t = tag("26C");
				if (t != null)
				{
					return new Field26C(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 77D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 77D at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field77D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field77D Field77D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("77D");
				Tag t = tag("77D");
				if (t != null)
				{
					return new Field77D(t.Value);
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
		/// The first occurrence of field 15B at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 17R, 
		/// or null if none is found.<br>
		/// The first occurrence of field 17R at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field17R object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field17R Field17R
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("17R");
				Tag t = tag("17R");
				if (t != null)
				{
					return new Field17R(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 30T, 
		/// or null if none is found.<br>
		/// The first occurrence of field 30T at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field30T object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field30T Field30T
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("30T");
				Tag t = tag("30T");
				if (t != null)
				{
					return new Field30T(t.Value);
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
		/// The first occurrence of field 30V at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 30P, 
		/// or null if none is found.<br>
		/// The first occurrence of field 30P at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field30P object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field30P Field30P
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("30P");
				Tag t = tag("30P");
				if (t != null)
				{
					return new Field30P(t.Value);
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
		/// The first occurrence of field 32B at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 32F, 
		/// or null if none is found.<br>
		/// The first occurrence of field 32F at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field32F object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field32F Field32F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("32F");
				Tag t = tag("32F");
				if (t != null)
				{
					return new Field32F(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 32H, 
		/// or null if none is found.<br>
		/// The first occurrence of field 32H at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field32H object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field32H Field32H
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("32H");
				Tag t = tag("32H");
				if (t != null)
				{
					return new Field32H(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 32R, 
		/// or null if none is found.<br>
		/// The first occurrence of field 32R at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field32R object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field32R Field32R
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("32R");
				Tag t = tag("32R");
				if (t != null)
				{
					return new Field32R(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 30X, 
		/// or null if none is found.<br>
		/// The first occurrence of field 30X at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field30X object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field30X Field30X
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("30X");
				Tag t = tag("30X");
				if (t != null)
				{
					return new Field30X(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 34E, 
		/// or null if none is found.<br>
		/// The first occurrence of field 34E at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field34E object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field34E Field34E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("34E");
				Tag t = tag("34E");
				if (t != null)
				{
					return new Field34E(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 34J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 34J at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field34J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field34J Field34J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("34J");
				Tag t = tag("34J");
				if (t != null)
				{
					return new Field34J(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 37G, 
		/// or null if none is found.<br>
		/// The first occurrence of field 37G at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field37G object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field37G Field37G
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("37G");
				Tag t = tag("37G");
				if (t != null)
				{
					return new Field37G(t.Value);
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
		/// The first occurrence of field 14D at MT620 is expected to be the only one.
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
		/// The first occurrence of field 30F at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 38J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 38J at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field38J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field38J Field38J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("38J");
				Tag t = tag("38J");
				if (t != null)
				{
					return new Field38J(t.Value);
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
		/// The first occurrence of field 15C at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 15D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15D at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 15E, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15E at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field15E object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field15E Field15E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("15E");
				Tag t = tag("15E");
				if (t != null)
				{
					return new Field15E(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 15F, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15F at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field15F object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field15F Field15F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("15F");
				Tag t = tag("15F");
				if (t != null)
				{
					return new Field15F(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 15G, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15G at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field15G object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field15G Field15G
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("15G");
				Tag t = tag("15G");
				if (t != null)
				{
					return new Field15G(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 37L, 
		/// or null if none is found.<br>
		/// The first occurrence of field 37L at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field37L object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field37L Field37L
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("37L");
				Tag t = tag("37L");
				if (t != null)
				{
					return new Field37L(t.Value);
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
		/// The first occurrence of field 33B at MT620 is expected to be the only one.
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
		/// The first occurrence of field 36 at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 33E, 
		/// or null if none is found.<br>
		/// The first occurrence of field 33E at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field33E object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field33E Field33E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("33E");
				Tag t = tag("33E");
				if (t != null)
				{
					return new Field33E(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 15H, 
		/// or null if none is found.<br>
		/// The first occurrence of field 15H at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field15H object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field15H Field15H
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("15H");
				Tag t = tag("15H");
				if (t != null)
				{
					return new Field15H(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 29A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 29A at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field29A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field29A Field29A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("29A");
				Tag t = tag("29A");
				if (t != null)
				{
					return new Field29A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 24D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 24D at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field24D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field24D Field24D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("24D");
				Tag t = tag("24D");
				if (t != null)
				{
					return new Field24D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 84A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 84A at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field84A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field84A Field84A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("84A");
				Tag t = tag("84A");
				if (t != null)
				{
					return new Field84A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 84B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 84B at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field84B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field84B Field84B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("84B");
				Tag t = tag("84B");
				if (t != null)
				{
					return new Field84B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 84D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 84D at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field84D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field84D Field84D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("84D");
				Tag t = tag("84D");
				if (t != null)
				{
					return new Field84D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 84J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 84J at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field84J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field84J Field84J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("84J");
				Tag t = tag("84J");
				if (t != null)
				{
					return new Field84J(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 85A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 85A at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field85A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field85A Field85A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("85A");
				Tag t = tag("85A");
				if (t != null)
				{
					return new Field85A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 85B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 85B at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field85B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field85B Field85B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("85B");
				Tag t = tag("85B");
				if (t != null)
				{
					return new Field85B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 85D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 85D at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field85D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field85D Field85D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("85D");
				Tag t = tag("85D");
				if (t != null)
				{
					return new Field85D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 85J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 85J at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field85J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field85J Field85J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("85J");
				Tag t = tag("85J");
				if (t != null)
				{
					return new Field85J(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 88A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 88A at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field88A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field88A Field88A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("88A");
				Tag t = tag("88A");
				if (t != null)
				{
					return new Field88A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 88D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 88D at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field88D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field88D Field88D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("88D");
				Tag t = tag("88D");
				if (t != null)
				{
					return new Field88D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 88J, 
		/// or null if none is found.<br>
		/// The first occurrence of field 88J at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field88J object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field88J Field88J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("88J");
				Tag t = tag("88J");
				if (t != null)
				{
					return new Field88J(t.Value);
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
		/// The first occurrence of field 71F at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 26H, 
		/// or null if none is found.<br>
		/// The first occurrence of field 26H at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field26H object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field26H Field26H
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("26H");
				Tag t = tag("26H");
				if (t != null)
				{
					return new Field26H(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 21G, 
		/// or null if none is found.<br>
		/// The first occurrence of field 21G at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field21G object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field21G Field21G
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("21G");
				Tag t = tag("21G");
				if (t != null)
				{
					return new Field21G(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 22Z, 
		/// or null if none is found.<br>
		/// The first occurrence of field 22Z at MT620 is expected to be the only one.
		/// </summary>
		/// <returns> a Field22Z object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field22Z Field22Z
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("22Z");
				Tag t = tag("22Z");
				if (t != null)
				{
					return new Field22Z(t.Value);
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
		/// The first occurrence of field 72 at MT620 is expected to be the only one.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 53A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 53A at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field53A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field53A> Field53A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field53A> result = new java.util.ArrayList<>();
				IList<Field53A> result = new List<Field53A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("53A");
				Tag[] tags = tags("53A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field53A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 53D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 53D at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field53D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field53D> Field53D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field53D> result = new java.util.ArrayList<>();
				IList<Field53D> result = new List<Field53D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("53D");
				Tag[] tags = tags("53D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field53D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 53J, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 53J at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field53J objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field53J> Field53J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field53J> result = new java.util.ArrayList<>();
				IList<Field53J> result = new List<Field53J>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("53J");
				Tag[] tags = tags("53J");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field53J(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 86A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 86A at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field86A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field86A> Field86A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field86A> result = new java.util.ArrayList<>();
				IList<Field86A> result = new List<Field86A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("86A");
				Tag[] tags = tags("86A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field86A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 86D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 86D at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field86D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field86D> Field86D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field86D> result = new java.util.ArrayList<>();
				IList<Field86D> result = new List<Field86D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("86D");
				Tag[] tags = tags("86D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field86D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 86J, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 86J at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field86J objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field86J> Field86J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field86J> result = new java.util.ArrayList<>();
				IList<Field86J> result = new List<Field86J>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("86J");
				Tag[] tags = tags("86J");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field86J(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 56A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 56A at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field56A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field56A> Field56A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field56A> result = new java.util.ArrayList<>();
				IList<Field56A> result = new List<Field56A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("56A");
				Tag[] tags = tags("56A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field56A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 56D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 56D at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field56D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field56D> Field56D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field56D> result = new java.util.ArrayList<>();
				IList<Field56D> result = new List<Field56D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("56D");
				Tag[] tags = tags("56D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field56D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 56J, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 56J at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field56J objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field56J> Field56J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field56J> result = new java.util.ArrayList<>();
				IList<Field56J> result = new List<Field56J>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("56J");
				Tag[] tags = tags("56J");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field56J(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 57A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 57A at MT620 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 57D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 57D at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field57D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field57D> Field57D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field57D> result = new java.util.ArrayList<>();
				IList<Field57D> result = new List<Field57D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("57D");
				Tag[] tags = tags("57D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field57D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 57J, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 57J at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field57J objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field57J> Field57J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field57J> result = new java.util.ArrayList<>();
				IList<Field57J> result = new List<Field57J>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("57J");
				Tag[] tags = tags("57J");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field57J(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 58A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 58A at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field58A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field58A> Field58A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field58A> result = new java.util.ArrayList<>();
				IList<Field58A> result = new List<Field58A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("58A");
				Tag[] tags = tags("58A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field58A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 58D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 58D at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field58D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field58D> Field58D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field58D> result = new java.util.ArrayList<>();
				IList<Field58D> result = new List<Field58D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("58D");
				Tag[] tags = tags("58D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field58D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 58J, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 58J at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field58J objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field58J> Field58J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field58J> result = new java.util.ArrayList<>();
				IList<Field58J> result = new List<Field58J>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("58J");
				Tag[] tags = tags("58J");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field58J(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 33J, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 33J at MT620 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field33J objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field33J> Field33J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field33J> result = new java.util.ArrayList<>();
				IList<Field33J> result = new List<Field33J>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("33J");
				Tag[] tags = tags("33J");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field33J(tag.Value));
					}
				}
				return result;
			}
		}


	// BaseSequenceCodeGenerator [seq=A]
		/// <summary>
		/// Class to model Sequence "A" in MT 620
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
		/// Class to model Sequence "B" in MT 620
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
		/// Class to model Sequence "C" in MT 620
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
		/// Class to model Sequence "D" in MT 620
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


	// BaseSequenceCodeGenerator [seq=E]
		/// <summary>
		/// Class to model Sequence "E" in MT 620
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.SPLIT_BY_15) public static class SequenceE extends SwiftTagListBlock
		public class SequenceE : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceE() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceE(final SwiftTagListBlock content)
			internal SequenceE(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			public static readonly Tag START_TAG = Field15E.emptyTag();
			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public static SequenceE newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceE newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE result = new SequenceE();
				SequenceE result = new SequenceE();
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
			public static SequenceE newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE result = new SequenceE();
				SequenceE result = new SequenceE();
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
//ORIGINAL LINE: public static SequenceE newInstance(final SwiftTagListBlock... sequences)
			public static SequenceE newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE result = new SequenceE();
				SequenceE result = new SequenceE();
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
		/// Get the single occurrence of SequenceE using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// 
		/// @since 7.7 </summary>
		/// <returns> a new sequence that may be empty, <em>never returns null</em> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceE getSequenceE()
		public virtual SequenceE SequenceE
		{
			get
			{
				return getSequenceE(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceE using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// </summary>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceE within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceE getSequenceE(SwiftTagListBlock parentSequence)
		public virtual SequenceE getSequenceE(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Map<String, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			IDictionary<string, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			if (map.ContainsKey("E"))
			{
				return new SequenceE(map["E"]);
			}
			return new SequenceE();
		}


	// BaseSequenceCodeGenerator [seq=F]
		/// <summary>
		/// Class to model Sequence "F" in MT 620
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.SPLIT_BY_15) public static class SequenceF extends SwiftTagListBlock
		public class SequenceF : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceF() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceF(final SwiftTagListBlock content)
			internal SequenceF(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			public static readonly Tag START_TAG = Field15F.emptyTag();
			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public static SequenceF newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceF newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceF result = new SequenceF();
				SequenceF result = new SequenceF();
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
			public static SequenceF newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceF result = new SequenceF();
				SequenceF result = new SequenceF();
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
//ORIGINAL LINE: public static SequenceF newInstance(final SwiftTagListBlock... sequences)
			public static SequenceF newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceF result = new SequenceF();
				SequenceF result = new SequenceF();
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
		/// Get the single occurrence of SequenceF using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// 
		/// @since 7.7 </summary>
		/// <returns> a new sequence that may be empty, <em>never returns null</em> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceF getSequenceF()
		public virtual SequenceF SequenceF
		{
			get
			{
				return getSequenceF(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceF using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// </summary>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceF within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceF getSequenceF(SwiftTagListBlock parentSequence)
		public virtual SequenceF getSequenceF(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Map<String, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			IDictionary<string, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			if (map.ContainsKey("F"))
			{
				return new SequenceF(map["F"]);
			}
			return new SequenceF();
		}


	// BaseSequenceCodeGenerator [seq=G]
		/// <summary>
		/// Class to model Sequence "G" in MT 620
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.SPLIT_BY_15) public static class SequenceG extends SwiftTagListBlock
		public class SequenceG : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceG() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceG(final SwiftTagListBlock content)
			internal SequenceG(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			public static readonly Tag START_TAG = Field15G.emptyTag();
			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public static SequenceG newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceG newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceG result = new SequenceG();
				SequenceG result = new SequenceG();
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
			public static SequenceG newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceG result = new SequenceG();
				SequenceG result = new SequenceG();
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
//ORIGINAL LINE: public static SequenceG newInstance(final SwiftTagListBlock... sequences)
			public static SequenceG newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceG result = new SequenceG();
				SequenceG result = new SequenceG();
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
		/// Get the single occurrence of SequenceG using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// 
		/// @since 7.7 </summary>
		/// <returns> a new sequence that may be empty, <em>never returns null</em> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceG getSequenceG()
		public virtual SequenceG SequenceG
		{
			get
			{
				return getSequenceG(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceG using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// </summary>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceG within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceG getSequenceG(SwiftTagListBlock parentSequence)
		public virtual SequenceG getSequenceG(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Map<String, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			IDictionary<string, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			if (map.ContainsKey("G"))
			{
				return new SequenceG(map["G"]);
			}
			return new SequenceG();
		}


	// BaseSequenceCodeGenerator [seq=G1]
		/// <summary>
		/// Class to model Sequence "G1" in MT 620
		/// </summary>
		public class SequenceG1 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceG1() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceG1(final SwiftTagListBlock content)
			internal SequenceG1(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// First mandatory tag name of the sequence: <em>"37L"  </em>.
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			public static readonly string[] START = new string[] {"37L"};

			/// <summary>
			/// Last mandatory tag name of the sequence: <em>"33B", "33J"  </em>
			/// Array format is for cases when more than one letter options is allowed
			/// </summary>
			protected internal static readonly string[] END = new string[] {"33B", "33J"};

			/// <summary>
			/// List of optional tags after the last mandatory tag
			/// </summary>
			protected internal static readonly string[] TAIL = new string[]{ };

			/// <summary>
			/// Same as <seealso cref="#newInstance(int, int, Tag...)"/> using zero for the indexes </summary>
			/// <param name="tags"> the list of tags to set as sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public static SequenceG1 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceG1 newInstance(params Tag[] tags)
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public static SequenceG1 newInstance(final int start, final int end, final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceG1 newInstance(int start, int end, params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceG1 result = new SequenceG1();
				SequenceG1 result = new SequenceG1();
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
		 /// Get the single occurrence of SequenceG1 delimited by leading tag and end, with an optional tail.
		 /// The presence of this method indicates that this sequence can occur only once according to the Standard.
		 /// If block 4 is empty this method returns null.
		 /// </summary>
		 /// <returns> the found sequence or an empty sequence if none is found </returns>
		 /// <seealso cref= SwiftTagListBlock#getSubBlockDelimitedWithOptionalTail(String[], String[], String[]) </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public SequenceG1 getSequenceG1()
		public virtual SequenceG1 SequenceG1
		{
			get
			{
				return getSequenceG1(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceG1 delimited by leading tag and end, with an optional tail.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// If block 4 is empty this method returns null.
		/// </summary>
		/// <seealso cref= SwiftTagListBlock#getSubBlockDelimitedWithOptionalTail(String[], String[], String[]) </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceG1 within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL) public SequenceG1 getSequenceG1(SwiftTagListBlock parentSequence)
		public virtual SequenceG1 getSequenceG1(SwiftTagListBlock parentSequence)
		{
			if (parentSequence != null && !parentSequence.Empty)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock content = parentSequence.getSubBlockDelimitedWithOptionalTail(SequenceG1.START, SequenceG1.END, SequenceG1.TAIL);
				SwiftTagListBlock content = parentSequence.getSubBlockDelimitedWithOptionalTail(SequenceG1.START, SequenceG1.END, SequenceG1.TAIL);
				if (log.isLoggable(java.util.logging.Level.FINE))
				{
					if (content == null)
					{
						log.fine("content for sequence SequenceG1: is null");
					}
					else
					{
						log.fine("content for sequence SequenceG1: " + content.tagNamesList());
					}
				}
				if (content == null)
				{
					return new SequenceG1();
				}
				else
				{
					return new SequenceG1(content);
				}
			}
			return null;
		}


	// BaseSequenceCodeGenerator [seq=H]
		/// <summary>
		/// Class to model Sequence "H" in MT 620
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.SPLIT_BY_15) public static class SequenceH extends SwiftTagListBlock
		public class SequenceH : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceH() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceH(final SwiftTagListBlock content)
			internal SequenceH(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			public static readonly Tag START_TAG = Field15H.emptyTag();
			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags
			/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public static SequenceH newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceH newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceH result = new SequenceH();
				SequenceH result = new SequenceH();
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
			public static SequenceH newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceH result = new SequenceH();
				SequenceH result = new SequenceH();
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
//ORIGINAL LINE: public static SequenceH newInstance(final SwiftTagListBlock... sequences)
			public static SequenceH newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceH result = new SequenceH();
				SequenceH result = new SequenceH();
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
		/// Get the single occurrence of SequenceH using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// 
		/// @since 7.7 </summary>
		/// <returns> a new sequence that may be empty, <em>never returns null</em> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceH getSequenceH()
		public virtual SequenceH SequenceH
		{
			get
			{
				return getSequenceH(base.SwiftMessageNotNullOrException.Block4);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceH using field field 15 as sequence boundary.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard.
		/// </summary>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceH within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.SPLIT_BY_15) public SequenceH getSequenceH(SwiftTagListBlock parentSequence)
		public virtual SequenceH getSequenceH(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Map<String, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			IDictionary<string, SwiftTagListBlock> map = SwiftMessageUtils.splitByField15(parentSequence);
			if (map.ContainsKey("H"))
			{
				return new SequenceH(map["H"]);
			}
			return new SequenceH();
		}




	}

}