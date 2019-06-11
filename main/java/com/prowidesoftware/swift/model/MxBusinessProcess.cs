using System.Collections.Generic;

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
namespace com.prowidesoftware.swift.model
{

	/// <summary>
	/// SWIFT business process classification for MX messages.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 7.0
	/// </summary>
	public sealed class MxBusinessProcess
	{
		public static readonly MxBusinessProcess acmt = new MxBusinessProcess("acmt", InnerEnum.acmt, "Account Management");
		public static readonly MxBusinessProcess admi = new MxBusinessProcess("admi", InnerEnum.admi, "Administration");
		public static readonly MxBusinessProcess auth = new MxBusinessProcess("auth", InnerEnum.auth, "Authorities");
		public static readonly MxBusinessProcess caaa = new MxBusinessProcess("caaa", InnerEnum.caaa, "Acceptor to Acquirer Card Transactions");
		public static readonly MxBusinessProcess caam = new MxBusinessProcess("caam", InnerEnum.caam, "ATM Management");
		public static readonly MxBusinessProcess camt = new MxBusinessProcess("camt", InnerEnum.camt, "Cash Management");
		public static readonly MxBusinessProcess catm = new MxBusinessProcess("catm", InnerEnum.catm, "Terminal Management");
		public static readonly MxBusinessProcess catp = new MxBusinessProcess("catp", InnerEnum.catp, "ATM Card Transactions");
		public static readonly MxBusinessProcess cbrf = new MxBusinessProcess("cbrf", InnerEnum.cbrf, "");
		public static readonly MxBusinessProcess colr = new MxBusinessProcess("colr", InnerEnum.colr, "Collateral Management");
		public static readonly MxBusinessProcess fxtr = new MxBusinessProcess("fxtr", InnerEnum.fxtr, "Foreign Exchange Trade");
		public static readonly MxBusinessProcess defp = new MxBusinessProcess("defp", InnerEnum.defp, "Derivatives");
		public static readonly MxBusinessProcess head = new MxBusinessProcess("head", InnerEnum.head, "Business Application Header");
		public static readonly MxBusinessProcess pacs = new MxBusinessProcess("pacs", InnerEnum.pacs, "Payments Clearing and Settlement");
		public static readonly MxBusinessProcess pain = new MxBusinessProcess("pain", InnerEnum.pain, "Payments Initiation");
		public static readonly MxBusinessProcess reda = new MxBusinessProcess("reda", InnerEnum.reda, "Reference Data");
		public static readonly MxBusinessProcess remt = new MxBusinessProcess("remt", InnerEnum.remt, "Payments Remittance Advice");
		public static readonly MxBusinessProcess secl = new MxBusinessProcess("secl", InnerEnum.secl, "Securities Clearing");
		public static readonly MxBusinessProcess seev = new MxBusinessProcess("seev", InnerEnum.seev, "Securities Events");
		public static readonly MxBusinessProcess semt = new MxBusinessProcess("semt", InnerEnum.semt, "Securities Management");
		public static readonly MxBusinessProcess sese = new MxBusinessProcess("sese", InnerEnum.sese, "Securities Settlement");
		public static readonly MxBusinessProcess seti = new MxBusinessProcess("seti", InnerEnum.seti, "Securities Trade Initiation");
		public static readonly MxBusinessProcess setr = new MxBusinessProcess("setr", InnerEnum.setr, "Securities Trade");
		public static readonly MxBusinessProcess supl = new MxBusinessProcess("supl", InnerEnum.supl, "Supplementary Data");
		public static readonly MxBusinessProcess trea = new MxBusinessProcess("trea", InnerEnum.trea, "Treasury");
		public static readonly MxBusinessProcess tsin = new MxBusinessProcess("tsin", InnerEnum.tsin, "Trade Services Initiation");
		public static readonly MxBusinessProcess tsmt = new MxBusinessProcess("tsmt", InnerEnum.tsmt, "Trade Services Management");
		public static readonly MxBusinessProcess tsrv = new MxBusinessProcess("tsrv", InnerEnum.tsrv, "Trade Services");
		public static readonly MxBusinessProcess xsys = new MxBusinessProcess("xsys", InnerEnum.xsys, "System Message");

		private static readonly IList<MxBusinessProcess> valueList = new List<MxBusinessProcess>();

		static MxBusinessProcess()
		{
			valueList.Add(acmt);
			valueList.Add(admi);
			valueList.Add(auth);
			valueList.Add(caaa);
			valueList.Add(caam);
			valueList.Add(camt);
			valueList.Add(catm);
			valueList.Add(catp);
			valueList.Add(cbrf);
			valueList.Add(colr);
			valueList.Add(fxtr);
			valueList.Add(defp);
			valueList.Add(head);
			valueList.Add(pacs);
			valueList.Add(pain);
			valueList.Add(reda);
			valueList.Add(remt);
			valueList.Add(secl);
			valueList.Add(seev);
			valueList.Add(semt);
			valueList.Add(sese);
			valueList.Add(seti);
			valueList.Add(setr);
			valueList.Add(supl);
			valueList.Add(trea);
			valueList.Add(tsin);
			valueList.Add(tsmt);
			valueList.Add(tsrv);
			valueList.Add(xsys);
		}

		public enum InnerEnum
		{
			acmt,
			admi,
			auth,
			caaa,
			caam,
			camt,
			catm,
			catp,
			cbrf,
			colr,
			fxtr,
			defp,
			head,
			pacs,
			pain,
			reda,
			remt,
			secl,
			seev,
			semt,
			sese,
			seti,
			setr,
			supl,
			trea,
			tsin,
			tsmt,
			tsrv,
			xsys
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		private string description = null;

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private MxBusinessProcess(final String description)
		private MxBusinessProcess(string name, InnerEnum innerEnum, string description)
		{
			this.description = description;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public String Description
		{
			get
			{
				return this.description;
			}
		}

		public static IList<MxBusinessProcess> values()
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

		public static MxBusinessProcess valueOf(string name)
		{
			foreach (MxBusinessProcess enumInstance in MxBusinessProcess.values())
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