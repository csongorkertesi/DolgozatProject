namespace DolgozatProject
{
    public class Dolgozat
    {
        public List<int> pontok;

        public Dolgozat()
        {
            pontok = new List<int>();
        }

        public void PontFelvesz(int x)
        {
            if (x == -1 || (x >= 0 && x < 101))
            {
                pontok.Add(x);
            }
            else
            {
                throw new ArgumentException("Hibás pontszám", "x");
            }
        }

        public bool MindenkiMegirta()
        {
            return !pontok.Contains(-1);
        }

        public int Bukas
        {
            get
            {
                return pontok.Count(x => (x < 50 && x != -1));
            }
        }

        public int Elegseges
        {
            get
            {
                return pontok.Count(x => (x >= 50 && x <= 60));
            }
        }

        public int Kozepes
        {
            get
            {
                return pontok.Count(x => (x >= 61 && x <= 70));
            }
        }

        public int Jo
        {
            get
            {
                return pontok.Count(x => (x >= 71 && x <= 80));
            }
        }

        public int Jeles
        {
            get
            {
                return pontok.Count(x => (x > 80));
            }
        }

        public bool Gyanus(int kivalok)
        {
            if (kivalok < 0) { throw new ArgumentException("Kiválók száma nem lehet kisebb mint 0", "kivalok"); }
            return Jeles > kivalok;
        }

        public bool Ervenytelen
        {
            get
            {
                return pontok.Count(x => (x == -1)) >= pontok.Count() / 2;
            }
        }
    }
}
