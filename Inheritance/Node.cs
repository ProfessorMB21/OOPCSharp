using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public abstract class Node
    {
        private int _a;
        private int _b;
        private int _n;

        public int A => _a;
        public int B => _b;
        public int N { get => _n; set { } }

        public Node() { }
        public Node(int a, int b, int n)
        {
            N = n;
            SetBoundaries(a, b);
        }

        public void SetBoundaries(int a, int b)
        {
            _a = Math.Min(a, b);
            _b = Math.Max(a, b);
        }

        public abstract double GetNode(int i);
        
    }
}
