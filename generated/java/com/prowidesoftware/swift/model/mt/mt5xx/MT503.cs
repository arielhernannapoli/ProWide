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
namespace com.prowidesoftware.swift.model.mt.mt5xx
{




	using StringUtils = org.apache.commons.lang3.StringUtils;

	using com.prowidesoftware.swift.model;
	using com.prowidesoftware.swift.@internal;
	using Type = com.prowidesoftware.swift.@internal.SequenceStyle.Type;
	using com.prowidesoftware.swift.model.field;
	using Lib = com.prowidesoftware.swift.utils.Lib;

	/// <summary>
	/// <strong>MT 503 - Collateral Claim</strong>
	/// 
	/// <para>
	/// SWIFT MT503 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="sequence">
	/// Sequence A - General Information (M)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 20
	/// (M) (repetitive)<ul><li>FieldsetItem 20 C (M)</li><li>FieldsetItem 20 C (O)</li><li>FieldsetItem 20 C (O)</li></ul></li><li class="field">Field 23 G (M)</li>
	/// <li class="sequence">
	/// Sequence A1 - Agreement (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 22 F (O)</li>
	/// <li class="field">Field 98 A (O)</li>
	/// <li class="field">Field 13 B (O)</li>
	/// <li class="field">Field 70 C (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 98 A,C,E (O)</li>
	/// <li class="fieldset">
	/// Fieldset 22
	/// (M)<ul><li>FieldsetItem 22 H (M)</li><li>FieldsetItem 22 F,H (M)</li></ul></li><li class="fieldset">
	/// Fieldset 95
	/// (M)<ul><li>FieldsetItem 95 P,Q,R (M)</li><li>FieldsetItem 95 P,Q,R (M)</li></ul></li><li class="field">Field 70 C (O)</li>
	/// <li class="sequence">
	/// Sequence A2 - Linkages (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 13 A,B (O)</li>
	/// <li class="field">Field 20 C (M)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence B - Summary (M)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 95 P,Q,R (O)</li>
	/// <li class="fieldset">
	/// Fieldset 19
	/// (M) (repetitive)<ul><li>FieldsetItem 19 B (M)</li><li>FieldsetItem 19 B (M)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li></ul></li><li class="sequence">
	/// Sequence B1 - Summary Details (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 19
	/// (O)<ul><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li></ul></li><li class="fieldset">
	/// Fieldset 98
	/// (O)<ul><li>FieldsetItem 98 A,C (O)</li><li>FieldsetItem 98 A,C (O)</li><li>FieldsetItem 98 A (O)</li></ul></li><li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence C - Collateral Details (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 20 C (M)</li>
	/// <li class="fieldset">
	/// Fieldset 22
	/// (M) (repetitive)<ul><li>FieldsetItem 22 H (M)</li><li>FieldsetItem 22 H (M)</li><li>FieldsetItem 22 F,H (O)</li></ul></li><li class="field">Field 98 A (O)</li>
	/// <li class="sequence">
	/// Sequence C1 - Securities Collateral Details (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 35 B (M)</li>
	/// <li class="field">Field 36 B (M)</li>
	/// <li class="field">Field 17 B (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence C2 - Cash Collateral Details (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 19 B (M)</li>
	/// <li class="field">Field 22 H (M)</li>
	/// <li class="field">Field 98 A (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence C3 - Other Collateral Details (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 22 H (M)</li>
	/// <li class="fieldset">
	/// Fieldset 98
	/// (M) (repetitive)<ul><li>FieldsetItem 98 A (M)</li><li>FieldsetItem 98 A,B (O)</li></ul></li><li class="field">Field 95 P,Q,R (M)</li>
	/// <li class="field">Field 19 B (M)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence D - Additional Information (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 95
	/// (O)<ul><li>FieldsetItem 95 P,Q,R (O)</li><li>FieldsetItem 95 P,Q,R (O)</li></ul></li><li class="field">Field 16 S (M)</li>
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
//ORIGINAL LINE: @Generated public class MT503 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT503 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT503).Name);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "503";

	// begin qualifiers constants	

