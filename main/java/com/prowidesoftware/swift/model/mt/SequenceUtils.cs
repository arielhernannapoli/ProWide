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
namespace com.prowidesoftware.swift.model.mt
{

	using Field16S = com.prowidesoftware.swift.model.field.Field16S;
	using com.prowidesoftware.swift.model.mt.mt5xx;
	using SequenceB = com.prowidesoftware.swift.model.mt.mt5xx.MT537.SequenceB;
	using MT670 = com.prowidesoftware.swift.model.mt.mt6xx.MT670;
	using MT671 = com.prowidesoftware.swift.model.mt.mt6xx.MT671;
	using Validate = org.apache.commons.lang3.Validate;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static com.prowidesoftware.swift.model.SwiftMessageUtils.join;


	/// <summary>
	/// All methods in this class may be removed without prior advice.
	/// <em>DO NOT USE</em>
	/// These are intended to solve some sequence access code required from MT classes.
	/// Use those MTxxx.getSequenceX directly instead of these.
	/// 
	/// @author miguel
	/// @since 7.8
	/// 
	/// </summary>
	public class SequenceUtils
	{

		// Suppress default constructor for noninstantiability
		private SequenceUtils()
		{
			throw new AssertionError();
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT535.SequenceB1b1> resolveMT535GetSequenceB1b1List_sru2018(final MT535 mt535)
		public static IList<MT535.SequenceB1b1> resolveMT535GetSequenceB1b1List_sru2018(MT535 mt535)
		{
			Validate.notNull(mt535);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT535.SequenceB1b1> result = new java.util.ArrayList<>();
			IList<MT535.SequenceB1b1> result = new List<MT535.SequenceB1b1>();
			foreach (SwiftTagListBlock seq in join(mt535.SequenceB1bList).getSubBlocks(MT535.SequenceB1b1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT535.SequenceB1b1 s = MT535.SequenceB1b1.newInstance();
				MT535.SequenceB1b1 s = MT535.SequenceB1b1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT535.SequenceB1c> resolveMT535GetSequenceB1cList_sru2018(final MT535 mt535)
		public static IList<MT535.SequenceB1c> resolveMT535GetSequenceB1cList_sru2018(MT535 mt535)
		{
			Validate.notNull(mt535);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT535.SequenceB1c> result = new java.util.ArrayList<>();
			IList<MT535.SequenceB1c> result = new List<MT535.SequenceB1c>();
			foreach (SwiftTagListBlock seq in join(mt535.SequenceB1List).getSubBlocks(MT535.SequenceB1c.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT535.SequenceB1c s = MT535.SequenceB1c.newInstance();
				MT535.SequenceB1c s = MT535.SequenceB1c.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT536.SequenceA1> resolveMT536GetSequenceA1List_sru2018(final MT536 mt536)
		public static IList<MT536.SequenceA1> resolveMT536GetSequenceA1List_sru2018(MT536 mt536)
		{
			Validate.notNull(mt536);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT536.SequenceA1> result = new java.util.ArrayList<>();
			IList<MT536.SequenceA1> result = new List<MT536.SequenceA1>();
			foreach (SwiftTagListBlock seq in mt536.SequenceA.getSubBlocks(MT536.SequenceA1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT536.SequenceA1 s = MT536.SequenceA1.newInstance();
				MT536.SequenceA1 s = MT536.SequenceA1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT536.SequenceB1a1> resolveMT536GetSequenceB1a1List_sru2018(final MT536 mt536)
		public static IList<MT536.SequenceB1a1> resolveMT536GetSequenceB1a1List_sru2018(MT536 mt536)
		{
			Validate.notNull(mt536);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT536.SequenceB1a1> result = new java.util.ArrayList<>();
			IList<MT536.SequenceB1a1> result = new List<MT536.SequenceB1a1>();
			foreach (SwiftTagListBlock seq in join(mt536.SequenceBList).getSubBlocks(MT536.SequenceB1a1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT536.SequenceB1a1 s = MT536.SequenceB1a1.newInstance();
				MT536.SequenceB1a1 s = MT536.SequenceB1a1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceA1> resolveMT537GetSequenceA1List_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceA1> resolveMT537GetSequenceA1List_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceA1> result = new java.util.ArrayList<>();
			IList<MT537.SequenceA1> result = new List<MT537.SequenceA1>();
			foreach (SwiftTagListBlock seq in mt537.SequenceA.getSubBlocks(MT537.SequenceA1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceA1 s = MT537.SequenceA1.newInstance();
				MT537.SequenceA1 s = MT537.SequenceA1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceB> resolveMT537GetSequenceBList_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceB> resolveMT537GetSequenceBList_sru2018(MT537 mt537)
		{
			return resolveMT537GetSequenceBList_sru2018(mt537.SwiftMessage.Block4);

		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceB> resolveMT537GetSequenceBList_sru2018(final com.prowidesoftware.swift.model.SwiftTagListBlock mt537)
		public static IList<MT537.SequenceB> resolveMT537GetSequenceBList_sru2018(SwiftTagListBlock mt537) // block 4
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<com.prowidesoftware.swift.model.mt.mt5xx.MT537.SequenceB> result = new java.util.ArrayList<>();
			IList<SequenceB> result = new List<SequenceB>();
			/*
			 * B delimiter overlaps with C3 delimiter, everything after and including C and use
			 * standard getter for B
			 */
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<com.prowidesoftware.swift.model.SwiftTagListBlock> raw = mt537.getSubBlockBeforeFirst(MT537.SequenceC.START_END_16RS, false).getSubBlocks(MT537.SequenceB.START_END_16RS);
			IList<SwiftTagListBlock> raw = mt537.getSubBlockBeforeFirst(MT537.SequenceC.START_END_16RS, false).getSubBlocks(MT537.SequenceB.START_END_16RS);
			if (raw == null)
			{
				return null;
			}
			else
			{
				foreach (SwiftTagListBlock swiftTagListBlock in raw)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceB sequenceB = MT537.SequenceB.newInstance();
					MT537.SequenceB sequenceB = MT537.SequenceB.newInstance();
					sequenceB.Tags.Clear();
					sequenceB.append(swiftTagListBlock);
					result.Add(sequenceB);
				}
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceB1> resolveMT537GetSequenceB1List_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceB1> resolveMT537GetSequenceB1List_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceB1> result = new java.util.ArrayList<>();
			IList<MT537.SequenceB1> result = new List<MT537.SequenceB1>();
			foreach (SwiftTagListBlock seq in join(mt537.SequenceBList).getSubBlocks(MT537.SequenceB1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceB1 s = MT537.SequenceB1.newInstance();
				MT537.SequenceB1 s = MT537.SequenceB1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceB2a> resolveMT537GetSequenceB2aList_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceB2a> resolveMT537GetSequenceB2aList_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceB2a> result = new java.util.ArrayList<>();
			IList<MT537.SequenceB2a> result = new List<MT537.SequenceB2a>();
			foreach (SwiftTagListBlock seq in join(mt537.SequenceB2List).getSubBlocks(MT537.SequenceB2a.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceB2a s = MT537.SequenceB2a.newInstance();
				MT537.SequenceB2a s = MT537.SequenceB2a.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceB2b1> resolveMT537GetSequenceB2b1List_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceB2b1> resolveMT537GetSequenceB2b1List_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceB2b1> result = new java.util.ArrayList<>();
			IList<MT537.SequenceB2b1> result = new List<MT537.SequenceB2b1>();
			foreach (SwiftTagListBlock seq in join(mt537.SequenceB2List).getSubBlocks(MT537.SequenceB2b1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceB2b1 s = MT537.SequenceB2b1.newInstance();
				MT537.SequenceB2b1 s = MT537.SequenceB2b1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceC1> resolveMT537GetSequenceC1List_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceC1> resolveMT537GetSequenceC1List_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceC1> result = new java.util.ArrayList<>();
			IList<MT537.SequenceC1> result = new List<MT537.SequenceC1>();
			foreach (SwiftTagListBlock seq in join(mt537.SequenceCList).getSubBlocks(MT537.SequenceC1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceC1 s = MT537.SequenceC1.newInstance();
				MT537.SequenceC1 s = MT537.SequenceC1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceC2> resolveMT537GetSequenceC2List_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceC2> resolveMT537GetSequenceC2List_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceC2> result = new java.util.ArrayList<>();
			IList<MT537.SequenceC2> result = new List<MT537.SequenceC2>();
			foreach (SwiftTagListBlock seq in join(mt537.SequenceCList).getSubBlocks(MT537.SequenceC2.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceC2 s = MT537.SequenceC2.newInstance();
				MT537.SequenceC2 s = MT537.SequenceC2.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceC2a> resolveMT537GetSequenceC2aList_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceC2a> resolveMT537GetSequenceC2aList_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceC2a> result = new java.util.ArrayList<>();
			IList<MT537.SequenceC2a> result = new List<MT537.SequenceC2a>();
			foreach (SwiftTagListBlock seq in join(mt537.SequenceC2List).getSubBlocks(MT537.SequenceC2a.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceC2a s = MT537.SequenceC2a.newInstance();
				MT537.SequenceC2a s = MT537.SequenceC2a.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceC3> resolveMT537GetSequenceC3List_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceC3> resolveMT537GetSequenceC3List_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceC3> result = new java.util.ArrayList<>();
			IList<MT537.SequenceC3> result = new List<MT537.SequenceC3>();
			foreach (SwiftTagListBlock seq in join(mt537.SequenceCList).getSubBlocks(MT537.SequenceC3.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceC3 s = MT537.SequenceC3.newInstance();
				MT537.SequenceC3 s = MT537.SequenceC3.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceC3a> resolveMT537GetSequenceC3aList_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceC3a> resolveMT537GetSequenceC3aList_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceC3a> result = new java.util.ArrayList<>();
			IList<MT537.SequenceC3a> result = new List<MT537.SequenceC3a>();
			foreach (SwiftTagListBlock seq in join(mt537.SequenceC3List).getSubBlocks(MT537.SequenceC3a.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceC3a s = MT537.SequenceC3a.newInstance();
				MT537.SequenceC3a s = MT537.SequenceC3a.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT537.SequenceB2b> resolveMT537GetSequenceB2bList_sru2018(final MT537 mt537)
		public static IList<MT537.SequenceB2b> resolveMT537GetSequenceB2bList_sru2018(MT537 mt537)
		{
			Validate.notNull(mt537);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT537.SequenceB2b> result = new java.util.ArrayList<>();
			IList<MT537.SequenceB2b> result = new List<MT537.SequenceB2b>();
			foreach (SwiftTagListBlock seq in join(mt537.SequenceB2List).getSubBlocks(MT537.SequenceB2b.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT537.SequenceB2b s = MT537.SequenceB2b.newInstance();
				MT537.SequenceB2b s = MT537.SequenceB2b.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT538.SequenceA1> resolveMT538GetSequenceA1List_sru2018(final MT538 mt538)
		public static IList<MT538.SequenceA1> resolveMT538GetSequenceA1List_sru2018(MT538 mt538)
		{
			Validate.notNull(mt538);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT538.SequenceA1> result = new java.util.ArrayList<>();
			IList<MT538.SequenceA1> result = new List<MT538.SequenceA1>();
			foreach (SwiftTagListBlock seq in mt538.SequenceA.getSubBlocks(MT538.SequenceA1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT538.SequenceA1 s = MT538.SequenceA1.newInstance();
				MT538.SequenceA1 s = MT538.SequenceA1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT538.SequenceB2a1> resolveMT538GetSequenceB2a1List_sru2018(final MT538 mt538)
		public static IList<MT538.SequenceB2a1> resolveMT538GetSequenceB2a1List_sru2018(MT538 mt538)
		{
			Validate.notNull(mt538);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT538.SequenceB2a1> result = new java.util.ArrayList<>();
			IList<MT538.SequenceB2a1> result = new List<MT538.SequenceB2a1>();
			foreach (SwiftTagListBlock seq in join(mt538.SequenceBList).getSubBlocks(MT538.SequenceB2a1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT538.SequenceB2a1 s = MT538.SequenceB2a1.newInstance();
				MT538.SequenceB2a1 s = MT538.SequenceB2a1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static MT564.SequenceB1 resolveMT564GetSequenceB1_sru2018(final MT564 mt564)
		public static MT564.SequenceB1 resolveMT564GetSequenceB1_sru2018(MT564 mt564)
		{
			Validate.notNull(mt564);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT564.SequenceB1 result = MT564.SequenceB1.newInstance();
			MT564.SequenceB1 result = MT564.SequenceB1.newInstance();
			result.clear().append(mt564.SequenceB.getSubBlock(MT564.SequenceB1.START_END_16RS));
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT564.SequenceE1a> resolveMT564GetSequenceE1aList_sru2018(final MT564 mt564)
		public static IList<MT564.SequenceE1a> resolveMT564GetSequenceE1aList_sru2018(MT564 mt564)
		{
			Validate.notNull(mt564);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT564.SequenceE1a> result = new java.util.ArrayList<>();
			IList<MT564.SequenceE1a> result = new List<MT564.SequenceE1a>();
			foreach (SwiftTagListBlock seq in join(mt564.SequenceEList).getSubBlocks(MT564.SequenceE1a.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT564.SequenceE1a s = MT564.SequenceE1a.newInstance();
				MT564.SequenceE1a s = MT564.SequenceE1a.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT566.SequenceB1> resolveMT566GetSequenceB1List_sru2018(final MT566 mt566)
		public static IList<MT566.SequenceB1> resolveMT566GetSequenceB1List_sru2018(MT566 mt566)
		{
			Validate.notNull(mt566);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT566.SequenceB1> result = new java.util.ArrayList<>();
			IList<MT566.SequenceB1> result = new List<MT566.SequenceB1>();
			foreach (SwiftTagListBlock seq in mt566.SequenceB.getSubBlocks(MT566.SequenceB1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT566.SequenceB1 s = MT566.SequenceB1.newInstance();
				MT566.SequenceB1 s = MT566.SequenceB1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT566.SequenceD1a> resolveMT566GetSequenceD1aList_sru2018(final MT566 mt566)
		public static IList<MT566.SequenceD1a> resolveMT566GetSequenceD1aList_sru2018(MT566 mt566)
		{
			Validate.notNull(mt566);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT566.SequenceD1a> result = new java.util.ArrayList<>();
			IList<MT566.SequenceD1a> result = new List<MT566.SequenceD1a>();
			foreach (SwiftTagListBlock seq in mt566.SequenceD.getSubBlocks(MT566.SequenceD1a.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT566.SequenceD1a s = MT566.SequenceD1a.newInstance();
				MT566.SequenceD1a s = MT566.SequenceD1a.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT575.SequenceA1> resolveMT575GetSequenceA1List_sru2018(final MT575 mt575)
		public static IList<MT575.SequenceA1> resolveMT575GetSequenceA1List_sru2018(MT575 mt575)
		{
			Validate.notNull(mt575);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT575.SequenceA1> result = new java.util.ArrayList<>();
			IList<MT575.SequenceA1> result = new List<MT575.SequenceA1>();
			foreach (SwiftTagListBlock seq in mt575.SequenceA.getSubBlocks(MT575.SequenceA1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT575.SequenceA1 s = MT575.SequenceA1.newInstance();
				MT575.SequenceA1 s = MT575.SequenceA1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT575.SequenceB1a1> resolveMT575GetSequenceB1a1List_sru2018(final MT575 mt575)
		public static IList<MT575.SequenceB1a1> resolveMT575GetSequenceB1a1List_sru2018(MT575 mt575)
		{
			Validate.notNull(mt575);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT575.SequenceB1a1> result = new java.util.ArrayList<>();
			IList<MT575.SequenceB1a1> result = new List<MT575.SequenceB1a1>();
			foreach (SwiftTagListBlock seq in join(mt575.SequenceB1aList).getSubBlocks(MT575.SequenceB1a1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT575.SequenceB1a1 s = MT575.SequenceB1a1.newInstance();
				MT575.SequenceB1a1 s = MT575.SequenceB1a1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT575.SequenceB1a4> resolveMT575GetSequenceB1a4List_sru2018(final MT575 mt575)
		public static IList<MT575.SequenceB1a4> resolveMT575GetSequenceB1a4List_sru2018(MT575 mt575)
		{
			Validate.notNull(mt575);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT575.SequenceB1a4> result = new java.util.ArrayList<>();
			IList<MT575.SequenceB1a4> result = new List<MT575.SequenceB1a4>();
			foreach (SwiftTagListBlock seq in join(mt575.SequenceB1aList).getSubBlocks(MT575.SequenceB1a4.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT575.SequenceB1a4 s = MT575.SequenceB1a4.newInstance();
				MT575.SequenceB1a4 s = MT575.SequenceB1a4.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT575.SequenceC1> resolveMT575GetSequenceC1List_sru2018(final MT575 mt575)
		public static IList<MT575.SequenceC1> resolveMT575GetSequenceC1List_sru2018(MT575 mt575)
		{
			Validate.notNull(mt575);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT575.SequenceC1> result = new java.util.ArrayList<>();
			IList<MT575.SequenceC1> result = new List<MT575.SequenceC1>();
			foreach (SwiftTagListBlock seq in join(mt575.SequenceCList).getSubBlocks(MT575.SequenceC1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT575.SequenceC1 s = MT575.SequenceC1.newInstance();
				MT575.SequenceC1 s = MT575.SequenceC1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT575.SequenceC2a> resolveMT575GetSequenceC2aList_sru2018(final MT575 mt575)
		public static IList<MT575.SequenceC2a> resolveMT575GetSequenceC2aList_sru2018(MT575 mt575)
		{
			Validate.notNull(mt575);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT575.SequenceC2a> result = new java.util.ArrayList<>();
			IList<MT575.SequenceC2a> result = new List<MT575.SequenceC2a>();
			foreach (SwiftTagListBlock seq in join(mt575.SequenceC2List).getSubBlocks(MT575.SequenceC2a.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT575.SequenceC2a s = MT575.SequenceC2a.newInstance();
				MT575.SequenceC2a s = MT575.SequenceC2a.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT576.SequenceA1> resolveMT576GetSequenceA1List_sru2018(final MT576 mt576)
		public static IList<MT576.SequenceA1> resolveMT576GetSequenceA1List_sru2018(MT576 mt576)
		{
			Validate.notNull(mt576);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT576.SequenceA1> result = new java.util.ArrayList<>();
			IList<MT576.SequenceA1> result = new List<MT576.SequenceA1>();
			foreach (SwiftTagListBlock seq in mt576.SequenceA.getSubBlocks(MT576.SequenceA1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT576.SequenceA1 s = MT576.SequenceA1.newInstance();
				MT576.SequenceA1 s = MT576.SequenceA1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT576.SequenceB2a> resolveMT576GetSequenceB2aList_sru2018(final MT576 mt576)
		public static IList<MT576.SequenceB2a> resolveMT576GetSequenceB2aList_sru2018(MT576 mt576)
		{
			Validate.notNull(mt576);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT576.SequenceB2a> result = new java.util.ArrayList<>();
			IList<MT576.SequenceB2a> result = new List<MT576.SequenceB2a>();
			foreach (SwiftTagListBlock seq in join(mt576.SequenceBList).getSubBlocks(MT576.SequenceB2a.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT576.SequenceB2a s = MT576.SequenceB2a.newInstance();
				MT576.SequenceB2a s = MT576.SequenceB2a.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT586.SequenceA1> resolveMT586GetSequenceA1List_sru2018(final MT586 mt586)
		public static IList<MT586.SequenceA1> resolveMT586GetSequenceA1List_sru2018(MT586 mt586)
		{
			Validate.notNull(mt586);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT586.SequenceA1> result = new java.util.ArrayList<>();
			IList<MT586.SequenceA1> result = new List<MT586.SequenceA1>();
			foreach (SwiftTagListBlock seq in mt586.SequenceA.getSubBlocks(MT586.SequenceA1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT586.SequenceA1 s = MT586.SequenceA1.newInstance();
				MT586.SequenceA1 s = MT586.SequenceA1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<MT586.SequenceB1> resolveMT586GetSequenceB1List_sru2018(final MT586 mt586)
		public static IList<MT586.SequenceB1> resolveMT586GetSequenceB1List_sru2018(MT586 mt586)
		{
			Validate.notNull(mt586);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MT586.SequenceB1> result = new java.util.ArrayList<>();
			IList<MT586.SequenceB1> result = new List<MT586.SequenceB1>();
			foreach (SwiftTagListBlock seq in join(mt586.SequenceBList).getSubBlocks(MT586.SequenceB1.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MT586.SequenceB1 s = MT586.SequenceB1.newInstance();
				MT586.SequenceB1 s = MT586.SequenceB1.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<com.prowidesoftware.swift.model.mt.mt6xx.MT670.SequenceB2> resolveMT670GetSequenceB2List_sru2018(final com.prowidesoftware.swift.model.mt.mt6xx.MT670 mt670)
		public static IList<MT670.SequenceB2> resolveMT670GetSequenceB2List_sru2018(MT670 mt670)
		{
			Validate.notNull(mt670);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<com.prowidesoftware.swift.model.mt.mt6xx.MT670.SequenceB2> result = new java.util.ArrayList<>();
			IList<MT670.SequenceB2> result = new List<MT670.SequenceB2>();
			foreach (SwiftTagListBlock seq in join(mt670.SequenceBList).getSubBlocks(MT670.SequenceB2.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt6xx.MT670.SequenceB2 s = com.prowidesoftware.swift.model.mt.mt6xx.MT670.SequenceB2.newInstance();
				MT670.SequenceB2 s = MT670.SequenceB2.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.mt.mt6xx.MT670.SequenceC resolveMT670GetSequenceC_sru2018(final com.prowidesoftware.swift.model.mt.mt6xx.MT670 mt670)
		public static MT670.SequenceC resolveMT670GetSequenceC_sru2018(MT670 mt670)
		{
			Validate.notNull(mt670);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt6xx.MT670.SequenceC result = com.prowidesoftware.swift.model.mt.mt6xx.MT670.SequenceC.newInstance();
			MT670.SequenceC result = MT670.SequenceC.newInstance();
			result.clear().append(getMT670_1_C(mt670.SwiftMessage.Block4, MT670.SequenceB.START_END_16RS));
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<com.prowidesoftware.swift.model.mt.mt6xx.MT671.SequenceB2> resolveMT671GetSequenceB2List_sru2018(final com.prowidesoftware.swift.model.mt.mt6xx.MT671 mt671)
		public static IList<MT671.SequenceB2> resolveMT671GetSequenceB2List_sru2018(MT671 mt671)
		{
			Validate.notNull(mt671);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<com.prowidesoftware.swift.model.mt.mt6xx.MT671.SequenceB2> result = new java.util.ArrayList<>();
			IList<MT671.SequenceB2> result = new List<MT671.SequenceB2>();
			foreach (SwiftTagListBlock seq in join(mt671.SequenceBList).getSubBlocks(MT671.SequenceB2.START_END_16RS))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt6xx.MT671.SequenceB2 s = com.prowidesoftware.swift.model.mt.mt6xx.MT671.SequenceB2.newInstance();
				MT671.SequenceB2 s = MT671.SequenceB2.newInstance();
				s.clear().append(seq);
				result.Add(s);
			}
			return result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.mt.mt6xx.MT671.SequenceC resolveMT671GetSequenceC_sru2018(final com.prowidesoftware.swift.model.mt.mt6xx.MT671 mt671)
		public static MT671.SequenceC resolveMT671GetSequenceC_sru2018(MT671 mt671)
		{
			Validate.notNull(mt671);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mt.mt6xx.MT671.SequenceC result = com.prowidesoftware.swift.model.mt.mt6xx.MT671.SequenceC.newInstance();
			MT671.SequenceC result = MT671.SequenceC.newInstance();
			result.clear().append(getMT670_1_C(mt671.SwiftMessage.Block4, MT671.SequenceB.START_END_16RS));
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static com.prowidesoftware.swift.model.SwiftTagListBlock getMT670_1_C(final com.prowidesoftware.swift.model.SwiftTagListBlock b4, final String B_startEnd16rs)
		private static SwiftTagListBlock getMT670_1_C(SwiftTagListBlock b4, string B_startEnd16rs)
		{
			/* 2016 Apr Miguel
			 * Since B contains inside a colliding sequence, with same delimiter as sequence C, if B is present we remove it to avoid ambiguity
			 */
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int last = b4.indexOfLastValue(com.prowidesoftware.swift.model.field.Field16S.NAME, B_startEnd16rs);
			int last = b4.indexOfLastValue(Field16S.NAME, B_startEnd16rs);
			if (last >= 0)
			{
				if (last + 1 == b4.size())
				{
					/*
					 * If 16S of C is the last tag on the message then there won't be a C block
					 */
					return SwiftTagListBlock.EMPTY_LIST;
				}
				return b4.sublist(last, b4.size());
			}
			return b4;
		}

	}

}