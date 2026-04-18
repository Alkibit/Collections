using UnityEngine;
using UnityEngine.Events;

namespace Alkibit.Collections.Samples
{
    public class PointsFollower : MonoBehaviour, IOnUpdate
    {
        public enum LoopType
        {
            Loop,
            Bounce,
            Random
        }

        public Transform points;
        public float speed;
        public UnityEvent onFinish;
        public LoopType loopType;

        public TimerData timer;

        private int pointIndex;
        private Transform[] allPoints;

        private bool isNormal;

        private void Start()
        {
            allPoints = new Transform[points.childCount];

            pointIndex = 0;
            foreach (Transform t in points)
            {
                allPoints.SetValue(t, pointIndex);
                pointIndex++;
            }
            pointIndex = 0;
            isNormal = true;
        }

        public void OnUpdate()
        {
            MoveToPoint();
        }

        void MoveToPoint()
        {
            Transform currentPoint = allPoints[pointIndex];
            if ((currentPoint.position - transform.position).magnitude < 0.05f)
            {
                NextPoint();
                return;
            }

            Move((currentPoint.position - transform.position).normalized * speed);
        }

        void NextPoint()
        {
            if (!timer.IsTicking())
                timer.Reset();

            if (!timer.Tick(Time.deltaTime)) return;

            switch (loopType)
            {
                case LoopType.Random:
                    pointIndex = Random.Range(0, allPoints.Length);
                    break;

                case LoopType.Loop:
                    if (RotatePoints()) pointIndex = 0;
                    break;

                case LoopType.Bounce:
                    if (RotatePoints(isNormal))
                    {
                        isNormal = !isNormal;
                        RotatePoints(isNormal);
                    }
                    break;
            }
        }

        private bool RotatePoints(bool isNormal = true)
        {
            if (isNormal)
            {
                pointIndex++;
                if (pointIndex >= allPoints.Length)
                    return true;
            }
            else
            {
                pointIndex--;
                if (pointIndex < 0)
                    return true;
            }
            return false;
        }

        private void Move(Vector3 amount)
        {
            transform.position += amount * Time.deltaTime;
        }
    }
}