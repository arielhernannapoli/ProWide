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

	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;

	/// <summary>
	/// This interface provides a general conversion service between three different formats:
	/// <ul>
	/// 	<li><b>FIN</b>: SWIFT message format as used by SWIFTNet (ISO 15022 compliance).</li>
	///  <li><b>XML</b>: WIFE's XML representation of SWIFT messages.</li>
	///  <li><b>SwiftMessage</b>: WIFE's java object model of SWIFT messages.</li>
	/// </ul>
	///  
	/// @author www.prowidesoftware.com
	/// </summary>
	public interface IConversionService
	{

		/// <summary>
		/// Gets a String containing the FIN message from the msg object 
		/// argument, using FIN writer.
		/// </summary>
		/// <param name="msg"> an object containing the message to convert </param>
		/// <returns> a string with the FIN format representation of the message
		/// </returns>
		/// <exception cref="IllegalArgumentException"> if msg is null </exception>
		string getFIN(SwiftMessage msg);

		/// <summary>
		/// Gets a String containing the FIN message from the XML representation
		/// passed as a String argument.
		/// </summary>
		/// <param name="xml"> the string with the internal XML message to read </param>
		/// <returns> a string with the FIN format representation of the message
		/// </returns>
		/// <exception cref="IllegalArgumentException"> if XML is null </exception>
		string getFIN(string xml);

		/// <summary>
		/// Gets a String containing the XML internal representation of the message 
		/// from the msg object argument.
		/// </summary>
		/// <param name="msg"> an object containing the message to convert </param>
		/// <returns> a string with the internal XML representation of the message
		/// </returns>
		/// <exception cref="IllegalArgumentException"> if msg is null </exception>
		string getXml(SwiftMessage msg);

		/// <summary>
		/// Gets a String containing the XML internal representation of the message 
		/// from the FIN string message passed as argument.
		/// </summary>
		/// <param name="fin"> a string containing the FIN message to convert </param>
		/// <returns> a string with the internal XML representation of the message
		/// </returns>
		/// <exception cref="IllegalArgumentException"> if fin is null </exception>
		string getXml(string fin);

		/// <summary>
		/// Gets a message object containing the message data 
		/// from the FIN string message passed as argument.
		/// </summary>
		/// <param name="fin"> a string containing the FIN message to convert </param>
		/// <returns> a swift object containing the message data
		/// </returns>
		/// <exception cref="IllegalArgumentException"> if fin is null </exception>
		SwiftMessage getMessageFromFIN(string fin);

		/// <summary>
		/// Gets a message object containing the message data 
		/// from the XML representation passed as a String argument.
		/// </summary>
		/// <param name="xml"> the string with the internal XML message to read </param>
		/// <returns> a swift object containing the message data
		/// </returns>
		/// <exception cref="IllegalArgumentException"> if XML is null </exception>
		SwiftMessage getMessageFromXML(string xml);

	}
}