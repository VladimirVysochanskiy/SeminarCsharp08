// Сформируйте трёхмерный массив из двузначных чисел. Напишите программу,  
// которая будет построчно выводить массив, добавляя индексы каждого элемента.  
// Массив размером 2 x 2 x 2  
//     66(0,0,0) 25(0,1,0)  
//     34(1,0,0) 41(1,1,0)  
//     27(0,0,1) 90(0,1,1)  
//     26(1,0,1) 55(1,1,1)  
//-------------------------------------------------------------------

Console.Clear();
Console.WriteLine("Создаётся трёхмерный массив наполненный случайными целыми "
                 + "числами.");
int str = InputNumberControl("Введите количество строк: ");
int col = InputNumberControl("Введите количество столбцов: ");
int lay = InputNumberControl("Введите количество слоёв: ");
Console.WriteLine("Введите границы диапазона случайных чисел.");
int from = InputNumberControl("От: ");
int to = InputNumberControl("До: ");
Console.WriteLine();

int[,,] myArray = CreateFill3DArrayRandom(str, col, lay, from, to);
PrintArray3DIndexes(myArray);

//-------------------------------------------------------------------
//Метод Создание и рандомное наполнение 3D int массива
int[,,] CreateFill3DArrayRandom(int strings, int columns, int layers, int fromNum, int toNum)
{
    int[,,] array = new int[strings, columns, layers];
    for (int k = 0; k < array.GetLength(2); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j, k] = new Random().Next(fromNum, toNum);
            }
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

//Метод Печать значений и индексов 3D массива равнение право.
void PrintArray3DIndexes(int[,,] matr)
{
    for (int k = 0; k < matr.GetLength(2); k++)
    {
        for (int i = 0; i < matr.GetLength(0); i++)
        {
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                System.Console.Write(String.Format("{0,4}({1},{2},{3})", matr[i, j, k],i,j,k));
            }
            System.Console.WriteLine();
        }
    }
    System.Console.WriteLine();
}

