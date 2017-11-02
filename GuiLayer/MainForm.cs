using System;
using System.Drawing;
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
        public ClassSymbol selected1 = null;
        public ClassSymbol selected2 = null;
        public Point defaultLocation = new Point(1, 1);
        public Point moveToLocation;
        private readonly Invoker _invoker = new Invoker();

        public MainForm()
        {
            InitializeComponent();
            TargetDrawing = new Drawing();
            Timer timer = new Timer();
            timer.Interval = (100);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
            ResetColors();
            //makeTools();
            moveToLocation = defaultLocation;
            _invoker.Start();

        }

        private void timer_tick(object sender, EventArgs e)
        {
            if (TargetDrawing.IsDirty)
            {
                DisplayDrawing();
                DiagramNameLabel.Text = TargetDrawing.DrawingName;
            }
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_SelectedTool == "Class")
            {
                AddCommand addCommand = new AddCommand("Class", e.Location, e.Location, TargetDrawing);
                _invoker.EnqueueCommandForExecution(addCommand);
                DisplayDrawing();
            }
            else
            {
                if (_SelectedTool == "Binary" || _SelectedTool == "Aggregation" || _SelectedTool == "Composition" || _SelectedTool == "Generalization" || _SelectedTool == "Dependency")
                {
                    if (selected1 == null)
                    {
                        Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                        if (foundSymbol != null && foundSymbol.type == "Class")
                        {
                            selected1 = foundSymbol as ClassSymbol;
                            foundSymbol = null;
                        }
                    }
                    else if (selected2 == null)
                    {
                        Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                        if (foundSymbol != null && foundSymbol.type == "Class")
                        {
                            selected2 = foundSymbol as ClassSymbol;
                            foundSymbol = null;
                        }
                    }
                    if (selected1 != null && selected2 != null)
                    {
                        AddCommand addCommand = new AddCommand(_SelectedTool, selected1.Location, selected2.Location, TargetDrawing);
                        selected1 = null;
                        selected2 = null;
                        _invoker.EnqueueCommandForExecution(addCommand);
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
                        EditClass editClassWindow = new EditClass(foundClass, TargetDrawing, _invoker);
                        editClassWindow.Show();
                    }
                    else if (foundSymbol.type == "Binary")
                    {
                        BinaryRelationship foundBinary = foundSymbol as BinaryRelationship;
                        EditBinary editBinaryWindow = new EditBinary(foundBinary, TargetDrawing, _invoker);
                        editBinaryWindow.Show();

                    }
                    else
                    {
                        Relationship foundLine = foundSymbol as Relationship;
                        EditLine editLineWindow = new EditLine(foundLine, _invoker, TargetDrawing);
                        editLineWindow.Show();
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
                                _invoker.EnqueueCommandForExecution(deleteLineCommand);
                            }
                        }
                        DeleteCommand command = new DeleteCommand(classSymbol, TargetDrawing);
                        _invoker.EnqueueCommandForExecution(command);
                    }
                    else if(foundSymbol.type == "Binary" || foundSymbol.type == "Aggregation" || foundSymbol.type == "Composition" || foundSymbol.type == "Generalization" || foundSymbol.type == "Dependency")
                    {
                        Relationship line = foundSymbol as Relationship;
                        DeleteCommand command = new DeleteCommand(line, TargetDrawing);
                        _invoker.EnqueueCommandForExecution(command);
                    }
                }
                else if(_SelectedTool == "Move")
                {
                    if(selected1 == null)
                    {
                        Symbol foundSymbol = TargetDrawing.FindSymbolAtPosition(e.Location);
                        if (foundSymbol == null)
                        {

                        }
                        else if (foundSymbol.type == "Class")
                        {
                            selected1 = foundSymbol as ClassSymbol;
                        }
                    }
                    else if(moveToLocation == defaultLocation)
                    {
                        moveToLocation = e.Location;
                    }

                    if(selected1 != null && moveToLocation != defaultLocation)
                    {
                        for(int i = 0; i < TargetDrawing._RelationShipLines.Count; i++)
                        {
                            if(TargetDrawing._RelationShipLines[i].Location1 == selected1.Location || TargetDrawing._RelationShipLines[i].Location2 == selected1.Location)
                            {
                                MoveLineCommand moveCommand = new MoveLineCommand(TargetDrawing._RelationShipLines[i], selected1.Location, moveToLocation, TargetDrawing);
                                _invoker.EnqueueCommandForExecution(moveCommand);
                            }
                        }
                        MoveClassCommand moveClass = new MoveClassCommand(selected1, moveToLocation, TargetDrawing);
                        _invoker.EnqueueCommandForExecution(moveClass);
                        selected1 = null;
                        moveToLocation = defaultLocation;
                    }
                }
            }
        }

        /**
        private void makeTools()
        {
            DrawToolIcons(ClassIconPanel, "Class");
        }

        private void DrawToolIcons(Panel panel, string type)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Purple);
            if(_selectionBuffer == null)
            {
                _selectionBuffer = new Bitmap(panel.Width, panel.Height);
                _selectionBufferGraphics = Graphics.FromImage(_selectionBuffer);
                _selectionGraphics = panel.CreateGraphics();
            }
            if(type == "Class")
            {
                Point location = new Point(0, 0);
                Size size = new Size(20, 20);
                Rectangle rect = new Rectangle(location, size);
                _selectionGraphics.DrawRectangle(pen, rect);
                _selectionGraphics.FillRectangle(brush, rect);
            }
            
        }
    **/

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
            UndoSelectPanel.BackColor = Color.LightBlue;
            RedoSelectPanel.BackColor = Color.LightBlue;
            MoveSelectPanel.BackColor = Color.LightBlue;
            SaveSelectPanel.BackColor = Color.LightBlue;
            OpenSelectPanel.BackColor = Color.LightBlue;
            OptionsSelectPanel.BackColor = Color.LightBlue;
            NewSelectPanel.BackColor = Color.LightBlue;
        }

        private void UndoSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _invoker.Undo();
            ResetColors();
        }

        private void UndoSelectPanel_MouseDown(object sender, MouseEventArgs e)
        {
            UndoSelectPanel.BackColor = Color.LightYellow;
        }

        private void RedoSelectPanel_MouseDown(object sender, MouseEventArgs e)
        {
            RedoSelectPanel.BackColor = Color.LightYellow;
        }

        private void RedoSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _invoker.Redo();
            ResetColors();
        }

        private void MoveSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            _SelectedTool = "Move";
            MoveSelectPanel.BackColor = Color.LightYellow;
        }

        private void SaveSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            Save();
            
        }

        private void Save()
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = "json",
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveCommand command = new SaveCommand(dialog.FileName);
                command.TargetDrawing = TargetDrawing;
                _invoker.EnqueueCommandForExecution(command);
            }
        }

        private void SaveSelectPanel_MouseDown(object sender, MouseEventArgs e)
        {
            SaveSelectPanel.BackColor = Color.LightYellow;
        }

        private void OpenSelectPanel_MouseDown(object sender, MouseEventArgs e)
        {
            OpenSelectPanel.BackColor = Color.LightYellow;
        }

        private void OpenSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            Open();            
        }

        private void Open()
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = "json",
                Multiselect = false,
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OpenCommand command = new OpenCommand(TargetDrawing, dialog.FileName);
                command.TargetDrawing = TargetDrawing;
                _invoker.EnqueueCommandForExecution(command);
            }
        }

        private void OptionsSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            EditDiagram editDiagramWindow = new EditDiagram(TargetDrawing, _invoker);
            editDiagramWindow.Show();
        }

        private void OptionsSelectPanel_MouseDown(object sender, MouseEventArgs e)
        {
            OptionsSelectPanel.BackColor = Color.LightYellow;
        }

        private void NewSelectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResetColors();
            NewDrawingCommand command = new NewDrawingCommand(TargetDrawing);
            _invoker.EnqueueCommandForExecution(command);
            
        }

        private void NewSelectPanel_MouseDown(object sender, MouseEventArgs e)
        {
            NewSelectPanel.BackColor = Color.LightYellow;
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'n' || e.KeyChar == 'N')
            {
                NewDrawingCommand command = new NewDrawingCommand(TargetDrawing);
                _invoker.EnqueueCommandForExecution(command);
            }
            else if(e.KeyChar == 's' || e.KeyChar == 'S')
            {
                Save();
            }
            else if(e.KeyChar == 'o' || e.KeyChar == 'O')
            {
                Open();
            }
        }
    }
}