		/// <summary>
		/// Constant for qualifier with value ADDINFO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ADDINFO = "ADDINFO";
		[Obsolete]
		public const string ADDINFO = "ADDINFO";

		/// <summary>
		/// Constant for qualifier with value AEXP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AEXP = "AEXP";
		[Obsolete]
		public const string AEXP = "AEXP";

		/// <summary>
		/// Constant for qualifier with value AGRE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AGRE = "AGRE";
		[Obsolete]
		public const string AGRE = "AGRE";

		/// <summary>
		/// Constant for qualifier with value BCOL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BCOL = "BCOL";
		[Obsolete]
		public const string BCOL = "BCOL";

		/// <summary>
		/// Constant for qualifier with value CANC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CANC = "CANC";
		[Obsolete]
		public const string CANC = "CANC";

		/// <summary>
		/// Constant for qualifier with value CCAL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CCAL = "CCAL";
		[Obsolete]
		public const string CCAL = "CCAL";

		/// <summary>
		/// Constant for qualifier with value CCOL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CCOL = "CCOL";
		[Obsolete]
		public const string CCOL = "CCOL";

		/// <summary>
		/// Constant for qualifier with value COAL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COAL = "COAL";
		[Obsolete]
		public const string COAL = "COAL";

		/// <summary>
		/// Constant for qualifier with value CODU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CODU = "CODU";
		[Obsolete]
		public const string CODU = "CODU";

		/// <summary>
		/// Constant for qualifier with value COLA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COLA = "COLA";
		[Obsolete]
		public const string COLA = "COLA";

		/// <summary>
		/// Constant for qualifier with value COLD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COLD = "COLD";
		[Obsolete]
		public const string COLD = "COLD";

		/// <summary>
		/// Constant for qualifier with value COLL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COLL = "COLL";
		[Obsolete]
		public const string COLL = "COLL";

		/// <summary>
		/// Constant for qualifier with value COLR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COLR = "COLR";
		[Obsolete]
		public const string COLR = "COLR";

		/// <summary>
		/// Constant for qualifier with value COPY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COPY = "COPY";
		[Obsolete]
		public const string COPY = "COPY";

		/// <summary>
		/// Constant for qualifier with value CORE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CORE = "CORE";
		[Obsolete]
		public const string CORE = "CORE";

		/// <summary>
		/// Constant for qualifier with value COVA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COVA = "COVA";
		[Obsolete]
		public const string COVA = "COVA";

		/// <summary>
		/// Constant for qualifier with value CRET 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CRET = "CRET";
		[Obsolete]
		public const string CRET = "CRET";

		/// <summary>
		/// Constant for qualifier with value DEPO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DEPO = "DEPO";
		[Obsolete]
		public const string DEPO = "DEPO";

		/// <summary>
		/// Constant for qualifier with value DUPL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DUPL = "DUPL";
		[Obsolete]
		public const string DUPL = "DUPL";

		/// <summary>
		/// Constant for qualifier with value EXPI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EXPI = "EXPI";
		[Obsolete]
		public const string EXPI = "EXPI";

		/// <summary>
		/// Constant for qualifier with value EXPP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EXPP = "EXPP";
		[Obsolete]
		public const string EXPP = "EXPP";

		/// <summary>
		/// Constant for qualifier with value GENL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String GENL = "GENL";
		[Obsolete]
		public const string GENL = "GENL";

		/// <summary>
		/// Constant for qualifier with value GUAR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String GUAR = "GUAR";
		[Obsolete]
		public const string GUAR = "GUAR";

		/// <summary>
		/// Constant for qualifier with value INOU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INOU = "INOU";
		[Obsolete]
		public const string INOU = "INOU";

		/// <summary>
		/// Constant for qualifier with value ISSU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ISSU = "ISSU";
		[Obsolete]
		public const string ISSU = "ISSU";

		/// <summary>
		/// Constant for qualifier with value LINK 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LINK = "LINK";
		[Obsolete]
		public const string LINK = "LINK";

		/// <summary>
		/// Constant for qualifier with value LOCR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOCR = "LOCR";
		[Obsolete]
		public const string LOCR = "LOCR";

