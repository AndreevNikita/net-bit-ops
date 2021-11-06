using NetBitOps;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BitOpsTest {
	public class GetLastSetBitTests {
		[SetUp]
		public void Setup() {
		}

		/*--------------------------------ULong--------------------------------*/
		/// <summary>
		/// All 0x80 and 0x1 (the last and the first bits of byte) combinations for each byte for 64-bit ulong type.
		/// </summary>
		private static IEnumerable<ulong> TestULongSource = 
			Enumerable.Range(0, sizeof(ulong) + 1).Reverse().SelectMany(
				index1 => Enumerable.Range(0, sizeof(ulong) + 1).Reverse().Select(index2 => (index1 != sizeof(ulong) ? unchecked((ulong)0x80) << (index1 * 8) : 0) | (index2 != sizeof(ulong) ? unchecked((ulong)0x1) << (index2 * 8) : 0))
			);

		[Test]
		[Description("Test BitOps.GetLastSetBit for ulong type")]
		[TestCaseSource(nameof(TestULongSource))]
		public void ULongTest(ulong n) {
			Assert.AreEqual(TrueGetLastSetBit(n), BitOps.GetLastSetBit(n));
		}


		/*--------------------------------UInt--------------------------------*/
		/// <summary>
		/// All 0x80 and 0x1 (the last and the first bits of byte) combinations for each byte for 32-bit uint type.
		/// </summary>
		private static IEnumerable<uint> TestUIntegerSource = 
			Enumerable.Range(0, sizeof(uint) + 1).Reverse().SelectMany(
				index1 => Enumerable.Range(0, sizeof(uint) + 1).Reverse().Select(index2 => (index1 != sizeof(uint) ? unchecked((uint)0x80) << (index1 * 8) : 0) | (index2 != sizeof(uint) ? unchecked((uint)0x1) << (index2 * 8) : 0))
			);

		[Test]
		[Description("Test BitOps.GetLastSetBit for uint type")]
		[TestCaseSource(nameof(TestUIntegerSource))]
		public void UIntTest(uint n) {
			Assert.AreEqual(TrueGetLastSetBit(n), BitOps.GetLastSetBit(n));
		}
		

		/*--------------------------------UShort--------------------------------*/
		/// <summary>
		/// All 0x80 and 0x1 (the last and the first bits of byte) combinations for each byte for 16-bit ushort type.
		/// </summary>
		private static IEnumerable<ushort> TestUShortSource = 
			Enumerable.Range(0, sizeof(ushort) + 1).Reverse().SelectMany(
				index1 => Enumerable.Range(0, sizeof(ushort) + 1).Reverse().Select(index2 => (ushort)((index1 != sizeof(ushort) ? unchecked((ushort)0x80) << (index1 * 8) : 0) | (index2 != sizeof(ushort) ? unchecked((ushort)0x1) << (index2 * 8) : 0)))
			);

		[Test]
		[Description("Test BitOps.GetLastSetBit for ushort type")]
		[TestCaseSource(nameof(TestUShortSource))]
		public void UShortTest(ushort n) {
			Assert.AreEqual(TrueGetLastSetBit(n), BitOps.GetLastSetBit(n));
		}


		/*--------------------------------Byte--------------------------------*/
		/// <summary>
		/// All 8-bit byte type values.
		/// </summary>
		private static IEnumerable<byte> TestByteSource = Enumerable.Range(0, 2 << (sizeof(byte) * 8)).Select(n => (byte)n);

		[Test]
		[Description("Test BitOps.GetLastSetBit for byte type")]
		[TestCaseSource(nameof(TestByteSource))]
		public void ByteTest(byte n) {
			Assert.AreEqual(TrueGetLastSetBit(n), BitOps.GetLastSetBit(n));
		}

		static int TrueGetLastSetBit(ulong n) {
			int counter = -1;
			while(n != 0) {
				n >>= 1;
				counter++;
			}
			return counter;
		}

	}
}