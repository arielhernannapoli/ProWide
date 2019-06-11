using System.Collections.Generic;

namespace com.prowidesoftware.swift.model.mx.dic
{



	/// 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlType(name = "NamePrefix1Code") @XmlEnum public enum NamePrefix1Code
	public sealed class NamePrefix1Code
	{


		/// <summary>
		/// Title of the person is Doctor or Dr.
		/// 
		/// </summary>
		DOCT,
		public static readonly NamePrefix1Code DOCT = new NamePrefix1Code("DOCT", InnerEnum.DOCT);

		/// <summary>
		/// Title of the person is Mister or Mr.
		/// 
		/// </summary>
		MIST,
		public static readonly NamePrefix1Code MIST = new NamePrefix1Code("MIST", InnerEnum.MIST);

		/// <summary>
		/// Title of the person is Miss.
		/// 
		/// </summary>
		MISS,
		public static readonly NamePrefix1Code MISS = new NamePrefix1Code("MISS", InnerEnum.MISS);

		/// <summary>
		/// Title of the person is Madam.
		/// 
		/// </summary>
		MADM
		public static readonly NamePrefix1Code MADM = new NamePrefix1Code("MADM", InnerEnum.MADM);

		private static readonly IList<NamePrefix1Code> valueList = new List<NamePrefix1Code>();

		static NamePrefix1Code()
		{
			valueList.Add(DOCT);
			valueList.Add(MIST);
			valueList.Add(MISS);
			valueList.Add(MADM);
		}

		public enum InnerEnum
		{
			DOCT,
			MIST,
			MISS,
			MADM
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public String value()
		{
			return name();
		}

		public static NamePrefix1Code fromValue(string v)
		{
			return valueOf(v);
		}


		public static IList<NamePrefix1Code> values()
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

		public static NamePrefix1Code valueOf(string name)
		{
			foreach (NamePrefix1Code enumInstance in NamePrefix1Code.values())
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