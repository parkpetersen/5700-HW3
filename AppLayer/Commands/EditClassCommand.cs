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

        public EditClassCommand(ClassSymbol symbol, string name, Size size, Color color, Drawing drawing)
        {
            this.Symbol = symbol;
            this.EditedName = name;
            this.EditedSize = size;
            this.EditedColor = color;
            this.TargetDrawing = drawing;
        }

        public override void Execute()
        {
            Symbol.EditClass(EditedName, EditedSize, EditedColor);
            this.TargetDrawing.IsDirty = true;
            
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
