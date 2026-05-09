using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Alkibit.Collections
{
    /// <summary>
    /// A basic Timer class used for timers and countdowns
    /// </summary>
    [Serializable]
    public class Timer
    {
        public float startTime;
        [ReadOnly]
        public float time;
        [HideInInspector]
        public UnityEvent onEnd;

        /// <summary>
        /// Makes the timer tick by time amount
        /// </summary>
        /// <param name="time">The timestep of the timer</param>
        /// <returns>if the timer has ended or not</returns>
        public virtual bool Tick(float time)
        {
            this.time -= time;

            if (this.time < 0)
            {
                if (onEnd != null) onEnd.Invoke();
                return true;
            }

            return false;
        }

        public void Reset()
        {
            time = startTime;
        }
    }

    /// <summary>
    /// A basic Timer class, that loops
    /// </summary>
    [Serializable]    
    
    public class LoopingTimer : Timer
    {
        public override bool Tick(float time)
        {
            base.time -= time;
            if (base.time < 0)
            {
                if(onEnd != null) onEnd.Invoke();
                Reset();
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// A basic Timer class, that counts up, instead of down
    /// </summary>
    public class UptimeTimer : Timer
    {
        public override bool Tick(float time)
        {
            base.time += time;
            return false;
        }
    }

    [Serializable]
    public class FlexibleTimer: Timer
    {
        public bool isCountUp;
        [HideIf("@isCountUp")]
        public bool isLooping;

        public override bool Tick(float time)
        {
            if (isCountUp)
                base.time += time;
            else
                base.time -= time;

            if (base.time < 0)
            {
                if (onEnd != null) onEnd.Invoke();

                if (isLooping)
                    Reset();
                return true;
            }
            return false;
        }
    }
}
