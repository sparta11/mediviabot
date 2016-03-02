using MediviaBot.memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.input
{
    class MouseImpl : InputSimulator
    {

        public void LeftClickEvent(Point point, bool ctrl = false, bool shift = false)
        {

            this.MouseMove(point);
            this.LeftButtonDown(point);
            this.LeftButtonUp(point);

        }

        public void RightClickEvent(Point point, bool ctrl = false, bool shift = false)
        {

            this.MouseMove(point);
            this.RightButtonDown(point);
            this.RightButtonUp(point);

        }

        public void ScrollUpEvent(Point point)
        {

            int x = point.X;
            int y = point.Y;
            WindowsAPI.ClientToScreen(handle, ref point);
            int xScreenPos = point.X;
            int yScreenPos = point.Y;
            int delta = 120 << 16;
            this.MouseMove(new Point(x, y));
            WindowsAPI.PostMessage(handle, WM_MOUSEWHEEL, (IntPtr)delta, paramHelper.createCoordinatesLParam(xScreenPos, yScreenPos));

        }

        public void ScrollDownEvent(Point point)
        {

            int x = point.X;
            int y = point.Y;
            WindowsAPI.ClientToScreen(handle, ref point);
            int xScreenPos = point.X;
            int yScreenPos = point.Y;
            int delta = (120 * -1) << 16;
            this.MouseMove(new Point(x, y));
            WindowsAPI.PostMessage(handle, WM_MOUSEWHEEL, (IntPtr)delta, paramHelper.createCoordinatesLParam(xScreenPos, yScreenPos));

        }

        public void DragEvent(Point from, Point to)
        {

            this.MouseMove(from);
            this.LeftButtonDown(from);
            this.MouseMove(to, true);
            this.LeftButtonUp(to);

        }

        public void UseOnEvent(Point from, Point to)
        {

            this.MouseMove(from);
            this.RightButtonDown(from);
            this.RightButtonUp(from);
            this.MouseMove(to);
            this.LeftButtonDown(to);
            this.LeftButtonUp(to);

        }

    }
}
