using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediviaBot.input
{
    class KeyboardImpl : InputSimulator
    {

        public void PressKey(uint key1Code)
        {
            this.KeyDown(key1Code);
            this.KeyUp(key1Code);
        }

        public void PressKey(uint key1Code, uint key2Code)
        {

            this.KeyDown(key1Code);
            Thread.Sleep(20);
            this.KeyDown(key2Code, false, true);
            this.KeyUp(key2Code, false, true);
            Thread.Sleep(20);
            this.KeyUp(key1Code);

        }

        public void Say(string text)
        {

            throw new NotImplementedException();

        }




    }
}
