using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AppLayer.DrawingComponents
{
    public abstract class Relationship : Symbol
    {
        public virtual Point Location1 { get; set; } = new Point(0, 0);
        public virtual Point Location2 { get; set; } = new Point(0, 0);

        public void MoveLine(Point oldLocation, Point newLocation)
        {
            if(Location1 == oldLocation)
            {
                Location1 = newLocation;
            }
            else if(Location2 == oldLocation)
            {
                Location2 = newLocation;
            }
        }

    }
}
