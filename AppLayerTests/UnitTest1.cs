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
        public void AddTest()
        {
            
            _testInvoker.Start();
            
            Point Location1 = new Point(100, 102);
            Point Location2 = new Point(100, 110);
            AddCommand command = new AddCommand("Class", Location1, Location1, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command);

            AddCommand command2 = new AddCommand("Binary", Location1, Location2, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command2);

            System.Threading.Thread.Sleep(1000);

            Assert.AreEqual(2, testDrawing._ClassSymbols.Count + testDrawing._RelationShipLines.Count);
        }

        [TestMethod]
        public void RemoveTest()
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
        public void MoveClassTest()
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
            Console.WriteLine(testDrawing._ClassSymbols[0].type);
            Assert.AreEqual(newLocation, testDrawing._ClassSymbols[0].Location);
        }

        [TestMethod]
        public void MoveLineTest()
        {

        }
    }
}
