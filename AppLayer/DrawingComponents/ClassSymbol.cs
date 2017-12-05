using System.Drawing;
using System.Runtime.Serialization;
using System;

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

        public static Color[] RandomColor = new Color[]
        {
            Color.AliceBlue,
            Color.AntiqueWhite,
            Color.Aqua,
            Color.Aquamarine,
            Color.Azure,
            Color.Beige,
            Color.Bisque,
            Color.BlanchedAlmond,
            Color.Blue,
            Color.BlueViolet,
            Color.Brown,
            Color.BurlyWood,
            Color.CadetBlue,
            Color.Chartreuse,
            Color.Chocolate,
            Color.Coral,
            Color.CornflowerBlue,
            Color.Cornsilk,
            Color.Crimson,
            Color.Cyan,
            Color.DarkBlue,
            Color.DarkCyan,
            Color.DarkGoldenrod,
            Color.DarkGray,
            Color.DarkGreen,
            Color.DarkKhaki,
            Color.DarkMagenta,
            Color.DarkOliveGreen,
            Color.DarkOrange,
            Color.DarkOrchid,
            Color.DarkRed,
            Color.DarkSalmon,
            Color.DarkSeaGreen,
            Color.DarkSeaGreen,
            Color.DarkSlateBlue,
            Color.DarkSlateGray,
            Color.DarkTurquoise,
            Color.DarkViolet,
            Color.DeepPink,
            Color.DeepSkyBlue,
            Color.DimGray,
            Color.DodgerBlue,
            Color.Firebrick,
            Color.FloralWhite,
            Color.ForestGreen,
            Color.Fuchsia,
            Color.Gainsboro,
            Color.GhostWhite,
            Color.Gold,
            Color.Goldenrod,
            Color.Gray,
            Color.Green,
            Color.GreenYellow,
            Color.Honeydew,
            Color.HotPink,
            Color.IndianRed,
            Color.Indigo,
            Color.Ivory,
            Color.Khaki,
            Color.Lavender,
            Color.LavenderBlush,
            Color.LawnGreen,
            Color.LemonChiffon,
            Color.LightBlue,
            Color.LightCoral,
            Color.LightCyan,
            Color.LightGoldenrodYellow,
            Color.LightGray,
            Color.LightGreen,
            Color.LightPink,
            Color.LightSalmon,
            Color.LightSeaGreen,
            Color.LightSkyBlue,
            Color.LightSlateGray,
            Color.LightSteelBlue,
            Color.LightYellow,
            Color.Lime,
            Color.LimeGreen,
            Color.Linen,
            Color.Magenta,
            Color.Maroon,
            Color.MediumAquamarine,
            Color.MediumBlue,
            Color.MediumOrchid,
            Color.MediumPurple,
            Color.MediumSeaGreen,
            Color.MediumSlateBlue,
            Color.MediumSpringGreen,
            Color.MediumTurquoise,
            Color.MediumVioletRed,
            Color.MidnightBlue,
            Color.MintCream,
            Color.MistyRose,
            Color.Moccasin,
            Color.NavajoWhite,
            Color.Navy,
            Color.OldLace,
            Color.Olive,
            Color.OliveDrab,
            Color.Orange,
            Color.OrangeRed,
            Color.Orchid,
            Color.PaleGoldenrod,
            Color.PaleGreen,
            Color.PaleTurquoise,
            Color.PaleVioletRed,
            Color.PapayaWhip,
            Color.PeachPuff,
            Color.Peru,
            Color.Pink,
            Color.Plum,
            Color.PowderBlue,
            Color.Purple,
            Color.Red,
            Color.RosyBrown,
            Color.RoyalBlue,
            Color.SaddleBrown,
            Color.Salmon,
            Color.SandyBrown,
            Color.SeaGreen,
            Color.SeaShell,
            Color.Sienna,
            Color.Silver,
            Color.SkyBlue,
            Color.SlateBlue,
            Color.SlateGray,
            Color.Snow,
            Color.SpringGreen,
            Color.SteelBlue,
            Color.Tan,
            Color.Teal,
            Color.Thistle,
            Color.Tomato,
            Color.Transparent,
            Color.Turquoise,
            Color.Violet,
            Color.Wheat,
            Color.White,
            Color.WhiteSmoke,
            Color.Yellow,
            Color.YellowGreen

        };

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

        public override void Randomize()
        {
            Random r = new Random();
            Random r2 = new Random(Location.X + Location.Y * r.Next());
            this.ClassColor = ClassSymbol.RandomColor[r2.Next(0, RandomColor.Length)];
        }

    }
}
