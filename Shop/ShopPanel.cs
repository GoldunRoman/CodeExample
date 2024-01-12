using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public event Action<WeaponShopItem> OnWeaponSelected;

    [SerializeField] private ShopPanel3DModel _shopPanel3DModel;
    [SerializeField] public List<WeaponShopItem> AllWeaponItems = new List<WeaponShopItem>();
    [SerializeField] private Transform _content;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private WeaponCharacteristicsView _weaponCharacteristicsView;  

    public static WeaponShopItem CurrentSelectedWeaponItem { get; set; }

    public void Initialize()
    {
        gameObject.SetActive(false);

        foreach (var weapon in AllWeaponItems)
        {
            weapon.Initialize();

            var weaponShopItem = Instantiate(weapon.Prefab, _content);
            var weaponShopItemView = weaponShopItem.GetComponent<ShopItemView>();

            weaponShopItemView.Initialize(weapon.WeaponSprite, weapon.Price);
            weaponShopItem.GetComponent<Button>().onClick.AddListener(() => SelectItem(weapon));
            weaponShopItemView.Click += _buyButton.UpdateText;

            var weaponItemData = weaponShopItem.GetComponent<WeaponItemData>();
            weaponItemData.Initialize(weapon);
            weaponItemData.Click += SelectWeaponItem;
        }

        ShopDataProvider.Initialize(this);

        CurrentSelectedWeaponItem = AllWeaponItems[0];

        if (AllWeaponItems.Count > 0)
        {
            SelectItem(AllWeaponItems[0]);
            _weaponCharacteristicsView.Initialize(AllWeaponItems[0]);
        }

    }

    private void SelectItem(WeaponShopItem weaponItem)
    {
        var visitor = new BuyButtonStateVisitor(_buyButton);
        weaponItem.Accept(visitor);       
    }

    public void SelectWeaponItem(WeaponShopItem weaponItem)
    {
        CurrentSelectedWeaponItem = weaponItem;
        Debug.Log(CurrentSelectedWeaponItem.WeaponName);

        //_shopPanel3DModel.Show3DModel(weaponItem);

        OnWeaponSelected?.Invoke(weaponItem);
        _shopPanel3DModel.Show3DModel(weaponItem);
    }
}
