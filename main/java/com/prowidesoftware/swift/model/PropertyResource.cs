using System;
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
namespace com.prowidesoftware.swift.model
{

	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using Validate = org.apache.commons.lang3.Validate;


	/// <summary>
	/// Common code for subclasses.
	/// </summary>
	/// @deprecated this class was meant to handle country and currency catalogs and it is no longer needed
	/// in favor of native Java implementations in Currency and Locale
	/// 
	/// @author www.prowidesoftware.com
	/// @since 3.3 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("this class was meant to handle country and currency catalogs and it is no longer needed") @ProwideDeprecated(phase3=TargetYear._2019) public abstract class PropertyResource
	[Obsolete("this class was meant to handle country and currency catalogs and it is no longer needed")]
	public abstract class PropertyResource
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		private static readonly Logger log = Logger.getLogger(typeof(PropertyResource).FullName);

		/// <summary>
		/// Property object to handle
		/// </summary>
		protected internal static readonly Properties prop = new Properties();

		/// <summary>
		/// Default constructor, loads the property file
		/// </summary>
		protected internal PropertyResource()
		{
			DeprecationUtils.phase2(this.GetType(), "constructor", "Implementation deprecated in favor of native Java implementations in Currency and Locale, use IsoUtils instead to validate currencies and countries");
			load();
		}


		private void load()
		{
			InputStream @is = Thread.CurrentThread.ContextClassLoader.getResourceAsStream(ResourceName);
			if (@is != null)
			{
				try
				{
					prop.load(@is);
				}
				catch (IOException e)
				{
					log.log(Level.SEVERE, "Exception loading resource", e);
				}
			}
		}

		/// <summary>
		/// Gets the resource name for the managed property </summary>
		/// <returns> String containing the resource name </returns>
		protected internal abstract string ResourceName {get;}


		/// <summary>
		/// Checks the parameter code in the managed prperty </summary>
		/// <param name="code"> key to look for in the properties </param>
		/// <returns> true if the property contains <code>code</code> as key </returns>
		public virtual bool isValidCode(string code)
		{
			Validate.notNull(code);
			return prop.containsKey(code.ToUpper());
		}

	}

}