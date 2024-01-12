using UnityEngine;

public class PurchaseState : IBuyButtonState
{
    private Wallet _wallet;
    private BuyButton _buyButton;

    public void InitializeState(BuyButton buyButton, Wallet wallet)
    {
        _buyButton = buyButton;
        _wallet = wallet;

        buyButton.ActivateStateObject(ButtonStates.Purchase);

        if (!_wallet.IsEnough(_buyButton.CurrentPrice))
            buyButton.SwitchNotEnoughCoinsUI();
        else
            buyButton.SwitchNotEnoughCoinsUI(false);
    }

    public void OnButtonPressed()
    {
        if (!_wallet.IsEnough(_buyButton.CurrentPrice)) return;

        _wallet.Spend(_buyButton.CurrentPrice);
        int currCoins = _wallet.GetCurrentCoins();
        WalletStorage.SaveCoins(currCoins);

        ShopPanel.CurrentSelectedWeaponItem.IsPurchased = true;
        WeaponStorage.SavePurchasedWeapon(ShopPanel.CurrentSelectedWeaponItem);

        ChangeBuyButtonState();
    }

    private void ChangeBuyButtonState()
    {
        BuyButtonStateVisitor visitor = new(_buyButton);
        visitor.Visit(ShopPanel.CurrentSelectedWeaponItem, ButtonStates.Inactive);
    }
}
