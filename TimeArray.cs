using InputKeyboard;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class TaskThreeTime
    {
        public static Time? MaxTime(TimeArray arr)
        {
            if (arr == null || arr.Size == 0)
            {
                Console.WriteLine("Пустой массив Time");
                return null;
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
                return maxTime;
            }
        }
    }

    public class TimeArray
    {
        static private int count = 0;
        private Time[] arr;
        public int Size => arr.Length;
        public static int Count() => count;

        public static void CounterErrase() => count = 0;

        public TimeArray() : this(0) { }  
        
        public TimeArray(int size)
        {
            if (size < 0)
            {
                Console.WriteLine("Размер не может быть меньше 0");
                size = 0;
            }
            arr = new Time[size];
            var random = new Random();

            for (int i = 0; i < size; i++)
            {
                int hours = random.Next(0, 24);
                int minutes = random.Next(0, 60);

                arr[i] = new Time(hours, minutes);
            }
            count++;
        }

        public TimeArray(bool console)
        {
            int newSize = EnterKeybord.TypeInteger("Введите количество элементов: ", 0);
            arr = new Time[newSize];
            for (int i = 0; i < Size; i++)
            {
                arr[i] = new Time();
                arr[i].ReadTime();
            }
            count++;
        }

        public TimeArray(params Time[] times)
        {
            arr = new Time[times.Length];

            for (int i = 0; i < times.Length; i++)
            {
                arr[i] = times[i];
            }
        }

        public void Display()
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
            }
            foreach (Time time in arr)
            {
                time.PrintTime();
            }
        }

        public Time this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Выход за границы.");
                }
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                {
                    arr[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Выход за границы.");
                }
            }
        }

    }
}
