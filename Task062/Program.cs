// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[] MoveUp(int[,] array, int[] position)
{
    int columns = array.GetLength(0);
    int rows = array.GetLength(1);
    int startRow = position[0];
    int startColumn = position[1];
    int count = array[startRow, startColumn];
    for (int i = startRow - 1; i >= rows - 1 - startRow; i--)
    {
        if (array[i, startColumn] == 0)
        {
            count++;
            array[i, startColumn] = count;
            position[0] = i;
        }
    }
    return position;
}

int[] MoveLeft(int[,] array, int[] position)
{
    int columns = array.GetLength(0);
    int rows = array.GetLength(1);
    int startRow = position[0];
    int startColumn = position[1];
    int count = 0;
    if (position[0] == 0 && position[1] == 0) count = 1;
    else count = array[position[0], position[1]];
    for (int i = startColumn - 1; i >= columns - 1 - startColumn; i--)
    {
        if (array[startRow, i] == 0)
        {
            count++;
            array[startRow, i] = count;
            position[1] = i;
        }
    }
    return position;
}

int[] MoveDown(int[,] array, int[] position)
{
    int columns = array.GetLength(0);
    int rows = array.GetLength(1);
    int startRow = position[0];
    int startColumn = position[1];
    int count = array[startRow, startColumn];
    for (int i = startRow + 1; i <= rows - 1 - startRow; i++)
    {
        if (array[i, startColumn] == 0)
        {
            count++;
            array[i, startColumn] = count;
            position[0] = i;
        }
    }
    return position;
}

int[] MoveRight(int[,] array, int[] position)
{
    int columns = array.GetLength(0);
    int rows = array.GetLength(1);
    int startRow = position[0];
    int startColumn = position[1];
    int count = 0;
    if (position[0] == 0 && position[1] == 0)
    {
        count = 1;
        array[0, 0] = count;
    }
    else count = array[startRow, startColumn];
    for (int i = startColumn + 1; i <= columns - 1 - startColumn; i++)
    {
        if (array[startRow, i] == 0)
        {
            count++;
            array[startRow, i] = count;
            position[1] = i;
        }
    }
    return position;
}

void PrintArray(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"[{matr[i, j].ToString("00")}] ");
        }
        Console.WriteLine();
    }
}

void FillArray(int[,] matr)
{
    int[] currentPosition = { 0, 0 };
    bool work = true;
    while (work)
    {
        currentPosition = MoveRight(matr, currentPosition);
        if (matr[currentPosition[0] + 1, currentPosition[1]] == 0) currentPosition = MoveDown(matr, currentPosition);
        if (matr[currentPosition[0], currentPosition[1] - 1] == 0) currentPosition = MoveLeft(matr, currentPosition);
        if (matr[currentPosition[0] - 1, currentPosition[1]] == 0) currentPosition = MoveUp(matr, currentPosition);
        if (matr[currentPosition[0], currentPosition[1] + 1] != 0) work = false;
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
FillArray(matr);
PrintArray(matr);
