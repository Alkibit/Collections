using System;
using UnityEngine;

namespace Alkibit.Collections
{
    [Serializable]
    public class CurvePoint
    {
        public float time;
        public float value;
    }

    [Serializable]
    public class Curve
    {
        public AnimationCurve curve;
        public CurvePoint[] points;

        [ContextMenu("Set Curve")]
        public void SetCurve()
        {
            curve = new();
            foreach (CurvePoint p in points)
            {
                curve.AddKey(p.time, p.value);
            }
        }
    }
}
