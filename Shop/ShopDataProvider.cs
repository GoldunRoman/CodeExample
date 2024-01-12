using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShopDataProvider
{
    public static List<WeaponShopItem> AwailableWeapons = new List<WeaponShopItem>();

    public static void Initialize(ShopPanel panel)
    {
        foreach(var weaponItem in panel.AllWeaponItems)
        {
            if (weaponItem.IsPurchased)
            {
                AwailableWeapons.Add(weaponItem);
            }
        }


        Debug.Log($"Weapon {AwailableWeapons[0].WeaponName}");
        Debug.Log($"PurchasedModifications {AwailableWeapons[0].Weapon3DModel.PurchasedWeaponModifications}");
        Debug.Log($"Damage {AwailableWeapons[0].Damage}");
        Debug.Log($"Prefab {AwailableWeapons[0].Weapon3DModel.Prefab}");
    }
}
