using System;
using System.Collections.Generic;
using System.Text;

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

	using StringUtils = org.apache.commons.lang3.StringUtils;




	/// <summary>
	/// This class provides methods to parse field components.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class SwiftParseUtils
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(SwiftParseUtils.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftParseUtils).FullName);

		// Suppress default constructor for noninstantiability
		private SwiftParseUtils()
		{
			throw new AssertionError();
		}

		/// <summary>
		/// Split components of a line, with an optional starting string and a component separator.
		/// Adjacent separators are treated as one separator.
		/// This method does not validate the starting string presence, it just strips it if present.
		/// this methods uses <seealso cref="StringUtils#splitByWholeSeparator(String, String)"/>
		/// </summary>
		/// <param name="line"> the string to parse </param>
		/// <param name="starting"> an optional starting string </param>
		/// <param name="separator"> the components separator </param>
		/// <returns> a list of String with the found components or an empty list if none is found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<String> splitComponents(final String line, final String starting, final String separator)
		public static IList<string> splitComponents(string line, string starting, string separator)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.ArrayList<String> result = new java.util.ArrayList<>();
			List<string> result = new List<string>();

			if (StringUtils.isNotBlank(line))
			{
				string lineNoPrefix = removePrefix(line, starting);

				if (StringUtils.isNotBlank(separator))
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String[] tokens = org.apache.commons.lang3.StringUtils.splitByWholeSeparator(lineNoPrefix, separator);
					string[] tokens = StringUtils.splitByWholeSeparator(lineNoPrefix, separator);
					//add not empty tokens to result
					for (int i = 0; i < tokens.Length; i++)
					{
						if (StringUtils.isNotBlank(tokens[i]))
						{
							result.Add(tokens[i]);
						}
					}
				}
				else
				{
					result.Add(lineNoPrefix);
				}
			}
			return result;
		}

		/// <summary>
		/// Split components of a line with an optional starting string and a component separator
		/// and returns the first token found or null if the string without starting substring
		/// is empty or null.<br>
		/// This method does not validate the starting string presence, it just strips it if present.
		/// </summary>
		/// <param name="line"> </param>
		/// <param name="starting"> </param>
		/// <param name="separator"> </param>
		/// <returns> the first token found or null </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenFirst(String line, final String starting, final String separator)
		public static string getTokenFirst(string line, string starting, string separator)
		{
			string result = null;
			if (StringUtils.isNotBlank(line))
			{
				string lineNoPrefix = removePrefix(line, starting);

				result = StringUtils.substringBefore(lineNoPrefix, separator);
				if (StringUtils.isBlank(result))
				{
					return null;
				}
			}
			return result;
		}

		/// <param name="line"> </param>
		/// <param name="separator"> </param>
		/// <returns> found token </returns>
		/// <seealso cref= #getTokenFirst(String, String, String) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenFirst(final String line, final String separator)
		public static string getTokenFirst(string line, string separator)
		{
			return getTokenFirst(line, null, separator);
		}

		/// <param name="value"> </param>
		/// <param name="prefix"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String removePrefix(final String value, final String prefix)
		public static string removePrefix(string value, string prefix)
		{
			if (StringUtils.isNotBlank(value) && StringUtils.isNotBlank(prefix) && value.StartsWith(prefix, StringComparison.Ordinal))
			{
				return StringUtils.substringAfter(value, prefix);
			}
			return value;
		}

		/// <summary>
		/// Split components of a line using the parameter separator and returns the second token found or null if
		/// second component is missing. Two adjacent separators are NOT treated as one.<br>
		/// Examples with slash as separator:<ul>
		/// 		<li>for the literal "abc//def/ghi" will return null.</li>
		/// 		<li>for the literal "abc/foo/def" will return "foo".</li>
		/// 		<li>for the literal "abc/foo/def/ghi" will return "foo".</li>
		/// </ul>
		/// </summary>
		/// <param name="line"> </param>
		/// <param name="separator"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenSecond(final String line, final String separator)
		public static string getTokenSecond(string line, string separator)
		{
			//notice we cannot use String.split nor StringUtils.split because in that implementations two adjacent separators are treated as one
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String result = getTokenFirst(org.apache.commons.lang3.StringUtils.substringAfter(line, separator), null, separator);
			string result = getTokenFirst(StringUtils.substringAfter(line, separator), null, separator);
			return result;
		}

		/// <summary>
		/// Split components of a line using the parameter separator and returns the second token found or null if
		/// second component is missing. Two adjacent separators are NOT treated as one. The second component is assumed as the
		/// last one so its content may have additional separators if present.<br>
		/// Examples with slash as separator:<ul>
		/// 		<li>for the literal "abc//def/ghi" will return null.</li>
		/// 		<li>for the literal "abc/foo" will return "foo".</li>
		/// 		<li>for the literal "abc/foo/def/ghi" will return "foo/def/ghi".</li>
		/// </ul>
		/// </summary>
		/// <param name="line"> </param>
		/// <param name="separator"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenSecondLast(final String line, final String separator)
		public static string getTokenSecondLast(string line, string separator)
		{
			string result = StringUtils.substringAfter(line, separator);
			if (StringUtils.isBlank(result))
			{
				result = null;
			}
			return result;
		}

		/// <summary>
		/// Split components of a line with an optional starting string and a component separator
		/// and returns the second token found or null if the string without starting substring
		/// is empty or null.<br>
		/// This method does not validate the starting string presence, it just strips it if present.
		/// </summary>
		/// <param name="line"> </param>
		/// <param name="starting"> </param>
		/// <param name="separator"> </param>
		/// <returns> the second token found or null
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenSecond(final String line, final String starting, final String separator)
		public static string getTokenSecond(string line, string starting, string separator)
		{
			return getTokenSecond(removePrefix(line, starting), separator);
		}

		/// <summary>
		/// Split components of a line with an optional starting string and a component separator
		/// and returns the second token found or null if the string without starting substring
		/// is empty or null.
		/// <br>
		/// Two adjacent separators are NOT treated as one. The second component is assumed as the
		/// last one so its content may have additional separators if present.<br>
		/// This method does not validate the starting string presence, it just strips it if present.
		/// </summary>
		/// <param name="line"> </param>
		/// <param name="starting"> </param>
		/// <param name="separator"> </param>
		/// <returns> the second token found or null
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenSecondLast(final String line, final String starting, final String separator)
		public static string getTokenSecondLast(string line, string starting, string separator)
		{
			return getTokenSecondLast(removePrefix(line, starting), separator);
		}

		/// <summary>
		/// Split components of a line using the parameter separator and returns the third token found or null if
		/// third component is missing. Two adjacent separators are NOT treated as one.<br>
		/// Examples with slash as separator:<ul>
		/// 		<li>for the literal "abc/def//ghi" will return null.</li>
		/// 		<li>for the literal "abc/foo" will return "null".</li>
		/// 		<li>for the literal "abc/def/foo" will return "foo".</li>
		/// 		<li>for the literal "abc/def/foo/ghi" will return "foo".</li>
		/// </ul>
		/// </summary>
		/// <param name="line"> </param>
		/// <param name="separator"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenThird(final String line, final String separator)
		public static string getTokenThird(string line, string separator)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String result = getTokenSecond(getTokenSecondLast(line, separator), separator);
			string result = getTokenSecond(getTokenSecondLast(line, separator), separator);
			return result;
		}

		/// <summary>
		/// Split components of a line using the parameter separator and returns the third token found or null if
		/// third component is missing. Two adjacent separators are NOT treated as one. The third component is assumed as the
		/// last one so its content may have additional separators if present.<br>
		/// Examples with slash as separator:<ul>
		/// 		<li>for the literal "abc/def//ghi" will return null.</li>
		/// 		<li>for the literal "abc/foo" will return "null".</li>
		/// 		<li>for the literal "abc/def/foo" will return "foo".</li>
		/// 		<li>for the literal "abc/def/foo/ghi" will return "foo/ghi".</li>
		/// </ul>
		/// </summary>
		/// <param name="line"> </param>
		/// <param name="separator"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenThirdLast(final String line, final String separator)
		public static string getTokenThirdLast(string line, string separator)
		{
			string result = null;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String s1 = getTokenSecondLast(line, separator);
			string s1 = getTokenSecondLast(line, separator);
			if (StringUtils.isNotBlank(s1))
			{
				result = StringUtils.substringAfter(s1, separator);
				if (StringUtils.isBlank(result))
				{
					result = null;
				}
			}
			return result;
		}

		/// <summary>
		/// Split components of a line using the parameter separator and returns the forth token found or null if
		/// forth component is missing. Two adjacent separators are NOT treated as one.<br>
		/// Examples with slash as separator:<ul>
		/// 		<li>for the literal "abc/def/ghi//ghi" will return null.</li>
		/// 		<li>for the literal "abc/foo/ghi" will return "null".</li>
		/// 		<li>for the literal "abc/def/ghi/foo" will return "foo".</li>
		/// 		<li>for the literal "abc/def/ghi/foo/ghi" will return "foo".</li>
		/// </ul>
		/// </summary>
		/// <param name="line"> </param>
		/// <param name="separator"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenForth(final String line, final String separator)
		public static string getTokenForth(string line, string separator)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String result = getTokenSecond(getTokenThirdLast(line, separator), separator);
			string result = getTokenSecond(getTokenThirdLast(line, separator), separator);
			return result;
		}

		/// <summary>
		/// Split components of a line using the parameter separator and returns the forth token found or null if
		/// forth component is missing. Two adjacent separators are NOT treated as one. The forth component is assumed as the
		/// last one so its content may have additional separators if present.<br>
		/// Examples with slash as separator:<ul>
		/// 		<li>for the literal "abc/def/ghi//ghi" will return null.</li>
		/// 		<li>for the literal "abc/foo/ghi" will return "null".</li>
		/// 		<li>for the literal "abc/def/ghi/foo" will return "foo".</li>
		/// 		<li>for the literal "abc/def/ghi/foo/ghi" will return "foo/ghi".</li>
		/// </ul>
		/// </summary>
		/// <param name="line"> </param>
		/// <param name="separator"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTokenForthLast(final String line, final String separator)
		public static string getTokenForthLast(string line, string separator)
		{
			string result = null;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String s1 = getTokenThirdLast(line, separator);
			string s1 = getTokenThirdLast(line, separator);
			if (StringUtils.isNotBlank(s1))
			{
				result = StringUtils.substringAfter(s1, separator);
				if (StringUtils.isBlank(result))
				{
					result = null;
				}
			}
			return result;
		}

		/// <summary>
		/// Returns the alphabetic starting substring of the value.
		/// The split is made when the first numeric character is found.
		/// For example:<br>
		/// ABCD2345,33 will be return ABCD<br>
		/// If the value does not contain any alphabetic character null is returned.
		/// </summary>
		/// <param name="value"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getAlphaPrefix(final String value)
		public static string getAlphaPrefix(string value)
		{
			if (value != null && value.Length > 0)
			{
				int i = 0;
				while (i < value.Length && !StringUtils.isNumeric(char.ToString(value[i])))
				{
					i++;
				}
				if (i > 0)
				{
					return StringUtils.Substring(value, 0, i);
				}
			}
			return null;
		}

		/// <summary>
		/// Returns the numeric starting substring of the value.
		/// The split is made when the first alpha character (not number or comma) is found.
		/// For example:<br>
		/// 2345,33ABCD will be return 2345,33<br>
		/// If the value does not contain any numeric or comma character null is returned.
		/// </summary>
		/// <param name="value"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getNumericPrefix(final String value)
		public static string getNumericPrefix(string value)
		{
			if (value != null && value.Length > 0)
			{
				int i = 0;
				while (i < value.Length && (StringUtils.isNumeric(char.ToString(value[i])) || value[i] == ','))
				{
					i++;
				}
				if (i > 0)
				{
					return StringUtils.Substring(value, 0, i);
				}
			}
			return null;
		}

		/// <summary>
		/// Returns the numeric suffix of the value.
		/// The split is made when the first numeric character is found.
		/// For example:<br>
		/// ABCD2345,33 will be return 2345,33<br>
		/// If the value does not contain any numeric character null is returned.
		/// </summary>
		/// <param name="value"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getNumericSuffix(final String value)
		public static string getNumericSuffix(string value)
		{
			if (value != null && value.Length > 0)
			{
				int i = 0;
				while (i < value.Length && !StringUtils.isNumeric(char.ToString(value[i])))
				{
					i++;
				}
				if (i < value.Length)
				{
					return StringUtils.Substring(value, i - value);
				}
			}
			return null;
		}

		/// <summary>
		/// Returns the alpha suffix of the value.
		/// The split is made when the first alpha (not numetic or comma) character is found.
		/// For example:<br>
		/// 2345,33ABCD will be return ABCD<br>
		/// If the value does not contain any alpha character null is returned.
		/// </summary>
		/// <param name="value"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getAlphaSuffix(final String value)
		public static string getAlphaSuffix(string value)
		{
			if (value != null && value.Length > 0)
			{
				int i = 0;
				while (i < value.Length && (StringUtils.isNumeric(char.ToString(value[i])) || value[i] == ','))
				{
					i++;
				}
				if (i < value.Length)
				{
					return StringUtils.Substring(value, i - value);
				}
			}
			return null;
		}

		/// <summary>
		/// Separate the given string in lines using readline
		/// </summary>
		/// <param name="value"> </param>
		/// <returns> list of found lines </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.List<String> getLines(final String value)
		public static IList<string> getLines(string value)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<String> result = new java.util.ArrayList<>();
			IList<string> result = new List<string>();
			if (value != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.BufferedReader br = new java.io.BufferedReader(new java.io.StringReader(value));
				BufferedReader br = new BufferedReader(new StringReader(value));
				try
				{
					string l = br.readLine();
					while (l != null)
					{
						result.Add(l);
						l = br.readLine();
					}
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final java.io.IOException e)
				catch (IOException e)
				{
					throw new ProwideException(e);
				}
			}
			return result;
		}

		/// <summary>
		/// Populates a multiline field with content from an array of Strings.
		/// </summary>
		/// <param name="f"> field to populate with components' values </param>
		/// <param name="startingComponentNumber"> first component number to be set, then it will increment on each line added </param>
		/// <param name="linesToSet"> how many components must to be set, or null to set all available lines as components </param>
		/// <param name="startingLine"> lines list offset, zero based </param>
		/// <param name="lines"> list of lines from where to get components content </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void setComponentsFromLines(final Field f, final int startingComponentNumber, final Integer linesToSet, final int startingLine, final java.util.List<String> lines)
		public static void setComponentsFromLines(Field f, int startingComponentNumber, int? linesToSet, int startingLine, IList<string> lines)
		{
			int max = linesToSet != null? linesToSet : lines.Count;
			int componentNumber = startingComponentNumber;
			int lineNumber = startingLine;
			for (int i = 0; i < max; i++)
			{
				if (lines.Count > lineNumber)
				{
					f.setComponent(componentNumber, lines[lineNumber]);
				}
				componentNumber++;
				lineNumber++;
			}
		}

		/// <summary>
		/// Populates field with content from of a String splited into fixed length tokens.
		/// </summary>
		/// <param name="f"> field to populate with components' values </param>
		/// <param name="startingComponentNumber"> first component number to be set, then it will increment on each token added </param>
		/// <param name="componentsToSet"> how many components must to be set </param>
		/// <param name="tokenSize"> fixed size for each token grabbed from the String value </param>
		/// <param name="value"> from where to get components content
		/// @since 7.4 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static void setComponentsFromTokens(final Field f, final int startingComponentNumber, final int componentsToSet, final int tokenSize, final String value)
		public static void setComponentsFromTokens(Field f, int startingComponentNumber, int componentsToSet, int tokenSize, string value)
		{
			StringBuilder token = new StringBuilder();
			int componentNumber = startingComponentNumber;
			foreach (char c in value.ToCharArray())
			{
				if (token.Length < tokenSize)
				{
					token.Append(c);
				}
				else
				{
					//token complete
					if (componentNumber <= componentsToSet)
					{
						f.setComponent(componentNumber, token.ToString());
					}
					componentNumber++;
					token = new StringBuilder();
					token.Append(c);
				}
			}
			//add remainder
			if (token.Length > 0 && componentNumber <= componentsToSet)
			{
				f.setComponent(componentNumber, token.ToString());
			}
		}

	}

}