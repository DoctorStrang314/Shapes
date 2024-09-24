using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace shapes
{
    internal interface ICalcStrateges
    {
       string Calc();
    }
    internal interface IInitStrateges
    {
       void InitParm();
    }
 
    internal interface IShape : IInitStrateges, ICalcStrateges {    }

    public class Shape : IShape
    {
        public double area;
        public string calcResult;
        public string nameShape;
        public Shape strategy;
        public Dictionary<string, Type> choice = new Dictionary<string, Type> { };
        Menu menu = new Menu();
        public virtual void InitParm()
        {
            strategy = menu.ShowChoice(choice);
            strategy.InitParm();
        }
        public virtual string Calc()
        {
            return strategy.Calc();
        }
    }
    public class CirleStrateges : Shape
    {
        protected const double PI = Math.PI;
        
    }
    public class TriangleStrateges : Shape
    {
        protected double[] array;
        public TriangleStrateges(int count)
        {
            array = new double[count];
        }
        
    }

    public class СircleRadius : CirleStrateges
    {
        public static string name = "Расчет площади по радиусу круга";
        double radius;
        public override void InitParm()
        {
            Console.WriteLine("Введите радиус круга");
            radius = Convert.ToDouble(Console.ReadLine());
        }
        public override string Calc()
        {
            area = PI * Math.Pow(radius,2);
            return Convert.ToString(area);
        }

    }
    public class СircleDiameter : CirleStrateges
    {
        public static string name = "Расчет площади по диаметру круга";
        double diameter;
        public override void InitParm()
        {
            Console.WriteLine("Введите диаметр круга");
            diameter = Convert.ToDouble(Console.ReadLine());
        }
        public override string Calc()
        {
            area = (PI * Math.Pow(diameter, 2))/4;
            return Convert.ToString(area);
        }

    }
    public class LenghtСircle : CirleStrateges
    {
        public static string name = "Расчет площади по длинне окружности";
        double Lenght;
        public override void InitParm()
        {
            Console.WriteLine("Введите длинну окружности");
            Lenght = Convert.ToDouble(Console.ReadLine());
        }
        public override string Calc()
        {
            area = Math.Pow(Lenght, 2) / (4 * PI);
            return Convert.ToString(area);
        }

    }

    public class Triangle_Geron : TriangleStrateges
    {
        public static string name = "Расчет площади по трём сторонам треугольника";
        double halfPerimeter;

        public Triangle_Geron() : base(3) { }

        public override void InitParm()
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Введите сторону " + (i+1));
                array[i] = Convert.ToDouble(Console.ReadLine());
            }
        }
        public override string Calc()
        {
            halfPerimeter = (array[0]+array[1]+array[2])/2;
            area = Math.Sqrt(halfPerimeter *(halfPerimeter-array[0])*(halfPerimeter-array[1])*(halfPerimeter- array[2]));
            return Convert.ToString(area);
        }

    }
    public class Triangle_HeightSide : TriangleStrateges
    {
        public static string name = "Расчет площади по стороне и высоте треугольника";
        public Triangle_HeightSide() : base(2) { }

        public override void InitParm()
        {
        
            Console.WriteLine("Введите сторону " );
            array[0] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите высоту ");
            array[1] = Convert.ToDouble(Console.ReadLine());

        }
        public override string Calc()
        {
            area = (array[0] * array[1]) / 2;
            return Convert.ToString(area);
        }

    }
    public class Triangle_SidesRectangle : TriangleStrateges
    {
        public static string name = "Расчет площади по двум сторонам и углу между ними";
        public Triangle_SidesRectangle() : base(2) { }
        double sinus; 
        public override void InitParm()
        {
            for (int i = 0; i <= 1; i++)
            {
                Console.WriteLine("Введите сторону "+(i+1));
                array[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Введите угол");
            sinus = Convert.ToDouble(Console.ReadLine());

        }
        public override string Calc()
        {
            area =  Math.Sin(Math.PI * sinus / 180) * ((array[0] * array[1]) / 2);
            return Convert.ToString(area);
        }

    }
    public class Triangle_AngleCheck : TriangleStrateges
    {
        public static string name = "Проверка наличия прямого угла по двум углам";
        public Triangle_AngleCheck() : base(2) { }
        public override void InitParm()
        {
            for (int i = 0; i <= 1; i++)
            {
                Console.WriteLine("Введите угол " + (i + 1));
                array[i] = Convert.ToDouble(Console.ReadLine());
            }

        }
        public override string Calc()
        { 
            if ((180 - (array[0] + array[1]) == 90) || array[0] == 90 || array[1] == 90)
            {
                return "Тругольник является прямоугольным";
            }
            else return "Этот треугольник не прямоугольный";
        }

    }
}
