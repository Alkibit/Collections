using System;
using UnityEngine;

namespace Alkibit.Collections
{
    public static class TargetSearch
    {
        public enum TargetType
        {
            Vector,
            Transform,
            NamedObject,
            Mouse,
        }

        [Serializable]
        public class Target
        {
            public TargetType type;
            public Vector3 vector;
            [SerializeField]
            public Transform transform;
            public string name;

            public Vector3 position { get { return GetTargetPosition(this); } }
        }

        private static GameObject FindGameObjectByName(string name)
        {
            foreach (GameObject obj in UnityEngine.Object.FindObjectsByType<GameObject>())
            {
                if (obj.name == name)
                {
                    return obj;
                }
            }
            return null;
        }

        public static Vector3 GetTargetPosition(TargetType type, Vector3 vector, Transform transform, string name)
        {
            Vector3 output = Vector3.zero;

            switch (type)
            {
                case TargetType.Vector:
                    output = vector; break;
                case TargetType.Transform:
                    output = transform.position; break;
                case TargetType.NamedObject:
                    output = FindGameObjectByName(name).transform.position; break;
                case TargetType.Mouse:
                    Vector3 x = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    x.z = 0;
                    output = x; 
                    break;
            }

            return output;
        }

        public static Vector3 GetTargetPosition(Target target)
        {
            Vector3 output = Vector3.zero;

            switch (target.type)
            {
                case TargetType.Vector:
                    output = target.vector; break;
                case TargetType.Transform:
                    output = target.transform.position; break;
                case TargetType.NamedObject:
                    output = FindGameObjectByName(target.name).transform.position; break;
                case TargetType.Mouse:
                    Vector3 x = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    x.z = 0;
                    output = x;
                    break;
            }

            return output;
        }
    }
}