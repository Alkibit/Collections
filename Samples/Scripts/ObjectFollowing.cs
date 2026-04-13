using Alkibit.Collections;
using Alkibit.Physics;
using UnityEngine;

namespace Alkibit.Collections.Demo
{
    public class ObjectFollowing : MonoBehaviour, IOnUpdate
    {

        public TargetSearch.Target target;
        public Tween tween;
        public float speed = 1f;
        public Vector3 offset;
        public QuickBoundaries.Boundary boundary = new();

        public void OnUpdate()
        {
            Vector3 targetPosition = target.position + offset;

            if (QuickBoundaries.IsInsideBoundary(transform.position, targetPosition, boundary)) return;

            transform.position = ClassTween.TweenVector(transform.position, targetPosition, speed * Time.deltaTime, tween);
        }

        private void OnDrawGizmosSelected()
        {
            QuickBoundaries.DrawGizmos(boundary, transform.position - offset);
        }
    }
}