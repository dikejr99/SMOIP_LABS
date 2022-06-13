using System;

namespace Lab4
{
    [Serializable()]
    class Node
    {
        public byte value;
        public short frequency;
        public Node? left;
        public Node? right;
    }
}
