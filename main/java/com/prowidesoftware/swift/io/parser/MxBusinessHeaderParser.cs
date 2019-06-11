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
namespace com.prowidesoftware.swift.io.parser
{

	using MxNode = com.prowidesoftware.swift.model.MxNode;
	using AddressType2Code = com.prowidesoftware.swift.model.mx.dic.AddressType2Code;
	using ApplicationHeader = com.prowidesoftware.swift.model.mx.dic.ApplicationHeader;
	using BranchAndFinancialInstitutionIdentification5 = com.prowidesoftware.swift.model.mx.dic.BranchAndFinancialInstitutionIdentification5;
	using BranchData2 = com.prowidesoftware.swift.model.mx.dic.BranchData2;
	using BusinessApplicationHeader1 = com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeader1;
	using BusinessApplicationHeaderV01 = com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01;
	using ClearingSystemIdentification2Choice = com.prowidesoftware.swift.model.mx.dic.ClearingSystemIdentification2Choice;
	using ClearingSystemMemberIdentification2 = com.prowidesoftware.swift.model.mx.dic.ClearingSystemMemberIdentification2;
	using ContactDetails2 = com.prowidesoftware.swift.model.mx.dic.ContactDetails2;
	using CopyDuplicate1Code = com.prowidesoftware.swift.model.mx.dic.CopyDuplicate1Code;
	using DateAndPlaceOfBirth = com.prowidesoftware.swift.model.mx.dic.DateAndPlaceOfBirth;
	using DuplicateIndication = com.prowidesoftware.swift.model.mx.dic.DuplicateIndication;
	using EntityIdentification = com.prowidesoftware.swift.model.mx.dic.EntityIdentification;
	using FinancialIdentificationSchemeName1Choice = com.prowidesoftware.swift.model.mx.dic.FinancialIdentificationSchemeName1Choice;
	using FinancialInstitutionIdentification8 = com.prowidesoftware.swift.model.mx.dic.FinancialInstitutionIdentification8;
	using GenericFinancialIdentification1 = com.prowidesoftware.swift.model.mx.dic.GenericFinancialIdentification1;
	using NamePrefix1Code = com.prowidesoftware.swift.model.mx.dic.NamePrefix1Code;
	using OrganisationIdentification7 = com.prowidesoftware.swift.model.mx.dic.OrganisationIdentification7;
	using Party10Choice = com.prowidesoftware.swift.model.mx.dic.Party10Choice;
	using Party9Choice = com.prowidesoftware.swift.model.mx.dic.Party9Choice;
	using PartyIdentification42 = com.prowidesoftware.swift.model.mx.dic.PartyIdentification42;
	using PersonIdentification5 = com.prowidesoftware.swift.model.mx.dic.PersonIdentification5;
	using PostalAddress6 = com.prowidesoftware.swift.model.mx.dic.PostalAddress6;
	using SignatureEnvelope = com.prowidesoftware.swift.model.mx.dic.SignatureEnvelope;

	/// <summary>
	/// Non-public helper class used by <seealso cref="MxParser"/> to parse the business header
	/// in its two variants, using MxNode. 
	/// 
	/// @author sebastian@prowidesoftware.com
	/// @since 7.8.4
	/// </summary>
	internal class MxBusinessHeaderParser
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly Logger log = Logger.getLogger(typeof(MxBusinessHeaderParser).FullName);

