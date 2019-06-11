﻿using System;

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

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.fail;

	using Ignore = org.junit.Ignore;

	/// <summary>
	/// Base implementation for field test cases
	/// 
	/// @author sebastian
	/// @since 7.9.3
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Ignore public abstract class AbstractFieldTest
	public abstract class AbstractFieldTest
	{

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void testSerializationImpl(final String tagName, String... values)
		protected internal virtual void testSerializationImpl(string tagName, params string[] values)
		{
			try
			{
				foreach (string v in values)
				{
					Tag t1 = new Tag(tagName, v);
					Tag t2 = Field.getField(t1).asTag();
					assertTrue("[" + t1.Value + "] is not equals [" + t2.Value + "]", t1.equalsIgnoreCR(t2));
				}
			}
			catch (Exception e)
			{
				fail(e.Message);
			}
		}

		/// <summary>
		/// All subclasses must implement this test case calling <seealso cref="#testSerializationImpl(String, String...)"/>
		/// to verify that a field value integrity is preserve after parsing it into components and serializing the
		/// components back into a plain string. 
		/// </summary>
		public abstract void testSerialization();

	}

}