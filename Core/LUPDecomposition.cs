using System;

namespace courseWorkNew.Core
{
    public static class LUPDecomposition
    {
        public static double[,] Invert(double[,] matrix)
        {
            return MatrixUtils.InvertUsingLUP(matrix);
        }
    }
}
