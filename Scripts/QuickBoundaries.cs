using System;
using UnityEngine;

namespace Alkibit.Physics
{
    public static class QuickBoundaries
    {
        [Serializable]
        public class BoxBoundary
        {
            public Vector3 size = new(2, 2, 0);
        }

        [Serializable]
        public class SphereBoundary
        {
            public float radius = 1;
        }

        [Serializable]
        public class Boundary
        {
            public enum BoundaryType
            {
                None,
                Box,
                Sphere,
            }
            public BoxBoundary box = new();
            public SphereBoundary sphere = new();
            public BoundaryType type = BoundaryType.Box;
        }

        public static bool IsInsideBoundary(Vector3 position, Vector3 point, Boundary boundary)
        {
            switch (boundary.type)
            {
                case Boundary.BoundaryType.Box:
                    return IsInsideBox(position, point, boundary.box);
                case Boundary.BoundaryType.Sphere:
                    return IsInsideSphere(position, point, boundary.sphere);
                case Boundary.BoundaryType.None:
                    return true;
                default:
                    break;
            }
            return false;
        }

        private static bool IsInsideBox(Vector3 boxPosition, Vector3 point, BoxBoundary box)
        {
            float halfX = box.size.x * 0.5f;
            float halfY = box.size.y * 0.5f;
            float halfZ = box.size.z * 0.5f;

            return point.x >= boxPosition.x - halfX && point.x <= boxPosition.x + halfX &&
                   point.y >= boxPosition.y - halfY && point.y <= boxPosition.y + halfY &&
                   point.z >= boxPosition.z - halfZ && point.z <= boxPosition.z + halfZ;
        }


        private static bool IsInsideSphere(Vector3 spherePosition, Vector3 point, SphereBoundary circle)
        {
            return (spherePosition - point).sqrMagnitude <= circle.radius * circle.radius;
        }

        private static void DrawBoxGizmos(BoxBoundary box, Vector3 position) =>
            Gizmos.DrawWireCube(position, box.size);

        private static void DrawSphereGizmos(SphereBoundary sphere, Vector3 position) =>
            Gizmos.DrawWireSphere(position, sphere.radius);

        public static void DrawGizmos(Boundary boundary, Vector3 position)
        {
            switch (boundary.type)
            {
                case Boundary.BoundaryType.Box:
                    DrawBoxGizmos(boundary.box, position); break;
                case Boundary.BoundaryType.Sphere:
                    DrawSphereGizmos(boundary.sphere, position); break;
            }
        }
    }
}
