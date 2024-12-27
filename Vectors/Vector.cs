using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    public class Vector<T> where T : struct, INumber<T>
    {
        private T _x1;
        private T _y1;
        private T _x2;
        private T _y2;

        public Vector(T x, T y)
        {
            _x2 = x;
            _y2 = y;
        }

        public Vector(T x1, T y1, T x2, T y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        public static Vector<T> operator +(Vector<T> _this, Vector<T> other) => new(
            _this._x1,
            _this._y1,
            _this._x2 + other._x2 - other._x1,
            _this._y2 + other._y2 - other._y1
            );

        public Vector<T> ShiftVector(Vector<T> _this) => new(
            _x1 + _this._x2 - _this._x1,
            _y1 + _this._y2 - _this._y1,
            _x2 + _this._x2 - _this._x1,
            _y2 + _this._y2 - _this._y1
            );

        public static Vector<T> operator *(Vector<T> _this, T alpha) => (alpha > T.Zero) ? new(
            _this._x1,
            _this._y1,
            _this._x2 * alpha,
            _this._y2 * alpha
            ) :
            new(
                -_this._x1,
                -_this._y1,
                _this._x2 * alpha,
                _this._y2 * alpha
                );

        public static Vector<T> operator -(Vector<T> _this) => new(_this._x2, _this._y2, _this._x1, _this._y1);

        public override string ToString()
        {
            return $"({_x1}, {_y1}) -> ({_x2}, {_y2})";
        }
    }
}
