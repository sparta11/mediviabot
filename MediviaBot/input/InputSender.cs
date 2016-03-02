using System.Drawing;
using System.Windows.Input;

namespace MediviaBot.input
{
    interface InputSender
    {

        //mouse
        void SendLeftClick(Point point, bool ctrl = false, bool shift = false, bool alt = false, int priority = 0);

        void SendRightClick(Point point, bool ctrl = false, bool shift = false, bool alt = false, int priority = 0);

        void SendDragEvent(Point from, Point to, bool ctrl = false, bool shift = false, int priority = 0);

        void SendUseOnEvent(Point from, Point to, int priority = 0);

        void SendScrollUp(Point point, int priority = 0);

        void SendScrollDown(Point point, int priority = 0);

        //keyboard
        void SendKeyPress(Key key, int priority = 0);

        void SendKeyPress(Key key1, Key key2, int priority = 0);


    }
}
