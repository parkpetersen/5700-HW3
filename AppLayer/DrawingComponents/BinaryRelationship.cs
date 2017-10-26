using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.DrawingComponents
{
    class BinaryRelationship : Relationship
    {
        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            graphics.DrawLine(pen, Location1, Location2);
        }
    }
}
