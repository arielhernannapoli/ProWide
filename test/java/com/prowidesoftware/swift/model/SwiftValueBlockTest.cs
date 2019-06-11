namespace com.prowidesoftware.swift.model
{

	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertEquals;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to .NET:
	import static org.junit.Assert.assertNull;

	public class SwiftValueBlockTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void getValuePart()
		public virtual void getValuePart()
		{
			TestValueBlock b = new TestValueBlock();
			assertNull(b.getValuePart("", 0, 0));
			assertEquals("", b.getValuePart("Hello", 0, 0));
			assertEquals("H", b.getValuePart("Hello", 0, 1));
			assertEquals("Hello", b.getValuePart("Hello", 0, 10));
			assertEquals("ello", b.getValuePart("Hello", 1, 10));
			assertEquals("e", b.getValuePart("Hello", 1, 1));
			assertNull(b.getValuePart("Hello", 10, 1));
			assertEquals("EAKWAXXXU3003", b.getValuePart("O101AZADEAKWAXXXU3003", 8, 28));
		}

		internal class TestValueBlock : SwiftValueBlock
		{

			protected internal override int? BlockNumber
			{
				set
				{
    
				}
			}

			protected internal override string BlockName
			{
				set
				{
    
				}
			}

			public override int? Number
			{
				get
				{
					return null;
				}
			}

			public override string Name
			{
				get
				{
					return null;
				}
			}
		}

	}

}