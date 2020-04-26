using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using WakProtocol;
using WakProtocol.Protocole.Server;

namespace WakfuBot.Client
{
    /// <summary>
    /// Class that manages a wakfu bot
    /// </summary>
    public class SocketBot
    {
        private static SslStream _SslStreamBot;
        private static TcpClient _ClientBot;
        private static NetworkStream _StreamData;
        private static ReaderProtocole Reader = new ReaderProtocole("username", "password"); // TODO LIST

        /// <summary>
        /// SSL certificate if needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        public static bool ValidateServerCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
        System.Security.Cryptography.X509Certificates.X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        /// <summary>
        /// Lets launch the bot
        /// </summary>
        public void StartingBot()
        {
            _ClientBot = new TcpClient(AddressFamily.InterNetwork);
            string[] addressConnect = ServerAddress.AuthServer.Split(':');
            _ClientBot.Connect(addressConnect[0], int.Parse(addressConnect[1]));

            using (SslStream sslStream = new SslStream(_ClientBot.GetStream(), true,
            new RemoteCertificateValidationCallback(ValidateServerCertificate), null))
            {
                if (false)
                {
                    _SslStreamBot.AuthenticateAsClient("127.0.0.1");
                    _SslStreamBot = sslStream;
                }
                else
                {
                    _StreamData = _ClientBot.GetStream();
                }
                ReadSocket();
            }
        }

        /// <summary>
        /// Read the data using the wakfu Protocol library
        /// </summary>
        private static void ReadSocket()
        {
            while (_ClientBot.Connected)
            {
                byte[] dataReceiver = new byte[5048];
                int receivedCount = _StreamData.Read(dataReceiver, 0, dataReceiver.Length);

                if (receivedCount < 1)
                    continue;
                byte[] data = dataReceiver.Take(receivedCount).ToArray();
                byte[] response = Reader.ReadPacket(data);
                if(response != null)
                {
                    _StreamData.Write(response);
                } 
            }
        }
    }
}
