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

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using MxNode = com.prowidesoftware.swift.model.MxNode;
	using AbstractMX = com.prowidesoftware.swift.model.mx.AbstractMX;
	using BusinessHeader = com.prowidesoftware.swift.model.mx.BusinessHeader;
	using MxWrite = com.prowidesoftware.swift.model.mx.MxWrite;

	/// <summary>
	/// For the moment this is only available in the Prowide Integrator version.
	/// 
	/// To create the XML from the generic structure check <seealso cref="MxNode"/> and <seealso cref="BusinessHeader"/>
	/// </summary>
	public class MxWriteCoreV1 : MxWrite
	{

		/// @deprecated use <seealso cref="#message(String, AbstractMX, Class[], String, boolean)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use <seealso cref="#message(String, com.prowidesoftware.swift.model.mx.AbstractMX, Class[] , String, boolean)"/> instead") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public String message(String namespace, com.prowidesoftware.swift.model.mx.AbstractMX obj, @SuppressWarnings("rawtypes") Class[] classes)
		[Obsolete("use <seealso cref="#message(String, com.prowidesoftware.swift.model.mx.AbstractMX, Class[] , String, boolean)"/> instead")]
		public virtual string message(string @namespace, AbstractMX obj, SuppressWarnings("rawtypes") Class[] classes)
		{
			DeprecationUtils.phase3(this.GetType(), "message(String, AbstractMX, Class[])", "Use message(String, AbstractMX, Class[], String, boolean) instead.");
			throw new System.NotSupportedException("For the moment this is only available in the integrator version");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public String message(String namespace, com.prowidesoftware.swift.model.mx.AbstractMX obj, @SuppressWarnings("rawtypes") Class[] classes, String prefix, boolean includeXMLDeclaration)
		public virtual string message(string @namespace, AbstractMX obj, Type[] classes, string prefix, bool includeXMLDeclaration)
		{
			throw new System.NotSupportedException("For the moment this is only available in the integrator version");
		}

	}

}