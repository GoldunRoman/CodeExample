using TMPro;
using UnityEngine;
using DG.Tweening;


public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;

    private Wallet _wallet;
    private int _displayedCoins;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        _displayedCoins = _wallet.GetCurrentCoins();
        UpdateValueDisplay(_wallet.GetCurrentCoins());

        _wallet.CoinsChanged += OnCoinsChanged;
    }

    private void OnDestroy() => _wallet.CoinsChanged -= UpdateValueDisplay;

    private void OnCoinsChanged(int newCoinAmount) => LerpCoinsView(newCoinAmount);

    private void UpdateValueDisplay(int value) => _value.text = value.ToString();

    private void LerpCoinsView(int newCoinAmount)
    {
        DOTween.To(() => _displayedCoins, x => _displayedCoins = x, newCoinAmount, 1f).OnUpdate(() =>
        {
            UpdateValueDisplay(_displayedCoins);
        });
    }
}
