using Alkibit.Physics;
using UnityEngine;

namespace Alkibit.Collections.Samples
{
    public class TargetFollowing2D : MonoBehaviour, IOnUpdate
    {

        public TargetSearch.Target target;
        public Tween tween;
        public float speed = 1f;

        public Vector2 offset;
        public QuickBoundaries.Boundary boundary = new();

        public void OnUpdate()
        {
            Vector3 targetPosition = target.position + (Vector3)offset;

            targetPosition.z = transform.position.z;

            if (QuickBoundaries.IsInsideBoundary(transform.position, targetPosition, boundary)) return;

            transform.position = ClassTween.TweenVector(transform.position, targetPosition, speed * Time.deltaTime, tween);
        }

        private void OnDrawGizmosSelected()
        {
            QuickBoundaries.DrawGizmos(boundary, transform.position - (Vector3)offset);
        }
    }
}