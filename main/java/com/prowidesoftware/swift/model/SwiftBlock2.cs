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

	using Gson = com.google.gson.Gson;
	using GsonBuilder = com.google.gson.GsonBuilder;
	using Validate = org.apache.commons.lang3.Validate;
	using ToStringBuilder = org.apache.commons.lang3.builder.ToStringBuilder;


	/// <summary>
	/// Base class for SWIFT <b>Application Header Block (block 2)</b>
	/// 
	/// <para>The Application Header contains information about the
	/// message type and the destination of the message.
	/// 
	/// </para>
	/// <para>There are two types of application headers: Input and Output.
	/// Both, input and output block 2 flavors are fixed-length and continuous with no field delimiters. 
	/// The fields that conform the blocks's value are represented in the subclasses
	/// as individual attributes for easier management.
	/// 
	/// </para>
	/// <para>This is an <b>abstract</b> class so specific block 2 subclasses should be instantiated.
	/// 
	/// @since 4.0
	/// </para>
	/// </summary>
	[Serializable]
	public abstract class SwiftBlock2 : SwiftValueBlock
	{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		[NonSerialized]
		private static readonly java.util.logging.Logger log = java.util.logging.Logger.getLogger(typeof(SwiftBlock2).FullName);
		private const long serialVersionUID = 7994472954593732477L;

		/// <summary>
		/// String of 1 character containing the message priority as follows:<br>
		/// S = System<br>
		/// N = Normal<br>
		/// U = Urgent
		/// </summary>
		protected internal string messagePriority = "N";

		/// <summary>
		/// String of 3 character containing the Message Type (MT) as classified and
		/// numbered by SWIFT. Three-digit FIN message type, example 103.
		/// </summary>
		protected internal string messageType = null;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public SwiftBlock2() : base()
		{
		}

		/// <summary>
		/// Sets the block number. Will cause an exception unless setting block number to 2. </summary>
		/// <param name="blockNumber"> the block number to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not the integer 2
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void setBlockNumber(final Integer blockNumber)
		protected internal override int? BlockNumber
		{
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'blockNumber' cannot be null");
				Validate.isTrue((int)value == 2, "blockNumber must be 2");
			}
		}

		/// <summary>
		/// Sets the block name. Will cause an exception unless setting block number to "2". </summary>
		/// <param name="blockName"> the block name to set </param>
		/// <exception cref="IllegalArgumentException"> if parameter blockName is not the string "2"
		/// @since 5.0 </exception>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void setBlockName(final String blockName)
		protected internal override string BlockName
		{
			set
			{
				// sanity check
				Validate.notNull(value, "parameter 'blockName' cannot be null");
				Validate.isTrue(value.CompareTo("2") == 0, "blockName must be string '2'");
			}
		}

		/// <summary>
		/// Returns the block number (the value 2 as an integer) </summary>
		/// <returns> Integer containing the block's number </returns>
		public override int? Number
		{
			get
			{
				return Convert.ToInt32(2);
			}
		}

		/// <summary>
		/// Returns the block name (the value 2 as a string) </summary>
		/// <returns> block name
		/// 
		/// @since 5.0 </returns>
		public override string Name
		{
			get
			{
				return "2";
			}
		}

		/// <summary>
		/// convert this to string
		/// </summary>
		public override string ToString()
		{
			return ToStringBuilder.reflectionToString(this);
		}

		/// <summary>
		/// Sets the Message Type (MT) as classified and numbered by SWIFT.
		/// Three-digit FIN message type, example 103.
		/// </summary>
		/// <param name="messageType"> String of 3 character </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setMessageType(final String messageType)
		public virtual string MessageType
		{
			set
			{
				this.messageType = value;
			}
			get
			{
				return messageType;
			}
		}


		/// <summary>
		/// Set the message priority </summary>
		/// <param name="messagePriority"> the message priority </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setMessagePriority(final String messagePriority)
		public virtual string MessagePriority
		{
			set
			{
				this.messagePriority = value;
			}
			get
			{
				return messagePriority;
			}
		}


		/// <summary>
		/// Gets the message priority as enum </summary>
		/// <returns> message priority enum value or null if the priority is not set or contains an invalid value
		/// @since 7.8.4 </returns>
		public virtual MessagePriority MessagePriorityType
		{
			get
			{
				if (this.messagePriority != null)
				{
					try
					{
						return MessagePriority.valueOf(this.messagePriority);
					}
					catch (Exception e)
					{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final String text = "Block2 messagePriority contains an invalid value ["+ this.messagePriority +"]. The expected values are "+MessagePriority.values();
						string text = "Block2 messagePriority contains an invalid value [" + this.messagePriority + "]. The expected values are " + MessagePriority.values();
						log.warning(text);
						log.log(Level.FINEST, text, e);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Returns <code>true</code> if this block 2 is an input block 2. </summary>
		/// <returns> <code>true</code> if block 2 is input, of <code>false</code> in other case </returns>
		public virtual bool Input
		{
			get
			{
				return this is SwiftBlock2Input;
			}
		}

		/// <summary>
		/// Returns <code>true</code> if this block 2 is an output block 2. </summary>
		/// <returns> <code>true</code> if block 2 is output, of <code>false</code> in other case </returns>
		public virtual bool Output
		{
			get
			{
				return this is SwiftBlock2Output;
			}
		}

		/// <summary>
		/// Sets all attributes to null
		/// @since 6.4
		/// </summary>
		public virtual void clean()
		{
			messagePriority = null;
			messageType = null;
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}
			if (!base.Equals(o))
			{
				return false;
			}
			SwiftBlock2 that = (SwiftBlock2) o;
			return Objects.Equals(messagePriority, that.messagePriority) && Objects.Equals(messageType, that.messageType);
		}

		public override int GetHashCode()
		{
			return Objects.hash(base.GetHashCode(), messagePriority, messageType);
		}

		/// <summary>
		/// Specific serialization is provided for block 2 input and output
		/// 
		/// @since 7.9.8 current block 2 implementation, based on Gson (method signature with null implementation is available since 7.5)
		/// </summary>
		public virtual string toJson()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final com.google.gson.Gson gson = new com.google.gson.GsonBuilder().registerTypeAdapter(SwiftBlock2.class, new SwiftBlock2Adapter()).setPrettyPrinting().create();
			Gson gson = (new GsonBuilder()).registerTypeAdapter(typeof(SwiftBlock2), new SwiftBlock2Adapter()).setPrettyPrinting().create();
			return gson.toJson(this,typeof(SwiftBlock2));
		}

		/// <summary>
		/// Generic getter for block attributes based on qualified names from <seealso cref="SwiftBlock2Field"/> </summary>
		/// <param name="field"> field to get </param>
		/// <returns> field value or null if attribute is not set
		/// @since 7.7 </returns>
		public virtual string field(SwiftBlock2Field field)
		{
			switch (field.InnerEnumValue())
			{
				case com.prowidesoftware.swift.model.SwiftBlock2Field.InnerEnum.MessageType:
					return MessageType;
				case com.prowidesoftware.swift.model.SwiftBlock2Field.InnerEnum.MessagePriority:
					return MessagePriority;
				default:
					return null;
			}
		}

		/// <summary>
		/// Generic setter for block attributes based on qualified names from <seealso cref="SwiftBlock2Field"/> </summary>
		/// <param name="field"> field to set </param>
		/// <param name="value"> content to set
		/// @since 7.8 </param>
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: public void setField(SwiftBlock2Field field, final String value)
		public virtual void setField(SwiftBlock2Field field, string value)
		{
			switch (field.InnerEnumValue())
			{
				case com.prowidesoftware.swift.model.SwiftBlock2Field.InnerEnum.MessageType:
					MessageType = value;
					break;
				case com.prowidesoftware.swift.model.SwiftBlock2Field.InnerEnum.MessagePriority:
					MessagePriority = value;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Message priority values
		/// @since 7.8.4
		/// </summary>
		public sealed class MessagePriority
		{
			public static readonly MessagePriority S = new MessagePriority("S", InnerEnum.S, "System");
			public static readonly MessagePriority N = new MessagePriority("N", InnerEnum.N, "Normal");
			public static readonly MessagePriority U = new MessagePriority("U", InnerEnum.U, "Urgent");

			private static readonly IList<MessagePriority> valueList = new List<MessagePriority>();

			static MessagePriority()
			{
				valueList.Add(S);
				valueList.Add(N);
				valueList.Add(U);
			}

			public enum InnerEnum
			{
				S,
				N,
				U
			}

			private readonly string nameValue;
			private readonly int ordinalValue;
			private readonly InnerEnum innerEnumValue;
			private static int nextOrdinal = 0;

			internal string label;

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: MessagePriority(final String label)
			internal MessagePriority(string name, InnerEnum innerEnum, SwiftBlock2 outerInstance, string label)
			{
				this.outerInstance = outerInstance;
				this.label = label;

				nameValue = name;
				ordinalValue = nextOrdinal++;
				innerEnumValue = innerEnum;
			}

			public String Label
			{
				get
				{
					return this.label;
				}
			}

			public static IList<MessagePriority> values()
			{
				return valueList;
			}

			public InnerEnum InnerEnumValue()
			{
				return innerEnumValue;
			}

			public int ordinal()
			{
				return ordinalValue;
			}

			public override string ToString()
			{
				return nameValue;
			}

			public static MessagePriority valueOf(string name)
			{
				foreach (MessagePriority enumInstance in MessagePriority.values())
				{
					if (enumInstance.nameValue == name)
					{
						return enumInstance;
					}
				}
				throw new System.ArgumentException(name);
			}
		}
	}

}