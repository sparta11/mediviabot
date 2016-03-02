
using MediviaBot.addresses;
using MediviaBot.game.model;
using MediviaBot.memory.containers;
using MediviaBot.memory.item;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.memory.container
{
    class ContainerMemoryReader : MemoryManager, ContainerReader
    {

        protected ItemReader itemReader = new ItemMemoryReader();
        protected ContainerAddress addresses = ContainerAddressRepository.Instance;
        protected StructureHelper structHelper = new StructureHelper();

        protected uint containerStartAdr = 0;
        public ContainerMemoryReader()
        {
            this.containerStartAdr = ReadUInt32(GetBaseAddress() + addresses.GetContainerStartAddress());
        }

        public List<Container> GetAllContainers()
        {
            return new ContainerReaderHelper().GetAllContainersWithItems();
        }

        public Container GetContainerByIndex(int index)
        {
            List<Container> containers = this.GetAllContainers();

            foreach (Container c in containers)
            {
                if (c.Index == index)
                    return c;
            }

            Console.WriteLine("CotainerReader: Could not found a container with index: " + index);
            return null;
        }

        public Container GetContainerByIndex(string index)
        {
           
            try
            {
                int indexInt = Convert.ToInt32(index);
                //Console.WriteLine("Container index: " + idInt);
                return this.GetContainerByIndex(indexInt);
            }
            catch (Exception)
            {
                Console.WriteLine("CotainerReader: Container with id: " + index + " not found");
                return null;
            }

        }

        public Container GetContainerByName(string name)
        {
            List<Container> containers = this.GetAllContainers();
            foreach (Container c in containers)
            {
                if (c.Name.Equals(name))
                    return c;
            }

            return null;
        }

        public ItemLocationContainer FindItemOnContainer(int itemId)
        {

            List<Container> containers = this.GetAllContainers();
            foreach (Container container in containers)
            {
                ItemLocationContainer itemLocation = this.findItemOnContainer(container, itemId);
                if (itemLocation != null)
                    return itemLocation;
            }

            //Console.WriteLine("No item with id: " + itemId + " was found on any container.");
            return null;
        }

        public ItemLocationContainer FindItemOnContainer(int itemId, int containerIndex)
        {
            Container c = this.GetContainerByIndex(containerIndex);
            if (c == null)
            {
                Console.WriteLine("Container with index: " + containerIndex + " not found.");
                return null;
            }
            return this.findItemOnContainer(c, itemId);
        }


        private ItemLocationContainer findItemOnContainer(Container container, int itemId)
        {
            List<Item> items = container.Items;
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                if (item.Id == itemId)
                {
                    return new ItemLocationContainer(item, container.Index, i);
                }
            }

            //Console.WriteLine("No item with id: " + itemId + " was found on container: " + container.Name + " index: " + container.Index);
            return null;
        } 
    }
}
