using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = "C:\\Users\\15975\\Desktop\\logs";
            vot(dir);
        }
        public static void vot(string file_name)
        {
            string S;
            ConsoleKeyInfo q;
            do
            {
                Console.WriteLine("\nВведите имя прибора, для которого хотите получить информацию: начиная с show ");
                string ustroistvo = Console.ReadLine();
                if (ustroistvo.StartsWith("show "))
                {
                    int x = 1;
                    string Show = ustroistvo.Substring(5);
                    int g1, g2;
                    int start, end;

                    string[] files = Directory.GetFiles(file_name);
                    for (int i = 0; i < files.Length; i++)
                    {
                        start = files[i].IndexOf("(");
                        end = files[i].IndexOf(")");
                        string data = files[i].Substring(start + 1, end - start - 1);
                        string[] stroki = File.ReadAllLines(files[i]);
                        for (int j = 0; j < stroki.Length; j++)
                        {
                            S = stroki[j];
                            g1 = S.IndexOf(":");
                            g2 = S.IndexOf(":", g1 + 1);

                            if (g1 > 0 && g2 > 0)
                            {
                                string Q1 = S.Substring(g1 + 1, g2 - g1 - 1);
                                string znachenie = S.Substring(g2 + 1);
                                if (Q1 == Show && !(Q1.Contains("garbage")))
                                {
                                    Console.WriteLine(data + " - " + znachenie);
                                    x = 0;
                                }
                            }
                        }
                       

                    }
                    if (x != 0)
                    {
                        Console.WriteLine("Девайс не найден");
                    }
                }
                else
                {
                    Console.WriteLine("Команда не распознана");
                }
                Console.WriteLine("Для выхода нажмите 'ESC', чтобы продолжить нажмите любую клавишу ");
                q = Console.ReadKey();

            }
            while ((q.Key != ConsoleKey.Escape));
        }
    }
}
