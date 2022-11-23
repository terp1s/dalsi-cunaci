using System;
using System.Collections.Generic;

namespace serifove_cunici
{
    class Spojak
    {
        public Vertex Zacatek { get; set; }

        public Vertex Konec { get; set; }

        public Spojak()
        {

        }
    }
    class Fronta
    {
        Spojak Spojak { get; } = new Spojak();
        public void Vloz(Vertex novy)
        {
            
            if (Spojak.Zacatek == null)
            {
                Spojak.Zacatek = novy;
                Spojak.Konec = Spojak.Zacatek;
            }
            else
            {
                Spojak.Konec.Next = novy;
                Spojak.Konec = Spojak.Konec.Next;
            }

        }

        public int VratPrvek()
        {
            return Spojak.Zacatek.Nazev;
        }

        public void OdeberPrvek()
        {
            Spojak.Zacatek = Spojak.Zacatek.Next;
        }

        public bool Prazdna()
        {
            if (Spojak.Zacatek == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Zasobnik
    {
        Spojak Spojak { get; } = new Spojak();

        public void Vloz(int i)
        {
            Vertex novy = new Vertex();
            novy.Next = Spojak.Zacatek;
            Spojak.Zacatek = novy;
        }

        public int VratPrvek()
        {
            return Spojak.Zacatek.Nazev;
        }

        public void OdeberPrvek()
        {
            Spojak.Zacatek = Spojak.Zacatek.Next;
        }

        public bool Prazdna()
        {
            if (Spojak.Zacatek == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Vertex
    {
        public List<Vertex> Sousedi = new List<Vertex>();
        public Vertex Next { get; set; }
        public int Hloubka;
        public int Nazev;
        //public Zasobnik Depth { get; set; }
        //public Fronta Breadth { get; set; }
    }
    class Graf
    {
        public List<Vertex> Vrcholy { get; set; }

        public void Pocet_vrcholu(int i)
        {
            Vrcholy = new List<Vertex>();

            for (int a = 0; a < i; a++)
            {

                Vrcholy.Add(new Vertex());
                Vrcholy[a].Nazev = a;
            }
        }

        public void Sousedi(string dvojice)
        {
            string[] nazvy = dvojice.Split();

            Vrcholy[int.Parse(nazvy[0])].Sousedi.Add(Vrcholy[int.Parse(nazvy[1])]);
            Vrcholy[int.Parse(nazvy[1])].Sousedi.Add(Vrcholy[int.Parse(nazvy[0])]);
        }
        public void Nacti()
        {
            Pocet_vrcholu(int.Parse(Console.ReadLine()));
            int hrany = int.Parse(Console.ReadLine());
            for (int i = 0; i < hrany; i++)
            {
                Sousedi(Console.ReadLine());
            }

        }

        public void Nejkratsi_cesta(Vertex start, Vertex cil)
        {
            Fronta cesta = new Fronta();
            List<Vertex> cesticka = new List<Vertex>();
            Vertex policko = start;
            policko.Hloubka = 1;
            cesta.Vloz(policko);
            while(policko != cil)
            {
                for (int i = 0; i < policko.Sousedi.Count; i++)
                {
                    cesta.Vloz(policko.Sousedi[i]);
                    policko.Sousedi[i].Hloubka = policko.Hloubka;
                }
                policko = policko.Next;
                cesta.OdeberPrvek();
            }

            int a = 0;
            cesticka.Add(policko);

            while(policko != start)
            {
                
                if (policko.Sousedi[a].Hloubka == policko.Hloubka)
                {
                    cesticka.Add(policko);
                    policko = policko.Sousedi[a];
                    a = 0;
                }
                else
                {
                    a++;
                }
            }

            foreach (Vertex item in cesticka)
            {
                Console.Write(item.Nazev);
            }


        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graf test = new Graf();
            test.Nacti();

            foreach (var item in test.Vrcholy)
            {
                Console.WriteLine(item.Nazev);
                foreach (var item2 in item.Sousedi)
                {
                    Console.WriteLine(item2.Nazev);
                }
            }

            test.Nejkratsi_cesta(test.Vrcholy[0], test.Vrcholy[4]);
            Console.ReadKey();
        }
    }
}
