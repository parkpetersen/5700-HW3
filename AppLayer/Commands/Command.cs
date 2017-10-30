using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLayer.DrawingComponents;

namespace AppLayer.Commands
{
    public abstract class Command
    {
        public Drawing TargetDrawing { get; set; }

        public abstract bool Execute();
        public abstract void Undo();
    }
}
