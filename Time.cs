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
        private static int count = 0;
        public int Hours { get; set; }
        public int Minutes { get; set; }


        // Конструкторы, вызывают конструктор с двумя параметрами.
        public Time() : this(0, 0) {}
        public Time(int Hours) : this(Hours, 0) { } 
        public Time(int hours, int minutes)
        {
            Hours = hours > 0 ? hours % 24 : 0;
            Minutes = minutes > 0 ? minutes % 60 : 0;
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

        // Вычитание из данного объекта
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
        
        // Вывод часов и минут
        public void PrintTime() => Console.WriteLine($"{Hours:D2}:{Minutes:D2}");

        // Ввод часов и минуn

        public void ReadTime()
        {
            Hours = EnterKeybord.TypeInteger("Введите часы: ", 0, 24);
            Minutes = EnterKeybord.TypeInteger("Введите минуты: ", 0, 60);
        }
        
        // Приведение к string
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}";

        // Унарная операция ++: добавление минуты к объекту типа Time
        public static Time operator ++(Time time)
        {
            time.Minutes++;
            if (time.Minutes >= 60)
            {
                time.Minutes %= 60;
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

    }
}
