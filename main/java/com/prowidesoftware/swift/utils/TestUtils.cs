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
namespace com.prowidesoftware.swift.utils
{

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using SwiftBlock2Input = com.prowidesoftware.swift.model.SwiftBlock2Input;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using SwiftTagListBlock = com.prowidesoftware.swift.model.SwiftTagListBlock;
	using Tag = com.prowidesoftware.swift.model.Tag;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Utility methods for test cases
	/// 
	/// @author www.prowidesoftware.com
	/// </summary>
	public class TestUtils
	{

		// Suppress default constructor for noninstantiability
		private TestUtils()
		{
			throw new AssertionError();
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.SwiftMessage createMT(final int type)
		public static SwiftMessage createMT(int type)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftMessage result = new com.prowidesoftware.swift.model.SwiftMessage(true);
			SwiftMessage result = new SwiftMessage(true);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftBlock2Input b2 = new com.prowidesoftware.swift.model.SwiftBlock2Input();
			SwiftBlock2Input b2 = new SwiftBlock2Input();
			b2.MessageType = Convert.ToString(type);
			b2.Input = true;
			b2.MessagePriority = "N";
			b2.DeliveryMonitoring = "2";
			b2.ObsolescencePeriod = "020";
			b2.ReceiverAddress = "12345612XXXX";
			result.Block2 = b2;
			return result;
		}

		private const string MTXXXMESSAGE = "Use new MTxxx plus the append methods instead.";

		/// <summary>
		/// create a message of given type, initialize blocks and add in order tags param in block 4
		/// </summary>
		/// @deprecated use new MTxxx instead of this 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use new MTxxx instead of this") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static com.prowidesoftware.swift.model.SwiftMessage createMT(final int i, final com.prowidesoftware.swift.model.Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use new MTxxx instead of this")]
		public static SwiftMessage createMT(int i, params Tag[] tags)
		{
			DeprecationUtils.phase3(typeof(TestUtils), "createMT(int, Tag...)", MTXXXMESSAGE);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftMessage result = createMT(i);
			SwiftMessage result = createMT(i);
			if (tags != null && tags.Length > 0)
			{
				foreach (Tag t in tags)
				{
					result.Block4.append(t);
				}
			}
			return result;
		}

		/// @deprecated use new MTxxx instead of this 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use new MTxxx instead of this") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static com.prowidesoftware.swift.model.SwiftMessage createMT(final int i, final com.prowidesoftware.swift.model.SwiftTagListBlock... blocks)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use new MTxxx instead of this")]
		public static SwiftMessage createMT(int i, params SwiftTagListBlock[] blocks)
		{
			DeprecationUtils.phase3(typeof(TestUtils), "createMT(int, SwiftTagListBlock...)", MTXXXMESSAGE);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftMessage result = createMT(i);
			SwiftMessage result = createMT(i);

			if (blocks != null && blocks.Length > 0)
			{
				foreach (SwiftTagListBlock b in blocks)
				{
					result.Block4.Tags.AddRange(b.Tags);
				}
			}
			return result;
		}

		/// <summary>
		/// Adds the given tags in the message, surrounded with sequence boundaries for given sequence name.
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.SwiftMessage addSeq(final com.prowidesoftware.swift.model.SwiftMessage msg, final String sequenceIdentifier, final com.prowidesoftware.swift.model.Tag... tags)
		public static SwiftMessage addSeq(SwiftMessage msg, string sequenceIdentifier, params Tag[] tags)
		{
			msg.Block4.append(new Tag("16R", sequenceIdentifier));
			if (tags != null && tags.Length > 0)
			{
				foreach (Tag t in tags)
				{
					msg.Block4.append(t);
				}
			}
			msg.Block4.append(new Tag("16S", sequenceIdentifier));
			return msg;
		}

		/// <summary>
		/// enclose tags in B4 with the given 16R/S tags.
		/// additional tags, if any, are added right after the first 16R:sequenceIdentifier
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.SwiftMessage enclose(final com.prowidesoftware.swift.model.SwiftMessage msg, final String sequenceIdentifier, final com.prowidesoftware.swift.model.Tag... tags)
		public static SwiftMessage enclose(SwiftMessage msg, string sequenceIdentifier, params Tag[] tags)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<com.prowidesoftware.swift.model.Tag> block4 = msg.getBlock4().getTags();
			IList<Tag> block4 = msg.Block4.Tags;
			block4.Insert(0, new Tag("16R", sequenceIdentifier));
			if (tags != null && tags.Length > 0)
			{
				for (int i = tags.Length - 1;i >= 0;i--)
				{
					block4.Insert(1, tags[i]);
				}
			}
			block4.Add(new Tag("16S", sequenceIdentifier));
			return msg;
		}

