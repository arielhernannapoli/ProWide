﻿namespace com.prowidesoftware.swift.model.mx.dic
{

	using com.prowidesoftware;
	using EqualsBuilder = org.apache.commons.lang3.builder.EqualsBuilder;
	using HashCodeBuilder = org.apache.commons.lang3.builder.HashCodeBuilder;
	using ToStringBuilder = org.apache.commons.lang3.builder.ToStringBuilder;
	using ToStringStyle = org.apache.commons.lang3.builder.ToStringStyle;


	/// <summary>
	/// Source code generated by prowidesoftware.com
	/// 
	/// 
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlAccessorType(XmlAccessType.FIELD) @XmlType(name = "BranchAndFinancialInstitutionIdentification5", propOrder = { "finInstnId", "brnchId" }) public class BranchAndFinancialInstitutionIdentification5 implements com.prowidesoftware.CopyableTo<BranchAndFinancialInstitutionIdentification5>
	public class BranchAndFinancialInstitutionIdentification5 : CopyableTo<BranchAndFinancialInstitutionIdentification5>
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "FinInstnId", required = true) protected FinancialInstitutionIdentification8 finInstnId;
		protected internal FinancialInstitutionIdentification8 finInstnId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "BrnchId") protected BranchData2 brnchId;
		protected internal BranchData2 brnchId;

		/// <summary>
		/// Gets the value of the finInstnId property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="FinancialInstitutionIdentification8 "/>
		///     
		/// </summary>
		public virtual FinancialInstitutionIdentification8 FinInstnId
		{
			get
			{
				return finInstnId;
			}
		}

		/// <summary>
		/// Sets the value of the finInstnId property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="FinancialInstitutionIdentification8 "/>
		///      </param>
		public virtual BranchAndFinancialInstitutionIdentification5 setFinInstnId(FinancialInstitutionIdentification8 value)
		{
			this.finInstnId = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the brnchId property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="BranchData2 "/>
		///     
		/// </summary>
		public virtual BranchData2 BrnchId
		{
			get
			{
				return brnchId;
			}
		}

		/// <summary>
		/// Sets the value of the brnchId property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="BranchData2 "/>
		///      </param>
		public virtual BranchAndFinancialInstitutionIdentification5 setBrnchId(BranchData2 value)
		{
			this.brnchId = value;
			return this;
		}

		public override string ToString()
		{
			return ToStringBuilder.reflectionToString(this, ToStringStyle.MULTI_LINE_STYLE);
		}

		public override bool Equals(object that)
		{
			return EqualsBuilder.reflectionEquals(this, that);
		}

		public override int GetHashCode()
		{
			return HashCodeBuilder.reflectionHashCode(this);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public final void copyTo(final BranchAndFinancialInstitutionIdentification5 target)
		public void copyTo(BranchAndFinancialInstitutionIdentification5 target)
		{
			FinancialInstitutionIdentification8 finInstnIdTarget = new FinancialInstitutionIdentification8();
			finInstnId.copyTo(finInstnIdTarget);
			target.finInstnId = finInstnIdTarget;
			BranchData2 brnchIdTarget = new BranchData2();
			brnchId.copyTo(brnchIdTarget);
			target.brnchId = brnchIdTarget;
		}

	}

}