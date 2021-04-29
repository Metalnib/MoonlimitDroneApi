using System;

namespace Moonlimit.DroneAPI.Domain
{
    public static class Base32Convert
    {
        private static readonly byte[] ValueMappingByte = {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0, 0, 0, 0, 0, 10, 11, 12, 13, 14, 15,
            16, 17, 1, 18, 19, 1, 20, 21, 0, 22, 23, 24, 25, 26, 0, 27, 28, 29, 30, 31, 0, 0, 0,
            0, 0, 0, 10, 11, 12, 13, 14, 15, 16, 17, 1, 18, 19, 1, 20, 21, 0, 22, 23, 24, 25, 26,
            0, 27, 28, 29, 30, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0
        };
        private static readonly string _encode32Chars =      "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
        private static readonly char[] _encode32CharsArray = "0123456789ABCDEFGHJKMNPQRSTVWXYZ".ToCharArray();
        
        public static string ToString(long input)
        {
            return string.Create(13,input, (buffer, id) =>
            {
                if (input <= 0) throw new ArgumentException("Input cannot be negative.");
                var encode32CharsArray = _encode32CharsArray;
                buffer[12] = encode32CharsArray[id & 31];
                buffer[11] = encode32CharsArray[(id >> 5) & 31];
                buffer[10] = encode32CharsArray[(id >> 10) & 31];
                buffer[9] = encode32CharsArray[(id >> 15) & 31];
                buffer[8] = encode32CharsArray[(id >> 20) & 31];
                buffer[7] = encode32CharsArray[(id >> 25) & 31];
                buffer[6] = encode32CharsArray[(id >> 30) & 31];
                buffer[5] = encode32CharsArray[(id >> 35) & 31];
                buffer[4] = encode32CharsArray[(id >> 40) & 31];
                buffer[3] = encode32CharsArray[(id >> 45) & 31];
                buffer[2] = encode32CharsArray[(id >> 50) & 31];
                buffer[1] = encode32CharsArray[(id >> 55) & 31];
                buffer[0] = encode32CharsArray[(id >> 60) & 31];
            });
        }
        
        const int PlaceShift = 5;
        
        public static long ToInt64(string value)
        {
            var input = value.AsSpan();
            if (input.Length > 11)
            {
                var decoded = 0L;
                long place = input.Length == 13 ? 1152921504606846976L : 36028797018963968L;
                decoded += ValueMappingByte[input[0]] * place;
                decoded += ValueMappingByte[input[1]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[2]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[3]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[4]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[5]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[6]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[7]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[8]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[9]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[10]] * (place >>= PlaceShift);
                decoded += ValueMappingByte[input[11]] * (place >>= PlaceShift);
                if (input.Length == 13)
                    decoded += ValueMappingByte[input[12]] * (place >>= PlaceShift);
                return decoded;
            }
            return -1;
        }
    }
}