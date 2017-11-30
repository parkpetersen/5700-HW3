
using System.Windows.Forms;
using AppLayer.Commands;
using AppLayer.DrawingComponents;

namespace GuiLayer.SelectedToolStates
{
    public class ClassState : SelectedToolState
    {
        private static ClassState _instance;
        private static readonly object MyLock = new object();

        private ClassState() { }

        public static ClassState Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new ClassState();
                }
                return _instance;
            }
        }

        public override void Trigger(object sender, MouseEventArgs e, Invoker invoker)
        {
            AddCommand addCommand = new AddCommand("Class", e.Location, e.Location, TargetDrawing);
            invoker.EnqueueCommandForExecution(addCommand);
        }
    }
}
