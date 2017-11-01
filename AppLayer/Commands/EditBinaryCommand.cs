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

        public EditBinaryCommand(BinaryRelationship line, string label, Drawing drawing, Color lineColor, Color arrowColor, int direction)
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
        }

        public override bool Execute()
        {
            line.EditBinary(editedLabel, newLineColor, newDirection, newArrowColor);
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            line.EditBinary(oldLabel, oldLineColor, oldDirection, oldArrowColor);
            TargetDrawing.IsDirty = true;
        }
    }
}
