using Lab_9;
using Menu;

static Time subTime(Time time1, Time time2)
{
    int totalMinutes = time1.Hours * 60 + time1.Minutes;
    int otherMinutes = time2.Hours * 60 + time2.Minutes;

    int resultMinutes = totalMinutes - otherMinutes;
    if (resultMinutes < 0)
    {
        resultMinutes = 0;
    }

    int resultHours = resultMinutes / 60;
    resultMinutes %= 60;

    return new Time(resultHours, resultMinutes);
}


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
    result.SubTime(time2);
    Console.WriteLine($"result - time2 (метод класса): {result}");
    Console.WriteLine($"time1 - time2 (отдельно от класса): {subTime(time1, time2)}");
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
    Console.WriteLine("++time1 : " + incrementedTime);  // Выведет: 4:46

    Time decrementedTime = --time1;
    Console.WriteLine("--time1 : " + decrementedTime);  // Выведет: 4:45

    int minutes = time1; //неявно
    Console.WriteLine("Явное преобразование к int: " + minutes);  // Выведет: 285

    bool isNotEmpty = (bool)time1; //явно
    Console.WriteLine("Неявное преобразование к bool: " + isNotEmpty);  // Выведет: true

    bool isLessThan = time1 < time2;
    Console.WriteLine("time1 < time2 : " + isLessThan);  // Выведет: false
    
    bool isGreaterThan = time1 > time2;
    Console.WriteLine("time1 > time2 : " + isGreaterThan);  // Выведет: true
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

    Console.WriteLine("Element at index 2 in Array 3: " + array3[2]);
    array3[2] = new Time(15, 45);
    Console.WriteLine("Updated Array 3:");
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

