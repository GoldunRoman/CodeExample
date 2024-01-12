using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItemData : MonoBehaviour
{
    public Action<WeaponShopItem> Click;
    public WeaponShopItem WeaponShopItem { get; set; }

    [SerializeField] private Button _button;

    public void Initialize(WeaponShopItem weapon)
    {
        WeaponShopItem = weapon;
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Click?.Invoke(WeaponShopItem);
    }
}
