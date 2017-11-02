using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class GeneralizationRelationship : Relationship
    {
        [DataMember]
        ClassSymbol Location1Class;
        public GeneralizationRelationship(Point location1, Point location2, ClassSymbol startingClass, Color linecolor)
        {
            this.Location1 = location1;
            this.Location2 = location2;
            this.Location1Class = startingClass;
            this.LineColor = linecolor;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(LineColor);
            pen.Width = LineThickness;
            Point midpoint = new Point((Location1.X + Location2.X) / 2, (Location1.Y + Location2.Y) / 2);
            int xDirection = ((midpoint.X - Location1.X) / Math.Abs(midpoint.X - Location1.X));
            int yDirection = ((midpoint.Y - Location1.Y) / Math.Abs(midpoint.Y - Location1.Y));

            Point p1 = new Point(Location1.X + ((Location1Class.Size.Width / 2) * xDirection),
                Location1.Y + ((Location1Class.Size.Height / 2) * yDirection));
            Point p2 = new Point(p1.X + (10 * xDirection) * SymbolSizeMultiplier, p1.Y + (10 * yDirection) * SymbolSizeMultiplier);
            Point p3 = new Point(p1.X + (10 * xDirection) * SymbolSizeMultiplier, p1.Y);
            Point p4 = new Point(p1.X + (10 * xDirection) * SymbolSizeMultiplier, p1.Y - (10 * yDirection) * SymbolSizeMultiplier);
            Point[] points = new Point[]
            {
                p1,
                p2,
                p3,
                p4
            };
            graphics.DrawLine(pen, p3, Location2);
            graphics.DrawPolygon(pen, points);
            Brush brush = new SolidBrush(SymbolFillColor);
            if(SymbolFillColor != Color.White)
                graphics.FillPolygon(brush, points);
            pen.Dispose();

        }

    }
}
