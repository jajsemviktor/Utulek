using System;
using System.Collections.Generic;
using System.Linq;

namespace Utulek
{
    internal class Evidence
    {
        private readonly List<Zvire> zvirata;
        private int nextId;

        public Evidence()
        {
            zvirata = new List<Zvire>();
            nextId = 1;
        }

        // Vrací kopii seznamu zvířat
        public IEnumerable<Zvire> GetAll()
        {
            return zvirata.ToList();
        }

        // Najde podle ID
        public Zvire GetById(int id)
        {
            return zvirata.FirstOrDefault(z => z.ID == id);
        }

        // Přidá nové zvíře a vrátí ho (s přiřazeným ID)
        public Zvire Add(string name, string druh, int vek, string pohlavi)
        {
            var zvire = new Zvire(nextId++, name ?? string.Empty, druh ?? string.Empty, vek, pohlavi ?? string.Empty, "ne");
            zvirata.Add(zvire);
            return zvire;
        }

        // Aktualizuje zvíře podle ID (vrací true pokud proběhlo)
        public bool Update(int id, string name, string druh, int vek, string pohlavi, string adoptovano = null)
        {
            var zvire = GetById(id);
            if (zvire == null) return false;

            zvire.Name = name ?? zvire.Name;
            zvire.druh = druh ?? zvire.druh;
            zvire.vek = vek;
            zvire.pohlavi = pohlavi ?? zvire.pohlavi;
            if (adoptovano != null) zvire.adoptovano = adoptovano;

            return true;
        }

        // Smaže zvíře podle ID
        public bool Delete(int id)
        {
            var zvire = GetById(id);
            if (zvire == null) return false;
            return zvirata.Remove(zvire);
        }

        // Označí zvíře jako adoptované ("ano"), vrací true pokud existovalo
        public bool Adopt(int id)
        {
            var zvire = GetById(id);
            if (zvire == null) return false;
            zvire.adoptovano = "ano";
            return true;
        }

        // Hledání podle jména (case-insensitive, částečná shoda)
        public IEnumerable<Zvire> FindByName(string nameFragment)
        {
            if (string.IsNullOrWhiteSpace(nameFragment)) return GetAll();
            return zvirata.Where(z => z.Name != null && z.Name.IndexOf(nameFragment, 
                StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        // Obecné filtrování
        public IEnumerable<Zvire> Filter(Func<Zvire, bool> predicate)
        {
            if (predicate == null) return GetAll();
            return zvirata.Where(predicate).ToList();
        }
    }
}
