using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Biblioteka
{
    public class ECuntor
    {
        private FirefoxDriver driver = new FirefoxDriver();

        private string[] sciezkiWalut = new string[] {
            //EURO,FUNT,DOLAR AMERYKANSKI,RUPIA INDYJSKA,DOLAR KANADYJSKI,DOLAR AUSTRALIJSKI,FRANK SZWAJCARSKI,PESO MEKSYKANSKIE,POLSKI ZŁOTY
            "EUR","GBP","USD","INR","CAD","AUD","CHF","MXN","PLN"
        };
        public string pobierzKursy()
        {
            driver.Navigate().GoToUrl("https://nbp.pl/statystyka-i-sprawozdawczosc/kursy/tabela-a/");
            string zapis = "Kurs przeliczany na złotówki\n\n";
            Thread.Sleep(2000);
            for(int i =1; i<26;i++)
            {
                zapis += driver.FindElement(By.XPath($"//*[@id=\"main-content\"]/div/section/div/figure/table/tbody/tr[{i}]/td[1]")).Text + " Kurs: " + driver.FindElement(By.XPath($"//*[@id=\"main-content\"]/div/section/div/figure/table/tbody/tr[{i}]/td[3]")).Text + "\n";
            }
            try
            {
                //Zapis do pliku
                File.WriteAllText(@"../../../kursy.txt", zapis);
                Console.WriteLine(zapis);
                Console.WriteLine("Plik Kursy.txt został utworzony, otwórz go i sprawdź kursy walut.");
                return zapis;
            }
            catch(Exception e)
            {
                Console.WriteLine("Bład: Nie udało się zapisać pliku kurs.txt");
            }
            return "";
        }
        public double przeliczWalute(int walutaPierwsza,int walutaDruga, int kwota)
        {
            
            driver.Navigate().GoToUrl("https://wise.com/pl/currency-converter/");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("source-input")).Clear();
            driver.FindElement(By.Id("source-input")).SendKeys(kwota.ToString());
            Thread.Sleep(1000);
            driver.FindElement(By.Id("source-input-select")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("source-input-select-searchbox")).SendKeys(sciezkiWalut[(walutaPierwsza - 1)]);
            Thread.Sleep(500);
            driver.FindElement(By.Id("source-input-select-searchbox")).SendKeys(Keys.Enter);
            Thread.Sleep(1500);
            driver.FindElement(By.Id("target-input-select")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("target-input-select-searchbox")).SendKeys(sciezkiWalut[(walutaDruga - 1)]);
            Thread.Sleep(1500);
            driver.FindElement(By.Id("target-input-select-searchbox")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            Console.WriteLine("[EKantor]: " + kwota + " " + sciezkiWalut[walutaPierwsza-1] + "  na  " + sciezkiWalut[walutaDruga-1] + "  wynosi:  " + driver.FindElement(By.Id("target-input")).GetAttribute("value"));
            double przeliczonaKwota = Double.Parse(driver.FindElement(By.Id("target-input")).GetAttribute("value"));
            return przeliczonaKwota;
        }
    }
}