using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    internal class ConcreteShape: Shape
    {
        // на уровне обстракции хочется разделить конкретные фигуры и способы их расчета, хотя интерфейс у них долже быть 1 и тот же,
        // но я считаю это более корректно, поскольку неизвестно какие могут добавиться еще поля для конкретных фигур. 
    }
    class Triangle : ConcreteShape
    {
        public static string name = "треугольник";
        public Triangle()
        {       
            InitParm();
            nameShape = name;
            calcResult = Calc();
        }
        public override void InitParm()
        {
            Console.Clear();
            Console.WriteLine("Выберите опцию");
            choice.Add("1", typeof(Triangle_Geron));// добавляем сколько угодно рассчетов по необходимости 
            choice.Add("2", typeof(Triangle_SidesRectangle));
            choice.Add("3", typeof(Triangle_HeightSide));
            choice.Add("4", typeof(Triangle_AngleCheck));

            base.InitParm();

        }

    }
    class Сircle : ConcreteShape
    {
        
        public static string name =  "круг";
       
        public Сircle()
        {
            InitParm();
            nameShape = name;
            calcResult = Calc();
        }
        public override void InitParm()
        {
            Console.Clear();
            Console.WriteLine("Выберите опцию");
            choice.Add("1", typeof(СircleRadius));
            choice.Add("2", typeof(СircleDiameter));
            choice.Add("3", typeof(LenghtСircle));

            base.InitParm();
  
        }
    }

}
