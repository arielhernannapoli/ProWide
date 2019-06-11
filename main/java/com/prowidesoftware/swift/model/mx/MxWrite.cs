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

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;

	/// <summary>
	/// Interface to plug in code that serializes MX message objects to XML string
	/// 
	/// @since 7.6
	/// </summary>
	public interface MxWrite
	{

		/// <summary>
		/// Converts obj into a xml string
		/// </summary>
		/// <param name="namespace"> the namespace for the target message </param>
		/// <param name="obj"> the object containing the message to be serialized </param>
		/// <param name="classes"> array of all classes used or referenced by message class </param>
		/// <returns> the message content serialized to XML
		/// @since 7.6
		/// </returns>
		/// @deprecated use <seealso cref="#message(String, AbstractMX, Class[], String, boolean)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") @Deprecated @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) String message(String namespace, AbstractMX obj, Class[] classes);
		[Obsolete]
		string message(string @namespace, AbstractMX obj, Type[] classes);

		/// <summary>
		/// Converts obj into a xml string
		/// </summary>
		/// <param name="namespace"> the namespace for the target message </param>
		/// <param name="obj"> the object containing the message to be serialized </param>
		/// <param name="classes"> array of all classes used or referenced by message class </param>
		/// <param name="prefix"> optional prefix for ns ("Doc" by default) </param>
		/// <param name="includeXMLDeclaration"> true to include the xml declaration (true by default) </param>
		/// <returns> the message content serialized to XML
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") String message(String namespace, AbstractMX obj, Class[] classes, final String prefix, boolean includeXMLDeclaration);
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		string message(string @namespace, AbstractMX obj, Type[] classes, string prefix, bool includeXMLDeclaration);

	}

}