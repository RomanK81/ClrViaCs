using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ClrViaDotNet
{
    public static class Program
    {

        public static void Main()
        {
            //MatrixConvert();

        }


        //public static void MatrixConvert()
        //{
        //    var h1 = new int[4, 3]
        //    {
        //        { 1, 2, 3 },
        //        { 3, 4, 5 },
        //        { 5, 6, 7 },
        //        { 7, 8, 9 },
        //    };

        //    foreach(var c in h1)
        //    {
        //        Console.Write($"{c},");
        //    }
        //    Console.Write(Environment.NewLine + Environment.NewLine);

        //    var h2 = new int[4, 3]
        //    {
        //        { 11, 21, 31 },
        //        { 31, 41, 51 },
        //        { 51, 61, 71 },
        //        { 71, 81, 91 },
        //    };

        //    var l1 = new List<int[,]>(5) { h1, h2};

        //    int[,] sum = new int[4, 3];
        //    int[] maxH = new int[4]; 

        //    int maxHistVal = 70;

        //    foreach (var h in l1)
        //    {
        //        for (int i = 0; i < h.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < h.GetLength(1); j++)
        //            {
        //                sum[i, j] += h[i, j];
        //                Console.Write(string.Format("{0} ", sum[i, j]));
        //                maxH[i] = sum[i, j] > maxH[i] ? sum[i, j] : maxH[i];
        //            }
        //            Console.Write(Environment.NewLine + Environment.NewLine);
        //        }
        //    }
        //    Console.Write(Environment.NewLine + Environment.NewLine);
        //    Console.WriteLine("***********************MAX***************************");
        //    Console.WriteLine("[{0}]", string.Join(", ", maxH));
        //    Console.WriteLine("*****************************************************");

        //    ushort[,] res2 = new ushort[4, 3];
        //    for (int i = 0; i < sum.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < sum.GetLength(1); j++)
        //        {
        //            if (maxH[i] > maxHistVal)
        //                res2[i, j] = (ushort)(sum[i, j] * maxHistVal / maxH[i]);
        //            else
        //                res2[i, j] = (ushort)(sum[i, j]);

        //            Console.Write(string.Format("{0} ", res2[i, j]));
        //        }
        //        Console.Write(Environment.NewLine + Environment.NewLine);
        //    }
        //    Console.ReadLine();

        //}
    }

}
