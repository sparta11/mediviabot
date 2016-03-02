using MediviaBot.game;
using MediviaBot.input;
using MediviaBot.memory.gui;
using MediviaBot.util;
using memory.gui;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace MediviaBot.client.gui
{
    internal class ContainerManager
    {
        private GuiReader guiReader = new GuiMemoryReader();
        private InputSender inputSender = InputSenderImpl.Instance;

        public Point GetInventoryPosition(int slot, int containerIndex)
        {
            //try scroll 10 times
            for (int i = 0; i < 10; i++)
            {

                //Console.WriteLine("Tries: " + (i + 1));
                string containerId = "container" + containerIndex;
                UIWidget container = getContainerByID(containerId, guiReader.GetContainerUIWidgets());

                if (container == null)
                {
                    Console.WriteLine("Container with id: " + containerId + " not found");
                    return new Point(-1, -1);
                }

                List<UIWidget> slots = container.Childrens;
                UIWidget item = slots[slot];

                int isVisible = slotIsVisible(item.Rect, container.Rect);

                Rect containerRect = container.Rect;

                //remove toolbar height for wheel
                containerRect.Top = containerRect.Top + 22;
                Point wheelPos = ClientGuiHelper.GetRandomCenterPos(container.Rect);

                if (isVisible == -1)
                {
                    inputSender.SendScrollUp(wheelPos);
                    Thread.Sleep(20);
                }
                else if (isVisible == 0)
                {
                    return ClientGuiHelper.GetRandomCenterPos(item.Rect);
                }
                else if (isVisible == 1)
                {
                    inputSender.SendScrollDown(wheelPos);
                    Thread.Sleep(20);
                }

            }

            Console.WriteLine("Could not get the item slot");
            return new Point(-1, -1);
        }

        private UIWidget getContainerByID(string containerId, List<UIWidget> containers)
        {
            //Console.WriteLine("getContainerByID => containers size: " + containers.Count);
            foreach (UIWidget container in containers)
            {
                if (container.Id.Equals(containerId))
                    return container;
            }

            return null;
        }

        private int slotIsVisible(Rect inner, Rect outRect)
        {

            //remove 21 pixels to toolbarheight
            outRect.Top = outRect.Top + 21;

            //not random
            Point p = ClientGuiHelper.getCenterPos(inner);

            Point upper = new Point(p.X - 5, p.Y - 5);
            Point lower = new Point(p.X + 5, p.Y + 5);

            int isInside = 0;
            //check upper point
            isInside = outRect.ContainsPoint(upper);
            if (isInside == -1 || isInside == 1)
                return isInside;

            //check lower point
            isInside = outRect.ContainsPoint(lower);
            return isInside;

        }
    }
}