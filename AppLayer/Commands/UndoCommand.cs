using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Commands
{
    public class UndoCommand : Command
    {
        public override bool Execute()
        {
            return false;
        }

        public override void Undo()
        {

        }
    }
}
