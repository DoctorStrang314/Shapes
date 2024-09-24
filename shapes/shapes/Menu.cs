using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    internal class Menu
    {
        
        Dictionary<string, Type> localChoice;
        public Shape ShowChoice(Dictionary<string, Type> choice) {// за счет метта данных отображаем все объект с интерфесом Shape

            localChoice = choice;
            for (int i = 0; i < choice.Count; i++)
            {
                FieldInfo name = choice[Convert.ToString(i + 1)].GetField("name");
                if (name != null) {
                    object value = name.GetValue(null);
                    Console.WriteLine((i + 1) + ")" + value);
                }
            }

            return (Activator.CreateInstance(choice[UserInput()]) as Shape); 
        }
        private string UserInput() {

            bool correct = false;
            string VariantChoice="";
            while (!correct)
            {
                VariantChoice = Console.ReadLine();
                if (int.TryParse(VariantChoice, out int number))
                {
                    if (number > 0 && number <= localChoice.Count)
                    {
                        correct = true;
                    }
                    else Console.WriteLine("такого варианта нету в списке введите другой");

                }
                else Console.WriteLine("не корректно, введите число!");

            }
            return VariantChoice;
        }
    }
}
