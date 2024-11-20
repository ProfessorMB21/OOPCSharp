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
