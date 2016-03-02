using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    class ContainerAddressRepository : ContainerAddress
    {

        //container
        private uint containerStart = 0x579A78;
        private uint[] containerOffsets = { 0x0, 0x14 };

        private uint containerdId = 0x0C;
        private uint containerCapacity = 0x10;
        private uint containerItem = 0x14;
        private uint containerName = 0x18;
        private uint containerHasParent = 0x30;
        private uint containerIsClosed = 0x31;
        private uint containerItemsDeque = 0x40;
        private uint containerItemsDequeFirstIndex = 0x48;
        private uint containerItemsDequeSize = 0x4c;


        //singleton instance
        private static ContainerAddressRepository instance;

        private ContainerAddressRepository() { }

        public static ContainerAddressRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContainerAddressRepository();
                }
                return instance;
            }
        }


        public uint GetContainerStartAddress()
        {
            return this.containerStart;
        }

        public uint[] GetContainerOffsetsAddress()
        {
            return this.containerOffsets;
        }

        public uint GetContainerIdAddress()
        {
            return this.containerdId;
        }

        public uint GetContainerCapacityAddress()
        {
            return this.containerCapacity;
        }

        public uint GetContainerItemAddress()
        {
            return this.containerItem;
        }

        public uint GetContainerNameAddress()
        {
            return this.containerName;
        }

        public uint GetContainerHasParentAddress()
        {
            return this.containerHasParent;
        }

        public uint GetContainerIsClosedAddress()
        {
            return this.containerIsClosed;
        }

        public uint GetContainerItemsDequeAddress()
        {
            return this.containerItemsDeque;
        }

        public uint GetContainerItemsDequeFirstIndex()
        {
            return this.containerItemsDequeFirstIndex;
        }

        public uint GetContainerItemsDequeSize()
        {
            return this.containerItemsDequeSize;
        }

    }
}
