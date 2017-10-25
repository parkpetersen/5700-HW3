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
            int x = location.X - (size.Width / 2);
            int y = location.Y - (size.Height / 2);
            this.Location = new Point(x, y);
            this.Size = size;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.BlueViolet);
            
            Rectangle rect = new Rectangle(Location, Size);
            
            graphics.DrawRectangle(pen, rect);
            graphics.FillRectangle(brush, rect);
        }

    }
}
