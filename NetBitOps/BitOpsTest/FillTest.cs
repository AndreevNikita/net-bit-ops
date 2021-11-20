using NetBitOps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitOpsTest {
	public class FillTest {

		[Test]
		[Description("Test BitOps.RightFill for UInt32 type")]
		[TestCase(  8, 0xffU)]
		[TestCase(  0, 0x00U)]
		[TestCase( -8, 0x00U)]
		[TestCase( 32, 0xffffffffU)]
		[TestCase( 36, 0xffffffffU)]
		public void UInt32RightTest(int length, uint expected) {
			Assert.AreEqual(expected, BitOps.RightFill(length));
		}

		[Test]
		[Description("Test BitOps.LeftFill for UInt32 type")]
		[TestCase(  8, 0xff000000U)]
		[TestCase(  0, 0x00U)]
		[TestCase( -8, 0x00U)]
		[TestCase( 32, 0xffffffffU)]
		[TestCase( 36, 0xffffffffU)]
		public void UInt32LeftTest(int length, uint expected) {
			Assert.AreEqual(expected, BitOps.LeftFill(length));
		}

		[Test]
		[Description("Test BitOps.RightFill for UInt64 type")]
		[TestCase(  8, 0xffU)]
		[TestCase(  0, 0x00U)]
		[TestCase( -8, 0x00U)]
		[TestCase( 64, 0xffffffff_ffffffffU)]
		[TestCase( 68, 0xffffffff_ffffffffU)]
		public void UInt64RightTest(int length, ulong expected) {
			Assert.AreEqual(expected, BitOps.RightFillLong(length));
		}

		[Test]
		[Description("Test BitOps.LeftFill for UInt64 type")]
		[TestCase(  8, 0xff000000_00000000U)]
		[TestCase(  0, 0x00U)]
		[TestCase( -8, 0x00U)]
		[TestCase( 64, 0xffffffff_ffffffffU)]
		[TestCase( 68, 0xffffffff_ffffffffU)]
		public void UInt64LeftTest(int length, ulong expected) {
			Assert.AreEqual(expected, BitOps.LeftFillLong(length));
		}

	}
}
