using NPOI.SS.Formula.Functions;

namespace serifove_cunici
{
    class Queue<T>
    {
        public LinkedList<T> Spojak { get; } = new LinkedList<T>();
        public void Enqueue(T novy)
        {
            Node<T> novy_node = new Node<T>(novy);
            
            if (Spojak.Zacatek == null)
            {
                Spojak.Zacatek = novy_node;
                Spojak.Konec = Spojak.Zacatek;
            }
            else
            {
                Spojak.Konec.Next = novy_node;
                Spojak.Konec = Spojak.Konec.Next;
            }

        }

        public T Peek()
        {
            return Spojak.Zacatek.Data;
        }

        public void Dequeue()
        {
            Spojak.Zacatek = Spojak.Zacatek.Next;
        }

        public bool IsEmpty()
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
}
