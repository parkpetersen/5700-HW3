using System.Windows.Forms;
using AppLayer.Commands;
using AppLayer.DrawingComponents;

namespace GuiLayer.SelectedToolStates
{
    public class DeleteState : SelectedToolState
    {
        private static DeleteState _instance;
        private static readonly object MyLock = new object();

        private DeleteState() { }

        public static DeleteState Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new DeleteState();
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
                ClassSymbol classSymbol = foundSymbol as ClassSymbol;
                for (int i = 0; i < TargetDrawing._RelationShipLines.Count; i++)
                {
                    if (TargetDrawing._RelationShipLines[i].Location1 == classSymbol.Location || TargetDrawing._RelationShipLines[i].Location2 == classSymbol.Location)
                    {
                        DeleteCommand deleteLineCommand = new DeleteCommand(TargetDrawing._RelationShipLines[i], TargetDrawing);
                        invoker.EnqueueCommandForExecution(deleteLineCommand);
                    }
                }
                DeleteCommand command = new DeleteCommand(classSymbol, TargetDrawing);
                invoker.EnqueueCommandForExecution(command);
            }
            else if (foundSymbol.type == "Binary" || foundSymbol.type == "Aggregation" || foundSymbol.type == "Composition" || foundSymbol.type == "Generalization" || foundSymbol.type == "Dependency")
            {
                Relationship line = foundSymbol as Relationship;
                DeleteCommand command = new DeleteCommand(line, TargetDrawing);
                invoker.EnqueueCommandForExecution(command);
            }
        }
    }
}
