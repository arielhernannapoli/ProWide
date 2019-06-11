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
namespace com.prowidesoftware.swift.model.mt.mt6xx
{




	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 607 - Commodity Credit Advice</strong>
	/// 
	/// <para>
	/// SWIFT MT607 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="field">Field 20  (M)</li>
	/// <li class="field">Field 21  (M)</li>
	/// <li class="field">Field 26 C (M)</li>
	/// <li class="field">Field 25  (O)</li>
	/// <li class="field">Field 26 D (O)</li>
	/// <li class="field">Field 30  (M)</li>
	/// <li class="field">Field 32 F (M)</li>
	/// <li class="field">Field 82 A,D (O)</li>
	/// <li class="field">Field 86 A,B,D (O)</li>
	/// <li class="field">Field 87 A,D (O)</li>
	/// <li class="field">Field 88 A,B,D (O)</li>
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
//ORIGINAL LINE: @Generated public class MT607 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT607 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT607).FullName);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "607";

	// begin qualifiers constants	

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
		/// Constant for qualifier with value ANUG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ANUG = "ANUG";
		[Obsolete]
		public const string ANUG = "ANUG";

		/// <summary>
		/// Constant for qualifier with value BRIT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BRIT = "BRIT";
		[Obsolete]
		public const string BRIT = "BRIT";

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
		/// Constant for qualifier with value FOZ 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FOZ = "FOZ";
		[Obsolete]
		public const string FOZ = "FOZ";

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
		/// Constant for qualifier with value GOZ 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String GOZ = "GOZ";
		[Obsolete]
		public const string GOZ = "GOZ";

		/// <summary>
		/// Constant for qualifier with value GRM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String GRM = "GRM";
		[Obsolete]
		public const string GRM = "GRM";

		/// <summary>
		/// Constant for qualifier with value IRID 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String IRID = "IRID";
		[Obsolete]
		public const string IRID = "IRID";

		/// <summary>
		/// Constant for qualifier with value KLO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String KLO = "KLO";
		[Obsolete]
		public const string KLO = "KLO";

		/// <summary>
		/// Constant for qualifier with value KRUG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String KRUG = "KRUG";
		[Obsolete]
		public const string KRUG = "KRUG";

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
		/// Constant for qualifier with value LIT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LIT = "LIT";
		[Obsolete]
		public const string LIT = "LIT";

		/// <summary>
		/// Constant for qualifier with value LOC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOC = "LOC";
		[Obsolete]
		public const string LOC = "LOC";

		/// <summary>
		/// Constant for qualifier with value LOT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOT = "LOT";
		[Obsolete]
		public const string LOT = "LOT";

		/// <summary>
		/// Constant for qualifier with value MAPL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MAPL = "MAPL";
		[Obsolete]
		public const string MAPL = "MAPL";

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
		/// Constant for qualifier with value PLAT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PLAT = "PLAT";
		[Obsolete]
		public const string PLAT = "PLAT";

		/// <summary>
		/// Constant for qualifier with value PND 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PND = "PND";
		[Obsolete]
		public const string PND = "PND";

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
		/// Constant for qualifier with value TAL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TAL = "TAL";
		[Obsolete]
		public const string TAL = "TAL";

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
		/// Constant for qualifier with value TOL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TOL = "TOL";
		[Obsolete]
		public const string TOL = "TOL";

		/// <summary>
		/// Constant for qualifier with value TON 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TON = "TON";
		[Obsolete]
		public const string TON = "TON";

		/// <summary>
		/// Constant for qualifier with value TOZ 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TOZ = "TOZ";
		[Obsolete]
		public const string TOZ = "TOZ";

		/// <summary>
		/// Constant for qualifier with value UNALL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String UNALL = "UNALL";
		[Obsolete]
		public const string UNALL = "UNALL";

