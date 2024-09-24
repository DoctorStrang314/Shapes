using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    internal class Program
    {
       
        static void Main(string[] args)
        { 
            
            Dictionary<string,Type> choice = new Dictionary<string, Type> { };
            choice.Add("1", typeof(Triangle));
            choice.Add("2", typeof(Сircle));
            Menu menu = new Menu();
            Shape shape;
            while (true) {
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Выберите фигуру");

                shape = menu.ShowChoice(choice);
                Console.WriteLine("Ответ для фигуры "+ shape.nameShape +": "+ shape.calcResult);
            }
            
        }

    }
}
