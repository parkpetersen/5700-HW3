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
    public partial class EditClass : Form
    {
        Color receivedColor;
        Drawing TargetDrawing;
        ClassSymbol EditedSymbol;

        public EditClass(ClassSymbol Symbol, Drawing targetDrawing)
        {
            InitializeComponent();
            EditedSymbol = Symbol;
            NameTextBox.Text = Symbol.label;
            string widthText = Symbol.Size.Width.ToString();
            string heightText = Symbol.Size.Height.ToString();
            WidthTextBox.Text = widthText;
            HeightTextBox1.Text = heightText;
            TargetDrawing = targetDrawing;
            receivedColor = Symbol.ClassColor;
        }

        private void ColorChangeButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                receivedColor = colorDialog1.Color;
            }

        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            int newWidth = Convert.ToInt32(WidthTextBox.Text);
            int newHeight = Convert.ToInt32(HeightTextBox1.Text);
            Size newSize = new Size(newWidth, newHeight);
            EditClassCommand command = new EditClassCommand(EditedSymbol, NameTextBox.Text, newSize, receivedColor, TargetDrawing);
            command.Execute();
            this.Hide();
        }
    }
}
