using System;
using System.Drawing;
using System.Windows.Forms;
using AppLayer.DrawingComponents;
using AppLayer.Commands;

namespace GuiLayer
{
    public partial class EditLine : Form
    {
        Relationship EditedLine;
        Color NewLineColor;
        Invoker _invoker;
        Drawing TargetDrawing;
        Color NewSymbolColor;
        int SymbolSizeMulitplier;

        public EditLine(Relationship line, Invoker invoker, Drawing drawing)
        {
            InitializeComponent();
            EditedLine = line;
            NewLineColor = line.LineColor;
            LineThicknessTextBox.Text = line.LineThickness.ToString();
            SymbolSizeTextBox.Text = line.SymbolSizeMultiplier.ToString();
            _invoker = invoker;
            TargetDrawing = drawing;
            NewSymbolColor = EditedLine.SymbolFillColor;
            SymbolSizeMulitplier = EditedLine.SymbolSizeMultiplier;
        }

        private void LineColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = LineColorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                NewLineColor = LineColorDialog.Color;
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            int newThickness = Convert.ToInt32(LineThicknessTextBox.Text);
            SymbolSizeMulitplier = Convert.ToInt32(SymbolSizeTextBox.Text);
            EditLineCommand command = new EditLineCommand(EditedLine, newThickness, NewLineColor, NewSymbolColor, SymbolSizeMulitplier ,TargetDrawing);
            _invoker.EnqueueCommandForExecution(command);
            this.Hide();
        }

        private void SymbolFillColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = SymbolColorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                NewSymbolColor = SymbolColorDialog.Color;
            }
        }
    }
}
