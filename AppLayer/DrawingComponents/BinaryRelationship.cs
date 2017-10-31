using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class BinaryRelationship : Relationship
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
            Point labelLocation = new Point(midpoint.X, midpoint.Y - 20);
            graphics.DrawString(label, font, Brushes.Black, labelLocation);
            //work on forming triangle to represent an arrow
            Point p1 = new Point(midpoint.X, midpoint.Y - 10);
            Point p2 = new Point(midpoint.X, midpoint.Y + 10);
            Point p3 = new Point(midpoint.X + 10 * ((Location2.X - midpoint.X) / Math.Abs(Location2.X - midpoint.X)), midpoint.Y);
            Point[] Points = new Point[]
            {
                p1,
                p2,
                p3
            };
            //graphics.DrawLine(pen, p1, p2);
            //graphics.DrawLine(pen, p2, p3);
            //graphics.DrawLine(pen, p3, p1);
            graphics.DrawPolygon(pen, Points);
            graphics.FillPolygon(Brushes.Black, Points);
            pen.Dispose();
        }

        public void EditBinary(string newLabel)
        {
            this.label = newLabel;
        }
    }
}
