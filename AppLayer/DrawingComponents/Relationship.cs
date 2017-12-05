using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public abstract class Relationship : Symbol
    {
        [DataMember]
        public virtual Point Location1 { get; set; } = new Point(0, 0);
        [DataMember]
        public virtual Point Location2 { get; set; } = new Point(0, 0);
        [DataMember]
        public virtual Color LineColor { get; set; } = Color.Black;
        [DataMember]
        public int LineThickness { get; set; } = 1;
        [DataMember]
        public virtual Color SymbolFillColor { get; set; } = Color.White;
        [DataMember]
        public virtual int SymbolSizeMultiplier { get; set; } = 1;

        public void MoveLine(Point oldLocation, Point newLocation)
        {
            if(Location1 == oldLocation)
            {
                Location1 = newLocation;
            }
            else if(Location2 == oldLocation)
            {
                Location2 = newLocation;
            }
        }

        public void EditLine(Color newColor, int newThickness, Color newFillColor, int newMultiplier)
        {
            LineColor = newColor;
            LineThickness = newThickness;
            SymbolFillColor = newFillColor;
            SymbolSizeMultiplier = newMultiplier;
        }

        public override void Randomize()
        {
            Random r = new Random();
            Random r2 = new Random(Location1.X + Location2.Y * r.Next());
            this.LineColor = ClassSymbol.RandomColor[r2.Next(0, ClassSymbol.RandomColor.Length)];
            if (type != "Composition")
            {
                this.SymbolFillColor = ClassSymbol.RandomColor[(r.Next(0, ClassSymbol.RandomColor.Length) + r.Next(0, ClassSymbol.RandomColor.Length)) % ClassSymbol.RandomColor.Length];
            }
                    
        }

    }
}
