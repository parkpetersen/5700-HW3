using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLayer.DrawingComponents;
using AppLayer.Commands;

namespace GuiLayer
{
    public partial class EditBinary : Form
    {
        BinaryRelationship editedLine;
        Drawing TargetDrawing;
        Invoker _invoker;
        Color NewLineColor;
        Color NewArrowColor;
        int directionModifier = 1;
        int newLineThickness;

        public EditBinary(BinaryRelationship line, Drawing drawing, Invoker invoker)
        {
            InitializeComponent();
            TargetDrawing = drawing;
            _invoker = invoker;
            editedLine = line;
            LabelTextBox.Text = editedLine.label;
            LineThicknessTextBox.Text = editedLine.LineThickness.ToString();
            NewLineColor = line.LineColor;
            NewArrowColor = line.ArrowColor;
            newLineThickness = editedLine.LineThickness;

            
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (DirectionCheckBox.Checked)
                directionModifier = directionModifier * -1;
            newLineThickness = Convert.ToInt32(LineThicknessTextBox.Text);
            EditBinaryCommand command = new EditBinaryCommand(editedLine, LabelTextBox.Text, TargetDrawing, NewLineColor, NewArrowColor, directionModifier, newLineThickness);
            _invoker.EnqueueCommandForExecution(command);
            this.Hide();
        }

        private void LineColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = LineColorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                NewLineColor = LineColorDialog.Color;
            }
        }

        private void ArrowColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = ArrowColorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                NewArrowColor = ArrowColorDialog.Color;
            }
        }
    }
}
