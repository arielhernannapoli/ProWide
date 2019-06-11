using System;
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
namespace com.prowidesoftware.swift.model.field
{


	using StringUtils = org.apache.commons.lang3.StringUtils;
	using Ignore = org.junit.Ignore;
	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Ignore public class FieldComponentLabelsCompatibilityTest
	public class FieldComponentLabelsCompatibilityTest
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") @Test public void test() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test()
		{
			IList<Type> classes = getClasses(typeof(Field).ClassLoader,"com/prowidesoftware/swift/model/field");
			int missing = 0;
			int availableOK = 0;
			int availableError = 0;
			foreach (Type c in classes)
			{
				Field f = (Field) c.newInstance();
				int size = f.Components.Count;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String label = Field.getLabelComponents(f.getName(), null, null, null);
				string label = Field.getLabelComponents(f.Name, null, null, null);
				if (label.EndsWith(".components", StringComparison.Ordinal))
				{
					missing++;
				}
				else
				{
					string[] labels = StringUtils.Split(label, "-");
					if (labels.Length == size)
					{
						availableOK++;
					}
					else
					{
						availableError++;
						Console.WriteLine(f.Name + " components=" + size + " " + label);
					}
				}
			}
			Console.WriteLine("total=" + classes.Count + " missing=" + missing + " availableOK=" + availableOK + " availableError=" + availableError);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void test50K() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual void test50K()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String label = Field.getLabelComponents("50K", null, null, null);
			string label = Field.getLabelComponents("50K", null, null, null);
			Console.WriteLine(label);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("rawtypes") public static java.util.List<Class> getClasses(ClassLoader cl,String pack) throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public static IList<Type> getClasses(ClassLoader cl, string pack)
		{
			string dottedPackage = pack.replaceAll("[/]", ".");
			IList<Type> classes = new List<Type>();
			URL upackage = cl.getResource(pack);
			BufferedReader reader = new BufferedReader(new InputStreamReader((InputStream) upackage.Content));
			string line = null;
			while ((line = reader.readLine()) != null)
			{
				if (line.EndsWith(".class", StringComparison.Ordinal) && line.StartsWith("Field", StringComparison.Ordinal) && !line.Contains("Test") && !line.Equals("Field.class"))
				{
				   classes.Add(Type.GetType(dottedPackage + "." + line.Substring(0,line.LastIndexOf('.'))));
				}
			}
			return classes;
		}
	}

}