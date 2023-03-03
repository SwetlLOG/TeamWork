
using System;

static class MatrixExt
{
  // метод расширения для получения кол-ва строк 
  public static int RowsCount(this int[,] matrix)
  {
    return matrix.GetUpperBound(0) + 1;
  }
  //метод расширения для получения кол-ва столбцов
  public static int ColumsCount(this int[,] matrix)
  {
    return matrix.GetUpperBound(0) + 1;
  }
}
//Метод получения матрицы из консоли
class Programm
{
  static int[,] GetMatrixFromConsole(string name)
  {
    Console.Write("Количество строк матрицы {0}:  ", name);
    var n = int.Parse(Console.ReadLine());

    Console.Write("Количество столбцов матрицы {0}:  ", name);
    var m = int.Parse(Console.ReadLine());

    var matrix = new int[n, m];
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        Console.Write("{0} [{1}, {2}] =  ", name, i, j);
        matrix[i, j] = int.Parse(Console.ReadLine());
      }
    }
    return matrix;
  }

  //метод печати матрицы в консоль

  void PrintMatrix(int[,] matrix)
  {
    for (var i = 0; i < matrix.RowsCount(); i++)
    {
      for (var j = 0; j < matrix.ColumsCount(); j++)
      {
        Console.Write(((byte)matrix[i, j]).ToString().PadLeft(4));
      }
      Console.WriteLine();
    }
  }

  //Метод перемножения массива
  static int MultiplicationArray(int[,] matrixA, int[,] matrixB)
  {
    if (matrixA.ColumsCount() != matrixB.RowsCount())
    {
      throw new Exception("Умножение невозможно, количество столбцов первой матрицы не равно кол-ву строк второй");
    }
    var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

    for (var i = 0; i < matrixA.RowsCount(); i++)
    {
      for (var j = 0; j < matrixB.ColumnsCount(); j++)
      {
        matrixC[i, j] = 0;

        for (var k = 0; k < matrixA.ColumnsCount(); k++)
        {
          matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
        }
      }
    }

    return matrixC;
  }

  static void Main(string[] args)
  {
    Console.WriteLine("Программа для умножения матриц");

    var a = GetMatrixFromConsole("A");
    var b = GetMatrixFromConsole("B");

    Console.WriteLine("Матрица A:");
    PrintMatrix(a);

    Console.WriteLine("Матрица B:");
    PrintMatrix(b);

    var result = MatrixMultiplication(a, b);
    Console.WriteLine("Произведение матриц:");
    PrintMatrix(result);

    Console.ReadLine();
  }
}


