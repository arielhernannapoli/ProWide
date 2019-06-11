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
	/// <strong>MT 566 - Corporate Action Confirmation</strong>
	/// 
	/// <para>
	/// SWIFT MT566 (ISO 15022) message structure:
	/// <br>
	/// <div class="scheme"><ul>
	/// <li class="sequence">
	/// Sequence A - General Information (M)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 20
	/// (M) (repetitive)<ul><li>FieldsetItem 20 C (M)</li><li>FieldsetItem 20 C (M)</li><li>FieldsetItem 20 C (O)</li></ul></li><li class="field">Field 23 G (M)</li>
	/// <li class="field">Field 22 F (M)</li>
	/// <li class="field">Field 98 A,C (O)</li>
	/// <li class="sequence">
	/// Sequence A1 - Linkages (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 22 F (O)</li>
	/// <li class="field">Field 13 A,B (O)</li>
	/// <li class="field">Field 20 C (M)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence B - Underlying Securities (M)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 95 P,R (O)</li>
	/// <li class="field">Field 97 A (M)</li>
	/// <li class="field">Field 94 B,C,F (O)</li>
	/// <li class="field">Field 35 B (M)</li>
	/// <li class="sequence">
	/// Sequence B1 - Financial Instrument Attributes (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 94 B (O)</li>
	/// <li class="field">Field 22 F (O)</li>
	/// <li class="field">Field 12 A,C (O)</li>
	/// <li class="field">Field 11 A (O)</li>
	/// <li class="fieldset">
	/// Fieldset 98
	/// (O)<ul><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li></ul></li><li class="fieldset">
	/// Fieldset 92
	/// (O)<ul><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 D (O)</li></ul></li><li class="fieldset">
	/// Fieldset 36
	/// (O)<ul><li>FieldsetItem 36 B (O)</li><li>FieldsetItem 36 B (O)</li></ul></li><li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="fieldset">
	/// Fieldset 93
	/// (O) (repetitive)<ul><li>FieldsetItem 93 B,C (O) (repetitive)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O) (repetitive)</li><li>FieldsetItem 93 B,C (O) (repetitive)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O) (repetitive)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li><li>FieldsetItem 93 B,C (O)</li></ul></li><li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence C - Corporate Action Details (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 98
	/// (O)<ul><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C,E (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li></ul></li><li class="fieldset">
	/// Fieldset 69
	/// (O)<ul><li>FieldsetItem 69 A,B,C,D,E,F (O)</li><li>FieldsetItem 69 A,B,C,D,E,F (O)</li><li>FieldsetItem 69 A,B,C,D,E,F (O)</li><li>FieldsetItem 69 A,B,C,D,E,F (O)</li><li>FieldsetItem 69 A,B,C,D,E,F (O)</li><li>FieldsetItem 69 A,B,C,D,E,F (O)</li></ul></li><li class="field">Field 99 A (O)</li>
	/// <li class="fieldset">
	/// Fieldset 92
	/// (O)<ul><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 F,P (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A,K (O)</li><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 A,F (O)</li></ul></li><li class="fieldset">
	/// Fieldset 90
	/// (O)<ul><li>FieldsetItem 90 A,B (O)</li><li>FieldsetItem 90 A,B,L (O)</li><li>FieldsetItem 90 A,B,L (O)</li></ul></li><li class="fieldset">
	/// Fieldset 36
	/// (O)<ul><li>FieldsetItem 36 B,C (O)</li><li>FieldsetItem 36 B,C (O)</li><li>FieldsetItem 36 B,C (O)</li><li>FieldsetItem 36 B (O)</li><li>FieldsetItem 36 B (O)</li><li>FieldsetItem 36 B (O)</li></ul></li><li class="field">Field 13 A,B (O) (repetitive)</li>
	/// <li class="fieldset">
	/// Fieldset 17
	/// (O)<ul><li>FieldsetItem 17 B (O)</li><li>FieldsetItem 17 B (O)</li><li>FieldsetItem 17 B (O)</li></ul></li><li class="fieldset">
	/// Fieldset 22
	/// (O) (repetitive)<ul><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O) (repetitive)</li><li>FieldsetItem 22 F (O) (repetitive)</li><li>FieldsetItem 22 F (O) (repetitive)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li></ul></li><li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence D - Corporate Action Confirmation (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 13 A (M)</li>
	/// <li class="fieldset">
	/// Fieldset 22
	/// (M) (repetitive)<ul><li>FieldsetItem 22 F,H (M)</li><li>FieldsetItem 22 F (O) (repetitive)</li><li>FieldsetItem 22 F (O)</li></ul></li><li class="field">Field 11 A (O)</li>
	/// <li class="fieldset">
	/// Fieldset 98
	/// (O)<ul><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C,E (O)</li><li>FieldsetItem 98 A,B,C,E (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C,E,F (O)</li><li>FieldsetItem 98 A,B,C,E (O)</li><li>FieldsetItem 98 A,B,C,E (O)</li></ul></li><li class="fieldset">
	/// Fieldset 69
	/// (O)<ul><li>FieldsetItem 69 A,B,C,D,E,F (O)</li><li>FieldsetItem 69 A,B,C,D,E,F (O)</li><li>FieldsetItem 69 A,B,C,D,E,F (O)</li></ul></li><li class="fieldset">
	/// Fieldset 92
	/// (O) (repetitive)<ul><li>FieldsetItem 92 F,H,J (O) (repetitive)</li><li>FieldsetItem 92 A,F,R (O) (repetitive)</li><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A,F,J (O) (repetitive)</li><li>FieldsetItem 92 J (O) (repetitive)</li><li>FieldsetItem 92 F,H,J (O) (repetitive)</li><li>FieldsetItem 92 A,F,R (O) (repetitive)</li></ul></li><li class="fieldset">
	/// Fieldset 90
	/// (O)<ul><li>FieldsetItem 90 A,B (O)</li><li>FieldsetItem 90 A,B (O)</li></ul></li><li class="field">Field 94 B (O)</li>
	/// <li class="sequence">
	/// Sequence D1 - Securities Movement (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 22
	/// (M) (repetitive)<ul><li>FieldsetItem 22 H (M)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 H (O)</li><li>FieldsetItem 22 F (O) (repetitive)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O)</li></ul></li><li class="field">Field 35 B (M)</li>
	/// <li class="sequence">
	/// Sequence D1a - Financial Instrument Attributes (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 94 B (O)</li>
	/// <li class="field">Field 22 F (O)</li>
	/// <li class="field">Field 12 A,C (O)</li>
	/// <li class="field">Field 11 A (O)</li>
	/// <li class="fieldset">
	/// Fieldset 98
	/// (O)<ul><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li><li>FieldsetItem 98 A (O)</li></ul></li><li class="field">Field 90 A,B (O)</li>
	/// <li class="fieldset">
	/// Fieldset 92
	/// (O)<ul><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li></ul></li><li class="fieldset">
	/// Fieldset 36
	/// (O)<ul><li>FieldsetItem 36 B (O)</li><li>FieldsetItem 36 B (O)</li><li>FieldsetItem 36 B (O)</li><li>FieldsetItem 36 B (O)</li></ul></li><li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 36 B (O) (repetitive)</li>
	/// <li class="fieldset">
	/// Fieldset 94
	/// (O)<ul><li>FieldsetItem 94 B,C,F (O)</li><li>FieldsetItem 94 C (O)</li></ul></li><li class="field">Field 22 F (O)</li>
	/// <li class="field">Field 11 A (O)</li>
	/// <li class="fieldset">
	/// Fieldset 90
	/// (O)<ul><li>FieldsetItem 90 A,B (O)</li><li>FieldsetItem 90 A,B (O)</li><li>FieldsetItem 90 A,B,F,J,L (O)</li><li>FieldsetItem 90 A,B,K (O)</li><li>FieldsetItem 90 B (O)</li></ul></li><li class="fieldset">
	/// Fieldset 92
	/// (O) (repetitive)<ul><li>FieldsetItem 92 D,L (O)</li><li>FieldsetItem 92 D,L,M,N (O)</li><li>FieldsetItem 92 D,L (O)</li><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 A (O)</li></ul></li><li class="fieldset">
	/// Fieldset 98
	/// (M) (repetitive)<ul><li>FieldsetItem 98 A,C (M)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C,E (O)</li><li>FieldsetItem 98 A,B,C (O)</li><li>FieldsetItem 98 A,B,C (O)</li></ul></li><li class="sequence">
	/// Sequence D1b - Receive/Deliver (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 95
	/// (M) (repetitive)<ul><li>FieldsetItem 95 P,Q,R,C (M)</li><li>FieldsetItem 95 S (O) (repetitive)</li></ul></li><li class="field">Field 97 A (O)</li>
	/// <li class="field">Field 20 C (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence D2 - Cash Movements (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 22
	/// (M) (repetitive)<ul><li>FieldsetItem 22 H (M)</li><li>FieldsetItem 22 H (O)</li><li>FieldsetItem 22 F (O)</li><li>FieldsetItem 22 F (O) (repetitive)</li><li>FieldsetItem 22 F (O)</li></ul></li><li class="field">Field 94 C (O)</li>
	/// <li class="field">Field 97 A,E (O)</li>
	/// <li class="sequence">
	/// Sequence D2a - Cash Parties (O) (repetitive)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 95
	/// (M) (repetitive)<ul><li>FieldsetItem 95 P,Q,R (M)</li><li>FieldsetItem 95 S (O)</li></ul></li><li class="field">Field 97 A,E (O)</li>
	/// <li class="field">Field 20 C (O)</li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="fieldset">
	/// Fieldset 19
	/// (M) (repetitive)<ul><li>FieldsetItem 19 B (M)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li><li>FieldsetItem 19 B (O)</li></ul></li><li class="fieldset">
	/// Fieldset 98
	/// (M) (repetitive)<ul><li>FieldsetItem 98 A,C (M)</li><li>FieldsetItem 98 A,C (O)</li><li>FieldsetItem 98 A,C,E (O)</li><li>FieldsetItem 98 A,C (O)</li><li>FieldsetItem 98 A,C (O)</li></ul></li><li class="fieldset">
	/// Fieldset 92
	/// (O) (repetitive)<ul><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 F (O)</li><li>FieldsetItem 92 A,F,M (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 F,H,J (O) (repetitive)</li><li>FieldsetItem 92 B (O)</li><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 A,F,J (O) (repetitive)</li><li>FieldsetItem 92 F,H,J (O) (repetitive)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A,F,M (O)</li><li>FieldsetItem 92 A,F (O) (repetitive)</li><li>FieldsetItem 92 A,F,R (O) (repetitive)</li><li>FieldsetItem 92 A,F (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A (O)</li><li>FieldsetItem 92 A,F,R (O) (repetitive)</li><li>FieldsetItem 92 A,F,J,R (O) (repetitive)</li></ul></li><li class="fieldset">
	/// Fieldset 90
	/// (O)<ul><li>FieldsetItem 90 A,B,F,J,L (O)</li><li>FieldsetItem 90 A,B,K (O)</li></ul></li><li class="sequence">
	/// Sequence D2b - Tax Voucher Details (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="field">Field 20 C (M)</li>
	/// <li class="fieldset">
	/// Fieldset 98
	/// (O)<ul><li>FieldsetItem 98 A,C (O)</li><li>FieldsetItem 98 A,C (O)</li></ul></li><li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="field">Field 16 S (M)</li>
	/// </ul></li>
	/// <li class="sequence">
	/// Sequence E - Additional Information (O)<ul><li class="field">Field 16 R (M)</li>
	/// <li class="fieldset">
	/// Fieldset 70
	/// (O) (repetitive)<ul><li>FieldsetItem 70 E (O) (repetitive)</li><li>FieldsetItem 70 E (O) (repetitive)</li><li>FieldsetItem 70 E (O) (repetitive)</li><li>FieldsetItem 70 E (O) (repetitive)</li></ul></li><li class="fieldset">
	/// Fieldset 95
	/// (O) (repetitive)<ul><li>FieldsetItem 95 P,Q,R (O)</li><li>FieldsetItem 95 P,Q,R (O)</li><li>FieldsetItem 95 P,Q,R (O) (repetitive)</li><li>FieldsetItem 95 P,Q,R (O) (repetitive)</li><li>FieldsetItem 95 P,Q,R (O) (repetitive)</li></ul></li><li class="field">Field 16 S (M)</li>
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
//ORIGINAL LINE: @Generated public class MT566 extends com.prowidesoftware.swift.model.mt.AbstractMT implements java.io.Serializable
	[Serializable]
	public class MT566 : AbstractMT
	{
		/// <summary>
		/// Constant identifying the SRU to which this class belongs to.
		/// </summary>
		public const int SRU = 2018;
		private const long serialVersionUID = 1L;
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MT566).Name);

		/// <summary>
		/// Constant for MT name, this is part of the classname, after <code>MT</code>
		/// </summary>
		public const string NAME = "566";

	// begin qualifiers constants	

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
		/// Constant for qualifier with value ADDB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ADDB = "ADDB";
		[Obsolete]
		public const string ADDB = "ADDB";

		/// <summary>
		/// Constant for qualifier with value ADDINFO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ADDINFO = "ADDINFO";
		[Obsolete]
		public const string ADDINFO = "ADDINFO";

		/// <summary>
		/// Constant for qualifier with value ADEX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ADEX = "ADEX";
		[Obsolete]
		public const string ADEX = "ADEX";

		/// <summary>
		/// Constant for qualifier with value ADSR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ADSR = "ADSR";
		[Obsolete]
		public const string ADSR = "ADSR";

		/// <summary>
		/// Constant for qualifier with value ADTX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ADTX = "ADTX";
		[Obsolete]
		public const string ADTX = "ADTX";

		/// <summary>
		/// Constant for qualifier with value AFFB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AFFB = "AFFB";
		[Obsolete]
		public const string AFFB = "AFFB";

		/// <summary>
		/// Constant for qualifier with value ALTE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ALTE = "ALTE";
		[Obsolete]
		public const string ALTE = "ALTE";

		/// <summary>
		/// Constant for qualifier with value ANOU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ANOU = "ANOU";
		[Obsolete]
		public const string ANOU = "ANOU";

		/// <summary>
		/// Constant for qualifier with value ARRE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ARRE = "ARRE";
		[Obsolete]
		public const string ARRE = "ARRE";

		/// <summary>
		/// Constant for qualifier with value ATAX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ATAX = "ATAX";
		[Obsolete]
		public const string ATAX = "ATAX";

		/// <summary>
		/// Constant for qualifier with value AVAL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String AVAL = "AVAL";
		[Obsolete]
		public const string AVAL = "AVAL";

		/// <summary>
		/// Constant for qualifier with value BAGA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BAGA = "BAGA";
		[Obsolete]
		public const string BAGA = "BAGA";

		/// <summary>
		/// Constant for qualifier with value BAST 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BAST = "BAST";
		[Obsolete]
		public const string BAST = "BAST";

		/// <summary>
		/// Constant for qualifier with value BENM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BENM = "BENM";
		[Obsolete]
		public const string BENM = "BENM";

		/// <summary>
		/// Constant for qualifier with value BIDI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BIDI = "BIDI";
		[Obsolete]
		public const string BIDI = "BIDI";

		/// <summary>
		/// Constant for qualifier with value BLOK 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BLOK = "BLOK";
		[Obsolete]
		public const string BLOK = "BLOK";

		/// <summary>
		/// Constant for qualifier with value BOCL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BOCL = "BOCL";
		[Obsolete]
		public const string BOCL = "BOCL";

		/// <summary>
		/// Constant for qualifier with value BOLQ 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BOLQ = "BOLQ";
		[Obsolete]
		public const string BOLQ = "BOLQ";

		/// <summary>
		/// Constant for qualifier with value BORR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BORR = "BORR";
		[Obsolete]
		public const string BORR = "BORR";

		/// <summary>
		/// Constant for qualifier with value BWIT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String BWIT = "BWIT";
		[Obsolete]
		public const string BWIT = "BWIT";

		/// <summary>
		/// Constant for qualifier with value CABF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CABF = "CABF";
		[Obsolete]
		public const string CABF = "CABF";

		/// <summary>
		/// Constant for qualifier with value CACF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CACF = "CACF";
		[Obsolete]
		public const string CACF = "CACF";

		/// <summary>
		/// Constant for qualifier with value CACN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CACN = "CACN";
		[Obsolete]
		public const string CACN = "CACN";

		/// <summary>
		/// Constant for qualifier with value CACONF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CACONF = "CACONF";
		[Obsolete]
		public const string CACONF = "CACONF";

		/// <summary>
		/// Constant for qualifier with value CADETL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CADETL = "CADETL";
		[Obsolete]
		public const string CADETL = "CADETL";

		/// <summary>
		/// Constant for qualifier with value CAEV 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CAEV = "CAEV";
		[Obsolete]
		public const string CAEV = "CAEV";

		/// <summary>
		/// Constant for qualifier with value CALD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CALD = "CALD";
		[Obsolete]
		public const string CALD = "CALD";

		/// <summary>
		/// Constant for qualifier with value CAON 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CAON = "CAON";
		[Obsolete]
		public const string CAON = "CAON";

		/// <summary>
		/// Constant for qualifier with value CAOP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CAOP = "CAOP";
		[Obsolete]
		public const string CAOP = "CAOP";

		/// <summary>
		/// Constant for qualifier with value CAPG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CAPG = "CAPG";
		[Obsolete]
		public const string CAPG = "CAPG";

		/// <summary>
		/// Constant for qualifier with value CASH 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CASH = "CASH";
		[Obsolete]
		public const string CASH = "CASH";

		/// <summary>
		/// Constant for qualifier with value CASHMOVE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CASHMOVE = "CASHMOVE";
		[Obsolete]
		public const string CASHMOVE = "CASHMOVE";

		/// <summary>
		/// Constant for qualifier with value CAVA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CAVA = "CAVA";
		[Obsolete]
		public const string CAVA = "CAVA";

		/// <summary>
		/// Constant for qualifier with value CDFI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CDFI = "CDFI";
		[Obsolete]
		public const string CDFI = "CDFI";

		/// <summary>
		/// Constant for qualifier with value CERT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CERT = "CERT";
		[Obsolete]
		public const string CERT = "CERT";

		/// <summary>
		/// Constant for qualifier with value CHAN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CHAN = "CHAN";
		[Obsolete]
		public const string CHAN = "CHAN";

		/// <summary>
		/// Constant for qualifier with value CHAR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CHAR = "CHAR";
		[Obsolete]
		public const string CHAR = "CHAR";

		/// <summary>
		/// Constant for qualifier with value CINL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CINL = "CINL";
		[Obsolete]
		public const string CINL = "CINL";

		/// <summary>
		/// Constant for qualifier with value CLAM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CLAM = "CLAM";
		[Obsolete]
		public const string CLAM = "CLAM";

		/// <summary>
		/// Constant for qualifier with value CLAS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CLAS = "CLAS";
		[Obsolete]
		public const string CLAS = "CLAS";

		/// <summary>
		/// Constant for qualifier with value CLCP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CLCP = "CLCP";
		[Obsolete]
		public const string CLCP = "CLCP";

		/// <summary>
		/// Constant for qualifier with value COAF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COAF = "COAF";
		[Obsolete]
		public const string COAF = "COAF";

		/// <summary>
		/// Constant for qualifier with value CODO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CODO = "CODO";
		[Obsolete]
		public const string CODO = "CODO";

		/// <summary>
		/// Constant for qualifier with value CODU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CODU = "CODU";
		[Obsolete]
		public const string CODU = "CODU";

		/// <summary>
		/// Constant for qualifier with value COIN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COIN = "COIN";
		[Obsolete]
		public const string COIN = "COIN";

		/// <summary>
		/// Constant for qualifier with value COLI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COLI = "COLI";
		[Obsolete]
		public const string COLI = "COLI";

		/// <summary>
		/// Constant for qualifier with value COLO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COLO = "COLO";
		[Obsolete]
		public const string COLO = "COLO";

		/// <summary>
		/// Constant for qualifier with value COMP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COMP = "COMP";
		[Obsolete]
		public const string COMP = "COMP";

		/// <summary>
		/// Constant for qualifier with value CONB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CONB = "CONB";
		[Obsolete]
		public const string CONB = "CONB";

		/// <summary>
		/// Constant for qualifier with value CONT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CONT = "CONT";
		[Obsolete]
		public const string CONT = "CONT";

		/// <summary>
		/// Constant for qualifier with value CONV 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CONV = "CONV";
		[Obsolete]
		public const string CONV = "CONV";

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
		/// Constant for qualifier with value COUP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String COUP = "COUP";
		[Obsolete]
		public const string COUP = "COUP";

		/// <summary>
		/// Constant for qualifier with value CRDB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CRDB = "CRDB";
		[Obsolete]
		public const string CRDB = "CRDB";

		/// <summary>
		/// Constant for qualifier with value CSHPRTY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CSHPRTY = "CSHPRTY";
		[Obsolete]
		public const string CSHPRTY = "CSHPRTY";

		/// <summary>
		/// Constant for qualifier with value CSPD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CSPD = "CSPD";
		[Obsolete]
		public const string CSPD = "CSPD";

		/// <summary>
		/// Constant for qualifier with value CVPR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String CVPR = "CVPR";
		[Obsolete]
		public const string CVPR = "CVPR";

		/// <summary>
		/// Constant for qualifier with value DAAC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DAAC = "DAAC";
		[Obsolete]
		public const string DAAC = "DAAC";

		/// <summary>
		/// Constant for qualifier with value DDTE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DDTE = "DDTE";
		[Obsolete]
		public const string DDTE = "DDTE";

		/// <summary>
		/// Constant for qualifier with value DECL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DECL = "DECL";
		[Obsolete]
		public const string DECL = "DECL";

		/// <summary>
		/// Constant for qualifier with value DEEM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DEEM = "DEEM";
		[Obsolete]
		public const string DEEM = "DEEM";

		/// <summary>
		/// Constant for qualifier with value DENO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DENO = "DENO";
		[Obsolete]
		public const string DENO = "DENO";

		/// <summary>
		/// Constant for qualifier with value DISF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DISF = "DISF";
		[Obsolete]
		public const string DISF = "DISF";

		/// <summary>
		/// Constant for qualifier with value DITY 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DITY = "DITY";
		[Obsolete]
		public const string DITY = "DITY";

		/// <summary>
		/// Constant for qualifier with value DIVI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DIVI = "DIVI";
		[Obsolete]
		public const string DIVI = "DIVI";

		/// <summary>
		/// Constant for qualifier with value DIVR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DIVR = "DIVR";
		[Obsolete]
		public const string DIVR = "DIVR";

		/// <summary>
		/// Constant for qualifier with value DUPL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String DUPL = "DUPL";
		[Obsolete]
		public const string DUPL = "DUPL";

		/// <summary>
		/// Constant for qualifier with value EARL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EARL = "EARL";
		[Obsolete]
		public const string EARL = "EARL";

		/// <summary>
		/// Constant for qualifier with value ECIO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ECIO = "ECIO";
		[Obsolete]
		public const string ECIO = "ECIO";

		/// <summary>
		/// Constant for qualifier with value EFFD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EFFD = "EFFD";
		[Obsolete]
		public const string EFFD = "EFFD";

		/// <summary>
		/// Constant for qualifier with value ELIG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ELIG = "ELIG";
		[Obsolete]
		public const string ELIG = "ELIG";

		/// <summary>
		/// Constant for qualifier with value EQUL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EQUL = "EQUL";
		[Obsolete]
		public const string EQUL = "EQUL";

		/// <summary>
		/// Constant for qualifier with value ESOF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ESOF = "ESOF";
		[Obsolete]
		public const string ESOF = "ESOF";

		/// <summary>
		/// Constant for qualifier with value ETYP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ETYP = "ETYP";
		[Obsolete]
		public const string ETYP = "ETYP";

		/// <summary>
		/// Constant for qualifier with value EUTR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EUTR = "EUTR";
		[Obsolete]
		public const string EUTR = "EUTR";

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
		/// Constant for qualifier with value EXPI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String EXPI = "EXPI";
		[Obsolete]
		public const string EXPI = "EXPI";

		/// <summary>
		/// Constant for qualifier with value FIA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FIA = "FIA";
		[Obsolete]
		public const string FIA = "FIA";

		/// <summary>
		/// Constant for qualifier with value FISC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FISC = "FISC";
		[Obsolete]
		public const string FISC = "FISC";

		/// <summary>
		/// Constant for qualifier with value FLFR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FLFR = "FLFR";
		[Obsolete]
		public const string FLFR = "FLFR";

		/// <summary>
		/// Constant for qualifier with value FOLQ 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FOLQ = "FOLQ";
		[Obsolete]
		public const string FOLQ = "FOLQ";

		/// <summary>
		/// Constant for qualifier with value FRAQ 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FRAQ = "FRAQ";
		[Obsolete]
		public const string FRAQ = "FRAQ";

		/// <summary>
		/// Constant for qualifier with value FRNR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FRNR = "FRNR";
		[Obsolete]
		public const string FRNR = "FRNR";

		/// <summary>
		/// Constant for qualifier with value FTCA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FTCA = "FTCA";
		[Obsolete]
		public const string FTCA = "FTCA";

		/// <summary>
		/// Constant for qualifier with value FXDT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String FXDT = "FXDT";
		[Obsolete]
		public const string FXDT = "FXDT";

		/// <summary>
		/// Constant for qualifier with value GENL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String GENL = "GENL";
		[Obsolete]
		public const string GENL = "GENL";

		/// <summary>
		/// Constant for qualifier with value GRSS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String GRSS = "GRSS";
		[Obsolete]
		public const string GRSS = "GRSS";

		/// <summary>
		/// Constant for qualifier with value IFIX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String IFIX = "IFIX";
		[Obsolete]
		public const string IFIX = "IFIX";

		/// <summary>
		/// Constant for qualifier with value INCE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INCE = "INCE";
		[Obsolete]
		public const string INCE = "INCE";

		/// <summary>
		/// Constant for qualifier with value INCO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INCO = "INCO";
		[Obsolete]
		public const string INCO = "INCO";

		/// <summary>
		/// Constant for qualifier with value INDC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INDC = "INDC";
		[Obsolete]
		public const string INDC = "INDC";

		/// <summary>
		/// Constant for qualifier with value INDM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INDM = "INDM";
		[Obsolete]
		public const string INDM = "INDM";

		/// <summary>
		/// Constant for qualifier with value INDX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INDX = "INDX";
		[Obsolete]
		public const string INDX = "INDX";

		/// <summary>
		/// Constant for qualifier with value INPE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INPE = "INPE";
		[Obsolete]
		public const string INPE = "INPE";

		/// <summary>
		/// Constant for qualifier with value INTP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INTP = "INTP";
		[Obsolete]
		public const string INTP = "INTP";

		/// <summary>
		/// Constant for qualifier with value INTR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String INTR = "INTR";
		[Obsolete]
		public const string INTR = "INTR";

		/// <summary>
		/// Constant for qualifier with value ISAG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ISAG = "ISAG";
		[Obsolete]
		public const string ISAG = "ISAG";

		/// <summary>
		/// Constant for qualifier with value ISSU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ISSU = "ISSU";
		[Obsolete]
		public const string ISSU = "ISSU";

		/// <summary>
		/// Constant for qualifier with value ITYP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String ITYP = "ITYP";
		[Obsolete]
		public const string ITYP = "ITYP";

		/// <summary>
		/// Constant for qualifier with value LINK 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LINK = "LINK";
		[Obsolete]
		public const string LINK = "LINK";

		/// <summary>
		/// Constant for qualifier with value LOAN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOAN = "LOAN";
		[Obsolete]
		public const string LOAN = "LOAN";

		/// <summary>
		/// Constant for qualifier with value LOCO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOCO = "LOCO";
		[Obsolete]
		public const string LOCO = "LOCO";

		/// <summary>
		/// Constant for qualifier with value LOTO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String LOTO = "LOTO";
		[Obsolete]
		public const string LOTO = "LOTO";

		/// <summary>
		/// Constant for qualifier with value MATU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MATU = "MATU";
		[Obsolete]
		public const string MATU = "MATU";

		/// <summary>
		/// Constant for qualifier with value MAXP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MAXP = "MAXP";
		[Obsolete]
		public const string MAXP = "MAXP";

		/// <summary>
		/// Constant for qualifier with value MEET 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MEET = "MEET";
		[Obsolete]
		public const string MEET = "MEET";

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
		/// Constant for qualifier with value MFDV 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MFDV = "MFDV";
		[Obsolete]
		public const string MFDV = "MFDV";

		/// <summary>
		/// Constant for qualifier with value MICO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MICO = "MICO";
		[Obsolete]
		public const string MICO = "MICO";

		/// <summary>
		/// Constant for qualifier with value MIEX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MIEX = "MIEX";
		[Obsolete]
		public const string MIEX = "MIEX";

		/// <summary>
		/// Constant for qualifier with value MILT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MILT = "MILT";
		[Obsolete]
		public const string MILT = "MILT";

		/// <summary>
		/// Constant for qualifier with value MINO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MINO = "MINO";
		[Obsolete]
		public const string MINO = "MINO";

		/// <summary>
		/// Constant for qualifier with value MINP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MINP = "MINP";
		[Obsolete]
		public const string MINP = "MINP";

		/// <summary>
		/// Constant for qualifier with value MKDT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MKDT = "MKDT";
		[Obsolete]
		public const string MKDT = "MKDT";

		/// <summary>
		/// Constant for qualifier with value MKTC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MKTC = "MKTC";
		[Obsolete]
		public const string MKTC = "MKTC";

		/// <summary>
		/// Constant for qualifier with value MRKT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String MRKT = "MRKT";
		[Obsolete]
		public const string MRKT = "MRKT";

		/// <summary>
		/// Constant for qualifier with value NBLT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NBLT = "NBLT";
		[Obsolete]
		public const string NBLT = "NBLT";

		/// <summary>
		/// Constant for qualifier with value NDIP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NDIP = "NDIP";
		[Obsolete]
		public const string NDIP = "NDIP";

		/// <summary>
		/// Constant for qualifier with value NETT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NETT = "NETT";
		[Obsolete]
		public const string NETT = "NETT";

		/// <summary>
		/// Constant for qualifier with value NEWD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NEWD = "NEWD";
		[Obsolete]
		public const string NEWD = "NEWD";

		/// <summary>
		/// Constant for qualifier with value NEWM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NEWM = "NEWM";
		[Obsolete]
		public const string NEWM = "NEWM";

		/// <summary>
		/// Constant for qualifier with value NEWO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NEWO = "NEWO";
		[Obsolete]
		public const string NEWO = "NEWO";

		/// <summary>
		/// Constant for qualifier with value NOMI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NOMI = "NOMI";
		[Obsolete]
		public const string NOMI = "NOMI";

		/// <summary>
		/// Constant for qualifier with value NRAT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NRAT = "NRAT";
		[Obsolete]
		public const string NRAT = "NRAT";

		/// <summary>
		/// Constant for qualifier with value NSIS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NSIS = "NSIS";
		[Obsolete]
		public const string NSIS = "NSIS";

		/// <summary>
		/// Constant for qualifier with value NTAX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String NTAX = "NTAX";
		[Obsolete]
		public const string NTAX = "NTAX";

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
		/// Constant for qualifier with value OFFE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OFFE = "OFFE";
		[Obsolete]
		public const string OFFE = "OFFE";

		/// <summary>
		/// Constant for qualifier with value OFFR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OFFR = "OFFR";
		[Obsolete]
		public const string OFFR = "OFFR";

		/// <summary>
		/// Constant for qualifier with value OPTF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OPTF = "OPTF";
		[Obsolete]
		public const string OPTF = "OPTF";

		/// <summary>
		/// Constant for qualifier with value OPTN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OPTN = "OPTN";
		[Obsolete]
		public const string OPTN = "OPTN";

		/// <summary>
		/// Constant for qualifier with value OSUB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OSUB = "OSUB";
		[Obsolete]
		public const string OSUB = "OSUB";

		/// <summary>
		/// Constant for qualifier with value OVEP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String OVEP = "OVEP";
		[Obsolete]
		public const string OVEP = "OVEP";

		/// <summary>
		/// Constant for qualifier with value PACO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PACO = "PACO";
		[Obsolete]
		public const string PACO = "PACO";

		/// <summary>
		/// Constant for qualifier with value PAMM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PAMM = "PAMM";
		[Obsolete]
		public const string PAMM = "PAMM";

		/// <summary>
		/// Constant for qualifier with value PARL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PARL = "PARL";
		[Obsolete]
		public const string PARL = "PARL";

		/// <summary>
		/// Constant for qualifier with value PAYA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PAYA = "PAYA";
		[Obsolete]
		public const string PAYA = "PAYA";

		/// <summary>
		/// Constant for qualifier with value PAYD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PAYD = "PAYD";
		[Obsolete]
		public const string PAYD = "PAYD";

		/// <summary>
		/// Constant for qualifier with value PEND 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PEND = "PEND";
		[Obsolete]
		public const string PEND = "PEND";

		/// <summary>
		/// Constant for qualifier with value PENR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PENR = "PENR";
		[Obsolete]
		public const string PENR = "PENR";

		/// <summary>
		/// Constant for qualifier with value PLIS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PLIS = "PLIS";
		[Obsolete]
		public const string PLIS = "PLIS";

		/// <summary>
		/// Constant for qualifier with value PODT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PODT = "PODT";
		[Obsolete]
		public const string PODT = "PODT";

		/// <summary>
		/// Constant for qualifier with value POST 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String POST = "POST";
		[Obsolete]
		public const string POST = "POST";

		/// <summary>
		/// Constant for qualifier with value PPDT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PPDT = "PPDT";
		[Obsolete]
		public const string PPDT = "PPDT";

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
		/// Constant for qualifier with value PRIN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PRIN = "PRIN";
		[Obsolete]
		public const string PRIN = "PRIN";

		/// <summary>
		/// Constant for qualifier with value PROC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PROC = "PROC";
		[Obsolete]
		public const string PROC = "PROC";

		/// <summary>
		/// Constant for qualifier with value PROD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PROD = "PROD";
		[Obsolete]
		public const string PROD = "PROD";

		/// <summary>
		/// Constant for qualifier with value PROR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PROR = "PROR";
		[Obsolete]
		public const string PROR = "PROR";

		/// <summary>
		/// Constant for qualifier with value PRPP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PRPP = "PRPP";
		[Obsolete]
		public const string PRPP = "PRPP";

		/// <summary>
		/// Constant for qualifier with value PSTA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PSTA = "PSTA";
		[Obsolete]
		public const string PSTA = "PSTA";

		/// <summary>
		/// Constant for qualifier with value PTSC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PTSC = "PTSC";
		[Obsolete]
		public const string PTSC = "PTSC";

		/// <summary>
		/// Constant for qualifier with value PUTT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PUTT = "PUTT";
		[Obsolete]
		public const string PUTT = "PUTT";

		/// <summary>
		/// Constant for qualifier with value PWAL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String PWAL = "PWAL";
		[Obsolete]
		public const string PWAL = "PWAL";

		/// <summary>
		/// Constant for qualifier with value QTSO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String QTSO = "QTSO";
		[Obsolete]
		public const string QTSO = "QTSO";

		/// <summary>
		/// Constant for qualifier with value RATE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RATE = "RATE";
		[Obsolete]
		public const string RATE = "RATE";

		/// <summary>
		/// Constant for qualifier with value RCHG 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RCHG = "RCHG";
		[Obsolete]
		public const string RCHG = "RCHG";

		/// <summary>
		/// Constant for qualifier with value RDDT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RDDT = "RDDT";
		[Obsolete]
		public const string RDDT = "RDDT";

		/// <summary>
		/// Constant for qualifier with value RDIS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RDIS = "RDIS";
		[Obsolete]
		public const string RDIS = "RDIS";

		/// <summary>
		/// Constant for qualifier with value RDTE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RDTE = "RDTE";
		[Obsolete]
		public const string RDTE = "RDTE";

		/// <summary>
		/// Constant for qualifier with value RECDEL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RECDEL = "RECDEL";
		[Obsolete]
		public const string RECDEL = "RECDEL";

		/// <summary>
		/// Constant for qualifier with value REDP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REDP = "REDP";
		[Obsolete]
		public const string REDP = "REDP";

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
		/// Constant for qualifier with value REGO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REGO = "REGO";
		[Obsolete]
		public const string REGO = "REGO";

		/// <summary>
		/// Constant for qualifier with value REIN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REIN = "REIN";
		[Obsolete]
		public const string REIN = "REIN";

		/// <summary>
		/// Constant for qualifier with value RELA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RELA = "RELA";
		[Obsolete]
		public const string RELA = "RELA";

		/// <summary>
		/// Constant for qualifier with value RESU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RESU = "RESU";
		[Obsolete]
		public const string RESU = "RESU";

		/// <summary>
		/// Constant for qualifier with value REVR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String REVR = "REVR";
		[Obsolete]
		public const string REVR = "REVR";

		/// <summary>
		/// Constant for qualifier with value RHDI 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RHDI = "RHDI";
		[Obsolete]
		public const string RHDI = "RHDI";

		/// <summary>
		/// Constant for qualifier with value RLOS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String RLOS = "RLOS";
		[Obsolete]
		public const string RLOS = "RLOS";

		/// <summary>
		/// Constant for qualifier with value SAFE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SAFE = "SAFE";
		[Obsolete]
		public const string SAFE = "SAFE";

		/// <summary>
		/// Constant for qualifier with value SECMOVE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SECMOVE = "SECMOVE";
		[Obsolete]
		public const string SECMOVE = "SECMOVE";

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
		/// Constant for qualifier with value SHIP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SHIP = "SHIP";
		[Obsolete]
		public const string SHIP = "SHIP";

		/// <summary>
		/// Constant for qualifier with value SHRT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SHRT = "SHRT";
		[Obsolete]
		public const string SHRT = "SHRT";

		/// <summary>
		/// Constant for qualifier with value SIZE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SIZE = "SIZE";
		[Obsolete]
		public const string SIZE = "SIZE";

		/// <summary>
		/// Constant for qualifier with value SOFE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SOFE = "SOFE";
		[Obsolete]
		public const string SOFE = "SOFE";

		/// <summary>
		/// Constant for qualifier with value SOIC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SOIC = "SOIC";
		[Obsolete]
		public const string SOIC = "SOIC";

		/// <summary>
		/// Constant for qualifier with value SPLT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SPLT = "SPLT";
		[Obsolete]
		public const string SPLT = "SPLT";

		/// <summary>
		/// Constant for qualifier with value SPOS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SPOS = "SPOS";
		[Obsolete]
		public const string SPOS = "SPOS";

		/// <summary>
		/// Constant for qualifier with value STAM 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String STAM = "STAM";
		[Obsolete]
		public const string STAM = "STAM";

		/// <summary>
		/// Constant for qualifier with value STEX 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String STEX = "STEX";
		[Obsolete]
		public const string STEX = "STEX";

		/// <summary>
		/// Constant for qualifier with value SUBS 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String SUBS = "SUBS";
		[Obsolete]
		public const string SUBS = "SUBS";

		/// <summary>
		/// Constant for qualifier with value TAVO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TAVO = "TAVO";
		[Obsolete]
		public const string TAVO = "TAVO";

		/// <summary>
		/// Constant for qualifier with value TAXB 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TAXB = "TAXB";
		[Obsolete]
		public const string TAXB = "TAXB";

		/// <summary>
		/// Constant for qualifier with value TAXC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TAXC = "TAXC";
		[Obsolete]
		public const string TAXC = "TAXC";

		/// <summary>
		/// Constant for qualifier with value TAXE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TAXE = "TAXE";
		[Obsolete]
		public const string TAXE = "TAXE";

		/// <summary>
		/// Constant for qualifier with value TAXR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TAXR = "TAXR";
		[Obsolete]
		public const string TAXR = "TAXR";

		/// <summary>
		/// Constant for qualifier with value TAXVODET 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TAXVODET = "TAXVODET";
		[Obsolete]
		public const string TAXVODET = "TAXVODET";

		/// <summary>
		/// Constant for qualifier with value TDMT 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TDMT = "TDMT";
		[Obsolete]
		public const string TDMT = "TDMT";

		/// <summary>
		/// Constant for qualifier with value TDTA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TDTA = "TDTA";
		[Obsolete]
		public const string TDTA = "TDTA";

		/// <summary>
		/// Constant for qualifier with value TEMP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TEMP = "TEMP";
		[Obsolete]
		public const string TEMP = "TEMP";

		/// <summary>
		/// Constant for qualifier with value TNDP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TNDP = "TNDP";
		[Obsolete]
		public const string TNDP = "TNDP";

		/// <summary>
		/// Constant for qualifier with value TRAD 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TRAD = "TRAD";
		[Obsolete]
		public const string TRAD = "TRAD";

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
		/// Constant for qualifier with value TXAP 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TXAP = "TXAP";
		[Obsolete]
		public const string TXAP = "TXAP";

		/// <summary>
		/// Constant for qualifier with value TXDF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TXDF = "TXDF";
		[Obsolete]
		public const string TXDF = "TXDF";

		/// <summary>
		/// Constant for qualifier with value TXFR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TXFR = "TXFR";
		[Obsolete]
		public const string TXFR = "TXFR";

		/// <summary>
		/// Constant for qualifier with value TXIN 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TXIN = "TXIN";
		[Obsolete]
		public const string TXIN = "TXIN";

		/// <summary>
		/// Constant for qualifier with value TXNR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TXNR = "TXNR";
		[Obsolete]
		public const string TXNR = "TXNR";

		/// <summary>
		/// Constant for qualifier with value TXPR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TXPR = "TXPR";
		[Obsolete]
		public const string TXPR = "TXPR";

		/// <summary>
		/// Constant for qualifier with value TXRC 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String TXRC = "TXRC";
		[Obsolete]
		public const string TXRC = "TXRC";

		/// <summary>
		/// Constant for qualifier with value UNAF 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String UNAF = "UNAF";
		[Obsolete]
		public const string UNAF = "UNAF";

		/// <summary>
		/// Constant for qualifier with value UNCO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String UNCO = "UNCO";
		[Obsolete]
		public const string UNCO = "UNCO";

		/// <summary>
		/// Constant for qualifier with value UNFR 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String UNFR = "UNFR";
		[Obsolete]
		public const string UNFR = "UNFR";

		/// <summary>
		/// Constant for qualifier with value USECU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String USECU = "USECU";
		[Obsolete]
		public const string USECU = "USECU";

		/// <summary>
		/// Constant for qualifier with value VALU 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String VALU = "VALU";
		[Obsolete]
		public const string VALU = "VALU";

		/// <summary>
		/// Constant for qualifier with value VATA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String VATA = "VATA";
		[Obsolete]
		public const string VATA = "VATA";

		/// <summary>
		/// Constant for qualifier with value WAPA 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String WAPA = "WAPA";
		[Obsolete]
		public const string WAPA = "WAPA";

		/// <summary>
		/// Constant for qualifier with value WITL 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String WITL = "WITL";
		[Obsolete]
		public const string WITL = "WITL";

		/// <summary>
		/// Constant for qualifier with value WUCO 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String WUCO = "WUCO";
		[Obsolete]
		public const string WUCO = "WUCO";

		/// <summary>
		/// Constant for qualifier with value XDTE 
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static final String XDTE = "XDTE";
		[Obsolete]
		public const string XDTE = "XDTE";

	// end qualifiers constants	

		/// <summary>
		/// Creates an MT566 initialized with the parameter SwiftMessage </summary>
		/// <param name="m"> swift message with the MT566 content </param>
		public MT566(SwiftMessage m) : base(m)
		{
			sanityCheck(m);
		}

		/// <summary>
		/// Creates an MT566 initialized with the parameter MtSwiftMessage. </summary>
		/// <param name="m"> swift message with the MT566 content, the parameter can not be null </param>
		/// <seealso cref= #MT566(String) </seealso>
		public MT566(MtSwiftMessage m) : this(m.message())
		{
		}

		/// <summary>
		/// Creates an MT566 initialized with the parameter MtSwiftMessage.
		/// </summary>
		/// <param name="m"> swift message with the MT566 content </param>
		/// <returns> the created object or null if the parameter is null </returns>
		/// <seealso cref= #MT566(String)
		/// @since 7.7 </seealso>
		public static MT566 parse(MtSwiftMessage m)
		{
			if (m == null)
			{
				return null;
			}
			return new MT566(m);
		}

		/// <summary>
		/// Creates and initializes a new MT566 input message setting TEST BICS as sender and receiver.<br>
		/// All mandatory header attributes are completed with default values.
		/// 
		/// @since 7.6
		/// </summary>
		public MT566() : this(BIC.TEST8, BIC.TEST8)
		{
		}

		/// <summary>
		/// Creates and initializes a new MT566 input message from sender to receiver.<br>
		/// All mandatory header attributes are completed with default values. 
		/// In particular the sender and receiver addresses will be filled with proper default LT identifier 
		/// and branch codes if not provided,
		/// </summary>
		/// <param name="sender"> the sender address as a bic8, bic11 or full logical terminal consisting of 12 characters </param>
		/// <param name="receiver"> the receiver address as a bic8, bic11 or full logical terminal consisting of 12 characters
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT566(final String sender, final String receiver)
		public MT566(string sender, string receiver) : base(566, sender, receiver)
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
		/// <seealso cref= #MT566(String, String) </seealso>
		/// @deprecated Use instead <code>new MT566(sender, receiver)</code> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("Use instead <code>new MT566(sender, receiver)</code> instead") @com.prowidesoftware.deprecation.ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public MT566(final int messageType, final String sender, final String receiver)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("Use instead <code>new MT566(sender, receiver)</code> instead")]
		public MT566(int messageType, string sender, string receiver) : base(566, sender, receiver)
		{
			com.prowidesoftware.deprecation.DeprecationUtils.phase3(this.GetType(), "MT566(int, String, String)", "Use the constructor MT566(sender, receiver) instead.");
		}

		/// <summary>
		/// Creates a new MT566 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter is null or the message cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MT566(final String fin)
		public MT566(string fin) : base()
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
				log.warning("Creating an MT566 object from FIN content with a Service Message. Check if the MT566 you are intended to read is prepended with and ACK.");
			}
			else if (!StringUtils.Equals(param.Type, MessageType))
			{
				log.warning("Creating an MT566 object from FIN content with message type " + param.Type);
			}
		}

		/// <summary>
		/// Creates a new MT566 by parsing a String with the message content in its swift FIN format.<br>
		/// If the fin parameter cannot be parsed, the returned MT566 will have its internal message object
		/// initialized (blocks will be created) but empty.<br>
		/// If the string contains multiple messages, only the first one will be parsed. 
		/// </summary>
		/// <param name="fin"> a string with the MT message in its FIN swift format. <em>fin may be null in which case this method returns null</em> </param>
		/// <returns> a new instance of MT566 or null if fin is null 
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT566 parse(final String fin)
		public static MT566 parse(string fin)
		{
			if (fin == null)
			{
				return null;
			}
			return new MT566(fin);
		}

		/// <summary>
		/// Creates a new MT566 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the message content is null or cannot be parsed, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT566(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT566(InputStream stream) : this(Lib.readStream(stream))
		{
		}

		/// <summary>
		/// Creates a new MT566 by parsing a input stream with the message content in its swift FIN format, using "UTF-8" as encoding.<br>
		/// If the stream contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="stream"> an input stream in UTF-8 encoding with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT566 or null if stream is null or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the stream data cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT566 parse(final java.io.InputStream stream) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT566 parse(InputStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			return new MT566(stream);
		}

		/// <summary>
		/// Creates a new MT566 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file content is null or cannot be parsed as a message, the internal message object
		/// will be initialized (blocks will be created) but empty.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public MT566(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public MT566(File file) : this(Lib.readFile(file))
		{
		}

		/// <summary>
		/// Creates a new MT566 by parsing a file with the message content in its swift FIN format.<br>
		/// If the file contains multiple messages, only the first one will be parsed.
		/// </summary>
		/// <param name="file"> a file with the MT message in its FIN swift format. </param>
		/// <returns> a new instance of MT566 or null if; file is null, does not exist, can't be read, is not a file or the message cannot be parsed </returns>
		/// <exception cref="IOException"> if the file content cannot be read
		/// @since 7.7 </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static MT566 parse(final java.io.File file) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static MT566 parse(File file)
		{
			if (file == null)
			{
				return null;
			}
			return new MT566(file);
		}

		/// <summary>
		/// Returns this MT number </summary>
		/// <returns> the message type number of this MT
		/// @since 6.4 </returns>
		public override string MessageType
		{
			get
			{
				return "566";
			}
		}

		/// <summary>
		/// Add all tags from block to the end of the block4.
		/// </summary>
		/// <param name="block"> to append </param>
		/// <returns> this object to allow method chaining
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public MT566 append(final SwiftTagListBlock block)
		public override MT566 append(SwiftTagListBlock block)
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
//ORIGINAL LINE: @Override public MT566 append(final Tag... tags)
		public override MT566 append(params Tag[] tags)
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
//ORIGINAL LINE: @Override public MT566 append(final Field... fields)
		public override MT566 append(params Field[] fields)
		{
			base.append(fields);
			return this;
		}

		/// <summary>
		/// Creates an MT566 messages from its JSON representation.
		/// <para>
		/// For generic conversion of JSON into the corresopnding MT instance
		/// see <seealso cref="AbstractMT#fromJson(String)"/>
		/// 
		/// </para>
		/// </summary>
		/// <param name="json"> a JSON representation of an MT566 message </param>
		/// <returns> a new instance of MT566
		/// @since 7.10.3 </returns>
		public static MT566 fromJson(string json)
		{
			return (MT566) AbstractMT.fromJson(json);
		}

		/// <summary>
		/// Iterates through block4 fields and return the first one whose name matches 23G, 
		/// or null if none is found.<br>
		/// The first occurrence of field 23G at MT566 is expected to be the only one.
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
		/// The first occurrence of field 99A at MT566 is expected to be the only one.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 20C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 20C at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 16R at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 22F at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 13A at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 13B at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 16S, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 16S at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 94B at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 12A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 12A at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 12C at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 11A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 11A at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98A at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92A at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92D at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92D> Field92D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92D> result = new java.util.ArrayList<>();
				IList<Field92D> result = new List<Field92D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92D");
				Tag[] tags = tags("92D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 36B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 36B at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 93B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 93B at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field93B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field93B> Field93B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field93B> result = new java.util.ArrayList<>();
				IList<Field93B> result = new List<Field93B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("93B");
				Tag[] tags = tags("93B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field93B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 93C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 93C at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field93C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field93C> Field93C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field93C> result = new java.util.ArrayList<>();
				IList<Field93C> result = new List<Field93C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("93C");
				Tag[] tags = tags("93C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field93C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98C at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 98B at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98E at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 69A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 69A at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field69A objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field69A> Field69A
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field69A> result = new java.util.ArrayList<>();
				IList<Field69A> result = new List<Field69A>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("69A");
				Tag[] tags = tags("69A");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field69A(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 69B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 69B at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field69B objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field69B> Field69B
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field69B> result = new java.util.ArrayList<>();
				IList<Field69B> result = new List<Field69B>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("69B");
				Tag[] tags = tags("69B");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field69B(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 69C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 69C at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field69C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field69C> Field69C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field69C> result = new java.util.ArrayList<>();
				IList<Field69C> result = new List<Field69C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("69C");
				Tag[] tags = tags("69C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field69C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 69D, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 69D at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field69D objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field69D> Field69D
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field69D> result = new java.util.ArrayList<>();
				IList<Field69D> result = new List<Field69D>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("69D");
				Tag[] tags = tags("69D");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field69D(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 69E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 69E at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field69E objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field69E> Field69E
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field69E> result = new java.util.ArrayList<>();
				IList<Field69E> result = new List<Field69E>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("69E");
				Tag[] tags = tags("69E");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field69E(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 69F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 69F at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field69F objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field69F> Field69F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field69F> result = new java.util.ArrayList<>();
				IList<Field69F> result = new List<Field69F>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("69F");
				Tag[] tags = tags("69F");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field69F(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92F at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92F objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92F> Field92F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92F> result = new java.util.ArrayList<>();
				IList<Field92F> result = new List<Field92F>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92F");
				Tag[] tags = tags("92F");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92F(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92K, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92K at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92K objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92K> Field92K
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92K> result = new java.util.ArrayList<>();
				IList<Field92K> result = new List<Field92K>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92K");
				Tag[] tags = tags("92K");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92K(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92P, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92P at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92P objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92P> Field92P
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92P> result = new java.util.ArrayList<>();
				IList<Field92P> result = new List<Field92P>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92P");
				Tag[] tags = tags("92P");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92P(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 90A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 90A at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 90B at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 90L, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 90L at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field90L objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field90L> Field90L
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field90L> result = new java.util.ArrayList<>();
				IList<Field90L> result = new List<Field90L>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("90L");
				Tag[] tags = tags("90L");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field90L(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 36C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 36C at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field36C objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field36C> Field36C
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field36C> result = new java.util.ArrayList<>();
				IList<Field36C> result = new List<Field36C>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("36C");
				Tag[] tags = tags("36C");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field36C(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 17B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 17B at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 22H, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 22H at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 98F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 98F at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field98F objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field98F> Field98F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field98F> result = new java.util.ArrayList<>();
				IList<Field98F> result = new List<Field98F>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("98F");
				Tag[] tags = tags("98F");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field98F(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92H, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92H at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92H objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92H> Field92H
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92H> result = new java.util.ArrayList<>();
				IList<Field92H> result = new List<Field92H>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92H");
				Tag[] tags = tags("92H");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92H(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92J, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92J at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92J objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92J> Field92J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92J> result = new java.util.ArrayList<>();
				IList<Field92J> result = new List<Field92J>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92J");
				Tag[] tags = tags("92J");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92J(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92R, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92R at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92R objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92R> Field92R
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92R> result = new java.util.ArrayList<>();
				IList<Field92R> result = new List<Field92R>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92R");
				Tag[] tags = tags("92R");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92R(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 35B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 35B at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 94C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 94C at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 94F at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 90F, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 90F at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field90F objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field90F> Field90F
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field90F> result = new java.util.ArrayList<>();
				IList<Field90F> result = new List<Field90F>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("90F");
				Tag[] tags = tags("90F");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field90F(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 90J, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 90J at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field90J objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field90J> Field90J
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field90J> result = new java.util.ArrayList<>();
				IList<Field90J> result = new List<Field90J>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("90J");
				Tag[] tags = tags("90J");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field90J(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 90K, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 90K at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field90K objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field90K> Field90K
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field90K> result = new java.util.ArrayList<>();
				IList<Field90K> result = new List<Field90K>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("90K");
				Tag[] tags = tags("90K");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field90K(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92L, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92L at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92L objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92L> Field92L
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92L> result = new java.util.ArrayList<>();
				IList<Field92L> result = new List<Field92L>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92L");
				Tag[] tags = tags("92L");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92L(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92M, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92M at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92M objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92M> Field92M
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92M> result = new java.util.ArrayList<>();
				IList<Field92M> result = new List<Field92M>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92M");
				Tag[] tags = tags("92M");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92M(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92N, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92N at MT566 are expected at one sequence or across several sequences.
		/// </summary>
		/// <returns> a List of Field92N objects or <code>Collections.emptyList()</code> if none is not found </returns>
		/// <seealso cref= SwiftTagListBlock#getTagsByName(String) </seealso>
		/// <exception cref="IllegalStateException"> if SwiftMessage object is not initialized </exception>
		public virtual IList<Field92N> Field92N
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Field92N> result = new java.util.ArrayList<>();
				IList<Field92N> result = new List<Field92N>();
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final Tag[] tags = tags("92N");
				Tag[] tags = tags("92N");
				if (tags != null && tags.Length > 0)
				{
					foreach (Tag tag in tags)
					{
						result.Add(new Field92N(tag.Value));
					}
				}
				return result;
			}
		}

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95C, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95C at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95P, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95P at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 95Q at MT566 are expected at one sequence or across several sequences.
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
		/// Multiple occurrences of field 95R at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 95S, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 95S at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 97A, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 97A at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 97E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 97E at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 19B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 19B at MT566 are expected at one sequence or across several sequences.
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
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 92B, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 92B at MT566 are expected at one sequence or across several sequences.
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

		/// <summary>
		/// Iterates through block4 fields and return all occurrences of fields whose names matches 70E, 
		/// or <code>Collections.emptyList()</code> if none is found.<br>
		/// Multiple occurrences of field 70E at MT566 are expected at one sequence or across several sequences.
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


	// BaseSequenceCodeGenerator [seq=A]
		/// <summary>
		/// Class to model Sequence "A" in MT 566
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
		/// Class to model Sequence "A1" in MT 566
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
		/// Class to model Sequence "B" in MT 566
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>USECU</em>
			/// </summary>
			public const string START_END_16RS = "USECU";
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
		/// Class to model Sequence "B1" in MT 566
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) @com.prowidesoftware.swift.internal.NonUniqueSeparator public static class SequenceB1 extends SwiftTagListBlock
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
//ORIGINAL LINE: @com.prowidesoftware.swift.internal.NonUniqueSeparator @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceB1 newInstance(final Tag... tags)
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
		/// Get the list of SequenceB1 delimited by 16R/16S with value specified in SequenceB1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard.
		///   
		/// <div><em>This sequence does not have a unique 16R/S delimiter. In order to be uniquely identified it must be
		/// present inside its parent sequences</em>
		/// </div>
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.model.mt.SequenceUtils
		/// </seealso>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceB1#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @com.prowidesoftware.swift.internal.NonUniqueSeparator @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceB1> getSequenceB1List()
		public virtual IList<SequenceB1> SequenceB1List
		{
			get
			{
				  /*
				 * The delimiter FIA is not unique across all sequences, in this MT.
				 * The usual generated API for accessing this can not be used for sequence B1.
				 * So we call a special method to resolve this situation until we find a better approach.
				 */
				if (this.SwiftMessage == null)
				{
					return null;
				}
				return com.prowidesoftware.swift.model.mt.SequenceUtils.resolveMT566GetSequenceB1List_sru2018(this);
			}
		}
		/// <summary>
		/// Get the list of SequenceB1 delimited by 16R/16S with value specified in SequenceB1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard.
		///   
		/// <div><em>This sequence does not have a unique 16R/S delimiter. In order to be uniquely identified it must be
		/// present inside its parent sequences</em>
		/// </div>
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.model.mt.SequenceUtils
		/// </seealso>
		/// <seealso cref= SequenceB1#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceB1 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @com.prowidesoftware.swift.internal.NonUniqueSeparator @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceB1> getSequenceB1List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceB1> getSequenceB1List(SwiftTagListBlock parentSequence)
		{
			  /*
			 * The delimiter FIA is not unique across all sequences, in this MT.
			 * The usual generated API for accessing this can not be used for sequence B1.
			 * So we call a special method to resolve this situation until we find a better approach.
			 */
			return com.prowidesoftware.swift.model.mt.SequenceUtils.resolveMT566GetSequenceB1List_sru2018((new MT566()).append(parentSequence));

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=C]
		/// <summary>
		/// Class to model Sequence "C" in MT 566
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>CADETL</em>
			/// </summary>
			public const string START_END_16RS = "CADETL";
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


	// BaseSequenceCodeGenerator [seq=D]
		/// <summary>
		/// Class to model Sequence "D" in MT 566
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>CACONF</em>
			/// </summary>
			public const string START_END_16RS = "CACONF";
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


	// BaseSequenceCodeGenerator [seq=D1]
		/// <summary>
		/// Class to model Sequence "D1" in MT 566
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceD1 extends SwiftTagListBlock
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
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>SECMOVE</em>
			/// </summary>
			public const string START_END_16RS = "SECMOVE";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceD1 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceD1 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1 result = new SequenceD1();
				SequenceD1 result = new SequenceD1();
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
			public static SequenceD1 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1 result = new SequenceD1();
				SequenceD1 result = new SequenceD1();
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
//ORIGINAL LINE: public static SequenceD1 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceD1 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1 result = new SequenceD1();
				SequenceD1 result = new SequenceD1();
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceD1(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceD1(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceD1 delimited by 16R/16S with value specified in SequenceD1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceD1#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceD1> getSequenceD1List()
		public virtual IList<SequenceD1> SequenceD1List
		{
			get
			{
				return getSequenceD1List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceD1 delimited by 16R/16S with value specified in SequenceD1#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceD1#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceD1 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceD1> getSequenceD1List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceD1> getSequenceD1List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD1.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD1.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceD1> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceD1> result = new List<SequenceD1>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1 s = new SequenceD1();
					SequenceD1 s = new SequenceD1();
					s.Tags = b.getSubBlock(SequenceD1.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=D1a]
		/// <summary>
		/// Class to model Sequence "D1a" in MT 566
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) @com.prowidesoftware.swift.internal.NonUniqueSeparator public static class SequenceD1a extends SwiftTagListBlock
		public class SequenceD1a : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceD1a() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceD1a(final SwiftTagListBlock content)
			internal SequenceD1a(SwiftTagListBlock content) : base(content.getTags())
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
//ORIGINAL LINE: @com.prowidesoftware.swift.internal.NonUniqueSeparator @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceD1a newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static SequenceD1a newInstance(params Tag[] tags)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1a result = new SequenceD1a();
				SequenceD1a result = new SequenceD1a();
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
			public static SequenceD1a newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1a result = new SequenceD1a();
				SequenceD1a result = new SequenceD1a();
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
//ORIGINAL LINE: public static SequenceD1a newInstance(final SwiftTagListBlock... sequences)
			public static SequenceD1a newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1a result = new SequenceD1a();
				SequenceD1a result = new SequenceD1a();
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceD1a(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceD1a(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceD1a delimited by 16R/16S with value specified in SequenceD1a#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard.
		///   
		/// <div><em>This sequence does not have a unique 16R/S delimiter. In order to be uniquely identified it must be
		/// present inside its parent sequences</em>
		/// </div>
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.model.mt.SequenceUtils
		/// </seealso>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceD1a#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @com.prowidesoftware.swift.internal.NonUniqueSeparator @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceD1a> getSequenceD1aList()
		public virtual IList<SequenceD1a> SequenceD1aList
		{
			get
			{
				  /*
				 * The delimiter FIA is not unique across all sequences, in this MT.
				 * The usual generated API for accessing this can not be used for sequence D1a.
				 * So we call a special method to resolve this situation until we find a better approach.
				 */
				if (this.SwiftMessage == null)
				{
					return null;
				}
				return com.prowidesoftware.swift.model.mt.SequenceUtils.resolveMT566GetSequenceD1aList_sru2018(this);
			}
		}
		/// <summary>
		/// Get the list of SequenceD1a delimited by 16R/16S with value specified in SequenceD1a#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard.
		///   
		/// <div><em>This sequence does not have a unique 16R/S delimiter. In order to be uniquely identified it must be
		/// present inside its parent sequences</em>
		/// </div>
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.model.mt.SequenceUtils
		/// </seealso>
		/// <seealso cref= SequenceD1a#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceD1a within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @com.prowidesoftware.swift.internal.NonUniqueSeparator @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceD1a> getSequenceD1aList(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceD1a> getSequenceD1aList(SwiftTagListBlock parentSequence)
		{
			  /*
			 * The delimiter FIA is not unique across all sequences, in this MT.
			 * The usual generated API for accessing this can not be used for sequence D1a.
			 * So we call a special method to resolve this situation until we find a better approach.
			 */
			return com.prowidesoftware.swift.model.mt.SequenceUtils.resolveMT566GetSequenceD1aList_sru2018((new MT566()).append(parentSequence));

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=D1b]
		/// <summary>
		/// Class to model Sequence "D1b" in MT 566
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceD1b extends SwiftTagListBlock
		public class SequenceD1b : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceD1b() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceD1b(final SwiftTagListBlock content)
			internal SequenceD1b(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>RECDEL</em>
			/// </summary>
			public const string START_END_16RS = "RECDEL";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceD1b newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceD1b newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1b result = new SequenceD1b();
				SequenceD1b result = new SequenceD1b();
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
			public static SequenceD1b newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1b result = new SequenceD1b();
				SequenceD1b result = new SequenceD1b();
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
//ORIGINAL LINE: public static SequenceD1b newInstance(final SwiftTagListBlock... sequences)
			public static SequenceD1b newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1b result = new SequenceD1b();
				SequenceD1b result = new SequenceD1b();
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceD1b(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceD1b(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceD1b delimited by 16R/16S with value specified in SequenceD1b#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceD1b#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceD1b> getSequenceD1bList()
		public virtual IList<SequenceD1b> SequenceD1bList
		{
			get
			{
				return getSequenceD1bList(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceD1b delimited by 16R/16S with value specified in SequenceD1b#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceD1b#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceD1b within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceD1b> getSequenceD1bList(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceD1b> getSequenceD1bList(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD1b.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD1b.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceD1b> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceD1b> result = new List<SequenceD1b>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD1b s = new SequenceD1b();
					SequenceD1b s = new SequenceD1b();
					s.Tags = b.getSubBlock(SequenceD1b.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=D2]
		/// <summary>
		/// Class to model Sequence "D2" in MT 566
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceD2 extends SwiftTagListBlock
		public class SequenceD2 : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceD2() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceD2(final SwiftTagListBlock content)
			internal SequenceD2(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>CASHMOVE</em>
			/// </summary>
			public const string START_END_16RS = "CASHMOVE";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceD2 newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceD2 newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2 result = new SequenceD2();
				SequenceD2 result = new SequenceD2();
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
			public static SequenceD2 newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2 result = new SequenceD2();
				SequenceD2 result = new SequenceD2();
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
//ORIGINAL LINE: public static SequenceD2 newInstance(final SwiftTagListBlock... sequences)
			public static SequenceD2 newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2 result = new SequenceD2();
				SequenceD2 result = new SequenceD2();
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceD2(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceD2(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceD2 delimited by 16R/16S with value specified in SequenceD2#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceD2#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceD2> getSequenceD2List()
		public virtual IList<SequenceD2> SequenceD2List
		{
			get
			{
				return getSequenceD2List(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceD2 delimited by 16R/16S with value specified in SequenceD2#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceD2#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceD2 within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceD2> getSequenceD2List(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceD2> getSequenceD2List(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD2.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD2.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceD2> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceD2> result = new List<SequenceD2>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2 s = new SequenceD2();
					SequenceD2 s = new SequenceD2();
					s.Tags = b.getSubBlock(SequenceD2.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=D2a]
		/// <summary>
		/// Class to model Sequence "D2a" in MT 566
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceD2a extends SwiftTagListBlock
		public class SequenceD2a : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceD2a() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceD2a(final SwiftTagListBlock content)
			internal SequenceD2a(SwiftTagListBlock content) : base(content.getTags())
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceD2a newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceD2a newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2a result = new SequenceD2a();
				SequenceD2a result = new SequenceD2a();
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
			public static SequenceD2a newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2a result = new SequenceD2a();
				SequenceD2a result = new SequenceD2a();
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
//ORIGINAL LINE: public static SequenceD2a newInstance(final SwiftTagListBlock... sequences)
			public static SequenceD2a newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2a result = new SequenceD2a();
				SequenceD2a result = new SequenceD2a();
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceD2a(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceD2a(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceD2a delimited by 16R/16S with value specified in SequenceD2a#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceD2a#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceD2a> getSequenceD2aList()
		public virtual IList<SequenceD2a> SequenceD2aList
		{
			get
			{
				return getSequenceD2aList(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceD2a delimited by 16R/16S with value specified in SequenceD2a#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceD2a#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceD2a within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceD2a> getSequenceD2aList(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceD2a> getSequenceD2aList(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD2a.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD2a.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceD2a> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceD2a> result = new List<SequenceD2a>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2a s = new SequenceD2a();
					SequenceD2a s = new SequenceD2a();
					s.Tags = b.getSubBlock(SequenceD2a.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=D2b]
		/// <summary>
		/// Class to model Sequence "D2b" in MT 566
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(Type.GENERATED_16RS) public static class SequenceD2b extends SwiftTagListBlock
		public class SequenceD2b : SwiftTagListBlock
		{
			internal const long serialVersionUID = 1L;

			/// <summary>
			/// Constructs an empty sequence
			/// </summary>
			internal SequenceD2b() : base(new ArrayList<Tag>())
			{
			}

			/// <summary>
			/// Creates a sequence with the given content. </summary>
			/// <seealso cref= SwiftTagListBlock </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceD2b(final SwiftTagListBlock content)
			internal SequenceD2b(SwiftTagListBlock content) : base(content.getTags())
			{
			}

			/// <summary>
			/// Value for the qualifier of the 16R / 16S tag that indicates start and end of this sequence <em>TAXVODET</em>
			/// </summary>
			public const string START_END_16RS = "TAXVODET";
			public static readonly Tag START_TAG = new Tag(Field16R.NAME, START_END_16RS);
			public static readonly Tag END_TAG = new Tag(Field16S.NAME, START_END_16RS);

			/// <summary>
			/// Creates a new instance of this sequence with the given tags inside. </summary>
			/// <param name="tags"> may be null, an empty sequence containing only start and end sequence tags will be returned </param>
			/// <returns> a new instance of the sequence, initialized with the parameter tags </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static SequenceD2b newInstance(final Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			public static SequenceD2b newInstance(params Tag[] tags)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2b result = new SequenceD2b();
				SequenceD2b result = new SequenceD2b();
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
			public static SequenceD2b newInstance()
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2b result = new SequenceD2b();
				SequenceD2b result = new SequenceD2b();
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
//ORIGINAL LINE: public static SequenceD2b newInstance(final SwiftTagListBlock... sequences)
			public static SequenceD2b newInstance(params SwiftTagListBlock[] sequences)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2b result = new SequenceD2b();
				SequenceD2b result = new SequenceD2b();
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
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) private SequenceD2b(final SwiftMessage m)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
			internal SequenceD2b(SwiftMessage m) : base()
			{
				if (m.Block4 != null)
				{
					Tags = m.Block4.getSubBlock(START_END_16RS).Tags;
				}
			}

		}

		/// <summary>
		/// Get the list of SequenceD2b delimited by 16R/16S with value specified in SequenceD2b#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <returns> the found sequences or an empty list if none is found </returns>
		/// <seealso cref= SequenceD2b#START_END_16RS </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public java.util.List<SequenceD2b> getSequenceD2bList()
		public virtual IList<SequenceD2b> SequenceD2bList
		{
			get
			{
				return getSequenceD2bList(base.SwiftMessageNotNullOrException.Block4);
			}
		}
		/// <summary>
		/// Get the list of SequenceD2b delimited by 16R/16S with value specified in SequenceD2b#START_END_16RS
		/// The presence of this method indicates that this sequence can occur more than once according to the Standard. </summary>
		/// <seealso cref= SequenceD2b#START_END_16RS </seealso>
		/// <param name="parentSequence"> an optional parent sequence or null to find SequenceD2b within the complete message </param>
		/// <returns> the found sequences or an empty list if none is found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SequenceStyle(com.prowidesoftware.swift.internal.SequenceStyle.Type.GENERATED_16RS) public static java.util.List<SequenceD2b> getSequenceD2bList(final SwiftTagListBlock parentSequence)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static IList<SequenceD2b> getSequenceD2bList(SwiftTagListBlock parentSequence)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD2b.START_END_16RS);
			IList<SwiftTagListBlock> blocks = parentSequence.getSubBlocks(SequenceD2b.START_END_16RS);
			if (blocks != null && blocks.Count > 0)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<SequenceD2b> result = new java.util.ArrayList<>(blocks.size());
				IList<SequenceD2b> result = new List<SequenceD2b>(blocks.Count);
				foreach (SwiftTagListBlock b in blocks)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceD2b s = new SequenceD2b();
					SequenceD2b s = new SequenceD2b();
					s.Tags = b.getSubBlock(SequenceD2b.START_END_16RS).Tags;
					result.Add(s);
				}
				return result;
			}
			// TODO if is is mandatory issue a warning log
			return Collections.emptyList();

		}
		 // Slice debug: com.prowidesoftware.swift.codegen.velocity.mt.DelimitedSequenceCodeGenerator


	// BaseSequenceCodeGenerator [seq=E]
		/// <summary>
		/// Class to model Sequence "E" in MT 566
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




	}

}