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
            ResetColors();
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
                if (_SelectedTool == "Binary" || _SelectedTool == "Aggregation" || _SelectedTool == "Composition" || _SelectedTool == "Generalization" || _SelectedTool == "Dependency")
                {
                    if (connected1 == null)
                    {
                        Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                        if (foundSymbol != null && foundSymbol.type == "Class")
                        {
                            connected1 = foundSymbol as ClassSymbol;
                            foundSymbol = null;
                        }
                    }
                    else if (connected2 == null)
                    {
                        Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                        if (foundSymbol != null && foundSymbol.type == "Class")
                        {
                            connected2 = foundSymbol as ClassSymbol;
                            foundSymbol = null;
                        }
                    }
                    if (connected1 != null && connected2 != null)
                    {
                        AddCommand addCommand = new AddCommand(_SelectedTool, connected1.Location, connected2.Location, TargetDrawing);
                        connected1 = null;
                        connected2 = null;
                        addCommand.Execute();
                        DisplayDrawing();
                    }
                }
                else if(_SelectedTool == "Edit")
                {
                    Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                    if (foundSymbol == null)
                    {

                    }
                    else if (foundSymbol.type == "Class")
                    {
                        ClassSymbol foundClass = foundSymbol as ClassSymbol;
                        EditClass editClassWindow = new EditClass(foundClass, TargetDrawing);
                        editClassWindow.Show();
                    }
                    else if (foundSymbol.type == "Binary")
                    {
                        BinaryRelationship foundBinary = foundSymbol as BinaryRelationship;
                        EditBinary editBinaryWindow = new EditBinary(foundBinary, TargetDrawing);
                        editBinaryWindow.Show();

                    }
                }
                else if(_SelectedTool == "Delete")
                {
                    Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                    if(foundSymbol == null)
                    {

                    }
                    else if(foundSymbol.type == "Class")
                    {
                        ClassSymbol classSymbol = foundSymbol as ClassSymbol;
                        for(int i = 0; i < TargetDrawing._RelationShipLines.Count; i++)
                        {
                            if(TargetDrawing._RelationShipLines[i].Location1 == classSymbol.Location || TargetDrawing._RelationShipLines[i].Location2 == classSymbol.Location)
                            {
                                DeleteCommand deleteLineCommand = new DeleteCommand(TargetDrawing._RelationShipLines[i], TargetDrawing);
                                deleteLineCommand.Execute();
                            }
                        }
                        DeleteCommand command = new DeleteCommand(classSymbol, TargetDrawing);
                        command.Execute();
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
            ResetColors();
            _SelectedTool = "Class";
            ClassIconPanel.BackColor = Color.LightYellow;
        }

        private void BinarySelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            _SelectedTool = "Binary";
            BinarySelectPanel.BackColor = Color.LightYellow;
        }

        private void EditSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            _SelectedTool = "Edit";
            EditSelectPanel.BackColor = Color.LightYellow;
        }

        private void AggregationSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            _SelectedTool = "Aggregation";
            AggregationSelectPanel.BackColor = Color.LightYellow;
        }

        private void CompositionSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            _SelectedTool = "Composition";
            CompositionSelectPanel.BackColor = Color.LightYellow;
        }

        private void GeneralizationSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            _SelectedTool = "Generalization";
            GeneralizationSelectPanel.BackColor = Color.LightYellow;
        }

        private void DependencySelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            _SelectedTool = "Dependency";
            DependencySelectPanel.BackColor = Color.LightYellow;
        }

        private void DeleteToolSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            _SelectedTool = "Delete";
            DeleteToolSelectPanel.BackColor = Color.LightYellow;
        }

        private void ResetColors()
        {
            ClassIconPanel.BackColor = Color.LightBlue;
            BinarySelectPanel.BackColor = Color.LightBlue;
            EditSelectPanel.BackColor = Color.LightBlue;
            AggregationSelectPanel.BackColor = Color.LightBlue;
            CompositionSelectPanel.BackColor = Color.LightBlue;
            GeneralizationSelectPanel.BackColor = Color.LightBlue;
            DependencySelectPanel.BackColor = Color.LightBlue;
            DeleteToolSelectPanel.BackColor = Color.LightBlue;
        }

      
    }
}
