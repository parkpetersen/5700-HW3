using System;
using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Commands
{
    public class RandomizeCommand : Command
    {
        List<ClassSymbol> OldSymbols;
        List<Relationship> OldLines;

        public RandomizeCommand(Drawing drawing)
        {
            TargetDrawing = drawing;
            OldSymbols = new List<ClassSymbol>();
            foreach(ClassSymbol symbol in TargetDrawing._ClassSymbols)
            {
                ClassSymbol oldSymbol = new ClassSymbol(symbol.Location, symbol.Size, symbol.ClassColor, symbol.ForegroundColor);
                OldSymbols.Add(oldSymbol);
            }
            OldLines = new List<Relationship>();
            foreach(Relationship line in TargetDrawing._RelationShipLines)
            {
                Relationship oldLine = RelationshipFactory.Instance.Create(line.type, line.Location1, line.Location2, TargetDrawing);
                OldLines.Add(oldLine);
            }
        }

        public override bool Execute()
        {
            foreach (ClassSymbol symbol in TargetDrawing._ClassSymbols)
            {
                symbol.Randomize();
            }
            foreach(Relationship line in TargetDrawing._RelationShipLines)
            {
                line.Randomize();
            }
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            TargetDrawing._ClassSymbols = OldSymbols;
            TargetDrawing._RelationShipLines = OldLines;
            TargetDrawing.IsDirty = true;
        }
    }
}
