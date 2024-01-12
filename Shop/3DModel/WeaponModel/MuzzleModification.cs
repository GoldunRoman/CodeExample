using UnityEngine;

[CreateAssetMenu(fileName = "Muzzle", menuName = "Shop/WeaponModification/Muzzle")]
public class MuzzleModification : WeaponModification, IWeaponMod
{
    [field: SerializeField] public ModificationTypes ModificationType = ModificationTypes.MUZZLE;
    [field: SerializeField] public MuzzleModificationNames ModificationName { get; private set; }

    private void OnValidate()
    {
        if (ModificationType != ModificationTypes.MUZZLE)
        {
            ModificationType = ModificationTypes.MUZZLE;
            throw new System.InvalidOperationException("You cannot change the ModificationType of a SightModification to anything other than MUZZLE.");
        }
    }

    public ModificationTypes GetModificationType()
    {
        return ModificationType;
    }

    public string GetModificationName()
    {
        return ModificationName.ToString();
    }
}
