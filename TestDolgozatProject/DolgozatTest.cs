using DolgozatProject;

namespace TestDolgozatProject
{
    public class DolgozatTest
    {

        Dolgozat dolgozat;

        [SetUp]
        public void Setup()
        {
            dolgozat = new Dolgozat();
        }

        [Test]
        public void Dolgozat_LetrejonUresLista()
        {
            Assert.IsInstanceOf<List<int>>(dolgozat.pontok);
            Assert.That(dolgozat.pontok.Count, Is.EqualTo(0));
        }

        [Test]
        public void Dolgozat_PontFelvesz_HelyesAdattal_Irt()
        {
            dolgozat.PontFelvesz(3);
            Assert.That(dolgozat.pontok.Count, Is.EqualTo(1));
            Assert.That(dolgozat.pontok[0], Is.EqualTo(3));

            dolgozat.PontFelvesz(80);
            Assert.That(dolgozat.pontok.Count, Is.EqualTo(2));
            Assert.That(dolgozat.pontok[1], Is.EqualTo(80));

            dolgozat.PontFelvesz(0);
            Assert.That(dolgozat.pontok.Count, Is.EqualTo(3));
            Assert.That(dolgozat.pontok[2], Is.EqualTo(0));

            dolgozat.PontFelvesz(100);
            Assert.That(dolgozat.pontok.Count, Is.EqualTo(4));
            Assert.That(dolgozat.pontok[3], Is.EqualTo(100));
        }

        [Test]
        public void Dolgozat_PontFelvesz_HelyesAdattal_NemIrt()
        {
            dolgozat.PontFelvesz(-1);
            Assert.That(dolgozat.pontok.Count, Is.EqualTo(1));
            Assert.That(dolgozat.pontok[0], Is.EqualTo(-1));

            dolgozat.PontFelvesz(-1);
            Assert.That(dolgozat.pontok.Count, Is.EqualTo(2));
            Assert.That(dolgozat.pontok[1], Is.EqualTo(-1));
        }

