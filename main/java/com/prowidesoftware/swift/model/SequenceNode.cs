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
namespace com.prowidesoftware.swift.model
{

	using ProwideDeprecated = com.prowidesoftware.deprecation.ProwideDeprecated;
	using TargetYear = com.prowidesoftware.deprecation.TargetYear;


	/// <summary>
	/// Node that identifies a sequence inside a message.
	/// Messages may define an arbitrary amount of sequences and nested subsequences.
	/// These structures are modeled here as a tree.
	/// 
	/// @since 6.3 </summary>
	/// @deprecated to retrieve fields in sequences use the AbstractMT model 
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Deprecated("to retrieve fields in sequences use the AbstractMT model") @ProwideDeprecated(phase2 = TargetYear._2019) public class SequenceNode
	[Obsolete("to retrieve fields in sequences use the AbstractMT model")]
	public class SequenceNode
	{
		private readonly string name;
		private readonly IList<SequenceNode> children = new List<SequenceNode>();
		private readonly SequenceNode parent;

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private SequenceNode(final String name, final SequenceNode parent)
		private SequenceNode(string name, SequenceNode parent)
		{
			this.name = name;
			this.parent = parent;
		}

		/// <summary>
		/// get the name of this sequence
		/// </summary>
		public virtual string Name
		{
			get
			{
				return name;
			}
		}

		/// <summary>
		/// Adds a sequence to this node </summary>
		/// <param name="name"> the name of the sequence to add </param>
		/// <returns> the newly created sequence </returns>
		public virtual SequenceNode addChild(string name)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SequenceNode o = new SequenceNode(name, this);
			SequenceNode o = new SequenceNode(name, this);
			this.children.Add(o);
			return o;
		}

		/// <summary>
		/// Creates a root node. this must be the main entry point of all sequences
		/// </summary>
		public static SequenceNode newRootNode()
		{
			return new SequenceNode("main", null);
		}

		public virtual SequenceNode Parent
		{
			get
			{
				return parent;
			}
		}
	}

}