using System;
using System.Windows.Forms;

namespace courseWorkNew.Core
{
    public static class MatrixUtils
    {
        public static void DisplayToGrid(DataGridView grid, double[,] matrix)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
                grid.Columns.Add($"C{i}", "");

            for (int i = 0; i < rows; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(grid);
                for (int j = 0; j < rows; j++)
                    row.Cells[j].Value = matrix[i, j];
                grid.Rows.Add(row);
            }
        }

        public static double[,] ReadFromGrid(DataGridView grid)
        {
            int rows = grid.Rows.Count - 1;
            double[,] matrix = new double[rows, rows];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < rows; j++)
                    matrix[i, j] = Convert.ToDouble(grid.Rows[i].Cells[j].Value);

            return matrix;
        }

        public static double[,] Identity(int size)
        {
            var identity = new double[size, size];
            for (int i = 0; i < size; i++)
                identity[i, i] = 1.0;
            return identity;
        }

        public static double[,] GaussJordan(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] a = (double[,])matrix.Clone();
            double[,] inv = Identity(n);

            for (int i = 0; i < n; i++)
            {
                double diag = a[i, i];
                for (int j = 0; j < n; j++)
                {
                    a[i, j] /= diag;
                    inv[i, j] /= diag;
                }

                for (int k = 0; k < n; k++)
                {
                    if (k == i) continue;
                    double factor = a[k, i];
                    for (int j = 0; j < n; j++)
                    {
                        a[k, j] -= factor * a[i, j];
                        inv[k, j] -= factor * inv[i, j];
                    }
                }
            }

            return inv;
        }

        public static double[,] InvertUsingLUP(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] LU = (double[,])A.Clone();
            int[] pi = new int[n];
            for (int i = 0; i < n; i++) pi[i] = i;

            for (int k = 0; k < n; k++)
            {
                double p = 0.0;
                int kp = -1;
                for (int i = k; i < n; i++)
                {
                    if (Math.Abs(LU[i, k]) > p)
                    {
                        p = Math.Abs(LU[i, k]);
                        kp = i;
                    }
                }

                if (p == 0.0) throw new InvalidOperationException("Matrix is singular");

                int temp = pi[k]; pi[k] = pi[kp]; pi[kp] = temp;
                for (int i = 0; i < n; i++)
                {
                    double t = LU[k, i]; LU[k, i] = LU[kp, i]; LU[kp, i] = t;
                }

                for (int i = k + 1; i < n; i++)
                {
                    LU[i, k] /= LU[k, k];
                    for (int j = k + 1; j < n; j++)
                        LU[i, j] -= LU[i, k] * LU[k, j];
                }
            }

            double[,] inv = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                double[] e = new double[n];
                e[pi[i]] = 1.0;
                double[] y = new double[n];
                for (int j = 0; j < n; j++)
                {
                    y[j] = e[j];
                    for (int k = 0; k < j; k++)
                        y[j] -= LU[j, k] * y[k];
                }
                for (int j = n - 1; j >= 0; j--)
                {
                    inv[j, i] = y[j];
                    for (int k = j + 1; k < n; k++)
                        inv[j, i] -= LU[j, k] * inv[k, i];
                    inv[j, i] /= LU[j, j];
                }
            }

            return inv;
        }
    }
}
