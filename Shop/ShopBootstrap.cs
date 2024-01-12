using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBootstrap : MonoBehaviour
{
    [SerializeField] private bool _deleteAllPlayerPrefsData = false;

    [SerializeField] private ShopPanel _view;
    [SerializeField] private WalletView _walletView;
    [SerializeField] private WalletDebug _walletDebug;
    [SerializeField] private BuyButton _buyButton;

    public static Wallet Wallet;

    void Start()
    {
        if(_deleteAllPlayerPrefsData)
            PlayerPrefs.DeleteAll();

        InitializeWallet();
        _view.Initialize();        
    }

    private void InitializeWallet()
    {
        Wallet = new Wallet();

        _buyButton.Initialize(Wallet);
        _walletView.Initialize(Wallet);
        _walletDebug.Initialize(Wallet);
    }
}
