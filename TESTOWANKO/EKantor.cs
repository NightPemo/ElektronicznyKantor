using Xunit;
using OpenQA.Selenium;
using NuGet.Frameworks;

namespace Biblioteka.Tests
{
    public class EKantor
    {
        //Sprawdzenie czy pobralo dane o kursach  ze strony
        [Fact]
        public void PobierzKursyTest()
        {           
            ECuntor ecuntor = new ECuntor();
            Thread.Sleep(1000);
            bool czyDziala = false;
            if(ecuntor.pobierzKursy().Length>50)
            {
                czyDziala = true;
            }
            Assert.True(czyDziala);
        }
  
        [Fact]
        public void PrzeliczWaluteTest()
        {
            ECuntor ecuntor = new ECuntor();
            Thread.Sleep(1000);
            Assert.Equal(21,Math.Floor(ecuntor.przeliczWalute(9, 1, 100)));
        }
    }
}


//9=pln 1=euro 100=kwota

