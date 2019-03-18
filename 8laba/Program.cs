using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _8laba
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFromFile = string.Empty;
            #region Считывание контейнера с файла
            using (FileStream fstream = File.OpenRead(@"input.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.UTF8.GetString(array);

            }
            #endregion

            #region Удаляем с пробелы в конце и в начале строки
            var s = textFromFile.Split('.');
            string out_text = string.Empty;

            var res = s;

            int i = 0;
            foreach (var item in s)
            {
                res[i] = item.TrimEnd(' ');
                res[i] = res[i].TrimStart(' ');
                i++;
            }
            #endregion

            string text = "Hello";

            string bintext = new Service().TextToBin(text);
            string test = "10101010101110101101";

            int k = test.Length < res.Length ? test.Length : res.Length;

            for (int t = 0; t < res.Length; t++)
            {
                res[t] += ".";
            }

            for (int j = 0; j <k; j++)
            {
                if (string.Equals(test[j],'0'))
                {
                    res[j] += "  ";}
                else
                {
                    res[j] += " ";
                }
            }

            out_text = string.Join("",res);

            using (FileStream fstream = new FileStream(@"output.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.UTF8.GetBytes(out_text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }


            using (FileStream fstream = File.OpenRead(@"output.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.UTF8.GetString(array);

            }


            var intext = textFromFile.Split('.');

            string outtex = string.Empty;

            foreach (var item in intext)
            {
                for (int t = 0; t < item.Length; t++)
                {
                    if (string.Equals(item[0],' ') && string.Equals(item[1],' '))
                    {
                        outtex += "0";break;
                    }
                    else
                        if (string.Equals(item[0],' '))
                    {
                        outtex += "1";break;
                    }
                }
            }





            Console.WriteLine(out_text);


            Console.WriteLine(outtex);
            Console.WriteLine(test);
            Console.ReadKey();
        }
    }
}
