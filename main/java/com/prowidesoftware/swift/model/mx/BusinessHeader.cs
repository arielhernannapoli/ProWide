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



	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Document = org.w3c.dom.Document;
	using Element = org.w3c.dom.Element;

	using MxParser = com.prowidesoftware.swift.io.parser.MxParser;
	using ApplicationHeader = com.prowidesoftware.swift.model.mx.dic.ApplicationHeader;
	using BranchAndFinancialInstitutionIdentification5 = com.prowidesoftware.swift.model.mx.dic.BranchAndFinancialInstitutionIdentification5;
	using BusinessApplicationHeaderV01 = com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01;
	using FinancialInstitutionIdentification8 = com.prowidesoftware.swift.model.mx.dic.FinancialInstitutionIdentification8;
	using Party9Choice = com.prowidesoftware.swift.model.mx.dic.Party9Choice;

	/// <summary>
	/// General information applicable to any MX.
	/// 
	/// The business header is an optional part of the payload of a message,
	/// and contains information that is relevant to the business applications
	/// that process the message.
	/// 
	/// There are two different business standards, but a message can contain only one.
	/// <ul>
	/// <li>The ISO 20022 business application header: <seealso cref="BusinessApplicationHeaderV01"/></li>
	/// <li>The application header originally defined by swift: <seealso cref="ApplicationHeader"/></li>
	/// </ul>
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.7
	/// </summary>
	public class BusinessHeader
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly Logger log = Logger.getLogger(typeof(BusinessHeader).FullName);

		private ApplicationHeader applicationHeader;
		private BusinessApplicationHeaderV01 businessApplicationHeader;

		[NonSerialized]
		public const string NAMESPACE_AH = "urn:swift:xsd:$ahV10";
		[NonSerialized]
		public const string NAMESPACE_BAH = "urn:iso:std:iso:20022:tech:xsd:head.001.001.01";
		private const string APPHDR = "AppHdr";

		/// <summary>
		/// Creates an empty header
		/// </summary>
		public BusinessHeader() : base()
		{
		}

		/// <summary>
		/// Creates a business header from the SWIFT Application Header </summary>
		/// <param name="applicationHeader">
		/// @since 7.8 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public BusinessHeader(final com.prowidesoftware.swift.model.mx.dic.ApplicationHeader applicationHeader)
		public BusinessHeader(ApplicationHeader applicationHeader) : this()
		{
			this.applicationHeader = applicationHeader;
		}

		/// <summary>
		/// Creates a business header from the ISO Business Application Header </summary>
		/// <param name="businessApplicationHeader">
		/// @since 7.8 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public BusinessHeader(final com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01 businessApplicationHeader)
		public BusinessHeader(BusinessApplicationHeaderV01 businessApplicationHeader) : this()
		{
			this.businessApplicationHeader = businessApplicationHeader;
		}

		public virtual ApplicationHeader ApplicationHeader
		{
			get
			{
				return applicationHeader;
			}
			set
			{
				if (this.businessApplicationHeader != null)
				{
					throw new IllegalStateException("can't set applicationHeader when businessApplicationHeader is not null, set it to null before. These attributes overlap each other");
				}
				this.applicationHeader = value;
			}
		}


		public virtual BusinessApplicationHeaderV01 BusinessApplicationHeader
		{
			get
			{
				return businessApplicationHeader;
			}
			set
			{
				if (this.applicationHeader != null)
				{
					throw new IllegalStateException("can't set businessApplicationHeader when applicationHeader is not null, set it to null before. These attributes overlap each other");
				}
				this.businessApplicationHeader = value;
			}
		}


		/*
		 *  2015.08 miguel.
		 *  ver MX Headers/stdsmx_usgi.pdf
		 *  doc 3.2.3 Correspondence between the ISO Business Application Header and the Application Header
		 *  de ahi sintentizar los atributos aca.
		 *  FIXME replicar metodos unificados segun el mapeo de la seccion 3.2.3
		 */

		/// <summary>
		/// Gets the sender BIC code.
		/// <br>
		/// If the header is a BAH, tries to gets the BIC code from this elements in the following order:
		/// <ol>
		/// 	<li>BusinessApplicationHeaderV01/Fr/FIId/FinInstnId/BICFI</li>
		///  <li>BusinessApplicationHeaderV01/Fr/OrgId/Id/OrgId/Id/AnyBIC</li>
		/// </ol>
		/// <br>
		/// If the header is an AH, gets the same from ApplicationHeader/From/Type+Id where if Type
		/// is BIC the Id is returned as is, otherwise the domain name is parsed using <seealso cref="MxParser#getBICFromDN(String)"/>
		/// </summary>
		/// <returns> found BIC or null if not present or cannot be parsed </returns>
		public virtual string from()
		{
			if (this.applicationHeader == null)
			{
				if (this.businessApplicationHeader == null)
				{
					return null;
				}
				/*
				 * is BAH
				 */
				return getBIC(this.businessApplicationHeader.Fr);
			}
			else
			{
				/*
				 * is AH
				 */
				try
				{
					if (StringUtils.Equals(this.applicationHeader.From.Type, "BIC"))
					{
						return this.applicationHeader.From.Id;
					}
					else
					{
						return MxParser.getBICFromDN(this.applicationHeader.From.Id);
					}
				}
				catch (System.NullReferenceException)
				{
					return null;
				}
			}
		}


		/// <summary>
		/// Gets the receiver BIC code
		/// <br>
		/// If the header is a BAH, tries to gets the BIC code from this elements in the following order:
		/// <ol>
		/// 	<li>BusinessApplicationHeaderV01/To/FIId/FinInstnId/BICFI</li>
		///  <li>BusinessApplicationHeaderV01/To/OrgId/Id/OrgId/Id/AnyBIC</li>
		/// </ol>
		/// <br>
		/// If the header is an AH, gets the same from ApplicationHeader/To/Type+Id where if Type
		/// is BIC the Id is returned as is, otherwise the domain name is parsed using <seealso cref="MxParser#getBICFromDN(String)"/>
		/// </summary>
		/// <returns> found BIC or null if not present or cannot be parsed </returns>
		public virtual string to()
		{
			if (this.applicationHeader == null)
			{
				if (this.businessApplicationHeader == null)
				{
					return null;
				}
				/*
				 * is BAH
				 */
				return getBIC(this.businessApplicationHeader.To);
			}
			else
			{
				/*
				 * is AH
				 */
				try
				{
					if (StringUtils.Equals(this.applicationHeader.To.Type, "BIC"))
					{
						return this.applicationHeader.To.Id;
					}
					else
					{
						return MxParser.getBICFromDN(this.applicationHeader.To.Id);
					}
				}
				catch (System.NullReferenceException)
				{
					return null;
				}
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String getBIC(final com.prowidesoftware.swift.model.mx.dic.Party9Choice p)
		private string getBIC(Party9Choice p)
		{
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String found = p.getFIId().getFinInstnId().getBICFI();
				string found = p.FIId.FinInstnId.BICFI;
				if (!StringUtils.isEmpty(found))
				{
					return found;
				}
			}
			catch (System.NullReferenceException)
			{
				try
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String found = p.getOrgId().getId().getOrgId().getAnyBIC();
					string found = p.OrgId.Id.OrgId.AnyBIC;
					if (!StringUtils.isEmpty(found))
					{
						return found;
					}
				}
				catch (System.NullReferenceException)
				{
					return null;
				}
			}
			return null;
		}

		/// <summary>
		/// Get the message reference.
		/// </summary>
		/// <seealso cref= BusinessApplicationHeaderV01#getBizMsgIdr() </seealso>
		/// <seealso cref= ApplicationHeader#getMsgRef()
		/// 
		/// @since 7.8 </seealso>
		public virtual string reference()
		{
			if (this.applicationHeader == null)
			{
				if (this.businessApplicationHeader == null)
				{
					return null;
				}
				return this.businessApplicationHeader.BizMsgIdr;
			}
			return this.applicationHeader.MsgRef;
		}

		/// <summary>
		/// Get this header as an XML string.
		/// </summary>
		/// <returns> header serialized into XML string or null if neither header version is present
		/// @since 7.8 </returns>
		/// <seealso cref= #xml(String, boolean) </seealso>
		public virtual string xml()
		{
			return xml(null, false);
		}

		/// <summary>
		/// Get this header as an XML string.
		/// Since this class contains a dual model supporting two type of headers (swift and ISO), if both
		/// headers are present in the object the BusinessApplicationHeaderV01 will be used.
		/// </summary>
		/// <param name="prefix"> optional prefix for namespace (empty by default) </param>
		/// <param name="includeXMLDeclaration"> true to include the XML declaration (false by default) </param>
		/// <returns> header serialized into XML string or null if neither header version is present
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String xml(final String prefix, boolean includeXMLDeclaration)
		public virtual string xml(string prefix, bool includeXMLDeclaration)
		{
			object header;
			if (this.businessApplicationHeader != null)
			{
				header = this.businessApplicationHeader;
			}
			else if (this.applicationHeader != null)
			{
				header = this.applicationHeader;
			}
			else
			{
				return null;
			}
			try
			{
				JAXBContext context = JAXBContext.newInstance(header.GetType());
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.bind.Marshaller marshaller = context.createMarshaller();
				Marshaller marshaller = context.createMarshaller();
				marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.StringWriter sw = new java.io.StringWriter();
				StringWriter sw = new StringWriter();
				marshaller.marshal(_element(header), new XmlEventWriter(sw, prefix, includeXMLDeclaration, APPHDR));
				return sw.Buffer.ToString();

			}
			catch (JAXBException e)
			{
				log.log(Level.SEVERE, "Error writing XML:" + e + "\n for header: " + header);
			}
			return null;
		}

		/// <summary>
		/// Gets the header as an Element object.
		/// </summary>
		/// <returns> Element this header parsed into Element or null if header is null
		/// @since 7.8 </returns>
		public virtual Element element()
		{
			object header;
			if (this.businessApplicationHeader != null)
			{
				header = this.businessApplicationHeader;
			}
			else if (this.applicationHeader != null)
			{
				header = this.applicationHeader;
			}
			else
			{
				return null;
			}
			try
			{
				JAXBContext context = JAXBContext.newInstance(header.GetType());
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.bind.Marshaller marshaller = context.createMarshaller();
				Marshaller marshaller = context.createMarshaller();
				marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);

				DOMResult res = new DOMResult();
				marshaller.marshal(_element(header), res);
				Document doc = (Document) res.Node;
				return (Element) doc.FirstChild;

			}
			catch (JAXBException e)
			{
				log.log(Level.SEVERE, "Error writing XML:" + e + "\n for header: " + header);
			}
			return null;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings({ "unchecked", "rawtypes" }) private javax.xml.bind.JAXBElement _element(final Object header)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		private JAXBElement _element(object header)
		{
			if (header is BusinessApplicationHeaderV01)
			{
				return (JAXBElement<BusinessApplicationHeaderV01>) new JAXBElement(new QName(NAMESPACE_BAH, APPHDR), header.GetType(), null, header);
			}
			else if (header is ApplicationHeader)
			{
				return (JAXBElement<ApplicationHeader>) new JAXBElement(new QName(NAMESPACE_AH, APPHDR), header.GetType(), null, header);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Convenient method to create a new header, initialized from simple parameters.
		/// <br>
		/// The created header will be of type <seealso cref="BusinessApplicationHeaderV01"/>.
		/// Creation date will be set to current time.
		/// <br>
		/// All parameters are optional but in order for the header to be valid the
		/// sender, receiver and reference must be set.
		/// </summary>
		/// <param name="sender"> optional sender BIC for the Fr element or null to leave not set </param>
		/// <param name="receiver"> optional receiver BIC for the To element or null to leave not set </param>
		/// <param name="reference"> optional reference for the BizMsgIdr (business message identifier) or null to leave not set </param>
		/// <param name="id"> optional MX identification for the MsgDefIdr (message definition identifier) element or null to leave not set </param>
		/// <returns> new header initialized from parameters.
		/// @since 7.8.5 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static BusinessHeader create(final String sender, final String receiver, final String reference, final com.prowidesoftware.swift.model.MxId id)
		public static BusinessHeader create(string sender, string receiver, string reference, MxId id)
		{
			BusinessHeader h = new BusinessHeader();
			h.BusinessApplicationHeader = new BusinessApplicationHeaderV01();

			if (sender != null)
			{
				h.BusinessApplicationHeader.Fr = new Party9Choice();
				h.BusinessApplicationHeader.Fr.FIId = new BranchAndFinancialInstitutionIdentification5();
				h.BusinessApplicationHeader.Fr.FIId.FinInstnId = new FinancialInstitutionIdentification8();
				h.BusinessApplicationHeader.Fr.FIId.FinInstnId.BICFI = sender;
			}

			if (receiver != null)
			{
				h.BusinessApplicationHeader.To = new Party9Choice();
				h.BusinessApplicationHeader.To.FIId = new BranchAndFinancialInstitutionIdentification5();
				h.BusinessApplicationHeader.To.FIId.FinInstnId = new FinancialInstitutionIdentification8();
				h.BusinessApplicationHeader.To.FIId.FinInstnId.BICFI = receiver;
			}

			if (reference != null)
			{
				h.BusinessApplicationHeader.BizMsgIdr = reference;
			}

			if (id != null)
			{
				h.BusinessApplicationHeader.MsgDefIdr = id.id();
			}

			h.BusinessApplicationHeader.CreDt = now();

			return h;
		}

		/// <summary>
		/// Sets the creation date in the inner header object with current moment in UTC time zone.
		/// <br>
		/// Either of the inner headers must be not null. If both are null this method does nothing. </summary>
		/// <param name="overwrite"> if true, the creation date will always be set overwriting any previous value; if false it will be set only if it is not already set 
		/// @since 7.8.5 </param>
		public virtual bool CreationDate
		{
			set
			{
				if (this.businessApplicationHeader != null && (this.businessApplicationHeader.CreDt == null || value))
				{
					this.businessApplicationHeader.CreDt = now();
				}
				else if (this.applicationHeader != null && (this.applicationHeader.CrDate == null || value))
				{
					this.applicationHeader.CrDate = now();
				}
			}
		}

		/// <summary>
		/// Returns a gregorian calendar for current moment in UTC time zone </summary>
		/// <returns> created calendar or null if DatatypeFactory fails to create the calendar instance </returns>
		private static XMLGregorianCalendar now()
		{
			GregorianCalendar c = new GregorianCalendar();
			c.Time = DateTime.getInstance(TimeZone.getTimeZone("UTC")).Ticks;
			XMLGregorianCalendar creationDate = null;
			try
			{
				/*
				 * important: cannot create XMLGregorianCalendar directly from Calendar object, 
				 * specific format must be used for the unmarshalled XML to pass XSD validation.
				 */
				creationDate = DatatypeFactory.newInstance().newXMLGregorianCalendar((new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'")).format(c.Time));
			}
			catch (DatatypeConfigurationException e)
			{
				log.log(Level.WARNING, "error initializing header creation date", e);
			}
			return creationDate;
		}
	}

}