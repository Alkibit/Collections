using Alkibit.Collections;
using UnityEngine;

namespace Alkibit.Collections.Demo
{
    public class DespawnableObject : MonoBehaviour, IOnUpdate
    {
        public WaitTimerData timer;

        private void Start() => timer.Reset();

        public void OnUpdate()
        {
            if (timer.Tick(Time.deltaTime)) Destroy(gameObject); 
        }
    }
}