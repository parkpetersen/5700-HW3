using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLayer.DrawingComponents;
using System.Drawing;

namespace AppLayer.Commands
{
    public class AddCommand : Command
    {

        Symbol Symbol;
        Point Location1;
        Point Location2;
        RelationshipFactory RelationshipFactory = RelationshipFactory.Instance;

        public AddCommand(string symbolType, Point location1, Point location2, Drawing drawing)
        {
            this.TargetDrawing = drawing;
            //RelationshipFactory = RelationshipFactory.Instance;
            //use factory here to create the right kind of symbol based on the string passed in.
            //for now creates a class
            if (symbolType == "Class")
            {
                Location1 = location1;
                this.Symbol = new ClassSymbol(Location1, new Size(80, 80), TargetDrawing.DefaultClassColor, TargetDrawing.ForeGroundColor);
                this.Symbol.type = "Class";
            }
            else
            {
                Location1 = location1;
                Location2 = location2;
                //use factory here to create the right kind of relationship line based on the string passed in.
                this.Symbol = Symbol as Relationship;
                this.Symbol = RelationshipFactory.Instance.Create(symbolType, Location1, Location2, TargetDrawing);
                this.Symbol.type = symbolType;
            }
        }

        public override bool Execute()
        {
            TargetDrawing.Add(Symbol);
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            TargetDrawing.RemoveSymbol(Symbol);
            TargetDrawing.IsDirty = true;
        }
    }
}
