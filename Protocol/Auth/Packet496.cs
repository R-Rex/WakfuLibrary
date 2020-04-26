﻿using System;
using System.Text;
using WakProtocol.Helper;
using wakufSniffing.mitm.Protocole;

namespace WakProtocol.Protocole.Auth
{
    class Packet496 : StructureOfPacket
    {
        private static byte[] data;
        public override int Id
        {
            get
            {
                return (Int32)ProtcoleAuthBuild.number7;
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
                return HelperReadByte.StringToByteArray("00050801CE");
            }
        }
    }
}
