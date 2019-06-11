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

	using IBAN = com.prowidesoftware.swift.model.IBAN;
	using IbanValidationResult = com.prowidesoftware.swift.model.IbanValidationResult;
	using StringUtils = org.apache.commons.lang3.StringUtils;


	/// <summary>
	/// Implementation of the IBAN validation constraint </summary>
	/// <seealso cref= IBAN#validate() for implementation details
	/// @since 7.10.3 </seealso>
	public class IbanValidator : ConstraintValidator<IbanConstraint, string>
	{

		public override void initialize(IbanConstraint iban)
		{
		}

		public override bool isValid(string iban, ConstraintValidatorContext context)
		{
			if (StringUtils.isBlank(iban))
			{
				return true;
			}
			IbanValidationResult result = (new IBAN(iban)).validate();
			if (result == IbanValidationResult.OK)
			{
				return true;
			}
			else
			{
				context.disableDefaultConstraintViolation();
				context.buildConstraintViolationWithTemplate(result.message()).addConstraintViolation();
				return false;
			}
		}

	}
}