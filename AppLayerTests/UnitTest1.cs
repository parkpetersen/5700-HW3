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
        

        [TestMethod]
        public void AddTest()
        {
            Drawing testDrawing = new Drawing();
            Invoker _testInvoker = new Invoker();
            _testInvoker.Start();
            Point Location = new Point(10, 10);
            AddCommand command = new AddCommand("Class", Location, Location, testDrawing);
            _testInvoker.EnqueueCommandForExecution(command);
            Assert.IsFalse(testDrawing._ClassSymbols.Count == 0);
        }
    }
}
