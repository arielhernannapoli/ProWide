using System;
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
namespace com.prowidesoftware.swift.io.writer
{

	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Helper class to deal with swift fields that allow many lines of text
	/// 
	/// @author www.prowidesoftware.com
	/// </summary>
	//Sebastian Feb 2016: make this API static
	public class MultilineUtil
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MultilineUtil).FullName);

		/// <summary>
		/// Same as <code>removeInnerEmptyLines(lines, false)</code> </summary>
		/// <param name="lines"> </param>
		/// <returns> a String array with all nonempty lines contained in the lines array
		/// </returns>
		/// <seealso cref= #removeInnerEmptyLines(String[], boolean) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String[] removeInnerEmptyLines(final String[] lines)
		public virtual string[] removeInnerEmptyLines(string[] lines)
		{
			return removeInnerEmptyLines(lines, false);
		}

		/// <summary>
		/// Helper method to remove empty lines on a multiline field.
		/// </summary>
		/// <param name="lines"> an non null array of lines to process </param>
		/// <param name="keepAll"> if <code>true</code> this method will have the effect of sorting empty lines to the end, if <code>false</code>, empty lines will be removed </param>
		/// <returns> a String array with all nonempty lines contained in the lines array, the string may be empty if lines is empty, or no non-empty lines are present </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String[] removeInnerEmptyLines(final String[] lines, final boolean keepAll)
		public virtual string[] removeInnerEmptyLines(string[] lines, bool keepAll)
		{
			Validate.notNull(lines, "lines cannot be null");
			if (lines.Length == 0)
			{
				return lines;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.ArrayList<String> text = new java.util.ArrayList<>();
			List<string> text = new List<string>();
			List<string> empty = null;
			if (keepAll)
			{
				empty = new List<>();
			}
			for (int i = 0;i < lines.Length;i++)
			{
				if (isEmpty(lines[i]))
				{
					if (keepAll)
					{
						empty.Add(lines[i]);
					}
				}
				else
				{
					text.Add(lines[i]);
				}
			}
			if (keepAll)
			{
				text.AddRange(empty);
			}
			if (log.isLoggable(Level.FINE))
			{
				log.fine("text: " + text);
			}
			return text.ToArray();
		}

		/// <summary>
		/// Returns <code>true</code> if string is not null and contains at least one non white character
		/// </summary>
		private bool isEmpty(string @string)
		{
			return @string == null || @string.Trim().Length == 0;
		}

	}

}