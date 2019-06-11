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

	/// <summary>
	/// Identifies a logical channel connection to SWIFT, and the network uses it
	/// for addressing. It is composed by the BIC code, an optional terminal
	/// identifier (A, B or C) if the institution has more than one terminal,
	/// and the branch (padded with "X" if no branch is used). 
	/// For example BFOOARBSAXXX or BFOOARBSXXX.<br>
	/// 
	/// A sender LT address cannot have 'X' as LT identifier, conversely a
	/// receiver LT address must have an 'X' as LT identifier.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.6
	/// </summary>
	public class LogicalTerminalAddress : BIC
	{
		private char? LTIdentifier_Renamed;

		/// <summary>
		/// Creates an LT address from its string value.
		/// <para>If the string contains a BIC8 or BIC11 the LT identifier will be set with a default value.
		/// 
		/// </para>
		/// </summary>
		/// <param name="code"> a full LT address code (12 characters) or a BIC8 or BIC11 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public LogicalTerminalAddress(final String code)
		public LogicalTerminalAddress(string code) : base(code)
		{
			if (code != null && code.Length >= 12)
			{
				this.LTIdentifier_Renamed = code[8];
			}
		}

		public virtual char? LTIdentifier
		{
			get
			{
				return LTIdentifier_Renamed;
			}
			set
			{
				LTIdentifier_Renamed = value;
			}
		}


		/// <summary>
		/// Returns a proper LT address for the sender of a message, assuring
		/// the returned code has 12 characters and with no "X" in the 9th position.
		/// 
		/// <para>If the terminal identifier is not set or if it is set to "X", then
		/// the default identifier "A" will be used.
		/// 
		/// </para>
		/// <para>The branch code is padded with "XXX" if not present.
		/// 
		/// </para>
		/// </summary>
		/// <returns> the 12 characters address or null if the BIC has less than 8 characters </returns>
		public virtual string SenderLogicalTerminalAddress
		{
			get
			{
				char? LT = (this.LTIdentifier_Renamed == null || this.LTIdentifier_Renamed.Equals('X'))? 'A' : this.LTIdentifier_Renamed;
				if (Bic8 != null)
				{
					return Bic8 + LT + BranchOrDefault;
				}
				return null;
			}
		}

		/// <summary>
		/// Returns a proper LT address for the receiver of a message, assuring
		/// the returned code has 12 characters and with a fixed "X" in the 9th position.
		/// 
		/// <para>The branch code is padded with "XXX" if not present.
		/// 
		/// </para>
		/// </summary>
		/// <returns> the 12 characters address or null if the BIC has less than 8 characters </returns>
		public virtual string ReceiverLogicalTerminalAddress
		{
			get
			{
				if (Bic8 != null)
				{
					return Bic8 + "X" + BranchOrDefault;
				}
				return null;
			}
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
			if (!base.Equals(o))
			{
				return false;
			}
			LogicalTerminalAddress that = (LogicalTerminalAddress) o;
			return Objects.Equals(LTIdentifier_Renamed, that.LTIdentifier_Renamed);
		}

		public override int GetHashCode()
		{
			return Objects.hash(base.GetHashCode(), LTIdentifier_Renamed);
		}
	}

}