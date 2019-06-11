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

	using SwiftBlock1 = com.prowidesoftware.swift.model.SwiftBlock1;
	using SwiftBlock2 = com.prowidesoftware.swift.model.SwiftBlock2;
	using SwiftBlock3 = com.prowidesoftware.swift.model.SwiftBlock3;
	using SwiftBlock4 = com.prowidesoftware.swift.model.SwiftBlock4;
	using SwiftBlock5 = com.prowidesoftware.swift.model.SwiftBlock5;
	using SwiftBlockUser = com.prowidesoftware.swift.model.SwiftBlockUser;
	using SwiftMessage = com.prowidesoftware.swift.model.SwiftMessage;
	using Tag = com.prowidesoftware.swift.model.Tag;

	/// <summary>
	/// Interface to be implemented by classes that will 'visit' a swift message.
	/// 
	/// There method call sequence is as follows:
	/// 
	/// <ol>
	/// <li><code>startMessage</code></li>
	/// <li><code>startBlock1 -&gt; value -&gt; endBlock1</code> (if block 1 exists)</li>
	/// <li><code>startBlock2 -&gt; value -&gt; endBlock2</code> (if block 2 exists)</li>
	/// <li><code>startBlock3 -&gt; tag (for every tag) -&gt; endBlock3</code> (if block 3 exists)</li>
	/// <li><code>startBlock4 -&gt; tag (for every tag) -&gt; endBlock4</code> (if block 4 exists)</li>
	/// <li><code>startBlock5 -&gt; tag (for every tag) -&gt; endBlock5</code> (if block 5 exists)</li>
	/// <li><code>startBlockUser -&gt; tag (for every tag) -&gt; endBlockUser</code> (for every user defined block and every tag of that block)</li>
	/// <li><code>endMessage</code></li>
	/// </ol>
	/// 
	/// <para>Notice that the <code>tag</code> and <code>value</code> methods are overloaded for every type of SwiftBlock
	/// derived class.
	/// 
	/// </para>
	/// <para><b>NOTE</b>: this API has changed since 4.0 with SwiftBlocks 1-5 in each start/end 
	/// method pairs.
	/// </para>
	/// </summary>
	public interface IMessageVisitor
	{

		/// <param name="b"> block to visit </param>
		void startBlock1(SwiftBlock1 b);

		/// <param name="b"> block to visit </param>
		void startBlock2(SwiftBlock2 b);

		/// <param name="b"> block to visit </param>
		void startBlock3(SwiftBlock3 b);

		/// <param name="b"> block to visit </param>
		void startBlock4(SwiftBlock4 b);

		/// <param name="b"> block to visit </param>
		void startBlock5(SwiftBlock5 b);

		/// <param name="b"> block to visit </param>
		void startBlockUser(SwiftBlockUser b);

		/// <param name="b"> block to visit </param>
		void endBlock1(SwiftBlock1 b);

		/// <param name="b"> block to visit </param>
		void endBlock2(SwiftBlock2 b);

		/// <param name="b"> block to visit </param>
		void endBlock3(SwiftBlock3 b);

		/// <param name="b"> block to visit </param>
		void endBlock4(SwiftBlock4 b);

		/// <param name="b"> block to visit </param>
		void endBlock5(SwiftBlock5 b);

		/// <param name="b"> block to visit </param>
		void endBlockUser(SwiftBlockUser b);

		/// <param name="b"> </param>
		/// <param name="t"> </param>
		void tag(SwiftBlock3 b, Tag t);

		/// <param name="b"> </param>
		/// <param name="t"> </param>
		void tag(SwiftBlock4 b, Tag t);

		/// <param name="b"> </param>
		/// <param name="t"> </param>
		void tag(SwiftBlock5 b, Tag t);

		/// <param name="b"> </param>
		/// <param name="t"> </param>
		void tag(SwiftBlockUser b, Tag t);

		/// <param name="b"> </param>
		/// <param name="v"> </param>
		void value(SwiftBlock1 b, string v);

		/// <param name="b"> </param>
		/// <param name="v"> </param>
		void value(SwiftBlock2 b, string v);

		/// 
		/// <param name="m"> </param>
		void startMessage(SwiftMessage m);

		/// 
		/// <param name="m"> </param>
		void endMessage(SwiftMessage m);
	}

}