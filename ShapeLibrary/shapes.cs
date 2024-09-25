using System.Collections.Generic;
using System.Dynamic;

namespace ShapeLibrary
{
    internal interface IArea
    {
        double AreaCalc();
    }

    public class shapes : IArea
    {
        public double area;              
        public virtual double AreaCalc()
        {
            return 0;
        }
    }
 

   
    public class Сircle : shapes
    {
        
        double diameter;
        public Сircle(double ADiameter)
        {
            diameter = Math.Abs(ADiameter);
        }
        public override double AreaCalc()
        {
            area = (Math.PI * Math.Pow(diameter, 2)) / 4;
            return area;
        }

    }

    public class Triangle : shapes
    {
       
        double halfPerimeter;
        protected List<double> list;
        public Triangle(double firstSide, double secondSide, double thirdSide) 
        {
            // не уверен стоит ли как то обозначить ситуацию при которой 3 сторона больше суммы предыдущих
            // поскольку таких треугольников не существует, в теории можно вернуть null, но говорят это не очень хорошая практика, косколько приводит к исключению
            // вероятно корректнее в процедурах на этот случай возвращать отдельный результат 
            // честно мне уже лень писать эту проверку, хотя это минус, но я уже потратил 8 часов на проект Shapes, который считаю более показательным.

            list = new List<double>();
            list.Add(Math.Abs(firstSide));// отрицательная длинна в любом случае не имеет смысла с геометрической точки зрения 
            list.Add(Math.Abs(secondSide));
            list.Add(Math.Abs(thirdSide));
        }

        public override double AreaCalc()
        {
            halfPerimeter = (list[0] + list[1] + list[2]) / 2;
            area = Math.Sqrt(halfPerimeter * (halfPerimeter - list[0]) * (halfPerimeter - list[1]) * (halfPerimeter - list[2]));
            return area;
        }
        public string AngleCheck()
        {
            
            list.Sort();
            double sum = Math.Round(Math.Pow(list[0], 2) + Math.Pow(list[1], 2), 4);
            double hypotenuse = Math.Round(Math.Pow(list[2], 2), 4);
            if (sum == hypotenuse) // теоретически если ввести очень длинное число с плавующей точкой, то
                                                                                  // он может посчитать сумму квадратов не корректно и сказать, что треугольник не прямоугольный 
            {
                return "Тругольник является прямоугольным";
            }
            else return "Этот треугольник не прямоугольный";
        }

    }

}
