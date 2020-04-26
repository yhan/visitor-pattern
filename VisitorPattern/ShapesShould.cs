using System;
using NFluent;
using NUnit.Framework;

namespace VisitorPattern
{
    [TestFixture]
    public class ShapesShould
    {
        [Test]
        public void Test1()
        {
            var exporter = new Exporter();
            Shape circle = new Circle();
            var result =  exporter.Export(circle);

            Check.That(result).IsEqualTo("Export circle");
        }

        [Test]
        public void Test2()
        {
            var exporter = new Exporter();
            var circle = new Circle();
            var result = exporter.Export(circle);

            Check.That(result).IsEqualTo("Export circle");
        }
    }

    class Shape
    {
    }

    internal class Circle : Shape
    {
    }

    class Exporter
    {
        public string Export(Shape shape)
        {
            return "Export shape";
        }

        public string Export(Circle circle)
        {
            return "Export circle";
        }
    }
}