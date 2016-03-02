using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    interface GuiAddress
    {
        uint GetClientWidthAddress();
        uint GetClientHeightAddress();

        uint GetGuiStartAddress();

        uint GetUIWidgetIDAdrress();
        uint GetUIWidgetLeftPosAdrress();
        uint GetUIWidgetTopPosAdrress();
        uint GetUIWidgetRightPosAdrress();
        uint GetUIWidgetBottomPosAdrress();

        uint GetUIWidgetIsVisibleAdrress();

        uint GetUIWidgetChildrensAdrress();
        uint GetUIWidgetLockedChildrensAdrress();

        uint GetUiWidgetChildrenFirstIndexAddress();
        uint GetUIWidgetChildrensSizeAdrress();

        uint GetGameMapLeftPosAdrress();
        uint GetGameMapTopPosAdrress();
        uint GetGameMapRightPosAdrress();
        uint GetGameMapBottomPosAdrress();

        //hotkeys
        uint[] GetHotkeysOffsetsAddress();

    }
}
