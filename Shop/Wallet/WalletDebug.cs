using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class WalletDebug : MonoBehaviour
{
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        GetComponent<Button>().onClick.AddListener(AddCoins);
    }

    private void AddCoins()
    {
        _wallet.AddCoins(1000);
    }
}
