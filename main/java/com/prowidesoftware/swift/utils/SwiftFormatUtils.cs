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
namespace com.prowidesoftware.swift.utils
{

	using BIC = com.prowidesoftware.swift.model.BIC;
	using LogicalTerminalAddress = com.prowidesoftware.swift.model.LogicalTerminalAddress;
	using MIR = com.prowidesoftware.swift.model.MIR;
	using MOR = com.prowidesoftware.swift.model.MOR;
	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;
	using StringUtils = org.apache.commons.lang3.StringUtils;
	using DateFormatUtils = org.apache.commons.lang3.time.DateFormatUtils;


	using StringUtils = org.apache.commons.lang3.StringUtils;
	using DateFormatUtils = org.apache.commons.lang3.time.DateFormatUtils;

	using BIC = com.prowidesoftware.swift.model.BIC;
	using LogicalTerminalAddress = com.prowidesoftware.swift.model.LogicalTerminalAddress;
	using MIR = com.prowidesoftware.swift.model.MIR;
	using MOR = com.prowidesoftware.swift.model.MOR;

	/// <summary>
	/// This class provides methods to convert field components to objects.
	/// It handles for example; dates, currencies and general functions defined in the SWIFT standard.
	/// <ul>
	/// 		<li>DATE1 MMDD</li>
	/// 		<li>DATE2 YYMMDD</li>
	/// 		<li>DATE3 YYMM</li>
	/// 		<li>DATE4 YYYYMMDD</li>
	/// 		<li>YEAR YYYY</li>
	/// 		<li>AMOUNT ###,### (digits with comma as decimal separator)</li>
	/// 		<li>TIME2 HHmmss</li>
	/// 		<li>TIME3 HH[mm]</li>
	/// 		<li>BOOL Y/N</li>
	/// 		<li>DATETIME YYYYMMDDHHMM</li>
	/// 		<li>DATETIME with short year YYMMDDHHMM</li>
	/// 		<li>DAYTIME DDHHMM</li>
	/// 		<li>MONTHDAY MMDD</li>
	/// 		<li>MIR</li>
	/// 		<li>MOR</li>
	/// </ul>
	/// 
	/// @author www.prowidesoftware.com
	/// @since 6.0
	/// </summary>
	public class SwiftFormatUtils
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftFormatUtils).FullName);

		// Suppress default constructor for noninstantiability
		private SwiftFormatUtils()
		{
			throw new AssertionError();
		}

		/// <summary>
		/// Parses a DATE2 string (accept dates in format YYMMDD) into a Calendar object. </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getDate2(final String strDate)
		public static DateTime getDate2(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 6))
			{
				return getCalendar(strDate, "yyMMdd");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a DATE2 string. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getDate2(final java.util.Calendar date)
		public static string getDate2(DateTime date)
		{
			return getCalendar(date, "yyMMdd");
		}

		/// <summary>
		/// Parses a DATE1 string (accept dates in format MMDD) into a Calendar object. </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getDate1(final String strDate)
		public static DateTime getDate1(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 4))
			{
				return getCalendar(strDate, "MMdd");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// returns true if the the current year is a leap year
		/// @since 7.8.8
		/// </summary>
		public static bool LeapYear
		{
			get
			{
				return new DateTime().getActualMaximum(DateTime.DAY_OF_YEAR) > 365;
			}
		}

		/// <summary>
		/// returns true if the parameter year is a leap year
		/// @since 7.8.8
		/// </summary>
		public static bool isLeapYear(int year)
		{
			DateTime cal = new DateTime();
			cal.set(DateTime.YEAR, year);
			return cal.getActualMaximum(DateTime.DAY_OF_YEAR) > 365;
		}

		/// <summary>
		/// Parses a Calendar object into a DATE1 string.
		/// For February 29 it will return null if current year is not a leap year </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null
		/// @since 6.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getDate1(final java.util.Calendar date)
		public static string getDate1(DateTime date)
		{
			return getCalendar(date, "MMdd");
		}

		/// <summary>
		/// Parses a DATE3 string (accept dates in format YYMM) into a Calendar object. </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getDate3(final String strDate)
		public static DateTime getDate3(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 4))
			{
				return getCalendar(strDate, "yyMM");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a DATE1 string. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null
		/// @since 6.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getDate3(final java.util.Calendar date)
		public static string getDate3(DateTime date)
		{
			return getCalendar(date, "yyMM");
		}

		/// <summary>
		/// Parses a DATE4 string (accept dates in format YYYYMMDD) into a Calendar object. </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getDate4(final String strDate)
		public static DateTime getDate4(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 8))
			{
				return getCalendar(strDate, "yyyyMMdd");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a DATE1 string. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null
		/// @since 6.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getDate4(final java.util.Calendar date)
		public static string getDate4(DateTime date)
		{
			return getCalendar(date, "yyyyMMdd");
		}

		/// <summary>
		/// Parses a YEAR string (accept dates in format YYYY) into a Calendar object. </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getYear(final String strDate)
		public static DateTime getYear(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 4))
			{
				return getCalendar(strDate, "yyyy");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a YYYY string. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null
		/// @since 6.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getYear(final java.util.Calendar date)
		public static string getYear(DateTime date)
		{
			return getCalendar(date, "yyyy");
		}

		/// <summary>
		/// Parses a value into a java Number (BigDecimal) using the comma for decimal separator. </summary>
		/// <param name="amount"> to parse </param>
		/// <returns> Number of the parsed amount or null if the number could not be parsed </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Number getNumber(final String amount)
		public static Number getNumber(string amount)
		{
			Number number = null;
			if (amount != null)
			{
				try
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.text.DecimalFormatSymbols symbols = new java.text.DecimalFormatSymbols();
					DecimalFormatSymbols symbols = new DecimalFormatSymbols();
					symbols.DecimalSeparator = ',';
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.text.DecimalFormat df = new java.text.DecimalFormat("00.##", symbols);
					DecimalFormat df = new DecimalFormat("00.##", symbols);
					df.ParseBigDecimal = true;
					number = df.parse(amount);
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final java.text.ParseException e)
				catch (ParseException e)
				{
					log.log(java.util.logging.Level.WARNING, "Error parsing number", e);
				}
			}
			return number;
		}

		/// <summary>
		/// Parses a Number into a SWIFT string number ####,## with truncated zero decimals and mandatory decimal separator.
		/// <ul>
		/// 	<li>Example: 1234.00 -&gt; 1234,</li>
		/// 	<li>Example: 1234 -&gt; 1234,</li>
		/// 	<li>Example: 1234.56 -&gt; 1234,56</li>
		/// </ul> </summary>
		/// <param name="number"> to parse </param>
		/// <returns> Number of the parsed amount or null if the number is null </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getNumber(final Number number)
		public static string getNumber(Number number)
		{
			if (number != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.text.DecimalFormatSymbols symbols = new java.text.DecimalFormatSymbols();
				DecimalFormatSymbols symbols = new DecimalFormatSymbols();
				symbols.DecimalSeparator = ',';
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.text.DecimalFormat df = new java.text.DecimalFormat("0.##########", symbols);
				DecimalFormat df = new DecimalFormat("0.##########", symbols);
				df.ParseBigDecimal = true;
				df.DecimalSeparatorAlwaysShown = true;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String formatted = df.format(number);
				string formatted = df.format(number);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String result = org.apache.commons.lang3.StringUtils.replaceChars(formatted, '.', ',');
				string result = StringUtils.replaceChars(formatted, '.', ',');
				return result;
			}
			return null;
		}

		/// <summary>
		/// Converts the given time into a Calendar.
		/// Only the time information is set, the date will be the default 1/1/70 </summary>
		/// <param name="hhmm"> hour and minutes </param>
		/// <returns> a Calendar set with the given hour and minutes </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getHhmm(final String hhmm)
		public static DateTime getHhmm(string hhmm)
		{
			if ((hhmm != null) && (hhmm.Length == 4))
			{
				return getCalendar(hhmm, "HHmm");
			}
			else
			{
				return null;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static java.util.Calendar getCalendar(final String value, final String format)
		private static DateTime getCalendar(string value, string format)
		{
			if (value != null)
			{
				try
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.text.SimpleDateFormat sdf = new java.text.SimpleDateFormat(format);
					SimpleDateFormat sdf = new SimpleDateFormat(format);
					sdf.Lenient = false;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Date d = sdf.parse(value);
					DateTime d = sdf.parse(value);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Calendar cal = new java.util.GregorianCalendar();
					DateTime cal = new GregorianCalendar();
					cal = new DateTime(d);
					return cal;
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final java.text.ParseException e)
				catch (va.text.ParseException)
				{
					log.log(java.util.logging.Level.WARNING, "Could not parse '" + value + "' with pattern '" + format + "'");
				}
			}
			return null;
		}

		/// <summary>
		/// @since 6.4
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static String getCalendar(final java.util.Calendar date, final String format)
		private static string getCalendar(DateTime date, string format)
		{
			if (date != null)
			{
				return DateFormatUtils.format(date.Ticks, format);
			}
			return null;
		}

		/// <summary>
		/// Converts the given time into a Calendar.
		/// Only the time information is set, the date will be the default 1/1/70 </summary>
		/// <param name="hhmmss"> hour, minutes and seconds </param>
		/// <returns> a Calendar set with the given hour, minutes and seconds </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getTime2(final String hhmmss)
		public static DateTime getTime2(string hhmmss)
		{
			if ((hhmmss != null) && (hhmmss.Length == 6))
			{
				return getCalendar(hhmmss, "HHmmss");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a TIME2 string. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed time or null if the calendar is null
		/// @since 6.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTime2(final java.util.Calendar date)
		public static string getTime2(DateTime date)
		{
			return getCalendar(date, "HHmmss");
		}

		/// <summary>
		/// Converts the given time into a Calendar.
		/// Only the time information is set, the date will be the default 1/1/70 </summary>
		/// <param name="hhmmss"> hour, minutes and seconds </param>
		/// <returns> a Calendar set with the given hour, or and hour and minutes </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getTime3(final String hhmmss)
		public static DateTime getTime3(string hhmmss)
		{
			if (hhmmss != null)
			{
				if (hhmmss.Length == 2)
				{
					return getCalendar(hhmmss, "HH");
				}
				else if (hhmmss.Length == 4)
				{
					return getCalendar(hhmmss, "HHmm");
				}
			}
			return null;
		}

		/// <summary>
		/// Parses a Calendar object into a TIME3 string. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed time or null if the calendar is null
		/// @since 6.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getTime3(final java.util.Calendar date)
		public static string getTime3(DateTime date)
		{
			return getCalendar(date, "HHmm");
		}

		/// <param name="string"> with a single character </param>
		/// <returns> the Character for the given string </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Character getSign(final String string)
		public static char? getSign(string @string)
		{
			if (StringUtils.isNotEmpty(@string))
			{
				return Convert.ToChar(@string[0]);
			}
			return null;
		}

		/// <param name="string"> with an offset </param>
		/// <returns> a Calendar set with hour and minutes from the offset </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getOffset(final String string)
		public static DateTime getOffset(string @string)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Calendar result = getHhmm(string);
			DateTime result = getHhmm(@string);
			return result;
		}

		/// <summary>
		/// Parses a Calendar object into a offset string. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed time or null if the calendar is null
		/// @since 6.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getOffset(final java.util.Calendar date)
		public static string getOffset(DateTime date)
		{
			return getCalendar(date, "HHmm");
		}

		/// <summary>
		/// Returns the <code>Currency</code> instance for the given currency code. </summary>
		/// <param name="code"> string with a currency code </param>
		/// <returns> a Currency initialized from the parameter code or null if parameter code is null </returns>
		/// <exception cref="IllegalArgumentException"> if currencyCode is not a supported ISO 4217 code. </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Currency getCurrency(final String code)
		public static Currency getCurrency(string code)
		{
			if (code != null)
			{
				return Currency.getInstance(code);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the currency code from the parameter Currency. </summary>
		/// <param name="currency"> Currency to use </param>
		/// <returns> the string with the currency code
		/// @since 6.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getCurrency(final java.util.Currency currency)
		public static string getCurrency(Currency currency)
		{
			return currency.CurrencyCode;
		}

		/// <param name="code"> string with a BIC code </param>
		/// <returns> a BIC initialized from the parameter code </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.BIC getBIC(final String code)
		public static BIC getBIC(string code)
		{
			return new BIC(code);
		}

		/// <summary>
		/// Gets the code from the parameter BIC.
		/// If branch is present, returns a BIC11, otherwise returns a BIC8. </summary>
		/// <param name="bic"> BIC to use </param>
		/// <returns> the string with the BIC code
		/// @since 6.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getBIC(final com.prowidesoftware.swift.model.BIC bic)
		public static string getBIC(BIC bic)
		{
			if (StringUtils.isBlank(bic.Branch))
			{
				return bic.Bic8;
			}
			else
			{
				return bic.Bic11;
			}
		}

		/// <summary>
		/// Gets the given string as boolean. </summary>
		/// <param name="string"> code to use where the expected values are "Y" or "N" </param>
		/// <returns> true for "Y", false for "N", and null otherwise
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static Boolean getBoolean(final String string)
		public static bool? getBoolean(string @string)
		{
			if (StringUtils.Equals("Y", @string))
			{
				return true;
			}
			else if (StringUtils.Equals("N", @string))
			{
				return false;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Boolean object into a string. </summary>
		/// <param name="bool"> Boolean to parse </param>
		/// <returns> parsed boolean converted to "Y" or "N" or null if the boolean object is null
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getBoolean(final Boolean bool)
		public static string getBoolean(bool? @bool)
		{
			if (@bool == null)
			{
				return null;
			}
			return @bool? "Y": "N";
		}

		/// <summary>
		/// Parses a DATETIME string (accepts dates with time in YYYYMMDDHHMM format) into a Calendar object. </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getDateTime(final String strDate)
		public static DateTime getDateTime(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 12))
			{
				return getCalendar(strDate, "yyyyMMddHHmm");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a string containing the DATETIME with YYYYMMDDHHMM format. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getDateTime(final java.util.Calendar date)
		public static string getDateTime(DateTime date)
		{
			return getCalendar(date, "yyyyMMddHHmm");
		}

		/// <summary>
		/// Parses a DATETIME with short year string (accepts dates with time in YYMMDDHHMM format) into a Calendar object. </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getDateTimeShortYear(final String strDate)
		public static DateTime getDateTimeShortYear(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 10))
			{
				return getCalendar(strDate, "yyMMddHHmm");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a DATETIME with short year string in YYMMDDHHMM format. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getDateTimeShortYear(final java.util.Calendar date)
		public static string getDateTimeShortYear(DateTime date)
		{
			return getCalendar(date, "yyMMddHHmm");
		}

		/// <summary>
		/// Parses a DAYTIME string (accepts dates with time in DDHHMM format) into a Calendar object. </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getDayTime(final String strDate)
		public static DateTime getDayTime(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 6))
			{
				return getCalendar(strDate, "ddHHmm");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a string containing the DAYTIME in DDHHMM format. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getDayTime(final java.util.Calendar date)
		public static string getDayTime(DateTime date)
		{
			return getCalendar(date, "ddHHmm");
		}

		/// <summary>
		/// Parses a MONTHDAY string (accepts dates in MMDD format) into a Calendar object.
		/// Only the month information is set, the date and year will be the Calendar default </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getMonthDay(final String strDate)
		public static DateTime getMonthDay(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 4))
			{
				return getCalendar(strDate, "MMdd");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a string containing MONTHDAY in MMDD format. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getMonthDay(final java.util.Calendar date)
		public static string getMonthDay(DateTime date)
		{
			return getCalendar(date, "MMdd");
		}

		/// <summary>
		/// Parses an HOUR string (accepts time in HH format) into a Calendar object. </summary>
		/// <param name="strDate"> string to parse </param>
		/// <returns> parsed date or null if the argument did not matched the expected date format
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static java.util.Calendar getHour(final String strDate)
		public static DateTime getHour(string strDate)
		{
			if ((strDate != null) && (strDate.Length == 2))
			{
				return getCalendar(strDate, "HH");
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a Calendar object into a string containing the HOUR in HH format. </summary>
		/// <param name="date"> Calendar to parse </param>
		/// <returns> parsed date or null if the calendar is null
		/// @since 7.4 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getHour(final java.util.Calendar date)
		public static string getHour(DateTime date)
		{
			return getCalendar(date, "HH");
		}

		/// <summary>
		/// Parses a string value into a MIR object. </summary>
		/// <param name="value"> string containing the complete MIR value </param>
		/// <returns> a MIR object containing the parsed data or null if the argument is not a 28 length string with a proper MIR data </returns>
		/// <seealso cref= com.prowidesoftware.swift.model.MIR </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.MIR getMIR(final String value)
		public static MIR getMIR(string value)
		{
			if (value != null && value.Length == 28)
			{
				return new MIR(value);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a MIR object into a string containing its serialized data. </summary>
		/// <param name="mir"> MIR to process </param>
		/// <returns> serialized content of the MIR object or null if the parameter is empty or null
		/// @since 7.4 </returns>
		/// <seealso cref= MIR#getMIR() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getMIR(final com.prowidesoftware.swift.model.MIR mir)
		public static string getMIR(MIR mir)
		{
			if (mir != null)
			{
				return mir.MIR;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a string value into a MOR object. </summary>
		/// <param name="value"> string containing the complete MOR value </param>
		/// <returns> a MOR object containing the parsed data or null if the argument is not a 28 length string with a proper MOR data </returns>
		/// <seealso cref= com.prowidesoftware.swift.model.MOR </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static com.prowidesoftware.swift.model.MOR getMOR(final String value)
		public static MOR getMOR(string value)
		{
			if (value != null && value.Length == 28)
			{
				return new MOR(value);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Parses a MOR object into a string containing its serialized data. </summary>
		/// <param name="mor"> MOR to process </param>
		/// <returns> serialized content of the MOR object or null if the parameter is empty or null
		/// @since 7.4 </returns>
		/// <seealso cref= MOR#getMOR() </seealso>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static String getMOR(final com.prowidesoftware.swift.model.MOR mor)
		public static string getMOR(MOR mor)
		{
			if (mor != null)
			{
				return mor.MOR;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Tell if <code>string</code> is a valid currency code using Currency isntances from Java </summary>
		/// <param name="string"> the string to test for a currency code </param>
		/// <returns> true if string is a valid currency code and false in other case, including null and empty </returns>
		/// @deprecated use IsoUtils#isValidISOCurrency(String) instead 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("use IsoUtils#isValidISOCurrency(String) instead") @ProwideDeprecated(phase2=com.prowidesoftware.deprecation.TargetYear._2019) public static boolean isCurrency(final String string)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		[Obsolete("use IsoUtils#isValidISOCurrency(String) instead")]
		public static bool isCurrency(string @string)
		{
			if (StringUtils.isNotBlank(@string))
			{
				try
				{
					return Currency.getInstance(@string) != null;
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final Exception ignored)
				catch (ception)
				{
				}
			}
			return false;
		}

		/// <summary>
		/// Return the number of decimals for a string with a swift formatted amount.
		/// </summary>
		/// <param name="amountString"> may be null or empty, in which case this method returns 0 </param>
		/// <returns> the number of digits after the last , or 0 in any other case.
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int decimalsInAmount(final String amountString)
		public static int decimalsInAmount(string amountString)
		{
			if (StringUtils.isNotEmpty(amountString))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String tail = org.apache.commons.lang3.StringUtils.trim(org.apache.commons.lang3.StringUtils.substringAfterLast(amountString, ","));
				string tail = StringUtils.Trim(StringUtils.substringAfterLast(amountString, ","));
				return tail.Length;
			}
			return 0;
		}

		/// <summary>
		/// Return the number of decimals for the given number, which can be null, in which case this method returns zero.
		/// </summary>
		/// <returns> the number of decimal in the number or zero if there are none or the amount is null
		/// @since 7.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static int decimalsInAmount(final java.math.BigDecimal amount)
		public static int decimalsInAmount(decimal amount)
		{
			if (amount != null)
			{
				decimal d = new decimal(amount.ToString());
				decimal result = d - d.setScale(0, RoundingMode.FLOOR).movePointRight(d.scale());
				if ((int)result != 0)
				{
					return result.ToString().Length;
				}
			}
			return 0;
		}

		/// <param name="address"> string with a LT identifier code (12 chars) composed by the
		/// BIC, LT identifier and branch. </param>
		/// <returns> a LT address initialized from the parameter code
		/// @since 7.8.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static final com.prowidesoftware.swift.model.LogicalTerminalAddress getLTAddress(final String address)
		public static LogicalTerminalAddress getLTAddress(string address)
		{
			return new LogicalTerminalAddress(address);
		}

		/// <summary>
		/// Gets the code from the parameter LogicalTerminalAddress.
		/// If the address is not complete, it will be filled with default values
		/// using <seealso cref="LogicalTerminalAddress#getSenderLogicalTerminalAddress()"/> </summary>
		/// <param name="address"> LT address to use </param>
		/// <returns> the string with the full 12 characters long LT identifier
		/// @since 7.8.8 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public static final String getLTAddress(final com.prowidesoftware.swift.model.LogicalTerminalAddress address)
		public static string getLTAddress(LogicalTerminalAddress address)
		{
			return address.SenderLogicalTerminalAddress;
		}
	}

}