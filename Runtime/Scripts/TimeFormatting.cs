using UnityEngine;

namespace Alkibit.Collections
{
    public static class TimeFormatting
    {
        public static string FormatTime(float time, bool showMilliseconds = false)
        {
            int hours = Mathf.FloorToInt(time / 3600);
            int minutes = Mathf.FloorToInt(time % 3600 / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            int milliseconds = Mathf.FloorToInt((time - Mathf.Floor(time)) * 100);

            string formattedTime = "";

            if (hours > 0)
            {
                formattedTime += hours.ToString() + ":";
                formattedTime += minutes.ToString() + ":";
                formattedTime += seconds;
            }
            else if (minutes > 0)
            {
                formattedTime += minutes.ToString() + ":";
                formattedTime += seconds.ToString();
                if (showMilliseconds)
                {
                    formattedTime += "." + milliseconds;
                }
            }
            else
            {
                formattedTime += seconds.ToString();
                if (showMilliseconds)
                {
                    formattedTime += "." + milliseconds;
                }
            }

            return formattedTime;
        }
    }
}