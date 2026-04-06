using System.Linq;
using UnityEngine;

namespace Alkibit.Collections
{
    public class UpdateManager : MonoBehaviour
    {
        [Header("UpdateManager")]
        public static bool IsPaused { get; private set; }
        public static UpdateManager Instance { get; private set; }

        private void Start() => Instance = this;

        private void Update()
        {
            if (IsPaused) return;

            foreach(MonoBehaviour behaviour in FindObjectsByType<MonoBehaviour>())
            {
                if(behaviour.GetType().GetInterfaces().Contains(typeof(IOnUpdate)))
                {
                    if (!behaviour.enabled) continue;
                    ((IOnUpdate)behaviour).OnUpdate();
                }
            }
        }

        private void FixedUpdate()
        {
            if (IsPaused) return;

            Physics2D.Simulate(Time.fixedDeltaTime);
        }

        private void OnApplicationPause(bool pause) { if (pause) { Pause(); } }

        public static void Pause() =>
            IsPaused = true;

        public static void Resume() =>
            IsPaused = false;

        public static void TogglePause() =>
            IsPaused = !IsPaused;
    }
}