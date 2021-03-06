﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Commands
{
    public class DeleteCommand : Command
    {
        Symbol DeletedSymbol;

        public DeleteCommand(Symbol symbol, Drawing drawing)
        {
            TargetDrawing = drawing;
            DeletedSymbol = symbol;
        }
        public override bool Execute()
        {
            TargetDrawing.RemoveSymbol(DeletedSymbol);
            TargetDrawing.IsDirty = true;
            return true;
        }

        public override void Undo()
        {
            TargetDrawing.Add(DeletedSymbol);
            TargetDrawing.IsDirty = true;
        }
    }
}
