﻿/*
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
namespace com.prowidesoftware.swift.io
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;


	using Test = org.junit.Test;

	using FINWriterVisitor = com.prowidesoftware.swift.io.writer.FINWriterVisitor;
	using MT103 = com.prowidesoftware.swift.model.mt.mt1xx.MT103;

	/// <summary>
	/// Test cases for the <seealso cref="RJEWriter"/> class
	/// 
	/// @author sebastian
	/// @since 7.8.8
	/// </summary>
	public class RJEWriterTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test1() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test1()
		{
			StringWriter s = new StringWriter();
			RJEWriter w = new RJEWriter(s);
			MT103 mt = new MT103();
			w.write(mt);
			assertEquals(s.ToString(), mt.message());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test2() throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test2()
		{
			StringWriter s = new StringWriter();
			RJEWriter w = new RJEWriter(s);
			MT103 mt = new MT103();
			w.write(mt);
			w.write(mt);
			assertEquals(s.ToString(), mt.message() + FINWriterVisitor.SWIFT_EOL + RJEReader.SPLITCHAR + FINWriterVisitor.SWIFT_EOL + mt.message());
		}

	}

}