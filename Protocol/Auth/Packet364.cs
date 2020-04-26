using System;
using WakProtocol.Helper;
using wakufSniffing.mitm.Protocole;

namespace WakProtocol.Protocole.Auth
{
    class Packet364 : StructureOfPacket
    {
        private static byte[] data;
        public override int Id
        {
            get
            {
                return (Int32)ProtcoleAuthBuild.number1;
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
                return HelperReadByte.StringToByteArray("000C00001601004302022D31");
            }
        }
    }
}
