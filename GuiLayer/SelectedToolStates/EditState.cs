using System.Windows.Forms;
using AppLayer.Commands;
using AppLayer.DrawingComponents;

namespace GuiLayer.SelectedToolStates
{
    public class EditState : SelectedToolState
    {
        private static EditState _instance;
        private static readonly object MyLock = new object();

        private EditState() { }

        public static EditState Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new EditState();
                }
                return _instance;
            }
        }

        public override void Trigger(object sender, MouseEventArgs e, Invoker invoker)
        {
            Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
            if (foundSymbol == null)
            {

            }
            else if (foundSymbol.type == "Class")
            {
                ClassSymbol foundClass = foundSymbol as ClassSymbol;
                EditClass editClassWindow = new EditClass(foundClass, TargetDrawing, invoker);
                editClassWindow.Show();
            }
            else if (foundSymbol.type == "Binary")
            {
                BinaryRelationship foundBinary = foundSymbol as BinaryRelationship;
                EditBinary editBinaryWindow = new EditBinary(foundBinary, TargetDrawing, invoker);
                editBinaryWindow.Show();

            }
            else
            {
                Relationship foundLine = foundSymbol as Relationship;
                EditLine editLineWindow = new EditLine(foundLine, invoker, TargetDrawing);
                editLineWindow.Show();
            }
        }
    }
}
