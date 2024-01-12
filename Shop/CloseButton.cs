using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseButton : MonoBehaviour
{
    [SerializeField] private ShopPanel _shopPanel;

    private Button _closeButton;

    private void OnEnable()
    {
        if(_closeButton == null)
            _closeButton = GetComponent<Button>();

        _closeButton.onClick.AddListener(CloseShopPanel);
        _closeButton.onClick.AddListener(Destroy3DModel);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(CloseShopPanel);
        _closeButton.onClick.RemoveListener(Destroy3DModel);
    }

    private void CloseShopPanel()
    {
        _shopPanel.gameObject.SetActive(false);
    }

    private void Destroy3DModel()
    {
        try
        {
            var model = ModsDataHelper.Instance.gameObject;
            Destroy(model);
        }
        catch(NullReferenceException e)
        {
            Debug.LogError($"CloseButton::Destroy3DModel NullReferenceException in try-catch");
            return;
        }
    }
}
