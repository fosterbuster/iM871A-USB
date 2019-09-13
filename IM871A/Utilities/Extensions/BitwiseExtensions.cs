// <copyright file="BitwiseExtensions.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace IM871A.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for bitwise manipulation and general help.
    /// </summary>
    public static class BitwiseExtensions
    {
        private const byte SlipEnd = 0xC0;
        private const byte SlipEscape = 0xDB;
        private const byte SlipEscapeEnd = 0xDC;
        private const byte SlipEscapeEscape = 0xDD;

        private const ushort InitialCrcValue = 0xFFFF;
        private const short CrcCheckValue = 0x0F47;

        /// <summary>
        /// CRC CCITTT Table.
        /// </summary>
        private static readonly ushort[] CRC16Table =
        {
            0x0000, 0x1189, 0x2312, 0x329B, 0x4624, 0x57AD, 0x6536, 0x74BF,
            0x8C48, 0x9DC1, 0xAF5A, 0xBED3, 0xCA6C, 0xDBE5, 0xE97E, 0xF8F7,
            0x1081, 0x0108, 0x3393, 0x221A, 0x56A5, 0x472C, 0x75B7, 0x643E,
            0x9CC9, 0x8D40, 0xBFDB, 0xAE52, 0xDAED, 0xCB64, 0xF9FF, 0xE876,
            0x2102, 0x308B, 0x0210, 0x1399, 0x6726, 0x76AF, 0x4434, 0x55BD,
            0xAD4A, 0xBCC3, 0x8E58, 0x9FD1, 0xEB6E, 0xFAE7, 0xC87C, 0xD9F5,
            0x3183, 0x200A, 0x1291, 0x0318, 0x77A7, 0x662E, 0x54B5, 0x453C,
            0xBDCB, 0xAC42, 0x9ED9, 0x8F50, 0xFBEF, 0xEA66, 0xD8FD, 0xC974,
            0x4204, 0x538D, 0x6116, 0x709F, 0x0420, 0x15A9, 0x2732, 0x36BB,
            0xCE4C, 0xDFC5, 0xED5E, 0xFCD7, 0x8868, 0x99E1, 0xAB7A, 0xBAF3,
            0x5285, 0x430C, 0x7197, 0x601E, 0x14A1, 0x0528, 0x37B3, 0x263A,
            0xDECD, 0xCF44, 0xFDDF, 0xEC56, 0x98E9, 0x8960, 0xBBFB, 0xAA72,
            0x6306, 0x728F, 0x4014, 0x519D, 0x2522, 0x34AB, 0x0630, 0x17B9,
            0xEF4E, 0xFEC7, 0xCC5C, 0xDDD5, 0xA96A, 0xB8E3, 0x8A78, 0x9BF1,
            0x7387, 0x620E, 0x5095, 0x411C, 0x35A3, 0x242A, 0x16B1, 0x0738,
            0xFFCF, 0xEE46, 0xDCDD, 0xCD54, 0xB9EB, 0xA862, 0x9AF9, 0x8B70,
            0x8408, 0x9581, 0xA71A, 0xB693, 0xC22C, 0xD3A5, 0xE13E, 0xF0B7,
            0x0840, 0x19C9, 0x2B52, 0x3ADB, 0x4E64, 0x5FED, 0x6D76, 0x7CFF,
            0x9489, 0x8500, 0xB79B, 0xA612, 0xD2AD, 0xC324, 0xF1BF, 0xE036,
            0x18C1, 0x0948, 0x3BD3, 0x2A5A, 0x5EE5, 0x4F6C, 0x7DF7, 0x6C7E,
            0xA50A, 0xB483, 0x8618, 0x9791, 0xE32E, 0xF2A7, 0xC03C, 0xD1B5,
            0x2942, 0x38CB, 0x0A50, 0x1BD9, 0x6F66, 0x7EEF, 0x4C74, 0x5DFD,
            0xB58B, 0xA402, 0x9699, 0x8710, 0xF3AF, 0xE226, 0xD0BD, 0xC134,
            0x39C3, 0x284A, 0x1AD1, 0x0B58, 0x7FE7, 0x6E6E, 0x5CF5, 0x4D7C,
            0xC60C, 0xD785, 0xE51E, 0xF497, 0x8028, 0x91A1, 0xA33A, 0xB2B3,
            0x4A44, 0x5BCD, 0x6956, 0x78DF, 0x0C60, 0x1DE9, 0x2F72, 0x3EFB,
            0xD68D, 0xC704, 0xF59F, 0xE416, 0x90A9, 0x8120, 0xB3BB, 0xA232,
            0x5AC5, 0x4B4C, 0x79D7, 0x685E, 0x1CE1, 0x0D68, 0x3FF3, 0x2E7A,
            0xE70E, 0xF687, 0xC41C, 0xD595, 0xA12A, 0xB0A3, 0x8238, 0x93B1,
            0x6B46, 0x7ACF, 0x4854, 0x59DD, 0x2D62, 0x3CEB, 0x0E70, 0x1FF9,
            0xF78F, 0xE606, 0xD49D, 0xC514, 0xB1AB, 0xA022, 0x92B9, 0x8330,
            0x7BC7, 0x6A4E, 0x58D5, 0x495C, 0x3DE3, 0x2C6A, 0x1EF1, 0x0F78,
        };

        /// <summary>
        /// Gets the high nibble of the passed <paramref name="b"/>.
        /// </summary>
        /// <param name="b">the byte.</param>
        /// <returns>the high nibble.</returns>
        public static int HighNibble(this byte b)
        {
            return (b >> 4) & 0b00001111;
        }

        /// <summary>
        /// Gets the low nibble of the passed <paramref name="b"/>.
        /// </summary>
        /// <param name="b">the byte.</param>
        /// <returns>the low nibble.</returns>
        public static int LowNibble(this byte b)
        {
            return b & 0b00001111;
        }

        public static byte ConcatBytes(byte highNibble, byte lowNibble)
        {
            return (byte)((highNibble << 4) | lowNibble);
        }

        /// <summary>
        /// Gets the bit at the <paramref name="position"/>.
        /// </summary>
        /// <param name="b">the byte.</param>
        /// <param name="position">the bit at the given position to extract.</param>
        /// <returns>A boolean indicating if it was 1 or 0.</returns>
        public static bool GetBit(this byte b, int position)
        {
            return (b & (1 << position)) != 0;
        }

        /// <summary>
        /// Encodes as SLIP.
        /// </summary>
        /// <param name="bytes">the bytes to be encoded.</param>
        /// <param name="appendCrc">optional boolean indicating if CRC16 should be appended, before encoding SLIP.</param>
        /// <returns>the <paramref name="bytes"/>, but SLIP encoded.</returns>
        public static IList<byte> EncodeSlipFrame(this IList<byte> bytes, bool appendCrc = true)
        {
            var result = new List<byte>();
            if(appendCrc)
            {
                bytes.AppendCrc();
            }

            foreach(var b in bytes)
            {
                if(b == SlipEnd)
                {
                    result.Add(SlipEscape);
                    result.Add(SlipEscapeEnd);
                }
                else if(b == SlipEscape)
                {
                    result.Add(SlipEscape);
                    result.Add(SlipEscapeEscape);
                }
                else
                {
                    result.Add(b);
                }
            }

            result.Insert(0, SlipEnd);
            result.Add(SlipEnd);

            return result;
        }

        /// <summary>
        /// Transforms a hex-formatted string to a byte array.
        /// </summary>
        /// <param name="hexString">the string.</param>
        /// <returns>a byte array of the hex-strings binary value.</returns>
        public static byte[] HexStringToBytes(this string hexString)
        {
            var sanitizedHex = hexString.ToUpper();

            if(sanitizedHex.Length % 2 == 1)
            {
                throw new ArgumentException("The binary key cannot have an odd number of digits");
            }

            var arr = new byte[sanitizedHex.Length >> 1];

            for(var i = 0; i < sanitizedHex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(sanitizedHex[i << 1]) << 4) +
                                      GetHexVal(sanitizedHex[(i << 1) + 1]));
            }

            return arr;
        }

        /// <summary>
        /// Decodes and strips SLIP.
        /// </summary>
        /// <param name="bytes">the bytes to be decoded and stripped.</param>
        /// <param name="validateCrc">optional boolean indicating if CRC16 should be validated.</param>
        /// <returns>the decoded frame.</returns>
        public static IList<byte> StripSlipFrame(this IList<byte> bytes, bool validateCrc = true)
        {
            // IList is nice and all, but i'd rather make a copy, than deal with an array might being passed.
            var list = bytes.ToList();

            for(var i = 0; i < list.Count; i++)
            {
                // Do we have a slip-escape and an escape end? If yes, remove them and replace with a slip-end.
                // Checks for bounds, so were safe. Could be written prettier - But honestly who cares?
                if(list[i] == SlipEscape && i + 1 < list.Count && list[i + 1] == SlipEscapeEnd)
                {
                    list.RemoveAt(i);
                    list.RemoveAt(i);
                    list.Insert(i, SlipEnd);
                }

                // Removes escape escape.
                if(list[i] == SlipEscape && i + 1 < list.Count && list[i + 1] == SlipEscapeEscape)
                {
                    list.RemoveAt(i + 1);
                }
            }

            if(list[0] == SlipEnd && list[list.Count - 1] == SlipEnd)
            {
                list.RemoveAt(0);
                list.RemoveAt(list.Count - 1);
            }

            if(validateCrc)
            {
                var crcCorrect = ValidateCrc(list);

                if(crcCorrect)
                {
                    list.RemoveAt(list.Count - 1);
                    list.RemoveAt(list.Count - 1);
                }
                else
                {
                    throw new ArgumentException("Frame did not have a valid checksum.");
                }
            }

            return list;
        }

        /// <summary>
        /// Applies a bitmask.
        /// </summary>
        /// <param name="b">the byte to mask.</param>
        /// <param name="mask">the mask to apply.</param>
        /// <returns>the masked value of the byte.</returns>
        public static byte Mask(this byte b, byte mask)
        {
            return (byte)(b & mask);
        }

        /// <summary>
        /// Sets the bit at the <paramref name="position"/>.
        /// </summary>
        /// <param name="b">the byte to manipulate.</param>
        /// <param name="position">the postion.</param>
        /// <returns>the same byte, but different.</returns>
        public static byte SetBit(this byte b, int position)
        {
            return (byte)(b | (1 << position));
        }

