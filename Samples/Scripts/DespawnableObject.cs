using UnityEngine;

namespace Alkibit.Collections.Samples
{
    public class DespawnableObject : MonoBehaviour, IOnUpdate
    {
        public Collections.Timer timer;

        private void Start() => timer.Reset();

        public void OnUpdate()
        {
            if (timer.Tick(Time.deltaTime)) Destroy(gameObject);
        }
    }
}