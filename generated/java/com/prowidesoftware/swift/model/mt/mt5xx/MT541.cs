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
	/// <strong>MT 541 - Receive Against Payment Instruction</strong>
	/// 
	/// <para>
	/// SWIFT MT541 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="sequence">
	/// Sequence A - General Information (M)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 20 C (M)</li>
	/// <li class="field">Field 23 G (M)</li>
	/// <li class="field">Field 98 A,C,E (O)</li>
	/// <li class="fieldset">
	/// Fieldset 99
	/// (O)<ul><li>FieldsetItem 99 B (O)</li><li>FieldsetItem 99 B (O)</li></ul></li><li class="sequence">
	/// Sequence A1 - Linkages (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 22 F (O)</li>
	/// <li class="field">Field 13 A,B (O)</li>
	/// <li class="field">Field 20 C (M)</li>
	/// <li class="field">Field 36 B (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence B - Trade Details (M)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 94
	/// (O) (repetitive)<ul><li>FieldsetItem 94 H,L (O) (repetitive)</li><li>FieldsetItem 94 B,L (O) (repetitive)</li></ul></li><li class="fieldset">
	/// Fieldset 98
	/// (M) (repetitive)<ul><li>FieldsetItem 98 A,B,C (M)</li><li>FieldsetItem 98 A,B,C,E (O)</li><li>FieldsetItem 98 A,C (O)</li></ul></li><li class="field">Field 90 A,B (O)</li>
	/// <li class="field">Field 99 A (O)</li>
	/// <li class="field">Field 35 B (M)</li>
	/// <li class="sequence">
	/// Sequence B1 - Financial Instrument Attributes (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 94 B (O)</li>
	/// <li class="fieldset">
	/// Fieldset 22
	/// (O)<ul><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li></ul></li><li class="fieldset">
	/// Fieldset 12
	/// (O)<ul><li>FieldsetItem 12 A,C (O)</li><li>FieldsetItem 12 B (O)</li><li>FieldsetItem 12 B (O)</li></ul></li><li class="field">Field 11 A (O)</li>
	/// <li class="fieldset">
	/// Fieldset 98
	/// (O)<ul><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li></ul></li><li class="fieldset">
	/// Fieldset 92
	/// (O)<ul><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li></ul></li><li class="fieldset">
	/// Fieldset 13
	/// (O)<ul><li>FieldsetItem 13 A,B (O)</li><li>FieldsetItem 13 B (O)</li></ul></li><li class="fieldset">
	/// Fieldset 17
	/// (O)<ul><li>FieldsetItem 17 B (O)</li><li>FieldsetItem 17 B (O)</li><li>FieldsetItem 17 B (O)</li></ul></li><li class="fieldset">
	/// Fieldset 90
	/// (O)<ul><li>FieldsetItem 90 A,B (O)</li><li>FieldsetItem 90 A,B (O)</li></ul></li><li class="fieldset">
	/// Fieldset 36
	/// (O)<ul><li>FieldsetItem 36 B (O)</li><li>FieldsetItem 36 B (O)</li></ul></li><li class="field">Field 35 B (O) (repetitive)</li>
	/// <li class="field">Field 70 E (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="fieldset">
	/// Fieldset 22
	/// (O) (repetitive)<ul><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O) (repetitive)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O) (repetitive)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li></ul></li><li class="field">Field 11 A (O)</li>
	/// <li class="fieldset">
	/// Fieldset 25
	/// (O)<ul><li>FieldsetItem 25 D (O)</li><li>FieldsetItem 25 D (O)</li></ul></li><li class="fieldset">
	/// Fieldset 70
	/// (O)<ul><li>FieldsetItem 70 E (O)</li><li>FieldsetItem 70 E (O)</li></ul></li><li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence C - Financial Instrument/Account (M)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 36 B (M) (repetitive)</li>
	/// <li class="field">Field 70 D (O)</li>
	/// <li class="field">Field 13 B (O) (repetitive)</li>
	/// <li class="fieldset">
	/// Fieldset 95
	/// (O)<ul><li>FieldsetItem 95 P,R (O)</li><li>FieldsetItem 95 L (O)</li></ul></li><li class="fieldset">
	/// Fieldset 97
	/// (M) (repetitive)<ul><li>FieldsetItem 97 A,B (M)</li><li>FieldsetItem 97 A,E (O)</li></ul></li><li class="field">Field 94 B,C,F,L (O) (repetitive)</li>
	/// <li class="sequence">
	/// Sequence C1 -  (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 13 B (O)</li>
	/// <li class="field">Field 36 B (O)</li>
	/// <li class="field">Field 98 A,C,E (O)</li>
	/// <li class="field">Field 90 A,B (O)</li>
	/// <li class="field">Field 22 F (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence D - Two Leg Transaction Details (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 98
	/// (O)<ul><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,C (O)</li></ul></li><li class="fieldset">
	/// Fieldset 22
	/// (O)<ul><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li></ul></li><li class="fieldset">
	/// Fieldset 20
	/// (O)<ul><li>FieldsetItem 20 C (O)</li><li>FieldsetItem 20 C (O)</li></ul></li><li class="fieldset">
	/// Fieldset 92
	/// (O)<ul><li>FieldsetItem 92 C (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A,C (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li></ul></li><li class="fieldset">
	/// Fieldset 99
	/// (O)<ul><li>FieldsetItem 99 B (O)</li><li>FieldsetItem 99 B (O)</li></ul></li><li class="fieldset">
	/// Fieldset 19
	/// (O)<ul><li>FieldsetItem 19 A (O)</li><li>FieldsetItem 19 A (O)</li><li>FieldsetItem 19 A (O)</li><li>FieldsetItem 19 A (O)</li><li>FieldsetItem 19 A (O)</li><li>FieldsetItem 19 A (O)</li></ul></li><li class="field">Field 70 C (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence E - Settlement Details (M)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 22
	/// (M) (repetitive)<ul><li>FieldsetItem 22 F (O) (repetitive)</li><li>FieldsetItem 22 F (M)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li></ul></li><li class="sequence">
	/// Sequence E1 - Settlement Parties (M) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 95
	/// (M) (repetitive)<ul><li>FieldsetItem 95 P,Q,R,C (M)</li><li>FieldsetItem 95 L,S (O) (repetitive)</li></ul></li><li class="field">Field 97 A,B (O)</li>
	/// <li class="field">Field 98 A,C (O)</li>
	/// <li class="field">Field 20 C (O)</li>
	/// <li class="fieldset">
	/// Fieldset 70
	/// (O)<ul><li>FieldsetItem 70 E (O)</li><li>FieldsetItem 70 D (O)</li><li>FieldsetItem 70 C (O)</li></ul></li><li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence E2 - Cash Parties (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 95
	/// (M) (repetitive)<ul><li>FieldsetItem 95 P,Q,R (M)</li><li>FieldsetItem 95 L,S (O) (repetitive)</li></ul></li><li class="fieldset">
	/// Fieldset 97
	/// (O)<ul><li>FieldsetItem 97 A,E (O)</li><li>FieldsetItem 97 A,E (O)</li><li>FieldsetItem 97 A,E (O)</li><li>FieldsetItem 97 A,E (O)</li></ul></li><li class="fieldset">
	/// Fieldset 70
	/// (O)<ul><li>FieldsetItem 70 E (O)</li><li>FieldsetItem 70 C (O)</li></ul></li><li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence E3 - Amounts (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 17
	/// (O)<ul><li>FieldsetItem 17 B (O)</li><li>FieldsetItem 17 B (O)</li><li>FieldsetItem 17 B (O)</li></ul></li><li class="fieldset">
	/// Fieldset 19
	/// (M) (repetitive)<ul><li>FieldsetItem 19 A (M)</li><li>FieldsetItem 19 A (O)</li><li>FieldsetItem 19 A (O)</li></ul></li><li class="field">Field 98 A,C (O)</li>
	/// <li class="field">Field 92 B (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence F - Other Parties (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 95
	/// (M) (repetitive)<ul><li>FieldsetItem 95 C,P,Q,R (M) (repetitive)</li><li>FieldsetItem 95 L,S (O) (repetitive)</li></ul></li><li class="field">Field 97 A (O)</li>
	/// <li class="fieldset">
	/// Fieldset 70
	/// (O)<ul><li>FieldsetItem 70 E (O)</li><li>FieldsetItem 70 D (O)</li><li>FieldsetItem 70 C (O)</li></ul></li><li class="field">Field 20 C (O)</li>
	/// <li class="field">Field 16 S (M)</li>
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
//ORIGINAL LINE: @Generated public class MT541 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT541 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT541).Name);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "541";

	// begin qualifiers constants	

		/// <summary>
		/// Constant for qualifier with value ACCA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ACCA = "ACCA";
		[Obsolete]
		public const string ACCA = "ACCA";

		/// <summary>
		/// Constant for qualifier with value ACCW 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ACCW = "ACCW";
		[Obsolete]
		public const string ACCW = "ACCW";

		/// <summary>
		/// Constant for qualifier with value ACOW 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ACOW = "ACOW";
		[Obsolete]
		public const string ACOW = "ACOW";

		/// <summary>
		/// Constant for qualifier with value ACRU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ACRU = "ACRU";
		[Obsolete]
		public const string ACRU = "ACRU";

		/// <summary>
		/// Constant for qualifier with value ADEL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ADEL = "ADEL";
		[Obsolete]
		public const string ADEL = "ADEL";

		/// <summary>
		/// Constant for qualifier with value AFFM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AFFM = "AFFM";
		[Obsolete]
		public const string AFFM = "AFFM";

		/// <summary>
		/// Constant for qualifier with value ALTE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ALTE = "ALTE";
		[Obsolete]
		public const string ALTE = "ALTE";

		/// <summary>
		/// Constant for qualifier with value AMT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AMT = "AMT";
		[Obsolete]
		public const string AMT = "AMT";

		/// <summary>
		/// Constant for qualifier with value ANTO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ANTO = "ANTO";
		[Obsolete]
		public const string ANTO = "ANTO";

		/// <summary>
		/// Constant for qualifier with value BENE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BENE = "BENE";
		[Obsolete]
		public const string BENE = "BENE";

		/// <summary>
		/// Constant for qualifier with value BENM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BENM = "BENM";
		[Obsolete]
		public const string BENM = "BENM";

		/// <summary>
		/// Constant for qualifier with value BLOC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BLOC = "BLOC";
		[Obsolete]
		public const string BLOC = "BLOC";

		/// <summary>
		/// Constant for qualifier with value BORR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BORR = "BORR";
		[Obsolete]
		public const string BORR = "BORR";

		/// <summary>
		/// Constant for qualifier with value BREAK 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BREAK = "BREAK";
		[Obsolete]
		public const string BREAK = "BREAK";

		/// <summary>
		/// Constant for qualifier with value CADE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CADE = "CADE";
		[Obsolete]
		public const string CADE = "CADE";

		/// <summary>
		/// Constant for qualifier with value CALD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CALD = "CALD";
		[Obsolete]
		public const string CALD = "CALD";

		/// <summary>
		/// Constant for qualifier with value CALL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CALL = "CALL";
		[Obsolete]
		public const string CALL = "CALL";

		/// <summary>
		/// Constant for qualifier with value CANC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CANC = "CANC";
		[Obsolete]
		public const string CANC = "CANC";

		/// <summary>
		/// Constant for qualifier with value CASH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CASH = "CASH";
		[Obsolete]
		public const string CASH = "CASH";

		/// <summary>
		/// Constant for qualifier with value CASY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CASY = "CASY";
		[Obsolete]
		public const string CASY = "CASY";

		/// <summary>
		/// Constant for qualifier with value CCPT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CCPT = "CCPT";
		[Obsolete]
		public const string CCPT = "CCPT";

		/// <summary>
		/// Constant for qualifier with value CERT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CERT = "CERT";
		[Obsolete]
		public const string CERT = "CERT";

		/// <summary>
		/// Constant for qualifier with value CFRE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CFRE = "CFRE";
		[Obsolete]
		public const string CFRE = "CFRE";

		/// <summary>
		/// Constant for qualifier with value CHAR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CHAR = "CHAR";
		[Obsolete]
		public const string CHAR = "CHAR";

		/// <summary>
		/// Constant for qualifier with value CLAS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CLAS = "CLAS";
		[Obsolete]
		public const string CLAS = "CLAS";

		/// <summary>
		/// Constant for qualifier with value CLCI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CLCI = "CLCI";
		[Obsolete]
		public const string CLCI = "CLCI";

		/// <summary>
		/// Constant for qualifier with value CLEA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CLEA = "CLEA";
		[Obsolete]
		public const string CLEA = "CLEA";

		/// <summary>
		/// Constant for qualifier with value CLTR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CLTR = "CLTR";
		[Obsolete]
		public const string CLTR = "CLTR";

		/// <summary>
		/// Constant for qualifier with value COAX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COAX = "COAX";
		[Obsolete]
		public const string COAX = "COAX";

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
		/// Constant for qualifier with value COLE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COLE = "COLE";
		[Obsolete]
		public const string COLE = "COLE";

		/// <summary>
		/// Constant for qualifier with value COLR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COLR = "COLR";
		[Obsolete]
		public const string COLR = "COLR";

		/// <summary>
		/// Constant for qualifier with value COMM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COMM = "COMM";
		[Obsolete]
		public const string COMM = "COMM";

		/// <summary>
		/// Constant for qualifier with value COPY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COPY = "COPY";
		[Obsolete]
		public const string COPY = "COPY";

		/// <summary>
		/// Constant for qualifier with value CORP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CORP = "CORP";
		[Obsolete]
		public const string CORP = "CORP";

		/// <summary>
		/// Constant for qualifier with value COUN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COUN = "COUN";
		[Obsolete]
		public const string COUN = "COUN";

		/// <summary>
		/// Constant for qualifier with value COUP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COUP = "COUP";
		[Obsolete]
		public const string COUP = "COUP";

		/// <summary>
		/// Constant for qualifier with value CSBT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CSBT = "CSBT";
		[Obsolete]
		public const string CSBT = "CSBT";

		/// <summary>
		/// Constant for qualifier with value CSHPRTY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CSHPRTY = "CSHPRTY";
		[Obsolete]
		public const string CSHPRTY = "CSHPRTY";

		/// <summary>
		/// Constant for qualifier with value CUFC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CUFC = "CUFC";
		[Obsolete]
		public const string CUFC = "CUFC";

		/// <summary>
		/// Constant for qualifier with value DAAC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DAAC = "DAAC";
		[Obsolete]
		public const string DAAC = "DAAC";

		/// <summary>
		/// Constant for qualifier with value DBNM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DBNM = "DBNM";
		[Obsolete]
		public const string DBNM = "DBNM";

		/// <summary>
		/// Constant for qualifier with value DDTE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DDTE = "DDTE";
		[Obsolete]
		public const string DDTE = "DDTE";

		/// <summary>
		/// Constant for qualifier with value DEAL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DEAL = "DEAL";
		[Obsolete]
		public const string DEAL = "DEAL";

		/// <summary>
		/// Constant for qualifier with value DEBT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DEBT = "DEBT";
		[Obsolete]
		public const string DEBT = "DEBT";

		/// <summary>
		/// Constant for qualifier with value DECL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DECL = "DECL";
		[Obsolete]
		public const string DECL = "DECL";

		/// <summary>
		/// Constant for qualifier with value DENC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DENC = "DENC";
		[Obsolete]
		public const string DENC = "DENC";

		/// <summary>
		/// Constant for qualifier with value DENO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DENO = "DENO";
		[Obsolete]
		public const string DENO = "DENO";

		/// <summary>
		/// Constant for qualifier with value DUPL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DUPL = "DUPL";
		[Obsolete]
		public const string DUPL = "DUPL";

		/// <summary>
		/// Constant for qualifier with value EXCH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EXCH = "EXCH";
		[Obsolete]
		public const string EXCH = "EXCH";

		/// <summary>
		/// Constant for qualifier with value EXEC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EXEC = "EXEC";
		[Obsolete]
		public const string EXEC = "EXEC";

		/// <summary>
		/// Constant for qualifier with value EXER 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EXER = "EXER";
		[Obsolete]
		public const string EXER = "EXER";

		/// <summary>
		/// Constant for qualifier with value EXPI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EXPI = "EXPI";
		[Obsolete]
		public const string EXPI = "EXPI";

		/// <summary>
		/// Constant for qualifier with value FCOU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FCOU = "FCOU";
		[Obsolete]
		public const string FCOU = "FCOU";

		/// <summary>
		/// Constant for qualifier with value FIA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FIA = "FIA";
		[Obsolete]
		public const string FIA = "FIA";

		/// <summary>
		/// Constant for qualifier with value FIAC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FIAC = "FIAC";
		[Obsolete]
		public const string FIAC = "FIAC";

		/// <summary>
		/// Constant for qualifier with value FIAN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FIAN = "FIAN";
		[Obsolete]
		public const string FIAN = "FIAN";

		/// <summary>
		/// Constant for qualifier with value FORF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FORF = "FORF";
		[Obsolete]
		public const string FORF = "FORF";

		/// <summary>
		/// Constant for qualifier with value FORM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FORM = "FORM";
		[Obsolete]
		public const string FORM = "FORM";

		/// <summary>
		/// Constant for qualifier with value FRNF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FRNF = "FRNF";
		[Obsolete]
		public const string FRNF = "FRNF";

		/// <summary>
		/// Constant for qualifier with value FRNR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FRNR = "FRNR";
		[Obsolete]
		public const string FRNR = "FRNR";

		/// <summary>
		/// Constant for qualifier with value FXCX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FXCX = "FXCX";
		[Obsolete]
		public const string FXCX = "FXCX";

		/// <summary>
		/// Constant for qualifier with value FXIN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FXIN = "FXIN";
		[Obsolete]
		public const string FXIN = "FXIN";

		/// <summary>
		/// Constant for qualifier with value FXIS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FXIS = "FXIS";
		[Obsolete]
		public const string FXIS = "FXIS";

		/// <summary>
		/// Constant for qualifier with value GENL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String GENL = "GENL";
		[Obsolete]
		public const string GENL = "GENL";

		/// <summary>
		/// Constant for qualifier with value INCA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INCA = "INCA";
		[Obsolete]
		public const string INCA = "INCA";

		/// <summary>
		/// Constant for qualifier with value INDC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INDC = "INDC";
		[Obsolete]
		public const string INDC = "INDC";

		/// <summary>
		/// Constant for qualifier with value INDX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INDX = "INDX";
		[Obsolete]
		public const string INDX = "INDX";

		/// <summary>
		/// Constant for qualifier with value INTM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INTM = "INTM";
		[Obsolete]
		public const string INTM = "INTM";

		/// <summary>
		/// Constant for qualifier with value INTR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INTR = "INTR";
		[Obsolete]
		public const string INTR = "INTR";

		/// <summary>
		/// Constant for qualifier with value ISDI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ISDI = "ISDI";
		[Obsolete]
		public const string ISDI = "ISDI";

		/// <summary>
		/// Constant for qualifier with value ISSU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ISSU = "ISSU";
		[Obsolete]
		public const string ISSU = "ISSU";

		/// <summary>
		/// Constant for qualifier with value LADT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LADT = "LADT";
		[Obsolete]
		public const string LADT = "LADT";

		/// <summary>
		/// Constant for qualifier with value LEGA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LEGA = "LEGA";
		[Obsolete]
		public const string LEGA = "LEGA";

		/// <summary>
		/// Constant for qualifier with value LEOG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LEOG = "LEOG";
		[Obsolete]
		public const string LEOG = "LEOG";

		/// <summary>
		/// Constant for qualifier with value LEVY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LEVY = "LEVY";
		[Obsolete]
		public const string LEVY = "LEVY";

		/// <summary>
		/// Constant for qualifier with value LINK 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LINK = "LINK";
		[Obsolete]
		public const string LINK = "LINK";

		/// <summary>
		/// Constant for qualifier with value LOCL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOCL = "LOCL";
		[Obsolete]
		public const string LOCL = "LOCL";

		/// <summary>
		/// Constant for qualifier with value LOCO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOCO = "LOCO";
		[Obsolete]
		public const string LOCO = "LOCO";

		/// <summary>
		/// Constant for qualifier with value LOTS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOTS = "LOTS";
		[Obsolete]
		public const string LOTS = "LOTS";

		/// <summary>
		/// Constant for qualifier with value MACL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MACL = "MACL";
		[Obsolete]
		public const string MACL = "MACL";

		/// <summary>
		/// Constant for qualifier with value MARG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MARG = "MARG";
		[Obsolete]
		public const string MARG = "MARG";

		/// <summary>
		/// Constant for qualifier with value MATU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MATU = "MATU";
		[Obsolete]
		public const string MATU = "MATU";

		/// <summary>
		/// Constant for qualifier with value MFKT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MFKT = "MFKT";
		[Obsolete]
		public const string MFKT = "MFKT";

		/// <summary>
		/// Constant for qualifier with value MICO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MICO = "MICO";
		[Obsolete]
		public const string MICO = "MICO";

		/// <summary>
		/// Constant for qualifier with value MINO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MINO = "MINO";
		[Obsolete]
		public const string MINO = "MINO";

		/// <summary>
		/// Constant for qualifier with value MTCH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MTCH = "MTCH";
		[Obsolete]
		public const string MTCH = "MTCH";

		/// <summary>
		/// Constant for qualifier with value NETT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NETT = "NETT";
		[Obsolete]
		public const string NETT = "NETT";

		/// <summary>
		/// Constant for qualifier with value NEWM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NEWM = "NEWM";
		[Obsolete]
		public const string NEWM = "NEWM";

		/// <summary>
		/// Constant for qualifier with value NWFC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NWFC = "NWFC";
		[Obsolete]
		public const string NWFC = "NWFC";

		/// <summary>
		/// Constant for qualifier with value NXRT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NXRT = "NXRT";
		[Obsolete]
		public const string NXRT = "NXRT";

		/// <summary>
		/// Constant for qualifier with value OCMT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OCMT = "OCMT";
		[Obsolete]
		public const string OCMT = "OCMT";

		/// <summary>
		/// Constant for qualifier with value OMAT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OMAT = "OMAT";
		[Obsolete]
		public const string OMAT = "OMAT";

		/// <summary>
		/// Constant for qualifier with value OPST 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OPST = "OPST";
		[Obsolete]
		public const string OPST = "OPST";

		/// <summary>
		/// Constant for qualifier with value OPTI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OPTI = "OPTI";
		[Obsolete]
		public const string OPTI = "OPTI";

		/// <summary>
		/// Constant for qualifier with value OTHR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OTHR = "OTHR";
		[Obsolete]
		public const string OTHR = "OTHR";

		/// <summary>
		/// Constant for qualifier with value OTHRPRTY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OTHRPRTY = "OTHRPRTY";
		[Obsolete]
		public const string OTHRPRTY = "OTHRPRTY";

		/// <summary>
		/// Constant for qualifier with value PACO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PACO = "PACO";
		[Obsolete]
		public const string PACO = "PACO";

		/// <summary>
		/// Constant for qualifier with value PAIR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PAIR = "PAIR";
		[Obsolete]
		public const string PAIR = "PAIR";

		/// <summary>
		/// Constant for qualifier with value PAYE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PAYE = "PAYE";
		[Obsolete]
		public const string PAYE = "PAYE";

		/// <summary>
		/// Constant for qualifier with value PAYS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PAYS = "PAYS";
		[Obsolete]
		public const string PAYS = "PAYS";

		/// <summary>
		/// Constant for qualifier with value PCTI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PCTI = "PCTI";
		[Obsolete]
		public const string PCTI = "PCTI";

		/// <summary>
		/// Constant for qualifier with value PFRE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PFRE = "PFRE";
		[Obsolete]
		public const string PFRE = "PFRE";

		/// <summary>
		/// Constant for qualifier with value PLIS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PLIS = "PLIS";
		[Obsolete]
		public const string PLIS = "PLIS";

		/// <summary>
		/// Constant for qualifier with value POOL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String POOL = "POOL";
		[Obsolete]
		public const string POOL = "POOL";

		/// <summary>
		/// Constant for qualifier with value PREA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PREA = "PREA";
		[Obsolete]
		public const string PREA = "PREA";

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
		/// Constant for qualifier with value PRFC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PRFC = "PRFC";
		[Obsolete]
		public const string PRFC = "PRFC";

		/// <summary>
		/// Constant for qualifier with value PRIC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PRIC = "PRIC";
		[Obsolete]
		public const string PRIC = "PRIC";

		/// <summary>
		/// Constant for qualifier with value PRIR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PRIR = "PRIR";
		[Obsolete]
		public const string PRIR = "PRIR";

		/// <summary>
		/// Constant for qualifier with value PROC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PROC = "PROC";
		[Obsolete]
		public const string PROC = "PROC";

		/// <summary>
		/// Constant for qualifier with value PUTT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PUTT = "PUTT";
		[Obsolete]
		public const string PUTT = "PUTT";

		/// <summary>
		/// Constant for qualifier with value RECO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RECO = "RECO";
		[Obsolete]
		public const string RECO = "RECO";

		/// <summary>
		/// Constant for qualifier with value REGF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REGF = "REGF";
		[Obsolete]
		public const string REGF = "REGF";

		/// <summary>
		/// Constant for qualifier with value REGI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REGI = "REGI";
		[Obsolete]
		public const string REGI = "REGI";

		/// <summary>
		/// Constant for qualifier with value REGT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REGT = "REGT";
		[Obsolete]
		public const string REGT = "REGT";

		/// <summary>
		/// Constant for qualifier with value RELA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RELA = "RELA";
		[Obsolete]
		public const string RELA = "RELA";

		/// <summary>
		/// Constant for qualifier with value REPO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REPO = "REPO";
		[Obsolete]
		public const string REPO = "REPO";

		/// <summary>
		/// Constant for qualifier with value REPP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REPP = "REPP";
		[Obsolete]
		public const string REPP = "REPP";

		/// <summary>
		/// Constant for qualifier with value REPT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REPT = "REPT";
		[Obsolete]
		public const string REPT = "REPT";

		/// <summary>
		/// Constant for qualifier with value RERA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RERA = "RERA";
		[Obsolete]
		public const string RERA = "RERA";

		/// <summary>
		/// Constant for qualifier with value RERT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RERT = "RERT";
		[Obsolete]
		public const string RERT = "RERT";

		/// <summary>
		/// Constant for qualifier with value REST 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REST = "REST";
		[Obsolete]
		public const string REST = "REST";

		/// <summary>
		/// Constant for qualifier with value RESU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RESU = "RESU";
		[Obsolete]
		public const string RESU = "RESU";

		/// <summary>
		/// Constant for qualifier with value REVA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REVA = "REVA";
		[Obsolete]
		public const string REVA = "REVA";

		/// <summary>
		/// Constant for qualifier with value RPOR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RPOR = "RPOR";
		[Obsolete]
		public const string RPOR = "RPOR";

		/// <summary>
		/// Constant for qualifier with value RSCH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RSCH = "RSCH";
		[Obsolete]
		public const string RSCH = "RSCH";

		/// <summary>
		/// Constant for qualifier with value RSPR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RSPR = "RSPR";
		[Obsolete]
		public const string RSPR = "RSPR";

		/// <summary>
		/// Constant for qualifier with value RTGS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RTGS = "RTGS";
		[Obsolete]
		public const string RTGS = "RTGS";

		/// <summary>
		/// Constant for qualifier with value SAFE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SAFE = "SAFE";
		[Obsolete]
		public const string SAFE = "SAFE";

		/// <summary>
		/// Constant for qualifier with value SECO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SECO = "SECO";
		[Obsolete]
		public const string SECO = "SECO";

		/// <summary>
		/// Constant for qualifier with value SEME 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SEME = "SEME";
		[Obsolete]
		public const string SEME = "SEME";

		/// <summary>
		/// Constant for qualifier with value SETDET 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SETDET = "SETDET";
		[Obsolete]
		public const string SETDET = "SETDET";

		/// <summary>
		/// Constant for qualifier with value SETPRTY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SETPRTY = "SETPRTY";
		[Obsolete]
		public const string SETPRTY = "SETPRTY";

		/// <summary>
		/// Constant for qualifier with value SETR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SETR = "SETR";
		[Obsolete]
		public const string SETR = "SETR";

		/// <summary>
		/// Constant for qualifier with value SETS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SETS = "SETS";
		[Obsolete]
		public const string SETS = "SETS";

		/// <summary>
		/// Constant for qualifier with value SETT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SETT = "SETT";
		[Obsolete]
		public const string SETT = "SETT";

		/// <summary>
		/// Constant for qualifier with value SHAI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SHAI = "SHAI";
		[Obsolete]
		public const string SHAI = "SHAI";

		/// <summary>
		/// Constant for qualifier with value SHIP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SHIP = "SHIP";
		[Obsolete]
		public const string SHIP = "SHIP";

		/// <summary>
		/// Constant for qualifier with value SIZE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SIZE = "SIZE";
		[Obsolete]
		public const string SIZE = "SIZE";

		/// <summary>
		/// Constant for qualifier with value SLMG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SLMG = "SLMG";
		[Obsolete]
		public const string SLMG = "SLMG";

		/// <summary>
		/// Constant for qualifier with value SPCN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SPCN = "SPCN";
		[Obsolete]
		public const string SPCN = "SPCN";

		/// <summary>
		/// Constant for qualifier with value SPRO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SPRO = "SPRO";
		[Obsolete]
		public const string SPRO = "SPRO";

		/// <summary>
		/// Constant for qualifier with value SSBT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SSBT = "SSBT";
		[Obsolete]
		public const string SSBT = "SSBT";

		/// <summary>
		/// Constant for qualifier with value STAM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String STAM = "STAM";
		[Obsolete]
		public const string STAM = "STAM";

		/// <summary>
		/// Constant for qualifier with value STCO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String STCO = "STCO";
		[Obsolete]
		public const string STCO = "STCO";

		/// <summary>
		/// Constant for qualifier with value STEX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String STEX = "STEX";
		[Obsolete]
		public const string STEX = "STEX";

		/// <summary>
		/// Constant for qualifier with value TAPC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TAPC = "TAPC";
		[Obsolete]
		public const string TAPC = "TAPC";

		/// <summary>
		/// Constant for qualifier with value TAXE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TAXE = "TAXE";
		[Obsolete]
		public const string TAXE = "TAXE";

		/// <summary>
		/// Constant for qualifier with value TCPI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TCPI = "TCPI";
		[Obsolete]
		public const string TCPI = "TCPI";

		/// <summary>
		/// Constant for qualifier with value TCTR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TCTR = "TCTR";
		[Obsolete]
		public const string TCTR = "TCTR";

		/// <summary>
		/// Constant for qualifier with value TERM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TERM = "TERM";
		[Obsolete]
		public const string TERM = "TERM";

		/// <summary>
		/// Constant for qualifier with value TOCO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TOCO = "TOCO";
		[Obsolete]
		public const string TOCO = "TOCO";

		/// <summary>
		/// Constant for qualifier with value TOSE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TOSE = "TOSE";
		[Obsolete]
		public const string TOSE = "TOSE";

		/// <summary>
		/// Constant for qualifier with value TRAD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRAD = "TRAD";
		[Obsolete]
		public const string TRAD = "TRAD";

		/// <summary>
		/// Constant for qualifier with value TRADDET 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRADDET = "TRADDET";
		[Obsolete]
		public const string TRADDET = "TRADDET";

		/// <summary>
		/// Constant for qualifier with value TRAK 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRAK = "TRAK";
		[Obsolete]
		public const string TRAK = "TRAK";

		/// <summary>
		/// Constant for qualifier with value TRAN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRAN = "TRAN";
		[Obsolete]
		public const string TRAN = "TRAN";

		/// <summary>
		/// Constant for qualifier with value TRAX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRAX = "TRAX";
		[Obsolete]
		public const string TRAX = "TRAX";

		/// <summary>
		/// Constant for qualifier with value TRCA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRCA = "TRCA";
		[Obsolete]
		public const string TRCA = "TRCA";

		/// <summary>
		/// Constant for qualifier with value TRCI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRCI = "TRCI";
		[Obsolete]
		public const string TRCI = "TRCI";

		/// <summary>
		/// Constant for qualifier with value TRRF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRRF = "TRRF";
		[Obsolete]
		public const string TRRF = "TRRF";

		/// <summary>
		/// Constant for qualifier with value TRTE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRTE = "TRTE";
		[Obsolete]
		public const string TRTE = "TRTE";

		/// <summary>
		/// Constant for qualifier with value TTCO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TTCO = "TTCO";
		[Obsolete]
		public const string TTCO = "TTCO";

		/// <summary>
		/// Constant for qualifier with value TURN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TURN = "TURN";
		[Obsolete]
		public const string TURN = "TURN";

		/// <summary>
		/// Constant for qualifier with value VALU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String VALU = "VALU";
		[Obsolete]
		public const string VALU = "VALU";

		/// <summary>
		/// Constant for qualifier with value VASU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String VASU = "VASU";
		[Obsolete]
		public const string VASU = "VASU";

		/// <summary>
		/// Constant for qualifier with value VATA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String VATA = "VATA";
		[Obsolete]
		public const string VATA = "VATA";

		/// <summary>
		/// Constant for qualifier with value WITH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String WITH = "WITH";
		[Obsolete]
		public const string WITH = "WITH";

		/// <summary>
		/// Constant for qualifier with value YTMR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String YTMR = "YTMR";
		[Obsolete]
		public const string YTMR = "YTMR";

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT541 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT541 content </param>
		public MT541(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT541 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT541 content, the parameter can not be null </param>
		/// <seealso cref= #MT541(String) </seealso>
		public MT541(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT541 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT541 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT541(String)
		/// @since 7.7 </seealso>
		public static MT541 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT541(m);
		}

		/// <summary>
		/// Creates and initializes a new MT541 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT541() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT541 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT541(final String sender, final String receiver)
		public MT541(string sender, string receiver) : base(541, sender, receiver)
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
		/// <seealso cref= #MT541(String, String) </seealso>
		/// @deprecated Use instead <code>new MT541(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT541(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT541(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT541(sender, receiver)</code> instead")]
		public MT541(int messageType, string sender, string receiver) : base(541, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT541(int, String, String)", "Use the constructor MT541(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT541 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT541(final String fin)
		public MT541(string fin) : base()
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
				log.warning("Creating an MT541 object from FIN content with a Service Message. Check if the MT541 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT541 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT541 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT541 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT541 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT541 parse(final String fin)
		public static MT541 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT541(fin);
		}

		/// <summary>
		/// Creates a new MT541 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT541(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT541(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT541 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT541 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT541 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT541 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT541(stream);
		}

		/// <summary>
		/// Creates a new MT541 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT541(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT541(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT541 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT541 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT541 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT541 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT541(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "541";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT541 append(final SwiftTagListBlock block)
		public override MT541 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT541 append(final Tag... tags)
		public override MT541 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT541 append(final Field... fields)
		public override MT541 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT541 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT541 message </param>
		/// <returns> a new instance of MT541
		/// @since 7.10.3 </returns>
		public static MT541 fromJson(string json)
		{
			return (MT541) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 23G, 
		/// or null if none is found.<br>
		/// The first occurrence of field 23G at MT541 is expected to be the only one.
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
		/// Iterates through block4 fields and return the first one whose name matches 99A, 
		/// or null if none is found.<br>
		/// The first occurrence of field 99A at MT541 is expected to be the only one.
		/// </summary>
		/// <returns> a Field99A object or null if the field is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual Field99A Field99A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag t = tag("99A");
				Tag t = tag("99A");
				if (t != null)
				{
					return new Field99A(t.Value);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 99B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 99B at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field99B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field99B> Field99B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field99B> result = new java.util.ArrayList<>();
				IList<Field99B> result = new List<Field99B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("99B");
				Tag[] tags = tags("99B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field99B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 16R, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 16R at MT541 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 22F at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 13A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 13A at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 13B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 13B at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 20C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 20C at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 36B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 36B at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field36B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field36B> Field36B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field36B> result = new java.util.ArrayList<>();
				IList<Field36B> result = new List<Field36B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("36B");
				Tag[] tags = tags("36B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field36B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 16S, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 16S at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 94B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 94B at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field94B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field94B> Field94B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field94B> result = new java.util.ArrayList<>();
				IList<Field94B> result = new List<Field94B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("94B");
				Tag[] tags = tags("94B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field94B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 94H, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 94H at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field94H objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field94H> Field94H
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field94H> result = new java.util.ArrayList<>();
				IList<Field94H> result = new List<Field94H>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("94H");
				Tag[] tags = tags("94H");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field94H(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 94L, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 94L at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field94L objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field94L> Field94L
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field94L> result = new java.util.ArrayList<>();
				IList<Field94L> result = new List<Field94L>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("94L");
				Tag[] tags = tags("94L");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field94L(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98A at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98B at MT541 are expected at one sequence or across several sequences.
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

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98C at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98E at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field98E objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field98E> Field98E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field98E> result = new java.util.ArrayList<>();
				IList<Field98E> result = new List<Field98E>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("98E");
				Tag[] tags = tags("98E");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field98E(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 12A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 12A at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field12A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field12A> Field12A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field12A> result = new java.util.ArrayList<>();
				IList<Field12A> result = new List<Field12A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("12A");
				Tag[] tags = tags("12A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field12A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 12C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 12C at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field12C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field12C> Field12C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field12C> result = new java.util.ArrayList<>();
				IList<Field12C> result = new List<Field12C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("12C");
				Tag[] tags = tags("12C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field12C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 12B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 12B at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field12B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field12B> Field12B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field12B> result = new java.util.ArrayList<>();
				IList<Field12B> result = new List<Field12B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("12B");
				Tag[] tags = tags("12B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field12B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92A at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92A> Field92A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92A> result = new java.util.ArrayList<>();
				IList<Field92A> result = new List<Field92A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92A");
				Tag[] tags = tags("92A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 17B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 17B at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field17B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field17B> Field17B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field17B> result = new java.util.ArrayList<>();
				IList<Field17B> result = new List<Field17B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("17B");
				Tag[] tags = tags("17B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field17B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 90A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 90A at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field90A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field90A> Field90A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field90A> result = new java.util.ArrayList<>();
				IList<Field90A> result = new List<Field90A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("90A");
				Tag[] tags = tags("90A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field90A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 90B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 90B at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field90B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field90B> Field90B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field90B> result = new java.util.ArrayList<>();
				IList<Field90B> result = new List<Field90B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("90B");
				Tag[] tags = tags("90B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field90B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 35B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 35B at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field35B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field35B> Field35B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field35B> result = new java.util.ArrayList<>();
				IList<Field35B> result = new List<Field35B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("35B");
				Tag[] tags = tags("35B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field35B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 11A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 11A at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field11A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field11A> Field11A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field11A> result = new java.util.ArrayList<>();
				IList<Field11A> result = new List<Field11A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("11A");
				Tag[] tags = tags("11A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field11A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 25D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 25D at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field25D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field25D> Field25D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field25D> result = new java.util.ArrayList<>();
				IList<Field25D> result = new List<Field25D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("25D");
				Tag[] tags = tags("25D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field25D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 70E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 70E at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field70E objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field70E> Field70E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field70E> result = new java.util.ArrayList<>();
				IList<Field70E> result = new List<Field70E>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("70E");
				Tag[] tags = tags("70E");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field70E(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95P, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95P at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95R, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95R at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95L, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95L at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field95L objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field95L> Field95L
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field95L> result = new java.util.ArrayList<>();
				IList<Field95L> result = new List<Field95L>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("95L");
				Tag[] tags = tags("95L");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field95L(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 97A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 97A at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field97A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field97A> Field97A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field97A> result = new java.util.ArrayList<>();
				IList<Field97A> result = new List<Field97A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("97A");
				Tag[] tags = tags("97A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field97A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 97B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 97B at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field97B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field97B> Field97B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field97B> result = new java.util.ArrayList<>();
				IList<Field97B> result = new List<Field97B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("97B");
				Tag[] tags = tags("97B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field97B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 97E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 97E at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field97E objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field97E> Field97E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field97E> result = new java.util.ArrayList<>();
				IList<Field97E> result = new List<Field97E>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("97E");
				Tag[] tags = tags("97E");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field97E(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 94C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 94C at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field94C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field94C> Field94C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field94C> result = new java.util.ArrayList<>();
				IList<Field94C> result = new List<Field94C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("94C");
				Tag[] tags = tags("94C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field94C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 94F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 94F at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field94F objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field94F> Field94F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field94F> result = new java.util.ArrayList<>();
				IList<Field94F> result = new List<Field94F>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("94F");
				Tag[] tags = tags("94F");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field94F(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92C at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92C> Field92C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92C> result = new java.util.ArrayList<>();
				IList<Field92C> result = new List<Field92C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92C");
				Tag[] tags = tags("92C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 19A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 19A at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field19A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field19A> Field19A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field19A> result = new java.util.ArrayList<>();
				IList<Field19A> result = new List<Field19A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("19A");
				Tag[] tags = tags("19A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field19A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95C at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field95C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field95C> Field95C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field95C> result = new java.util.ArrayList<>();
				IList<Field95C> result = new List<Field95C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("95C");
				Tag[] tags = tags("95C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field95C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95Q, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95Q at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95S, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95S at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field95S objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field95S> Field95S
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field95S> result = new java.util.ArrayList<>();
				IList<Field95S> result = new List<Field95S>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("95S");
				Tag[] tags = tags("95S");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field95S(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 70C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 70C at MT541 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 70D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 70D at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field70D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field70D> Field70D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field70D> result = new java.util.ArrayList<>();
				IList<Field70D> result = new List<Field70D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("70D");
				Tag[] tags = tags("70D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field70D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92B at MT541 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92B> Field92B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92B> result = new java.util.ArrayList<>();
				IList<Field92B> result = new List<Field92B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92B");
				Tag[] tags = tags("92B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92B(tag.Value));
					}
				}
				return result;
			}
		}


	// BaseSequenceCodeGenerator [seq=A]
		/// <summary>
		/// Class to model Sequence "A" in MT 541
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
		/// Class to model Sequence "A1" in MT 541
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


	// BaseSequenceCodeGenerator [seq=B]
		/// <summary>
		/// Class to model Sequence "B" in MT 541
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>TRADDET</em>
			/// </summary>
			public const string START_END_16RS = "TRADDET";
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
		/// Class to model Sequence "B1" in MT 541
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>FIA</em>
			/// </summary>
			public const string START_END_16RS = "FIA";
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
		/// Class to model Sequence "C" in MT 541
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>FIAC</em>
			/// </summary>
			public const string START_END_16RS = "FIAC";
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
		/// Get the single occurrence of SequenceC delimited by 16R/16S the value of SequenceC#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <returns> the found sequence or an empty sequence if none is found </returns>
		/// <seealso cref= SequenceC#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public SequenceC getSequenceC()
		public virtual SequenceC SequenceC
		{
			get
			{
				return new SequenceC(base.SwiftMessageNotNullOrException);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceC delimited by 16R/16S the value of SequenceC#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <seealso cref= SequenceC#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceC within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceC getSequenceC(SwiftTagListBlock parentSequence)
		public static SequenceC getSequenceC(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceC s = new SequenceC();
			SequenceC s = new SequenceC();
			s.Tags = parentSequence.getSubBlock(SequenceC.START_END_16RS).getTags();
			return s;
		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=C1]
		/// <summary>
		/// Class to model Sequence "C1" in MT 541
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>BREAK</em>
			/// </summary>
			public const string START_END_16RS = "BREAK";
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


	// BaseSequenceCodeGenerator [seq=D]
		/// <summary>
		/// Class to model Sequence "D" in MT 541
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>REPO</em>
			/// </summary>
			public const string START_END_16RS = "REPO";
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


	// BaseSequenceCodeGenerator [seq=E]
		/// <summary>
		/// Class to model Sequence "E" in MT 541
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceE extends SwiftTagListBlock
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

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>SETDET</em>
			/// </summary>
			public const string START_END_16RS = "SETDET";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceE newInstance(final Tag... tags)
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
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceE newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE result = new SequenceE();
				SequenceE result = new SequenceE();
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
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceE(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceE(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}
		/// <summary>
		/// Get the single occurrence of SequenceE delimited by 16R/16S the value of SequenceE#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <returns> the found sequence or an empty sequence if none is found </returns>
		/// <seealso cref= SequenceE#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public SequenceE getSequenceE()
		public virtual SequenceE SequenceE
		{
			get
			{
				return new SequenceE(base.SwiftMessageNotNullOrException);
			}
		}

		/// <summary>
		/// Get the single occurrence of SequenceE delimited by 16R/16S the value of SequenceE#START_END_16RS.
		/// The presence of this method indicates that this sequence can occur only once according to the Standard. </summary>
		/// <seealso cref= SequenceE#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceE within the complete message </param>
		/// <returns> the found sequence or an empty sequence if none is found, <em>never returns null</em>
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceE getSequenceE(SwiftTagListBlock parentSequence)
		public static SequenceE getSequenceE(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE s = new SequenceE();
			SequenceE s = new SequenceE();
			s.Tags = parentSequence.getSubBlock(SequenceE.START_END_16RS).getTags();
			return s;
		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=E1]
		/// <summary>
		/// Class to model Sequence "E1" in MT 541
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceE1 extends SwiftTagListBlock
		public class SequenceE1 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceE1() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceE1(final SwiftTagListBlock content)
			internal SequenceE1(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>SETPRTY</em>
			/// </summary>
			public const string START_END_16RS = "SETPRTY";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceE1 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceE1 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE1 result = new SequenceE1();
				SequenceE1 result = new SequenceE1();
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
			public static SequenceE1 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE1 result = new SequenceE1();
				SequenceE1 result = new SequenceE1();
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
//ORIGINAL LINE: public static SequenceE1 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceE1 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE1 result = new SequenceE1();
				SequenceE1 result = new SequenceE1();
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceE1(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceE1(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceE1 delimited by 16R/16S with value specified in SequenceE1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceE1#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceE1> getSequenceE1List()
		public virtual IList<SequenceE1> SequenceE1List
		{
			get
			{
				return getSequenceE1List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceE1 delimited by 16R/16S with value specified in SequenceE1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceE1#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceE1 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceE1> getSequenceE1List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceE1> getSequenceE1List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceE1.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceE1.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceE1> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceE1> result = new List<SequenceE1>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE1 s = new SequenceE1();
					SequenceE1 s = new SequenceE1();
					s.Tags = b.getSubBlock(SequenceE1.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=E2]
		/// <summary>
		/// Class to model Sequence "E2" in MT 541
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceE2 extends SwiftTagListBlock
		public class SequenceE2 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceE2() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceE2(final SwiftTagListBlock content)
			internal SequenceE2(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>CSHPRTY</em>
			/// </summary>
			public const string START_END_16RS = "CSHPRTY";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceE2 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceE2 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE2 result = new SequenceE2();
				SequenceE2 result = new SequenceE2();
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
			public static SequenceE2 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE2 result = new SequenceE2();
				SequenceE2 result = new SequenceE2();
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
//ORIGINAL LINE: public static SequenceE2 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceE2 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE2 result = new SequenceE2();
				SequenceE2 result = new SequenceE2();
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceE2(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceE2(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceE2 delimited by 16R/16S with value specified in SequenceE2#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceE2#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceE2> getSequenceE2List()
		public virtual IList<SequenceE2> SequenceE2List
		{
			get
			{
				return getSequenceE2List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceE2 delimited by 16R/16S with value specified in SequenceE2#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceE2#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceE2 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceE2> getSequenceE2List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceE2> getSequenceE2List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceE2.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceE2.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceE2> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceE2> result = new List<SequenceE2>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE2 s = new SequenceE2();
					SequenceE2 s = new SequenceE2();
					s.Tags = b.getSubBlock(SequenceE2.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=E3]
		/// <summary>
		/// Class to model Sequence "E3" in MT 541
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceE3 extends SwiftTagListBlock
		public class SequenceE3 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceE3() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceE3(final SwiftTagListBlock content)
			internal SequenceE3(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>AMT</em>
			/// </summary>
			public const string START_END_16RS = "AMT";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceE3 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceE3 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE3 result = new SequenceE3();
				SequenceE3 result = new SequenceE3();
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
			public static SequenceE3 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE3 result = new SequenceE3();
				SequenceE3 result = new SequenceE3();
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
//ORIGINAL LINE: public static SequenceE3 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceE3 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE3 result = new SequenceE3();
				SequenceE3 result = new SequenceE3();
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceE3(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceE3(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceE3 delimited by 16R/16S with value specified in SequenceE3#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceE3#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceE3> getSequenceE3List()
		public virtual IList<SequenceE3> SequenceE3List
		{
			get
			{
				return getSequenceE3List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceE3 delimited by 16R/16S with value specified in SequenceE3#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceE3#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceE3 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceE3> getSequenceE3List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceE3> getSequenceE3List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceE3.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceE3.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceE3> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceE3> result = new List<SequenceE3>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceE3 s = new SequenceE3();
					SequenceE3 s = new SequenceE3();
					s.Tags = b.getSubBlock(SequenceE3.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=F]
		/// <summary>
		/// Class to model Sequence "F" in MT 541
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceF extends SwiftTagListBlock
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

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>OTHRPRTY</em>
			/// </summary>
			public const string START_END_16RS = "OTHRPRTY";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceF newInstance(final Tag... tags)
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
				result.append(END_TAG);
				return result;
			}

			/// <summary>
			/// Create an empty $sequenceClassname.
			/// This method is intended to avoid disambiguation for the newInstance() with variable list of blocks or tags </summary>
			/// <returns> a new instance of the sequence
			/// @since 7.6 </returns>
			public static SequenceF newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceF result = new SequenceF();
				SequenceF result = new SequenceF();
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
				result.append(END_TAG);
				return result;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceF(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceF(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceF delimited by 16R/16S with value specified in SequenceF#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceF#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceF> getSequenceFList()
		public virtual IList<SequenceF> SequenceFList
		{
			get
			{
				return getSequenceFList(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceF delimited by 16R/16S with value specified in SequenceF#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceF#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceF within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceF> getSequenceFList(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceF> getSequenceFList(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceF.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceF.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceF> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceF> result = new List<SequenceF>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceF s = new SequenceF();
					SequenceF s = new SequenceF();
					s.Tags = b.getSubBlock(SequenceF.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator




	}

}