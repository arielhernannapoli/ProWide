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
namespace com.prowidesoftware.swift.model
{


	/// <summary>
	/// This class models and parses the Message Output Reference (MOR).
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.4 </summary>
	/// <seealso cref= MIR </seealso>
	public class MOR : MIR
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(MOR.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MOR).FullName);

		public MOR(string date, string logicalTerminal, string sessionNumber, string sequenceNumber) : base(date, logicalTerminal, sessionNumber, sequenceNumber)
		{
		}

		public MOR(string value) : base(value)
		{
		}

		public MOR() : base()
		{
		}

		/// <seealso cref= #getMIR()  </seealso>
		public virtual string MOR
		{
			get
			{
				return MIR;
			}
		}
	}

}