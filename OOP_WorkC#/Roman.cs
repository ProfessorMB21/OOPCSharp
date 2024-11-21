using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkC_
{
    public class Roman
    {
        Dictionary<int, string> intToRoman = new()
        {
            {1000, "M" },
            {900, "CM" },
            {500, "D" },
            {400, "CD" },
            {100, "C" },
            {90, "XC" },
            {50, "L" },
            {40, "XL" },
            {10, "X" },
            {9, "IX" },
            {5, "V"},
            {4, "IV" },
            {1, "I" }
        };

        Dictionary<char, int> romanToInt = new()
        {
            {'M', 1000 },
            {'D', 500 },
            {'C', 100 },
            {'L', 50 },
            {'X', 10 },
            {'V', 5 },
            {'I', 1 }
        };

        public int IntValue { get; private set; }
        public Roman() { }
        public Roman(int val)
        {
            if (val >= -3999 && val <= 3999)
            {
                IntValue = val;
            }
            else { throw new ArgumentOutOfRangeException(nameof(val), "Value out of range.."); }
        }
        public Roman(string val)
        {
            IntValue = FromRoman(val);
        }

        private int FromRoman(string roman)
        {
            roman = roman.ToUpper();
            int sum = 0, prev = 0;

            foreach(char c in roman)
            {
                if (!romanToInt.ContainsKey(c))
                {
                    // bug here
                    if (c == '-') { continue; }
                    else { throw new Exception($"Invalid Roman character: {c}"); }
                }

                int curr = romanToInt[c];
                sum += curr <= prev ? curr : curr - 2 * prev;
                prev = curr;
            }

            if (ToRoman(sum) != roman) { throw new Exception($"Invalid Roman numeral: {roman}"); }
            return sum;
        }

        private string ToRoman(int num)
        {
            if (num == 0) return "N";
            if (num < 0) return $"-{ToRoman(Math.Abs(num))}";

            string result = string.Empty;
            foreach (var pair in intToRoman)
            {
                while (num >= pair.Key)
                {
                    result += pair.Value;
                    num -= pair.Key;
                }
            }
            return result;
        }

        public override string ToString() => ToRoman(IntValue);

        public static Roman operator +(Roman _this, Roman other) => new Roman(_this.IntValue + other.IntValue);

        public static Roman operator -(Roman _this, Roman other) => new Roman(_this.IntValue - other.IntValue);

        public static Roman operator *(Roman _this, Roman other) => new Roman(_this.IntValue * other.IntValue);

        public static Roman operator /(Roman _this, Roman other)
        {
            if (other.IntValue != 0)
            {
                return new Roman(_this.IntValue / other.IntValue);
            } else { throw new DivideByZeroException($"Cannot divide by zero: {other}"); }
        }
    }
}
