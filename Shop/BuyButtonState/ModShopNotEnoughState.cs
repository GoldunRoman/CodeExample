using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModShopNotEnoughState : IBuyButtonState
{
    public void InitializeState(BuyButton buyButton, Wallet wallet)
    {
        buyButton.ActivateStateObject(ButtonStates.ModShop_NotEnough);
    }

    public void OnButtonPressed()
    {
        Debug.Log("ModShopNotEnoughState Button Pressed!");
    }
}
