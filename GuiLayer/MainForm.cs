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
        public ClassSymbol connected1 = null;
        public ClassSymbol connected2 = null;

        public MainForm()
        {
            InitializeComponent();
            TargetDrawing = new Drawing();
            Timer timer = new Timer();
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
            DrawToolIcons();
            

        }

        private void timer_tick(object sender, EventArgs e)
        {
            if (TargetDrawing.IsDirty)
            {
                DisplayDrawing();
            }
        }

        private void DrawToolIcons()
        {

        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_SelectedTool == "Class")
            {
                AddCommand addCommand = new AddCommand("Class", e.Location, e.Location, TargetDrawing);
                //addCommand.TargetDrawing = TargetDrawing;
                addCommand.Execute();
                DisplayDrawing();
            }
            else
            {
                if (_SelectedTool == "Binary")
                {
                    if (connected1 == null)
                    {
                        Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                        if (foundSymbol != null && foundSymbol.type == "Class")
                        {
                            connected1 = foundSymbol as ClassSymbol;
                            Console.WriteLine($"connected1: {connected1.Location.X},{connected1.Location.Y}.");
                            foundSymbol = null;
                        }
                    }
                    else if (connected2 == null)
                    {
                        Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                        if (foundSymbol != null && foundSymbol.type == "Class")
                        {
                            connected2 = foundSymbol as ClassSymbol;
                            Console.WriteLine($"connected2: {connected2.Location.X},{connected2.Location.Y}.");
                            foundSymbol = null;
                        }
                    }
                    if (connected1 != null && connected2 != null)
                    {
                        AddCommand addCommand = new AddCommand(_SelectedTool, connected1.Location, connected2.Location, TargetDrawing);
                        connected1 = null;
                        connected2 = null;
                        //addCommand.TargetDrawing = TargetDrawing;
                        addCommand.Execute();
                        DisplayDrawing();
                    }
                }
                else if(_SelectedTool == "Edit")
                {
                    Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                    if (foundSymbol.type == "Class")
                    {
                        ClassSymbol foundClass = foundSymbol as ClassSymbol;
                        EditClass editClassWindow = new EditClass(foundClass, TargetDrawing);
                        editClassWindow.Show();
                    }
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

        private void BinarySelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _SelectedTool = "Binary";
        }

        private void EditSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _SelectedTool = "Edit";
        }
    }
}
