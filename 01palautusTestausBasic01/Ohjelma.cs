using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestausBasic01
{
    public class Ohjelma
    {
        public double lasku2;
        public double arvoI;

        public int KaksiLukua(int eka, int toka)
        {
            int lasku = eka - toka;

            return lasku;
        }

       public double Kokonaisluku(int luku)
        {
            lasku2 = 0;
           
            if (luku < 101)
            {
                lasku2 = Math.Pow(luku, 2);
             //   Console.WriteLine(lasku2);
            }
            

            return lasku2;
        }


        public double Neliojuuri(int luku)
        {

         
            double lasku3 = Math.Sqrt(luku);
            Console.WriteLine($"Neliöjuuri luvusta {luku} on {lasku3}");

            return lasku3;

        }

        public double Listanpienin(List<double> sisaanlista) //Tee ohjelma, joka etsii double tyyppisestä listasta (List) pienimmän arvon ja palauttaa sen.
                                        //Tee itse pienimmän arvon etsiminen. List.Min metodin käyttö on kielletty. Tee ohjelmalle yksikköstestit.
        {
        
            arvoI = sisaanlista[0];
          

            for (int i= 0; i < sisaanlista.Count;i++)
            {
                double arvo = sisaanlista[i];
                if (arvo < arvoI) arvoI = arvo;
                
            }

            double listanpienin = arvoI;
            Console.WriteLine($"Listan pienin arvo on: {listanpienin}");
            return listanpienin;



        }

        public int ListanSuurin(List<int> sisaanlista) //Tee ohjelma, joka etsii double tyyppisestä listasta (List) pienimmän arvon ja palauttaa sen.
                                                             //Tee itse pienimmän arvon etsiminen. List.Min metodin käyttö on kielletty. Tee ohjelmalle yksikköstestit.
        {
          
           int arvoI2 = sisaanlista[0];


            for (int i = 0; i < sisaanlista.Count; i++)
            {
                int arvo = sisaanlista[i];
                if (arvo > arvoI2) arvoI2 = arvo;

            }

            int listanSuurin = arvoI2;
            Console.WriteLine($"Listan suurin arvo on: {listanSuurin}");
            return listanSuurin;



        }

        public float ListanKeskiarvo(List<float> sisaanlista)
        {
            float keskiarvo = 0;

            for (int i = 0; i < sisaanlista.Count; i++)
            {
                keskiarvo = keskiarvo + sisaanlista[i];
            }

            keskiarvo = keskiarvo/sisaanlista.Count;
            Console.WriteLine($"Listan keskiarvo on: {keskiarvo}");

            return keskiarvo;
        }

    }
}
