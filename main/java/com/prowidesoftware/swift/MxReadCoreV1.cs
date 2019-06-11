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

	using MxParser = com.prowidesoftware.swift.io.parser.MxParser;
	using MxId = com.prowidesoftware.swift.model.MxId;
	using AbstractMX = com.prowidesoftware.swift.model.mx.AbstractMX;
	using MxRead = com.prowidesoftware.swift.model.mx.MxRead;

	/// <summary>
	/// For the moment this is only available in the Prowide Integrator version.
	/// 
	/// To parse XML into the generic MxNode structure, or to parse business headers check <seealso cref="MxParser"/>
	/// </summary>
	/*
	 * 2015.03 miguel
	 * This interface is not going to make much sense since MxParser will support directly MxNode,
	 * which was supposed to be here initially
	 */
	public class MxReadCoreV1 : MxRead
	{

		/// <summary>
		/// For the moment this is only available in the Prowide Integrator version
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public com.prowidesoftware.swift.model.mx.AbstractMX read(final Class targetClass, final String xml, final Class[] classes)
		public virtual AbstractMX read(Type targetClass, string xml, Type[] classes)
		{
			throw new System.NotSupportedException("For the moment this is only available in the integrator version");
		}

		/// <summary>
		/// For the moment this is only available in the Prowide Integrator version
		/// </summary>
		public virtual AbstractMX read(string xml, MxId id)
		{
			throw new System.NotSupportedException("For the moment this is only available in the integrator version");
		}

	}

}