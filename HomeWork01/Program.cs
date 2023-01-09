/*Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию  
элементы каждой строки двумерного массива.  
Например, задан массив:  
    1 4 7 2  
    5 9 2 3  
    8 4 2 4  
В итоге получается вот такой массив:  
    7 4 2 1  
    9 5 3 2  
    8 4 4 2  */

Console.Clear();
Console.WriteLine("Создаётся двумерный массив наполненный случайными целыми "
                 + "числами.");
int str = InputNumberControl("Введите количество строк: ");
int col = InputNumberControl("Введите количество столбцов: ");
Console.WriteLine("Введите границы диапазона случайных чисел.");
int from = InputNumberControl("От: ");
int to = InputNumberControl("До: ");
Console.WriteLine();

int[,] myArray = CreateFill2DArrayRandom(str, col, from, to);
PrintArray2D(myArray);
Console.WriteLine();

SortElemOfString2DArrayMaxMin(myArray);
Console.WriteLine("Элементы строк отсортированы в порядке убывания:");
PrintArray2D(myArray);
Console.WriteLine();

//Метод Сортировка элементов строк 2D массива по убыванию
void SortElemOfString2DArrayMaxMin(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1) - 1; j++)
        {
            int maxPosition = j;

            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i,k] > array[i,maxPosition]) maxPosition = k;
            }

            int temporary = array[i,j];
            array[i,j] = array[i,maxPosition];
            array[i,maxPosition] = temporary;
        }
    }
}

//Метод Создание и рандомное наполнение 2D int массива
int[,] CreateFill2DArrayRandom(int strings, int columns, int fromNum, int toNum)
{
    int[,] array = new int[strings, columns];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(fromNum, toNum);
        }
    }
    return array;
}

//Метод контроль ввода целого числа
int InputNumberControl(string text)
{
    System.Console.Write(text);
    int number;
    while (true)
    {
        string? txt = (Console.ReadLine());
        if (int.TryParse(txt, out number))
        {
            break;
        }
        System.Console.Write("Введенное значение не является натуральным числом. Попробуйте ещё раз: ");
    }
    return number;
}

//Метод Печать 2D массива равнение право.
void PrintArray2D(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            //System.Console.Write($" {matr[i, j]} ");
            System.Console.Write(String.Format("{0,4}", matr[i, j]));
        }
        System.Console.WriteLine();
    }
}

//Метод Сортировка элементов 1D массива по убыванию
/*void ArraySortMaxMin(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int maxPosition = i;

        for (int j = i + 1; j < array.Length; j++)
        {
            if(array[j] > array[maxPosition]) maxPosition = j;
        }

        int temporary = array[i];
        array[i] = array[maxPosition];
        array[maxPosition] = temporary;
    }
} */
