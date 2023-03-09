using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Matrix
{
    public int[,] matrix { get; set; }


    public Matrix(int[,] matrix)
    {
        this.matrix = matrix;
    }
}

class NumberOperation : Matrix
{
    public int[,] matrix2 { get; set; }
    public int number { get; set; }
    public NumberOperation(int number, int[,] matrix2, int[,] matrix) : base(matrix) 
    {
        this.number = number;
        this.matrix2 = matrix2;
    }
    public void matrixPlus() {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int f = 0; f < matrix.GetLength(1); f++)
            {
                matrix[i, f] = matrix[i, f] + matrix2[i, f];
                Console.WriteLine(matrix[i, f]);
            }
        }
    }
    public void matrixMinus()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int f = 0; f < matrix.GetLength(1); f++)
            {
                matrix[i, f] = matrix[i, f] - matrix2[i, f];
                Console.WriteLine(matrix[i, f]);
            }
        }
    }

    public void multiplicationByNumber()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int f = 0; f < matrix.GetLength(1); f++)
            {
                matrix[i, f] = matrix[i, f] * number;
                Console.WriteLine(matrix[i, f]);
            }
        }
    }

}

class MultiplicationMatrix : Matrix
{
    public int[,] matrix2 { get; set; }
    public MultiplicationMatrix(int[,] matrix2, int[,] matrix) : base(matrix)
    {
        this.matrix2 = matrix2;
    }

    public void multiplication()
    {
        if (matrix.GetLength(1) != matrix2.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
        int[,] r = new int[matrix.GetLength(0), matrix2.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                for (int k = 0; k < matrix2.GetLength(0); k++)
                {
                    r[i, j] += matrix[i, k] * matrix2[k, j];
                   
                }
                Console.Write("{0} ", r[i, j]);
            }
        }
    }
}

class TranspositionMatrix : Matrix
{
    public TranspositionMatrix(int[,] matrix) : base(matrix)
    {
    }
    
    public void transposition()
    {
        int[,] qq = new int[matrix.GetLength(0), matrix.GetLength(1)];
        int a = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {          
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                qq[i,j] = matrix[j,i];
                
                
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write("{0,3}", qq[i, j]);

        Console.WriteLine("");

    }
}

public class Program
{
    public static void Main()
    {
        int[,] matrix =
            { { 3, 2, 10 },
            { 3, 4, 5 },
            { 3, 2, 6 } };
        int[,] matrix2 = { { 1, 2 }, { 1, 2 } };
      
        NumberOperation matrixOb = new NumberOperation(2, matrix, matrix2);
        MultiplicationMatrix matrixOb2 = new MultiplicationMatrix(matrix, matrix2);
        TranspositionMatrix matrixOb3 = new TranspositionMatrix(matrix);
        matrixOb3.transposition();
        //matrixOb2.multiplication();
        //matrixOb.matrixPlus();
        //matrixOb.matrixMinus();
        //matrixOb.multiplicationByNumber();
    }
}