using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediviaBot.input
{
    class InputSenderImpl : InputSender
    {

        private static InputSenderImpl instance;
        private InputSenderImpl() { }
        public static InputSenderImpl Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputSenderImpl();
                }
                return instance;
            }
        }

        private MouseImpl mouse = new MouseImpl();
        private KeyboardImpl keyboard = new KeyboardImpl();
        private MouseAndKeyboard mouseAndKeyboard = new MouseAndKeyboard();

        public void SendDragEvent(Point from, Point to, bool ctrl = false, bool shift = false, int priority = 0)
        {
            if (ctrl || shift)
                mouseAndKeyboard.DragEvent(from, to, ctrl, shift);
            else
                mouse.DragEvent(from, to);
        }

        public void SendKeyPress(Key key, int priority = 0)
        {
            uint vk_code = (uint)KeyInterop.VirtualKeyFromKey(key);
            keyboard.PressKey(vk_code);
        }

        public void SendKeyPress(Key key1, Key key2, int priority = 0)
        {
            uint vk_code1 = (uint)KeyInterop.VirtualKeyFromKey(key1);
            uint vk_code2 = (uint)KeyInterop.VirtualKeyFromKey(key2);
            keyboard.PressKey(vk_code1, vk_code2);
        }

        public void SendScrollDown(Point point, int priority = 0)
        {
            mouse.ScrollDownEvent(point);
        }

        public void SendScrollUp(Point point, int priority = 0)
        {
            mouse.ScrollUpEvent(point);
        }

        public void SendUseOnEvent(Point from, Point to, int priority = 0)
        {
            mouse.UseOnEvent(from, to);
        }

        public void SendLeftClick(Point point, bool ctrl = false, bool shift = false, bool alt = false, int priority = 0)
        {
            if (ctrl || shift || alt)
                mouseAndKeyboard.LeftClickPressingKeyEvent(point, ctrl, shift, alt);

            else
                mouse.LeftClickEvent(point);


        }

        public void SendRightClick(Point point, bool ctrl = false, bool shift = false, bool alt = false, int priority = 0)
        {
            if (ctrl || shift || alt)
                mouseAndKeyboard.RightClickPressingKeyEvent(point, ctrl, shift, alt);
            else
                mouse.RightClickEvent(point);
        }
    }
}
