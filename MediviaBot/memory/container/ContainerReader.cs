using MediviaBot.game.model;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediviaBot.memory.container
{
    interface ContainerReader
    {
        Container GetContainerByIndex(int id);
        Container GetContainerByIndex(string id);
        Container GetContainerByName(string name);
        List<Container> GetAllContainers();
        ItemLocationContainer FindItemOnContainer(int itemId);
        ItemLocationContainer FindItemOnContainer(int itemId, int containerIndex);

    }
}
