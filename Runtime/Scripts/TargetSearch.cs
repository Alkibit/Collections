using System;
using System.Collections.Generic;
using UnityEngine;

namespace Alkibit.Collections
{
    public static class TargetSearch
    {
        private static Dictionary<string, Transform> namedObjectCache = new();

        public enum TargetType
        {
            Vector,
            Transform,
            NamedObject,
            Mouse,
        }

        [Serializable]
        public struct Target
        {
            public TargetType type;
            public Vector3 vector;
            [SerializeField]
            public Transform transform;
            public string name;

            public Vector3 position { get { return GetTargetPosition(this); } }

            public override string ToString()
            {
                switch (type)
                {
                    case TargetType.Vector:
                        return $"vector: {vector}";
                    case TargetType.Transform:
                        return $"transform: {transform.name}";
                    case TargetType.NamedObject:
                        return $"named object: {name}";
                    case TargetType.Mouse:
                        return "mouse position";
                    default:
                        return base.ToString();
                }
            }
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

        public static Vector3 GetTargetPosition(Target target)
        {
            switch (target.type)
            {
                case TargetType.Vector:
                    return target.vector;
                case TargetType.Transform:
                    return target.transform.position;
                case TargetType.NamedObject:
                    if (namedObjectCache.TryGetValue(target.name, out Transform cachedTransform))
                    {
                        return cachedTransform.position;
                    }
                    else
                    {
                        GameObject foundObject = FindGameObjectByName(target.name);
                        if (foundObject != null)
                        {
                            namedObjectCache[target.name] = foundObject.transform;
                            return foundObject.transform.position;
                        }
                        else
                        {
                            Debug.LogAssertion($"TargetSearch: No GameObject found with name '{target.name}'");
                            return Vector3.zero;
                        }
                    }
                case TargetType.Mouse:
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePosition.z = 0;
                    return mousePosition;
            }
            Debug.LogAssertion($"TargetSearch: Something went wrong searching '{target}'");
            return Vector3.zero;
        }
    }
}