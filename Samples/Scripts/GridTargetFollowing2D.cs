using UnityEngine;

namespace Alkibit.Collections.Samples
{
    public class GridTargetFollowing2D : MonoBehaviour
    {
        public TargetSearch.Target target;

        public int times = 1;
        public float cellSize = 1;
        public float frequency = 1;
        public LayerMask layerMask = 127;

        private int index;

        private void Start()
        {
            index = 0;
        }

        public void Move()
        {
            index++;
            if (index % frequency > 0.5f) return;

            Vector2Int targetPosition = Vector2Int.RoundToInt(target.position / cellSize);
            Vector2Int difference = targetPosition - Vector2Int.RoundToInt(transform.position / cellSize);
            Vector2Int way = Vector2Int.zero;

            if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
            {
                if (difference.x > 0)
                    way = Vector2Int.right;
                else
                    way = Vector2Int.left;
            }

            if (Mathf.Abs(difference.x) < Mathf.Abs(difference.y))
            {
                if (difference.y > 0)
                    way = Vector2Int.up;
                else
                    way = Vector2Int.down;
            }

            way *= times;
            transform.Translate((Vector2)way * cellSize);

            if (Physics2D.CircleCastAll(transform.position, 0.1f, Vector2.zero, 0f, layerMask).Length > 0)
            {
                transform.Translate(-(Vector2)way * cellSize);
            }
        }
    }
}