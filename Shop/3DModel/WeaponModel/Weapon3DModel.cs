using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon3DModel", menuName = "Shop/Shop3DModel/Weapon3DModel", order = 1)]
public class Weapon3DModel : Shop3DModel
{
    [field: SerializeField] public WeaponName WeaponName { get; private set; }
    [field: SerializeField] public List<WeaponModification> PurchasedWeaponModifications { get; set; }

    public void UpdateModelModsInfo(List<WeaponModification> selectedModifications)
    {
        PurchasedWeaponModifications = new();

        foreach (var current in selectedModifications)
            PurchasedWeaponModifications.Add(current);
    }
}
