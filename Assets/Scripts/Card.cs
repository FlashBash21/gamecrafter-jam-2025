using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    private bool _isSelected = false;
    private bool _isDragging = false;

    private Vector3 offset;

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
            transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) + offset;
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
        offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        Debug.Log(transform.InverseTransformPoint(eventData.position));
        Debug.Log(transform.position.xy());
        _isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
    }
}
