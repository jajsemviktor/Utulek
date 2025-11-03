using System;

namespace Utulek
{
    internal class KonzoleUI
    {
        public void Spustit()
        {
            int volba;
            do
            {
                ZobrazitMenu();

                if (!int.TryParse(Console.ReadLine(), out volba))
                {
                    volba = -1;
                }

                switch (volba)
                {
                    case 1:
                        PridatZvire();
                        break;
                    case 2:
                        VypsatZvirata();
                        break;
                    case 3:
                        VyhledatZvire();
                        break;
                    case 4:
                        OznacitAdopci();
                        break;
                    case 0:
                        Console.WriteLine("Konec programu.");
                        break;
                    default:
                        Console.WriteLine("Neplatna volba!");
                        break;
                }

                if (volba != 0)
                {
                    Console.WriteLine("Stiskni libovolnou klavesu...");
                    Console.ReadKey();
                }

            } while (volba != 0);
        }

        private void ZobrazitMenu()
        {
            Console.Clear();
            Console.WriteLine("===== UTULEK PRO ZVIRATA =====");
            Console.WriteLine("1) Pridat zvire");
            Console.WriteLine("2) Vypsat vsechna zvirata");
            Console.WriteLine("3) Vyhledat / filtrovat");
            Console.WriteLine("4) Oznacit adopci");
            Console.WriteLine("0) Konec");
            Console.Write("Volba: ");
        }

        private void PridatZvire()
        {
            Console.WriteLine(">>> PridatZvire() zatim neni implementovano");
        }

        private void VypsatZvirata()
        {
            Console.WriteLine(">>> VypsatZvirata() zatim neni implementovano");
        }

        private void VyhledatZvire()
        {
            Console.WriteLine(">>> VyhledatZvire() zatim neni implementovano");
        }

        private void OznacitAdopci()
        {
            Console.WriteLine(">>> OznacitAdopci() zatim neni implementovano");
        }

    }
}
