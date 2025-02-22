﻿using System;
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
            if (Imaginary != 0)
            {
                if (Imaginary > 0 && Real != 0) { sb.Append(" + "); }
                else { sb.Append(" - "); }
                if (Math.Abs(Imaginary) != 1) { sb.Append(Math.Abs(Imaginary)); }
                sb.Append("i");
            }
            return sb.ToString();
        }
        public ComplexClass Sum(ComplexClass other) => new(Real + other.Real, Imaginary + other.Imaginary);
        public ComplexClass Diff(ComplexClass other) => new(Real - other.Real, Imaginary - other.Imaginary);
        public ComplexClass Prod(ComplexClass other) => new(Real * other.Real - Imaginary * other.Imaginary, Real * other.Imaginary + Imaginary * other.Real);
        public ComplexClass Quotient(ComplexClass other)
        {
            return new((Real * other.Real + Imaginary * other.Imaginary) / (other.Real * other.Real + other.Imaginary * other.Imaginary),
                 (other.Real * Imaginary - Real * other.Imaginary) / (other.Real * other.Real + other.Imaginary * other.Imaginary));
        }
        public void SumAssign(ComplexClass other)
        {
            Real += other.Real;
            Imaginary += other.Imaginary;
        }
        public void DiffAssign(ComplexClass other)
        {
            Real -= other.Real;
            Imaginary -= other.Imaginary;
        }
        public void ProdAssign(ComplexClass other)
        {
            var t = Real * other.Real - Imaginary * other.Imaginary;
            Imaginary = Real * other.Imaginary + Imaginary * other.Real;
            Real = t;
        }
        public void QuotientAssign(ComplexClass other)
        {

        }
        public static bool operator ==(ComplexClass _this, ComplexClass other)
        {
            if (_this is null || other is null) return false;
            return Math.Abs(_this.Real - other.Real) < 1e-10 && Math.Abs(_this.Imaginary - other.Imaginary) < 1e-10;
        }
        
        public static bool operator !=(ComplexClass _this, ComplexClass other)
        {
            return !(_this == other);
        }

        public static implicit operator ComplexClass(double d)
        {
            return new(d, 0);
        }

        public static ComplexClass operator -(ComplexClass _this) => new(-_this.Real, -_this.Real);
        public static ComplexClass operator +(ComplexClass _this) => new(_this.Real, _this.Real);
        public static bool operator true(ComplexClass _this) => _this != 0;
        public static bool operator false(ComplexClass _this) => !(_this != 0);
        
    }
}
