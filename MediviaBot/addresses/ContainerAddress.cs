using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    interface ContainerAddress
    {

        ////container
        uint GetContainerStartAddress();
        uint[] GetContainerOffsetsAddress();

        uint GetContainerIdAddress();
        uint GetContainerCapacityAddress();
        uint GetContainerItemAddress();
        uint GetContainerNameAddress();
        uint GetContainerHasParentAddress();
        uint GetContainerIsClosedAddress();
        uint GetContainerItemsDequeAddress();
        uint GetContainerItemsDequeFirstIndex();

        uint GetContainerItemsDequeSize();
    }
}
