using MediviaBot.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.gui
{
    class GuiContainerReader : GuiMemoryReader
    {

        public List<UIWidget> GetAllContainers()
        {
            List<UIWidget> containers = getPanelContainers(gameRightPanelAdr, rootAdr);
            containers.AddRange(getPanelContainers(gameLeftPanelAdr, rootAdr));
            return containers;
        }

        private List<UIWidget> getPanelContainers(uint panelAdr, uint rootAdr)
        {
            //Console.WriteLine("|-- RightPanelAdr adr: " + Convert.ToUInt32(rightPanelAdr).ToString("X"));
            List<uint> rightChildsAdr = findAllChildsAddress(panelAdr);

            //remove inventory, skill, vip
            List<uint> containersAdresses = getAllContainersAddress(rightChildsAdr);

            List<UIWidget> containersList = new List<UIWidget>();
            foreach (uint containerAdr in containersAdresses)
            {

                UIWidget containerWidget = ReadUIWidget(containerAdr);
                uint contentsPanelAdr = findChildAddressByID("contentsPanel", containerAdr);

                List<UIWidget> itemsWidgets = findAllChilds(contentsPanelAdr);
                containerWidget.Childrens = itemsWidgets;
                containersList.Add(containerWidget);
            }

            return containersList;
        }

        private List<uint> getAllContainersAddress(List<uint> childsAdr)
        {

            List<uint> containersAdr = new List<uint>();
            foreach (uint childAdr in childsAdr)
            {
                string id = getWidgetID(childAdr);
                if (id.StartsWith("container"))
                    containersAdr.Add(childAdr);
            }

            return containersAdr;
        }


    }
}
