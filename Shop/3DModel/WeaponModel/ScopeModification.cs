using UnityEngine;

[CreateAssetMenu(fileName = "Scope", menuName = "Shop/WeaponModification/Scope")]
public class ScopeModification : WeaponModification, IWeaponMod
{
    [field: SerializeField] public ModificationTypes ModificationType = ModificationTypes.SCOPE;
    [field: SerializeField] public ScopeModificationsNames ModificationName { get; private set; }

    private void OnValidate()
    {
        if (ModificationType != ModificationTypes.SCOPE)
        {
            ModificationType = ModificationTypes.SCOPE;
            throw new System.InvalidOperationException("You cannot change the ModificationType of a ScopeModification to anything other than MUZZLE.");
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
