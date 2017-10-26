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
        public BinaryRelationship(Point location1, Point location2)
        {
            this.Location1 = location1;
            this.Location2 = location2;
            this.label = "Binary Relationship";
        }

        public override void Draw(Graphics graphics)
        {
            Console.WriteLine($"Drawing from {Location1} to {Location2}");
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            graphics.DrawLine(pen, Location1, Location2);
            Font font = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            Point midpoint = new Point();
            midpoint.X = (Location1.X + Location2.X) / 2;
            midpoint.Y = (Location1.Y + Location2.Y) / 2 - 5;
            graphics.DrawString(label, font, Brushes.Black, midpoint);
            //work on forming triangle to represent an arrow
            Point p1 = new Point(midpoint.X, midpoint.Y - 5);
            Point p2 = new Point(midpoint.X, midpoint.Y + 5);
            Point p3 = new Point(Location2.X - midpoint.X) 
            graphics.DrawPolygon(pen, )
            pen.Dispose();
        }
    }
}
