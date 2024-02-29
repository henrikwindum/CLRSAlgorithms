using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library.Chapter04
{
    public class MatrixOperations
    {
        public static int[,] Multiply(int[,] matrixA, int[,] matrixB)
        {
            int numRowsA = matrixA.GetLength(0);
            int numColsA = matrixA.GetLength(1);

            int numRowsB = matrixB.GetLength(0);
            int numColsB = matrixB.GetLength(1);

            if (!(numColsA == numRowsB))
            {
                string errorMessage = "Matrices not compatible for multiplication. Got matrixA dim {0}x{1} & matrixB dim {2}x{3}.";
                throw new Exception(String.Format(errorMessage, numRowsA, numColsA, numRowsB, numColsB));
            }

            int[,] matrixC = new int[numRowsA, numColsB];

            for (int i = 0; i < numRowsA; i++)
            {
                for (int j = 0; j < numColsB; j++)
                {
                    for (int k = 0; k < numColsA; k++)
                    {
                        matrixC[i, j] = matrixC[i, j] + matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }

        public static int[,] Strassen(int[,] matrixA, int[,] matrixB)
        {
            if (!MatricesCompatible(matrixA, matrixB))
            {
                throw new ArgumentException("Matrices are not compatible.");
            }

            int n = matrixA.GetLength(0);

            if (n == 1)
            {
                int[,] C = new int[1, 1];
                C[0, 0] = matrixA[0, 0] * matrixB[0, 0];
                return C;
            }

            int newSize = n / 2;
            int[,] A11 = new int[newSize, newSize];
            int[,] A12 = new int[newSize, newSize];
            int[,] A21 = new int[newSize, newSize];
            int[,] A22 = new int[newSize, newSize];

            int[,] B11 = new int[newSize, newSize];
            int[,] B12 = new int[newSize, newSize];
            int[,] B21 = new int[newSize, newSize];
            int[,] B22 = new int[newSize, newSize];

            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    A11[i, j] = matrixA[i, j];
                    A12[i, j] = matrixA[i, j + newSize];
                    A21[i, j] = matrixA[i + newSize, j];
                    A22[i, j] = matrixA[i + newSize, j + newSize];

                    B11[i, j] = matrixB[i, j];
                    B12[i, j] = matrixB[i, j + newSize];
                    B21[i, j] = matrixB[i + newSize, j];
                    B22[i, j] = matrixB[i + newSize, j + newSize];
                }
            }

            int[,] P1 = Strassen(A11, MatrixSub(B12, B22));
            int[,] P2 = Strassen(MatrixAdd(A11, A12), B22);
            int[,] P3 = Strassen(MatrixAdd(A21, A22), B11);
            int[,] P4 = Strassen(A22, MatrixSub(B21, B11));
            int[,] P5 = Strassen(MatrixAdd(A11, A22), MatrixAdd(B11, B22));
            int[,] P6 = Strassen(MatrixSub(A12, A22), MatrixAdd(B21, B22));
            int[,] P7 = Strassen(MatrixSub(A11, A21), MatrixAdd(B11, B12));

            int[,] C11 = MatrixAdd(MatrixSub(MatrixAdd(P5, P4), P2), P6);
            int[,] C12 = MatrixAdd(P1, P2);
            int[,] C21 = MatrixAdd(P3, P4);
            int[,] C22 = MatrixSub(MatrixSub(MatrixAdd(P1, P5), P3), P7);

            int[,] matrixC = new int[n, n];
            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    matrixC[i, j] = C11[i, j];
                    matrixC[i, j + newSize] = C12[i, j];
                    matrixC[i + newSize, j] = C21[i, j];
                    matrixC[i + newSize, j + newSize] = C22[i, j];
                }
            }

            return matrixC;
        }

        private static int[,] MatrixSub(int[,] matrixA, int[,] matrixB)
        {
            int rows = matrixA.GetLength(0);
            int cols = matrixA.GetLength(1);

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            return result;
        }

        private static int[,] MatrixAdd(int[,] matrixA, int[,] matrixB)
        {
            int rows = matrixA.GetLength(0);
            int cols = matrixA.GetLength(1);

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    result[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return result;
        }

        private static bool IsPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }

        private static bool MatricesCompatible(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            return rowsA == colsA && rowsA == rowsB && colsA == colsB && IsPowerOfTwo(rowsA);
        }

        public static int[,] InitializeRandomSquareMatrix(int size, int minValue, int maxValue)
        {
            int[,] matrix = new int[size, size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue + 1); // Random().Next - minValue inclusive, maxValue exclusive
                }
            }

            return matrix;
        }

        public static bool AreMatricesEqual(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.GetLength(0) != matrixB.GetLength(0) || matrixA.GetLength(1) != matrixB.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (matrixA[i, j] != matrixB[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreMatricesEqualParallel(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.GetLength(0) != matrixB.GetLength(0) || matrixA.GetLength(1) != matrixB.GetLength(1))
            {
                return false;
            }

            int rows = matrixA.GetLength(0);
            int cols = matrixA.GetLength(1);

            bool equal = true;

            Parallel.For(0, rows, (i, state) =>
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrixA[i, j] != matrixB[i, j])
                    {
                        equal = false;
                        state.Break();
                    }
                }
            });

            return equal;
        }
    }
}
