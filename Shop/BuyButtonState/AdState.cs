using UnityEngine;

public class AdState : MonoBehaviour, IBuyButtonState
{
    private BuyButton _buyButton;

    public void InitializeState(BuyButton buyButton, Wallet wallet)
    {
        _buyButton = buyButton;
        buyButton.ActivateStateObject(ButtonStates.Ad);
    }

    public void OnButtonPressed()
    {
        //Show ad and on reward do this:

        ShopPanel.CurrentSelectedWeaponItem.IsPurchased = true;

        WeaponStorage.SavePurchasedWeapon(ShopPanel.CurrentSelectedWeaponItem);
        WeaponStorage.SaveAdWeapon(ShopPanel.CurrentSelectedWeaponItem);

        BuyButtonStateVisitor visitor = new(_buyButton);
        visitor.Visit(ShopPanel.CurrentSelectedWeaponItem, ButtonStates.Inactive, true);
    }
}
