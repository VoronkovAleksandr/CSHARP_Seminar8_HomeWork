// Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.

void ChangeArray(int[,] arr)
{
    int columns = arr.GetLength(0);
    int rows = arr.GetLength(1);
    int temp = 0;
    int count = 0;

    for (int i = 0; i < rows; i++)
    {
        count = columns;
        for (int j = 0; j < columns; j++)
        {
            for (int k = 1; k < count; k++)
            {
                if (arr[i, k] > arr[i, k - 1])
                {
                    temp = arr[i, k];
                    arr[i, k] = arr[i, k - 1];
                    arr[i, k - 1] = temp;
                }
            }
            count--;
        }
    }
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

int m = Convert.ToInt32(DataEntry("Введите число столбцов: "));
int n = Convert.ToInt32(DataEntry("Введите число строк: "));
int[,] matr = new int[m, n];
FillArray(matr, -10, 10);
PrintArray(matr);
Console.WriteLine();
ChangeArray(matr);
PrintArray(matr);