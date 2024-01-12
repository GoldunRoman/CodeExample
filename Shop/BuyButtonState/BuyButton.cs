using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public GameObject PurchaseStateView;
    public GameObject AdStateView;
    public GameObject ModShopPurchaseState;
    public GameObject ModShopNotEnoughState;

    [SerializeField] private List<GameObject> _stateObjects;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _noCoinsUI;

    private Wallet _wallet;
    private IBuyButtonState _currentState;

    public int CurrentPrice 
    {
        get 
        { 
            return Int32.Parse(_priceText.text); 
        } 
    }

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void SetState(IBuyButtonState newState)
    {
        _currentState = newState;
        _currentState.InitializeState(this, _wallet);
    }

    public void OnButtonPressed() => _currentState?.OnButtonPressed();


    public void UpdateText(int price) => _priceText.text = price.ToString();

    public void SwitchNotEnoughCoinsUI(bool isActivate = true)
    {
        _noCoinsUI.SetActive(isActivate);
    } 

    public void ActivateStateObject(ButtonStates state)
    {
        switch (state)
        {
            case ButtonStates.Purchase:
                foreach(var stateObj in _stateObjects)
                    stateObj.SetActive(false);
                _stateObjects[(int)ButtonStates.Purchase].SetActive(true);
                break;

            case ButtonStates.Ad:
                foreach (var stateObj in _stateObjects)
                    stateObj.SetActive(false);
                _stateObjects[(int)ButtonStates.Ad].SetActive(true);
                break;

            case ButtonStates.ModShop_Purchase:
                foreach (var stateObj in _stateObjects)
                    stateObj.SetActive(false);
                _stateObjects[(int)ButtonStates.ModShop_Purchase].SetActive(true);
                break;

            case ButtonStates.ModShop_NotEnough:
                foreach (var stateObj in _stateObjects)
                    stateObj.SetActive(false);
                _stateObjects[(int)ButtonStates.ModShop_NotEnough].SetActive(true);
                break;

            case ButtonStates.Inactive:
                foreach (var stateObj in _stateObjects)
                    stateObj.SetActive(false);
                break;
        }
    }
}

public enum ButtonStates
{
    Purchase,
    Ad,
    ModShop_Purchase,
    ModShop_NotEnough,
    Inactive
}
