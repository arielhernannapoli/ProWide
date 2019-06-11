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
//ORIGINAL LINE: @XmlAccessorType(XmlAccessType.FIELD) @XmlType(name = "ClearingSystemMemberIdentification2", propOrder = { "clrSysId", "mmbId" }) public class ClearingSystemMemberIdentification2 implements com.prowidesoftware.CopyableTo<ClearingSystemMemberIdentification2>
	public class ClearingSystemMemberIdentification2 : CopyableTo<ClearingSystemMemberIdentification2>
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "ClrSysId") protected ClearingSystemIdentification2Choice clrSysId;
		protected internal ClearingSystemIdentification2Choice clrSysId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "MmbId", required = true) protected String mmbId;
		protected internal string mmbId;

		/// <summary>
		/// Gets the value of the clrSysId property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="ClearingSystemIdentification2Choice "/>
		///     
		/// </summary>
		public virtual ClearingSystemIdentification2Choice ClrSysId
		{
			get
			{
				return clrSysId;
			}
		}

		/// <summary>
		/// Sets the value of the clrSysId property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="ClearingSystemIdentification2Choice "/>
		///      </param>
		public virtual ClearingSystemMemberIdentification2 setClrSysId(ClearingSystemIdentification2Choice value)
		{
			this.clrSysId = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the mmbId property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string MmbId
		{
			get
			{
				return mmbId;
			}
		}

		/// <summary>
		/// Sets the value of the mmbId property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual ClearingSystemMemberIdentification2 setMmbId(string value)
		{
			this.mmbId = value;
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
//ORIGINAL LINE: public final void copyTo(final ClearingSystemMemberIdentification2 target)
		public void copyTo(ClearingSystemMemberIdentification2 target)
		{
			ClearingSystemIdentification2Choice clrSysIdTarget = new ClearingSystemIdentification2Choice();
			clrSysId.copyTo(clrSysIdTarget);
			target.clrSysId = clrSysIdTarget;
			target.mmbId = mmbId;
		}

	}

}