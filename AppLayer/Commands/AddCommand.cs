using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLayer.DrawingComponents;
using System.Drawing;

namespace AppLayer.Commands
{
    public class AddCommand : Command
    {

        Symbol Symbol;
        Point Location1;
        Point Location2;

        public AddCommand(string symbolType, Point location1, Point location2)
        {
            //use factory here to create the right kind of symbol based on the string passed in.
            //for now creates a class
            if (symbolType == "Class")
            {
                Location1 = location1;
                this.Symbol = new ClassSymbol(Location1, new Size(80, 80));
            }
            else
            {
                Location1 = location1;
                Location2 = location2;
                //use factory here to create the right kind of relationship line based on the string passed in.
                this.Symbol = 
            }
        }

        public override void Execute()
        {
            TargetDrawing.Add(Symbol);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
