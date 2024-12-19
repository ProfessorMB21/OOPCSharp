/**
 *  
 * 
 */
using ComplexNumbers;

ComplexClass z1 = new();
ComplexClass z2 = new() { Real = 3, Imaginary = 4};

Console.WriteLine(z1);
Console.WriteLine(z2);
Console.WriteLine(z1.Absolute);
Console.WriteLine(z2.Absolute);

ComplexClass z3 = z2.Sum(z1);
Console.WriteLine(z3);

TrigComplex trigComplex = new(2.0, 0.0);
trigComplex.Real = 10.0;
Console.WriteLine(trigComplex);
