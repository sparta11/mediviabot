using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediviaBot.input
{
    class MouseAndKeyboard : InputSimulator
    {

        public void DragEvent(Point from, Point to, bool ctrl = false, bool shift = false)
        {
            this.KeyDown(VK_CONTROL, false, false, 0);
            Thread.Sleep(50);
            this.MouseMove(from, false, false, true, false);
            this.LeftButtonDown(from, ctrl, shift);
            this.MouseMove(to, true, false, ctrl, shift);
            this.LeftButtonUp(to, ctrl, shift);
            Thread.Sleep(50);
            this.KeyUp(VK_CONTROL);
        }

        //public void AttackEvent(Point point)
        //{
        //    this.KeyDown(VK_MENU, true, false, 0);
        //    this.MouseMove(point, false, false, false, false);
        //    this.LeftButtonDown(point, false, false);
        //    this.KeyUp(VK_MENU, true, false);
        //}

        internal void LeftClickPressingKeyEvent(Point point, bool ctrl, bool shift, bool alt)
        {

            //Console.WriteLine("LeftClickPressingKeyEvent - Point x: " + point.X + " y: " + point.Y + " ctrl: " + ctrl + " shift: " + shift + " alt: " + alt);
            if (ctrl)
            {
                this.KeyDown(VK_CONTROL, false, false, 0);
                Thread.Sleep(50);
                this.MouseMove(point, false, false, true, false);
                this.LeftButtonDown(point, true, false);
                this.LeftButtonUp(point, true, false);
                Thread.Sleep(50);
                this.KeyUp(VK_MENU, false, false);
                return;
            }

            if (shift)
            {
                this.KeyDown(VK_SHIFT, false, false, 0);
                Thread.Sleep(50);
                this.MouseMove(point, false, false, false, true);
                this.LeftButtonDown(point, false, true);
                this.LeftButtonUp(point, false, true);
                this.KeyUp(VK_MENU, false, false);
                return;
            }

            if (alt)
            {
                this.KeyDown(VK_MENU, true, false, 0, true);
                Thread.Sleep(50);
                this.MouseMove(point);
                this.LeftButtonDown(point);
                this.LeftButtonUp(point);
                Thread.Sleep(50);
                this.KeyUp(VK_MENU, true);
                return;
            }

            throw new InvalidOperationException();
        }

        internal void RightClickPressingKeyEvent(Point point, bool ctrl, bool shift, bool alt)
        {

            if (ctrl)
            {
                this.KeyDown(VK_CONTROL);
                this.MouseMove(point, false, false, true, false);
                this.RightButtonDown(point, true, false);
                this.KeyUp(VK_MENU);
                return;
            }

            if (shift)
            {
                this.KeyDown(VK_SHIFT);
                this.MouseMove(point, false, false, false, true);
                this.RightButtonDown(point, false, true);
                this.KeyUp(VK_MENU);
                return;
            }

            if (alt)
            {
                this.KeyDown(VK_MENU, true);
                this.MouseMove(point);
                this.RightButtonDown(point);
                this.KeyUp(VK_MENU, true);
                return;
            }

            throw new InvalidOperationException();
        }
    }
}
