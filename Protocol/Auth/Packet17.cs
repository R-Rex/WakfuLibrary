using System;
using WakProtocol.Helper;
using wakufSniffing.mitm.Protocole;

namespace WakProtocol.Protocole.Auth
{
    class Packet17 : StructureOfPacket
    {
        private static byte[] data;
        public override int Id
        {
            get
            {
                return (Int32)ProtcoleAuthBuild.number4;
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
                return HelperReadByte.StringToByteArray("0005080222");
            }
        }
    }
}
