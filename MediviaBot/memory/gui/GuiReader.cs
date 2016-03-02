using MediviaBot.client;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediviaBot.memory.gui
{
    internal interface GuiReader
    {

        Rect GetGameMapRect();
        List<UIWidget> GetContainerUIWidgets();
        List<UIWidget> GetInventorySlotsUIWidgets();
        List<ClientHotkey> GetHotkeys();
        string GetStatusMessage();
        
    }
}
