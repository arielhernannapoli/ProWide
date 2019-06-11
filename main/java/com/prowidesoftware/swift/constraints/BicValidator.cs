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

	using BIC = com.prowidesoftware.swift.model.BIC;
	using BicValidationResult = com.prowidesoftware.swift.model.BicValidationResult;
	using StringUtils = org.apache.commons.lang3.StringUtils;


	/// <summary>
	/// Implementation of the BIC validation constraint </summary>
	/// <seealso cref= BIC#validate() for implementation details
	/// @since 7.10.3 </seealso>
	public class BicValidator : ConstraintValidator<BicConstraint, string>
	{

		public override void initialize(BicConstraint bic)
		{
		}

		public override bool isValid(string bic, ConstraintValidatorContext context)
		{
			if (StringUtils.isBlank(bic))
			{
				return true;
			}
			BicValidationResult result = (new BIC(bic)).validate();
			if (result == BicValidationResult.OK)
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