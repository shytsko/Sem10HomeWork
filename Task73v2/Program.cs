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
// 
// Вариант 2

double n = ReadDouble("Введите число N = ");
double log2N = Math.Log2(n);
int countGroups = Convert.ToInt32(log2N - log2N % 1.0 + 1);
double[][] groups = new double[countGroups][];

double i = 1;
int indexGroup = 0;
double startNextGroup = Math.Min(Math.Pow(2, indexGroup + 1), n);
groups[indexGroup] = new double[Convert.ToInt32(startNextGroup - i)];
int k = 0;
while (i <= n)
{
    if (i == startNextGroup)
    {
        indexGroup++;
        startNextGroup = Math.Min(Math.Pow(2, indexGroup + 1), n + 1);
        groups[indexGroup] = new double[Convert.ToInt32(startNextGroup - i)];
        k = 0;
    }
    groups[indexGroup][k++] = i;
    i += 1;
}

Console.WriteLine($"Количество групп: {groups.Length}");
PrintGroups(groups);

void PrintGroups(double[][] groups)
{
    for (int i = 0; i < groups.Length; i++)
    {
        Console.Write($"Группа {i + 1}: ");
        for (int j = 0; j < groups[i].Length; j++)
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
