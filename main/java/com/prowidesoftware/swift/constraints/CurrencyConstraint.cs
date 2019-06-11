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
namespace com.prowidesoftware.swift.constraints
{


	/// <summary>
	/// Bean validation for ISO currency codes.
	/// 
	/// <para><p>It will validate true for null, empty or blank values to bypass validation when
	/// the field is optional. If you require a currency code to be mandatory, combine this
	/// constraint with @NotBlank.
	/// 
	/// </para>
	/// </summary>
	/// <seealso cref= com.prowidesoftware.swift.utils.IsoUtils#isValidISOCurrency(String) for implementation details
	/// @since 7.10.3 </seealso>
//JAVA TO C# CONVERTER TODO TASK: There is no attribute target in .NET corresponding to METHOD:
//ORIGINAL LINE: @Documented @Constraint(validatedBy = CurrencyValidator.class) @Target({ METHOD, FIELD, PARAMETER }) @Retention(RetentionPolicy.RUNTIME) public class CurrencyConstraint extends System.Attribute
//JAVA TO C# CONVERTER TODO TASK: There is no attribute target in .NET corresponding to FIELD:
//JAVA TO C# CONVERTER TODO TASK: There is no attribute target in .NET corresponding to PARAMETER:
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	[AttributeUsage(<missing> | <missing> | <missing>, AllowMultiple = false, Inherited = false]
	public class CurrencyConstraint : System.Attribute
	{
		string message() default "Invalid currency code";
		Type[] groups() default
		{
		};
		Type[] payload() default
		{
		};
	}
}