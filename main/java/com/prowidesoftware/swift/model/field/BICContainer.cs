using System.Collections.Generic;

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
namespace com.prowidesoftware.swift.model.field
{


	/// <summary>
	/// Interface to mark fields whose definition contain a BIC.
	/// Note that if a field has a BIC and it is optional, and the actual 
	/// field has not set the optional BIC/s then
	/// the call bics() will return an empty list
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.1
	/// </summary>
	public interface BICContainer
	{

		/// <summary>
		/// Get a list of strings of BICs present in this field </summary>
		/// <returns> a list, with zero or more BICs in this field. </returns>
		IList<string> bicStrings();

		/// <summary>
		/// Utility method that creates a BIC for every string returned by <seealso cref="#bicStrings()"/>
		/// 
		/// </summary>
		IList<BIC> bics();
	}

}