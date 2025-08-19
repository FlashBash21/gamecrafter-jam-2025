using System;
using UnityEngine;
using Random = UnityEngine.Random;

static class RandomExtentions
{
    // Fisher-Yates array shuffling algorithm
    public static void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            (array[k], array[n]) = (array[n], array[k]);
        }

    }
}
