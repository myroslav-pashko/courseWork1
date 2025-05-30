using System;
using System.IO;

namespace courseWorkNew.Services
{
    public static class FileService
    {
        public static double[,] LoadFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            int size = lines.Length;
            var matrix = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                var parts = lines[i].Split(' ');
                for (int j = 0; j < size; j++)
                    matrix[i, j] = double.Parse(parts[j]);
            }
            return matrix;
        }

        public static void SaveToFile(double[,] matrix, string path)
        {
            using var writer = new StreamWriter(path);
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    writer.Write(matrix[i, j].ToString("F4"));
                    if (j < size - 1) writer.Write(" ");
                }
                writer.WriteLine();
            }
        }
    }
}
