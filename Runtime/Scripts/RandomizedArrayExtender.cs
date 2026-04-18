using System.Collections.Generic;
using UnityEngine;

namespace Alkibit.Collections
{
    public static class RandomizedArrayExtender
    {
        public static T GetRandomItem<T>(this T[] array) => array[Random.Range(0, array.Length)];
        public static T GetRandomItem<T>(this List<T> array) => array[Random.Range(0, array.Count)];
    }
}