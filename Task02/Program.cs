//Задача 55: Задайте двумерный массив. Напишите программу, которая заменяет 
//строки на столбцы. В случае, если это невозможно, программа должна вывести 
//сообщение для пользователя.

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

int[,] newMyArray = ChangeStringToColumn2DArray(myArray);
PrintArray2D(newMyArray);
Console.WriteLine();


//Метод замены строк на столбцы
int[,] ChangeStringToColumn2DArray(int[,] array)
{
    int[,] newArray = new int[array.GetLength(1), array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            newArray[j,i] = array[i,j];
        }
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

