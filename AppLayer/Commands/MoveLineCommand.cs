using System;
using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Commands
{
    public class MoveLineCommand : Command
    {
        Point OldLocation;
        Point NewLocation;
        Relationship MovedLine;

        public MoveLineCommand(Relationship line, Point oldLocation, Point newLocation, Drawing drawing)
        {
            TargetDrawing = drawing;
            MovedLine = line;
            OldLocation = oldLocation;
            NewLocation = newLocation;
        }

        public override bool Execute()
        {
            MovedLine.MoveLine(OldLocation, NewLocation);
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            MovedLine.MoveLine(NewLocation, OldLocation);
            TargetDrawing.IsDirty = true;
        }
    }
}
