using Alkibit.Physics;
using UnityEngine;

namespace Alkibit.Collections.Samples
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicsTargetFollowing2D : MonoBehaviour, IOnUpdate
    {
        public TargetSearch.Target target;
        public Tween tween;
        public float speed = 1f;

        public Vector2 offset;
        public QuickBoundaries.Boundary boundary = new();

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void OnUpdate()
        {
            Vector3 targetPosition = target.position + (Vector3)offset;

            targetPosition.z = transform.position.z;

            if (QuickBoundaries.IsInsideBoundary(transform.position, targetPosition, boundary)) return;

            rb.linearVelocity = ClassTween.TweenVector(transform.position, targetPosition, speed * Time.deltaTime, tween) - transform.position;
        }

        private void OnDrawGizmosSelected()
        {
            QuickBoundaries.DrawGizmos(boundary, transform.position - (Vector3)offset);
        }
    }
}