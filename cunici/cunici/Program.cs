using NPOI.SS.Formula.Functions;
using System;

namespace serifove_cunici
{
    class Program
    {
        static void Main(string[] args)
        {
            (int,int)[] hrany =
            {
                (0, 1),
                (1, 2),
                (3, 2),
                (4, 2),
                (0,1),
            };

            
            GraphDef def = new GraphDef();
            Graph test = def.Graph;

            def.Pocet_vrcholu(5);
            def.Pocet_hran(4);
            def.Sousedi(hrany);

            Vertex start = test.Vrcholy[0];
            Vertex cil = test.Vrcholy[4];


            foreach (var item in test.Vrcholy)
            {
                
                Console.Write(item.Nazev + ":");
                
                foreach (var item2 in item.Sousedi)
                { 
                    Console.Write(item2.Nazev + " ");
                    
                }
                Console.WriteLine();
            }

            Console.WriteLine(def.Cesta(start, cil));
            
            Console.ReadKey();
        }
    }
}
