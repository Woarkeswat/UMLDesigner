using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.DrawingComponents;
using System.Drawing;
using AppLayer.Command;

namespace AppLayer.DrawingComponents.Tests
{
    [TestClass()]
    public class LineTests
    {
        [TestMethod()]
        public void ContainsPointTest()
        {
            Point point = new Point(40, 40);
            Point point1 = new Point(80, 80);
            Drawing TargetDrawing = new Drawing();

            Line line = new Line() { Start = (Point)point, End = (Point)point1 };
            TargetDrawing.Add(line);

            Assert.AreEqual(40, line.Start.X);
            Assert.AreEqual(40, line.Start.Y);
            Assert.AreEqual(80, line.End.X);
            Assert.AreEqual(80, line.End.Y);
        }
    }
}