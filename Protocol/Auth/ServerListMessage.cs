using System;
using System.Collections.Generic;
using System.Text;
using wakufSniffing.mitm.Protocole;

namespace WakProtocol.Protocole.Packet
{
    class ServerListMessage : StructureOfPacket
    {
        private static byte[] data;
        public override int Id
        {
            get
            {

                return (int)ProtcoleAuthBuild.number9;
            }
        }
        public override byte[] Data
        {
            set
            {
                data = value;
                string read = Encoding.UTF8.GetString(data);
            }
            get
            {
                return null;
            }
        }
    }
}

