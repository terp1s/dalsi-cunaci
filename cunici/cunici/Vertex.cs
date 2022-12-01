using System.Collections.Generic;

namespace serifove_cunici
{
    class Vertex
    {
        public List<Vertex> Sousedi = new List<Vertex>();
        public int Hloubka = -1;
        public int Nazev;

        public Vertex()
        {

        }
        public Vertex(int i)
        {
            Nazev = i;
        }
    }
}
