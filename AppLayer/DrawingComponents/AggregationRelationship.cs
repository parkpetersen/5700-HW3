using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AppLayer.DrawingComponents
{
    public class AggregationRelationship : Relationship
    {
        ClassSymbol Location1Class;

        public AggregationRelationship(Point location1, Point location2, ClassSymbol startingClass)
        {
            this.Location1 = location1;
            this.Location2 = location2;
            this.Location1Class = startingClass;

        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Point midpoint = new Point((Location1.X + Location2.X) / 2, (Location1.Y + Location2.Y) / 2);
            int xDirection = ((midpoint.X - Location1.X) / Math.Abs(midpoint.X - Location1.X));
            int yDirection = ((midpoint.Y - Location1.Y) / Math.Abs(midpoint.Y - Location1.Y));

            Point p1 = new Point(Location1.X + ((Location1Class.Size.Width / 2) * xDirection),
                Location1.Y + ((Location1Class.Size.Height/2) * yDirection));
            Point p2 = new Point(p1.X + (10 * xDirection), p1.Y + (10 * yDirection));
            Point p3 = new Point(p1.X + (20 * xDirection), p1.Y);
            Point p4 = new Point(p1.X + (10 * xDirection), p1.Y - (10 * yDirection));
            Point[] points = new Point[]
            {
                p1,
                p2,
                p3,
                p4
            };
            graphics.DrawPolygon(pen, points);
            graphics.FillPolygon(Brushes.Black, points);
            graphics.DrawLine(pen, p1, Location2);

            pen.Dispose();

        }
    }
}
