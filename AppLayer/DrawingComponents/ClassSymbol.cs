using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AppLayer.DrawingComponents
{
    public class ClassSymbol : Symbol
    {
        public virtual Point Location { get; set; } = new Point(0, 0);
        public virtual Size Size { get; set; } = new Size(0, 0);

        public ClassSymbol(Point location, Size size)
        {
            
            this.Location = location;
            this.Size = size;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.BlueViolet);
            int x = Location.X - (Size.Width / 2);
            int y = Location.Y - (Size.Height / 2);
            Point modifiedLocation = new Point(x, y);

            Rectangle rect = new Rectangle(modifiedLocation, Size);
            
            graphics.DrawRectangle(pen, rect);
            graphics.FillRectangle(brush, rect);
        }

    }
}
