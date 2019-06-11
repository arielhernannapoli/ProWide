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

	using MTVariant = com.prowidesoftware.swift.model.mt.MTVariant;
	using StringUtils = org.apache.commons.lang3.StringUtils;

	/// <summary>
	/// Class for identification of MT messages.
	/// <br >
	/// Composed by the business process, message type and variant or message user group (MUG).
	/// <br>
	/// The business process is currently set to a fixed value "fin", however it is kept as
	/// class attribute because eventually could be used also for "apc".
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8.4
	/// </summary>
	public class MtId
	{
		private string businessProcess = "fin";
		private string messageType;
		private string variant;

		/// <summary>
		/// Creates an identification given the message type, with no variant. </summary>
		/// <param name="messageType"> the message type number (optionally prefixed with "fin.")
		/// @since 7.8.6 </param>
		public MtId(string messageType) : this(messageType, (string)null)
		{
		}

		/// <param name="messageType"> the message type number (optionally prefixed with "fin.") </param>
		/// <param name="variant"> An MT variant (STP, REMIT, COV), a MUG identifier or null if none applies </param>
		public MtId(string messageType, string variant) : base()
		{
			if (StringUtils.StartsWith(messageType, "fin."))
			{
				this.messageType = StringUtils.substringAfter(messageType, "fin.");
			}
			else
			{
				this.messageType = messageType;
			}
			this.variant = variant;
		}

		/// <param name="messageType"> the message type number </param>
		/// <param name="variant"> a message variant (STP, REMIT, COV) or null if none applies </param>
		public MtId(string messageType, MTVariant variant) : this(messageType, variant != null? variant.name() : null)
		{
		}

		public virtual string BusinessProcess
		{
			get
			{
				return businessProcess;
			}
			set
			{
				this.businessProcess = value;
			}
		}


		public virtual string MessageType
		{
			get
			{
				return messageType;
			}
			set
			{
				this.messageType = value;
			}
		}


		public virtual string Variant
		{
			get
			{
				return variant;
			}
			set
			{
				this.variant = value;
			}
		}


		public override string ToString()
		{
			return id();
		}

		/// <summary>
		/// Get a string in the form of businessprocess.messagetype.variant </summary>
		/// <returns> a string with the MT message type identification 
		/// @since 7.8.4 </returns>
		public virtual string id()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			if (businessProcess != null)
			{
				sb.Append(businessProcess);
			}
			else
			{
				return null;
			}
			if (messageType != null)
			{
				sb.Append("." + messageType);
			}
			else
			{
				return null;
			}
			if (variant != null)
			{
				sb.Append("." + variant);
			}
			return sb.ToString();
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
			MtId mtId = (MtId) o;
			return Objects.Equals(businessProcess, mtId.businessProcess) && Objects.Equals(messageType, mtId.messageType) && Objects.Equals(variant, mtId.variant);
		}

		public override int GetHashCode()
		{
			return Objects.hash(businessProcess, messageType, variant);
		}

		/// <summary>
		/// Returns the first number in the message type, representing the message category.
		/// For example for 103 returns 1 </summary>
		/// <returns> the message category number or empty if the message type is invalid or not present
		/// @since 7.10.4 </returns>
		public virtual string category()
		{
			if (messageType != null && messageType.Length > 0)
			{
				char cat = messageType[0];
				if (char.IsDigit(cat))
				{
					return Convert.ToString(cat);
				}
			}
			return "";
		}

	}

}