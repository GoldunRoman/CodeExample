using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModShopPurchaseState : IBuyButtonState
{
    private BuyButton _buyButton;

    public void InitializeState(BuyButton buyButton, Wallet wallet)
    {
        buyButton.ActivateStateObject(ButtonStates.ModShop_Purchase);
        _buyButton = buyButton;
    }

    public void OnButtonPressed()
    {
        var wallet = ShopBootstrap.Wallet;
        wallet.Spend(500); //default test price

        List<WeaponModification> selectedMods = new List<WeaponModification>
        {
            ModsDataHelper.Instance.KitMod,
            ModsDataHelper.Instance.MuzzleMod,
            ModsDataHelper.Instance.ScopeMod
        };

        Weapon3DModel weapon3DModel = ShopPanel.CurrentSelectedWeaponItem.Weapon3DModel;
        weapon3DModel.UpdateModelModsInfo(selectedMods);

        BuyButtonStateVisitor visitor = new(_buyButton);
        visitor.Visit(ShopPanel.CurrentSelectedWeaponItem, ButtonStates.Inactive);
    }
}
