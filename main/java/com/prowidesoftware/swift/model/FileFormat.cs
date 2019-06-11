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
namespace com.prowidesoftware.swift.model
{

	/// <summary>
	/// Supported file formats in the <seealso cref="AbstractSwiftMessage"/> hierarchy.
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8.4
	/// </summary>
	/*
	 * sebastian aug 2016: annotate subclasses?
	 */
	public sealed class FileFormat
	{
		/// <summary>
		/// SWIFT FIN message format
		/// </summary>
		public static readonly FileFormat FIN = new FileFormat("FIN", InnerEnum.FIN, "fin");
		/// <summary>
		/// Prowide CORE XML format
		/// </summary>
		public static readonly FileFormat CORE_XML = new FileFormat("CORE_XML", InnerEnum.CORE_XML, "xml");
		/// <summary>
		/// MQ-MT format
		/// </summary>
		public static readonly FileFormat MQ_MT = new FileFormat("MQ_MT", InnerEnum.MQ_MT, "mt");
		/// <summary>
		/// Only valid for MT.
		/// Remote Job Entry
		/// </summary>
		public static readonly FileFormat RJE = new FileFormat("RJE", InnerEnum.RJE, "rje");
		/// <summary>
		/// MX format 
		/// </summary>
		public static readonly FileFormat MX = new FileFormat("MX", InnerEnum.MX, "xml");
		/// <summary>
		/// Applies to both MT and MX
		/// </summary>
		public static readonly FileFormat XML_V2 = new FileFormat("XML_V2", InnerEnum.XML_V2, "xml");

		private static readonly IList<FileFormat> valueList = new List<FileFormat>();

		static FileFormat()
		{
			valueList.Add(FIN);
			valueList.Add(CORE_XML);
			valueList.Add(MQ_MT);
			valueList.Add(RJE);
			valueList.Add(MX);
			valueList.Add(XML_V2);
		}

		public enum InnerEnum
		{
			FIN,
			CORE_XML,
			MQ_MT,
			RJE,
			MX,
			XML_V2
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		private string extension = null;

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: FileFormat(final String extension)
		internal FileFormat(string name, InnerEnum innerEnum, string extension)
		{
			this.extension = extension;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public String extension()
		{
			return this.extension;
		}

		public String label()
		{
			return "file-format." + name();
		}

		public static IList<FileFormat> values()
		{
			return valueList;
		}

		public InnerEnum InnerEnumValue()
		{
			return innerEnumValue;
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static FileFormat valueOf(string name)
		{
			foreach (FileFormat enumInstance in FileFormat.values())
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}

}