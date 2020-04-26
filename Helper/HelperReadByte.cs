using System;
using System.IO;
using System.Linq;
using System.Text;

namespace WakProtocol.Helper
{
    public static class HelperReadByte
    {
        /// <summary>
        /// Get byte Array
        /// </summary>
        /// <param name="lg"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this long lg)
        {
            return BitConverter.GetBytes((long)lg);
        }
        /// <summary>
        /// Concat one byte in the byte[] Array
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static byte[] Concat(this byte[] first, byte second)
        {
            var p = first.ToList();
            p.Add(second);
            return p.ToArray();
        }
        /// <summary>
        /// Read the OpCode (Is ID packet)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="IsServer"></param>
        /// <returns></returns>
        public static int ReadOpCode(this byte[] array, bool IsServer)
        {
            int OpCode = 0;
            if (IsServer)
            {
                OpCode = BitConverter.ToUInt16(array.Skip(2).Take(2).Reverse().ToArray(), 0);
            }
            else
            {
                OpCode = BitConverter.ToUInt16(array.Take(5).ToArray().Reverse().Take(2).ToArray(), 0);
            }
            return OpCode;
        }
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
