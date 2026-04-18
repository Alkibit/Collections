using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Alkibit.Collections.Samples
{
    public class Timer : MonoBehaviour, IOnUpdate
    {
        public TextMeshProUGUI text;
        public bool showMilliseconds;
        public TimerData timer;
        public UnityEvent onTimerEnd;

        private void Start()
        {
            timer.Reset();
        }

        public void OnUpdate()
        {
            timer.Tick(Time.deltaTime, onTimerEnd.Invoke);
            if (text != null) text.text = TimeFormatting.FormatTime(timer.timeLeft, showMilliseconds);
        }
    }
}