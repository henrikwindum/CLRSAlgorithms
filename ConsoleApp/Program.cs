using Library;
using Library.Chapter04;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrixA = MatrixOperations.InitializeRandomSquareMatrix(512, 0, 1);
            int[,] matrixB = MatrixOperations.InitializeRandomSquareMatrix(512, 0, 1);

            int[,] result1 = MatrixOperations.Strassen(matrixA, matrixB);
            int[,] result2 = MatrixOperations.Multiply(matrixA, matrixB);

            // Print the result matrix
            Console.WriteLine("Result of Matrix Multiplication:");
            for (int i = 0; i < result1.GetLength(0); i++)
            {
                for (int j = 0; j < result1.GetLength(1); j++)
                {
                    Console.Write(result1[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Print the result matrix
            Console.WriteLine("Result of Matrix Multiplication:");
            for (int i = 0; i < result2.GetLength(0); i++)
            {
                for (int j = 0; j < result2.GetLength(1); j++)
                {
                    Console.Write(result2[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
