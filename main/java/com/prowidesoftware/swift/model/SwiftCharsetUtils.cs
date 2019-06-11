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
namespace com.prowidesoftware.swift.model
{

	using ArrayUtils = org.apache.commons.lang3.ArrayUtils;
	using StringUtils = org.apache.commons.lang3.StringUtils;

	/// <summary>
	/// Helper class to validate SWIFT char sets (named after the SWIFT User Handbook).
	/// 
	/// <para>Note that when a SWIFT character set refers to a set of letters, lowercase or uppercase, it means only letters in
	/// English. Therefore this implementation does not use the Character API as being Character.isLetter because that would
	/// accept letters with internationalization. Instead, the integer values of the characters are used to compare them with
	/// the set of allowed characters in each case.
	/// </para>
	/// </summary>
	public class SwiftCharsetUtils
	{
		private static char[] digits = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
		private static char[] AZ = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
		private static char[] azLowerCase = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
		private static char[] specialCharacters_x = new char[] {'/', '-', '?', ':', '(', ')', '.', ',', '\'', '+', ' ', '\n', '\r'};
		private static char[] specialCharacters_y = new char[] {' ', '.', ',', '-', '(', ')', '/', '=', '\'', '+', ':', '?', '!', '"', '%', '&', '*', ';', '<', '>'};
		private static char[] specialCharacters_z = new char[] {'.', ',', '-', '(', ')', '/', '=', '\'', '+', ':', '?', '@', '#', ' ', '{', '!', '"', '%', '&', '*', ';', '<', '>', '_', '\n', '\r'};

		public static int OK = -1;

		// Suppress default constructor for noninstantiability
		private SwiftCharsetUtils()
		{
			throw new AssertionError();
		}

		private static bool isNumber(char character)
		{
			return (character >= '0') && (character <= '9');
		}

		private static bool isLowercaseLetter(char character)
		{
			return (character >= 'a') && (character <= 'z');
		}

		private static bool isUppercaseLetter(char character)
		{
			return (character >= 'A') && (character <= 'Z');
		}

		/// <summary>
		/// Returns true if the parameter char is part of the n character set;
		/// numeric digits (0 through 9) only
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean is_n(final char character)
		public static bool is_n(char character)
		{
			return isNumber(character);
		}

		/// <summary>
		/// Returns this.OK (-1) if all characters of parameter string are part of the n character set.
		/// Otherwise returns the position (zero based) of the first invalid character found. </summary>
		/// <seealso cref= #get_n() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int is_n(final String s)
		public static int is_n(string s)
		{
			return @is(s, SwiftCharset.n);
		}

		/// <summary>
		/// Returns true if the parameter char is part of the a character set;
		/// alphabetic capital letters (A through Z), upper case only
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean is_a(final char character)
		public static bool is_a(char character)
		{
			return isUppercaseLetter(character);
		}

		/// <summary>
		/// Returns this.OK (-1) if all characters of parameter string are part of the a character set.
		/// Otherwise returns the position (zero based) of the first invalid character found. </summary>
		/// <seealso cref= #get_a() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int is_a(final String s)
		public static int is_a(string s)
		{
			return @is(s, SwiftCharset.a);
		}

		/// <summary>
		/// Returns true if the parameter char is part of the x character set;
		/// any character of the X permitted set (General FIN application set)  upper case and lower case allowed
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean is_x(final char character)
		public static bool is_x(char character)
		{
			return isLowercaseLetter(character) || isUppercaseLetter(character) || isNumber(character) || @is(character, specialCharacters_x);
		}

		/// <summary>
		/// Returns this.OK (-1) if all characters of parameter string are part of the x character set.
		/// Otherwise returns the position (zero based) of the first invalid character found. </summary>
		/// <seealso cref= #get_x() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int is_x(final String s)
		public static int is_x(string s)
		{
			return @is(s, SwiftCharset.x);
		}

		/// <summary>
		/// Returns true if the parameter char is part of the y character set;
		/// any character of the Y permitted set (EDI service specific set), upper case only
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean is_y(final char character)
		public static bool is_y(char character)
		{
			return isUppercaseLetter(character) || isNumber(character) || @is(character, specialCharacters_y);
		}

		/// <summary>
		/// Returns this.OK (-1) if all characters of parameter string are part of the y character set.
		/// Otherwise returns the position (zero based) of the first invalid character found. </summary>
		/// <seealso cref= #get_y() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int is_y(final String s)
		public static int is_y(string s)
		{
			return @is(s, SwiftCharset.y);
		}

		/// <summary>
		/// Returns true if the parameter char is part of the z character set;
		/// all characters included in the X and Y sets, plus a couple of special characters
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean is_z(final char character)
		public static bool is_z(char character)
		{
			return isLowercaseLetter(character) || isUppercaseLetter(character) || isNumber(character) || @is(character, specialCharacters_z);
		}

