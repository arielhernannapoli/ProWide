using System;
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
namespace com.prowidesoftware.swift.model.field
{

	using JsonElement = com.google.gson.JsonElement;
	using JsonObject = com.google.gson.JsonObject;
	using JsonParser = com.google.gson.JsonParser;
	using DeprecationUtils = com.prowidesoftware.deprecation.DeprecationUtils;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;
	using SwiftFormatUtils = com.prowidesoftware.swift.utils.SwiftFormatUtils;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Validate = org.apache.commons.lang3.Validate;
	using DateFormatUtils = org.apache.commons.lang3.time.DateFormatUtils;



	/// <summary>
	/// Base class implemented by classes that provide a general access to field components.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public abstract class Field : PatternContainer, JsonSerializable
	{
		public abstract string parserPattern();
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(Field).FullName);

		/// <summary>
		/// Zero based list of field components in String format.<br>
		/// For example: for field content ":FOO//EUR1234 will be components[0]=FOO, components[1]=EUR and components[1]=1234
		/// </summary>
		protected internal IList<string> components;

		/// @deprecated usar <seealso cref="#Field(int)"/> 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("usar <seealso cref="#Field(int)"/>") @ProwideDeprecated(phase2=com.prowidesoftware.deprecation.TargetYear._2019) protected Field()
		[Obsolete("usar <seealso cref="#Field(int)"/>")]
		protected internal Field()
		{
		}

		/// <summary>
		/// Creates a field with the list of components initialized to the given number of components. </summary>
		/// <seealso cref= #init(int) </seealso>
		/// <param name="components"> the number of components to initialize </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected Field(final int components)
		protected internal Field(int components) : base()
		{
			init(components);
		}

		/// <summary>
		/// Initialize the list of components to the indicated size and sets all values to null </summary>
		/// <param name="components"> the number of components to initialize
		/// @since 7.8 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void init(final int components)
		protected internal virtual void init(int components)
		{
			this.components = new List<>(components);
			for (int i = 0;i < components;i++)
			{
				this.components.Add(null);
			}
		}

		/// <summary>
		/// Creates a new field and initializes its components with content from the parameter value.
		/// The value is parsed with <seealso cref="#parse(String)"/> </summary>
		/// <param name="value"> complete field value including separators and CRLF </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected Field(final String value)
		protected internal Field(string value) : base()
		{
			parse(value);
			/*
			 * trim empty components to null
			 */
			for (int i = 0; i < this.components.Count; i++)
			{
				if (StringUtils.isEmpty(this.components[i]))
				{
					this.components[i] = null;
				}
			}
		}

		/// <summary>
		/// Parses the parameter value into the internal components structure.
		/// Used to update all components from a full new value, as an alternative
		/// to setting individual components. Previous components value is overwritten.
		/// <br>
		/// Implemented by subclasses with logic for each specific field structure. 
		/// </summary>
		/// <param name="value"> complete field value including separators and CRLF
		/// @since 7.8 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public abstract void parse(final String value);
		public abstract void parse(string value);

		/// <summary>
		/// Copy constructor.<br>
		/// Initializes the components list with a deep copy of the source components list. </summary>
		/// <param name="source"> a field instance to copy
		/// @since 7.7 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected Field(final Field source)
		protected internal Field(Field source)
		{
			this.components = new List<string>(source.Components);
		}

		/// <summary>
		/// Implementation of toString using ToStringBuilder from commons-lang
		/// </summary>
		public override string ToString()
		{
			return org.apache.commons.lang3.builder.ToStringBuilder.reflectionToString(this);
		}

		/// <summary>
		/// Implementation of equals using EqualsBuilder from commons-lang
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: @Override public boolean equals(final Object obj)
		public override bool Equals(object obj)
		{
			return org.apache.commons.lang3.builder.EqualsBuilder.reflectionEquals(this, obj);
		}

		/// <summary>
		/// Implementation of hashCode using HashCodeBuilder from commons-lang
		/// </summary>
		public override int GetHashCode()
		{
			return org.apache.commons.lang3.builder.HashCodeBuilder.reflectionHashCode(this);
		}

		/// <summary>
		/// Format the given object as a money number without currency information in format </summary>
		/// <param name="aValue"> </param>
		/// <returns> the formatted amount as String </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected static String formatNumber(final Object aValue)
		protected internal static string formatNumber(object aValue)
		{
			//create formatter for financial amounts
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.text.DecimalFormat fmt = new java.text.DecimalFormat("#,###.00");
			DecimalFormat fmt = new DecimalFormat("#,###.00");

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.text.NumberFormat f = java.text.NumberFormat.getInstance(Locale.getDefault());
			NumberFormat f = NumberFormat.getInstance(Locale.Default);
			if (f is DecimalFormat)
			{
				((DecimalFormat) f).DecimalSeparatorAlwaysShown = true;
				fmt.DecimalFormatSymbols = ((DecimalFormat) f).DecimalFormatSymbols;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String formatted = fmt.format(aValue);
			string formatted = fmt.format(aValue);
			return formatted;
		}


		/// <param name="d"> Date object to format </param>
		/// <returns> the formatted date as dd/MM/yyyy or empty if exception occurs during formatting </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected static String format(final Calendar d)
		protected internal static string format(DateTime d)
		{
			if (d != null)
			{
				try
				{
					return DateFormatUtils.format(d.Ticks, "dd/MM/yyyy");
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
					log.log(Level.WARNING, "error formatting date", e);
				}
			}
			return StringUtils.EMPTY;
		}

		/// <summary>
		/// A formatted account with a fixed format nnnn-nnnnn-nnn-n </summary>
		/// <param name="a"> string with an account number or null </param>
		/// <returns> the formatted account or an empty String if param is null </returns>
		// TODO support user formatting masks from property file
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected static String formatAccount(final String a)
		protected internal static string formatAccount(string a)
		{
			if (a != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder result = new StringBuilder(a);
				StringBuilder result = new StringBuilder(a);
				try
				{
					result.Insert(4, '-');
					result.Insert(9, '-');
					result.Insert(12, '-');
					return result.ToString();
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
					log.log(Level.WARNING, "error formatting account", e);
				}
			}
			return StringUtils.EMPTY;
		}

		/// <summary>
		/// Append each lines in a new lines, empty lines are ignored </summary>
		/// <param name="sb"> must not be null, target buffer </param>
		/// <param name="lines"> may be null or empty, nothing is done in this case </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void appendInLines(final StringBuilder sb, final String... lines)
		protected internal virtual void appendInLines(StringBuilder sb, params string[] lines)
		{
			Validate.notNull(sb);
			if (lines == null)
			{
				log.finest("lines is null");
			}
			else
			{
				for (int i = 0;i < lines.Length;i++)
				{
					if (StringUtils.isNotBlank(lines[i]))
					{
						if ((i != 0) || ((i == 0) && StringUtils.isNotBlank(sb.ToString())))
						{
							sb.Append(FINWriterVisitor.SWIFT_EOL);
						}
						sb.Append(lines[i]);
					}
				}
			}
		}

		/// <summary>
		/// Append each component between componentStart and componentEnd in a new lines, empty components are ignored </summary>
		/// <param name="sb"> must not be null, target buffer </param>
		/// <param name="componentStart"> starting component number to add </param>
		/// <param name="componentEnd"> ending component number to add </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void appendInLines(final StringBuilder sb, final int componentStart, final int componentEnd)
		protected internal virtual void appendInLines(StringBuilder sb, int componentStart, int componentEnd)
		{
			Validate.notNull(sb);
			bool first = true;
			for (int i = componentStart; i <= componentEnd; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String c = getComponent(i);
				string c = getComponent(i);
				if (StringUtils.isNotBlank(c))
				{
					if (!first || StringUtils.isNotBlank(sb.ToString()))
					{
						sb.Append(FINWriterVisitor.SWIFT_EOL);
					}
					sb.Append(c);
					first = false;
				}
			}
		}

		/// <returns> comopnents list </returns>
		public virtual IList<string> Components
		{
			get
			{
				return components;
			}
			set
			{
				this.components = value;
			}
		}


		/// <summary>
		/// Inserts a component String value into the list of components, using the component number to position the value into the List. </summary>
		/// <param name="number"> component number, first component of a field should be number one </param>
		/// <param name="value"> String value of the parsed component (without component separators ':', '/', '//') </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setComponent(final int number, final String value)
		public virtual void setComponent(int number, string value)
		{
			Validate.isTrue(number > 0, "component number is 1-based");

			//internal position index is zero based
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int position = number - 1;
			int position = number - 1;

			if (this.components == null)
			{
				this.components = new List<>();
			}
			if (position >= 0)
			{
				if (position >= this.components.Count)
				{
					log.warning("component number " + number + " is out of bound for field " + Name);
				}
				else
				{
					this.components[position] = value;
				}
			}
			else
			{
				log.severe("components are named starting at 1, cannot insert a component with number " + number);
			}
		}

		/// <summary>
		/// Gets a specific component from the components list. </summary>
		/// <param name="number"> one-based index of component, first component of a field should be number one </param>
		/// <returns> found component or null </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getComponent(final int number)
		public virtual string getComponent(int number)
		{
			//internal position index is zero based
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int position = number - 1;
			int position = number - 1;

			if (this.components != null)
			{
				if ((position >= 0) && (position < this.components.Count))
				{
					return this.components[position];
				}
			}
			return null;
		}

		/// <seealso cref= #getValueDisplay(Locale) </seealso>
		public virtual string ValueDisplay
		{
			get
			{
				return getValueDisplay(null);
			}
		}

		/// <summary>
		/// Get a localized, suitable for showing to humans string of the field values.
		/// This method is overwritten when necessary by subclasses.
		/// </summary>
		/// <param name="locale"> optional locale to format date and amounts, if null, the default locale is used </param>
		/// <returns> a concatenation of formated components with " " separator </returns>
		/// <seealso cref= #getValueDisplay(int, Locale)
		/// @since 7.8 </seealso>
		public virtual string getValueDisplay(Locale locale)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder result = new StringBuilder();
			StringBuilder result = new StringBuilder();
			for (int i = 1; i <= components.Count; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String s = getValueDisplay(i, locale);
				string s = getValueDisplay(i, locale);
				if (s != null)
				{
					if (result.Length > 0)
					{
						result.Append(" ");
					}
					result.Append(s);
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns a localized suitable for showing to humans string of a field component.
		/// </summary>
		/// <param name="component"> number of the component to display </param>
		/// <param name="locale"> optional locale to format date and amounts, if null, the default locale is used </param>
		/// <returns> formatted component value or null if component number is invalid or not present </returns>
		/// <exception cref="IllegalArgumentException"> if component number is invalid for the field
		/// @since 7.8 </exception>
		public abstract string getValueDisplay(int component, Locale locale);

		/// <summary>
		/// Get the given component as the given object type.
		/// If the class is not recognized, it returns null, as well as if conversion fails. </summary>
		/// <param name="component"> one-based index of the component to retrieve </param>
		/// <seealso cref= #getComponent(int) </seealso>
		/// <exception cref="IllegalArgumentException"> if c is not any of: String, BIC, Currency, Number, BigDecimal Character or Integer </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Object getComponentAs(final int component, @SuppressWarnings("rawtypes") final Class c)
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
		public virtual object getComponentAs(int component, Type c)
		{
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String s = getComponent(component);
				string s = getComponent(component);
				log.finest("converting string value: " + s);

				if (c.Equals(typeof(string)))
				{
					return s;

				}
				else if (c.Equals(typeof(Number)) || c.Equals(typeof(decimal)))
				{
					return SwiftFormatUtils.getNumber(s);

				}
				else if (c.Equals(typeof(BIC)))
				{
					return new BIC(s);

				}
				else if (c.Equals(typeof(Currency)))
				{
					return Currency.getInstance(s);

				}
				else if (c.Equals(typeof(char?)))
				{
					return SwiftFormatUtils.getSign(s);

				}
				else if (c.Equals(typeof(int?)))
				{
					return Convert.ToInt32(s);

				}
				else
				{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
					throw new System.ArgumentException("Can't handle " + c.FullName);
				}
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
			catch (Exception e)
			{
				log.severe("Error converting component content: " + e);
			}
			return null;
		}

		/// <summary>
		/// Get the given component as a number object
		/// This method internall y calls <seealso cref="#getComponentAs(int, Class)"/>, and casts the result
		/// @since 7.8
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public Number getComponentAsNumber(final int component)
		public virtual Number getComponentAsNumber(int component)
		{
			return (Number)getComponentAs(component, typeof(Number));
		}

		/// <summary>
		/// Returns a string with joined components values.
		/// </summary>
		/// <param name="start"> starting index of components to join (zero based) </param>
		/// <param name="skipLast"> if true the last component will not be included in the join, and where
		/// the "last" component is understood as the last not empty component (this is not necessary
		/// the last component of the field's component list.
		/// </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String joinComponents(final int start, final boolean skipLast)
		public virtual string joinComponents(int start, bool skipLast)
		{
			// FIXME para que se crea el list intermedio toAdd? no le veo razon de ser, se podria iterar en el segundo loop directo sobre this.components
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<String> toAdd = new ArrayList<>();
			IList<string> toAdd = new List<string>();
			for (int i = start; i < this.componentsSize(); i++)
			{
				if (StringUtils.isNotEmpty(this.components[i]))
				{
					toAdd.Add(this.components[i]);
				}
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int end = skipLast ? toAdd.size() - 1 : toAdd.size();
			int end = skipLast ? toAdd.Count - 1 : toAdd.Count;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder result = new StringBuilder();
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < end; i++)
			{
				result.Append(toAdd[i]);
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns a string with all field's components joined. </summary>
		/// <param name="skipLast"> </param>
		/// <returns> s </returns>
		/// <seealso cref= #joinComponents(int, boolean) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String joinComponents(final boolean skipLast)
		public virtual string joinComponents(bool skipLast)
		{
			return joinComponents(0, skipLast);
		}

		/// <summary>
		/// Returns a string with all field's components joined </summary>
		/// <param name="start"> </param>
		/// <returns> s </returns>
		/// <seealso cref= #joinComponents(int, boolean) </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String joinComponents(final int start)
		public virtual string joinComponents(int start)
		{
			return joinComponents(start, false);
		}

		/// <summary>
		/// Returns a string with all field's components joined. </summary>
		/// <returns> s </returns>
		/// <seealso cref= #joinComponents(int, boolean) </seealso>
		public virtual string joinComponents()
		{
			return joinComponents(0, false);
		}

		/// <summary>
		/// Gets a BigDecimal from a generic Number argument </summary>
		/// <param name="number"> </param>
		/// <returns> BigDecimal value of number parameter </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.math.BigDecimal getAsBigDecimal(final Number number)
		public static decimal getAsBigDecimal(Number number)
		{
			if (number is decimal)
			{
				return (decimal)number;
			}
			else if (number is long?)
			{
				return new decimal((long)((long?)number));
			}
			else if (number is int?)
			{
				return new decimal((int)((int?)number));
			}
			else if (number is short?)
			{
				return new decimal((int)((short?)number));
			}
			else if (number is double?)
			{
				return new decimal(number.ToString());
			}
			else
			{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
				throw new System.ArgumentException("class " + number.GetType().FullName + " is not supported");
			}
		}

		/// <summary>
		/// Returns the first component starting with the given prefix value or null if not found. </summary>
		/// <param name="prefix"> </param>
		/// <returns> s </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String findComponentStartingWith(final String prefix)
		public virtual string findComponentStartingWith(string prefix)
		{
			for (int i = 0; i < this.components.Count; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String c = this.components.get(i);
				string c = this.components[i];
				if (StringUtils.StartsWith(c, prefix))
				{
					return c;
				}
			}
			return null;
		}

		/// <summary>
		/// Finds the first component starting with the given codeword between slashes, and returns the component subvalue.
		/// For example, for the following field value<br>
		/// /ACC/BLABLABLA CrLf<br>
		/// //BLABLABLA CrLf<br>
		/// /INS/CITIUS33MIA CrLf<br>
		/// //BLABLABLA CrLf<br>
		/// A call to this method with parameter "INS" will return "CITIUS33MIA"
		/// </summary>
		/// <param name="codeword"> </param>
		/// <seealso cref= #findComponentStartingWith(String) </seealso>
		/// <returns> the found value or null if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getValueByCodeword(final String codeword)
		public virtual string getValueByCodeword(string codeword)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String key = "/"+codeword+"/";
			string key = "/" + codeword + "/";
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String c = findComponentStartingWith(key);
			string c = findComponentStartingWith(key);
			if (c != null)
			{
				return StringUtils.substringAfter(c, key);
			}
			return null;
		}

		/// <summary>
		/// Serializes the components into the a plain string value in SWIFT format.
		/// 
		/// <para>This method implementation is specific for each field. All not null
		/// components are appended to the result string with proper components
		/// separators like ':', slashes and CRLF.
		/// 
		/// </para>
		/// <para>For any <strong>valid</strong> field this is always true: 
		/// <code>new Field(v)).getValue() = v</code>
		/// meaning plain value integrity must be preserved after parsing the value
		/// into components and serializing it back into the plain value.
		/// Conversely this may not be true when the parsed field value is invalid 
		/// because the parser will do a best effort to gather as many valid components
		/// as possible and the serialization will also do a best effort to generate
		/// valid content.
		///  
		/// </para>
		/// </summary>
		/// <returns> SWIFT formatted value </returns>
		public abstract string Value {get;}

		/// <summary>
		/// Returns true if all field's components are blank or null </summary>
		/// <returns> true if all field's components are blank or null </returns>
		public virtual bool Empty
		{
			get
			{
				foreach (String c in Components)
				{
					if ((c != null) && StringUtils.isNotBlank(c))
					{
						return false;
					}
				}
				return true;
			}
		}

		/// <summary>
		/// Creates a Field instance for the given Tag object, using reflection.
		/// The created object is populated with parsed components data from the Tag. </summary>
		/// <param name="t"> a tag with proper name and value content </param>
		/// <returns> a specific field object, ex: Field32A. Or null if exceptions occur during object creation. </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field getField(final com.prowidesoftware.swift.model.Tag t)
		public static Field getField(Tag t)
		{
			return getField(t.Name, t.Value);
		}

		/// <summary>
		/// Creates a Field instance for the given it's name and and optional value, using reflection.
		/// </summary>
		/// <param name="name"> a proper field name, ex: 32A, 22F, 20 </param>
		/// <param name="value"> an optional field value or null to create the field with no initial content </param>
		/// <returns> a specific field object (example: Field32A) or null if exceptions occur during object creation.
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field getField(final String name, final String value)
		public static Field getField(string name, string value)
		{
			object r = null;
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Class c = Class.forName("com.prowidesoftware.swift.model.field.Field" + name);
				Type c = Type.GetType("com.prowidesoftware.swift.model.field.Field" + name);
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") final Class[] argsClass = new Class[] { String.class };
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
				Type[] argsClass = new Type[] {typeof(string)};
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") final Constructor ct = c.getConstructor(argsClass);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
				Constructor ct = c.GetConstructor(argsClass);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Object arglist[] = new Object[] { value };
				object[] arglist = new object[] {value};
				r = ct.newInstance(arglist);
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final ClassNotFoundException e)
			catch (ClassNotFoundException e)
			{
				log.log(Level.WARNING, "Field class for Field" + name + " not found. This is normally caused by an unrecognized field in the message or a malformed message block structure.", e);
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
			catch (Exception e)
			{
				log.log(Level.WARNING, "An error occurred while creating an instance of " + name, e);
			}
			return (Field) r;
		}

		/// @deprecated field labels varies depending on the specific MT and sequence, label should be retrieve using <seealso cref="#getLabel(String, String, String, Locale)"/> with proper MT and sequence identifiers 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("field labels varies depending on the specific MT and sequence, label should be retrieve using <seealso cref="#getLabel(String, String, String, Locale)"/> with proper MT and sequence identifiers") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public String getLabel()
		[Obsolete("field labels varies depending on the specific MT and sequence, label should be retrieve using <seealso cref="#getLabel(String, String, String, Locale)"/> with proper MT and sequence identifiers")]
		public virtual string Label
		{
			get
			{
				DeprecationUtils.phase3(typeof(Field), "getLabel()", "This method uses deprecated label property files. Use getLabel(String, String, String, Locale.getDefault())} with proper MT and sequence identifiers instead.");
				return getLabel(Locale.Default);
			}
		}

		/// @deprecated field labels varies depending on the specific MT and sequence, label should be retrieve using <seealso cref="#getLabel(String, String, String, Locale)"/> with proper MT and sequence identifiers 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("field labels varies depending on the specific MT and sequence, label should be retrieve using <seealso cref="#getLabel(String, String, String, Locale)"/> with proper MT and sequence identifiers") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public String getLabel(final Locale locale)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("field labels varies depending on the specific MT and sequence, label should be retrieve using <seealso cref="#getLabel(String, String, String, Locale)"/> with proper MT and sequence identifiers")]
		public virtual string getLabel(Locale locale)
		{
			DeprecationUtils.phase3(typeof(Field), "getLabel(Locale)", "This method uses deprecated label property files. Use getLabel(String, String, String, Locale)} with proper MT and sequence identifiers instead.");
			return getLabel(Name, locale);
		}

		/// @deprecated field labels varies depending on the specific MT and sequence, label should be retrieve using <seealso cref="#getLabel(String, String, String, Locale)"/> with proper MT and sequence identifiers 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("field labels varies depending on the specific MT and sequence, label should be retrieve using <seealso cref="#getLabel(String, String, String, Locale)"/> with proper MT and sequence identifiers") @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) public static String getLabel(final String fieldName, final Locale locale)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("field labels varies depending on the specific MT and sequence, label should be retrieve using <seealso cref="#getLabel(String, String, String, Locale)"/> with proper MT and sequence identifiers")]
		public static string getLabel(string fieldName, Locale locale)
		{
			DeprecationUtils.phase3(typeof(Field), "getLabel(String, Locale)", "This method uses deprecated label property files. Use getLabel(String, String, String, Locale)} with proper MT and sequence identifiers instead.");
			return _getLabel(fieldName, null, null, locale);
		}

		/*
		 * @deprecated Legacy implementation for backward compatibility
		 * This method is used only by deprecated label API, to maintain the old version of labels.
		 * 
		 * The usage of this deprecated bundle and labels API is discourage because labels are context dependent, meaning
		 * the proper label for a field depends on the MT at least, and in some occasions also depends on the particular 
		 * sequence.
		 * 
		 * The new bundles include proper names for each combination of field name, MT and sequences as needed. There are
		 * small subset of fields sharing the same naming cross MTs and cross sequences, but most of the new labels include
		 * variations per MT and in several cases per sequence.
		 */
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @ProwideDeprecated(phase4=com.prowidesoftware.deprecation.TargetYear._2019) private static String _getLabel(final String fieldName, final String mt, final String sequence, final Locale locale)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete]
		private static string _getLabel(string fieldName, string mt, string sequence, Locale locale)
		{
			const string bundle = "deprecated_labels";
			string key = null;
			string result = null;
			//try {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final ResourceBundle labels = ResourceBundle.getBundle(bundle, locale);
			ResourceBundle labels = ResourceBundle.getBundle(bundle, locale);
			if (labels != null)
			{
				if ((sequence != null) && (mt != null))
				{
					key = "field" + fieldName + "[" + mt + "][" + sequence + "].name";
					result = getString(labels, key);
					if (result == null)
					{
						key = "field" + getNumber(fieldName) + "a[" + mt + "][" + sequence + "].name";
						result = getString(labels, key);
					}
				}
				if ((result == null) && (mt != null))
				{
					key = "field" + fieldName + "[" + mt + "][" + sequence + "].name";
					result = getString(labels, key);
					if (result == null)
					{
						key = "field" + getNumber(fieldName) + "a[" + mt + "].name";
						result = getString(labels, key);
					}
				}
				if (result == null)
				{
					key = "field" + fieldName + ".name";
					result = getString(labels, key);
					if (result == null)
					{
						key = "field" + getNumber(fieldName) + "a.name";
						result = getString(labels, key);
					}
				}
				if (result == null)
				{
					key = "field" + getNumber(fieldName) + ".name";
					result = getString(labels, key);
				}
			}
			//} catch (MissingResourceException e) {
			//	e.printStackTrace();
			//}
			if (result != null)
			{
				return result;
			}
			return key;
		}

		/// <summary>
		/// Same as <seealso cref="#getLabel(String, String, String, Locale)"/> using default locale
		/// @since 7.8
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getLabel(final String fieldName, final String mt, final String sequence)
		public static string getLabel(string fieldName, string mt, string sequence)
		{
			return getLabel(fieldName, mt, sequence, Locale.Default);
		}

		/// <summary>
		/// Returns the field business description name, using resource bundle from pw_swift_labels property files.
		/// Field names may be generic for all usages, or may differ for particular letter option, message type
		/// or even sequence of a message type. The property supports all this kind of definitions with generic
		/// labels and specific ones. The following example illustrate the precedence of bundle keys that are checked for
		/// field 50:<br>
		/// <ul>
		/// <li>50K[103][B]</li>
		/// <li>50a[103][B]</li>
		/// <li>50K[103]</li>
		/// <li>50a[103]</li>
		/// <li>50K</li>
		/// <li>50a</li>
		/// <li>50</li>
		/// </ul>
		/// </summary>
		/// <param name="fieldName"> field name of the field to retrieve its label, if the combination of number and letter option
		/// is provided then a specific label is returned; is the letter option is omitted then a more generic label is returned. </param>
		/// <param name="mt"> optional indication of message type or null. </param>
		/// <param name="sequence"> optional indication of sequence or null if does not apply for the specific MT and field. </param>
		/// <param name="locale"> the locale for which a resource bundle is desired
		/// </param>
		/// <returns> a resource bundle based label for the given locale or the tag name, or the resource key if not found </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getLabel(final String fieldName, final String mt, final String sequence, final Locale locale)
		public static string getLabel(string fieldName, string mt, string sequence, Locale locale)
		{
			return _getLabel(fieldName, mt, sequence, locale, "name");
		}

		/// <summary>
		/// Similar to <seealso cref="#getLabelComponents(String, String, String, Locale)"/> but returning the components property in bundle
		/// @since 7.8.4
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getLabelComponents(final String fieldName, final String mt, final String sequence, final Locale locale)
		public static string getLabelComponents(string fieldName, string mt, string sequence, Locale locale)
		{
			Locale l = locale != null? locale : Locale.Default;
			return _getLabel(fieldName, mt, sequence, l, "components");
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static String _getLabel(final String fieldName, final String mt, final String sequence, final Locale locale, final String prop)
		private static string _getLabel(string fieldName, string mt, string sequence, Locale locale, string prop)
		{
			const string bundle = "pw_swift_labels";
			string key = null;
			string result = null;
			//try {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final ResourceBundle labels = ResourceBundle.getBundle(bundle, locale);
			ResourceBundle labels = ResourceBundle.getBundle(bundle, locale);
			if (labels != null)
			{
				if ((sequence != null) && (mt != null))
				{
					/*
					 * sequence + mt
					 */
					key = "field" + fieldName + "[" + mt + "][" + sequence + "]." + prop;
					result = getString(labels, key);
					if (result == null)
					{
						/*
						 * sequence + mt + generic letter option
						 */
						key = "field" + getNumber(fieldName) + "a[" + mt + "][" + sequence + "]." + prop;
						result = getString(labels, key);
					}
				}
				if ((result == null) && (mt != null))
				{
					/*
					 * mt only
					 */
					key = "field" + fieldName + "[" + mt + "]." + prop;
					result = getString(labels, key);
					if (result == null)
					{
						/*
						 * mt + generic letter option
						 */
						key = "field" + getNumber(fieldName) + "a[" + mt + "]." + prop;
						result = getString(labels, key);
					}
				}
				if (result == null)
				{
					/*
					 * tag only
					 */
					key = "field" + fieldName + "." + prop;
					result = getString(labels, key);
					if (result == null)
					{
						/*
						 * tag + generic letter option
						 */
						key = "field" + getNumber(fieldName) + "a." + prop;
						result = getString(labels, key);
					}
				}
				if (result == null)
				{
					/*
					 * number only
					 */
					key = "field" + getNumber(fieldName) + "." + prop;
					result = getString(labels, key);
				}
			}
			//} catch (MissingResourceException e) {
			//	e.printStackTrace();
			//}
			if (result != null)
			{
				return result;
			}
			return key;
		}

		/// <summary>
		/// Helper implementation of getString from bundle without throwing exception </summary>
		/// <param name="labels"> </param>
		/// <param name="key"> </param>
		/// <returns> the found resource or null if not found for the given key </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static String getString(final ResourceBundle labels, final String key)
		private static string getString(ResourceBundle labels, string key)
		{
			try
			{
				return labels.getString(key);
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final MissingResourceException ignored)
			catch (ssingResourceException)
			{
				return null;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static String getNumber(final String fieldName)
		private static string getNumber(string fieldName)
		{
			if (fieldName != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder sb = new StringBuilder();
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < fieldName.Length; i++)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char c = fieldName.charAt(i);
					char c = fieldName[i];
					if (char.IsDigit(c))
					{
						sb.Append(c);
					}
				}
				if (sb.Length > 0)
				{
					return sb.ToString();
				}
			}
			return null;
		}

		/// <summary>
		/// Returns the field's name composed by the field number and the letter option (if any) </summary>
		/// <returns> the static value of FieldNN.NAME </returns>
		public abstract string Name {get;}


		/// <summary>
		/// Returns the field's components pattern
		/// @since 7.8
		/// </summary>
		public abstract string componentsPattern();
		/// <summary>
		/// Returns the field's validator pattern
		/// @since 7.8
		/// </summary>
		public abstract string validatorPattern();

		public abstract bool isOptional(int component);
		public abstract bool Generic {get;}

		/// <summary>
		/// Moved to GenericField Interface
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @ProwideDeprecated(phase2=com.prowidesoftware.deprecation.TargetYear._2019) public String getDSS()
		[Obsolete]
		public virtual string DSS
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Moved to GenericField Interface
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @ProwideDeprecated(phase2=com.prowidesoftware.deprecation.TargetYear._2019) public boolean isDSSPresent()
		[Obsolete]
		public virtual bool DSSPresent
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Moved to GenericField Interface
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated @ProwideDeprecated(phase2=com.prowidesoftware.deprecation.TargetYear._2019) public String getConditionalQualifier()
		[Obsolete]
		public virtual string ConditionalQualifier
		{
			get
			{
				return null;
			}
		}

		// FIXME debido a esto: el nombre del field deberia ser validado y eliminado como atributo dinamico
		/// <summary>
		/// Return the letter option of this field as given by it classname or null if this field has no letter option
		/// </summary>
		public virtual char? letterOption()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String cn = getClass().getName();
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
			string cn = this.GetType().FullName;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final char c = cn.charAt(cn.length()-1);
			char c = cn[cn.Length - 1];
			if (char.IsLetter(c))
			{
				return c;
			}
			return null;
		}

		/// <summary>
		/// Tell if this field is of a given letter option.
		/// letter is case sensitive
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean isLetterOption(final char c)
		public virtual bool isLetterOption(char c)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Character l = letterOption();
			char? l = letterOption();
			if (l != null)
			{
				return (char)l == c;
			}
			return false;
		}

		/// @deprecated confusing name, use <seealso cref="#isNameAnyOf(String...)"/> instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("confusing name, use <seealso cref="#isNameAnyOf(String...)"/> instead") @ProwideDeprecated(phase3=com.prowidesoftware.deprecation.TargetYear._2019) public boolean isAnyOf(final String... names)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("confusing name, use <seealso cref="#isNameAnyOf(String...)"/> instead")]
		public virtual bool isAnyOf(params string[] names)
		{
			DeprecationUtils.phase2(this.GetType(), "isAnyOf(String...)", "Use isNameAnyOf(String...) instead.");
			return isNameAnyOf(names);
		}

		/// <summary>
		/// Compares the this fields's name with a list of names to check </summary>
		/// <param name="names"> must not be null nor empty </param>
		/// <returns> true if this field names equals one in the list of names and false otherwise </returns>
		/// <exception cref="IllegalArgumentException"> if names is null or empty </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean isNameAnyOf(final String... names)
		public virtual bool isNameAnyOf(params string[] names)
		{
			Validate.isTrue(names != null && names.Length > 0, "name list must have at least one element");
			foreach (String n in names)
			{
				if (StringUtils.Equals(Name, n))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Compares this field component 1 with the parameter value
		/// <br>
		/// Same as <code>is(1, compare)</code>
		/// <br>
		/// If the field has only one component this is the same as comparing against field value </summary>
		/// <param name="compare"> string to compare </param>
		/// <returns> true if the first component is equal to the parameter </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean is(final String compare)
		public virtual bool @is(string compare)
		{
			return StringUtils.Equals(compare, getComponent(1));
		}
		/// <summary>
		/// Compares a specific component with the parameter value </summary>
		/// <param name="componentNumber"> component number 1-based </param>
		/// <param name="compare"> string to compare </param>
		/// <returns> true if the indicated component value is equal to the parameter </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean is(final int componentNumber, final String compare)
		public virtual bool @is(int componentNumber, string compare)
		{
			return StringUtils.Equals(compare, getComponent(componentNumber));
		}

		/// <summary>
		/// Compares this field components 1 and 2 with the parameter values. </summary>
		/// <param name="compare1"> string to compare with component 1 </param>
		/// <param name="compare2"> string to compare with component 2 </param>
		/// <returns> true if components 1 and 2 are equal the parameter values respectively </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean is(final String compare1, final String compare2)
		public virtual bool @is(string compare1, string compare2)
		{
			return StringUtils.Equals(compare1, getComponent(1)) && StringUtils.Equals(compare2, getComponent(2));
		}

		/// <summary>
		/// Compares this field component 1 with the parameter values.
		/// <br>
		/// If the field has only one component this is the same as comparing against the field value </summary>
		/// <param name="values"> the values to compare </param>
		/// <returns> true if the first component is equal to any of the given values
		/// @since 7.9.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public boolean is(final String... values)
		public virtual bool @is(params string[] values)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String comp1 = getComponent(1);
			string comp1 = getComponent(1);
			if (values != null)
			{
				foreach (string value in values)
				{
					if (StringUtils.Equals(comp1, value))
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Get the generic tag object of this field.
		/// </summary>
		public virtual Tag asTag()
		{
			return new Tag(Name, Value);
		}

		/// <summary>
		/// Returns the defined amount of components.<br>
		/// This is not the amount of components present in the field instance, but the total amount of components
		/// that this field accepts as defined.
		/// </summary>
		public abstract int componentsSize();

		/// <summary>
		/// Base implementation for subclasses getLine API.
		/// 
		/// Notice that line instance numbers are static and relevant to the
		/// field components definition, and not relative to the particular
		/// instance value. For example field 35B Line[1] will be the line with the
		/// ISIN number, regardless of the ISIN number present or not in the particular
		/// field instance. If that ISIN line is not present in the parameter field,
		/// the method will return null.<br><br>
		/// 
		/// Also notice that a line may be composed by several components, there is
		/// no linear relation between component numbers and lines numbers.<br>
		/// </summary>
		/// <param name="cp"> a copy of the subclass (this object is altered during method execution) </param>
		/// <param name="start"> a reference to a specific line in the field, first line being 1; if null returns all found lines. </param>
		/// <param name="end"> a reference to a specific line in the field, first line being 1; if null returns all found lines. </param>
		/// <param name="offset"> an optional component number used as offset when counting lines </param>
		/// <returns> found line content or null </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected String getLine(final Field cp, final Integer start, final Integer end, final int offset)
		protected internal virtual string getLine(Field cp, int? start, int? end, int offset)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String hash = UUID.randomUUID().toString();
			string hash = UUID.randomUUID().ToString();
			for (int i = 1; i <= componentsSize(); i++)
			{
				if (i < offset)
				{
					/*
					 * blank fields below the offset
					 */
					cp.setComponent(i, null);
				}
				else if (getComponent(i) == null)
				{
					/*
					 * fill empty components above offset
					 */
					cp.setComponent(i, hash);
				}
			}

			/*
			 * get all meaningful lines from value
			 */
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<String> lines = new ArrayList<>();
			IList<string> lines = new List<string>();
			foreach (String l in SwiftParseUtils.getLines(cp.Value))
			{
				if (StringUtils.isNotEmpty(l) && !onlySlashes(l))
				{
					lines.Add(l);
				}
			}

			/*
			 * if the query includes a component offset above 1, we remove meaningless prefix separators from result.
			 */
			bool removeSeparators = offset > 1;
			if (start != null)
			{
				if (lines.Count >= start)
				{
					if (end != null)
					{
						if (end >= start)
						{
							int? trimmedEnd = end;
							if (end > lines.Count)
							{
								trimmedEnd = lines.Count - 1;
							}
							/*
							 * return line subset
							 */
							return asString(hash, lines.subList(start - 1, trimmedEnd), removeSeparators);
						}
						else
						{
							log.warning("invalid lines range [" + start + "-" + end + "] the ending line number (" + end + ") must be greater or equal to the starting line number (" + start + ")");
						}
					}
					else
					{
						/*
						 * return a single line
						 */
						return clean(hash, lines[start - 1], removeSeparators);
					}
				}
			}
			else
			{
				/*
				 * return all lines from offset
				 */
				return asString(hash, lines, removeSeparators);
			}
			return null;
		}

		/// <summary>
		/// Returns true if the value only contains '/' characters
		/// (one or many but only that character)
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private boolean onlySlashes(final String value)
		private bool onlySlashes(string value)
		{
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i] != '/')
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Creates a string from the list of lines, replacing the hash by blank, and ignoring empty lines </summary>
		/// <param name="hash"> hash used during getLine process </param>
		/// <param name="list"> list of lines </param>
		/// <param name="removeSeparators"> true to remove meaningless prefix separators, </param>
		/// <returns> a string with the final, cleaned, joined lines </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String asString(final String hash, final List<String> list, boolean removeSeparators)
		private string asString(string hash, IList<string> list, bool removeSeparators)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder result = new StringBuilder();
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String l = list.get(i);
				string l = list[i];
				bool b = i == 0? removeSeparators : false; //remove prefix only for first line
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String trimmed = clean(hash, l, b);
				string trimmed = clean(hash, l, b);
				if (trimmed != null)
				{
					if (result.Length > 0)
					{
						result.Append(FINWriterVisitor.SWIFT_EOL);
					}
					result.Append(trimmed);
				}
			}
			if (result.Length == 0)
			{
				return null;
			}
			else
			{
				return result.ToString();
			}
		}

		/// <summary>
		/// Replaces the hash by empty and trims to null.<br>
		/// 
		/// It also can remove meaningless component separators (If the resulting string only
		/// contains the component separator "/", or starts with ":" or starts with "/" separators
		/// all of them will also be removed).
		/// </summary>
		/// <param name="hash"> hash string used by the get lines method </param>
		/// <param name="value"> current value to clean </param>
		/// <param name="removeSeparators"> if true, meaningless starting separators (: and /) are removed </param>
		/// <returns> proper final line value or null if the original field didn't contained content for such line </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String clean(final String hash, final String value, boolean removeSeparators)
		private string clean(string hash, string value, bool removeSeparators)
		{
			/*
			 * try to replace /hash first just in case the component is optional
			 * then replace the hash only if present
			 */
			string trimmed = StringUtils.trimToNull(StringUtils.replace(StringUtils.replace(value, "/" + hash, ""), hash, ""));
			if (trimmed != null && !onlySlashes(trimmed))
			{
				/*
				 * sebastian Oct 2015
				 * La logica para remover separadores debiera depender de si el offset
				 * abarca la linea entera o si el componente del offset esta en al mitad 
				 * de una linea, y removerlo solo en este ultimo caso.
				 * Esto es dificil de implementar porque no esta modelada la relacion
				 * entre componentes y lineas.
				 * Por lo tanto de momento se deja el parametro removeSeparators pero
				 * con el codigo de aca abajo comentado. Y se coloca a cambio el patch
				 * para el caso especifico de :// que es el que aparentemente no esta
				 * contemplado segun los test.
				 * 
				if (removeSeparators) {
					for (int i = 0; i < trimmed.length(); i++) {
						char c = trimmed.charAt(i);
						if (c != ':' && c != '/') {
							return trimmed.substring(i);
						}
					}
				} else {
					return trimmed;
				}
				*/
				if (trimmed.StartsWith("://", StringComparison.Ordinal))
				{
					return StringUtils.substringAfter(trimmed, "://");
				}
				else if (removeSeparators && (trimmed.StartsWith(":", StringComparison.Ordinal) || trimmed.StartsWith("/", StringComparison.Ordinal)))
				{
					return StringUtils.trimToNull(StringUtils.Substring(trimmed, 1 - trimmed));
				}
				else
				{
					return trimmed;
				}
			}
			/*
			 * otherwise return null
			 */
			return null;
		}

		/// <summary>
		/// Returns true if the field name is valid. 
		/// Valid field names are for example: 20, 20C, 108 </summary>
		/// <param name="name"> a field name to validate </param>
		/// <returns> true if valid, false otherwise
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static boolean validName(final String name)
		public static bool validName(string name)
		{
			if (name == null)
			{
				return false;
			}
			if (name.Length < 2 || name.Length > 3)
			{
				//log.warning("field name must be present and have 2 or 3 characters length and found: "+field);
				return false;
			}
			if (!StringUtils.isNumeric(name.Substring(0, 2)))
			{
				//log.warning("field name should start with a numeric prefix and found: "+field.substring(0, 2));
				return false;
			}
			if ((name.Length == 3 && !(char.IsDigit(name[2]) || name[2] == 'a' || char.IsUpper(name[2]))))
			{
				//log.warning("letter option if present should be a single capital letter or an 'a' for all letter options, and found: "+field.charAt(2));
				return false;
			}
			return true;
		}

		/// <summary>
		/// Returns english label for components.
		/// <br>
		/// The index in the list is in sync with specific field component structure. </summary>
		/// <seealso cref= #getComponentLabel(int)
		/// @since 7.8.4 </seealso>
		protected internal abstract IList<string> ComponentLabels {get;}

		/// <summary>
		/// Returns english label for the component.
		/// <br> </summary>
		/// <param name="number"> one-based index of component, first component of a field should be number one </param>
		/// <returns> found label or null if it is not defined
		/// @since 7.8.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getComponentLabel(final int number)
		public virtual string getComponentLabel(int number)
		{
			//internal position index is zero based
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int position = number - 1;
			int position = number - 1;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final List<String> labels = getComponentLabels();
			IList<string> labels = ComponentLabels;
			if (labels != null)
			{
				if ((position >= 0) && (position < labels.Count))
				{
					return labels[position];
				}
			}
			return null;
		}

		/// <summary>
		/// Returns a mapping between component numbers and their label in camel case format.
		/// @since 7.10.3
		/// </summary>
		protected internal abstract IDictionary<int?, string> ComponentMap {get;}

		/// <summary>
		/// Returns english label for the component in camel case format.
		/// <br> </summary>
		/// <param name="number"> one-based index of component, first component of a field should be number one </param>
		/// <returns> found label or <code>null</code> if it is not defined
		/// @since 7.10.3 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String getComponentLabelCamelCase(final int number)
		private string getComponentLabelCamelCase(int number)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Map<Integer, String> labels = getComponentMap();
			IDictionary<int?, string> labels = ComponentMap;
			if (labels != null)
			{
				if (number >= 0)
				{
					return labels[number];
				}
			}
			return null;
		}

		/// <summary>
		/// Ensures a not-null locale parameter. </summary>
		/// <param name="locale"> a locale or null </param>
		/// <returns> the parameter locale if it is not null or the default locale
		/// @since 7.8.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected final Locale notNull(final Locale locale)
		protected internal Locale notNull(Locale locale)
		{
			if (locale != null)
			{
				return locale;
			}
			else
			{
				return Locale.Default;
			}
		}


		/// <summary>
		/// Appends a not null field component to the builder.
		/// <br>
		/// This helper method is used by subclasses implementation of <seealso cref="#getValue()"/>
		/// </summary>
		/// <param name="result"> string where component content is appended </param>
		/// <param name="component"> component number
		/// @since 7.9.3 </param>
		protected internal virtual void append(StringBuilder result, int component)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String value = getComponent(component);
			string value = getComponent(component);
			if (value != null && result != null)
			{
				result.Append(value);
			}
		}

		/*
		 * TO DO: 
		 * this will take the result of getLabelComponents
		 * and use that as key to access bundle with translations.
		 * For example Name And Address will be name-and-address key
		 * in resource bundle
		 */
		//public abstract List<String> getComponentLabels(Locale locale);
		//public String getComponentLabel(Locale locale);

		/// <summary>
		/// Get a json representation of this message with expanded fields content.
		/// <para>
		/// The JSON representation for fields contains the field name and the components with camel case labels, for example:
		/// <pre>{"name":"32A","date":"010203","currency":"USD","amount":"123"}</pre>
		/// 
		/// @since 7.10.3
		/// </para>
		/// </summary>
		public virtual string toJson()
		{
			JsonObject field = new JsonObject();
			field.addProperty("name", this.Name);
			for (int i = 1; i <= this.Components.Count; i++)
			{
				if (this.getComponent(i) != null)
				{
					string label = this.getComponentLabelCamelCase(i);
					if (label == null)
					{
						label = "value";
					}
					field.addProperty(label, this.getComponent(i));
				}
			}
			return field.ToString();
		}

		/// <summary>
		/// Creates a specific field instance from its JSON representation.
		/// 
		/// <para>The implementation reads the "name" property in the JSON data, then calls the fromJson method in the specific
		/// Field subclass
		/// 
		/// </para>
		/// </summary>
		/// <returns> a specific field, for example Field32A, or null if the JSON data is not well-formed or contains an unrecognized field name </returns>
		/// <seealso cref= #toJson() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Field fromJson(final String json)
		public static Field fromJson(string json)
		{
			JsonParser parser = new JsonParser();
			JsonObject jsonObject = (JsonObject) parser.parse(json);
			JsonElement nameElement = jsonObject.get("name");
			if (nameElement != null)
			{
				string name = nameElement.AsString;
				object r = null;
				try
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Class c = Class.forName("com.prowidesoftware.swift.model.field.Field" + name);
					Type c = Type.GetType("com.prowidesoftware.swift.model.field.Field" + name);
					Method method = c.GetMethod("fromJson", typeof(string));
					return (Field) method.invoke(null, json);
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final ClassNotFoundException e)
				catch (ClassNotFoundException e)
				{
					log.log(Level.WARNING, "Field class for Field" + name + " not found. This is normally caused by an unrecognized field in the message or a malformed message block structure.", e);
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception e)
				catch (Exception e)
				{
					log.log(Level.WARNING, "An error occured while creating an instance of " + name, e);
				}
				return (Field) r;
			}
			return null;
		}

	}
}