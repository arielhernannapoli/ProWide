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
//ORIGINAL LINE: @XmlAccessorType(XmlAccessType.FIELD) @XmlType(name = "ApplicationHeader", propOrder = { "from", "to", "svcName", "msgName", "msgRef", "crDate", "dup" }) public class ApplicationHeader implements com.prowidesoftware.CopyableTo<ApplicationHeader>
	public class ApplicationHeader : CopyableTo<ApplicationHeader>
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "From") protected EntityIdentification from;
		protected internal EntityIdentification from;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "To") protected EntityIdentification to;
		protected internal EntityIdentification to;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "SvcName") protected String svcName;
		protected internal string svcName;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "MsgName") protected String msgName;
		protected internal string msgName;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "MsgRef", required = true) protected String msgRef;
		protected internal string msgRef;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "CrDate", required = true) protected javax.xml.datatype.XMLGregorianCalendar crDate;
		protected internal XMLGregorianCalendar crDate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "Dup") protected DuplicateIndication dup;
		protected internal DuplicateIndication dup;

		/// <summary>
		/// Gets the value of the from property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="EntityIdentification "/>
		///     
		/// </summary>
		public virtual EntityIdentification From
		{
			get
			{
				return from;
			}
		}

		/// <summary>
		/// Sets the value of the from property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="EntityIdentification "/>
		///      </param>
		public virtual ApplicationHeader setFrom(EntityIdentification value)
		{
			this.from = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the to property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="EntityIdentification "/>
		///     
		/// </summary>
		public virtual EntityIdentification To
		{
			get
			{
				return to;
			}
		}

		/// <summary>
		/// Sets the value of the to property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="EntityIdentification "/>
		///      </param>
		public virtual ApplicationHeader setTo(EntityIdentification value)
		{
			this.to = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the svcName property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string SvcName
		{
			get
			{
				return svcName;
			}
		}

		/// <summary>
		/// Sets the value of the svcName property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual ApplicationHeader setSvcName(string value)
		{
			this.svcName = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the msgName property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string MsgName
		{
			get
			{
				return msgName;
			}
		}

		/// <summary>
		/// Sets the value of the msgName property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual ApplicationHeader setMsgName(string value)
		{
			this.msgName = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the msgRef property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string MsgRef
		{
			get
			{
				return msgRef;
			}
		}

		/// <summary>
		/// Sets the value of the msgRef property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual ApplicationHeader setMsgRef(string value)
		{
			this.msgRef = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the crDate property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="XMLGregorianCalendar "/>
		///     
		/// </summary>
		public virtual XMLGregorianCalendar CrDate
		{
			get
			{
				return crDate;
			}
		}

		/// <summary>
		/// Sets the value of the crDate property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="XMLGregorianCalendar "/>
		///      </param>
		public virtual ApplicationHeader setCrDate(XMLGregorianCalendar value)
		{
			this.crDate = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the dup property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="DuplicateIndication "/>
		///     
		/// </summary>
		public virtual DuplicateIndication Dup
		{
			get
			{
				return dup;
			}
		}

		/// <summary>
		/// Sets the value of the dup property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="DuplicateIndication "/>
		///      </param>
		public virtual ApplicationHeader setDup(DuplicateIndication value)
		{
			this.dup = value;
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
//ORIGINAL LINE: public final void copyTo(final ApplicationHeader target)
		public void copyTo(ApplicationHeader target)
		{
			EntityIdentification fromTarget = new EntityIdentification();
			from.copyTo(fromTarget);
			target.from = fromTarget;
			EntityIdentification toTarget = new EntityIdentification();
			to.copyTo(toTarget);
			target.to = toTarget;
			target.svcName = svcName;
			target.msgName = msgName;
			target.msgRef = msgRef;
			// debug: XMLGregorianCalendar does not implement copyTo
			target.crDate = crDate;
			DuplicateIndication dupTarget = new DuplicateIndication();
			dup.copyTo(dupTarget);
			target.dup = dupTarget;
		}

	}

}