﻿using System;

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
namespace com.prowidesoftware.swift.@internal
{


	/// <summary>
	/// Mark detecting sequences strategy used.
	/// <em>Internal use</em> 
	/// <ol>
	/// 		<li> <code>Type.GENERATED_16RS</code> </li>
	/// 		<li> <code>Type.GENERATED_FIXED_WITH_OPTIONAL_TAIL</code> </li>
	/// 		<li> <code>Type.GENERATED_SLICE</code> </li>
	/// 		<li> <code>Type.SPLIT_BY_15</code> </li>
	/// </ol>
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Documented @Retention(RetentionPolicy.SOURCE) public class SequenceStyle extends System.Attribute
	public class SequenceStyle : System.Attribute
	{
		public enum Type
		{
			GENERATED_16RS,
			GENERATED_FIXED_WITH_OPTIONAL_TAIL,
			GENERATED_SLICE,
			SPLIT_BY_15,
			CUSTOM
		}

		Type value();
	}

}