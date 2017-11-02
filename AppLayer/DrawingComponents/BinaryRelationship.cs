using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class BinaryRelationship : Relationship
    {
        [DataMember]
        public int directionSwap { get; set; } = 1;
        [DataMember]
        public Color ArrowColor { get; set; } = Color.Black;

        public BinaryRelationship(Point location1, Point location2, Color lineColor)
        {
            this.Location1 = location1;
            this.Location2 = location2;
            this.label = "Binary Relationship";
            this.LineColor = lineColor;
        }

        public override void Draw(Graphics graphics)
        {
            Console.WriteLine($"Drawing from {Location1} to {Location2}");
            Pen pen = new Pen(LineColor);
            pen.Width = LineThickness;
            graphics.DrawLine(pen, Location1, Location2);
            Font font = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            Point midpoint = new Point();
            midpoint.X = (Location1.X + Location2.X) / 2;
            midpoint.Y = (Location1.Y + Location2.Y) / 2 - 5;
            Point labelLocation = new Point(midpoint.X, midpoint.Y - 20);
            Brush brush = new SolidBrush(LineColor);
            graphics.DrawString(label, font, brush, labelLocation);

            Point p1 = new Point(midpoint.X, midpoint.Y - 10);
            Point p2 = new Point(midpoint.X, midpoint.Y + 10);
            Point p3 = new Point(midpoint.X + 10 * ((Location2.X - midpoint.X) / Math.Abs(Location2.X - midpoint.X)) * directionSwap, midpoint.Y);
            Point[] Points = new Point[]
            {
                p1,
                p2,
                p3
            };

            graphics.DrawPolygon(pen, Points);
            brush = new SolidBrush(ArrowColor);
            graphics.FillPolygon(brush, Points);
            pen.Dispose();
        }

        public void EditBinary(string newLabel, Color newColor, int directionSwap, Color newArrowColor, int thickness)
        {
            this.label = newLabel;
            this.LineColor = newColor;
            this.directionSwap = this.directionSwap * directionSwap;
            this.ArrowColor = newArrowColor;
            LineThickness = thickness;
        }
    }
}
