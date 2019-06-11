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

	using StringUtils = org.apache.commons.lang3.StringUtils;


	/// <summary>
	/// <para>This class represents a node element within a tree of MX message.
	/// It is basically a generic <b>XML node</b> structure used to provide basic 
	/// parsing functionallity for MX messages in Prowide Core.
	/// 
	/// </para>
	/// <para>Note than full business model is provided only for the business
	/// header, while a complete MX model is implemented in Prowide Integrator.
	/// For more information on the full MX model implementation please check:
	/// <a href="http://www.prowidesoftware.com/products/integrator">Prowide Integrator</a>
	/// 
	/// @since 7.6
	/// </para>
	/// </summary>
	public class MxNode
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(MxNode).FullName);

		[NonSerialized]
		public const string PATH_SEPARATOR = "/";
		private MxNode parent;
		private readonly IList<MxNode> children;
		private string value;
		private string localName;
		private IDictionary<string, string> attributes = null;

		public MxNode()
		{
			this.parent = null;
			this.children = new List<>();
			this.value = null;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxNode(final MxNode parent, final String localName)
		public MxNode(MxNode parent, string localName) : this()
		{
			this.localName = localName;
			if (parent != null)
			{
				bindParent(parent);
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void bindParent(final MxNode parent)
		private void bindParent(MxNode parent)
		{
			this.parent = parent;
			parent.addChild(this);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void addChild(final MxNode child)
		private void addChild(MxNode child)
		{
			this.children.Add(child);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String singlePathValue(final String path)
		public virtual string singlePathValue(string path)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MxNode first = findFirst(path);
			MxNode first = findFirst(path);
			if (first != null)
			{
				return first.Value;
			}
			return null;
		}

		/// <summary>
		/// Given a basic path, find the first instance of a node matching the
		/// path parameter.<br>
		/// 
		/// If the path starts with '/' it will search from the root element,
		/// else it will search from this node.
		/// </summary>
		/// <param name="path"> absolute or relative path to find </param>
		/// <returns> found node or null
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxNode findFirst(final String path)
		public virtual MxNode findFirst(string path)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MxNode> found = find(path);
			IList<MxNode> found = find(path);
			if (found.Count > 0)
			{
				return found[0];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Given a basic path, find all nodes matching the path parameter.<br>
		/// 
		/// If the path starts with '/' it will search from the root element,
		/// else it will search from this node.
		/// </summary>
		/// <param name="path"> absolute or relative path to find </param>
		/// <returns> found node or null
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public java.util.List<MxNode> find(final String path)
		public virtual IList<MxNode> find(string path)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String[] segments = org.apache.commons.lang3.StringUtils.split(path, PATH_SEPARATOR);
			string[] segments = StringUtils.Split(path, PATH_SEPARATOR);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MxNode start = path != null && path.startsWith(PATH_SEPARATOR) ? getRoot() : this;
			MxNode start = path != null && path.StartsWith(PATH_SEPARATOR, StringComparison.Ordinal) ? Root : this;
			return _find2(0, segments, start);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private java.util.List<MxNode> _find2(int index, final String[] segments, final MxNode node)
		private IList<MxNode> _find2(int index, string[] segments, MxNode node)
		{
			if (index > segments.Length)
			{
				return new List<>();
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<MxNode> result = new java.util.ArrayList<>();
			IList<MxNode> result = new List<MxNode>();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String segment = segments[index];
			string segment = segments[index];
			int nextIndex = index + 1;

			//TODO en vez de remover el predicado, habria que soportarlo, devolviendo la/s instancia/s pedidas
			if (StringUtils.Equals(".", segment) || StringUtils.equalsIgnoreCase(node.localName, removePredicate(segment)))
			{
				if (nextIndex == segments.Length)
				{
					result.Add(node);
					return result;
				}
				else if (node.children != null)
				{
					foreach (MxNode n in node.children)
					{
						result.AddRange(_find2(nextIndex, segments, n));
					}
					return result;
				}

			}
			return result;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private String removePredicate(final String segment)
		private string removePredicate(string segment)
		{
			int index = segment.IndexOf('[');
			if (index > 0)
			{
				return segment.Substring(0, index);
			}
			else
			{
				return segment;
			}
		}

		public virtual MxNode Root
		{
			get
			{
				return _getRoot(this);
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private static MxNode _getRoot(final MxNode mxNode)
		private static MxNode _getRoot(MxNode mxNode)
		{
			if (mxNode == null)
			{
				return null;
			}
			return mxNode.parent == null ? mxNode : _getRoot(mxNode.parent);
		}

		public virtual string Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}


		public override string ToString()
		{
			return "MxNode{" + "localName='" + localName + '\'' + '}';
		}

		/// <summary>
		/// Prints this node tree structure in standard output
		/// </summary>
		public virtual void print()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.PrintStream w = System.out;
			PrintStream w = System.out;
			try
			{
				_print(0, Root, w);
			}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final java.io.IOException e)
			catch (IOException e)
			{
				log.log(Level.WARNING, "exception printing node structure", e);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void _print(int level, final MxNode node, final java.io.PrintStream w) throws java.io.IOException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
		private void _print(int level, MxNode node, PrintStream w)
		{
			for (int i = 0;i < level;i++)
			{
				w.write("   ".GetBytes());
			}
			w.write((node.localName + "\n").Bytes);
			int nextLevel = level + 1;
			foreach (MxNode child in node.children)
			{
				_print(nextLevel, child, w);
			}
		}

		public virtual MxNode Parent
		{
			get
			{
				return parent;
			}
		}

		/// <summary>
		/// Traverse the tree from this node looking for the first node matching the given name. </summary>
		/// <param name="name"> a node name to find </param>
		/// <returns> the found node or null if not found
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public MxNode findFirstByName(final String name)
		public virtual MxNode findFirstByName(string name)
		{
			return _findFirstByName(this, name);
		}

		/// <summary>
		/// Recursive implementation of the find by name
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private MxNode _findFirstByName(final MxNode node, final String name)
		private MxNode _findFirstByName(MxNode node, string name)
		{
			if (node == null)
			{
				return null;
			}
			if (StringUtils.equalsIgnoreCase(node.localName, name))
			{
				return node;
			}
			else if (node.children != null)
			{
				foreach (MxNode child in node.children)
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final MxNode found = _findFirstByName(child, name);
					MxNode found = _findFirstByName(child, name);
					if (found != null)
					{
						return found;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// @since 7.8 </summary>
		/// <returns> returns this node children nodes </returns>
		public virtual IList<MxNode> Children
		{
			get
			{
				return children;
			}
		}

		/// <summary>
		/// @since 7.8
		/// </summary>
		public virtual IDictionary<string, string> Attributes
		{
			get
			{
				return attributes;
			}
			set
			{
				this.attributes = value;
			}
		}


		/// <summary>
		/// Adds the given attribute to the node. 
		/// If an attribute already exist with the same local name, its value is updated.
		/// @since 7.8
		/// </summary>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void addAttribute(final String name, final String value)
		public virtual void addAttribute(string name, string value)
		{
			if (this.attributes == null)
			{
				this.attributes = new Dictionary<>();
			}
			this.attributes.Remove(name);
			this.attributes[name] = value;
		}

		/// <summary>
		/// @since 7.8 </summary>
		/// <returns> found attribute value or null if not found or node does not contain attributes </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public String getAttribute(final String name)
		public virtual string getAttribute(string name)
		{
			if (this.attributes != null)
			{
				return this.attributes[name];
			}
			return null;
		}

		/// <summary>
		/// Builds this node's path up to the root element </summary>
		/// <returns> the absolute path of the ndoe in the form /foo/foo/foo
		/// @since 7.8  </returns>
		public virtual string path()
		{
			if (this.parent == null)
			{
				return PATH_SEPARATOR + this.localName;
			}
			else
			{
				return this.parent.path() + PATH_SEPARATOR + this.localName;
			}
		}
	}

}