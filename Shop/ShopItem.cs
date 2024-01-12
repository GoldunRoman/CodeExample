using UnityEngine;

public abstract class ShopItem : ScriptableObject
{
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField, Range(1, 50000)] public int Price { get; private set; } 
}
