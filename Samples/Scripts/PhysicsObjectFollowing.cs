using Alkibit.Physics;
using UnityEngine;

namespace Alkibit.Collections.Samples
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsTargetFollowing : MonoBehaviour, IOnUpdate
    {

        public TargetSearch.Target target;
        public Tween tween;
        public float speed = 1f;

        public Vector3 offset;
        public QuickBoundaries.Boundary boundary = new();

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnUpdate()
        {
            Vector3 targetPosition = target.position + offset;

            if (QuickBoundaries.IsInsideBoundary(transform.position, targetPosition, boundary)) return;

            rb.linearVelocity = ClassTween.TweenVector(transform.position, targetPosition, speed * Time.deltaTime, tween) - transform.position;
        }

        private void OnDrawGizmosSelected()
        {
            QuickBoundaries.DrawGizmos(boundary, transform.position - offset);
        }
    }
}