		/// <summary>
		/// Parses the application header from the parameter node. </summary>
		/// <returns> parsed header or null if the content cannot be parsed or the header is not present in the xml </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static com.prowidesoftware.swift.model.mx.dic.ApplicationHeader parseApplicationHeader(final com.prowidesoftware.swift.model.MxNode tree)
		internal static ApplicationHeader parseApplicationHeader(MxNode tree)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long t0 = System.currentTimeMillis();
			long t0 = DateTimeHelperClass.CurrentUnixTimeMillis();
			try
			{
				if (tree != null)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode header = tree.findFirstByName(MxParser.HEADER_LOCALNAME);
					MxNode header = tree.findFirstByName(MxParser.HEADER_LOCALNAME);
					if (header == null)
					{
						log.warning(MxParser.HEADER_LOCALNAME + " element not found");
					}
					else
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mx.dic.ApplicationHeader result = new com.prowidesoftware.swift.model.mx.dic.ApplicationHeader();
						ApplicationHeader result = new ApplicationHeader();

						/*
						 * From
						 */
						MxNode From = header.findFirst("./From");
						if (From != null)
						{
							result.From = new EntityIdentification();
							MxNode Type = From.findFirst("./Type");
							if (Type != null)
							{
								result.From.Type = Type.Value;
							}
							MxNode Id = From.findFirst("./Id");
							if (Id != null)
							{
								result.From.Id = Id.Value;
							}
						}

						/*
						 * To
						 */
						MxNode To = header.findFirst("./To");
						if (To != null)
						{
							result.To = new EntityIdentification();
							MxNode Type = To.findFirst("./Type");
							if (Type != null)
							{
								result.To.Type = Type.Value;
							}
							MxNode Id = To.findFirst("./Id");
							if (Id != null)
							{
								result.To.Id = Id.Value;
							}
						}

						/*
						 * Service name
						 */
						MxNode SvcName = header.findFirst("./SvcName");
						if (SvcName != null)
						{
							result.SvcName = SvcName.Value;
						}

						/*
						 * Message name
						 */
						MxNode MsgName = header.findFirst("./MsgName");
						if (MsgName != null)
						{
							result.MsgName = MsgName.Value;
						}

						/*
						 * Message reference
						 */
						MxNode MsgRef = header.findFirst("./MsgRef");
						if (MsgRef != null)
						{
							result.MsgRef = MsgRef.Value;
						}

						/*
						 * Date
						 */
						MxNode CrDate = header.findFirst("./CrDate");
						if (CrDate != null)
						{
							try
							{
								result.CrDate = javax.xml.datatype.DatatypeFactory.newInstance().newXMLGregorianCalendar(CrDate.Value);
							}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final javax.xml.datatype.DatatypeConfigurationException e)
							catch (javax.xml.datatype.DatatypeConfigurationException e)
							{
								log.warning("exception " + e + " parsign header crDate [" + CrDate.Value + "]");
							}
						}

						/*
						 * Duplicate information
						 */
						MxNode Dup = header.findFirst("./Dup");
						if (Dup != null)
						{
							result.Dup = new DuplicateIndication();
							MxNode Ref = Dup.findFirst("./Ref");
							if (Ref != null)
							{
								result.Dup.Ref = Ref.Value;
							}
							MxNode Info = Dup.findFirst("./Info");
							if (Info != null)
							{
								result.Dup.Info = Info.Value;
							}
						}

