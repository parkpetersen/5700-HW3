using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLayer.DrawingComponents;
using System.Drawing;

namespace AppLayer.Commands
{
    public class EditClassCommand : Command
    {
        public ClassSymbol Symbol;
        string EditedName;
        Size EditedSize;
        Color EditedColor;
        string OldName;
        Size OldSize;
        Color OldColor;

        public EditClassCommand(ClassSymbol symbol, string name, Size size, Color color, Drawing drawing)
        {
            this.Symbol = symbol;
            this.OldName = symbol.label;
            this.OldSize = symbol.Size;
            this.OldColor = symbol.ClassColor;
            this.EditedName = name;
            this.EditedSize = size;
            this.EditedColor = color;
            this.TargetDrawing = drawing;
        }

        public override bool Execute()
        {
            Symbol.EditClass(EditedName, EditedSize, EditedColor);
            this.TargetDrawing.IsDirty = true;
            return true;
            
        }

        public override void Undo()
        {
            Symbol.EditClass(OldName, OldSize, OldColor);
            this.TargetDrawing.IsDirty = true;
        }
    }
}
