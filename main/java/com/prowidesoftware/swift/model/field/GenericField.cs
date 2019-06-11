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
	/// Interface to mark generic fields and add method related to DSS and qualifiers.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.4
	/// </summary>
	public interface GenericField
	{
		   /// <summary>
		   /// Returns the issuer code (or Data Source Scheme or DSS).
		   /// The DSS is only present in some generic fields, when present, is equals to component two.
		   /// </summary>
		   /// <returns> DSS component value or null if the DSS is not set or not available for this field. </returns>
		   string DSS {get;}

		   /// <summary>
		   /// Checks if the issuer code (or Data Source Scheme or DSS) is present.
		   /// </summary>
		   /// <seealso cref= #getDSS() </seealso>
		   /// <returns> true if DSS is present, false otherwise. </returns>
		   bool DSSPresent {get;}

		   /// <summary>
		   /// Gets the conditional qualifier.<br>
		   /// The conditional qualifier is the the component following the DSS of generic fields, being component 2 or 3 depending on the field structure definition.
		   /// </summary>
		   /// <returns> for generic fields returns the value of the conditional qualifier or null if not set or not applicable for this kind of field. </returns>
		   string ConditionalQualifier {get;}
	}

}