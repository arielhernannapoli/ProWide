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
namespace com.prowidesoftware.swift
{

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;

	/// <summary>
	/// Base class for exceptions.
	/// 
	/// @author www.prowidesoftware.com </summary>
	/// @deprecated this has been replaced by <seealso cref="com.prowidesoftware.ProwideException"/> 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("this has been replaced by <seealso cref="com.prowidesoftware.ProwideException"/>") @ProwideDeprecated(phase4=TargetYear._2019) public class WifeException extends RuntimeException
	[Obsolete("this has been replaced by <seealso cref="com.prowidesoftware.ProwideException"/>")]
	public class WifeException : Exception
	{
		private const long serialVersionUID = -5598159933338062109L;

		/// <seealso cref= RuntimeException#RuntimeException() </seealso>
		public WifeException() : base()
		{
		}

		/// <seealso cref= RuntimeException#RuntimeException(String, Throwable) </seealso>
		public WifeException(string message, Exception cause) : base(message, cause)
		{
		}

		/// <seealso cref= RuntimeException#RuntimeException(String) </seealso>
		public WifeException(string message) : base(message)
		{
		}

		/// <seealso cref= RuntimeException#RuntimeException(Throwable) </seealso>
		public WifeException(Exception cause) : base(cause)
		{
		}

	}

}