		/// <summary>
		/// Constant for qualifier with value UNT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String UNT = "UNT";
		[Obsolete]
		public const string UNT = "UNT";

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
		/// Creates an MT607 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT607 content </param>
		public MT607(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT607 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT607 content, the parameter can not be null </param>
		/// <seealso cref= #MT607(String) </seealso>
		public MT607(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT607 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT607 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT607(String)
		/// @since 7.7 </seealso>
		public static MT607 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT607(m);
		}

		/// <summary>
		/// Creates and initializes a new MT607 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT607() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT607 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT607(final String sender, final String receiver)
		public MT607(string sender, string receiver) : base(607, sender, receiver)
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
		/// <seealso cref= #MT607(String, String) </seealso>
		/// @deprecated Use instead <code>new MT607(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT607(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT607(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT607(sender, receiver)</code> instead")]
		public MT607(int messageType, string sender, string receiver) : base(607, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT607(int, String, String)", "Use the constructor MT607(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT607 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT607(final String fin)
		public MT607(string fin) : base()
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
				log.warning("Creating an MT607 object from FIN content with a Service Message. Check if the MT607 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT607 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT607 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT607 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT607 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT607 parse(final String fin)
		public static MT607 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT607(fin);
		}

		/// <summary>
		/// Creates a new MT607 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT607(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT607(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT607 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT607 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT607 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT607 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT607(stream);
		}

		/// <summary>
		/// Creates a new MT607 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT607(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT607(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT607 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT607 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT607 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT607 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT607(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "607";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT607 append(final SwiftTagListBlock block)
		public override MT607 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT607 append(final Tag... tags)
		public override MT607 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT607 append(final Field... fields)
		public override MT607 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT607 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT607 message </param>
		/// <returns> a new instance of MT607
		/// @since 7.10.3 </returns>
		public static MT607 fromJson(string json)
		{
			return (MT607) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 20, 
		/// or null if none is found.<br>
		/// The first occurrence of field 20 at MT607 is expected to be the only one.
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
		/// The first occurrence of field 21 at MT607 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 26C, 
		/// or null if none is found.<br>
		/// The first occurrence of field 26C at MT607 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 25, 
		/// or null if none is found.<br>
		/// The first occurrence of field 25 at MT607 is expected to be the only one.
		/// </summary>
		/// <returns> a Field25 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field25 Field25
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("25");
				Tag t = tag("25");
				if (t != null)
				{
					return new Field25(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 26D, 
		/// or null if none is found.<br>
		/// The first occurrence of field 26D at MT607 is expected to be the only one.
		/// </summary>
		/// <returns> a Field26D object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field26D Field26D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("26D");
				Tag t = tag("26D");
				if (t != null)
				{
					return new Field26D(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 30, 
		/// or null if none is found.<br>
		/// The first occurrence of field 30 at MT607 is expected to be the only one.
		/// </summary>
		/// <returns> a Field30 object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field30 Field30
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("30");
				Tag t = tag("30");
				if (t != null)
				{
					return new Field30(t.Value);
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
		/// The first occurrence of field 32F at MT607 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 82A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 82A at MT607 is expected to be the only one.
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
		/// The first occurrence of field 82D at MT607 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 86A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 86A at MT607 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 86B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 86B at MT607 is expected to be the only one.
		/// </summary>
		/// <returns> a Field86B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field86B Field86B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("86B");
				Tag t = tag("86B");
				if (t != null)
				{
					return new Field86B(t.Value);
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
		/// The first occurrence of field 86D at MT607 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 87A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 87A at MT607 is expected to be the only one.
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
		/// The first occurrence of field 87D at MT607 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 88A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 88A at MT607 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 88B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 88B at MT607 is expected to be the only one.
		/// </summary>
		/// <returns> a Field88B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field88B Field88B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("88B");
				Tag t = tag("88B");
				if (t != null)
				{
					return new Field88B(t.Value);
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
		/// The first occurrence of field 88D at MT607 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 72, 
		/// or null if none is found.<br>
		/// The first occurrence of field 72 at MT607 is expected to be the only one.
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




	}

}