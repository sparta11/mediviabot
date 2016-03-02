using MediviaBot.input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediviaBot.bot.core.keyboardsimulator
{
    class KeyboardSimulatorImpl : KeyboardSimulator
    {

        private InputSender inputSender = InputSenderImpl.Instance;

        public void SendKeyPress(string key)
        {
            string[] keys = splitKeyString(key);
            
            if (keys.Length > 1)
            {
                Key key1 = StringToKey(keys[0]);
                Key key2 = StringToKey(keys[1]);
                inputSender.SendKeyPress(key1, key2);
            }

            inputSender.SendKeyPress(StringToKey(keys[0]));
        }

        private string[] splitKeyString(string key)
        {
            string[] tokens = key.Split('+');
            return tokens;
        }

        private Key StringToKey(string text)
        {
            KeyConverter k = new KeyConverter();
            Key mykey = (Key)k.ConvertFromString(text);
            return mykey;
        }
    }
}
