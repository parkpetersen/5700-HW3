using System.Windows.Forms;
using AppLayer.DrawingComponents;
using System.Drawing;
using AppLayer.Commands;

namespace GuiLayer
{
    public partial class EditDiagram : Form
    {
        Drawing TargetDrawing;
        Color newBackgroundColor;
        Color newForegroundColor;
        Color newClassColor;
        Invoker _invoker;


        public EditDiagram(Drawing drawing, Invoker invoker)
        {
            InitializeComponent();
            TargetDrawing = drawing;
            NameTextBox.Text = TargetDrawing.DrawingName;
            _invoker = invoker;
            newBackgroundColor = TargetDrawing.BackGroundColor;
            newForegroundColor = TargetDrawing.ForeGroundColor;
            newClassColor = TargetDrawing.DefaultClassColor;
        }

        private void BackgroundColorButton_Click(object sender, System.EventArgs e)
        {
            DialogResult result = BackgroundColorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                newBackgroundColor = BackgroundColorDialog.Color;
            }
        }

        private void ForegroundColorButton_Click(object sender, System.EventArgs e)
        {
            DialogResult result = ForegroundColorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                newForegroundColor = ForegroundColorDialog.Color;
            }
        }

        private void ClassColorButton_Click(object sender, System.EventArgs e)
        {
            DialogResult result = ClassColorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                newClassColor = ClassColorDialog.Color;
            }
        }

        private void AcceptButton_Click(object sender, System.EventArgs e)
        {
            EditDiagramCommand command = new EditDiagramCommand(NameTextBox.Text, newBackgroundColor, newForegroundColor, newClassColor, TargetDrawing);
            _invoker.EnqueueCommandForExecution(command);
            this.Hide();
        }
    }
}
