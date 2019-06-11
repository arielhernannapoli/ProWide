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

	using com.prowidesoftware.swift.model.field;
	using Validate = org.apache.commons.lang3.Validate;

	/// <summary>
	/// Helper class to fill a User Header block 3 ensuring only expected
	/// fields are set and fields are set in proper order.
	/// 
	/// <para>It is implemented as a Decorator for the SwiftBlock3 instance.
	/// Each time a new field is set, the internal tag list will be
	/// updated in proper order.
	/// 
	/// @since 7.10.0
	/// </para>
	/// </summary>
	public class SwiftBlock3Builder
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftBlock3Builder).FullName);

		private Tag field103 = null;
		private Tag field113 = null;
		private Tag field108 = null;
		private Tag field119 = null;
		private Tag field423 = null;
		private Tag field106 = null;
		private Tag field424 = null;
		private Tag field111 = null;
		private Tag field121 = null;
		private Tag field115 = null;
		private Tag field165 = null;
		private Tag field433 = null;
		private Tag field434 = null;

		private SwiftBlock3 b3 = null;

		/// <summary>
		/// Initializes the builder with fields data from an existing block 3 </summary>
		/// <param name="b3"> an existing block3 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: SwiftBlock3Builder(final SwiftBlock3 b3)
		internal SwiftBlock3Builder(SwiftBlock3 b3) : base()
		{
			Validate.notNull(b3, "SwiftBlock3 parameter cannot be null");
			this.b3 = b3;
			this.field103 = b3.getTagByName(Field103.NAME);
			this.field113 = b3.getTagByName(Field113.NAME);
			this.field108 = b3.getTagByName(Field108.NAME);
			this.field119 = b3.getTagByName(Field119.NAME);
			this.field423 = b3.getTagByName(Field423.NAME);
			this.field106 = b3.getTagByName(Field106.NAME);
			this.field424 = b3.getTagByName(Field424.NAME);
			this.field111 = b3.getTagByName(Field111.NAME);
			this.field121 = b3.getTagByName(Field121.NAME);
			this.field115 = b3.getTagByName(Field115.NAME);
			this.field165 = b3.getTagByName(Field165.NAME);
			this.field433 = b3.getTagByName(Field433.NAME);
			this.field434 = b3.getTagByName(Field434.NAME);
		}

		public virtual SwiftBlock3Builder setField103(Field103 field103)
		{
			this.field103 = field103.asTag();
			update();
			return this;
		}

		public virtual SwiftBlock3Builder setField113(Field113 field113)
		{
			this.field113 = field113.asTag();
			update();
			return this;
		}

		public virtual SwiftBlock3Builder setField108(Field108 field108)
		{
			this.field108 = field108.asTag();
			update();
			return this;
		}

		public virtual SwiftBlock3Builder setField119(Field119 field119)
		{
			this.field119 = field119.asTag();
			update();
			return this;
		}

		public virtual SwiftBlock3Builder setField423(Field423 field423)
		{
			this.field423 = field423.asTag();
			update();
			return this;
		}

		public virtual SwiftBlock3Builder setField106(Field106 field106)
		{
			this.field106 = field106.asTag();
			update();
			return this;
		}

		public virtual SwiftBlock3Builder setField424(Field424 field424)
		{
			this.field424 = field424.asTag();
			update();
			return this;
		}

		public virtual SwiftBlock3Builder setField111(Field111 field111)
		{
			this.field111 = field111.asTag();
			update();
			return this;
		}

		public virtual SwiftBlock3Builder setField121(Field121 field121)
		{
			this.field121 = field121.asTag();
			update();
			return this;
		}

		/// <summary>
		/// This field should only be set for outgoing messages (input to SWIFT)
		/// </summary>
		public virtual SwiftBlock3Builder setField115(Field115 field115)
		{
			this.field115 = field115.asTag();
			update();
			return this;
		}

		/// <summary>
		/// This field should only be set for outgoing messages (input to SWIFT)
		/// </summary>
		public virtual SwiftBlock3Builder setField165(Field165 field165)
		{
			this.field165 = field165.asTag();
			update();
			return this;
		}

		/// <summary>
		/// This field should only be set for outgoing messages (input to SWIFT)
		/// </summary>
		public virtual SwiftBlock3Builder setField433(Field433 field433)
		{
			this.field433 = field433.asTag();
			update();
			return this;
		}

		/// <summary>
		/// This field should only be set for outgoing messages (input to SWIFT)
		/// @since 7.10.3
		/// </summary>
		public virtual SwiftBlock3Builder setField434(Field434 field434)
		{
			this.field434 = field434.asTag();
			update();
			return this;
		}

		private void update()
		{
			b3.Tags.Clear();
			if (field103 != null)
			{
				b3.Tags.Add(field103);
			}
			if (field113 != null)
			{
				b3.Tags.Add(field113);
			}
			if (field108 != null)
			{
				b3.Tags.Add(field108);
			}
			if (field119 != null)
			{
				b3.Tags.Add(field119);
			}
			if (field423 != null)
			{
				b3.Tags.Add(field423);
			}
			if (field106 != null)
			{
				b3.Tags.Add(field106);
			}
			if (field424 != null)
			{
				b3.Tags.Add(field424);
			}
			if (field111 != null)
			{
				b3.Tags.Add(field111);
			}
			if (field121 != null)
			{
				b3.Tags.Add(field121);
			}
			if (field115 != null)
			{
				b3.Tags.Add(field115);
			}
			if (field165 != null)
			{
				b3.Tags.Add(field165);
			}
			if (field433 != null)
			{
				b3.Tags.Add(field433);
			}
			if (field434 != null)
			{
				b3.Tags.Add(field434);
			}
		}

		/// <summary>
		/// Adds the list of fields to the block, dropping any unexpected field </summary>
		/// <param name="fields"> the fields to add
		/// @since 7.10.9 </param>
		public virtual SwiftBlock3Builder setFields(IList<Field> fields)
		{
			foreach (Field field in fields)
			{
				Field = field;
			}
			return this;
		}

		/// <summary>
		/// If the field is expected, it is added to the block </summary>
		/// <param name="field"> the field to add
		/// @since 7.10.9 </param>
		public virtual SwiftBlock3Builder setField(Field field)
		{
			switch (field.Name)
			{
				case Field103.NAME:
				{
					return setField103((Field103) field);
				}
				case Field113.NAME:
				{
					return setField113((Field113) field);
				}
				case Field108.NAME:
				{
					return setField108((Field108) field);
				}
				case Field119.NAME:
				{
					return setField119((Field119) field);
				}
				case Field423.NAME:
				{
					return setField423((Field423) field);
				}
				case Field106.NAME:
				{
					return setField106((Field106) field);
				}
				case Field424.NAME:
				{
					return setField424((Field424) field);
				}
				case Field111.NAME:
				{
					return setField111((Field111) field);
				}
				case Field121.NAME:
				{
					return setField121((Field121) field);
				}
				case Field115.NAME:
				{
					return setField115((Field115) field);
				}
				case Field165.NAME:
				{
					return setField165((Field165) field);
				}
				case Field433.NAME:
				{
					return setField433((Field433) field);
				}
				case Field434.NAME:
				{
					return setField434((Field434) field);
				}
				default:
				{
					log.warning("Unexpected field " + field.Name + " passed to the block 3 builder");
				}
			break;
			}
			return this;
		}

	}
}