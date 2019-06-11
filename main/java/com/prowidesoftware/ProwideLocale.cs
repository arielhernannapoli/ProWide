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
namespace com.prowidesoftware
{


	/// <summary>
	/// Helper class to manage default supported locales
	/// 
	/// @author miguel
	/// 
	/// @since 7.7
	/// </summary>
	public sealed class ProwideLocale
	{
		public static string[] SUPPORTED_LANGS = new string[] {"en", "es", "fr", "it", "ru"};

		/// <summary>
		/// Get requested bundle or ENGLISH if missing resource for the given locale.
		/// Uses the calss FQN (with package) for the resource location.
		/// </summary>
		/// <param name="clazz">
		///            the class for which the resource bundle is loaded </param>
		/// <param name="locale">
		///            a locale </param>
		/// <returns> the bundle for the given class and locale or English if not found.
		/// @since 7.7 </returns>
		public static ResourceBundle getBundle(Type clazz, Locale locale)
		{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
			return getBundle(clazz.FullName, locale);
		}

		/// <summary>
		/// Safe get locale, checking if current locale is supported Same as
		/// <code>getBundle(clazz, Locale.getDefault()))</code>
		/// </summary>
		/// <seealso cref= #getBundle(Class, Locale)
		/// @since 7.7 </seealso>
		public static ResourceBundle getBundle(Type clazz)
		{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
			return getBundle(clazz.FullName);
		}

		/// <summary>
		/// Get requested bundle or ENGLISH if missing resource for the given locale.
		/// </summary>
		/// <param name="resource">
		///            the name ot the resource bundle to loaded </param>
		/// <param name="locale">
		///            a locale </param>
		/// <returns> the bundle for the given resource name and locale or English if not
		///         found.
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.ResourceBundle getBundle(final String resource, java.util.Locale locale)
		public static ResourceBundle getBundle(string resource, Locale locale)
		{
			try
			{
				return ResourceBundle.getBundle(resource, locale);
			}
			catch (MissingResourceException)
			{
				return ResourceBundle.getBundle(resource, Locale.ENGLISH);
			}
		}

		/// <summary>
		/// Safe get locale, checking if current locale is supported Same as
		/// <code>getBundle(resource, Locale.getDefault()))</code>
		/// </summary>
		/// <seealso cref= #getBundle(String, Locale)
		/// @since 7.9.7 </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.ResourceBundle getBundle(final String resource)
		public static ResourceBundle getBundle(string resource)
		{
			return getBundle(resource, Locale.Default);
		}

	}

}