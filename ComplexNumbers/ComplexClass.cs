using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/**
 * Complex numbers class
 */

namespace ComplexNumbers
{
    public class ComplexClass
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public double Absolute => Math.Sqrt(Real * Real + Imaginary * Imaginary);
        public ComplexClass Conjugate => new(Real, -Imaginary);
        public ComplexClass(double real, double imaginary) { Real = real; Imaginary = imaginary; }
        public ComplexClass() { }
        public override string ToString() 
        {
            StringBuilder sb = new();
            if (Real != 0 || Imaginary == 0)
            {
                sb.Append(Real);
            }
            
            return sb.ToString();
        }

    }
}
