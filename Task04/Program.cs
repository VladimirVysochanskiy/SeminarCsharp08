//Задача 59: Задайте двумерный массив из целых чисел. Напишите программу, 
//которая удалит строку и столбец, на пересечении которых расположен 
//наименьший элемент массива. Например, задан массив:
//  1 4 7 2
//  5 9 2 3
//  8 4 2 4
//  5 2 6 7
//Наименьший элемент - 1, на выходе получим следующий массив:
//  9 4 2
//  2 2 6
//  3 4 7

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

int[,] newMyArray = StrAndColDeletingForMinItem(myArray);
PrintArray2D(newMyArray);
Console.WriteLine();

//Метод удаления строки и столбца на пересечении первого мин значения
int[,] StrAndColDeletingForMinItem(int[,] array)
{
    int min = array[0,0];
    int x = 0;
    int y = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
           if (min > array[i,j]) {
            min = array[i,j];
            x = i;
            y = j;
           }
        }
    } 
    
    int[,] newArray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    int k = 0;
    int h = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if(i == x) continue;
        h = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j == y) continue;
            newArray[k,h] = array[i,j];
            h++;
        }
        k++;
    }
    return newArray;
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
