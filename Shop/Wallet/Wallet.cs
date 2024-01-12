using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Wallet
{
    public event Action<int> CoinsChanged;
    private int _coins;

    public Wallet() 
    {
        _coins = WalletStorage.LoadCoins();
    } 


    public void AddCoins(int coins)
    {
        if (coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

        _coins += coins;
        WalletStorage.SaveCoins(_coins);
        CoinsChanged?.Invoke(_coins);
    }

    public int GetCurrentCoins() => _coins;

    public bool IsEnough(int itemPrice)
    {
        if (itemPrice < 0)
            throw new ArgumentOutOfRangeException(nameof(itemPrice));

        return _coins >= itemPrice;
    }

    public void Spend(int itemPrice)
    {
        if (itemPrice < 0)
            throw new ArgumentOutOfRangeException(nameof(itemPrice));

        _coins -= itemPrice;
        WalletStorage.SaveCoins(_coins);
        CoinsChanged?.Invoke(_coins);
    }
}
