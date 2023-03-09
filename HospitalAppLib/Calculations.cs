using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppLib
{
    public class Calculations
    {
        /// <summary>
        /// Образование графика приемов специалиста с учетом записей на определенное время
        /// </summary>
        /// <param name="startTimes"> время записей </param>
        /// <param name="durations"> продолжительность записей </param>
        /// <param name="beginWorkingTime"> начало работы специалиста </param>
        /// <param name="endWorkingTime"> конец работы специалиста</param>
        /// <param name="consultationTime"> длительность работы специалиста </param>
        /// <returns> готовый лист времени приемов в виде строчного массива</returns>
        public string[] AvailablePeriods(TimeSpan[] startTimes,
            int[] durations,
            TimeSpan beginWorkingTime,
            TimeSpan endWorkingTime,
            int consultationTime
        )
        {
            if (consultationTime == 0)
            {
                throw new Exception("Вы неправильно ввели длительность приема");
            }
            if (durations != null && startTimes == null)
            {
                throw new Exception("Вы неправильно указали готовые приемы врачей");
            }
            if (durations == null && startTimes != null)
            {
                throw new Exception("Вы неправильно указали готовые приемы врачей");
            }

            if (beginWorkingTime == new TimeSpan())
            {
                throw new Exception("Вы неправильно указали начало работы специалиста");
            }
            if (endWorkingTime == new TimeSpan())
            {
                throw new Exception("Вы неправильно указали начало работы специалиста");
            }
            if (endWorkingTime.Hours - beginWorkingTime.Hours < 1)
            {
                throw new Exception("Специалист работает менее 1 часа");
            }
            List<string> periods = new List<string>();
            while (beginWorkingTime < endWorkingTime)
            {
                TimeSpan newWorkingTime;
                newWorkingTime = new TimeSpan(beginWorkingTime.Hours, beginWorkingTime.Minutes + consultationTime, beginWorkingTime.Seconds);
                string currentString = "";
                int i = 0;
                if (startTimes != null)
                {
                    foreach (var item in startTimes)
                    {
                        if (item == beginWorkingTime)
                        {
                            newWorkingTime = new TimeSpan(beginWorkingTime.Hours, beginWorkingTime.Minutes + durations[i], beginWorkingTime.Seconds);
                        }
                        i++;
                    }
                }


                if (newWorkingTime > endWorkingTime)
                {
                    break;
                }
                string starHours = "";
                string starMinutes = "";
                string endHours = "";
                string endMinutes = "";
                if (beginWorkingTime.Hours < 10)
                {
                    starHours = "0" + beginWorkingTime.Hours.ToString();
                }
                else
                {
                    starHours = beginWorkingTime.Hours.ToString();
                }
                if (beginWorkingTime.Minutes < 10)
                {
                    starMinutes = "0" + beginWorkingTime.Minutes.ToString();
                }
                else
                {
                    starMinutes = beginWorkingTime.Minutes.ToString();
                }

                if (newWorkingTime.Hours < 10)
                {
                    endHours = "0" + newWorkingTime.Hours.ToString();
                }
                else
                {
                    endHours = newWorkingTime.Hours.ToString();
                }
                if (newWorkingTime.Minutes < 10)
                {
                    endMinutes = "0" + newWorkingTime.Minutes.ToString();
                }
                else
                {
                    endMinutes = newWorkingTime.Minutes.ToString();
                }
                currentString = starHours + ":" + starMinutes + "-" + endHours + ":" + endMinutes;
                beginWorkingTime = newWorkingTime;
                periods.Add(currentString);
            }
            string[] strings = periods.ToArray();
            return strings;
        }
    }
}