		/// @deprecated use new MTnnn instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use new MTnnn instead") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static com.prowidesoftware.swift.model.SwiftMessage createMTwithEmptyTags(final int i, final String... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use new MTnnn instead")]
		public static SwiftMessage createMTwithEmptyTags(int i, params string[] tags)
		{
			DeprecationUtils.phase3(typeof(TestUtils), "createMTwithEmptyTags(int, String...)", MTXXXMESSAGE);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftMessage r = createMT(i, (com.prowidesoftware.swift.model.Tag[])null);
			SwiftMessage r = createMT(i, (Tag[])null);
			if (tags != null && tags.Length > 0)
			{
				foreach (String n in tags)
				{
					r.Block4.append(new Tag(n, "ignored"));
				}
			}
			return r;
		}

		/// <summary>
		/// Returns the array of tags enclosed in 16RS with the given qualifier </summary>
		/// <param name="startEnd16rs"> qualifier for 16RS tag </param>
		/// <param name="tags"> tags to include </param>
		/// <returns> the created array of tags </returns>
		/// @deprecated use directly MTXXX.SequenceX.newInstance(Tag ...) 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use directly MTXXX.SequenceX.newInstance(Tag ...)") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static com.prowidesoftware.swift.model.Tag[] newSeq(final String startEnd16rs, final com.prowidesoftware.swift.model.Tag... tags)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use directly MTXXX.SequenceX.newInstance(Tag ...)")]
		public static Tag[] newSeq(string startEnd16rs, params Tag[] tags)
		{
			DeprecationUtils.phase3(typeof(TestUtils), "newSeq(String, Tag...)", MTXXXMESSAGE);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.ArrayList<com.prowidesoftware.swift.model.Tag> result = new java.util.ArrayList<>();
			List<Tag> result = new List<Tag>();
			result.Add(new Tag("16R", startEnd16rs));
			if (tags != null && tags.Length > 0)
			{
				foreach (Tag t in tags)
				{
					result.Add(t);
				}
			}
			result.Add(new Tag("16S", startEnd16rs));
			return (Tag[]) result.ToArray();
		}

		/// <summary>
		/// Returns an array of empty value tags enclosed in 16RS with the given qualifier </summary>
		/// <param name="startEnd16rs"> qualifier for 16RS tag </param>
		/// <param name="tagnames"> tag names to create </param>
		/// <returns> the created array of tag objects </returns>
		/// @deprecated use directly MTXXX.SequenceX.newInstance(Tag ...) 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use directly MTXXX.SequenceX.newInstance(Tag ...)") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static com.prowidesoftware.swift.model.Tag[] newSeq(final String startEnd16rs, final String... tagnames)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use directly MTXXX.SequenceX.newInstance(Tag ...)")]
		public static Tag[] newSeq(string startEnd16rs, params string[] tagnames)
		{
			DeprecationUtils.phase3(typeof(TestUtils), "newSeq(String, String...)", MTXXXMESSAGE);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.ArrayList<com.prowidesoftware.swift.model.Tag> result = new java.util.ArrayList<>();
			List<Tag> result = new List<Tag>();
			result.Add(new Tag("16R", startEnd16rs));
			if (tagnames != null && tagnames.Length > 0)
			{
				foreach (String name in tagnames)
				{
					result.Add(new Tag(name, ""));
				}
			}
			result.Add(new Tag("16S", startEnd16rs));
			return (Tag[]) result.ToArray();
		}

		/// <summary>
		/// Appends block to the block4 of the given message. </summary>
		/// <param name="m"> the message that will be appended the block </param>
		/// <param name="block"> block to append </param>
		/// <exception cref="java.lang.IllegalArgumentException"> if m or block is null </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void append(final com.prowidesoftware.swift.model.SwiftMessage m, final com.prowidesoftware.swift.model.SwiftTagListBlock block)
		public static void append(SwiftMessage m, SwiftTagListBlock block)
		{
			Validate.notNull(m, "message must not be null");
			Validate.notNull(block, "block must not be null");
			m.Block4.append(block);
		}

		/// <summary>
		/// Patches a simple XPath to make it work in XMLUnit asserts 
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String patch(final String xpath)
		public static string patch(string xpath)
		{
			StringBuilder result = new StringBuilder();
			foreach (string s in StringUtils.Split(xpath, "/"))
			{
				result.Append("/*[local-name()='" + s + "']");
			}
			return result.ToString();
		}
	}

}