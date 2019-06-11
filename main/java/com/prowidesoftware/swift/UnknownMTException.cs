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
	/// Thrown if a message cannot be identified.
	/// </summary>
	/// @deprecated no longer used 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("no longer used") @ProwideDeprecated(phase2=TargetYear._2019) public class UnknownMTException extends com.prowidesoftware.ProwideException
	[Obsolete("no longer used")]
	public class UnknownMTException : ProwideException
	{
		private const long serialVersionUID = 6708923821228731L;

		/// <summary>
		/// Default constructor
		/// </summary>
		public UnknownMTException() : base()
		{
		}

		/// <summary>
		/// Constructor with given text message and cause </summary>
		/// <param name="message"> </param>
		/// <param name="cause"> </param>
		public UnknownMTException(string message, Exception cause) : base(message, cause)
		{
		}

		/// <summary>
		/// Constructor with given text message, it takes a default cause. </summary>
		/// <param name="message"> </param>
		public UnknownMTException(string message) : base(message)
		{
		}

		/// <summary>
		/// Constructor with given cause, it takes a default message. </summary>
		/// <param name="cause"> </param>
		public UnknownMTException(Exception cause) : base(cause)
		{
		}

	}

}