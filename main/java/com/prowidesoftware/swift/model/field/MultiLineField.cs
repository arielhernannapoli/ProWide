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
	/// Interface to mark fields whose structure admits multiple lines
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.7
	/// </summary>
	public interface MultiLineField
	{

		/// <summary>
		/// Returns a specific line from the field's value.<br>
		/// </summary>
		/// <param name="line"> a reference to a specific line in the field, first line being 1 </param>
		/// <returns> line content or null if not present or if line number is above the expected
		/// </returns>
		/// <seealso cref= #getLine(int, int)
		/// @since 7.7 </seealso>
		string getLine(int line);

		/// <summary>
		/// Returns a specific line from the field's value.<br><br>
		/// 
		/// Performs a semantic line retrieval based on the field components definition,
		/// so this is not the same as just splitting the value in lines and getting
		/// one of the lines with an index.<br>
		/// If the field defines the first line components as optional and those components
		/// are not present in the particular field instance, then getLine(1) will return null
		/// because according to the field definition the first line is not present.<br>
		/// 
		/// Also notice that a line may be composed by several components, there is
		/// no linear relation between component numbers and lines numbers.<br>
		/// 
		/// The offset parameter is used to count lines from a specific component instead
		/// of the first one, and it is particularly useful when combined with the component
		/// static names, for example getLine(1, Field35B.DESCRIPTION)
		/// Notice than if the query includes a component offset, the result will not contain 
		/// prefix component separators. If the line for example starts with a slash character
		/// it will be removed. This is to avoid meaningless separators for components that
		/// are being skipped because of the offset parameter. 
		/// </summary>
		/// <param name="line"> a reference to a specific line in the field, first line being 1 </param>
		/// <param name="offset"> an optional component number used as offset when counting lines
		/// </param>
		/// <returns> line content or null if not present, if line number is above the expected or if the offset is invalid
		/// @since 7.7 </returns>
		string getLine(int line, int offset);

		/// <summary>
		/// Returns the field value split into lines.<br>
		/// </summary>
		/// <returns> found lines or empty list if value is empty
		/// @since 7.7 </returns>
		IList<string> Lines {get;}

		/// <summary>
		/// Returns the field value starting at the offset component, split into lines.<br>
		/// </summary>
		/// <param name="offset"> an optional component number used as offset when counting lines </param>
		/// <returns> found lines or empty list if lines are not present or the offset is invalid
		/// @since 7.7 </returns>
		IList<string> getLines(int offset);

		/// <summary>
		/// Returns a specific subset of lines from the field's value, given a range.<br>
		/// </summary>
		/// <param name="start"> a reference to a specific line in the field, first line being 1 </param>
		/// <param name="end"> a reference to a specific line in the field, must be greater than start
		/// </param>
		/// <returns> found lines or empty list if value is empty
		/// </returns>
		/// <seealso cref= #getLinesBetween(int, int, int)
		/// @since 7.7 </seealso>
		IList<string> getLinesBetween(int start, int end);

		/// <summary>
		/// Returns a specific subset of lines from the field's value, starting at the offset component.<br>
		/// </summary>
		/// <param name="start"> a reference to a specific line in the field, first line being 1 </param>
		/// <param name="end"> a reference to a specific line in the field, must be greater than start </param>
		/// <param name="offset"> an optional component number used as offset when counting lines
		/// </param>
		/// <returns> found lines or empty list if lines are not present or the offset is invalid
		/// 
		/// @since 7.7 </returns>
		IList<string> getLinesBetween(int start, int end, int offset);

	}

}