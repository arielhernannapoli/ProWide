using System;

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
namespace com.prowidesoftware.swift.io.writer
{

	using com.prowidesoftware.swift.model;
	using IMessageVisitor = com.prowidesoftware.swift.utils.IMessageVisitor;
	using StringUtils = org.apache.commons.lang3.StringUtils;


	/// <summary>
	/// Main class for writing SwiftMessage objects into SWIFT FIN message text.
	/// 
	/// @author www.prowidesoftware.com
	/// </summary>
	public class FINWriterVisitor : IMessageVisitor
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(FINWriterVisitor).FullName);

		/// <summary>
		/// EOL as defined by swift
		/// </summary>
		public const string SWIFT_EOL = "\r\n";

		private Writer writer;
		private bool? block4asText = true;

		/// <param name="writer"> </param>
		public FINWriterVisitor(Writer writer)
		{
			this.writer = writer;
		}

		////////////////////////////////////////////////////////////
		//
		// MESSAGE HANDLING
		//
		////////////////////////////////////////////////////////////
		public virtual void startMessage(SwiftMessage m)
		{

			// initialize status
			this.block4asText = true;

			// If app identifier NOT 'F' OR service identifier NOT '01'  	=> USE TAG-BLOCK  syntax
			// If message type is category 0                      			=> USE TAG-BLOCK  syntax
			// Otherwise													=> USE TEXT-BLOCK syntax

			SwiftBlock1 b1 = m != null ? m.Block1 : null;
			// if b1 not empty
			if (b1 != null && StringUtils.isNotEmpty(b1.Value))
			{
				// check for app id and service id
				bool isAppIdOrServiceId = !StringUtils.Equals(b1.ApplicationId, "F") || !StringUtils.Equals(b1.ServiceId, "01");
				if (isAppIdOrServiceId)
				{
					// if app identifier NOT 'F' OR service identifier NOT '01' => USE TAG-BLOCK syntax
					this.block4asText = false;
				}
			}

			SwiftBlock2 b2 = m != null ? m.Block2 : null;
			// if b2 not empty
			if (b2 != null && StringUtils.isNotEmpty(b2.Value))
			{
				// check for message category
				string mt = StringUtils.trimToEmpty(b2.MessageType);
				if (mt.StartsWith("0", StringComparison.Ordinal))
				{
					// if message type is category 0 => USE TAG-BLOCK  syntax
					this.block4asText = false;
				}
			}
		}

		public virtual void endMessage(SwiftMessage m)
		{

			// if message has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)m.UnparsedTextsSize > 0)
			{
				write(m.UnparsedTexts);
			}

			// cleanup status
			this.block4asText = true;
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 1
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock1(SwiftBlock1 b)
		{
			write("{1:");
		}

		public virtual void value(SwiftBlock1 b, string v)
		{
			if (StringUtils.isNotEmpty(v))
			{
				write(v);
			}
		}

		public virtual void endBlock1(SwiftBlock1 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts);
			}

			// write block termination
			write("}");
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 2
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock2(SwiftBlock2 b)
		{
			write("{2:");
		}

		public virtual void value(SwiftBlock2 b, string v)
		{
			if (StringUtils.isNotEmpty(v))
			{
				write(v);
			}
		}

		public virtual void endBlock2(SwiftBlock2 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts);
			}

			// write block termination
			write("}");
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 3
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock3(SwiftBlock3 b)
		{
			write("{3:");
		}

		public virtual void tag(SwiftBlock3 b, Tag t)
		{
			appendBlockTag(t);
		}

		public virtual void endBlock3(SwiftBlock3 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts);
			}

			// write block termination
			write("}");
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 4
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock4(SwiftBlock4 b)
		{
			write("{4:" + ((bool)this.block4asText ? SWIFT_EOL : ""));
		}

		public virtual void tag(SwiftBlock4 b, Tag t)
		{
			if ((bool)this.block4asText)
			{
				appendTextTag(t);
			}
			else
			{
				appendBlockTag(t);
			}
		}

		public virtual void endBlock4(SwiftBlock4 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts);
			}

			// write block termination
			write(((bool)this.block4asText ? "-" : "") + "}");
		}

		////////////////////////////////////////////////////////////
		//
		// BLOCK 5
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlock5(SwiftBlock5 b)
		{
			write("{5:");
		}

		public virtual void tag(SwiftBlock5 b, Tag t)
		{
			appendBlockTag(t);
		}

		public virtual void endBlock5(SwiftBlock5 b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts);
			}

			// write block termination
			write("}");
		}

		////////////////////////////////////////////////////////////
		//
		// USER DEFINED BLOCK
		//
		////////////////////////////////////////////////////////////
		public virtual void startBlockUser(SwiftBlockUser b)
		{
			write("{" + b.Name + ":");
		}

		public virtual void tag(SwiftBlockUser b, Tag t)
		{
			appendBlockTag(t);
		}

		public virtual void endBlockUser(SwiftBlockUser b)
		{

			// if block has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)b.UnparsedTextsSize > 0)
			{
				write(b.UnparsedTexts);
			}

			// write block termination
			write("}");
		}

		////////////////////////////////////////////////////////////
		//
		// DEPRECATED
		//
		////////////////////////////////////////////////////////////
		public virtual void tag(SwiftBlock b, Tag t)
		{
			if (b == null)
			{
				return;
			}
			if (b is SwiftBlock3)
			{
				tag((SwiftBlock3) b, t);
			}
			if (b is SwiftBlock4)
			{
				tag((SwiftBlock4) b, t);
			}
			if (b is SwiftBlock5)
			{
				tag((SwiftBlock5) b, t);
			}
			if (b is SwiftBlockUser)
			{
				tag((SwiftBlockUser) b, t);
			}
		}

		////////////////////////////////////////////////////////////
		//
		// INTERNAL METHODS
		//
		////////////////////////////////////////////////////////////
		private void appendBlockTag(Tag t)
		{
			// this goes: "{<tag>:<value>}" (quotes not included)

			// empty tags are not written
			if (StringUtils.isEmpty(t.Name) && StringUtils.isEmpty(t.Value))
			{
				return;
			}

			// we don't trim the value to preserve trailing spaces, but we avoid printing null
			if (StringUtils.isNotEmpty(t.Name))
			{
				// we have name
				write("{" + t.Name + ":" + notNullValue(t));
			}
			else
			{
				// no name but value => {<value>}
				write("{" + notNullValue(t));
			}

			// if tag has unparsed texts, write them down.
			// this goes "{<tag>:<value>unparsed_texts}" (NOTICE that unparsed text goes inside tag braquets)
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)t.UnparsedTextsSize > 0)
			{
				write(t.UnparsedTexts);
			}

			// write closing braquets
			write("}");
		}

		/*
		 * When printing tag values, we put empty string when null but we do not trim
		 * Don't replace this with StringUtils.trimToEmpty
		 */
		private string notNullValue(Tag t)
		{
			if (t.Value == null)
			{
				return "";
			}
			else
			{
				return t.Value;
			}
		}

		private void appendTextTag(Tag t)
		{
			// this goes: ":<tag>:<value>[CRLF]" (quotes not included)
			if (StringUtils.isNotEmpty(t.Name))
			{
				// we don't trim the value to preserve trailing spaces, but we avoid printing null
				write(":" + t.Name + ":" + notNullValue(t) + SWIFT_EOL);
			}

			// if tag has unparsed texts, write them down
			//
			// IMPORTANT: do not just "write(m.getUnparsedTexts())" because this latest method actually
			//            creates the object if not already there. Guard this with the size "if" that is
			//            safe (returns 0 if there is no list or real size otherwise).
			if ((int)t.UnparsedTextsSize > 0)
			{
				write(t.UnparsedTexts);
			}
		}


		/// <summary>
		/// Returns the tags value.
		/// </summary>
		/// <param name="t"> </param>
		/// <param name="block"> </param>
		/// <returns> the tag value removing the block number if present </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected String getTagValue(final Tag t, final int block)
		protected internal virtual string getTagValue(Tag t, int block)
		{
			/*
			 * If the value starts with blocknumber and the tag is unnamed,
			 * assume is block data and avoid repeating block number 
			 */
			string s = t.Value;
			if (t.Name == null && s.StartsWith(block + ":", StringComparison.Ordinal) && s.Length > 2)
			{
				return s.Substring(2);
			}
			return s;
		}

		private void write(UnparsedTextList texts)
		{
			// write the unparsed texts (if any)
			if ((int)texts.size() > 0)
			{
				for (int i = 0; i < (int)texts.size(); i++)
				{
					if ((bool)texts.isMessage(Convert.ToInt32(i)))
					{
						write(texts.getText(Convert.ToInt32(i)));
					}
				}
			}
		}

		private void write(string s)
		{
			try
			{
				writer.write(s);
			}
			catch (IOException e)
			{
				log.log(Level.SEVERE, "Caught exception in FINWriterVisitor, method write", e);
				throw new ProwideException(e);
			}
		}

	}

}