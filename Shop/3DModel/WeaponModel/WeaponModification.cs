using UnityEngine;

public class WeaponModification : ScriptableObject
{
    //Need to create their own types in future
    [field: SerializeField] public GameObject Model3DPrefab { get; private set; }
    [field: SerializeField] public Sprite UIPrefab { get; private set; }
}
