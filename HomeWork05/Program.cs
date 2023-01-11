// Напишите программу, которая заполнит спирально массив 4 на 4.  
// Например, на выходе получается вот такой массив:  
//     01 02 03 04  
//     12 13 14 05  
//     11 16 15 06  
//     10 09 08 07  
//-------------------------------------------------------------------
Console.Clear();
Console.WriteLine("Создание массива заполненного по спирали");
int str = InputNumberControl("Введите количество строк: ");
int col = InputNumberControl("Введите количество столбцов: ");
int from = 0;
int to = 0;
Console.WriteLine();

int[,] myArray = CreateFill2DArrayRandom(str, col, from, to);

Fill2DArraySpiral(myArray);
PrintArray2D(myArray);
Console.WriteLine();

//-------------------------------------------------------------------
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
              System.Console.Write(String.Format("{0,4:00}", matr[i, j]));
        }
        System.Console.WriteLine();
    }
}

//Метод заполнения 2D массива по спирали.
void Fill2DArraySpiral(int[,] array)
{
    int i = 0;
    int j = 0;
    for (int k = 1; k <= array.Length; k++)
    {
        array[i,j] = k;
        if (i == 0 && j < array.GetLength(1) - 1) j++;
        else if (j == array.GetLength(1) - 1 && i < array.GetLength(0) - 1) i++;
        else if (i == array.GetLength(0) - 1 && j > 0) j--;
        else if (j == 0 && i > 1) i--;
        else if (j == 0 && i == 1) j++;
        else if (array[i-1,j] > 0 && array[i,j+1] == 0) j++;
        else if (array[i,j+1] > 0 && array[i+1,j] == 0) i++;
        else if (array[i+1,j] > 0 && array[i,j-1] == 0) j--;
        else if (array[i,j-1] > 0 && array[i-1,j] == 0) i--;
    }
}
