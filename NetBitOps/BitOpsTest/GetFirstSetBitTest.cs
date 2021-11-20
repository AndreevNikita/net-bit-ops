using NetBitOps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitOpsTest {
	public class GetFirstSetBitTests {

		/// <summary>
		/// All 0x80 and 0x1 (the last and the first bits of byte) combinations for each byte for 64-bit ulong type.
		/// </summary>
		private static IEnumerable<ulong> TestULongsSource = 
			Enumerable.Range(0, sizeof(ulong) + 1).Reverse().SelectMany(
				index1 => Enumerable.Range(0, sizeof(ulong) + 1).Reverse().Select(index2 => (index1 != sizeof(ulong) ? 0x80UL << (index1 * 8) : 0) | (index2 != sizeof(ulong) ? 0x1UL << (index2 * 8) : 0))
			);

		[Test]
		[Description("Test BitOps.GetFirstSetBit for ulong type")]
		[TestCaseSource(nameof(TestULongsSource))]
		public void ULongTest(ulong n) {
			Assert.AreEqual(TrueGetFirstSetBit(n), BitOps.GetFirstSetBit(n));
		}

		/// <summary>
		/// All 0x80 and 0x1 (the last and the first bits of byte) combinations for each byte for 32-bit uint type.
		/// </summary>
		private static IEnumerable<uint> TestUIntegersSource = 
			Enumerable.Range(0, sizeof(uint) + 1).Reverse().SelectMany(
				index1 => Enumerable.Range(0, sizeof(uint) + 1).Reverse().Select(index2 => (index1 != sizeof(uint) ? 0x80U << (index1 * 8) : 0) | (index2 != sizeof(uint) ? 0x1U << (index2 * 8) : 0))
			);



		[Test]
		[Description("Test BitOps.GetFirstSetBit for uint type")]
		[TestCaseSource(nameof(TestUIntegersSource))]
		public void UIntTest(uint n) {
			Assert.AreEqual(TrueGetFirstSetBit(n), BitOps.GetFirstSetBit(n));
		}


		/// <summary>
		/// All 0x80 and 0x1 (the last and the first bits of byte) combinations for each byte for 16-bit ushort type.
		/// </summary>
		private static IEnumerable<ushort> TestUShortsSource = 
			Enumerable.Range(0, sizeof(ushort) + 1).Reverse().SelectMany(
				index1 => Enumerable.Range(0, sizeof(ushort) + 1).Reverse().Select(index2 => (ushort)((index1 != sizeof(ushort) ? 0x80U << (index1 * 8) : 0) | (index2 != sizeof(ushort) ? 0x1U << (index2 * 8) : 0)))
			);



		[Test]
		[Description("Test BitOps.GetFirstSetBit for ushort type")]
		[TestCaseSource(nameof(TestUShortsSource))]
		public void UShortTest(ushort n) {
			Assert.AreEqual(TrueGetFirstSetBit(n), BitOps.GetFirstSetBit(n));
		}

		/*--------------------------------Byte--------------------------------*/
		/// <summary>
		/// All 8-bit byte type values.
		/// </summary>
		private static IEnumerable<byte> TestByteSource = Enumerable.Range(0, 2 << (sizeof(byte) * 8)).Select(n => (byte)n);

		[Test]
		[Description("Test BitOps.GetFirstSetBit for byte type")]
		[TestCaseSource(nameof(TestByteSource))]
		public void ByteTest(byte n) {
			Assert.AreEqual(TrueGetFirstSetBit(n), BitOps.GetFirstSetBit(n));
		}

		static int TrueGetFirstSetBit(ulong n) {
			int counter = 0;
			while(n != 0) {
				if((n & 0b1) != 0)
					return counter;
				n >>= 1;
				counter++;
			}
			return -1;
		}
	}
}
