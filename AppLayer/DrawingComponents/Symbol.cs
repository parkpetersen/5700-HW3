using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AppLayer.DrawingComponents
{
    public abstract class Symbol
    {
        public virtual bool IsSelected { get; set; } = false;
        public virtual void Draw(Graphics graphics) { }

    }
}
