using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : Matrix<T> where T : INumber<T>
    {
        private T[,] _array;
        public T Determinant => GetDeterminant();
        public int Size => _array.GetLength(0);
        public SquareMatrix() { _array = new T[0, 0]; }
        public SquareMatrix(int size)
            : base(size, size)
        {
            _array = new T[size, size];
        }
        public SquareMatrix(T[,] array)
            : base(array)
        {
            if (array.GetLength(0) != array.GetLength(1))
                throw new InvalidDimensionsException(array.GetLength(0), array.GetLength(1));
        }

        public override string ToString() => PrettyPrint();
        private T GetDeterminant()
        {
            if (Size <= 0) return T.Zero;
            else if (Size == 1) return _array[0, 0];
            else if (Size == 2)
                return _array[0, 0] * _array[1, 1] - _array[0, 1] * _array[1, 0];
            else
            {
                T determinant = T.Zero;
                T kroneckerSign = T.One;

                for (int col = 0; col < Size; col++)
                {
                    T minorDeterminant = GetMinorDeterminant(0, col);
                    determinant += (col % 2 == 0 ? kroneckerSign : -kroneckerSign) * _array[0, col] * minorDeterminant;
                }
                return determinant;
            }
        }

        private T GetMinorDeterminant(int row, int col)
        {
            T[,] minor = new T[Size - 1, Size - 1];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (i != row && j != col)
                        minor[i < row ? i : i - 1, j < col ? j : j - 1] = _array[i, j];

            return new SquareMatrix<T>(minor).GetDeterminant();
        }
    }
}
