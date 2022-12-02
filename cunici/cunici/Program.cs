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
                (0, 1),
            };

            
            Graph test = GraphFactory.CreateGraph(5, hrany);

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

            Console.WriteLine(test.Nejkratsi_cesta(start, cil));
            
            Console.ReadKey();
        }
    }
}
