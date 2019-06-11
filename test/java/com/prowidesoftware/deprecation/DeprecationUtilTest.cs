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
namespace com.prowidesoftware.deprecation
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertTrue;

	using Test = org.junit.Test;

	using EnvironmentVariableKey = com.prowidesoftware.deprecation.DeprecationUtils.EnvironmentVariableKey;

	/// <summary>
	/// Test cases for the deprecation policy implementation
	/// 
	/// @author sebastian
	/// @since 7.8.9
	/// </summary>
	public class DeprecationUtilTest
	{

		/// <summary>
		/// Default behavior
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPhase2_default()
		public virtual void testPhase2_default()
		{
			long t0 = DateTimeHelperClass.CurrentUnixTimeMillis();
			DeprecationUtils.phase2(this.GetType(), "method", "phase 2 message");
			long t1 = DateTimeHelperClass.CurrentUnixTimeMillis();
			long diff = t1 - t0;
			assertTrue(diff >= 3990);
		}

		/// <summary>
		/// Log and delay switched off
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPhase2_off()
		public virtual void testPhase2_off()
		{
			DeprecationUtils.setEnv(EnvironmentVariableKey.NOLOG, EnvironmentVariableKey.NODELAY);
			long t0 = DateTimeHelperClass.CurrentUnixTimeMillis();
			DeprecationUtils.phase2(this.GetType(), null, "another phase 2 message");
			long t1 = DateTimeHelperClass.CurrentUnixTimeMillis();
			assertTrue((t1 - t0) < 4000);
			DeprecationUtils.clearEnv();
		}

		/// <summary>
		/// Default behavior
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=UnsupportedOperationException.class) public void testPhase3_default()
		public virtual void testPhase3_default()
		{
			DeprecationUtils.phase3(this.GetType(), null, "phase 3 message");
		}

		/// <summary>
		/// Exception switched off
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testPhase3_off()
		public virtual void testPhase3_off()
		{
			DeprecationUtils.setEnv(EnvironmentVariableKey.NOLOG, EnvironmentVariableKey.NODELAY, EnvironmentVariableKey.NOEXCEPTION);
			DeprecationUtils.phase3(this.GetType(), null, "phase 3 message");
			DeprecationUtils.clearEnv();
		}

	}

}