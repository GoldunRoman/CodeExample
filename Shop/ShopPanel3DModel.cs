using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel3DModel : MonoBehaviour
{
    public event Action<bool> OnSpawn;

    [SerializeField] private Transform _modelPosition;
    [SerializeField] private Rotator _rotator;
    private GameObject _currentModel;


    public void Show3DModel(WeaponShopItem item)
    {      
        if(_currentModel != null)
        {
            Destroy(_currentModel.gameObject);
        }

        _rotator.ResetRotation();

        _currentModel = Instantiate(item.Weapon3DModel.Prefab, _modelPosition);
        OnSpawn?.Invoke(item.IsPurchased);
    }
}
