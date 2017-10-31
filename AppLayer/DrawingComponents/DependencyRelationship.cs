using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class DependencyRelationship : Relationship
    {
        public DependencyRelationship(Point location1, Point location2)
        {
            this.Location1 = location1;
            this.Location2 = location2;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            float[] pattern = { 5, 5, 5, 5 };
            pen.DashPattern = pattern;
            graphics.DrawLine(pen, Location1, Location2);
            pen.Dispose();
        }
    }
}
