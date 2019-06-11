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
	/// Base class for a IMessageVisitor. This class does nothing, implements all
	/// methods empty. All methods may be overwritten.
	/// 
	/// @author www.prowidesoftware.com
	/// </summary>
	//TODO: complete javadocs 
	public class BaseMessageVisitor : IMessageVisitor
	{

		public virtual void startBlock1(SwiftBlock1 b)
		{
		}

		public virtual void startBlock2(SwiftBlock2 b)
		{
		}

		public virtual void startBlock3(SwiftBlock3 b)
		{
		}

		public virtual void startBlock4(SwiftBlock4 b)
		{
		}

		public virtual void startBlock5(SwiftBlock5 b)
		{
		}

		public virtual void startBlockUser(SwiftBlockUser b)
		{
		}

		public virtual void endBlock1(SwiftBlock1 b)
		{
		}

		public virtual void endBlock2(SwiftBlock2 b)
		{
		}

		public virtual void endBlock3(SwiftBlock3 b)
		{
		}

		public virtual void endBlock4(SwiftBlock4 b)
		{
		}

		public virtual void endBlock5(SwiftBlock5 b)
		{
		}

		public virtual void endBlockUser(SwiftBlockUser b)
		{
		}

		public virtual void tag(SwiftBlock3 b, Tag t)
		{
		}

		public virtual void tag(SwiftBlock4 b, Tag t)
		{
		}

		public virtual void tag(SwiftBlock5 b, Tag t)
		{
		}

		public virtual void tag(SwiftBlockUser b, Tag t)
		{
		}

		public virtual void value(SwiftBlock1 b, string v)
		{
		}

		public virtual void value(SwiftBlock2 b, string v)
		{
		}

		public virtual void endMessage(SwiftMessage m)
		{
		}

		public virtual void startMessage(SwiftMessage m)
		{
		}

	}

}