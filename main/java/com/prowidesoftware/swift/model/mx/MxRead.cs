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
namespace com.prowidesoftware.swift.model.mx
{

	/// <summary>
	/// Interface to plug in code that reads XML strings into MX message objects
	/// 
	/// @since 7.6
	/// </summary>
	public interface MxRead
	{

		/// <summary>
		/// Read <code>xml</code> into a message object
		/// </summary>
		/// <param name="targetClass"> class of the message to be read </param>
		/// <param name="xml"> the string with the message </param>
		/// <param name="classes"> classes for the context </param>
		/// <returns> parsed message or null if string content could not be parsed into an Mx
		/// 
		/// @since 7.6 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: AbstractMX read(Class targetClass, final String xml, Class[] classes);
		AbstractMX read(Type targetClass, string xml, Type[] classes);

		/// <summary>
		/// Read <code>xml</code> into a message object
		/// </summary>
		/// <param name="xml"> the string with the message </param>
		/// <param name="id"> optional parameter to indicate the specific MX type to create; autodetected from namespace if null. </param>
		/// <returns> parsed message or null if string content could not be parsed into an Mx
		/// 
		/// @since 7.8.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public AbstractMX read(final String xml, com.prowidesoftware.swift.model.MxId id);
		AbstractMX read(string xml, MxId id);
	}

}