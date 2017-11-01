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
        [DataMember]
        public Color ForegroundColor;

        public ClassSymbol(Point location, Size size, Color bgcolor, Color fgColor)
        {
            
            this.Location = location;
            this.Size = size;
            this.label = "Class";
            this.ClassColor = bgcolor;
            this.ForegroundColor = fgColor;
        }

        public void EditClass(string name, Size size, Color bgcolor)
        {
            this.label = name;
            this.Size = size;
            this.ClassColor = bgcolor;
        }

        public void MoveClass(Point newLocation)
        {
            this.Location = newLocation;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(ForegroundColor);
            SolidBrush brush = new SolidBrush(ClassColor);
            int x = Location.X - (Size.Width / 2);
            int y = Location.Y - (Size.Height / 2);
            Point modifiedLocation = new Point(x, y);

            Rectangle rect = new Rectangle(modifiedLocation, Size);
            Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

            graphics.DrawRectangle(pen, rect);
            graphics.FillRectangle(brush, rect);
            brush.Color = ForegroundColor;
            graphics.DrawString(this.label, font, brush, rect);

            pen.Dispose();
            brush.Dispose();
        }

    }
}
