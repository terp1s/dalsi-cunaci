namespace serifove_cunici
{
    class Zasobnik<T>
    {
        LinkedList<T> Spojak { get; } = new LinkedList<T>();

        public void Push(int i)
        {
            Node<T> novy = new Node<T>();
            novy.Next = Spojak.Zacatek;
            Spojak.Zacatek = novy;
        }

        public T Top()
        {
            return Spojak.Zacatek.Data;
        }

        public void Pop()
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
