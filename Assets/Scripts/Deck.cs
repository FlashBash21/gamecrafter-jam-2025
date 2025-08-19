using System;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class Deck : MonoBehaviour
{
    public int MAX_DECK_SIZE { get; } = 52;

    private int[] _cards;

    void Start()
    {
        // DEBUG
        Random.InitState(1);

        _cards = new int[MAX_DECK_SIZE];
        int accum = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int val = 1; val <= 13; val++, accum++)
            {
                _cards[accum] = val;
            }
        }
        Debug.Log(ArrayToString<int>(_cards));
        RandomExtentions.Shuffle<int>(_cards);
        Debug.Log(ArrayToString<int>(_cards));
    }

    private String ArrayToString<T>(T[] array)
    {
        StringBuilder stringBuilder = new StringBuilder(array.Length * 3);
        stringBuilder.Append("[");
        foreach (T i in array)
        {
            stringBuilder.Append(i.ToString());
            stringBuilder.Append(',');
        }
        stringBuilder.Replace(',', ']', stringBuilder.Length - 1, 1);
        return stringBuilder.ToString();
    }

    void Update()
    {
        
    }
}
