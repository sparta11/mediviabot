using MediviaBot.game.model;
using MediviaBot.memory.container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.memory.containers
{
    class ContainerReaderHelper : ContainerMemoryReader
    {


        public List<Container> GetAllContainersWithItems()
        {

            List<uint> containersAdress = structHelper.iterateMap(containerStartAdr);
            List<Container> containers = new List<Container>();
            foreach (uint adr in containersAdress)
            {

                uint containerAdr = ReadUInt32(adr + addresses.GetContainerOffsetsAddress()[1]);

                Container container = readContainer(containerAdr);
                if (container == null)
                    continue;

                uint dequeStart = ReadUInt32(containerAdr + addresses.GetContainerItemsDequeAddress());
                int dequeSize = ReadInt32(containerAdr + addresses.GetContainerItemsDequeSize());
                int firstIndex = ReadInt32(containerAdr + +addresses.GetContainerItemsDequeFirstIndex());

                //Console.WriteLine("|--------------------------------------------|");
                //Console.WriteLine("|-- Iterating deque of: container: " + container.Id);
                //Console.WriteLine("|-- Size              : " + dequeSize);
                //Console.WriteLine("|-- firstIndex        : " + firstIndex);
                //Console.WriteLine("|--------------------------------------------|");

                List<uint> itemsAddrs = structHelper.iterateDeque(containerAdr, dequeStart, dequeSize, firstIndex);
                List<Item> items = getAllItems(itemsAddrs);
                container.Items = items;
                containers.Add(container);
            }

            return containers;
        }

        private List<Item> getAllItems(List<uint> itemsAddrs)
        {
            List<Item> items = new List<Item>();
            foreach (uint itemAdr in itemsAddrs)
            {
                Item item = itemReader.ReadItem(itemAdr);
                items.Add(item);
            }

            return items;
        }

        private Container readContainer(uint containerAddress)
        {

            //Console.WriteLine("Container addres: " + Convert.ToUInt32(containerAddress + addresses.GetContainerIdAddress()).ToString("X") );

            try
            {
                int index = ReadInt32(containerAddress + addresses.GetContainerIdAddress());
                int capacity = ReadInt32(containerAddress + addresses.GetContainerCapacityAddress());
                string name = ReadString(containerAddress + addresses.GetContainerNameAddress(), 18);
                byte hasParentByte = ReadByte(containerAddress + addresses.GetContainerHasParentAddress());
                bool hasParent = Convert.ToBoolean(hasParentByte);
                byte isClosedByte = ReadByte(containerAddress + addresses.GetContainerIsClosedAddress());
                bool isClosed = Convert.ToBoolean(isClosedByte);
                //int itemQuantity = ReadInt32(containerAddress + addresses.GetContainerItemsDequeSize());
                uint firstIndex = ReadUInt32(containerAddress + addresses.GetContainerItemsDequeFirstIndex());

                if (containerAddress == 0 || String.IsNullOrEmpty(name) || index > 1000 || firstIndex > 50)
                    return null;

                uint itemAdr = ReadUInt32(containerAddress + addresses.GetContainerItemAddress());
                Item item = itemReader.ReadItem(itemAdr);

                Container container = new Container(new string[] { "container", "pickable" }, index, capacity, hasParent, isClosed, item);
                return container;
            }
            catch (Exception)
            {
                Console.WriteLine("Error while readContainer:");
                return null;
            }

        }


    }
}
