using NetBitOps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitOpsTest {
	public class FillOffsetTest {
		
		[Test]
		[Description("Test BitOps.Fill for UInt32 type")]
		[TestCase(  0,   8, 0b11111111U)]
		[TestCase(  4,   8, 0b11111111_0000U)]
		[TestCase(  0,   0, 0b00000000_0000U)]
		[TestCase( 28,   8, 0xf0000000U)]
		[TestCase( -4,  -8, 0x00U)]
		[TestCase(  4,  -1, 0x00U)]
		[TestCase( -4,   8, 0x0fU)]
		[TestCase( 31,  -8, 0x00U)]
		[TestCase( 35,  -8, 0x00U)]
		public void UInt32Test(int startIndex, int length, uint expected) {
			Assert.AreEqual(expected, BitOps.Fill(startIndex, length));
		}

		[Test]
		[Description("Test BitOps.Fill for UInt64 type")]
		[TestCase(  0,   8, 0b11111111UL)]
		[TestCase(  4,   8, 0b11111111_0000UL)]
		[TestCase(  0,   0, 0b00000000_0000UL)]
		[TestCase( 60,   8, 0xf0000000_00000000UL)]
		[TestCase( -4,  -8, 0x00UL)]
		[TestCase(  4,  -1, 0x00UL)]
		[TestCase( -4,   8, 0x0fUL)]
		[TestCase( 63,  -8, 0x00UL)]
		[TestCase( 67,  -8, 0x00UL)]
		public void UInt64Test(int startIndex, int length, ulong expected) {
			Assert.AreEqual(expected, BitOps.FillLong(startIndex, length));
		}

	}
}
