// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


int[,] ProductOfArray(int[,] firstArr, int[,] secondArr)
{
    int columns = firstArr.GetLength(0);
    int rows = firstArr.GetLength(1);
    int[,] newArray = new int[rows, columns];
    int sum = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < columns; k++)
            {
                sum += firstArr[i, k] * secondArr[k, j];
            }
            newArray[i, j] = sum;
            sum = 0;
        }
    }
    return newArray;
}

void PrintArray(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"[{matr[i, j]}] ");
        }
        Console.WriteLine();
    }
}

void FillArray(int[,] matr, int minValue, int maxValue)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
}

string DataEntry(string text)
{
    Console.Write(text);
    string result = Console.ReadLine();
    return result;
}

int m = Convert.ToInt32(DataEntry("Введите размер прямоугольного массива: "));
int[,] fitstMatrix = new int[m, m];
int[,] secondMatrix = new int[m, m];
FillArray(fitstMatrix, 1, 10);
FillArray(secondMatrix, 1, 10);
PrintArray(fitstMatrix);
Console.WriteLine();
PrintArray(secondMatrix);
Console.WriteLine();
int[,] thirdMatrix = ProductOfArray(fitstMatrix, secondMatrix);
PrintArray(thirdMatrix);