using System;
using System.Collections.Generic;
using System.Text;

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
namespace com.prowidesoftware.swift.model
{

	using SwiftWriter = com.prowidesoftware.swift.io.writer.SwiftWriter;
	using CurrencyContainer = com.prowidesoftware.swift.model.field.CurrencyContainer;
	using DateContainer = com.prowidesoftware.swift.model.field.DateContainer;
	using Field = com.prowidesoftware.swift.model.field.Field;
	using Field30T = com.prowidesoftware.swift.model.field.Field30T;
	using AbstractMT = com.prowidesoftware.swift.model.mt.AbstractMT;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Utility methods that provide higher level access to <seealso cref="SwiftMessage"/>
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class SwiftMessageUtils
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		private static readonly Logger log = Logger.getLogger(typeof(SwiftMessageUtils).FullName);
		private readonly SwiftMessage msg;

		public SwiftMessageUtils() : this(null)
		{
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public SwiftMessageUtils(final SwiftMessage m)
		public SwiftMessageUtils(SwiftMessage m)
		{
			this.msg = m;
		}

		public virtual IList<string> currencyStrings()
		{
			return SwiftMessageUtils.currencyStrings(msg);
		}

		/// <summary>
		/// Mirrors logic on <seealso cref="CurrencyContainer#currencyStrings()"/> including all fields </summary>
		/// <param name="m"> </param>
		/// <returns> an empty list if none found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static List<String> currencyStrings(final SwiftMessage m)
		public static IList<string> currencyStrings(SwiftMessage m)
		{
			if (m != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = m.getBlock4();
				SwiftBlock4 b4 = m.Block4;
				if (b4 != null && !b4.Empty)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final ArrayList<String> curs = new ArrayList<>();
					List<string> curs = new List<string>();
					foreach (Tag t in b4.Tags)
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field f = t.asField();
						Field f = t.asField();
						if (f is CurrencyContainer)
						{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.CurrencyContainer cc = (com.prowidesoftware.swift.model.field.CurrencyContainer) f;
							CurrencyContainer cc = (CurrencyContainer) f;
							curs.AddRange(cc.currencyStrings());
						}
					}
					return curs;
				}
			}
			return java.util.Collections.emptyList();
		}

		/// <summary>
		/// Gets the message value date </summary>
		/// <seealso cref= #valueDate(SwiftMessage) </seealso>
		public virtual DateTime valueDate()
		{
			return SwiftMessageUtils.valueDate(msg);
		}

		/// <summary>
		/// Iterates through the parameter tags and removes all inner blocks enclosed between
		/// sequences boundary fields 16R and 16S
		/// <br>
		/// This method requires a sequence starting with 16R and ending with 16S, so first
		/// and last tags must be those. Due to this constraint, null, empty and sequences with less 
		/// than 3 tags will be returned without any modification.
		/// </summary>
		/// <param name="sequence"> a block with a sequence to filter </param>
		/// <returns> a new block containing all tags that are outside a 16R/S block, the only 16R/S tags returned are the first and last delimiters. </returns>
		/// <exception cref="IllegalArgumentException"> if the starting tag is not 16R or the ending tag is not the matching 16S
		/// @since 7.8.1 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SwiftTagListBlock removeInnerSequences(final SwiftTagListBlock sequence)
		public static SwiftTagListBlock removeInnerSequences(SwiftTagListBlock sequence)
		{
			if (sequence == null || sequence.size() < 3)
			{
				return sequence;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag start = sequence.getTag(0);
			Tag start = sequence.getTag(0);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag end = sequence.getTag(sequence.size()-1);
			Tag end = sequence.getTag(sequence.size() - 1);
			if (!StringUtils.Equals("16R", start.Name))
			{
					throw new System.ArgumentException("Starting tag of sequence must be 16R (and was " + start.Name + ")");
			}
			if (!StringUtils.Equals("16S", end.Name))
			{
				throw new System.ArgumentException("Ending tag of sequence must be 16S (and was " + end.Name + ")");
			}
			if (!StringUtils.Equals(start.Value, end.Value))
			{
				throw new System.ArgumentException("The qualifier of the starting block " + start + " must match the qualifier of the ending block " + end);
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = new SwiftTagListBlock();
			SwiftTagListBlock result = new SwiftTagListBlock();
			string qualifier = null;
			for (int i = 0; i < sequence.getTags().Count; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = sequence.getTags().get(i);
				Tag t = sequence.getTags()[i];
				if (i > 0 && qualifier == null && StringUtils.Equals(t.Name, "16R"))
				{
					/*
					 * found sequence start
					 */
					qualifier = t.Value;
				}
				else if (qualifier != null && StringUtils.Equals(t.Name, "16S") && StringUtils.Equals(t.Value, qualifier))
				{
					/*
					 * found sequence end
					 */
					qualifier = null;
				}
				else if (qualifier == null)
				{
					result.append(t);
				}
			}
			return result;
		}

		/// <summary>
		/// Gets the value date of a message.
		/// 
		/// <para>The value date is meaningful and defined by the standard only for a subset of message types.
		/// In most of the cases it is contained in the date subfield of field 32A (for example MT103)
		/// or field 30 (for example MT101).
		/// 
		/// </para>
		/// <para>Notice a lot of messages do not define a value date.
		/// 
		/// </para>
		/// <para>Also a few define several fields as value date, or the value date can be repeated.
		/// for those messages the first one is returned as follows:<br>
		/// <ul>
		/// <li>For MT450 returns the first value date occurrence of field 32A</li>
		/// <li>For MT455 returns the value date from field 32A (not from 33[C,D])</li>
		/// <li>For MT456 returns the first value date occurrence of field 33D</li>
		/// <li>For MT564 returns the value date from Cash Movements Field 98a with qualifier PAYD (not qualifier VALU)</li>
		/// </ul>
		/// 
		/// </para>
		/// </summary>
		/// <param name="m"> the message where the value date is to be found </param>
		/// <returns> found date or null if the message does not defines a value date, or if the defined value date field is not present in the message
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Calendar valueDate(final SwiftMessage m)
		public static DateTime valueDate(SwiftMessage m)
		{
			if (m != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = m.getBlock4();
				SwiftBlock4 b4 = m.Block4;
				if (b4 != null && !b4.Empty)
				{
					Tag t = null;
					Field f = null;
					if (m.isType(101, 104, 107, 201, 203, 204, 207, 210, 604,605))
					{
						t = b4.getTagByName("30");
					}
					else if (m.isType(102, 103, 200, 202, 205, 400, 450, 455, 800, 802, 900, 910))
					{
						t = b4.getTagByName("32A");
					}
					else if (m.isType(300, 304, 320, 330, 350, 620))
					{
						t = b4.getTagByName("30V");
					}
					else if (m.isType(370))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("NETPOS");
						SwiftTagListBlock seq = b4.getSubBlock("NETPOS");
						if (seq != null)
						{
							f = seq.getFieldByNumber(98, "NETT");
						}
					}
					else if (m.isType(456))
					{
						t = b4.getTagByName("33D");
					}
					else if (m.isType(502))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("AMT");
						SwiftTagListBlock seq = b4.getSubBlock("AMT");
						if (seq != null)
						{
							f = seq.getFieldByNumber(98, "VALU");
						}
					}
					else if (m.isType(509))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("TRADE");
						SwiftTagListBlock seq = b4.getSubBlock("TRADE");
						if (seq != null)
						{
							f = seq.getFieldByNumber(98, "SETT");
						}
					}
					else if (m.isType(513))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("ORDRDET");
						SwiftTagListBlock seq = b4.getSubBlock("ORDRDET");
						if (seq != null)
						{
							f = seq.getFieldByNumber(98, "SETT");
						}
					}
					else if (m.isType(514, 515, 518))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("CONFDET");
						SwiftTagListBlock seq = b4.getSubBlock("CONFDET");
						if (seq != null)
						{
							f = seq.getFieldByNumber(98, "SETT");
						}
					}
					else if (m.isType(540, 541, 542, 543, 544, 545, 546, 547, 586))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("TRADDET");
						SwiftTagListBlock seq = b4.getSubBlock("TRADDET");
						if (seq != null)
						{
							f = seq.getFieldByNumber(98, "SETT");
						}
						else
						{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq2 = b4.getSubBlock("AMT");
							SwiftTagListBlock seq2 = b4.getSubBlock("AMT");
							if (seq2 != null)
							{
								f = seq.getFieldByNumber(98, "VALU");
							}
						}
					}
					else if (m.isType(537))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("TRANSDET");
						SwiftTagListBlock seq = b4.getSubBlock("TRANSDET");
						if (seq != null)
						{
							f = seq.getFieldByNumber(98, "EXSE");
						}
					}
					else if (m.isType(548))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("SETTRAN");
						SwiftTagListBlock seq = b4.getSubBlock("SETTRAN");
						if (seq != null)
						{
							f = seq.getFieldByNumber(70, "SPRO");
						}
					}
					else if (m.isType(564))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("CASHMOVE");
						SwiftTagListBlock seq = b4.getSubBlock("CASHMOVE");
						if (seq != null)
						{
							f = seq.getFieldByNumber(98, "PAYD");
						}
					}
					else if (m.isType(566))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock seq = b4.getSubBlock("CASHMOVE");
						SwiftTagListBlock seq = b4.getSubBlock("CASHMOVE");
						if (seq != null)
						{
							f = seq.getFieldByNumber(98, "POST");
						}
					}
					else if (m.isType(730, 768, 769))
					{
						t = b4.getTagByName("32D");
					}
					else if (m.isType(734, 752, 756))
					{
						t = b4.getTagByName("33A");
					}
					else if (m.isType(742, 754))
					{
						t = b4.getTagByName("34A");
					}
					else if (m.isType(942, 950, 970, 972))
					{
						t = b4.getTagByName("61");
					}
					if (t != null)
					{
						f = t.asField();
					}
					if (f != null && f is DateContainer)
					{
						return ((DateContainer) f).dates()[0];
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Gets the trade date of a message.
		/// 
		/// <para>The implementation tries first to get the trade date from field 30T (present in many
		/// category 3 messages) and if not found it tries to get the trade date from field 98a::TRAD
		/// (present in many category 5 messages).
		/// 
		/// </para>
		/// <para>Notice a lot of messages do not define a trade date.
		/// 
		/// </para>
		/// </summary>
		/// <param name="m"> the message where the value date is to be found </param>
		/// <returns> found date or null if the message does not defines a trade date, or if the defined trade date field is not present in the message
		/// @since 7.10.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Calendar tradeDate(final SwiftMessage m)
		public static DateTime tradeDate(SwiftMessage m)
		{
			if (m != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = m.getBlock4();
				SwiftBlock4 b4 = m.Block4;
				if (b4 != null && !b4.Empty)
				{

					Field f = m.Block4.getFieldByName(Field30T.NAME);
					if (f == null)
					{
						f = m.Block4.getFieldByNumber(98, "TRAD");
					}
					if (f != null && f is DateContainer)
					{
						return ((DateContainer) f).dates()[0];
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Proprietary checksum for message integrity verification or duplicates detection.
		/// <para>Please notice <strong>this is not the SWIFT trailer CHK field</strong>.
		/// </para>
		/// <para>The implementation computes an MD5 on the complete message in FIN format. The result hash
		/// is a 32 character string, you may consider encoding it with base64 on top to have the same 
		/// information stored in 22 characters.
		/// 
		/// </para>
		/// </summary>
		/// <param name="model"> the message </param>
		/// <returns> computed hash or null if errors occurred during computation or the message is null </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String calculateChecksum(final SwiftMessage model)
		public static string calculateChecksum(SwiftMessage model)
		{
			if (model != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.StringWriter writer = new java.io.StringWriter();
				StringWriter writer = new StringWriter();
				SwiftWriter.writeMessage(model, writer);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = writer.getBuffer().toString();
				string fin = writer.Buffer.ToString();
				return md5(fin);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Proprietary checksum for message text block (block 4) integrity verification or duplicates detection
		/// <para>Please notice <strong>this is not the SWIFT trailer CHK field</strong>.
		/// </para>
		/// <para>The implementation computes an MD5 on the complete message in FIN format. The result hash
		/// is a 32 character string, you may consider encoding it with base64 on top to have the same 
		/// information stored in 22 characters.
		/// 
		/// </para>
		/// </summary>
		/// <param name="b4"> the message text block </param>
		/// <returns> computed hash or null if errors occurred during computation or the block is null
		/// @since 7.9.5 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String calculateChecksum(final SwiftBlock4 b4)
		public static string calculateChecksum(SwiftBlock4 b4)
		{
			if (b4 != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.StringWriter writer = new java.io.StringWriter();
				StringWriter writer = new StringWriter();
				SwiftWriter.writeBlock4(b4, writer);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = writer.getBuffer().toString();
				string fin = writer.Buffer.ToString();
				return md5(fin);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Computes an MD5 hash on the parameter text </summary>
		/// <param name="text"> the text to hash </param>
		/// <returns> computed hash or null if exceptions are thrown reading bytes or processing the digest
		/// @since 7.9.5 </returns>
		//TODO add base 64 encoding on top when upgraded to Java 8
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static String md5(final String text)
		private static string md5(string text)
		{
			try
			{
				sbyte[] bytesOfMessage = text.GetBytes("UTF-8");
				MessageDigest md = MessageDigest.getInstance("MD5");
				sbyte[] thedigest = md.digest(bytesOfMessage);

				//Converting the bytes to a Hex string
				StringBuilder buff = new StringBuilder();
				foreach (sbyte b in thedigest)
				{
					string conversion = Convert.ToString(b & 0xFF,16);
					while (conversion.Length < 2)
					{
						conversion = "0" + conversion;
					}
					buff.Append(conversion);
				}

				return buff.ToString();
			}
			catch (UnsupportedEncodingException e)
			{
				log.log(Level.FINEST, e.Message, e);
			}
			catch (NoSuchAlgorithmException e)
			{
				log.log(Level.FINEST, e.Message, e);
			}
			return null;
		}

		/// <summary>
		/// Split the given message by the field 15, returning the letter option in the field 15 as the key in the map. </summary>
		/// <seealso cref= #splitByField15(SwiftTagListBlock) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Map<String, SwiftTagListBlock> splitByField15(final SwiftMessage msg)
		public static IDictionary<string, SwiftTagListBlock> splitByField15(SwiftMessage msg)
		{
			if (msg != null && msg.Block4 != null)
			{
				return splitByField15(msg.Block4);
			}
			else
			{
				return new Dictionary<string, SwiftTagListBlock>();
			}
		}

		/// <summary>
		/// Split the given block content by the field 15, returning the letter option in the field 15 as the key in the map
		/// </summary>
		/// <param name="block"> the content to split </param>
		/// <returns> a map with letter options as keys, and blocks as value
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Map<String, SwiftTagListBlock> splitByField15(final SwiftTagListBlock block)
		public static IDictionary<string, SwiftTagListBlock> splitByField15(SwiftTagListBlock block)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Map<String, SwiftTagListBlock> result = new HashMap<String, SwiftTagListBlock>();
			IDictionary<string, SwiftTagListBlock> result = new Dictionary<string, SwiftTagListBlock>();
			if (block != null)
			{
				SwiftTagListBlock currentList = null;
				foreach (Tag t in block.getTags())
				{
					if (t.Number == 15)
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String letter = t.getLetterOption();
						string letter = t.LetterOption;
						if (letter != null && letter.Length == 1)
						{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock thisList = new SwiftTagListBlock();
							SwiftTagListBlock thisList = new SwiftTagListBlock();
							result[letter] = thisList;
							currentList = thisList;
						}
					}
					if (currentList != null)
					{
						currentList.append(t);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Helper method to retrieve all sequences starting with 15X where X is the letterOption parameter
		/// @since 7.7 </summary>
		/// <seealso cref= #splitByField15(SwiftTagListBlock, String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static List<SwiftTagListBlock> splitByField15(final SwiftMessage msg, final String letterOption)
		public static IList<SwiftTagListBlock> splitByField15(SwiftMessage msg, string letterOption)
		{
			if (msg != null && msg.Block4 != null)
			{
				return splitByField15(msg.Block4, letterOption);
			}
			else
			{
				return java.util.Collections.emptyList();
			}
		}

		/// <summary>
		/// Helper method to retrieve all sequences starting with 15X where X is the letterOption parameter.
		/// Field 15a is used as a boundary for sequences, so the letter option correspond to a subsequence name. </summary>
		/// <param name="block"> the content to split into subsequences </param>
		/// <param name="letterOption"> a letter option for the field boundary </param>
		/// <returns> found subsequences or an empty list if field 15 is not found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static List<SwiftTagListBlock> splitByField15(final SwiftTagListBlock block, final String letterOption)
		public static IList<SwiftTagListBlock> splitByField15(SwiftTagListBlock block, string letterOption)
		{
			Validate.notNull(letterOption);
			Validate.isTrue(StringUtils.length(letterOption) == 1, "letter option must be only one character");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<SwiftTagListBlock> result = new ArrayList<>();
			IList<SwiftTagListBlock> result = new List<SwiftTagListBlock>();
			if (block != null)
			{
				SwiftTagListBlock currentList = null;
				foreach (Tag t in block.getTags())
				{
					if (t.Number == 15)
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String letter = t.getLetterOption();
						string letter = t.LetterOption;
						if (letter != null && letter.Length == 1)
						{
							if (letter.Equals(letterOption))
							{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock thisList = new SwiftTagListBlock();
								SwiftTagListBlock thisList = new SwiftTagListBlock();
								result.Add(thisList);
								currentList = thisList;
							}
							else
							{
								currentList = null;
							}
						}
					}
					if (currentList != null)
					{
						currentList.append(t);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Gets the message reference from field 20 (if present) or from field 20C:SEME if message category is 5.
		/// If no Field20 or 20C are found and MUR is present, returns the MUR value (field 108 from block 3). </summary>
		/// <param name="m"> the message where the reference is to be found </param>
		/// <returns> found reference or null if the message does not defines a reference, or if the defined reference field is not present in the message
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String reference(final SwiftMessage m)
		public static string reference(SwiftMessage m)
		{
			if (m != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = m.getBlock4();
				SwiftBlock4 b4 = m.Block4;
				if (b4 != null && !b4.Empty)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag t = b4.getTagByName("20");
					Tag t = b4.getTagByName("20");
					if (t != null)
					{
						return t.Value;
					}
					if (m.Type != null && m.Type.StartsWith("5", StringComparison.Ordinal))
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.field.Field f = b4.getFieldByNumber(20, "SEME");
						Field f = b4.getFieldByNumber(20, "SEME");
						if (f != null)
						{
							return f.getComponent(2);
						}
					}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Tag mur = b4.getTagByName("108");
					Tag mur = b4.getTagByName("108");
					if (mur != null)
					{
						return mur.Value;
					}

				}
			}
			return null;
		}

		/// <summary>
		/// Gets the message reference </summary>
		/// <seealso cref= #reference(SwiftMessage)
		/// @since 7.8.8 </seealso>
		public string reference()
		{
			return SwiftMessageUtils.reference(msg);
		}

		/// <summary>
		/// Joins all the given sequences in one single list.
		/// </summary>
		/// <param name="sequences"> the sequences to be joined. Can be null or empty, in which case this method returns <seealso cref="SwiftTagListBlock#EMPTY_LIST"/> </param>
		/// <returns> a single <seealso cref="SwiftTagListBlock"/> containing all elements in order of each of the given sequences or <seealso cref="SwiftTagListBlock#EMPTY_LIST"/> if sequences is null or empty
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SwiftTagListBlock join(final List<? extends SwiftTagListBlock> sequences)
		public static SwiftTagListBlock join<T1>(IList<T1> sequences) where T1 : SwiftTagListBlock
		{
			if (sequences == null || sequences.Count == 0)
			{
				return SwiftTagListBlock.EMPTY_LIST;
			}


//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = new SwiftTagListBlock();
			SwiftTagListBlock result = new SwiftTagListBlock();
			foreach (SwiftTagListBlock b in sequences)
			{
				result.getTags().AddRange(b.Tags);
			}
			return result;
		}

		/// <summary>
		/// Creates a sequence  and all it's containing parents.
		/// This method is mainly useful for writing test cases. Instead of writing:
		/// <pre><code>
		/// MT535.SequenceB.newInstance(
		/// 		MT535.SequenceB1b.newInstance(
		/// 			MT535.SequenceB1b.newInstance(
		/// 				MT535.SequenceB1b1.newInstance(
		/// 					tags
		/// 				)
		/// 			)
		/// 		)
		/// );
		/// </code></pre>
		/// This method is the same with a much cleaner code literature:
		/// <pre><code>
		/// 	SwiftMessageUtils.createSequenceWithParents(MT535.class, "B1b1", tags);
		/// </code></pre>
		/// 
		/// <em>Note:</em><br>
		/// Using  
		/// <pre><code>
		/// 	SwiftMessageUtils.createSequenceWithParents(MT535.class, "B", tags);
		/// </code></pre>
		/// Is virtually the same as:
		/// <pre><code>
		/// 	MT535.SequenceB.newInstance(tags);
		/// </code></pre>
		/// </summary>
		/// <param name="mt"> the MT class for which the sequence is to be created </param>
		/// <param name="sequenceName"> name of the sequence </param>
		/// <param name="tags"> the content to put in the sequence </param>
		/// <returns> the SwiftTagListBlock containing all parent sequences, the sequence requested and the contents
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static final SwiftTagListBlock createSubsequenceWithParents(final Class mt, final String sequenceName, final Tag... tags)
		public static SwiftTagListBlock createSubsequenceWithParents(Type mt, string sequenceName, params Tag[] tags)
		{
			log.finer("Create sequence " + sequenceName);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock result = new SwiftTagListBlock();
			SwiftTagListBlock result = new SwiftTagListBlock();
			result.append(tags);

			for (int i = sequenceName.Length;i >= 1;i--)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String sn = org.apache.commons.lang3.StringUtils.substring(sequenceName, 0, i);
				string sn = StringUtils.Substring(sequenceName, 0, i);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftTagListBlock newresult = createSequenceSingle(mt, sn, result.asTagArray());
				SwiftTagListBlock newresult = createSequenceSingle(mt, sn, result.asTagArray());
				log.finer(sn + " => " + newresult);
				result.setTags(newresult.getTags());
			}
			return result;

		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static SwiftTagListBlock createSequenceSingle(final Class mt, final String sequenceName, final Tag... tags)
		public static SwiftTagListBlock createSequenceSingle(Type mt, string sequenceName, params Tag[] tags)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String cn = mt.getName() + "$Sequence" + sequenceName;
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
			string cn = mt.FullName + "$Sequence" + sequenceName;
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Class subSequenceClass = Class.forName(cn);
				Type subSequenceClass = Type.GetType(cn);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Method method = subSequenceClass.getMethod("newInstance", Tag[] .class);
				Method method = subSequenceClass.GetMethod("newInstance", typeof(Tag[]));
				return (SwiftTagListBlock) method.invoke(null, new object[]{tags});
			}
			catch (Exception e)
			{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
				log.log(Level.WARNING, "Reflection error: mt=" + mt.FullName + ", sequenceName=" + sequenceName + ", tags=" + tags + " - " + e, e);
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
				throw new ProwideException("Reflection error: mt=" + mt.FullName + ", sequenceName=" + sequenceName + ", tags=" + tags + " - " + e);
			}
		}

		/// <summary>
		/// Gets the message main amount </summary>
		/// <seealso cref= #currencyAmount(SwiftMessage)
		/// @since 7.8.8 </seealso>
		protected internal virtual CurrencyAmount currencyAmount()
		{
			return currencyAmount(msg);
		}

		/// <summary>
		/// Gets the message main amount
		/// 
		/// <para>The amount is meaningful and defined by the standard only for a subset of message types.
		/// In most of the cases it is contained in the currency and amount subfields of fields 32a 
		/// in payments messages and 19A in securities.
		/// 
		/// This implementation is a work in progress and the interpretation of which field is consider
		/// the main amount for each message type may change from time to time adding more cases or 
		/// even changing the used field.
		/// 
		/// </para>
		/// </summary>
		/// <param name="m"> a message with some amount field </param>
		/// <returns> the currency and amount object extracted from the message or null if non is present or cannot be created from its fields
		/// @since 7.8.8 </returns>
		/*
		 * Do not use API from MTs and Field classes here to avoid cyclic dependency in code generation.
		 * Keep in sync special case for 104 and 107 with MT104 and MT107 getSequenceC logic.
		 */
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static final CurrencyAmount currencyAmount(final SwiftMessage m)
		internal static CurrencyAmount currencyAmount(SwiftMessage m)
		{
			if (m == null || m.ServiceMessage21)
			{
				return null;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SwiftBlock4 b4 = m.getBlock4();
			SwiftBlock4 b4 = m.Block4;
			if (b4 == null || b4.Empty)
			{
				return null;
			}
			if (m.isType(102, 103, 200, 202, 205, 256, 450, 455, 643, 644, 646, 734, 802, 900, 910))
			{
				return CurrencyAmount.of(b4.getFieldByName("32A"));
			}
			else if (m.isType(191, 291, 300, 304, 305, 320, 391, 491, 591, 691, 791, 891, 991, 340, 341, 350, 360, 361, 364, 365, 620, 700, 705, 710, 720, 732, 740, 742, 756))
			{
				return CurrencyAmount.of(b4.getFieldByName("32B"));
			}
			else if (m.isType(321, 370, 508, 509, 535, 536, 537, 540, 541, 542, 543, 544, 545, 546, 547, 548, 558, 559, 569, 574, 575, 576, 578, 586))
			{
				return CurrencyAmount.of(b4.getFieldByName("19A"));
			}
			else if (m.isType(330, 362))
			{
				return CurrencyAmount.of(b4.getFieldByName("32H"));
			}
			else if (m.isType(306, 581, 707, 747))
			{
				return CurrencyAmount.of(b4.getFieldByName("34B"));
			}
			else if (m.isType(380, 381, 505, 564, 566, 567))
			{
				return CurrencyAmount.of(b4.getFieldByName("19B"));
			}
			else if (m.isType(800))
			{
				return CurrencyAmount.of(b4.getFieldByName("33B"));
			}
			else if (m.isType(941))
			{
				return CurrencyAmount.of(b4.getFieldByName("62F"));

			}
			else if (m.isType(600, 601))
			{
				return CurrencyAmount.ofAny(b4, "34P", "34R");
			}
			else if (m.isType(609))
			{
				return CurrencyAmount.ofAny(b4, "68B", "68C");
			}
			else if (m.isType(111, 112, 516, 649) || m.isType(754))
			{
				return CurrencyAmount.ofAny(b4, "32A", "32B");
			}
			else if (m.isType(190, 290, 390, 490, 590, 690, 790, 890, 990))
			{
				return CurrencyAmount.ofAny(b4, "32C", "32D");
			}
			else if (m.isType(730) || m.isType(768))
			{
				return CurrencyAmount.ofAny(b4, "32B", "32D");
			}
			else if (m.isType(400, 410))
			{
				return CurrencyAmount.ofAny(b4, "32A", "32B", "32K");
			}
			else if (m.isType(430))
			{
				return CurrencyAmount.ofAny(b4, "33A", "33K", "32A", "32K");
			}
			else if (m.isType(750))
			{
				return CurrencyAmount.ofAny(b4, "34B", "32B");
			}
			else if (m.isType(752))
			{
				return CurrencyAmount.ofAny(b4, "33A", "33B", "32B");
			}
			else if (m.isType(769))
			{
				return CurrencyAmount.ofAny(b4, "32B", "32D", "33B", "34B");
			}
			else if (m.isType(940, 950, 970))
			{
				return CurrencyAmount.ofAny(b4, "62F", "62M");

			}
			else if (m.isType(101, 201, 203, 204, 207, 210))
			{
				return CurrencyAmount.ofSum(b4.getFieldsByName("32B"));
			}
			else if (m.isType(110, 416, 420, 422, 456))
			{
				return CurrencyAmount.ofSum(b4.getFieldsByName("32a"));
			}
			else if (m.isType(509))
			{
				return CurrencyAmount.ofSum(b4.getFieldsByName("19A"));
			}
			else if (m.isType(112))
			{
				return CurrencyAmount.ofSum(b4.getFieldsByName("32A"));
			}
			else if (m.isType(801))
			{
				return CurrencyAmount.ofSum(b4.getFieldsByName("33B"));
			}
			else if (m.isType(824))
			{
				return CurrencyAmount.ofSum(b4.getFieldsByName("68A"));

			}
			else if (m.isType(104, 107))
			{
				// we pick field 32B from sequence C
				// find last mandatory tag of mandatory sequence B
				int last59 = b4.indexOfAnyLast("59", "59A");
				if (last59 >= 0)
				{
					int startIndexOfC = b4.indexOfAnyFirstAfterIndex(last59, "32B");
					if (startIndexOfC >= 0)
					{
						Tag t = b4.Tags[startIndexOfC];
						if (t != null)
						{
							return CurrencyAmount.of(t.asField());
						}
					}
				}

			}
			else if (m.isType(502, 513))
			{
				/*
				 * we pick the first available 19A from the order detail
				 * for MT513 will be only one
				 */
				SwiftTagListBlock seq = b4.getSubBlock("ORDRDET");
				if (seq != null)
				{
					return CurrencyAmount.of(seq.getFieldByName("19A"));
				}

			}
			else if (m.isType(514, 515, 518))
			{
				/*
				 * we pick the first available 19A from the confirmation detail
				 * for 515 and 518 will be only one
				 */
				SwiftTagListBlock seq = b4.getSubBlock("CONFDET");
				if (seq != null)
				{
					return CurrencyAmount.of(seq.getFieldByName("19A"));
				}

			}
			else if (m.isType(503, 504, 506))
			{
				/*
				 * we pick the first available 19B from the summary
				 */
				SwiftTagListBlock seq = b4.getSubBlock("SUMM");
				if (seq != null)
				{
					return CurrencyAmount.of(seq.getFieldByName("19B"));
				}

			}
			else if (m.isType(527))
			{
				/*
				 * we pick the first available 19A from the deal transaction details
				 */
				SwiftTagListBlock seq = b4.getSubBlock("DEALTRAN");
				if (seq != null)
				{
					return CurrencyAmount.of(seq.getFieldByName("19A"));
				}
			}

			return null;
		}

	}

}