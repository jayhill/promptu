using System.Collections.Generic;

namespace ZachJohnson.Promptu.UIModel.RichText
{
    public class RTGroup : RTElement
    {
        private List<RTElement> children = new List<RTElement>();

        public RTGroup()
        {
        }

        public List<RTElement> Children
        {
            get { return this.children; }
        }
    }
}
