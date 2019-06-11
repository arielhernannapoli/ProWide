using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
namespace com.prowidesoftware.deprecation
{


	using StringUtils = org.apache.commons.lang3.StringUtils;

	/// <summary>
	/// Helper API to implement the http://www.prowidesoftware.com/resources/deprecation-policy
	/// 
	/// @author sebastian
	/// @since 7.8.9
	/// </summary>
	public class DeprecationUtils
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(DeprecationUtils).FullName);

		/// <summary>
		/// Environment variable used to switch off deprecation phase implementation
		/// </summary>
		public const string PW_DEPRECATED = "PW_DEPRECATED";

		// Suppress default constructor for noninstantiability
		private DeprecationUtils()
		{
			throw new AssertionError();
		}

		/// <summary>
		/// According to the deprecation policy this method implements the phase 2 which 
		/// involves logging a warning and making a small pause in the execution thread. </summary>
		/// <param name="message"> the log message </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public static void phase2(final Class clazz, final String method, final String message)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static void phase2(Type clazz, string method, string message)
		{
			if (!isSet(EnvironmentVariableKey.NOLOG))
			{
				log.warning(notice(clazz, method) + message);
			}
			if (!isSet(EnvironmentVariableKey.NODELAY))
			{
				try
				{
					Thread.Sleep(4000);
				}
				catch (InterruptedException e)
				{
					Thread.CurrentThread.Interrupt();
					log.log(Level.WARNING, notice(clazz, method) + message, e);
				}
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") private static String notice(final Class clazz, final String method)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		private static string notice(Type clazz, string method)
		{
			StringBuilder note = new StringBuilder();
			note.Append("The API ").Append(clazz.Name);
			if (method != null)
			{
				note.Append("#").Append(method);
			}
			note.Append(" is deprecated. ");
			return note.ToString();
		}

		/// <summary>
		/// According to the deprecation policy this method implements the phase 3 which 
		/// involves throwing a runtime exception. </summary>
		/// <param name="message"> the log message </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public static void phase3(final Class clazz, final String method, final String message)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public static void phase3(Type clazz, string method, string message)
		{
			if (!isSet(EnvironmentVariableKey.NOEXCEPTION))
			{
				throw new System.NotSupportedException(notice(clazz, method) + message);
			}
			else
			{
				/*
				 * fall back to phase 2
				 */
				phase2(clazz, method, message);
			}
		}

		/// <summary>
		/// Returns true if the environment variable <seealso cref="#PW_DEPRECATED"/> contains
		/// the given key in its value
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static final boolean isSet(final EnvironmentVariableKey key)
		private static bool isSet(EnvironmentVariableKey key)
		{
			return StringUtils.containsIgnoreCase(System.getenv(PW_DEPRECATED), key.name());
		}

		/// <summary>
		/// Keywords for the environment variable <seealso cref="#PW_DEPRECATED"/>
		/// </summary>
		public enum EnvironmentVariableKey
		{
			NOLOG,
			NODELAY,
			NOEXCEPTION
		}

		/// <summary>
		/// Helper hack to set the environment variable from Java.
		/// 
		/// <para>For example if all keys are passed as parameter, this will set 
		/// the environment variable PW_DEPRECATED=nolog,nodelay,noexception
		///  
		/// </para>
		/// </summary>
		/// <param name="keys"> the variables to set in the environment variable </param>
		public static params EnvironmentVariableKey[] Env
		{
			set
			{
				if (value != null && value.Length > 0)
				{
					StringBuilder value = new StringBuilder();
					foreach (EnvironmentVariableKey key in value)
					{
						if (value.Length > 0)
						{
							value.Append(",");
						}
						value.Append(key.name().ToLower());
					}
					setEnv(PW_DEPRECATED, value.ToString());
				}
			}
		}

		/// <summary>
		/// Sets the environment variable PW_DEPRECATED to an empty string, meaning
		/// all flags corresponding to the deprecation phase will be active by default.
		/// </summary>
		public static void clearEnv()
		{
			setEnv(PW_DEPRECATED, "");
		}

		/// <summary>
		/// Helper hack to set environment variables from Java code
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings({ "unchecked", "rawtypes" }) private static void setEnv(final String key, final String value)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		private static void setEnv(string key, string value)
		{
			try
			{
				Type processEnvironmentClass = Type.GetType("java.lang.ProcessEnvironment");
				Field theEnvironmentField = processEnvironmentClass.getDeclaredField("theEnvironment");
				theEnvironmentField.Accessible = true;
				IDictionary<string, string> env = (IDictionary<string, string>) theEnvironmentField.get(null);
				env[key] = value;
				Field theCaseInsensitiveEnvironmentField = processEnvironmentClass.getDeclaredField("theCaseInsensitiveEnvironment");
				theCaseInsensitiveEnvironmentField.Accessible = true;
				IDictionary<string, string> cienv = (IDictionary<string, string>) theCaseInsensitiveEnvironmentField.get(null);
				cienv[key] = value;
			}
			catch (NoSuchFieldException)
			{
				try
				{
					Type[] classes = typeof(Collections).DeclaredClasses;
					IDictionary<string, string> env = System.getenv();
					foreach (Type cl in classes)
					{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
						if ("java.util.Collections$UnmodifiableMap".Equals(cl.FullName))
						{
							Field field = cl.getDeclaredField("m");
							field.Accessible = true;
							object obj = field.get(env);
							IDictionary<string, string> map = (IDictionary<string, string>) obj;
							map.Clear();
							map[key] = value;
						}
					}
				}
				catch (Exception e2)
				{
					Console.WriteLine(e2.ToString());
					Console.Write(e2.StackTrace);
				}
			}
			catch (Exception e1)
			{
				Console.WriteLine(e1.ToString());
				Console.Write(e1.StackTrace);
			}
		}

	}

}