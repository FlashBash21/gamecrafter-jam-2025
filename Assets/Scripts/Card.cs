using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Multiplayer.Center.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private TextMeshPro _cardText;
    private bool _isSelected = false;
    private bool _isDragging = false;

    private Vector3 _offset;
    private Dictionary<int, String> _textConversionDict;

    public int Value { get; private set; } = 0;

    private void Start()
    {
        _textConversionDict = new Dictionary<int, string>();
        _textConversionDict.Add(0, "");
        _textConversionDict.Add(1, "A");
        _textConversionDict.Add(11, "J");
        _textConversionDict.Add(12, "Q");
        _textConversionDict.Add(13, "K");
    }

    private void Update()
    {
        if (_isSelected)
        {
            _spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Card-Hover");
        }
        else
        {
            _spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Blank-Card");
        }

        if (_isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) + _offset;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Value += 1;
            if (Value > 13)
            {
                Value = 0;
            }
        }

        UpdateCard();
    }

    private void UpdateCard()
    {
        if (_textConversionDict.TryGetValue(Value, out String txt))
        {
            _cardText.text = txt;
        }
        else
        {
            _cardText.text = Value.ToString();
        }
    }

    private void SelectCard()
    {
        _isSelected = true;
    }

    private void DeselectCard()
    {
        _isSelected = false;
    }

    public void SetValue(int val)
    {
        Value = val;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SelectCard();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DeselectCard();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        Debug.Log(transform.InverseTransformPoint(eventData.position));
        Debug.Log(transform.position.xy());
        _isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
    }
}
