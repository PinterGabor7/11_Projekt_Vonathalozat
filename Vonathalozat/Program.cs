namespace Vonathalozat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Allomas> Allomasok = new List<Allomas>()
            {
                new Allomas(),
            };
            char choice = ' ';
            while (choice != '0')
            {
                Console.WriteLine("Jelenleg a(z) {} állomáson van.");
                Console.WriteLine("Továbbmehet a következő állomásokra: ");
                foreach (Allomas a in Allomasok)
                {

                }
            }
        }
    }
}