        [Test]
        public void Dolgozat_PontFelvesz_Helytelen_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                dolgozat.PontFelvesz(-2);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                dolgozat.PontFelvesz(101);
            });
        }

        [Test]
        public void Dolgozat_MindenkiMegirta_Igaz()
        {
            dolgozat.PontFelvesz(51);
            dolgozat.PontFelvesz(23);
            dolgozat.PontFelvesz(99);
            dolgozat.PontFelvesz(12);
            dolgozat.PontFelvesz(73);
            Assert.That(dolgozat.MindenkiMegirta);
        }

        [Test]
        public void Dolgozat_MindenkiMegirta_Hamis()
        {
            dolgozat.PontFelvesz(51);
            dolgozat.PontFelvesz(23);
            dolgozat.PontFelvesz(-1);
            dolgozat.PontFelvesz(12);
            dolgozat.PontFelvesz(73);
            Assert.That(dolgozat.MindenkiMegirta, Is.False);
        }

        [Test]
        public void Dolgozat_Bukas() // < 50
        {
            // Bukott                   -- 1
            dolgozat.PontFelvesz(0);
            // Átment
            dolgozat.PontFelvesz(50);
            // Bukott                   -- 2
            dolgozat.PontFelvesz(49);
            // Nem írt
            dolgozat.PontFelvesz(-1);

            Assert.That(dolgozat.Bukas, Is.EqualTo(2));
        }

        [Test]
        public void Dolgozat_Elegseges() // [50, 60]
        {
            dolgozat.PontFelvesz(-1);
            dolgozat.PontFelvesz(99);
            dolgozat.PontFelvesz(0);
            dolgozat.PontFelvesz(49);
            dolgozat.PontFelvesz(61);
            dolgozat.PontFelvesz(56); // 1
            dolgozat.PontFelvesz(60); // 2
            dolgozat.PontFelvesz(50); // 3

            Assert.That(dolgozat.Elegseges, Is.EqualTo(3));
        }

        [Test]
        public void Dolgozat_Kozepes() // [61, 70]
        {
            dolgozat.PontFelvesz(-1);
            dolgozat.PontFelvesz(60);
            dolgozat.PontFelvesz(71);
            dolgozat.PontFelvesz(66); // 1
            dolgozat.PontFelvesz(61); // 2
            dolgozat.PontFelvesz(70); // 3

            Assert.That(dolgozat.Kozepes, Is.EqualTo(3));
        }

        [Test]
        public void Dolgozat_Jo() // [71, 80]
        {
            dolgozat.PontFelvesz(-1);
            dolgozat.PontFelvesz(70);
            dolgozat.PontFelvesz(81);
            dolgozat.PontFelvesz(76); // 1
            dolgozat.PontFelvesz(71); // 2
            dolgozat.PontFelvesz(80); // 3

            Assert.That(dolgozat.Jo, Is.EqualTo(3));
        }

        [Test]
        public void Dolgozat_Jeles() // [81, 100]
        {
            dolgozat.PontFelvesz(-1);
            dolgozat.PontFelvesz(80);
            dolgozat.PontFelvesz(81); // 1
            dolgozat.PontFelvesz(100); // 2
            dolgozat.PontFelvesz(90); // 3

            Assert.That(dolgozat.Jeles, Is.EqualTo(3));
        }

        [Test]
        public void Dolgozat_Gyanus_Hamis()
        {
            dolgozat.PontFelvesz(90); // 1 jeles
            dolgozat.PontFelvesz(-1);
            dolgozat.PontFelvesz(14);
            dolgozat.PontFelvesz(57);
            dolgozat.PontFelvesz(80);
            dolgozat.PontFelvesz(91); // 2 jeles
            dolgozat.PontFelvesz(100); // 3 jeles

            Assert.That(dolgozat.Gyanus(100), Is.False);

            Assert.That(dolgozat.Gyanus(3), Is.False);
        }

        [Test]
        public void Dolgozat_Gyanus_Igaz()
        {
            dolgozat.PontFelvesz(90); // 1 jeles
            dolgozat.PontFelvesz(-1);
            dolgozat.PontFelvesz(14);
            dolgozat.PontFelvesz(57);
            dolgozat.PontFelvesz(80);
            dolgozat.PontFelvesz(91); // 2 jeles
            dolgozat.PontFelvesz(100); // 3 jeles

            Assert.That(dolgozat.Gyanus(0), Is.True);

            Assert.That(dolgozat.Gyanus(2), Is.True);
        }

        [Test]
        public void Dolgozat_Gyanus_Hibas_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                dolgozat.Gyanus(-1);
            });
        }

        [Test]
        public void Dolgozat_Ervenytelen_Igaz()
        {
            dolgozat.PontFelvesz(-1);   // 1
            dolgozat.PontFelvesz(100);
            dolgozat.PontFelvesz(-1);   // 2
            dolgozat.PontFelvesz(30);
            dolgozat.PontFelvesz(-1);   // 3
            dolgozat.PontFelvesz(50);
            dolgozat.PontFelvesz(100);

            // 3 nem írt a 6-ból
            Assert.That(dolgozat.Ervenytelen, Is.True);

            dolgozat.PontFelvesz(-1);   // 4
            dolgozat.PontFelvesz(-1);   // 5

            // 5 nem írt a 8-ból
            Assert.That(dolgozat.Ervenytelen, Is.True);
        }

        [Test]
        public void Dolgozat_Ervenytelen_Hamis()
        {
            dolgozat.PontFelvesz(-1);   // 1
            dolgozat.PontFelvesz(100);
            dolgozat.PontFelvesz(-1);   // 2
            dolgozat.PontFelvesz(30);
            dolgozat.PontFelvesz(-1);   // 3
            dolgozat.PontFelvesz(50);
            dolgozat.PontFelvesz(100);
            dolgozat.PontFelvesz(88);

            // 3 nem írt a 7-ből
            Assert.That(dolgozat.Ervenytelen, Is.False);
        }
    }
}