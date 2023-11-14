using Lab_9;
using Menu;
using System.Net.Http.Headers;

static void Task1()
{
    Console.WriteLine("Задание 1");
    var time1 = new Time();
    time1.ReadTime();

    var time2 = new Time();
    time2.ReadTime();

    Console.WriteLine($"Первый объект: {time1}\nВторой объект: {time2}");
    Console.WriteLine();

    Time result = time1 - time2;
    Console.WriteLine($"result = time1 - time2 (оператор -): {result}");

    time1.SubTime(time2);
    Console.WriteLine($"time1.SubTime(time2) (метод класса): {result}");

    Console.WriteLine($"Time.SubTime(time1, time2) (статический метод): {Time.SubTime(time1, time2)}");

    Console.WriteLine();
    Console.WriteLine("Кол-во созданных объектов: " + Time.Count());
}

static void Task2()
{
    var time1 = new Time();
    time1.ReadTime();
    var time2 = new Time();
    time2.ReadTime();

    Console.WriteLine($"Первый объект: {time1}\nВторой объект: {time2}");

    Time incrementedTime = ++time1;
    Console.WriteLine("++time1 : " + incrementedTime); 

    Time decrementedTime = --time1;
    Console.WriteLine("--time1 : " + decrementedTime); 

    int minutes = time1; //неявно
    Console.WriteLine("Явное преобразование к int: " + minutes);  

    bool isNotEmpty = (bool)time1; //явно
    Console.WriteLine("Неявное преобразование к bool: " + isNotEmpty);  

    bool isLessThan = time1 < time2;
    Console.WriteLine("time1 < time2 : " + isLessThan);  

    bool isGreaterThan = time1 > time2;
    Console.WriteLine("time1 > time2 : " + isGreaterThan);  
}


static void MaxTime(TimeArray arr)
{
    if (arr == null || arr.Size == 0)
    {
        Console.WriteLine("Пустой массив Time");
    }
    else
    {
        Time maxTime = arr[0];
        for (int i = 0; i < arr.Size; i++)
        {
            if (maxTime < arr[i])
                maxTime = arr[i];
        }
        Console.WriteLine($"Максимальное значение: {maxTime}");
    }
}
static void Task3()
{
    var array1 = new TimeArray();
    Console.WriteLine("Array 1:");
    array1.Display();

    Console.WriteLine();

    var array2 = new TimeArray(5);
    Console.WriteLine("Array 2:");
    array2.Display();

    Console.WriteLine();

    var array3 = new TimeArray(
        new Time(10, 30),
        new Time(25, 15),
        new Time(12, 0)
    );
    Console.WriteLine("Array 3:");
    array3.Display();

    Console.WriteLine();

    Console.WriteLine("Элемент под 3 номером: " + array3[2]);
    array3[2] = new Time(15, 45);
    Console.WriteLine("Изменение на 15:45 под 3 номер:");
    array3.Display();
    MaxTime(array3);
}

var dialog = new Dialog(new[]
{
    new Options("Задание 1", Task1),
    new Options("Задание 2", Task2),
    new Options("Задание 3", Task3)
});

dialog.Start();
