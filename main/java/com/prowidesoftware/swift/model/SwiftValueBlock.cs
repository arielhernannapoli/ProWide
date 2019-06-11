using System;

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


	/// <summary>
	/// Base class for SWIFT blocks that contain its fields concatenated as a single <b>fixed length</b> value; blocks 1 and 2.<br>
	/// This is an <b>abstract</b> class so specific block classes for each block should be instantiated.
	/// 
	/// @author www.prowidesoftware.com
	/// @since 4.0
	/// </summary>
	[Serializable]
	public abstract class SwiftValueBlock : SwiftBlock
	{
		private const long serialVersionUID = -3680693640473937755L;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final transient java.util.logging.Logger log = java.util.logging.Logger.getLogger(SwiftValueBlock.class.getName());
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftValueBlock).FullName);

		/// <summary>
		/// Default constructor, shouldn't be used normally.
		/// present only for subclasses
		/// </summary>
		protected internal SwiftValueBlock() : base()
		{
		}

		/// <summary>
		/// This method should be overwritten by subclasses, calling 
		/// this method will throw a <code>java.lang.UnsupportedOperationException</code> </summary>
		/// <returns> N/A </returns>
		public virtual string BlockValue
		{
			get
			{
				throw new System.NotSupportedException("cannot call getBlockValue on SwiftValueBlock, must be on specific subclasses");
			}
			set
			{
				throw new System.NotSupportedException("cannot call setBlockValue on SwiftValueBlock, must be on specific subclasses");
			}
		}

		/// <summary>
		/// This method should be overwritten by subclasses, calling 
		/// this method will throw a <code>java.lang.UnsupportedOperationException</code>
		/// </summary>
		/// <returns> the blocks value as a single string </returns>
		public virtual string Value
		{
			get
			{
				throw new System.NotSupportedException("cannot call getValue on SwiftValueBlock, must be on specific subclasses");
			}
			set
			{
				throw new System.NotSupportedException("cannot call setValue on SwiftValueBlock, must be on specific subclasses");
			}
		}



		/// <summary>
		/// Tells if the block contains at least one field.
		/// This method must be called on specific subclasses, calling it for SwiftValueBlock will throw 
		/// a <code>java.lang.UnsupportedOperationException</code> </summary>
		/// <returns> <code>true</code> if getValue returns a non null object </returns>
		public virtual bool Empty
		{
			get
			{
				return (this.Value == null);
			}
		}

		/// <summary>
		/// Tells the block's string value size (in chars).<br>
		/// NOTICE this does not return the actual number of fields set
		/// because value blocks are mostly fixed length.
		/// This method must be called on specific subclasses, calling it for SwiftValueBlock will throw 
		/// a <code>java.lang.UnsupportedOperationException</code> </summary>
		/// <returns> the size of the value or zero if value is null  </returns>
		public virtual int size()
		{
			return (this.Value == null ? 0 : this.Value.Length);
		}

		/// <summary>
		/// returns a fragment of the block value received (or null if value is not large enough).<br>
		/// This method is used in derived classes to get value fragments. </summary>
		/// <param name="value"> the full block value </param>
		/// <param name="start"> the starting point of the fragment in the big block value </param>
		/// <param name="size"> the fragment size </param>
		/// <returns> the value fragment or null if value is not large enough </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected String getValuePart(final String value, final int start, int size)
		protected internal virtual string getValuePart(string value, int start, int size)
		{
			// prepare the result
			string s = null;

			// check start is within bounds
			if (start < value.Length)
			{

				// check start+size is within bounds
				int boundedSize;
				if ((start + size) >= value.Length)
				{
					boundedSize = value.Length - start;
				}
				else
				{
					boundedSize = size;
				}

				// get the fragment
				try
				{
					s = value.Substring(start, boundedSize);
				}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not allowed in C#:
//ORIGINAL LINE: catch (final IndexOutOfBoundsException e)
				catch (System.IndexOutOfRangeException e)
				{
					log.log(Level.SEVERE, "Exception parsing value part", e);
				}
			}
			return s;
		}


		/// <summary>
		/// Returns a fragment of the block value received from a starting index until the end of value
		/// (or null if value is not large enough).<br>
		/// 
		/// This method is used in derived classes to get value fragments. </summary>
		/// <param name="value"> the full block value </param>
		/// <param name="start"> the starting point of the fragment in the big block value </param>
		/// <returns> the value fragment or null if value is not large enough
		/// @since 7.7 </returns>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected String getValuePart(final String value, final int start)
		protected internal virtual string getValuePart(string value, int start)
		{
			// check start is within bounds
			if (start < value.Length)
			{
				return value.Substring(start);
			}
			return null;
		}
	}

}