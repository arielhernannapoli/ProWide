﻿using System.Collections.Generic;

namespace com.prowidesoftware.swift.model.mx.dic
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
//ORIGINAL LINE: @XmlAccessorType(XmlAccessType.FIELD) @XmlType(name = "PostalAddress6", propOrder = { "adrTp", "dept", "subDept", "strtNm", "bldgNb", "pstCd", "twnNm", "ctrySubDvsn", "ctry", "adrLine" }) public class PostalAddress6 implements com.prowidesoftware.CopyableTo<PostalAddress6>
	public class PostalAddress6 : CopyableTo<PostalAddress6>
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "AdrTp") protected AddressType2Code adrTp;
		protected internal AddressType2Code adrTp;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "Dept") protected String dept;
		protected internal string dept;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "SubDept") protected String subDept;
		protected internal string subDept;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "StrtNm") protected String strtNm;
		protected internal string strtNm;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "BldgNb") protected String bldgNb;
		protected internal string bldgNb;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "PstCd") protected String pstCd;
		protected internal string pstCd;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "TwnNm") protected String twnNm;
		protected internal string twnNm;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "CtrySubDvsn") protected String ctrySubDvsn;
		protected internal string ctrySubDvsn;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "Ctry") protected String ctry;
		protected internal string ctry;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "AdrLine") protected java.util.List<String> adrLine;
		protected internal IList<string> adrLine;

		/// <summary>
		/// Gets the value of the adrTp property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="AddressType2Code "/>
		///     
		/// </summary>
		public virtual AddressType2Code AdrTp
		{
			get
			{
				return adrTp;
			}
		}

		/// <summary>
		/// Sets the value of the adrTp property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="AddressType2Code "/>
		///      </param>
		public virtual PostalAddress6 setAdrTp(AddressType2Code value)
		{
			this.adrTp = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the dept property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string Dept
		{
			get
			{
				return dept;
			}
		}

		/// <summary>
		/// Sets the value of the dept property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual PostalAddress6 setDept(string value)
		{
			this.dept = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the subDept property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string SubDept
		{
			get
			{
				return subDept;
			}
		}

		/// <summary>
		/// Sets the value of the subDept property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual PostalAddress6 setSubDept(string value)
		{
			this.subDept = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the strtNm property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string StrtNm
		{
			get
			{
				return strtNm;
			}
		}

		/// <summary>
		/// Sets the value of the strtNm property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual PostalAddress6 setStrtNm(string value)
		{
			this.strtNm = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the bldgNb property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string BldgNb
		{
			get
			{
				return bldgNb;
			}
		}

		/// <summary>
		/// Sets the value of the bldgNb property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual PostalAddress6 setBldgNb(string value)
		{
			this.bldgNb = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the pstCd property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string PstCd
		{
			get
			{
				return pstCd;
			}
		}

		/// <summary>
		/// Sets the value of the pstCd property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual PostalAddress6 setPstCd(string value)
		{
			this.pstCd = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the twnNm property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string TwnNm
		{
			get
			{
				return twnNm;
			}
		}

		/// <summary>
		/// Sets the value of the twnNm property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual PostalAddress6 setTwnNm(string value)
		{
			this.twnNm = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the ctrySubDvsn property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string CtrySubDvsn
		{
			get
			{
				return ctrySubDvsn;
			}
		}

		/// <summary>
		/// Sets the value of the ctrySubDvsn property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual PostalAddress6 setCtrySubDvsn(string value)
		{
			this.ctrySubDvsn = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the ctry property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string Ctry
		{
			get
			{
				return ctry;
			}
		}

		/// <summary>
		/// Sets the value of the ctry property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual PostalAddress6 setCtry(string value)
		{
			this.ctry = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the adrLine property.
		/// 
		/// <para>
		/// This accessor method returns a reference to the live list,
		/// not a snapshot. Therefore any modification you make to the
		/// returned list will be present inside the JAXB object.
		/// This is why there is not a <CODE>set</CODE> method for the adrLine property.
		/// 
		/// </para>
		/// <para>
		/// For example, to add a new item, do as follows:
		/// <pre>
		///    getAdrLine().add(newItem);
		/// </pre>
		/// 
		/// 
		/// </para>
		/// <para>
		/// Objects of the following type(s) are allowed in the list
		/// <seealso cref="String "/>
		/// 
		/// 
		/// </para>
		/// </summary>
		public virtual IList<string> AdrLine
		{
			get
			{
				if (adrLine == null)
				{
					adrLine = new List<string>();
				}
				return this.adrLine;
			}
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
//ORIGINAL LINE: public final void copyTo(final PostalAddress6 target)
		public void copyTo(PostalAddress6 target)
		{
			// debug: AddressType2Code does not implement copyTo
			target.adrTp = adrTp;
			target.dept = dept;
			target.subDept = subDept;
			target.strtNm = strtNm;
			target.bldgNb = bldgNb;
			target.pstCd = pstCd;
			target.twnNm = twnNm;
			target.ctrySubDvsn = ctrySubDvsn;
			target.ctry = ctry;
			// debug: List<String> does not implement copyTo
			target.adrLine = adrLine;
		}

		public virtual PostalAddress6 addAdrLine(string a)
		{
			AdrLine.Add(a);
			return this;
		}

	}

}