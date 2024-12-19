using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix<T>
    {
        private T[][] _data;
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Matrix() 
        {
            Rows = Columns = 1;
            CreateArray(Rows, Columns);
        }
        public Matrix(int rows, int cols)
        {
            if (rows < 1 || cols < 1) 
            {
                throw new ArgumentOutOfRangeException($"{(rows < 1 ? nameof(rows) : nameof(cols))} out of range"); 
            }
            Rows = rows;
            Columns = cols;
            CreateArray(Rows, Columns);
        }
        public Matrix(T[] arr)
        {
            Rows = 1;
            Columns = arr.Length - 1;
            CreateArray(Rows, Columns, arr);
        }
        public Matrix(T[][] arr)
        {
            Rows = arr.Length - 1;
            Columns = arr[0].Length - 1;
            CreateArray(Rows, Columns, [], arr);
        }

        private void CreateArray(int rows, int cols)
        {
            if (arr1 is not null && arr2 is null)
            {
                _data = new T[rows][];
                for (int i = 0; i < rows; i++)
                {
                    _data[i] = new T[cols];
                }
            }
            
        }
        private void FillMatrix(T[][] dest, [Optional] T[][] arr1, [Optional] T[] arr2)
        {

        }
        
        public T this[int i, int j]
        {
            get
            {
                if ((i >= 0 && j >= 0) && (i < Rows && j < Columns))
                {
                    throw new ArgumentOutOfRangeException($"{(i < 0 ? nameof(i) : nameof(j))} out of array range.");
                }
                return _data[i][j];
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach(var item in _data)
            {
                sb.Append($"{item.ToString()} ");
            }
            return sb.ToString();
        }
    }
}
