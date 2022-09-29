// Задача 25: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
//3, 5 -> 243 (3⁵)
// Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// Задача 29: Напишите программу, которая задаёт массив из N элементов и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// задача (задача со звёздочкой): Напишите программу, которая задаёт массив из 10 элементов, 
// которые необходимо заполнить случайными значениями в диапазоне от -10 до 10 и найти максимальное значение среди них.
// [-1, 2, 4, 6, -7, 9, -3, -4, -6 ,1] -> 9
// задача 2 (задача со звёздочкой): Напишите программу, которая задаёт 2 одномерных массива из N элементов которые заполняются 
// случайными значениями в диапазоне от 1 до 10 и находит среднее арифметическое элементов этих 2 массивов, далее от большего 
// из получившихся средних арифметических отнимаем меньшее и округлённый до целого числа результат переводим в двоичную систему счисления.
// [1,2,3,4] [3,6,4] -> округлённая до целого числа разница между средними арифметическими массивов = 2. 2 
// в двоичной системе счисления = 10

Console.Clear();
Console.WriteLine("Задача 25: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.");
Console.WriteLine("Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.");
Console.WriteLine("Задача 29: Напишите программу, которая задаёт массив из N элементов и выводит их на экран.");
Console.WriteLine("Задача 1: (задача со звёздочкой): Напишите программу, которая задаёт массив из 10 элементов,");
Console.WriteLine("которые необходимо заполнить случайными значениями в диапазоне от -10 до 10 и найти максимальное значение среди них.");
Console.Write("Введите номер задачи: ");
int task = Convert.ToInt32(Console.ReadLine());
switch (task){
    case 25: 
        Console.Clear();
        Console.Write("Введите первое число: ");
        int numA = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int numB = Convert.ToInt32(Console.ReadLine());
        Exponenet(numA,numB);
        break;
    case 27: 
        Console.Clear();
        Console.Write("Введите первое число: ");
        int num = Convert.ToInt32(Console.ReadLine());
        SumNumber(num);
        break;
        
    case 29: 
        Console.Clear();
        Console.Write("Введите размер массива: ");
        int size = Convert.ToInt32(Console.ReadLine());
        int[] newArray = FillArray(size);
        Console.Write(String.Join(", ", newArray)); 
        break;
    case 1:
        Console.Clear();
        int[] someArray = FillArray2(10, -10, 10);
        int maximum = FindMax(someArray);
        Console.WriteLine($"максимальное число в массиве [{String.Join(", ", someArray)}] - это {maximum}");
        break;
    case 2:
        Console.Clear();
        Console.Write("Введите размер массива: ");
        int sizeN = Convert.ToInt32(Console.ReadLine());
        Task2(sizeN);

        break;

    default: Console.WriteLine("Неправильный ввод");
            break;
}

void Exponenet(int num1, int num2){
    int result = num1;
    for (int i = 2; i <= num2; i++){
        result = result*num1;
    }
    Console.WriteLine($"{num1} в {num2}-й степени равно {result}");
}

void SumNumber(int number){
    int result = number;
    int count = 0;
    while(result > 0){
        result = result / 10;
        count ++;
    }
    int[] array = new int[count];
    for (int i = count -1; i >= 0; i--){
        array[i] = number % 10;
        number = number / 10;
    }
    int sum = array[0];
    for(int i = 1; i < array.Length; i ++){
        sum = sum + array[i];
    }
    Console.WriteLine($"Сумма цифр в числе{number} равна {sum}");
}

int[] FillArray(int n)
{
    int[] array = new int[n];
    int index = 0;
    while(index < n)
    {
        array[index] = new Random().Next(1, 100);
        index ++;
    }
    return array;
}

int[] FillArray2(int n, int from, int to)
{
    int[] array = new int[n];
    int index = 0;
    while(index < n)
    {
        array[index] = new Random().Next(from, to);
        index ++;
    }
    return array;
}

int FindMax(int[] array){
    int max = array[0];
    for (int i = 1; i < array.Length; i++){
        if(array[i] > max) max = array[i];
    }
    return max;
}

double Average(int[] array){
    int sum = 0;
    int count = 0;
    for (int i = 0; i < array.Length; i++){
        sum = sum + array[i];
        count = count + 1;
    }
    double result = sum / count;
    return result;
}
int[] ConvertNumber(int number){
    int size = 1;
    int result = number;
    while (number > 1){
        number = number / 2;
        size ++;
    }
        int[] array = new int[size];
    for (int i = size -1; i >= 0; i--){
        array[i] = result % 2;
        result = result / 2;
    }
   return array;

}
void Task2(int arraySize){
    int[] array1 = FillArray2(arraySize, 1, 10);
    int[] array2 = FillArray2(arraySize, 1, 10);
    double num1 = Average(array1);
    double num2 = Average(array2);
    double diff = 0;
    if(num1 < num2) diff = num2 - num1;
    else diff = Math.Round(num1 - num2, 0);
    int result = Convert.ToInt32(diff);
    int[] newNumber = ConvertNumber(result);
    Console.Write("Первый массив: ");
    Console.WriteLine(String.Join(",", array1));
    Console.WriteLine($"Среднее арифметическое первого массива - {num1} ");
    Console.Write("Первый массив: ");
    Console.WriteLine(String.Join(",", array2));
    Console.WriteLine($"Среднее арифметическое первого массива - {num2} ");
    Console.Write($"разница будет - {result}, в двоичной системе это - ");
    Console.WriteLine(String.Join(" ",newNumber));

}



