﻿namespace serifove_cunici
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node()
        {

        }
    }
}
