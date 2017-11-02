using System;
using AppLayer.DrawingComponents;
using System.Drawing;

namespace AppLayer.Commands
{
    public class EditLineCommand : Command
    {
        Relationship Line;
        int oldThickness;
        int newThickness;
        Color oldColor;
        Color newColor;
        Color oldSymbolColor;
        Color newSymbolColor;
        int oldSizeMultiplier;
        int newSizeMultiplier;

        public EditLineCommand(Relationship line, int thickness, Color color, Color symbolColor, int symbolSize, Drawing drawing)
        {
            Line = line;
            oldThickness = Line.LineThickness;
            newThickness = thickness;
            oldColor = Line.LineColor;
            newColor = color;
            TargetDrawing = drawing;
            oldSymbolColor = Line.SymbolFillColor;
            newSymbolColor = symbolColor;
            oldSizeMultiplier = Line.SymbolSizeMultiplier;
            newSizeMultiplier = symbolSize;
        }

        public override bool Execute()
        {
            Line.EditLine(newColor, newThickness, newSymbolColor, newSizeMultiplier);
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            Line.EditLine(oldColor, oldThickness, oldSymbolColor, oldSizeMultiplier);
            TargetDrawing.IsDirty = true;
        }
    }
}