		/// <summary>
		/// Returns this.OK (-1) if all characters of parameter string are part of the z character set.
		/// Otherwise returns the position (zero based) of the first invalid character found. </summary>
		/// <seealso cref= #get_z() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int is_z(final String s)
		public static int is_z(string s)
		{
			return @is(s, SwiftCharset.z);
		}

		/// <summary>
		/// Returns true if the parameter char is part of the c character set;
		/// alpha-numeric capital letters (upper case), and digits only
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean is_c(final char character)
		public static bool is_c(char character)
		{
			return isUppercaseLetter(character) || isNumber(character);
		}

		/// <summary>
		/// Returns this.OK (-1) if all characters of parameter string are part of the c character set.
		/// Otherwise returns the position (zero based) of the first invalid character found. </summary>
		/// <seealso cref= #get_c() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int is_c(final String s)
		public static int is_c(string s)
		{
			return @is(s, SwiftCharset.c);
		}

		/// <summary>
		/// Returns true if the parameter char is part of the A character set;
		/// alphabetic, upper case or lower case A through Z, a through z
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean is_A(final char character)
		public static bool is_A(char character)
		{
			return isLowercaseLetter(character) || isUppercaseLetter(character);
		}

		/// <summary>
		/// Returns this.OK (-1) if all characters of parameter string are part of the A character set.
		/// Otherwise returns the position (zero based) of the first invalid character found. </summary>
		/// <seealso cref= #get_A() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int is_A(final String s)
		public static int is_A(string s)
		{
			return @is(s, SwiftCharset.A);
		}

		/// <summary>
		/// Returns true if the parameter char is part of the B character set;
		/// alphanumeric upper case or lower case A through Z, a through z and digits
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean is_B(final char character)
		public static bool is_B(char character)
		{
			return isLowercaseLetter(character) || isUppercaseLetter(character) || isNumber(character);
		}

		/// <summary>
		/// Returns this.OK (-1) if all characters of parameter string are part of the B character set.
		/// Otherwise returns the position (zero based) of the first invalid character found. </summary>
		/// <seealso cref= #get_B() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int is_B(final String s)
		public static int is_B(string s)
		{
			return @is(s, SwiftCharset.B);
		}

		/// <summary>
		/// Checks if the string character belogs to a given SWIFT charset </summary>
		/// <returns> Returns this.OK (-1) if all characters in the string matches a char defined in the charset or
		/// the position (zero based) of the first invalid character found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int is(final String s, SwiftCharset charset)
		public static int @is(string s, SwiftCharset charset)
		{
			if (StringUtils.isNotEmpty(s))
			{
				for (int i = 0; i < s.Length; i++)
				{
					if (!@is(s[i], charset))
					{
						return i;
					}
				}
			}
			return OK;
		}

		/// <summary>
		/// Checks if the character belogs to a given SWIFT charset </summary>
		/// <returns> true if character matches a char defined in the charset </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean is(final char c, SwiftCharset charset)
		public static bool @is(char c, SwiftCharset charset)
		{
			switch (charset)
			{
				case com.prowidesoftware.swift.model.SwiftCharset.n:
				{
					return is_n(c);
				}
				case com.prowidesoftware.swift.model.SwiftCharset.a:
				{
					return is_a(c);
				}
				case com.prowidesoftware.swift.model.SwiftCharset.A:
				{
					return is_A(c);
				}
				case com.prowidesoftware.swift.model.SwiftCharset.x:
				{
					return is_x(c);
				}
				case com.prowidesoftware.swift.model.SwiftCharset.y:
				{
					return is_y(c);
				}
				case com.prowidesoftware.swift.model.SwiftCharset.z:
				{
					return is_z(c);
				}
				case com.prowidesoftware.swift.model.SwiftCharset.c:
				{
					return is_c(c);
				}
				case com.prowidesoftware.swift.model.SwiftCharset.B:
				{
					return is_B(c);
				}
				default:
				{
					throw new ProwideException("Unexpected charset value " + charset);
				}
			}
		}

