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

        public EditBinary(BinaryRelationship line, Drawing drawing)
        {
            InitializeComponent();
            TargetDrawing = drawing;
            editedLine = line;
            LabelTextBox.Text = editedLine.label;
            
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            EditBinaryCommand command = new EditBinaryCommand(editedLine, LabelTextBox.Text, TargetDrawing);
            command.Execute();
            this.Hide();
        }
    }
}
