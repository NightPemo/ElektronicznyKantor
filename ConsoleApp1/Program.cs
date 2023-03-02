using Biblioteka;
using ConsoleApp1;
Console.Title = "EKANTOR";
Console.Clear();
Console.WriteLine("");
Opcje opcje = new Opcje();
Console.WriteLine("================");
Console.WriteLine(" ONLINE KANTOR");
Console.WriteLine("================");
Console.WriteLine("Wybierz Opcje:");
Console.WriteLine("1. Pobierz kursy");
Console.WriteLine("2. Przelicz waluty");
podajOpcje();

void podajOpcje()
{
    try
    {
        int opcja = Convert.ToInt32(Console.ReadLine());
        if (opcja == 1)
        {
            Console.Clear();
            opcje.wybierzPobierzKursy();
        }
        else
        {
            Console.Clear();
            opcje.wybierzWalute();
        }
    }
    catch (Exception wyjatek)
    {
        Console.Clear();
        Console.WriteLine("================");
        Console.WriteLine(" ONLINE KANTOR");
        Console.WriteLine("================");
        Console.WriteLine("Wybierz Opcje:");
        Console.WriteLine("1. Pobierz kursy");
        Console.WriteLine("2. Przelicz waluty");
        podajOpcje();
    }
}

