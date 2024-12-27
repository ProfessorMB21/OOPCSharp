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

    class InvalidDimensionsException : Exception
    {
        private int _invalidRowValue;
        private int _invalidColumnValue;
        public InvalidDimensionsException(int row, int col)
            : base($"{nameof(row)}={row} and {nameof(col)}={col} cannot be less than or equal to zero.")
        {
            _invalidColumnValue= col;
            _invalidRowValue= row;
        }
    }

    public class Matrix<T> : IMatrix<T> where T : INumber<T>
    {
        private T[,] _array;
        public int Rows => _array.GetLength(0);
        public int Columns => _array.GetLength(1);
        public Matrix() { _array = new T[0, 0]; }
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new InvalidDimensionsException(rows, columns);
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

        public static Matrix<T> operator +(Matrix<T> _this, Matrix<T> other)
        {
            if (_this is null || other is null || _this.Columns != other.Columns || _this.Rows != other.Rows)
                throw new ArgumentException("Matrices must have the same dimensions for addition.");

            Matrix<T> result = new(_this.Rows, _this.Columns);
            for (int i = 0; i <= _this.Rows; i++)
                for (int j = 0; j < other.Columns; j++)
                    result[i, j] = _this[i, j] + other[i, j];
            return result;
        }
        public static Matrix<T> operator -(Matrix<T> _this, Matrix<T> other)
        {
            if (_this is null || other is null || _this.Columns != other.Columns || _this.Rows != other.Rows)
                throw new ArgumentException("Matrices must have the same dimensions for addition.");

            Matrix<T> result = new(_this.Rows, _this.Columns);
            for (int i = 0; i < _this.Rows; i++)
                for (int j = 0; j < _this.Columns; j++)
                    result[i, j] = _this[i, j] - other[i, j];
            return result;
        }
        public static Matrix<T> operator /(Matrix<T> _this, T scalar)
        {
            if (_this is null || scalar == T.Zero)
                throw new ArgumentException($"Value {((T.IsZero(scalar) == true) ? nameof(scalar) : nameof(_this))} cannot be null or have a zero value of type {typeof(T)}.");
            //if (scalar == T.Zero) throw new DivideByZeroException($"{nameof(scalar)} cannot be zero. Division by zero not allowed.");

            Matrix<T> result = new(_this.Rows, _this.Columns);
            for (int i = 0; i < _this.Rows; i++)
                for (int j = 0; j < _this.Columns; j++)
                    result[i, j] = _this[i, j] / scalar;
            return result;
        }
        public static Matrix<T> operator *(Matrix<T> _this, T scalar)
        {
            if (_this is null) throw new ArgumentException($"Value {nameof(_this)} cannot be null.");
            Matrix<T> result = new(_this.Rows, _this.Columns);

            for (int i = 0; i < _this.Rows; i++)
                for (int j = 0; j < _this.Columns; j++)
                    result[i, j] = _this[i, j] * scalar;
            return result;
        }
        public static Matrix<T> operator *(Matrix<T> _this, Matrix<T> other)
        {
            if (_this is null || other is null || _this.Columns != other.Columns || _this.Rows != other.Rows)
                throw new ArgumentException("Matrices must have the same dimensions for addition.");

            var n = _this.Rows;
            var m1 = _this.Columns;
            var m2 = other.Rows;
            var p = other.Columns;
            // nxm1 * m2xp = nxp (m1 === m2)
            
            Matrix<T> result = new(_this.Rows, other.Columns);
            for (int i = 0; i < n; i++)
                for (int j = 0; ++j < p; j++)
                    for (int k = 0; k < m1; k++)
                        result[i, j] += _this[i, k] * other[k, j];
            return result;
        }
    }
}
