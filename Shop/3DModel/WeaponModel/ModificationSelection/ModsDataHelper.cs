using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModsDataHelper : MonoBehaviour
{
    #region Singleton
    private static ModsDataHelper _instance;
    public static ModsDataHelper Instance {  get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public WeaponModification KitMod { get; set; }
    public WeaponModification MuzzleMod { get; set; }
    public WeaponModification ScopeMod { get; set; }
}