#pragma warning disable SA1005 // Single line comments should begin with single space
#pragma warning disable S125 // Sections of code should not be commented out

        //public static byte Or(this byte b, byte other)

        //{
        //    return (byte)(b | other);
        //}

        //public static byte ShiftRight(this byte b, byte places)
        //{
        //    return (byte)(b >> places);
        //}

        //public static byte ShiftLeft(this byte b, byte places)
        //{
        //    return (byte)(b << places);
        //}
#pragma warning restore SA1005 // Single line comments should begin with single space
#pragma warning restore S125 // Sections of code should not be commented out
        /// <summary>
        /// Parses the passed <paramref name="bytes"/> into a hex-formatted string.
        /// </summary>
        /// <param name="bytes">The bytes to be parsed.</param>
        /// <returns>A hex formatted string.</returns>
        public static string ToHexString(this IList<byte> bytes)
        {
            var c = new char[bytes.Count * 2];
            for(var i = 0; i < bytes.Count; i++)
            {
                var b = bytes[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = bytes[i] & 0xF;
                c[(i * 2) + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }

            return new string(c);
        }

        /// <summary>
        /// Appends a CRC16 to the end of the <paramref name="bytes"/>.
        /// </summary>
        /// <param name="bytes">the bytes to append to.</param>
        /// <returns><paramref name="bytes"/>, but with CRC16 appended.</returns>
        public static IList<byte> AppendCrc(this IList<byte> bytes)
        {
            var crc = bytes.CalculateCrc();

            bytes.Add((byte)(crc & 0xFF)); // MSB
            bytes.Add((byte)(crc >> 8)); // LSB

            return bytes;
        }

        /// <summary>
        /// Calculates the CRC16 CCITTT.
        /// </summary>
        /// <param name="bytes">the bytes.</param>
        /// <returns>CRC16 CCITTT.</returns>
        public static ushort CalculateCrc(this IList<byte> bytes)
        {
            var crc = InitialCrcValue;

            foreach(var b in bytes)
            {
                crc = (ushort)((crc >> 8) ^ CRC16Table[(crc ^ b) & 0x00FF]);
            }

            // WiMod uses ones complement
            crc = (ushort)~crc;
            return crc;
        }

        /// <summary>
        /// Validates CRC16.
        /// </summary>
        /// <param name="bytes">bytes to validate.</param>
        /// <returns>A boolean indicating if the CRC is valid.</returns>
        public static bool ValidateCrc(this IList<byte> bytes)
        {
            var crc = bytes.CalculateCrc();

            return crc == CrcCheckValue;
        }

        private static int GetHexVal(char hex)
        {
            var val = (int)hex;

            // For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
        }
    }
}