						return result;
					}
				}
			}
			finally
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long t1 = System.currentTimeMillis();
				long t1 = DateTimeHelperClass.CurrentUnixTimeMillis();
				log.fine("parseApplicationHeader_sax: " + (t1 - t0) + "ms");
			}
			return null;
		}

		/// <summary>
		/// Parses the application header from the parameter node. </summary>
		/// <returns> parsed header or null if the content cannot be parsed or the header is not present in the xml </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: static com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01 parseBusinessApplicationHeaderV01(final com.prowidesoftware.swift.model.MxNode tree)
		internal static BusinessApplicationHeaderV01 parseBusinessApplicationHeaderV01(MxNode tree)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long t0 = System.currentTimeMillis();
			long t0 = DateTimeHelperClass.CurrentUnixTimeMillis();
			if (tree != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.MxNode header = tree.findFirstByName(MxParser.HEADER_LOCALNAME);
				MxNode header = tree.findFirstByName(MxParser.HEADER_LOCALNAME);
				if (header == null)
				{
					log.warning(MxParser.HEADER_LOCALNAME + " element not found");
				}
				else
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01 result = new com.prowidesoftware.swift.model.mx.dic.BusinessApplicationHeaderV01();
					BusinessApplicationHeaderV01 result = new BusinessApplicationHeaderV01();

					MxNode CharSet = header.findFirst("./CharSet");
					if (CharSet != null)
					{
						result.CharSet = CharSet.Value;
					}

					MxNode Fr = header.findFirst("./Fr");
					if (Fr != null)
					{
						result.Fr = new Party9Choice();
						parse(Fr, result.Fr);
					}

					MxNode To = header.findFirst("./To");
					if (To != null)
					{
						result.To = new Party9Choice();
						parse(To, result.To);
					}

					MxNode BizMsgIdr = header.findFirst("./BizMsgIdr");
					if (BizMsgIdr != null)
					{
						result.BizMsgIdr = BizMsgIdr.Value;
					}

					MxNode MsgDefIdr = header.findFirst("./MsgDefIdr");
					if (MsgDefIdr != null)
					{
						result.MsgDefIdr = MsgDefIdr.Value;
					}

					MxNode BizSvc = header.findFirst("./BizSvc");
					if (BizSvc != null)
					{
						result.BizSvc = BizSvc.Value;
					}

					MxNode CreDt = header.findFirst("./CreDt");
					if (CreDt != null)
					{
						try
						{
							result.CreDt = javax.xml.datatype.DatatypeFactory.newInstance().newXMLGregorianCalendar(CreDt.Value);
						}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final javax.xml.datatype.DatatypeConfigurationException e)
						catch (javax.xml.datatype.DatatypeConfigurationException e)
						{
							log.warning("exception " + e + " parsing header crDate [" + CreDt.Value + "]");
						}
					}

					MxNode CpyDplct = header.findFirst("./CpyDplct");
					if (CpyDplct != null)
					{
						try
						{
							result.CpyDplct = CopyDuplicate1Code.valueOf(CpyDplct.Value);
						}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
						catch (Exception e)
						{
							log.warning("exception " + e + " parsing header CpyDplct [" + CpyDplct.Value + "]");
						}
					}

					MxNode PssblDplct = header.findFirst("./PssblDplct");
					if (PssblDplct != null)
					{
						try
						{
							result.PssblDplct = Convert.ToBoolean(PssblDplct.Value);
						}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
						catch (Exception e)
						{
							log.warning("exception " + e + " parsing header PssblDplct [" + PssblDplct.Value + "]");
						}
					}

					MxNode Prty = header.findFirst("./Prty");
					if (Prty != null)
					{
						result.Prty = Prty.Value;
					}

					MxNode Sgntr = header.findFirst("./Sgntr");
					if (Sgntr != null)
					{
						result.Sgntr = new SignatureEnvelope();
						result.Sgntr.Any = Sgntr.Value;
					}

					MxNode Rltd = header.findFirst("./Rltd");
					if (Rltd != null)
					{
						result.Rltd = new BusinessApplicationHeader1();
						parse(Rltd, result.Rltd);
					}

					return result;
				}
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long t1 = System.currentTimeMillis();
			long t1 = DateTimeHelperClass.CurrentUnixTimeMillis();
			log.fine("parseApplicationHeader_sax: " + (t1 - t0) + "ms");
			return null;
		}

		/// <summary>
		/// Helper parse for BusinessApplicationHeader1.
		/// This actually parses a BusinessApplicationHeaderV01 and copies all its content into 
		/// the result BusinessApplicationHeader1. Both header model classes share the same fields. </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="h"> object to fill with parsed content </param>
		private static void parse(MxNode node, BusinessApplicationHeader1 h)
		{
			BusinessApplicationHeaderV01 bah = parseBusinessApplicationHeaderV01(node);
			if (bah != null)
			{
				h.BizMsgIdr = bah.BizMsgIdr;
				h.BizSvc = bah.BizSvc;
				h.CharSet = bah.CharSet;
				h.CpyDplct = bah.CpyDplct;
				h.CreDt = bah.CreDt;
				h.Fr = bah.Fr;
				h.MsgDefIdr = bah.MsgDefIdr;
				h.Prty = bah.Prty;
				h.Sgntr = bah.Sgntr;
				h.To = bah.To;
				h.PssblDplct = bah.PssblDplct;
			}
		}

		/// <summary>
		/// Helper parse for Party9Choice </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="party"> object to fill with parsed content </param>
		private static void parse(MxNode node, Party9Choice party)
		{
			MxNode OrgId = node.findFirst("./OrgId");
			if (OrgId != null)
			{
				party.OrgId = new PartyIdentification42();
				parse(OrgId, party.OrgId);
			}
			MxNode FIId = node.findFirst("./FIId");
			if (FIId != null)
			{
				party.FIId = new BranchAndFinancialInstitutionIdentification5();
				parse(FIId, party.FIId);
			}
		}

		/// <summary>
		/// Helper parse for BranchAndFinancialInstitutionIdentification5 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="fiId"> object to fill with parsed content </param>
		private static void parse(MxNode node, BranchAndFinancialInstitutionIdentification5 fiId)
		{
			MxNode FinInstnId = node.findFirst("./FinInstnId");
			if (FinInstnId != null)
			{
				fiId.FinInstnId = new FinancialInstitutionIdentification8();
				parse(FinInstnId, fiId.FinInstnId);
			}
			MxNode BrnchId = node.findFirst("./BrnchId");
			if (BrnchId != null)
			{
				fiId.BrnchId = new BranchData2();
				parse(BrnchId, fiId.BrnchId);
			}
		}

		/// <summary>
		/// Helper parse for BranchData2 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="branch"> object to fill with parsed content </param>
		private static void parse(MxNode node, BranchData2 branch)
		{
			MxNode Id = node.findFirst("./Id");
			if (Id != null)
			{
				branch.Id = Id.Value;
			}
			MxNode Nm = node.findFirst("./Nm");
			if (Nm != null)
			{
				branch.Nm = Nm.Value;
			}
			MxNode PstlAdr = node.findFirst("./PstlAdr");
			if (PstlAdr != null)
			{
				branch.PstlAdr = new PostalAddress6();
				parse(PstlAdr, branch.PstlAdr);
			}
		}

		/// <summary>
		/// Helper parse for PostalAddress6 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="pstlAdr"> object to fill with parsed content </param>
		private static void parse(MxNode node, PostalAddress6 pstlAdr)
		{
			MxNode AdrTp = node.findFirst("./AdrTp");
			if (AdrTp != null)
			{
				try
				{
					pstlAdr.AdrTp = AddressType2Code.valueOf(AdrTp.Value);
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
					log.warning("exception " + e + " parsing header AdrTp [" + AdrTp.Value + "]");
				}
			}
			MxNode Dept = node.findFirst("./Dept");
			if (Dept != null)
			{
				pstlAdr.Dept = Dept.Value;
			}
			MxNode SubDept = node.findFirst("./SubDept");
			if (AdrTp != null)
			{
				pstlAdr.SubDept = SubDept.Value;
			}
			MxNode StrtNm = node.findFirst("./StrtNm");
			if (StrtNm != null)
			{
				pstlAdr.StrtNm = StrtNm.Value;
			}
			MxNode BldgNb = node.findFirst("./BldgNb");
			if (BldgNb != null)
			{
				pstlAdr.BldgNb = BldgNb.Value;
			}
			MxNode PstCd = node.findFirst("./PstCd");
			if (PstCd != null)
			{
				pstlAdr.PstCd = PstCd.Value;
			}
			MxNode TwnNm = node.findFirst("./TwnNm");
			if (TwnNm != null)
			{
				pstlAdr.TwnNm = TwnNm.Value;
			}
			MxNode CtrySubDvsn = node.findFirst("./CtrySubDvsn");
			if (CtrySubDvsn != null)
			{
				pstlAdr.CtrySubDvsn = CtrySubDvsn.Value;
			}
			MxNode Ctry = node.findFirst("./Ctry");
			if (Ctry != null)
			{
				pstlAdr.Ctry = Ctry.Value;
			}
		}

		/// <summary>
		/// Helper parse for FinancialInstitutionIdentification8 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="finInstnId"> object to fill with parsed content </param>
		private static void parse(MxNode node, FinancialInstitutionIdentification8 finInstnId)
		{
			MxNode BICFI = node.findFirst("./BICFI");
			if (BICFI != null)
			{
				finInstnId.BICFI = BICFI.Value;
			}
			MxNode ClrSysMmbId = node.findFirst("./ClrSysMmbId");
			if (ClrSysMmbId != null)
			{
				finInstnId.ClrSysMmbId = new ClearingSystemMemberIdentification2();
				parse(ClrSysMmbId, finInstnId.ClrSysMmbId);

			}
			MxNode Nm = node.findFirst("./Nm");
			if (Nm != null)
			{
				finInstnId.Nm = Nm.Value;
			}
			MxNode PstlAdr = node.findFirst("./PstlAdr");
			if (PstlAdr != null)
			{
				finInstnId.PstlAdr = new PostalAddress6();
				parse(PstlAdr, finInstnId.PstlAdr);
			}
			MxNode Othr = node.findFirst("./Othr");
			if (Othr != null)
			{
				finInstnId.Othr = new GenericFinancialIdentification1();
				parse(Othr, finInstnId.Othr);
			}
		}

		/// <summary>
		/// Helper parse for GenericFinancialIdentification1 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="fiId"> object to fill with parsed content </param>
		private static void parse(MxNode node, GenericFinancialIdentification1 fiId)
		{
			MxNode Id = node.findFirst("./Id");
			if (Id != null)
			{
				fiId.Id = Id.Value;
			}
			MxNode SchmeNm = node.findFirst("./SchmeNm");
			if (SchmeNm != null)
			{
				fiId.SchmeNm = new FinancialIdentificationSchemeName1Choice();
				parse(SchmeNm, fiId.SchmeNm);
			}
			MxNode Issr = node.findFirst("./Issr");
			if (Issr != null)
			{
				fiId.Issr = Issr.Value;
			}
		}

		/// <summary>
		/// Helper parse for FinancialIdentificationSchemeName1Choice </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="schmeNm"> object to fill with parsed content </param>
		private static void parse(MxNode node, FinancialIdentificationSchemeName1Choice schmeNm)
		{
			MxNode Cd = node.findFirst("./Cd");
			if (Cd != null)
			{
				schmeNm.Cd = Cd.Value;
			}
			MxNode Prtry = node.findFirst("./Prtry");
			if (Prtry != null)
			{
				schmeNm.Prtry = Prtry.Value;
			}
		}

		/// <summary>
		/// Helper parse for ClearingSystemMemberIdentification2 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="clrSysMmbId"> object to fill with parsed content </param>
		private static void parse(MxNode node, ClearingSystemMemberIdentification2 clrSysMmbId)
		{
			MxNode ClrSysId = node.findFirst("./ClrSysId");
			if (ClrSysId != null)
			{
				clrSysMmbId.ClrSysId = new ClearingSystemIdentification2Choice();
				parse(ClrSysId, clrSysMmbId.ClrSysId);
			}
			MxNode MmbId = node.findFirst("./MmbId");
			if (MmbId != null)
			{
				clrSysMmbId.MmbId = MmbId.Value;
			}
		}

		/// <summary>
		/// Helper parse for ClearingSystemIdentification2Choice </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="clrSysId"> object to fill with parsed content </param>
		private static void parse(MxNode node, ClearingSystemIdentification2Choice clrSysId)
		{
			MxNode Cd = node.findFirst("./Cd");
			if (Cd != null)
			{
				clrSysId.Cd = Cd.Value;
			}
			MxNode Prtry = node.findFirst("./Prtry");
			if (Prtry != null)
			{
				clrSysId.Prtry = Prtry.Value;
			}
		}

		/// <summary>
		/// Helper parse for PartyIdentification42 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="party"> object to fill with parsed content </param>
		private static void parse(MxNode node, PartyIdentification42 party)
		{
			MxNode Nm = node.findFirst("./Nm");
			if (Nm != null)
			{
				party.Nm = Nm.Value;
			}
			MxNode PstlAdr = node.findFirst("./PstlAdr");
			if (PstlAdr != null)
			{
				party.PstlAdr = new PostalAddress6();
				parse(PstlAdr, party.PstlAdr);
			}
			MxNode Id = node.findFirst("./Id");
			if (Id != null)
			{
				party.Id = new Party10Choice();
				parse(Id, party.Id);
			}
			MxNode CtryOfRes = node.findFirst("./CtryOfRes");
			if (CtryOfRes != null)
			{
				party.CtryOfRes = CtryOfRes.Value;
			}
			MxNode CtctDtls = node.findFirst("./CtctDtls");
			if (CtctDtls != null)
			{
				party.CtctDtls = new ContactDetails2();
				parse(CtctDtls, party.CtctDtls);
			}
		}

		/// <summary>
		/// Helper parse for ContactDetails2 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="ctctDtls"> object to fill with parsed content </param>
		private static void parse(MxNode node, ContactDetails2 ctctDtls)
		{
			MxNode NmPrfx = node.findFirst("./NmPrfx");
			if (NmPrfx != null)
			{
				try
				{
					ctctDtls.NmPrfx = NamePrefix1Code.valueOf(NmPrfx.Value);
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
					log.warning("exception " + e + " parsing header NmPrfx [" + NmPrfx.Value + "]");
				}
			}
			MxNode Nm = node.findFirst("./Nm");
			if (Nm != null)
			{
				ctctDtls.Nm = Nm.Value;
			}
			MxNode PhneNb = node.findFirst("./PhneNb");
			if (PhneNb != null)
			{
				ctctDtls.PhneNb = PhneNb.Value;
			}
			MxNode MobNb = node.findFirst("./MobNb");
			if (MobNb != null)
			{
				ctctDtls.MobNb = MobNb.Value;
			}
			MxNode FaxNb = node.findFirst("./FaxNb");
			if (FaxNb != null)
			{
				ctctDtls.FaxNb = FaxNb.Value;
			}
			MxNode EmailAdr = node.findFirst("./EmailAdr");
			if (EmailAdr != null)
			{
				ctctDtls.EmailAdr = EmailAdr.Value;
			}
			MxNode Othr = node.findFirst("./Othr");
			if (Othr != null)
			{
				ctctDtls.Othr = Othr.Value;
			}
		}

		/// <summary>
		/// Helper parse for Party10Choice </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="id"> object to fill with parsed content </param>
		private static void parse(MxNode node, Party10Choice id)
		{
			MxNode OrgId = node.findFirst("./OrgId");
			if (OrgId != null)
			{
				id.OrgId = new OrganisationIdentification7();
				parse(OrgId, id.OrgId);
			}
			MxNode PrvtId = node.findFirst("./PrvtId");
			if (PrvtId != null)
			{
				id.PrvtId = new PersonIdentification5();
				parse(PrvtId, id.PrvtId);
			}
		}

		/// <summary>
		/// Helper parse for PersonIdentification5 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="prvtId"> object to fill with parsed content </param>
		private static void parse(MxNode node, PersonIdentification5 prvtId)
		{
			MxNode DtAndPlcOfBirth = node.findFirst("./DtAndPlcOfBirth");
			if (DtAndPlcOfBirth != null)
			{
				prvtId.DtAndPlcOfBirth = new DateAndPlaceOfBirth();
				parse(DtAndPlcOfBirth, prvtId.DtAndPlcOfBirth);
			}
		}

		/// <summary>
		/// Helper parse for DateAndPlaceOfBirth </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="dtAndPlcOfBirth"> object to fill with parsed content </param>
		private static void parse(MxNode node, DateAndPlaceOfBirth dtAndPlcOfBirth)
		{
			MxNode BirthDt = node.findFirst("./BirthDt");
			if (BirthDt != null)
			{
				try
				{
					dtAndPlcOfBirth.BirthDt = javax.xml.datatype.DatatypeFactory.newInstance().newXMLGregorianCalendar(BirthDt.Value);
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final javax.xml.datatype.DatatypeConfigurationException e)
				catch (javax.xml.datatype.DatatypeConfigurationException e)
				{
					log.warning("exception " + e + " parsing header BirthDt [" + BirthDt.Value + "]");
				}
			}
			MxNode PrvcOfBirth = node.findFirst("./PrvcOfBirth");
			if (PrvcOfBirth != null)
			{
				dtAndPlcOfBirth.PrvcOfBirth = PrvcOfBirth.Value;
			}
			MxNode CityOfBirth = node.findFirst("./CityOfBirth");
			if (CityOfBirth != null)
			{
				dtAndPlcOfBirth.CityOfBirth = CityOfBirth.Value;
			}
			MxNode CtryOfBirth = node.findFirst("./CtryOfBirth");
			if (CtryOfBirth != null)
			{
				dtAndPlcOfBirth.CtryOfBirth = CtryOfBirth.Value;
			}
		}

		/// <summary>
		/// Helper parse for OrganisationIdentification7 </summary>
		/// <param name="node"> current node for the path search </param>
		/// <param name="orgId"> object to fill with parsed content </param>
		private static void parse(MxNode node, OrganisationIdentification7 orgId)
		{
			MxNode AnyBIC = node.findFirst("./AnyBIC");
			if (AnyBIC != null)
			{
				orgId.AnyBIC = AnyBIC.Value;
			}
		}
	}

}