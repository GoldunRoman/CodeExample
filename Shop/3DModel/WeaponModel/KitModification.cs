using UnityEngine;

[CreateAssetMenu(fileName = "Kit", menuName = "Shop/WeaponModification/Kit")]
public class KitModification : WeaponModification, IWeaponMod
{
    [field: SerializeField] public ModificationTypes ModificationType = ModificationTypes.KIT;
    [field: SerializeField] public KitModificationNames ModificationName { get; private set; }

    private void OnValidate()
    {
        if (ModificationType != ModificationTypes.KIT)
        {
            ModificationType = ModificationTypes.KIT;
            throw new System.InvalidOperationException("You cannot change the ModificationType of a KitModification to anything other than KIT.");
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