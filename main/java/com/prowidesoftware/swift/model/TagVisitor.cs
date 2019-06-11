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
namespace com.prowidesoftware.swift.model
{

	public interface TagVisitor
	{

		/// <summary>
		/// Visit the current tag </summary>
		/// <param name="tag"> the current tag </param>
		/// <returns> <code>true</code> if the visitor should continue with further tags if any or <code>false</code> to abort the visiting process </returns>
		bool onTag(Tag tag);
	}

}