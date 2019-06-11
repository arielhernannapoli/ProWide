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


	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;

	/// @deprecated user <seealso cref="SwiftWriter"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("user <seealso cref="SwiftWriter"/> instead") @ProwideDeprecated(phase4=TargetYear._2019) public class TextWriter
	[Obsolete("user <seealso cref="SwiftWriter"/> instead")]
	public class TextWriter
	{
		//private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger( TextWriter.class );

		/// <summary>
		/// Creates a string with  a swift message for the given object.
		/// The message type is selected in the template, which must point to a resource found in classapath.
		/// </summary>
		/// <param name="template"> a valid path to the resource </param>
		/// <param name="env"> the object to use to render the message </param>
		/// <returns> the string containing the encoded message </returns>
		/// <exception cref="IllegalArgumentException"> if template is null or the the template resource is not found in classpath </exception>
		public virtual string buildMessage(string template, object env)
		{
			DeprecationUtils.phase3(this.GetType(), "buildMessage(String, Object)", "Use SwiftWriter instead.");
			throw new System.NotSupportedException("Use SwiftWriter");
		}
	}

}