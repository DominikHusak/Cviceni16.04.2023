using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            Fronta fronta = new Fronta();

            Thread vlaknoVkladani = new Thread(() =>
            {
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int cislo = rnd.Next(1, 101); // Generování náhodného čísla v rozsahu 1-100
                    fronta.VlozPrvek(cislo);
                    Thread.Sleep(500); // Pauza mezi vkládáním prvku
                }
            });

            Thread vlaknoOdebirani = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    int prvek = fronta.ZiskejPrvek();
                    Thread.Sleep(1000); // Pauza mezi odebíráním prvku
                }
            });

            vlaknoVkladani.Start();
            vlaknoOdebirani.Start();

            vlaknoVkladani.Join();
            vlaknoOdebirani.Join();

            Console.WriteLine($"Ve frontě zbylo {fronta.PocetPrvkuVeFronte()} prvků.");
        }
    }
    }

