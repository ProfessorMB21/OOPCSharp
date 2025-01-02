using Matrix;

Matrix.Matrix<int> m1 = new(2, 2);

Console.WriteLine(m1[1,1]);

int[,] matrix2x2 = {
    { 1, 2 },
    { 2, 1 }
};
int[,] mat2x2 = {
    { 7, 9 },
    { 11, -5 }
};

int[,] mat3x3 =
{
    {2, 4, 5 },
    {1, 0, 6 },
    {10, 8, -1 }
};

var m2 = new Matrix.Matrix<int>(matrix2x2);
var m3x3 = new Matrix.Matrix<int>(mat3x3);

Console.WriteLine(m2);
Console.WriteLine(m3x3);
Console.WriteLine(m2*0);
//Console.WriteLine(m2*m3x3);
Console.WriteLine(m2+m2);
Console.WriteLine(m2 == m3x3);
Console.WriteLine(m2/2);
//Console.WriteLine(m2/0);
Console.WriteLine(m2*m2);

Matrix<int> m3 = m3x3 * m3x3;
Console.WriteLine(m3);

Matrix<int> transpose_m2 = (Matrix<int>)m2.Transpose;
Console.WriteLine(transpose_m2.PrettyPrint());

Matrix<int> m2_ = new(mat2x2);
Matrix<int> m4 = m2 * m2_;
Console.WriteLine(m2_);
Console.WriteLine(m4);

////////////// square matrix //////////////

int[,] sq_matrixArray =
{
    {1, 2, 1 },
    {0, 3, 4 },
    {3, 1, 4 }
};

SquareMatrix<int> square = new(sq_matrixArray);
Console.WriteLine(square);
Console.WriteLine("Det: " + square.Determinant);

int[,] arr22 =
{
    {4, 1 },
    {5, 2}
};

SquareMatrix<int> square2 = new(arr22);
Console.WriteLine(square2);
Console.WriteLine(square2.Determinant);

double[,] doubles =
{ 
    { 2.7, 1}, 
    { 5.6, -6} 
};

Console.WriteLine(new SquareMatrix<double>(doubles).Determinant);
Console.WriteLine();
