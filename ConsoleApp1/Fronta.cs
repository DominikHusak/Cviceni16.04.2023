using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Fronta
    {
        private Queue<int> queue = new Queue<int>();
        private object lockObj = new object(); // Zámek pro synchronizaci přístupu k frontě

        // Metoda pro vložení prvku do fronty
        public void VlozPrvek(int cislo)
        {
            lock (lockObj) // Použití zámku pro synchronizaci
            {
                queue.Enqueue(cislo);
                Console.WriteLine($"Prvek {cislo} byl vložen do fronty.");
                Monitor.Pulse(lockObj); // Probuzení vlákna, které čeká na prvek
            }
        }

        // Metoda pro získání prvku z fronty
        public int ZiskejPrvek()
        {
            lock (lockObj) // Použití zámku pro synchronizaci
            {
                while (queue.Count == 0) // Pokud je fronta prázdná, čekáme na prvek
                {
                    Monitor.Wait(lockObj); // Uvolnění zámku a uspání vlákna
                }
                int prvek = queue.Dequeue();
                Console.WriteLine($"Prvek {prvek} byl odebrán z fronty.");
                return prvek;
            }
        }

        // Metoda pro zjištění počtu prvků ve frontě
        public int PocetPrvkuVeFronte()
        {
            lock (lockObj) // Použití zámku pro synchronizaci
            {
                return queue.Count;
            }
        }
    }
}

