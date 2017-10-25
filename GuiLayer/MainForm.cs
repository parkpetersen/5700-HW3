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
    public partial class MainForm : Form
    {
        Drawing TargetDrawing;
        private Bitmap _imageBuffer;
        private Graphics _imageBufferGraphics;
        private Graphics _panelGraphics;

        private string _SelectedTool;
        public ClassSymbol connected1, connected2;

        public MainForm()
        {
            InitializeComponent();
            TargetDrawing = new Drawing();

        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_SelectedTool == "Class")
            {
                AddCommand addCommand = new AddCommand(_SelectedTool, e.Location, e.Location);
                addCommand.TargetDrawing = TargetDrawing;
                addCommand.Execute();
                DisplayDrawing();
            }
            else
            {
                if(connected1 != null)
                {
                    Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                    if (foundSymbol.type == "Class")
                    {
                        connected1 = foundSymbol as ClassSymbol;
                    }
                }
                else if (connected2 != null)
                {
                    Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                    if (foundSymbol.type == "Class")
                    {
                        connected2 = foundSymbol as ClassSymbol;
                    }
                }
                if(connected1 != null && connected2 != null)
                {
                    AddCommand addCommand = new AddCommand(_SelectedTool, connected1.Location, connected2.Location);
                    connected1 = null;
                    connected2 = null;
                    addCommand.TargetDrawing = TargetDrawing;
                    addCommand.Execute();
                    DisplayDrawing();
                }
            }
        }

        private void DisplayDrawing()
        {
            if (_imageBuffer == null)
            {
                _imageBuffer = new Bitmap(DrawingPanel.Width, DrawingPanel.Height);
                _imageBufferGraphics = Graphics.FromImage(_imageBuffer);
                _panelGraphics = DrawingPanel.CreateGraphics();
            }

            if (TargetDrawing.Draw(_imageBufferGraphics))
                _panelGraphics.DrawImageUnscaled(_imageBuffer, 0, 0);
        }

        private void ClassIconPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _SelectedTool = "Class";
        }

        private void LineSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _SelectedTool = "Line";
        }
    }
}
