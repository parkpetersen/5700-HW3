using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.Commands;
using AppLayer.DrawingComponents;
using System.Drawing;

namespace AppLayerTests
{
    [TestClass]
    public class UnitTest1
    {
        Drawing testDrawing = new Drawing();
        Invoker _testInvoker = new Invoker();

        [TestMethod]
        public void AddTest() //tests adding 2 classes and a line connecting them
        {
            
            _testInvoker.Start();
            
            Point Location1 = new Point(100, 102);
            Point Location2 = new Point(100, 110);
            AddCommand command = new AddCommand("Class", Location1, Location1, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command);
            AddCommand command2 = new AddCommand("Class", Location2, Location2, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command2);

            AddCommand command3 = new AddCommand("Binary", Location1, Location2, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command3);

            System.Threading.Thread.Sleep(1000);

            Assert.AreEqual(3, testDrawing._ClassSymbols.Count + testDrawing._RelationShipLines.Count);
        }

        [TestMethod]
        public void RemoveTest() //tests the remove command
        {
            _testInvoker.Start();
            Point Location1 = new Point(100, 102);
            AddCommand command1 = new AddCommand("Class", Location1, Location1, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command1);
            Symbol symbol = testDrawing.FindSymbolAtPosition(Location1);
            DeleteCommand command2 = new DeleteCommand(symbol, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command2);

            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual(0, testDrawing._ClassSymbols.Count);
        }

        [TestMethod]
        public void MoveClassTest() //tests moving a class
        {
            _testInvoker.Start();
            Point Location1 = new Point(100, 102);
            AddCommand command1 = new AddCommand("Class", Location1, Location1, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command1);
            System.Threading.Thread.Sleep(1000);

            Symbol symbol = testDrawing.FindSymbolAtPosition(Location1);
            Point newLocation = new Point(0, 0);
            ClassSymbol classSymbol = symbol as ClassSymbol;
            MoveClassCommand cmd = new MoveClassCommand(classSymbol, newLocation, testDrawing);
            _testInvoker.EnqueueCommandForExecution(cmd);
            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual(newLocation, testDrawing._ClassSymbols[0].Location);
        }

        [TestMethod]
        public void MoveLineTest() //tests moving a line to a new location after it's connected class is moved
        {
            _testInvoker.Start();
            Point Location1 = new Point(100, 102);
            Point Location2 = new Point(100, 110);

            AddCommand command3 = new AddCommand("Binary", Location1, Location2, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command3);
            System.Threading.Thread.Sleep(1000);

            Point newLocation = new Point(0, 0);

            if (testDrawing._RelationShipLines[0].Location1 == Location1 || testDrawing._RelationShipLines[0].Location2 == Location1)
            {
                MoveLineCommand moveCommand = new MoveLineCommand(testDrawing._RelationShipLines[0], Location1, newLocation, testDrawing);
                _testInvoker.EnqueueCommandForExecution(moveCommand);
            }

            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual(newLocation, testDrawing._RelationShipLines[0].Location1);
        }

        [TestMethod]
        public void EditClassTest()
        {
            _testInvoker.Start();
            Point Location1 = new Point(100, 102);
            AddCommand command1 = new AddCommand("Class", Location1, Location1, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command1);
            System.Threading.Thread.Sleep(1000);

            //change the color, size and name
            Color newColor = Color.Azure;
            string newName = "New Name";
            Size newSize = new Size(90, 90);

            EditClassCommand cmd = new EditClassCommand(testDrawing._ClassSymbols[0], newName, newSize, newColor, testDrawing);
            _testInvoker.EnqueueCommandForExecution(cmd);
            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual(newColor, testDrawing._ClassSymbols[0].ClassColor);
            Assert.AreEqual(newName, testDrawing._ClassSymbols[0].label);
            Assert.AreEqual(newSize, testDrawing._ClassSymbols[0].Size);

        }

        [TestMethod]
        public void EditDiagramTest()
        {
            _testInvoker.Start();
            Color newBackgroundColor = Color.Aqua;
            Color newForegroundColor = Color.Beige;
            string newDrawingName = "New Name";
            Color newDefaultClassColor = Color.Purple;

            EditDiagramCommand cmd = new EditDiagramCommand(newDrawingName, newBackgroundColor, newForegroundColor, newDefaultClassColor, testDrawing);
            _testInvoker.EnqueueCommandForExecution(cmd);
            System.Threading.Thread.Sleep(1000);

            Assert.AreEqual(newDrawingName, testDrawing.DrawingName);
            Assert.AreEqual(newBackgroundColor, testDrawing.BackGroundColor);
            Assert.AreEqual(newForegroundColor, testDrawing.ForeGroundColor);
            Assert.AreEqual(newDefaultClassColor, testDrawing.DefaultClassColor);
            
        }

        [TestMethod]
        public void NewDiagramTest() //tests the creation of a new drawing.
        {
            _testInvoker.Start();
            Color newBackgroundColor = Color.Aqua;
            Color newForegroundColor = Color.Beige;
            string newDrawingName = "New Name";
            Color newDefaultClassColor = Color.Purple;

            EditDiagramCommand cmd = new EditDiagramCommand(newDrawingName, newBackgroundColor, newForegroundColor, newDefaultClassColor, testDrawing);
            _testInvoker.EnqueueCommandForExecution(cmd);
            System.Threading.Thread.Sleep(1000);

            NewDrawingCommand newCommand = new NewDrawingCommand(testDrawing);
            _testInvoker.EnqueueCommandForExecution(newCommand);
            System.Threading.Thread.Sleep(1000);


            Assert.AreEqual("New Drawing", testDrawing.DrawingName);
            Assert.AreEqual(Color.White, testDrawing.BackGroundColor);
            Assert.AreEqual(Color.Black, testDrawing.ForeGroundColor);
            Assert.AreEqual(Color.LightBlue, testDrawing.DefaultClassColor);
        }

        [TestMethod]
        public void UndoTest() //test undo by issuing a command, undoing it then testing results.
        {
            _testInvoker.Start();
            Point Location1 = new Point(100, 102);
            AddCommand command1 = new AddCommand("Class", Location1, Location1, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command1);
            System.Threading.Thread.Sleep(1000);

            //change the color, size and name
            Color newColor = Color.Azure;
            string newName = "New Name";
            Size newSize = new Size(90, 90);

            EditClassCommand cmd = new EditClassCommand(testDrawing._ClassSymbols[0], newName, newSize, newColor, testDrawing);
            _testInvoker.EnqueueCommandForExecution(cmd);
            System.Threading.Thread.Sleep(1000);

            UndoCommand undo = new UndoCommand();
            _testInvoker.EnqueueCommandForExecution(undo);
            System.Threading.Thread.Sleep(1000);

            Assert.AreEqual("Class", testDrawing._ClassSymbols[0].label);
            Assert.AreEqual(new Size(80, 80), testDrawing._ClassSymbols[0].Size);
            Assert.AreEqual(Color.LightBlue, testDrawing._ClassSymbols[0].ClassColor);

        }
    }
}
