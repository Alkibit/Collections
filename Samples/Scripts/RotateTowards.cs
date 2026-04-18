using UnityEngine;

namespace Alkibit.Collections.Samples
{
    public class RotateTowards : MonoBehaviour, IOnUpdate
    {
        public float offset;
        public TargetSearch.Target target;

        public void OnUpdate()
        {
            Vector3 difference = target.position - transform.position;

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);
        }
    }
}