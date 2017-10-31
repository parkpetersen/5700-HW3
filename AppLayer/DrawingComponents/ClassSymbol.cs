using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class ClassSymbol : Symbol
    {
        [DataMember]
        public virtual Point Location { get; set; } = new Point(0, 0);
        [DataMember]
        public virtual Size Size { get; set; } = new Size(0, 0);
        [DataMember]
        public Color ClassColor;

        public ClassSymbol(Point location, Size size)
        {
            
            this.Location = location;
            this.Size = size;
            this.label = "Class";
            this.ClassColor = Color.LightBlue;
        }

        public void EditClass(string name, Size size, Color color)
        {
            this.label = name;
            this.Size = size;
            this.ClassColor = color;
        }

        public void MoveClass(Point newLocation)
        {
            this.Location = newLocation;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(ClassColor);
            int x = Location.X - (Size.Width / 2);
            int y = Location.Y - (Size.Height / 2);
            Point modifiedLocation = new Point(x, y);

            Rectangle rect = new Rectangle(modifiedLocation, Size);
            Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

            graphics.DrawRectangle(pen, rect);
            graphics.FillRectangle(brush, rect);
            graphics.DrawString(this.label, font, Brushes.Black, rect);

            pen.Dispose();
            brush.Dispose();
        }

    }
}
