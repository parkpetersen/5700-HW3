using System.Windows.Forms;
using AppLayer.Commands;
using AppLayer.DrawingComponents;

namespace GuiLayer.SelectedToolStates
{
    public class RelationshipState : SelectedToolState
    {
        private static RelationshipState _instance;
        private static readonly object MyLock = new object();

        private RelationshipState() { }

        public static RelationshipState Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new RelationshipState();
                }
                return _instance;
            }
        }

        public override void Trigger(object sender, MouseEventArgs e, Invoker invoker)
        {
            if (MainForm.selected1 == null)
            {
                Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                if (foundSymbol != null && foundSymbol.type == "Class")
                {
                    MainForm.selected1 = foundSymbol as ClassSymbol;
                    foundSymbol = null;
                }
            }
            else if (MainForm.selected2 == null)
            {
                Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                if (foundSymbol != null && foundSymbol.type == "Class")
                {
                    MainForm.selected2 = foundSymbol as ClassSymbol;
                    foundSymbol = null;
                }
            }
            if (MainForm.selected1 != null && MainForm.selected2 != null)
            {
                AddCommand addCommand = new AddCommand(MainForm._SelectedTool, MainForm.selected1.Location, MainForm.selected2.Location, TargetDrawing);
                MainForm.selected1 = null;
                MainForm.selected2 = null;
                invoker.EnqueueCommandForExecution(addCommand);
            }
        }
    }
}
