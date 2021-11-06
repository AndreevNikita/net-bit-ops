using System;

namespace NetBitOps {
	
	public static class BitOps {

		/// <summary>
		/// The precomputed table of the last set bit index for each byte value.
		/// </summary>
		private static sbyte[] lastSetBitCache = new sbyte[] {
			-1, 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3,
			4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
			6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
			6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
			6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
			7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
		};

		/// <summary>
		/// Returns the index of the last set bit in the binary number representation or -1 if it's missing.
		/// </summary>
		/// <param name="n">The 64-bit ulong value.</param>
		/// <returns>The index of the last set bit in the binary n representation or -1.</returns>
		public static int GetLastSetBit(ulong n) {
			if((n & 0xffffffff00000000) == 0) {
				if((n & 0xffff0000) == 0) {
					if((n & 0xff00) == 0) { 
						//If all the bits are zero, we'll be here
						return lastSetBitCache[n];
					} else {
						return lastSetBitCache[n >> 8] + 8;
					}
				} else {
					if((n & 0xff000000) == 0) {
						return lastSetBitCache[n >> 16] + 16;
					} else {
						return lastSetBitCache[n >> 24] + 24;
					}
				}
			} else {
				if((n & 0xffff000000000000) == 0) {
					if((n & 0xff0000000000) == 0) { 
						return lastSetBitCache[n >> 32] + 32;
					} else {
						return lastSetBitCache[n >> 40] + 40;
					}
				} else {
					if((n & 0xff00000000000000) == 0) {
						return lastSetBitCache[n >> 48] + 48;
					} else {
						return lastSetBitCache[n >> 56] + 56;
					}
				}
			}
		}

		/// <summary>
		/// Returns the index of the last set bit in the binary number representation or -1 if it's missing.
		/// </summary>
		/// <param name="n">The 32-bit uint value.</param>
		/// <returns>The index of the last set bit in the binary n representation or -1.</returns>
		public static int GetLastSetBit(uint n) {
			if((n & 0xffff0000) == 0) {
				if((n & 0xff00) == 0) { 
					//If all the bits are zero, we'll be here
					return lastSetBitCache[n];
				} else {
					return lastSetBitCache[n >> 8] + 8;
				}
			} else {
				if((n & 0xff000000) == 0) {
					return lastSetBitCache[n >> 16] + 16;
				} else {
					return lastSetBitCache[n >> 24] + 24;
				}
			}
		}

		/// <summary>
		/// Returns the index of the last set bit in the binary number representation or -1 if it's missing.
		/// </summary>
		/// <param name="n">The 16-bit ushort value.</param>
		/// <returns>The index of the last set bit in the binary n representation or -1.</returns>
		public static int GetLastSetBit(ushort n) {
			if((n & 0xff00) == 0) { 
				//If all the bits are zero, we'll be here
				return lastSetBitCache[n];
			} else {
				return lastSetBitCache[n >> 8] + 8;
			}
		}

		/// <summary>
		/// Returns the index of the last set bit in the binary number representation or -1 if it's missing.
		/// </summary>
		/// <param name="n">The 8-bit byte value.</param>
		/// <returns>The index of the last set bit in the binary n representation or -1.</returns>
		public static int GetLastSetBit(byte n) => lastSetBitCache[n];

		/// <summary>
		/// The precomputed table of the first set bit index for each byte value.
		/// </summary>
		private static sbyte[] firstSetBitCache = new sbyte[] {
			-1, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			4, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			5, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			4, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			6, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			4, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			5, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			4, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			7, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			4, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			5, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			4, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			6, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			4, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			5, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
			4, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
		};

		/// <summary>
		/// Returns the index of the first set bit in the binary number representation or -1 if it's missing.
		/// </summary>
		/// <param name="n">The 64-bit ulong value.</param>
		/// <returns>The index of the first set bit in the binary n representation or -1.</returns>
		public static int GetFirstSetBit(ulong n) {
			if((n & 0xffffffff) == 0) {
				if((n & 0xffff00000000) == 0) {
					if((n & 0xff000000000000) == 0) {
						//If all the bits are zero, we'll be here
						return n == 0 ? -1 : firstSetBitCache[(n >> 56) & 0xff] + 56;
					} else {
						return firstSetBitCache[(n >> 48) & 0xff] + 48;
					}
				} else {
					if((n & 0xff00000000) == 0) {
						return firstSetBitCache[(n >> 40) & 0xff] + 40;
					} else {
						return firstSetBitCache[(n >> 32) & 0xff] + 32;
					}
				}
			} else {
				if((n & 0xffff) == 0) {
					if((n & 0xff0000) == 0) {
						return firstSetBitCache[(n >> 24) & 0xff] + 24;
					} else {
						return firstSetBitCache[(n >> 16) & 0xff] + 16;
					}
				} else {
					if((n & 0xff) == 0) {
						return firstSetBitCache[(n >> 8) & 0xff] + 8;
					} else {
						return firstSetBitCache[(n) & 0xff];
					}
				}
			}
		}

		/// <summary>
		/// Returns the index of the first set bit in the binary number representation or -1 if it's missing.
		/// </summary>
		/// <param name="n">The 32-bit uint value.</param>
		/// <returns>The index of the first set bit in the binary n representation or -1.</returns>
		public static int GetFirstSetBit(uint n) {
			if((n & 0xffff) == 0) {
				if((n & 0xff0000) == 0) {
					//If all the bits are zero, we'll be here
					return n == 0 ? -1 : firstSetBitCache[(n >> 24) & 0xff] + 24;
				} else {
					return firstSetBitCache[(n >> 16) & 0xff] + 16;
				}
			} else {
				if((n & 0xff) == 0) {
					return firstSetBitCache[(n >> 8) & 0xff] + 8;
				} else {
					return firstSetBitCache[(n) & 0xff];
				}
			}
		}

		/// <summary>
		/// Returns the index of the first set bit in the binary number representation or -1 if it's missing.
		/// </summary>
		/// <param name="n">The 16-bit ushort value.</param>
		/// <returns>The index of the first set bit in the binary n representation or -1.</returns>
		public static int GetFirstSetBit(ushort n) {
			if((n & 0xff) == 0) {
				//If all the bits are zero, we'll be here
				return n == 0 ? -1 : firstSetBitCache[(n >> 8) & 0xff] + 8;
			} else {
				return firstSetBitCache[(n) & 0xff];
			}
		}

		/// <summary>
		/// Returns the index of the first set bit in the binary number representation or -1 if it's missing.
		/// </summary>
		/// <param name="n">The 8-bit byte value.</param>
		/// <returns>The index of the first set bit in the binary n representation or -1.</returns>
		public static int GetFirstSetBit(byte n) => firstSetBitCache[n];

	}
}
