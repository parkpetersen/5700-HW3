using System;
using AppLayer.DrawingComponents;
using System.Drawing;

namespace AppLayer.Commands
{
    public class EditDiagramCommand : Command
    {
        string OldName;
        Color OldBackgroundColor;
        Color OldForegroundColor;
        Color OldDefaultClassColor;

        string NewName;
        Color NewBackgroundColor;
        Color NewForegroundColor;
        Color NewDefaultClassColor;

        public EditDiagramCommand(string newName, Color bgColor, Color fgColor, Color defaultClassColor, Drawing drawing)
        {
            TargetDrawing = drawing;
            OldName = TargetDrawing.DrawingName;
            OldBackgroundColor = TargetDrawing.BackGroundColor;
            OldForegroundColor = TargetDrawing.ForeGroundColor;
            OldDefaultClassColor = TargetDrawing.DefaultClassColor;
            NewName = newName;
            NewBackgroundColor = bgColor;
            NewForegroundColor = fgColor;
            NewDefaultClassColor = defaultClassColor;
        }

        public override bool Execute()
        {
            TargetDrawing.EditDiagramOptions(NewName, NewBackgroundColor, NewForegroundColor, NewDefaultClassColor);
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            TargetDrawing.EditDiagramOptions(OldName, OldBackgroundColor, OldForegroundColor, OldDefaultClassColor);
            TargetDrawing.IsDirty = true;
        }

    }
}
