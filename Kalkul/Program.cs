using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Kalkul
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать!");
            Menu();

        }

        static public void Menu()
        {
            Console.WriteLine("Введите команду: 1 - Калькулятор калорий; 2 - Расчитать ваш рацион; 3 - Ваша дневная активность; 4 - Средне статитическое потребление\n");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Kakul();
                    break;
                case 2:
                    Rachet();
                    break;
                case 3:
                    Day_activ();
                    break;
                case 4:
                    sred_stat();
                    break;
            }
        }
       static public void Kakul()
       {
            int sum = 0;
            Console.WriteLine("Калькулятор калорий!\n");

            Console.WriteLine("Количество калорий в продуктах:\n");

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\data\Рацион.txt";
            string file_name = File.ReadAllText(path);
            Console.WriteLine(file_name);

                Console.WriteLine("Введите количество калорий первого продукта:");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество калорий второго продукта:");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("1 - добавить продукт; 2 - результат:\n");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Введите количество калорий третьего продукта:");
                        int c = Convert.ToInt32(Console.ReadLine());
                        sum = a + b + c;
                        Console.WriteLine($"Сумма калорий: {sum}");
                        break;
                    case 2:
                        sum = a + b;
                        Console.WriteLine($"Сумма калорий: {sum}");
                        break;
                }
                Console.WriteLine("Выберите команду: 0 - начать с начала; 1 - вернутся в меню");
                int flag = Convert.ToInt32(Console.ReadLine());
            if (flag == 0)
            {
                Kakul();
            }
            else
            {
                Menu();
            }
            Console.ReadKey();
            return;
            
       }
        static public void Rachet()
        {
            double sum;
            Console.WriteLine("Посчитаем ваш рацион!\n");
            Console.WriteLine("Введите возраст:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пол: 1 - мужской; 2 - женский");
            int pol = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите рост:");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вес:");
            int weight = Convert.ToInt32(Console.ReadLine());
            if (pol == 1)
            {
                sum = 66.5 + (13.75 * weight) + (5.003 * height) - (6.775 * age);
                Console.WriteLine($"Суточная норма мужчины: {sum} ккал");
            }
            else
            {
                sum = 665.1 + (9.563 * weight) + (1.87 * height) - (4.676 * age);
                Console.WriteLine($"Суточная норма женщины: {sum} ккал");
            }
            Console.WriteLine("Выберите команду: 0 - начать с начала; 1 - вернутся в меню");
            int flag = Convert.ToInt32(Console.ReadLine());
            if (flag == 0)
            {
                Rachet();
            }
            else
            {
                Menu();
            }
            Console.ReadKey();
        }
        static public void Day_activ()
        {
            double sum1, sum2, sum3;
            Console.WriteLine("Посчитаем вашу норму активности!\n");
            Console.WriteLine("Введите возраст:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пол: 1 - мужской; 2 - женский");
            int pol = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите рост:");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вес:");
            int weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вашу степень активности: 1 - минимальная; 2 - низкая; 3 - умеренная; 4 - высокая; 5 - экстримальная");
            int active = Convert.ToInt32(Console.ReadLine());
            if (pol == 1)
            {
                sum1 = 66.5 + (13.75 * weight) + (5.003 * height) - (6.775 * age);
                switch(active)
                {
                    case 1:
                        sum1 = sum1 * 1.2;
                        break;
                    case 2:
                        sum1 = sum1 * 1.375;
                        break;
                    case 3:
                        sum1 = sum1 * 1.55;
                        break;
                    case 4:
                        sum1 = sum1 * 1.7;
                        break;
                    case 5:
                        sum1 = sum1 * 1.9;
                        break;
                }
                sum2 = sum1 - (sum1 * 0.2);
                sum3 = sum1 - (sum1 * 0.4);
                var a = new StreamWriter(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\data\Дневная_активность.txt");
                a.WriteLine("Сумма калорий в день, чтобы вес не менялся:");
                a.WriteLine(sum1);
                a.WriteLine("Сумма калорий в день, чтобы похудеть:");
                a.WriteLine(sum2);
                a.WriteLine("Сумма калорий в день, чтобы быстро похудеть:");
                a.WriteLine(sum3);
                a.Close();  
            }
            else
            {
                sum1 = 665.1 + (9.563 * weight) + (1.87 * height) - (4.676 * age);
                switch (active)
                {
                    case 1:
                        sum1 = sum1 * 1.2;
                        break;
                    case 2:
                        sum1 = sum1 * 1.375;
                        break;
                    case 3:
                        sum1 = sum1 * 1.55;
                        break;
                    case 4:
                        sum1 = sum1 * 1.7;
                        break;
                    case 5:
                        sum1 = sum1 * 1.9;
                        break;
                }
                sum2 = sum1 - (sum1 * 0.2);
                sum3 = sum1 - (sum1 * 0.4);
                var a = new StreamWriter(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\data\Дневная_активность.txt");
                a.WriteLine("Сумма калорий в день, чтобы вес не менялся:");
                a.WriteLine(sum1);
                a.WriteLine("Сумма калорий в день, чтобы похудеть:");
                a.WriteLine(sum2);
                a.WriteLine("Сумма калорий в день, чтобы быстро похудеть:");
                a.WriteLine(sum3);
                a.Close();
            }
            Console.WriteLine("Выберите команду: 0 - начать с начала; 1 - вернутся в меню");
            int flag = Convert.ToInt32(Console.ReadLine());
            if (flag == 0)
            {
                Day_activ();
            }
            else
            {
                Menu();
            }
            Console.ReadKey();
        }
        static public void sred_stat()
        {
            double sum;
            Console.WriteLine("Посчитаем сколько калорий вы в среднем употребляете!\n");
            Console.WriteLine("Введите сумму калорий за понедельник:");
            int pon = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сумму калорий за вторник:");
            int vto = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сумму калорий за среду:");
            int sre = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сумму калорий за четверг:");
            int che = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сумму калорий за пятницу:");
            int pya = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сумму калорий за субботу:");
            int sub = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сумму калорий за воскресенье:");
            int vos = Convert.ToInt32(Console.ReadLine());
            sum = (pon + vto + sre + che + pya + sub + vos) / 7;
            Console.WriteLine($"Вы в среднем употребляете: {sum} ккал");
            Console.WriteLine("Выберите команду: 0 - начать с начала; 1 - вернутся в меню");
            int flag = Convert.ToInt32(Console.ReadLine());
            if (flag == 0)
            {
                sred_stat();
            }
            else
            {
                Menu();
            }
        }

    }
}
