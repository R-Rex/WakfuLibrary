using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WakProtocol.Helper;
using wakufSniffing.mitm.Protocole;

namespace WakProtocol.Protocole.Auth
{
    class PublicKeyMessage : StructureOfPacket
    {
        private static byte[] data;
        public override int Id
        {
            get
            {
                return (int)ProtcoleAuthBuild.number5;
            }
        }
        public override byte[] Data
        {
            set
            {
                data = value;
            }
            get
            {
                byte[] publicKey = data.Skip(12).ToArray();
                byte[] dataCrypt = AuthData("username", "password", (long)128, publicKey); // TODO LIST 
                byte[] testing = new byte[] { };
                testing = testing.Concat(new byte[] { 0, 137, 8, 1, 172, 0, 0, 0, 128 }).Concat(dataCrypt).ToArray();
                return testing;
            }
        }
        /// <summary>
        /// Build the data for the encrypted
        /// </summary>
        /// <param name="loginStr"></param>
        /// <param name="passwordStr"></param>
        /// <param name="salt"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static byte[] AuthData(string loginStr, string passwordStr, long salt, byte[] publicKey)
        {
            byte[] login = Encoding.UTF8.GetBytes(loginStr);
            byte loginLength = (byte)login.Length;
            byte[] password = Encoding.UTF8.GetBytes(passwordStr);
            byte passwordLength = (byte)password.Length;
            var data = salt.GetBytes().Concat(loginLength).Concat(login).ToArray().Concat(passwordLength).Concat(password).ToArray();
            return PublicKeyEncrypt(data, publicKey);
        }

        /// <summary>
        /// Enables data encryption with the public key in a byte [] of 128byte
        /// </summary>
        /// <param name="data"></param>
        /// <param name="publickey"></param>
        /// <returns></returns>
        public static byte[] PublicKeyEncrypt(byte[] data, byte[] publickey)
        {
            var rsaKeyParameters = (RsaKeyParameters)PublicKeyFactory.CreateKey(new MemoryStream(publickey, false));
            var rsaParameters = new RSAParameters();
            rsaParameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
            rsaParameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);
            return rsa.Encrypt(data, false);
        }
    }
}
