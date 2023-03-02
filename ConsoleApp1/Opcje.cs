using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Opcje
    {
       
        public void wybierzPobierzKursy()
        {
            ECuntor kantor = new ECuntor();
            Console.Clear();
            kantor.pobierzKursy();
        }
        public void wybierzWalute()
        {
            try
            {
                Console.WriteLine("================");
                Console.WriteLine(" ONLINE KANTOR");
                Console.WriteLine("================");
                Console.WriteLine("\nDostępne waluty do wymiany:");
                Console.WriteLine("1. EURO");
                Console.WriteLine("2. FUNT BRYTYJSKI");
                Console.WriteLine("3. DOLAR AMERYKANSKI");
                Console.WriteLine("4. RUPIA INDYJSKA");
                Console.WriteLine("5. DOLAR KANADYJSKI");
                Console.WriteLine("6. DOLAR AUSTRALIJSKI");
                Console.WriteLine("7. FRANK SZWAJCARSKI");
                Console.WriteLine("8. PESO");
                Console.WriteLine("9. PLN");
                Console.WriteLine("\nWpisz numer Waluty z której chcesz przeliczać: ");
                int waluta1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj kwotę jaką chcesz przeliczyć:  ");
                int kwota = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Wpisz numer Waluty na którą chcesz przeliczać: ");
                int waluta2 = Convert.ToInt32(Console.ReadLine());
                ECuntor kantor = new ECuntor();
                Console.Clear();
                kantor.przeliczWalute(waluta1, waluta2,kwota);
            }
            catch(Exception wyjatek)
            {
                Console.Clear();
                wybierzWalute();
            }
        }
    }
}
