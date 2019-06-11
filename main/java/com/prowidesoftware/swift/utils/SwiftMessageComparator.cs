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
namespace com.prowidesoftware.swift.utils
{

	using com.prowidesoftware.swift.model;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// An MT message comparator that compares all values from block 1 2 3, 4 and 5.
	/// 
	/// <para>By default the messages must be an exact match in order to be considered equal.
	/// This can be tailored for example to ignore EOLS in multiline fiels, to ignore
	/// header sequence and session numbers or to ignore the trailer block. Specific
	/// text block fields can also indicated to be ignore when comparing the messages.
	/// 
	/// </para>
	/// <para>This implementation can be overwritten to add special compare implementations
	/// for each of the blocks or to setup the parameters in different ways.
	/// 
	/// </para>
	/// <para>Despite implementing the Comparator interface this class is useful to find a 
	/// message 'almost equal' to another one but it is not intended to <strong>sort</strong>
	/// messages, since it does not provide ordering information of any kind.
	/// 
	/// </para>
	/// <para>NOTE: when both blocks being compared are null they are considered equals, even when they're actually empty.
	/// 
	/// @author sebastian
	/// @since 7.8.8
	/// </para>
	/// </summary>
	public class SwiftMessageComparator : IComparer<SwiftMessage>
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftMessageComparator).FullName);
		/// <summary>
		/// Flag to enable different type of EOLs in multi-line values
		/// </summary>
		protected internal bool ignoreEolsInMultiline = false;

		protected internal bool ignoreHeaderSession = false;

		protected internal bool ignoreTrailer = false;

		/// <summary>
		/// List of tagnames to ignore in comparison.
		/// tagnames will be matched using tag.getName()
		/// </summary>
		private IList<string> tagnamesToIgnore = new List<string>();

		/// <summary>
		/// Compare the two given messages. Message parameters cannot be null.
		/// 
		/// <para>This implementation calls the specific comparator methods for
		/// blocks 1 and 2, and the generic tag list block comparator for other
		/// blocks
		/// 
		/// </para>
		/// </summary>
		/// <seealso cref= #compareB1(SwiftBlock1, SwiftBlock1) </seealso>
		/// <seealso cref= #compareB2(SwiftBlock2, SwiftBlock2) </seealso>
		/// <seealso cref= #compareTagListBlock(SwiftTagListBlock, SwiftTagListBlock)  </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public int compare(final SwiftMessage m1, final SwiftMessage m2)
		public virtual int Compare(SwiftMessage m1, SwiftMessage m2)
		{
			Validate.notNull(m1);
			Validate.notNull(m2);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean b1 = compareB1(m1.getBlock1(), m2.getBlock1());
			bool b1 = compareB1(m1.Block1, m2.Block1);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean b2 = compareB2(m1.getBlock2(), m2.getBlock2());
			bool b2 = compareB2(m1.Block2, m2.Block2);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean b3 = compareTagListBlock(m1.getBlock3(), m2.getBlock3());
			bool b3 = compareTagListBlock(m1.Block3, m2.Block3);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean b4 = compareTagListBlock(m1.getBlock4(), m2.getBlock4());
			bool b4 = compareTagListBlock(m1.Block4, m2.Block4);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final boolean b5 = this.ignoreTrailer || compareTagListBlock(m1.getBlock5(), m2.getBlock5());
			bool b5 = this.ignoreTrailer || compareTagListBlock(m1.Block5, m2.Block5);
			log.finest("b1=" + b1 + ", b2=" + b2 + ", b3=" + b3 + ", b4=" + b4 + ", b5=" + b5);
			return (b1 && b2 && b3 && b4 && b5) ? 0 : 1;
		}

		/// <summary>
		/// Compares all elements of block2.
		/// <br>
		/// If both blocks null will return <code>true</code> and one null and the other one not null will return <code>false</code>
		/// </summary>
		/// <param name="o1"> </param>
		/// <param name="o2"> </param>
		/// <returns> <code>true</code> if both blocks are null or equal (from ACK point of view) or false in any other case </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean compareB2(final SwiftBlock2 o1, final SwiftBlock2 o2)
		public virtual bool compareB2(SwiftBlock2 o1, SwiftBlock2 o2)
		{
			if (o1 == null && o2 == null)
			{
				/*
				 * both are null
				 */
				return true;
			}
			if (o1 == null || o2 == null)
			{
				/*
				 * return false because the other one is not null
				 */
				return false;
			}
			if (!o1.GetType().Equals(o2.GetType()))
			{
				return false;
			}
			return StringUtils.Equals(o1.Value, o2.Value);
		}

		/// <summary>
		/// Compare all tags in taglist from both given blocks.
		/// 
		/// <para>This implementation uses <seealso cref="Tag#equals(Object)"/> for fields comparison.
		/// 
		/// </para>
		/// <para>NOTE a null or empty block is considered a blank block; then if both are blank this method returns <code>true</code>
		/// and if one of the blocks is blank and the other is not this method returns <code>false</code>
		/// 
		/// </para>
		/// </summary>
		/// <param name="o1"> first block to compare </param>
		/// <param name="o2"> second block to compare </param>
		/// <returns> true if both blocks are equal (or blank) and false in any other case </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean compareTagListBlock(final SwiftTagListBlock o1, final SwiftTagListBlock o2)
		public virtual bool compareTagListBlock(SwiftTagListBlock o1, SwiftTagListBlock o2)
		{
			if (isBlank(o1) && isBlank(o2))
			{
				/*
				 * both are null or empty
				 */
				return true;
			}
			if (isBlank(o1) || isBlank(o2))
			{
				/*
				 * return false because the other one is not blank
				 */
				return false;
			}
			if (o1.size() != o2.size())
			{
				return false;
			}

			int count = 0;
			for (int i = 0;i < o1.size();i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t1 = o1.getTag(i);
				Tag t1 = o1.getTag(i);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t2 = o2.getTag(i);
				Tag t2 = o2.getTag(i);

				if (tagNameIgnored(t1.Name, t2.Name))
				{
					log.finer("Tag ignored: " + t1.Name + " - " + t2.Name);
				}
				else
				{
					if (!(StringUtils.Equals(t1.Name, t2.Name) && valuesAreEqual(t1.Value, t2.Value)))
					{
						count++;
					}
				}
			}
			if (count > 0)
			{
				return false;
			}

			return true;
		}

		/// <returns> true if block is null or empty </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static boolean isBlank(final SwiftTagListBlock b)
		private static bool isBlank(SwiftTagListBlock b)
		{
			return b == null || b.Empty;
		}

		/// <summary>
		/// Compare two tag values considering internal settings.
		/// if <seealso cref="#ignoreEolsInMultiline"/> is true, then multi-line tags are compared line by 
		/// line, ignoring which eol is used in each case. lines are determined by java api readline
		/// </summary>
		/// <param name="value1"> </param>
		/// <param name="value2"> </param>
		/// <returns> true if equals according to internal settings, false otherwise </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private boolean valuesAreEqual(final String value1, final String value2)
		private bool valuesAreEqual(string value1, string value2)
		{
			if (value1 == null && value2 == null)
			{
				return true;
			}
			if (value1 == null || value2 == null)
			{
				return false;
			}
			// both values are non-null here
			if (this.ignoreEolsInMultiline)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.BufferedReader br1 = new java.io.BufferedReader(new java.io.StringReader(value1));
				BufferedReader br1 = new BufferedReader(new StringReader(value1));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.BufferedReader br2 = new java.io.BufferedReader(new java.io.StringReader(value2));
				BufferedReader br2 = new BufferedReader(new StringReader(value2));

				while (true)
				{
					try
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String l1 = br1.readLine();
						string l1 = br1.readLine();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String l2 = br2.readLine();
						string l2 = br2.readLine();

						if (!StringUtils.Equals(l1, l2))
						{
							return false;
						}
						if (l1 == null && l2 == null)
						{
							/*
							 * If both end of streams are reached and no differences were 
							 * reported previously then return true
							 */
							return true;
						}
					}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final java.io.IOException e)
					catch (IOException e)
					{
						throw new ProwideException(e);
					}
				}
			}
			else
			{
				return StringUtils.Equals(value1, value2);
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private boolean tagNameIgnored(final String name1, final String name2)
		private bool tagNameIgnored(string name1, string name2)
		{
			if (this.tagnamesToIgnore != null && this.tagnamesToIgnore.Count > 0)
			{
				for (final IEnumerator<string> it = this.tagnamesToIgnore.GetEnumerator() ; it.hasNext() ;)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String name = (String) it.next();
					string name = (string) it.next();
					if (StringUtils.Equals(name, name1) || StringUtils.Equals(name, name2))
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Return true if blocks are equals in all values except session and sequence number and false in any other case (including one of them being null)
		/// If both parameters are null it returns <code>true</code>, since there is nothing to compare.
		/// </summary>
		/// <param name="b1"> block to compare </param>
		/// <param name="b2"> block to compare </param>
		/// <returns> true if b1 equals b2 (except mentioned fields) and none is null false in any other case </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean compareB1(final SwiftBlock1 b1, final SwiftBlock1 b2)
		public virtual bool compareB1(SwiftBlock1 b1, SwiftBlock1 b2)
		{
			if (b1 == null && b2 == null)
			{
				return true;
			}
			if (b1 == null || b2 == null)
			{
				return false;
			}
			bool session = this.ignoreHeaderSession || StringUtils.Equals(b1.SessionNumber, b2.SessionNumber);
			bool sequence = this.ignoreHeaderSession || StringUtils.Equals(b1.SequenceNumber, b2.SequenceNumber);
			return session && sequence && StringUtils.Equals(b1.ApplicationId, b2.ApplicationId) && StringUtils.Equals(b1.LogicalTerminal, b2.LogicalTerminal) && StringUtils.Equals(b1.ServiceId, b2.ServiceId);
		}

		/// <returns> boolean value of ignoreEolsInMultiline property </returns>
		public virtual bool IgnoreEolsInMultiline
		{
			get
			{
				return ignoreEolsInMultiline;
			}
			set
			{
				this.ignoreEolsInMultiline = value;
			}
		}


		/// <returns> tags to ignore list </returns>
		public virtual IList<string> TagnamesToIgnore
		{
			get
			{
				return tagnamesToIgnore;
			}
			set
			{
				this.tagnamesToIgnore = value;
			}
		}


		/// <param name="o"> tag to add </param>
		/// <returns> true if tag was added </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean addTagnameToIgnore(final String o)
		public virtual bool addTagnameToIgnore(string o)
		{
			return tagnamesToIgnore.Add(o);
		}

		public virtual bool IgnoreHeaderSession
		{
			get
			{
				return ignoreHeaderSession;
			}
			set
			{
				this.ignoreHeaderSession = value;
			}
		}


		public virtual bool IgnoreTrailer
		{
			get
			{
				return ignoreTrailer;
			}
			set
			{
				this.ignoreTrailer = value;
			}
		}


	}

}