using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MuzzleSelection : MonoBehaviour
{
    [SerializeField] private List<MuzzleItem> _awailableBarrels = new List<MuzzleItem>();
    [SerializeField] private Image _barrelSprite;

    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private List<GameObject> _selectionUI;

    private ShopPanel3DModel _shopPanel;
    private BuyButton _buyButton;
    private int _currentBarrel = 0;

    private void OnEnable()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        _shopPanel = FindFirstObjectByType<ShopPanel3DModel>();
        _buyButton = FindFirstObjectByType<BuyButton>();

        ShowModification(_currentBarrel);
        _nextButton.onClick.AddListener(OnNextClick);
        _previousButton.onClick.AddListener(OnPreviousClick);

        _shopPanel.OnSpawn += HandleOnSpawnEvent;

        var wallet = ShopBootstrap.Wallet;
        wallet.CoinsChanged += BuyButtonViewVisit;
    }

    private void OnDestroy()
    {
        _nextButton.onClick.RemoveListener(OnNextClick);
        _previousButton.onClick.RemoveListener(OnPreviousClick);

        _shopPanel.OnSpawn -= HandleOnSpawnEvent;

        var wallet = ShopBootstrap.Wallet;
        wallet.CoinsChanged -= BuyButtonViewVisit;
    }

    public void OnNextClick()
    {
        BuyButtonViewVisit(WalletStorage.LoadCoins());

        SwitchSpriteForward();
    }

    public void OnPreviousClick()
    {
        BuyButtonViewVisit(WalletStorage.LoadCoins());

        SwitchSpriteBack();
    }

    private void HandleOnSpawnEvent(bool isPurchased)
    {
        if (!isPurchased)
        {
            foreach (var child in _selectionUI)
            {
                child.SetActive(false);
            }
            return;
        }

        foreach (var child in _selectionUI)
        {
            child.SetActive(true);
        }
    }

    private void ShowModification(int i)
    {
        foreach (var mod in _awailableBarrels)
        {
            mod.gameObject.SetActive(false);
        }
        _awailableBarrels[i].gameObject.SetActive(true);
        _barrelSprite.sprite = _awailableBarrels[i].Mod.UIPrefab;

        SendDataToHelper(_awailableBarrels[i].Mod);
    }

    private void BuyButtonViewVisit(int currentCoins)
    {
        int modificationPrice = 500; //debugDefaultValue

        BuyButtonStateVisitor visitor = new(_buyButton);

        if (currentCoins < modificationPrice)
        {
            visitor.Visit(ShopPanel.CurrentSelectedWeaponItem, ButtonStates.ModShop_NotEnough);
            return;
        }

        visitor.Visit(ShopPanel.CurrentSelectedWeaponItem, ButtonStates.ModShop_Purchase);
    }

    private void SwitchSpriteForward()
    {
        if (_currentBarrel >= _awailableBarrels.Count - 1)
        {
            _currentBarrel = 0;
            ShowModification(_currentBarrel);
            return;
        }

        _currentBarrel++;
        ShowModification(_currentBarrel);
    }

    private void SwitchSpriteBack()
    {
        if (_currentBarrel == 0)
        {
            _currentBarrel = _awailableBarrels.Count - 1;
            ShowModification(_currentBarrel);
            return;
        }

        _currentBarrel--;
        ShowModification(_currentBarrel);
    }
    private void SendDataToHelper(WeaponModification modification)
    {
        ModsDataHelper.Instance.MuzzleMod = modification;
    }
}
