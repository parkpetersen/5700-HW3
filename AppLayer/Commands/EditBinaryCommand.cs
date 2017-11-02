using AppLayer.DrawingComponents;
using System.Drawing;

namespace AppLayer.Commands
{
    public class EditBinaryCommand : Command
    {
        public BinaryRelationship line { get; set; }
        public string oldLabel { get; set; }
        public string editedLabel { get; set; }
        Color oldLineColor;
        Color newLineColor;
        Color oldArrowColor;
        Color newArrowColor;
        int oldDirection;
        int newDirection;
        int oldThickness;
        int newThickness;

        public EditBinaryCommand(BinaryRelationship line, string label, Drawing drawing, Color lineColor, Color arrowColor, int direction, int thickness)
        {
            this.line = line;
            oldLabel = line.label;
            this.editedLabel = label;
            this.TargetDrawing = drawing;
            oldLineColor = line.LineColor;
            newLineColor = lineColor;
            oldArrowColor = line.ArrowColor;
            newArrowColor = arrowColor;
            oldDirection = line.directionSwap;
            newDirection = direction;
            oldThickness = line.LineThickness;
            newThickness = thickness;
        }

        public override bool Execute()
        {
            line.EditBinary(editedLabel, newLineColor, newDirection, newArrowColor, newThickness);
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            line.EditBinary(oldLabel, oldLineColor, oldDirection, oldArrowColor, oldThickness);
            TargetDrawing.IsDirty = true;
        }
    }
}
