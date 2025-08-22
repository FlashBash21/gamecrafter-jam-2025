using System;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
public class Deck : MonoBehaviour
{
    [SerializeField]
    private Card _model; //temporary

    [SerializeField]
    private Card _cardObject;
    public int MAX_DECK_SIZE { get; } = 52;

    private int[] _cards;
    private int _size; // current number of cards in deck

    void Start()
    {
        _model.enabled = false;
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
        _size = MAX_DECK_SIZE;
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            int next_card = _cards[--_size];
            //Draw a card.
            Card drawn_card = Instantiate<Card>(_cardObject);
            drawn_card.enabled = true;
            drawn_card.SetValue(next_card);
            drawn_card.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
    }

    private void UpdateVisual()
    {

    }
}
