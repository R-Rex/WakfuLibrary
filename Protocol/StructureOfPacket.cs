using System;
using System.Collections.Generic;
using System.Text;

namespace WakProtocol.Protocole
{
    public abstract class StructureOfPacket
    {
        /// <summary>
        /// Reception identifier of the packet coming from the server
        /// </summary>
        public abstract int Id
        {
            get;
        }
        /// <summary>
        /// Allows you to give it a data for the treatment or to recover the data of the next packet one depending on the other
        /// </summary>
        public abstract byte[] Data
        {
            set;
            get;
        }
    }
}
