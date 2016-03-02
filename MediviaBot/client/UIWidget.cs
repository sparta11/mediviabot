using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.client
{
    class UIWidget
    {

        private String id;
        private Rect rect;
        private List<UIWidget> childrens = new List<UIWidget>();

        public UIWidget(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        internal List<UIWidget> Childrens
        {
            get
            {
                return childrens;
            }

            set
            {
                childrens = value;
            }
        }

        public Rect Rect
        {
            get
            {
                return rect;
            }

            set
            {
                rect = value;
            }
        }
    }
}
