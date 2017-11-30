using System.Windows.Forms;
using AppLayer.Commands;
using AppLayer.DrawingComponents;

namespace GuiLayer.SelectedToolStates
{
    public class MoveState : SelectedToolState
    {
        private static MoveState _instance;
        private static readonly object MyLock = new object();

        private MoveState() { }

        public static MoveState Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new MoveState();
                }
                return _instance;
            }
        }

        public override void Trigger(object sender, MouseEventArgs e, Invoker invoker)
        {
            if (MainForm.selected1 == null)
            {
                Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                if (foundSymbol == null)
                {

                }
                else if (foundSymbol.type == "Class")
                {
                    MainForm.selected1 = foundSymbol as ClassSymbol;
                }
            }
            else if (MainForm.moveToLocation == MainForm.defaultLocation)
            {
                MainForm.moveToLocation = e.Location;
            }

            if (MainForm.selected1 != null && MainForm.moveToLocation != MainForm.defaultLocation)
            {
                for (int i = 0; i < TargetDrawing._RelationShipLines.Count; i++)
                {
                    if (TargetDrawing._RelationShipLines[i].Location1 == MainForm.selected1.Location || TargetDrawing._RelationShipLines[i].Location2 == MainForm.selected1.Location)
                    {
                        MoveLineCommand moveCommand = new MoveLineCommand(TargetDrawing._RelationShipLines[i], MainForm.selected1.Location, MainForm.moveToLocation, TargetDrawing);
                        invoker.EnqueueCommandForExecution(moveCommand);
                    }
                }
                MoveClassCommand moveClass = new MoveClassCommand(MainForm.selected1, MainForm.moveToLocation, TargetDrawing);
                invoker.EnqueueCommandForExecution(moveClass);
                MainForm.selected1 = null;
                MainForm.moveToLocation = MainForm.defaultLocation;
            }
        }
    }
}
