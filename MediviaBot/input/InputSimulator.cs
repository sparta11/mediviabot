using MediviaBot.client;
using MediviaBot.memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.input
{
    class InputSimulator
    {
        protected const uint WM_LBUTTONDOWN = 0x201;    //Left mousebutton down
        protected const uint WM_LBUTTONUP = 0x202;      //Left mousebutton up
        protected const uint WM_RBUTTONDOWN = 0x0204;   //right mousebutton down
        protected const uint WM_RBUTTONUP = 0x0205;     //right mousebutton up
        protected const uint WM_SETCURSOR = 0x0020;
        protected const uint WM_MOUSEMOVE = 0x0200;
        protected const uint WM_MOUSEWHEEL = 0x020A;

        //use for mousemove wParam
        protected const uint MK_LBUTTON = 0x0001;//The left mouse button is down.
        protected const uint MK_RBUTTON = 0x0002;//The right mouse button is down.
        protected const uint MK_SHIFT = 0x0004; //The SHIFT key is down. 
        protected const uint MK_CONTROL = 0x0008; //The CTRL key is down. 

        protected const uint VK_SHIFT = 0x10;
        protected const uint VK_CONTROL = 0x11;
        protected const uint VK_MENU = 0x12; //alt key

        //keyboaord
        protected const uint WM_KEYDOWN = 0x100;
        protected const uint WM_KEYUP = 0x0101;
        protected const uint WM_SYSKEYDOWN = 0x0104;
        protected const uint WM_SYSKEYUP = 0x0105;
        protected IntPtr handle;

        protected InputParameterHelper paramHelper = new InputParameterHelper();

        protected InputSimulator()
        {
            Client client = ClientImpl.Instance;
            this.handle = client.GetProcess().MainWindowHandle;
        }

        protected void SetCursor(uint code)
        {
            WindowsAPI.PostMessage(handle, WM_SETCURSOR, handle, paramHelper.createCoordinatesLParam(1, (int)code));
            ////Thread.Sleep(1);
        }

        protected void MouseMove(Point destination, bool lbutton = false, bool rbutton = false, bool ctrl = false, bool shift = false)
        {
            uint lbuttonValue = 0;
            uint rbuttonValue = 0;
            uint ctrlValue = 0;
            uint shiftValue = 0;
            if (lbutton)
                lbuttonValue = MK_LBUTTON;
            if (rbutton)
                rbuttonValue = MK_RBUTTON;
            if (ctrl)
                ctrlValue = MK_CONTROL;
            if (shift)
                shiftValue = MK_SHIFT;

            this.SetCursor(WM_MOUSEMOVE);
            IntPtr wParam = paramHelper.createMouseMoveWParam(lbuttonValue, rbuttonValue, ctrlValue, shiftValue);
            WindowsAPI.PostMessage(handle, WM_MOUSEMOVE, wParam, paramHelper.createCoordinatesLParam(destination.X, destination.Y));
        }

        protected void LeftButtonDown(Point point, bool ctrl = false, bool shift = false)
        {
            uint ctrlValue = 0;
            uint shiftValue = 0;
            if (ctrl)
                ctrlValue = MK_CONTROL;
            if (shift)
                shiftValue = MK_SHIFT;

            IntPtr wParam = paramHelper.createLeftMouseButtonWparam(ctrlValue, shiftValue);
            this.SetCursor(WM_LBUTTONDOWN);
            WindowsAPI.PostMessage(handle, WM_LBUTTONDOWN, wParam, paramHelper.createCoordinatesLParam(point.X, point.Y));
        }

        protected void LeftButtonUp(Point point, bool ctrl = false, bool shift = false)
        {
            uint ctrlValue = 0;
            uint shiftValue = 0;
            if (ctrl)
                ctrlValue = MK_CONTROL;
            if (shift)
                shiftValue = MK_SHIFT;

            this.SetCursor(WM_LBUTTONUP);
            IntPtr wParam = paramHelper.createLeftMouseUpButtonWparam(ctrlValue, shiftValue);
            WindowsAPI.PostMessage(handle, WM_LBUTTONUP, wParam, paramHelper.createCoordinatesLParam(point.X, point.Y));
        }

        protected void RightButtonDown(Point point, bool ctrl = false, bool shift = false)
        {
            uint ctrlValue = 0;
            uint shiftValue = 0;
            if (ctrl)
                ctrlValue = MK_CONTROL;
            if (shift)
                shiftValue = MK_SHIFT;

            IntPtr wParam = paramHelper.createRightMouseButtonWparam(ctrlValue, shiftValue);
            this.SetCursor(WM_RBUTTONDOWN);
            WindowsAPI.PostMessage(handle, WM_RBUTTONDOWN, wParam, paramHelper.createCoordinatesLParam(point.X, point.Y));
        }

        protected void RightButtonUp(Point point, bool ctrl = false, bool shift = false)
        {
            IntPtr wParam;
            uint ctrlValue = 0;
            uint shiftValue = 0;
            if (ctrl)
                ctrlValue = MK_CONTROL;
            if (shift)
                shiftValue = MK_SHIFT;

            if (ctrlValue == 0 && shiftValue == 0)
                wParam = new IntPtr(0);
            else
                wParam = paramHelper.createRightMouseUpButtonWparam(ctrlValue, shiftValue);

            this.SetCursor(WM_RBUTTONUP);
            WindowsAPI.PostMessage(handle, WM_RBUTTONUP, wParam, paramHelper.createCoordinatesLParam(point.X, point.Y));
        }

        protected void KeyDown(uint vk_code, bool sysKey = false, bool extended = false, uint fRepeat = 0, bool altDown = false)
        {
            uint scanCode = WindowsAPI.MapVirtualKey((uint)vk_code, 0);
            uint msg = 0;
            if (sysKey)
                msg = WM_SYSKEYDOWN;
            else
                msg = WM_KEYDOWN;

            uint extendedValue = 0;
            uint altDownValue = 0;
            if (altDown)
                altDownValue = 1;
            if (extended)
                extendedValue = 1;

            IntPtr leftParam = paramHelper.createkeyPressLParam(1, scanCode, extendedValue, altDownValue, fRepeat, 0);
            WindowsAPI.PostMessage(handle, msg, (IntPtr)vk_code, leftParam);
        }

        protected void KeyUp(uint vk_code, bool sysKey = false, bool extended = false)
        {
            //uint vk_code = (uint)KeyInterop.VirtualKeyFromKey(key);
            uint scanCode = WindowsAPI.MapVirtualKey((uint)vk_code, 0);
            uint msg = 0;
            if (sysKey)
                msg = WM_SYSKEYUP;
            else
                msg = WM_KEYUP;

            IntPtr leftParam;
            if (extended)
                leftParam = paramHelper.createkeyPressLParam(1, scanCode, 1, 0, 1, 1);
            else
                leftParam = paramHelper.createkeyPressLParam(1, scanCode, 0, 0, 1, 1);

            WindowsAPI.PostMessage(handle, msg, (IntPtr)vk_code, leftParam);
        }
    }
}
