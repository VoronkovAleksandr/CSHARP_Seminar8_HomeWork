// ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

bool CheckRepeat(int[,,] matrix, int digit)
{
    int length = matrix.GetLength(0);
    int width = matrix.GetLength(1);
    int height = matrix.GetLength(2);
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < width; j++)
        {
            for (int k = 0; k < height; k++)
            {
                if (digit == matrix[i, j, k]) return true;
            }
        }
    }
    return false;
}

void PrintArray(int[,,] matr)
{
    int length = matr.GetLength(0);
    int width = matr.GetLength(1);
    int height = matr.GetLength(2);
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < width; j++)
        {
            for (int k = 0; k < height; k++)
            {
                Console.Write($"{matr[i, j, k]} ({i}, {j}, {k}) ");
            }
            Console.WriteLine();
        }
    }
}

void FillArray(int[,,] matr, int minValue, int maxValue)
{
    int length = matr.GetLength(0);
    int width = matr.GetLength(1);
    int height = matr.GetLength(2);
    int randNumber = 0;
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < width; j++)
        {
            for (int k = 0; k < height; k++)
            {
                while (CheckRepeat(matr, randNumber))
                {
                    randNumber = new Random().Next(minValue, maxValue);
                }
                matr[i, j, k] = randNumber;
            }
        }
    }
}

string DataEntry(string text)
{
    Console.Write(text);
    string result = Console.ReadLine();
    return result;
}

int x = Convert.ToInt32(DataEntry("Введите число столбцов: "));
int y = Convert.ToInt32(DataEntry("Введите число строк: "));
int z = Convert.ToInt32(DataEntry("Введите число слоев: "));
int[,,] matr = new int[x, y, z];
FillArray(matr, 10, 100);
PrintArray(matr);