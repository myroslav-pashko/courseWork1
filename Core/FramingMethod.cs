using System;

namespace courseWorkNew.Core
{
    public static class FramingMethod
    {
        public static double[,] Invert(double[,] matrix)
        {
            return MatrixUtils.GaussJordan(matrix);
        }
    }
}
