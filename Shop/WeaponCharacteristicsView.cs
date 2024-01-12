using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCharacteristicsView : MonoBehaviour
{
    [SerializeField] private ShopPanel _shopPanel;
    [SerializeField] private Image _damageFillBar;
    [SerializeField] private Image _reloadingFillBar;
    [SerializeField] private Image _fireRateFillBar;

    public void Initialize(WeaponShopItem weaponItem)
    {
        UpdateCharacteristicsView(weaponItem);
    }

    private void OnEnable()
    {
        _shopPanel.OnWeaponSelected += UpdateCharacteristicsView;
    }

    private void OnDisable()
    {
        _shopPanel.OnWeaponSelected -= UpdateCharacteristicsView;
    }

    public void UpdateCharacteristicsView(WeaponShopItem weaponItem)
    {
        float damage = (float)weaponItem.Damage / 100;
        _damageFillBar.fillAmount = damage;

        float reloadingTime = weaponItem.ReloadTime / 100;
        _reloadingFillBar.fillAmount = reloadingTime;

        float fireRate = weaponItem.FireRate / 100;
        _fireRateFillBar.fillAmount = fireRate;
    }
}
