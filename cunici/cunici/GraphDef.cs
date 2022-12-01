using System;
using System.Collections.Generic;

namespace serifove_cunici
{
    class GraphDef
    {
        int PocetVrcholu;
        public Graph Graph = new Graph();

        (int a, int b)[] Hrany;

        //vytvareni listu vrcholu a nacitani int PocetVrcholu
        public void Pocet_vrcholu(int i)
        {
            PocetVrcholu = i;
            Graph.Vrcholy = new List<Vertex>();

            for (int a = 0; a < PocetVrcholu; a++)
            {
                Graph.Vrcholy.Add(new Vertex());
                Graph.Vrcholy[a].Nazev = a;
            }
        }

        //nacitani dvojic vrcholu
        public void Pocet_hran(int i)
        {
            Hrany = new (int, int)[i];
        }

        //odkazovani sousedu na sebe navzajem
        public void Sousedi((int, int)[] hrany)
        {
            Hrany = hrany;

            for(int i = 0; i < hrany.Length; i++)
            {
                //pokud hrana jiz nebyla zadana, vrchlu a se prida do sousedu vrchol b a naopak
                if (!Graph.Vrcholy[Hrany[i].a].Sousedi.Contains(Graph.Vrcholy[Hrany[i].b]))
                {
                    Graph.Vrcholy[Hrany[i].a].Sousedi.Add(Graph.Vrcholy[Hrany[i].b]);
                    Graph.Vrcholy[Hrany[i].b].Sousedi.Add(Graph.Vrcholy[Hrany[i].a]);
                }
                
            }
          
        }

        //je tohle potreba?
        public string Cesta(Vertex a, Vertex b)
        {
            return Graph.Nejkratsi_cesta(a, b);
        }
    }
}
