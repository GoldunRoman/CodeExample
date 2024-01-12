using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonStateVisitor : IWeaponShopItemVisitor
{
    private BuyButton _buyButton;

    public BuyButtonStateVisitor(BuyButton buyButton)
    {
        _buyButton = buyButton;
    }

    public void Visit(WeaponShopItem weaponItem, ButtonStates state, bool isPurchasedForAd = false)
    {
        if (weaponItem.IsForAd && !weaponItem.IsPurchased)
        {
            _buyButton.SetState(new AdState());
            return;
        }

        if (!weaponItem.IsForAd && !weaponItem.IsPurchased)
        {
            var purchaseState = new PurchaseState();
            _buyButton.SetState(purchaseState);
            return;
        }

        switch (state)
        {
            case ButtonStates.Purchase:
                _buyButton.SetState(new PurchaseState());
                return;

            case ButtonStates.Ad:
                _buyButton.SetState(new AdState());
                return;

            case ButtonStates.ModShop_Purchase:
                _buyButton.SetState(new ModShopPurchaseState());
                return;

            case ButtonStates.ModShop_NotEnough:
                _buyButton.SetState(new ModShopNotEnoughState());
                return;

            case ButtonStates.Inactive:
                _buyButton.SetState(new InactiveState());
                return;
        }


        //Need to replase this in future
        if (WeaponStorage.IsWeaponPurchasedForAd(weaponItem.WeaponName))
        {
            _buyButton.SetState(new InactiveState());
            return;
        }

        else if (!weaponItem.IsForAd && !weaponItem.IsPurchased)
        {
            var purchaseState = new PurchaseState();
            _buyButton.SetState(purchaseState);
            return;
        }

        else if (weaponItem.IsForAd)
        {
            _buyButton.SetState(new AdState());
            return;
        }

        else
            throw new InvalidOperationException("Undefined state for BuyButton");
    }
}
