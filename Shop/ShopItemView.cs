using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    public Action<int> Click;

    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    private int _price;

    public bool IsSelected { private get; set; }

    public void Initialize(Sprite sprite, int price)
    {
        _image.sprite = sprite;
        _price = price;
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Click?.Invoke(_price);        
    }
}
