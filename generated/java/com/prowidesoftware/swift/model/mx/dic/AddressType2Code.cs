using System.Collections.Generic;

namespace com.prowidesoftware.swift.model.mx.dic
{



	/// 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlType(name = "AddressType2Code") @XmlEnum public enum AddressType2Code
	public sealed class AddressType2Code
	{


		/// <summary>
		/// Address is the complete postal address.
		/// 
		/// </summary>
		ADDR,
		public static readonly AddressType2Code ADDR = new AddressType2Code("ADDR", InnerEnum.ADDR);

		/// <summary>
		/// Address is a postal office (PO) box.
		/// 
		/// </summary>
		PBOX,
		public static readonly AddressType2Code PBOX = new AddressType2Code("PBOX", InnerEnum.PBOX);

		/// <summary>
		/// Address is the home address.
		/// 
		/// </summary>
		HOME,
		public static readonly AddressType2Code HOME = new AddressType2Code("HOME", InnerEnum.HOME);

		/// <summary>
		/// Address is the business address.
		/// 
		/// </summary>
		BIZZ,
		public static readonly AddressType2Code BIZZ = new AddressType2Code("BIZZ", InnerEnum.BIZZ);

		/// <summary>
		/// Address is the address to which mail is sent.
		/// 
		/// </summary>
		MLTO,
		public static readonly AddressType2Code MLTO = new AddressType2Code("MLTO", InnerEnum.MLTO);

		/// <summary>
		/// Address is the address to which delivery is to take place.
		/// 
		/// </summary>
		DLVY
		public static readonly AddressType2Code DLVY = new AddressType2Code("DLVY", InnerEnum.DLVY);

		private static readonly IList<AddressType2Code> valueList = new List<AddressType2Code>();

		static AddressType2Code()
		{
			valueList.Add(ADDR);
			valueList.Add(PBOX);
			valueList.Add(HOME);
			valueList.Add(BIZZ);
			valueList.Add(MLTO);
			valueList.Add(DLVY);
		}

		public enum InnerEnum
		{
			ADDR,
			PBOX,
			HOME,
			BIZZ,
			MLTO,
			DLVY
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		public String value()
		{
			return name();
		}

		public static AddressType2Code fromValue(string v)
		{
			return valueOf(v);
		}


		public static IList<AddressType2Code> values()
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

		public static AddressType2Code valueOf(string name)
		{
			foreach (AddressType2Code enumInstance in AddressType2Code.values())
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