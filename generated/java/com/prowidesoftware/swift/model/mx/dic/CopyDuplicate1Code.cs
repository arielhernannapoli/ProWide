using System.Collections.Generic;

namespace com.prowidesoftware.swift.model.mx.dic
{



	/// 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlType(name = "CopyDuplicate1Code") @XmlEnum public enum CopyDuplicate1Code
	public sealed class CopyDuplicate1Code
	{


		/// <summary>
		/// Message is being sent as a copy to a party other than the account owner, for information purposes and the message is a duplicate of a message previously sent.
		/// 
		/// </summary>
		CODU,
		public static readonly CopyDuplicate1Code CODU = new CopyDuplicate1Code("CODU", InnerEnum.CODU);

		/// <summary>
		/// Message is being sent as a copy to a party other than the account owner, for information purposes.
		/// 
		/// </summary>
		COPY,
		public static readonly CopyDuplicate1Code COPY = new CopyDuplicate1Code("COPY", InnerEnum.COPY);

		/// <summary>
		/// Message is for information/confirmation purposes. It is a duplicate of a message previously sent.
		/// 
		/// </summary>
		DUPL
		public static readonly CopyDuplicate1Code DUPL = new CopyDuplicate1Code("DUPL", InnerEnum.DUPL);

		private static readonly IList<CopyDuplicate1Code> valueList = new List<CopyDuplicate1Code>();

		static CopyDuplicate1Code()
		{
			valueList.Add(CODU);
			valueList.Add(COPY);
			valueList.Add(DUPL);
		}

		public enum InnerEnum
		{
			CODU,
			COPY,
			DUPL
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public String value()
		{
			return name();
		}

		public static CopyDuplicate1Code fromValue(string v)
		{
			return valueOf(v);
		}


		public static IList<CopyDuplicate1Code> values()
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

		public static CopyDuplicate1Code valueOf(string name)
		{
			foreach (CopyDuplicate1Code enumInstance in CopyDuplicate1Code.values())
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