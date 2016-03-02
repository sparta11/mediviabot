using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.model
{
    abstract class Thing
    {

        private List<string> attributes = new List<string>();

        public Thing(string[] attributes)
        {
            this.attributes.AddRange(attributes);
        }

        public List<string> Attributes
        {
            get
            {
                return attributes;
            }

            set
            {
                attributes = value;
            }
        }

        public bool hasProperty(string prop)
        {
            if (attributes.Any(str => str.Contains(prop)))
            {
                return true;
            }

            return false;
        }

        public bool IsStackable()
        {
            if (hasProperty("stackable"))
                return true;
            return false;
        }

        public bool IsContainer()
        {
            if (hasProperty("container"))
                return true;
            return false;

        }


    }
}
