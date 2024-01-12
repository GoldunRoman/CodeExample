using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponMod
{
    public ModificationTypes GetModificationType();

    public string GetModificationName();
}
