using NFluent;
using NUnit.Framework;

namespace VisitorPattern
{

    /// <summary>
    /// Ref:
    ///     https://refactoring.guru/design-patterns/visitor-double-dispatch
    ///     https://en.wikipedia.org/wiki/Double_dispatch
    /// </summary>
    [TestFixture]
    public class ShapesShould
    {
        [Test]
        public void Double_dispatch_failure()
        {
            var exporter = new Exporter();
            Shape circle = new Circle();
            var result =  exporter.Export(circle);

            Check.That(result).IsEqualTo("Export circle");
        }

        [Test]
        public void Static_typing_OK()
        {
            var exporter = new Exporter();
            var circle = new Circle();
            var result = exporter.Export(circle);

            Check.That(result).IsEqualTo("Export circle");
        }

        [Test]
        public void Visitor_pattern_OK()
        {
            Shape circle = new Circle();
            var result = circle.Accept(new Exporter());

            Check.That(result).IsEqualTo("Export circle");
        }
    }

    class Shape
    {
        public virtual string Accept(Exporter exporter)
        {
            return exporter.Export(this);
        }
    }

    internal class Circle : Shape
    {
        public override string Accept(Exporter exporter)
        {
            return exporter.Export(this);
        }
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