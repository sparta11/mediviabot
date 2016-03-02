using System.Windows.Input;

namespace MediviaBot.input
{
    class KeyboardKeyPress : Input
    {

        public KeyboardKeyPress(Key key, int priority) : base(priority, InputType.Keyboard)
        {
            Priority = Priority;
            this.key = key;
        }

        public Key key { get; set; }

    }
}
