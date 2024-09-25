using ShapeLibrary;
namespace ShapeModalTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestTrianleArea()
        {
            double area, expected=6;
            Triangle triangle = new Triangle(5,4,3);
            area = triangle.AreaCalc();

            Assert.AreEqual(expected, area, "Account not debited correctly");
        }
        [TestMethod]
        public void Test_Int_Right_TrianleAngle()
        {
            string message, expected = "Тругольник является прямоугольным";
            Triangle triangle = new Triangle(2,3, Math.Sqrt(13));
            message = triangle.AngleCheck();

            Assert.AreEqual(expected, message, "Account not debited correctly");

        }

        [TestMethod]
        public void TestLieTrianleAngle()
        {
            string message, expected = "Этот треугольник не прямоугольный";
            Triangle triangle = new Triangle(2, 2, Math.Sqrt(3));
            message = triangle.AngleCheck();

            Assert.AreEqual(expected, message, "Account not debited correctly");

        }
        [TestMethod]
        public void TestСircleArea()
        {
            double area, expected = Math.PI;
            Сircle circle = new Сircle(2);
            area = circle.AreaCalc();

            Assert.AreEqual(expected, area, "Account not debited correctly");
        }
    }
}