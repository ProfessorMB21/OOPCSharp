using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class ChebyshevNodes : Node
    {
        public ChebyshevNodes(int a, int b, int n) : base(a, b, n) { }
        
        public override double GetNode(int i)
        {
            return this[i];
        }

        public double this[int i] => 0.5 * (A + B) + 0.5 * (B - A) * Math.Cos((2.0*i + 1)/(2.0*N) * Math.PI);
    }
}
