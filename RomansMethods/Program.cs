// --------------------safe input number
int inputNumberPrompt(string str)
{
    int number;
    string text;

    while (true)
    {
        Console.Write($"{str} ");
        text = Console.ReadLine();
        if (int.TryParse(text, out number))
        {
            break;
        }
        Console.WriteLine("Не удалось распознать число, попробуйте еще раз.");
    }
    return number;
}

// --------------------safe input double number
double inputNumberPromptDouble(string str)
{
    System.Console.WriteLine("При вводе десятичного разделителя");
    System.Console.WriteLine("в зависимости от настроек региона");
    System.Console.WriteLine("нужно набрать \",\" или \".\".");
    double number;
    string text;

    while (true)
    {
        Console.Write($"{str} ");
        text = Console.ReadLine();
        if (double.TryParse(text, out number))
        {
            break;
        }
        Console.WriteLine("Не удалось распознать число, попробуйте еще раз.");
    }
    return number;
}

// --------------------fill ARRAY int numbers
void arrayFill(int[,] arr, int left, int right)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = GetRandomFrom(left, right);
        }
    }
}

// --------------------RANDOM NUMBER from - to
int GetRandomFrom(int bottom, int top)
{
    Random rnd = new Random();
    int result = rnd.Next(bottom, top + 1);
    return result;
}

// --------------------fill ARRAY double
void arrayFill(double[,] arr, int left, int right, int digits)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = Math.Round(GetRandomFrom(left, right), digits);
        }
    }
}

// --------------------RANDOM NUMBER from - to (not included) -------------------
double GetRandomFrom(int bottom, int top)
{
    Random rnd = new Random();
    return bottom + rnd.NextDouble() * (top - bottom);
}

// --------------------PRINT 2dARRAY
void printArray(double[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        System.Console.Write("[ ");
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            System.Console.Write("\t " + arr[i, j]);
        }
        System.Console.Write("\t]");
        System.Console.WriteLine();
    }
}