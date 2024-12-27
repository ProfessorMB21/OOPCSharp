using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public interface IMatrix<T> where T : INumber<T>
    {
        int Rows { get; }
        int Columns { get; }
        IMatrix<T> Transpose { get; }
    }

    public class Matrix<T> : IMatrix<T> where T : INumber<T>
    {
        private T[,] _array;
        public int Rows => _array.GetLength(0);
        public int Columns => _array.GetLength(1);

        IMatrix<T> IMatrix<T>.Transpose => throw new NotImplementedException();

        public Matrix() { _array = new T[0, 0]; }
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException($"{(rows <= 0 ? nameof(rows) : nameof(columns))} out of range.");
            }
            _array = new T[rows, columns];
        }
        public Matrix(T[,] array)
        {
            if (array is null) throw new ArgumentNullException($"{nameof(array)} cannot be null.");
            _array = array;
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    sb.Append($"\t{this[i, j]}");
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    sb.Append($"{this[i, j]} ");
            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Matrix<T> other && Rows == other.Rows && Columns == other.Columns)
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                        if (!EqualityComparer<T>.Default.Equals(this[i, j], other[i, j])) return false;
                }
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var elem in _array)
            {
                hash = hash * 31 + elem.GetHashCode();
            }
            return hash;
        }
        public IMatrix<T> Transpose
        {
            get
            {
                var transposed_matrix = new Matrix<T>(Rows, Columns);
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                        transposed_matrix[j, i] = this[i, j];
                }
                return transposed_matrix;
            }
        }
        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Columns)
                    throw new IndexOutOfRangeException("Matrix indices out of bounds.");
                return _array[row, col];
            }
            private set
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Columns)
                    throw new IndexOutOfRangeException("Matrix indices out of bounds.");
                _array[row, col] = value;
            }
        }
        // Todo: find another alternative
        // int
        private static Matrix<int>Subtract(Matrix<int> lhs, Matrix<int> rhs)
        {
            var result = new Matrix<int>(lhs.Rows, lhs.Columns);
            for (int i = 0; i <= lhs.Rows; i++)
            {
                for (int j = 0 ; j < lhs.Columns; j++)
                    result[i, j] = lhs[i, j] - rhs[i, j];
            }
            return result;
        }
        private static Matrix<int>Add(Matrix<int> lhs, Matrix<int> rhs)
        {
            var result = new Matrix<int>(lhs.Rows, lhs.Columns);
            for (int i = 0; i <= lhs.Rows; i++)
            {
                for (int j = 0; j < lhs.Columns; j++)
                    result[i, j] = lhs[i, j] + rhs[i, j];
            }
            return result;
        }
        private static Matrix<int>ProductByScalar(Matrix<int> lhs, int k)
        {
            var result = new Matrix<int>(lhs.Rows, lhs.Columns);
            for (int i = 0; i <= lhs.Rows; i++)
            {
                for (int j = 0; j < lhs.Columns;  ++j)
                    result[i, j] = lhs[i, j] * k;
            }
            return result;
        }
        private static Matrix<int>Product(Matrix<int> lhs, Matrix<int> rhs)
        {
            var n = lhs.Rows;
            var m1 = lhs.Columns;
            var m2 = rhs.Rows;
            var p = rhs.Columns;
            // nxm1 * m2xp = nxp (m1 === m2)

            var result = new Matrix<int>(lhs.Rows, lhs.Columns);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; ++j < p; j++)
                {
                    var sum = 0;
                    for (int k = 0; k < m1; k++)
                    {
                        sum += lhs[i, k] * rhs[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }
        private static Matrix<int> QuotientByScalar(Matrix<int> lhs, int k)
        {
            var result = new Matrix<int>(lhs.Rows, lhs.Columns);
            for (int i = 0; i < lhs.Rows; i++)
            {
                for (int j = 0; j < lhs.Columns; j++)
                    result[i, j] = lhs[i, j] / k;
            }
            return result;
        }

        // double
        private static Matrix<double>Subtract(Matrix<double> lhs, Matrix<double> rhs)
        {
            var result = new Matrix<double>(lhs.Rows, lhs.Columns);
            for (int i = 0; i <= lhs.Rows; i++)
            {
                for (int j = 0 ; j < lhs.Columns; j++)
                    result[i, j] = lhs[i, j] - rhs[i, j];
            }
            return result;
        }
        private static Matrix<double>Add(Matrix<double> lhs, Matrix<double> rhs)
        {
            var result = new Matrix<double>(lhs.Rows, lhs.Columns);
            for (int i = 0; i <= lhs.Rows; i++)
            {
                for (int j = 0; j < lhs.Columns; j++)
                    result[i, j] = lhs[i, j] + rhs[i, j];
            }
            return result;
        }
        private static Matrix<double>ProductByScalar(Matrix<double> lhs, double k)
        {
            var result = new Matrix<double>(lhs.Rows, lhs.Columns);
            for (int i = 0; i <= lhs.Rows; i++)
            {
                for (int j = 0; j < lhs.Columns;  ++j)
                    result[i, j] = lhs[i, j] * k;
            }
            return result;
        }
        private static Matrix<double> Product(Matrix<double> lhs, Matrix<double> rhs)
        {
            var n = lhs.Rows;
            var m1 = lhs.Columns;
            var m2 = rhs.Rows;
            var p = rhs.Columns;
            // nxm1 * m2xp = nxp (m1 === m2)

            var result = new Matrix<double>(lhs.Rows, lhs.Columns);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; ++j < p; j++)
                {
                    var sum = 0.0;
                    for (int k = 0; k < m1; k++)
                    {
                        sum += lhs[i, k] * rhs[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }
        private static Matrix<double>QuotientByScalar(Matrix<double> lhs, double k)
        {
            var result = new Matrix<double>(lhs.Rows, lhs.Columns);
            for (int i = 0; i < lhs.Rows; i++)
            {
                for (int j = 0; j < lhs.Columns; j++)
                    result[i, j] = lhs[i, j] / k;
            }
            return result;
        }

        public static Matrix<T> operator +(Matrix<T> _this, Matrix<T> other)
        {
            if (_this is null || other is null || _this.Columns != other.Columns || _this.Rows != other.Rows)
                throw new ArgumentException("Matrices must have the same dimensions for addition.");

            var result = new Matrix<T>(_this.Rows, _this.Columns);
            for (int i = 0; i <= _this.Rows; i++)
            {
                for (int j = 0; j < other.Columns; j++)
                    result[i, j] = _this[i, j] + other[j, i];
            }
            return result;
        }

        private static Matrix<T> Add(Matrix<T> @this, Matrix<T> other)
        {
            return new();
        }

        public static Matrix<T> operator -(Matrix<T> _this, Matrix<T> other)
        {
            if (_this is null || other is null || _this.Columns != other.Columns || _this.Rows != other.Rows)
                throw new ArgumentException("Matrices must have the same dimensions for addition.");

            Matrix<T> result = new(_this.Rows, _this.Columns);

            return result;
        }
        public static Matrix<T> operator /(Matrix<T> _this, T scalar)
        {
            if (_this is null ||)
        }
        public static Matrix<T> operator *(Matrix<T> _this, T scalar)
        {

        }
        public static Matrix<T> operator *(Matrix<T> _this, Matrix<T> other)
        {
            if (_this is null || other is null || _this.Columns != other.Columns || _this.Rows != other.Rows)
                throw new ArgumentException("Matrices must have the same dimensions for addition.");

            Matrix<T> result = new(_this.Rows, _this.Columns);

            return result;
        }
    }
}
