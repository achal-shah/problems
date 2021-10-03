using System;

namespace primitives
{
    public class Parity
    {
        public static void ExecuteParity()
        {
            Console.WriteLine("Calculate Parity");
            Console.WriteLine($"Parity: {CalculateParity(0x0000000200000003)}"); // odd
            Console.WriteLine($"Parity: {CalculateParity(0x0000000300000003)}"); // even
            Console.WriteLine($"Parity: {CalculateParity(0x000000020000000e)}"); // even
            Console.WriteLine($"Parity: {CalculateParity(0x000000030000000e)}"); // odd
            Console.WriteLine($"Parity: {CalculateParity(0xffffffffffffffff)}"); // even

            Console.WriteLine("\nSwap bits");
            Console.WriteLine("0x0000000200000003 -> {0:X}", SwapBits(0x0000000200000003, 0, 2));

            Console.WriteLine("\nReverse bits");
            Console.WriteLine("0x0000000000000003 -> {0:X}", ReverseBits(0x0000000000000003));
        }

        // Calculate the parity of a 64 bit value.
        public static short CalculateParity(ulong number)
        {
            // Each bit of this 16 bit value represents the parity of the
            // corresponding index of the bit.
            ushort parityLookup = 0b0110100110010110;
            
            number ^= number >> 32;
            number ^= number >> 16;
            number ^= number >> 8;
            number ^= number >> 4;
            ushort index = (ushort)(number & 0xf);
            return (short)(parityLookup >> index & 0b1);
        }

        // Swap the ith and jth bits in value
        public static ulong SwapBits(ulong value, int i, int j)
        {
            var biti = (value >> i) & 0b1;
            var bitj = (value >> j) & 0b1;

            if (biti == bitj) return value;

            // Othewise flip the values
            ulong mask = (1UL << i) | (1UL << j);

            return value ^ mask;
        }

        // Reverse the bits in the 64 bit value
        public static ulong ReverseBits(ulong value)
        {
            ulong retval = 0;

            for (int i= 0; i < 64; ++i)
            {
                var bitval = (value >> (63 - i)) & 0b1;
                if (bitval == 1)
                {
                    retval ^= (1UL << i);
                }
            }

            return retval;
        }
    }
}