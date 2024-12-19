using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    public class TrigComplex : ComplexClass
    {
        private double _r;
        private double _phi;
        public new double Real { get => base.Real; 
            set
            {
                base.Real = value;
                _r = Absolute;
                _phi = Math.Atan2(Real, Imaginary);
            }
        }
        public new double Imaginary { get => base.Imaginary;
        set
            {
                base.Imaginary = value;
                _r = Absolute;
                _phi = Math.Atan2(Real, Imaginary);
            }
        }
        public double R { get => _r;  
            set
            { 
                _r = value;
                base.Real = Math.Cos(_phi) * _r;
                base.Imaginary = Math.Sin(_phi) * _r;
            } 
        }
        public double Phi { get => _phi;
            set 
            {
                _phi = value;
                base.Real = Math.Cos(_phi) * _r;
                base.Imaginary = Math.Sin(_phi) * _r;
            }
        }

        public TrigComplex() { }
        public TrigComplex(double r, double phi)
        {
            R = r;
            Phi = phi;
        }
        public override string ToString() => $"{R}(cos{Phi} + i sin{Phi})";
    }
}