		/// <summary>
		/// Constant for qualifier with value MEOR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MEOR = "MEOR";
		[Obsolete]
		public const string MEOR = "MEOR";

		/// <summary>
		/// Constant for qualifier with value MERE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MERE = "MERE";
		[Obsolete]
		public const string MERE = "MERE";

		/// <summary>
		/// Constant for qualifier with value MITR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MITR = "MITR";
		[Obsolete]
		public const string MITR = "MITR";

		/// <summary>
		/// Constant for qualifier with value NEWM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NEWM = "NEWM";
		[Obsolete]
		public const string NEWM = "NEWM";

		/// <summary>
		/// Constant for qualifier with value NRAD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NRAD = "NRAD";
		[Obsolete]
		public const string NRAD = "NRAD";

		/// <summary>
		/// Constant for qualifier with value OWNF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OWNF = "OWNF";
		[Obsolete]
		public const string OWNF = "OWNF";

		/// <summary>
		/// Constant for qualifier with value PACO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PACO = "PACO";
		[Obsolete]
		public const string PACO = "PACO";

		/// <summary>
		/// Constant for qualifier with value PREP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PREP = "PREP";
		[Obsolete]
		public const string PREP = "PREP";

		/// <summary>
		/// Constant for qualifier with value PREV 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PREV = "PREV";
		[Obsolete]
		public const string PREV = "PREV";

		/// <summary>
		/// Constant for qualifier with value PRHA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PRHA = "PRHA";
		[Obsolete]
		public const string PRHA = "PRHA";

		/// <summary>
		/// Constant for qualifier with value PTYA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PTYA = "PTYA";
		[Obsolete]
		public const string PTYA = "PTYA";

		/// <summary>
		/// Constant for qualifier with value PTYB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PTYB = "PTYB";
		[Obsolete]
		public const string PTYB = "PTYB";

		/// <summary>
		/// Constant for qualifier with value RADD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RADD = "RADD";
		[Obsolete]
		public const string RADD = "RADD";

		/// <summary>
		/// Constant for qualifier with value RCTR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RCTR = "RCTR";
		[Obsolete]
		public const string RCTR = "RCTR";

		/// <summary>
		/// Constant for qualifier with value RELA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RELA = "RELA";
		[Obsolete]
		public const string RELA = "RELA";

		/// <summary>
		/// Constant for qualifier with value ROUN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ROUN = "ROUN";
		[Obsolete]
		public const string ROUN = "ROUN";

		/// <summary>
		/// Constant for qualifier with value RSET 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RSET = "RSET";
		[Obsolete]
		public const string RSET = "RSET";

		/// <summary>
		/// Constant for qualifier with value SCOL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SCOL = "SCOL";
		[Obsolete]
		public const string SCOL = "SCOL";

		/// <summary>
		/// Constant for qualifier with value SCTR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SCTR = "SCTR";
		[Obsolete]
		public const string SCTR = "SCTR";

		/// <summary>
		/// Constant for qualifier with value SEME 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SEME = "SEME";
		[Obsolete]
		public const string SEME = "SEME";

		/// <summary>
		/// Constant for qualifier with value SETT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SETT = "SETT";
		[Obsolete]
		public const string SETT = "SETT";

		/// <summary>
		/// Constant for qualifier with value SUMD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SUMD = "SUMD";
		[Obsolete]
		public const string SUMD = "SUMD";

		/// <summary>
		/// Constant for qualifier with value SUMM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SUMM = "SUMM";
		[Obsolete]
		public const string SUMM = "SUMM";

		/// <summary>
		/// Constant for qualifier with value TCRL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TCRL = "TCRL";
		[Obsolete]
		public const string TCRL = "TCRL";

		/// <summary>
		/// Constant for qualifier with value TERM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TERM = "TERM";
		[Obsolete]
		public const string TERM = "TERM";

		/// <summary>
		/// Constant for qualifier with value TEXA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TEXA = "TEXA";
		[Obsolete]
		public const string TEXA = "TEXA";

