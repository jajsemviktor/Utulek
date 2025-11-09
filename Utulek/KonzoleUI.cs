using System;
using System.IO;

namespace Utulek
{
    internal class KonzoleUI
    {
        private readonly Evidence _evidence = new Evidence();

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
                    case 5:
                        ZapisDoSouboru();
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
            Console.WriteLine("===== UTULEK PRO ZVIRATA ===== \n1) Pridat zvire \n2) Vypsat vsechna zvirata \n3) Vyhledat / filtrovat \n4) Oznacit adopci\n5) Zapsat do souboru \n0) Konec");
            Console.Write("Volba: ");
        }

        private void PridatZvire()
        {
            Console.WriteLine("=== Pøidat zvíøe ===");
            Console.Write("Jméno: ");
            var name = Console.ReadLine();

            Console.Write("Druh: ");
            var druh = Console.ReadLine();

            int vek;
            Console.Write("Vìk: ");
            while (!int.TryParse(Console.ReadLine(), out vek) || vek < 0)
            {
                Console.Write("Neplatný vìk. Zadej èíslo (>= 0): ");
            }

            Console.Write("Pohlaví: ");
            var pohlavi = Console.ReadLine();

            var zvire = _evidence.Add(name, druh, vek, pohlavi);
            Console.WriteLine($"Pøidáno zvíøe s ID {zvire.ID}.");
        }

        private void VypsatZvirata()
        {
            Console.WriteLine("=== Seznam zvíøat ===");
            var zvirata = _evidence.GetAll();

            bool any = false;
            foreach (var z in zvirata)
            {
                any = true;
                VypisZvire(z);
            }

            if (!any)
            {
                Console.WriteLine("Žádná zvíøata v evidenci.");
            }
        }

        private void VyhledatZvire()
        {
            Console.WriteLine("=== Vyhledat / filtrovat ===");
            Console.Write("Zadej èást jména (enter = všechna): ");
            var fragment = Console.ReadLine();

            var vysledky = _evidence.FindByName(fragment);
            bool any = false;
            foreach (var z in vysledky)
            {
                any = true;
                VypisZvire(z);
            }

            if (!any)
            {
                Console.WriteLine("Nic nenalezeno.");
            }
        }

        private void OznacitAdopci()
        {
            VypsatZvirata();
            Console.WriteLine("=== Oznaèit adopci ===");

            Console.Write("Zadej ID zvíøete: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Neplatné ID.");
                return;
            }

            var z = _evidence.GetById(id);
            if (z == null)
            {
                Console.WriteLine("Zvíøe s tímto ID nebylo nalezeno.");
                return;
            }

            if (string.Equals(z.adoptovano, "ano", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Toto zvíøe je již adoptováno.");
                return;
            }

            var ok = _evidence.Adopt(id);
            Console.WriteLine(ok ? "Zvíøe bylo oznaèeno jako adoptované." : "Nepodaøilo se oznaèit adopci.");
        }

        private void VypisZvire(Zvire z)
        {
            Console.WriteLine($"ID: {z.ID} | Jméno: {z.Name} | Druh: {z.druh} | Vìk: {z.vek} | Pohlaví: {z.pohlavi} | Adoptováno: {z.adoptovano}");
        }

        private void ZapisDoSouboru()
        {
            using (StreamWriter sw = new StreamWriter("Utulek.txt"))
            {
                try
                {
                    foreach (Zvire z in _evidence.GetAll())
                    {
                        sw.WriteLine($"ID: {z.ID} | JMÉNO: {z.Name} | DRUH: {z.druh} | VÌK: {z.vek} | POHLAVÍ: {z.pohlavi} | ADOPTOVANO: {z.adoptovano}");
                    }
                    sw.Flush();
                    Console.WriteLine("Zápis byl uložen.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}