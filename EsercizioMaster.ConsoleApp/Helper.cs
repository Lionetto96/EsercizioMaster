using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.ConsoleApp
{
    public class Helper
    {
        public static string CheckStringa(string messaggio)
        {
            string info;
            do
            {
                Console.WriteLine($"inserisci {messaggio}");
                info = Console.ReadLine();
                
            } while (string.IsNullOrWhiteSpace(info));
            return info;
        }

        public static int CheckIntero(string messaggio)
        {
            int intero;
            do
            {
                Console.WriteLine($"inserisci {messaggio}");
                

            } while (!(int.TryParse(Console.ReadLine(),out intero)));
            return intero;
        }
        public static DateTime CheckData(string messaggio)
        {
            DateTime data;
            do
            {
                Console.WriteLine($"inserisci {messaggio}");
            }while(!(DateTime.TryParse(Console.ReadLine(), out data)));
            return data;
        }
    }
}
