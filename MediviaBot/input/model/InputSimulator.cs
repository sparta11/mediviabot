using MediviaBot.client;
using static MediviaBot.memory.WindowsAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.input.model
{
    abstract class InputSimulator
    {
        private const uint WM_LBUTTONDOWN = 0x201;    //Left mousebutton down
        private const uint WM_LBUTTONUP = 0x202;      //Left mousebutton up
        private const uint WM_RBUTTONDOWN = 0x0204;   //right mousebutton down
        private const uint WM_RBUTTONUP = 0x0205;     //right mousebutton up
        private const uint WM_SETCURSOR = 0x0020;
        private const uint WM_MOUSEMOVE = 0x0200;
        private const uint WM_MOUSEWHEEL = 0x020A;

        //use for mousemove wParam
        private const uint MK_LBUTTON = 0x0001;//The left mouse button is down.
        private const uint MK_RBUTTON = 0x0002;//The right mouse button is down.
        private const uint MK_SHIFT = 0x0004; //The SHIFT key is down. 
        private const uint MK_CONTROL = 0x0008; //The CTRL key is down. 


        protected const uint VK_SHIFT = 0x10;
        protected const uint VK_CONTROL = 0x11;

        private IntPtr handle;

        public InputSimulator()
        {
            Client client = ClientImpl.Instance;
            this.handle = client.GetProcess().MainWindowHandle;
        }

        public void SetCursor(uint code)
        {
            SendMessage(handle, WM_SETCURSOR, handle, createCoordinatesLParam(1, (int)code));
        }

        public void MouseMove(Point destination, bool lbutton = false, bool rbutton = false, bool ctrl = false, bool shift = false)
        {
            IntPtr wParam;
            if (lbutton)
                wParam = new IntPtr(MK_LBUTTON);
            else if (rbutton)
                wParam = new IntPtr(MK_RBUTTON);
            else if (ctrl)
                wParam = new IntPtr(MK_CONTROL);
            else if (shift)
                wParam = new IntPtr(MK_CONTROL);
            else
                wParam = new IntPtr(0);

            PostMessage(handle, WM_MOUSEMOVE, wParam, createCoordinatesLParam(destination.X, destination.Y));
        }

        public void LeftDownDown(Point point, bool rbutton = false, bool ctrl = false, bool shift = false)
        {
            this.SetCursor(WM_LBUTTONDOWN);
            IntPtr wParam = createLeftButtonWparam(Convert.ToInt32(rbutton), Convert.ToInt32(ctrl), Convert.ToInt32(shift));
            PostMessage(handle, WM_LBUTTONDOWN, wParam, createCoordinatesLParam(point.X, point.Y));
        }

        public void SendMouseLeftUp(Point point, bool rbutton = false, bool ctrl = false, bool shift = false)
        {
            this.SetCursor(WM_LBUTTONUP);
            IntPtr wParam = createLeftButtonWparam(Convert.ToInt32(rbutton), Convert.ToInt32(ctrl), Convert.ToInt32(shift));
            PostMessage(handle, WM_LBUTTONUP, wParam, createCoordinatesLParam(point.X, point.Y));
        }

        private IntPtr createLeftButtonWparam(int rButton, int ctrl, int shift)
        {
            int lParam = 1 | (rButton << 0x2) | (shift << 0x4) | (ctrl << 0x8);
            return new IntPtr((int)lParam);

        }






        private IntPtr createCoordinatesLParam(int hi, int low)
        {
            int coordinates = ((low << 0x10) | hi);
            return (IntPtr)coordinates;
        }

    }
}
