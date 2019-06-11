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
namespace com.prowidesoftware.swift.io
{

	using SwiftParser = com.prowidesoftware.swift.io.parser.SwiftParser;
	using XMLParser = com.prowidesoftware.swift.io.parser.XMLParser;
	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;
	using SwiftWriter = com.prowidesoftware.swift.io.writer.SwiftWriter;
	using XMLWriterVisitor = com.prowidesoftware.swift.io.writer.XMLWriterVisitor;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// This interface provides a general conversion service between three different formats:
	/// <ul>
	/// 	<li><b>FIN</b>: SWIFT message format as used by SWIFTNet (ISO 15022 compliance).</li>
	///  <li><b>XML</b>: WIFE's XML representation of SWIFT messages.</li>
	///  <li><b>SwiftMessage</b>: WIFE's java object model of SWIFT messages.</li>
	/// </ul>
	/// <para>This class may be used as a serializer.
	/// </para>
	/// <para>All methods in this class are <b>threadsafe</b>.
	/// </para>
	/// </summary>
	public class ConversionService : IConversionService
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(ConversionService).FullName);

		/// <summary>
		/// Given a SwiftMessage object returns a String containing its SWIFT message representation.
		/// Ensures all line breaks use CRLF
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.io.IConversionService#getFIN(com.prowidesoftware.swift.model.SwiftMessage) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getFIN(final com.prowidesoftware.swift.model.SwiftMessage msg)
		public virtual string getFIN(SwiftMessage msg)
		{
			Validate.notNull(msg);
			msg.removeEmptyBlocks();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringWriter writer = new StringWriter();
			StringWriter writer = new StringWriter();
			SwiftWriter.writeMessage(msg, writer);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fin = writer.getBuffer().toString();
			string fin = writer.Buffer.ToString();
			return SwiftWriter.ensureEols(fin);
		}

		/// <summary>
		/// Given a String containing a message in its Wife XML internal representation, returns a String
		/// containing its SWIFT message representation.
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.io.IConversionService#getFIN(java.lang.String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getFIN(final String xml)
		public virtual string getFIN(string xml)
		{
			Validate.notNull(xml);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftMessage msg = getMessageFromXML(xml);
			SwiftMessage msg = getMessageFromXML(xml);
			if (msg == null)
			{
				throw new ProwideException("parsed SwiftMessage from XML is null");
			}
			return getFIN(msg);
		}

		/// <summary>
		/// Given a SwiftMessage objects returns a String containing WIFE internal XML representation of the message.
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.io.IConversionService#getXml(com.prowidesoftware.swift.model.SwiftMessage) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getXml(final com.prowidesoftware.swift.model.SwiftMessage msg)
		public virtual string getXml(SwiftMessage msg)
		{
			return getXml(msg, false);
		}

		/// <summary>
		/// Given a SwiftMessage objects returns a String containing WIFE internal XML representation of the message.
		/// @since 7.6
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getXml(final com.prowidesoftware.swift.model.SwiftMessage msg, final boolean useField)
		public virtual string getXml(SwiftMessage msg, bool useField)
		{
			Validate.notNull(msg);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringWriter w = new StringWriter();
			StringWriter w = new StringWriter();
			msg.visit(new XMLWriterVisitor(w, useField));
			return w.Buffer.ToString();
		}

		/// <summary>
		/// Given a Swift message String returns a String containing WIFE internal XML representation of the message.
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.io.IConversionService#getXml(java.lang.String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getXml(final String fin)
		public virtual string getXml(string fin)
		{
			return getXml(fin, false);
		}

		/// <summary>
		/// Given a Swift message String returns a String containing WIFE internal XML representation of the message, use field (true) or tag (false) depending on the value of useField 
		/// </summary>
		/// <seealso cref= #getXml(String)
		/// @since 7.6 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getXml(final String fin, final boolean useField)
		public virtual string getXml(string fin, bool useField)
		{
			Validate.notNull(fin);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.SwiftMessage msg = this.getMessageFromFIN(fin);
			SwiftMessage msg = this.getMessageFromFIN(fin);
			return getXml(msg, useField);
		}

		/// <summary>
		/// Given a Swift message String returns a SwiftMessage object.
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.io.IConversionService#getMessageFromFIN(java.lang.String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.SwiftMessage getMessageFromFIN(final String fin)
		public virtual SwiftMessage getMessageFromFIN(string fin)
		{
			Validate.notNull(fin);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.io.parser.SwiftParser p = new com.prowidesoftware.swift.io.parser.SwiftParser(new ByteArrayInputStream(fin.getBytes()));
			SwiftParser p = new SwiftParser(new ByteArrayInputStream(fin.GetBytes()));
			try
			{
				return p.message();
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final IOException e)
			catch (IOException e)
			{
				throw new ProwideException(e + " during parse of message");
			}
		}

		/// <summary>
		/// Given a String containing a message in its WIFE internal XML representation, returns a SwiftMessage object.
		/// </summary>
		/// <seealso cref= com.prowidesoftware.swift.io.IConversionService#getMessageFromXML(java.lang.String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.SwiftMessage getMessageFromXML(final String xml)
		public virtual SwiftMessage getMessageFromXML(string xml)
		{
			return (new XMLParser()).parse(xml);
		}

	}

}