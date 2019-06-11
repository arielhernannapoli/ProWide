using System;
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
namespace com.prowidesoftware.swift.io.writer
{


	using Validate = org.apache.commons.lang3.Validate;

	using SwiftBlock1 = com.prowidesoftware.swift.model.SwiftBlock1;
	using SwiftBlock2 = com.prowidesoftware.swift.model.SwiftBlock2;
	using SwiftBlock3 = com.prowidesoftware.swift.model.SwiftBlock3;
	using SwiftBlock4 = com.prowidesoftware.swift.model.SwiftBlock4;
	using SwiftBlock5 = com.prowidesoftware.swift.model.SwiftBlock5;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;

	/// <summary>
	/// Helper API to write MT message content into native SWIFT format.
	/// 
	/// <para>This class handles writing swift messages exclusively, 
	/// all validation and consistency checks must be done
	/// previous to using the writer.
	/// </para>
	/// </summary>
	public class SwiftWriter
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftWriter).FullName);

		private const string WRITER_MESSAGE = "writer cannot be null";

		/// <summary>
		/// Write the given message to writer in its native SWIFT format
		/// </summary>
		/// <param name="msg"> the message to write </param>
		/// <param name="writer"> the writer that will actually receive all the write operations </param>
		/// <exception cref="IllegalArgumentException"> if msg or writer are null </exception>
		public static void writeMessage(SwiftMessage msg, Writer writer)
		{
			Validate.notNull(msg, "msg cannot be null");
			Validate.notNull(writer, WRITER_MESSAGE);
			FINWriterVisitor v = new FINWriterVisitor(writer);
			msg.visit(v);
		}

		/// <summary>
		/// Get a string with the internal xml representation of a message. </summary>
		/// <param name="msg"> the message to write </param>
		/// <returns> a string with an internal xml representation of the message </returns>
		/// <exception cref="IllegalArgumentException"> if msg is null </exception>
		public static string getInternalXml(SwiftMessage msg)
		{
			Validate.notNull(msg, "msg cannot be null");
			StringWriter w = new StringWriter();
			XMLWriterVisitor visitor = new XMLWriterVisitor(w);
			msg.visit(visitor);
			return w.ToString();
		}

		/// <summary>
		/// Write the given block to writer in its native SWIFT format
		/// </summary>
		/// <param name="b1"> a not null block 1 </param>
		/// <param name="writer">
		/// @since 7.8.6 </param>
		public static void writeBlock1(SwiftBlock1 b1, Writer writer)
		{
			Validate.notNull(b1, "b1 cannot be null");
			Validate.notNull(writer, WRITER_MESSAGE);
			FINWriterVisitor visitor = new FINWriterVisitor(writer);
			visitor.startBlock1(b1);
			visitor.value(b1, b1.Value);
			visitor.endBlock1(b1);
		}

		/// <summary>
		/// Returns the given block content in its native SWIFT format
		/// </summary>
		/// <param name="b1"> a not null block 1
		/// @since 7.8.6 </param>
		public static string writeBlock1(SwiftBlock1 b1)
		{
			StringWriter w = new StringWriter();
			writeBlock1(b1, w);
			return w.ToString();
		}

		/// <summary>
		/// Write the given block to writer in its native SWIFT format
		/// </summary>
		/// <param name="b2"> a not null block 2 </param>
		/// <param name="writer">
		/// @since 7.8.6 </param>
		public static void writeBlock2(SwiftBlock2 b2, Writer writer)
		{
			Validate.notNull(b2, "b2 cannot be null");
			Validate.notNull(writer, WRITER_MESSAGE);
			FINWriterVisitor visitor = new FINWriterVisitor(writer);
			visitor.startBlock2(b2);
			visitor.value(b2, b2.Value);
			visitor.endBlock2(b2);
		}

		/// <summary>
		/// Returns the given block content in its native SWIFT format
		/// </summary>
		/// <param name="b2"> a not null block 2
		/// @since 7.8.6 </param>
		public static string writeBlock2(SwiftBlock2 b2)
		{
			StringWriter w = new StringWriter();
			writeBlock2(b2, w);
			return w.ToString();
		}

		/// <summary>
		/// Write the given block to writer in its native SWIFT format
		/// </summary>
		/// <param name="b3"> a not null block 3 </param>
		/// <param name="writer">
		/// @since 7.8.6 </param>
		public static void writeBlock3(SwiftBlock3 b3, Writer writer)
		{
			Validate.notNull(b3, "b3 cannot be null");
			Validate.notNull(writer, WRITER_MESSAGE);
			FINWriterVisitor visitor = new FINWriterVisitor(writer);
			visitor.startBlock3(b3);
			SwiftMessage.visit(b3, visitor);
			visitor.endBlock3(b3);
		}

		/// <summary>
		/// Returns the given block content in its native SWIFT format
		/// </summary>
		/// <param name="b3"> a not null block 3
		/// @since 7.8.6 </param>
		public static string writeBlock3(SwiftBlock3 b3)
		{
			StringWriter w = new StringWriter();
			writeBlock3(b3, w);
			return w.ToString();
		}

		/// <summary>
		/// Write the given block to writer in its native SWIFT format
		/// </summary>
		/// <param name="b4"> a not null block 4 </param>
		/// <param name="writer">
		/// @since 7.8.6 </param>
		public static void writeBlock4(SwiftBlock4 b4, Writer writer)
		{
			Validate.notNull(b4, "b4 cannot be null");
			Validate.notNull(writer, WRITER_MESSAGE);
			FINWriterVisitor visitor = new FINWriterVisitor(writer);
			visitor.startBlock4(b4);
			SwiftMessage.visit(b4, visitor);
			visitor.endBlock4(b4);
		}

		/// <summary>
		/// Returns the given block content in its native SWIFT format
		/// </summary>
		/// <param name="b4"> a not null block 4
		/// @since 7.8.6 </param>
		public static string writeBlock4(SwiftBlock4 b4)
		{
			StringWriter w = new StringWriter();
			writeBlock4(b4, w);
			return w.ToString();
		}

		/// <summary>
		/// Write the given block to writer in its native SWIFT format
		/// </summary>
		/// <param name="b5"> a not null block 5 </param>
		/// <param name="writer">
		/// @since 7.8.6 </param>
		public static void writeBlock5(SwiftBlock5 b5, Writer writer)
		{
			Validate.notNull(b5, "b5 cannot be null");
			Validate.notNull(writer, WRITER_MESSAGE);
			FINWriterVisitor visitor = new FINWriterVisitor(writer);
			visitor.startBlock5(b5);
			SwiftMessage.visit(b5, visitor);
			visitor.endBlock5(b5);
		}

		/// <summary>
		/// Returns the given block content in its native SWIFT format
		/// </summary>
		/// <param name="b5"> a not null block 5
		/// @since 7.8.6 </param>
		public static string writeBlock5(SwiftBlock5 b5)
		{
			StringWriter w = new StringWriter();
			writeBlock5(b5, w);
			return w.ToString();
		}

		/// <summary>
		/// Makes sure all EOLs are swift compatible by replacing any line break in the parameter String with CRLF
		/// </summary>
		/// <param name="content"> the complete or partial FIN text to process </param>
		/// <returns> the source parameter with CRLF for all line breaks or an empty or incomplete string if an error occurs
		/// @since 7.10.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String ensureEols(final String content)
		public static string ensureEols(string content)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder buf = new StringBuilder();
			StringBuilder buf = new StringBuilder();
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.BufferedReader r = new java.io.BufferedReader(new java.io.StringReader(content));
				BufferedReader r = new BufferedReader(new StringReader(content));
				string l;
				while ((l = r.readLine()) != null)
				{
					buf.Append(l).Append(FINWriterVisitor.SWIFT_EOL);
				}
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
			catch (Exception e)
			{
				log.severe("Error in EOL correction: " + e);
			}
			if (buf.Length > 0)
			{
				//remove the last EOL inserted
				return buf.Substring(0, buf.Length - FINWriterVisitor.SWIFT_EOL.Length);
			}
			else
			{
				return "";
			}
		}

	}

}