using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClrViaDotNet
{
    public static class Array2DExtensions
    {
        public static IEnumerable<T> GetRow<T>(this T[,] array, int row)
        {
            for (int i = 0; i <= array.GetUpperBound(1); ++i)
                yield return array[row, i];
        }

        public static IEnumerable<T> GetColumn<T>(this T[,] array, int column)
        {
            for (int i = 0; i <= array.GetUpperBound(0); ++i)
                yield return array[i, column];
        }
    }
}
