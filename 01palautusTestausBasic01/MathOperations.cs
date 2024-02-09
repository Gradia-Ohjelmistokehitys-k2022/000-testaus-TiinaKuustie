

namespace TestausBasic01
{
    internal class MathOperations
    {
        static void Main(string[] args)
        {
            Ohjelma x = new Ohjelma();
            //    x.Kokonaisluku(2);

            //x.Neliojuuri(4);

            List<double> lista = new List<double> { 5.5, 3.3, 8.8, 2.2, 7.7, 1.1 };


            double result = x.Listanpienin(lista);

            Console.WriteLine($"Listan pienin arvo on: {result}");
        }

       
    }
}
