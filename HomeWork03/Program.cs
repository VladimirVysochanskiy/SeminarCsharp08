/*Задайте две матрицы. Напишите программу, которая будет находить  
произведение двух матриц. Например, даны 2 матрицы:  
    2 4 | 3 4  
    3 2 | 3 3  
Результирующая матрица будет:  
    18 20  
    15 18  */
//-------------------------------------------------------------------
Console.Clear();
Console.WriteLine("ПРОИЗВЕДЕНИЕ ДВУХ МАТРИЦ");
Console.WriteLine("\nУмножить матрицы друг на друга можно в том случае, когда "
                 +"количество столбцов \nпервой матрицы равно количеству строк "
                 +"второй.");
int str1 = InputNumberControl("\nВведите размеры первой матрицы. \nСтрок: ");
int col1 = InputNumberControl("Столбцов: ");
str2Input:
int str2 = InputNumberControl("\nВведите размеры второй матрицы. \nСтрок: ");
if (str2 != col1) {
    Console.WriteLine($"Во второй матрице должно быть {col1} строк.");
    goto str2Input;
}
int col2 = InputNumberControl("Столбцов: ");
int fromNum = InputNumberControl("\nУкажите диапазон чисел для заполнения матриц. \nОт: ");
int toNum = InputNumberControl("До: ");

int[,] myArray1 = CreateFill2DArrayRandom(str1, col1, fromNum, toNum);
Console.WriteLine("Первая матрица:");
PrintArray2D(myArray1);

int[,] myArray2 = CreateFill2DArrayRandom(str2, col2, fromNum, toNum);
Console.WriteLine("Вторая матрица:");
PrintArray2D(myArray2);

int[,] productArray = Product2DArrays(myArray1, myArray2);
Console.WriteLine("Произведение двух матриц:");
PrintArray2D(productArray);

//Проверка на контрольном примере
// int[,] controlArray1 = {{2,4},{3,2}};
// PrintArray2D(controlArray1);
// int[,] controlArray2 = {{3,4},{3,3}};
// PrintArray2D(controlArray2);
// PrintArray2D(Product2DArrays(controlArray1,controlArray2));

//-------------------------------------------------------------------
//Метод Произведение 2D матриц
int[,] Product2DArrays(int[,] array1, int[,] array2)
{
    if (myArray1.GetLength(1) != myArray2.GetLength(0))
    {
        Console.WriteLine("\nОшибка! Умножить матрицы друг на друга можно в том случае, когда "
                     + "количество столбцов \nпервой матрицы равно количеству строк "
                     + "второй.");
        int[,] newArray = new int[2, 2];
        return newArray;
    }
    else
    {
        int[,] newArray = new int[array1.GetLength(0), array2.GetLength(1)];
        for (int i = 0; i < newArray.GetLength(0); i++)
        {
            for (int j = 0; j < newArray.GetLength(1); j++)
            {
                int temp = 0;
                for (int k = 0; k < array1.GetLength(1); k++)
                {
                    temp += array1[i,k] * array2[k,j];
                }
                newArray[i,j] = temp;
            }
        }
        return newArray;
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
    Console.WriteLine();
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            //System.Console.Write($" {matr[i, j]} ");
            System.Console.Write(String.Format("{0,4}", matr[i, j]));
        }
        System.Console.WriteLine();
    }
    Console.WriteLine();
}
