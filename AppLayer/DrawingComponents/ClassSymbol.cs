using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AppLayer.DrawingComponents
{
    public class ClassSymbol : Symbol
    {
        public virtual Point Location { get; set; } = new Point(0, 0);
        public virtual Size Size { get; set; } = new Size(0, 0);

    }
}
