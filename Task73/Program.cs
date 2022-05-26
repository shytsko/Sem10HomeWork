// Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, так чтобы в одной группе все числа были
// взаимно просты (все числа в группе друг на друга не делятся)? Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.
// Можно использовать рекурсию.
// Например, для N = 50, M получается 6
// Группа 1: 1
// Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
// Группа 5: 7 16 24 36 40
// Группа 6: 5 32 48

// Или
// Группа 1: 1
// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
// Группа 5: 16 24 36 40
// Группа 6: 32 48

double[][] groups = new double[0][];
double n = ReadDouble("Введите число N = ");

for (double i = 1; i <= n; i += 1)
{
    bool isNumberAdded = false;
    for (int j = 0; j < groups.Length; j++)
    {
        if (IsPrimeForGroup(i, groups[j]))
        {
            groups[j] = AddToArrayOfDouble(groups[j], i);
            isNumberAdded = true;
            break;
        }
    }
    if (!isNumberAdded)
    {
        groups = AddToArrayOfDoubleArrays(groups, new double[] { i });
    }
}

Console.WriteLine($"Количество групп: {groups.Length}");
PrintGroups(groups);

double[] AddToArrayOfDouble(double[] sourceArray, double value)
{
    double[] newArray = new double[sourceArray.Length + 1];
    for (int i = 0; i < sourceArray.Length; i++)
    {
        newArray[i] = sourceArray[i];
    }
    newArray[newArray.Length - 1] = value;
    return newArray;
}

double[][] AddToArrayOfDoubleArrays(double[][] sourceArray, double[] value)
{
    double[][] newArray = new double[sourceArray.Length + 1][];
    for (int i = 0; i < sourceArray.Length; i++)
    {
        newArray[i] = sourceArray[i];
    }
    newArray[newArray.Length - 1] = value;
    return newArray;
}

bool IsPrimeForGroup(double value, double[] group)
{
    for (int i = 0; i < group.Length; i++)
    {
        //if (value % group[i] == 0)
        if (GCD(value, group[i]) != 1)
        {
            return false;
        }
    }
    return true;
}

double GCD(double a, double b)
{
    if (a < b)
    {
        double temp = a;
        a = b;
        b = temp;
    }
    return (b != 0) ? GCD(b, a % b) : a;
}

void PrintGroups(double[][] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"Группа {i + 1}: ");
        for (int j = 0; j < array[i].Length; j++)
        {
            Console.Write($"{array[i][j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

double ReadDouble(string message)
{
    Console.Write(message);
    return Convert.ToDouble(Console.ReadLine());
}
