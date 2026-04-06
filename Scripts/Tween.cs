using System;
using UnityEngine;

namespace Alkibit.Collections.Tween
{
    [Serializable]
    public enum Tween
    {
        Linear,
        Logarithmic,
        Exponential,
    }
    public static class ClassTween
    {
        public static Vector3 TweenVector(Vector3 start, Vector3 target, float speed, Tween tween)
        {
            Vector3 change = Vector3.zero;
            switch (tween)
            {
                case Tween.Linear:
                    change = (target - start).normalized * speed; break;

                case Tween.Logarithmic:
                    change = (target - start) * speed; break;

                case Tween.Exponential:
                    float force = 1 / (target - start).magnitude * speed;
                    change = (target - start).normalized * force; break;
            }

            return start + change;
        }

        public static float TweenFloat(float start, float target, float speed, Tween tween)
        {
            float change = 0f;
            switch (tween)
            {
                case Tween.Linear:
                    if (target > start) change = speed;
                    else change = -speed;
                    break;

                case Tween.Logarithmic:
                    change = (target - start) * speed; break;

                case Tween.Exponential:
                    change = 1 / (target - start); break;
            }

            return start + change;
        }

        public static void TweenTransform(Transform transform, Vector3 target, float speed, Tween tween)
        {
            transform.position = TweenVector(transform.position, target, speed, tween);
        }

        public static Color TweenColor(Color start, Color target, float speed, Tween tween)
        {
            Color final = new(
                TweenFloat(start.r, target.r, speed, tween),
                TweenFloat(start.g, target.g, speed, tween),
                TweenFloat(start.b, target.b, speed, tween)
                );

            return final;
        }
    }
}
