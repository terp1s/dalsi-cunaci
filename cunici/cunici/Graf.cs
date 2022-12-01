using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;

namespace serifove_cunici
{
    class Graph
    {
        public GraphDef Def { get; set; }
        public List<Vertex> Vrcholy { get; set; } = new List<Vertex>();

        public LinkedList<T> Cesta { get; set; }

        public Graph(GraphDef zadani)
        {

        }
        public Graph()
        {

        }

        //hleda nejkratsi cestu mezi dvema vertexy
        public string Nejkratsi_cesta(Vertex start, Vertex cil)
        {
            Queue<Vertex> cesta = new Queue<Vertex>();  //fronta sousedu policka/startu
            List<Vertex> cesticka = new List<Vertex>();  //po ceste se pujde zpatky od cile po vertexech, ktere prijdou do cesticky
            Vertex policko = cil;  //potrebuju novou promenou? nechtela jsem si prepisovat cil.  
            start.Hloubka = 0;
            cesta.Enqueue(start);
            string output = "";


            //prohledavani do sirky dokud nedojdu do cile, nebo cil neni dosazitelny
            while (cesta.Spojak.Zacatek.Data != cil && !cesta.IsEmpty())
            {
                //pro kazdy  vertex pridam do fronty vsechny jeho sousedy s hloubkou +1
                for (int i = 0; i < cesta.Spojak.Zacatek.Data.Sousedi.Count; i++)
                {
                    if (cesta.Spojak.Zacatek.Data.Sousedi[i].Hloubka == -1)
                    {
                        cesta.Enqueue(cesta.Spojak.Zacatek.Data.Sousedi[i]);
                        cesta.Spojak.Zacatek.Data.Sousedi[i].Hloubka = cesta.Spojak.Zacatek.Data.Hloubka + 1;
                    }

                }
                cesta.Dequeue();

            }

            //nasli jsme cil
            if (cesta.Spojak.Zacatek.Data == cil)
            {
                int a = 0;
                cesticka.Add(cil);

                while (policko != start)
                {
                    //pokud jsou sousedi cile v ceste, vedou ke startu
                    if (policko.Sousedi[a].Hloubka != -1 && policko.Sousedi[a].Hloubka < policko.Hloubka)
                    {
                        policko = policko.Sousedi[a];
                        cesticka.Add(policko);
                        a = 0;
                    }
                    else
                    {
                        a++;
                    }
                }

                cesticka.Reverse();

                foreach (Vertex item in cesticka)
                {
                    output = output + item.Nazev;
                }

                ;

            }
            else //cesta neexistuje
            {
                output = null;
            }

            //znovu nastavit hloubky na jine prohledavani
            foreach (Vertex item in Vrcholy)
            {
                item.Hloubka = -1;
            }

            return output;


        }
        
    }
}
