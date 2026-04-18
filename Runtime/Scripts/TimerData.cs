using System;
using UnityEngine;

namespace Alkibit.Collections
{
    [Serializable]
    public class TimerData
    {
        public float startTime;
        public bool isLooping;
        [HideInInspector]
        public float timeLeft;
        public float speed = 1f;

        public bool Tick(float time, Action onEnd = null)
        {
            timeLeft -= time * speed;

            if (timeLeft > 0) return false;

            if (isLooping)
            {
                Reset();
            }

            onEnd?.Invoke();

            return true;
        }

        public void Reset()
        {
            timeLeft = startTime;
        }

        public bool IsTicking()
        {
            return 0 < timeLeft && timeLeft < startTime;
        }
    }
}
