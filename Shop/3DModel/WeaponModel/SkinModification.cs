using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Shop/WeaponModification/Skin")]
public class SkinModification : WeaponModification, IWeaponMod
{
    [field: SerializeField] public ModificationTypes ModificationType = ModificationTypes.SKIN;
    [field: SerializeField] public KitModificationNames ModificationName { get; private set; }

    private void OnValidate()
    {
        if (ModificationType != ModificationTypes.SKIN)
        {
            ModificationType = ModificationTypes.SKIN;
            throw new System.InvalidOperationException("You cannot change the ModificationType of a SkinModification to anything other than SKIN.");
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
