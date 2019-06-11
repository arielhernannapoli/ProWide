using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
	using ToStringBuilder = org.apache.commons.lang3.builder.ToStringBuilder;


	/// <summary>
	/// XMl writer for MX model classes.
	/// 
	/// @since 7.8
	/// </summary>
	public sealed class XmlEventWriter : XMLEventWriter
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(XmlEventWriter).FullName);
		private Writer @out;
		private readonly StringBuilder indent = new StringBuilder();
		private StartElement delayedStart = null;
		private bool startTagIncomplete = false;
		private int startElementCount;
		private string defaultPrefix = null;
		private IDictionary<string, string> peferredPrefixes;
		private bool includeXMLDeclaration = true;
		private string rootElement = null;

		/// <param name="baos"> output buffer to write </param>
		/// <param name="defaultPrefix"> optional prefix (empty by default) to used for all elements that are not binded to a specific prefix </param>
		/// <param name="includeXMLDeclaration"> true to include the XML declaration (true by default) </param>
		/// <param name="rootElement"> local name of the root element of the XML fragment to create, used to declare namespace </param>
		/// <seealso cref= #setPeferredPrefixes(Map) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public XmlEventWriter(java.io.Writer baos, final String defaultPrefix, boolean includeXMLDeclaration, final String rootElement)
		public XmlEventWriter(Writer baos, string defaultPrefix, bool includeXMLDeclaration, string rootElement)
		{
			this.@out = baos;
			this.startElementCount = 0;
			this.defaultPrefix = defaultPrefix;
			this.includeXMLDeclaration = includeXMLDeclaration;
			this.rootElement = rootElement;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void add(final javax.xml.stream.events.XMLEvent event) throws javax.xml.stream.XMLStreamException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		public void add(XMLEvent @event)
		{
			if (@event != null)
			{
				try
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int type = event.getEventType();
					int type = @event.EventType;
					switch (type)
					{
					case XMLEvent.START_DOCUMENT:
						if (this.includeXMLDeclaration)
						{
							@out.write("<?xml version=\"1.0\" encoding=\"" + ((StartDocument) @event).CharacterEncodingScheme + "\"?>");
						}
						else
						{
							log.finest("skipping xml declaration");
						}
						break;

					case XMLEvent.START_ELEMENT:
						this.startElementCount++;
						closeStartTagIfNeeded();
						indent.Append(' ');
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.stream.events.StartElement se = event.asStartElement();
						StartElement se = @event.asStartElement();
						/*
						 * the startElementyCount below fixes the bug related to not opening nested Document inside xs:any
						 */
						if (StringUtils.Equals(se.Name.LocalPart, this.rootElement) && this.startElementCount == 1)
						{
							delayedStart = se;
							log.finest("local part is Document, initializing delayed start, startElementCount=" + this.startElementCount);
						}
						else
						{
							@out.write("\n" + indent + "<" + prefix(se.Name) + se.Name.LocalPart);
							/* 
							 * to support attributes instead of closing here we set a flag and close this later
							 */
							startTagIncomplete = true;
						}
						break;

					case XMLEvent.NAMESPACE:
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.stream.events.Namespace ne = (javax.xml.stream.events.Namespace) event;
						Namespace ne = (Namespace) @event;
						StringBuilder sb = new StringBuilder();
						if (delayedStart != null)
						{
							sb.Append("\n" + indent + "<" + prefix(ne.Name) + delayedStart.Name.LocalPart);
							delayedStart = null;
						}
						sb.Append(@namespace(ne));
						@out.write(sb.ToString());
						startTagIncomplete = true;
						break;

					case XMLEvent.CHARACTERS:
						closeStartTagIfNeeded();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.stream.events.Characters ce = event.asCharacters();
						Characters ce = @event.asCharacters();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char[] arr = ce.getData().toCharArray();
						char[] arr = ce.Data.ToCharArray();
						@out.write(escape(arr));
						break;

					case XMLEvent.END_ELEMENT:
						closeStartTagIfNeeded();
						indent.Remove(0, 1);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.stream.events.EndElement ee = event.asEndElement();
						EndElement ee = @event.asEndElement();
						@out.write("</" + prefix(ee.Name) + ee.Name.LocalPart + ">\n" + indent);
						break;

					case XMLEvent.END_DOCUMENT:
						closeStartTagIfNeeded();
						/*  
						 * No need to do anything while writing to a string 
						 */
						break;

					case XMLEvent.ATTRIBUTE:
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.xml.stream.events.Attribute a = (javax.xml.stream.events.Attribute) event;
						Attribute a = (Attribute) @event;
						@out.write(" " + a.Name + "=\"" + a.Value + "\" ");
						break;

					default:
						log.finer("PW Unhandled XMLEvent " + ToStringBuilder.reflectionToString(@event));
						break;
					}
				}
				catch (IOException e)
				{
					log.severe("PW I/O error: " + e.Message);
					log.log(Level.FINER, "PW I/O error: ", e);
					throw new XMLStreamException(e);
				}
			}
		}

		/// <summary>
		/// Given a namespace event, returns the xmlns declaration with proper prefix
		/// from the preferred prefix parameter map or default prefix
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String namespace(final javax.xml.stream.events.Namespace ne)
		private string @namespace(Namespace ne)
		{
			StringBuilder sb = new StringBuilder(" xmlns");
			string prefix = null;
			if (this.peferredPrefixes != null)
			{
				prefix = this.peferredPrefixes[ne.Value];
			}
			if (prefix == null && this.defaultPrefix != null)
			{
				prefix = this.defaultPrefix;
			}
			if (prefix != null)
			{
				sb.Append(":").Append(prefix);
			}
			sb.Append("=\"").Append(ne.Value).Append("\"");
			return sb.ToString();
		}

		/// <summary>
		/// Inplace escape por xml
		/// repa </summary>
		/// <param name="arr">
		/// @since 7.8 </param>
		private string escape(char[] arr)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder(arr.length);
			StringBuilder sb = new StringBuilder(arr.Length);
			// 2015.11 miguel
			// Consider code in com.sun.xml.bind.marshaller.DumbEscapeHandler for replacements
			for (int i = 0; i < arr.Length; i++)
			{
				switch (arr[i])
				{
				case '&':
					sb.Append("&amp;");
					break;
				case '<':
					sb.Append("&lt;");
					break;
				case '>':
					sb.Append("&gt;");
					break;
				case '\"':
					// 2015.11 miguel: esto podria dar probelmas eventualmente con escapeo dentro de atributos, ignorado por ahora porque se usa para curency y ns
					//	                if (isAttVal) {
					//	                    sb.append("&quot;");
					//	                } else {
					sb.Append('\"');
					//	                }
					break;
				default:
					if (arr[i] > '\u007f')
					{
						sb.Append("&#");
						sb.Append(Convert.ToString(arr[i]));
						sb.Append(';');
					}
					else
					{
						sb.Append(arr[i]);
					}
				break;
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// Return the prefix for the current tag checking if there is a parent prefix set, or a default prefix
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String peferredPrefix(final javax.xml.namespace.QName qname)
		private string peferredPrefix(QName qname)
		{
			if (this.peferredPrefixes != null)
			{
				string prefix = this.peferredPrefixes[qname.NamespaceURI];
				if (prefix != null)
				{
					return prefix;
				}
			}
			/*
			 * Sebastian sep 2017: qname prefix must be ignored since closing AppHdr will include unbounded ns2
			 */
			//if (!StringUtils.isBlank(qname.getPrefix()) && !StringUtils.equals(qname.getPrefix(), "xmlns")) {
			//	return qname.getPrefix();
			if (this.defaultPrefix != null)
			{
				return this.defaultPrefix;
			}
			else
			{
				return null;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String prefix(final javax.xml.namespace.QName qname)
		private string prefix(QName qname)
		{
			string prefix = peferredPrefix(qname);
			if (prefix != null)
			{
				return prefix + ":";
			}
			else
			{
				return "";
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void closeStartTagIfNeeded() throws java.io.IOException
		private void closeStartTagIfNeeded()
		{
			if (this.startTagIncomplete)
			{
				@out.write('>');
				this.startTagIncomplete = false;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void add(javax.xml.stream.XMLEventReader arg0) throws javax.xml.stream.XMLStreamException
		public void add(XMLEventReader arg0)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void close() throws javax.xml.stream.XMLStreamException
		public void close()
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void flush() throws javax.xml.stream.XMLStreamException
		public void flush()
		{
			try
			{
				@out.flush();
			}
			catch (IOException e)
			{
				throw new XMLStreamException(e);
			}
		}

		public NamespaceContext NamespaceContext
		{
			get
			{
				return new ProwideNamespaceContext();
			}
			set
			{
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public String getPrefix(String arg0) throws javax.xml.stream.XMLStreamException
		public string getPrefix(string arg0)
		{
			return null;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void setDefaultNamespace(String arg0) throws javax.xml.stream.XMLStreamException
		public string DefaultNamespace
		{
			set
			{
			}
		}


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void setPrefix(String arg0, String arg1) throws javax.xml.stream.XMLStreamException
		public void setPrefix(string arg0, string arg1)
		{
		}

		/*
		 * Sebastian sep 2017: esto no se puede usar porque al usarlo funciona en los elements pero 
		 * no se recibe ningun evento namespace y quedan sin definir en el root
		 */
		private sealed class ProwideNamespaceContext : NamespaceContext
		{

			public string getNamespaceURI(string prefix)
			{
				//return XsysNamespaces.namespaceURI(prefix);
				return null;
			}

			public string getPrefix(string namespaceURI)
			{
				//return XsysNamespaces.prefix(namespaceURI);
				return null;
			}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public java.util.Iterator getPrefixes(String namespaceURI)
			public IEnumerator getPrefixes(string namespaceURI)
			{
				/*
				String prefix = XsysNamespaces.prefix(namespaceURI);
				if (prefix != null) {
					List<String> result = new ArrayList<>();
					result.add(prefix);
					return result.iterator();
				}
				*/
				return null;
			}
		}

		/// <summary>
		/// @since 7.9.3
		/// </summary>
		public string DefaultPrefix
		{
			get
			{
				return defaultPrefix;
			}
			set
			{
				this.defaultPrefix = value;
			}
		}


		/// <summary>
		/// @since 7.9.3
		/// </summary>
		public IDictionary<string, string> PeferredPrefixes
		{
			get
			{
				return peferredPrefixes;
			}
			set
			{
				this.peferredPrefixes = value;
			}
		}


		/// <summary>
		/// @since 7.9.3
		/// </summary>
		public bool IncludeXMLDeclaration
		{
			get
			{
				return includeXMLDeclaration;
			}
			set
			{
				this.includeXMLDeclaration = value;
			}
		}


		/// <summary>
		/// @since 7.9.3
		/// </summary>
		public string RootElement
		{
			get
			{
				return rootElement;
			}
			set
			{
				this.rootElement = value;
			}
		}


	}
}