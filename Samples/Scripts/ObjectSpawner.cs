using System.Collections.Generic;
using UnityEngine;

namespace Alkibit.Collections.Demo
{
    public class ObjectSpawner : MonoBehaviour, IOnUpdate
    {

        [System.Serializable]
        public class SpawningData
        {
            public GameObject prefab;
            public int times;

            public SpawningData(SpawningData data)
            {
                prefab = data.prefab;
                times = data.times;
            }
        }

        public SpawningData[] data;

        public List<GameObject> prefabs;
        public Transform points;

        public Curve curve;
        public bool usesTimer = true;

        [Space(16)]

        public int round;

        private TimerData timer;

        private void Start()
        {
            timer = new TimerData();
            timer.Reset();
            round = 0;
            timer.isLooping = true;
            timer.startTime = curve.curve.Evaluate(round);

            foreach (SpawningData sd in data)
            {
                for (int i = 0; i < sd.times; i++)
                    prefabs.Add(sd.prefab);
            }
        }

        public void OnUpdate()
        {
            if (usesTimer) timer.Tick(Time.deltaTime, Spawn);
        }

        void Spawn()
        {
            Transform[] children = new Transform[points.childCount];

            int index = 0;

            foreach (Transform t in points)
            {
                children.SetValue(t, index);
                index++;
            }

            Summon(children.GetRandomItem().position);

            if (usesTimer)
            {
                round++;
                timer.startTime = curve.curve.Evaluate(round);
                timer.Reset();
            }
        }

        void Summon(Vector3 position)
        {
            GameObject go = Instantiate(prefabs.GetRandomItem());

            go.transform.position += position;
        }

        [ContextMenu("Set Curve")]
        public void SetCurve()
        {
            curve.SetCurve();
        }
    }
}