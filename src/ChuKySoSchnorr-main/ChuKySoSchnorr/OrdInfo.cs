using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuKySoSchnorr
{
    internal class OrdInfo
    {
        public int x { get; set; }
        public bool primitive { get; set; }

        public OrdInfo() { }

        public OrdInfo(int x, bool primitive)
        {
            this.x = x;
            this.primitive = primitive;
        }
    }
}
