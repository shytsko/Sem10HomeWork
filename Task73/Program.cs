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
        if (IsNoDividersInGroup(i, groups[j]))
        {
            groups[j] = AddToGroup(i, groups[j]);
            isNumberAdded = true;
            break;
        }
    }
    if (!isNumberAdded)
    {
        groups = AddGroups(groups, new double[] { 1, i, 0, 0, 0, 0, 0, 0, 0, 0 });
    }
}

Console.WriteLine($"Количество групп: {groups.Length}");
PrintGroups(groups);

double[] AddToGroup(double value, double[] group)
{
    double[] temp;
    int sizeGroup = Convert.ToInt32(group[0]);

    if (sizeGroup == group.Length - 1)
    {
        temp = new double[group.Length * 2];
        for (int i = 0; i < group.Length; i++)
        {
            temp[i] = group[i];
        }
    }
    else
    {
        temp = group;
    }
    sizeGroup++;
    temp[0] = sizeGroup;
    temp[sizeGroup] = value;
    return temp;
}

double[][] AddGroups(double[][] sourceArray, double[] value)
{
    double[][] newArray = new double[sourceArray.Length + 1][];
    for (int i = 0; i < sourceArray.Length; i++)
    {
        newArray[i] = sourceArray[i];
    }
    newArray[newArray.Length - 1] = value;
    return newArray;
}

bool IsNoDividersInGroup(double value, double[] group)
{
    double halfValue = value / 2;
    for (int i = 1; i < group.Length && group[i] <= halfValue; i++)
    {
        if (value % group[i] == 0)
        {
            return false;
        }
    }
    return true;
}

void PrintGroups(double[][] groups)
{
    for (int i = 0; i < groups.Length; i++)
    {
        Console.Write($"Группа {i + 1}: ");
        int sizeGroup = Convert.ToInt32(groups[i][0]);
        for (int j = 1; j <= sizeGroup; j++)
        {
            Console.Write($"{groups[i][j]} ");
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
