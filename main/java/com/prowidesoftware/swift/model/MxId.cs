using System;
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


	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;

	/// <summary>
	/// Class for identification of MX messages.<br >
	/// Composed by the business process (business area), functionality (message type), variant and version.
	/// 
	/// @author miguel
	/// @since 7.7
	/// </summary>
	public class MxId
	{
		private MxBusinessProcess businessProcess;
		private string functionality;
		private string variant;
		private string version;
		private static readonly Pattern pattern = Pattern.compile(".*([a-zA-Z]{4}).(\\d{3}).(\\d{3}).(\\d{2}).*");

		public MxId()
		{
			this.businessProcess = null;
			this.functionality = StringUtils.EMPTY;
			this.variant = StringUtils.EMPTY;
			this.version = StringUtils.EMPTY;
		}
		/// <summary>
		/// Creates a new object getting data from an MX message namespace.
		/// <para>The implementation parses the namespace using a regex to detect the message type part.
		/// 
		/// </para>
		/// </summary>
		/// <param name="namespace"> a complete or partial namespace such as "urn:iso:std:iso:20022:tech:xsd:pain.001.001.03" or just "pain.001.001.03" </param>
		/// <exception cref="IllegalArgumentException"> if namespace parameter cannot be parsed as MX identification </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxId(final String namespace)
		public MxId(string @namespace)
		{
			Validate.notNull(@namespace);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.regex.Matcher matcher = pattern.matcher(namespace);
			Matcher matcher = pattern.matcher(@namespace);
			if (matcher.matches())
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String bpStr = matcher.group(1);
				string bpStr = matcher.group(1);
				try
				{
					this.businessProcess = MxBusinessProcess.valueOf(bpStr);
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
					throw new System.ArgumentException("Illegal value for business process: '" + bpStr + "' see enum values in " + typeof(MxBusinessProcess).FullName + " for valid options", e);
				}
				this.functionality = matcher.group(2);
				this.variant = matcher.group(3);
				this.version = matcher.group(4);
			}
			else
			{
				throw new System.ArgumentException("Could not parse namespace '" + @namespace + "'");
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxId(final MxBusinessProcess businessProcess, final String funString, final String varString, final String verString)
		public MxId(MxBusinessProcess businessProcess, string funString, string varString, string verString)
		{
			this.businessProcess = businessProcess;
			this.functionality = funString;
			this.variant = varString;
			this.version = verString;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxId(final String bpString, final String funString, final String varString, final String verString)
		public MxId(string bpString, string funString, string varString, string verString) : this(MxBusinessProcess.valueOf(bpString), funString, varString, verString)
		{
		}

		/// <summary>
		/// Gets the business process (a.k.a. business area) </summary>
		/// <returns> the business process set </returns>
		public virtual MxBusinessProcess BusinessProcess
		{
			get
			{
				return businessProcess;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxId setBusinessProcess(final MxBusinessProcess businessProcess)
		public virtual MxId setBusinessProcess(MxBusinessProcess businessProcess)
		{
			this.businessProcess = businessProcess;
			return this;
		}

		/// <summary>
		/// Gets the functionality (a.k.a. message type) </summary>
		/// <returns> the functionality set </returns>
		public virtual string Functionality
		{
			get
			{
				return functionality;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxId setFunctionality(final String functionality)
		public virtual MxId setFunctionality(string functionality)
		{
			this.functionality = functionality;
			return this;
		}

		public virtual string Variant
		{
			get
			{
				return variant;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxId setVariant(final String variant)
		public virtual MxId setVariant(string variant)
		{
			this.variant = variant;
			return this;
		}

		public virtual string Version
		{
			get
			{
				return version;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxId setVersion(final String version)
		public virtual MxId setVersion(string version)
		{
			this.version = version;
			return this;
		}

		public virtual string camelized()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			if (businessProcess != null)
			{
				sb.Append(char.ToUpper(businessProcess.name().charAt(0)));
				sb.Append(businessProcess.name().Substring(1));
			}
			if (functionality != null)
			{
				sb.Append(functionality);
			}
			if (variant != null)
			{
				sb.Append(variant);
			}
			if (version != null)
			{
				sb.Append(version);
			}

			return sb.ToString();
		}

		public virtual int VersionInt
		{
			get
			{
				return Convert.ToInt32(Version);
			}
		}
		public virtual int VariantInt
		{
			get
			{
				return Convert.ToInt32(Variant);
			}
		}
		public virtual int FunctionalityInt
		{
			get
			{
				return Convert.ToInt32(Functionality);
			}
		}

		/// <summary>
		/// Creates a namespace URI for this MX, for example: urn:swift:xsd:camt.003.001.04
		/// All id attributes should be properly filled.
		/// </summary>
		/// <returns> a string representing the namespace URI for the MX or null if any of the attributes is not set </returns>
		public virtual string namespaceURI()
		{
			return (new StringBuilder("urn:swift:xsd:")).Append(id()).ToString();
		}

		/// <summary>
		/// Get a string in the form of businessprocess.functionality.variant.version </summary>
		/// <returns> a string with the MX message type identification or null if any of the properties is null
		/// @since 7.7 </returns>
		public virtual string id()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			if (businessProcess != null)
			{
				sb.Append(businessProcess.name());
			}
			else
			{
				return null;
			}
			if (functionality != null)
			{
				sb.Append("." + functionality);
			}
			else
			{
				return null;
			}
			if (variant != null)
			{
				sb.Append("." + variant);
			}
			else
			{
				return null;
			}
			if (version != null)
			{
				sb.Append("." + version);
			}
			else
			{
				return null;
			}
			return sb.ToString();
		}

		public override string ToString()
		{
			return id();
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}
			MxId mxId = (MxId) o;
			return businessProcess == mxId.businessProcess && Objects.Equals(functionality, mxId.functionality) && Objects.Equals(variant, mxId.variant) && Objects.Equals(version, mxId.version);
		}

		public override int GetHashCode()
		{
			return Objects.hash(businessProcess, functionality, variant, version);
		}

		/// <summary>
		/// Check if this identification matches the given namespace.
		/// 
		/// <para>This is particularly useful if this identifier is not completely filled, for example: if the business process
		/// is set to "pain" and the functionality is set to "002" but the variant and version are left null, then this
		/// identifier will match any namespace containing pain.002.*.* where the wildcard could be any number.
		/// <br>new MxId("pain", "002", null, null).matches("pain.002.001.03") will be true.
		/// 
		/// </para>
		/// </summary>
		/// <param name="namespace"> a complete or partial namespace such as "urn:iso:std:iso:20022:tech:xsd:pain.001.001.03" or just "pain.001.001.03" </param>
		/// <returns> true if this id matches the parameter </returns>
		/// <exception cref="IllegalArgumentException"> if namespace parameter cannot be parsed as MX identification
		/// @since 7.10.7 </exception>
		public virtual bool matches(string @namespace)
		{
			return matches(new MxId(@namespace));
		}

		/// <summary>
		/// Check if this identification matches another one.
		/// 
		/// <para>This is particularly useful if this identifier is not completely filled, for example: if the business process
		/// is set to "pain" and the functionality is set to "002" but the variant and version are left null, then this
		/// identifier will match for example both pain.002.001.03 and pain.002.002.04.
		/// 
		/// </para>
		/// <para>The difference between this implementation and <seealso cref="#equals(Object)"/> is that here null and empty properties
		/// are treated as equals. Meaning it is not sensible to null versus blank properties, thus pain.001.001.null will
		/// match pain.001.001.empty. </para>
		/// </summary>
		/// <param name="other"> an identification to compare </param>
		/// <returns> true if this id matches the parameter </returns>
		/// <exception cref="IllegalArgumentException"> if namespace parameter cannot be parsed as MX identification
		/// @since 7.10.7 </exception>
		public virtual bool matches(MxId other)
		{
			return this.businessProcess == other.BusinessProcess && (StringUtils.isBlank(this.functionality) || StringUtils.isBlank(other.Functionality) || StringUtils.Equals(this.functionality, other.Functionality)) && (StringUtils.isBlank(this.variant) || StringUtils.isBlank(other.Variant) || StringUtils.Equals(this.variant, other.Variant)) && (StringUtils.isBlank(this.version) || StringUtils.isBlank(other.Version) || StringUtils.Equals(this.version, other.Version));
		}

	}

}