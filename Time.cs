using InputKeyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class Time
    {
        private int hours;
        private int minutes;
        private static int count = 0;

        public int Hours
        {
            get => this.hours;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Часы не могут быть отрицательными");
                    this.hours = 0;
                }
                else
                {
                    AdjustTime(value, this.minutes);
                }
            }
        }

        public int Minutes
        {
            get => this.minutes;
            set
            {
                if (value < 0 && hours <= 0)
                {
                    Console.WriteLine("Минуты не могут быть отрицательными");
                    this.minutes = 0;
                }
                else
                {
                    AdjustTime(this.hours, value);
                }
            }
        }

        private void AdjustTime(int hours, int minutes)
        {
            int totalMinutes = (hours * 60) + minutes;

            this.hours = totalMinutes / 60 % 24;
            this.minutes = totalMinutes % 60;

          
        }

        // Конструкторы, вызывают конструктор с двумя параметрами.
        public Time() : this(0, 0) {}
        public Time(int Hours) : this(Hours, 0) { } 
        public Time(int hours, int minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            count++;
        }

        // число созданных объектов
        public static int Count() => count;

        // число объектов к нулю
        public static void CounterErrase() => count = 0;

        // Перегрузка оператора вычитания
        // Метод для получения общего числа минут из объекта Time
        private static int GetTotalMinutes(Time time)
        {
            return time.Hours * 60 + time.Minutes;
        }

        // Метод для создания объекта Time из общего числа минут
        private static Time CreateTimeFromMinutes(int totalMinutes)
        {
            if (totalMinutes < 0)
            {
                totalMinutes = 0;
                Console.WriteLine("\nВычитаемое больше уменьшаего!");
            }

            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            return new Time(hours, minutes);
        }

        // Оператор вычитания
        public static Time operator -(Time time1, Time time2)
        {
            int totalMinutes = GetTotalMinutes(time1);
            int otherMinutes = GetTotalMinutes(time2);
            return CreateTimeFromMinutes(totalMinutes - otherMinutes);
        }

        // Метод вычитания из данного объекта
        public void SubTime(Time time2)
        {
            int totalMinutes = GetTotalMinutes(this);
            int otherMinutes = GetTotalMinutes(time2);
            Time resultTime = CreateTimeFromMinutes(totalMinutes - otherMinutes);
            this.Hours = resultTime.Hours;
            this.Minutes = resultTime.Minutes;
        }

        // Статический метод вычитания
        public static Time SubTime(Time time1, Time time2)
        {
            int totalMinutes = GetTotalMinutes(time1);
            int otherMinutes = GetTotalMinutes(time2);
            return CreateTimeFromMinutes(totalMinutes - otherMinutes);
        }
        // Вывод часов и минут
        public void PrintTime() => Console.WriteLine($"{Hours:D2}:{Minutes:D2}");

        // Ввод часов и минуn
        public void ReadTime()
        {
            Hours = EnterKeybord.TypeInteger("Введите часы: ", 0);
            Minutes = EnterKeybord.TypeInteger("Введите минуты: ", 0);
        }
        
        // Приведение к string
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}";

        // Унарная операция ++: добавление минуты к объекту типа Time
        public static Time operator ++(Time time)
        {
            return new Time(time.Hours, ++time.Minutes);
        }

        // Унарная операция --: вычитание минуты из объекта типа Time (учесть, что минут не может быть меньше 0)
        public static Time operator --(Time time)
        {
            return new Time(time.Hours, --time.Minutes);
        }

        // Операция приведения типа int (неявная): время переводится в минуты
        public static implicit operator int(Time time)
        {
            return GetTotalMinutes(time);
        }

        // Операция приведения типа bool (явная)
        // Результатом является true, если часы и минуты не равны нулю, и false в противном случае
        public static explicit operator bool(Time time)
        {
            return time.Hours != 0 || time.Minutes != 0;
        }


        // Бинарная операция < Time t1, Time t2 – время переводится в минуты
        // Результатом является true, если количество минут в левом операнде меньше, чем количество минут в правом операнде, и false – в противном случае
        public static bool operator <(Time t1, Time t2)
        {
            return GetTotalMinutes(t1) < GetTotalMinutes(t2);
        }

        // Бинарная операция > Time t1, Time t2 – время переводится в минуты
        // Результатом является true, если количество минут в левом операнде больше, чем количество минут в правом операнде, и false – в противном случае
        public static bool operator >(Time t1, Time t2)
        {
            return GetTotalMinutes(t1) > GetTotalMinutes(t2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Time time)
                return (this.Hours == time.Hours) && (this.Minutes == time.Minutes);
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