		/// <summary>
		/// Constant for qualifier with value THRS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String THRS = "THRS";
		[Obsolete]
		public const string THRS = "THRS";

		/// <summary>
		/// Constant for qualifier with value THRU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String THRU = "THRU";
		[Obsolete]
		public const string THRU = "THRU";

		/// <summary>
		/// Constant for qualifier with value TYCO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TYCO = "TYCO";
		[Obsolete]
		public const string TYCO = "TYCO";

		/// <summary>
		/// Constant for qualifier with value VALC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String VALC = "VALC";
		[Obsolete]
		public const string VALC = "VALC";

		/// <summary>
		/// Constant for qualifier with value VALE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String VALE = "VALE";
		[Obsolete]
		public const string VALE = "VALE";

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT503 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT503 content </param>
		public MT503(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT503 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT503 content, the parameter can not be null </param>
		/// <seealso cref= #MT503(String) </seealso>
		public MT503(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT503 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT503 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT503(String)
		/// @since 7.7 </seealso>
		public static MT503 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT503(m);
		}

		/// <summary>
		/// Creates and initializes a new MT503 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT503() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT503 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT503(final String sender, final String receiver)
		public MT503(string sender, string receiver) : base(503, sender, receiver)
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
		/// <seealso cref= #MT503(String, String) </seealso>
		/// @deprecated Use instead <code>new MT503(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT503(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT503(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT503(sender, receiver)</code> instead")]
		public MT503(int messageType, string sender, string receiver) : base(503, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT503(int, String, String)", "Use the constructor MT503(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT503 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT503(final String fin)
		public MT503(string fin) : base()
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
				log.warning("Creating an MT503 object from FIN content with a Service Message. Check if the MT503 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT503 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT503 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT503 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT503 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT503 parse(final String fin)
		public static MT503 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT503(fin);
		}

		/// <summary>
		/// Creates a new MT503 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT503(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT503(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT503 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT503 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT503 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT503 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT503(stream);
		}

		/// <summary>
		/// Creates a new MT503 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT503(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT503(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT503 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT503 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT503 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT503 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT503(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "503";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT503 append(final SwiftTagListBlock block)
		public override MT503 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT503 append(final Tag... tags)
		public override MT503 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT503 append(final Field... fields)
		public override MT503 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT503 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT503 message </param>
		/// <returns> a new instance of MT503
		/// @since 7.10.3 </returns>
		public static MT503 fromJson(string json)
		{
			return (MT503) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 23G, 
		/// or null if none is found.<br>
		/// The first occurrence of field 23G at MT503 is expected to be the only one.
		/// </summary>
		/// <returns> a Field23G object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field23G Field23G
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("23G");
				Tag t = tag("23G");
				if (t != null)
				{
					return new Field23G(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 98E, 
		/// or null if none is found.<br>
		/// The first occurrence of field 98E at MT503 is expected to be the only one.
		/// </summary>
		/// <returns> a Field98E object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field98E Field98E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("98E");
				Tag t = tag("98E");
				if (t != null)
				{
					return new Field98E(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 35B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 35B at MT503 is expected to be the only one.
		/// </summary>
		/// <returns> a Field35B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field35B Field35B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("35B");
				Tag t = tag("35B");
				if (t != null)
				{
					return new Field35B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 36B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 36B at MT503 is expected to be the only one.
		/// </summary>
		/// <returns> a Field36B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field36B Field36B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("36B");
				Tag t = tag("36B");
				if (t != null)
				{
					return new Field36B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 17B, 
		/// or null if none is found.<br>
		/// The first occurrence of field 17B at MT503 is expected to be the only one.
		/// </summary>
		/// <returns> a Field17B object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field17B Field17B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("17B");
				Tag t = tag("17B");
				if (t != null)
				{
					return new Field17B(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 20C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 20C at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field20C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field20C> Field20C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field20C> result = new java.util.ArrayList<>();
				IList<Field20C> result = new List<Field20C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("20C");
				Tag[] tags = tags("20C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field20C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 16R, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 16R at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field16R objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field16R> Field16R
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field16R> result = new java.util.ArrayList<>();
				IList<Field16R> result = new List<Field16R>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("16R");
				Tag[] tags = tags("16R");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field16R(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 22F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 22F at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field22F objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field22F> Field22F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field22F> result = new java.util.ArrayList<>();
				IList<Field22F> result = new List<Field22F>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("22F");
				Tag[] tags = tags("22F");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field22F(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98A at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field98A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field98A> Field98A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field98A> result = new java.util.ArrayList<>();
				IList<Field98A> result = new List<Field98A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("98A");
				Tag[] tags = tags("98A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field98A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 13B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 13B at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field13B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field13B> Field13B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field13B> result = new java.util.ArrayList<>();
				IList<Field13B> result = new List<Field13B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("13B");
				Tag[] tags = tags("13B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field13B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 70C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 70C at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field70C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field70C> Field70C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field70C> result = new java.util.ArrayList<>();
				IList<Field70C> result = new List<Field70C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("70C");
				Tag[] tags = tags("70C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field70C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 16S, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 16S at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field16S objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field16S> Field16S
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field16S> result = new java.util.ArrayList<>();
				IList<Field16S> result = new List<Field16S>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("16S");
				Tag[] tags = tags("16S");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field16S(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 22H, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 22H at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field22H objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field22H> Field22H
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field22H> result = new java.util.ArrayList<>();
				IList<Field22H> result = new List<Field22H>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("22H");
				Tag[] tags = tags("22H");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field22H(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95P, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95P at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field95P objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field95P> Field95P
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field95P> result = new java.util.ArrayList<>();
				IList<Field95P> result = new List<Field95P>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("95P");
				Tag[] tags = tags("95P");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field95P(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95Q, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95Q at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field95Q objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field95Q> Field95Q
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field95Q> result = new java.util.ArrayList<>();
				IList<Field95Q> result = new List<Field95Q>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("95Q");
				Tag[] tags = tags("95Q");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field95Q(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95R, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95R at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field95R objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field95R> Field95R
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field95R> result = new java.util.ArrayList<>();
				IList<Field95R> result = new List<Field95R>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("95R");
				Tag[] tags = tags("95R");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field95R(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 13A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 13A at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field13A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field13A> Field13A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field13A> result = new java.util.ArrayList<>();
				IList<Field13A> result = new List<Field13A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("13A");
				Tag[] tags = tags("13A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field13A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 19B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 19B at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field19B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field19B> Field19B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field19B> result = new java.util.ArrayList<>();
				IList<Field19B> result = new List<Field19B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("19B");
				Tag[] tags = tags("19B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field19B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98C at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field98C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field98C> Field98C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field98C> result = new java.util.ArrayList<>();
				IList<Field98C> result = new List<Field98C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("98C");
				Tag[] tags = tags("98C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field98C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98B at MT503 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field98B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field98B> Field98B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field98B> result = new java.util.ArrayList<>();
				IList<Field98B> result = new List<Field98B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("98B");
				Tag[] tags = tags("98B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field98B(tag.Value));
					}
				}
				return result;
			}
		}


	// BaseSequenceCodeGenerator [seq=A]
		/// <summary>
		/// Class to model Sequence "A" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceA extends SwiftTagListBlock
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>GENL</em>
			/// </summary>
			public const string START_END_16RS = "GENL";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceA newInstance(final Tag... tags)
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
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceA newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA result = new SequenceA();
				SequenceA result = new SequenceA();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
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
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceA(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceA(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}
		/// <summary>
		/// Get the single occurrence of SequenceA delimited by 16R/16S the value of SequenceA#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <returns> the found sequence or an empty sequence if none is found </returns>
		/// <seealso cref= SequenceA#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public SequenceA getSequenceA()
		public virtual SequenceA SequenceA
		{
			get
			{
				return new SequenceA(base.SwiftMessageNotNullOrException);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceA delimited by 16R/16S the value of SequenceA#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <seealso cref= SequenceA#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceA within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceA getSequenceA(SwiftTagListBlock parentSequence)
		public static SequenceA getSequenceA(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA s = new SequenceA();
			SequenceA s = new SequenceA();
			s.Tags = parentSequence.getSubBlock(SequenceA.START_END_16RS).getTags();
			return s;
		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=A1]
		/// <summary>
		/// Class to model Sequence "A1" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceA1 extends SwiftTagListBlock
		public class SequenceA1 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceA1() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceA1(final SwiftTagListBlock content)
			internal SequenceA1(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>AGRE</em>
			/// </summary>
			public const string START_END_16RS = "AGRE";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceA1 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceA1 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA1 result = new SequenceA1();
				SequenceA1 result = new SequenceA1();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceA1 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA1 result = new SequenceA1();
				SequenceA1 result = new SequenceA1();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceA1 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceA1 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA1 result = new SequenceA1();
				SequenceA1 result = new SequenceA1();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceA1(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceA1(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceA1 delimited by 16R/16S with value specified in SequenceA1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceA1#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceA1> getSequenceA1List()
		public virtual IList<SequenceA1> SequenceA1List
		{
			get
			{
				return getSequenceA1List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceA1 delimited by 16R/16S with value specified in SequenceA1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceA1#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceA1 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceA1> getSequenceA1List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceA1> getSequenceA1List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceA1.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceA1.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceA1> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceA1> result = new List<SequenceA1>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA1 s = new SequenceA1();
					SequenceA1 s = new SequenceA1();
					s.Tags = b.getSubBlock(SequenceA1.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=A2]
		/// <summary>
		/// Class to model Sequence "A2" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceA2 extends SwiftTagListBlock
		public class SequenceA2 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceA2() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceA2(final SwiftTagListBlock content)
			internal SequenceA2(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>LINK</em>
			/// </summary>
			public const string START_END_16RS = "LINK";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceA2 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceA2 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA2 result = new SequenceA2();
				SequenceA2 result = new SequenceA2();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceA2 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA2 result = new SequenceA2();
				SequenceA2 result = new SequenceA2();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceA2 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceA2 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA2 result = new SequenceA2();
				SequenceA2 result = new SequenceA2();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceA2(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceA2(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceA2 delimited by 16R/16S with value specified in SequenceA2#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceA2#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceA2> getSequenceA2List()
		public virtual IList<SequenceA2> SequenceA2List
		{
			get
			{
				return getSequenceA2List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceA2 delimited by 16R/16S with value specified in SequenceA2#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceA2#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceA2 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceA2> getSequenceA2List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceA2> getSequenceA2List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceA2.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceA2.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceA2> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceA2> result = new List<SequenceA2>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceA2 s = new SequenceA2();
					SequenceA2 s = new SequenceA2();
					s.Tags = b.getSubBlock(SequenceA2.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=B]
		/// <summary>
		/// Class to model Sequence "B" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceB extends SwiftTagListBlock
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>SUMM</em>
			/// </summary>
			public const string START_END_16RS = "SUMM";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceB newInstance(final Tag... tags)
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
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceB newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB result = new SequenceB();
				SequenceB result = new SequenceB();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
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
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceB(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceB(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}
		/// <summary>
		/// Get the single occurrence of SequenceB delimited by 16R/16S the value of SequenceB#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <returns> the found sequence or an empty sequence if none is found </returns>
		/// <seealso cref= SequenceB#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public SequenceB getSequenceB()
		public virtual SequenceB SequenceB
		{
			get
			{
				return new SequenceB(base.SwiftMessageNotNullOrException);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceB delimited by 16R/16S the value of SequenceB#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <seealso cref= SequenceB#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceB within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceB getSequenceB(SwiftTagListBlock parentSequence)
		public static SequenceB getSequenceB(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB s = new SequenceB();
			SequenceB s = new SequenceB();
			s.Tags = parentSequence.getSubBlock(SequenceB.START_END_16RS).getTags();
			return s;
		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=B1]
		/// <summary>
		/// Class to model Sequence "B1" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceB1 extends SwiftTagListBlock
		public class SequenceB1 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceB1() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceB1(final SwiftTagListBlock content)
			internal SequenceB1(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>SUMD</em>
			/// </summary>
			public const string START_END_16RS = "SUMD";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceB1 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceB1 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB1 result = new SequenceB1();
				SequenceB1 result = new SequenceB1();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceB1 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB1 result = new SequenceB1();
				SequenceB1 result = new SequenceB1();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceB1 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceB1 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB1 result = new SequenceB1();
				SequenceB1 result = new SequenceB1();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceB1(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceB1(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}
		/// <summary>
		/// Get the single occurrence of SequenceB1 delimited by 16R/16S the value of SequenceB1#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <returns> the found sequence or an empty sequence if none is found </returns>
		/// <seealso cref= SequenceB1#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public SequenceB1 getSequenceB1()
		public virtual SequenceB1 SequenceB1
		{
			get
			{
				return new SequenceB1(base.SwiftMessageNotNullOrException);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceB1 delimited by 16R/16S the value of SequenceB1#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <seealso cref= SequenceB1#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceB1 within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceB1 getSequenceB1(SwiftTagListBlock parentSequence)
		public static SequenceB1 getSequenceB1(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceB1 s = new SequenceB1();
			SequenceB1 s = new SequenceB1();
			s.Tags = parentSequence.getSubBlock(SequenceB1.START_END_16RS).getTags();
			return s;
		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=C]
		/// <summary>
		/// Class to model Sequence "C" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceC extends SwiftTagListBlock
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

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>COLD</em>
			/// </summary>
			public const string START_END_16RS = "COLD";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceC newInstance(final Tag... tags)
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
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceC newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC result = new SequenceC();
				SequenceC result = new SequenceC();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
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
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceC(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceC(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceC delimited by 16R/16S with value specified in SequenceC#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceC#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceC> getSequenceCList()
		public virtual IList<SequenceC> SequenceCList
		{
			get
			{
				return getSequenceCList(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceC delimited by 16R/16S with value specified in SequenceC#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceC#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceC within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceC> getSequenceCList(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceC> getSequenceCList(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceC.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceC.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceC> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceC> result = new List<SequenceC>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC s = new SequenceC();
					SequenceC s = new SequenceC();
					s.Tags = b.getSubBlock(SequenceC.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=C1]
		/// <summary>
		/// Class to model Sequence "C1" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceC1 extends SwiftTagListBlock
		public class SequenceC1 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceC1() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceC1(final SwiftTagListBlock content)
			internal SequenceC1(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>SCOL</em>
			/// </summary>
			public const string START_END_16RS = "SCOL";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceC1 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceC1 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC1 result = new SequenceC1();
				SequenceC1 result = new SequenceC1();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceC1 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC1 result = new SequenceC1();
				SequenceC1 result = new SequenceC1();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceC1 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceC1 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC1 result = new SequenceC1();
				SequenceC1 result = new SequenceC1();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceC1(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceC1(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceC1 delimited by 16R/16S with value specified in SequenceC1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceC1#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceC1> getSequenceC1List()
		public virtual IList<SequenceC1> SequenceC1List
		{
			get
			{
				return getSequenceC1List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceC1 delimited by 16R/16S with value specified in SequenceC1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceC1#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceC1 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceC1> getSequenceC1List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceC1> getSequenceC1List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceC1.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceC1.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceC1> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceC1> result = new List<SequenceC1>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC1 s = new SequenceC1();
					SequenceC1 s = new SequenceC1();
					s.Tags = b.getSubBlock(SequenceC1.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=C2]
		/// <summary>
		/// Class to model Sequence "C2" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceC2 extends SwiftTagListBlock
		public class SequenceC2 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceC2() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceC2(final SwiftTagListBlock content)
			internal SequenceC2(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>CCOL</em>
			/// </summary>
			public const string START_END_16RS = "CCOL";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceC2 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceC2 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC2 result = new SequenceC2();
				SequenceC2 result = new SequenceC2();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceC2 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC2 result = new SequenceC2();
				SequenceC2 result = new SequenceC2();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceC2 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceC2 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC2 result = new SequenceC2();
				SequenceC2 result = new SequenceC2();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceC2(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceC2(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceC2 delimited by 16R/16S with value specified in SequenceC2#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceC2#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceC2> getSequenceC2List()
		public virtual IList<SequenceC2> SequenceC2List
		{
			get
			{
				return getSequenceC2List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceC2 delimited by 16R/16S with value specified in SequenceC2#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceC2#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceC2 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceC2> getSequenceC2List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceC2> getSequenceC2List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceC2.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceC2.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceC2> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceC2> result = new List<SequenceC2>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC2 s = new SequenceC2();
					SequenceC2 s = new SequenceC2();
					s.Tags = b.getSubBlock(SequenceC2.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=C3]
		/// <summary>
		/// Class to model Sequence "C3" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceC3 extends SwiftTagListBlock
		public class SequenceC3 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceC3() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceC3(final SwiftTagListBlock content)
			internal SequenceC3(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>BCOL</em>
			/// </summary>
			public const string START_END_16RS = "BCOL";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceC3 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceC3 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC3 result = new SequenceC3();
				SequenceC3 result = new SequenceC3();
				result.append(START_TAG);
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag t in tags)
					{
						result.append(t);
					}
				}
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceC3 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC3 result = new SequenceC3();
				SequenceC3 result = new SequenceC3();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SequenceC3 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceC3 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC3 result = new SequenceC3();
				SequenceC3 result = new SequenceC3();
				result.append(START_TAG);
				if (sequences != null && sequences.Length > 0)
				{
					foreach (SwiftTagListBlock s in sequences)
					{
						result.addTags(s.Tags);
					}
				}
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceC3(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceC3(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceC3 delimited by 16R/16S with value specified in SequenceC3#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceC3#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceC3> getSequenceC3List()
		public virtual IList<SequenceC3> SequenceC3List
		{
			get
			{
				return getSequenceC3List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceC3 delimited by 16R/16S with value specified in SequenceC3#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceC3#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceC3 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceC3> getSequenceC3List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceC3> getSequenceC3List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceC3.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceC3.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceC3> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceC3> result = new List<SequenceC3>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC3 s = new SequenceC3();
					SequenceC3 s = new SequenceC3();
					s.Tags = b.getSubBlock(SequenceC3.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=D]
		/// <summary>
		/// Class to model Sequence "D" in MT 503
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceD extends SwiftTagListBlock
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

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>ADDINFO</em>
			/// </summary>
			public const string START_END_16RS = "ADDINFO";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceD newInstance(final Tag... tags)
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
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceD newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD result = new SequenceD();
				SequenceD result = new SequenceD();
				result.append(START_TAG);
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create a new instance of $sequenceClassname and add the contents of all sequences given inside.
			/// Mainly intended to create a sequence by adding subsequences </summary>
			/// <param name="sequences"> a list of blocks to set as the new sequence content </param>
			/// <returns> a new instance of the sequence, initialized with the parameter sequences content
			/// @since 7.6 </returns>
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
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceD(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceD(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}
		/// <summary>
		/// Get the single occurrence of SequenceD delimited by 16R/16S the value of SequenceD#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <returns> the found sequence or an empty sequence if none is found </returns>
		/// <seealso cref= SequenceD#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public SequenceD getSequenceD()
		public virtual SequenceD SequenceD
		{
			get
			{
				return new SequenceD(base.SwiftMessageNotNullOrException);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceD delimited by 16R/16S the value of SequenceD#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <seealso cref= SequenceD#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceD within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceD getSequenceD(SwiftTagListBlock parentSequence)
		public static SequenceD getSequenceD(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD s = new SequenceD();
			SequenceD s = new SequenceD();
			s.Tags = parentSequence.getSubBlock(SequenceD.START_END_16RS).getTags();
			return s;
		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator




	}

}