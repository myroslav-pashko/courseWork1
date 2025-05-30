using System;

namespace courseWorkNew.Core
{
    public static class MatrixGenerator
    {
        public static double[,] GenerateRandom(int size)
        {
            var rnd = new Random();
            var matrix = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = rnd.Next(-10, 11);
            return matrix;
        }
    }
}
