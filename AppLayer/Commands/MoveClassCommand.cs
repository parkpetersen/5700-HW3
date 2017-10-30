using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLayer.DrawingComponents;
using System.Drawing;

namespace AppLayer.Commands
{
    public class MoveClassCommand : Command
    {
        ClassSymbol MovedSymbol;
        Point OldLocation;
        Point NewLocation;

        public MoveClassCommand(ClassSymbol symbol, Point newLocation, Drawing drawing)
        {
            TargetDrawing = drawing;
            MovedSymbol = symbol;
            OldLocation = MovedSymbol.Location;
            NewLocation = newLocation;
        }

        public override bool Execute()
        {
            MovedSymbol.MoveClass(NewLocation);
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            MovedSymbol.MoveClass(OldLocation);
            TargetDrawing.IsDirty = true;
        }
    }
}
