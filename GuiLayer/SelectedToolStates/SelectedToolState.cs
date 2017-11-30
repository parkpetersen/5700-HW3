using AppLayer.DrawingComponents;
using AppLayer.Commands;
using System.Windows.Forms;

namespace GuiLayer.SelectedToolStates
{
    public abstract class SelectedToolState
    {
        public Drawing TargetDrawing { get; set; }

        public abstract void Trigger(object sender, MouseEventArgs e, Invoker invoker);
    }
}
