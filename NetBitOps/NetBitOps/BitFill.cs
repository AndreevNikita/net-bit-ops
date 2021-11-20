using System;
using System.Collections.Generic;
using System.Text;

namespace NetBitOps {
	public static partial class BitOps {

		/// <summary>
		/// Fills <paramref name="length"/> uint32 number bits count from <paramref name="startIndex"/>.
		/// </summary>
		/// <param name="startIndex">The start index to fill the result.</param>
		/// <param name="length">The number of filled bits.</param>
		/// <returns>The filled uint32 value.</returns>
		public static uint Fill(int startIndex, int length) => ~RightFill(startIndex) & RightFill(startIndex + length);

		/// <summary>
		/// Fills <paramref name="length"/> uint32 number bits from the right side.
		/// </summary>
		/// <param name="length">The length of set bits chain.</param>
		/// <returns>The filled uint32 value.</returns>
		public static uint RightFill(int length) => length <= 0 ? 0 : (length & 0xffffffe0) == 0 ? ~(0xffffffff << length) : 0xffffffff;

		/// <summary>
		/// Fills <paramref name="length"/> uint32 number bits from the left side.
		/// </summary>
		/// <param name="length">The length of set bits chain.</param>
		/// <returns>The filled uint32 value.</returns>
		public static uint LeftFill(int length) => length <= 0 ? 0 : (length & 0xffffffe0) == 0 ? ~(0xffffffff >> length) : 0xffffffff;

		/// <summary>
		/// Fills <paramref name="length"/> uint64 number bits count from <paramref name="startIndex"/>.
		/// </summary>
		/// <param name="startIndex">The start index to fill the result.</param>
		/// <param name="length">The number of filled bits.</param>
		/// <returns>The filled uint64 value.</returns>
		public static ulong FillLong(int startIndex, int length) => ~RightFillLong(startIndex) & RightFillLong(startIndex + length);

		/// <summary>
		/// Fills <paramref name="length"/> uint64 number bits from the right side.
		/// </summary>
		/// <param name="length">The length of set bits chain.</param>
		/// <returns>The filled uint64 value.</returns>
		public static ulong RightFillLong(int length) => length <= 0 ? 0 : ((ulong)length & 0xffffffffffffffc0) == 0 ? ~(0xffffffffffffffff << length) : 0xffffffffffffffff;

		/// <summary>
		/// Fills <paramref name="length"/> uint64 number bits from the length side.
		/// </summary>
		/// <param name="length">The length of set bits chain.</param>
		/// <returns>The filled uint64 value.</returns>
		public static ulong LeftFillLong(int length) => length <= 0 ? 0 : ((ulong)length & 0xffffffffffffffc0) == 0 ? ~(0xffffffffffffffff >> length) : 0xffffffffffffffff;

	}
}
