using UnityEngine;

[CreateAssetMenu(fileName = "WeaponShopItem", menuName = "Shop/WeaponShopItem", order = 0)]
public class WeaponShopItem : ShopItem
{
    [field: SerializeField] public Weapon3DModel Weapon3DModel;
    [field: SerializeField] public Sprite WeaponSprite;
    [field: SerializeField] public WeaponName WeaponName { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField] public float ReloadTime { get; private set; }
    [field: SerializeField] public bool IsForAd { get; private set; }
    [field: SerializeField] public bool IsPurchased { get; set; }

    public void Accept(IWeaponShopItemVisitor visitor)
    {
        visitor.Visit(this, ButtonStates.Inactive);
    }

    public void Initialize()
    {
        IsPurchased = WeaponStorage.IsWeaponPurchased(WeaponName);
    }
}