		/// <summary>
		/// Returns a human-friendly description of the charset </summary>
		/// <param name="charset"> a list of character defining a charset </param>
		/// <returns> a string describing the charset </returns>
		public static string getAsString(SwiftCharset charset)
		{
			string result = null;
			switch (charset)
			{
				case com.prowidesoftware.swift.model.SwiftCharset.n:
				{
					result = getAsString(get_n());
					break;
				}
				case com.prowidesoftware.swift.model.SwiftCharset.a:
				{
					result = getAsString(get_a());
					break;
				}
				case com.prowidesoftware.swift.model.SwiftCharset.A:
				{
					result = getAsString(get_A());
					break;
				}
				case com.prowidesoftware.swift.model.SwiftCharset.x:
				{
					result = getAsString(get_x());
					break;
				}
				case com.prowidesoftware.swift.model.SwiftCharset.y:
				{
					result = getAsString(get_y());
					break;
				}
				case com.prowidesoftware.swift.model.SwiftCharset.z:
				{
					result = getAsString(get_z());
					break;
				}
				case com.prowidesoftware.swift.model.SwiftCharset.c:
				{
					result = getAsString(get_c());
					break;
				}
				case com.prowidesoftware.swift.model.SwiftCharset.B:
				{
					result = getAsString(get_B());
					break;
				}
				default:
				{
					throw new ProwideException("Unexpected charset value " + charset);
				}
			}
			result = StringUtils.replace(result, getAsString(get_n()), "[0-9]");
			result = StringUtils.replace(result, getAsString(get_a()), "[A-Z]");
			result = StringUtils.replace(result, getAsString(azLowerCase), "[a-z]");
			return result;
		}

		/// <summary>
		/// Returns true if the parameter char is part of the parameter character set
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static boolean is(final char c, final char[] charset)
		private static bool @is(char c, char[] charset)
		{
			return ArrayUtils.contains(charset, c);
		}

		/// <summary>
		/// Gets SWIFT n charset; numeric digits (0 through 9) only.
		/// </summary>
		public static char[] get_n()
		{
			char[] result = new char[] {'0','1','2','3','4','5','6','7','8','9'};
			return result;
		}

		/// <summary>
		/// Gets SWIFT a charset; alphabetic capital letters (A through Z), upper case only.
		/// </summary>
		public static char[] get_a()
		{
			char[] result = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
			return result;
		}

		/// <summary>
		/// Lower case a to z.
		/// </summary>
		private static char[] _get_az()
		{
			char[] result = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
			return result;
		}

		/// <summary>
		/// Gets SWIFT A charset; alphabetic, upper case or lower case A through Z, a through z.
		/// </summary>
		public static char[] get_A()
		{
			char[] result = get_a();
			return ArrayUtils.addAll(result, _get_az());
		}

		/// <summary>
		/// Gets SWIFT x charset; any character of the X permitted set (General FIN application set)  upper case and lower case allowed.
		/// </summary>
		public static char[] get_x()
		{
			char[] result = specialCharacters_x;
			result = ArrayUtils.addAll(result, get_A());
			result = ArrayUtils.addAll(result, get_n());
			return result;
		}

		/// <summary>
		/// Gets SWIFT y charset; any character of the Y permitted set (EDI service specific set), upper case only.
		/// </summary>
		public static char[] get_y()
		{
			char[] result = specialCharacters_y;
			result = ArrayUtils.addAll(result, get_a());
			result = ArrayUtils.addAll(result, get_n());
			return result;
		}

		/// <summary>
		/// Gets SWIFT z charset; all characters included in the X and Y sets, plus a couple of special characters.
		/// </summary>
		public static char[] get_z()
		{
			char[] result = specialCharacters_z;
			result = ArrayUtils.addAll(result, get_A());
			result = ArrayUtils.addAll(result, get_n());
			return result;
		}

		/// <summary>
		/// Gets SWIFT c charset; alpha-numeric capital letters (upper case), and digits only.
		/// </summary>
		public static char[] get_c()
		{
			char[] result = get_a();
			return ArrayUtils.addAll(result, get_n());
		}

		/// <summary>
		/// Gets SWIFT B charset; alphanumeric upper case or lower case A through Z, a through z and 0, 1, 2, 3, 4, 5, 6, 7, 8, 9.
		/// </summary>
		public static char[] get_B()
		{
			char[] result = get_A();
			return ArrayUtils.addAll(result, get_n());
		}

		/// <summary>
		/// Returns a human-friendly description of the charset </summary>
		/// <param name="charset"> a list of character defining a charset </param>
		/// <returns> a string describing the charset </returns>
		public static string getAsString(char[] charset)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < charset.Length; i++)
			{
				string ch = null;
				if (charset[i] == '\n')
				{
					ch = "LF";
				}
				else if (charset[i] == '\r')
				{
					ch = "CR";
				}
				else
				{
					ch = "" + charset[i];
				}
				result.Append("[");
				result.Append(ch);
				result.Append("]");
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns a new string removing all characters that not belong to the parameter charset </summary>
		/// <param name="s"> the string to filter </param>
		/// <param name="charset"> a charset to match </param>
		/// <returns> a new string with non matching characters removed </returns>
		public static string filter(string s, SwiftCharset charset)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				if (@is(s[i], charset))
				{
					result.Append(s[i]);
				}
			}
			return result.ToString();
		}

	}
}