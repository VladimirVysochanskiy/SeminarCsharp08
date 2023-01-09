/*Задайте прямоугольный двумерный массив. Напишите программу, которая будет
находить строку с наименьшей суммой элементов.  
Например, задан массив:  
    1 4 7 2  
    5 9 2 3  
    8 4 2 4  
    5 2 6 7  
Программа считает сумму элементов в каждой строке и выдаёт номер строки с 
наименьшей суммой элементов: 1 строка  */
//--------------------------------------------------------------------
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
int minStr = FindMinTotalString2DArray(myArray);
Console.WriteLine($"Наименьшая сумма элементов в строке {minStr + 1}");
Console.WriteLine();

//-------------------------------------------------------------------
//Метод Поиск строки с наименьшей суммой элементов
int FindMinTotalString2DArray(int[,] array)
{
    int minIndex = 0;
    int minTotal = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int strTotal = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            strTotal += array[i,j];    
        }
        if (i == 0) minTotal = strTotal;
        if (strTotal < minTotal) {
            minTotal = strTotal;
            minIndex = i;
        }
    }
    return minIndex;
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
