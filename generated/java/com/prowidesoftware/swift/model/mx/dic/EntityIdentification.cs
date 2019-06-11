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
//ORIGINAL LINE: @XmlAccessorType(XmlAccessType.FIELD) @XmlType(name = "EntityIdentification", propOrder = { "type", "id" }) public class EntityIdentification implements com.prowidesoftware.CopyableTo<EntityIdentification>
	public class EntityIdentification : CopyableTo<EntityIdentification>
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "Type", required = true) protected String type;
		protected internal string type;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @XmlElement(name = "Id", required = true) protected String id;
		protected internal string id;

		/// <summary>
		/// Gets the value of the type property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string Type
		{
			get
			{
				return type;
			}
		}

		/// <summary>
		/// Sets the value of the type property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual EntityIdentification setType(string value)
		{
			this.type = value;
			return this;
		}

		/// <summary>
		/// Gets the value of the id property.
		/// 
		/// @return
		///     possible object is
		///     <seealso cref="String "/>
		///     
		/// </summary>
		public virtual string Id
		{
			get
			{
				return id;
			}
		}

		/// <summary>
		/// Sets the value of the id property.
		/// </summary>
		/// <param name="value">
		///     allowed object is
		///     <seealso cref="String "/>
		///      </param>
		public virtual EntityIdentification setId(string value)
		{
			this.id = value;
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
//ORIGINAL LINE: public final void copyTo(final EntityIdentification target)
		public void copyTo(EntityIdentification target)
		{
			target.type = type;
			target.id = id;
		}

	}

}