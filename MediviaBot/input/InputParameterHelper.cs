using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.input
{
    class InputParameterHelper
    {
        public IntPtr createLeftMouseButtonWparam(uint ctrl, uint shift)
        {
            return new IntPtr(1 | ctrl | shift);
        }

        public IntPtr createLeftMouseUpButtonWparam(uint ctrl, uint shift)
        {
            return new IntPtr(ctrl | shift);
        }


        public IntPtr createRightMouseButtonWparam(uint ctrl, uint shift)
        {
            return new IntPtr(2 | ctrl | shift);
        }

        public IntPtr createRightMouseUpButtonWparam(uint ctrl, uint shift)
        {
            return new IntPtr(ctrl | shift);
        }

        public IntPtr createMouseMoveWParam(uint lbutton, uint rbutton, uint ctrl, uint shift)
        {
            return new IntPtr(lbutton | rbutton | ctrl | shift);
        }

        public IntPtr createCoordinatesLParam(int hi, int low)
        {
            int coordinates = ((low << 0x10) | hi);
            return (IntPtr)coordinates;
        }

        public IntPtr createkeyPressLParam(uint repeatCount, uint scanCode, uint extended, uint context, uint state, uint transition)
        {
            uint lParam = repeatCount
                | (scanCode << 16)
                | (extended << 24)
                | (context << 29)
                | (state << 30)
                | (transition << 31);

            return new IntPtr((int)lParam);
        }
    }
}
