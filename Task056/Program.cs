// Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

void FindMinSumRow(int[,] arr)
{
    int columns = arr.GetLength(0);
    int rows = arr.GetLength(1);
    int sum = 0;
    int minRow = 0;
    int minSumRow = 100 * rows;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            sum += arr[i, j];
        }
        if (sum < minSumRow)
        {
            minRow = i;
            minSumRow = sum;
        }
        sum = 0;
    }
    Console.WriteLine($"Сторка №{minRow + 1} имеет минимальную сумму {minSumRow}");
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
int[,] matr = new int[m, m];
FillArray(matr, 10, 100);
PrintArray(matr);
Console.WriteLine();
FindMinSumRow(matr);