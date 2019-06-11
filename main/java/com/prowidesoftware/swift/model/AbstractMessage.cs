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

	/// <summary>
	/// Base class for hierarchy of specific MT and MX classes. 
	/// 
	/// @author sebastian
	/// 
	/// </summary>
	public class AbstractMessage
	{

		internal MessageStandardType type = null;

		/*
		 * necessary for jaxb in MX
		 */
		protected internal AbstractMessage() : base()
		{
		}

		protected internal AbstractMessage(MessageStandardType type) : base()
		{
			this.type = type;
		}

		/// <summary>
		/// True if the message is an MT, false otherwise
		/// </summary>
		public virtual bool MT
		{
			get
			{
				return this.type == MessageStandardType.MT;
			}
		}

		/// <summary>
		/// True if the message is an MX, false otherwise
		/// </summary>
		public virtual bool MX
		{
			get
			{
				return this.type == MessageStandardType.MX;
			}
		}

		/// <summary>
		/// Returns the standard enumeration value corresponding to this message
		/// </summary>
		public virtual MessageStandardType MessageStandardType
		{
			get
			{
				return this.type;
			}
		}
	}

}