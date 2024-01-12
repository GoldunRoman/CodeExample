using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponStorage
{
    private static List<string> _adPurchasedWeaponsList = new(); 

    public static void SavePurchasedWeapon(WeaponShopItem weaponItem)
    {
        PlayerPrefs.SetString(weaponItem.WeaponName.ToString(), weaponItem.WeaponName.ToString());
    }

    public static void SaveAdWeapon(WeaponShopItem weaponItem)
    {
        _adPurchasedWeaponsList.Add(weaponItem.WeaponName.ToString());
    }

    public static bool IsWeaponPurchased(WeaponName weaponName)
    {
        string key = weaponName.ToString();

        if(PlayerPrefs.HasKey(key))
            return true;

        return false;
    }

    public static bool IsWeaponPurchasedForAd(WeaponName weaponName)
    {
        string name = weaponName.ToString();
        bool isContains = _adPurchasedWeaponsList.Contains(name);

        return isContains;
    }

    public static void SavePurchasedMod(WeaponShopItem weaponItem, IWeaponMod mod)
    {
        PlayerPrefs.SetString($"{weaponItem.WeaponName.ToString()}{mod.GetModificationType()}", weaponItem.WeaponName.ToString());
    }
}
