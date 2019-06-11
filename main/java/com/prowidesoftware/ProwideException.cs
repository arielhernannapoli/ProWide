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
namespace com.prowidesoftware
{

	using StringSubstitutor = org.apache.commons.text.StringSubstitutor;


	/// <summary>
	/// Base class for Prowide exceptions hierarchy.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.7
	/// </summary>
	public class ProwideException : Exception
	{
		private const long serialVersionUID = 4645197208853563727L;
		[NonSerialized]
		private static final java;

		private IDictionary<string, string> variables = null;

		public ProwideException() : base()
		{
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public ProwideException(final String message, final Throwable cause)
		public ProwideException(string message, Exception cause) : base(message, cause)
		{
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public ProwideException(final String message)
		public ProwideException(string message) : base(message)
		{
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public ProwideException(final Throwable cause)
		public ProwideException(Exception cause) : base(cause)
		{
		}

		public static ResourceBundle Bundle
		{
			get
			{
				return ProwideLocale.getBundle(typeof(ProwideException).Name);
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static ResourceBundle getBundle(final Locale locale)
		public static ResourceBundle getBundle(Locale locale)
		{
			return ProwideLocale.getBundle(typeof(ProwideException).Name, locale);
		}

		/// <summary>
		/// Gets a descriptive, localized error message suitable for presenting to the final user.
		/// </summary>
		/// <param name="locale"> optional locale </param>
		/// <returns> exception description </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getMessage(final Locale locale)
		public virtual string getMessage(Locale locale)
		{
			return getMessage(locale, null);
		}

		/// <summary>
		/// Gets a descriptive message suitable for presenting to the final user, using the default locale.
		/// </summary>
		/// <returns> the formated text message </returns>
		public override string Message
		{
			get
			{
				return getMessage(null, null);
			}
		}

		/// <summary>
		/// Gets a descriptive, localized error message suitable for presenting to the final user.
		/// </summary>
		/// <param name="locale"> optional locale </param>
		/// <param name="variables"> optional map of variables to replace in the message read from resource bundle </param>
		/// <returns> exception description </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected String getMessage(final Locale locale, final Map<String, String> variables)
		protected internal virtual string getMessage(Locale locale, IDictionary<string, string> variables)
		{
			ResourceBundle bundle;
			try
			{
				bundle = locale == null ? Bundle : getBundle(locale);
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final MissingResourceException ignored)
			catch (ssingResourceException)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String lan = locale != null ? locale.getLanguage() : "en";
				string lan = locale != null ? locale.Language : "en";
				return "Missing resource bundle. Please check that " + typeof(ProwideException).Name + "_" + lan + ".properties is present in the classpath";
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String key = this.getClass().getSimpleName();
			string key = this.GetType().Name;
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String msg = bundle.getString(key);
				string msg = bundle.getString(key);
				if (this.variables != null)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.commons.text.StringSubstitutor sub = new org.apache.commons.text.StringSubstitutor(this.variables);
					StringSubstitutor sub = new StringSubstitutor(this.variables);
					return sub.replace(msg);
				}
				else
				{
					return msg;
				}
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final MissingResourceException ignored)
			catch (ssingResourceException)
			{
				log.fine("No localized message found for exception key '" + key + "'");
				return base.Message;
			}

		}

		/// <summary>
		/// Initializes the variables Map if necessary and puts the parameter tuple. </summary>
		/// <param name="key"> variable key </param>
		/// <param name="value"> variable value </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void addVariable(final String key, final String value)
		protected internal virtual void addVariable(string key, string value)
		{
			if (this.variables == null)
			{
				this.variables = new Dictionary<>();
			}
			this.variables[key] = value;
		}

		/// <summary>
		/// Returns a variable value, if set, given its key </summary>
		/// <param name="key"> variable key name </param>
		/// <returns> found variable value or null if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected String getVariable(final String key)
		protected internal virtual string getVariable(string key)
		{
			if (this.variables != null)
			{
				return this.variables[key];
			}
			else
			{
				return null;
			}
		}
	}

}