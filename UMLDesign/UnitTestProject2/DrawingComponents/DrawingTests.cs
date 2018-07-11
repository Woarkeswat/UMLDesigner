using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.DrawingComponents.Tests
{
    [TestClass()]
    public class DrawingTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Drawing drawing = new Drawing();
            Element element = new LabeledBox();

            drawing.Add(element);

            //Assert.IsFalse();
        }
    }
}