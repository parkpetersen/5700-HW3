using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLayer.DrawingComponents;

namespace AppLayer.Commands
{
    public class EditBinaryCommand : Command
    {
        public BinaryRelationship line { get; set; }
        public string oldLabel { get; set; }
        public string editedLabel { get; set; }

        public EditBinaryCommand(BinaryRelationship line, string label, Drawing drawing)
        {
            this.line = line;
            oldLabel = line.label;
            this.editedLabel = label;
            this.TargetDrawing = drawing;
        }

        public override bool Execute()
        {
            line.EditBinary(editedLabel);
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            line.EditBinary(oldLabel);
            TargetDrawing.IsDirty = true;
        }
    }
}
