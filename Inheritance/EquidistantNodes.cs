using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class EquidistantNodes : Node
    {
        public EquidistantNodes(int a, int b, int n) : base(a, b, n) { }

        public override double GetNode(int i)
        {
            return A + (B - A) / (N - 1) * i;
        }
        public double this[int i]
        {
            get => A + (B - A) / (N - 1) * i;
        }
    }
}
