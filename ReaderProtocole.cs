using System;
using System.Linq;
using System.Reflection;
using WakProtocol.Helper;
using WakProtocol.Protocole;

namespace WakProtocol
{

    /// <summary>
    /// Class using WakfuProtocol
    /// </summary>
    public class ReaderProtocole
    {
        private string Username = "";
        private string Password = "";
        /// <summary>
        /// Connection identifier ANKAMA(WAKFU)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ReaderProtocole(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        /// <summary>
        /// Allow to have the next packet of the network frame of the wakfu protocol
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] ReadPacket(byte[] data)
        {
            byte[] response = new byte[] { };
            int opCode = HelperReadByte.ReadOpCode(data, true);
            var subclassTypes = Assembly
                .GetAssembly(typeof(StructureOfPacket))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(StructureOfPacket)));

            foreach (var objectType in subclassTypes)
            {
                StructureOfPacket instance = (StructureOfPacket)Activator.CreateInstance(objectType);

                if (instance.Id == opCode)
                {
                    instance.Data = data;
                    response = instance.Data;
                }
            }

            return response;
        }
    }
}
