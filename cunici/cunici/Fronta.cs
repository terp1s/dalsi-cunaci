namespace serifove_cunici
{
    class Queue<T>
    {
        private LinkedList<T> Spojak { get; } = new LinkedList<T>();
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

        public T Peek() => Spojak.Zacatek.Data;

        public T Dequeue()
        {
            var result = Spojak.Zacatek;
            Spojak.Zacatek = Spojak.Zacatek.Next;
            return result.Data;
        }        

        public bool IsEmpty() => Spojak.Zacatek == null;
       
    }
}
