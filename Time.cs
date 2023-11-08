using InputKeyboard;
using System;
using System.Collections.Generic;
using System.Linq;
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
            get { return hours; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Ошибка, количество часов не может быть меньше нуля!");
                else
                    hours = value;
            }
        }
        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Ошибка, количество минут не может быть меньше нуля!");
                else if (value > 59)
                {
                    Console.WriteLine("Ошибка, количество минут не может быть больше 59");
                }
                else
                    minutes = value;
            }
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

        // Перегрузка оператора вычитания
        public static Time operator -(Time time1, Time time2)
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

        // Вычитание из данного объекта (метод класса)
        public void SubTime(Time time2)
        {
            int totalMinutes = this.Hours * 60 + this.Minutes;
            int otherMinutes = time2.Hours * 60 + time2.Minutes;

            int resultMinutes = totalMinutes - otherMinutes;
            if (resultMinutes < 0)
            {
                resultMinutes = 0;

            }

            this.Hours = resultMinutes / 60;
            this.Minutes = resultMinutes % 60;
        }

        // Вычитание из данного объекта (статический метод)
        public static Time SubTime(Time time1, Time time2)
        {
            int totalMinutes = time1.Hours * 60 + time1.Minutes;
            int otherMinutes = time2.Hours * 60 + time2.Minutes;

            int resultMinutes = totalMinutes - otherMinutes;
            if (resultMinutes < 0)
            {
                resultMinutes = 0;
                Console.WriteLine("Вычитаемое больше уменьшаего!");
            }

            return new Time(resultMinutes / 60, resultMinutes % 60);
        }

        // Вывод часов и минут
        public void PrintTime() => Console.WriteLine($"{Hours:D2}:{Minutes:D2}");

        // Ввод часов и минуn
        public void ReadTime()
        {
            Hours = EnterKeybord.TypeInteger("Введите часы: ", 0);
            Minutes = EnterKeybord.TypeInteger("Введите минуты: ", 0, 60);
        }
        
        // Приведение к string
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}";

        // Унарная операция ++: добавление минуты к объекту типа Time
        public static Time operator ++(Time time)
        {
            if (time.Minutes + 1 >= 60)
            {
                time.Minutes = (time.Minutes + 1) % 60;
                time.Hours++;
            }
            return time;
        }

        // Унарная операция --: вычитание минуты из объекта типа Time (учесть, что минут не может быть меньше 0)
        public static Time operator --(Time time)
        {
            if (time.Minutes > 0)
            {
                time.Minutes--;
            }
            else if (time.Hours > 0)
            {
                time.Hours--;
                time.Minutes = 59;
            }
            return time;
        }

        // Операция приведения типа int (неявная): время переводится в минуты
        public static implicit operator int(Time time)
        {
            return time.Hours * 60 + time.Minutes;
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
            return t1.Hours * 60 + t1.Minutes < t2.Hours * 60 + t2.Minutes;
        }

        // Бинарная операция > Time t1, Time t2 – время переводится в минуты
        // Результатом является true, если количество минут в левом операнде больше, чем количество минут в правом операнде, и false – в противном случае
        public static bool operator >(Time t1, Time t2)
        {
            return t1.Hours * 60 + t1.Minutes > t2.Hours * 60 + t2.Minutes;
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
