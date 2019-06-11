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
namespace com.prowidesoftware.swift.model.mx
{

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;

	/// <summary>
	/// <b>This class will be deleted and will not be available in 2017.
	/// Business header may be used from AbstractMX</b> </summary>
	/// @deprecated  
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @ProwideDeprecated(phase4=TargetYear._2019) public class MxPayload
	[Obsolete]
	public class MxPayload
	{
		private BusinessHeader header;
		private IDocument document;

		public virtual BusinessHeader Header
		{
			get
			{
				return header;
			}
			set
			{
				this.header = value;
			}
		}


		public virtual IDocument Document
		{
			get
			{
				return document;
			}
			set
			{
				this.document = value;
			}
		}

	}

}